
namespace PCodin_Sinlacc.Formularios.Circuito_Productivo
{
    partial class frmAgregarCircuito
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarCircuito));
            this.dgvCircuitoProd = new System.Windows.Forms.DataGridView();
            this.colOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInsumoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeccionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoEstimado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnBuscarInsumo = new System.Windows.Forms.Button();
            this.txtBuscarInsumo = new System.Windows.Forms.TextBox();
            this.cmbInsumo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSeccion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrden = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMinutos = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.pnlSubCentral2 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pnlSubCentral1 = new System.Windows.Forms.Panel();
            this.btnAgregarDGV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCircuitoProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            this.pnlSubCentral2.SuspendLayout();
            this.pnlSubCentral1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCircuitoProd
            // 
            this.dgvCircuitoProd.AllowUserToAddRows = false;
            this.dgvCircuitoProd.AllowUserToResizeRows = false;
            this.dgvCircuitoProd.BackgroundColor = System.Drawing.Color.White;
            this.dgvCircuitoProd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCircuitoProd.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvCircuitoProd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCircuitoProd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvCircuitoProd.ColumnHeadersHeight = 26;
            this.dgvCircuitoProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCircuitoProd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrden,
            this.colInsumoID,
            this.colInsumo,
            this.colSeccionID,
            this.colSeccion,
            this.colTiempoEstimado});
            this.dgvCircuitoProd.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCircuitoProd.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvCircuitoProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCircuitoProd.EnableHeadersVisualStyles = false;
            this.dgvCircuitoProd.GridColor = System.Drawing.Color.Teal;
            this.dgvCircuitoProd.Location = new System.Drawing.Point(4, 41);
            this.dgvCircuitoProd.MultiSelect = false;
            this.dgvCircuitoProd.Name = "dgvCircuitoProd";
            this.dgvCircuitoProd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCircuitoProd.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvCircuitoProd.RowHeadersVisible = false;
            this.dgvCircuitoProd.RowHeadersWidth = 38;
            this.dgvCircuitoProd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCircuitoProd.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvCircuitoProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCircuitoProd.Size = new System.Drawing.Size(1141, 350);
            this.dgvCircuitoProd.TabIndex = 589;
            this.dgvCircuitoProd.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCircuitoProd_CellFormatting);
            // 
            // colOrden
            // 
            dataGridViewCellStyle17.Format = "N0";
            dataGridViewCellStyle17.NullValue = null;
            this.colOrden.DefaultCellStyle = dataGridViewCellStyle17;
            this.colOrden.HeaderText = "Orden";
            this.colOrden.Name = "colOrden";
            this.colOrden.Width = 50;
            // 
            // colInsumoID
            // 
            this.colInsumoID.HeaderText = "Codigo";
            this.colInsumoID.Name = "colInsumoID";
            this.colInsumoID.Width = 250;
            // 
            // colInsumo
            // 
            this.colInsumo.HeaderText = "Insumo";
            this.colInsumo.Name = "colInsumo";
            this.colInsumo.Width = 420;
            // 
            // colSeccionID
            // 
            this.colSeccionID.HeaderText = "Seccion_ID";
            this.colSeccionID.Name = "colSeccionID";
            this.colSeccionID.Visible = false;
            this.colSeccionID.Width = 300;
            // 
            // colSeccion
            // 
            this.colSeccion.HeaderText = "Seccion";
            this.colSeccion.Name = "colSeccion";
            this.colSeccion.Width = 350;
            // 
            // colTiempoEstimado
            // 
            this.colTiempoEstimado.HeaderText = "Estimado";
            this.colTiempoEstimado.Name = "colTiempoEstimado";
            this.colTiempoEstimado.Width = 200;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.White;
            this.btnExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel.BackgroundImage")));
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Location = new System.Drawing.Point(49, 7);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(25, 25);
            this.btnExcel.TabIndex = 648;
            this.btnExcel.UseVisualStyleBackColor = false;
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackColor = System.Drawing.Color.Orange;
            this.pictureBox18.Location = new System.Drawing.Point(40, 9);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(2, 21);
            this.pictureBox18.TabIndex = 646;
            this.pictureBox18.TabStop = false;
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackColor = System.Drawing.Color.White;
            this.btnEliminarProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarProducto.BackgroundImage")));
            this.btnEliminarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarProducto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEliminarProducto.FlatAppearance.BorderSize = 0;
            this.btnEliminarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEliminarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarProducto.Location = new System.Drawing.Point(5, 7);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarProducto.TabIndex = 645;
            this.btnEliminarProducto.UseVisualStyleBackColor = false;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnBuscarInsumo
            // 
            this.btnBuscarInsumo.BackColor = System.Drawing.Color.White;
            this.btnBuscarInsumo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarInsumo.BackgroundImage")));
            this.btnBuscarInsumo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarInsumo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarInsumo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarInsumo.FlatAppearance.BorderSize = 0;
            this.btnBuscarInsumo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarInsumo.Location = new System.Drawing.Point(468, 80);
            this.btnBuscarInsumo.Name = "btnBuscarInsumo";
            this.btnBuscarInsumo.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarInsumo.TabIndex = 652;
            this.btnBuscarInsumo.UseVisualStyleBackColor = false;
            this.btnBuscarInsumo.Click += new System.EventHandler(this.btnBuscarInsumo_Click);
            // 
            // txtBuscarInsumo
            // 
            this.txtBuscarInsumo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscarInsumo.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarInsumo.Location = new System.Drawing.Point(123, 80);
            this.txtBuscarInsumo.Name = "txtBuscarInsumo";
            this.txtBuscarInsumo.Size = new System.Drawing.Size(339, 22);
            this.txtBuscarInsumo.TabIndex = 651;
            this.txtBuscarInsumo.Visible = false;
            this.txtBuscarInsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarInsumo_KeyPress);
            // 
            // cmbInsumo
            // 
            this.cmbInsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInsumo.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInsumo.FormattingEnabled = true;
            this.cmbInsumo.Location = new System.Drawing.Point(122, 81);
            this.cmbInsumo.Name = "cmbInsumo";
            this.cmbInsumo.Size = new System.Drawing.Size(339, 22);
            this.cmbInsumo.TabIndex = 650;
            this.cmbInsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbInsumo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(19, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 649;
            this.label5.Text = "Insumo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 653;
            this.label1.Text = "Sección";
            // 
            // cmbSeccion
            // 
            this.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeccion.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSeccion.FormattingEnabled = true;
            this.cmbSeccion.Location = new System.Drawing.Point(123, 54);
            this.cmbSeccion.Name = "cmbSeccion";
            this.cmbSeccion.Size = new System.Drawing.Size(339, 22);
            this.cmbSeccion.TabIndex = 654;
            this.cmbSeccion.SelectedIndexChanged += new System.EventHandler(this.cmbSeccion_SelectedIndexChanged);
            this.cmbSeccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSeccion_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 655;
            this.label2.Text = "Orden";
            // 
            // txtOrden
            // 
            this.txtOrden.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrden.Location = new System.Drawing.Point(123, 117);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(83, 22);
            this.txtOrden.TabIndex = 656;
            this.txtOrden.Click += new System.EventHandler(this.txtOrden_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(244, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 19);
            this.label3.TabIndex = 657;
            this.label3.Text = "Tiempo estimado";
            // 
            // txtHora
            // 
            this.txtHora.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(372, 117);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(26, 22);
            this.txtHora.TabIndex = 658;
            this.txtHora.Click += new System.EventHandler(this.txtHora_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(404, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 19);
            this.label4.TabIndex = 659;
            this.label4.Text = ":";
            // 
            // txtMinutos
            // 
            this.txtMinutos.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinutos.Location = new System.Drawing.Point(423, 116);
            this.txtMinutos.Name = "txtMinutos";
            this.txtMinutos.Size = new System.Drawing.Size(26, 22);
            this.txtMinutos.TabIndex = 660;
            this.txtMinutos.Click += new System.EventHandler(this.txtMinutos_Click);
            // 
            // txtProducto
            // 
            this.txtProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProducto.BackColor = System.Drawing.Color.White;
            this.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProducto.Font = new System.Drawing.Font("Roboto Condensed", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtProducto.Location = new System.Drawing.Point(558, 26);
            this.txtProducto.Multiline = true;
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(586, 31);
            this.txtProducto.TabIndex = 662;
            this.txtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.textBox3.Location = new System.Drawing.Point(558, 3);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(586, 20);
            this.textBox3.TabIndex = 661;
            this.textBox3.Text = "Producto";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(1113, 0);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(28, 37);
            this.btnAgregar.TabIndex = 663;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Visible = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Cursor = System.Windows.Forms.Cursors.Default;
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(3, 3);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(3);
            this.button4.Size = new System.Drawing.Size(32, 31);
            this.button4.TabIndex = 664;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.White;
            this.btnBuscarProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarProducto.BackgroundImage")));
            this.btnBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarProducto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarProducto.FlatAppearance.BorderSize = 0;
            this.btnBuscarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProducto.Location = new System.Drawing.Point(468, 25);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarProducto.TabIndex = 669;
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBuscarProducto.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarProducto.Location = new System.Drawing.Point(123, 26);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(339, 22);
            this.txtBuscarProducto.TabIndex = 668;
            this.txtBuscarProducto.Visible = false;
            this.txtBuscarProducto.Click += new System.EventHandler(this.txtBuscarProducto_Click);
            this.txtBuscarProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarProducto_KeyPress);
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(123, 26);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(339, 22);
            this.cmbProducto.TabIndex = 667;
            this.cmbProducto.SelectedIndexChanged += new System.EventHandler(this.cmbProducto_SelectedIndexChanged);
            this.cmbProducto.SelectedValueChanged += new System.EventHandler(this.cmbProducto_SelectedValueChanged);
            this.cmbProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbProducto_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Roboto Condensed", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(19, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 24);
            this.label6.TabIndex = 666;
            this.label6.Text = "Producto";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Teal;
            this.pictureBox2.Location = new System.Drawing.Point(236, 116);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(2, 21);
            this.pictureBox2.TabIndex = 670;
            this.pictureBox2.TabStop = false;
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
            this.btnCargar.Size = new System.Drawing.Size(208, 34);
            this.btnCargar.TabIndex = 671;
            this.btnCargar.Text = "   Cargar circuito";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click_1);
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.button4);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSuperior.Size = new System.Drawing.Size(1159, 37);
            this.pnlSuperior.TabIndex = 672;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.btnEliminarProducto);
            this.pnlMenu.Controls.Add(this.pictureBox18);
            this.pnlMenu.Controls.Add(this.btnExcel);
            this.pnlMenu.Controls.Add(this.btnAgregar);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(4, 4);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1141, 37);
            this.pnlMenu.TabIndex = 673;
            this.pnlMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInferior_Paint);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnCargar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 648);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(4);
            this.pnlInferior.Size = new System.Drawing.Size(1159, 42);
            this.pnlInferior.TabIndex = 674;
            // 
            // pnlCentral
            // 
            this.pnlCentral.BackColor = System.Drawing.Color.White;
            this.pnlCentral.Controls.Add(this.pnlSubCentral2);
            this.pnlCentral.Controls.Add(this.pnlSubCentral1);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(0, 37);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Padding = new System.Windows.Forms.Padding(5);
            this.pnlCentral.Size = new System.Drawing.Size(1159, 611);
            this.pnlCentral.TabIndex = 675;
            // 
            // pnlSubCentral2
            // 
            this.pnlSubCentral2.Controls.Add(this.panel9);
            this.pnlSubCentral2.Controls.Add(this.dgvCircuitoProd);
            this.pnlSubCentral2.Controls.Add(this.pnlMenu);
            this.pnlSubCentral2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubCentral2.Location = new System.Drawing.Point(5, 211);
            this.pnlSubCentral2.Name = "pnlSubCentral2";
            this.pnlSubCentral2.Padding = new System.Windows.Forms.Padding(4);
            this.pnlSubCentral2.Size = new System.Drawing.Size(1149, 395);
            this.pnlSubCentral2.TabIndex = 677;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(4, 41);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1141, 2);
            this.panel9.TabIndex = 674;
            // 
            // pnlSubCentral1
            // 
            this.pnlSubCentral1.BackColor = System.Drawing.Color.White;
            this.pnlSubCentral1.Controls.Add(this.btnAgregarDGV);
            this.pnlSubCentral1.Controls.Add(this.txtBuscarProducto);
            this.pnlSubCentral1.Controls.Add(this.label5);
            this.pnlSubCentral1.Controls.Add(this.cmbInsumo);
            this.pnlSubCentral1.Controls.Add(this.txtBuscarInsumo);
            this.pnlSubCentral1.Controls.Add(this.btnBuscarInsumo);
            this.pnlSubCentral1.Controls.Add(this.txtProducto);
            this.pnlSubCentral1.Controls.Add(this.textBox3);
            this.pnlSubCentral1.Controls.Add(this.pictureBox2);
            this.pnlSubCentral1.Controls.Add(this.label1);
            this.pnlSubCentral1.Controls.Add(this.btnBuscarProducto);
            this.pnlSubCentral1.Controls.Add(this.cmbSeccion);
            this.pnlSubCentral1.Controls.Add(this.label2);
            this.pnlSubCentral1.Controls.Add(this.cmbProducto);
            this.pnlSubCentral1.Controls.Add(this.txtOrden);
            this.pnlSubCentral1.Controls.Add(this.label6);
            this.pnlSubCentral1.Controls.Add(this.label3);
            this.pnlSubCentral1.Controls.Add(this.txtHora);
            this.pnlSubCentral1.Controls.Add(this.label4);
            this.pnlSubCentral1.Controls.Add(this.txtMinutos);
            this.pnlSubCentral1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubCentral1.Location = new System.Drawing.Point(5, 5);
            this.pnlSubCentral1.Name = "pnlSubCentral1";
            this.pnlSubCentral1.Size = new System.Drawing.Size(1149, 206);
            this.pnlSubCentral1.TabIndex = 676;
            // 
            // btnAgregarDGV
            // 
            this.btnAgregarDGV.BackColor = System.Drawing.Color.White;
            this.btnAgregarDGV.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAgregarDGV.FlatAppearance.BorderSize = 2;
            this.btnAgregarDGV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnAgregarDGV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAgregarDGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDGV.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDGV.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarDGV.Image")));
            this.btnAgregarDGV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarDGV.Location = new System.Drawing.Point(123, 166);
            this.btnAgregarDGV.Name = "btnAgregarDGV";
            this.btnAgregarDGV.Size = new System.Drawing.Size(208, 34);
            this.btnAgregarDGV.TabIndex = 672;
            this.btnAgregarDGV.Text = "   Agregar";
            this.btnAgregarDGV.UseVisualStyleBackColor = false;
            this.btnAgregarDGV.Click += new System.EventHandler(this.btnAgregarDGV_Click);
            // 
            // frmAgregarCircuito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1159, 690);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAgregarCircuito";
            this.Text = "frmAgregarCircuito";
            this.Load += new System.EventHandler(this.frmAgregarCircuito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCircuitoProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.pnlCentral.ResumeLayout(false);
            this.pnlSubCentral2.ResumeLayout(false);
            this.pnlSubCentral1.ResumeLayout(false);
            this.pnlSubCentral1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCircuitoProd;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnBuscarInsumo;
        private System.Windows.Forms.TextBox txtBuscarInsumo;
        private System.Windows.Forms.ComboBox cmbInsumo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSeccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMinutos;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsumoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeccionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoEstimado;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel pnlSubCentral1;
        private System.Windows.Forms.Panel pnlSubCentral2;
        private System.Windows.Forms.Button btnAgregarDGV;
        private System.Windows.Forms.Panel panel9;
    }
}