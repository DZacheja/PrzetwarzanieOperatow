/*
 * GUI do edycji okładki
 */
using BarcodeLib;
using ControlManager;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using ProgramConfiguration;
using Przetwarzanie_plików_PDF;
using Przetwarzanie_plikow_PDF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GUI {
    public partial class PdfEditForm : Form {
        #region Inicjalizacja okna


        public double multipilerX;
        public double multipilerY;
        private List<PictureBox> InsertingElements;
        private Dictionary<TextBox, int> InsertingTexts;
        private string docPath;
        private double docWidth;
        private double docHeight;
        private double PROP_PIX_MM;
        private TextBox selectedText;
        private bool _deleting;
        public PdfDocument coverDocument;
        private Control InsertingElement;
        
        public PdfEditForm() { }

        /// <summary>
        /// Tworzenie edytra do edycji plików zawierających więcej niż jedną stronę
        /// </summary>
        /// <param name="file">ścieżka do pliku pdf</param>
        /// <param name="multipage"></param>
        public PdfEditForm(string file, bool multipage) {

        }
        /// <summary>
        /// Tworzenie edytora do edycji pojedynczej strony
        /// </summary>
        /// <param name="file"></param>
        public PdfEditForm(string file) {
            //Zapis wybranej scieżki
            docPath = file;
            InitializeComponent();

            //Listy przechowujące dodawane elementy
            InsertingElements = new List<PictureBox>();
            InsertingTexts = new Dictionary<TextBox, int>();

            //Odczytanie parametrów dokumentu
            PdfDocument doc = PdfReader.Open(docPath, PdfDocumentOpenMode.Import);
            coverDocument = new PdfDocument();
            coverDocument.AddPage(doc.Pages[0]);
            doc.Close();
            PdfPage pge = coverDocument.Pages[0];
            docWidth = pge.Width.Value;
            docHeight = pge.Height.Value;

            //Obliczenie wielkości piksela
            PROP_PIX_MM = pge.Width / pge.Width.Millimeter;

            //Wczytanie pliku jako obraz i wyświetlenie
            Image imgFFile = ProgramOperations.GetImageFromFile(docPath);
            picDocument.BackgroundImage = imgFFile;

            //Pozostałe elementy
            ControlMoverOrResizer.WorkType = ControlMoverOrResizer.MoveOrResize.Move;

            //Uzupełnienie czcionek i rozmiarów tekstu
            grpTextOptions.Visible = false;
            for (int i = 6; i < 128; i++) {
                cboTextSize.Items.Add(i.ToString());
                i++;
            }
            cboTextSize.SelectedIndex = 1;

            FontFamily[] fontFamilies;

            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            fontFamilies = installedFontCollection.Families;
            foreach (FontFamily family in fontFamilies) {
                cboFonts.Items.Add(family.Name);
            }
            cboFonts.Text = "Arial";

            //Pokazanie okna
            this.ShowDialog();

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
            double ImageWidth = Convert.ToInt32(ImageWidthInPix / docWidth);
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
            TextBox txB = new TextBox();
            txB.Multiline = true;
            txB.Text = "Wpisz tekst.";
            bool t = SetStyle(txB,ControlStyles.SupportsTransparentBackColor,true);
            txB.BackColor = System.Drawing.Color.Transparent;
            txB.Location = new Point(10, 10);
            grpDocument.Controls.Add(txB);
            txB.BringToFront();

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
            ResizeTextToView(txB,Convert.ToInt32(cboTextSize.Text));

            //Dodanie elementu do listy elementów do dodania
            InsertingTexts.Add(txB, Convert.ToInt32(cboTextSize.Text));

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

            ResizeAllItemsToNewDocumentViewSize(curWidth, newWidth, curHeight, newHeight, 1.1F);
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

            ResizeAllItemsToNewDocumentViewSize(curWidth, newWidth, curHeight, newHeight, 0.9F);
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
        private void ResizeTextToView(TextBox txb, int TextHeight) {
            double prop = (double)docWidth / (double)grpDocument.Width;
            int TextSize = Convert.ToInt32(Convert.ToDouble(TextHeight) / prop);
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
            txb.Width = size.Width +10;
            int lines = txb.Lines.Count();
            txb.Height = txb.Font.Height * (lines +1);
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
        private void ResizeAllItemsToNewDocumentViewSize(int oldX, int newX, int oldY, int newY, double size) {
            double propX = (double)oldX / (double)newX;
            double propY = (double)oldY / (double)newY;

            //Zmiana rozmiaru dodawanych obrazków
            foreach (PictureBox pic in InsertingElements) {
                int newPosX = Convert.ToInt32((double)pic.Location.X / propX);
                int newPosY = Convert.ToInt32((double)pic.Location.Y / propY);
                pic.Location = new Point(newPosX, newPosY);
                ResizeControlByPrecent(pic, size);
            }

            //Zmiana rozmiaru dodawanych tekstów
            foreach (TextBox tb in InsertingTexts.Keys) {
                int newPosX = Convert.ToInt32((double)tb.Location.X / propX);
                int newPosY = Convert.ToInt32((double)tb.Location.Y / propY);
                tb.Location = new Point(newPosX, newPosY);
                int CurrentTextHeight = InsertingTexts[tb];
                ResizeTextToView(tb,CurrentTextHeight);
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
                int CurrentTextHeight = InsertingTexts[selectedText];
                ResizeTextToView(selectedText,CurrentTextHeight);
            }
        }

        //Usuwanie wskazanego elementu
        private void DeleteItem(object c, EventArgs e) {
            if (_deleting) {
                if (c is TextBox) {
                    TextBox tb = (TextBox)c;
                    InsertingTexts.Remove(tb);
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
                SaveChanges(true,folder);
                System.Diagnostics.Process.Start(folder);
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
            double multipilerX = (double)grpDocument.Width / docWidth;
            double multipilerY = (double)grpDocument.Height / docHeight;
            PdfPage page = coverDocument.Pages[0];
            XGraphics graphics = XGraphics.FromPdfPage(page);
            foreach (PictureBox pixB in InsertingElements) {
                int elemLocationX = Convert.ToInt32(pixB.Location.X / multipilerX);
                int elemLocationY = Convert.ToInt32(pixB.Location.Y / multipilerY);
                int elemWidth = Convert.ToInt32(pixB.Width / multipilerX);
                int elemHeight = Convert.ToInt32(pixB.Height / multipilerY);
                Image img = pixB.BackgroundImage;
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                XImage xImg = XImage.FromStream(ms);
                graphics.DrawImage(xImg, elemLocationX, elemLocationY, elemWidth, elemHeight);
            }
            foreach (TextBox txB in InsertingTexts.Keys) {
                int Size = InsertingTexts[txB];
                System.Drawing.Font f = new System.Drawing.Font(
                  txB.Font.FontFamily,
                  Size, txB.Font.Style);
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

                XFont font = new XFont(f.FontFamily.Name, Size, xStyle);
                int elemLocationX = Convert.ToInt32(txB.Location.X / multipilerX);
                int elemLocationY = Convert.ToInt32(txB.Location.Y / multipilerY);
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
                XRect rect = new XRect(p.X,p.Y, TxtSize.Height, TxtSize.Width);
                
                formatter.DrawString(txB.Text, font, br, rect);
                //graphics.DrawString(txB.Text, font, br, p);
            }
            graphics.Dispose();
            if (saveAsPdf) {
                coverDocument.Save(folder);
            }
        }

        #endregion

        #region Obsługa zdarzeń
        private void textBoxMouseClick(object sender, MouseEventArgs e) {
            selectedText = (TextBox)sender;
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

                InsertingTexts[selectedText] = Convert.ToInt32(cboTextSize.Text);
                ResizeTextToView(selectedText,Convert.ToInt32(cboTextSize.Text));
            }

        }
        private void SelectionSettings(object c, EventArgs e) {
            if (c is TextBox) {
                ControlMoverOrResizer.WorkType = ControlMoverOrResizer.MoveOrResize.Move;
                ControlMoverOrResizer.CheckSize = 1;
                selectedText = (TextBox)c;
                grpDocument.Visible = true;
                System.Drawing.Font f = selectedText.Font;
                chkBold.Checked = f.Bold;
                chkItalic.Checked = f.Italic;
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
            ChceckIfTextIsSelected();
            grpTextOptions.Visible = false;
        }
        private void TextChanged(object sender, EventArgs e) {
            ResizeTextToView((TextBox)sender,InsertingTexts[(TextBox)sender]);
        }
        private void cboFonts_SelectedIndexChanged(object sender, EventArgs e) {
            if (selectedText != null) {
                selectedText.Font = new System.Drawing.Font(
                    cboFonts.Text,
                    Convert.ToInt32(cboTextSize.Text),
                    selectedText.Font.Style);
                System.Drawing.Size size = TextRenderer.MeasureText(selectedText.Text, selectedText.Font);
                selectedText.Size = size;
                InsertingTexts[selectedText] = Convert.ToInt32(cboTextSize.Text);
                int CurrentTextHeight = InsertingTexts[selectedText];
                ResizeTextToView(selectedText,CurrentTextHeight);
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
                picDocument.Focus();
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
    }
}
