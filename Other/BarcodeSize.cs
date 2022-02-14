/*
 * GUI do dodania nowego rozmiaru kodu kreskowego
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProgramConfiguration {
    public partial class BarcodeSize : Form {
        private ComboBox cboBox;
        public BarcodeSize(ComboBox cbo) {
            InitializeComponent();
            cboBox = cbo;
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            string file = Path.Combine(ProgramSettings.ProgramPath, "BarcodeLabelSizes.txt");
            List<string> elements = new List<string>();
            if (File.Exists(file)) {
                elements.AddRange(File.ReadAllLines(file));
            }
            try {
                string selectedSize = numWidth.Value.ToString() + "x" + numHeight.Value.ToString();
                elements.Add(selectedSize);
                cboBox.DataSource = elements;
                FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(fs)) {
                    elements.Sort();
                    foreach (string element in elements) {
                        sw.WriteLine(element);
                    }
                    
                }
                fs.Close();
                this.Close();
            } catch (Exception) {

                MessageBox.Show("Wpisano błędne dane");
            }
        }
    }

}