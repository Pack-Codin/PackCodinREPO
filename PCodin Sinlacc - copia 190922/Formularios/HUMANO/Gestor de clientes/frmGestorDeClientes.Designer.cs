namespace PCodin_Sinlacc.Formularios
{
    partial class frmGestorDeClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestorDeClientes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnMostrarfiltros = new System.Windows.Forms.Button();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.pnlFiltroGeneral = new System.Windows.Forms.Panel();
            this.cmbFiltraZona = new System.Windows.Forms.ComboBox();
            this.chkFiltraZona = new System.Windows.Forms.CheckBox();
            this.txtFiltraDescripcion = new System.Windows.Forms.TextBox();
            this.chkFiltraDescripcion = new System.Windows.Forms.CheckBox();
            this.cmbFiltaTipoCliente = new System.Windows.Forms.ComboBox();
            this.chkFiltraCiudad = new System.Windows.Forms.CheckBox();
            this.chkFiltraTipoCliente = new System.Windows.Forms.CheckBox();
            this.cmbFiltraCiudad = new System.Windows.Forms.ComboBox();
            this.btnBuscarCiudad = new System.Windows.Forms.Button();
            this.chkFiltraEstado = new System.Windows.Forms.CheckBox();
            this.txtBuscaCiudad = new System.Windows.Forms.TextBox();
            this.cmbFiltraEstado = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblfiltros = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarEmpleado = new System.Windows.Forms.Button();
            this.btnBuscarDesc = new System.Windows.Forms.Button();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.btnBuscarAsc = new System.Windows.Forms.Button();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.gbxFiltros.SuspendLayout();
            this.pnlFiltroGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
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
            this.btnMostrarfiltros.Location = new System.Drawing.Point(667, 3);
            this.btnMostrarfiltros.Name = "btnMostrarfiltros";
            this.btnMostrarfiltros.Size = new System.Drawing.Size(492, 35);
            this.btnMostrarfiltros.TabIndex = 521;
            this.btnMostrarfiltros.Text = "Mostrar Filtros";
            this.btnMostrarfiltros.UseVisualStyleBackColor = false;
            this.btnMostrarfiltros.Click += new System.EventHandler(this.btnMostrarfiltros_Click);
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbxFiltros.Controls.Add(this.pnlFiltroGeneral);
            this.gbxFiltros.Controls.Add(this.textBox4);
            this.gbxFiltros.Controls.Add(this.lblfiltros);
            this.gbxFiltros.Controls.Add(this.btnBuscar);
            this.gbxFiltros.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbxFiltros.Location = new System.Drawing.Point(663, 4);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Size = new System.Drawing.Size(495, 604);
            this.gbxFiltros.TabIndex = 520;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Visible = false;
            // 
            // pnlFiltroGeneral
            // 
            this.pnlFiltroGeneral.Controls.Add(this.cmbFiltraZona);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraZona);
            this.pnlFiltroGeneral.Controls.Add(this.txtFiltraDescripcion);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraDescripcion);
            this.pnlFiltroGeneral.Controls.Add(this.cmbFiltaTipoCliente);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraCiudad);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraTipoCliente);
            this.pnlFiltroGeneral.Controls.Add(this.cmbFiltraCiudad);
            this.pnlFiltroGeneral.Controls.Add(this.btnBuscarCiudad);
            this.pnlFiltroGeneral.Controls.Add(this.chkFiltraEstado);
            this.pnlFiltroGeneral.Controls.Add(this.txtBuscaCiudad);
            this.pnlFiltroGeneral.Controls.Add(this.cmbFiltraEstado);
            this.pnlFiltroGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltroGeneral.Location = new System.Drawing.Point(3, 68);
            this.pnlFiltroGeneral.Name = "pnlFiltroGeneral";
            this.pnlFiltroGeneral.Size = new System.Drawing.Size(489, 246);
            this.pnlFiltroGeneral.TabIndex = 567;
            // 
            // cmbFiltraZona
            // 
            this.cmbFiltraZona.BackColor = System.Drawing.Color.White;
            this.cmbFiltraZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraZona.Enabled = false;
            this.cmbFiltraZona.FormattingEnabled = true;
            this.cmbFiltraZona.Location = new System.Drawing.Point(111, 87);
            this.cmbFiltraZona.Name = "cmbFiltraZona";
            this.cmbFiltraZona.Size = new System.Drawing.Size(335, 21);
            this.cmbFiltraZona.TabIndex = 583;
            // 
            // chkFiltraZona
            // 
            this.chkFiltraZona.AutoSize = true;
            this.chkFiltraZona.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraZona.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraZona.Location = new System.Drawing.Point(54, 90);
            this.chkFiltraZona.Name = "chkFiltraZona";
            this.chkFiltraZona.Size = new System.Drawing.Size(51, 17);
            this.chkFiltraZona.TabIndex = 584;
            this.chkFiltraZona.Text = "Zona";
            this.chkFiltraZona.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraZona.UseVisualStyleBackColor = false;
            this.chkFiltraZona.CheckedChanged += new System.EventHandler(this.chkFiltraZona_CheckedChanged);
            // 
            // txtFiltraDescripcion
            // 
            this.txtFiltraDescripcion.Enabled = false;
            this.txtFiltraDescripcion.Location = new System.Drawing.Point(111, 33);
            this.txtFiltraDescripcion.Name = "txtFiltraDescripcion";
            this.txtFiltraDescripcion.Size = new System.Drawing.Size(335, 20);
            this.txtFiltraDescripcion.TabIndex = 53;
            this.txtFiltraDescripcion.Click += new System.EventHandler(this.txtFiltraDescripcion_Click);
            // 
            // chkFiltraDescripcion
            // 
            this.chkFiltraDescripcion.AutoSize = true;
            this.chkFiltraDescripcion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraDescripcion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraDescripcion.Location = new System.Drawing.Point(42, 34);
            this.chkFiltraDescripcion.Name = "chkFiltraDescripcion";
            this.chkFiltraDescripcion.Size = new System.Drawing.Size(63, 17);
            this.chkFiltraDescripcion.TabIndex = 38;
            this.chkFiltraDescripcion.Text = "Nombre";
            this.chkFiltraDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraDescripcion.UseVisualStyleBackColor = false;
            this.chkFiltraDescripcion.CheckedChanged += new System.EventHandler(this.chkFiltraDescripcion_CheckedChanged);
            // 
            // cmbFiltaTipoCliente
            // 
            this.cmbFiltaTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltaTipoCliente.FormattingEnabled = true;
            this.cmbFiltaTipoCliente.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbFiltaTipoCliente.Location = new System.Drawing.Point(111, 118);
            this.cmbFiltaTipoCliente.Name = "cmbFiltaTipoCliente";
            this.cmbFiltaTipoCliente.Size = new System.Drawing.Size(113, 21);
            this.cmbFiltaTipoCliente.TabIndex = 566;
            // 
            // chkFiltraCiudad
            // 
            this.chkFiltraCiudad.AutoSize = true;
            this.chkFiltraCiudad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraCiudad.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraCiudad.Location = new System.Drawing.Point(46, 61);
            this.chkFiltraCiudad.Name = "chkFiltraCiudad";
            this.chkFiltraCiudad.Size = new System.Drawing.Size(59, 17);
            this.chkFiltraCiudad.TabIndex = 42;
            this.chkFiltraCiudad.Text = "Ciudad";
            this.chkFiltraCiudad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraCiudad.UseVisualStyleBackColor = false;
            this.chkFiltraCiudad.CheckedChanged += new System.EventHandler(this.chkFiltraCiudad_CheckedChanged);
            // 
            // chkFiltraTipoCliente
            // 
            this.chkFiltraTipoCliente.AutoSize = true;
            this.chkFiltraTipoCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraTipoCliente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraTipoCliente.Location = new System.Drawing.Point(58, 120);
            this.chkFiltraTipoCliente.Name = "chkFiltraTipoCliente";
            this.chkFiltraTipoCliente.Size = new System.Drawing.Size(47, 17);
            this.chkFiltraTipoCliente.TabIndex = 565;
            this.chkFiltraTipoCliente.Text = "Tipo";
            this.chkFiltraTipoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraTipoCliente.UseVisualStyleBackColor = false;
            this.chkFiltraTipoCliente.CheckedChanged += new System.EventHandler(this.chkTipo_CheckedChanged);
            // 
            // cmbFiltraCiudad
            // 
            this.cmbFiltraCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraCiudad.Enabled = false;
            this.cmbFiltraCiudad.FormattingEnabled = true;
            this.cmbFiltraCiudad.Location = new System.Drawing.Point(111, 59);
            this.cmbFiltraCiudad.Name = "cmbFiltraCiudad";
            this.cmbFiltraCiudad.Size = new System.Drawing.Size(335, 21);
            this.cmbFiltraCiudad.TabIndex = 43;
            this.cmbFiltraCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFiltraCiudad_KeyPress);
            // 
            // btnBuscarCiudad
            // 
            this.btnBuscarCiudad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarCiudad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCiudad.BackgroundImage")));
            this.btnBuscarCiudad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarCiudad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCiudad.Enabled = false;
            this.btnBuscarCiudad.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarCiudad.FlatAppearance.BorderSize = 0;
            this.btnBuscarCiudad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCiudad.Location = new System.Drawing.Point(452, 58);
            this.btnBuscarCiudad.Name = "btnBuscarCiudad";
            this.btnBuscarCiudad.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCiudad.TabIndex = 564;
            this.btnBuscarCiudad.UseVisualStyleBackColor = false;
            this.btnBuscarCiudad.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkFiltraEstado
            // 
            this.chkFiltraEstado.AutoSize = true;
            this.chkFiltraEstado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraEstado.Checked = true;
            this.chkFiltraEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiltraEstado.Location = new System.Drawing.Point(49, 147);
            this.chkFiltraEstado.Name = "chkFiltraEstado";
            this.chkFiltraEstado.Size = new System.Drawing.Size(56, 17);
            this.chkFiltraEstado.TabIndex = 44;
            this.chkFiltraEstado.Text = "Activo";
            this.chkFiltraEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraEstado.UseVisualStyleBackColor = false;
            this.chkFiltraEstado.CheckedChanged += new System.EventHandler(this.chkFiltraEstado_CheckedChanged);
            // 
            // txtBuscaCiudad
            // 
            this.txtBuscaCiudad.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscaCiudad.Enabled = false;
            this.txtBuscaCiudad.Location = new System.Drawing.Point(111, 60);
            this.txtBuscaCiudad.Name = "txtBuscaCiudad";
            this.txtBuscaCiudad.Size = new System.Drawing.Size(335, 20);
            this.txtBuscaCiudad.TabIndex = 512;
            this.txtBuscaCiudad.Visible = false;
            this.txtBuscaCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaCiudad_KeyPress);
            // 
            // cmbFiltraEstado
            // 
            this.cmbFiltraEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraEstado.FormattingEnabled = true;
            this.cmbFiltraEstado.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbFiltraEstado.Location = new System.Drawing.Point(111, 145);
            this.cmbFiltraEstado.Name = "cmbFiltraEstado";
            this.cmbFiltraEstado.Size = new System.Drawing.Size(113, 21);
            this.cmbFiltraEstado.TabIndex = 45;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Black;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(3, 45);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(489, 23);
            this.textBox4.TabIndex = 511;
            this.textBox4.Text = "General";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblfiltros
            // 
            this.lblfiltros.AutoSize = true;
            this.lblfiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblfiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblfiltros.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfiltros.ForeColor = System.Drawing.Color.Teal;
            this.lblfiltros.Location = new System.Drawing.Point(3, 16);
            this.lblfiltros.Name = "lblfiltros";
            this.lblfiltros.Size = new System.Drawing.Size(74, 29);
            this.lblfiltros.TabIndex = 510;
            this.lblfiltros.Text = "Filtros";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnBuscar.FlatAppearance.BorderSize = 2;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(3, 564);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(489, 37);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExportarExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.BackgroundImage")));
            this.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarExcel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExportarExcel.FlatAppearance.BorderSize = 0;
            this.btnExportarExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Location = new System.Drawing.Point(140, 4);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(30, 28);
            this.btnExportarExcel.TabIndex = 519;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(76, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(30, 28);
            this.btnEliminar.TabIndex = 518;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Transparent;
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Location = new System.Drawing.Point(40, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(30, 28);
            this.btnEditar.TabIndex = 517;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox18.Location = new System.Drawing.Point(123, 10);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(2, 21);
            this.pictureBox18.TabIndex = 516;
            this.pictureBox18.TabStop = false;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClientes.ColumnHeadersHeight = 26;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colCliente,
            this.colTipo,
            this.colCiudad,
            this.colZona,
            this.colEstado,
            this.colTelefono,
            this.colEmail,
            this.colObservaciones});
            this.dgvClientes.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientes.EnableHeadersVisualStyles = false;
            this.dgvClientes.GridColor = System.Drawing.Color.Teal;
            this.dgvClientes.Location = new System.Drawing.Point(4, 6);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowHeadersWidth = 38;
            this.dgvClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvClientes.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(659, 602);
            this.dgvClientes.TabIndex = 515;
            this.dgvClientes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentDoubleClick);
            this.dgvClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellDoubleClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.Width = 250;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            // 
            // colCiudad
            // 
            this.colCiudad.HeaderText = "Ciudad";
            this.colCiudad.Name = "colCiudad";
            this.colCiudad.Width = 200;
            // 
            // colZona
            // 
            this.colZona.HeaderText = "Zona";
            this.colZona.Name = "colZona";
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Activo";
            this.colEstado.Name = "colEstado";
            this.colEstado.Width = 60;
            // 
            // colTelefono
            // 
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.Width = 150;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Width = 200;
            // 
            // colObservaciones
            // 
            this.colObservaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colObservaciones.HeaderText = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.Width = 350;
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarEmpleado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarEmpleado.BackgroundImage")));
            this.btnAgregarEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAgregarEmpleado.FlatAppearance.BorderSize = 0;
            this.btnAgregarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnAgregarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(4, 3);
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(30, 28);
            this.btnAgregarEmpleado.TabIndex = 514;
            this.btnAgregarEmpleado.UseVisualStyleBackColor = false;
            this.btnAgregarEmpleado.Click += new System.EventHandler(this.btnAgregarEmpleado_Click);
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
            this.btnBuscarDesc.Location = new System.Drawing.Point(884, 6);
            this.btnBuscarDesc.Name = "btnBuscarDesc";
            this.btnBuscarDesc.Size = new System.Drawing.Size(31, 26);
            this.btnBuscarDesc.TabIndex = 582;
            this.btnBuscarDesc.UseVisualStyleBackColor = false;
            this.btnBuscarDesc.Visible = false;
            this.btnBuscarDesc.Click += new System.EventHandler(this.btnBuscarDesc_Click);
            // 
            // cmbOrdenar
            // 
            this.cmbOrdenar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOrdenar.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenar.FormattingEnabled = true;
            this.cmbOrdenar.Items.AddRange(new object[] {
            "",
            "Cliente",
            "Tipo",
            "Ciudad",
            "Estado"});
            this.cmbOrdenar.Location = new System.Drawing.Point(921, 10);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(229, 21);
            this.cmbOrdenar.TabIndex = 581;
            this.cmbOrdenar.SelectedIndexChanged += new System.EventHandler(this.cmbOrdenar_SelectedIndexChanged);
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
            this.btnBuscarAsc.Location = new System.Drawing.Point(884, 7);
            this.btnBuscarAsc.Name = "btnBuscarAsc";
            this.btnBuscarAsc.Size = new System.Drawing.Size(31, 26);
            this.btnBuscarAsc.TabIndex = 580;
            this.btnBuscarAsc.UseVisualStyleBackColor = false;
            this.btnBuscarAsc.Click += new System.EventHandler(this.btnBuscarAsc_Click);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.lblResultados);
            this.pnlInferior.Controls.Add(this.label1);
            this.pnlInferior.Controls.Add(this.btnMostrarfiltros);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 649);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(3);
            this.pnlInferior.Size = new System.Drawing.Size(1162, 41);
            this.pnlInferior.TabIndex = 583;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoEllipsis = true;
            this.lblResultados.BackColor = System.Drawing.Color.Transparent;
            this.lblResultados.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblResultados.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultados.ForeColor = System.Drawing.Color.Black;
            this.lblResultados.Location = new System.Drawing.Point(138, 3);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(88, 35);
            this.lblResultados.TabIndex = 496;
            this.lblResultados.Text = "0";
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 35);
            this.label1.TabIndex = 495;
            this.label1.Text = "Cantidad";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCentral
            // 
            this.pnlCentral.Controls.Add(this.dgvClientes);
            this.pnlCentral.Controls.Add(this.pnlLinea);
            this.pnlCentral.Controls.Add(this.gbxFiltros);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(0, 37);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Padding = new System.Windows.Forms.Padding(4);
            this.pnlCentral.Size = new System.Drawing.Size(1162, 612);
            this.pnlCentral.TabIndex = 584;
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnlLinea.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLinea.Location = new System.Drawing.Point(4, 4);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(659, 2);
            this.pnlLinea.TabIndex = 672;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.btnBuscarDesc);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1162, 37);
            this.pnlSuperior.TabIndex = 585;
            // 
            // frmGestorDeClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1162, 690);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.cmbOrdenar);
            this.Controls.Add(this.btnBuscarAsc);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.pictureBox18);
            this.Controls.Add(this.btnAgregarEmpleado);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGestorDeClientes";
            this.Text = "frmGestorDeClientes";
            this.Load += new System.EventHandler(this.frmGestorDeClientes_Load);
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.pnlFiltroGeneral.ResumeLayout(false);
            this.pnlFiltroGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.pnlCentral.ResumeLayout(false);
            this.pnlSuperior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMostrarfiltros;
        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.Label lblfiltros;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtFiltraDescripcion;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbFiltraEstado;
        private System.Windows.Forms.CheckBox chkFiltraEstado;
        private System.Windows.Forms.ComboBox cmbFiltraCiudad;
        private System.Windows.Forms.CheckBox chkFiltraCiudad;
        private System.Windows.Forms.CheckBox chkFiltraDescripcion;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnAgregarEmpleado;
        private System.Windows.Forms.TextBox txtBuscaCiudad;
        private System.Windows.Forms.Button btnBuscarCiudad;
        private System.Windows.Forms.Button btnBuscarDesc;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.Button btnBuscarAsc;
        private System.Windows.Forms.ComboBox cmbFiltaTipoCliente;
        private System.Windows.Forms.CheckBox chkFiltraTipoCliente;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel pnlFiltroGeneral;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZona;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private System.Windows.Forms.ComboBox cmbFiltraZona;
        private System.Windows.Forms.CheckBox chkFiltraZona;
    }
}