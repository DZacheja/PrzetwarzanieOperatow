namespace GUI {
    partial class PdfEditForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfEditForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PanelPDF = new System.Windows.Forms.Panel();
            this.grpDocument = new System.Windows.Forms.GroupBox();
            this.picDocument = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grpInCompressing = new System.Windows.Forms.GroupBox();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.lblDeleteInfo = new System.Windows.Forms.Label();
            this.grpPageNumbers = new System.Windows.Forms.GroupBox();
            this.txtPageNumber = new System.Windows.Forms.TextBox();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.grpTextOptions = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTextAlignRight = new System.Windows.Forms.Button();
            this.btnTextAlignCenter = new System.Windows.Forms.Button();
            this.btnTextAlignLeft = new System.Windows.Forms.Button();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFonts = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTextSize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.btnAddText = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnSaveDoc = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveBarcodeSize = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddBarcodeSize = new System.Windows.Forms.Button();
            this.cboBarSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCodeBar = new System.Windows.Forms.Button();
            this.txtCodeBarText = new System.Windows.Forms.TextBox();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.PanelPDF.SuspendLayout();
            this.grpDocument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDocument)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpInCompressing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.grpPageNumbers.SuspendLayout();
            this.grpTextOptions.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PanelPDF);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1033, 1030);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // PanelPDF
            // 
            this.PanelPDF.AutoScroll = true;
            this.PanelPDF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelPDF.Controls.Add(this.grpDocument);
            this.PanelPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPDF.Location = new System.Drawing.Point(3, 235);
            this.PanelPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PanelPDF.Name = "PanelPDF";
            this.PanelPDF.Size = new System.Drawing.Size(1027, 791);
            this.PanelPDF.TabIndex = 11;
            // 
            // grpDocument
            // 
            this.grpDocument.Controls.Add(this.picDocument);
            this.grpDocument.Location = new System.Drawing.Point(0, 0);
            this.grpDocument.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDocument.Name = "grpDocument";
            this.grpDocument.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDocument.Size = new System.Drawing.Size(1000, 1680);
            this.grpDocument.TabIndex = 15;
            this.grpDocument.TabStop = false;
            // 
            // picDocument
            // 
            this.picDocument.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDocument.Location = new System.Drawing.Point(3, 23);
            this.picDocument.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picDocument.Name = "picDocument";
            this.picDocument.Size = new System.Drawing.Size(994, 1653);
            this.picDocument.TabIndex = 0;
            this.picDocument.TabStop = false;
            this.picDocument.Click += new System.EventHandler(this.picDocument_Click);
            this.picDocument.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDocument_MouseMove);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.grpInCompressing);
            this.groupBox2.Controls.Add(this.lblDeleteInfo);
            this.groupBox2.Controls.Add(this.grpPageNumbers);
            this.groupBox2.Controls.Add(this.grpTextOptions);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnZoomIn);
            this.groupBox2.Controls.Add(this.btnZoomOut);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(3, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(1027, 212);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operacje na pliku";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.redo_arrow;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(957, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 33);
            this.button1.TabIndex = 5;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.button1, "Obróc strone zgodnie z ruchem wskazówek zegara");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpInCompressing
            // 
            this.grpInCompressing.Controls.Add(this.picLoading);
            this.grpInCompressing.Controls.Add(this.lblProcessing);
            this.grpInCompressing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpInCompressing.Location = new System.Drawing.Point(552, 129);
            this.grpInCompressing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpInCompressing.Name = "grpInCompressing";
            this.grpInCompressing.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpInCompressing.Size = new System.Drawing.Size(408, 73);
            this.grpInCompressing.TabIndex = 20;
            this.grpInCompressing.TabStop = false;
            this.grpInCompressing.Text = "Przetwarzanie ";
            this.grpInCompressing.Visible = false;
            // 
            // picLoading
            // 
            this.picLoading.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.pending_work;
            this.picLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLoading.Location = new System.Drawing.Point(16, 25);
            this.picLoading.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(48, 44);
            this.picLoading.TabIndex = 20;
            this.picLoading.TabStop = false;
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProcessing.Location = new System.Drawing.Point(70, 33);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(329, 20);
            this.lblProcessing.TabIndex = 19;
            this.lblProcessing.Text = "Proszę czekać trwa wyświetlanie nowej strony";
            // 
            // lblDeleteInfo
            // 
            this.lblDeleteInfo.AutoSize = true;
            this.lblDeleteInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDeleteInfo.ForeColor = System.Drawing.Color.Red;
            this.lblDeleteInfo.Location = new System.Drawing.Point(546, 188);
            this.lblDeleteInfo.Name = "lblDeleteInfo";
            this.lblDeleteInfo.Size = new System.Drawing.Size(455, 20);
            this.lblDeleteInfo.TabIndex = 13;
            this.lblDeleteInfo.Text = "USUWANIE WSKAZANYCH ELEMENTÓW AKTYWNE";
            this.lblDeleteInfo.Visible = false;
            // 
            // grpPageNumbers
            // 
            this.grpPageNumbers.Controls.Add(this.txtPageNumber);
            this.grpPageNumbers.Controls.Add(this.btnNextPage);
            this.grpPageNumbers.Controls.Add(this.btnPreviousPage);
            this.grpPageNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpPageNumbers.Location = new System.Drawing.Point(248, 129);
            this.grpPageNumbers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpPageNumbers.Name = "grpPageNumbers";
            this.grpPageNumbers.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpPageNumbers.Size = new System.Drawing.Size(204, 79);
            this.grpPageNumbers.TabIndex = 19;
            this.grpPageNumbers.TabStop = false;
            this.grpPageNumbers.Text = "Strony:";
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Location = new System.Drawing.Point(6, 32);
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.Size = new System.Drawing.Size(115, 25);
            this.txtPageNumber.TabIndex = 2;
            this.txtPageNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageNumber_KeyPress);
            // 
            // btnNextPage
            // 
            this.btnNextPage.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.right_arrow;
            this.btnNextPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNextPage.Location = new System.Drawing.Point(162, 29);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(33, 33);
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnNextPage, "Następna strona");
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.left_arrow;
            this.btnPreviousPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPreviousPage.Location = new System.Drawing.Point(126, 29);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(33, 33);
            this.btnPreviousPage.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnPreviousPage, "Poprzednia strona");
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // grpTextOptions
            // 
            this.grpTextOptions.Controls.Add(this.label2);
            this.grpTextOptions.Controls.Add(this.btnTextAlignRight);
            this.grpTextOptions.Controls.Add(this.btnTextAlignCenter);
            this.grpTextOptions.Controls.Add(this.btnTextAlignLeft);
            this.grpTextOptions.Controls.Add(this.chkItalic);
            this.grpTextOptions.Controls.Add(this.chkBold);
            this.grpTextOptions.Controls.Add(this.btnColor);
            this.grpTextOptions.Controls.Add(this.label7);
            this.grpTextOptions.Controls.Add(this.cboFonts);
            this.grpTextOptions.Controls.Add(this.label6);
            this.grpTextOptions.Controls.Add(this.cboTextSize);
            this.grpTextOptions.Controls.Add(this.label5);
            this.grpTextOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpTextOptions.Location = new System.Drawing.Point(527, 21);
            this.grpTextOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTextOptions.Name = "grpTextOptions";
            this.grpTextOptions.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTextOptions.Size = new System.Drawing.Size(433, 101);
            this.grpTextOptions.TabIndex = 16;
            this.grpTextOptions.TabStop = false;
            this.grpTextOptions.Text = "Konfiguracja tekstu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Położenie:";
            // 
            // btnTextAlignRight
            // 
            this.btnTextAlignRight.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.text_align_right;
            this.btnTextAlignRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTextAlignRight.Location = new System.Drawing.Point(399, 66);
            this.btnTextAlignRight.Name = "btnTextAlignRight";
            this.btnTextAlignRight.Size = new System.Drawing.Size(28, 31);
            this.btnTextAlignRight.TabIndex = 24;
            this.btnTextAlignRight.UseVisualStyleBackColor = true;
            this.btnTextAlignRight.Click += new System.EventHandler(this.btnTextAlignRight_Click);
            // 
            // btnTextAlignCenter
            // 
            this.btnTextAlignCenter.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.text_align_center;
            this.btnTextAlignCenter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTextAlignCenter.Location = new System.Drawing.Point(365, 66);
            this.btnTextAlignCenter.Name = "btnTextAlignCenter";
            this.btnTextAlignCenter.Size = new System.Drawing.Size(28, 31);
            this.btnTextAlignCenter.TabIndex = 23;
            this.btnTextAlignCenter.UseVisualStyleBackColor = true;
            this.btnTextAlignCenter.Click += new System.EventHandler(this.btnTextAlignCenter_Click);
            // 
            // btnTextAlignLeft
            // 
            this.btnTextAlignLeft.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.text_align_left;
            this.btnTextAlignLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTextAlignLeft.Location = new System.Drawing.Point(331, 66);
            this.btnTextAlignLeft.Name = "btnTextAlignLeft";
            this.btnTextAlignLeft.Size = new System.Drawing.Size(28, 31);
            this.btnTextAlignLeft.TabIndex = 22;
            this.btnTextAlignLeft.UseVisualStyleBackColor = true;
            this.btnTextAlignLeft.Click += new System.EventHandler(this.btnTextAlignLeft_Click);
            // 
            // chkItalic
            // 
            this.chkItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkItalic.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.italic;
            this.chkItalic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkItalic.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkItalic.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkItalic.Location = new System.Drawing.Point(284, 30);
            this.chkItalic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(25, 29);
            this.chkItalic.TabIndex = 21;
            this.chkItalic.TabStop = false;
            this.chkItalic.Text = " ";
            this.toolTip1.SetToolTip(this.chkItalic, "Pochyl tekst");
            this.chkItalic.UseVisualStyleBackColor = true;
            this.chkItalic.CheckedChanged += new System.EventHandler(this.FontCheck);
            // 
            // chkBold
            // 
            this.chkBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBold.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.bold_text;
            this.chkBold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkBold.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkBold.Location = new System.Drawing.Point(253, 30);
            this.chkBold.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(25, 29);
            this.chkBold.TabIndex = 19;
            this.chkBold.TabStop = false;
            this.toolTip1.SetToolTip(this.chkBold, "Pogrubienie tekstu");
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.CheckedChanged += new System.EventHandler(this.FontCheck);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnColor.Location = new System.Drawing.Point(278, 66);
            this.btnColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(33, 30);
            this.btnColor.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnColor, "Wybierz kolor tekstu");
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Kolor:";
            // 
            // cboFonts
            // 
            this.cboFonts.FormattingEnabled = true;
            this.cboFonts.Location = new System.Drawing.Point(96, 32);
            this.cboFonts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboFonts.Name = "cboFonts";
            this.cboFonts.Size = new System.Drawing.Size(151, 28);
            this.cboFonts.TabIndex = 19;
            this.cboFonts.SelectedIndexChanged += new System.EventHandler(this.cboFonts_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(9, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Czcionka:";
            // 
            // cboTextSize
            // 
            this.cboTextSize.FormattingEnabled = true;
            this.cboTextSize.Location = new System.Drawing.Point(96, 67);
            this.cboTextSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTextSize.Name = "cboTextSize";
            this.cboTextSize.Size = new System.Drawing.Size(71, 28);
            this.cboTextSize.TabIndex = 17;
            this.cboTextSize.SelectedIndexChanged += new System.EventHandler(this.cboTextSize_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Wielkość:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAddImage);
            this.groupBox5.Controls.Add(this.chkDelete);
            this.groupBox5.Controls.Add(this.btnAddText);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox5.Location = new System.Drawing.Point(6, 129);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(236, 79);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Dodawanie elementów";
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.image_add;
            this.btnAddImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddImage.Location = new System.Drawing.Point(82, 30);
            this.btnAddImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(40, 38);
            this.btnAddImage.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnAddImage, "Dodaj obraz");
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // chkDelete
            // 
            this.chkDelete.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDelete.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.delete;
            this.chkDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.chkDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDelete.Location = new System.Drawing.Point(144, 30);
            this.chkDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(40, 38);
            this.chkDelete.TabIndex = 18;
            this.chkDelete.TabStop = false;
            this.toolTip1.SetToolTip(this.chkDelete, "Usuń element");
            this.chkDelete.UseVisualStyleBackColor = true;
            this.chkDelete.CheckedChanged += new System.EventHandler(this.chkDelete_CheckedChanged);
            // 
            // btnAddText
            // 
            this.btnAddText.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.text_add;
            this.btnAddText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddText.Location = new System.Drawing.Point(20, 30);
            this.btnAddText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddText.Name = "btnAddText";
            this.btnAddText.Size = new System.Drawing.Size(40, 38);
            this.btnAddText.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnAddText, "Dodaj tekst");
            this.btnAddText.UseVisualStyleBackColor = true;
            this.btnAddText.Click += new System.EventHandler(this.btnAddText_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSaveChanges);
            this.groupBox4.Controls.Add(this.btnSaveDoc);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(6, 21);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(116, 67);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Zapisywanie";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.tick;
            this.btnSaveChanges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveChanges.Location = new System.Drawing.Point(8, 30);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(30, 28);
            this.btnSaveChanges.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnSaveChanges, "Zapisz zmiany");
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnSaveDoc
            // 
            this.btnSaveDoc.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.save_file;
            this.btnSaveDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveDoc.Location = new System.Drawing.Point(53, 28);
            this.btnSaveDoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveDoc.Name = "btnSaveDoc";
            this.btnSaveDoc.Size = new System.Drawing.Size(35, 33);
            this.btnSaveDoc.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnSaveDoc, "Zapisz zmiany do pliku");
            this.btnSaveDoc.UseVisualStyleBackColor = true;
            this.btnSaveDoc.Click += new System.EventHandler(this.btnSaveDoc_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemoveBarcodeSize);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnAddBarcodeSize);
            this.groupBox3.Controls.Add(this.cboBarSize);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnCodeBar);
            this.groupBox3.Controls.Add(this.txtCodeBarText);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(127, 21);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(393, 101);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Konfiguracja kodu kreskowego";
            // 
            // btnRemoveBarcodeSize
            // 
            this.btnRemoveBarcodeSize.BackColor = System.Drawing.SystemColors.Control;
            this.btnRemoveBarcodeSize.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.minus_round;
            this.btnRemoveBarcodeSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveBarcodeSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveBarcodeSize.Location = new System.Drawing.Point(331, 62);
            this.btnRemoveBarcodeSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveBarcodeSize.Name = "btnRemoveBarcodeSize";
            this.btnRemoveBarcodeSize.Size = new System.Drawing.Size(34, 28);
            this.btnRemoveBarcodeSize.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnRemoveBarcodeSize, "Usuń wybrany rozmiar z listy");
            this.btnRemoveBarcodeSize.UseVisualStyleBackColor = false;
            this.btnRemoveBarcodeSize.Click += new System.EventHandler(this.btnRemoveBarcodeSize_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "[mm]";
            // 
            // btnAddBarcodeSize
            // 
            this.btnAddBarcodeSize.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddBarcodeSize.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.plus_round;
            this.btnAddBarcodeSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddBarcodeSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddBarcodeSize.Location = new System.Drawing.Point(291, 62);
            this.btnAddBarcodeSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddBarcodeSize.Name = "btnAddBarcodeSize";
            this.btnAddBarcodeSize.Size = new System.Drawing.Size(34, 28);
            this.btnAddBarcodeSize.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btnAddBarcodeSize, "Dodaj rozmiar");
            this.btnAddBarcodeSize.UseVisualStyleBackColor = false;
            this.btnAddBarcodeSize.Click += new System.EventHandler(this.AddBarcodeSize_Click);
            // 
            // cboBarSize
            // 
            this.cboBarSize.FormattingEnabled = true;
            this.cboBarSize.Items.AddRange(new object[] {
            "50x30",
            "100x60",
            "150x90"});
            this.cboBarSize.Location = new System.Drawing.Point(86, 62);
            this.cboBarSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboBarSize.Name = "cboBarSize";
            this.cboBarSize.Size = new System.Drawing.Size(148, 28);
            this.cboBarSize.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Rozmiar:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tekst:";
            // 
            // btnCodeBar
            // 
            this.btnCodeBar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCodeBar.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.barcode_scan;
            this.btnCodeBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCodeBar.Location = new System.Drawing.Point(331, 19);
            this.btnCodeBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCodeBar.Name = "btnCodeBar";
            this.btnCodeBar.Size = new System.Drawing.Size(35, 33);
            this.btnCodeBar.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnCodeBar, "Wstaw kod kreskowy");
            this.btnCodeBar.UseVisualStyleBackColor = false;
            this.btnCodeBar.Click += new System.EventHandler(this.btnCodeBar_Click);
            // 
            // txtCodeBarText
            // 
            this.txtCodeBarText.Location = new System.Drawing.Point(67, 27);
            this.txtCodeBarText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodeBarText.Name = "txtCodeBarText";
            this.txtCodeBarText.Size = new System.Drawing.Size(258, 25);
            this.txtCodeBarText.TabIndex = 9;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.search_zoom;
            this.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomIn.Location = new System.Drawing.Point(9, 89);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(40, 38);
            this.btnZoomIn.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnZoomIn, "Powiększ podgląd");
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.search_minus;
            this.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomOut.Location = new System.Drawing.Point(55, 90);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(40, 38);
            this.btnZoomOut.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnZoomOut, "Pomniejsz podgląd");
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // PdfEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1033, 1030);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PdfEditForm";
            this.Text = "Edycja pliku";
            this.Load += new System.EventHandler(this.EdycjaPDF_Load);
            this.groupBox1.ResumeLayout(false);
            this.PanelPDF.ResumeLayout(false);
            this.grpDocument.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDocument)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpInCompressing.ResumeLayout(false);
            this.grpInCompressing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.grpPageNumbers.ResumeLayout(false);
            this.grpPageNumbers.PerformLayout();
            this.grpTextOptions.ResumeLayout(false);
            this.grpTextOptions.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel PanelPDF;
        private System.Windows.Forms.PictureBox picDocument;
        private System.Windows.Forms.Button btnCodeBar;
        private System.Windows.Forms.TextBox txtCodeBarText;
        private System.Windows.Forms.Button btnSaveDoc;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnAddText;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox grpDocument;
        private System.Windows.Forms.Button btnAddBarcodeSize;
        private System.Windows.Forms.ComboBox cboBarSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpTextOptions;
        private System.Windows.Forms.ComboBox cboTextSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboFonts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.Label lblDeleteInfo;
        private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnRemoveBarcodeSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTextAlignRight;
        private System.Windows.Forms.Button btnTextAlignCenter;
        private System.Windows.Forms.Button btnTextAlignLeft;
        private System.Windows.Forms.GroupBox grpPageNumbers;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.TextBox txtPageNumber;
        private System.Windows.Forms.Button btnRotateMinus;
        private System.Windows.Forms.Button btnRotatePlus;
        private System.Windows.Forms.GroupBox grpInCompressing;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.Button button1;
    }
}