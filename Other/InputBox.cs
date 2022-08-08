/**
 * GUI inputboxa
 */
using System;
using System.Windows.Forms;

namespace OtherItems {
    public partial class InputBox : Form {
        private string _results;

        public InputBoxResults InputBoxResults;
        public InputBox(string info) {
            InitializeComponent();
            lblInfo.Text = info;
            txtValues.Visible = true;
            InputBoxResults = InputBoxResults.NothingSelected;
        }

        public InputBox(string info, string[] values) {
            InitializeComponent();
            cboValues.DataSource = values;
            lblInfo.Text = info;
            cboValues.Visible = true;
            cboValues.SelectedIndex = 0;
            InputBoxResults = InputBoxResults.NothingSelected;

        }

        public string GetResults() {
            this.ShowDialog();
            if (_results == null) {
                InputBoxResults = InputBoxResults.NothingSelected;
                return _results;
            } else if (InputBoxResults == InputBoxResults.PrintAll) {
                return _results;
            } else { 
                InputBoxResults = InputBoxResults.OK;
                return _results;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (txtValues.Visible) {
                _results = txtValues.Text;
            } else {
                _results = cboValues.Text;
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            InputBoxResults = InputBoxResults.PrintAll;
            this.Close();
        }
    }
    public enum InputBoxResults {
        OK,
        PrintAll,
        NothingSelected
    }

}
