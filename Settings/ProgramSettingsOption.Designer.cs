namespace ProgramConfiguration {
    partial class ProgramSettingsOption {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.chkReadOnLoad = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBarcodePrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCoverClear = new System.Windows.Forms.Button();
            this.txtCoverPath = new System.Windows.Forms.TextBox();
            this.btnSearchFor = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkLoadMergeSettings = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkReadOnLoad
            // 
            this.chkReadOnLoad.AutoSize = true;
            this.chkReadOnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkReadOnLoad.Location = new System.Drawing.Point(6, 26);
            this.chkReadOnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkReadOnLoad.Name = "chkReadOnLoad";
            this.chkReadOnLoad.Size = new System.Drawing.Size(330, 24);
            this.chkReadOnLoad.TabIndex = 1;
            this.chkReadOnLoad.Text = "Wczytuj ustawienia po starcie programu";
            this.chkReadOnLoad.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkReadOnLoad.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 449);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLoadFromFile);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.btnSaveToFile);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 318);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(435, 62);
            this.panel2.TabIndex = 9;
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.search_file;
            this.btnLoadFromFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoadFromFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLoadFromFile.Location = new System.Drawing.Point(169, 5);
            this.btnLoadFromFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(50, 52);
            this.btnLoadFromFile.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnLoadFromFile, "Wczytaj ustawienia z pliku");
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(137, 5);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(32, 52);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.save_file;
            this.btnSaveToFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveToFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaveToFile.Location = new System.Drawing.Point(87, 5);
            this.btnSaveToFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(50, 52);
            this.btnSaveToFile.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnSaveToFile, "Zapisz obecne ustawienia do pliku");
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(55, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(32, 52);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Location = new System.Drawing.Point(5, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 52);
            this.btnSave.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnSave, "Zapisz zmiany");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBarcodePrefix);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(0, 197);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(435, 121);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Domyślne wartości:";
            // 
            // txtBarcodePrefix
            // 
            this.txtBarcodePrefix.Location = new System.Drawing.Point(12, 76);
            this.txtBarcodePrefix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBarcodePrefix.Name = "txtBarcodePrefix";
            this.txtBarcodePrefix.Size = new System.Drawing.Size(324, 27);
            this.txtBarcodePrefix.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Początek kodu kreskowego";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCoverClear);
            this.groupBox1.Controls.Add(this.txtCoverPath);
            this.groupBox1.Controls.Add(this.btnSearchFor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 111);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(435, 86);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Domyślna okładka";
            // 
            // btnCoverClear
            // 
            this.btnCoverClear.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.delete;
            this.btnCoverClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCoverClear.Location = new System.Drawing.Point(306, 25);
            this.btnCoverClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCoverClear.Name = "btnCoverClear";
            this.btnCoverClear.Size = new System.Drawing.Size(35, 40);
            this.btnCoverClear.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnCoverClear, "Usuń domyślną okładkę");
            this.btnCoverClear.UseVisualStyleBackColor = true;
            this.btnCoverClear.Click += new System.EventHandler(this.btnCoverClear_Click);
            // 
            // txtCoverPath
            // 
            this.txtCoverPath.Location = new System.Drawing.Point(12, 32);
            this.txtCoverPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCoverPath.Name = "txtCoverPath";
            this.txtCoverPath.ReadOnly = true;
            this.txtCoverPath.Size = new System.Drawing.Size(252, 27);
            this.txtCoverPath.TabIndex = 3;
            // 
            // btnSearchFor
            // 
            this.btnSearchFor.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.search_file;
            this.btnSearchFor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchFor.Location = new System.Drawing.Point(270, 25);
            this.btnSearchFor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearchFor.Name = "btnSearchFor";
            this.btnSearchFor.Size = new System.Drawing.Size(35, 40);
            this.btnSearchFor.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnSearchFor, "Wybierz okładkę domyślną");
            this.btnSearchFor.UseVisualStyleBackColor = true;
            this.btnSearchFor.Click += new System.EventHandler(this.btnSearchFor_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkLoadMergeSettings);
            this.groupBox3.Controls.Add(this.chkReadOnLoad);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(435, 111);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Opcje ogólne";
            // 
            // chkLoadMergeSettings
            // 
            this.chkLoadMergeSettings.AutoSize = true;
            this.chkLoadMergeSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkLoadMergeSettings.Location = new System.Drawing.Point(6, 59);
            this.chkLoadMergeSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkLoadMergeSettings.Name = "chkLoadMergeSettings";
            this.chkLoadMergeSettings.Size = new System.Drawing.Size(366, 24);
            this.chkLoadMergeSettings.TabIndex = 2;
            this.chkLoadMergeSettings.Text = "Zapisuj wybierane ustawienia łączenia plików";
            this.chkLoadMergeSettings.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkLoadMergeSettings.UseVisualStyleBackColor = true;
            // 
            // ProgramSettingsOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 449);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramSettingsOption";
            this.Text = "Ustawienia programu";
            this.Load += new System.EventHandler(this.UstawieniaProgramu_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkReadOnLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBarcodePrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCoverPath;
        private System.Windows.Forms.Button btnSearchFor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkLoadMergeSettings;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnCoverClear;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Splitter splitter1;
    }
}