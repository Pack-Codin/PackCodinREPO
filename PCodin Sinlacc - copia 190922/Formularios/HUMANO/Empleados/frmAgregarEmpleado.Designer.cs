namespace PCodin_Sinlacc.Formularios
{
    partial class frmAgregarEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEmpleado));
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cmbEstadoEmp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSexoEmp = new System.Windows.Forms.ComboBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picFotoEmp = new System.Windows.Forms.PictureBox();
            this.cmsEditarEliminarFotoPC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnEditarFoto = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEliminarFoto = new System.Windows.Forms.ToolStripMenuItem();
            this.txtObservacionesEmp = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpFechaAltaEmp = new System.Windows.Forms.DateTimePicker();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTel2Emp = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDNIEmp = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPuesto = new System.Windows.Forms.ComboBox();
            this.txtNombreEmp = new System.Windows.Forms.TextBox();
            this.dtpFechaNacimientoEmp = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnEliminarPuesto = new System.Windows.Forms.Button();
            this.btnEditarPuesto = new System.Windows.Forms.Button();
            this.btnAgregarPuesto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSeccion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbZona = new System.Windows.Forms.ComboBox();
            this.btnCargar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoEmp)).BeginInit();
            this.cmsEditarEliminarFotoPC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.Color.Black;
            this.txtDireccion.Location = new System.Drawing.Point(198, 453);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(211, 22);
            this.txtDireccion.TabIndex = 414;
            this.txtDireccion.Visible = false;
            // 
            // cmbEstadoEmp
            // 
            this.cmbEstadoEmp.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbEstadoEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoEmp.FormattingEnabled = true;
            this.cmbEstadoEmp.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbEstadoEmp.Location = new System.Drawing.Point(147, 288);
            this.cmbEstadoEmp.Name = "cmbEstadoEmp";
            this.cmbEstadoEmp.Size = new System.Drawing.Size(124, 21);
            this.cmbEstadoEmp.TabIndex = 391;
            this.cmbEstadoEmp.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoEmp_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(80, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 412;
            this.label5.Text = "Activo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(94, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 411;
            this.label3.Text = "Sexo";
            // 
            // cmbSexoEmp
            // 
            this.cmbSexoEmp.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbSexoEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexoEmp.FormattingEnabled = true;
            this.cmbSexoEmp.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cmbSexoEmp.Location = new System.Drawing.Point(147, 149);
            this.cmbSexoEmp.Name = "cmbSexoEmp";
            this.cmbSexoEmp.Size = new System.Drawing.Size(65, 21);
            this.cmbSexoEmp.TabIndex = 388;
            this.cmbSexoEmp.SelectedIndexChanged += new System.EventHandler(this.cmbSexoEmp_SelectedIndexChanged);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox5.Location = new System.Drawing.Point(144, 477);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(198, 4);
            this.pictureBox5.TabIndex = 410;
            this.pictureBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(144, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 25);
            this.label2.TabIndex = 409;
            this.label2.Text = "Foto";
            // 
            // picFotoEmp
            // 
            this.picFotoEmp.ContextMenuStrip = this.cmsEditarEliminarFotoPC;
            this.picFotoEmp.Image = ((System.Drawing.Image)(resources.GetObject("picFotoEmp.Image")));
            this.picFotoEmp.Location = new System.Drawing.Point(144, 481);
            this.picFotoEmp.Name = "picFotoEmp";
            this.picFotoEmp.Size = new System.Drawing.Size(197, 197);
            this.picFotoEmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFotoEmp.TabIndex = 408;
            this.picFotoEmp.TabStop = false;
            // 
            // cmsEditarEliminarFotoPC
            // 
            this.cmsEditarEliminarFotoPC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEditarFoto,
            this.btnEliminarFoto});
            this.cmsEditarEliminarFotoPC.Name = "cmsEditarEliminarFoto";
            this.cmsEditarEliminarFotoPC.Size = new System.Drawing.Size(145, 48);
            this.cmsEditarEliminarFotoPC.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEditarEliminarFotoPC_Opening);
            // 
            // btnEditarFoto
            // 
            this.btnEditarFoto.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarFoto.Image")));
            this.btnEditarFoto.Name = "btnEditarFoto";
            this.btnEditarFoto.Size = new System.Drawing.Size(144, 22);
            this.btnEditarFoto.Text = "Editar Foto";
            this.btnEditarFoto.Click += new System.EventHandler(this.btnEditarFoto_Click);
            // 
            // btnEliminarFoto
            // 
            this.btnEliminarFoto.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarFoto.Image")));
            this.btnEliminarFoto.Name = "btnEliminarFoto";
            this.btnEliminarFoto.Size = new System.Drawing.Size(144, 22);
            this.btnEliminarFoto.Text = "Eliminar Foto";
            this.btnEliminarFoto.Click += new System.EventHandler(this.btnEliminarFoto_Click);
            // 
            // txtObservacionesEmp
            // 
            this.txtObservacionesEmp.BackColor = System.Drawing.Color.White;
            this.txtObservacionesEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacionesEmp.Location = new System.Drawing.Point(147, 401);
            this.txtObservacionesEmp.Multiline = true;
            this.txtObservacionesEmp.Name = "txtObservacionesEmp";
            this.txtObservacionesEmp.Size = new System.Drawing.Size(386, 46);
            this.txtObservacionesEmp.TabIndex = 392;
            this.txtObservacionesEmp.Click += new System.EventHandler(this.txtObservacionesEmp_Click);
            this.txtObservacionesEmp.TextChanged += new System.EventHandler(this.txtObservacionesEmp_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label17.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(26, 401);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 20);
            this.label17.TabIndex = 407;
            this.label17.Text = "Observaciones";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox4.Location = new System.Drawing.Point(-5, 349);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(540, 4);
            this.pictureBox4.TabIndex = 406;
            this.pictureBox4.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(139, 324);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(162, 25);
            this.label16.TabIndex = 405;
            this.label16.Text = "Datos Adicionales";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(82, 234);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 20);
            this.label15.TabIndex = 404;
            this.label15.Text = "Puesto";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(37, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 20);
            this.label14.TabIndex = 403;
            this.label14.Text = "Fecha de Alta";
            // 
            // dtpFechaAltaEmp
            // 
            this.dtpFechaAltaEmp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAltaEmp.Location = new System.Drawing.Point(147, 208);
            this.dtpFechaAltaEmp.Name = "dtpFechaAltaEmp";
            this.dtpFechaAltaEmp.Size = new System.Drawing.Size(125, 20);
            this.dtpFechaAltaEmp.TabIndex = 389;
            this.dtpFechaAltaEmp.ValueChanged += new System.EventHandler(this.dtpFechaAltaEmp_ValueChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox3.Location = new System.Drawing.Point(-5, 198);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(540, 4);
            this.pictureBox3.TabIndex = 402;
            this.pictureBox3.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(139, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(182, 25);
            this.label13.TabIndex = 401;
            this.label13.Text = "Datos Empresariales";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(10, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 20);
            this.label12.TabIndex = 400;
            this.label12.Text = "Fecha Nacimiento";
            // 
            // txtTel2Emp
            // 
            this.txtTel2Emp.BackColor = System.Drawing.Color.White;
            this.txtTel2Emp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel2Emp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel2Emp.ForeColor = System.Drawing.Color.Black;
            this.txtTel2Emp.Location = new System.Drawing.Point(147, 97);
            this.txtTel2Emp.Name = "txtTel2Emp";
            this.txtTel2Emp.Size = new System.Drawing.Size(209, 22);
            this.txtTel2Emp.TabIndex = 386;
            this.txtTel2Emp.Click += new System.EventHandler(this.txtTel2Emp_Click);
            this.txtTel2Emp.TextChanged += new System.EventHandler(this.txtTel2Emp_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(71, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 20);
            this.label11.TabIndex = 399;
            this.label11.Text = "Teléfono";
            // 
            // txtDNIEmp
            // 
            this.txtDNIEmp.BackColor = System.Drawing.Color.White;
            this.txtDNIEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDNIEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNIEmp.ForeColor = System.Drawing.Color.Black;
            this.txtDNIEmp.Location = new System.Drawing.Point(147, 71);
            this.txtDNIEmp.Name = "txtDNIEmp";
            this.txtDNIEmp.Size = new System.Drawing.Size(386, 22);
            this.txtDNIEmp.TabIndex = 384;
            this.txtDNIEmp.Click += new System.EventHandler(this.txtDNIEmp_Click);
            this.txtDNIEmp.TextChanged += new System.EventHandler(this.txtDNIEmp_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(95, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.TabIndex = 398;
            this.label10.Text = "D.N.I";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox2.Location = new System.Drawing.Point(-7, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(540, 4);
            this.pictureBox2.TabIndex = 396;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(139, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 25);
            this.label8.TabIndex = 395;
            this.label8.Text = "Datos Personales";
            // 
            // cmbPuesto
            // 
            this.cmbPuesto.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuesto.FormattingEnabled = true;
            this.cmbPuesto.Location = new System.Drawing.Point(147, 234);
            this.cmbPuesto.Name = "cmbPuesto";
            this.cmbPuesto.Size = new System.Drawing.Size(299, 21);
            this.cmbPuesto.TabIndex = 390;
            this.cmbPuesto.SelectedIndexChanged += new System.EventHandler(this.cmbPuesto_SelectedIndexChanged);
            // 
            // txtNombreEmp
            // 
            this.txtNombreEmp.BackColor = System.Drawing.Color.White;
            this.txtNombreEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreEmp.ForeColor = System.Drawing.Color.Black;
            this.txtNombreEmp.Location = new System.Drawing.Point(147, 43);
            this.txtNombreEmp.Name = "txtNombreEmp";
            this.txtNombreEmp.Size = new System.Drawing.Size(386, 22);
            this.txtNombreEmp.TabIndex = 382;
            this.txtNombreEmp.Click += new System.EventHandler(this.txtNombreEmp_Click);
            this.txtNombreEmp.TextChanged += new System.EventHandler(this.txtNombreEmp_TextChanged);
            // 
            // dtpFechaNacimientoEmp
            // 
            this.dtpFechaNacimientoEmp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimientoEmp.Location = new System.Drawing.Point(147, 123);
            this.dtpFechaNacimientoEmp.Name = "dtpFechaNacimientoEmp";
            this.dtpFechaNacimientoEmp.Size = new System.Drawing.Size(211, 20);
            this.dtpFechaNacimientoEmp.TabIndex = 387;
            this.dtpFechaNacimientoEmp.ValueChanged += new System.EventHandler(this.dtpFechaNacimientoEmp_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(71, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 394;
            this.label4.Text = "Nombre";
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox9.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(142, 689);
            this.pictureBox9.TabIndex = 413;
            this.pictureBox9.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(-1, -1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 26);
            this.button4.TabIndex = 525;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnEliminarPuesto
            // 
            this.btnEliminarPuesto.BackColor = System.Drawing.Color.White;
            this.btnEliminarPuesto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarPuesto.BackgroundImage")));
            this.btnEliminarPuesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminarPuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarPuesto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEliminarPuesto.FlatAppearance.BorderSize = 0;
            this.btnEliminarPuesto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEliminarPuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarPuesto.Location = new System.Drawing.Point(510, 232);
            this.btnEliminarPuesto.Name = "btnEliminarPuesto";
            this.btnEliminarPuesto.Size = new System.Drawing.Size(23, 23);
            this.btnEliminarPuesto.TabIndex = 528;
            this.btnEliminarPuesto.UseVisualStyleBackColor = false;
            this.btnEliminarPuesto.Click += new System.EventHandler(this.btnEliminarPuesto_Click);
            // 
            // btnEditarPuesto
            // 
            this.btnEditarPuesto.BackColor = System.Drawing.Color.White;
            this.btnEditarPuesto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarPuesto.BackgroundImage")));
            this.btnEditarPuesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditarPuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarPuesto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEditarPuesto.FlatAppearance.BorderSize = 0;
            this.btnEditarPuesto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEditarPuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarPuesto.Location = new System.Drawing.Point(481, 231);
            this.btnEditarPuesto.Name = "btnEditarPuesto";
            this.btnEditarPuesto.Size = new System.Drawing.Size(23, 23);
            this.btnEditarPuesto.TabIndex = 527;
            this.btnEditarPuesto.UseVisualStyleBackColor = false;
            this.btnEditarPuesto.Click += new System.EventHandler(this.btnEditarPuesto_Click);
            // 
            // btnAgregarPuesto
            // 
            this.btnAgregarPuesto.BackColor = System.Drawing.Color.White;
            this.btnAgregarPuesto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarPuesto.BackgroundImage")));
            this.btnAgregarPuesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregarPuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarPuesto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAgregarPuesto.FlatAppearance.BorderSize = 0;
            this.btnAgregarPuesto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnAgregarPuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPuesto.Location = new System.Drawing.Point(452, 231);
            this.btnAgregarPuesto.Name = "btnAgregarPuesto";
            this.btnAgregarPuesto.Size = new System.Drawing.Size(23, 23);
            this.btnAgregarPuesto.TabIndex = 526;
            this.btnAgregarPuesto.UseVisualStyleBackColor = false;
            this.btnAgregarPuesto.Click += new System.EventHandler(this.btnAgregarPuesto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(47, 477);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 529;
            this.label1.Text = "Multimedia";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(74, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 531;
            this.label6.Text = "Sección";
            // 
            // cmbSeccion
            // 
            this.cmbSeccion.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeccion.FormattingEnabled = true;
            this.cmbSeccion.Location = new System.Drawing.Point(147, 261);
            this.cmbSeccion.Name = "cmbSeccion";
            this.cmbSeccion.Size = new System.Drawing.Size(299, 21);
            this.cmbSeccion.TabIndex = 530;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(88, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 20);
            this.label7.TabIndex = 532;
            this.label7.Text = "Zona";
            // 
            // cmbZona
            // 
            this.cmbZona.BackColor = System.Drawing.Color.White;
            this.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZona.FormattingEnabled = true;
            this.cmbZona.Location = new System.Drawing.Point(149, 365);
            this.cmbZona.Name = "cmbZona";
            this.cmbZona.Size = new System.Drawing.Size(340, 21);
            this.cmbZona.TabIndex = 754;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.Transparent;
            this.btnCargar.Enabled = false;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCargar.FlatAppearance.BorderSize = 2;
            this.btnCargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.Image = ((System.Drawing.Image)(resources.GetObject("btnCargar.Image")));
            this.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargar.Location = new System.Drawing.Point(347, 621);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(220, 44);
            this.btnCargar.TabIndex = 755;
            this.btnCargar.Text = "   Cargar empleado";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // frmAgregarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1269, 690);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.cmbZona);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbSeccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminarPuesto);
            this.Controls.Add(this.btnEditarPuesto);
            this.Controls.Add(this.btnAgregarPuesto);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.cmbEstadoEmp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSexoEmp);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picFotoEmp);
            this.Controls.Add(this.txtObservacionesEmp);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dtpFechaAltaEmp);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTel2Emp);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDNIEmp);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbPuesto);
            this.Controls.Add(this.txtNombreEmp);
            this.Controls.Add(this.dtpFechaNacimientoEmp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAgregarEmpleado";
            this.Text = "frmAgregarEmpleado";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAgregarEmpleado_FormClosed);
            this.Load += new System.EventHandler(this.frmAgregarEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoEmp)).EndInit();
            this.cmsEditarEliminarFotoPC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ComboBox cmbEstadoEmp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSexoEmp;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picFotoEmp;
        private System.Windows.Forms.TextBox txtObservacionesEmp;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpFechaAltaEmp;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTel2Emp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDNIEmp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPuesto;
        private System.Windows.Forms.TextBox txtNombreEmp;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimientoEmp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnEliminarPuesto;
        private System.Windows.Forms.Button btnEditarPuesto;
        private System.Windows.Forms.Button btnAgregarPuesto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip cmsEditarEliminarFotoPC;
        private System.Windows.Forms.ToolStripMenuItem btnEditarFoto;
        private System.Windows.Forms.ToolStripMenuItem btnEliminarFoto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSeccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbZona;
        private System.Windows.Forms.Button btnCargar;
    }
}