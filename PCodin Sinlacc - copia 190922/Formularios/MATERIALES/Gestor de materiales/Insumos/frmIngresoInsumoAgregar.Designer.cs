namespace PCodin_Sinlacc.Formularios.MATERIALES.Gestor_de_materiales.Insumos
{
    partial class frmIngresoInsumoAgregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoInsumoAgregar));
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.cmbMedida = new System.Windows.Forms.ComboBox();
            this.txtBuscaInsPro = new System.Windows.Forms.TextBox();
            this.cmbInsumo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.lblCostoPrecio = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigoBarra = new System.Windows.Forms.TextBox();
            this.pnlSeleccionRapida = new System.Windows.Forms.Panel();
            this.btnVarios = new System.Windows.Forms.Button();
            this.btnPanaderia = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCarniceria = new System.Windows.Forms.Button();
            this.btnFiambreria = new System.Windows.Forms.Button();
            this.btnVerduleria = new System.Windows.Forms.Button();
            this.pnlArticulo = new System.Windows.Forms.Panel();
            this.btnBuscarCodigo = new System.Windows.Forms.Button();
            this.btnBuscaInsumo = new System.Windows.Forms.Button();
            this.pnlCantidad = new System.Windows.Forms.Panel();
            this.btnCalculadora = new System.Windows.Forms.Button();
            this.panel10.SuspendLayout();
            this.pnlSeleccionRapida.SuspendLayout();
            this.pnlArticulo.SuspendLayout();
            this.pnlCantidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(102, 48);
            this.txtCantidad.Multiline = true;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(120, 30);
            this.txtCantidad.TabIndex = 569;
            this.txtCantidad.Text = "1,00";
            this.txtCantidad.Click += new System.EventHandler(this.txtCantidad_Click);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // cmbMedida
            // 
            this.cmbMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbMedida.Enabled = false;
            this.cmbMedida.FormattingEnabled = true;
            this.cmbMedida.Items.AddRange(new object[] {
            "",
            "Unidad",
            "Kilogramos",
            "Litros"});
            this.cmbMedida.Location = new System.Drawing.Point(228, 56);
            this.cmbMedida.Name = "cmbMedida";
            this.cmbMedida.Size = new System.Drawing.Size(117, 21);
            this.cmbMedida.TabIndex = 568;
            // 
            // txtBuscaInsPro
            // 
            this.txtBuscaInsPro.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscaInsPro.Location = new System.Drawing.Point(130, 104);
            this.txtBuscaInsPro.Name = "txtBuscaInsPro";
            this.txtBuscaInsPro.Size = new System.Drawing.Size(332, 20);
            this.txtBuscaInsPro.TabIndex = 567;
            this.txtBuscaInsPro.Visible = false;
            this.txtBuscaInsPro.Click += new System.EventHandler(this.txtBuscaInsPro_Click);
            this.txtBuscaInsPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaInsPro_KeyPress);
            // 
            // cmbInsumo
            // 
            this.cmbInsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInsumo.FormattingEnabled = true;
            this.cmbInsumo.Location = new System.Drawing.Point(130, 103);
            this.cmbInsumo.Name = "cmbInsumo";
            this.cmbInsumo.Size = new System.Drawing.Size(332, 21);
            this.cmbInsumo.TabIndex = 565;
            this.cmbInsumo.SelectedIndexChanged += new System.EventHandler(this.cmbInsumo_SelectedIndexChanged);
            this.cmbInsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbInsumo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 564;
            this.label1.Text = "Cantidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(50, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 23);
            this.label7.TabIndex = 563;
            this.label7.Text = "Articulo";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Controls.Add(this.btnAgregar);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 251);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(4);
            this.panel10.Size = new System.Drawing.Size(1031, 41);
            this.panel10.TabIndex = 677;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAgregar.FlatAppearance.BorderSize = 2;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(4, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(1023, 33);
            this.btnAgregar.TabIndex = 678;
            this.btnAgregar.Text = "   Cargar artículo";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(102, 94);
            this.txtCosto.Multiline = true;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(120, 30);
            this.txtCosto.TabIndex = 679;
            this.txtCosto.Text = "0,00";
            this.txtCosto.Click += new System.EventHandler(this.txtCosto_Click);
            this.txtCosto.TextChanged += new System.EventHandler(this.txtCosto_TextChanged);
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCosto_KeyPress);
            this.txtCosto.Leave += new System.EventHandler(this.txtCosto_Leave);
            // 
            // lblCostoPrecio
            // 
            this.lblCostoPrecio.AutoSize = true;
            this.lblCostoPrecio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCostoPrecio.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoPrecio.Location = new System.Drawing.Point(41, 98);
            this.lblCostoPrecio.Name = "lblCostoPrecio";
            this.lblCostoPrecio.Size = new System.Drawing.Size(56, 23);
            this.lblCostoPrecio.TabIndex = 678;
            this.lblCostoPrecio.Text = "Costo";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(453, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(188, 21);
            this.comboBox1.TabIndex = 680;
            this.comboBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 23);
            this.label4.TabIndex = 682;
            this.label4.Text = "Codigo barra";
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.Location = new System.Drawing.Point(130, 55);
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Size = new System.Drawing.Size(332, 20);
            this.txtCodigoBarra.TabIndex = 683;
            this.txtCodigoBarra.Click += new System.EventHandler(this.txtCodigoBarra_Click);
            this.txtCodigoBarra.TextChanged += new System.EventHandler(this.txtCodigoBarra_TextChanged);
            // 
            // pnlSeleccionRapida
            // 
            this.pnlSeleccionRapida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSeleccionRapida.Controls.Add(this.btnVarios);
            this.pnlSeleccionRapida.Controls.Add(this.btnPanaderia);
            this.pnlSeleccionRapida.Controls.Add(this.label2);
            this.pnlSeleccionRapida.Controls.Add(this.btnCarniceria);
            this.pnlSeleccionRapida.Controls.Add(this.btnFiambreria);
            this.pnlSeleccionRapida.Controls.Add(this.btnVerduleria);
            this.pnlSeleccionRapida.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeleccionRapida.Location = new System.Drawing.Point(0, 0);
            this.pnlSeleccionRapida.Name = "pnlSeleccionRapida";
            this.pnlSeleccionRapida.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSeleccionRapida.Size = new System.Drawing.Size(1031, 100);
            this.pnlSeleccionRapida.TabIndex = 688;
            // 
            // btnVarios
            // 
            this.btnVarios.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVarios.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnVarios.FlatAppearance.BorderSize = 2;
            this.btnVarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnVarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.btnVarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVarios.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVarios.Image = ((System.Drawing.Image)(resources.GetObject("btnVarios.Image")));
            this.btnVarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVarios.Location = new System.Drawing.Point(811, 32);
            this.btnVarios.Name = "btnVarios";
            this.btnVarios.Size = new System.Drawing.Size(182, 41);
            this.btnVarios.TabIndex = 690;
            this.btnVarios.Text = "Varios";
            this.btnVarios.UseVisualStyleBackColor = false;
            this.btnVarios.Click += new System.EventHandler(this.btnVarios_Click);
            // 
            // btnPanaderia
            // 
            this.btnPanaderia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPanaderia.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnPanaderia.FlatAppearance.BorderSize = 2;
            this.btnPanaderia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPanaderia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.btnPanaderia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanaderia.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPanaderia.Image = ((System.Drawing.Image)(resources.GetObject("btnPanaderia.Image")));
            this.btnPanaderia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPanaderia.Location = new System.Drawing.Point(613, 32);
            this.btnPanaderia.Name = "btnPanaderia";
            this.btnPanaderia.Size = new System.Drawing.Size(182, 41);
            this.btnPanaderia.TabIndex = 689;
            this.btnPanaderia.Text = "Panaderia";
            this.btnPanaderia.UseVisualStyleBackColor = false;
            this.btnPanaderia.Click += new System.EventHandler(this.btnPanaderia_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 21);
            this.label2.TabIndex = 688;
            this.label2.Text = "Seleccion rápida";
            // 
            // btnCarniceria
            // 
            this.btnCarniceria.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCarniceria.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnCarniceria.FlatAppearance.BorderSize = 2;
            this.btnCarniceria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCarniceria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.btnCarniceria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarniceria.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarniceria.Image = ((System.Drawing.Image)(resources.GetObject("btnCarniceria.Image")));
            this.btnCarniceria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarniceria.Location = new System.Drawing.Point(16, 32);
            this.btnCarniceria.Name = "btnCarniceria";
            this.btnCarniceria.Size = new System.Drawing.Size(182, 41);
            this.btnCarniceria.TabIndex = 679;
            this.btnCarniceria.Text = "Carniceria";
            this.btnCarniceria.UseVisualStyleBackColor = false;
            this.btnCarniceria.Click += new System.EventHandler(this.btnCarniceria_Click);
            // 
            // btnFiambreria
            // 
            this.btnFiambreria.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFiambreria.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnFiambreria.FlatAppearance.BorderSize = 2;
            this.btnFiambreria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFiambreria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.btnFiambreria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiambreria.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiambreria.Image = ((System.Drawing.Image)(resources.GetObject("btnFiambreria.Image")));
            this.btnFiambreria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiambreria.Location = new System.Drawing.Point(415, 32);
            this.btnFiambreria.Name = "btnFiambreria";
            this.btnFiambreria.Size = new System.Drawing.Size(182, 41);
            this.btnFiambreria.TabIndex = 687;
            this.btnFiambreria.Text = "Fiambreria";
            this.btnFiambreria.UseVisualStyleBackColor = false;
            this.btnFiambreria.Click += new System.EventHandler(this.btnFiambreria_Click);
            // 
            // btnVerduleria
            // 
            this.btnVerduleria.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVerduleria.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnVerduleria.FlatAppearance.BorderSize = 2;
            this.btnVerduleria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnVerduleria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.btnVerduleria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerduleria.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerduleria.Image = ((System.Drawing.Image)(resources.GetObject("btnVerduleria.Image")));
            this.btnVerduleria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerduleria.Location = new System.Drawing.Point(216, 32);
            this.btnVerduleria.Name = "btnVerduleria";
            this.btnVerduleria.Size = new System.Drawing.Size(182, 41);
            this.btnVerduleria.TabIndex = 686;
            this.btnVerduleria.Text = "Verduleria";
            this.btnVerduleria.UseVisualStyleBackColor = false;
            this.btnVerduleria.Click += new System.EventHandler(this.btnVerduleria_Click);
            // 
            // pnlArticulo
            // 
            this.pnlArticulo.Controls.Add(this.txtBuscaInsPro);
            this.pnlArticulo.Controls.Add(this.txtCodigoBarra);
            this.pnlArticulo.Controls.Add(this.label7);
            this.pnlArticulo.Controls.Add(this.btnBuscarCodigo);
            this.pnlArticulo.Controls.Add(this.cmbInsumo);
            this.pnlArticulo.Controls.Add(this.btnBuscaInsumo);
            this.pnlArticulo.Controls.Add(this.label4);
            this.pnlArticulo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlArticulo.Location = new System.Drawing.Point(0, 100);
            this.pnlArticulo.Name = "pnlArticulo";
            this.pnlArticulo.Padding = new System.Windows.Forms.Padding(10);
            this.pnlArticulo.Size = new System.Drawing.Size(526, 151);
            this.pnlArticulo.TabIndex = 689;
            // 
            // btnBuscarCodigo
            // 
            this.btnBuscarCodigo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarCodigo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCodigo.BackgroundImage")));
            this.btnBuscarCodigo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarCodigo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscarCodigo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarCodigo.FlatAppearance.BorderSize = 0;
            this.btnBuscarCodigo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCodigo.Location = new System.Drawing.Point(479, 57);
            this.btnBuscarCodigo.Name = "btnBuscarCodigo";
            this.btnBuscarCodigo.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarCodigo.TabIndex = 685;
            this.btnBuscarCodigo.UseVisualStyleBackColor = false;
            this.btnBuscarCodigo.Click += new System.EventHandler(this.btnBuscarCodigo_Click);
            // 
            // btnBuscaInsumo
            // 
            this.btnBuscaInsumo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscaInsumo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscaInsumo.BackgroundImage")));
            this.btnBuscaInsumo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscaInsumo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscaInsumo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscaInsumo.FlatAppearance.BorderSize = 0;
            this.btnBuscaInsumo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscaInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaInsumo.Location = new System.Drawing.Point(479, 103);
            this.btnBuscaInsumo.Name = "btnBuscaInsumo";
            this.btnBuscaInsumo.Size = new System.Drawing.Size(20, 20);
            this.btnBuscaInsumo.TabIndex = 684;
            this.btnBuscaInsumo.UseVisualStyleBackColor = false;
            this.btnBuscaInsumo.Click += new System.EventHandler(this.btnBuscaInsumo_Click);
            // 
            // pnlCantidad
            // 
            this.pnlCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCantidad.Controls.Add(this.btnCalculadora);
            this.pnlCantidad.Controls.Add(this.cmbMedida);
            this.pnlCantidad.Controls.Add(this.label1);
            this.pnlCantidad.Controls.Add(this.txtCantidad);
            this.pnlCantidad.Controls.Add(this.lblCostoPrecio);
            this.pnlCantidad.Controls.Add(this.txtCosto);
            this.pnlCantidad.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCantidad.Location = new System.Drawing.Point(571, 100);
            this.pnlCantidad.Name = "pnlCantidad";
            this.pnlCantidad.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCantidad.Size = new System.Drawing.Size(460, 151);
            this.pnlCantidad.TabIndex = 690;
            // 
            // btnCalculadora
            // 
            this.btnCalculadora.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCalculadora.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnCalculadora.FlatAppearance.BorderSize = 2;
            this.btnCalculadora.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCalculadora.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.btnCalculadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculadora.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculadora.Image = ((System.Drawing.Image)(resources.GetObject("btnCalculadora.Image")));
            this.btnCalculadora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalculadora.Location = new System.Drawing.Point(228, 87);
            this.btnCalculadora.Name = "btnCalculadora";
            this.btnCalculadora.Size = new System.Drawing.Size(172, 41);
            this.btnCalculadora.TabIndex = 680;
            this.btnCalculadora.Text = "Calculadora";
            this.btnCalculadora.UseVisualStyleBackColor = false;
            this.btnCalculadora.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmIngresoInsumoAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1031, 292);
            this.Controls.Add(this.pnlCantidad);
            this.Controls.Add(this.pnlArticulo);
            this.Controls.Add(this.pnlSeleccionRapida);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel10);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIngresoInsumoAgregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar Insumo / Artículo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIngresoInsumoAgregar_FormClosing);
            this.Load += new System.EventHandler(this.frmIngresoInsumoAgregar_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmIngresoInsumoAgregar_KeyPress);
            this.panel10.ResumeLayout(false);
            this.pnlSeleccionRapida.ResumeLayout(false);
            this.pnlSeleccionRapida.PerformLayout();
            this.pnlArticulo.ResumeLayout(false);
            this.pnlArticulo.PerformLayout();
            this.pnlCantidad.ResumeLayout(false);
            this.pnlCantidad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox cmbMedida;
        private System.Windows.Forms.TextBox txtBuscaInsPro;
        private System.Windows.Forms.ComboBox cmbInsumo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblCostoPrecio;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.Button btnBuscaInsumo;
        private System.Windows.Forms.Button btnBuscarCodigo;
        private System.Windows.Forms.Button btnCarniceria;
        private System.Windows.Forms.Button btnVerduleria;
        private System.Windows.Forms.Button btnFiambreria;
        private System.Windows.Forms.Panel pnlSeleccionRapida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPanaderia;
        private System.Windows.Forms.Panel pnlArticulo;
        private System.Windows.Forms.Panel pnlCantidad;
        private System.Windows.Forms.Button btnCalculadora;
        public System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Button btnVarios;
    }
}