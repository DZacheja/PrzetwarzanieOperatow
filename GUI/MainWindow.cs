/*
 * Główne GUI programu
 * 
 */
using Ghostscript.NET;
using Ghostscript.NET.Processor;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using ProgramConfiguration;
using Przetwarzanie_plików_PDF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI {
    public partial class MainWindow : Form {

        #region Inicjalizacja 

        private int _tempFileCounter = 0; //-> licznik plików tymczasowych
        private string CoverExtension; //-> Rozszerzenie okładki
        private PdfDocument coverDocument; //->Okładka
        private PdfEditForm currentEdit;
        /// <summary>
        /// Konstruktor
        /// </summary>
        public MainWindow() {
            InitializeComponent();
            InitializeFromSettings();
        }

        /// <summary>
        /// Wczytywanie ustawień domyślnych przez użytkownika
        /// </summary>
        private void InitializeFromSettings() {
            //Wczytaj domyślną okładkę
            if (ProgramSettings.DefaultCover != null) {
                txtCoverPath.Text = ProgramSettings.DefaultCover;
                CoverExtension = ProgramSettings.DefaultCoverExtension;
                coverDocument = null;
                currentEdit = null;
            }
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            Environment.Exit(Environment.ExitCode);
        }
        #endregion

        #region Obsługa listy plików do połączenia

        /// <summary>
        /// Wyszukiwanie plików w obsługiwanym przezm program formacie na dysku
        /// </summary>
        private void btnSzukaj_Click(object sender, EventArgs e) {
            //Otwórz okno wyboru plików, z filtrami
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = ProgramSettings.supportedFileFilters;
                ofd.FilterIndex = 0;
                ofd.RestoreDirectory = true;
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    string[] sFiles = ofd.FileNames;
                    foreach (string file in sFiles) {
                        CheckAndAddFileToList(file);
                    };
                }
            }
        }

        /// <summary>
        /// Dodawanie wszystkich plików z folderu
        /// </summary>
        private async void btnFilesFromDirectory_Click(object sender, EventArgs e) {
            //Otwórz okno do wyboru folderu i sprawdź wszystkie pliki
            using (FolderBrowserDialog ofd = new FolderBrowserDialog()) {
                if (ofd.ShowDialog() == DialogResult.OK) {
                    string[] files = Directory.GetFiles(ofd.SelectedPath);
                    foreach (string file in files) {
                        CheckAndAddFileToList(file);
                    };
                }

            }
        }
        private static string[] GetFiles(string sourceFolder) {
            return ProgramSettings.supportedFileExtensions.Split('|').SelectMany(filter => System.IO.Directory.GetFiles(sourceFolder, filter)).ToArray();
        }

        /// <summary>
        /// Usuń zaznaczony element z listy
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e) {
            if (dgvFiles.SelectedRows.Count > 0) {
                DataGridViewRow rowToRemove = dgvFiles.SelectedRows[0];
                dgvFiles.Rows.Remove(rowToRemove);
            }
        }

        /// <summary>
        /// Przesuń zaznaczony element na liście w dół
        /// </summary>
        private void btnDol_Click(object sender, EventArgs e) {
            if (dgvFiles.SelectedRows.Count > 0) {
                DataGridViewRow curRow = dgvFiles.SelectedRows[0];
                int curRowIndex = curRow.Index;
                if (curRowIndex != dgvFiles.Rows.Count - 1) {
                    DataGridViewRow lowerRow = dgvFiles.Rows[curRowIndex + 1];
                    dgvFiles.Rows.Remove(curRow);
                    dgvFiles.Rows.Remove(lowerRow);
                    dgvFiles.Rows.Insert(curRowIndex, curRow);
                    dgvFiles.Rows.Insert(curRowIndex, lowerRow);
                    dgvFiles.Rows[curRowIndex + 1].Selected = true;
                }
            }
        }

        /// <summary>
        /// Przesuń zaznaczony element na liście w górę
        /// </summary>
        private void btnGora_Click(object sender, EventArgs e) {
            if (dgvFiles.SelectedRows.Count > 0) {
                DataGridViewRow curRow = dgvFiles.SelectedRows[0];
                int curRowIndex = curRow.Index;
                if (curRowIndex != 0) {
                    DataGridViewRow upperRow = dgvFiles.Rows[curRowIndex - 1];
                    dgvFiles.Rows.Remove(curRow);
                    dgvFiles.Rows.Remove(upperRow);
                    dgvFiles.Rows.Insert(curRowIndex - 1, upperRow);
                    dgvFiles.Rows.Insert(curRowIndex - 1, curRow);
                    dgvFiles.Rows[curRowIndex - 1].Selected = true;
                }
            }
        }

        /// <summary>
        /// Dodawanie pliku do listy
        /// </summary>
        /// <param name="filePath">Ścieżka do pliku</param>
        private void CheckAndAddFileToList(string filePath) {
            //utwórz komórkę określającą typ pliku
            DataGridViewTextBoxCell TypeOfFile = new DataGridViewTextBoxCell();

            //określ rodzaj pliku
            TypeOfFile.Value = ProgramOperations.ExtensionCheck(filePath);
             if (TypeOfFile.Value == null) {
                ProgramStateInfo("Nieobsługiwany typ pliku!");
                return;
            }

            //utwórz nowy wiersz zawierający nazwę pliku
            DataGridViewTextBoxCell FileName = new DataGridViewTextBoxCell();
            FileName.Value = Path.GetFileName(filePath);

            //utwórz nową komórkę zawierającą pełną sieżkę do pliku
            DataGridViewTextBoxCell FilePath = new DataGridViewTextBoxCell();
            FilePath.Value = filePath;

            //utwórz nowy wiersz i dodaj do niego komórki danych
            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(FileName);
            row.Cells.Add(FilePath);
            row.Cells.Add(TypeOfFile);

            //dodaj wiersz do listy
            this.Invoke(new Action(() => dgvFiles.Rows.Add(row)));
        }

        #endregion

        #region Łączenie i optymalizacja plików
        /// <summary>
        /// Połączenie plików z listy
        /// </summary>
        private async void btnMerge_Click(object sender, EventArgs e) {
            //Wybierz folder do zapisu danych
            string fileName = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pdf |*.pdf";
            sfd.Title = "Wybierz miejsce zapisu";
            sfd.FilterIndex = 0;
            if (sfd.ShowDialog() == DialogResult.OK) {
                fileName = sfd.FileName;
            } else {
                return;
            }

            //Włącz widoczność grup kontrolek dotyczących informacji o przetwarzaniu
            this.grpStatus.Visible = true;
            this.grpInCompressing.Visible = false;

            //Rozpocznij łączenie w osobnym procesie
            _ = Task.Run(() => {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                long FileCount, CurrentFileCounter, PageCount, CurrentPageCounter;
                long pages = 0;
                FileCount = dgvFiles.Rows.Count;
                CurrentFileCounter = 0;
                string filePath = "";
                int PageNumerator = ProgramSettings.StartNumber;
                int Pagefrom = ProgramSettings.StartPage;
                //Ustaw Wartość paska postępu
                this.Invoke(new Action(() => this.pgrFiles.Maximum = (int)FileCount));
                string currentFile = "";
                try {
                    //Stwórz nowy dokument i przypisz do niego okładkę
                    PdfDocument outputDocument = new PdfDocument();
                    if (lblCoverInfo.Visible) {
                        if (coverDocument != null) {
                            string name = Path.Combine(ProgramSettings.TEMP_FOLDER, _tempFileCounter.ToString() + "_okladka");
                            coverDocument.Save(name);
                            PdfDocument cover = PdfReader.Open(name, PdfDocumentOpenMode.Import);
                            outputDocument.AddPage(cover.Pages[0]);
                        } else {
                            filePath = ProgramOperations.ConvertFileToPdf(txtCoverPath.Text);
                            PdfDocument pdfDocument = PdfReader.Open(filePath, PdfDocumentOpenMode.Import);
                            outputDocument.AddPage(pdfDocument.Pages[0]);
                            pdfDocument.Close();
                        }
                        if(ProgramSettings.watermark && ProgramSettings.WatemarkOnCover) {
                            ProgramOperations.AddWatemark(outputDocument.Pages[0]);
                        }

                        if (ProgramSettings.pageNumeration && ProgramSettings.CoverNumeation) {
                            ProgramOperations.AddNumber(outputDocument.Pages[0],PageNumerator);
                            PageNumerator++;
                        }
                        pages++;
                    }

                    //Dodaj do pliku wynikowego wszystkie elementy z listy plików
                    foreach (DataGridViewRow row in dgvFiles.Rows) {
                        //Aktualizacja informacji o postępnie
                        this.Invoke(new Action(() => {
                            this.pgrFiles.Value = (int)CurrentFileCounter;
                            this.lblFileCounter.Text = $"{CurrentFileCounter} z {FileCount}";
                        }));

                        //Sprawdzenie pliku i w razie konieczności konwersja na PDF
                        filePath = ProgramOperations.ConvertFileToPdf(row);

                        currentFile = row.Cells[0].Value.ToString();
                        //Otworzenie dołączanego pliku
                        PdfDocument mergingDoc = PdfReader.Open(filePath, PdfDocumentOpenMode.Import);

                        //Aktualizacja informacji
                        PageCount = mergingDoc.PageCount;
                        this.Invoke(new Action(() => {
                            this.pgrPages.Maximum = (int)PageCount;
                            this.lblProcessingFile.Text = currentFile;
                        }));
                        CurrentPageCounter = 0;

                        //Dodawanie stron z pliku do pliku wynikowego
                        foreach (PdfPage page in mergingDoc.Pages) {
                            outputDocument.Pages.Add(page);
                            if (ProgramSettings.watermark) {
                                ProgramOperations.AddWatemark(outputDocument.Pages[(int)pages]);
                            }
                            if (ProgramSettings.pageNumeration && (pages + 1) >= Pagefrom) {
                                ProgramOperations.AddNumber(outputDocument.Pages[(int)pages],PageNumerator);
                                PageNumerator++;
                            }
                            CurrentPageCounter++;
                            pages++;
                            this.Invoke(new Action(() => {
                                this.pgrPages.Value = (int)CurrentPageCounter;
                                this.lblPageCounter.Text = $"{CurrentPageCounter} z {PageCount}";
                                this.lblPages.Text = pages.ToString();
                            }));
                        }

                        //Zamykanie pliku dołączanego 
                        mergingDoc.Close();
                        mergingDoc.Dispose();
                        CurrentFileCounter++;
                    }

                    //Określenie nazwy pliku do zapisu
                    string createdFile = fileName;

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
                        OptimalizePDFFile(tempPath, createdFile);
                        ProgramStateInfo("Pomyślnie zapisano!");

                    } else {
                        //Zapisz plik bez optymalizacji
                        outputDocument.Save(createdFile);
                        outputDocument.Close();
                        outputDocument.Dispose();

                        ProgramStateInfo("Pomyślnie zapisano!");
                    }

                } catch (Exception ex) {
                    //W przypadku wystąpienia błędu poinformuj o nim użytkownika
                    if (ex.Message.Contains("protected with an encryption")) {
                        ProgramStateInfo(
                            $"Plik: {currentFile} zawiera szyfrowanie nieobsługiwane przez ten program!" +
                            $"\nProszę usuń hasło z pliku i spróbuj ponownie!");
                    } else {
                        ProgramStateInfo(
                            $"Podczas próby dołączenia pliku {currentFile} wystąpił nieznany błąd\n {ex.Message}");

                    }
                }

                //Usuń pliki tymczasowe
                this.Invoke(new Action(() => {
                    grpInCompressing.Visible = true;
                    lblProcessing.Text = "Proszę czekać trwa usuwanie plików czasowych";
                    try {
                        ProgramOperations.ClearTempFile();
                    } catch (Exception) {
                        ProgramStateInfo("Błąd podczas usuwania plików czasowych!\nUsuń je ręcznie z folderu 'temp'");
                    }
                    grpInCompressing.Visible = false;
                }));

                //Ukryj grupe kontrolek odpowiedzialną za postęp procesu
                this.Invoke(new Action(() => this.grpStatus.Visible = false));
            });
        }

        /// <summary>
        /// Kompresja pliku PDF według wskazań uzykowanika
        /// </summary>
        /// <param name="fileInput">Ścieżka do chwilowo zapisanego pliku</param>
        /// <param name="fileOutput">Ścieżka do pliku docelowego</param>
        /// <summary>
        /// Połączenie wszystkich plików znajdujących się na liście
        /// </summary>
        private void OptimalizePDFFile(string fileInput, string fileOutput) {
            ProgramOperations.OptimalizePDFFile(fileInput, fileOutput, this);
        }

        /// <summary>
        /// Informacje o rozpoczęciu kompresji pliku prze GS
        /// </summary>
        public async void GsProcessingStart() {
            this.Invoke(new Action(() => {
                panelMerging.Visible = false;
                InLoadingImage().ConfigureAwait(false);
                grpInCompressing.Visible = true;
                lblProcessing.Text = "Proszę czekać trwa optymalizacja pliku";
            }));
        }

        /// <summary>
        /// Informacja o pomyślnej kompresji pliku przez GS
        /// </summary>
        public void GsSuccessProcessed() {
            this.Invoke(new Action(() => grpInCompressing.Visible = false));
            ProgramStateInfo("Pomyślna kompresja");
        }

        /// <summary>
        /// Informacja o błędnej kompresji pliku przez GS
        /// </summary>
        /// <param name="message"></param>
        public void GsErrorDiuringProcessing(string message) {
            if (message.Contains("'gsapi_init_with_args' is made: -100'")) {
                ProgramStateInfo("Nieprawidłowa ścieżka do zapisu plików" +
                    "\nZainstaluj program w ścieżce bez polskich znaków.");
            } else {
                ProgramStateInfo(message);
            }
            this.Invoke(new Action(() => grpInCompressing.Visible = false));
        }
        #endregion

        #region Wygląd okna i włączanie innych elementów

        /// <summary>
        /// Otwórz okno ustawień łączenia i optymalizacji plików
        /// </summary>
        private void btnSettings_Click(object sender, EventArgs e) {
            MergeOpionWindow us = new MergeOpionWindow();
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
                        i = 1;
                    } else {
                        this.picLoading.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.pending_work2;
                        i = 0;
                    }
                }
            });

        }

        /// <summary>
        /// Dodaj tekst to pola z informacjami 
        /// </summary>
        /// <param name="text">Dodawany tekst</param>
        private void ProgramStateInfo(string text) {
            this.Invoke(new Action(() => txtInformation.Text = text));
        }

        /// <summary>
        /// Otwórz ustawienia programu pozwalające zdefiniować profil użytkownika
        /// </summary>
        private void btnProgramSettings_Click(object sender, EventArgs e) {
            ProgramSettingsOption up = new ProgramSettingsOption();
            up.ShowDialog();
            InitializeFromSettings();
        }

        #endregion

        #region Dostosowanie okładki

        /// <summary>
        /// Wyszukiwanie okładki
        /// </summary>
        private void btnSearchCover_Click_1(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                coverDocument = null;
                currentEdit = null;
                chkAddCoverWithoutChanges.Visible = true;
                chkAddCoverWithoutChanges.Checked = false;
                ofd.Filter = "Pliki PDF|*.pdf|" +
                             "Pliki graficzne|*.jpg;*.bmp;*.png;*.tiff|" +
                             "Pliki word|*.doc;*.docx;*.docm|" +
                             "Pliki excel|*.xls;*.xlsm;*.xlsx";
                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtCoverPath.Text = ofd.FileName;

                    //Sprawdź rozszerzenie okładki i poinformuj o rezultatach
                    CoverExtension = ProgramOperations.ExtensionCheck(ofd.FileName);
                    if (CoverExtension == null) {
                        txtCoverPath.Text = "Błędny format pliku!";
                        ProgramStateInfo("Nieobsługiwany typ pliku okładki");
                    } else {
                        ProgramStateInfo("Okładka wczytana pomyślnie");
                    }
                }
            }
        }

        /// <summary>
        /// Otwórz okno do edycji okładki
        /// </summary>
        private void btnCoverEdit_Click_1(object sender, EventArgs e) {
            //Jeżeli okładka była edytowana pokaż edycję
            if (currentEdit != null) {
                currentEdit.ShowDialog();
            } else {
                if (!string.IsNullOrEmpty(CoverExtension)) {
                    try {
                        string filePath = ProgramOperations.ConvertFileToPdf(txtCoverPath.Text);
                        currentEdit = new PdfEditForm(filePath);
                        if (currentEdit.coverDocument != null) {
                            coverDocument = currentEdit.coverDocument;
                            lblCoverInfo.Visible = true;
                            chkAddCoverWithoutChanges.Visible = false;
                            ProgramStateInfo("Pomyślnie dokonano edycji okładki");
                        } else {
                            ProgramStateInfo("Okładka nie została ustawiona");
                        }
                    } catch (Exception ex) {
                        ProgramStateInfo("Błąd podczas wczytywania okładki:\n" + ex.Message);
                    }
                } else {
                    ProgramStateInfo("Wybierz okładkę!");
                }
            }
        }

        /// <summary>
        /// Akceptacja wczytanej okładki bez jej edycji
        /// </summary>
        private void chkAddCoverWithoutChanges_CheckedChanged(object sender, EventArgs e) {
            if (CoverExtension != null) {
                this.lblCoverInfo.Visible = this.chkAddCoverWithoutChanges.Checked;
            } else {
                ProgramStateInfo("Wczytaj najpierw okładkę!");
                this.chkAddCoverWithoutChanges.Checked = false;
            }
        }
        #endregion


    }
}
