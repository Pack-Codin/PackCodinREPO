namespace PCodin_Sinlacc.Formularios
{
    partial class frmHistorialInsumos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistorialInsumos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEliminarInsumo = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.dgvHistorialInsumos = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInsumo_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResponsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.chkFiltraResponsable = new System.Windows.Forms.CheckBox();
            this.txtBuscarResponsable = new System.Windows.Forms.TextBox();
            this.btnBuscarResponsable = new System.Windows.Forms.Button();
            this.cmbFiltraResponsable = new System.Windows.Forms.ComboBox();
            this.txtBuscaInsPro = new System.Windows.Forms.TextBox();
            this.txtBuscaCategoria = new System.Windows.Forms.TextBox();
            this.chkMuestraInsProActInac = new System.Windows.Forms.CheckBox();
            this.chkMuestraCategActivasInact = new System.Windows.Forms.CheckBox();
            this.btnBuscarCategoria = new System.Windows.Forms.Button();
            this.btnBuscarInsPro = new System.Windows.Forms.Button();
            this.chkFiltraInsPro = new System.Windows.Forms.CheckBox();
            this.cmbFiltraInsPro = new System.Windows.Forms.ComboBox();
            this.lblfiltros = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cmbFiltraCategoria = new System.Windows.Forms.ComboBox();
            this.chkFiltraCategoria = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbFiltraMedida = new System.Windows.Forms.ComboBox();
            this.chkFiltraMedida = new System.Windows.Forms.CheckBox();
            this.btnMostrarfiltros = new System.Windows.Forms.Button();
            this.txtResultados = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialInsumos)).BeginInit();
            this.gbxFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEliminarInsumo
            // 
            this.btnEliminarInsumo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnEliminarInsumo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarInsumo.BackgroundImage")));
            this.btnEliminarInsumo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminarInsumo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarInsumo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEliminarInsumo.FlatAppearance.BorderSize = 0;
            this.btnEliminarInsumo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEliminarInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarInsumo.Location = new System.Drawing.Point(3, 1);
            this.btnEliminarInsumo.Name = "btnEliminarInsumo";
            this.btnEliminarInsumo.Size = new System.Drawing.Size(34, 28);
            this.btnEliminarInsumo.TabIndex = 447;
            this.btnEliminarInsumo.UseVisualStyleBackColor = false;
            this.btnEliminarInsumo.Click += new System.EventHandler(this.btnEliminarInsumo_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox7.Location = new System.Drawing.Point(0, -1);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(1162, 32);
            this.pictureBox7.TabIndex = 445;
            this.pictureBox7.TabStop = false;
            // 
            // dgvHistorialInsumos
            // 
            this.dgvHistorialInsumos.AllowUserToAddRows = false;
            this.dgvHistorialInsumos.AllowUserToOrderColumns = true;
            this.dgvHistorialInsumos.AllowUserToResizeColumns = false;
            this.dgvHistorialInsumos.AllowUserToResizeRows = false;
            this.dgvHistorialInsumos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorialInsumos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvHistorialInsumos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvHistorialInsumos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorialInsumos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistorialInsumos.ColumnHeadersHeight = 26;
            this.dgvHistorialInsumos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colInsumo_ID,
            this.colFecha,
            this.colInsumo,
            this.colCantidad,
            this.colMedida,
            this.colResponsable});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistorialInsumos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistorialInsumos.EnableHeadersVisualStyles = false;
            this.dgvHistorialInsumos.GridColor = System.Drawing.Color.Teal;
            this.dgvHistorialInsumos.Location = new System.Drawing.Point(0, 31);
            this.dgvHistorialInsumos.Name = "dgvHistorialInsumos";
            this.dgvHistorialInsumos.ReadOnly = true;
            this.dgvHistorialInsumos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvHistorialInsumos.RowHeadersVisible = false;
            this.dgvHistorialInsumos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialInsumos.Size = new System.Drawing.Size(1162, 631);
            this.dgvHistorialInsumos.TabIndex = 442;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colInsumo_ID
            // 
            this.colInsumo_ID.HeaderText = "Insumo_ID";
            this.colInsumo_ID.Name = "colInsumo_ID";
            this.colInsumo_ID.ReadOnly = true;
            this.colInsumo_ID.Visible = false;
            // 
            // colFecha
            // 
            this.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFecha.FillWeight = 80F;
            this.colFecha.HeaderText = "Fecha De Carga";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colInsumo
            // 
            this.colInsumo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInsumo.FillWeight = 250F;
            this.colInsumo.HeaderText = "Insumo";
            this.colInsumo.Name = "colInsumo";
            this.colInsumo.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colMedida
            // 
            this.colMedida.HeaderText = "Medida";
            this.colMedida.Name = "colMedida";
            this.colMedida.ReadOnly = true;
            // 
            // colResponsable
            // 
            this.colResponsable.HeaderText = "Responsable";
            this.colResponsable.Name = "colResponsable";
            this.colResponsable.ReadOnly = true;
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.BackColor = System.Drawing.Color.Silver;
            this.gbxFiltros.Controls.Add(this.chkFiltraResponsable);
            this.gbxFiltros.Controls.Add(this.txtBuscarResponsable);
            this.gbxFiltros.Controls.Add(this.btnBuscarResponsable);
            this.gbxFiltros.Controls.Add(this.cmbFiltraResponsable);
            this.gbxFiltros.Controls.Add(this.txtBuscaInsPro);
            this.gbxFiltros.Controls.Add(this.txtBuscaCategoria);
            this.gbxFiltros.Controls.Add(this.chkMuestraInsProActInac);
            this.gbxFiltros.Controls.Add(this.chkMuestraCategActivasInact);
            this.gbxFiltros.Controls.Add(this.btnBuscarCategoria);
            this.gbxFiltros.Controls.Add(this.btnBuscarInsPro);
            this.gbxFiltros.Controls.Add(this.chkFiltraInsPro);
            this.gbxFiltros.Controls.Add(this.cmbFiltraInsPro);
            this.gbxFiltros.Controls.Add(this.lblfiltros);
            this.gbxFiltros.Controls.Add(this.textBox4);
            this.gbxFiltros.Controls.Add(this.cmbFiltraCategoria);
            this.gbxFiltros.Controls.Add(this.chkFiltraCategoria);
            this.gbxFiltros.Controls.Add(this.btnBuscar);
            this.gbxFiltros.Controls.Add(this.cmbFiltraMedida);
            this.gbxFiltros.Controls.Add(this.chkFiltraMedida);
            this.gbxFiltros.Location = new System.Drawing.Point(636, 393);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Size = new System.Drawing.Size(525, 269);
            this.gbxFiltros.TabIndex = 486;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Visible = false;
            // 
            // chkFiltraResponsable
            // 
            this.chkFiltraResponsable.AutoSize = true;
            this.chkFiltraResponsable.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraResponsable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraResponsable.Location = new System.Drawing.Point(23, 197);
            this.chkFiltraResponsable.Name = "chkFiltraResponsable";
            this.chkFiltraResponsable.Size = new System.Drawing.Size(88, 17);
            this.chkFiltraResponsable.TabIndex = 548;
            this.chkFiltraResponsable.Text = "Responsable";
            this.chkFiltraResponsable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraResponsable.UseVisualStyleBackColor = false;
            this.chkFiltraResponsable.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtBuscarResponsable
            // 
            this.txtBuscarResponsable.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscarResponsable.Location = new System.Drawing.Point(120, 193);
            this.txtBuscarResponsable.Name = "txtBuscarResponsable";
            this.txtBuscarResponsable.Size = new System.Drawing.Size(332, 20);
            this.txtBuscarResponsable.TabIndex = 547;
            this.txtBuscarResponsable.Visible = false;
            this.txtBuscarResponsable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarResponsable_KeyPress);
            // 
            // btnBuscarResponsable
            // 
            this.btnBuscarResponsable.BackColor = System.Drawing.Color.Silver;
            this.btnBuscarResponsable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarResponsable.BackgroundImage")));
            this.btnBuscarResponsable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarResponsable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarResponsable.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarResponsable.FlatAppearance.BorderSize = 0;
            this.btnBuscarResponsable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarResponsable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarResponsable.Location = new System.Drawing.Point(458, 194);
            this.btnBuscarResponsable.Name = "btnBuscarResponsable";
            this.btnBuscarResponsable.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarResponsable.TabIndex = 546;
            this.btnBuscarResponsable.UseVisualStyleBackColor = false;
            this.btnBuscarResponsable.Click += new System.EventHandler(this.btnBuscarResponsable_Click);
            // 
            // cmbFiltraResponsable
            // 
            this.cmbFiltraResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraResponsable.FormattingEnabled = true;
            this.cmbFiltraResponsable.Location = new System.Drawing.Point(120, 193);
            this.cmbFiltraResponsable.Name = "cmbFiltraResponsable";
            this.cmbFiltraResponsable.Size = new System.Drawing.Size(332, 21);
            this.cmbFiltraResponsable.TabIndex = 545;
            this.cmbFiltraResponsable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFiltraResponsable_KeyPress);
            // 
            // txtBuscaInsPro
            // 
            this.txtBuscaInsPro.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscaInsPro.Location = new System.Drawing.Point(120, 46);
            this.txtBuscaInsPro.Name = "txtBuscaInsPro";
            this.txtBuscaInsPro.Size = new System.Drawing.Size(332, 20);
            this.txtBuscaInsPro.TabIndex = 531;
            this.txtBuscaInsPro.Visible = false;
            this.txtBuscaInsPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaInsPro_KeyPress);
            // 
            // txtBuscaCategoria
            // 
            this.txtBuscaCategoria.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscaCategoria.Location = new System.Drawing.Point(120, 102);
            this.txtBuscaCategoria.Name = "txtBuscaCategoria";
            this.txtBuscaCategoria.Size = new System.Drawing.Size(332, 20);
            this.txtBuscaCategoria.TabIndex = 532;
            this.txtBuscaCategoria.Visible = false;
            this.txtBuscaCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaCategoria_KeyPress);
            // 
            // chkMuestraInsProActInac
            // 
            this.chkMuestraInsProActInac.AutoSize = true;
            this.chkMuestraInsProActInac.Checked = true;
            this.chkMuestraInsProActInac.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMuestraInsProActInac.Enabled = false;
            this.chkMuestraInsProActInac.Location = new System.Drawing.Point(120, 72);
            this.chkMuestraInsProActInac.Name = "chkMuestraInsProActInac";
            this.chkMuestraInsProActInac.Size = new System.Drawing.Size(139, 17);
            this.chkMuestraInsProActInac.TabIndex = 532;
            this.chkMuestraInsProActInac.Text = "Muestra Ins/Pro activos";
            this.chkMuestraInsProActInac.UseVisualStyleBackColor = true;
            // 
            // chkMuestraCategActivasInact
            // 
            this.chkMuestraCategActivasInact.AutoSize = true;
            this.chkMuestraCategActivasInact.Checked = true;
            this.chkMuestraCategActivasInact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMuestraCategActivasInact.Enabled = false;
            this.chkMuestraCategActivasInact.Location = new System.Drawing.Point(120, 130);
            this.chkMuestraCategActivasInact.Name = "chkMuestraCategActivasInact";
            this.chkMuestraCategActivasInact.Size = new System.Drawing.Size(180, 17);
            this.chkMuestraCategActivasInact.TabIndex = 531;
            this.chkMuestraCategActivasInact.Text = "Muestra solo categorías  activas";
            this.chkMuestraCategActivasInact.UseVisualStyleBackColor = true;
            // 
            // btnBuscarCategoria
            // 
            this.btnBuscarCategoria.BackColor = System.Drawing.Color.Silver;
            this.btnBuscarCategoria.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCategoria.BackgroundImage")));
            this.btnBuscarCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCategoria.Enabled = false;
            this.btnBuscarCategoria.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarCategoria.FlatAppearance.BorderSize = 0;
            this.btnBuscarCategoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCategoria.Location = new System.Drawing.Point(458, 104);
            this.btnBuscarCategoria.Name = "btnBuscarCategoria";
            this.btnBuscarCategoria.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarCategoria.TabIndex = 530;
            this.btnBuscarCategoria.UseVisualStyleBackColor = false;
            this.btnBuscarCategoria.Click += new System.EventHandler(this.btnBuscarCategoria_Click);
            // 
            // btnBuscarInsPro
            // 
            this.btnBuscarInsPro.BackColor = System.Drawing.Color.Silver;
            this.btnBuscarInsPro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarInsPro.BackgroundImage")));
            this.btnBuscarInsPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarInsPro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarInsPro.Enabled = false;
            this.btnBuscarInsPro.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarInsPro.FlatAppearance.BorderSize = 0;
            this.btnBuscarInsPro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarInsPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarInsPro.Location = new System.Drawing.Point(458, 47);
            this.btnBuscarInsPro.Name = "btnBuscarInsPro";
            this.btnBuscarInsPro.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarInsPro.TabIndex = 529;
            this.btnBuscarInsPro.UseVisualStyleBackColor = false;
            this.btnBuscarInsPro.Click += new System.EventHandler(this.btnBuscarInsPro_Click);
            // 
            // chkFiltraInsPro
            // 
            this.chkFiltraInsPro.AutoSize = true;
            this.chkFiltraInsPro.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraInsPro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraInsPro.Location = new System.Drawing.Point(51, 47);
            this.chkFiltraInsPro.Name = "chkFiltraInsPro";
            this.chkFiltraInsPro.Size = new System.Drawing.Size(60, 17);
            this.chkFiltraInsPro.TabIndex = 460;
            this.chkFiltraInsPro.Text = "Insumo";
            this.chkFiltraInsPro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraInsPro.UseVisualStyleBackColor = false;
            this.chkFiltraInsPro.CheckedChanged += new System.EventHandler(this.chkFiltraInsPro_CheckedChanged);
            // 
            // cmbFiltraInsPro
            // 
            this.cmbFiltraInsPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraInsPro.Enabled = false;
            this.cmbFiltraInsPro.FormattingEnabled = true;
            this.cmbFiltraInsPro.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbFiltraInsPro.Location = new System.Drawing.Point(120, 45);
            this.cmbFiltraInsPro.Name = "cmbFiltraInsPro";
            this.cmbFiltraInsPro.Size = new System.Drawing.Size(332, 21);
            this.cmbFiltraInsPro.TabIndex = 458;
            this.cmbFiltraInsPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFiltraInsPro_KeyPress);
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
            // cmbFiltraCategoria
            // 
            this.cmbFiltraCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraCategoria.Enabled = false;
            this.cmbFiltraCategoria.FormattingEnabled = true;
            this.cmbFiltraCategoria.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbFiltraCategoria.Location = new System.Drawing.Point(120, 103);
            this.cmbFiltraCategoria.Name = "cmbFiltraCategoria";
            this.cmbFiltraCategoria.Size = new System.Drawing.Size(332, 21);
            this.cmbFiltraCategoria.TabIndex = 56;
            this.cmbFiltraCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFiltraCategoria_KeyPress);
            // 
            // chkFiltraCategoria
            // 
            this.chkFiltraCategoria.AutoSize = true;
            this.chkFiltraCategoria.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraCategoria.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraCategoria.Location = new System.Drawing.Point(38, 105);
            this.chkFiltraCategoria.Name = "chkFiltraCategoria";
            this.chkFiltraCategoria.Size = new System.Drawing.Size(73, 17);
            this.chkFiltraCategoria.TabIndex = 55;
            this.chkFiltraCategoria.Text = "Categoría";
            this.chkFiltraCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraCategoria.UseVisualStyleBackColor = false;
            this.chkFiltraCategoria.CheckedChanged += new System.EventHandler(this.chkFiltraCategoria_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(0, 240);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(526, 30);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmbFiltraMedida
            // 
            this.cmbFiltraMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraMedida.Enabled = false;
            this.cmbFiltraMedida.FormattingEnabled = true;
            this.cmbFiltraMedida.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbFiltraMedida.Location = new System.Drawing.Point(120, 158);
            this.cmbFiltraMedida.Name = "cmbFiltraMedida";
            this.cmbFiltraMedida.Size = new System.Drawing.Size(199, 21);
            this.cmbFiltraMedida.TabIndex = 45;
            // 
            // chkFiltraMedida
            // 
            this.chkFiltraMedida.AutoSize = true;
            this.chkFiltraMedida.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraMedida.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraMedida.Location = new System.Drawing.Point(50, 160);
            this.chkFiltraMedida.Name = "chkFiltraMedida";
            this.chkFiltraMedida.Size = new System.Drawing.Size(61, 17);
            this.chkFiltraMedida.TabIndex = 44;
            this.chkFiltraMedida.Text = "Medida";
            this.chkFiltraMedida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraMedida.UseVisualStyleBackColor = false;
            this.chkFiltraMedida.CheckedChanged += new System.EventHandler(this.chkFiltraEstado_CheckedChanged);
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
            this.btnMostrarfiltros.Location = new System.Drawing.Point(636, 662);
            this.btnMostrarfiltros.Name = "btnMostrarfiltros";
            this.btnMostrarfiltros.Size = new System.Drawing.Size(526, 28);
            this.btnMostrarfiltros.TabIndex = 487;
            this.btnMostrarfiltros.Text = "Mostrar Filtros";
            this.btnMostrarfiltros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarfiltros.UseVisualStyleBackColor = false;
            this.btnMostrarfiltros.Click += new System.EventHandler(this.btnMostrarfiltros_Click);
            // 
            // txtResultados
            // 
            this.txtResultados.BackColor = System.Drawing.Color.Gray;
            this.txtResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultados.ForeColor = System.Drawing.Color.White;
            this.txtResultados.Location = new System.Drawing.Point(104, 662);
            this.txtResultados.Multiline = true;
            this.txtResultados.Name = "txtResultados";
            this.txtResultados.Size = new System.Drawing.Size(160, 28);
            this.txtResultados.TabIndex = 489;
            this.txtResultados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkOrange;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-3, 662);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 31);
            this.label5.TabIndex = 488;
            this.label5.Text = "Cantidad";
            // 
            // frmHistorialInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 690);
            this.Controls.Add(this.txtResultados);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbxFiltros);
            this.Controls.Add(this.btnMostrarfiltros);
            this.Controls.Add(this.btnEliminarInsumo);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.dgvHistorialInsumos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHistorialInsumos";
            this.Text = "frmHistorialInsumos";
            this.Load += new System.EventHandler(this.frmHistorialInsumos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialInsumos)).EndInit();
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEliminarInsumo;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.DataGridView dgvHistorialInsumos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsumo_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResponsable;
        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.TextBox txtBuscaInsPro;
        private System.Windows.Forms.TextBox txtBuscaCategoria;
        private System.Windows.Forms.CheckBox chkMuestraInsProActInac;
        private System.Windows.Forms.CheckBox chkMuestraCategActivasInact;
        private System.Windows.Forms.Button btnBuscarCategoria;
        private System.Windows.Forms.Button btnBuscarInsPro;
        private System.Windows.Forms.CheckBox chkFiltraInsPro;
        private System.Windows.Forms.ComboBox cmbFiltraInsPro;
        private System.Windows.Forms.Label lblfiltros;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox cmbFiltraCategoria;
        private System.Windows.Forms.CheckBox chkFiltraCategoria;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbFiltraMedida;
        private System.Windows.Forms.CheckBox chkFiltraMedida;
        private System.Windows.Forms.Button btnMostrarfiltros;
        private System.Windows.Forms.TextBox txtResultados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkFiltraResponsable;
        private System.Windows.Forms.TextBox txtBuscarResponsable;
        private System.Windows.Forms.Button btnBuscarResponsable;
        private System.Windows.Forms.ComboBox cmbFiltraResponsable;
    }
}