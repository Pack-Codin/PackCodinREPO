
namespace PCodin_Sinlacc.Formularios.Gastos
{
    partial class frmMostrarGastos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMostrarGastos));
            this.dgvGastos = new System.Windows.Forms.DataGridView();
            this.colGastoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscarDesc = new System.Windows.Forms.Button();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.btnBuscarAsc = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.cmbFiltraEstado = new System.Windows.Forms.ComboBox();
            this.chkFiltraEstado = new System.Windows.Forms.CheckBox();
            this.btnBuscarConcepto = new System.Windows.Forms.Button();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.chkFiltraCliente = new System.Windows.Forms.CheckBox();
            this.cmbMovimiento = new System.Windows.Forms.ComboBox();
            this.chkFiltraMovimiento = new System.Windows.Forms.CheckBox();
            this.chkFechaHasta = new System.Windows.Forms.CheckBox();
            this.chkFechaDesde = new System.Windows.Forms.CheckBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.txtBuscaConcepto = new System.Windows.Forms.TextBox();
            this.chkFiltraConcepto = new System.Windows.Forms.CheckBox();
            this.cmbFiltraConcepto = new System.Windows.Forms.ComboBox();
            this.lblfiltros = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrarfiltros = new System.Windows.Forms.Button();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.pnlSuperior2 = new System.Windows.Forms.Panel();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            this.gbxFiltros.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.pnlSuperior2.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGastos
            // 
            this.dgvGastos.AllowUserToAddRows = false;
            this.dgvGastos.AllowUserToResizeRows = false;
            this.dgvGastos.BackgroundColor = System.Drawing.Color.White;
            this.dgvGastos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGastos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvGastos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGastos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGastos.ColumnHeadersHeight = 25;
            this.dgvGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGastoID,
            this.colFecha,
            this.ColMovimiento,
            this.colNumeroComprobante,
            this.colImporte,
            this.colEstado,
            this.colObservacion});
            this.dgvGastos.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGastos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGastos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGastos.EnableHeadersVisualStyles = false;
            this.dgvGastos.GridColor = System.Drawing.Color.Teal;
            this.dgvGastos.Location = new System.Drawing.Point(4, 4);
            this.dgvGastos.MultiSelect = false;
            this.dgvGastos.Name = "dgvGastos";
            this.dgvGastos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGastos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGastos.RowHeadersVisible = false;
            this.dgvGastos.RowHeadersWidth = 38;
            this.dgvGastos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGastos.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGastos.Size = new System.Drawing.Size(656, 606);
            this.dgvGastos.TabIndex = 545;
            this.dgvGastos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGastos_CellDoubleClick);
            this.dgvGastos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGastos_CellFormatting);
            // 
            // colGastoID
            // 
            this.colGastoID.HeaderText = "GastoID";
            this.colGastoID.Name = "colGastoID";
            this.colGastoID.Visible = false;
            this.colGastoID.Width = 300;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Width = 200;
            // 
            // ColMovimiento
            // 
            this.ColMovimiento.HeaderText = "Movimiento";
            this.ColMovimiento.Name = "ColMovimiento";
            this.ColMovimiento.Width = 350;
            // 
            // colNumeroComprobante
            // 
            this.colNumeroComprobante.HeaderText = "Numero";
            this.colNumeroComprobante.Name = "colNumeroComprobante";
            // 
            // colImporte
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.colImporte.DefaultCellStyle = dataGridViewCellStyle2;
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Width = 150;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            // 
            // colObservacion
            // 
            this.colObservacion.HeaderText = "Obsevacion";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.Width = 500;
            // 
            // btnBuscarDesc
            // 
            this.btnBuscarDesc.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarDesc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarDesc.BackgroundImage")));
            this.btnBuscarDesc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarDesc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarDesc.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarDesc.FlatAppearance.BorderSize = 0;
            this.btnBuscarDesc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDesc.Location = new System.Drawing.Point(19, 3);
            this.btnBuscarDesc.Name = "btnBuscarDesc";
            this.btnBuscarDesc.Size = new System.Drawing.Size(31, 26);
            this.btnBuscarDesc.TabIndex = 603;
            this.btnBuscarDesc.UseVisualStyleBackColor = false;
            this.btnBuscarDesc.Visible = false;
            this.btnBuscarDesc.Click += new System.EventHandler(this.btnBuscarDesc_Click);
            // 
            // cmbOrdenar
            // 
            this.cmbOrdenar.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenar.FormattingEnabled = true;
            this.cmbOrdenar.Items.AddRange(new object[] {
            "",
            "Fecha",
            "Concepto",
            "Valor"});
            this.cmbOrdenar.Location = new System.Drawing.Point(67, 5);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(229, 21);
            this.cmbOrdenar.TabIndex = 602;
            // 
            // btnBuscarAsc
            // 
            this.btnBuscarAsc.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarAsc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarAsc.BackgroundImage")));
            this.btnBuscarAsc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarAsc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarAsc.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarAsc.FlatAppearance.BorderSize = 0;
            this.btnBuscarAsc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarAsc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarAsc.Location = new System.Drawing.Point(19, 3);
            this.btnBuscarAsc.Name = "btnBuscarAsc";
            this.btnBuscarAsc.Size = new System.Drawing.Size(31, 26);
            this.btnBuscarAsc.TabIndex = 601;
            this.btnBuscarAsc.UseVisualStyleBackColor = false;
            this.btnBuscarAsc.Click += new System.EventHandler(this.btnBuscarAsc_Click);
            // 
            // btnCopiar
            // 
            this.btnCopiar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCopiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopiar.BackgroundImage")));
            this.btnCopiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCopiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopiar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCopiar.FlatAppearance.BorderSize = 0;
            this.btnCopiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiar.Location = new System.Drawing.Point(37, 3);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(26, 26);
            this.btnCopiar.TabIndex = 600;
            this.btnCopiar.UseVisualStyleBackColor = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel.BackgroundImage")));
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Location = new System.Drawing.Point(191, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(26, 26);
            this.btnExcel.TabIndex = 599;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Location = new System.Drawing.Point(179, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 21);
            this.pictureBox1.TabIndex = 598;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(143, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 597;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox18.Location = new System.Drawing.Point(133, 6);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(2, 21);
            this.pictureBox18.TabIndex = 596;
            this.pictureBox18.TabStop = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Location = new System.Drawing.Point(69, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(26, 26);
            this.btnEditar.TabIndex = 595;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(101, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(26, 26);
            this.btnEliminar.TabIndex = 594;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(3, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(26, 26);
            this.btnAgregar.TabIndex = 593;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbxFiltros.Controls.Add(this.cmbFiltraEstado);
            this.gbxFiltros.Controls.Add(this.chkFiltraEstado);
            this.gbxFiltros.Controls.Add(this.btnBuscarConcepto);
            this.gbxFiltros.Controls.Add(this.txtBuscarCliente);
            this.gbxFiltros.Controls.Add(this.btnBuscarCliente);
            this.gbxFiltros.Controls.Add(this.cmbCliente);
            this.gbxFiltros.Controls.Add(this.chkFiltraCliente);
            this.gbxFiltros.Controls.Add(this.cmbMovimiento);
            this.gbxFiltros.Controls.Add(this.chkFiltraMovimiento);
            this.gbxFiltros.Controls.Add(this.chkFechaHasta);
            this.gbxFiltros.Controls.Add(this.chkFechaDesde);
            this.gbxFiltros.Controls.Add(this.dtpFechaHasta);
            this.gbxFiltros.Controls.Add(this.dtpFechaDesde);
            this.gbxFiltros.Controls.Add(this.txtBuscaConcepto);
            this.gbxFiltros.Controls.Add(this.chkFiltraConcepto);
            this.gbxFiltros.Controls.Add(this.cmbFiltraConcepto);
            this.gbxFiltros.Controls.Add(this.lblfiltros);
            this.gbxFiltros.Controls.Add(this.btnBuscar);
            this.gbxFiltros.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbxFiltros.Location = new System.Drawing.Point(660, 4);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Size = new System.Drawing.Size(495, 606);
            this.gbxFiltros.TabIndex = 607;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Visible = false;
            this.gbxFiltros.Enter += new System.EventHandler(this.gbxFiltros_Enter);
            // 
            // cmbFiltraEstado
            // 
            this.cmbFiltraEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraEstado.FormattingEnabled = true;
            this.cmbFiltraEstado.Items.AddRange(new object[] {
            "FI",
            "AN"});
            this.cmbFiltraEstado.Location = new System.Drawing.Point(113, 167);
            this.cmbFiltraEstado.Name = "cmbFiltraEstado";
            this.cmbFiltraEstado.Size = new System.Drawing.Size(171, 21);
            this.cmbFiltraEstado.TabIndex = 618;
            // 
            // chkFiltraEstado
            // 
            this.chkFiltraEstado.AutoSize = true;
            this.chkFiltraEstado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraEstado.Location = new System.Drawing.Point(45, 171);
            this.chkFiltraEstado.Name = "chkFiltraEstado";
            this.chkFiltraEstado.Size = new System.Drawing.Size(59, 17);
            this.chkFiltraEstado.TabIndex = 617;
            this.chkFiltraEstado.Text = "Estado";
            this.chkFiltraEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraEstado.UseVisualStyleBackColor = false;
            this.chkFiltraEstado.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnBuscarConcepto
            // 
            this.btnBuscarConcepto.BackColor = System.Drawing.Color.White;
            this.btnBuscarConcepto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarConcepto.BackgroundImage")));
            this.btnBuscarConcepto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarConcepto.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscarConcepto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarConcepto.FlatAppearance.BorderSize = 0;
            this.btnBuscarConcepto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarConcepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarConcepto.Location = new System.Drawing.Point(451, 137);
            this.btnBuscarConcepto.Name = "btnBuscarConcepto";
            this.btnBuscarConcepto.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarConcepto.TabIndex = 616;
            this.btnBuscarConcepto.UseVisualStyleBackColor = false;
            this.btnBuscarConcepto.Click += new System.EventHandler(this.btnBuscarConcepto_Click_1);
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBuscarCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarCliente.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarCliente.Location = new System.Drawing.Point(114, 107);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(332, 22);
            this.txtBuscarCliente.TabIndex = 615;
            this.txtBuscarCliente.Visible = false;
            this.txtBuscarCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarCliente_KeyPress);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.White;
            this.btnBuscarCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.BackgroundImage")));
            this.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Location = new System.Drawing.Point(451, 108);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCliente.TabIndex = 614;
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // cmbCliente
            // 
            this.cmbCliente.BackColor = System.Drawing.Color.White;
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(114, 107);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(332, 22);
            this.cmbCliente.TabIndex = 613;
            this.cmbCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCliente_KeyPress);
            // 
            // chkFiltraCliente
            // 
            this.chkFiltraCliente.AutoSize = true;
            this.chkFiltraCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraCliente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraCliente.Location = new System.Drawing.Point(46, 109);
            this.chkFiltraCliente.Name = "chkFiltraCliente";
            this.chkFiltraCliente.Size = new System.Drawing.Size(58, 17);
            this.chkFiltraCliente.TabIndex = 609;
            this.chkFiltraCliente.Text = "Cliente";
            this.chkFiltraCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraCliente.UseVisualStyleBackColor = false;
            this.chkFiltraCliente.CheckedChanged += new System.EventHandler(this.chkFiltraCliente_CheckedChanged);
            // 
            // cmbMovimiento
            // 
            this.cmbMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovimiento.FormattingEnabled = true;
            this.cmbMovimiento.Location = new System.Drawing.Point(113, 78);
            this.cmbMovimiento.Name = "cmbMovimiento";
            this.cmbMovimiento.Size = new System.Drawing.Size(332, 21);
            this.cmbMovimiento.TabIndex = 608;
            // 
            // chkFiltraMovimiento
            // 
            this.chkFiltraMovimiento.AutoSize = true;
            this.chkFiltraMovimiento.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraMovimiento.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraMovimiento.Location = new System.Drawing.Point(24, 80);
            this.chkFiltraMovimiento.Name = "chkFiltraMovimiento";
            this.chkFiltraMovimiento.Size = new System.Drawing.Size(80, 17);
            this.chkFiltraMovimiento.TabIndex = 593;
            this.chkFiltraMovimiento.Text = "Movimiento";
            this.chkFiltraMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraMovimiento.UseVisualStyleBackColor = false;
            this.chkFiltraMovimiento.CheckedChanged += new System.EventHandler(this.chkFiltraMovimiento_CheckedChanged);
            // 
            // chkFechaHasta
            // 
            this.chkFechaHasta.AutoSize = true;
            this.chkFechaHasta.Checked = true;
            this.chkFechaHasta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFechaHasta.Location = new System.Drawing.Point(278, 231);
            this.chkFechaHasta.Name = "chkFechaHasta";
            this.chkFechaHasta.Size = new System.Drawing.Size(54, 17);
            this.chkFechaHasta.TabIndex = 592;
            this.chkFechaHasta.Text = "Hasta";
            this.chkFechaHasta.UseVisualStyleBackColor = true;
            // 
            // chkFechaDesde
            // 
            this.chkFechaDesde.AutoSize = true;
            this.chkFechaDesde.Checked = true;
            this.chkFechaDesde.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFechaDesde.Location = new System.Drawing.Point(57, 231);
            this.chkFechaDesde.Name = "chkFechaDesde";
            this.chkFechaDesde.Size = new System.Drawing.Size(57, 17);
            this.chkFechaDesde.TabIndex = 591;
            this.chkFechaDesde.Text = "Desde";
            this.chkFechaDesde.UseVisualStyleBackColor = true;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(335, 231);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaHasta.TabIndex = 590;
            this.dtpFechaHasta.Value = new System.DateTime(2021, 4, 30, 2, 21, 26, 0);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(114, 230);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaDesde.TabIndex = 589;
            // 
            // txtBuscaConcepto
            // 
            this.txtBuscaConcepto.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscaConcepto.Location = new System.Drawing.Point(113, 137);
            this.txtBuscaConcepto.Name = "txtBuscaConcepto";
            this.txtBuscaConcepto.Size = new System.Drawing.Size(332, 20);
            this.txtBuscaConcepto.TabIndex = 531;
            this.txtBuscaConcepto.Visible = false;
            this.txtBuscaConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaConcepto_KeyPress);
            // 
            // chkFiltraConcepto
            // 
            this.chkFiltraConcepto.AutoSize = true;
            this.chkFiltraConcepto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraConcepto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraConcepto.Location = new System.Drawing.Point(32, 139);
            this.chkFiltraConcepto.Name = "chkFiltraConcepto";
            this.chkFiltraConcepto.Size = new System.Drawing.Size(72, 17);
            this.chkFiltraConcepto.TabIndex = 460;
            this.chkFiltraConcepto.Text = "Concepto";
            this.chkFiltraConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraConcepto.UseVisualStyleBackColor = false;
            this.chkFiltraConcepto.CheckedChanged += new System.EventHandler(this.chkFiltraConcepto_CheckedChanged);
            // 
            // cmbFiltraConcepto
            // 
            this.cmbFiltraConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraConcepto.Enabled = false;
            this.cmbFiltraConcepto.FormattingEnabled = true;
            this.cmbFiltraConcepto.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbFiltraConcepto.Location = new System.Drawing.Point(113, 136);
            this.cmbFiltraConcepto.Name = "cmbFiltraConcepto";
            this.cmbFiltraConcepto.Size = new System.Drawing.Size(332, 21);
            this.cmbFiltraConcepto.TabIndex = 458;
            this.cmbFiltraConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFiltraConcepto_KeyPress);
            // 
            // lblfiltros
            // 
            this.lblfiltros.AutoSize = true;
            this.lblfiltros.BackColor = System.Drawing.Color.WhiteSmoke;
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
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImage = global::PCodin_Sinlacc.Properties.Resources.lupa__8_;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(3, 573);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(489, 30);
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
            this.btnMostrarfiltros.Location = new System.Drawing.Point(660, 3);
            this.btnMostrarfiltros.Name = "btnMostrarfiltros";
            this.btnMostrarfiltros.Size = new System.Drawing.Size(496, 36);
            this.btnMostrarfiltros.TabIndex = 604;
            this.btnMostrarfiltros.Text = "Mostrar Filtros";
            this.btnMostrarfiltros.UseVisualStyleBackColor = false;
            this.btnMostrarfiltros.Click += new System.EventHandler(this.btnMostrarfiltros_Click);
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.pnlSuperior2);
            this.pnlSuperior.Controls.Add(this.btnAgregar);
            this.pnlSuperior.Controls.Add(this.btnEliminar);
            this.pnlSuperior.Controls.Add(this.btnEditar);
            this.pnlSuperior.Controls.Add(this.pictureBox18);
            this.pnlSuperior.Controls.Add(this.button1);
            this.pnlSuperior.Controls.Add(this.pictureBox1);
            this.pnlSuperior.Controls.Add(this.btnExcel);
            this.pnlSuperior.Controls.Add(this.btnCopiar);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1159, 34);
            this.pnlSuperior.TabIndex = 608;
            // 
            // pnlSuperior2
            // 
            this.pnlSuperior2.Controls.Add(this.cmbOrdenar);
            this.pnlSuperior2.Controls.Add(this.btnBuscarDesc);
            this.pnlSuperior2.Controls.Add(this.btnBuscarAsc);
            this.pnlSuperior2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSuperior2.Location = new System.Drawing.Point(858, 0);
            this.pnlSuperior2.Name = "pnlSuperior2";
            this.pnlSuperior2.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSuperior2.Size = new System.Drawing.Size(301, 34);
            this.pnlSuperior2.TabIndex = 601;
            // 
            // pnlCentral
            // 
            this.pnlCentral.BackColor = System.Drawing.Color.White;
            this.pnlCentral.Controls.Add(this.panel9);
            this.pnlCentral.Controls.Add(this.dgvGastos);
            this.pnlCentral.Controls.Add(this.gbxFiltros);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(0, 34);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Padding = new System.Windows.Forms.Padding(4);
            this.pnlCentral.Size = new System.Drawing.Size(1159, 614);
            this.pnlCentral.TabIndex = 609;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(4, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(656, 2);
            this.panel9.TabIndex = 671;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblResultados);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.btnMostrarfiltros);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 648);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(1159, 42);
            this.panel1.TabIndex = 610;
            // 
            // lblResultados
            // 
            this.lblResultados.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblResultados.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblResultados.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultados.ForeColor = System.Drawing.Color.Teal;
            this.lblResultados.Location = new System.Drawing.Point(156, 3);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(85, 36);
            this.lblResultados.TabIndex = 606;
            this.lblResultados.Text = "0";
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label20.Dock = System.Windows.Forms.DockStyle.Left;
            this.label20.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(3, 3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(153, 36);
            this.label20.TabIndex = 605;
            this.label20.Text = "Cantidad";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMostrarGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1159, 690);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMostrarGastos";
            this.Text = "frmGastos";
            this.Load += new System.EventHandler(this.frmMostrarGastos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior2.ResumeLayout(false);
            this.pnlCentral.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvGastos;
        private System.Windows.Forms.Button btnBuscarDesc;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.Button btnBuscarAsc;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.CheckBox chkFechaHasta;
        private System.Windows.Forms.CheckBox chkFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.TextBox txtBuscaConcepto;
        private System.Windows.Forms.CheckBox chkFiltraConcepto;
        private System.Windows.Forms.ComboBox cmbFiltraConcepto;
        private System.Windows.Forms.Label lblfiltros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrarfiltros;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pnlSuperior2;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.CheckBox chkFiltraMovimiento;
        private System.Windows.Forms.CheckBox chkFiltraCliente;
        public System.Windows.Forms.ComboBox cmbMovimiento;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Button btnBuscarConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
        private System.Windows.Forms.CheckBox chkFiltraEstado;
        public System.Windows.Forms.ComboBox cmbFiltraEstado;
    }
}