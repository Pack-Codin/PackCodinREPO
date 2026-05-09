namespace PCodin_Sinlacc.Formularios
{
    partial class frmSeleccionarProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionarProducto));
            this.dgvPedidoProductos = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDModificar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductoDescrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFicha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsAfectarProducto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAfecComp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDesafectar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAfectados = new System.Windows.Forms.Button();
            this.btnAfectar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMostrarfiltros = new System.Windows.Forms.Button();
            this.bunifuFlatButton1 = new System.Windows.Forms.Button();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlFiltroFecha = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.chkFechaHasta = new System.Windows.Forms.CheckBox();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.chkFechaDesde = new System.Windows.Forms.CheckBox();
            this.pnlFiltroGeneral = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cmbFiltraFicha = new System.Windows.Forms.ComboBox();
            this.chkFiltraFicha = new System.Windows.Forms.CheckBox();
            this.chkFiltraProduccion = new System.Windows.Forms.CheckBox();
            this.cmbFiltraRetencion = new System.Windows.Forms.ComboBox();
            this.txtFiltraProduccion = new System.Windows.Forms.TextBox();
            this.chkFiltraRetencion = new System.Windows.Forms.CheckBox();
            this.chkFiltraMovimiento = new System.Windows.Forms.CheckBox();
            this.cmbFiltraMovimiento = new System.Windows.Forms.ComboBox();
            this.lblfiltros = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.picFiltroActivo = new System.Windows.Forms.PictureBox();
            this.picFiltroInactivo = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pblSuperior1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNumPedido = new System.Windows.Forms.Label();
            this.lblNumOrdenCarga = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCantAfectada = new System.Windows.Forms.Label();
            this.lblCantAfectar = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoProductos)).BeginInit();
            this.cmsAfectarProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbxFiltros.SuspendLayout();
            this.pnlFiltroFecha.SuspendLayout();
            this.pnlFiltroGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFiltroActivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFiltroInactivo)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.pblSuperior1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPedidoProductos
            // 
            this.dgvPedidoProductos.AllowUserToAddRows = false;
            this.dgvPedidoProductos.AllowUserToResizeRows = false;
            this.dgvPedidoProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidoProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPedidoProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPedidoProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidoProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPedidoProductos.ColumnHeadersHeight = 20;
            this.dgvPedidoProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPedidoProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colIDModificar,
            this.colDeposito,
            this.colFecha,
            this.colMovimiento,
            this.colProductoDescrip,
            this.colCantidad,
            this.colMedida,
            this.colLote,
            this.colRetencion,
            this.colFicha,
            this.colEmpleado,
            this.colObservaciones});
            this.dgvPedidoProductos.ContextMenuStrip = this.cmsAfectarProducto;
            this.dgvPedidoProductos.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidoProductos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPedidoProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidoProductos.EnableHeadersVisualStyles = false;
            this.dgvPedidoProductos.GridColor = System.Drawing.Color.Teal;
            this.dgvPedidoProductos.Location = new System.Drawing.Point(5, 5);
            this.dgvPedidoProductos.MultiSelect = false;
            this.dgvPedidoProductos.Name = "dgvPedidoProductos";
            this.dgvPedidoProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidoProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPedidoProductos.RowHeadersVisible = false;
            this.dgvPedidoProductos.RowHeadersWidth = 38;
            this.dgvPedidoProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPedidoProductos.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPedidoProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidoProductos.Size = new System.Drawing.Size(825, 524);
            this.dgvPedidoProductos.TabIndex = 604;
            this.dgvPedidoProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidoProductos_CellClick);
            this.dgvPedidoProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPedidoProductos_CellFormatting);
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colIDModificar
            // 
            this.colIDModificar.HeaderText = "Produccion";
            this.colIDModificar.Name = "colIDModificar";
            // 
            // colDeposito
            // 
            this.colDeposito.HeaderText = "Deposito";
            this.colDeposito.Name = "colDeposito";
            this.colDeposito.Width = 70;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            // 
            // colMovimiento
            // 
            this.colMovimiento.HeaderText = "Movimiento";
            this.colMovimiento.Name = "colMovimiento";
            this.colMovimiento.Width = 230;
            // 
            // colProductoDescrip
            // 
            this.colProductoDescrip.FillWeight = 49.555F;
            this.colProductoDescrip.HeaderText = "Producto";
            this.colProductoDescrip.Name = "colProductoDescrip";
            this.colProductoDescrip.ReadOnly = true;
            this.colProductoDescrip.Width = 400;
            // 
            // colCantidad
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            this.colCantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCantidad.FillWeight = 16.51833F;
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 150;
            // 
            // colMedida
            // 
            this.colMedida.FillWeight = 140F;
            this.colMedida.HeaderText = "Medida";
            this.colMedida.Name = "colMedida";
            this.colMedida.ReadOnly = true;
            this.colMedida.Width = 130;
            // 
            // colLote
            // 
            this.colLote.HeaderText = "Lote";
            this.colLote.Name = "colLote";
            // 
            // colRetencion
            // 
            this.colRetencion.HeaderText = "Retención";
            this.colRetencion.Name = "colRetencion";
            // 
            // colFicha
            // 
            this.colFicha.HeaderText = "Ficha";
            this.colFicha.Name = "colFicha";
            // 
            // colEmpleado
            // 
            this.colEmpleado.HeaderText = "Empleado";
            this.colEmpleado.Name = "colEmpleado";
            this.colEmpleado.Width = 250;
            // 
            // colObservaciones
            // 
            this.colObservaciones.HeaderText = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.Width = 250;
            // 
            // cmsAfectarProducto
            // 
            this.cmsAfectarProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAfecComp,
            this.btnDesafectar});
            this.cmsAfectarProducto.Name = "cmsEditarEliminarFoto";
            this.cmsAfectarProducto.Size = new System.Drawing.Size(219, 48);
            // 
            // btnAfecComp
            // 
            this.btnAfecComp.Image = ((System.Drawing.Image)(resources.GetObject("btnAfecComp.Image")));
            this.btnAfecComp.Name = "btnAfecComp";
            this.btnAfecComp.Size = new System.Drawing.Size(218, 22);
            this.btnAfecComp.Text = "Aferctar cantidad completa";
            this.btnAfecComp.Click += new System.EventHandler(this.btnAfecComp_Click);
            // 
            // btnDesafectar
            // 
            this.btnDesafectar.Image = ((System.Drawing.Image)(resources.GetObject("btnDesafectar.Image")));
            this.btnDesafectar.Name = "btnDesafectar";
            this.btnDesafectar.Size = new System.Drawing.Size(218, 22);
            this.btnDesafectar.Text = "Desafectar ";
            this.btnDesafectar.Click += new System.EventHandler(this.btnDesafectar_Click);
            // 
            // btnAfectados
            // 
            this.btnAfectados.BackColor = System.Drawing.Color.White;
            this.btnAfectados.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAfectados.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAfectados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAfectados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnAfectados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfectados.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfectados.Image = ((System.Drawing.Image)(resources.GetObject("btnAfectados.Image")));
            this.btnAfectados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAfectados.Location = new System.Drawing.Point(132, 4);
            this.btnAfectados.Name = "btnAfectados";
            this.btnAfectados.Size = new System.Drawing.Size(147, 28);
            this.btnAfectados.TabIndex = 635;
            this.btnAfectados.Text = "       Productos afectados";
            this.btnAfectados.UseVisualStyleBackColor = false;
            this.btnAfectados.Click += new System.EventHandler(this.btnAfectados_Click);
            // 
            // btnAfectar
            // 
            this.btnAfectar.BackColor = System.Drawing.Color.White;
            this.btnAfectar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAfectar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAfectar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAfectar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnAfectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfectar.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfectar.Image = ((System.Drawing.Image)(resources.GetObject("btnAfectar.Image")));
            this.btnAfectar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAfectar.Location = new System.Drawing.Point(4, 4);
            this.btnAfectar.Name = "btnAfectar";
            this.btnAfectar.Size = new System.Drawing.Size(128, 28);
            this.btnAfectar.TabIndex = 634;
            this.btnAfectar.Text = "        Afectar producto";
            this.btnAfectar.UseVisualStyleBackColor = false;
            this.btnAfectar.Click += new System.EventHandler(this.btnAfectar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Orange;
            this.pictureBox1.Location = new System.Drawing.Point(7, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 3);
            this.pictureBox1.TabIndex = 640;
            this.pictureBox1.TabStop = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Transparent;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(230, 62);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(102, 46);
            this.btnEditar.TabIndex = 639;
            this.btnEditar.Text = "        Afectar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(15, 46);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 20);
            this.textBox1.TabIndex = 638;
            this.textBox1.Text = "Cantidad afectada";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.Black;
            this.txtCantidad.Location = new System.Drawing.Point(104, 72);
            this.txtCantidad.Multiline = true;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(120, 30);
            this.txtCantidad.TabIndex = 637;
            this.txtCantidad.Click += new System.EventHandler(this.txtCantidad_Click);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 23);
            this.label8.TabIndex = 636;
            this.label8.Text = "Cantidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 641;
            this.label1.Text = "Cantidad a afectar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 19);
            this.label2.TabIndex = 643;
            this.label2.Text = "Cantidad afectada";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Teal;
            this.pictureBox2.Location = new System.Drawing.Point(173, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(3, 68);
            this.pictureBox2.TabIndex = 645;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 23);
            this.label3.TabIndex = 649;
            this.label3.Text = "N° Pedido :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 651;
            this.label4.Text = "Producto :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(5, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 23);
            this.label5.TabIndex = 655;
            this.label5.Text = "N° Orden :";
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
            this.btnMostrarfiltros.Location = new System.Drawing.Point(832, 3);
            this.btnMostrarfiltros.Name = "btnMostrarfiltros";
            this.btnMostrarfiltros.Size = new System.Drawing.Size(525, 32);
            this.btnMostrarfiltros.TabIndex = 659;
            this.btnMostrarfiltros.Text = "Mostrar Filtros";
            this.btnMostrarfiltros.UseVisualStyleBackColor = false;
            this.btnMostrarfiltros.Click += new System.EventHandler(this.btnMostrarfiltros_Click);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuFlatButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuFlatButton1.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.bunifuFlatButton1.FlatAppearance.BorderSize = 2;
            this.bunifuFlatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuFlatButton1.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Location = new System.Drawing.Point(3, 3);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Size = new System.Drawing.Size(243, 32);
            this.bunifuFlatButton1.TabIndex = 660;
            this.bunifuFlatButton1.Text = "Confirmar";
            this.bunifuFlatButton1.UseVisualStyleBackColor = false;
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbxFiltros.Controls.Add(this.btnBuscar);
            this.gbxFiltros.Controls.Add(this.pnlFiltroFecha);
            this.gbxFiltros.Controls.Add(this.pnlFiltroGeneral);
            this.gbxFiltros.Controls.Add(this.lblfiltros);
            this.gbxFiltros.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbxFiltros.Location = new System.Drawing.Point(830, 5);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Size = new System.Drawing.Size(525, 524);
            this.gbxFiltros.TabIndex = 661;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Visible = false;
            this.gbxFiltros.Enter += new System.EventHandler(this.gbxFiltros_Enter);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(3, 491);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(519, 30);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlFiltroFecha
            // 
            this.pnlFiltroFecha.Controls.Add(this.textBox3);
            this.pnlFiltroFecha.Controls.Add(this.dtpFechaHasta);
            this.pnlFiltroFecha.Controls.Add(this.chkFechaHasta);
            this.pnlFiltroFecha.Controls.Add(this.dtpFechaDesde);
            this.pnlFiltroFecha.Controls.Add(this.chkFechaDesde);
            this.pnlFiltroFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltroFecha.Location = new System.Drawing.Point(3, 203);
            this.pnlFiltroFecha.Name = "pnlFiltroFecha";
            this.pnlFiltroFecha.Size = new System.Drawing.Size(519, 136);
            this.pnlFiltroFecha.TabIndex = 601;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Black;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox3.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(519, 23);
            this.textBox3.TabIndex = 593;
            this.textBox3.Text = "Fecha";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(345, 61);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaHasta.TabIndex = 590;
            this.dtpFechaHasta.Value = new System.DateTime(2021, 4, 30, 2, 21, 26, 0);
            // 
            // chkFechaHasta
            // 
            this.chkFechaHasta.AutoSize = true;
            this.chkFechaHasta.Location = new System.Drawing.Point(288, 61);
            this.chkFechaHasta.Name = "chkFechaHasta";
            this.chkFechaHasta.Size = new System.Drawing.Size(54, 17);
            this.chkFechaHasta.TabIndex = 592;
            this.chkFechaHasta.Text = "Hasta";
            this.chkFechaHasta.UseVisualStyleBackColor = true;
            this.chkFechaHasta.CheckedChanged += new System.EventHandler(this.chkFechaHasta_CheckedChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(124, 60);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaDesde.TabIndex = 589;
            // 
            // chkFechaDesde
            // 
            this.chkFechaDesde.AutoSize = true;
            this.chkFechaDesde.Location = new System.Drawing.Point(67, 61);
            this.chkFechaDesde.Name = "chkFechaDesde";
            this.chkFechaDesde.Size = new System.Drawing.Size(57, 17);
            this.chkFechaDesde.TabIndex = 591;
            this.chkFechaDesde.Text = "Desde";
            this.chkFechaDesde.UseVisualStyleBackColor = true;
            this.chkFechaDesde.CheckedChanged += new System.EventHandler(this.chkFechaDesde_CheckedChanged);
            // 
            // pnlFiltroGeneral
            // 
            this.pnlFiltroGeneral.Controls.Add(this.textBox4);
            this.pnlFiltroGeneral.Controls.Add(this.cmbFiltraFicha);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraFicha);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraProduccion);
            this.pnlFiltroGeneral.Controls.Add(this.cmbFiltraRetencion);
            this.pnlFiltroGeneral.Controls.Add(this.txtFiltraProduccion);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraRetencion);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraMovimiento);
            this.pnlFiltroGeneral.Controls.Add(this.cmbFiltraMovimiento);
            this.pnlFiltroGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltroGeneral.Location = new System.Drawing.Point(3, 45);
            this.pnlFiltroGeneral.Name = "pnlFiltroGeneral";
            this.pnlFiltroGeneral.Size = new System.Drawing.Size(519, 158);
            this.pnlFiltroGeneral.TabIndex = 600;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Black;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox4.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(0, 0);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(519, 23);
            this.textBox4.TabIndex = 457;
            this.textBox4.Text = "General";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbFiltraFicha
            // 
            this.cmbFiltraFicha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraFicha.Enabled = false;
            this.cmbFiltraFicha.FormattingEnabled = true;
            this.cmbFiltraFicha.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbFiltraFicha.Location = new System.Drawing.Point(106, 114);
            this.cmbFiltraFicha.Name = "cmbFiltraFicha";
            this.cmbFiltraFicha.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltraFicha.TabIndex = 599;
            // 
            // chkFiltraFicha
            // 
            this.chkFiltraFicha.AutoSize = true;
            this.chkFiltraFicha.BackColor = System.Drawing.Color.Transparent;
            this.chkFiltraFicha.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraFicha.Location = new System.Drawing.Point(45, 116);
            this.chkFiltraFicha.Name = "chkFiltraFicha";
            this.chkFiltraFicha.Size = new System.Drawing.Size(52, 17);
            this.chkFiltraFicha.TabIndex = 598;
            this.chkFiltraFicha.Text = "Ficha";
            this.chkFiltraFicha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraFicha.UseVisualStyleBackColor = false;
            this.chkFiltraFicha.CheckedChanged += new System.EventHandler(this.chkFiltraFicha_CheckedChanged);
            // 
            // chkFiltraProduccion
            // 
            this.chkFiltraProduccion.AutoSize = true;
            this.chkFiltraProduccion.BackColor = System.Drawing.Color.Transparent;
            this.chkFiltraProduccion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraProduccion.Location = new System.Drawing.Point(17, 39);
            this.chkFiltraProduccion.Name = "chkFiltraProduccion";
            this.chkFiltraProduccion.Size = new System.Drawing.Size(80, 17);
            this.chkFiltraProduccion.TabIndex = 533;
            this.chkFiltraProduccion.Text = "Producción";
            this.chkFiltraProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraProduccion.UseVisualStyleBackColor = false;
            this.chkFiltraProduccion.CheckedChanged += new System.EventHandler(this.chkFiltraProduccion_CheckedChanged);
            // 
            // cmbFiltraRetencion
            // 
            this.cmbFiltraRetencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraRetencion.Enabled = false;
            this.cmbFiltraRetencion.FormattingEnabled = true;
            this.cmbFiltraRetencion.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbFiltraRetencion.Location = new System.Drawing.Point(106, 87);
            this.cmbFiltraRetencion.Name = "cmbFiltraRetencion";
            this.cmbFiltraRetencion.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltraRetencion.TabIndex = 597;
            // 
            // txtFiltraProduccion
            // 
            this.txtFiltraProduccion.Location = new System.Drawing.Point(106, 37);
            this.txtFiltraProduccion.Name = "txtFiltraProduccion";
            this.txtFiltraProduccion.Size = new System.Drawing.Size(139, 20);
            this.txtFiltraProduccion.TabIndex = 534;
            // 
            // chkFiltraRetencion
            // 
            this.chkFiltraRetencion.AutoSize = true;
            this.chkFiltraRetencion.BackColor = System.Drawing.Color.Transparent;
            this.chkFiltraRetencion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraRetencion.Location = new System.Drawing.Point(22, 89);
            this.chkFiltraRetencion.Name = "chkFiltraRetencion";
            this.chkFiltraRetencion.Size = new System.Drawing.Size(75, 17);
            this.chkFiltraRetencion.TabIndex = 596;
            this.chkFiltraRetencion.Text = "Retención";
            this.chkFiltraRetencion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraRetencion.UseVisualStyleBackColor = false;
            this.chkFiltraRetencion.CheckedChanged += new System.EventHandler(this.chkFiltraRetencion_CheckedChanged);
            // 
            // chkFiltraMovimiento
            // 
            this.chkFiltraMovimiento.AutoSize = true;
            this.chkFiltraMovimiento.BackColor = System.Drawing.Color.Transparent;
            this.chkFiltraMovimiento.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraMovimiento.Location = new System.Drawing.Point(17, 62);
            this.chkFiltraMovimiento.Name = "chkFiltraMovimiento";
            this.chkFiltraMovimiento.Size = new System.Drawing.Size(80, 17);
            this.chkFiltraMovimiento.TabIndex = 594;
            this.chkFiltraMovimiento.Text = "Movimiento";
            this.chkFiltraMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraMovimiento.UseVisualStyleBackColor = false;
            this.chkFiltraMovimiento.CheckedChanged += new System.EventHandler(this.chkFiltraMovimiento_CheckedChanged);
            // 
            // cmbFiltraMovimiento
            // 
            this.cmbFiltraMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraMovimiento.FormattingEnabled = true;
            this.cmbFiltraMovimiento.Location = new System.Drawing.Point(106, 60);
            this.cmbFiltraMovimiento.Name = "cmbFiltraMovimiento";
            this.cmbFiltraMovimiento.Size = new System.Drawing.Size(332, 21);
            this.cmbFiltraMovimiento.TabIndex = 595;
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
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBox2.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(460, 5);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(69, 22);
            this.textBox2.TabIndex = 663;
            this.textBox2.Text = "Filtros";
            // 
            // picFiltroActivo
            // 
            this.picFiltroActivo.Dock = System.Windows.Forms.DockStyle.Right;
            this.picFiltroActivo.Image = ((System.Drawing.Image)(resources.GetObject("picFiltroActivo.Image")));
            this.picFiltroActivo.Location = new System.Drawing.Point(529, 5);
            this.picFiltroActivo.Name = "picFiltroActivo";
            this.picFiltroActivo.Size = new System.Drawing.Size(26, 22);
            this.picFiltroActivo.TabIndex = 664;
            this.picFiltroActivo.TabStop = false;
            this.picFiltroActivo.Visible = false;
            // 
            // picFiltroInactivo
            // 
            this.picFiltroInactivo.Dock = System.Windows.Forms.DockStyle.Right;
            this.picFiltroInactivo.Image = ((System.Drawing.Image)(resources.GetObject("picFiltroInactivo.Image")));
            this.picFiltroInactivo.Location = new System.Drawing.Point(555, 5);
            this.picFiltroInactivo.Name = "picFiltroInactivo";
            this.picFiltroInactivo.Size = new System.Drawing.Size(26, 22);
            this.picFiltroInactivo.TabIndex = 665;
            this.picFiltroInactivo.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoEllipsis = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Dock = System.Windows.Forms.DockStyle.Left;
            this.label20.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(5, 5);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 22);
            this.label20.TabIndex = 666;
            this.label20.Text = "Cantidad";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.White;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(282, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(272, 28);
            this.btnExcel.TabIndex = 669;
            this.btnExcel.Text = "      Exportar a excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.panel5);
            this.pnlSuperior.Controls.Add(this.pblSuperior1);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1360, 154);
            this.pnlSuperior.TabIndex = 670;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.btnExcel);
            this.panel5.Controls.Add(this.pictureBox5);
            this.panel5.Controls.Add(this.btnAfectados);
            this.panel5.Controls.Add(this.btnAfectar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 116);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(4);
            this.panel5.Size = new System.Drawing.Size(1360, 36);
            this.panel5.TabIndex = 671;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Teal;
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox5.Location = new System.Drawing.Point(279, 4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(3, 28);
            this.pictureBox5.TabIndex = 670;
            this.pictureBox5.TabStop = false;
            // 
            // pblSuperior1
            // 
            this.pblSuperior1.Controls.Add(this.panel4);
            this.pblSuperior1.Controls.Add(this.panel2);
            this.pblSuperior1.Controls.Add(this.panel1);
            this.pblSuperior1.Controls.Add(this.panel3);
            this.pblSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pblSuperior1.Location = new System.Drawing.Point(0, 0);
            this.pblSuperior1.Name = "pblSuperior1";
            this.pblSuperior1.Size = new System.Drawing.Size(1360, 116);
            this.pblSuperior1.TabIndex = 670;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(532, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(467, 116);
            this.panel4.TabIndex = 652;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(375, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 41);
            this.label6.TabIndex = 660;
            this.label6.Text = "Pendiente";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.textBox1);
            this.panel6.Controls.Add(this.txtCantidad);
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.btnEditar);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(375, 116);
            this.panel6.TabIndex = 649;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblNumPedido);
            this.panel2.Controls.Add(this.lblNumOrdenCarga);
            this.panel2.Controls.Add(this.lblProducto);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(106, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(426, 116);
            this.panel2.TabIndex = 1;
            // 
            // lblNumPedido
            // 
            this.lblNumPedido.AutoSize = true;
            this.lblNumPedido.BackColor = System.Drawing.Color.White;
            this.lblNumPedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNumPedido.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPedido.ForeColor = System.Drawing.Color.Black;
            this.lblNumPedido.Location = new System.Drawing.Point(5, 51);
            this.lblNumPedido.Name = "lblNumPedido";
            this.lblNumPedido.Size = new System.Drawing.Size(39, 23);
            this.lblNumPedido.TabIndex = 660;
            this.lblNumPedido.Text = "P01";
            // 
            // lblNumOrdenCarga
            // 
            this.lblNumOrdenCarga.AutoSize = true;
            this.lblNumOrdenCarga.BackColor = System.Drawing.Color.White;
            this.lblNumOrdenCarga.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNumOrdenCarga.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOrdenCarga.ForeColor = System.Drawing.Color.Black;
            this.lblNumOrdenCarga.Location = new System.Drawing.Point(5, 28);
            this.lblNumOrdenCarga.Name = "lblNumOrdenCarga";
            this.lblNumOrdenCarga.Size = new System.Drawing.Size(41, 23);
            this.lblNumOrdenCarga.TabIndex = 659;
            this.lblNumOrdenCarga.Text = "OC5";
            // 
            // lblProducto
            // 
            this.lblProducto.BackColor = System.Drawing.Color.White;
            this.lblProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProducto.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProducto.Location = new System.Drawing.Point(5, 5);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(416, 23);
            this.lblProducto.TabIndex = 658;
            this.lblProducto.Text = "Cantidad";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Teal;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(5, 109);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(416, 2);
            this.panel7.TabIndex = 657;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(106, 116);
            this.panel1.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Teal;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(5, 109);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(96, 2);
            this.panel9.TabIndex = 658;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblCantAfectada);
            this.panel3.Controls.Add(this.lblCantAfectar);
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(999, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4);
            this.panel3.Size = new System.Drawing.Size(361, 116);
            this.panel3.TabIndex = 651;
            // 
            // lblCantAfectada
            // 
            this.lblCantAfectada.BackColor = System.Drawing.Color.White;
            this.lblCantAfectada.Font = new System.Drawing.Font("Roboto Condensed", 20.25F);
            this.lblCantAfectada.ForeColor = System.Drawing.Color.Green;
            this.lblCantAfectada.Location = new System.Drawing.Point(179, 36);
            this.lblCantAfectada.Name = "lblCantAfectada";
            this.lblCantAfectada.Size = new System.Drawing.Size(178, 28);
            this.lblCantAfectada.TabIndex = 661;
            this.lblCantAfectada.Text = "0,00";
            this.lblCantAfectada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCantAfectar
            // 
            this.lblCantAfectar.BackColor = System.Drawing.Color.White;
            this.lblCantAfectar.Font = new System.Drawing.Font("Roboto Condensed", 20.25F);
            this.lblCantAfectar.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblCantAfectar.Location = new System.Drawing.Point(0, 36);
            this.lblCantAfectar.Name = "lblCantAfectar";
            this.lblCantAfectar.Size = new System.Drawing.Size(173, 28);
            this.lblCantAfectar.TabIndex = 660;
            this.lblCantAfectar.Text = "0,00";
            this.lblCantAfectar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.lblDiferencia);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(4, 75);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(3);
            this.panel10.Size = new System.Drawing.Size(353, 37);
            this.panel10.TabIndex = 646;
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.BackColor = System.Drawing.Color.White;
            this.lblDiferencia.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDiferencia.Font = new System.Drawing.Font("Roboto Condensed", 20.25F);
            this.lblDiferencia.Location = new System.Drawing.Point(3, 5);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(347, 28);
            this.lblDiferencia.TabIndex = 659;
            this.lblDiferencia.Text = "0,00";
            this.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.DarkOrange;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(347, 2);
            this.panel11.TabIndex = 658;
            // 
            // pnlCentral
            // 
            this.pnlCentral.BackColor = System.Drawing.Color.White;
            this.pnlCentral.Controls.Add(this.panel12);
            this.pnlCentral.Controls.Add(this.dgvPedidoProductos);
            this.pnlCentral.Controls.Add(this.gbxFiltros);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(0, 154);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Padding = new System.Windows.Forms.Padding(5);
            this.pnlCentral.Size = new System.Drawing.Size(1360, 534);
            this.pnlCentral.TabIndex = 671;
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.panel8);
            this.pnlInferior.Controls.Add(this.bunifuFlatButton1);
            this.pnlInferior.Controls.Add(this.btnMostrarfiltros);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 688);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(3);
            this.pnlInferior.Size = new System.Drawing.Size(1360, 38);
            this.pnlInferior.TabIndex = 672;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblResultados);
            this.panel8.Controls.Add(this.label20);
            this.panel8.Controls.Add(this.textBox2);
            this.panel8.Controls.Add(this.picFiltroActivo);
            this.panel8.Controls.Add(this.picFiltroInactivo);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(246, 3);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(586, 32);
            this.panel8.TabIndex = 668;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoEllipsis = true;
            this.lblResultados.BackColor = System.Drawing.Color.Transparent;
            this.lblResultados.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblResultados.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultados.ForeColor = System.Drawing.Color.Teal;
            this.lblResultados.Location = new System.Drawing.Point(93, 5);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(88, 22);
            this.lblResultados.TabIndex = 667;
            this.lblResultados.Text = "Cantidad";
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(5, 5);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(825, 2);
            this.panel12.TabIndex = 671;
            // 
            // frmSeleccionarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1360, 726);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.pnlInferior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSeleccionarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSeleccionarProducto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSeleccionarProducto_FormClosed);
            this.Load += new System.EventHandler(this.frmSeleccionarProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoProductos)).EndInit();
            this.cmsAfectarProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.pnlFiltroFecha.ResumeLayout(false);
            this.pnlFiltroFecha.PerformLayout();
            this.pnlFiltroGeneral.ResumeLayout(false);
            this.pnlFiltroGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFiltroActivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFiltroInactivo)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.pblSuperior1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.pnlCentral.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPedidoProductos;
        private System.Windows.Forms.Button btnAfectados;
        private System.Windows.Forms.Button btnAfectar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip cmsAfectarProducto;
        private System.Windows.Forms.ToolStripMenuItem btnAfecComp;
        private System.Windows.Forms.ToolStripMenuItem btnDesafectar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMostrarfiltros;
        private System.Windows.Forms.Button bunifuFlatButton1;
        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.ComboBox cmbFiltraFicha;
        private System.Windows.Forms.CheckBox chkFiltraFicha;
        private System.Windows.Forms.ComboBox cmbFiltraRetencion;
        private System.Windows.Forms.CheckBox chkFiltraRetencion;
        private System.Windows.Forms.ComboBox cmbFiltraMovimiento;
        private System.Windows.Forms.CheckBox chkFiltraMovimiento;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox chkFechaHasta;
        private System.Windows.Forms.CheckBox chkFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.TextBox txtFiltraProduccion;
        private System.Windows.Forms.CheckBox chkFiltraProduccion;
        private System.Windows.Forms.Label lblfiltros;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox picFiltroActivo;
        private System.Windows.Forms.PictureBox picFiltroInactivo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pblSuperior1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Panel pnlFiltroFecha;
        private System.Windows.Forms.Panel pnlFiltroGeneral;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblNumPedido;
        private System.Windows.Forms.Label lblNumOrdenCarga;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblCantAfectada;
        private System.Windows.Forms.Label lblCantAfectar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDModificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeposito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductoDescrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFicha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private System.Windows.Forms.Panel panel12;
    }
}