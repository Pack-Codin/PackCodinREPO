namespace PCodin_Sinlacc.Formularios
{
    partial class frmMostrarOrdenesCarga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMostrarOrdenesCarga));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.pnlFiltroFecha = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.chkFechaHasta = new System.Windows.Forms.CheckBox();
            this.chkFechaDesde = new System.Windows.Forms.CheckBox();
            this.pnlFiltroGeneral = new System.Windows.Forms.Panel();
            this.txtFiltraPedido = new System.Windows.Forms.TextBox();
            this.chkFiltraPedido = new System.Windows.Forms.CheckBox();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtFiltraNumero = new System.Windows.Forms.TextBox();
            this.txtBuscarCiudad = new System.Windows.Forms.TextBox();
            this.chkFiltraNumero = new System.Windows.Forms.CheckBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.chkMuestraInsProActInac = new System.Windows.Forms.CheckBox();
            this.btnBuscarIProducto = new System.Windows.Forms.Button();
            this.cmbCiudad = new System.Windows.Forms.ComboBox();
            this.chkFiltraProducto = new System.Windows.Forms.CheckBox();
            this.btnBuscarCiudad = new System.Windows.Forms.Button();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.chkFiltraCliente = new System.Windows.Forms.CheckBox();
            this.chkFiltraCiudad = new System.Windows.Forms.CheckBox();
            this.chkFiltraEstado = new System.Windows.Forms.CheckBox();
            this.cmbFiltraEstado = new System.Windows.Forms.ComboBox();
            this.lblfiltros = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnMostrarfiltros = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvOrdenCarga = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.btnBuscarDesc = new System.Windows.Forms.Button();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.btnBuscarAsc = new System.Windows.Forms.Button();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.btnExpedicion = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxFiltros.SuspendLayout();
            this.pnlFiltroFecha.SuspendLayout();
            this.pnlFiltroGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbxFiltros.Controls.Add(this.pnlFiltroFecha);
            this.gbxFiltros.Controls.Add(this.pnlFiltroGeneral);
            this.gbxFiltros.Controls.Add(this.lblfiltros);
            this.gbxFiltros.Controls.Add(this.btnBuscar);
            this.gbxFiltros.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbxFiltros.Location = new System.Drawing.Point(637, 0);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Padding = new System.Windows.Forms.Padding(5);
            this.gbxFiltros.Size = new System.Drawing.Size(525, 615);
            this.gbxFiltros.TabIndex = 501;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Visible = false;
            // 
            // pnlFiltroFecha
            // 
            this.pnlFiltroFecha.Controls.Add(this.textBox1);
            this.pnlFiltroFecha.Controls.Add(this.dtpFechaHasta);
            this.pnlFiltroFecha.Controls.Add(this.dtpFechaDesde);
            this.pnlFiltroFecha.Controls.Add(this.chkFechaHasta);
            this.pnlFiltroFecha.Controls.Add(this.chkFechaDesde);
            this.pnlFiltroFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltroFecha.Location = new System.Drawing.Point(5, 316);
            this.pnlFiltroFecha.Name = "pnlFiltroFecha";
            this.pnlFiltroFecha.Size = new System.Drawing.Size(515, 100);
            this.pnlFiltroFecha.TabIndex = 592;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(515, 23);
            this.textBox1.TabIndex = 458;
            this.textBox1.Text = "Fecha";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(344, 51);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaHasta.TabIndex = 585;
            this.dtpFechaHasta.Value = new System.DateTime(2021, 4, 30, 2, 21, 26, 0);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(123, 50);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaDesde.TabIndex = 584;
            // 
            // chkFechaHasta
            // 
            this.chkFechaHasta.AutoSize = true;
            this.chkFechaHasta.Checked = true;
            this.chkFechaHasta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFechaHasta.Location = new System.Drawing.Point(287, 51);
            this.chkFechaHasta.Name = "chkFechaHasta";
            this.chkFechaHasta.Size = new System.Drawing.Size(54, 17);
            this.chkFechaHasta.TabIndex = 587;
            this.chkFechaHasta.Text = "Hasta";
            this.chkFechaHasta.UseVisualStyleBackColor = true;
            // 
            // chkFechaDesde
            // 
            this.chkFechaDesde.AutoSize = true;
            this.chkFechaDesde.Checked = true;
            this.chkFechaDesde.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFechaDesde.Location = new System.Drawing.Point(66, 51);
            this.chkFechaDesde.Name = "chkFechaDesde";
            this.chkFechaDesde.Size = new System.Drawing.Size(57, 17);
            this.chkFechaDesde.TabIndex = 586;
            this.chkFechaDesde.Text = "Desde";
            this.chkFechaDesde.UseVisualStyleBackColor = true;
            this.chkFechaDesde.CheckedChanged += new System.EventHandler(this.chkFechaDesde_CheckedChanged);
            // 
            // pnlFiltroGeneral
            // 
            this.pnlFiltroGeneral.Controls.Add(this.txtFiltraPedido);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraPedido);
            this.pnlFiltroGeneral.Controls.Add(this.txtBuscarCliente);
            this.pnlFiltroGeneral.Controls.Add(this.textBox4);
            this.pnlFiltroGeneral.Controls.Add(this.txtFiltraNumero);
            this.pnlFiltroGeneral.Controls.Add(this.txtBuscarCiudad);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraNumero);
            this.pnlFiltroGeneral.Controls.Add(this.cmbCliente);
            this.pnlFiltroGeneral.Controls.Add(this.btnBuscarCliente);
            this.pnlFiltroGeneral.Controls.Add(this.txtBuscarProducto);
            this.pnlFiltroGeneral.Controls.Add(this.chkMuestraInsProActInac);
            this.pnlFiltroGeneral.Controls.Add(this.btnBuscarIProducto);
            this.pnlFiltroGeneral.Controls.Add(this.cmbCiudad);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraProducto);
            this.pnlFiltroGeneral.Controls.Add(this.btnBuscarCiudad);
            this.pnlFiltroGeneral.Controls.Add(this.cmbProducto);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraCliente);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraCiudad);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraEstado);
            this.pnlFiltroGeneral.Controls.Add(this.cmbFiltraEstado);
            this.pnlFiltroGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltroGeneral.Location = new System.Drawing.Point(5, 47);
            this.pnlFiltroGeneral.Name = "pnlFiltroGeneral";
            this.pnlFiltroGeneral.Size = new System.Drawing.Size(515, 269);
            this.pnlFiltroGeneral.TabIndex = 591;
            // 
            // txtFiltraPedido
            // 
            this.txtFiltraPedido.Enabled = false;
            this.txtFiltraPedido.Location = new System.Drawing.Point(126, 60);
            this.txtFiltraPedido.Name = "txtFiltraPedido";
            this.txtFiltraPedido.Size = new System.Drawing.Size(190, 20);
            this.txtFiltraPedido.TabIndex = 592;
            this.txtFiltraPedido.Click += new System.EventHandler(this.txtFiltraPedido_Click);
            // 
            // chkFiltraPedido
            // 
            this.chkFiltraPedido.AutoSize = true;
            this.chkFiltraPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraPedido.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraPedido.Location = new System.Drawing.Point(39, 62);
            this.chkFiltraPedido.Name = "chkFiltraPedido";
            this.chkFiltraPedido.Size = new System.Drawing.Size(74, 17);
            this.chkFiltraPedido.TabIndex = 591;
            this.chkFiltraPedido.Text = "N° Pedido";
            this.chkFiltraPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraPedido.UseVisualStyleBackColor = false;
            this.chkFiltraPedido.CheckedChanged += new System.EventHandler(this.chkFiltraPedido_CheckedChanged);
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBuscarCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarCliente.Location = new System.Drawing.Point(126, 90);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(340, 22);
            this.txtBuscarCliente.TabIndex = 576;
            this.txtBuscarCliente.Visible = false;
            this.txtBuscarCliente.Click += new System.EventHandler(this.txtBuscarCliente_Click);
            this.txtBuscarCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarCliente_KeyPress);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox4.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(0, 0);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(515, 23);
            this.textBox4.TabIndex = 457;
            this.textBox4.Text = "General";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFiltraNumero
            // 
            this.txtFiltraNumero.Enabled = false;
            this.txtFiltraNumero.Location = new System.Drawing.Point(126, 34);
            this.txtFiltraNumero.Name = "txtFiltraNumero";
            this.txtFiltraNumero.Size = new System.Drawing.Size(190, 20);
            this.txtFiltraNumero.TabIndex = 590;
            this.txtFiltraNumero.Click += new System.EventHandler(this.txtFiltraNumero_Click);
            // 
            // txtBuscarCiudad
            // 
            this.txtBuscarCiudad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBuscarCiudad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCiudad.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarCiudad.Location = new System.Drawing.Point(126, 126);
            this.txtBuscarCiudad.Name = "txtBuscarCiudad";
            this.txtBuscarCiudad.Size = new System.Drawing.Size(340, 22);
            this.txtBuscarCiudad.TabIndex = 581;
            this.txtBuscarCiudad.Visible = false;
            this.txtBuscarCiudad.Click += new System.EventHandler(this.txtBuscarCiudad_Click);
            this.txtBuscarCiudad.TextChanged += new System.EventHandler(this.txtBuscarCiudad_TextChanged);
            this.txtBuscarCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarCiudad_KeyPress);
            // 
            // chkFiltraNumero
            // 
            this.chkFiltraNumero.AutoSize = true;
            this.chkFiltraNumero.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraNumero.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraNumero.Location = new System.Drawing.Point(45, 36);
            this.chkFiltraNumero.Name = "chkFiltraNumero";
            this.chkFiltraNumero.Size = new System.Drawing.Size(68, 17);
            this.chkFiltraNumero.TabIndex = 589;
            this.chkFiltraNumero.Text = "N° orden";
            this.chkFiltraNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraNumero.UseVisualStyleBackColor = false;
            this.chkFiltraNumero.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cmbCliente
            // 
            this.cmbCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(126, 91);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(340, 21);
            this.cmbCliente.TabIndex = 574;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            this.cmbCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCliente_KeyPress);
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
            this.btnBuscarCliente.Location = new System.Drawing.Point(484, 68);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCliente.TabIndex = 575;
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBuscarProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarProducto.Location = new System.Drawing.Point(126, 163);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(340, 20);
            this.txtBuscarProducto.TabIndex = 531;
            this.txtBuscarProducto.Visible = false;
            this.txtBuscarProducto.Click += new System.EventHandler(this.txtBuscarProducto_Click);
            this.txtBuscarProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarProducto_KeyPress);
            // 
            // chkMuestraInsProActInac
            // 
            this.chkMuestraInsProActInac.AutoSize = true;
            this.chkMuestraInsProActInac.Checked = true;
            this.chkMuestraInsProActInac.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMuestraInsProActInac.Enabled = false;
            this.chkMuestraInsProActInac.Location = new System.Drawing.Point(126, 190);
            this.chkMuestraInsProActInac.Name = "chkMuestraInsProActInac";
            this.chkMuestraInsProActInac.Size = new System.Drawing.Size(139, 17);
            this.chkMuestraInsProActInac.TabIndex = 532;
            this.chkMuestraInsProActInac.Text = "Muestra Ins/Pro activos";
            this.chkMuestraInsProActInac.UseVisualStyleBackColor = true;
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
            this.btnBuscarIProducto.Location = new System.Drawing.Point(484, 136);
            this.btnBuscarIProducto.Name = "btnBuscarIProducto";
            this.btnBuscarIProducto.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarIProducto.TabIndex = 529;
            this.btnBuscarIProducto.UseVisualStyleBackColor = false;
            this.btnBuscarIProducto.Click += new System.EventHandler(this.btnBuscarIProducto_Click);
            // 
            // cmbCiudad
            // 
            this.cmbCiudad.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudad.FormattingEnabled = true;
            this.cmbCiudad.Location = new System.Drawing.Point(126, 126);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(340, 21);
            this.cmbCiudad.TabIndex = 579;
            this.cmbCiudad.SelectedIndexChanged += new System.EventHandler(this.cmbCiudad_SelectedIndexChanged);
            this.cmbCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCiudad_KeyPress);
            // 
            // chkFiltraProducto
            // 
            this.chkFiltraProducto.AutoSize = true;
            this.chkFiltraProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraProducto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraProducto.Location = new System.Drawing.Point(45, 165);
            this.chkFiltraProducto.Name = "chkFiltraProducto";
            this.chkFiltraProducto.Size = new System.Drawing.Size(69, 17);
            this.chkFiltraProducto.TabIndex = 460;
            this.chkFiltraProducto.Text = "Producto";
            this.chkFiltraProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraProducto.UseVisualStyleBackColor = false;
            this.chkFiltraProducto.CheckedChanged += new System.EventHandler(this.chkFiltraProducto_CheckedChanged);
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
            this.btnBuscarCiudad.Location = new System.Drawing.Point(484, 101);
            this.btnBuscarCiudad.Name = "btnBuscarCiudad";
            this.btnBuscarCiudad.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCiudad.TabIndex = 580;
            this.btnBuscarCiudad.UseVisualStyleBackColor = false;
            this.btnBuscarCiudad.Click += new System.EventHandler(this.btnBuscarCiudad_Click);
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.Enabled = false;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbProducto.Location = new System.Drawing.Point(126, 163);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(340, 21);
            this.cmbProducto.TabIndex = 458;
            this.cmbProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbProducto_KeyPress);
            // 
            // chkFiltraCliente
            // 
            this.chkFiltraCliente.AutoSize = true;
            this.chkFiltraCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraCliente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraCliente.Location = new System.Drawing.Point(56, 95);
            this.chkFiltraCliente.Name = "chkFiltraCliente";
            this.chkFiltraCliente.Size = new System.Drawing.Size(58, 17);
            this.chkFiltraCliente.TabIndex = 582;
            this.chkFiltraCliente.Text = "Cliente";
            this.chkFiltraCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraCliente.UseVisualStyleBackColor = false;
            this.chkFiltraCliente.CheckedChanged += new System.EventHandler(this.chkFiltraCliente_CheckedChanged);
            // 
            // chkFiltraCiudad
            // 
            this.chkFiltraCiudad.AutoSize = true;
            this.chkFiltraCiudad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraCiudad.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraCiudad.Location = new System.Drawing.Point(55, 128);
            this.chkFiltraCiudad.Name = "chkFiltraCiudad";
            this.chkFiltraCiudad.Size = new System.Drawing.Size(59, 17);
            this.chkFiltraCiudad.TabIndex = 583;
            this.chkFiltraCiudad.Text = "Ciudad";
            this.chkFiltraCiudad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraCiudad.UseVisualStyleBackColor = false;
            this.chkFiltraCiudad.CheckedChanged += new System.EventHandler(this.chkFiltraCiudad_CheckedChanged);
            // 
            // chkFiltraEstado
            // 
            this.chkFiltraEstado.AutoSize = true;
            this.chkFiltraEstado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraEstado.Location = new System.Drawing.Point(55, 215);
            this.chkFiltraEstado.Name = "chkFiltraEstado";
            this.chkFiltraEstado.Size = new System.Drawing.Size(59, 17);
            this.chkFiltraEstado.TabIndex = 44;
            this.chkFiltraEstado.Text = "Estado";
            this.chkFiltraEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraEstado.UseVisualStyleBackColor = false;
            this.chkFiltraEstado.CheckedChanged += new System.EventHandler(this.chkFiltraEstado_CheckedChanged);
            // 
            // cmbFiltraEstado
            // 
            this.cmbFiltraEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraEstado.Enabled = false;
            this.cmbFiltraEstado.FormattingEnabled = true;
            this.cmbFiltraEstado.Items.AddRange(new object[] {
            "FI",
            "AN"});
            this.cmbFiltraEstado.Location = new System.Drawing.Point(126, 213);
            this.cmbFiltraEstado.Name = "cmbFiltraEstado";
            this.cmbFiltraEstado.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltraEstado.TabIndex = 45;
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
            this.lblfiltros.TabIndex = 456;
            this.lblfiltros.Text = "Filtros";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(5, 580);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(515, 30);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Transparent;
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Location = new System.Drawing.Point(70, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(26, 26);
            this.btnEditar.TabIndex = 500;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(103, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(26, 26);
            this.btnEliminar.TabIndex = 499;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnMostrarfiltros
            // 
            this.btnMostrarfiltros.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrarfiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMostrarfiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarfiltros.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMostrarfiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarfiltros.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarfiltros.ForeColor = System.Drawing.Color.Black;
            this.btnMostrarfiltros.Location = new System.Drawing.Point(637, 4);
            this.btnMostrarfiltros.Name = "btnMostrarfiltros";
            this.btnMostrarfiltros.Size = new System.Drawing.Size(521, 34);
            this.btnMostrarfiltros.TabIndex = 498;
            this.btnMostrarfiltros.Text = "Mostrar Filtros";
            this.btnMostrarfiltros.UseVisualStyleBackColor = false;
            this.btnMostrarfiltros.Click += new System.EventHandler(this.btnMostrarfiltros_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(7, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(26, 26);
            this.btnAgregar.TabIndex = 497;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvOrdenCarga
            // 
            this.dgvOrdenCarga.AllowUserToAddRows = false;
            this.dgvOrdenCarga.AllowUserToResizeRows = false;
            this.dgvOrdenCarga.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenCarga.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrdenCarga.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvOrdenCarga.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenCarga.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvOrdenCarga.ColumnHeadersHeight = 26;
            this.dgvOrdenCarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrdenCarga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colFecha,
            this.colCliente,
            this.colCiudad,
            this.colEstado,
            this.colObservacion,
            this.colModo});
            this.dgvOrdenCarga.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdenCarga.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvOrdenCarga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdenCarga.EnableHeadersVisualStyles = false;
            this.dgvOrdenCarga.GridColor = System.Drawing.Color.SpringGreen;
            this.dgvOrdenCarga.Location = new System.Drawing.Point(0, 0);
            this.dgvOrdenCarga.MultiSelect = false;
            this.dgvOrdenCarga.Name = "dgvOrdenCarga";
            this.dgvOrdenCarga.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenCarga.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvOrdenCarga.RowHeadersVisible = false;
            this.dgvOrdenCarga.RowHeadersWidth = 38;
            this.dgvOrdenCarga.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdenCarga.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvOrdenCarga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenCarga.Size = new System.Drawing.Size(637, 615);
            this.dgvOrdenCarga.TabIndex = 495;
            this.dgvOrdenCarga.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenCarga_CellDoubleClick);
            this.dgvOrdenCarga.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOrdenCarga_CellFormatting);
            // 
            // colID
            // 
            this.colID.HeaderText = "Carga nro";
            this.colID.Name = "colID";
            this.colID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colID.Width = 120;
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
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            // 
            // colObservacion
            // 
            this.colObservacion.HeaderText = "Observaciones";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.Width = 300;
            // 
            // colModo
            // 
            this.colModo.HeaderText = "Modo";
            this.colModo.Name = "colModo";
            this.colModo.Visible = false;
            // 
            // btnCopiar
            // 
            this.btnCopiar.BackColor = System.Drawing.Color.Transparent;
            this.btnCopiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopiar.BackgroundImage")));
            this.btnCopiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCopiar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCopiar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCopiar.FlatAppearance.BorderSize = 0;
            this.btnCopiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiar.Location = new System.Drawing.Point(39, 3);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(26, 26);
            this.btnCopiar.TabIndex = 502;
            this.btnCopiar.UseVisualStyleBackColor = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Teal;
            this.pictureBox3.Location = new System.Drawing.Point(135, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(2, 21);
            this.pictureBox3.TabIndex = 530;
            this.pictureBox3.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(189, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 26);
            this.button2.TabIndex = 534;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(146, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 532;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackColor = System.Drawing.Color.Teal;
            this.pictureBox18.Location = new System.Drawing.Point(181, 7);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(2, 21);
            this.pictureBox18.TabIndex = 531;
            this.pictureBox18.TabStop = false;
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
            this.btnBuscarDesc.Location = new System.Drawing.Point(146, 3);
            this.btnBuscarDesc.Name = "btnBuscarDesc";
            this.btnBuscarDesc.Size = new System.Drawing.Size(31, 26);
            this.btnBuscarDesc.TabIndex = 576;
            this.btnBuscarDesc.UseVisualStyleBackColor = false;
            this.btnBuscarDesc.Visible = false;
            this.btnBuscarDesc.Click += new System.EventHandler(this.btnBuscarDesc_Click);
            // 
            // cmbOrdenar
            // 
            this.cmbOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenar.FormattingEnabled = true;
            this.cmbOrdenar.Items.AddRange(new object[] {
            "",
            "Nro Orden",
            "Fecha",
            "Cliente",
            "Ciudad",
            "Estado"});
            this.cmbOrdenar.Location = new System.Drawing.Point(186, 6);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(229, 21);
            this.cmbOrdenar.TabIndex = 575;
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
            this.btnBuscarAsc.Location = new System.Drawing.Point(146, 3);
            this.btnBuscarAsc.Name = "btnBuscarAsc";
            this.btnBuscarAsc.Size = new System.Drawing.Size(34, 26);
            this.btnBuscarAsc.TabIndex = 574;
            this.btnBuscarAsc.UseVisualStyleBackColor = false;
            this.btnBuscarAsc.Click += new System.EventHandler(this.btnBuscarAsc_Click);
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSuperior.Controls.Add(this.btnExpedicion);
            this.pnlSuperior.Controls.Add(this.pictureBox1);
            this.pnlSuperior.Controls.Add(this.panel1);
            this.pnlSuperior.Controls.Add(this.btnAgregar);
            this.pnlSuperior.Controls.Add(this.btnEliminar);
            this.pnlSuperior.Controls.Add(this.btnEditar);
            this.pnlSuperior.Controls.Add(this.btnCopiar);
            this.pnlSuperior.Controls.Add(this.pictureBox3);
            this.pnlSuperior.Controls.Add(this.button2);
            this.pnlSuperior.Controls.Add(this.pictureBox18);
            this.pnlSuperior.Controls.Add(this.button1);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1162, 33);
            this.pnlSuperior.TabIndex = 577;
            // 
            // btnExpedicion
            // 
            this.btnExpedicion.BackColor = System.Drawing.Color.Transparent;
            this.btnExpedicion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExpedicion.BackgroundImage")));
            this.btnExpedicion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpedicion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpedicion.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExpedicion.FlatAppearance.BorderSize = 0;
            this.btnExpedicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnExpedicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpedicion.Location = new System.Drawing.Point(229, 3);
            this.btnExpedicion.Name = "btnExpedicion";
            this.btnExpedicion.Size = new System.Drawing.Size(29, 26);
            this.btnExpedicion.TabIndex = 579;
            this.btnExpedicion.UseVisualStyleBackColor = false;
            this.btnExpedicion.Click += new System.EventHandler(this.btnAsistente_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Teal;
            this.pictureBox1.Location = new System.Drawing.Point(221, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 21);
            this.pictureBox1.TabIndex = 578;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbOrdenar);
            this.panel1.Controls.Add(this.btnBuscarAsc);
            this.panel1.Controls.Add(this.btnBuscarDesc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(734, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 33);
            this.panel1.TabIndex = 577;
            // 
            // pnlCentral
            // 
            this.pnlCentral.BackColor = System.Drawing.Color.White;
            this.pnlCentral.Controls.Add(this.pnlLinea);
            this.pnlCentral.Controls.Add(this.dgvOrdenCarga);
            this.pnlCentral.Controls.Add(this.gbxFiltros);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(0, 33);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Size = new System.Drawing.Size(1162, 615);
            this.pnlCentral.TabIndex = 578;
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnlLinea.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLinea.Location = new System.Drawing.Point(0, 0);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(637, 2);
            this.pnlLinea.TabIndex = 671;
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInferior.Controls.Add(this.lblResultados);
            this.pnlInferior.Controls.Add(this.label1);
            this.pnlInferior.Controls.Add(this.btnMostrarfiltros);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 648);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(4);
            this.pnlInferior.Size = new System.Drawing.Size(1162, 42);
            this.pnlInferior.TabIndex = 579;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoEllipsis = true;
            this.lblResultados.BackColor = System.Drawing.Color.Transparent;
            this.lblResultados.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblResultados.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultados.ForeColor = System.Drawing.Color.Teal;
            this.lblResultados.Location = new System.Drawing.Point(146, 4);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(88, 34);
            this.lblResultados.TabIndex = 669;
            this.lblResultados.Text = "0";
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 34);
            this.label1.TabIndex = 668;
            this.label1.Text = "Cantidad";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMostrarOrdenesCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1162, 690);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMostrarOrdenesCarga";
            this.Text = "frmMostrarOrdenesCarga";
            this.Load += new System.EventHandler(this.frmMostrarOrdenesCarga_Load);
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.pnlFiltroFecha.ResumeLayout(false);
            this.pnlFiltroFecha.PerformLayout();
            this.pnlFiltroGeneral.ResumeLayout(false);
            this.pnlFiltroGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlCentral.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.CheckBox chkFechaHasta;
        private System.Windows.Forms.CheckBox chkFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.CheckBox chkFiltraCiudad;
        private System.Windows.Forms.CheckBox chkFiltraCliente;
        private System.Windows.Forms.TextBox txtBuscarCiudad;
        private System.Windows.Forms.Button btnBuscarCiudad;
        private System.Windows.Forms.ComboBox cmbCiudad;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.CheckBox chkMuestraInsProActInac;
        private System.Windows.Forms.Button btnBuscarIProducto;
        private System.Windows.Forms.CheckBox chkFiltraProducto;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label lblfiltros;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbFiltraEstado;
        private System.Windows.Forms.CheckBox chkFiltraEstado;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnMostrarfiltros;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvOrdenCarga;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.TextBox txtFiltraNumero;
        private System.Windows.Forms.CheckBox chkFiltraNumero;
        private System.Windows.Forms.Button btnBuscarDesc;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.Button btnBuscarAsc;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlFiltroGeneral;
        private System.Windows.Forms.Panel pnlFiltroFecha;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnExpedicion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModo;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.TextBox txtFiltraPedido;
        private System.Windows.Forms.CheckBox chkFiltraPedido;
    }
}