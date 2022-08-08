/**
 * GUI do edycji okładki
 */
using BarcodeLib;
using ControlManager;
using ImageMagick;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using ProgramConfiguration;
using Przetwarzanie_plików_PDF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using Przetwarzanie_plikow_PDF.GUI;

namespace GUI {
    public partial class PdfEditForm : Form {
        #region Inicjalizacja okna

        private bool IsMultiplepageEdit = false;
        public double multipilerX;
        public double multipilerY;
        private List<Control> InsertingElements;
        private string docPath;
        private double pageWidth;
        private double pageHeight;
        private double PROP_PIX_MM;
        private InsertingTextBox selectedText;
        private bool _deleting;
        public PdfDocument document;
        private Control InsertingElement;
        private Dictionary<int, EditingPageSettings> PageSettings;
        private double _currentZoom = 1;
        private int _currentPage;
        public PdfEditForm() { }

        /// <summary>
        /// Tworzenie edytra do edycji plików zawierających więcej niż jedną stronę
        /// </summary>
        /// <param name="file">ścieżka do pliku pdf</param>
        /// <param name="multipage">informacje o tym czy jest to edycja wielu stron</param>
        public PdfEditForm(string file, bool multipage) : this(file) {
            if (multipage) {
                IsMultiplepageEdit = true;
                PdfDocument doc = PdfReader.Open(docPath, PdfDocumentOpenMode.Import);
                for (int i = 1; i <= doc.Pages.Count - 1; i++) {
                    document.AddPage(doc.Pages[i]);
                    EditingPageSettings pge = new EditingPageSettings(i);
                    pge.originalOrientation = doc.Pages[i].Orientation;
                    PageSettings.Add(i, pge);
                }
                doc.Close();
                doc.Dispose();

                grpPageNumbers.Visible = true;
                txtPageNumber.Text = "1 z " + document.PageCount;
                IsMultiplepageEdit = true;
            }
        }
        /// <summary>
        /// Tworzenie edytora do edycji pojedynczej strony
        /// </summary>
        /// <param name="file"></param>
        public PdfEditForm(string file) {
            //Zapis wybranej scieżki
            docPath = file;
            InitializeComponent();
            grpPageNumbers.Visible = false;
            //Listy przechowujące dodawane elementy
            InsertingElements = new List<Control>();
            InsertingElement = null;

            PageSettings = new Dictionary<int, EditingPageSettings>();
            EditingPageSettings pge = new EditingPageSettings(0);
            PageSettings.Add(0, pge);
            PageSettings[0].InsertingElements = InsertingElements;
            //Odczytanie parametrów dokumentu
            PdfDocument doc = PdfReader.Open(docPath, PdfDocumentOpenMode.Import);
            document = new PdfDocument();
            document.AddPage(doc.Pages[0]);
            doc.Close();
            doc.Dispose();
            ShowPage(0);

            //Pozostałe elementy
            ControlMoverOrResizer.WorkType = ControlMoverOrResizer.MoveOrResize.Move;

            //Uzupełnienie czcionek i rozmiarów tekstu
            grpTextOptions.Visible = false;
            for (int i = 6; i < 128; i++) {
                cboTextSize.Items.Add(i.ToString());
                i++;
            }
            cboTextSize.SelectedIndex = 1;

            ProgramSettings.FillComboBoxWithSupportedFonts(cboFonts);
            cboFonts.Text = "Arial";
        }
        private async Task ShowPage(int PageNumber) { 

            foreach (Control c in InsertingElements) {
                c.Visible = false;
            }
            if (IsMultiplepageEdit) {
                InsertingElements = PageSettings[_currentPage].InsertingElements;
                foreach (Control c in InsertingElements) {
                    c.Visible = true;
                }
            }

            PdfPage pge = document.Pages[PageNumber];
            Debug.WriteLine(pge.Orientation);

            //Obliczenie wielkości piksela
            PROP_PIX_MM = pge.Width / pge.Width.Millimeter;
            Image imgFFile;
            if (PageSettings[_currentPage].PageImage == null) {
                //Wczytanie pliku jako obraz i wyświetlenie
                imgFFile = await ProgramOperations.GetImageFromFile(docPath, _currentPage).ConfigureAwait(false);
                if (imgFFile.Width > imgFFile.Height) {
                    pge.Orientation = PdfSharp.PageOrientation.Landscape;
                } else {
                    pge.Orientation = PdfSharp.PageOrientation.Portrait;
                }
                picDocument.BackgroundImage = imgFFile;
                PageSettings[_currentPage].PageImage = imgFFile;
                switch (PageSettings[_currentPage].PageRotation) {
                    case 90:
                        imgFFile.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 180:
                        imgFFile.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 270:
                        imgFFile.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case 0:
                        break;
                }
            } else {
                imgFFile = PageSettings[_currentPage].PageImage;
                picDocument.BackgroundImage = imgFFile;
            }
            pageWidth = pge.Width.Value;
            pageHeight = pge.Height.Value;
            grpDocument.Width = (int)pageWidth;
            grpDocument.Height = (int)pageHeight;



            int curWidth = grpDocument.Width;
            int curHeight = grpDocument.Height;
            ResizeControlByPrecent(grpDocument, _currentZoom);

            int newWidth = grpDocument.Width;
            int newHeight = grpDocument.Height;
            if (_currentZoom != PageSettings[_currentPage].LastZoom) {
                PageSettings[_currentPage].LastZoom = _currentZoom;
            }

            PageSettings[_currentPage].PageXMultipiler = (double)grpDocument.Width / pge.Width;
            PageSettings[_currentPage].PageYMultipiler = (double)grpDocument.Height / pge.Height;
            txtPageNumber.Text = $"{_currentPage + 1} z {document.PageCount}";
            grpInCompressing.Visible = false;
        }
        /// <summary>
        /// Wczytanie parametrów programu zdefiniowanych przez użytkownika w ustawieniach
        /// </summary>
        private void EdycjaPDF_Load(object sender, EventArgs e) {
            string file = Path.Combine(ProgramSettings.ProgramPath, "BarcodeLabelSizes.txt");
            if (File.Exists(file)) {
                string[] elements = File.ReadAllLines(file);
                cboBarSize.DataSource = elements;
            }
            if (ProgramSettings.BarcodePrefix != null) {
                txtCodeBarText.Text = ProgramSettings.BarcodePrefix;
            }

        }

