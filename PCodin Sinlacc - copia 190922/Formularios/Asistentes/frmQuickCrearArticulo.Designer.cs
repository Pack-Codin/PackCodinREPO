namespace PCodin_Sinlacc.Formularios.Asistentes
{
    partial class frmQuickCrearArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuickCrearArticulo));
            this.label12 = new System.Windows.Forms.Label();
            this.txtCodArticulo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbMedida = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerarPLU = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPLU = new System.Windows.Forms.TextBox();
            this.btnCopiarCodBarras = new System.Windows.Forms.Button();
            this.txtDescripcionAriculo = new System.Windows.Forms.MaskedTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoBarra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscarCategoria = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbListaPrecio = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtBuscaInsPro = new System.Windows.Forms.TextBox();
            this.btnBuscarInsPro = new System.Windows.Forms.Button();
            this.cmbFiltraInsPro = new System.Windows.Forms.ComboBox();
            this.cmbMedidaEquiv = new System.Windows.Forms.ComboBox();
            this.txtCantEquivalencia = new System.Windows.Forms.TextBox();
            this.chkUsaEquivalencia = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 20);
            this.label12.TabIndex = 675;
            this.label12.Text = "Código";
            // 
            // txtCodArticulo
            // 
            this.txtCodArticulo.Location = new System.Drawing.Point(127, 30);
            this.txtCodArticulo.Name = "txtCodArticulo";
            this.txtCodArticulo.Size = new System.Drawing.Size(140, 20);
            this.txtCodArticulo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 678;
            this.label1.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 680;
            this.label2.Text = "Rubro";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(127, 105);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(344, 21);
            this.cmbCategoria.TabIndex = 4;
            // 
            // cmbMedida
            // 
            this.cmbMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedida.FormattingEnabled = true;
            this.cmbMedida.Items.AddRange(new object[] {
            "",
            "Unidad",
            "Kilogramos",
            "Litros"});
            this.cmbMedida.Location = new System.Drawing.Point(127, 146);
            this.cmbMedida.Name = "cmbMedida";
            this.cmbMedida.Size = new System.Drawing.Size(117, 21);
            this.cmbMedida.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 685;
            this.label3.Text = "Medida";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGenerarPLU);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtPLU);
            this.panel1.Controls.Add(this.btnCopiarCodBarras);
            this.panel1.Controls.Add(this.txtDescripcionAriculo);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtCodigoBarra);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtBuscarCategoria);
            this.panel1.Controls.Add(this.cmbMedida);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtCodArticulo);
            this.panel1.Controls.Add(this.cmbCategoria);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(526, 247);
            this.panel1.TabIndex = 686;
            // 
            // btnGenerarPLU
            // 
            this.btnGenerarPLU.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerarPLU.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerarPLU.BackgroundImage")));
            this.btnGenerarPLU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGenerarPLU.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGenerarPLU.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGenerarPLU.FlatAppearance.BorderSize = 0;
            this.btnGenerarPLU.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnGenerarPLU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarPLU.Location = new System.Drawing.Point(304, 214);
            this.btnGenerarPLU.Name = "btnGenerarPLU";
            this.btnGenerarPLU.Size = new System.Drawing.Size(51, 28);
            this.btnGenerarPLU.TabIndex = 692;
            this.btnGenerarPLU.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 20);
            this.label10.TabIndex = 691;
            this.label10.Text = "PLU";
            // 
            // txtPLU
            // 
            this.txtPLU.Location = new System.Drawing.Point(126, 219);
            this.txtPLU.MaxLength = 4;
            this.txtPLU.Multiline = true;
            this.txtPLU.Name = "txtPLU";
            this.txtPLU.Size = new System.Drawing.Size(172, 20);
            this.txtPLU.TabIndex = 690;
            // 
            // btnCopiarCodBarras
            // 
            this.btnCopiarCodBarras.BackColor = System.Drawing.Color.Transparent;
            this.btnCopiarCodBarras.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopiarCodBarras.BackgroundImage")));
            this.btnCopiarCodBarras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCopiarCodBarras.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCopiarCodBarras.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCopiarCodBarras.FlatAppearance.BorderSize = 0;
            this.btnCopiarCodBarras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnCopiarCodBarras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiarCodBarras.Location = new System.Drawing.Point(273, 25);
            this.btnCopiarCodBarras.Name = "btnCopiarCodBarras";
            this.btnCopiarCodBarras.Size = new System.Drawing.Size(51, 28);
            this.btnCopiarCodBarras.TabIndex = 689;
            this.btnCopiarCodBarras.UseVisualStyleBackColor = false;
            this.btnCopiarCodBarras.Click += new System.EventHandler(this.btnCopiarCodBarras_Click);
            // 
            // txtDescripcionAriculo
            // 
            this.txtDescripcionAriculo.Location = new System.Drawing.Point(127, 65);
            this.txtDescripcionAriculo.Name = "txtDescripcionAriculo";
            this.txtDescripcionAriculo.Size = new System.Drawing.Size(344, 20);
            this.txtDescripcionAriculo.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(477, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 688;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 687;
            this.label5.Text = "Cod barras";
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.Location = new System.Drawing.Point(127, 184);
            this.txtCodigoBarra.Multiline = true;
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Size = new System.Drawing.Size(172, 20);
            this.txtCodigoBarra.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 676;
            this.label4.Text = "Datos del articulo";
            // 
            // txtBuscarCategoria
            // 
            this.txtBuscarCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscarCategoria.Location = new System.Drawing.Point(127, 105);
            this.txtBuscarCategoria.Name = "txtBuscarCategoria";
            this.txtBuscarCategoria.Size = new System.Drawing.Size(344, 20);
            this.txtBuscarCategoria.TabIndex = 683;
            this.txtBuscarCategoria.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCosto);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtPrecio);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbListaPrecio);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 247);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(526, 152);
            this.panel2.TabIndex = 687;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(127, 75);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(117, 20);
            this.txtCosto.TabIndex = 9;
            this.txtCosto.Text = "0,00";
            this.txtCosto.Leave += new System.EventHandler(this.txtCosto_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 690;
            this.label8.Text = "Costo";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(126, 101);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(117, 20);
            this.txtPrecio.TabIndex = 8;
            this.txtPrecio.Text = "0,00";
            this.txtPrecio.Leave += new System.EventHandler(this.txtPrecio_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 688;
            this.label7.Text = "Precio";
            // 
            // cmbListaPrecio
            // 
            this.cmbListaPrecio.BackColor = System.Drawing.Color.White;
            this.cmbListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListaPrecio.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbListaPrecio.FormattingEnabled = true;
            this.cmbListaPrecio.Location = new System.Drawing.Point(126, 34);
            this.cmbListaPrecio.Name = "cmbListaPrecio";
            this.cmbListaPrecio.Size = new System.Drawing.Size(243, 22);
            this.cmbListaPrecio.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 20);
            this.label13.TabIndex = 678;
            this.label13.Text = "Lista de precio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 677;
            this.label6.Text = "Datos monetarios";
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCargar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCargar.FlatAppearance.BorderSize = 2;
            this.btnCargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.Image = ((System.Drawing.Image)(resources.GetObject("btnCargar.Image")));
            this.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargar.Location = new System.Drawing.Point(5, 24);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(516, 37);
            this.btnCargar.TabIndex = 688;
            this.btnCargar.Text = "   Cargar articulo";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtBuscaInsPro);
            this.panel3.Controls.Add(this.btnBuscarInsPro);
            this.panel3.Controls.Add(this.cmbFiltraInsPro);
            this.panel3.Controls.Add(this.cmbMedidaEquiv);
            this.panel3.Controls.Add(this.txtCantEquivalencia);
            this.panel3.Controls.Add(this.chkUsaEquivalencia);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 399);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(526, 112);
            this.panel3.TabIndex = 689;
            // 
            // txtBuscaInsPro
            // 
            this.txtBuscaInsPro.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscaInsPro.Location = new System.Drawing.Point(126, 61);
            this.txtBuscaInsPro.Name = "txtBuscaInsPro";
            this.txtBuscaInsPro.Size = new System.Drawing.Size(297, 20);
            this.txtBuscaInsPro.TabIndex = 695;
            this.txtBuscaInsPro.Visible = false;
            this.txtBuscaInsPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaInsPro_KeyPress);
            // 
            // btnBuscarInsPro
            // 
            this.btnBuscarInsPro.BackColor = System.Drawing.Color.White;
            this.btnBuscarInsPro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarInsPro.BackgroundImage")));
            this.btnBuscarInsPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarInsPro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarInsPro.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarInsPro.FlatAppearance.BorderSize = 0;
            this.btnBuscarInsPro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarInsPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarInsPro.Location = new System.Drawing.Point(429, 61);
            this.btnBuscarInsPro.Name = "btnBuscarInsPro";
            this.btnBuscarInsPro.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarInsPro.TabIndex = 696;
            this.btnBuscarInsPro.UseVisualStyleBackColor = false;
            this.btnBuscarInsPro.Visible = false;
            this.btnBuscarInsPro.Click += new System.EventHandler(this.btnBuscarInsPro_Click);
            // 
            // cmbFiltraInsPro
            // 
            this.cmbFiltraInsPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraInsPro.FormattingEnabled = true;
            this.cmbFiltraInsPro.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbFiltraInsPro.Location = new System.Drawing.Point(126, 61);
            this.cmbFiltraInsPro.Name = "cmbFiltraInsPro";
            this.cmbFiltraInsPro.Size = new System.Drawing.Size(297, 21);
            this.cmbFiltraInsPro.TabIndex = 694;
            this.cmbFiltraInsPro.Visible = false;
            this.cmbFiltraInsPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFiltraInsPro_KeyPress);
            // 
            // cmbMedidaEquiv
            // 
            this.cmbMedidaEquiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedidaEquiv.FormattingEnabled = true;
            this.cmbMedidaEquiv.Items.AddRange(new object[] {
            "",
            "Unidad",
            "Kilogramos",
            "Litros"});
            this.cmbMedidaEquiv.Location = new System.Drawing.Point(252, 35);
            this.cmbMedidaEquiv.Name = "cmbMedidaEquiv";
            this.cmbMedidaEquiv.Size = new System.Drawing.Size(117, 21);
            this.cmbMedidaEquiv.TabIndex = 693;
            this.cmbMedidaEquiv.Visible = false;
            // 
            // txtCantEquivalencia
            // 
            this.txtCantEquivalencia.Location = new System.Drawing.Point(126, 35);
            this.txtCantEquivalencia.Name = "txtCantEquivalencia";
            this.txtCantEquivalencia.Size = new System.Drawing.Size(117, 20);
            this.txtCantEquivalencia.TabIndex = 692;
            this.txtCantEquivalencia.Text = "0,00";
            this.txtCantEquivalencia.Visible = false;
            this.txtCantEquivalencia.Leave += new System.EventHandler(this.txtCantEquivalencia_Leave);
            // 
            // chkUsaEquivalencia
            // 
            this.chkUsaEquivalencia.AutoSize = true;
            this.chkUsaEquivalencia.Location = new System.Drawing.Point(12, 38);
            this.chkUsaEquivalencia.Name = "chkUsaEquivalencia";
            this.chkUsaEquivalencia.Size = new System.Drawing.Size(108, 17);
            this.chkUsaEquivalencia.TabIndex = 679;
            this.chkUsaEquivalencia.Text = "Usa equivalencia";
            this.chkUsaEquivalencia.UseVisualStyleBackColor = true;
            this.chkUsaEquivalencia.CheckedChanged += new System.EventHandler(this.chkUsaEquivalencia_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(5, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 678;
            this.label9.Text = "Equivalencias";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCargar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 511);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(526, 66);
            this.panel4.TabIndex = 690;
            // 
            // frmQuickCrearArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(526, 577);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQuickCrearArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick - Crear articulo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuickCrearArticulo_FormClosed);
            this.Load += new System.EventHandler(this.frmQuickCrearArticulo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbCategoria;
        public System.Windows.Forms.ComboBox cmbMedida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkUsaEquivalencia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.ComboBox cmbMedidaEquiv;
        public System.Windows.Forms.TextBox txtCantEquivalencia;
        private System.Windows.Forms.Button btnBuscarInsPro;
        private System.Windows.Forms.TextBox txtBuscaInsPro;
        private System.Windows.Forms.ComboBox cmbFiltraInsPro;
        private System.Windows.Forms.Button btnCopiarCodBarras;
        private System.Windows.Forms.Button btnGenerarPLU;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtPLU;
        public System.Windows.Forms.MaskedTextBox txtCodArticulo;
        public System.Windows.Forms.ComboBox cmbListaPrecio;
        public System.Windows.Forms.TextBox txtBuscarCategoria;
        public System.Windows.Forms.MaskedTextBox txtDescripcionAriculo;
    }
}