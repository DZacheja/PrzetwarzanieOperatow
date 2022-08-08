/*
 * GUI do wybrania opcji łączenia plików PDF
 */
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace ProgramConfiguration {
    public partial class MergeOpionWindow : Form {
        public bool NumberLeftAlign;
        public bool NumberUpAlign;
        public MergeOpionWindow() {
            InitializeComponent();
            cboResolution.SelectedIndex = 0;
            this.chkPDFOptimalize.Checked = ProgramSettings.compression;
            if (ProgramSettings.compression) {
                switch (ProgramSettings.PdfPrinterSettings) {
                    case "screen":
                        cboResolution.SelectedIndex = 0;
                        break;
                    case "ebook":
                        cboResolution.SelectedIndex = 1;
                        break;
                    case "printer":
                        cboResolution.SelectedIndex = 2;
                        break;
                    case "prepress":
                        cboResolution.SelectedIndex = 3;
                        break;
                    case "default":
                        cboResolution.SelectedIndex = 4;
                        break;
                }

                grpSettings.Enabled = chkPDFOptimalize.Checked;
                trcImageSize.Value = ProgramSettings.ImageResolution;
                numImgSize.Value = ProgramSettings.ImageResolution;
            }
            //Uzupełnienie czcionek i rozmiarów tekstu
            for (int i = 6; i < 128; i++) {
                cboTextSize.Items.Add(i.ToString());
                cboTextSizeNumbers.Items.Add(i.ToString());
                i++;
            }
            cboTextSize.SelectedIndex = 1;
            cboTextSizeNumbers.SelectedIndex = 1;
            ProgramSettings.FillComboBoxWithSupportedFonts(cboFonts);
            ProgramSettings.FillComboBoxWithSupportedFonts(cboFontsNumber);
            cboFonts.Text = "Arial";
            cboFontsNumber.Text = "Arial";

            panelPgeNumeration.Enabled = chkPgeNumeration.Checked;
            panelWatermark.Enabled = chkWatermark.Checked;

            if (ProgramSettings.watermark) {
                chkWatermark.Checked = true;
                chkWatemarkOnCover.Checked = ProgramSettings.WatemarkOnCover;
                txtWatermark.Text = ProgramSettings.WatermarkText;
                cboFonts.Text = ProgramSettings.WatermarkFont;
                cboTextSize.Text = ProgramSettings.WatermarkHeight.ToString();
                chkBold.Checked = ProgramSettings.WatermarkBold;
                chkItalic.Checked = ProgramSettings.WatermarkItalic;
                if (ProgramSettings.WatermarkColor.Length < 3) {
                    ProgramSettings.WatermarkColor = new int[] { 0, 0, 0 };
                }
                btnColor.BackColor = Color.FromArgb(
                    ProgramSettings.WatermarkColor[0],
                    ProgramSettings.WatermarkColor[1],
                    ProgramSettings.WatermarkColor[2]);
                numWaterY.Value = ProgramSettings.WatermarkPositionY;
                numWaterX.Value = ProgramSettings.WatermarkPositionX;
            }

            if (ProgramSettings.pageNumeration) {
                chkPgeNumeration.Checked = true;
                chkNumberInCover.Checked = ProgramSettings.CoverNumeation;
                numStartNumber.Value = ProgramSettings.StartNumber;
                numFromPages.Value = ProgramSettings.StartPage;
                cboFontsNumber.Text = ProgramSettings.NumberFont;
                cboTextSizeNumbers.Text = ProgramSettings.NumberHeight.ToString();
                chkBoldNumbers.Checked = ProgramSettings.NumberBold;
                chkItalicNumbers.Checked = ProgramSettings.NumberItalic;
                numNumPosX.Value = ProgramSettings.NumberPositionX;
                numNumPosY.Value = ProgramSettings.NumberPositionY;
                if (ProgramSettings.NumbersColor.Length < 3) {
                    ProgramSettings.NumbersColor = new int[] { 0, 0, 0 };
                }
                btnNumberColors.BackColor = Color.FromArgb(
                    ProgramSettings.NumbersColor[0],
                    ProgramSettings.NumbersColor[1],
                    ProgramSettings.NumbersColor[2]);

                NumberLeftAlign = ProgramSettings.NumberAlignleft;
                NumberUpAlign = ProgramSettings.NumberAlignUp;
                if (ProgramSettings.NumberAlignleft && ProgramSettings.NumberAlignUp) {
                    rbnLeftUp.Checked = true;

                } else if (!ProgramSettings.NumberAlignleft && ProgramSettings.NumberAlignUp) {
                    rbnRightUp.Checked = true;
                } else if (ProgramSettings.NumberAlignleft && !ProgramSettings.NumberAlignUp) {
                    rbnLeftDown.Checked = true;

                } else if (!ProgramSettings.NumberAlignleft && !ProgramSettings.NumberAlignUp) {
                    rbnRightDown.Checked = true;
                }
            }

            this.ShowDialog();
        }

        /// <summary>
        /// Określenie jakości drukowanego pliku
        /// </summary>
        private void cboResolution_SelectedIndexChanged(object sender, EventArgs e) {
            int selected = cboResolution.SelectedIndex;
            switch (selected) {
                case 0:
                    ProgramSettings.PdfPrinterSettings = "screen";
                    break;
                case 1:
                    ProgramSettings.PdfPrinterSettings = "ebook";
                    break;
                case 2:
                    ProgramSettings.PdfPrinterSettings = "printer";
                    break;
                case 3:
                    ProgramSettings.PdfPrinterSettings = "prepress";
                    break;
                case 4:
                    ProgramSettings.PdfPrinterSettings = "default";
                    break;
            }
        }

        /// <summary>
        /// Zmiana wartości DPI
        /// </summary>
        private void trcImageSize_Scroll(object sender, EventArgs e) {
            int value = trcImageSize.Value;
            numImgSize.Value = value;
            ProgramSettings.ImageResolution = value;
        }

        /// <summary>
        /// Zmiana statusu optymalizacji pliku
        /// </summary>
        private void chkPDFOptimalize_CheckedChanged(object sender, EventArgs e) {
            ProgramSettings.compression = chkPDFOptimalize.Checked;
            grpSettings.Enabled = chkPDFOptimalize.Checked;
        }

        /// <summary>
        /// Zapis wybranych ustawień do programu i pliku XML
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e) {
            OnLoadSettingsClas olsc;
            if (File.Exists(ProgramSettings.PROGRAM_SETTINGS_FILE)) {
                olsc =
                    OnLoadSettingsClas.ReadAsXmlFormat<OnLoadSettingsClas>(ProgramSettings.PROGRAM_SETTINGS_FILE);
            } else {
                olsc = new OnLoadSettingsClas();
            }
            //Kompresja
            olsc.compression = ProgramSettings.compression;
            if (chkPDFOptimalize.Checked) {
                olsc.ImageResolution = ProgramSettings.ImageResolution;
                olsc.PdfPrinterSettings = ProgramSettings.PdfPrinterSettings;
            }
            //Znak wodny
            olsc.watermark = chkWatermark.Checked;
            if (chkWatermark.Checked) {
                olsc.WatermarkText = txtWatermark.Text;
                olsc.WatemarkOnCover = chkWatemarkOnCover.Checked;
                olsc.WatermarkFont = cboFonts.Text;
                olsc.WatermarkHeight = Convert.ToInt32(cboTextSize.Text);
                olsc.WatermarkBold = chkBold.Checked;
                olsc.WatermarkItalic = chkItalic.Checked;
                olsc.WatermarkColor = new int[] { btnColor.BackColor.R, btnColor.BackColor.G, btnColor.BackColor.B };
                olsc.WatermarkPositionX = Convert.ToInt32(numWaterX.Value);
                olsc.WatermarkPositionY = Convert.ToInt32(numWaterY.Value);
            }
            //Numeracja stron
            olsc.pageNumeration = chkPgeNumeration.Checked;
            if (chkPgeNumeration.Checked) {
                olsc.StartNumber = Convert.ToInt32(numStartNumber.Value);
                olsc.StartPage = Convert.ToInt32(numFromPages.Value);
                olsc.CoverNumeation = chkNumberInCover.Checked;
                olsc.NumberFont = cboFontsNumber.Text;
                olsc.NumberHeight = Convert.ToInt32(cboTextSizeNumbers.Text);
                olsc.NumberItalic = chkItalicNumbers.Checked;
                olsc.NumberBold = chkBoldNumbers.Checked;
                olsc.NumbersColor = new int[] { btnNumberColors.BackColor.R, btnNumberColors.BackColor.G, btnNumberColors.BackColor.B };
                olsc.NumberPositionX = Convert.ToInt32(numNumPosX.Value);
                olsc.NumbersPositionY = Convert.ToInt32(numNumPosY.Value);
                olsc.NumberAlignleft = NumberLeftAlign;
                olsc.NumberAlignUp = NumberUpAlign;
            }
            if (ProgramSettings.SaveCurrentMergeOpions) {
                File.WriteAllText(ProgramSettings.PROGRAM_SETTINGS_FILE, String.Empty);
                OnLoadSettingsClas.SaveAsXmlFormat<OnLoadSettingsClas>(olsc, ProgramSettings.PROGRAM_SETTINGS_FILE);
            }

            ProgramSettings.LoadSettingsFromObject(olsc);
            this.Close();
        }


        /// <summary>
        /// Ustaw skok co 50 w polu wpisywania
        /// </summary>
        private void numImgSize_ValueChanged(object sender, EventArgs e) {
            int val = (int)numImgSize.Value / 50;
            val *= 50;
            trcImageSize.Value = val;
            numImgSize.Value = val;
        }

        /// <summary>
        /// Ustaw skok co 50 w polu przesuwania
        /// </summary>
        private void trcImageSize_MouseLeave(object sender, EventArgs e) {
            int curvalue = (int)trcImageSize.Value / 50;
            curvalue *= 50;
            trcImageSize.Value = curvalue;
            numImgSize.Value = curvalue;
        }

        #region Akcje po naciśnięciu kontrolek
        /// <summary>
        /// Znak wodny dostępność do konfiguracji
        /// </summary>
        private void chkWatermark_CheckedChanged(object sender, EventArgs e) {
            panelWatermark.Enabled = chkWatermark.Checked;
        }

        /// <summary>
        /// Numery stron dostępność konfiguracji
        /// </summary>
        private void chkPgeNumeration_CheckedChanged(object sender, EventArgs e) {
            panelPgeNumeration.Enabled = chkPgeNumeration.Checked;
        }

        /// <summary>
        /// Wybór koloru tekstu znaku wodnego
        /// </summary>
        private void btnColor_Click(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                btnColor.BackColor = colorDialog1.Color;
            }
        }
        /// <summary>
        /// Wybór koloru tekstu numerów
        /// </summary>
        private void btnNumberColors_Click(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                btnNumberColors.BackColor = colorDialog1.Color;
            }
        }
        #endregion


        /// <summary>
        /// Zmiana połozenia
        /// </summary>
        private void SetUpNumberAlignOption(object sender, EventArgs e) {
            if (rbnRightUp.Checked) {
                NumberLeftAlign = false;
                NumberUpAlign = true;
            }

            if (rbnRightDown.Checked) {
                NumberLeftAlign = false;
                NumberUpAlign = false;
            }

            if (rbnLeftUp.Checked) {
                NumberLeftAlign = true;
                NumberUpAlign = true;
            }

            if (rbnLeftDown.Checked) {
                NumberLeftAlign = true;
                NumberUpAlign = false;
            }

        }

        /// <summary>
        /// Zmiana statusu numeracji stron
        /// </summary>
        private void chkNumberInCover_CheckedChanged(object sender, EventArgs e) {
            if (chkNumberInCover.Checked) {
                numFromPages.Value = 1;
                numFromPages.Enabled = false;
            } else {
                numFromPages.Enabled = true;
            }
        }
    }
}
