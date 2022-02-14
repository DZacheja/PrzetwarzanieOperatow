/*
 * Klasa zawiera te same elementy co ProgramSettings
 * jednak nie jest klasą statyczną dzięki czemu można z łatwością
 * zapisać elementy do XML i wczytaj z XML
 */
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace ProgramConfiguration {
    public class OnLoadSettingsClas {
        
        public bool LoadOnStart;
        public bool SaveCurrentMergeOpions;
        public string DefaultCover;
        public string DefaultCoverExtension;
        public string BarcodePrefix;

        //Łączenie plików
        public bool compression; 
        public int ImageResolution; 
        public string PdfPrinterSettings;

        //Znak wodny
        public bool watermark;
        public bool WatemarkOnCover;
        public string WatermarkText;
        public string WatermarkFont;
        public int WatermarkHeight;
        public bool WatermarkBold;
        public bool WatermarkItalic;
        public int[] WatermarkColor;
        public int WatermarkPositionX;
        public int WatermarkPositionY;

        //Numeracja stron
        public bool pageNumeration;
        public bool NumberAlignUp;
        public bool NumberAlignleft;
        public int StartNumber;
        public int StartPage;
        public bool CoverNumeation;
        public string NumberFont;
        public int NumberHeight;
        public bool NumberItalic;
        public bool NumberBold;
        public int[] NumbersColor;
        public int NumberPositionX;
        public int NumbersPositionY;

        public OnLoadSettingsClas() { }

        public static void SaveAsXmlFormat<T>(T obj, string filename) {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
            using (Stream fstream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None)) {
                xmlFormat.Serialize(fstream, obj);
            }
        }

        public static T ReadAsXmlFormat<T>(string fileName) {
            // Create a typed instance of the XmlSerializer
            XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read)) {
                T obj = default;
                obj = (T)xmlFormat.Deserialize(fStream);
                return obj;
            }
        }
    }
}
