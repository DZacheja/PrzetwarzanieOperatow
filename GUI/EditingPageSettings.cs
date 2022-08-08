/**
 * Klasa przechowuje informacje o edytowanej stronie pliku PDF
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Przetwarzanie_plikow_PDF.GUI {
    internal class EditingPageSettings {
        public Image PageImage { get; set; }  
        public int PageNumer { get; set; }
        public int PageRotation;
        public double PageXMultipiler { get; set; }
        public double PageYMultipiler { get; set; }
        public List<Control> InsertingElements { get; set; }
        public double LastZoom;

        public PdfSharp.PageOrientation originalOrientation;
        public EditingPageSettings(int page) {
            PageNumer = page;
            InsertingElements = new List<Control>();
            PageImage = null;
            PageRotation = 0;
            LastZoom = 0;
        }
    }
}
