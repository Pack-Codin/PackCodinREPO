namespace PCodin_Sinlacc.Formularios
{
    partial class frmAfeccionCuerpo
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAfeccionCuerpo));
            this.dgvOrdenPedido = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadAfec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsAfectarProducto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAfec = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAfecParcial = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.txtCantidadResultados = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.txtFiltraNroPedido = new System.Windows.Forms.TextBox();
            this.chkFiltraNroPedido = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.chkFechaHasta = new System.Windows.Forms.CheckBox();
            this.chkFechaDesde = new System.Windows.Forms.CheckBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.chkMuestraInsProActInac = new System.Windows.Forms.CheckBox();
            this.btnBuscarIProducto = new System.Windows.Forms.Button();
            this.chkFiltraProducto = new System.Windows.Forms.CheckBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.lblfiltros = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrarfiltros = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenPedido)).BeginInit();
            this.cmsAfectarProducto.SuspendLayout();
            this.gbxFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrdenPedido
            // 
            this.dgvOrdenPedido.AllowUserToAddRows = false;
            this.dgvOrdenPedido.AllowUserToResizeRows = false;
            this.dgvOrdenPedido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrdenPedido.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenPedido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrdenPedido.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dgvOrdenPedido.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenPedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrdenPedido.ColumnHeadersHeight = 26;
            this.dgvOrdenPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrdenPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colProducto_ID,
            this.colProducto,
            this.colMedida,
            this.colCantidad,
            this.colCantidadAfec,
            this.colEstado,
            this.colObservacion});
            this.dgvOrdenPedido.ContextMenuStrip = this.cmsAfectarProducto;
            this.dgvOrdenPedido.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdenPedido.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOrdenPedido.EnableHeadersVisualStyles = false;
            this.dgvOrdenPedido.GridColor = System.Drawing.Color.White;
            this.dgvOrdenPedido.Location = new System.Drawing.Point(2, 229);
            this.dgvOrdenPedido.MultiSelect = false;
            this.dgvOrdenPedido.Name = "dgvOrdenPedido";
            this.dgvOrdenPedido.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenPedido.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOrdenPedido.RowHeadersVisible = false;
            this.dgvOrdenPedido.RowHeadersWidth = 38;
            this.dgvOrdenPedido.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdenPedido.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvOrdenPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenPedido.Size = new System.Drawing.Size(1157, 287);
            this.dgvOrdenPedido.TabIndex = 489;
            this.dgvOrdenPedido.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenPedido_CellContentClick);
            this.dgvOrdenPedido.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenPedido_CellEnter);
            this.dgvOrdenPedido.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOrdenPedido_CellFormatting);
            // 
            // colID
            // 
            this.colID.HeaderText = "Nro pedido";
            this.colID.Name = "colID";
            this.colID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colID.Width = 120;
            // 
            // colProducto_ID
            // 
            this.colProducto_ID.HeaderText = "Producto_ID";
            this.colProducto_ID.Name = "colProducto_ID";
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.Width = 150;
            // 
            // colMedida
            // 
            this.colMedida.HeaderText = "Medida";
            this.colMedida.Name = "colMedida";
            this.colMedida.Width = 350;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad pend";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 150;
            // 
            // colCantidadAfec
            // 
            this.colCantidadAfec.HeaderText = "Cantidad afectada";
            this.colCantidadAfec.Name = "colCantidadAfec";
            this.colCantidadAfec.Width = 150;
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
            this.colObservacion.Width = 300;
            // 
            // cmsAfectarProducto
            // 
            this.cmsAfectarProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAfec,
            this.btnAfecParcial});
            this.cmsAfectarProducto.Name = "cmsEditarEliminarFoto";
            this.cmsAfectarProducto.Size = new System.Drawing.Size(219, 48);
            // 
            // btnAfec
            // 
            this.btnAfec.Image = ((System.Drawing.Image)(resources.GetObject("btnAfec.Image")));
            this.btnAfec.Name = "btnAfec";
            this.btnAfec.Size = new System.Drawing.Size(218, 22);
            this.btnAfec.Text = "Aferctar cantidad completa";
            this.btnAfec.Click += new System.EventHandler(this.btnAfec_Click);
            // 
            // btnAfecParcial
            // 
            this.btnAfecParcial.Image = ((System.Drawing.Image)(resources.GetObject("btnAfecParcial.Image")));
            this.btnAfecParcial.Name = "btnAfecParcial";
            this.btnAfecParcial.Size = new System.Drawing.Size(218, 22);
            this.btnAfecParcial.Text = "Afectar cantidad parcial";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(2, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 27);
            this.button4.TabIndex = 526;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtCantidadResultados
            // 
            this.txtCantidadResultados.BackColor = System.Drawing.Color.Gray;
            this.txtCantidadResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidadResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadResultados.ForeColor = System.Drawing.Color.White;
            this.txtCantidadResultados.Location = new System.Drawing.Point(84, 665);
            this.txtCantidadResultados.Multiline = true;
            this.txtCantidadResultados.Name = "txtCantidadResultados";
            this.txtCantidadResultados.Size = new System.Drawing.Size(154, 25);
            this.txtCantidadResultados.TabIndex = 533;
            this.txtCantidadResultados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.DarkOrange;
            this.label20.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(-3, 665);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 25);
            this.label20.TabIndex = 532;
            this.label20.Text = "Cantidad";
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.BackColor = System.Drawing.Color.Silver;
            this.gbxFiltros.Controls.Add(this.txtFiltraNroPedido);
            this.gbxFiltros.Controls.Add(this.chkFiltraNroPedido);
            this.gbxFiltros.Controls.Add(this.textBox3);
            this.gbxFiltros.Controls.Add(this.chkFechaHasta);
            this.gbxFiltros.Controls.Add(this.chkFechaDesde);
            this.gbxFiltros.Controls.Add(this.dtpFechaHasta);
            this.gbxFiltros.Controls.Add(this.dtpFechaDesde);
            this.gbxFiltros.Controls.Add(this.txtBuscarProducto);
            this.gbxFiltros.Controls.Add(this.chkMuestraInsProActInac);
            this.gbxFiltros.Controls.Add(this.btnBuscarIProducto);
            this.gbxFiltros.Controls.Add(this.chkFiltraProducto);
            this.gbxFiltros.Controls.Add(this.cmbProducto);
            this.gbxFiltros.Controls.Add(this.lblfiltros);
            this.gbxFiltros.Controls.Add(this.textBox4);
            this.gbxFiltros.Controls.Add(this.btnBuscar);
            this.gbxFiltros.Location = new System.Drawing.Point(637, 416);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Size = new System.Drawing.Size(525, 243);
            this.gbxFiltros.TabIndex = 531;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Visible = false;
            this.gbxFiltros.Enter += new System.EventHandler(this.gbxFiltros_Enter);
            // 
            // txtFiltraNroPedido
            // 
            this.txtFiltraNroPedido.Enabled = false;
            this.txtFiltraNroPedido.Location = new System.Drawing.Point(112, 44);
            this.txtFiltraNroPedido.Name = "txtFiltraNroPedido";
            this.txtFiltraNroPedido.Size = new System.Drawing.Size(168, 20);
            this.txtFiltraNroPedido.TabIndex = 590;
            // 
            // chkFiltraNroPedido
            // 
            this.chkFiltraNroPedido.AutoSize = true;
            this.chkFiltraNroPedido.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraNroPedido.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraNroPedido.Location = new System.Drawing.Point(22, 46);
            this.chkFiltraNroPedido.Name = "chkFiltraNroPedido";
            this.chkFiltraNroPedido.Size = new System.Drawing.Size(78, 17);
            this.chkFiltraNroPedido.TabIndex = 589;
            this.chkFiltraNroPedido.Text = "Nro pedido";
            this.chkFiltraNroPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraNroPedido.UseVisualStyleBackColor = false;
            this.chkFiltraNroPedido.CheckedChanged += new System.EventHandler(this.chkFiltraNroPedido_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Black;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(0, 136);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(525, 23);
            this.textBox3.TabIndex = 588;
            this.textBox3.Text = "Fecha";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkFechaHasta
            // 
            this.chkFechaHasta.AutoSize = true;
            this.chkFechaHasta.Checked = true;
            this.chkFechaHasta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFechaHasta.Location = new System.Drawing.Point(276, 179);
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
            this.chkFechaDesde.Location = new System.Drawing.Point(55, 179);
            this.chkFechaDesde.Name = "chkFechaDesde";
            this.chkFechaDesde.Size = new System.Drawing.Size(57, 17);
            this.chkFechaDesde.TabIndex = 586;
            this.chkFechaDesde.Text = "Desde";
            this.chkFechaDesde.UseVisualStyleBackColor = true;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(333, 179);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaHasta.TabIndex = 585;
            this.dtpFechaHasta.Value = new System.DateTime(2021, 10, 20, 0, 0, 0, 0);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(112, 178);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaDesde.TabIndex = 584;
            this.dtpFechaDesde.Value = new System.DateTime(2021, 10, 20, 10, 52, 34, 0);
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBuscarProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarProducto.Location = new System.Drawing.Point(112, 82);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(340, 20);
            this.txtBuscarProducto.TabIndex = 531;
            this.txtBuscarProducto.Visible = false;
            this.txtBuscarProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarProducto_KeyPress);
            // 
            // chkMuestraInsProActInac
            // 
            this.chkMuestraInsProActInac.AutoSize = true;
            this.chkMuestraInsProActInac.Checked = true;
            this.chkMuestraInsProActInac.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMuestraInsProActInac.Enabled = false;
            this.chkMuestraInsProActInac.Location = new System.Drawing.Point(112, 108);
            this.chkMuestraInsProActInac.Name = "chkMuestraInsProActInac";
            this.chkMuestraInsProActInac.Size = new System.Drawing.Size(139, 17);
            this.chkMuestraInsProActInac.TabIndex = 532;
            this.chkMuestraInsProActInac.Text = "Muestra Ins/Pro activos";
            this.chkMuestraInsProActInac.UseVisualStyleBackColor = true;
            // 
            // btnBuscarIProducto
            // 
            this.btnBuscarIProducto.BackColor = System.Drawing.Color.Silver;
            this.btnBuscarIProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarIProducto.BackgroundImage")));
            this.btnBuscarIProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarIProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarIProducto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarIProducto.FlatAppearance.BorderSize = 0;
            this.btnBuscarIProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarIProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarIProducto.Location = new System.Drawing.Point(470, 78);
            this.btnBuscarIProducto.Name = "btnBuscarIProducto";
            this.btnBuscarIProducto.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarIProducto.TabIndex = 529;
            this.btnBuscarIProducto.UseVisualStyleBackColor = false;
            this.btnBuscarIProducto.Click += new System.EventHandler(this.btnBuscarIProducto_Click);
            // 
            // chkFiltraProducto
            // 
            this.chkFiltraProducto.AutoSize = true;
            this.chkFiltraProducto.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraProducto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraProducto.Location = new System.Drawing.Point(31, 83);
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
            this.cmbProducto.Location = new System.Drawing.Point(112, 81);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(340, 21);
            this.cmbProducto.TabIndex = 458;
            this.cmbProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbProducto_KeyPress);
            // 
            // lblfiltros
            // 
            this.lblfiltros.AutoSize = true;
            this.lblfiltros.BackColor = System.Drawing.Color.DarkOrange;
            this.lblfiltros.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfiltros.Location = new System.Drawing.Point(-3, 0);
            this.lblfiltros.Name = "lblfiltros";
            this.lblfiltros.Size = new System.Drawing.Size(79, 32);
            this.lblfiltros.TabIndex = 456;
            this.lblfiltros.Text = "Filtros";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Black;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(-4, 0);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(529, 23);
            this.textBox4.TabIndex = 457;
            this.textBox4.Text = "General";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(0, 214);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(525, 30);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnMostrarfiltros
            // 
            this.btnMostrarfiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMostrarfiltros.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMostrarfiltros.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMostrarfiltros.BackgroundImage")));
            this.btnMostrarfiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMostrarfiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarfiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarfiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarfiltros.ForeColor = System.Drawing.Color.Black;
            this.btnMostrarfiltros.Location = new System.Drawing.Point(637, 659);
            this.btnMostrarfiltros.Name = "btnMostrarfiltros";
            this.btnMostrarfiltros.Size = new System.Drawing.Size(525, 31);
            this.btnMostrarfiltros.TabIndex = 530;
            this.btnMostrarfiltros.Text = "Mostrar Filtros";
            this.btnMostrarfiltros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarfiltros.UseVisualStyleBackColor = false;
            this.btnMostrarfiltros.Click += new System.EventHandler(this.btnMostrarfiltros_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(106, 553);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(120, 20);
            this.txtCantidad.TabIndex = 537;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 550);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 25);
            this.label8.TabIndex = 536;
            this.label8.Text = "Cantidad";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(17, 527);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 20);
            this.textBox1.TabIndex = 538;
            this.textBox1.Text = "Cantidad afectada";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Enabled = false;
           this.btnEditar.Location = new System.Drawing.Point(232, 527);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(48, 46);
            this.btnEditar.TabIndex = 539;
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.Orange;
            this.btnCargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargar.Location = new System.Drawing.Point(2, 595);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(318, 48);
            this.btnCargar.TabIndex = 540;
            this.btnCargar.Text = "Confirmar orden de carga";
            this.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 541;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // frmAfeccionCuerpo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1162, 690);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCantidadResultados);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.gbxFiltros);
            this.Controls.Add(this.btnMostrarfiltros);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dgvOrdenPedido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAfeccionCuerpo";
            this.Text = "frmAfeccionCuerpo";
            this.Load += new System.EventHandler(this.frmAfeccionCuerpo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenPedido)).EndInit();
            this.cmsAfectarProducto.ResumeLayout(false);
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdenPedido;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtCantidadResultados;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.TextBox txtFiltraNroPedido;
        private System.Windows.Forms.CheckBox chkFiltraNroPedido;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox chkFechaHasta;
        private System.Windows.Forms.CheckBox chkFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.CheckBox chkMuestraInsProActInac;
        private System.Windows.Forms.Button btnBuscarIProducto;
        private System.Windows.Forms.CheckBox chkFiltraProducto;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label lblfiltros;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrarfiltros;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.ContextMenuStrip cmsAfectarProducto;
        private System.Windows.Forms.ToolStripMenuItem btnAfec;
        private System.Windows.Forms.ToolStripMenuItem btnAfecParcial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadAfec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
        private System.Windows.Forms.Button button1;
    }
}