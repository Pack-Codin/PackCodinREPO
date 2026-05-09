namespace PCodin_Sinlacc.Formularios
{
    partial class frmRegistroDePedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroDePedidos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnMostrarfiltros = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvOrdenPedido = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.Button();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlFiltroFecha = new System.Windows.Forms.Panel();
            this.chkFechaHasta = new System.Windows.Forms.CheckBox();
            this.chkFechaDesde = new System.Windows.Forms.CheckBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pnlFiltroGeneral = new System.Windows.Forms.Panel();
            this.chkFiltraVendedor = new System.Windows.Forms.CheckBox();
            this.txtFiltraVendedor = new System.Windows.Forms.TextBox();
            this.btnBuscaVendedor = new System.Windows.Forms.Button();
            this.cmbFiltraVendedor = new System.Windows.Forms.ComboBox();
            this.cmbFiltraZona = new System.Windows.Forms.ComboBox();
            this.chkFiltraZona = new System.Windows.Forms.CheckBox();
            this.txtFiltraNroPedido = new System.Windows.Forms.TextBox();
            this.chkFiltraNroPedido = new System.Windows.Forms.CheckBox();
            this.chkFiltraCiudad = new System.Windows.Forms.CheckBox();
            this.chkFiltraCliente = new System.Windows.Forms.CheckBox();
            this.txtBuscarCiudad = new System.Windows.Forms.TextBox();
            this.btnBuscarCiudad = new System.Windows.Forms.Button();
            this.cmbCiudad = new System.Windows.Forms.ComboBox();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.btnBuscarIProducto = new System.Windows.Forms.Button();
            this.chkFiltraProducto = new System.Windows.Forms.CheckBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.cmbFiltraEstado = new System.Windows.Forms.ComboBox();
            this.chkFiltraEstado = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblfiltros = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnBuscarDesc = new System.Windows.Forms.Button();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.btnBuscarAsc = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnRelacion = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            this.gbxFiltros.SuspendLayout();
            this.pnlFiltroFecha.SuspendLayout();
            this.pnlFiltroGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(101, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(26, 26);
            this.btnEliminar.TabIndex = 491;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnMostrarfiltros
            // 
            this.btnMostrarfiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMostrarfiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMostrarfiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarfiltros.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMostrarfiltros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMostrarfiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarfiltros.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarfiltros.ForeColor = System.Drawing.Color.Black;
            this.btnMostrarfiltros.Location = new System.Drawing.Point(599, 0);
            this.btnMostrarfiltros.Name = "btnMostrarfiltros";
            this.btnMostrarfiltros.Size = new System.Drawing.Size(563, 35);
            this.btnMostrarfiltros.TabIndex = 490;
            this.btnMostrarfiltros.Text = "Mostrar Filtros";
            this.btnMostrarfiltros.UseVisualStyleBackColor = false;
            this.btnMostrarfiltros.Click += new System.EventHandler(this.btnMostrarfiltros_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(3, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(26, 26);
            this.btnAgregar.TabIndex = 489;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvOrdenPedido
            // 
            this.dgvOrdenPedido.AllowUserToAddRows = false;
            this.dgvOrdenPedido.AllowUserToResizeRows = false;
            this.dgvOrdenPedido.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenPedido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrdenPedido.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvOrdenPedido.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenPedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrdenPedido.ColumnHeadersHeight = 26;
            this.dgvOrdenPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrdenPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colNumeroPedido,
            this.colFecha,
            this.colCliente,
            this.colCiudad,
            this.colZona,
            this.colVendedor,
            this.colEstado,
            this.colObservacion});
            this.dgvOrdenPedido.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdenPedido.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrdenPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdenPedido.EnableHeadersVisualStyles = false;
            this.dgvOrdenPedido.GridColor = System.Drawing.Color.Teal;
            this.dgvOrdenPedido.Location = new System.Drawing.Point(0, 0);
            this.dgvOrdenPedido.MultiSelect = false;
            this.dgvOrdenPedido.Name = "dgvOrdenPedido";
            this.dgvOrdenPedido.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenPedido.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrdenPedido.RowHeadersVisible = false;
            this.dgvOrdenPedido.RowHeadersWidth = 38;
            this.dgvOrdenPedido.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdenPedido.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrdenPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenPedido.Size = new System.Drawing.Size(594, 621);
            this.dgvOrdenPedido.TabIndex = 487;
            this.dgvOrdenPedido.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenPedido_CellContentClick);
            this.dgvOrdenPedido.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenPedido_CellDoubleClick);
            this.dgvOrdenPedido.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOrdenPedido_CellFormatting);
            // 
            // colID
            // 
            this.colID.HeaderText = "PedidoID";
            this.colID.Name = "colID";
            this.colID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colID.Visible = false;
            this.colID.Width = 120;
            // 
            // colNumeroPedido
            // 
            this.colNumeroPedido.HeaderText = "Nro pedido";
            this.colNumeroPedido.Name = "colNumeroPedido";
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Width = 150;
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.Width = 350;
            // 
            // colCiudad
            // 
            this.colCiudad.HeaderText = "Ciudad";
            this.colCiudad.Name = "colCiudad";
            this.colCiudad.Width = 200;
            // 
            // colZona
            // 
            this.colZona.HeaderText = "Zona";
            this.colZona.Name = "colZona";
            // 
            // colVendedor
            // 
            this.colVendedor.HeaderText = "Responsable";
            this.colVendedor.Name = "colVendedor";
            // 
            // colEstado
            // 
            this.colEstado.FillWeight = 40F;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Width = 150;
            // 
            // colObservacion
            // 
            this.colObservacion.HeaderText = "Observaciones";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.Width = 450;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Location = new System.Drawing.Point(69, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(26, 26);
            this.btnEditar.TabIndex = 492;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox18.Location = new System.Drawing.Point(133, 6);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(2, 21);
            this.pictureBox18.TabIndex = 493;
            this.pictureBox18.TabStop = false;
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbxFiltros.Controls.Add(this.btnBuscar);
            this.gbxFiltros.Controls.Add(this.pnlFiltroFecha);
            this.gbxFiltros.Controls.Add(this.textBox3);
            this.gbxFiltros.Controls.Add(this.pnlFiltroGeneral);
            this.gbxFiltros.Controls.Add(this.textBox4);
            this.gbxFiltros.Controls.Add(this.lblfiltros);
            this.gbxFiltros.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbxFiltros.Location = new System.Drawing.Point(594, 0);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Padding = new System.Windows.Forms.Padding(5);
            this.gbxFiltros.Size = new System.Drawing.Size(568, 621);
            this.gbxFiltros.TabIndex = 494;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnBuscar.FlatAppearance.BorderSize = 2;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(5, 586);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(558, 30);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlFiltroFecha
            // 
            this.pnlFiltroFecha.Controls.Add(this.chkFechaHasta);
            this.pnlFiltroFecha.Controls.Add(this.chkFechaDesde);
            this.pnlFiltroFecha.Controls.Add(this.dtpFechaHasta);
            this.pnlFiltroFecha.Controls.Add(this.dtpFechaDesde);
            this.pnlFiltroFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltroFecha.Location = new System.Drawing.Point(5, 375);
            this.pnlFiltroFecha.Name = "pnlFiltroFecha";
            this.pnlFiltroFecha.Size = new System.Drawing.Size(558, 55);
            this.pnlFiltroFecha.TabIndex = 614;
            // 
            // chkFechaHasta
            // 
            this.chkFechaHasta.AutoSize = true;
            this.chkFechaHasta.Checked = true;
            this.chkFechaHasta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFechaHasta.Location = new System.Drawing.Point(282, 17);
            this.chkFechaHasta.Name = "chkFechaHasta";
            this.chkFechaHasta.Size = new System.Drawing.Size(54, 17);
            this.chkFechaHasta.TabIndex = 587;
            this.chkFechaHasta.Text = "Hasta";
            this.chkFechaHasta.UseVisualStyleBackColor = true;
            this.chkFechaHasta.CheckedChanged += new System.EventHandler(this.chkFechaHasta_CheckedChanged);
            // 
            // chkFechaDesde
            // 
            this.chkFechaDesde.AutoSize = true;
            this.chkFechaDesde.Checked = true;
            this.chkFechaDesde.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFechaDesde.Location = new System.Drawing.Point(61, 17);
            this.chkFechaDesde.Name = "chkFechaDesde";
            this.chkFechaDesde.Size = new System.Drawing.Size(57, 17);
            this.chkFechaDesde.TabIndex = 586;
            this.chkFechaDesde.Text = "Desde";
            this.chkFechaDesde.UseVisualStyleBackColor = true;
            this.chkFechaDesde.CheckedChanged += new System.EventHandler(this.chkFechaDesde_CheckedChanged);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(339, 17);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaHasta.TabIndex = 585;
            this.dtpFechaHasta.Value = new System.DateTime(2025, 4, 4, 0, 0, 0, 0);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(118, 16);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaDesde.TabIndex = 584;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox3.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(5, 352);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(558, 23);
            this.textBox3.TabIndex = 588;
            this.textBox3.Text = "Fecha";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlFiltroGeneral
            // 
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraVendedor);
            this.pnlFiltroGeneral.Controls.Add(this.txtFiltraVendedor);
            this.pnlFiltroGeneral.Controls.Add(this.btnBuscaVendedor);
            this.pnlFiltroGeneral.Controls.Add(this.cmbFiltraVendedor);
            this.pnlFiltroGeneral.Controls.Add(this.cmbFiltraZona);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraZona);
            this.pnlFiltroGeneral.Controls.Add(this.txtFiltraNroPedido);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraNroPedido);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraCiudad);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraCliente);
            this.pnlFiltroGeneral.Controls.Add(this.txtBuscarCiudad);
            this.pnlFiltroGeneral.Controls.Add(this.btnBuscarCiudad);
            this.pnlFiltroGeneral.Controls.Add(this.cmbCiudad);
            this.pnlFiltroGeneral.Controls.Add(this.txtBuscarCliente);
            this.pnlFiltroGeneral.Controls.Add(this.btnBuscarCliente);
            this.pnlFiltroGeneral.Controls.Add(this.cmbCliente);
            this.pnlFiltroGeneral.Controls.Add(this.txtBuscarProducto);
            this.pnlFiltroGeneral.Controls.Add(this.btnBuscarIProducto);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraProducto);
            this.pnlFiltroGeneral.Controls.Add(this.cmbProducto);
            this.pnlFiltroGeneral.Controls.Add(this.cmbFiltraEstado);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraEstado);
            this.pnlFiltroGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltroGeneral.Location = new System.Drawing.Point(5, 70);
            this.pnlFiltroGeneral.Name = "pnlFiltroGeneral";
            this.pnlFiltroGeneral.Size = new System.Drawing.Size(558, 282);
            this.pnlFiltroGeneral.TabIndex = 613;
            // 
            // chkFiltraVendedor
            // 
            this.chkFiltraVendedor.AutoSize = true;
            this.chkFiltraVendedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraVendedor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraVendedor.Location = new System.Drawing.Point(28, 153);
            this.chkFiltraVendedor.Name = "chkFiltraVendedor";
            this.chkFiltraVendedor.Size = new System.Drawing.Size(72, 17);
            this.chkFiltraVendedor.TabIndex = 596;
            this.chkFiltraVendedor.Text = "Vendedor";
            this.chkFiltraVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraVendedor.UseVisualStyleBackColor = false;
            this.chkFiltraVendedor.CheckedChanged += new System.EventHandler(this.chkFiltraVendedor_CheckedChanged);
            // 
            // txtFiltraVendedor
            // 
            this.txtFiltraVendedor.AcceptsReturn = true;
            this.txtFiltraVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtFiltraVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltraVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltraVendedor.ForeColor = System.Drawing.Color.Black;
            this.txtFiltraVendedor.Location = new System.Drawing.Point(112, 150);
            this.txtFiltraVendedor.Name = "txtFiltraVendedor";
            this.txtFiltraVendedor.Size = new System.Drawing.Size(340, 22);
            this.txtFiltraVendedor.TabIndex = 595;
            this.txtFiltraVendedor.Visible = false;
            this.txtFiltraVendedor.Click += new System.EventHandler(this.txtFiltraVendedor_Click);
            this.txtFiltraVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltraVendedor_KeyPress);
            // 
            // btnBuscaVendedor
            // 
            this.btnBuscaVendedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscaVendedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscaVendedor.BackgroundImage")));
            this.btnBuscaVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscaVendedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscaVendedor.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscaVendedor.FlatAppearance.BorderSize = 0;
            this.btnBuscaVendedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscaVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaVendedor.Location = new System.Drawing.Point(470, 149);
            this.btnBuscaVendedor.Name = "btnBuscaVendedor";
            this.btnBuscaVendedor.Size = new System.Drawing.Size(23, 23);
            this.btnBuscaVendedor.TabIndex = 594;
            this.btnBuscaVendedor.UseVisualStyleBackColor = false;
            this.btnBuscaVendedor.Click += new System.EventHandler(this.btnBuscaVendedor_Click);
            // 
            // cmbFiltraVendedor
            // 
            this.cmbFiltraVendedor.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbFiltraVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraVendedor.FormattingEnabled = true;
            this.cmbFiltraVendedor.Location = new System.Drawing.Point(112, 149);
            this.cmbFiltraVendedor.Name = "cmbFiltraVendedor";
            this.cmbFiltraVendedor.Size = new System.Drawing.Size(340, 21);
            this.cmbFiltraVendedor.TabIndex = 593;
            this.cmbFiltraVendedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFiltraVendedor_KeyPress);
            // 
            // cmbFiltraZona
            // 
            this.cmbFiltraZona.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbFiltraZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraZona.FormattingEnabled = true;
            this.cmbFiltraZona.Location = new System.Drawing.Point(112, 114);
            this.cmbFiltraZona.Name = "cmbFiltraZona";
            this.cmbFiltraZona.Size = new System.Drawing.Size(340, 21);
            this.cmbFiltraZona.TabIndex = 591;
            // 
            // chkFiltraZona
            // 
            this.chkFiltraZona.AutoSize = true;
            this.chkFiltraZona.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraZona.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraZona.Location = new System.Drawing.Point(49, 118);
            this.chkFiltraZona.Name = "chkFiltraZona";
            this.chkFiltraZona.Size = new System.Drawing.Size(51, 17);
            this.chkFiltraZona.TabIndex = 592;
            this.chkFiltraZona.Text = "Zona";
            this.chkFiltraZona.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraZona.UseVisualStyleBackColor = false;
            this.chkFiltraZona.CheckedChanged += new System.EventHandler(this.chkFiltraZona_CheckedChanged);
            // 
            // txtFiltraNroPedido
            // 
            this.txtFiltraNroPedido.Enabled = false;
            this.txtFiltraNroPedido.Location = new System.Drawing.Point(112, 14);
            this.txtFiltraNroPedido.Name = "txtFiltraNroPedido";
            this.txtFiltraNroPedido.Size = new System.Drawing.Size(139, 20);
            this.txtFiltraNroPedido.TabIndex = 590;
            // 
            // chkFiltraNroPedido
            // 
            this.chkFiltraNroPedido.AutoSize = true;
            this.chkFiltraNroPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraNroPedido.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraNroPedido.Location = new System.Drawing.Point(22, 17);
            this.chkFiltraNroPedido.Name = "chkFiltraNroPedido";
            this.chkFiltraNroPedido.Size = new System.Drawing.Size(78, 17);
            this.chkFiltraNroPedido.TabIndex = 589;
            this.chkFiltraNroPedido.Text = "Nro pedido";
            this.chkFiltraNroPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraNroPedido.UseVisualStyleBackColor = false;
            this.chkFiltraNroPedido.CheckedChanged += new System.EventHandler(this.chkFiltraNroPedido_CheckedChanged);
            // 
            // chkFiltraCiudad
            // 
            this.chkFiltraCiudad.AutoSize = true;
            this.chkFiltraCiudad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraCiudad.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraCiudad.Location = new System.Drawing.Point(41, 82);
            this.chkFiltraCiudad.Name = "chkFiltraCiudad";
            this.chkFiltraCiudad.Size = new System.Drawing.Size(59, 17);
            this.chkFiltraCiudad.TabIndex = 583;
            this.chkFiltraCiudad.Text = "Ciudad";
            this.chkFiltraCiudad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraCiudad.UseVisualStyleBackColor = false;
            this.chkFiltraCiudad.CheckedChanged += new System.EventHandler(this.chkFiltraCiudad_CheckedChanged);
            // 
            // chkFiltraCliente
            // 
            this.chkFiltraCliente.AutoSize = true;
            this.chkFiltraCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraCliente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraCliente.Location = new System.Drawing.Point(42, 49);
            this.chkFiltraCliente.Name = "chkFiltraCliente";
            this.chkFiltraCliente.Size = new System.Drawing.Size(58, 17);
            this.chkFiltraCliente.TabIndex = 582;
            this.chkFiltraCliente.Text = "Cliente";
            this.chkFiltraCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraCliente.UseVisualStyleBackColor = false;
            this.chkFiltraCliente.CheckedChanged += new System.EventHandler(this.chkFiltraCliente_CheckedChanged);
            // 
            // txtBuscarCiudad
            // 
            this.txtBuscarCiudad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBuscarCiudad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCiudad.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarCiudad.Location = new System.Drawing.Point(112, 80);
            this.txtBuscarCiudad.Name = "txtBuscarCiudad";
            this.txtBuscarCiudad.Size = new System.Drawing.Size(340, 22);
            this.txtBuscarCiudad.TabIndex = 581;
            this.txtBuscarCiudad.Visible = false;
            this.txtBuscarCiudad.Click += new System.EventHandler(this.txtBuscarCiudad_Click);
            this.txtBuscarCiudad.TextChanged += new System.EventHandler(this.txtBuscarCiudad_TextChanged);
            this.txtBuscarCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarCiudad_KeyPress);
            // 
            // btnBuscarCiudad
            // 
            this.btnBuscarCiudad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarCiudad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCiudad.BackgroundImage")));
            this.btnBuscarCiudad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarCiudad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCiudad.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarCiudad.FlatAppearance.BorderSize = 0;
            this.btnBuscarCiudad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCiudad.Location = new System.Drawing.Point(470, 79);
            this.btnBuscarCiudad.Name = "btnBuscarCiudad";
            this.btnBuscarCiudad.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCiudad.TabIndex = 580;
            this.btnBuscarCiudad.UseVisualStyleBackColor = false;
            this.btnBuscarCiudad.Click += new System.EventHandler(this.btnBuscarCiudad_Click);
            // 
            // cmbCiudad
            // 
            this.cmbCiudad.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudad.FormattingEnabled = true;
            this.cmbCiudad.Location = new System.Drawing.Point(112, 80);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(340, 21);
            this.cmbCiudad.TabIndex = 579;
            this.cmbCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCiudad_KeyPress);
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBuscarCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarCliente.Location = new System.Drawing.Point(112, 47);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(340, 22);
            this.txtBuscarCliente.TabIndex = 576;
            this.txtBuscarCliente.Visible = false;
            this.txtBuscarCliente.Click += new System.EventHandler(this.txtBuscarCliente_Click);
            this.txtBuscarCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarCliente_KeyPress);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.BackgroundImage")));
            this.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Location = new System.Drawing.Point(470, 46);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCliente.TabIndex = 575;
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // cmbCliente
            // 
            this.cmbCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(112, 46);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(340, 21);
            this.cmbCliente.TabIndex = 574;
            this.cmbCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCliente_KeyPress);
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBuscarProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarProducto.Location = new System.Drawing.Point(112, 189);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(340, 20);
            this.txtBuscarProducto.TabIndex = 531;
            this.txtBuscarProducto.Visible = false;
            this.txtBuscarProducto.Click += new System.EventHandler(this.txtBuscarProducto_Click);
            this.txtBuscarProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaInsPro_KeyPress);
            // 
            // btnBuscarIProducto
            // 
            this.btnBuscarIProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarIProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarIProducto.BackgroundImage")));
            this.btnBuscarIProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarIProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarIProducto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarIProducto.FlatAppearance.BorderSize = 0;
            this.btnBuscarIProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarIProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarIProducto.Location = new System.Drawing.Point(470, 187);
            this.btnBuscarIProducto.Name = "btnBuscarIProducto";
            this.btnBuscarIProducto.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarIProducto.TabIndex = 529;
            this.btnBuscarIProducto.UseVisualStyleBackColor = false;
            this.btnBuscarIProducto.Click += new System.EventHandler(this.btnBuscarInsPro_Click);
            // 
            // chkFiltraProducto
            // 
            this.chkFiltraProducto.AutoSize = true;
            this.chkFiltraProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraProducto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraProducto.Location = new System.Drawing.Point(31, 191);
            this.chkFiltraProducto.Name = "chkFiltraProducto";
            this.chkFiltraProducto.Size = new System.Drawing.Size(69, 17);
            this.chkFiltraProducto.TabIndex = 460;
            this.chkFiltraProducto.Text = "Producto";
            this.chkFiltraProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraProducto.UseVisualStyleBackColor = false;
            this.chkFiltraProducto.CheckedChanged += new System.EventHandler(this.chkFiltraProducto_CheckedChanged);
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.Enabled = false;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbProducto.Location = new System.Drawing.Point(112, 189);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(340, 21);
            this.cmbProducto.TabIndex = 458;
            this.cmbProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFiltraInsPro_KeyPress);
            // 
            // cmbFiltraEstado
            // 
            this.cmbFiltraEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraEstado.Enabled = false;
            this.cmbFiltraEstado.FormattingEnabled = true;
            this.cmbFiltraEstado.Items.AddRange(new object[] {
            "AU",
            "FI",
            "IN",
            "AN"});
            this.cmbFiltraEstado.Location = new System.Drawing.Point(112, 225);
            this.cmbFiltraEstado.Name = "cmbFiltraEstado";
            this.cmbFiltraEstado.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltraEstado.TabIndex = 45;
            // 
            // chkFiltraEstado
            // 
            this.chkFiltraEstado.AutoSize = true;
            this.chkFiltraEstado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraEstado.Location = new System.Drawing.Point(41, 227);
            this.chkFiltraEstado.Name = "chkFiltraEstado";
            this.chkFiltraEstado.Size = new System.Drawing.Size(59, 17);
            this.chkFiltraEstado.TabIndex = 44;
            this.chkFiltraEstado.Text = "Estado";
            this.chkFiltraEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraEstado.UseVisualStyleBackColor = false;
            this.chkFiltraEstado.CheckedChanged += new System.EventHandler(this.chkFiltraEstado_CheckedChanged);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox4.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(5, 47);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(558, 23);
            this.textBox4.TabIndex = 457;
            this.textBox4.Text = "General";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblfiltros
            // 
            this.lblfiltros.AutoSize = true;
            this.lblfiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblfiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblfiltros.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfiltros.ForeColor = System.Drawing.Color.Teal;
            this.lblfiltros.Location = new System.Drawing.Point(5, 18);
            this.lblfiltros.Name = "lblfiltros";
            this.lblfiltros.Size = new System.Drawing.Size(74, 29);
            this.lblfiltros.TabIndex = 612;
            this.lblfiltros.Text = "Filtros";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(143, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 495;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox1.Location = new System.Drawing.Point(179, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 21);
            this.pictureBox1.TabIndex = 496;
            this.pictureBox1.TabStop = false;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.White;
            this.btnExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel.BackgroundImage")));
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Location = new System.Drawing.Point(191, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(26, 26);
            this.btnExcel.TabIndex = 497;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBuscarDesc
            // 
            this.btnBuscarDesc.BackColor = System.Drawing.Color.White;
            this.btnBuscarDesc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarDesc.BackgroundImage")));
            this.btnBuscarDesc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarDesc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarDesc.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarDesc.FlatAppearance.BorderSize = 0;
            this.btnBuscarDesc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDesc.Location = new System.Drawing.Point(916, 3);
            this.btnBuscarDesc.Name = "btnBuscarDesc";
            this.btnBuscarDesc.Size = new System.Drawing.Size(31, 26);
            this.btnBuscarDesc.TabIndex = 573;
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
            "Nro pedido",
            "Fecha",
            "Cliente",
            "Ciudad",
            "Estado"});
            this.cmbOrdenar.Location = new System.Drawing.Point(953, 5);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(204, 21);
            this.cmbOrdenar.TabIndex = 572;
            this.cmbOrdenar.SelectedIndexChanged += new System.EventHandler(this.cmbOrdenar_SelectedIndexChanged);
            // 
            // btnBuscarAsc
            // 
            this.btnBuscarAsc.BackColor = System.Drawing.Color.White;
            this.btnBuscarAsc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarAsc.BackgroundImage")));
            this.btnBuscarAsc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarAsc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarAsc.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarAsc.FlatAppearance.BorderSize = 0;
            this.btnBuscarAsc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarAsc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarAsc.Location = new System.Drawing.Point(916, 3);
            this.btnBuscarAsc.Name = "btnBuscarAsc";
            this.btnBuscarAsc.Size = new System.Drawing.Size(31, 26);
            this.btnBuscarAsc.TabIndex = 571;
            this.btnBuscarAsc.UseVisualStyleBackColor = false;
            this.btnBuscarAsc.Click += new System.EventHandler(this.btnBuscarAsc_Click);
            // 
            // btnCopiar
            // 
            this.btnCopiar.BackColor = System.Drawing.Color.White;
            this.btnCopiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopiar.BackgroundImage")));
            this.btnCopiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCopiar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCopiar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCopiar.FlatAppearance.BorderSize = 0;
            this.btnCopiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiar.Location = new System.Drawing.Point(37, 3);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(26, 26);
            this.btnCopiar.TabIndex = 574;
            this.btnCopiar.UseVisualStyleBackColor = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click_1);
            // 
            // btnRelacion
            // 
            this.btnRelacion.BackColor = System.Drawing.Color.White;
            this.btnRelacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRelacion.BackgroundImage")));
            this.btnRelacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRelacion.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRelacion.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnRelacion.FlatAppearance.BorderSize = 0;
            this.btnRelacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnRelacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelacion.Location = new System.Drawing.Point(239, 3);
            this.btnRelacion.Name = "btnRelacion";
            this.btnRelacion.Size = new System.Drawing.Size(26, 26);
            this.btnRelacion.TabIndex = 582;
            this.btnRelacion.UseVisualStyleBackColor = false;
            this.btnRelacion.Click += new System.EventHandler(this.btnRelacion_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox2.Location = new System.Drawing.Point(226, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(2, 21);
            this.pictureBox2.TabIndex = 581;
            this.pictureBox2.TabStop = false;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.btnAgregar);
            this.pnlSuperior.Controls.Add(this.btnRelacion);
            this.pnlSuperior.Controls.Add(this.btnBuscarDesc);
            this.pnlSuperior.Controls.Add(this.btnEliminar);
            this.pnlSuperior.Controls.Add(this.cmbOrdenar);
            this.pnlSuperior.Controls.Add(this.btnBuscarAsc);
            this.pnlSuperior.Controls.Add(this.pictureBox2);
            this.pnlSuperior.Controls.Add(this.btnEditar);
            this.pnlSuperior.Controls.Add(this.btnCopiar);
            this.pnlSuperior.Controls.Add(this.pictureBox18);
            this.pnlSuperior.Controls.Add(this.button1);
            this.pnlSuperior.Controls.Add(this.pictureBox1);
            this.pnlSuperior.Controls.Add(this.btnExcel);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSuperior.Size = new System.Drawing.Size(1162, 34);
            this.pnlSuperior.TabIndex = 583;
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.lblResultados);
            this.pnlInferior.Controls.Add(this.label1);
            this.pnlInferior.Controls.Add(this.btnMostrarfiltros);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 655);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(1162, 35);
            this.pnlInferior.TabIndex = 584;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoEllipsis = true;
            this.lblResultados.BackColor = System.Drawing.Color.Transparent;
            this.lblResultados.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblResultados.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultados.ForeColor = System.Drawing.Color.Black;
            this.lblResultados.Location = new System.Drawing.Point(88, 0);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(88, 35);
            this.lblResultados.TabIndex = 494;
            this.lblResultados.Text = "0";
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 35);
            this.label1.TabIndex = 493;
            this.label1.Text = "Cantidad";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.dgvOrdenPedido);
            this.panel1.Controls.Add(this.gbxFiltros);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 621);
            this.panel1.TabIndex = 585;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(594, 2);
            this.panel9.TabIndex = 671;
            // 
            // frmRegistroDePedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 690);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.pnlSuperior);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRegistroDePedidos";
            this.Text = "frmRegistroDePedidos";
            this.Load += new System.EventHandler(this.frmRegistroDePedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.pnlFiltroFecha.ResumeLayout(false);
            this.pnlFiltroFecha.PerformLayout();
            this.pnlFiltroGeneral.ResumeLayout(false);
            this.pnlFiltroGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnMostrarfiltros;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvOrdenPedido;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Button btnBuscarIProducto;
        private System.Windows.Forms.CheckBox chkFiltraProducto;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbFiltraEstado;
        private System.Windows.Forms.CheckBox chkFiltraEstado;
        private System.Windows.Forms.CheckBox chkFiltraCiudad;
        private System.Windows.Forms.CheckBox chkFiltraCliente;
        private System.Windows.Forms.TextBox txtBuscarCiudad;
        private System.Windows.Forms.Button btnBuscarCiudad;
        private System.Windows.Forms.ComboBox cmbCiudad;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox chkFechaHasta;
        private System.Windows.Forms.CheckBox chkFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox txtFiltraNroPedido;
        private System.Windows.Forms.CheckBox chkFiltraNroPedido;
        private System.Windows.Forms.Button btnBuscarDesc;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.Button btnBuscarAsc;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnRelacion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlFiltroGeneral;
        private System.Windows.Forms.Label lblfiltros;
        private System.Windows.Forms.Panel pnlFiltroFecha;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZona;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
        private System.Windows.Forms.ComboBox cmbFiltraZona;
        private System.Windows.Forms.CheckBox chkFiltraZona;
        private System.Windows.Forms.CheckBox chkFiltraVendedor;
        private System.Windows.Forms.TextBox txtFiltraVendedor;
        private System.Windows.Forms.Button btnBuscaVendedor;
        private System.Windows.Forms.ComboBox cmbFiltraVendedor;
    }
}