        #endregion

        #region Dodawanie elementów
        /// <summary>
        /// Dodaj kod kreskowy
        /// </summary>
        private void btnCodeBar_Click(object sender, EventArgs e) {
            ChceckIfTextIsSelected();

            if (string.IsNullOrEmpty(txtCodeBarText.Text)) {
                MessageBox.Show("Wprowadź tekst dla tworzonego kodu kreskowego", "Puste pole");
                return;
            }
            if (string.IsNullOrEmpty(cboBarSize.Text)) {
                MessageBox.Show("Wybierz rozmiar kodu!");
                return;
            }

            Barcode b;
            try {
                b = new Barcode(txtCodeBarText.Text, TYPE.CODE128B);
            } catch (Exception) {
                MessageBox.Show("Użyto niedozwolonych znaków!");
                return;
            }

            //Parametry kodu kreskowego
            b.IncludeLabel = true;
            b.AlternateLabel = txtCodeBarText.Text;
            b.LabelPosition = LabelPositions.BOTTOMCENTER;
            string[] size = cboBarSize.Text.Split('x');
            int[] imgSize;
            try {
                //Rozmiar kodu
                imgSize = new int[] {
                Convert.ToInt32(size[0]),
                Convert.ToInt32(size[1]),
            };
            } catch {
                MessageBox.Show("Błędny rozmiar papieru!");
                return;
            }

            //Przeliczenie mm na piksele
            imgSize[0] = Convert.ToInt32((double)imgSize[0] * PROP_PIX_MM);
            imgSize[1] = Convert.ToInt32((double)imgSize[1] * PROP_PIX_MM);
            Image img;

            //Próba utworzenia kodu z tekstu i podanych wymiarów
            try {
                img = b.Encode(TYPE.CODE128B, txtCodeBarText.Text, System.Drawing.Color.Black, System.Drawing.Color.White, imgSize[0], imgSize[1]);
            } catch (Exception ex) {
                MessageBox.Show("Wybrany rozmiar kodu kreskowego jezt zbyt mały dla tak długiego tekstu!");
                return;
            }

            //Dodanie kodu kreskowego na obecny formularz
            int ImgWidthOrg = img.Width;
            double CODEBAR_PROP = (double)img.Width / (double)img.Height;
            PictureBox picBox = new PictureBox();
            picBox.BackgroundImage = img;
            picBox.BackgroundImageLayout = ImageLayout.Stretch;
            picBox.Location = new Point(10, 10);
            picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //Określenie wielości kodu proporcjonalnie do wyświetlanej strony
            double ImageWidthInPix = (ImgWidthOrg);
            ImageWidthInPix *= grpDocument.Width;
            double ImageWidth = Convert.ToInt32(ImageWidthInPix / pageWidth);
            double ImageHeight = ImageWidth / CODEBAR_PROP;
            picBox.Size = new Size((int)ImageWidth, (int)ImageHeight);

            //Umieszczenie kodu na obrazie
            grpDocument.Controls.Add(picBox);
            picBox.BringToFront();


            //Dodanie obsługi usuwania, przesuwania i umieszczania
            ControlMoverOrResizer.Init(picBox);
            ControlMoverOrResizer.ProportionalResize = true;
            picBox.Click += new System.EventHandler(this.DeleteItem);
            picBox.Click += new System.EventHandler(this.SelectionSettings);
            picBox.Click += new System.EventHandler(this.StopInserting);

            //Dodanie kodu do listy elementów do dodania podczas zapisu
            InsertingElements.Add(picBox);

            //Ustawienie kodu jako obecnie dodawany element
            InsertingElement = picBox;
        }


