namespace PCodin_Sinlacc.Formularios
{
    partial class frmIngresoDeInsumos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoDeInsumos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEditarRegistro = new System.Windows.Forms.Button();
            this.btnEditarLista = new System.Windows.Forms.Button();
            this.cmbResponsable = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCargarEnLista = new System.Windows.Forms.Button();
            this.btnCargarInsumosDefinitivo = new System.Windows.Forms.Button();
            this.btnLimpliarLista = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvInsumos = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID_Responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedidaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResponsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBuscaInsPro = new System.Windows.Forms.TextBox();
            this.btnBuscarInsPro = new System.Windows.Forms.Button();
            this.cmbInsumo = new System.Windows.Forms.ComboBox();
            this.cmbMedida = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscarResponsable = new System.Windows.Forms.Button();
            this.txtBuscarResponsable = new System.Windows.Forms.TextBox();
            this.btnCancelarEdicion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditarRegistro
            // 
            this.btnEditarRegistro.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEditarRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditarRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarRegistro.Enabled = false;
            this.btnEditarRegistro.Location = new System.Drawing.Point(23, 356);
            this.btnEditarRegistro.Name = "btnEditarRegistro";
            this.btnEditarRegistro.Size = new System.Drawing.Size(226, 48);
            this.btnEditarRegistro.TabIndex = 457;
            this.btnEditarRegistro.Text = "Editar Registro";
            this.btnEditarRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditarRegistro.Visible = false;
            this.btnEditarRegistro.Click += new System.EventHandler(this.btnEditarRegistro_Click);
            // 
            // btnEditarLista
            // 
            this.btnEditarLista.BackColor = System.Drawing.Color.Silver;
            this.btnEditarLista.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarLista.BackgroundImage")));
            this.btnEditarLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditarLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarLista.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEditarLista.FlatAppearance.BorderSize = 0;
            this.btnEditarLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEditarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarLista.Location = new System.Drawing.Point(485, 3);
            this.btnEditarLista.Name = "btnEditarLista";
            this.btnEditarLista.Size = new System.Drawing.Size(26, 26);
            this.btnEditarLista.TabIndex = 454;
            this.btnEditarLista.UseVisualStyleBackColor = false;
            this.btnEditarLista.Click += new System.EventHandler(this.btnEditarLista_Click);
            // 
            // cmbResponsable
            // 
            this.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsable.FormattingEnabled = true;
            this.cmbResponsable.Location = new System.Drawing.Point(136, 187);
            this.cmbResponsable.Name = "cmbResponsable";
            this.cmbResponsable.Size = new System.Drawing.Size(308, 21);
            this.cmbResponsable.TabIndex = 452;
            this.cmbResponsable.SelectedIndexChanged += new System.EventHandler(this.cmbResponsable_SelectedIndexChanged);
            this.cmbResponsable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbResponsable_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 453;
            this.label5.Text = "Responsable";
            // 
            // btnCargarEnLista
            // 
            this.btnCargarEnLista.BackColor = System.Drawing.Color.Orange;
            this.btnCargarEnLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargarEnLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarEnLista.Enabled = false;
            this.btnCargarEnLista.Location = new System.Drawing.Point(10, 302);
            this.btnCargarEnLista.Name = "btnCargarEnLista";
            this.btnCargarEnLista.Size = new System.Drawing.Size(226, 48);
            this.btnCargarEnLista.TabIndex = 451;
            this.btnCargarEnLista.Text = "Cargar en Lista";
            this.btnCargarEnLista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCargarEnLista.Click += new System.EventHandler(this.btnCargarEnLista_Click);
            // 
            // btnCargarInsumosDefinitivo
            // 
            this.btnCargarInsumosDefinitivo.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCargarInsumosDefinitivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargarInsumosDefinitivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarInsumosDefinitivo.Location = new System.Drawing.Point(478, 657);
            this.btnCargarInsumosDefinitivo.Name = "btnCargarInsumosDefinitivo";
            this.btnCargarInsumosDefinitivo.Size = new System.Drawing.Size(690, 34);
            this.btnCargarInsumosDefinitivo.TabIndex = 450;
            this.btnCargarInsumosDefinitivo.Text = "Confirmar Lista";
            this.btnCargarInsumosDefinitivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCargarInsumosDefinitivo.Click += new System.EventHandler(this.btnCargarInsumosDefinitivo_Click);
            // 
            // btnLimpliarLista
            // 
            this.btnLimpliarLista.BackColor = System.Drawing.Color.Silver;
            this.btnLimpliarLista.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpliarLista.BackgroundImage")));
            this.btnLimpliarLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimpliarLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpliarLista.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLimpliarLista.FlatAppearance.BorderSize = 0;
            this.btnLimpliarLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnLimpliarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpliarLista.Location = new System.Drawing.Point(550, 2);
            this.btnLimpliarLista.Name = "btnLimpliarLista";
            this.btnLimpliarLista.Size = new System.Drawing.Size(27, 27);
            this.btnLimpliarLista.TabIndex = 449;
            this.btnLimpliarLista.UseVisualStyleBackColor = false;
            this.btnLimpliarLista.Click += new System.EventHandler(this.btnLimpliarLista_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Silver;
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(517, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(27, 27);
            this.btnEliminar.TabIndex = 448;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvInsumos
            // 
            this.dgvInsumos.AllowUserToAddRows = false;
            this.dgvInsumos.AllowUserToResizeRows = false;
            this.dgvInsumos.BackgroundColor = System.Drawing.Color.White;
            this.dgvInsumos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvInsumos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInsumos.ColumnHeadersHeight = 26;
            this.dgvInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInsumos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colIDInsumo,
            this.colID_Responsable,
            this.colMedidaID,
            this.colFecha,
            this.colInsumo,
            this.colCantidad,
            this.colMedida,
            this.colResponsable});
            this.dgvInsumos.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsumos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInsumos.EnableHeadersVisualStyles = false;
            this.dgvInsumos.GridColor = System.Drawing.Color.Teal;
            this.dgvInsumos.Location = new System.Drawing.Point(478, 30);
            this.dgvInsumos.MultiSelect = false;
            this.dgvInsumos.Name = "dgvInsumos";
            this.dgvInsumos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInsumos.RowHeadersVisible = false;
            this.dgvInsumos.RowHeadersWidth = 38;
            this.dgvInsumos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInsumos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInsumos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsumos.Size = new System.Drawing.Size(682, 626);
            this.dgvInsumos.TabIndex = 447;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            this.colID.Width = 130;
            // 
            // colIDInsumo
            // 
            this.colIDInsumo.HeaderText = "ID_Insumo";
            this.colIDInsumo.Name = "colIDInsumo";
            this.colIDInsumo.Visible = false;
            // 
            // colID_Responsable
            // 
            this.colID_Responsable.HeaderText = "ID_Responsable";
            this.colID_Responsable.Name = "colID_Responsable";
            this.colID_Responsable.Visible = false;
            // 
            // colMedidaID
            // 
            this.colMedidaID.HeaderText = "ID_Medida";
            this.colMedidaID.Name = "colMedidaID";
            this.colMedidaID.Visible = false;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = false;
            // 
            // colInsumo
            // 
            this.colInsumo.FillWeight = 500F;
            this.colInsumo.HeaderText = "Insumo";
            this.colInsumo.Name = "colInsumo";
            this.colInsumo.Width = 380;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 150;
            // 
            // colMedida
            // 
            this.colMedida.HeaderText = "Medida";
            this.colMedida.Name = "colMedida";
            this.colMedida.Width = 150;
            // 
            // colResponsable
            // 
            this.colResponsable.HeaderText = "Responsable";
            this.colResponsable.Name = "colResponsable";
            this.colResponsable.Visible = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Silver;
            this.pictureBox5.Location = new System.Drawing.Point(478, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(690, 31);
            this.pictureBox5.TabIndex = 446;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox2.Location = new System.Drawing.Point(474, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(5, 701);
            this.pictureBox2.TabIndex = 445;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 444;
            this.label1.Text = "Cantidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 25);
            this.label7.TabIndex = 443;
            this.label7.Text = "Insumo";
            // 
            // txtBuscaInsPro
            // 
            this.txtBuscaInsPro.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscaInsPro.Location = new System.Drawing.Point(112, 80);
            this.txtBuscaInsPro.Name = "txtBuscaInsPro";
            this.txtBuscaInsPro.Size = new System.Drawing.Size(332, 20);
            this.txtBuscaInsPro.TabIndex = 534;
            this.txtBuscaInsPro.Visible = false;
            this.txtBuscaInsPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaInsPro_KeyPress);
            // 
            // btnBuscarInsPro
            // 
            this.btnBuscarInsPro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarInsPro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarInsPro.BackgroundImage")));
            this.btnBuscarInsPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarInsPro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarInsPro.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarInsPro.FlatAppearance.BorderSize = 0;
            this.btnBuscarInsPro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarInsPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarInsPro.Location = new System.Drawing.Point(450, 81);
            this.btnBuscarInsPro.Name = "btnBuscarInsPro";
            this.btnBuscarInsPro.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarInsPro.TabIndex = 533;
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
            this.cmbInsumo.Location = new System.Drawing.Point(112, 80);
            this.cmbInsumo.Name = "cmbInsumo";
            this.cmbInsumo.Size = new System.Drawing.Size(332, 21);
            this.cmbInsumo.TabIndex = 532;
            this.cmbInsumo.SelectedIndexChanged += new System.EventHandler(this.cmbInsumo_SelectedIndexChanged);
            this.cmbInsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFiltraInsPro_KeyPress);
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
            this.cmbMedida.Location = new System.Drawing.Point(202, 136);
            this.cmbMedida.Name = "cmbMedida";
            this.cmbMedida.Size = new System.Drawing.Size(117, 21);
            this.cmbMedida.TabIndex = 539;
            this.cmbMedida.SelectedIndexChanged += new System.EventHandler(this.cmbMedida_SelectedIndexChanged);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(112, 137);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(84, 20);
            this.txtCantidad.TabIndex = 540;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(112, 30);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(149, 20);
            this.dtpFecha.TabIndex = 541;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 542;
            this.label4.Text = "Fecha";
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
            this.btnBuscarResponsable.Location = new System.Drawing.Point(448, 187);
            this.btnBuscarResponsable.Name = "btnBuscarResponsable";
            this.btnBuscarResponsable.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarResponsable.TabIndex = 543;
            this.btnBuscarResponsable.UseVisualStyleBackColor = false;
            this.btnBuscarResponsable.Click += new System.EventHandler(this.btnBuscarResponsable_Click);
            // 
            // txtBuscarResponsable
            // 
            this.txtBuscarResponsable.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscarResponsable.Location = new System.Drawing.Point(136, 202);
            this.txtBuscarResponsable.Name = "txtBuscarResponsable";
            this.txtBuscarResponsable.Size = new System.Drawing.Size(308, 20);
            this.txtBuscarResponsable.TabIndex = 544;
            this.txtBuscarResponsable.Visible = false;
            this.txtBuscarResponsable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarResponsable_KeyPress);
            // 
            // btnCancelarEdicion
            // 
            this.btnCancelarEdicion.BackColor = System.Drawing.Color.MistyRose;
            this.btnCancelarEdicion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelarEdicion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarEdicion.Location = new System.Drawing.Point(242, 302);
            this.btnCancelarEdicion.Name = "btnCancelarEdicion";
            this.btnCancelarEdicion.Size = new System.Drawing.Size(226, 48);
            this.btnCancelarEdicion.TabIndex = 546;
            this.btnCancelarEdicion.Text = "Cancelar Edición";
            this.btnCancelarEdicion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelarEdicion.Visible = false;
            this.btnCancelarEdicion.Click += new System.EventHandler(this.btnCancelarEdicion_Click);
            // 
            // frmIngresoDeInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1162, 690);
            this.Controls.Add(this.btnCancelarEdicion);
            this.Controls.Add(this.txtBuscarResponsable);
            this.Controls.Add(this.btnBuscarResponsable);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cmbMedida);
            this.Controls.Add(this.txtBuscaInsPro);
            this.Controls.Add(this.btnBuscarInsPro);
            this.Controls.Add(this.cmbInsumo);
            this.Controls.Add(this.btnEditarRegistro);
            this.Controls.Add(this.btnEditarLista);
            this.Controls.Add(this.cmbResponsable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCargarEnLista);
            this.Controls.Add(this.btnCargarInsumosDefinitivo);
            this.Controls.Add(this.btnLimpliarLista);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvInsumos);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmIngresoDeInsumos";
            this.Text = "frmIngresoDeInsumos";
            this.Load += new System.EventHandler(this.frmIngresoDeInsumos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEditarRegistro;
        private System.Windows.Forms.Button btnEditarLista;
        private System.Windows.Forms.ComboBox cmbResponsable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCargarEnLista;
        private System.Windows.Forms.Button btnCargarInsumosDefinitivo;
        private System.Windows.Forms.Button btnLimpliarLista;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvInsumos;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBuscaInsPro;
        private System.Windows.Forms.Button btnBuscarInsPro;
        private System.Windows.Forms.ComboBox cmbInsumo;
        private System.Windows.Forms.ComboBox cmbMedida;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscarResponsable;
        private System.Windows.Forms.TextBox txtBuscarResponsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID_Responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedidaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResponsable;
        private System.Windows.Forms.Button btnCancelarEdicion;
    }
}