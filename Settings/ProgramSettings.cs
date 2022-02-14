/*
 * Klasa statyczna przechowująca parametry programu możliwe do odczytania 
 * z dowolnego miejsca
 * GS  = skrót od GhostScript
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime;

namespace ProgramConfiguration {
    internal static class ProgramSettings {
        internal static bool isWindowedApplication; //->Rodzaj dzialania programu
        internal static string ProgramPath; //->ściezka do programu
        internal static string GS_DLL_FILE; //->ścieżka do pliku GS
        internal static string GS_DLL_DIR; //->ścieżka do folderu w którym znajduje się plik dll GS
        internal static readonly string TEMP_FOLDER = Path.Combine(Directory.GetCurrentDirectory(), "TempFiles"); //-> Folder z plikami czasowymi
        internal static readonly string PROGRAM_SETTINGS_FILE = "ProgramSettings.xml"; //-> Plik xml do wczytywania/zapisywania oznaczeń
        internal static bool LoadOnStart; //->Czy wczytywać zapisane ustawienia
        internal static bool SaveCurrentMergeOpions; //->Czy wczytywać obecnie zaznaczone elementy wybrane podczas ustawień łączenia plików
        internal static string DefaultCover; //-> domyślna okładka 
        internal static string DefaultCoverExtension; //->rozszerzenie okładki
        internal static string BarcodePrefix; //->domyślny przedrostek dla kodu kreskowego
        internal static string supportedFileFilters; //->Dostępne filtry do wyszukiwania w oknie
        internal static string supportedFileExtensions; //->Dostępne filtry do spradzenia przez funkcje
        internal static bool isWordInstall; //->Sprawdzenie czy jest zainstalowany program Word
        internal static bool isExcelInstall; //->Sprawdzenie czy jest zainstalowany program Excel

        //Opcje łączenia plików
        internal static bool compression; //->informacja czy kompresować połączony plik
        internal static int ImageResolution; //->rozdzielczośc obrazów podczas kompresji  GS
        internal static string PdfPrinterSettings; //->ustawienia drukowania do GS

        //Opcje znaku wodnego
        internal static bool watermark; //->Czy dodawać znak wodny
        internal static bool WatemarkOnCover; //->Czy dodać znak wodny na okładkę
        internal static string WatermarkText;//->Tekst znaku wodnego
        internal static string WatermarkFont;//->Czcionka znaku wodnego
        internal static int WatermarkHeight;//->Wysokośc znaku wodnego
        internal static bool WatermarkBold;//->Pogrubienie znaku wodnego
        internal static bool WatermarkItalic;//->Pochylenie znaku wodnego
        internal static int[] WatermarkColor;//->Kolor znaku wodnego
        internal static int WatermarkPositionX;//->Położenie od lewej
        internal static int WatermarkPositionY;//->Położenie od góry

        //Numeracja stron
        internal static bool pageNumeration;//->Czy numerować strony
        internal static int StartNumber;//->Początkowy numer
        internal static int StartPage;//->Początkowa strona
        internal static bool CoverNumeation; //->Czy numerować okładkę
        internal static string NumberFont;//->Czcionka numerów
        internal static int NumberHeight;//->Wysokośc numerów
        internal static bool NumberItalic;//->pochylenie numerów
        internal static bool NumberBold;//->Pogrubienie numerów
        internal static int[] NumbersColor;//->Kolor numerów
        internal static int NumberPositionX;//->Pozycja numerów
        internal static int NumberPositionY;//->Pozycja numerów 
        internal static bool NumberAlignUp;//->Położenie liczone od góry
        internal static bool NumberAlignleft;//Położenie liczone od lewej
        internal static void Init() {
            ProgramPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (Environment.Is64BitOperatingSystem) {
                GS_DLL_DIR = Path.Combine(ProgramPath, "Resources", "x64");
                GS_DLL_FILE = Path.Combine(GS_DLL_DIR, "gsdll64.dll");
            } else {
                GS_DLL_DIR = Path.Combine(ProgramPath, "Resources", "x32");
                GS_DLL_FILE = Path.Combine(GS_DLL_DIR, "gsdll32.dll");
            }
            if (!Directory.Exists(TEMP_FOLDER)) {
                Directory.CreateDirectory(TEMP_FOLDER);
            }
            if (File.Exists(PROGRAM_SETTINGS_FILE) && isWindowedApplication) {
                OnLoadSettingsClas olsc = OnLoadSettingsClas.ReadAsXmlFormat<OnLoadSettingsClas>(PROGRAM_SETTINGS_FILE);
                if (olsc.LoadOnStart) {
                    LoadSettingsFromObject(olsc);
                }
            }
            if (!Directory.Exists(TEMP_FOLDER)) {
                Directory.CreateDirectory(TEMP_FOLDER);
            }
            supportedFileFilters = "Pliki PDF|*.pdf|" +
                "Pliki graficzne|*.jpg;*.bmp;*.png;*.tiff";
            string extensions = "*.pdf|*.jpg|*.bmp|*.png|*.tiff";

            try {
                Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
                isWordInstall = true;
                supportedFileFilters += "|Pliki word|*.doc;*.docx;*.docm";
                extensions += "|*.dpc|*.docx|*.docm";
            } catch (Exception) {
                isWordInstall = false;
            }

            try {
                Microsoft.Office.Interop.Excel.Application ap = new Microsoft.Office.Interop.Excel.Application();
                isExcelInstall = true;
                supportedFileFilters += "|Pliki excel|*.xls;*.xlsm;*.xlsx";
            } catch (Exception) {
                isExcelInstall = false;
            }
        }
        /// <summary>
        /// Zapisz ustawienia z obiektu klasy OnLoadSettingsClass
        /// </summary>
        public static void LoadSettingsFromObject(OnLoadSettingsClas olsc) {
            LoadOnStart = olsc.LoadOnStart;
            SaveCurrentMergeOpions = olsc.SaveCurrentMergeOpions;
            DefaultCover = olsc.DefaultCover;
            DefaultCoverExtension = olsc.DefaultCoverExtension;
            BarcodePrefix = olsc.BarcodePrefix;
            compression = olsc.compression;
            ImageResolution = olsc.ImageResolution;
            PdfPrinterSettings = olsc.PdfPrinterSettings;

            watermark = olsc.watermark;
            WatemarkOnCover = olsc.WatemarkOnCover;
            WatermarkText = olsc.WatermarkText;
            WatermarkFont = olsc.WatermarkFont;
            WatermarkHeight = olsc.WatermarkHeight;
            WatermarkBold = olsc.WatermarkBold;
            WatermarkItalic = olsc.WatermarkItalic;
            WatermarkColor = olsc.WatermarkColor;
            WatermarkPositionX = olsc.WatermarkPositionX;
            WatermarkPositionY = olsc.WatermarkPositionY;

            pageNumeration = olsc.pageNumeration;
            StartNumber = olsc.StartNumber;
            StartPage = olsc.StartPage;
            CoverNumeation = olsc.CoverNumeation;
            NumberFont = olsc.NumberFont;
            NumberHeight = olsc.NumberHeight;
            NumberItalic = olsc.NumberItalic;
            NumberBold = olsc.NumberBold;
            NumbersColor = olsc.NumbersColor;
            NumberPositionX = olsc.NumberPositionX;
            NumberPositionY = olsc.NumbersPositionY;
            NumberAlignUp = olsc.NumberAlignUp;
            NumberAlignleft = olsc.NumberAlignleft;
        }

        public static int GetCurrentPdfPrinterSettings() {
            switch (PdfPrinterSettings) {
                case "screen":
                    return 5;
                    break;
                case "ebook":
                    return 4;
                    break;
                case "printer":
                    return 3;
                    break;
                case "prepress":
                    return 2;
                    break;
                case "default":
                    return 1;
                    break;
                default:
                    PdfPrinterSettings = "default";
                    return 1;
                    break;
            }
        }

        public static void SetCurrentPdfPrinterSettings(int i) {
            switch (i) {
                case 5:
                    PdfPrinterSettings = "screen";
                    break;
                case 4:
                    PdfPrinterSettings = "ebook";
                    break;
                case 3:
                    PdfPrinterSettings = "printer";
                    break;
                case 2:
                    PdfPrinterSettings = "prepress";
                    break;
                case 1:
                    PdfPrinterSettings = "default";
                    break;
            }
        }
    }
}



