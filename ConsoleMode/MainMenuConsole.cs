/**
 * Menu główne trybu pracy konsoli
 */
using PdfSharp.Pdf;
using ProgramConfiguration;
using Przetwarzanie_plików_PDF;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleMode {
    internal class MainMenuConsole {
        private string CoverPath;
        private List<string> FilesList;
        private PdfDocument coverDoc;

        #region Menu

        /// <summary>
        /// Konstruktor.
        /// Wyświetlenie menu programu i oczekiwanie na wybór użytkownika
        /// </summary>
        public MainMenuConsole(string[] args = null) {
            FilesList = new List<string>();

            //Dodanie plików wywołanych przez program
            if (args is not null) {
                List<string> newFiles = new List<string>();
                bool coverIsNest = false;
                foreach (string s in args) {
                    if (s == "-o") {
                        coverIsNest = true;
                        continue;
                    }

                    if (coverIsNest) {
                        AddCover(s);
                        if (CoverPath != null) {
                            newFiles.Add("Okładka: " + Path.GetFileName(s));
                        }
                        coverIsNest = false;
                        continue;
                    }
                    string test = ProgramOperations.ExtensionCheck(s);
                    if (test != null) {
                        FilesList.Add(s);
                        newFiles.Add(Path.GetFileName(s));
                    }

                }
                Console.Clear();
                if (newFiles.Count > 0) {
                    Console.WriteLine($"Pomyślnie dodano {newFiles.Count} plików:");
                    foreach (string file in newFiles) {
                        Console.WriteLine(file);
                    }
                } else {
                    Console.WriteLine("Nierozpoznane parametry...\nZostanie wyświetlone menu główne.");
                }
                Console.ReadLine();
            }
            while (true) {
                ShowMainMenu();
                Console.Write("\nWprowadź numer opcji:");
                try {
                    int selectedNumer = Convert.ToInt32(Console.ReadLine());

                    switch (selectedNumer) {
                        case 1:
                            AddCover();
                            break;
                        case 2:
                            AddFile();
                            break;
                        case 3:
                            AddMultipleFiles();
                            break;
                        case 4:
                            ShowAllFiles();
                            break;
                        case 5:
                            CoverEdit();
                            break;
                        case 6:
                            SetUpParameters();
                            break;
                        case 7:
                            LoadSettingsFromFile();
                            break;
                        case 8:
                            MergeFiles();
                            break;
                        case 9:
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("\nWybrano błędną opcje!");
                            Console.ReadLine();
                            break;
                    }
                } catch (Exception) {
                    Console.WriteLine("Wprowadzono błędna cyfre");
                    Console.ReadLine();
                }
            }
        }


        /// <summary>
        /// Pokazuje menu główne
        /// </summary>
        private void ShowMainMenu() {
            Console.Clear();
            Console.WriteLine("MENU GŁÓWNE");
            string menu;
            if (CoverPath != null) {
                menu = "1. Zmień okładkę\n";
            } else {
                menu = "1. Dodaj okładkę\n";
            }
            Console.WriteLine("Wybierz jedną z opcji");
            Console.WriteLine(menu +
                "2. Dodaj pojedynczy plik do połączenia\n" +
                "3. Dodaj wszystkie pliki ze ścieżki do połączenia\n" +
                "4. Wyświetl dodane pliki\n" +
                "5. Edytuj okładkę\n" +
                "6. Ustaw parametry połączenia plików\n" +
                "7. Wczytaj parametry łączenia plików przygotowane w GUI\n" +
                "8. Połącz pliki\n" +
                "9. Zakończ program\n"
                );
        }

        #endregion

        #region Dodawanie plików
        /// <summary>
        /// Dodanie okładki
        /// </summary>
        private void AddCover(string path = "") {
            bool stopAfterAdd = false;
            if (path == "") {
                stopAfterAdd = true;
                Console.Clear();
                Console.Write("Wpisz ścieżkę do pliku z okładką:");
                path = Console.ReadLine();
            }
            string test = ProgramOperations.ExtensionCheck(path);
            if (test != null) {
                CoverPath = path;
                Console.WriteLine("Dodano pomyślnie okładkę!");
            } else {
                Console.WriteLine("Nieobsługiwany typ pliku okładki!");
            }
            if (stopAfterAdd) {
                Console.ReadLine();
            }

        }

        /// <summary>
        /// Dodawanie pojedynczych plików
        /// </summary>
        private void AddFile() {
            Console.Clear();
            Console.Write("Wpisz ścieżkę do pliku:");
            string path = Console.ReadLine();
            string test = ProgramOperations.ExtensionCheck(path);
            if (test != null) {
                FilesList.Add(path);
                Console.WriteLine("Dodano pomyślnie!");
            } else {
                Console.WriteLine("Nieobsługiwany typ pliku!");
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Dodawanie plików ze wskazanej ścieżki
        /// </summary>
        private void AddMultipleFiles() {
            Console.Clear();
            Console.Write("Wpisz ścieżkę do plików:");
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);

            List<string> newFiles = new List<string>();
            foreach (string file in files) {
                string test = ProgramOperations.ExtensionCheck(file);
                if (test != null) {
                    FilesList.Add(file);
                    newFiles.Add(file);
                }
            }
            Console.WriteLine($"Pomyślnie dodano {newFiles.Count} plików:");
            foreach (string file in newFiles) {
                Console.WriteLine(Path.GetFileName(file));
            }
            Console.WriteLine("\n\nWciśnij enter aby kontynuować");
            Console.ReadLine();
        }

        /// <summary>
        /// Pokaż wszystkie wczytane pliki
        /// </summary>
        private void ShowAllFiles() {
            Console.Clear();
            Console.WriteLine("Wczytane pliki:");
            if (CoverPath != null) {
                Console.WriteLine("Okładka: " + Path.GetFileName(CoverPath));
            }
            foreach (string f in FilesList) {
                Console.WriteLine(Path.GetFileName(f));
            }
            Console.WriteLine("\n\nWciśnij enter aby kontynuować");
            Console.ReadLine();
        }
        #endregion

        #region Operacje na plikach
        /// <summary>
        /// Połączenie plików
        /// </summary>
        private void MergeFiles() {
            Console.WriteLine("Podaj lokalizację zapisywanego pliku:");
            string path = Console.ReadLine();
            if (!Directory.Exists(path)) {
                Console.WriteLine("Podana ścieżka nie istnieje!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Podaj nazwe tworzonego pliku");
            string file = Console.ReadLine();
            if (!file.Contains(".pdf")) {
                file += ".pdf";
            }
            string fullPath = Path.Combine(path, file);
            if (coverDoc != null) {
                ProgramOperations.MergeFiles(FilesList, fullPath, coverDoc);
            } else if (CoverPath != null) {
                ProgramOperations.MergeFiles(FilesList, fullPath, CoverPath);
            } else {
                ProgramOperations.MergeFiles(FilesList, fullPath);
            }

        }

        /// <summary>
        /// Edycja okładki
        /// </summary>
        private void CoverEdit() {
            if (CoverPath != null) {
                CoverEditInConsole editor = new CoverEditInConsole(CoverPath);
                coverDoc = editor.CoverDoc;
                if (coverDoc != null) {
                    Console.Clear();
                    Console.WriteLine("Edycja pomyślna!");

                    //Zapisywanie okładki do pliku PDF
                    Console.WriteLine("Zapisać okładke do pliku PDF? 0-Nie 1-Tak");
                    int res = 0;
                    try {
                        res = Convert.ToInt32(Console.ReadLine());
                    } catch (Exception) {
                        Console.WriteLine("Wpisano błędną odpowiedź!");
                        Console.ReadLine();
                        return;
                    }

                    if (res == 0)
                        return;
                    if (res == 1) {
                        try {
                            Console.WriteLine("Podaj lokalizację zapisywanego pliku:");
                            string path = Console.ReadLine();
                            if (!Directory.Exists(path)) {
                                Console.WriteLine("Podana ścieżka nie istnieje!");
                                Console.ReadLine();
                                return;
                            }
                            Console.WriteLine("Podaj nazwe tworzonego pliku");
                            string file = Console.ReadLine();
                            if (!file.Contains(".pdf")) {
                                file += ".pdf";
                            }
                            string fullPath = Path.Combine(path, file);
                            coverDoc.Save(fullPath);
                        } catch (Exception) {
                            Console.WriteLine("Błąd podczas zapisu!");
                        }
                    }
                }
            } else {
                Console.WriteLine("Aby edytować okładkę najpierw ją wczytaj!");
                Console.ReadLine();
            }

        }
        #endregion

        #region Ustawienia programu
        /// <summary>
        /// Ustawianie paramerów kompresji plików PDF
        /// </summary>
        private void SetUpParameters() {
            //Wyświetlenie obenych parametrów:
            Console.Clear();
            Console.WriteLine("Obecne parametry: ");
            Console.WriteLine($"Dokonywanie kompresji: {ProgramSettings.compression}");
            if (ProgramSettings.compression) {
                Console.WriteLine($"Stopień jakości pliku [1-5]: {ProgramSettings.GetCurrentPdfPrinterSettings()}");
                Console.WriteLine($"DPI obrazów: {ProgramSettings.ImageResolution}");
            }

            //Menu opcji
            Console.WriteLine("\n");
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1. Zmień ustawienia\n" +
                "2. Zakmnij");

            //Zmiana ustawień
            try {
                int s = Convert.ToInt32(Console.ReadLine());
                switch (s) {
                    case 1: //-> nowe ustawienia
                        Console.WriteLine("Czy dokonywać kompresji 0-Nie 1-Tak");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 0 || c == 1) {
                            if (c == 0)
                                ProgramSettings.compression = false;
                            else
                                ProgramSettings.compression = true;

                            Console.WriteLine("Ustaw jakośc pdf [1-5]");
                            int j = Convert.ToInt32(Console.ReadLine());

                            if (j >= 1 && j <= 5) {
                                ProgramSettings.SetCurrentPdfPrinterSettings(j);
                            } else {
                                Console.WriteLine("Błędna wartość");
                                Console.ReadLine();
                                return;
                            }


                            Console.WriteLine("Ustaw DPI obrazów [100-600]");
                            j = Convert.ToInt32(Console.ReadLine());

                            if (j >= 100 && j <= 600) {
                                ProgramSettings.ImageResolution = j;
                            } else {
                                Console.WriteLine("Błędna wartość");
                                Console.ReadLine();
                                return;
                            }
                            Console.WriteLine("Ustawiono pomyślnie!");
                            Console.ReadLine();
                        } else {
                            Console.WriteLine("Błędna wartość");
                            Console.ReadLine();
                            return;
                        }
                        break;
                    case 2:
                        return;
                        break;
                    default:
                        Console.WriteLine("Wprowadzono błędną wartość");
                        break;
                }
            } catch (Exception) {
                Console.WriteLine("Błędna wartość!");
                Console.ReadLine();
                return;
            }
        }

        /// <summary>
        /// Wczytanie pliku ustawień z GUI
        /// w tych ustawieniach jest dużo więcej opcji
        /// konfiguracja ich z poziomu konsoli była by zbyt żmudna
        /// </summary>
        private void LoadSettingsFromFile() {
            Console.Clear();
            Console.WriteLine("Wprowadź ścieżke do pliku z ustawieniami:");
            string path = Console.ReadLine();
            try {
                OnLoadSettingsClas olsc = OnLoadSettingsClas.ReadAsXmlFormat<OnLoadSettingsClas>(path);
                ProgramSettings.LoadSettingsFromObject(olsc);
                Console.WriteLine("Wczytano pomyślnie!");
                Console.ReadLine();
            } catch (Exception) {
                Console.WriteLine("Wskazany plik jest niepoprawny!");
                return;
            }
        }
        #endregion

    }

}
