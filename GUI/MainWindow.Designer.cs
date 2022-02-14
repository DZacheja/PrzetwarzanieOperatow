using System;

namespace GUI {
    partial class MainWindow {
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
            Environment.Exit(Environment.ExitCode);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFilesFromDirectory = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnSzukaj = new System.Windows.Forms.Button();
            this.btnDol = new System.Windows.Forms.Button();
            this.btnGora = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnProgramSettings = new System.Windows.Forms.Button();
            this.btnCoverEdit = new System.Windows.Forms.Button();
            this.chkAddCoverWithoutChanges = new System.Windows.Forms.CheckBox();
            this.btnSearchCover = new System.Windows.Forms.Button();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.panelMerging = new System.Windows.Forms.Panel();
            this.lblPageCounter = new System.Windows.Forms.Label();
            this.pgrPages = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPages = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFileCounter = new System.Windows.Forms.Label();
            this.pgrFiles = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpInCompressing = new System.Windows.Forms.GroupBox();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.lblProcessingFile = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtInformation = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCoverPath = new System.Windows.Forms.TextBox();
            this.lblCoverInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.panel2.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.panelMerging.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpInCompressing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvFiles);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(450, 882);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pliki";
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowDrop = true;
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvFiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFiles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFiles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiles.Location = new System.Drawing.Point(3, 24);
            this.dgvFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvFiles.MultiSelect = false;
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvFiles.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFiles.RowTemplate.Height = 24;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(382, 854);
            this.dgvFiles.StandardTab = true;
            this.dgvFiles.TabIndex = 21;
            this.toolTip1.SetToolTip(this.dgvFiles, "Pliki do połączenia. Kolejność od góry do dołu.");
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nazwa pliku";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Path";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "FileType";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnFilesFromDirectory);
            this.panel2.Controls.Add(this.btnSettings);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnMerge);
            this.panel2.Controls.Add(this.btnSzukaj);
            this.panel2.Controls.Add(this.btnDol);
            this.panel2.Controls.Add(this.btnGora);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(385, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(62, 854);
            this.panel2.TabIndex = 19;
            // 
            // btnFilesFromDirectory
            // 
            this.btnFilesFromDirectory.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.folder_download;
            this.btnFilesFromDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFilesFromDirectory.Location = new System.Drawing.Point(10, 59);
            this.btnFilesFromDirectory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFilesFromDirectory.Name = "btnFilesFromDirectory";
            this.btnFilesFromDirectory.Size = new System.Drawing.Size(40, 40);
            this.btnFilesFromDirectory.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnFilesFromDirectory, "Wczytaj wszystkie pliku ze wskazanego folderu");
            this.btnFilesFromDirectory.UseVisualStyleBackColor = true;
            this.btnFilesFromDirectory.Click += new System.EventHandler(this.btnFilesFromDirectory_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.gears;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSettings.Location = new System.Drawing.Point(10, 257);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(40, 40);
            this.btnSettings.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btnSettings, "Konfiguracja");
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Location = new System.Drawing.Point(10, 209);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 40);
            this.btnDelete.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnDelete, "Usuń zaznaczony plik z listy");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.compare_file;
            this.btnMerge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMerge.Location = new System.Drawing.Point(10, 305);
            this.btnMerge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(40, 40);
            this.btnMerge.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnMerge, "Ustawienia łączenia plików");
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnSzukaj
            // 
            this.btnSzukaj.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.search_file;
            this.btnSzukaj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSzukaj.Location = new System.Drawing.Point(10, 12);
            this.btnSzukaj.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSzukaj.Name = "btnSzukaj";
            this.btnSzukaj.Size = new System.Drawing.Size(40, 40);
            this.btnSzukaj.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnSzukaj, "Wyszukaj pliki na dysku");
            this.btnSzukaj.UseVisualStyleBackColor = true;
            this.btnSzukaj.Click += new System.EventHandler(this.btnSzukaj_Click);
            // 
            // btnDol
            // 
            this.btnDol.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.bottom_arrow;
            this.btnDol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDol.Location = new System.Drawing.Point(10, 159);
            this.btnDol.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDol.Name = "btnDol";
            this.btnDol.Size = new System.Drawing.Size(40, 40);
            this.btnDol.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnDol, "Przesuń plik w dół");
            this.btnDol.UseVisualStyleBackColor = true;
            this.btnDol.Click += new System.EventHandler(this.btnDol_Click);
            // 
            // btnGora
            // 
            this.btnGora.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.top_arrow;
            this.btnGora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGora.Location = new System.Drawing.Point(10, 107);
            this.btnGora.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGora.Name = "btnGora";
            this.btnGora.Size = new System.Drawing.Size(40, 40);
            this.btnGora.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnGora, "Przesuń plik do góry");
            this.btnGora.UseVisualStyleBackColor = true;
            this.btnGora.Click += new System.EventHandler(this.btnGora_Click);
            // 
            // btnProgramSettings
            // 
            this.btnProgramSettings.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.desktop_application_app;
            this.btnProgramSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProgramSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnProgramSettings.Location = new System.Drawing.Point(441, 0);
            this.btnProgramSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProgramSettings.Name = "btnProgramSettings";
            this.btnProgramSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnProgramSettings.Size = new System.Drawing.Size(40, 50);
            this.btnProgramSettings.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnProgramSettings, "Ustawienia programu");
            this.btnProgramSettings.UseVisualStyleBackColor = true;
            this.btnProgramSettings.Click += new System.EventHandler(this.btnProgramSettings_Click);
            // 
            // btnCoverEdit
            // 
            this.btnCoverEdit.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.document_edit;
            this.btnCoverEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCoverEdit.Location = new System.Drawing.Point(16, 109);
            this.btnCoverEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCoverEdit.Name = "btnCoverEdit";
            this.btnCoverEdit.Size = new System.Drawing.Size(40, 40);
            this.btnCoverEdit.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnCoverEdit, "Edytuj okładkę");
            this.btnCoverEdit.UseVisualStyleBackColor = true;
            this.btnCoverEdit.Click += new System.EventHandler(this.btnCoverEdit_Click_1);
            // 
            // chkAddCoverWithoutChanges
            // 
            this.chkAddCoverWithoutChanges.AutoSize = true;
            this.chkAddCoverWithoutChanges.Location = new System.Drawing.Point(16, 159);
            this.chkAddCoverWithoutChanges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAddCoverWithoutChanges.Name = "chkAddCoverWithoutChanges";
            this.chkAddCoverWithoutChanges.Size = new System.Drawing.Size(155, 24);
            this.chkAddCoverWithoutChanges.TabIndex = 17;
            this.chkAddCoverWithoutChanges.Text = "Dodaj bez edycji";
            this.toolTip1.SetToolTip(this.chkAddCoverWithoutChanges, "Dodaje orginalną okładkę");
            this.chkAddCoverWithoutChanges.UseVisualStyleBackColor = true;
            this.chkAddCoverWithoutChanges.CheckedChanged += new System.EventHandler(this.chkAddCoverWithoutChanges_CheckedChanged);
            // 
            // btnSearchCover
            // 
            this.btnSearchCover.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.search_file;
            this.btnSearchCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchCover.Location = new System.Drawing.Point(372, 34);
            this.btnSearchCover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearchCover.Name = "btnSearchCover";
            this.btnSearchCover.Size = new System.Drawing.Size(40, 40);
            this.btnSearchCover.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnSearchCover, "Wyszukaj okładkę na dysku");
            this.btnSearchCover.UseVisualStyleBackColor = true;
            this.btnSearchCover.Click += new System.EventHandler(this.btnSearchCover_Click_1);
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.panelMerging);
            this.grpStatus.Controls.Add(this.grpInCompressing);
            this.grpStatus.Controls.Add(this.lblProcessingFile);
            this.grpStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpStatus.Location = new System.Drawing.Point(450, 456);
            this.grpStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpStatus.Size = new System.Drawing.Size(487, 426);
            this.grpStatus.TabIndex = 16;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status operacji";
            this.grpStatus.Visible = false;
            // 
            // panelMerging
            // 
            this.panelMerging.Controls.Add(this.lblPageCounter);
            this.panelMerging.Controls.Add(this.pgrPages);
            this.panelMerging.Controls.Add(this.groupBox2);
            this.panelMerging.Controls.Add(this.label2);
            this.panelMerging.Controls.Add(this.label1);
            this.panelMerging.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMerging.Location = new System.Drawing.Point(3, 104);
            this.panelMerging.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMerging.Name = "panelMerging";
            this.panelMerging.Size = new System.Drawing.Size(481, 266);
            this.panelMerging.TabIndex = 19;
            // 
            // lblPageCounter
            // 
            this.lblPageCounter.AutoSize = true;
            this.lblPageCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPageCounter.Location = new System.Drawing.Point(143, 29);
            this.lblPageCounter.Name = "lblPageCounter";
            this.lblPageCounter.Size = new System.Drawing.Size(55, 20);
            this.lblPageCounter.TabIndex = 10;
            this.lblPageCounter.Text = "1 z 10";
            // 
            // pgrPages
            // 
            this.pgrPages.Location = new System.Drawing.Point(8, 66);
            this.pgrPages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgrPages.Name = "pgrPages";
            this.pgrPages.Size = new System.Drawing.Size(408, 29);
            this.pgrPages.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPages);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblFileCounter);
            this.groupBox2.Controls.Add(this.pgrFiles);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 102);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(420, 148);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Całkowity postęp:";
            // 
            // lblPages
            // 
            this.lblPages.AutoSize = true;
            this.lblPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPages.Location = new System.Drawing.Point(140, 66);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(55, 20);
            this.lblPages.TabIndex = 13;
            this.lblPages.Text = "1 z 10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(36, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Liczba stron:";
            // 
            // lblFileCounter
            // 
            this.lblFileCounter.AutoSize = true;
            this.lblFileCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFileCounter.Location = new System.Drawing.Point(140, 38);
            this.lblFileCounter.Name = "lblFileCounter";
            this.lblFileCounter.Size = new System.Drawing.Size(55, 20);
            this.lblFileCounter.TabIndex = 11;
            this.lblFileCounter.Text = "1 z 10";
            // 
            // pgrFiles
            // 
            this.pgrFiles.Location = new System.Drawing.Point(6, 98);
            this.pgrFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgrFiles.Name = "pgrFiles";
            this.pgrFiles.Size = new System.Drawing.Size(408, 29);
            this.pgrFiles.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(10, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Połączone pliki:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(83, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Strona:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Przetwarzany plik:";
            // 
            // grpInCompressing
            // 
            this.grpInCompressing.Controls.Add(this.picLoading);
            this.grpInCompressing.Controls.Add(this.lblProcessing);
            this.grpInCompressing.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInCompressing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpInCompressing.Location = new System.Drawing.Point(3, 24);
            this.grpInCompressing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpInCompressing.Name = "grpInCompressing";
            this.grpInCompressing.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpInCompressing.Size = new System.Drawing.Size(481, 80);
            this.grpInCompressing.TabIndex = 18;
            this.grpInCompressing.TabStop = false;
            this.grpInCompressing.Text = "Przetwarzanie ";
            // 
            // picLoading
            // 
            this.picLoading.BackgroundImage = global::Przetwarzanie_plikow_PDF.Resource.pending_work;
            this.picLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLoading.Location = new System.Drawing.Point(16, 26);
            this.picLoading.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(48, 46);
            this.picLoading.TabIndex = 20;
            this.picLoading.TabStop = false;
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProcessing.Location = new System.Drawing.Point(70, 34);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(303, 20);
            this.lblProcessing.TabIndex = 19;
            this.lblProcessing.Text = "Proszę czekać trwa optymalizacja pliku";
            // 
            // lblProcessingFile
            // 
            this.lblProcessingFile.AutoSize = true;
            this.lblProcessingFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProcessingFile.Location = new System.Drawing.Point(155, 38);
            this.lblProcessingFile.Name = "lblProcessingFile";
            this.lblProcessingFile.Size = new System.Drawing.Size(117, 20);
            this.lblProcessingFile.TabIndex = 9;
            this.lblProcessingFile.Text = "123456789012";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(450, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(487, 448);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Opcje ogólne";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtInformation);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 264);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(481, 178);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Informacje:";
            // 
            // txtInformation
            // 
            this.txtInformation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInformation.Location = new System.Drawing.Point(3, 24);
            this.txtInformation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.ReadOnly = true;
            this.txtInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInformation.Size = new System.Drawing.Size(475, 150);
            this.txtInformation.TabIndex = 20;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCoverPath);
            this.groupBox4.Controls.Add(this.chkAddCoverWithoutChanges);
            this.groupBox4.Controls.Add(this.lblCoverInfo);
            this.groupBox4.Controls.Add(this.btnCoverEdit);
            this.groupBox4.Controls.Add(this.btnSearchCover);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(3, 74);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(481, 190);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Okładka";
            // 
            // txtCoverPath
            // 
            this.txtCoverPath.Location = new System.Drawing.Point(12, 42);
            this.txtCoverPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCoverPath.Name = "txtCoverPath";
            this.txtCoverPath.ReadOnly = true;
            this.txtCoverPath.Size = new System.Drawing.Size(354, 27);
            this.txtCoverPath.TabIndex = 3;
            // 
            // lblCoverInfo
            // 
            this.lblCoverInfo.AutoSize = true;
            this.lblCoverInfo.ForeColor = System.Drawing.Color.Lime;
            this.lblCoverInfo.Location = new System.Drawing.Point(12, 80);
            this.lblCoverInfo.Name = "lblCoverInfo";
            this.lblCoverInfo.Size = new System.Drawing.Size(206, 20);
            this.lblCoverInfo.TabIndex = 16;
            this.lblCoverInfo.Text = "Pomyślnie dodano okładkę";
            this.lblCoverInfo.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnProgramSettings);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 50);
            this.panel1.TabIndex = 18;
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 882);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.panel2.ResumeLayout(false);
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.panelMerging.ResumeLayout(false);
            this.panelMerging.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpInCompressing.ResumeLayout(false);
            this.grpInCompressing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGora;
        private System.Windows.Forms.Button btnDol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSzukaj;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.ProgressBar pgrPages;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar pgrFiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPageCounter;
        private System.Windows.Forms.Label lblProcessingFile;
        private System.Windows.Forms.Label lblFileCounter;
        private System.Windows.Forms.Label lblPages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.GroupBox grpInCompressing;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.Button btnFilesFromDirectory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCoverPath;
        private System.Windows.Forms.Button btnCoverEdit;
        private System.Windows.Forms.Button btnSearchCover;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProgramSettings;
        private System.Windows.Forms.Panel panelMerging;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtInformation;
        private System.Windows.Forms.CheckBox chkAddCoverWithoutChanges;
        private System.Windows.Forms.Label lblCoverInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}