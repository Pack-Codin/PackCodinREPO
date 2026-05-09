
namespace PCodin_Sinlacc.Formularios.Orden_Produccion
{
    partial class frmMostrarProduccionesRelacionadas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMostrarProduccionesRelacionadas));
            this.dgvMovimientoProduccion = new System.Windows.Forms.DataGridView();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.cmbFiltraFicha = new System.Windows.Forms.ComboBox();
            this.chkFiltraFicha = new System.Windows.Forms.CheckBox();
            this.cmbFiltraRetencion = new System.Windows.Forms.ComboBox();
            this.chkFiltraRetencion = new System.Windows.Forms.CheckBox();
            this.cmbFiltraMovimiento = new System.Windows.Forms.ComboBox();
            this.chkFiltraMovimiento = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.chkFechaHasta = new System.Windows.Forms.CheckBox();
            this.chkFechaDesde = new System.Windows.Forms.CheckBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.txtBuscaInsPro = new System.Windows.Forms.TextBox();
            this.txtBuscaCategoria = new System.Windows.Forms.TextBox();
            this.btnBuscarCategoria = new System.Windows.Forms.Button();
            this.btnBuscarInsPro = new System.Windows.Forms.Button();
            this.chkFiltraInsPro = new System.Windows.Forms.CheckBox();
            this.cmbFiltraInsPro = new System.Windows.Forms.ComboBox();
            this.lblfiltros = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cmbFiltraCategoria = new System.Windows.Forms.ComboBox();
            this.chkFiltraCategoria = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbFiltraEstado = new System.Windows.Forms.ComboBox();
            this.chkFiltraEstado = new System.Windows.Forms.CheckBox();
            this.btnMostrarfiltros = new System.Windows.Forms.Button();
            this.txtCantidadResultados = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.bunifuFlatButton1 = new System.Windows.Forms.Button();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroProduccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadUtiliz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadDisponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFicha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientoProduccion)).BeginInit();
            this.gbxFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMovimientoProduccion
            // 
            this.dgvMovimientoProduccion.AllowUserToAddRows = false;
            this.dgvMovimientoProduccion.AllowUserToResizeRows = false;
            this.dgvMovimientoProduccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovimientoProduccion.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovimientoProduccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMovimientoProduccion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvMovimientoProduccion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovimientoProduccion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMovimientoProduccion.ColumnHeadersHeight = 26;
            this.dgvMovimientoProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMovimientoProduccion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colNumeroProduccion,
            this.colFecha,
            this.colMovimiento,
            this.colCodigo,
            this.colProducto,
            this.colCantidad,
            this.colCantidadUtiliz,
            this.colCantidadDisponible,
            this.colMedida,
            this.colRetencion,
            this.colFicha,
            this.colEstado,
            this.colEmpleado,
            this.colObservacion});
            this.dgvMovimientoProduccion.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMovimientoProduccion.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMovimientoProduccion.EnableHeadersVisualStyles = false;
            this.dgvMovimientoProduccion.GridColor = System.Drawing.Color.Teal;
            this.dgvMovimientoProduccion.Location = new System.Drawing.Point(0, 37);
            this.dgvMovimientoProduccion.Name = "dgvMovimientoProduccion";
            this.dgvMovimientoProduccion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovimientoProduccion.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMovimientoProduccion.RowHeadersVisible = false;
            this.dgvMovimientoProduccion.RowHeadersWidth = 38;
            this.dgvMovimientoProduccion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMovimientoProduccion.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMovimientoProduccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientoProduccion.Size = new System.Drawing.Size(1409, 660);
            this.dgvMovimientoProduccion.TabIndex = 501;
            this.dgvMovimientoProduccion.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMovimientoProduccion_CellFormatting);
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.BackColor = System.Drawing.Color.Silver;
            this.gbxFiltros.Controls.Add(this.cmbFiltraFicha);
            this.gbxFiltros.Controls.Add(this.chkFiltraFicha);
            this.gbxFiltros.Controls.Add(this.cmbFiltraRetencion);
            this.gbxFiltros.Controls.Add(this.chkFiltraRetencion);
            this.gbxFiltros.Controls.Add(this.cmbFiltraMovimiento);
            this.gbxFiltros.Controls.Add(this.chkFiltraMovimiento);
            this.gbxFiltros.Controls.Add(this.textBox3);
            this.gbxFiltros.Controls.Add(this.chkFechaHasta);
            this.gbxFiltros.Controls.Add(this.chkFechaDesde);
            this.gbxFiltros.Controls.Add(this.dtpFechaHasta);
            this.gbxFiltros.Controls.Add(this.dtpFechaDesde);
            this.gbxFiltros.Controls.Add(this.txtBuscaInsPro);
            this.gbxFiltros.Controls.Add(this.txtBuscaCategoria);
            this.gbxFiltros.Controls.Add(this.btnBuscarCategoria);
            this.gbxFiltros.Controls.Add(this.btnBuscarInsPro);
            this.gbxFiltros.Controls.Add(this.chkFiltraInsPro);
            this.gbxFiltros.Controls.Add(this.cmbFiltraInsPro);
            this.gbxFiltros.Controls.Add(this.lblfiltros);
            this.gbxFiltros.Controls.Add(this.textBox4);
            this.gbxFiltros.Controls.Add(this.cmbFiltraCategoria);
            this.gbxFiltros.Controls.Add(this.chkFiltraCategoria);
            this.gbxFiltros.Controls.Add(this.btnBuscar);
            this.gbxFiltros.Controls.Add(this.cmbFiltraEstado);
            this.gbxFiltros.Controls.Add(this.chkFiltraEstado);
            this.gbxFiltros.Location = new System.Drawing.Point(842, 368);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Size = new System.Drawing.Size(525, 328);
            this.gbxFiltros.TabIndex = 514;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Visible = false;
            // 
            // cmbFiltraFicha
            // 
            this.cmbFiltraFicha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraFicha.Enabled = false;
            this.cmbFiltraFicha.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltraFicha.FormattingEnabled = true;
            this.cmbFiltraFicha.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbFiltraFicha.Location = new System.Drawing.Point(117, 175);
            this.cmbFiltraFicha.Name = "cmbFiltraFicha";
            this.cmbFiltraFicha.Size = new System.Drawing.Size(121, 22);
            this.cmbFiltraFicha.TabIndex = 599;
            // 
            // chkFiltraFicha
            // 
            this.chkFiltraFicha.AutoSize = true;
            this.chkFiltraFicha.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraFicha.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraFicha.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFiltraFicha.Location = new System.Drawing.Point(56, 177);
            this.chkFiltraFicha.Name = "chkFiltraFicha";
            this.chkFiltraFicha.Size = new System.Drawing.Size(53, 18);
            this.chkFiltraFicha.TabIndex = 598;
            this.chkFiltraFicha.Text = "Ficha";
            this.chkFiltraFicha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraFicha.UseVisualStyleBackColor = false;
            this.chkFiltraFicha.CheckedChanged += new System.EventHandler(this.chkFiltraFicha_CheckedChanged_1);
            // 
            // cmbFiltraRetencion
            // 
            this.cmbFiltraRetencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraRetencion.Enabled = false;
            this.cmbFiltraRetencion.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltraRetencion.FormattingEnabled = true;
            this.cmbFiltraRetencion.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbFiltraRetencion.Location = new System.Drawing.Point(117, 148);
            this.cmbFiltraRetencion.Name = "cmbFiltraRetencion";
            this.cmbFiltraRetencion.Size = new System.Drawing.Size(121, 22);
            this.cmbFiltraRetencion.TabIndex = 597;
            // 
            // chkFiltraRetencion
            // 
            this.chkFiltraRetencion.AutoSize = true;
            this.chkFiltraRetencion.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraRetencion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraRetencion.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFiltraRetencion.Location = new System.Drawing.Point(34, 150);
            this.chkFiltraRetencion.Name = "chkFiltraRetencion";
            this.chkFiltraRetencion.Size = new System.Drawing.Size(75, 18);
            this.chkFiltraRetencion.TabIndex = 596;
            this.chkFiltraRetencion.Text = "Retención";
            this.chkFiltraRetencion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraRetencion.UseVisualStyleBackColor = false;
            this.chkFiltraRetencion.CheckedChanged += new System.EventHandler(this.chkFiltraRetencion_CheckedChanged_1);
            // 
            // cmbFiltraMovimiento
            // 
            this.cmbFiltraMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraMovimiento.Enabled = false;
            this.cmbFiltraMovimiento.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltraMovimiento.FormattingEnabled = true;
            this.cmbFiltraMovimiento.Location = new System.Drawing.Point(117, 68);
            this.cmbFiltraMovimiento.Name = "cmbFiltraMovimiento";
            this.cmbFiltraMovimiento.Size = new System.Drawing.Size(332, 22);
            this.cmbFiltraMovimiento.TabIndex = 595;
            // 
            // chkFiltraMovimiento
            // 
            this.chkFiltraMovimiento.AutoSize = true;
            this.chkFiltraMovimiento.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraMovimiento.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraMovimiento.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFiltraMovimiento.Location = new System.Drawing.Point(26, 70);
            this.chkFiltraMovimiento.Name = "chkFiltraMovimiento";
            this.chkFiltraMovimiento.Size = new System.Drawing.Size(83, 18);
            this.chkFiltraMovimiento.TabIndex = 594;
            this.chkFiltraMovimiento.Text = "Movimiento";
            this.chkFiltraMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraMovimiento.UseVisualStyleBackColor = false;
            this.chkFiltraMovimiento.CheckedChanged += new System.EventHandler(this.chkFiltraMovimiento_CheckedChanged_1);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Black;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(0, 213);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(525, 23);
            this.textBox3.TabIndex = 593;
            this.textBox3.Text = "Fecha";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkFechaHasta
            // 
            this.chkFechaHasta.AutoSize = true;
            this.chkFechaHasta.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFechaHasta.Location = new System.Drawing.Point(273, 258);
            this.chkFechaHasta.Name = "chkFechaHasta";
            this.chkFechaHasta.Size = new System.Drawing.Size(54, 18);
            this.chkFechaHasta.TabIndex = 592;
            this.chkFechaHasta.Text = "Hasta";
            this.chkFechaHasta.UseVisualStyleBackColor = true;
            this.chkFechaHasta.CheckedChanged += new System.EventHandler(this.chkFechaHasta_CheckedChanged_1);
            // 
            // chkFechaDesde
            // 
            this.chkFechaDesde.AutoSize = true;
            this.chkFechaDesde.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFechaDesde.Location = new System.Drawing.Point(52, 258);
            this.chkFechaDesde.Name = "chkFechaDesde";
            this.chkFechaDesde.Size = new System.Drawing.Size(56, 18);
            this.chkFechaDesde.TabIndex = 591;
            this.chkFechaDesde.Text = "Desde";
            this.chkFechaDesde.UseVisualStyleBackColor = true;
            this.chkFechaDesde.CheckedChanged += new System.EventHandler(this.chkFechaDesde_CheckedChanged_1);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(330, 256);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(111, 22);
            this.dtpFechaHasta.TabIndex = 590;
            this.dtpFechaHasta.Value = new System.DateTime(2021, 4, 30, 2, 21, 26, 0);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(109, 255);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(111, 22);
            this.dtpFechaDesde.TabIndex = 589;
            // 
            // txtBuscaInsPro
            // 
            this.txtBuscaInsPro.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscaInsPro.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaInsPro.Location = new System.Drawing.Point(117, 42);
            this.txtBuscaInsPro.Name = "txtBuscaInsPro";
            this.txtBuscaInsPro.Size = new System.Drawing.Size(332, 22);
            this.txtBuscaInsPro.TabIndex = 531;
            this.txtBuscaInsPro.Visible = false;
            this.txtBuscaInsPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaInsPro_KeyPress_1);
            // 
            // txtBuscaCategoria
            // 
            this.txtBuscaCategoria.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscaCategoria.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaCategoria.Location = new System.Drawing.Point(117, 94);
            this.txtBuscaCategoria.Name = "txtBuscaCategoria";
            this.txtBuscaCategoria.Size = new System.Drawing.Size(332, 22);
            this.txtBuscaCategoria.TabIndex = 532;
            this.txtBuscaCategoria.Visible = false;
            this.txtBuscaCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaCategoria_KeyPress_1);
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
            this.btnBuscarCategoria.Location = new System.Drawing.Point(455, 95);
            this.btnBuscarCategoria.Name = "btnBuscarCategoria";
            this.btnBuscarCategoria.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarCategoria.TabIndex = 530;
            this.btnBuscarCategoria.UseVisualStyleBackColor = false;
            this.btnBuscarCategoria.Click += new System.EventHandler(this.btnBuscarCategoria_Click_1);
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
            this.btnBuscarInsPro.Location = new System.Drawing.Point(455, 43);
            this.btnBuscarInsPro.Name = "btnBuscarInsPro";
            this.btnBuscarInsPro.Size = new System.Drawing.Size(20, 20);
            this.btnBuscarInsPro.TabIndex = 529;
            this.btnBuscarInsPro.UseVisualStyleBackColor = false;
            this.btnBuscarInsPro.Click += new System.EventHandler(this.btnBuscarInsPro_Click_1);
            // 
            // chkFiltraInsPro
            // 
            this.chkFiltraInsPro.AutoSize = true;
            this.chkFiltraInsPro.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraInsPro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraInsPro.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFiltraInsPro.Location = new System.Drawing.Point(3, 43);
            this.chkFiltraInsPro.Name = "chkFiltraInsPro";
            this.chkFiltraInsPro.Size = new System.Drawing.Size(106, 18);
            this.chkFiltraInsPro.TabIndex = 460;
            this.chkFiltraInsPro.Text = "Insumo / Produc";
            this.chkFiltraInsPro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraInsPro.UseVisualStyleBackColor = false;
            this.chkFiltraInsPro.CheckedChanged += new System.EventHandler(this.chkFiltraInsPro_CheckedChanged_1);
            // 
            // cmbFiltraInsPro
            // 
            this.cmbFiltraInsPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraInsPro.Enabled = false;
            this.cmbFiltraInsPro.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltraInsPro.FormattingEnabled = true;
            this.cmbFiltraInsPro.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbFiltraInsPro.Location = new System.Drawing.Point(117, 41);
            this.cmbFiltraInsPro.Name = "cmbFiltraInsPro";
            this.cmbFiltraInsPro.Size = new System.Drawing.Size(332, 22);
            this.cmbFiltraInsPro.TabIndex = 458;
            this.cmbFiltraInsPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFiltraInsPro_KeyPress_1);
            // 
            // lblfiltros
            // 
            this.lblfiltros.AutoSize = true;
            this.lblfiltros.BackColor = System.Drawing.Color.DarkOrange;
            this.lblfiltros.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfiltros.Location = new System.Drawing.Point(-3, 0);
            this.lblfiltros.Name = "lblfiltros";
            this.lblfiltros.Size = new System.Drawing.Size(65, 25);
            this.lblfiltros.TabIndex = 456;
            this.lblfiltros.Text = "Filtros";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Black;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cmbFiltraCategoria.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltraCategoria.FormattingEnabled = true;
            this.cmbFiltraCategoria.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbFiltraCategoria.Location = new System.Drawing.Point(117, 94);
            this.cmbFiltraCategoria.Name = "cmbFiltraCategoria";
            this.cmbFiltraCategoria.Size = new System.Drawing.Size(332, 22);
            this.cmbFiltraCategoria.TabIndex = 56;
            this.cmbFiltraCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFiltraCategoria_KeyPress_1);
            // 
            // chkFiltraCategoria
            // 
            this.chkFiltraCategoria.AutoSize = true;
            this.chkFiltraCategoria.BackColor = System.Drawing.Color.Silver;
            this.chkFiltraCategoria.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraCategoria.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFiltraCategoria.Location = new System.Drawing.Point(35, 96);
            this.chkFiltraCategoria.Name = "chkFiltraCategoria";
            this.chkFiltraCategoria.Size = new System.Drawing.Size(74, 18);
            this.chkFiltraCategoria.TabIndex = 55;
            this.chkFiltraCategoria.Text = "Categoría";
            this.chkFiltraCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraCategoria.UseVisualStyleBackColor = false;
            this.chkFiltraCategoria.CheckedChanged += new System.EventHandler(this.chkFiltraCategoria_CheckedChanged_1);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(0, 299);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(525, 30);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // cmbFiltraEstado
            // 
            this.cmbFiltraEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltraEstado.Enabled = false;
            this.cmbFiltraEstado.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltraEstado.FormattingEnabled = true;
            this.cmbFiltraEstado.Items.AddRange(new object[] {
            "PEN",
            "ENT",
            "AN"});
            this.cmbFiltraEstado.Location = new System.Drawing.Point(117, 121);
            this.cmbFiltraEstado.Name = "cmbFiltraEstado";
            this.cmbFiltraEstado.Size = new System.Drawing.Size(121, 22);
            this.cmbFiltraEstado.TabIndex = 45;
            // 
            // chkFiltraEstado
            // 
            this.chkFiltraEstado.AutoSize = true;
            this.chkFiltraEstado.BackColor = System.Drawing.Color.PowderBlue;
            this.chkFiltraEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFiltraEstado.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFiltraEstado.Location = new System.Drawing.Point(50, 123);
            this.chkFiltraEstado.Name = "chkFiltraEstado";
            this.chkFiltraEstado.Size = new System.Drawing.Size(59, 18);
            this.chkFiltraEstado.TabIndex = 44;
            this.chkFiltraEstado.Text = "Estado";
            this.chkFiltraEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFiltraEstado.UseVisualStyleBackColor = false;
            this.chkFiltraEstado.CheckedChanged += new System.EventHandler(this.chkFiltraEstado_CheckedChanged_1);
            // 
            // btnMostrarfiltros
            // 
            this.btnMostrarfiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMostrarfiltros.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMostrarfiltros.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMostrarfiltros.BackgroundImage")));
            this.btnMostrarfiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMostrarfiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarfiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarfiltros.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarfiltros.ForeColor = System.Drawing.Color.Black;
            this.btnMostrarfiltros.Location = new System.Drawing.Point(842, 698);
            this.btnMostrarfiltros.Name = "btnMostrarfiltros";
            this.btnMostrarfiltros.Size = new System.Drawing.Size(525, 31);
            this.btnMostrarfiltros.TabIndex = 513;
            this.btnMostrarfiltros.Text = "Mostrar Filtros";
            this.btnMostrarfiltros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarfiltros.UseVisualStyleBackColor = false;
            this.btnMostrarfiltros.Click += new System.EventHandler(this.btnMostrarfiltros_Click_1);
            // 
            // txtCantidadResultados
            // 
            this.txtCantidadResultados.BackColor = System.Drawing.Color.Gray;
            this.txtCantidadResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidadResultados.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadResultados.ForeColor = System.Drawing.Color.White;
            this.txtCantidadResultados.Location = new System.Drawing.Point(73, 704);
            this.txtCantidadResultados.Multiline = true;
            this.txtCantidadResultados.Name = "txtCantidadResultados";
            this.txtCantidadResultados.Size = new System.Drawing.Size(111, 23);
            this.txtCantidadResultados.TabIndex = 516;
            this.txtCantidadResultados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.DarkOrange;
            this.label20.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(0, 704);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 23);
            this.label20.TabIndex = 515;
            this.label20.Text = "Cantidad";
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.DarkOrange;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(1331, 0);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Size = new System.Drawing.Size(36, 36);
            this.bunifuFlatButton1.TabIndex = 517;
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colNumeroProduccion
            // 
            this.colNumeroProduccion.HeaderText = "N° produccion";
            this.colNumeroProduccion.Name = "colNumeroProduccion";
            this.colNumeroProduccion.Width = 150;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            // 
            // colMovimiento
            // 
            this.colMovimiento.HeaderText = "Movimiento";
            this.colMovimiento.Name = "colMovimiento";
            this.colMovimiento.Width = 210;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCodigo.Width = 120;
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.Width = 350;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 80;
            // 
            // colCantidadUtiliz
            // 
            this.colCantidadUtiliz.HeaderText = "Cant Utilzada";
            this.colCantidadUtiliz.Name = "colCantidadUtiliz";
            // 
            // colCantidadDisponible
            // 
            this.colCantidadDisponible.HeaderText = "Cant Disp";
            this.colCantidadDisponible.Name = "colCantidadDisponible";
            // 
            // colMedida
            // 
            this.colMedida.HeaderText = "Medida";
            this.colMedida.Name = "colMedida";
            // 
            // colRetencion
            // 
            this.colRetencion.HeaderText = "Retención";
            this.colRetencion.Name = "colRetencion";
            // 
            // colFicha
            // 
            this.colFicha.HeaderText = "Ficha";
            this.colFicha.Name = "colFicha";
            this.colFicha.Width = 60;
            // 
            // colEstado
            // 
            this.colEstado.FillWeight = 40F;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Width = 150;
            // 
            // colEmpleado
            // 
            this.colEmpleado.HeaderText = "Responsable";
            this.colEmpleado.Name = "colEmpleado";
            this.colEmpleado.Width = 150;
            // 
            // colObservacion
            // 
            this.colObservacion.HeaderText = "Observaciones";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.Width = 300;
            // 
            // frmMostrarProduccionesRelacionadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1366, 730);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.txtCantidadResultados);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.gbxFiltros);
            this.Controls.Add(this.btnMostrarfiltros);
            this.Controls.Add(this.dgvMovimientoProduccion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMostrarProduccionesRelacionadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMostrarProduccionesRelacionadas";
            this.Load += new System.EventHandler(this.frmMostrarProduccionesRelacionadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientoProduccion)).EndInit();
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMovimientoProduccion;
        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.ComboBox cmbFiltraFicha;
        private System.Windows.Forms.CheckBox chkFiltraFicha;
        private System.Windows.Forms.ComboBox cmbFiltraRetencion;
        private System.Windows.Forms.CheckBox chkFiltraRetencion;
        private System.Windows.Forms.ComboBox cmbFiltraMovimiento;
        private System.Windows.Forms.CheckBox chkFiltraMovimiento;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox chkFechaHasta;
        private System.Windows.Forms.CheckBox chkFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.TextBox txtBuscaInsPro;
        private System.Windows.Forms.TextBox txtBuscaCategoria;
        private System.Windows.Forms.Button btnBuscarCategoria;
        private System.Windows.Forms.Button btnBuscarInsPro;
        private System.Windows.Forms.CheckBox chkFiltraInsPro;
        private System.Windows.Forms.ComboBox cmbFiltraInsPro;
        private System.Windows.Forms.Label lblfiltros;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox cmbFiltraCategoria;
        private System.Windows.Forms.CheckBox chkFiltraCategoria;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbFiltraEstado;
        private System.Windows.Forms.CheckBox chkFiltraEstado;
        private System.Windows.Forms.Button btnMostrarfiltros;
        private System.Windows.Forms.TextBox txtCantidadResultados;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button bunifuFlatButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroProduccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadUtiliz;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadDisponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFicha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
    }
}