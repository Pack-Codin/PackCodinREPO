
namespace PCodin_Sinlacc.Formularios.Productos___Insumos
{
    partial class frmAgregarCompraInsumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarCompraInsumo));
            this.txtBuscarResponsable = new System.Windows.Forms.TextBox();
            this.btnBuscarResponsable = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMedida = new System.Windows.Forms.ComboBox();
            this.txtBuscaInsPro = new System.Windows.Forms.TextBox();
            this.btnBuscarInsPro = new System.Windows.Forms.Button();
            this.cmbInsumo = new System.Windows.Forms.ComboBox();
            this.cmbResponsable = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtBuscaProveedor = new System.Windows.Forms.TextBox();
            this.btnBuscaProveedor = new System.Windows.Forms.Button();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtCantidadUtilizada = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cmbMovimiento = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnInvalidar = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnCargar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBuscarResponsable
            // 
            this.txtBuscarResponsable.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscarResponsable.Location = new System.Drawing.Point(161, 276);
            this.txtBuscarResponsable.Name = "txtBuscarResponsable";
            this.txtBuscarResponsable.Size = new System.Drawing.Size(332, 20);
            this.txtBuscarResponsable.TabIndex = 557;
            this.txtBuscarResponsable.Visible = false;
            this.txtBuscarResponsable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarResponsable_KeyPress);
            // 
            // btnBuscarResponsable
            // 
            this.btnBuscarResponsable.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarResponsable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarResponsable.BackgroundImage")));
            this.btnBuscarResponsable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarResponsable.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscarResponsable.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarResponsable.FlatAppearance.BorderSize = 0;
            this.btnBuscarResponsable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarResponsable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarResponsable.Location = new System.Drawing.Point(508, 277);
            this.btnBuscarResponsable.Name = "btnBuscarResponsable";
            this.btnBuscarResponsable.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarResponsable.TabIndex = 556;
            this.btnBuscarResponsable.UseVisualStyleBackColor = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(161, 49);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(149, 20);
            this.dtpFecha.TabIndex = 554;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 555;
            this.label4.Text = "Fecha";
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
            this.cmbMedida.Location = new System.Drawing.Point(287, 228);
            this.cmbMedida.Name = "cmbMedida";
            this.cmbMedida.Size = new System.Drawing.Size(117, 21);
            this.cmbMedida.TabIndex = 552;
            this.cmbMedida.SelectedIndexChanged += new System.EventHandler(this.cmbMedida_SelectedIndexChanged);
            // 
            // txtBuscaInsPro
            // 
            this.txtBuscaInsPro.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscaInsPro.Location = new System.Drawing.Point(161, 140);
            this.txtBuscaInsPro.Name = "txtBuscaInsPro";
            this.txtBuscaInsPro.Size = new System.Drawing.Size(332, 20);
            this.txtBuscaInsPro.TabIndex = 551;
            this.txtBuscaInsPro.Visible = false;
            this.txtBuscaInsPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaInsPro_KeyPress);
            // 
            // btnBuscarInsPro
            // 
            this.btnBuscarInsPro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarInsPro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarInsPro.BackgroundImage")));
            this.btnBuscarInsPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarInsPro.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscarInsPro.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarInsPro.FlatAppearance.BorderSize = 0;
            this.btnBuscarInsPro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarInsPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarInsPro.Location = new System.Drawing.Point(510, 142);
            this.btnBuscarInsPro.Name = "btnBuscarInsPro";
            this.btnBuscarInsPro.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarInsPro.TabIndex = 550;
            this.btnBuscarInsPro.UseVisualStyleBackColor = false;
            this.btnBuscarInsPro.Click += new System.EventHandler(this.btnBuscarInsPro_Click);
            // 
            // cmbInsumo
            // 
            this.cmbInsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInsumo.FormattingEnabled = true;
            this.cmbInsumo.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbInsumo.Location = new System.Drawing.Point(161, 140);
            this.cmbInsumo.Name = "cmbInsumo";
            this.cmbInsumo.Size = new System.Drawing.Size(332, 21);
            this.cmbInsumo.TabIndex = 549;
            this.cmbInsumo.SelectedIndexChanged += new System.EventHandler(this.cmbInsumo_SelectedIndexChanged);
            this.cmbInsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbInsumo_KeyPress);
            // 
            // cmbResponsable
            // 
            this.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsable.FormattingEnabled = true;
            this.cmbResponsable.Location = new System.Drawing.Point(161, 276);
            this.cmbResponsable.Name = "cmbResponsable";
            this.cmbResponsable.Size = new System.Drawing.Size(332, 21);
            this.cmbResponsable.TabIndex = 547;
            this.cmbResponsable.SelectedIndexChanged += new System.EventHandler(this.cmbResponsable_SelectedIndexChanged);
            this.cmbResponsable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbResponsable_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 548;
            this.label5.Text = "Responsable";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 546;
            this.label1.Text = "Cantidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(73, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 25);
            this.label7.TabIndex = 545;
            this.label7.Text = "Insumo";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(161, 220);
            this.txtCantidad.Multiline = true;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(120, 30);
            this.txtCantidad.TabIndex = 558;
            this.txtCantidad.Click += new System.EventHandler(this.txtCantidad_Click);
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged_1);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // txtBuscaProveedor
            // 
            this.txtBuscaProveedor.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscaProveedor.Location = new System.Drawing.Point(161, 194);
            this.txtBuscaProveedor.Name = "txtBuscaProveedor";
            this.txtBuscaProveedor.Size = new System.Drawing.Size(332, 20);
            this.txtBuscaProveedor.TabIndex = 562;
            this.txtBuscaProveedor.Visible = false;
            this.txtBuscaProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaProveedor_KeyPress);
            // 
            // btnBuscaProveedor
            // 
            this.btnBuscaProveedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscaProveedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscaProveedor.BackgroundImage")));
            this.btnBuscaProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscaProveedor.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscaProveedor.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscaProveedor.FlatAppearance.BorderSize = 0;
            this.btnBuscaProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscaProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaProveedor.Location = new System.Drawing.Point(510, 182);
            this.btnBuscaProveedor.Name = "btnBuscaProveedor";
            this.btnBuscaProveedor.Size = new System.Drawing.Size(20, 20);
            this.btnBuscaProveedor.TabIndex = 561;
            this.btnBuscaProveedor.UseVisualStyleBackColor = false;
            this.btnBuscaProveedor.Click += new System.EventHandler(this.btnBuscaProveedor_Click);
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbProveedor.Location = new System.Drawing.Point(161, 180);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(332, 21);
            this.cmbProveedor.TabIndex = 560;
            this.cmbProveedor.SelectedIndexChanged += new System.EventHandler(this.cmbProveedor_SelectedIndexChanged);
            this.cmbProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbProveedor_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 559;
            this.label2.Text = "Proveedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 25);
            this.label3.TabIndex = 563;
            this.label3.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(161, 330);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(332, 181);
            this.txtObservaciones.TabIndex = 564;
            this.txtObservaciones.TextChanged += new System.EventHandler(this.txtObservaciones_TextChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Cursor = System.Windows.Forms.Cursors.Default;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(1, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 27);
            this.button4.TabIndex = 594;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.Color.White;
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.ForeColor = System.Drawing.Color.Red;
            this.txtEstado.Location = new System.Drawing.Point(954, 53);
            this.txtEstado.Multiline = true;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(209, 31);
            this.txtEstado.TabIndex = 643;
            this.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(954, 36);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(209, 20);
            this.textBox2.TabIndex = 642;
            this.textBox2.Text = "Estado";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCantidadUtilizada
            // 
            this.txtCantidadUtilizada.BackColor = System.Drawing.Color.White;
            this.txtCantidadUtilizada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidadUtilizada.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadUtilizada.ForeColor = System.Drawing.Color.Red;
            this.txtCantidadUtilizada.Location = new System.Drawing.Point(954, 107);
            this.txtCantidadUtilizada.Multiline = true;
            this.txtCantidadUtilizada.Name = "txtCantidadUtilizada";
            this.txtCantidadUtilizada.ReadOnly = true;
            this.txtCantidadUtilizada.Size = new System.Drawing.Size(209, 31);
            this.txtCantidadUtilizada.TabIndex = 645;
            this.txtCantidadUtilizada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidadUtilizada.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(954, 90);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(209, 20);
            this.textBox3.TabIndex = 644;
            this.textBox3.Text = "Cantidad utilizada";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.Visible = false;
            // 
            // cmbMovimiento
            // 
            this.cmbMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovimiento.FormattingEnabled = true;
            this.cmbMovimiento.Location = new System.Drawing.Point(161, 92);
            this.cmbMovimiento.Name = "cmbMovimiento";
            this.cmbMovimiento.Size = new System.Drawing.Size(332, 21);
            this.cmbMovimiento.TabIndex = 647;
            this.cmbMovimiento.SelectedIndexChanged += new System.EventHandler(this.cmbMovimiento_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(34, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 25);
            this.label6.TabIndex = 648;
            this.label6.Text = "Movimiento";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 30);
            this.panel1.TabIndex = 650;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnInvalidar);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.btnCargar);
            this.panel2.Location = new System.Drawing.Point(1, 652);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1163, 39);
            this.panel2.TabIndex = 651;
            // 
            // btnInvalidar
            // 
            this.btnInvalidar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInvalidar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInvalidar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnInvalidar.FlatAppearance.BorderSize = 2;
            this.btnInvalidar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnInvalidar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnInvalidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvalidar.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvalidar.Image = ((System.Drawing.Image)(resources.GetObject("btnInvalidar.Image")));
            this.btnInvalidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvalidar.Location = new System.Drawing.Point(218, 0);
            this.btnInvalidar.Name = "btnInvalidar";
            this.btnInvalidar.Size = new System.Drawing.Size(208, 39);
            this.btnInvalidar.TabIndex = 676;
            this.btnInvalidar.Text = "Invalidar";
            this.btnInvalidar.UseVisualStyleBackColor = false;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(208, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(10, 39);
            this.panel10.TabIndex = 677;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCargar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCargar.FlatAppearance.BorderSize = 2;
            this.btnCargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.Image = ((System.Drawing.Image)(resources.GetObject("btnCargar.Image")));
            this.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargar.Location = new System.Drawing.Point(0, 0);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(208, 39);
            this.btnCargar.TabIndex = 675;
            this.btnCargar.Text = "   Cargar compra";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(597, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(188, 21);
            this.comboBox1.TabIndex = 652;
            this.comboBox1.Visible = false;
            // 
            // frmAgregarCompraInsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 690);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cmbMovimiento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCantidadUtilizada);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBuscaProveedor);
            this.Controls.Add(this.btnBuscaProveedor);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtBuscarResponsable);
            this.Controls.Add(this.btnBuscarResponsable);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMedida);
            this.Controls.Add(this.txtBuscaInsPro);
            this.Controls.Add(this.btnBuscarInsPro);
            this.Controls.Add(this.cmbInsumo);
            this.Controls.Add(this.cmbResponsable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAgregarCompraInsumo";
            this.Text = "frmAgregarCompraInsumo";
            this.Load += new System.EventHandler(this.frmAgregarCompraInsumo_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscarResponsable;
        private System.Windows.Forms.Button btnBuscarResponsable;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMedida;
        private System.Windows.Forms.TextBox txtBuscaInsPro;
        private System.Windows.Forms.Button btnBuscarInsPro;
        private System.Windows.Forms.ComboBox cmbInsumo;
        private System.Windows.Forms.ComboBox cmbResponsable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtBuscaProveedor;
        private System.Windows.Forms.Button btnBuscaProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtCantidadUtilizada;
        private System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.ComboBox cmbMovimiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnInvalidar;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnCargar;
    }
}