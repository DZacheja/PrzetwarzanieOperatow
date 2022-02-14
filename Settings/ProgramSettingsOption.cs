/*
 * GUI do zapisywania parametrów użytkownika
 */
using Przetwarzanie_plików_PDF;
using System;
using System.IO;
using System.Windows.Forms;

namespace ProgramConfiguration {
    public partial class ProgramSettingsOption : Form {
        private string CoverExtension;
        public ProgramSettingsOption() {
            InitializeComponent();
        }

        /// <summary>
        /// Wybranie domyślnej okładki
        /// </summary>
        private void btnSearchFor_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = ProgramSettings.supportedFileFilters;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtCoverPath.Text = ofd.FileName;
                    CoverExtension = ProgramOperations.ExtensionCheck(ofd.FileName);
                    if (CoverExtension == null) {
                        txtCoverPath.Text = "Błędny format pliku!";
                    }
                }
            }
        }

        /// <summary>
        /// Zapisz wybrane ustawienia do pliku XML oraz ustawień programu
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e) {
            OnLoadSettingsClas olsc;
            if (File.Exists(ProgramSettings.PROGRAM_SETTINGS_FILE)) {
                olsc = OnLoadSettingsClas.ReadAsXmlFormat<OnLoadSettingsClas>(ProgramSettings.PROGRAM_SETTINGS_FILE);
                olsc.LoadOnStart = chkReadOnLoad.Checked;
                olsc.SaveCurrentMergeOpions = chkLoadMergeSettings.Checked;
                olsc.DefaultCover = txtCoverPath.Text;
                olsc.DefaultCoverExtension = CoverExtension;
                olsc.BarcodePrefix = txtBarcodePrefix.Text;
                olsc.compression = ProgramSettings.compression;
                olsc.ImageResolution = ProgramSettings.ImageResolution;
                olsc.PdfPrinterSettings = ProgramSettings.PdfPrinterSettings;
            } else {
                olsc = new OnLoadSettingsClas() {
                    LoadOnStart = chkReadOnLoad.Checked,
                    SaveCurrentMergeOpions = chkLoadMergeSettings.Checked,
                    DefaultCover = txtCoverPath.Text,
                    DefaultCoverExtension = CoverExtension,
                    BarcodePrefix = txtBarcodePrefix.Text,
                    compression = ProgramSettings.compression,
                    ImageResolution = ProgramSettings.ImageResolution,
                    PdfPrinterSettings = ProgramSettings.PdfPrinterSettings
                };
            }
            if (File.Exists(ProgramSettings.PROGRAM_SETTINGS_FILE)) {
                File.WriteAllText(ProgramSettings.PROGRAM_SETTINGS_FILE, string.Empty);
            }
            OnLoadSettingsClas.SaveAsXmlFormat<OnLoadSettingsClas>(olsc, ProgramSettings.PROGRAM_SETTINGS_FILE);
            ProgramSettings.LoadSettingsFromObject(olsc);
            this.Close();
        }

        /// <summary>
        /// Usuwanie domyślnej okładki
        /// </summary>
        private void btnCoverClear_Click(object sender, EventArgs e) {
            txtCoverPath.Text = "";
            CoverExtension = null;
        }

        /// <summary>
        /// Wczytywanie obecnego stanu ustawień programu
        /// </summary>
        private void UstawieniaProgramu_Load(object sender, EventArgs e) {
            if (File.Exists(ProgramSettings.PROGRAM_SETTINGS_FILE)) {
                try {
                    OnLoadSettingsClas olsc
                        = OnLoadSettingsClas.ReadAsXmlFormat<OnLoadSettingsClas>(ProgramSettings.PROGRAM_SETTINGS_FILE);
                    SetUpFromObject(olsc);
                } catch (Exception) {
                    MessageBox.Show("Błędny plik ustawień!");
                    File.Delete(ProgramSettings.PROGRAM_SETTINGS_FILE);
                }
            }
        }

        private void SetUpFromObject(OnLoadSettingsClas olsc) {
            chkReadOnLoad.Checked = olsc.LoadOnStart;
            txtCoverPath.Text = olsc.DefaultCover;
            CoverExtension = olsc.DefaultCoverExtension;
            txtBarcodePrefix.Text = olsc.BarcodePrefix;
            chkLoadMergeSettings.Checked = olsc.SaveCurrentMergeOpions;
        }

        /// <summary>
        /// Zapisywanie ustawień do pliku
        /// </summary>
        private void btnSaveToFile_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki xml|*.xml";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string file = saveFileDialog.FileName;
                try {
                    OnLoadSettingsClas olsc;
                    if (File.Exists(ProgramSettings.PROGRAM_SETTINGS_FILE)) {
                        olsc = OnLoadSettingsClas.ReadAsXmlFormat<OnLoadSettingsClas>(ProgramSettings.PROGRAM_SETTINGS_FILE);
                        olsc.LoadOnStart = chkReadOnLoad.Checked;
                        olsc.SaveCurrentMergeOpions = chkLoadMergeSettings.Checked;
                        olsc.DefaultCover = txtCoverPath.Text;
                        olsc.DefaultCoverExtension = CoverExtension;
                        olsc.BarcodePrefix = txtBarcodePrefix.Text;
                        olsc.compression = ProgramSettings.compression;
                        olsc.ImageResolution = ProgramSettings.ImageResolution;
                        olsc.PdfPrinterSettings = ProgramSettings.PdfPrinterSettings;
                    } else {
                        olsc = new OnLoadSettingsClas() {
                            LoadOnStart = chkReadOnLoad.Checked,
                            SaveCurrentMergeOpions = chkLoadMergeSettings.Checked,
                            DefaultCover = txtCoverPath.Text,
                            DefaultCoverExtension = CoverExtension,
                            BarcodePrefix = txtBarcodePrefix.Text,
                            compression = ProgramSettings.compression,
                            ImageResolution = ProgramSettings.ImageResolution,
                            PdfPrinterSettings = ProgramSettings.PdfPrinterSettings
                        };
                    }
                    OnLoadSettingsClas.SaveAsXmlFormat(olsc, ProgramSettings.PROGRAM_SETTINGS_FILE);
                    OnLoadSettingsClas.SaveAsXmlFormat(olsc, file);
                    ProgramSettings.LoadSettingsFromObject(olsc);
                    MessageBox.Show("Pomyślnie zapisano plik.");
                } catch (Exception ex) {
                    MessageBox.Show("Wystąpił błąd podczas zapisu:\n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Wczytaj ustawienia z pliku
        /// </summary>
        private void btnLoadFromFile_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK) {
                try {
                    OnLoadSettingsClas olsc = OnLoadSettingsClas.ReadAsXmlFormat<OnLoadSettingsClas>(ofd.FileName);
                    SetUpFromObject(olsc);
                    ProgramSettings.LoadSettingsFromObject(olsc);
                    OnLoadSettingsClas.SaveAsXmlFormat(olsc,ProgramSettings.PROGRAM_SETTINGS_FILE);

                } catch (Exception) {
                    MessageBox.Show("Plik jest nieprawidłowy", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}


