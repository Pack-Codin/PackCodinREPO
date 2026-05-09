namespace PCodin_Sinlacc.Formularios
{
    partial class frmRelacionesPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelacionesPedido));
            this.dgvOrdenPedido = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPedido_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrden_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsRelaciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRelacion = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenPedido)).BeginInit();
            this.cmsRelaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrdenPedido
            // 
            this.dgvOrdenPedido.AllowUserToAddRows = false;
            this.dgvOrdenPedido.AllowUserToResizeRows = false;
            this.dgvOrdenPedido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrdenPedido.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenPedido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrdenPedido.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dgvOrdenPedido.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenPedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrdenPedido.ColumnHeadersHeight = 26;
            this.dgvOrdenPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrdenPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colPedido_ID,
            this.colOrden_ID,
            this.colCliente,
            this.colCiudad,
            this.colCantidad});
            this.dgvOrdenPedido.ContextMenuStrip = this.cmsRelaciones;
            this.dgvOrdenPedido.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdenPedido.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrdenPedido.EnableHeadersVisualStyles = false;
            this.dgvOrdenPedido.GridColor = System.Drawing.Color.White;
            this.dgvOrdenPedido.Location = new System.Drawing.Point(1, 1);
            this.dgvOrdenPedido.MultiSelect = false;
            this.dgvOrdenPedido.Name = "dgvOrdenPedido";
            this.dgvOrdenPedido.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenPedido.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrdenPedido.RowHeadersVisible = false;
            this.dgvOrdenPedido.RowHeadersWidth = 38;
            this.dgvOrdenPedido.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdenPedido.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrdenPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenPedido.Size = new System.Drawing.Size(1064, 448);
            this.dgvOrdenPedido.TabIndex = 488;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Width = 150;
            // 
            // colPedido_ID
            // 
            this.colPedido_ID.HeaderText = "Nro pedido";
            this.colPedido_ID.Name = "colPedido_ID";
            this.colPedido_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPedido_ID.Width = 150;
            // 
            // colOrden_ID
            // 
            this.colOrden_ID.HeaderText = "Afectada por orden";
            this.colOrden_ID.Name = "colOrden_ID";
            this.colOrden_ID.Width = 150;
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.Width = 300;
            // 
            // colCiudad
            // 
            this.colCiudad.HeaderText = "Ciudad";
            this.colCiudad.Name = "colCiudad";
            this.colCiudad.Width = 200;
            // 
            // colCantidad
            // 
            this.colCantidad.FillWeight = 40F;
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // cmsRelaciones
            // 
            this.cmsRelaciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRelacion});
            this.cmsRelaciones.Name = "cmsEditarEliminarFoto";
            this.cmsRelaciones.Size = new System.Drawing.Size(110, 26);
            // 
            // btnRelacion
            // 
            this.btnRelacion.Image = ((System.Drawing.Image)(resources.GetObject("btnRelacion.Image")));
            this.btnRelacion.Name = "btnRelacion";
            this.btnRelacion.Size = new System.Drawing.Size(109, 22);
            this.btnRelacion.Text = "Copiar";
            this.btnRelacion.Click += new System.EventHandler(this.btnRelacion_Click);
            // 
            // frmRelacionesPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 450);
            this.Controls.Add(this.dgvOrdenPedido);
            this.Name = "frmRelacionesPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relaciones";
            this.Load += new System.EventHandler(this.frmRelacionesPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenPedido)).EndInit();
            this.cmsRelaciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdenPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPedido_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrden_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.ContextMenuStrip cmsRelaciones;
        private System.Windows.Forms.ToolStripMenuItem btnRelacion;
    }
}