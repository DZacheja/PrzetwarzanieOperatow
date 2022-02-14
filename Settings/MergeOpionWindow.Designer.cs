namespace ProgramConfiguration {
    partial class MergeOpionWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer compression = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (compression != null)) {
                compression.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergeOpionWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.numImgSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trcImageSize = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cboResolution = new System.Windows.Forms.ComboBox();
            this.chkPDFOptimalize = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkWatermark = new System.Windows.Forms.CheckBox();
            this.panelWatermark = new System.Windows.Forms.Panel();
            this.chkWatemarkOnCover = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numWaterY = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numWaterX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWatermark = new System.Windows.Forms.TextBox();
            this.grpTextOptions = new System.Windows.Forms.GroupBox();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFonts = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTextSize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpNumeration = new System.Windows.Forms.GroupBox();
            this.chkPgeNumeration = new System.Windows.Forms.CheckBox();
            this.panelPgeNumeration = new System.Windows.Forms.Panel();
            this.chkNumberInCover = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbnRightUp = new System.Windows.Forms.RadioButton();
            this.rbnRightDown = new System.Windows.Forms.RadioButton();
            this.rbnLeftDown = new System.Windows.Forms.RadioButton();
            this.rbnLeftUp = new System.Windows.Forms.RadioButton();
            this.lbltextAlign = new System.Windows.Forms.Label();
            this.numNumPosY = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numNumPosX = new System.Windows.Forms.NumericUpDown();
            this.numFromPages = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkItalicNumbers = new System.Windows.Forms.CheckBox();
            this.chkBoldNumbers = new System.Windows.Forms.CheckBox();
            this.btnNumberColors = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboFontsNumber = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTextSizeNumbers = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numStartNumber = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImgSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trcImageSize)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panelWatermark.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterX)).BeginInit();
            this.grpTextOptions.SuspendLayout();
            this.grpNumeration.SuspendLayout();
            this.panelPgeNumeration.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromPages)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStartNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpSettings);
            this.groupBox1.Controls.Add(this.chkPDFOptimalize);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(343, 328);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Łączenie plików";
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.numImgSize);
            this.grpSettings.Controls.Add(this.groupBox2);
            this.grpSettings.Controls.Add(this.label1);
            this.grpSettings.Controls.Add(this.cboResolution);
            this.grpSettings.Location = new System.Drawing.Point(21, 78);
            this.grpSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSettings.Size = new System.Drawing.Size(310, 231);
            this.grpSettings.TabIndex = 4;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Kompresja pliku";
            // 
            // numImgSize
            // 
            this.numImgSize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numImgSize.Location = new System.Drawing.Point(112, 197);
            this.numImgSize.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numImgSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numImgSize.Name = "numImgSize";
            this.numImgSize.Size = new System.Drawing.Size(72, 27);
            this.numImgSize.TabIndex = 7;
            this.numImgSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numImgSize.ValueChanged += new System.EventHandler(this.numImgSize_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trcImageSize);
            this.groupBox2.Location = new System.Drawing.Point(12, 101);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(292, 96);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DPI obrazów w pliku";
            // 
            // trcImageSize
            // 
            this.trcImageSize.LargeChange = 10;
            this.trcImageSize.Location = new System.Drawing.Point(6, 29);
            this.trcImageSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trcImageSize.Maximum = 600;
            this.trcImageSize.Minimum = 100;
            this.trcImageSize.Name = "trcImageSize";
            this.trcImageSize.Size = new System.Drawing.Size(270, 56);
            this.trcImageSize.SmallChange = 50;
            this.trcImageSize.TabIndex = 3;
            this.trcImageSize.TickFrequency = 50;
            this.trcImageSize.Value = 100;
            this.trcImageSize.Scroll += new System.EventHandler(this.trcImageSize_Scroll);
            this.trcImageSize.MouseLeave += new System.EventHandler(this.trcImageSize_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jakość:";
            // 
            // cboResolution
            // 
            this.cboResolution.FormattingEnabled = true;
            this.cboResolution.Items.AddRange(new object[] {
            "Niska",
            "Średnia",
            "Normalna",
            "Wysoka",
            "Najwyższa"});
            this.cboResolution.Location = new System.Drawing.Point(69, 46);
            this.cboResolution.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboResolution.Name = "cboResolution";
            this.cboResolution.Size = new System.Drawing.Size(137, 28);
            this.cboResolution.TabIndex = 1;
            this.cboResolution.SelectedIndexChanged += new System.EventHandler(this.cboResolution_SelectedIndexChanged);
            // 
            // chkPDFOptimalize
            // 
            this.chkPDFOptimalize.AutoSize = true;
            this.chkPDFOptimalize.Location = new System.Drawing.Point(21, 27);
            this.chkPDFOptimalize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkPDFOptimalize.Name = "chkPDFOptimalize";
            this.chkPDFOptimalize.Size = new System.Drawing.Size(169, 24);
            this.chkPDFOptimalize.TabIndex = 0;
            this.chkPDFOptimalize.Text = "Optymalizuj plik PDF";
            this.chkPDFOptimalize.UseVisualStyleBackColor = true;
            this.chkPDFOptimalize.CheckedChanged += new System.EventHandler(this.chkPDFOptimalize_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.save;
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOk.Location = new System.Drawing.Point(145, 364);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 50);
            this.btnOk.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnOk, "Zapisz wszystkie ustawienia");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkWatermark);
            this.groupBox3.Controls.Add(this.panelWatermark);
            this.groupBox3.Location = new System.Drawing.Point(361, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(386, 449);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tekst";
            // 
            // chkWatermark
            // 
            this.chkWatermark.AutoSize = true;
            this.chkWatermark.Location = new System.Drawing.Point(10, 27);
            this.chkWatermark.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkWatermark.Name = "chkWatermark";
            this.chkWatermark.Size = new System.Drawing.Size(223, 24);
            this.chkWatermark.TabIndex = 5;
            this.chkWatermark.Text = "Dodaj tekst na każdej stronie";
            this.chkWatermark.UseVisualStyleBackColor = true;
            this.chkWatermark.CheckedChanged += new System.EventHandler(this.chkWatermark_CheckedChanged);
            // 
            // panelWatermark
            // 
            this.panelWatermark.Controls.Add(this.chkWatemarkOnCover);
            this.panelWatermark.Controls.Add(this.groupBox5);
            this.panelWatermark.Controls.Add(this.label2);
            this.panelWatermark.Controls.Add(this.txtWatermark);
            this.panelWatermark.Controls.Add(this.grpTextOptions);
            this.panelWatermark.Location = new System.Drawing.Point(10, 58);
            this.panelWatermark.Name = "panelWatermark";
            this.panelWatermark.Size = new System.Drawing.Size(370, 383);
            this.panelWatermark.TabIndex = 18;
            // 
            // chkWatemarkOnCover
            // 
            this.chkWatemarkOnCover.AutoSize = true;
            this.chkWatemarkOnCover.Location = new System.Drawing.Point(19, 11);
            this.chkWatemarkOnCover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkWatemarkOnCover.Name = "chkWatemarkOnCover";
            this.chkWatemarkOnCover.Size = new System.Drawing.Size(155, 24);
            this.chkWatemarkOnCover.TabIndex = 25;
            this.chkWatemarkOnCover.Text = "Umieść na okładce";
            this.chkWatemarkOnCover.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numWaterY);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.numWaterX);
            this.groupBox5.Location = new System.Drawing.Point(9, 230);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(347, 144);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Położenie";
            // 
            // numWaterY
            // 
            this.numWaterY.Location = new System.Drawing.Point(10, 108);
            this.numWaterY.Maximum = new decimal(new int[] {
            594,
            0,
            0,
            0});
            this.numWaterY.Name = "numWaterY";
            this.numWaterY.Size = new System.Drawing.Size(183, 27);
            this.numWaterY.TabIndex = 6;
            this.toolTip1.SetToolTip(this.numWaterY, "Odsunięcie od górnej części papieru");
            this.numWaterY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(178, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "Odsunięcie od góry [mm]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "Odsunięcie od lewej [mm]";
            // 
            // numWaterX
            // 
            this.numWaterX.Location = new System.Drawing.Point(10, 49);
            this.numWaterX.Maximum = new decimal(new int[] {
            594,
            0,
            0,
            0});
            this.numWaterX.Name = "numWaterX";
            this.numWaterX.Size = new System.Drawing.Size(183, 27);
            this.numWaterX.TabIndex = 2;
            this.toolTip1.SetToolTip(this.numWaterX, "Odsunięcie od lewej krawędzi papieru");
            this.numWaterX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Treść:";
            // 
            // txtWatermark
            // 
            this.txtWatermark.Location = new System.Drawing.Point(9, 62);
            this.txtWatermark.Name = "txtWatermark";
            this.txtWatermark.Size = new System.Drawing.Size(347, 27);
            this.txtWatermark.TabIndex = 18;
            // 
            // grpTextOptions
            // 
            this.grpTextOptions.Controls.Add(this.chkItalic);
            this.grpTextOptions.Controls.Add(this.chkBold);
            this.grpTextOptions.Controls.Add(this.btnColor);
            this.grpTextOptions.Controls.Add(this.label7);
            this.grpTextOptions.Controls.Add(this.cboFonts);
            this.grpTextOptions.Controls.Add(this.label6);
            this.grpTextOptions.Controls.Add(this.cboTextSize);
            this.grpTextOptions.Controls.Add(this.label5);
            this.grpTextOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpTextOptions.Location = new System.Drawing.Point(9, 96);
            this.grpTextOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTextOptions.Name = "grpTextOptions";
            this.grpTextOptions.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTextOptions.Size = new System.Drawing.Size(347, 127);
            this.grpTextOptions.TabIndex = 17;
            this.grpTextOptions.TabStop = false;
            this.grpTextOptions.Text = "Konfiguracja tekstu";
            // 
            // chkItalic
            // 
            this.chkItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkItalic.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.italic;
            this.chkItalic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkItalic.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkItalic.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkItalic.Location = new System.Drawing.Point(268, 31);
            this.chkItalic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(25, 31);
            this.chkItalic.TabIndex = 21;
            this.chkItalic.TabStop = false;
            this.chkItalic.Text = " ";
            this.chkItalic.UseVisualStyleBackColor = true;
            // 
            // chkBold
            // 
            this.chkBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBold.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.bold_text;
            this.chkBold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkBold.FlatAppearance.BorderSize = 0;
            this.chkBold.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkBold.Location = new System.Drawing.Point(237, 31);
            this.chkBold.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(25, 31);
            this.chkBold.TabIndex = 19;
            this.chkBold.TabStop = false;
            this.chkBold.UseVisualStyleBackColor = true;
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnColor.Location = new System.Drawing.Point(260, 74);
            this.btnColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(33, 32);
            this.btnColor.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnColor, "Wybierz kolor znaku wodneg");
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(212, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "Kolor:";
            // 
            // cboFonts
            // 
            this.cboFonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboFonts.FormattingEnabled = true;
            this.cboFonts.Location = new System.Drawing.Point(80, 36);
            this.cboFonts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboFonts.Name = "cboFonts";
            this.cboFonts.Size = new System.Drawing.Size(151, 24);
            this.cboFonts.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(10, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "Czcionka:";
            // 
            // cboTextSize
            // 
            this.cboTextSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboTextSize.FormattingEnabled = true;
            this.cboTextSize.Location = new System.Drawing.Point(80, 79);
            this.cboTextSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTextSize.Name = "cboTextSize";
            this.cboTextSize.Size = new System.Drawing.Size(71, 24);
            this.cboTextSize.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(10, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "Wielkość:";
            // 
            // grpNumeration
            // 
            this.grpNumeration.Controls.Add(this.chkPgeNumeration);
            this.grpNumeration.Controls.Add(this.panelPgeNumeration);
            this.grpNumeration.Location = new System.Drawing.Point(753, 15);
            this.grpNumeration.Name = "grpNumeration";
            this.grpNumeration.Size = new System.Drawing.Size(386, 449);
            this.grpNumeration.TabIndex = 19;
            this.grpNumeration.TabStop = false;
            this.grpNumeration.Text = "Numeracja stron";
            // 
            // chkPgeNumeration
            // 
            this.chkPgeNumeration.AutoSize = true;
            this.chkPgeNumeration.Location = new System.Drawing.Point(10, 27);
            this.chkPgeNumeration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkPgeNumeration.Name = "chkPgeNumeration";
            this.chkPgeNumeration.Size = new System.Drawing.Size(132, 24);
            this.chkPgeNumeration.TabIndex = 5;
            this.chkPgeNumeration.Text = "Numeruj strony";
            this.chkPgeNumeration.UseVisualStyleBackColor = true;
            this.chkPgeNumeration.CheckedChanged += new System.EventHandler(this.chkPgeNumeration_CheckedChanged);
            // 
            // panelPgeNumeration
            // 
            this.panelPgeNumeration.Controls.Add(this.chkNumberInCover);
            this.panelPgeNumeration.Controls.Add(this.groupBox6);
            this.panelPgeNumeration.Controls.Add(this.numFromPages);
            this.panelPgeNumeration.Controls.Add(this.label10);
            this.panelPgeNumeration.Controls.Add(this.groupBox4);
            this.panelPgeNumeration.Controls.Add(this.label3);
            this.panelPgeNumeration.Controls.Add(this.numStartNumber);
            this.panelPgeNumeration.Location = new System.Drawing.Point(10, 58);
            this.panelPgeNumeration.Name = "panelPgeNumeration";
            this.panelPgeNumeration.Size = new System.Drawing.Size(370, 383);
            this.panelPgeNumeration.TabIndex = 18;
            // 
            // chkNumberInCover
            // 
            this.chkNumberInCover.AutoSize = true;
            this.chkNumberInCover.Location = new System.Drawing.Point(9, 11);
            this.chkNumberInCover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkNumberInCover.Name = "chkNumberInCover";
            this.chkNumberInCover.Size = new System.Drawing.Size(144, 24);
            this.chkNumberInCover.TabIndex = 19;
            this.chkNumberInCover.Text = "Numeruj okładkę";
            this.chkNumberInCover.UseVisualStyleBackColor = true;
            this.chkNumberInCover.CheckedChanged += new System.EventHandler(this.chkNumberInCover_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbnRightUp);
            this.groupBox6.Controls.Add(this.rbnRightDown);
            this.groupBox6.Controls.Add(this.rbnLeftDown);
            this.groupBox6.Controls.Add(this.rbnLeftUp);
            this.groupBox6.Controls.Add(this.lbltextAlign);
            this.groupBox6.Controls.Add(this.numNumPosY);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.numNumPosX);
            this.groupBox6.Location = new System.Drawing.Point(9, 227);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(347, 144);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Położenie";
            // 
            // rbnRightUp
            // 
            this.rbnRightUp.AutoSize = true;
            this.rbnRightUp.Location = new System.Drawing.Point(199, 82);
            this.rbnRightUp.Name = "rbnRightUp";
            this.rbnRightUp.Size = new System.Drawing.Size(138, 24);
            this.rbnRightUp.TabIndex = 9;
            this.rbnRightUp.Text = "Prawy górny róg";
            this.rbnRightUp.UseVisualStyleBackColor = true;
            this.rbnRightUp.CheckedChanged += new System.EventHandler(this.SetUpNumberAlignOption);
            // 
            // rbnRightDown
            // 
            this.rbnRightDown.AutoSize = true;
            this.rbnRightDown.Location = new System.Drawing.Point(199, 107);
            this.rbnRightDown.Name = "rbnRightDown";
            this.rbnRightDown.Size = new System.Drawing.Size(137, 24);
            this.rbnRightDown.TabIndex = 8;
            this.rbnRightDown.Text = "Prawy dolny róg";
            this.rbnRightDown.UseVisualStyleBackColor = true;
            this.rbnRightDown.CheckedChanged += new System.EventHandler(this.SetUpNumberAlignOption);
            // 
            // rbnLeftDown
            // 
            this.rbnLeftDown.AutoSize = true;
            this.rbnLeftDown.Location = new System.Drawing.Point(199, 54);
            this.rbnLeftDown.Name = "rbnLeftDown";
            this.rbnLeftDown.Size = new System.Drawing.Size(131, 24);
            this.rbnLeftDown.TabIndex = 7;
            this.rbnLeftDown.Text = "Lewy dolny róg";
            this.rbnLeftDown.UseVisualStyleBackColor = true;
            this.rbnLeftDown.CheckedChanged += new System.EventHandler(this.SetUpNumberAlignOption);
            // 
            // rbnLeftUp
            // 
            this.rbnLeftUp.AutoSize = true;
            this.rbnLeftUp.Checked = true;
            this.rbnLeftUp.Location = new System.Drawing.Point(199, 28);
            this.rbnLeftUp.Name = "rbnLeftUp";
            this.rbnLeftUp.Size = new System.Drawing.Size(132, 24);
            this.rbnLeftUp.TabIndex = 6;
            this.rbnLeftUp.TabStop = true;
            this.rbnLeftUp.Text = "Lewy górny róg";
            this.rbnLeftUp.UseVisualStyleBackColor = true;
            this.rbnLeftUp.CheckedChanged += new System.EventHandler(this.SetUpNumberAlignOption);
            // 
            // lbltextAlign
            // 
            this.lbltextAlign.AutoSize = true;
            this.lbltextAlign.Location = new System.Drawing.Point(10, 82);
            this.lbltextAlign.Name = "lbltextAlign";
            this.lbltextAlign.Size = new System.Drawing.Size(184, 20);
            this.lbltextAlign.TabIndex = 5;
            this.lbltextAlign.Text = "Odsunięcie pionowe [mm]";
            // 
            // numNumPosY
            // 
            this.numNumPosY.Location = new System.Drawing.Point(10, 105);
            this.numNumPosY.Maximum = new decimal(new int[] {
            594,
            0,
            0,
            0});
            this.numNumPosY.Name = "numNumPosY";
            this.numNumPosY.Size = new System.Drawing.Size(183, 27);
            this.numNumPosY.TabIndex = 4;
            this.toolTip1.SetToolTip(this.numNumPosY, "Odsunięcia od pionowej krawędzi papieru");
            this.numNumPosY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(185, 20);
            this.label14.TabIndex = 3;
            this.label14.Text = "Odsunięcie poziome [mm]";
            // 
            // numNumPosX
            // 
            this.numNumPosX.Location = new System.Drawing.Point(10, 49);
            this.numNumPosX.Maximum = new decimal(new int[] {
            594,
            0,
            0,
            0});
            this.numNumPosX.Name = "numNumPosX";
            this.numNumPosX.Size = new System.Drawing.Size(183, 27);
            this.numNumPosX.TabIndex = 2;
            this.toolTip1.SetToolTip(this.numNumPosX, "Odsunięcia od poziomej krawędzi papieru");
            this.numNumPosX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numFromPages
            // 
            this.numFromPages.Location = new System.Drawing.Point(179, 62);
            this.numFromPages.Name = "numFromPages";
            this.numFromPages.Size = new System.Drawing.Size(132, 27);
            this.numFromPages.TabIndex = 24;
            this.numFromPages.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(188, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Numeruj od strony";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkItalicNumbers);
            this.groupBox4.Controls.Add(this.chkBoldNumbers);
            this.groupBox4.Controls.Add(this.btnNumberColors);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cboFontsNumber);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.cboTextSizeNumbers);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(9, 96);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(347, 124);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Wygląd numerów";
            // 
            // chkItalicNumbers
            // 
            this.chkItalicNumbers.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkItalicNumbers.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.italic;
            this.chkItalicNumbers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkItalicNumbers.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkItalicNumbers.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkItalicNumbers.Location = new System.Drawing.Point(268, 27);
            this.chkItalicNumbers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkItalicNumbers.Name = "chkItalicNumbers";
            this.chkItalicNumbers.Size = new System.Drawing.Size(25, 31);
            this.chkItalicNumbers.TabIndex = 21;
            this.chkItalicNumbers.TabStop = false;
            this.chkItalicNumbers.Text = " ";
            this.chkItalicNumbers.UseVisualStyleBackColor = true;
            // 
            // chkBoldNumbers
            // 
            this.chkBoldNumbers.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBoldNumbers.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.bold_text;
            this.chkBoldNumbers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkBoldNumbers.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBoldNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkBoldNumbers.Location = new System.Drawing.Point(237, 27);
            this.chkBoldNumbers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkBoldNumbers.Name = "chkBoldNumbers";
            this.chkBoldNumbers.Size = new System.Drawing.Size(25, 31);
            this.chkBoldNumbers.TabIndex = 19;
            this.chkBoldNumbers.TabStop = false;
            this.chkBoldNumbers.UseVisualStyleBackColor = true;
            // 
            // btnNumberColors
            // 
            this.btnNumberColors.BackColor = System.Drawing.Color.Black;
            this.btnNumberColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNumberColors.Location = new System.Drawing.Point(260, 64);
            this.btnNumberColors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNumberColors.Name = "btnNumberColors";
            this.btnNumberColors.Size = new System.Drawing.Size(33, 32);
            this.btnNumberColors.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnNumberColors, "Wybierz kolor tekstu");
            this.btnNumberColors.UseVisualStyleBackColor = false;
            this.btnNumberColors.Click += new System.EventHandler(this.btnNumberColors_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(212, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "Kolor:";
            // 
            // cboFontsNumber
            // 
            this.cboFontsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboFontsNumber.FormattingEnabled = true;
            this.cboFontsNumber.Location = new System.Drawing.Point(80, 32);
            this.cboFontsNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboFontsNumber.Name = "cboFontsNumber";
            this.cboFontsNumber.Size = new System.Drawing.Size(151, 24);
            this.cboFontsNumber.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(10, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 18);
            this.label8.TabIndex = 18;
            this.label8.Text = "Czcionka:";
            // 
            // cboTextSizeNumbers
            // 
            this.cboTextSizeNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboTextSizeNumbers.FormattingEnabled = true;
            this.cboTextSizeNumbers.Location = new System.Drawing.Point(80, 73);
            this.cboTextSizeNumbers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTextSizeNumbers.Name = "cboTextSizeNumbers";
            this.cboTextSizeNumbers.Size = new System.Drawing.Size(71, 24);
            this.cboTextSizeNumbers.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(10, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "Wielkość:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Początkowy numer";
            // 
            // numStartNumber
            // 
            this.numStartNumber.Location = new System.Drawing.Point(9, 62);
            this.numStartNumber.Name = "numStartNumber";
            this.numStartNumber.Size = new System.Drawing.Size(132, 27);
            this.numStartNumber.TabIndex = 0;
            this.numStartNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MergeOpionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 478);
            this.Controls.Add(this.grpNumeration);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MergeOpionWindow";
            this.Text = "Ustawienia";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImgSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trcImageSize)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelWatermark.ResumeLayout(false);
            this.panelWatermark.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterX)).EndInit();
            this.grpTextOptions.ResumeLayout(false);
            this.grpTextOptions.PerformLayout();
            this.grpNumeration.ResumeLayout(false);
            this.grpNumeration.PerformLayout();
            this.panelPgeNumeration.ResumeLayout(false);
            this.panelPgeNumeration.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromPages)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStartNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboResolution;
        private System.Windows.Forms.CheckBox chkPDFOptimalize;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.TrackBar trcImageSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.NumericUpDown numImgSize;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkWatermark;
        private System.Windows.Forms.Panel panelWatermark;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numWaterFromUp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numWaterX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWatermark;
        private System.Windows.Forms.GroupBox grpTextOptions;
        private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboFonts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTextSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpNumeration;
        private System.Windows.Forms.CheckBox chkPgeNumeration;
        private System.Windows.Forms.Panel panelPgeNumeration;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbltextAlign;
        private System.Windows.Forms.NumericUpDown numNumPosY;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numNumPosX;
        private System.Windows.Forms.NumericUpDown numFromPages;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkItalicNumbers;
        private System.Windows.Forms.CheckBox chkBoldNumbers;
        private System.Windows.Forms.Button btnNumberColors;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFontsNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTextSizeNumbers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numStartNumber;
        private System.Windows.Forms.CheckBox chkNumberInCover;
        private System.Windows.Forms.RadioButton rbnLeftUp;
        private System.Windows.Forms.RadioButton rbnLeftDown;
        private System.Windows.Forms.NumericUpDown numWaterY;
        private System.Windows.Forms.RadioButton rbnRightUp;
        private System.Windows.Forms.RadioButton rbnRightDown;
        private System.Windows.Forms.CheckBox chkWatemarkOnCover;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.IContainer components;
    }
}