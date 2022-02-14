using BarcodeLib;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Przetwarzanie_plików_PDF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMode {
    internal class CoverEditInConsole {
        public PdfDocument CoverDoc = null;
        private List<string> FontsCollecion;
        private XGraphics gfx;
        private PdfPage page;
        /// <summary>
        /// Otwarcie okładki ze ściezki
        /// </summary>
        public CoverEditInConsole(string path)
            {
            string filePath = ProgramOperations.ConvertFileToPdf(path);
            if (filePath != null) {
                PdfDocument pdfDoc = PdfReader.Open(path, PdfDocumentOpenMode.Import);
                CoverDoc = new PdfDocument();
                CoverDoc.AddPage(pdfDoc.Pages[0]);
                pdfDoc.Close();
                InMenu();
            } else {
                Console.WriteLine("Bład podczas konswersji okładki do formatu PDF");
            }
        }

        /// <summary>
        /// Otwarcie okładki wcześniej zedytowanej
        /// </summary>
        /// <param name="doc"></param>
        public CoverEditInConsole(PdfDocument doc) {
            CoverDoc = doc;
            InMenu();
        }
        private void InMenu() {
            //Wczytanie czcionek systemowych
            FontsCollecion = new List<string>();
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies;
            fontFamilies = installedFontCollection.Families;
            foreach (FontFamily family in fontFamilies) {
                FontsCollecion.Add(family.Name);
            }

            while (true) {
                ShowEditMenu();
                Console.Write("\nWybierz opcje:");
                try {
                    int number = Convert.ToInt32(Console.ReadLine());
                    switch (number) {
                        case 1:
                            AddCodeBar();
                            break;
                        case 2:
                            AddImage();
                            break;
                        case 3:
                            AddText();
                            break;
                        case 4:
                            return;
                            break;
                        default:
                            Console.WriteLine("Błędna wartość");
                            return;
                    }
                } catch {
                    Console.WriteLine("Wpisano niepoprawną cyfrę!");
                }

            }

        }
        private void ShowEditMenu() {
            string menu = "Edycja okładki\n" +
                "1. Dodaj kod kreskowy\n" +
                "2. Dodaj obraz\n" +
                "3. Dodaj tekst\n" +
                "4. Zapisz i zamknij";
            Console.Clear();
            Console.WriteLine(menu);
        }

        /// <summary>
        /// Dodawanie kodu kreskowego z poziomu konsoli
        /// </summary>
        private void AddCodeBar() {
            Console.Clear();
            Console.WriteLine("Wpisz następujące parametry po przecinku: ");
            Console.WriteLine("Tekst kodu, Szerokość [mm], Wysokość [mm], Pozycja od lewej w [mm], Pozycja od góry w [mm]");
            string[] parametry = Console.ReadLine().Split(',');

            //Sprawdzenie parametrów
            if (parametry.Length != 5) {
                Console.WriteLine("Pominięto parametr!");
                ShowEditMenu();
                return;
            }
            PdfPage page = CoverDoc.Pages[0];
            double prop = Convert.ToDouble((double)page.Width / page.Width.Millimeter);
            Barcode b = new Barcode();
            try {
                b = new Barcode(parametry[0], TYPE.CODE128B);
            } catch (Exception) {
                Console.WriteLine("Użyto niedozwolonych znaków!");
                Console.ReadLine();
                return;
            }

            //Parametry kodu kreskowego
            b.IncludeLabel = true;
            b.AlternateLabel = parametry[0];
            b.LabelPosition = LabelPositions.BOTTOMCENTER;
            int[] imgSize;
            try {
                imgSize = new int[]{
                Convert.ToInt32(Convert.ToDouble(parametry[1]) * prop),
                Convert.ToInt32(Convert.ToDouble(parametry[2]) * prop),
                Convert.ToInt32(Convert.ToDouble(parametry[3]) * prop),
                Convert.ToInt32(Convert.ToDouble(parametry[4]) * prop)
                };

            } catch (Exception) {
                Console.WriteLine("Błędna wartosć rozmiaru lub położenia kodu");
                Console.ReadLine();
                return;
            }

            Image img;
            //Próba utworzenia kodu z tekstu i podanych wymiarów
            try {
                img = b.Encode(TYPE.CODE128B, parametry[0], Color.Black, Color.White, imgSize[0], imgSize[1]);
            } catch (Exception ex) {
                Console.WriteLine("Wybrany rozmiar kodu kreskowego jezt zbyt mały dla tak długiego tekstu!");
                Console.ReadLine();
                return;
            }


            //Dodanie kodu kreskowego na dokument

            XGraphics graphics = XGraphics.FromPdfPage(page);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            XImage xImg = XImage.FromStream(ms);
            try {
                graphics.DrawImage(xImg, imgSize[2], imgSize[3], imgSize[0], imgSize[1]);
                Console.WriteLine("Pomyślnie dodano element");
                graphics.Dispose();
                Console.ReadLine();
                return;
            } catch (Exception) {
                graphics.Dispose();
                Console.WriteLine("Błąd poczas dodawania kodu na stronę!");
                Console.ReadLine();
                return;
            }

        }

        private void AddText() {
            Console.Clear();
            Console.WriteLine("Dodawanie Tekstu");
            Console.WriteLine("Podaj następujące parametry po średniku:");
            Console.WriteLine("\nTekst \nWysokość Tekstu \nPozycja od lewej w [mm] \nPozycja od góry w [mm]\n" +
                "Opcjonalnie: Kolor: R ; G ; B (domyślny 0;0;0)\n" +
                "Opcjonalnie: Czcionka (domyślna Arial) z dopiskiem -b dla pogrubienia lub -i pochylenia");
            string[] parametry = Console.ReadLine().Split(';');

            if (!(parametry.Length == 4 || parametry.Length == 7 || parametry.Length == 8)) {
                Console.WriteLine("Wprowadzono błędną ilośc parametrów");
                Console.ReadLine();
                return;
            }
            PdfPage page = CoverDoc.Pages[0];
            //Sprawdzenie czcionki
            try {
                string font = "Arial";
                bool Bold = false, Italic = false;
                if (parametry.Length == 8) {
                    font = parametry[7];
                    if (font.Contains("-b")) {
                        Bold = true;
                        font = font.Replace("-b", "");
                    }
                    if (font.Contains("-i")) {
                        Italic = true;
                        font = font.Replace("-i", "");
                    }
                    if (!FontsCollecion.Contains(font, StringComparer.CurrentCultureIgnoreCase)) {
                        Console.WriteLine("Czcionka nie rozpoznana!");
                        Console.ReadLine();
                        return;
                    }
                }
                uint Height = 0;
                try {
                    Height = Convert.ToUInt32(parametry[1]);

                } catch {
                    Console.WriteLine("Nieprawidłowa wysokość czionki!");
                }

                //ustawienie obiektu czcionki
                Font f = new Font(font, Height, FontStyle.Regular);

                XFontStyle xStyle;
                if (Bold && Italic) {
                    xStyle = XFontStyle.BoldItalic;
                } else if (Bold) {
                    xStyle = XFontStyle.Bold;
                } else if (Italic) {
                    xStyle = XFontStyle.Italic;
                } else {
                    xStyle = XFontStyle.Regular;
                }

                XFont Xfont = new XFont(f.FontFamily.Name, Height, xStyle);
                double prop = Convert.ToDouble((double)page.Width / page.Width.Millimeter);
                int X, Y;
                //Sprawdzenie położenia
                try {
                    X = Convert.ToInt32(Convert.ToDouble(parametry[2]) * prop);
                    Y = Convert.ToInt32(Convert.ToDouble(parametry[3]) * prop);
                } catch (Exception) {
                    Console.WriteLine("Błędna lokalizacja tekstu");
                    Console.ReadLine();
                    return;
                }
                XPoint p = new XPoint(X, Y);
                XColor xc = XColor.FromArgb(0, 0, 0);

                //Sprawdzenie koloru
                if (parametry.Length > 4) {
                    try {
                        xc = XColor.FromArgb(Convert.ToInt32(parametry[4]),
                            Convert.ToInt32(parametry[5]),
                            Convert.ToInt32(parametry[6]));
                    } catch (Exception) {
                        Console.WriteLine("Nieprawidlowy kolor!");
                        Console.ReadLine();
                        return;
                    }
                }

                XBrush br = new XSolidBrush(xc);

                XGraphics graphics = XGraphics.FromPdfPage(page);
                graphics.DrawString(parametry[0], Xfont, br, p);
                graphics.Dispose();
                Console.WriteLine("Pomyślnie dodano tekst!");
                Console.ReadLine();
            } catch (Exception) {
                Console.WriteLine("Nie udało się dodać tekstu!");
            }

        }

        private void AddImage() {
            Console.Clear();
            Console.WriteLine("Dodawanie Obrazu");
            Console.WriteLine("Podaj sciezke do obrazu");
            string path = Console.ReadLine();
            Image img = null;
            try {
                img = Image.FromFile(path);
            } catch {
                Console.WriteLine("Błędna ścieżka");
            }
            Console.WriteLine("Podaj położenie obrazka: \n" +
                "Szerokość , Wysokość , Położenie od lewej, Położenie od góry [mm]");
            string[] param = Console.ReadLine().Split(',');

            //Sprawdzenie wymiarów
            int[] dimensions;
            try {
                dimensions = new int[] {
                Convert.ToInt32(param[0]),
                Convert.ToInt32(param[1]),
                Convert.ToInt32(param[2]),
                Convert.ToInt32(param[3])};
            } catch (Exception) {
                Console.Write("Błędne wymiary");
                Console.ReadLine();
                return;
            }

            //Próba dodania obrazu
            PdfPage page = CoverDoc.Pages[0];
            XGraphics graphics = XGraphics.FromPdfPage(page);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            XImage xImg = XImage.FromStream(ms);
            try {
                graphics.DrawImage(xImg, dimensions[2], dimensions[3], dimensions[0], dimensions[1]);
                Console.WriteLine("Pomyślnie dodano element");
                graphics.Dispose();
                Console.ReadLine();
                return;
            } catch (Exception) {
                Console.WriteLine("Błąd poczas dodawania kodu na stronę!");
                graphics.Dispose();
                Console.ReadLine();
                return;
            }

        }

    }
}
