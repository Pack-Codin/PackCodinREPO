namespace PCodin_Sinlacc.Formularios
{
    partial class frmEstadisticas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstadisticas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.gbxFiltrosTermo = new System.Windows.Forms.GroupBox();
            this.cmbFiltraEstado = new System.Windows.Forms.ComboBox();
            this.chkFiltraEstado = new System.Windows.Forms.CheckBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.cmbFiltraProducto = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbInformes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.chkFiltraProducto = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.chkFiltraFechaHasta = new System.Windows.Forms.CheckBox();
            this.chkFiltraFechaDesde = new System.Windows.Forms.CheckBox();
            this.dtpFiltraFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFiltraFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadPend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadEntreg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNroPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.gbxFiltrosTermo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox5.Location = new System.Drawing.Point(76, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(2, 21);
            this.pictureBox5.TabIndex = 566;
            this.pictureBox5.TabStop = false;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.Silver;
            this.btnExportarExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.BackgroundImage")));
            this.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarExcel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExportarExcel.FlatAppearance.BorderSize = 0;
            this.btnExportarExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Location = new System.Drawing.Point(93, 0);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(30, 28);
            this.btnExportarExcel.TabIndex = 565;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Silver;
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Location = new System.Drawing.Point(-1, 0);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(66, 29);
            this.btnImprimir.TabIndex = 564;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // gbxFiltrosTermo
            // 
            this.gbxFiltrosTermo.BackColor = System.Drawing.Color.Silver;
            this.gbxFiltrosTermo.Controls.Add(this.button2);
            this.gbxFiltrosTermo.Controls.Add(this.textBox2);
            this.gbxFiltrosTermo.Controls.Add(this.cmbFiltraEstado);
            this.gbxFiltrosTermo.Controls.Add(this.chkFiltraEstado);
            this.gbxFiltrosTermo.Controls.Add(this.btnBuscarProducto);
            this.gbxFiltrosTermo.Controls.Add(this.txtBuscarProducto);
            this.gbxFiltrosTermo.Controls.Add(this.cmbFiltraProducto);
            this.gbxFiltrosTermo.Controls.Add(this.btnBuscar);
            this.gbxFiltrosTermo.Controls.Add(this.textBox1);
            this.gbxFiltrosTermo.Controls.Add(this.cmbInformes);
            this.gbxFiltrosTermo.Controls.Add(this.label7);
            this.gbxFiltrosTermo.Controls.Add(this.pictureBox8);
            this.gbxFiltrosTermo.Controls.Add(this.label6);
            this.gbxFiltrosTermo.Controls.Add(this.pictureBox7);
            this.gbxFiltrosTermo.Controls.Add(this.chkFiltraProducto);
            this.gbxFiltrosTermo.Controls.Add(this.label1);
            this.gbxFiltrosTermo.Controls.Add(this.pictureBox2);
            this.gbxFiltrosTermo.Controls.Add(this.chkFiltraFechaHasta);
            this.gbxFiltrosTermo.Controls.Add(this.chkFiltraFechaDesde);
            this.gbxFiltrosTermo.Controls.Add(this.dtpFiltraFechaHasta);
            this.gbxFiltrosTermo.Controls.Add(this.dtpFiltraFechaDesde);
            this.gbxFiltrosTermo.Location = new System.Drawing.Point(-1, 516);
            this.gbxFiltrosTermo.Name = "gbxFiltrosTermo";
            this.gbxFiltrosTermo.Size = new System.Drawing.Size(1354, 155);
            this.gbxFiltrosTermo.TabIndex = 563;
            this.gbxFiltrosTermo.TabStop = false;
            this.gbxFiltrosTermo.Enter += new System.EventHandler(this.gbxFiltrosTermo_Enter);
            // 
            // cmbFiltraEstado
            // 
            this.cmbFiltraEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraEstado.FormattingEnabled = true;
            this.cmbFiltraEstado.Items.AddRange(new object[] {
            "AU",
            "FI"});
            this.cmbFiltraEstado.Location = new System.Drawing.Point(625, 51);
            this.cmbFiltraEstado.Name = "cmbFiltraEstado";
            this.cmbFiltraEstado.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltraEstado.TabIndex = 588;
            // 
            // chkFiltraEstado
            // 
            this.chkFiltraEstado.AutoSize = true;
            this.chkFiltraEstado.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraEstado.Location = new System.Drawing.Point(560, 53);
            this.chkFiltraEstado.Name = "chkFiltraEstado";
            this.chkFiltraEstado.Size = new System.Drawing.Size(59, 17);
            this.chkFiltraEstado.TabIndex = 587;
            this.chkFiltraEstado.Text = "Estado";
            this.chkFiltraEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraEstado.UseVisualStyleBackColor = false;
            this.chkFiltraEstado.CheckedChanged += new System.EventHandler(this.chkFiltraEstado_CheckedChanged);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarProducto.BackgroundImage")));
            this.btnBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarProducto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarProducto.FlatAppearance.BorderSize = 0;
            this.btnBuscarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProducto.Location = new System.Drawing.Point(970, 27);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarProducto.TabIndex = 586;
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscarProducto.Location = new System.Drawing.Point(625, 28);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(339, 20);
            this.txtBuscarProducto.TabIndex = 585;
            this.txtBuscarProducto.Visible = false;
            this.txtBuscarProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarProducto_KeyPress);
            // 
            // cmbFiltraProducto
            // 
            this.cmbFiltraProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraProducto.FormattingEnabled = true;
            this.cmbFiltraProducto.Location = new System.Drawing.Point(625, 28);
            this.cmbFiltraProducto.Name = "cmbFiltraProducto";
            this.cmbFiltraProducto.Size = new System.Drawing.Size(339, 21);
            this.cmbFiltraProducto.TabIndex = 584;
            this.cmbFiltraProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbProducto_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(1037, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(86, 78);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(351, 22);
            this.textBox1.TabIndex = 417;
            this.textBox1.Text = "Informes";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbInformes
            // 
            this.cmbInformes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInformes.FormattingEnabled = true;
            this.cmbInformes.Items.AddRange(new object[] {
            "",
            "Maestro de pedidos"});
            this.cmbInformes.Location = new System.Drawing.Point(0, 61);
            this.cmbInformes.Name = "cmbInformes";
            this.cmbInformes.Size = new System.Drawing.Size(351, 21);
            this.cmbInformes.TabIndex = 416;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(731, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 23);
            this.label7.TabIndex = 409;
            this.label7.Text = "Otros";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox8.Location = new System.Drawing.Point(550, 2);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(443, 25);
            this.pictureBox8.TabIndex = 410;
            this.pictureBox8.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(375, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 23);
            this.label6.TabIndex = 406;
            this.label6.Text = "Fechas";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox7.Location = new System.Drawing.Point(368, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(168, 25);
            this.pictureBox7.TabIndex = 407;
            this.pictureBox7.TabStop = false;
            // 
            // chkFiltraProducto
            // 
            this.chkFiltraProducto.AutoSize = true;
            this.chkFiltraProducto.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraProducto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraProducto.Location = new System.Drawing.Point(550, 32);
            this.chkFiltraProducto.Name = "chkFiltraProducto";
            this.chkFiltraProducto.Size = new System.Drawing.Size(69, 17);
            this.chkFiltraProducto.TabIndex = 404;
            this.chkFiltraProducto.Text = "Producto";
            this.chkFiltraProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraProducto.UseVisualStyleBackColor = false;
            this.chkFiltraProducto.CheckedChanged += new System.EventHandler(this.chkFiltraProducto_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkOrange;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 32);
            this.label1.TabIndex = 380;
            this.label1.Text = "Funciones Estadisticas";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(351, 37);
            this.pictureBox2.TabIndex = 380;
            this.pictureBox2.TabStop = false;
            // 
            // chkFiltraFechaHasta
            // 
            this.chkFiltraFechaHasta.AutoSize = true;
            this.chkFiltraFechaHasta.Checked = true;
            this.chkFiltraFechaHasta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiltraFechaHasta.Location = new System.Drawing.Point(368, 53);
            this.chkFiltraFechaHasta.Name = "chkFiltraFechaHasta";
            this.chkFiltraFechaHasta.Size = new System.Drawing.Size(54, 17);
            this.chkFiltraFechaHasta.TabIndex = 58;
            this.chkFiltraFechaHasta.Text = "Hasta";
            this.chkFiltraFechaHasta.UseVisualStyleBackColor = true;
            // 
            // chkFiltraFechaDesde
            // 
            this.chkFiltraFechaDesde.AutoSize = true;
            this.chkFiltraFechaDesde.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraFechaDesde.Checked = true;
            this.chkFiltraFechaDesde.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiltraFechaDesde.Location = new System.Drawing.Point(368, 30);
            this.chkFiltraFechaDesde.Name = "chkFiltraFechaDesde";
            this.chkFiltraFechaDesde.Size = new System.Drawing.Size(57, 17);
            this.chkFiltraFechaDesde.TabIndex = 57;
            this.chkFiltraFechaDesde.Text = "Desde";
            this.chkFiltraFechaDesde.UseVisualStyleBackColor = true;
            this.chkFiltraFechaDesde.CheckedChanged += new System.EventHandler(this.chkFiltraFechaDesde_CheckedChanged);
            // 
            // dtpFiltraFechaHasta
            // 
            this.dtpFiltraFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltraFechaHasta.Location = new System.Drawing.Point(425, 53);
            this.dtpFiltraFechaHasta.Name = "dtpFiltraFechaHasta";
            this.dtpFiltraFechaHasta.Size = new System.Drawing.Size(111, 20);
            this.dtpFiltraFechaHasta.TabIndex = 52;
            this.dtpFiltraFechaHasta.Value = new System.DateTime(2021, 8, 7, 0, 0, 0, 0);
            // 
            // dtpFiltraFechaDesde
            // 
            this.dtpFiltraFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltraFechaDesde.Location = new System.Drawing.Point(425, 29);
            this.dtpFiltraFechaDesde.Name = "dtpFiltraFechaDesde";
            this.dtpFiltraFechaDesde.Size = new System.Drawing.Size(111, 20);
            this.dtpFiltraFechaDesde.TabIndex = 50;
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.AllowUserToResizeRows = false;
            this.dgvEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpleados.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmpleados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvEmpleados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEmpleados.ColumnHeadersHeight = 34;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colCliente,
            this.colProducto,
            this.colCantidadTotal,
            this.colCantidadPend,
            this.colCantidadEntreg,
            this.colNroPedido});
            this.dgvEmpleados.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmpleados.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEmpleados.EnableHeadersVisualStyles = false;
            this.dgvEmpleados.GridColor = System.Drawing.Color.White;
            this.dgvEmpleados.Location = new System.Drawing.Point(-1, 31);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmpleados.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvEmpleados.RowHeadersVisible = false;
            this.dgvEmpleados.RowHeadersWidth = 38;
            this.dgvEmpleados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEmpleados.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleados.Size = new System.Drawing.Size(1267, 509);
            this.dgvEmpleados.TabIndex = 562;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Prodcuto";
            this.colProducto.Name = "colProducto";
            // 
            // colCantidadTotal
            // 
            this.colCantidadTotal.HeaderText = "Cantidad total";
            this.colCantidadTotal.Name = "colCantidadTotal";
            // 
            // colCantidadPend
            // 
            this.colCantidadPend.HeaderText = "Cantidad pend";
            this.colCantidadPend.Name = "colCantidadPend";
            // 
            // colCantidadEntreg
            // 
            this.colCantidadEntreg.HeaderText = "Cantidad Entreg";
            this.colCantidadEntreg.Name = "colCantidadEntreg";
            // 
            // colNroPedido
            // 
            this.colNroPedido.HeaderText = "Nro pedido";
            this.colNroPedido.Name = "colNroPedido";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 567;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(444, 103);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 20);
            this.textBox2.TabIndex = 589;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(350, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 590;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1269, 690);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.gbxFiltrosTermo);
            this.Controls.Add(this.dgvEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEstadisticas";
            this.Text = "frmEstadisticas";
            this.Load += new System.EventHandler(this.frmEstadisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.gbxFiltrosTermo.ResumeLayout(false);
            this.gbxFiltrosTermo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.GroupBox gbxFiltrosTermo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbInformes;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox8;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.CheckBox chkFiltraProducto;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox chkFiltraFechaHasta;
        private System.Windows.Forms.CheckBox chkFiltraFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFiltraFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFiltraFechaDesde;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.ComboBox cmbFiltraProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadPend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadEntreg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNroPedido;
        private System.Windows.Forms.ComboBox cmbFiltraEstado;
        private System.Windows.Forms.CheckBox chkFiltraEstado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
    }
}