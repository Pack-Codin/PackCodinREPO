
namespace PCodin_Sinlacc.Formularios.Orden_Produccion
{
    partial class frmAgregarOrdenProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarOrdenProduccion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAfectados = new System.Windows.Forms.Button();
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
            this.btnEditar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAfectar = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.dgvPedidoProductos = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedida_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductoDescrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadAfec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxEstadoPedido = new System.Windows.Forms.GroupBox();
            this.rdbFinalizado = new System.Windows.Forms.RadioButton();
            this.rdbAutorizado = new System.Windows.Forms.RadioButton();
            this.rdbInform = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscarResponsable = new System.Windows.Forms.TextBox();
            this.btnBuscarResponsable = new System.Windows.Forms.Button();
            this.cmbResponsable = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkFiltraCliente = new System.Windows.Forms.CheckBox();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.cmbFiltraCliente = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoProductos)).BeginInit();
            this.gbxEstadoPedido.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.White;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(278, 198);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(162, 28);
            this.btnExcel.TabIndex = 654;
            this.btnExcel.Text = "      Exportar a excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            // 
            // btnAnular
            // 
            this.btnAnular.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnular.Enabled = false;
            this.btnAnular.Location = new System.Drawing.Point(323, 639);
            this.btnAnular.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(233, 48);
            this.btnAnular.TabIndex = 653;
            this.btnAnular.Text = "Anular orden";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Orange;
            this.pictureBox1.Location = new System.Drawing.Point(895, 227);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 3);
            this.pictureBox1.TabIndex = 652;
            this.pictureBox1.TabStop = false;
            // 
            // btnAfectados
            // 
            this.btnAfectados.BackColor = System.Drawing.Color.White;
            this.btnAfectados.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAfectados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAfectados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnAfectados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfectados.Image = ((System.Drawing.Image)(resources.GetObject("btnAfectados.Image")));
            this.btnAfectados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAfectados.Location = new System.Drawing.Point(125, 198);
            this.btnAfectados.Name = "btnAfectados";
            this.btnAfectados.Size = new System.Drawing.Size(147, 28);
            this.btnAfectados.TabIndex = 651;
            this.btnAfectados.Text = "     Pedidos afectados";
            this.btnAfectados.UseVisualStyleBackColor = false;
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.BackColor = System.Drawing.Color.Silver;
            this.gbxFiltros.Controls.Add(this.chkFiltraCliente);
            this.gbxFiltros.Controls.Add(this.txtBuscarCliente);
            this.gbxFiltros.Controls.Add(this.btnBuscarCliente);
            this.gbxFiltros.Controls.Add(this.cmbFiltraCliente);
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
            this.gbxFiltros.Location = new System.Drawing.Point(639, 367);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Size = new System.Drawing.Size(525, 289);
            this.gbxFiltros.TabIndex = 650;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Visible = false;
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
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Black;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(0, 179);
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
            this.chkFechaHasta.Location = new System.Drawing.Point(276, 222);
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
            this.dtpFechaHasta.Location = new System.Drawing.Point(333, 222);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaHasta.TabIndex = 585;
            this.dtpFechaHasta.Value = new System.DateTime(2021, 10, 20, 0, 0, 0, 0);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(112, 221);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaDesde.TabIndex = 584;
            this.dtpFechaDesde.Value = new System.DateTime(2021, 10, 20, 10, 52, 34, 0);
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBuscarProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarProducto.Location = new System.Drawing.Point(112, 81);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(340, 20);
            this.txtBuscarProducto.TabIndex = 531;
            this.txtBuscarProducto.Visible = false;
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
            this.btnBuscar.Location = new System.Drawing.Point(0, 257);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(525, 30);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.UseVisualStyleBackColor = false;
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
            this.btnMostrarfiltros.Location = new System.Drawing.Point(639, 656);
            this.btnMostrarfiltros.Name = "btnMostrarfiltros";
            this.btnMostrarfiltros.Size = new System.Drawing.Size(525, 31);
            this.btnMostrarfiltros.TabIndex = 649;
            this.btnMostrarfiltros.Text = "Mostrar Filtros";
            this.btnMostrarfiltros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarfiltros.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(1110, 173);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(48, 46);
            this.btnEditar.TabIndex = 648;
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.Black;
            this.txtCantidad.Location = new System.Drawing.Point(984, 189);
            this.txtCantidad.Multiline = true;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(120, 30);
            this.txtCantidad.TabIndex = 647;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(890, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 25);
            this.label8.TabIndex = 646;
            this.label8.Text = "Cantidad";
            // 
            // btnAfectar
            // 
            this.btnAfectar.BackColor = System.Drawing.Color.White;
            this.btnAfectar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAfectar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAfectar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnAfectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfectar.Image = ((System.Drawing.Image)(resources.GetObject("btnAfectar.Image")));
            this.btnAfectar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAfectar.Location = new System.Drawing.Point(0, 198);
            this.btnAfectar.Name = "btnAfectar";
            this.btnAfectar.Size = new System.Drawing.Size(128, 28);
            this.btnAfectar.TabIndex = 645;
            this.btnAfectar.Text = "        Afectar pedido";
            this.btnAfectar.UseVisualStyleBackColor = false;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(534, 30);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(342, 144);
            this.txtObservaciones.TabIndex = 644;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.Orange;
            this.btnCargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargar.Enabled = false;
            this.btnCargar.Location = new System.Drawing.Point(3, 639);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(310, 48);
            this.btnCargar.TabIndex = 643;
            this.btnCargar.Text = "Confirmar orden de carga";
            this.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPedidoProductos
            // 
            this.dgvPedidoProductos.AllowUserToAddRows = false;
            this.dgvPedidoProductos.AllowUserToResizeRows = false;
            this.dgvPedidoProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidoProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPedidoProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvPedidoProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle43.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle43.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle43.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidoProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle43;
            this.dgvPedidoProductos.ColumnHeadersHeight = 20;
            this.dgvPedidoProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPedidoProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colProductoID,
            this.colMedida_ID,
            this.colProductoDescrip,
            this.colMedida,
            this.colCantidad,
            this.colCantidadAfec,
            this.colEstado,
            this.colPCID});
            this.dgvPedidoProductos.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle46.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle46.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle46.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle46.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle46.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle46.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidoProductos.DefaultCellStyle = dataGridViewCellStyle46;
            this.dgvPedidoProductos.EnableHeadersVisualStyles = false;
            this.dgvPedidoProductos.GridColor = System.Drawing.Color.Teal;
            this.dgvPedidoProductos.Location = new System.Drawing.Point(0, 232);
            this.dgvPedidoProductos.MultiSelect = false;
            this.dgvPedidoProductos.Name = "dgvPedidoProductos";
            this.dgvPedidoProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle47.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidoProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle47;
            this.dgvPedidoProductos.RowHeadersVisible = false;
            this.dgvPedidoProductos.RowHeadersWidth = 38;
            this.dgvPedidoProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle48.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPedidoProductos.RowsDefaultCellStyle = dataGridViewCellStyle48;
            this.dgvPedidoProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidoProductos.Size = new System.Drawing.Size(1161, 396);
            this.dgvPedidoProductos.TabIndex = 642;
            // 
            // colID
            // 
            this.colID.HeaderText = "Nro Pedido";
            this.colID.Name = "colID";
            this.colID.Width = 150;
            // 
            // colProductoID
            // 
            this.colProductoID.HeaderText = "Producto_ID";
            this.colProductoID.Name = "colProductoID";
            this.colProductoID.Visible = false;
            // 
            // colMedida_ID
            // 
            this.colMedida_ID.HeaderText = "Medida_ID";
            this.colMedida_ID.Name = "colMedida_ID";
            this.colMedida_ID.Visible = false;
            // 
            // colProductoDescrip
            // 
            this.colProductoDescrip.FillWeight = 49.555F;
            this.colProductoDescrip.HeaderText = "Producto";
            this.colProductoDescrip.Name = "colProductoDescrip";
            this.colProductoDescrip.ReadOnly = true;
            this.colProductoDescrip.Width = 400;
            // 
            // colMedida
            // 
            this.colMedida.FillWeight = 140F;
            this.colMedida.HeaderText = "Medida";
            this.colMedida.Name = "colMedida";
            this.colMedida.ReadOnly = true;
            this.colMedida.Width = 150;
            // 
            // colCantidad
            // 
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle44.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle44.Format = "N2";
            dataGridViewCellStyle44.NullValue = "0";
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.Color.Red;
            this.colCantidad.DefaultCellStyle = dataGridViewCellStyle44;
            this.colCantidad.FillWeight = 16.51833F;
            this.colCantidad.HeaderText = "Cantidad pend";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 150;
            // 
            // colCantidadAfec
            // 
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle45.Format = "N2";
            dataGridViewCellStyle45.NullValue = "0";
            this.colCantidadAfec.DefaultCellStyle = dataGridViewCellStyle45;
            this.colCantidadAfec.FillWeight = 16.51833F;
            this.colCantidadAfec.HeaderText = "Cantidad afec";
            this.colCantidadAfec.Name = "colCantidadAfec";
            this.colCantidadAfec.Width = 150;
            // 
            // colEstado
            // 
            this.colEstado.FillWeight = 16.51833F;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Width = 150;
            // 
            // colPCID
            // 
            this.colPCID.HeaderText = "PedCuerID";
            this.colPCID.Name = "colPCID";
            this.colPCID.Visible = false;
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
            this.button4.Location = new System.Drawing.Point(0, -1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 27);
            this.button4.TabIndex = 657;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(117, 30);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(151, 20);
            this.dtpFecha.TabIndex = 656;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 21);
            this.label10.TabIndex = 655;
            this.label10.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(117, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker1.TabIndex = 659;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 658;
            this.label1.Text = "Fecha limite";
            // 
            // gbxEstadoPedido
            // 
            this.gbxEstadoPedido.Controls.Add(this.rdbFinalizado);
            this.gbxEstadoPedido.Controls.Add(this.rdbAutorizado);
            this.gbxEstadoPedido.Controls.Add(this.rdbInform);
            this.gbxEstadoPedido.Location = new System.Drawing.Point(117, 82);
            this.gbxEstadoPedido.Name = "gbxEstadoPedido";
            this.gbxEstadoPedido.Size = new System.Drawing.Size(386, 50);
            this.gbxEstadoPedido.TabIndex = 661;
            this.gbxEstadoPedido.TabStop = false;
            // 
            // rdbFinalizado
            // 
            this.rdbFinalizado.AutoSize = true;
            this.rdbFinalizado.Enabled = false;
            this.rdbFinalizado.Location = new System.Drawing.Point(289, 19);
            this.rdbFinalizado.Name = "rdbFinalizado";
            this.rdbFinalizado.Size = new System.Drawing.Size(72, 17);
            this.rdbFinalizado.TabIndex = 2;
            this.rdbFinalizado.TabStop = true;
            this.rdbFinalizado.Text = "Finalizado";
            this.rdbFinalizado.UseVisualStyleBackColor = true;
            // 
            // rdbAutorizado
            // 
            this.rdbAutorizado.AutoSize = true;
            this.rdbAutorizado.Location = new System.Drawing.Point(146, 19);
            this.rdbAutorizado.Name = "rdbAutorizado";
            this.rdbAutorizado.Size = new System.Drawing.Size(75, 17);
            this.rdbAutorizado.TabIndex = 1;
            this.rdbAutorizado.TabStop = true;
            this.rdbAutorizado.Text = "Autorizado";
            this.rdbAutorizado.UseVisualStyleBackColor = true;
            // 
            // rdbInform
            // 
            this.rdbInform.AutoSize = true;
            this.rdbInform.Location = new System.Drawing.Point(5, 19);
            this.rdbInform.Name = "rdbInform";
            this.rdbInform.Size = new System.Drawing.Size(77, 17);
            this.rdbInform.TabIndex = 0;
            this.rdbInform.TabStop = true;
            this.rdbInform.Text = "Informativo";
            this.rdbInform.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 660;
            this.label3.Text = "Estado";
            // 
            // txtBuscarResponsable
            // 
            this.txtBuscarResponsable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBuscarResponsable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarResponsable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarResponsable.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarResponsable.Location = new System.Drawing.Point(116, 151);
            this.txtBuscarResponsable.Name = "txtBuscarResponsable";
            this.txtBuscarResponsable.Size = new System.Drawing.Size(340, 22);
            this.txtBuscarResponsable.TabIndex = 665;
            this.txtBuscarResponsable.Visible = false;
            // 
            // btnBuscarResponsable
            // 
            this.btnBuscarResponsable.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarResponsable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarResponsable.BackgroundImage")));
            this.btnBuscarResponsable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarResponsable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarResponsable.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarResponsable.FlatAppearance.BorderSize = 0;
            this.btnBuscarResponsable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarResponsable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarResponsable.Location = new System.Drawing.Point(474, 149);
            this.btnBuscarResponsable.Name = "btnBuscarResponsable";
            this.btnBuscarResponsable.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarResponsable.TabIndex = 664;
            this.btnBuscarResponsable.UseVisualStyleBackColor = false;
            // 
            // cmbResponsable
            // 
            this.cmbResponsable.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsable.FormattingEnabled = true;
            this.cmbResponsable.Location = new System.Drawing.Point(116, 150);
            this.cmbResponsable.Name = "cmbResponsable";
            this.cmbResponsable.Size = new System.Drawing.Size(340, 21);
            this.cmbResponsable.TabIndex = 663;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 662;
            this.label2.Text = "Responsable";
            // 
            // chkFiltraCliente
            // 
            this.chkFiltraCliente.AutoSize = true;
            this.chkFiltraCliente.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraCliente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraCliente.Location = new System.Drawing.Point(42, 134);
            this.chkFiltraCliente.Name = "chkFiltraCliente";
            this.chkFiltraCliente.Size = new System.Drawing.Size(58, 17);
            this.chkFiltraCliente.TabIndex = 594;
            this.chkFiltraCliente.Text = "Cliente";
            this.chkFiltraCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraCliente.UseVisualStyleBackColor = false;
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBuscarCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarCliente.Location = new System.Drawing.Point(118, 159);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(340, 22);
            this.txtBuscarCliente.TabIndex = 593;
            this.txtBuscarCliente.Visible = false;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.Silver;
            this.btnBuscarCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.BackgroundImage")));
            this.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Location = new System.Drawing.Point(470, 130);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCliente.TabIndex = 592;
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            // 
            // cmbFiltraCliente
            // 
            this.cmbFiltraCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbFiltraCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraCliente.FormattingEnabled = true;
            this.cmbFiltraCliente.Location = new System.Drawing.Point(112, 132);
            this.cmbFiltraCliente.Name = "cmbFiltraCliente";
            this.cmbFiltraCliente.Size = new System.Drawing.Size(340, 21);
            this.cmbFiltraCliente.TabIndex = 591;
            // 
            // frmAgregarOrdenProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1162, 690);
            this.Controls.Add(this.txtBuscarResponsable);
            this.Controls.Add(this.btnBuscarResponsable);
            this.Controls.Add(this.cmbResponsable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbxEstadoPedido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAfectados);
            this.Controls.Add(this.gbxFiltros);
            this.Controls.Add(this.btnMostrarfiltros);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAfectar);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.dgvPedidoProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAgregarOrdenProduccion";
            this.Text = "frmAgregarOrdenProduccion";
            this.Load += new System.EventHandler(this.frmAgregarOrdenProduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoProductos)).EndInit();
            this.gbxEstadoPedido.ResumeLayout(false);
            this.gbxEstadoPedido.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAfectados;
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
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAfectar;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.DataGridView dgvPedidoProductos;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxEstadoPedido;
        private System.Windows.Forms.RadioButton rdbFinalizado;
        private System.Windows.Forms.RadioButton rdbAutorizado;
        private System.Windows.Forms.RadioButton rdbInform;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuscarResponsable;
        private System.Windows.Forms.Button btnBuscarResponsable;
        private System.Windows.Forms.ComboBox cmbResponsable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedida_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductoDescrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadAfec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPCID;
        private System.Windows.Forms.CheckBox chkFiltraCliente;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.ComboBox cmbFiltraCliente;
    }
}