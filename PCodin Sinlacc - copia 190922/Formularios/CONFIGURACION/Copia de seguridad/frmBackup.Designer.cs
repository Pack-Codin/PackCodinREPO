namespace PCodin_Sinlacc
{
    partial class frmBackup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackup));
            this.txtDBs = new System.Windows.Forms.Label();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbDiff = new System.Windows.Forms.RadioButton();
            this.rdbBak = new System.Windows.Forms.RadioButton();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtFechaUltCopia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoraUltCopia = new System.Windows.Forms.TextBox();
            this.dgvBackup = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.cmbFiltraTipo = new System.Windows.Forms.ComboBox();
            this.chkFechaHasta = new System.Windows.Forms.CheckBox();
            this.chkFiltraUsurio = new System.Windows.Forms.CheckBox();
            this.chkFechaDesde = new System.Windows.Forms.CheckBox();
            this.chkFiltraTipo = new System.Windows.Forms.CheckBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbFiltraUsuario = new System.Windows.Forms.ComboBox();
            this.lblfiltros = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrarfiltros = new System.Windows.Forms.Button();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.pnlSuperior2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnElegirRuta = new System.Windows.Forms.Button();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackup)).BeginInit();
            this.gbxFiltros.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.pnlSuperior2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pnlCentral.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDBs
            // 
            this.txtDBs.AutoSize = true;
            this.txtDBs.BackColor = System.Drawing.Color.White;
            this.txtDBs.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBs.Location = new System.Drawing.Point(14, 26);
            this.txtDBs.Name = "txtDBs";
            this.txtDBs.Size = new System.Drawing.Size(81, 19);
            this.txtDBs.TabIndex = 571;
            this.txtDBs.Text = "Base datos";
            // 
            // txtDB
            // 
            this.txtDB.BackColor = System.Drawing.Color.White;
            this.txtDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDB.ForeColor = System.Drawing.Color.Black;
            this.txtDB.Location = new System.Drawing.Point(107, 25);
            this.txtDB.Name = "txtDB";
            this.txtDB.ReadOnly = true;
            this.txtDB.Size = new System.Drawing.Size(340, 22);
            this.txtDB.TabIndex = 570;
            this.txtDB.Click += new System.EventHandler(this.txtDB_Click);
            this.txtDB.TextChanged += new System.EventHandler(this.txtDB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 572;
            this.label1.Text = "Tipo de copia";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbDiff);
            this.groupBox1.Controls.Add(this.rdbBak);
            this.groupBox1.Location = new System.Drawing.Point(111, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 58);
            this.groupBox1.TabIndex = 573;
            this.groupBox1.TabStop = false;
            // 
            // rdbDiff
            // 
            this.rdbDiff.AutoSize = true;
            this.rdbDiff.Checked = true;
            this.rdbDiff.Location = new System.Drawing.Point(232, 19);
            this.rdbDiff.Name = "rdbDiff";
            this.rdbDiff.Size = new System.Drawing.Size(98, 17);
            this.rdbDiff.TabIndex = 1;
            this.rdbDiff.TabStop = true;
            this.rdbDiff.Text = "Diff (diferencial)";
            this.rdbDiff.UseVisualStyleBackColor = true;
            // 
            // rdbBak
            // 
            this.rdbBak.AutoSize = true;
            this.rdbBak.Location = new System.Drawing.Point(14, 19);
            this.rdbBak.Name = "rdbBak";
            this.rdbBak.Size = new System.Drawing.Size(97, 17);
            this.rdbBak.TabIndex = 0;
            this.rdbBak.TabStop = true;
            this.rdbBak.Text = "Bak (Completa)";
            this.rdbBak.UseVisualStyleBackColor = true;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.White;
            this.Label6.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(60, 143);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(39, 19);
            this.Label6.TabIndex = 578;
            this.Label6.Text = "Ruta";
            // 
            // txtRuta
            // 
            this.txtRuta.BackColor = System.Drawing.Color.White;
            this.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.ForeColor = System.Drawing.Color.Black;
            this.txtRuta.Location = new System.Drawing.Point(111, 143);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(697, 21);
            this.txtRuta.TabIndex = 577;
            this.txtRuta.TextChanged += new System.EventHandler(this.txtRuta_TextChanged);
            // 
            // txtFechaUltCopia
            // 
            this.txtFechaUltCopia.BackColor = System.Drawing.Color.White;
            this.txtFechaUltCopia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFechaUltCopia.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaUltCopia.ForeColor = System.Drawing.Color.Teal;
            this.txtFechaUltCopia.Location = new System.Drawing.Point(71, 47);
            this.txtFechaUltCopia.Multiline = true;
            this.txtFechaUltCopia.Name = "txtFechaUltCopia";
            this.txtFechaUltCopia.Size = new System.Drawing.Size(193, 31);
            this.txtFechaUltCopia.TabIndex = 580;
            this.txtFechaUltCopia.Text = "12/12/2021";
            this.txtFechaUltCopia.TextChanged += new System.EventHandler(this.txtFechaUltCopia_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(25, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 29);
            this.label2.TabIndex = 581;
            this.label2.Text = "Ultima copia realizada";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtHoraUltCopia
            // 
            this.txtHoraUltCopia.BackColor = System.Drawing.Color.White;
            this.txtHoraUltCopia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHoraUltCopia.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraUltCopia.ForeColor = System.Drawing.Color.Black;
            this.txtHoraUltCopia.Location = new System.Drawing.Point(71, 87);
            this.txtHoraUltCopia.Multiline = true;
            this.txtHoraUltCopia.Name = "txtHoraUltCopia";
            this.txtHoraUltCopia.Size = new System.Drawing.Size(193, 31);
            this.txtHoraUltCopia.TabIndex = 587;
            this.txtHoraUltCopia.Text = "13:25";
            this.txtHoraUltCopia.TextChanged += new System.EventHandler(this.txtHoraUltCopia_TextChanged);
            // 
            // dgvBackup
            // 
            this.dgvBackup.AllowUserToAddRows = false;
            this.dgvBackup.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBackup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBackup.BackgroundColor = System.Drawing.Color.White;
            this.dgvBackup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBackup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvBackup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBackup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBackup.ColumnHeadersHeight = 26;
            this.dgvBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBackup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colFecha,
            this.colHora,
            this.colTipo,
            this.colUsuario});
            this.dgvBackup.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBackup.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBackup.EnableHeadersVisualStyles = false;
            this.dgvBackup.GridColor = System.Drawing.Color.Teal;
            this.dgvBackup.Location = new System.Drawing.Point(4, 4);
            this.dgvBackup.Name = "dgvBackup";
            this.dgvBackup.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBackup.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBackup.RowHeadersVisible = false;
            this.dgvBackup.RowHeadersWidth = 38;
            this.dgvBackup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBackup.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBackup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBackup.Size = new System.Drawing.Size(629, 399);
            this.dgvBackup.TabIndex = 588;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Width = 150;
            // 
            // colHora
            // 
            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "colHora";
            this.colHora.Width = 150;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.Width = 200;
            // 
            // colUsuario
            // 
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.Width = 660;
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbxFiltros.Controls.Add(this.pnlFiltro);
            this.gbxFiltros.Controls.Add(this.lblfiltros);
            this.gbxFiltros.Controls.Add(this.btnBuscar);
            this.gbxFiltros.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbxFiltros.Location = new System.Drawing.Point(633, 4);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Size = new System.Drawing.Size(525, 399);
            this.gbxFiltros.TabIndex = 592;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Visible = false;
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Controls.Add(this.cmbFiltraTipo);
            this.pnlFiltro.Controls.Add(this.chkFechaHasta);
            this.pnlFiltro.Controls.Add(this.chkFiltraUsurio);
            this.pnlFiltro.Controls.Add(this.chkFechaDesde);
            this.pnlFiltro.Controls.Add(this.chkFiltraTipo);
            this.pnlFiltro.Controls.Add(this.dtpFechaHasta);
            this.pnlFiltro.Controls.Add(this.dtpFechaDesde);
            this.pnlFiltro.Controls.Add(this.cmbFiltraUsuario);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltro.Location = new System.Drawing.Point(3, 45);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(519, 154);
            this.pnlFiltro.TabIndex = 593;
            // 
            // cmbFiltraTipo
            // 
            this.cmbFiltraTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraTipo.Enabled = false;
            this.cmbFiltraTipo.FormattingEnabled = true;
            this.cmbFiltraTipo.Items.AddRange(new object[] {
            "",
            "BAK",
            "DIFF"});
            this.cmbFiltraTipo.Location = new System.Drawing.Point(117, 20);
            this.cmbFiltraTipo.Name = "cmbFiltraTipo";
            this.cmbFiltraTipo.Size = new System.Drawing.Size(153, 21);
            this.cmbFiltraTipo.TabIndex = 592;
            // 
            // chkFechaHasta
            // 
            this.chkFechaHasta.AutoSize = true;
            this.chkFechaHasta.Checked = true;
            this.chkFechaHasta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFechaHasta.Location = new System.Drawing.Point(284, 104);
            this.chkFechaHasta.Name = "chkFechaHasta";
            this.chkFechaHasta.Size = new System.Drawing.Size(54, 17);
            this.chkFechaHasta.TabIndex = 587;
            this.chkFechaHasta.Text = "Hasta";
            this.chkFechaHasta.UseVisualStyleBackColor = true;
            // 
            // chkFiltraUsurio
            // 
            this.chkFiltraUsurio.AutoSize = true;
            this.chkFiltraUsurio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraUsurio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraUsurio.Location = new System.Drawing.Point(46, 49);
            this.chkFiltraUsurio.Name = "chkFiltraUsurio";
            this.chkFiltraUsurio.Size = new System.Drawing.Size(62, 17);
            this.chkFiltraUsurio.TabIndex = 44;
            this.chkFiltraUsurio.Text = "Usuario";
            this.chkFiltraUsurio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraUsurio.UseVisualStyleBackColor = false;
            this.chkFiltraUsurio.CheckedChanged += new System.EventHandler(this.chkFiltraUsurio_CheckedChanged);
            // 
            // chkFechaDesde
            // 
            this.chkFechaDesde.AutoSize = true;
            this.chkFechaDesde.Checked = true;
            this.chkFechaDesde.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFechaDesde.Location = new System.Drawing.Point(63, 104);
            this.chkFechaDesde.Name = "chkFechaDesde";
            this.chkFechaDesde.Size = new System.Drawing.Size(57, 17);
            this.chkFechaDesde.TabIndex = 586;
            this.chkFechaDesde.Text = "Desde";
            this.chkFechaDesde.UseVisualStyleBackColor = true;
            // 
            // chkFiltraTipo
            // 
            this.chkFiltraTipo.AutoSize = true;
            this.chkFiltraTipo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraTipo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraTipo.Location = new System.Drawing.Point(61, 22);
            this.chkFiltraTipo.Name = "chkFiltraTipo";
            this.chkFiltraTipo.Size = new System.Drawing.Size(47, 17);
            this.chkFiltraTipo.TabIndex = 591;
            this.chkFiltraTipo.Text = "Tipo";
            this.chkFiltraTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraTipo.UseVisualStyleBackColor = false;
            this.chkFiltraTipo.CheckedChanged += new System.EventHandler(this.chkFiltraTipo_CheckedChanged);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(341, 104);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaHasta.TabIndex = 585;
            this.dtpFechaHasta.Value = new System.DateTime(2021, 4, 30, 2, 21, 26, 0);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(120, 103);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaDesde.TabIndex = 584;
            // 
            // cmbFiltraUsuario
            // 
            this.cmbFiltraUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraUsuario.Enabled = false;
            this.cmbFiltraUsuario.FormattingEnabled = true;
            this.cmbFiltraUsuario.Items.AddRange(new object[] {
            "FI",
            "AN"});
            this.cmbFiltraUsuario.Location = new System.Drawing.Point(117, 47);
            this.cmbFiltraUsuario.Name = "cmbFiltraUsuario";
            this.cmbFiltraUsuario.Size = new System.Drawing.Size(153, 21);
            this.cmbFiltraUsuario.TabIndex = 45;
            // 
            // lblfiltros
            // 
            this.lblfiltros.AutoSize = true;
            this.lblfiltros.BackColor = System.Drawing.Color.Transparent;
            this.lblfiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblfiltros.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfiltros.ForeColor = System.Drawing.Color.Teal;
            this.lblfiltros.Location = new System.Drawing.Point(3, 16);
            this.lblfiltros.Name = "lblfiltros";
            this.lblfiltros.Size = new System.Drawing.Size(74, 29);
            this.lblfiltros.TabIndex = 456;
            this.lblfiltros.Text = "Filtros";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscar.BackgroundImage = global::PCodin_Sinlacc.Properties.Resources.lupa__8_;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(3, 366);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(519, 30);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnMostrarfiltros
            // 
            this.btnMostrarfiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMostrarfiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMostrarfiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarfiltros.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMostrarfiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarfiltros.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarfiltros.ForeColor = System.Drawing.Color.Black;
            this.btnMostrarfiltros.Location = new System.Drawing.Point(634, 3);
            this.btnMostrarfiltros.Name = "btnMostrarfiltros";
            this.btnMostrarfiltros.Size = new System.Drawing.Size(525, 33);
            this.btnMostrarfiltros.TabIndex = 591;
            this.btnMostrarfiltros.Text = "Mostrar Filtros";
            this.btnMostrarfiltros.UseVisualStyleBackColor = false;
            this.btnMostrarfiltros.Click += new System.EventHandler(this.btnMostrarfiltros_Click);
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.pnlSuperior2);
            this.pnlSuperior.Controls.Add(this.button1);
            this.pnlSuperior.Controls.Add(this.btnBackup);
            this.pnlSuperior.Controls.Add(this.btnElegirRuta);
            this.pnlSuperior.Controls.Add(this.Label6);
            this.pnlSuperior.Controls.Add(this.txtRuta);
            this.pnlSuperior.Controls.Add(this.groupBox1);
            this.pnlSuperior.Controls.Add(this.txtDBs);
            this.pnlSuperior.Controls.Add(this.txtDB);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1162, 244);
            this.pnlSuperior.TabIndex = 670;
            this.pnlSuperior.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSuperior_Paint);
            // 
            // pnlSuperior2
            // 
            this.pnlSuperior2.Controls.Add(this.txtFechaUltCopia);
            this.pnlSuperior2.Controls.Add(this.label2);
            this.pnlSuperior2.Controls.Add(this.pictureBox2);
            this.pnlSuperior2.Controls.Add(this.pictureBox3);
            this.pnlSuperior2.Controls.Add(this.pictureBox4);
            this.pnlSuperior2.Controls.Add(this.txtHoraUltCopia);
            this.pnlSuperior2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSuperior2.Location = new System.Drawing.Point(890, 0);
            this.pnlSuperior2.Name = "pnlSuperior2";
            this.pnlSuperior2.Size = new System.Drawing.Size(272, 244);
            this.pnlSuperior2.TabIndex = 670;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(31, 47);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 584;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox3.Location = new System.Drawing.Point(31, 39);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(233, 2);
            this.pictureBox3.TabIndex = 585;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(31, 87);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 586;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(325, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 37);
            this.button1.TabIndex = 669;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBackup.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnBackup.FlatAppearance.BorderSize = 2;
            this.btnBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnBackup.Image")));
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.Location = new System.Drawing.Point(111, 187);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(208, 37);
            this.btnBackup.TabIndex = 668;
            this.btnBackup.Text = "   Realizar copia";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnElegirRuta
            // 
            this.btnElegirRuta.BackColor = System.Drawing.Color.White;
            this.btnElegirRuta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnElegirRuta.BackgroundImage")));
            this.btnElegirRuta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnElegirRuta.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnElegirRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElegirRuta.Location = new System.Drawing.Point(814, 139);
            this.btnElegirRuta.Name = "btnElegirRuta";
            this.btnElegirRuta.Size = new System.Drawing.Size(30, 29);
            this.btnElegirRuta.TabIndex = 579;
            this.btnElegirRuta.UseVisualStyleBackColor = false;
            this.btnElegirRuta.Click += new System.EventHandler(this.btnElegirRuta_Click);
            // 
            // pnlCentral
            // 
            this.pnlCentral.Controls.Add(this.dgvBackup);
            this.pnlCentral.Controls.Add(this.gbxFiltros);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(0, 244);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Padding = new System.Windows.Forms.Padding(4);
            this.pnlCentral.Size = new System.Drawing.Size(1162, 407);
            this.pnlCentral.TabIndex = 671;
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInferior.Controls.Add(this.btnMostrarfiltros);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 651);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(3);
            this.pnlInferior.Size = new System.Drawing.Size(1162, 39);
            this.pnlInferior.TabIndex = 672;
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 690);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlInferior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBackup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBackup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackup)).EndInit();
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlSuperior2.ResumeLayout(false);
            this.pnlSuperior2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pnlCentral.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label txtDBs;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbDiff;
        private System.Windows.Forms.RadioButton rdbBak;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnElegirRuta;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtFechaUltCopia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txtHoraUltCopia;
        private System.Windows.Forms.DataGridView dgvBackup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.ComboBox cmbFiltraTipo;
        private System.Windows.Forms.CheckBox chkFiltraTipo;
        private System.Windows.Forms.CheckBox chkFechaHasta;
        private System.Windows.Forms.CheckBox chkFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblfiltros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbFiltraUsuario;
        private System.Windows.Forms.CheckBox chkFiltraUsurio;
        private System.Windows.Forms.Button btnMostrarfiltros;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pnlSuperior2;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel pnlFiltro;
    }
}