        /// <summary>
        /// Dodanie tekstu do okładki
        /// </summary>
        private void btnAddText_Click(object sender, EventArgs e) {
            //Usunięcie zaznaczenia z obecnie zaznaczonego tekstu
            ChceckIfTextIsSelected();

            //Włączenie widoczności opcji Tekstu
            grpTextOptions.Visible = true;

            //Dodanie elementu typu TextBox jako dodawany tekst
            InsertingTextBox txB = new InsertingTextBox();
            txB.Multiline = true;
            txB.Text = "Wpisz tekst.";
            bool t = SetStyle(txB, ControlStyles.SupportsTransparentBackColor, true);
            txB.BackColor = System.Drawing.Color.Transparent;
            txB.Location = new Point(10, 10);
            grpDocument.Controls.Add(txB);
            txB.BringToFront();
            txB.TargetTextHeight = Convert.ToInt32(cboTextSize.Text);
            //Dodanie możliwości przesuwania, usuwania, umieszczania i wyświetlania opcji tekstu
            ControlMoverOrResizer.Init(txB);
            ControlMoverOrResizer.CheckSize = 1;
            txB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxMouseClick);
            txB.Click += new System.EventHandler(this.DeleteItem);
            txB.Click += new System.EventHandler(this.SelectionSettings);
            txB.Click += new System.EventHandler(this.StopInserting);
            txB.TextChanged += new System.EventHandler(this.TextChanged);

            //Ustawienie parametrów TextBoxa
            txB.TextAlign = HorizontalAlignment.Center;
            System.Drawing.Font f = new System.Drawing.Font(cboFonts.Text, Convert.ToInt32(cboTextSize.Text));
            txB.Font = f;
            selectedText = txB;

            //Dostosowanie wielkości tekstu do rozmiarów wyświetlania dokumentu
            ResizeTextToView(txB);

            //Dodanie elementu do listy elementów do dodania
            InsertingElements.Add(txB);

