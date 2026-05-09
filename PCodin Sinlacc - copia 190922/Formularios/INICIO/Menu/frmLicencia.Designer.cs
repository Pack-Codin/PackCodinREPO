
namespace PCodin_Sinlacc.Formularios.Menu
{
    partial class frmLicencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicencia));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLicencia = new System.Windows.Forms.Panel();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btnCargar = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgvMercaderia = new System.Windows.Forms.DataGridView();
            this.colClienteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlLicencia.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMercaderia)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLicencia
            // 
            this.pnlLicencia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLicencia.Controls.Add(this.pnlCentral);
            this.pnlLicencia.Controls.Add(this.pnlInferior);
            this.pnlLicencia.Controls.Add(this.pnlSuperior);
            this.pnlLicencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLicencia.Location = new System.Drawing.Point(0, 0);
            this.pnlLicencia.Name = "pnlLicencia";
            this.pnlLicencia.Size = new System.Drawing.Size(583, 267);
            this.pnlLicencia.TabIndex = 276;
            this.pnlLicencia.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLicencia_Paint);
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.label1);
            this.pnlSuperior.Controls.Add(this.panel1);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Padding = new System.Windows.Forms.Padding(4);
            this.pnlSuperior.Size = new System.Drawing.Size(583, 39);
            this.pnlSuperior.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::PCodin_Sinlacc.Properties.Resources.Logo_Pack_Codin;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 31);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(176, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 31);
            this.label1.TabIndex = 647;
            this.label1.Text = "Control de licencia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCentral
            // 
            this.pnlCentral.Controls.Add(this.dgvMercaderia);
            this.pnlCentral.Controls.Add(this.panel9);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(0, 39);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Padding = new System.Windows.Forms.Padding(3);
            this.pnlCentral.Size = new System.Drawing.Size(583, 184);
            this.pnlCentral.TabIndex = 6;
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnCargar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 223);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(4);
            this.pnlInferior.Size = new System.Drawing.Size(583, 44);
            this.pnlInferior.TabIndex = 7;
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
            this.btnCargar.Size = new System.Drawing.Size(208, 36);
            this.btnCargar.TabIndex = 673;
            this.btnCargar.Text = "   Actualizar";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(577, 2);
            this.panel9.TabIndex = 671;
            // 
            // dgvMercaderia
            // 
            this.dgvMercaderia.AllowUserToAddRows = false;
            this.dgvMercaderia.AllowUserToOrderColumns = true;
            this.dgvMercaderia.AllowUserToResizeRows = false;
            this.dgvMercaderia.BackgroundColor = System.Drawing.Color.White;
            this.dgvMercaderia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMercaderia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMercaderia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMercaderia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMercaderia.ColumnHeadersHeight = 26;
            this.dgvMercaderia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMercaderia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClienteID,
            this.colCliente,
            this.colFechaVencimiento,
            this.colEstado});
            this.dgvMercaderia.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMercaderia.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMercaderia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMercaderia.EnableHeadersVisualStyles = false;
            this.dgvMercaderia.GridColor = System.Drawing.Color.Teal;
            this.dgvMercaderia.Location = new System.Drawing.Point(3, 5);
            this.dgvMercaderia.Name = "dgvMercaderia";
            this.dgvMercaderia.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMercaderia.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMercaderia.RowHeadersVisible = false;
            this.dgvMercaderia.RowHeadersWidth = 38;
            this.dgvMercaderia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMercaderia.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMercaderia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMercaderia.Size = new System.Drawing.Size(577, 176);
            this.dgvMercaderia.TabIndex = 672;
            this.dgvMercaderia.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMercaderia_CellFormatting);
            // 
            // colClienteID
            // 
            this.colClienteID.HeaderText = "ClienteID";
            this.colClienteID.Name = "colClienteID";
            this.colClienteID.Visible = false;
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            this.colCliente.Width = 250;
            // 
            // colFechaVencimiento
            // 
            dataGridViewCellStyle2.NullValue = null;
            this.colFechaVencimiento.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFechaVencimiento.HeaderText = "Fecha vencimiento";
            this.colFechaVencimiento.Name = "colFechaVencimiento";
            this.colFechaVencimiento.ReadOnly = true;
            this.colFechaVencimiento.Width = 150;
            // 
            // colEstado
            // 
            this.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.NullValue = "0";
            this.colEstado.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // frmLicencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 267);
            this.Controls.Add(this.pnlLicencia);
            this.Name = "frmLicencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de licencias";
            this.Load += new System.EventHandler(this.frmLicencia_Load);
            this.pnlLicencia.ResumeLayout(false);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlCentral.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMercaderia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLicencia;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dgvMercaderia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClienteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}