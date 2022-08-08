using Ghostscript.NET;
using Ghostscript.NET.Processor;
using GUI;
using ImageMagick;
using OtherItems;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using ProgramConfiguration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Przetwarzanie_plików_PDF {
    internal static class ProgramOperations {
        internal static int _tempFileCounter;

        /// <summary>
        /// Zmiana pliku na PDF
        /// </summary>
        /// <param name="file">ściezka do pliku</param>
        /// <returns>Zwraca ścieżkę do pliku pdf lub nowo utworzonego pliku tymczasowego</returns>
        public static string ConvertFileToPdf(string file) {
            string filePath = "";
            string extension = ExtensionCheck(file);
            switch (extension) {
                case "PDF":
                    filePath = file;
                    break;
                case "IMAGE":
                    filePath = ImageToPdf(file);
                    break;
                case "WORD":
                    filePath = WordToPdf(file);
                    break;
                case "EXCEL":
                    filePath = ExcelToPdf(file);
                    if (filePath == null) {
                        return null;
                    }
                    break;
                default:
                    return null;
                    break;
            }
            return filePath;
        }
        public static string ConvertFileToPdf(DataGridViewRow row) {
            string filePath = row.Cells[1].Value.ToString();
            return ConvertFileToPdf(filePath);
        }

        /// <summary>
        /// Połączenie plików z konsoli
        /// </summary>
        /// <param name="fileList">Lista ścieżek do plików które mają zostać dołączone</param>
        /// <param name="outputFolder">Miejsce zapisu pliku</param>
        /// <param name="coverDocument">Link do okładki jeżeli istnieje</param>
        public static void MergeFiles(List<string> fileList, string outputFolder, string coverDocument) {
            string extension = ExtensionCheck(coverDocument);
            string filePath = ProgramOperations.ConvertFileToPdf(coverDocument);
            if (filePath == null) {
                PdfDocument pdfDocument = PdfReader.Open(filePath);
                MergeFiles(fileList, outputFolder, pdfDocument);
            } else {
                Console.WriteLine("Błąd podczas zamiany okładki na PDF\nNie zostanie dodana.!");
            }

        }

        /// <summary>
        /// Dodanie numeru strony
        /// </summary>
        /// <param name="page">Obiekt strony</param>
        /// <param name="number">Dodawany numer</param>
        public static void AddNumber(PdfPage page, int number) {
            //ustawienie obiektu czcionki
            Font f = new Font(ProgramSettings.NumberFont, ProgramSettings.NumberHeight, FontStyle.Regular);

            XFontStyle xStyle;
            if (ProgramSettings.NumberBold && ProgramSettings.NumberItalic) {
                xStyle = XFontStyle.BoldItalic;
            } else if (ProgramSettings.NumberBold) {
                xStyle = XFontStyle.Bold;
            } else if (ProgramSettings.NumberItalic) {
                xStyle = XFontStyle.Italic;
            } else {
                xStyle = XFontStyle.Regular;
            }
            XFont Xfont = new XFont(f.FontFamily.Name, ProgramSettings.NumberHeight, xStyle);
            double prop = Convert.ToDouble((double)page.Width / page.Width.Millimeter);
            int X, Y;
            X = Convert.ToInt32(ProgramSettings.NumberPositionX * prop);
            Y = Convert.ToInt32(ProgramSettings.NumberPositionY * prop);

            if (page.Orientation == PdfSharp.PageOrientation.Portrait) {

                if (!ProgramSettings.NumberAlignleft) {
                    X = Convert.ToInt32(page.Width - (double)X);
                }

                if (!ProgramSettings.NumberAlignUp) {
                    Y = Convert.ToInt32(page.Height - (double)Y);
                }
            } else {

                if (ProgramSettings.NumberAlignleft) {
                    X = Convert.ToInt32(page.Width - (double)X);
                }

                if (ProgramSettings.NumberAlignUp) {
                    Y = Convert.ToInt32(page.Height - (double)Y);
                }
            }

            XPoint p = new XPoint(X, Y);
            XColor xc = XColor.FromArgb(
                ProgramSettings.NumbersColor[0],
                ProgramSettings.NumbersColor[1],
                ProgramSettings.NumbersColor[2]);

            XBrush br = new XSolidBrush(xc);
            XGraphics graphics = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Append);
            graphics.DrawString(number.ToString(), Xfont, br, p);
            graphics.Dispose();
        }

        /// <summary>
        /// Dodanie znaku wodnego do strony
        /// </summary>
        /// <param name="page"></param>
        public static void AddWatemark(PdfPage page) {
            //ustawienie obiektu czcionki
            Font f = new Font(ProgramSettings.WatermarkFont, ProgramSettings.WatermarkHeight, FontStyle.Regular);

            XFontStyle xStyle;
            if (ProgramSettings.WatermarkBold && ProgramSettings.WatermarkItalic) {
                xStyle = XFontStyle.BoldItalic;
            } else if (ProgramSettings.WatermarkBold) {
                xStyle = XFontStyle.Bold;
            } else if (ProgramSettings.WatermarkItalic) {
                xStyle = XFontStyle.Italic;
            } else {
                xStyle = XFontStyle.Regular;
            }
            XFont Xfont = new XFont(f.FontFamily.Name, ProgramSettings.WatermarkHeight, xStyle);

            double prop = Convert.ToDouble((double)page.Width / page.Width.Millimeter);
            int X, Y;

            X = Convert.ToInt32(ProgramSettings.WatermarkPositionX * prop);
            Y = Convert.ToInt32(ProgramSettings.WatermarkPositionY * prop);

            XPoint p = new XPoint(X, Y);
            XColor xc = XColor.FromArgb(
                ProgramSettings.WatermarkColor[0],
                ProgramSettings.WatermarkColor[1],
                ProgramSettings.WatermarkColor[2]);
            var format = new XStringFormat();
            format.Alignment = XStringAlignment.Near;
            format.LineAlignment = XLineAlignment.Near;

            XBrush br = new XSolidBrush(xc);
            XGraphics graphics = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Append);
            graphics.DrawString(ProgramSettings.WatermarkText, Xfont, br, p, format);
            graphics.Dispose();
        }


        /// <summary>
        /// Połączenie plików z konsoli
        /// </summary>
        /// <param name="fileList">Lista ścieżek do plików które mają zostać dołączone</param>
        /// <param name="outputFolder">Miejsce zapisu pliku</param>
        /// <param name="coverDocument">Obiekt PDF okładki</param>
        public static void MergeFiles(List<string> fileList, string outputFile, PdfDocument coverDocument = null) {
            //Rozpocznij łączenie w osobnym procesie
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            long FileCount, CurrentFileCounter, PageCount, CurrentPageCounter;
            long pages = 0;
            FileCount = fileList.Count;
            CurrentFileCounter = 1;
            string filePath = "";
            string currentFile = "";
            int PageNumerator = ProgramSettings.StartNumber;
            int Pagefrom = ProgramSettings.StartPage;

            //Ustaw Wartość paska postępu
            try {
                //Stwórz nowy dokument i przypisz do niego okładkę
                PdfDocument outputDocument = new PdfDocument();
                if (coverDocument != null) {
                        string name = Path.Combine(ProgramSettings.TEMP_FOLDER, _tempFileCounter.ToString() + "_okladka");
                        coverDocument.Save(name);
                        PdfDocument cover = PdfReader.Open(name, PdfDocumentOpenMode.Import);
                        outputDocument.AddPage(cover.Pages[0]);

                        if (ProgramSettings.watermark && ProgramSettings.WatemarkOnCover) {
                            ProgramOperations.AddWatemark(outputDocument.Pages[0]);
                        }

                        if (ProgramSettings.pageNumeration && ProgramSettings.CoverNumeation) {
                            ProgramOperations.AddNumber(outputDocument.Pages[0], PageNumerator);
                            PageNumerator++;
                        }

                        CurrentFileCounter++;
                        pages++;
                    }
                    //Dodaj do pliku wynikowego wszystkie elementy z listy plików
                    foreach (string item in fileList) {
                        currentFile = Path.GetFileName(item);
                        //Aktualizacja informacji o postępnie
                        Console.WriteLine("Łączenie pliku nr " + CurrentFileCounter.ToString());

                        string extension = ExtensionCheck(item);

                        //Sprawdzenie pliku i w razie konieczności konwersja na PDF
                        filePath = ProgramOperations.ConvertFileToPdf(item);
                        if (filePath == null) {
                            Console.WriteLine($"Bład podczas zamiany pliku {currentFile} na PDF");
                            continue;
                        }

                        //Otworzenie dołączanego pliku
                        PdfDocument mergingDoc = PdfReader.Open(filePath, PdfDocumentOpenMode.Import);

                        //Aktualizacja informacji
                        PageCount = mergingDoc.PageCount;
                        Console.WriteLine("Dzołączanie pliku: " + currentFile);

                        CurrentPageCounter = 0;
                        Console.WriteLine("Dołączono stron: ");
                        Console.WriteLine(" ");
                        //Dodawanie stron z pliku do pliku wynikowego
                        foreach (PdfPage page in mergingDoc.Pages) {
                            ClearCurrentConsoleLine();
                            outputDocument.Pages.Add(page);
                            if (ProgramSettings.watermark) {
                                ProgramOperations.AddWatemark(outputDocument.Pages[(int)pages]);
                            }
                            if (ProgramSettings.pageNumeration && (pages + 1) >= Pagefrom) {
                                ProgramOperations.AddNumber(outputDocument.Pages[(int)pages], PageNumerator);
                                PageNumerator++;
                            }
                            CurrentPageCounter++;
                            Console.Clear();
                            Console.WriteLine($"Dołączono stronę {CurrentPageCounter} z {PageCount}");
                            Console.WriteLine($"Łączna ilość stron {pages}");
                            pages++;
                        }

                        //Zamykanie pliku dołączanego 
                        mergingDoc.Close();
                        mergingDoc.Dispose();
                        CurrentFileCounter++;
                    }

                    //Jeżeli użytkownik wybrał kompresję wykonaj ją, w innym przypadku zapisz plik wynikowy
                    if (ProgramSettings.compression) {
                        //Zapisz obecny plik wynikowy do folderu z plikami czasowymi i zamknij go
                        string PdfFileName = _tempFileCounter.ToString() + "_ImageTemp.pdf";
                        string tempPath = Path.Combine(ProgramSettings.TEMP_FOLDER, PdfFileName);
                        _tempFileCounter++;
                        outputDocument.Save(tempPath);
                        outputDocument.Close();
                        outputDocument.Dispose();

                        //Rozpocznij optymalizację
                        OptimalizePDFFile(tempPath, outputFile);
                        Console.WriteLine("Operacja pomyślna");
                        Console.ReadLine();

                } else {
                        //Zapisz plik bez optymalizacji
                        outputDocument.Save(outputFile);
                        outputDocument.Close();
                        outputDocument.Dispose();
                        Console.WriteLine("Operacja pomyślna");
                        Console.ReadLine();
                    }
            } catch (Exception ex) {
                //W przypadku wystąpienia błędu poinformuj o nim użytkownika
                if (ex.Message.Contains("protected with an encryption")) {
                    Console.WriteLine(
                        $"Plik: {currentFile} zawiera szyfrowanie nieobsługiwane przez ten program!" +
                        $"\nProszę usuń hasło z pliku i spróbuj ponownie!");
                } else {
                    Console.WriteLine(
                        $"Podczas próby dołączenia pliku {currentFile} wystąpił nieznany błąd\n {ex.Message}");
                }
            }

            //Usuń pliki tymczasowe
            try {
                ProgramOperations.ClearTempFile();
            } catch (Exception) {
                Console.WriteLine("Błąd podczas usuwania plików czasowych!\nUsuń je ręcznie z folderu 'temp'");
            }
        }

        /// <summary>
        /// Sprawdź czy podany plik jest obsługiwany przez program
        /// </summary>
        /// <param name="filePath">Ścieżka do pliku</param>
        public static string ExtensionCheck(string filePath) {
            string extension = Path.GetExtension(filePath);
            if (extension == ".pdf")
                return "PDF";
            else if (extension == ".jpg" || extension == ".bmp" || extension == ".png" || extension == ".tiff")
                return "IMAGE";
            else if ((extension == ".doc" || extension == ".docx" || extension == ".docm") && ProgramSettings.isWordInstall)
                return "WORD";
            else if ((extension == ".xls" || extension == ".xlsx" || extension == ".xls" || extension == ".xlsm") && ProgramSettings.isExcelInstall)
                return "EXCEL";
            else
                return null;
        }
        /// <summary>
        /// Kompresja pliku PDF według wskazań uzykowanika
        /// </summary>
        /// <param name="fileInput">Ścieżka do chwilowo zapisanego pliku</param>
        /// <param name="fileOutput">Ścieżka do pliku docelowego</param>
        public static void OptimalizePDFFile(string fileInput, string fileOutput, MainWindow mw = null) {
            //Ustaw widoczność grupy informującej o procesie kompresji
            if (mw != null) {
                mw.GsProcessingStart();
            }
            if (ProgramSettings.isWindowedApplication) {
                Console.WriteLine("Trwa optymalizacja pliku...");
            }
            //Wykorzystując GhostScript dokonaj kompresji pliku uwzględniając wybrane parametry
            GhostscriptVersionInfo ver = new GhostscriptVersionInfo(ProgramSettings.GS_DLL_FILE);

            GhostscriptPipedOutput gsPipedOutput = new GhostscriptPipedOutput();
            string outputPipeHandle = "%handle%" + int.Parse(gsPipedOutput.ClientHandle).ToString("X2");


            using (GhostscriptProcessor processor = new GhostscriptProcessor(ver)) {
                List<string> switches = new List<string>();
                switches.Add("-empty");
                switches.Add("-dQUIET");
                switches.Add("-dSAFER");
                switches.Add("-dBATCH");
                switches.Add("-dNOPAUSE");
                switches.Add("-dNOPROMPT");
                switches.Add("-sDEVICE=pdfwrite");
                switches.Add("-dPDFSETTINGS=/" + ProgramSettings.PdfPrinterSettings);
                switches.Add("-dEmbedAllFonts=true");
                switches.Add("-dSubsetFonts=true");
                switches.Add("-dColorImageDownsampleType=/Bicubic");
                switches.Add("-dColorImageResolution=" + ProgramSettings.ImageResolution.ToString());
                switches.Add("-dGrayImageDownsampleType=/Bicubic");
                switches.Add("-dGrayImageResolution=" + ProgramSettings.ImageResolution.ToString());
                switches.Add("-dMonoImageDownsampleType=/Bicubic");
                switches.Add("-dMonoImageResolution=" + ProgramSettings.ImageResolution.ToString());
                switches.Add("-o" + outputPipeHandle);
                switches.Add("-q");
                switches.Add("-f");
                switches.Add(fileInput);
                try {
                    processor.StartProcessing(switches.ToArray(), null);
                    byte[] gsOutpuData = gsPipedOutput.Data;
                    File.WriteAllBytes(fileOutput, gsOutpuData);
                    if (mw != null) {
                        mw.GsSuccessProcessed();
                    }
                } catch (Exception ex) {
                    if (mw != null) {
                        mw.GsErrorDiuringProcessing(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Uzyskaj obraz z pliku pdf
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static async Task<Image> GetImageFromFile(string fileName, int pageNumber = 0) {
            try {
                string ghDir = ProgramSettings.GS_DLL_DIR;
                MagickNET.SetGhostscriptDirectory(ghDir);
                var settings = new MagickReadSettings();
                settings.Density = new Density(300, 300);
                settings.FrameIndex = pageNumber;
                settings.FrameCount = 1;
                Image IIM = null;
                MemoryStream ms = new MemoryStream();
                using (var img = new MagickImageCollection()) {
                    img.Read(fileName, settings);
                    img.Write(ms, MagickFormat.Jpg);
                    //img.Write(ms,MagickFormat.Png);
                    return System.Drawing.Image.FromStream(ms);

                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Usuń pliki tymczasowe
        /// </summary>
        public static void ClearTempFile() {
            string temp = Path.Combine(ProgramSettings.ProgramPath, "temp");
            if (Directory.Exists(temp)) {
                DirectoryInfo di = new DirectoryInfo(temp);
                di.Attributes = FileAttributes.Normal;
                foreach (FileInfo fi in di.GetFiles()) {

                    File.SetAttributes(fi.FullName, FileAttributes.Normal);
                    File.Delete(fi.FullName);
                }
            }
        }

        /// <summary>
        /// Przekonwertuj pliki graficzne na plik pdf
        /// Przekonwertowane pliki zostaną chwilowo zapisane w folderze 'temp'
        /// </summary>
        /// 
        private static string ImageToPdf(string v) {
            PdfDocument doc = new PdfDocument();
            doc.Pages.Add(new PdfPage());
            XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
            XImage img = XImage.FromFile(v);

            xgr.DrawImage(img, 0, 0);
            string PdfFileName = _tempFileCounter.ToString() + "_ImageTemp.pdf";


            string PdfFilepath = Path.Combine(ProgramSettings.TEMP_FOLDER, PdfFileName);
            doc.Save(PdfFilepath);
            doc.Close();
            doc.Dispose();
            _tempFileCounter++;
            return PdfFilepath;
        }

        /// <summary>
        /// Przekonwertuj pliki Word na plik pdf
        /// Przekonwertowane pliki zostaną chwilowo zapisane w folderze 'temp'
        /// </summary>
        /// 
        private static string WordToPdf(string v) {
            string PdfFileName = _tempFileCounter.ToString() + "_OfficeTemp.pdf";
            string PdfFilepath = Path.Combine(ProgramSettings.TEMP_FOLDER, PdfFileName);
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

            word.Visible = false;
            word.ScreenUpdating = false;

            var doc = word.Documents.Open(v);
            doc.Activate();
            doc.SaveAs2(PdfFilepath, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
            doc.Close();
            doc = null;
            word.Quit();
            word = null;
            return PdfFilepath;
        }

        /// <summary>
        /// Przekonwertuj plik Excela na pdf
        /// </summary>
        /// <param name="v"> Lokalizacja pliku excela</param>
        private static string ExcelToPdf(string v) {
            string PdfFileName = _tempFileCounter.ToString() + "_OfficeTemp.pdf";
            string PdfFilepath = Path.Combine(ProgramSettings.TEMP_FOLDER, PdfFileName);
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Visible = false;
            excel.ScreenUpdating = false;

            var wb = excel.Workbooks.Open(v, 0, true);
            wb.Activate();
            var wsCount = wb.Worksheets.Count;
            if (wsCount > 1) {
                List<string> sheets = new List<string>();
                foreach (Microsoft.Office.Interop.Excel.Worksheet sht in wb.Worksheets) {
                    sheets.Add(sht.Name);
                }
                string res;
                //Wybierz arkusz do wydrukowania w okienku
                if (ProgramSettings.isWindowedApplication) {
                    string title = "Wybierz arkusz dla pliku: " + Path.GetFileName(v);
                    InputBox inbx = new InputBox(title, sheets.ToArray());
                    res = inbx.GetResults();
                    if (inbx.InputBoxResults == InputBoxResults.OK) {
                        Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[res];
                        ws.Activate();
                        ws.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, PdfFilepath);
                        wb.Close();
                        return PdfFilepath;
                    } else if (inbx.InputBoxResults == InputBoxResults.PrintAll) {
                        wb.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, PdfFilepath);
                        wb.Close();
                        return PdfFilepath;
                    } else {
                        wb.Close();
                        return null;
                    }
                    //Wybierz arkusz do wydrukowania w konsoli
                } else {
                    Console.WriteLine("Wybierz numer arkusza do dołączenia:");
                    string options = "1. Drukuj wszystkie";
                    int counter = 2;
                    foreach (string s in sheets) {
                        options += $"{counter.ToString()}. {s}";
                    }
                    Console.WriteLine(options);
                    int sResults;
                    //Próba zamiany odczytanej wartości na numer
                    try {
                        sResults = Convert.ToInt32(Console.ReadLine());
                    } catch (Exception) {
                        Console.WriteLine("Wprowadzona wartość musi być liczbą! Plik zostanie pominięty.");
                        return null;
                    }

                    //Sprawdzenie czy wartośc mieści sie w zakresie
                    if (sResults <= 0 || sResults > sheets.Count + 1) {
                        Console.WriteLine("Wprowadzona wartość musi mieścić sie w zakrsie! Plik zostanie pominięty.");
                        return null;
                    }
                    //Operacja dla wybrania opcji druku wszystkich arkuszy
                    if (sResults == 1) {
                        wb.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, PdfFilepath);
                        wb.Close();
                        return PdfFilepath;
                        //Operacja dla wybiru wydruku konkretnego arkusza
                    } else {
                        res = sheets[sResults - 2];
                        Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[res];
                        ws.Activate();
                        ws.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, PdfFilepath);
                        wb.Close();
                        return PdfFilepath;
                    }
                }
            }
            // W shoroszycie jest tylko jeden arkusz
            wb.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, PdfFilepath);
            wb.Close();
            wb = null;
            excel.Quit();
            excel = null;
            return PdfFilepath;
        }

        //Wyczysczczenie linii
        public static void ClearCurrentConsoleLine() {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