            //Ustawianie elementu jako obecnie dodawany
            InsertingElement = txB;
        }
        public static bool SetStyle(Control c, ControlStyles Style, bool value) {
            bool retval = false;
            Type typeTB = typeof(Control);
            System.Reflection.MethodInfo misSetStyle = typeTB.GetMethod("SetStyle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (misSetStyle != null && c != null) { misSetStyle.Invoke(c, new object[] { Style, value }); retval = true; }
            return retval;
        }
        /// <summary>
        /// Dodanie obrazka do okładki
        /// </summary>
        private void btnAddImage_Click(object sender, EventArgs e) {
            ChceckIfTextIsSelected();
            //Otwórz okno wyboru pliku
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "Pliki graficzne|*.jpg;*.bmp;*.png;*.tiff";
                ofd.Title = "Wybierz zdjęcie do wstawienia!";
                ofd.FilterIndex = 0;
                ofd.Multiselect = false;
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    //Dodaj wybrane zdjęcie do obiektu typu Image
                    Image img = Image.FromFile(ofd.FileName);

                    //Wstaw zdjęcie do obiektu typu pictureBox
                    PictureBox picBox = new PictureBox();
                    picBox.BackgroundImage = img;
                    picBox.BackgroundImageLayout = ImageLayout.Stretch;

                    //Określ rozmiary obrazu i jeżeli są za duże dostosuj je do wielkości strony
                    if (img.Width < grpDocument.Width && img.Height < grpDocument.Height) {
                        picBox.Width = img.Width;
                        picBox.Height = img.Height;
                    } else {
                        double prop = (double)img.Width / (double)img.Height;
                        picBox.Width = grpDocument.Width / 2;
                        picBox.Height = Convert.ToInt32((double)picBox.Width / prop);
                    }

                    //Dodaj obiekt na stonrę
                    picBox.Location = new Point(10, 10);
                    grpDocument.Controls.Add(picBox);
                    picBox.BringToFront();

                    //Ustaw możliwość przesuwania/rozciągania
                    ControlMoverOrResizer.Init(picBox);
                    picBox.Click += new System.EventHandler(this.SelectionSettings);
                    picBox.Click += new System.EventHandler(this.StopInserting);

                    //Dodaj element do listy dodwanych elementów
                    InsertingElements.Add(picBox);

                    //Ustawianie elementu jako obecnie dodawany
                    InsertingElement = picBox;
                }
            }
        }

        #endregion

        #region Modyfikacja elementów

        /// <summary>
        /// Dodanie nowego rozmiaru kodu kreskowego
        /// </summary>
        private void AddBarcodeSize_Click(object sender, EventArgs e) {
            BarcodeSize bs = new BarcodeSize(cboBarSize);
            bs.StartPosition = FormStartPosition.CenterParent;
            bs.ShowDialog();
        }

        /// <summary>
        /// Usuwanie obecnie wybranego rozmiaru z listy
        /// </summary>
        private void btnRemoveBarcodeSize_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Czy napewno usunąć obecnie wybrany rozmiar?", "Pytanie", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes) {
                string file = Path.Combine(ProgramSettings.ProgramPath, "BarcodeLabelSizes.txt");
                string[] lines = File.ReadAllLines(file);
                List<string> list = new List<string>();
                list.AddRange(lines);
                list.Remove(cboBarSize.Text);
                lines = list.ToArray();
                cboBarSize.DataSource = lines;
                if (File.Exists(file)) {
                    File.WriteAllText(file, String.Empty);
                }
                File.WriteAllLines(file, lines);
            }
        }

        /// <summary>
        /// Ustawienie koloru zaznaczonego tektu
        /// </summary>
        private void btnColor_Click(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                btnColor.BackColor = colorDialog1.Color;
                selectedText.ForeColor = colorDialog1.Color;
            }
        }

        /// <summary>
        /// Przybliżenie widoku o 10%
        /// </summary>
        private void btnZoomIn_Click(object sender, EventArgs e) {
            int curWidth = grpDocument.Width;
            int curHeight = grpDocument.Height;
            ResizeControlByPrecent(grpDocument, 1.1F);

            int newWidth = grpDocument.Width;
            int newHeight = grpDocument.Height;
            _currentZoom = _currentZoom * 1.1F;
            if (IsMultiplepageEdit) {
                for (int i = 0; i < PageSettings.Count; i++) {
                    ResizeAllItemsToNewDocumentViewSize(curWidth, newWidth, curHeight, newHeight, 1.1F, PageSettings[i].InsertingElements);
                }
            } else {
                ResizeAllItemsToNewDocumentViewSize(curWidth, newWidth, curHeight, newHeight, 1.1F, InsertingElements);
            }
            PageSettings[_currentPage].LastZoom = _currentZoom;
        }

        /// <summary>
        /// Oddalenie widoku o 10%
        /// </summary>
        private void btnZoomOut_Click(object sender, EventArgs e) {
            int curWidth = grpDocument.Width;
            int curHeight = grpDocument.Height;
            ResizeControlByPrecent(grpDocument, 0.9F);

            int newWidth = grpDocument.Width;
            int newHeight = grpDocument.Height;
            _currentZoom = _currentZoom * 0.9F;
            if (IsMultiplepageEdit) {
                for (int i = 0; i < PageSettings.Count; i++) {
                    ResizeAllItemsToNewDocumentViewSize(curWidth, newWidth, curHeight, newHeight, 0.9F, PageSettings[i].InsertingElements);
                }
            } else {
                ResizeAllItemsToNewDocumentViewSize(curWidth, newWidth, curHeight, newHeight, 0.9F, InsertingElements);
            }
            PageSettings[_currentPage].LastZoom = _currentZoom;

        }

        /// <summary>
        /// Zmień wielkość kontrolki
        /// </summary>
        private void ResizeControlByPrecent(Control c, double prc) {
            int curWidth = c.Width;
            int curHeight = c.Height;
            int newWidth = Convert.ToInt32(((double)curWidth * prc));
            double properties = (double)curWidth / (double)curHeight;
            int newHeight = Convert.ToInt32((double)newWidth / properties);
            c.Width = newWidth;
            c.Height = newHeight;
        }

        /// <summary>
        /// Dostosuj wielkość elementów TextBox do rozmiarów wyświetlanego papieru
        /// </summary>
        private void ResizeTextToView(InsertingTextBox txb) {
            double prop = (double)pageWidth / (double)grpDocument.Width;
            int TextSize = Convert.ToInt32(Convert.ToDouble(txb.TargetTextHeight) / prop);
            TextSize = (int)((double)TextSize / 1.5);
            txb.Font = new System.Drawing.Font(
                    txb.Font.FontFamily,
                        TextSize, txb.Font.Style);
            System.Drawing.Size size;
            if (string.IsNullOrEmpty(txb.Text)) {
                size = TextRenderer.MeasureText("Puste pole", txb.Font);
            } else {
                size = TextRenderer.MeasureText(txb.Text, txb.Font);
            }
            //txb.Size = size;
            txb.Width = size.Width + 20;
            int lines = txb.Lines.Count();
            txb.Height = txb.Font.Height * (lines + 1);
            txb.Height -= (int)((double)txb.Font.Height * 0.5F);

        }

        /// <summary>
        /// Dostosuj wielkość wszystkich dodwanaych elementów do nowej wielkości wyświetlania strony
        /// </summary>
        /// <param name="oldX">Stara szerokość</param>
        /// <param name="newX">Nowa szerokość</param>
        /// <param name="oldY">Stara wysokość</param>
        /// <param name="newY">Nowa wysokość</param>
        /// <param name="size">Procent zmiany</param>
        private void ResizeAllItemsToNewDocumentViewSize(int oldX, int newX, int oldY, int newY, double size, List<Control> controls) {
            double propX = (double)oldX / (double)newX;
            double propY = (double)oldY / (double)newY;

            //Zmiana rozmiaru dodawanych obrazków
            foreach (Control cnt in controls) {
                if (cnt is PictureBox) {
                    int newPosX = Convert.ToInt32((double)cnt.Location.X / propX);
                    int newPosY = Convert.ToInt32((double)cnt.Location.Y / propY);
                    cnt.Location = new Point(newPosX, newPosY);
                    ResizeControlByPrecent(cnt, size);
                } else if (cnt is InsertingTextBox) {
                    InsertingTextBox txB = (InsertingTextBox)cnt;
                    int newPosX = Convert.ToInt32((double)cnt.Location.X / propX);
                    int newPosY = Convert.ToInt32((double)cnt.Location.Y / propY);
                    cnt.Location = new Point(newPosX, newPosY);
                    int CurrentTextHeight = txB.TargetTextHeight;
                    ResizeTextToView(txB);
                }
            }
        }

        /// <summary>
        /// Zmiana czcionki tekstu
        /// </summary>
        private void FontCheck(object sender, EventArgs e) {
            if (selectedText != null) {
                System.Drawing.Font f;
                if (chkBold.Checked & chkItalic.Checked) {
                    f = new System.Drawing.Font(selectedText.Font, FontStyle.Bold | FontStyle.Italic);
                } else if (chkBold.Checked) {
                    f = new System.Drawing.Font(selectedText.Font, FontStyle.Bold);
                } else if (chkItalic.Checked) {
                    f = new System.Drawing.Font(selectedText.Font, FontStyle.Italic);
                } else {
                    f = new System.Drawing.Font(selectedText.Font, FontStyle.Regular);
                }
                selectedText.Font = f;
                System.Drawing.Size size = TextRenderer.MeasureText(selectedText.Text, selectedText.Font);
                selectedText.Size = size;
                ResizeTextToView(selectedText);
            }
        }

        //Usuwanie wskazanego elementu
        private void DeleteItem(object c, EventArgs e) {
            if (_deleting) {
                if (c is InsertingTextBox) {
                    InsertingTextBox tb = (InsertingTextBox)c;
                    InsertingElements.Remove(tb);
                    tb.Dispose();
                } else if (c is PictureBox) {
                    PictureBox pb = (PictureBox)c;
                    InsertingElements.Remove(pb);
                    pb.Dispose();
                }
            }
        }
        #endregion

        #region Zapisyanie

        /// <summary>
        /// Zapisywanie okładki jako nowy plik pdf
        /// </summary>
        private void btnSaveDoc_Click(object sender, EventArgs e) {

            SaveFileDialog fbd = new SaveFileDialog();
            fbd.Filter = "Pliki pdf|*.pdf";
            fbd.Title = "Wybierz lokalizację do zapisu pliku";
            fbd.FilterIndex = 0;
            if (fbd.ShowDialog() == DialogResult.OK) {
                string folder = fbd.FileName;
                SaveChanges(true, folder);
                System.Diagnostics.Process.Start(new ProcessStartInfo(folder) { UseShellExecute = true });
                this.Close();
            }
        }

        /// <summary>
        /// Zapisywanie zmian bez tworzenia nowego pliku
        /// </summary>
        private void btnSaveChanges_Click(object sender, EventArgs e) {
            SaveChanges(false);
            this.Close();
        }
        /// <summary>
        /// Zapisanie zmodyfikowanego pliku
        /// </summary>
        /// <param name="saveAsPdf"></param>
        /// <param name="folder"></param>
        private void SaveChanges(bool saveAsPdf, string folder = "") {
            multipilerX = (double)grpDocument.Width / pageWidth;
            multipilerY = (double)grpDocument.Height / pageHeight;
            if (IsMultiplepageEdit) {
                for (int i = 0; i < document.Pages.Count; i++) {
                    PdfPage pge = document.Pages[i];
                    pge.Orientation = PageSettings[i].originalOrientation;
                    SaveItemsOnPage(pge, PageSettings[i].InsertingElements, i);
                }
            } else {
                PdfPage page = document.Pages[0];
                SaveItemsOnPage(page, InsertingElements, 0);
            }
            try {
                if (saveAsPdf) {
                    document.Save(folder);
                }
            } catch (Exception ex) {
                MessageBox.Show("Błąd podczas zapisu pliku!");
            }
        }

        /// <summary>
        /// Zapisanie wszystkich dodawanych elementów na stronę
        /// </summary>
        /// <param name="page">Strona dokumentu</param>
        /// <param name="elements">Wstawiane elementy</param>
        private void SaveItemsOnPage(PdfPage page, List<Control> elements, int numerator) {
            XGraphics graphics = XGraphics.FromPdfPage(page);
            double proporties = (double)grpDocument.Height / pageHeight;
            foreach (Control cont in elements) {
                if (cont is PictureBox) {
                    int elemLocationX, elemLocationY, elemWidth, elemHeight;
                    if (IsMultiplepageEdit) {
                        elemLocationX = Convert.ToInt32(cont.Location.X / PageSettings[numerator].PageXMultipiler);
                        elemLocationY = Convert.ToInt32(cont.Location.Y / PageSettings[numerator].PageYMultipiler);
                        elemWidth = Convert.ToInt32(cont.Width / PageSettings[numerator].PageXMultipiler);
                        elemHeight = Convert.ToInt32(cont.Height / PageSettings[numerator].PageYMultipiler);
                    } else {
                        elemLocationX = Convert.ToInt32(cont.Location.X / multipilerX);
                        elemLocationY = Convert.ToInt32(cont.Location.Y / multipilerY);
                        elemWidth = Convert.ToInt32(cont.Width / multipilerX);
                        elemHeight = Convert.ToInt32(cont.Height / multipilerY);
                    }
                    Image img = cont.BackgroundImage;
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    XImage xImg = XImage.FromStream(ms);
                    graphics.DrawImage(xImg, elemLocationX, elemLocationY, elemWidth, elemHeight);
                } else if (cont is InsertingTextBox) {

                    InsertingTextBox txB = (InsertingTextBox)cont;
                    System.Drawing.Font f = new System.Drawing.Font(
                  txB.Font.FontFamily,
                  txB.TargetTextHeight, txB.Font.Style);

                    XFontStyle xStyle;
                    if (f.Bold && f.Italic) {
                        xStyle = XFontStyle.BoldItalic;
                    } else if (f.Bold) {
                        xStyle = XFontStyle.Bold;
                    } else if (f.Italic) {
                        xStyle = XFontStyle.Italic;
                    } else {
                        xStyle = XFontStyle.Regular;
                    }

                    XFont font = new XFont(f.FontFamily.Name, txB.TargetTextHeight, xStyle);

                    int elemLocationX, elemLocationY;
                    if (IsMultiplepageEdit) {
                        elemLocationX = Convert.ToInt32(cont.Location.X / PageSettings[numerator].PageXMultipiler);
                        elemLocationY = Convert.ToInt32(cont.Location.Y / PageSettings[numerator].PageYMultipiler);
                    } else {
                        elemLocationX = Convert.ToInt32(cont.Location.X / multipilerX);
                        elemLocationY = Convert.ToInt32(cont.Location.Y / multipilerY);
                    }
                    XPoint p = new XPoint(elemLocationX, elemLocationY);
                    System.Drawing.Color c = txB.ForeColor;
                    XColor xc = XColor.FromArgb(c.R, c.G, c.B);
                    XBrush br = new XSolidBrush(xc);
                    XTextFormatter formatter = new XTextFormatter(graphics);
                    var TxtSize = TextRenderer.MeasureText(txB.Text, txB.Font);
                    switch (txB.TextAlign) {
                        case HorizontalAlignment.Left:
                            formatter.Alignment = XParagraphAlignment.Left;
                            break;
                        case HorizontalAlignment.Center:
                            formatter.Alignment = XParagraphAlignment.Center;
                            break;
                        case HorizontalAlignment.Right:
                            formatter.Alignment = XParagraphAlignment.Right;
                            break;
                    }

                    XRect rect = new XRect();
                    rect.Location = new XPoint(p.X, p.Y);
                    rect.Width = Convert.ToInt32(txB.Width / multipilerX);
                    rect.Height = Convert.ToInt32(txB.Height / multipilerY);
                    formatter.DrawString(txB.Text, font, br, rect);
                }
            }
            graphics.Dispose();
        }
        #endregion

        #region Obsługa zdarzeń
        private void textBoxMouseClick(object sender, MouseEventArgs e) {
            selectedText = (InsertingTextBox)sender;
            selectedText.BackColor = System.Drawing.Color.LightBlue;
            grpTextOptions.Visible = true;
        }
        private void cboTextSize_SelectedIndexChanged(object sender, EventArgs e) {
            if (selectedText != null) {
                selectedText.Font = new System.Drawing.Font(
                    selectedText.Font.FontFamily,
                    Convert.ToInt32(cboTextSize.Text),
                    selectedText.Font.Style);
                System.Drawing.Size size = TextRenderer.MeasureText(selectedText.Text, selectedText.Font);
                selectedText.Size = size;

                //InsertingTexts[selectedText] = Convert.ToInt32(cboTextSize.Text);
                selectedText.TargetTextHeight = Convert.ToInt32(cboTextSize.Text);
                ResizeTextToView(selectedText);
            }

        }
        private void SelectionSettings(object c, EventArgs e) {
            if (c is TextBox) {
                ControlMoverOrResizer.WorkType = ControlMoverOrResizer.MoveOrResize.Move;
                ControlMoverOrResizer.CheckSize = 1;
                if (selectedText != null) {
                    selectedText.BackColor = System.Drawing.Color.Transparent;
                    selectedText = null;
                }
                selectedText = (InsertingTextBox)c;
                grpDocument.Visible = true;
                System.Drawing.Font f = selectedText.Font;
                chkBold.Checked = f.Bold;
                chkItalic.Checked = f.Italic;
                cboFonts.Text = f.FontFamily.Name;
                btnColor.BackColor = selectedText.ForeColor;
                cboTextSize.Text = selectedText.TargetTextHeight.ToString();
            } else if (c is PictureBox) {
                ControlMoverOrResizer.WorkType = ControlMoverOrResizer.MoveOrResize.MoveAndResize;
                ControlMoverOrResizer.CheckSize = 10;
                grpTextOptions.Visible = false;
            }

        }
        private void chkDelete_CheckedChanged(object sender, EventArgs e) {
            _deleting = chkDelete.Checked;
            lblDeleteInfo.Visible = chkDelete.Checked;
        }
        private void StopInserting(object c, EventArgs e) {
            if (InsertingElement != null) {
                InsertingElement = null;
            }
        }
        private void picDocument_Click(object sender, EventArgs e) {
            if (InsertingElement != null) {
                InsertingElement = null;
            }
            ChceckIfTextIsSelected();
            grpTextOptions.Visible = false;
        }
        private void TextChanged(object sender, EventArgs e) {
            ResizeTextToView((InsertingTextBox)sender);
        }
        private void cboFonts_SelectedIndexChanged(object sender, EventArgs e) {
            if (selectedText != null) {
                selectedText.Font = new System.Drawing.Font(
                    cboFonts.Text,
                    Convert.ToInt32(cboTextSize.Text),
                    selectedText.Font.Style);
                System.Drawing.Size size = TextRenderer.MeasureText(selectedText.Text, selectedText.Font);
                selectedText.Size = size;
                ResizeTextToView(selectedText);
            }
        }
        private void picDocument_MouseMove(object sender, MouseEventArgs e) {
            if (InsertingElement != null) {
                InsertingElement.Left = e.Location.X;
                InsertingElement.Top = e.Location.Y;
            }
        }

        private void ChceckIfTextIsSelected() {
            if (selectedText != null) {
                selectedText.BackColor = System.Drawing.Color.Transparent;
                groupBox4.Focus();
                selectedText = null;
            }
        }


        /// <summary>
        /// Ustaw położenie tekstu na lewo
        /// </summary>
        private void btnTextAlignLeft_Click(object sender, EventArgs e) {
            if (selectedText != null) {
                selectedText.TextAlign = HorizontalAlignment.Left;
            }
        }
        /// <summary>
        /// Ustaw położenie tekstu na środek
        /// </summary>
        private void btnTextAlignCenter_Click(object sender, EventArgs e) {
            if (selectedText != null) {
                selectedText.TextAlign = HorizontalAlignment.Center;
            }
        }

        /// <summary>
        /// Ustaw położenie tekstu na prawo
        /// </summary>
        private void btnTextAlignRight_Click(object sender, EventArgs e) {
            if (selectedText != null) {
                selectedText.TextAlign = HorizontalAlignment.Right;
            }
        }
        #endregion

        /// <summary>
        /// Przejście do poprzedniej strony
        /// </summary>
        private async void btnPreviousPage_Click(object sender, EventArgs e) {
            if (_currentPage != 0) {
                _currentPage--;
                this.Invoke(new Action(() => {
                    grpInCompressing.Visible = true;
                    InLoadingImage().ConfigureAwait(false);
                    ShowPage(_currentPage);
                    grpInCompressing.Visible = false;
                }));
            }
        }

        /// <summary>
        /// Przejście do nastepnej strony
        /// </summary>
        private void btnNextPage_Click(object sender, EventArgs e) {
            if (_currentPage != document.PageCount - 1) {
                _currentPage++;
                grpInCompressing.Visible = true;
                InLoadingImage().ConfigureAwait(false);
                Application.DoEvents();
                _ = Task.Run(() => {
                    this.Invoke(new Action(() => {
                        ShowPage(_currentPage).ConfigureAwait(true);
                    }));
                });
            }
        }

        /// <summary>
        /// Animowana ikona przetwarzania
        /// </summary>
        private async Task InLoadingImage() {
            _ = Task.Run(() => {
                int i = 0;
                while (grpInCompressing.Visible) {
                    Thread.Sleep(500);
                    if (i == 0) {
                        this.picLoading.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.pending_work;
                        Application.DoEvents();
                        i = 1;
                    } else {
                        this.picLoading.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.pending_work2;
                        Application.DoEvents();
                        i = 0;
                    }
                }
            });

        }

        /// <summary>
        /// Akceptacja tyllko cyfr i obsluga entera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPageNumber_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.')) {
                e.Handled = true;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                int Page = Convert.ToInt32(txtPageNumber.Text);
                if (Page > 0 && Page <= document.PageCount) {
                    _currentPage = Page -1;
                    grpInCompressing.Visible = true;
                    InLoadingImage().ConfigureAwait(false);
                    Application.DoEvents();
                    _ = Task.Run(() => {
                        this.Invoke(new Action(() => {
                            ShowPage(_currentPage).ConfigureAwait(true);
                        }));
                    });

                } else {
                    MessageBox.Show("Nieprawidłowy numer strony");
                    txtPageNumber.Text = $"{_currentPage + 1} z {document.PageCount}";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            if (grpInCompressing.Visible) {
                grpInCompressing.Visible = false;
            } else {
                grpInCompressing.Visible = true;
                InLoadingImage().ConfigureAwait(false);
            }
        }
    }
}
