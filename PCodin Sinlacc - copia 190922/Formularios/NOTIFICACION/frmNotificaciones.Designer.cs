
namespace PCodin_Sinlacc.Formularios.Notificación
{
    partial class frmNotificaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotificaciones));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.txtFiltraDescipcion = new System.Windows.Forms.TextBox();
            this.chkFiltraLeidaPor = new System.Windows.Forms.CheckBox();
            this.cmbFiltraLeidaPor = new System.Windows.Forms.ComboBox();
            this.chkFechaHasta = new System.Windows.Forms.CheckBox();
            this.chkFechaDesde = new System.Windows.Forms.CheckBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.chkFiltraDescripcion = new System.Windows.Forms.CheckBox();
            this.lblfiltros = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.dgvNotificaciones = new System.Windows.Forms.DataGridView();
            this.colNotificacionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspacioPorComa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeidaPor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.pnlSuperior2 = new System.Windows.Forms.Panel();
            this.btnBuscarDesc = new System.Windows.Forms.Button();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.btnBuscarAsc = new System.Windows.Forms.Button();
            this.btnMarcarComoVista = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMostrarVistas = new System.Windows.Forms.Button();
            this.btnMostrarNoVistas = new System.Windows.Forms.Button();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMostrarfiltros = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            this.gbxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotificaciones)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.pnlSuperior2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.pnlCentral);
            this.panel1.Controls.Add(this.pnlSuperior);
            this.panel1.Controls.Add(this.pnlInferior);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 689);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pnlCentral
            // 
            this.pnlCentral.Controls.Add(this.panel9);
            this.pnlCentral.Controls.Add(this.gbxFiltros);
            this.pnlCentral.Controls.Add(this.txtObservaciones);
            this.pnlCentral.Controls.Add(this.dgvNotificaciones);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(0, 40);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Padding = new System.Windows.Forms.Padding(4);
            this.pnlCentral.Size = new System.Drawing.Size(1163, 605);
            this.pnlCentral.TabIndex = 738;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(4, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(630, 2);
            this.panel9.TabIndex = 737;
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbxFiltros.Controls.Add(this.txtFiltraDescipcion);
            this.gbxFiltros.Controls.Add(this.chkFiltraLeidaPor);
            this.gbxFiltros.Controls.Add(this.cmbFiltraLeidaPor);
            this.gbxFiltros.Controls.Add(this.chkFechaHasta);
            this.gbxFiltros.Controls.Add(this.chkFechaDesde);
            this.gbxFiltros.Controls.Add(this.dtpFechaHasta);
            this.gbxFiltros.Controls.Add(this.dtpFechaDesde);
            this.gbxFiltros.Controls.Add(this.chkFiltraDescripcion);
            this.gbxFiltros.Controls.Add(this.lblfiltros);
            this.gbxFiltros.Controls.Add(this.btnBuscar);
            this.gbxFiltros.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbxFiltros.Location = new System.Drawing.Point(634, 4);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Padding = new System.Windows.Forms.Padding(5);
            this.gbxFiltros.Size = new System.Drawing.Size(525, 597);
            this.gbxFiltros.TabIndex = 735;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Visible = false;
            // 
            // txtFiltraDescipcion
            // 
            this.txtFiltraDescipcion.Location = new System.Drawing.Point(133, 77);
            this.txtFiltraDescipcion.Name = "txtFiltraDescipcion";
            this.txtFiltraDescipcion.Size = new System.Drawing.Size(339, 20);
            this.txtFiltraDescipcion.TabIndex = 607;
            this.txtFiltraDescipcion.Click += new System.EventHandler(this.txtFiltraDescipcion_Click);
            // 
            // chkFiltraLeidaPor
            // 
            this.chkFiltraLeidaPor.AutoSize = true;
            this.chkFiltraLeidaPor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraLeidaPor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraLeidaPor.Location = new System.Drawing.Point(53, 107);
            this.chkFiltraLeidaPor.Name = "chkFiltraLeidaPor";
            this.chkFiltraLeidaPor.Size = new System.Drawing.Size(70, 17);
            this.chkFiltraLeidaPor.TabIndex = 606;
            this.chkFiltraLeidaPor.Text = "Leida por";
            this.chkFiltraLeidaPor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraLeidaPor.UseVisualStyleBackColor = false;
            this.chkFiltraLeidaPor.CheckedChanged += new System.EventHandler(this.chkFiltraLeidaPor_CheckedChanged);
            // 
            // cmbFiltraLeidaPor
            // 
            this.cmbFiltraLeidaPor.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbFiltraLeidaPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraLeidaPor.FormattingEnabled = true;
            this.cmbFiltraLeidaPor.Location = new System.Drawing.Point(133, 103);
            this.cmbFiltraLeidaPor.Name = "cmbFiltraLeidaPor";
            this.cmbFiltraLeidaPor.Size = new System.Drawing.Size(340, 21);
            this.cmbFiltraLeidaPor.TabIndex = 603;
            // 
            // chkFechaHasta
            // 
            this.chkFechaHasta.AutoSize = true;
            this.chkFechaHasta.Location = new System.Drawing.Point(293, 165);
            this.chkFechaHasta.Name = "chkFechaHasta";
            this.chkFechaHasta.Size = new System.Drawing.Size(54, 17);
            this.chkFechaHasta.TabIndex = 587;
            this.chkFechaHasta.Text = "Hasta";
            this.chkFechaHasta.UseVisualStyleBackColor = true;
            // 
            // chkFechaDesde
            // 
            this.chkFechaDesde.AutoSize = true;
            this.chkFechaDesde.Location = new System.Drawing.Point(72, 165);
            this.chkFechaDesde.Name = "chkFechaDesde";
            this.chkFechaDesde.Size = new System.Drawing.Size(57, 17);
            this.chkFechaDesde.TabIndex = 586;
            this.chkFechaDesde.Text = "Desde";
            this.chkFechaDesde.UseVisualStyleBackColor = true;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(348, 163);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaHasta.TabIndex = 585;
            this.dtpFechaHasta.Value = new System.DateTime(2021, 4, 30, 2, 21, 26, 0);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(127, 162);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaDesde.TabIndex = 584;
            // 
            // chkFiltraDescripcion
            // 
            this.chkFiltraDescripcion.AutoSize = true;
            this.chkFiltraDescripcion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFiltraDescripcion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraDescripcion.Location = new System.Drawing.Point(41, 81);
            this.chkFiltraDescripcion.Name = "chkFiltraDescripcion";
            this.chkFiltraDescripcion.Size = new System.Drawing.Size(82, 17);
            this.chkFiltraDescripcion.TabIndex = 460;
            this.chkFiltraDescripcion.Text = "Descripción";
            this.chkFiltraDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraDescripcion.UseVisualStyleBackColor = false;
            this.chkFiltraDescripcion.CheckedChanged += new System.EventHandler(this.chkFiltraDescripcion_CheckedChanged);
            // 
            // lblfiltros
            // 
            this.lblfiltros.AutoSize = true;
            this.lblfiltros.BackColor = System.Drawing.Color.Transparent;
            this.lblfiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblfiltros.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfiltros.ForeColor = System.Drawing.Color.Teal;
            this.lblfiltros.Location = new System.Drawing.Point(5, 18);
            this.lblfiltros.Name = "lblfiltros";
            this.lblfiltros.Size = new System.Drawing.Size(78, 32);
            this.lblfiltros.TabIndex = 456;
            this.lblfiltros.Text = "Filtros";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImage = global::PCodin_Sinlacc.Properties.Resources.lupa__8_;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(5, 562);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(515, 30);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.Color.White;
            this.txtObservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservaciones.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(4, 4);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(1155, 597);
            this.txtObservaciones.TabIndex = 736;
            this.txtObservaciones.Visible = false;
            this.txtObservaciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservaciones_KeyPress);
            // 
            // dgvNotificaciones
            // 
            this.dgvNotificaciones.AllowUserToAddRows = false;
            this.dgvNotificaciones.AllowUserToResizeRows = false;
            this.dgvNotificaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvNotificaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNotificaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvNotificaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNotificaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNotificaciones.ColumnHeadersHeight = 26;
            this.dgvNotificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNotificaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNotificacionID,
            this.colEspacioPorComa,
            this.colTipo,
            this.colFecha,
            this.colHora,
            this.colDescripcion,
            this.colLeidaPor});
            this.dgvNotificaciones.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNotificaciones.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNotificaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotificaciones.EnableHeadersVisualStyles = false;
            this.dgvNotificaciones.GridColor = System.Drawing.Color.Teal;
            this.dgvNotificaciones.Location = new System.Drawing.Point(4, 4);
            this.dgvNotificaciones.MultiSelect = false;
            this.dgvNotificaciones.Name = "dgvNotificaciones";
            this.dgvNotificaciones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNotificaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNotificaciones.RowHeadersVisible = false;
            this.dgvNotificaciones.RowHeadersWidth = 38;
            this.dgvNotificaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNotificaciones.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNotificaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotificaciones.Size = new System.Drawing.Size(1155, 597);
            this.dgvNotificaciones.TabIndex = 507;
            this.dgvNotificaciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotificaciones_CellDoubleClick);
            // 
            // colNotificacionID
            // 
            this.colNotificacionID.HeaderText = "Notificacion_ID";
            this.colNotificacionID.Name = "colNotificacionID";
            this.colNotificacionID.Visible = false;
            // 
            // colEspacioPorComa
            // 
            this.colEspacioPorComa.HeaderText = "Espacio por coma";
            this.colEspacioPorComa.Name = "colEspacioPorComa";
            this.colEspacioPorComa.Visible = false;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.Width = 150;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            // 
            // colHora
            // 
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.colHora.DefaultCellStyle = dataGridViewCellStyle2;
            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "colHora";
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Width = 700;
            // 
            // colLeidaPor
            // 
            this.colLeidaPor.HeaderText = "Leida por";
            this.colLeidaPor.Name = "colLeidaPor";
            this.colLeidaPor.Width = 110;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.pnlSuperior2);
            this.pnlSuperior.Controls.Add(this.btnMarcarComoVista);
            this.pnlSuperior.Controls.Add(this.pictureBox1);
            this.pnlSuperior.Controls.Add(this.btnMostrarVistas);
            this.pnlSuperior.Controls.Add(this.btnMostrarNoVistas);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1163, 40);
            this.pnlSuperior.TabIndex = 737;
            // 
            // pnlSuperior2
            // 
            this.pnlSuperior2.Controls.Add(this.btnBuscarDesc);
            this.pnlSuperior2.Controls.Add(this.cmbOrdenar);
            this.pnlSuperior2.Controls.Add(this.btnBuscarAsc);
            this.pnlSuperior2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSuperior2.Location = new System.Drawing.Point(828, 0);
            this.pnlSuperior2.Name = "pnlSuperior2";
            this.pnlSuperior2.Padding = new System.Windows.Forms.Padding(7, 7, 15, 7);
            this.pnlSuperior2.Size = new System.Drawing.Size(335, 40);
            this.pnlSuperior2.TabIndex = 580;
            // 
            // btnBuscarDesc
            // 
            this.btnBuscarDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarDesc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarDesc.BackgroundImage")));
            this.btnBuscarDesc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarDesc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarDesc.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarDesc.FlatAppearance.BorderSize = 0;
            this.btnBuscarDesc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDesc.Location = new System.Drawing.Point(26, 7);
            this.btnBuscarDesc.Name = "btnBuscarDesc";
            this.btnBuscarDesc.Size = new System.Drawing.Size(31, 26);
            this.btnBuscarDesc.TabIndex = 579;
            this.btnBuscarDesc.UseVisualStyleBackColor = false;
            this.btnBuscarDesc.Visible = false;
            this.btnBuscarDesc.Click += new System.EventHandler(this.btnBuscarDesc_Click);
            // 
            // cmbOrdenar
            // 
            this.cmbOrdenar.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenar.FormattingEnabled = true;
            this.cmbOrdenar.Items.AddRange(new object[] {
            "",
            "Tipo",
            "Fecha",
            "Hora",
            "Descripcion",
            "Leida por"});
            this.cmbOrdenar.Location = new System.Drawing.Point(92, 7);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(228, 21);
            this.cmbOrdenar.TabIndex = 578;
            // 
            // btnBuscarAsc
            // 
            this.btnBuscarAsc.BackColor = System.Drawing.Color.White;
            this.btnBuscarAsc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarAsc.BackgroundImage")));
            this.btnBuscarAsc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarAsc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarAsc.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarAsc.FlatAppearance.BorderSize = 0;
            this.btnBuscarAsc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarAsc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarAsc.Location = new System.Drawing.Point(26, 7);
            this.btnBuscarAsc.Name = "btnBuscarAsc";
            this.btnBuscarAsc.Size = new System.Drawing.Size(31, 26);
            this.btnBuscarAsc.TabIndex = 577;
            this.btnBuscarAsc.UseVisualStyleBackColor = false;
            this.btnBuscarAsc.Click += new System.EventHandler(this.btnBuscarAsc_Click);
            // 
            // btnMarcarComoVista
            // 
            this.btnMarcarComoVista.BackColor = System.Drawing.Color.White;
            this.btnMarcarComoVista.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMarcarComoVista.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnMarcarComoVista.FlatAppearance.BorderSize = 0;
            this.btnMarcarComoVista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnMarcarComoVista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcarComoVista.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcarComoVista.Image = ((System.Drawing.Image)(resources.GetObject("btnMarcarComoVista.Image")));
            this.btnMarcarComoVista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcarComoVista.Location = new System.Drawing.Point(282, 5);
            this.btnMarcarComoVista.Name = "btnMarcarComoVista";
            this.btnMarcarComoVista.Size = new System.Drawing.Size(124, 29);
            this.btnMarcarComoVista.TabIndex = 541;
            this.btnMarcarComoVista.Text = "Leida";
            this.btnMarcarComoVista.UseVisualStyleBackColor = false;
            this.btnMarcarComoVista.Click += new System.EventHandler(this.btnMarcarComoVista_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox1.Location = new System.Drawing.Point(262, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 23);
            this.pictureBox1.TabIndex = 540;
            this.pictureBox1.TabStop = false;
            // 
            // btnMostrarVistas
            // 
            this.btnMostrarVistas.BackColor = System.Drawing.Color.White;
            this.btnMostrarVistas.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMostrarVistas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMostrarVistas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnMostrarVistas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarVistas.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarVistas.Location = new System.Drawing.Point(131, 4);
            this.btnMostrarVistas.Name = "btnMostrarVistas";
            this.btnMostrarVistas.Size = new System.Drawing.Size(113, 30);
            this.btnMostrarVistas.TabIndex = 511;
            this.btnMostrarVistas.Text = "Vistas";
            this.btnMostrarVistas.UseVisualStyleBackColor = false;
            this.btnMostrarVistas.Click += new System.EventHandler(this.btnMostrarVistas_Click);
            // 
            // btnMostrarNoVistas
            // 
            this.btnMostrarNoVistas.BackColor = System.Drawing.Color.Orange;
            this.btnMostrarNoVistas.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMostrarNoVistas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMostrarNoVistas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnMostrarNoVistas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarNoVistas.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarNoVistas.Location = new System.Drawing.Point(12, 4);
            this.btnMostrarNoVistas.Name = "btnMostrarNoVistas";
            this.btnMostrarNoVistas.Size = new System.Drawing.Size(113, 30);
            this.btnMostrarNoVistas.TabIndex = 510;
            this.btnMostrarNoVistas.Text = "No vistas";
            this.btnMostrarNoVistas.UseVisualStyleBackColor = false;
            this.btnMostrarNoVistas.Click += new System.EventHandler(this.btnMostrarNoVistas_Click);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.lblResultados);
            this.pnlInferior.Controls.Add(this.label1);
            this.pnlInferior.Controls.Add(this.btnMostrarfiltros);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 645);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(4);
            this.pnlInferior.Size = new System.Drawing.Size(1163, 44);
            this.pnlInferior.TabIndex = 739;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoEllipsis = true;
            this.lblResultados.BackColor = System.Drawing.Color.Transparent;
            this.lblResultados.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblResultados.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultados.ForeColor = System.Drawing.Color.Black;
            this.lblResultados.Location = new System.Drawing.Point(151, 4);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(88, 36);
            this.lblResultados.TabIndex = 498;
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
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 36);
            this.label1.TabIndex = 497;
            this.label1.Text = "Cantidad";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMostrarfiltros
            // 
            this.btnMostrarfiltros.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrarfiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMostrarfiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarfiltros.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMostrarfiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarfiltros.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarfiltros.ForeColor = System.Drawing.Color.Black;
            this.btnMostrarfiltros.Location = new System.Drawing.Point(634, 4);
            this.btnMostrarfiltros.Name = "btnMostrarfiltros";
            this.btnMostrarfiltros.Size = new System.Drawing.Size(525, 36);
            this.btnMostrarfiltros.TabIndex = 734;
            this.btnMostrarfiltros.Text = "Mostrar Filtros";
            this.btnMostrarfiltros.UseVisualStyleBackColor = false;
            this.btnMostrarfiltros.Click += new System.EventHandler(this.btnMostrarfiltros_Click);
            // 
            // frmNotificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1159, 690);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotificaciones";
            this.Text = "frmNotificaciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNotificaciones_Load);
            this.panel1.ResumeLayout(false);
            this.pnlCentral.ResumeLayout(false);
            this.pnlCentral.PerformLayout();
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotificaciones)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvNotificaciones;
        private System.Windows.Forms.Button btnMostrarVistas;
        private System.Windows.Forms.Button btnMostrarNoVistas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMarcarComoVista;
        private System.Windows.Forms.Button btnBuscarDesc;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.Button btnBuscarAsc;
        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.TextBox txtFiltraDescipcion;
        private System.Windows.Forms.CheckBox chkFiltraLeidaPor;
        private System.Windows.Forms.ComboBox cmbFiltraLeidaPor;
        private System.Windows.Forms.CheckBox chkFechaHasta;
        private System.Windows.Forms.CheckBox chkFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.CheckBox chkFiltraDescripcion;
        private System.Windows.Forms.Label lblfiltros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrarfiltros;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotificacionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspacioPorComa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeidaPor;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel pnlSuperior2;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel9;
    }
}