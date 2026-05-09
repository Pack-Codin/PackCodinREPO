namespace PCodin_Sinlacc.Formularios.MANTENIMIENTO.Registro_de_mantenimiento
{
    partial class frmRegistroMantenimientoAgregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroMantenimientoAgregar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlSuperior2 = new System.Windows.Forms.Panel();
            this.txtBuscaTipoMantenimiento = new System.Windows.Forms.TextBox();
            this.cmbTipoMantenimiento = new System.Windows.Forms.ComboBox();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.pnlSuperior22 = new System.Windows.Forms.Panel();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.pnlSuperior221 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.dgvMantenimientoTarea = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTareaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaLimite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResponsableID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResponsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.lblResultados = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnInvalidar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCargar = new System.Windows.Forms.Button();
            this.pnlSuperior.SuspendLayout();
            this.pnlSuperior2.SuspendLayout();
            this.pnlSuperior22.SuspendLayout();
            this.pnlSuperior221.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMantenimientoTarea)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSuperior.Controls.Add(this.btnVolver);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSuperior.Size = new System.Drawing.Size(1300, 30);
            this.pnlSuperior.TabIndex = 675;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVolver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVolver.BackgroundImage")));
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnVolver.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(3, 3);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(32, 24);
            this.btnVolver.TabIndex = 652;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // pnlSuperior2
            // 
            this.pnlSuperior2.BackColor = System.Drawing.Color.White;
            this.pnlSuperior2.Controls.Add(this.txtBuscaTipoMantenimiento);
            this.pnlSuperior2.Controls.Add(this.cmbTipoMantenimiento);
            this.pnlSuperior2.Controls.Add(this.btnBuscarProveedor);
            this.pnlSuperior2.Controls.Add(this.dtpFecha);
            this.pnlSuperior2.Controls.Add(this.pnlSuperior22);
            this.pnlSuperior2.Controls.Add(this.cmbEstado);
            this.pnlSuperior2.Controls.Add(this.label2);
            this.pnlSuperior2.Controls.Add(this.label1);
            this.pnlSuperior2.Controls.Add(this.label10);
            this.pnlSuperior2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior2.Location = new System.Drawing.Point(0, 30);
            this.pnlSuperior2.Name = "pnlSuperior2";
            this.pnlSuperior2.Size = new System.Drawing.Size(1300, 144);
            this.pnlSuperior2.TabIndex = 676;
            // 
            // txtBuscaTipoMantenimiento
            // 
            this.txtBuscaTipoMantenimiento.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscaTipoMantenimiento.Location = new System.Drawing.Point(128, 53);
            this.txtBuscaTipoMantenimiento.Name = "txtBuscaTipoMantenimiento";
            this.txtBuscaTipoMantenimiento.Size = new System.Drawing.Size(405, 20);
            this.txtBuscaTipoMantenimiento.TabIndex = 672;
            this.txtBuscaTipoMantenimiento.Visible = false;
            this.txtBuscaTipoMantenimiento.Click += new System.EventHandler(this.txtBuscaTipoMantenimiento_Click);
            // 
            // cmbTipoMantenimiento
            // 
            this.cmbTipoMantenimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMantenimiento.FormattingEnabled = true;
            this.cmbTipoMantenimiento.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbTipoMantenimiento.Location = new System.Drawing.Point(128, 54);
            this.cmbTipoMantenimiento.Name = "cmbTipoMantenimiento";
            this.cmbTipoMantenimiento.Size = new System.Drawing.Size(405, 21);
            this.cmbTipoMantenimiento.TabIndex = 670;
            this.cmbTipoMantenimiento.SelectedIndexChanged += new System.EventHandler(this.cmbFiltraTipoMantenimiento_SelectedIndexChanged);
            this.cmbTipoMantenimiento.Click += new System.EventHandler(this.cmbFiltraTipoMantenimiento_Click);
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.BackColor = System.Drawing.Color.White;
            this.btnBuscarProveedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarProveedor.BackgroundImage")));
            this.btnBuscarProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarProveedor.Enabled = false;
            this.btnBuscarProveedor.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarProveedor.FlatAppearance.BorderSize = 0;
            this.btnBuscarProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProveedor.Location = new System.Drawing.Point(539, 55);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarProveedor.TabIndex = 671;
            this.btnBuscarProveedor.UseVisualStyleBackColor = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(128, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(131, 22);
            this.dtpFecha.TabIndex = 669;
            // 
            // pnlSuperior22
            // 
            this.pnlSuperior22.Controls.Add(this.txtObservaciones);
            this.pnlSuperior22.Controls.Add(this.pnlSuperior221);
            this.pnlSuperior22.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSuperior22.Location = new System.Drawing.Point(832, 0);
            this.pnlSuperior22.Name = "pnlSuperior22";
            this.pnlSuperior22.Padding = new System.Windows.Forms.Padding(4);
            this.pnlSuperior22.Size = new System.Drawing.Size(468, 144);
            this.pnlSuperior22.TabIndex = 668;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservaciones.Location = new System.Drawing.Point(4, 33);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(460, 107);
            this.txtObservaciones.TabIndex = 654;
            // 
            // pnlSuperior221
            // 
            this.pnlSuperior221.Controls.Add(this.label3);
            this.pnlSuperior221.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior221.Location = new System.Drawing.Point(4, 4);
            this.pnlSuperior221.Name = "pnlSuperior221";
            this.pnlSuperior221.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSuperior221.Size = new System.Drawing.Size(460, 29);
            this.pnlSuperior221.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(454, 23);
            this.label3.TabIndex = 663;
            this.label3.Text = "Observaciones";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Pendiente",
            "Finalizado"});
            this.cmbEstado.Location = new System.Drawing.Point(128, 88);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(131, 21);
            this.cmbEstado.TabIndex = 667;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 665;
            this.label2.Text = "Estado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 664;
            this.label1.Text = "Mantenimiento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 19);
            this.label10.TabIndex = 662;
            this.label10.Text = "Fecha";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.panel8);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 174);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(3);
            this.pnlMenu.Size = new System.Drawing.Size(1300, 10);
            this.pnlMenu.TabIndex = 677;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(3, 5);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1294, 2);
            this.panel8.TabIndex = 589;
            // 
            // pnlCentral
            // 
            this.pnlCentral.Controls.Add(this.dgvMantenimientoTarea);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(0, 184);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Padding = new System.Windows.Forms.Padding(4);
            this.pnlCentral.Size = new System.Drawing.Size(1300, 479);
            this.pnlCentral.TabIndex = 678;
            // 
            // dgvMantenimientoTarea
            // 
            this.dgvMantenimientoTarea.AllowUserToAddRows = false;
            this.dgvMantenimientoTarea.AllowUserToResizeRows = false;
            this.dgvMantenimientoTarea.BackgroundColor = System.Drawing.Color.White;
            this.dgvMantenimientoTarea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMantenimientoTarea.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMantenimientoTarea.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMantenimientoTarea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMantenimientoTarea.ColumnHeadersHeight = 26;
            this.dgvMantenimientoTarea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMantenimientoTarea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colTareaID,
            this.colTarea,
            this.colFecha,
            this.colFechaLimite,
            this.colResponsableID,
            this.colResponsable,
            this.colEstado,
            this.colAccion});
            this.dgvMantenimientoTarea.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMantenimientoTarea.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMantenimientoTarea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMantenimientoTarea.EnableHeadersVisualStyles = false;
            this.dgvMantenimientoTarea.GridColor = System.Drawing.Color.Teal;
            this.dgvMantenimientoTarea.Location = new System.Drawing.Point(4, 4);
            this.dgvMantenimientoTarea.Name = "dgvMantenimientoTarea";
            this.dgvMantenimientoTarea.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMantenimientoTarea.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMantenimientoTarea.RowHeadersVisible = false;
            this.dgvMantenimientoTarea.RowHeadersWidth = 38;
            this.dgvMantenimientoTarea.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMantenimientoTarea.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMantenimientoTarea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMantenimientoTarea.Size = new System.Drawing.Size(1292, 471);
            this.dgvMantenimientoTarea.TabIndex = 593;
            this.dgvMantenimientoTarea.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMantenimientoTarea_CellDoubleClick);
            this.dgvMantenimientoTarea.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMantenimientoTarea_CellFormatting);
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colTareaID
            // 
            this.colTareaID.HeaderText = "TareaID";
            this.colTareaID.Name = "colTareaID";
            this.colTareaID.ReadOnly = true;
            this.colTareaID.Visible = false;
            // 
            // colTarea
            // 
            this.colTarea.HeaderText = "Tarea";
            this.colTarea.Name = "colTarea";
            this.colTarea.ReadOnly = true;
            this.colTarea.Width = 500;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha tarea";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 150;
            // 
            // colFechaLimite
            // 
            this.colFechaLimite.HeaderText = "Fecha limite";
            this.colFechaLimite.Name = "colFechaLimite";
            this.colFechaLimite.ReadOnly = true;
            this.colFechaLimite.Width = 150;
            // 
            // colResponsableID
            // 
            this.colResponsableID.HeaderText = "ResponsableID";
            this.colResponsableID.Name = "colResponsableID";
            this.colResponsableID.Visible = false;
            // 
            // colResponsable
            // 
            this.colResponsable.HeaderText = "Responsable";
            this.colResponsable.Name = "colResponsable";
            this.colResponsable.ReadOnly = true;
            this.colResponsable.Width = 200;
            // 
            // colEstado
            // 
            this.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colAccion
            // 
            this.colAccion.HeaderText = "Accion";
            this.colAccion.Name = "colAccion";
            this.colAccion.ReadOnly = true;
            this.colAccion.Visible = false;
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInferior.Controls.Add(this.label20);
            this.pnlInferior.Controls.Add(this.lblResultados);
            this.pnlInferior.Controls.Add(this.panel4);
            this.pnlInferior.Controls.Add(this.panel3);
            this.pnlInferior.Controls.Add(this.btnCargar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 663);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(4);
            this.pnlInferior.Size = new System.Drawing.Size(1300, 47);
            this.pnlInferior.TabIndex = 679;
            // 
            // label20
            // 
            this.label20.AutoEllipsis = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Dock = System.Windows.Forms.DockStyle.Right;
            this.label20.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label20.Location = new System.Drawing.Point(1074, 4);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 39);
            this.label20.TabIndex = 766;
            this.label20.Text = "Cantidad";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoEllipsis = true;
            this.lblResultados.BackColor = System.Drawing.Color.Transparent;
            this.lblResultados.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblResultados.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultados.ForeColor = System.Drawing.Color.Black;
            this.lblResultados.Location = new System.Drawing.Point(1162, 4);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(134, 39);
            this.lblResultados.TabIndex = 767;
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnInvalidar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(222, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(264, 39);
            this.panel4.TabIndex = 765;
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
            this.btnInvalidar.Location = new System.Drawing.Point(0, 0);
            this.btnInvalidar.Name = "btnInvalidar";
            this.btnInvalidar.Size = new System.Drawing.Size(208, 39);
            this.btnInvalidar.TabIndex = 669;
            this.btnInvalidar.Text = "Invalidar";
            this.btnInvalidar.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(212, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 39);
            this.panel3.TabIndex = 763;
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
            this.btnCargar.Location = new System.Drawing.Point(4, 4);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(208, 39);
            this.btnCargar.TabIndex = 762;
            this.btnCargar.Text = "        Cargar mantenimiento";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // frmRegistroMantenimientoAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 710);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlSuperior2);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.pnlInferior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRegistroMantenimientoAgregar";
            this.Text = "frmRegistroMantenimientoAgregar";
            this.Load += new System.EventHandler(this.frmRegistroMantenimientoAgregar_Load);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior2.ResumeLayout(false);
            this.pnlSuperior2.PerformLayout();
            this.pnlSuperior22.ResumeLayout(false);
            this.pnlSuperior22.PerformLayout();
            this.pnlSuperior221.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMantenimientoTarea)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel pnlSuperior2;
        private System.Windows.Forms.Panel pnlSuperior22;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Panel pnlSuperior221;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtBuscaTipoMantenimiento;
        private System.Windows.Forms.ComboBox cmbTipoMantenimiento;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.DataGridView dgvMantenimientoTarea;
        private System.Windows.Forms.Button btnInvalidar;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTareaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaLimite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResponsableID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResponsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccion;
    }
}