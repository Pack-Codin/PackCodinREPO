
namespace PCodin_Sinlacc.Formularios.Movimiento_de_Produccion
{
    partial class frmRelacionesMovProduccion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelacionesMovProduccion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvInsumo = new System.Windows.Forms.DataGridView();
            this.colNumeroMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuFlatButton3 = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.bunifuFlatButton1 = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvOrdenCarga = new System.Windows.Forms.DataGridView();
            this.colNumeroMovimiento2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMovimiento2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInsumo
            // 
            this.dgvInsumo.AllowUserToAddRows = false;
            this.dgvInsumo.AllowUserToOrderColumns = true;
            this.dgvInsumo.AllowUserToResizeRows = false;
            this.dgvInsumo.BackgroundColor = System.Drawing.Color.White;
            this.dgvInsumo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInsumo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvInsumo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInsumo.ColumnHeadersHeight = 20;
            this.dgvInsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumeroMovimiento,
            this.colMovimiento,
            this.colCantidad});
            this.dgvInsumo.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsumo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInsumo.EnableHeadersVisualStyles = false;
            this.dgvInsumo.GridColor = System.Drawing.Color.Teal;
            this.dgvInsumo.Location = new System.Drawing.Point(3, 51);
            this.dgvInsumo.MultiSelect = false;
            this.dgvInsumo.Name = "dgvInsumo";
            this.dgvInsumo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInsumo.RowHeadersVisible = false;
            this.dgvInsumo.RowHeadersWidth = 38;
            this.dgvInsumo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInsumo.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInsumo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsumo.Size = new System.Drawing.Size(804, 285);
            this.dgvInsumo.TabIndex = 605;
            this.dgvInsumo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInsumo_CellContentClick);
            // 
            // colNumeroMovimiento
            // 
            this.colNumeroMovimiento.HeaderText = "Num Movimiento";
            this.colNumeroMovimiento.Name = "colNumeroMovimiento";
            this.colNumeroMovimiento.Width = 250;
            // 
            // colMovimiento
            // 
            this.colMovimiento.HeaderText = "Movimiento";
            this.colMovimiento.Name = "colMovimiento";
            this.colMovimiento.Width = 300;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 250;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.bunifuFlatButton3);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.bunifuFlatButton1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 45);
            this.panel1.TabIndex = 606;
            // 
            // bunifuFlatButton3
            // 
            this.bunifuFlatButton3.BackColor = System.Drawing.Color.DarkOrange;
            this.bunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton3.Location = new System.Drawing.Point(736, 6);
            this.bunifuFlatButton3.Name = "bunifuFlatButton3";
            this.bunifuFlatButton3.Size = new System.Drawing.Size(36, 36);
            this.bunifuFlatButton3.TabIndex = 610;
            this.bunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton3.Click += new System.EventHandler(this.bunifuFlatButton3_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.Location = new System.Drawing.Point(12, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(207, 29);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Orden producción";
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.DarkOrange;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(771, 6);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Size = new System.Drawing.Size(36, 36);
            this.bunifuFlatButton1.TabIndex = 609;
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.White;
            this.lbl2.Location = new System.Drawing.Point(12, 9);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(181, 29);
            this.lbl2.TabIndex = 0;
            this.lbl2.Text = "Orden de carga";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.lbl2);
            this.panel2.Location = new System.Drawing.Point(0, 342);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1362, 45);
            this.panel2.TabIndex = 607;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dgvOrdenCarga
            // 
            this.dgvOrdenCarga.AllowUserToAddRows = false;
            this.dgvOrdenCarga.AllowUserToResizeRows = false;
            this.dgvOrdenCarga.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenCarga.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOrdenCarga.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvOrdenCarga.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenCarga.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrdenCarga.ColumnHeadersHeight = 20;
            this.dgvOrdenCarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrdenCarga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumeroMovimiento2,
            this.colMovimiento2,
            this.colCantidadOC});
            this.dgvOrdenCarga.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdenCarga.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOrdenCarga.EnableHeadersVisualStyles = false;
            this.dgvOrdenCarga.GridColor = System.Drawing.Color.Teal;
            this.dgvOrdenCarga.Location = new System.Drawing.Point(3, 393);
            this.dgvOrdenCarga.MultiSelect = false;
            this.dgvOrdenCarga.Name = "dgvOrdenCarga";
            this.dgvOrdenCarga.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenCarga.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOrdenCarga.RowHeadersVisible = false;
            this.dgvOrdenCarga.RowHeadersWidth = 38;
            this.dgvOrdenCarga.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdenCarga.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvOrdenCarga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenCarga.Size = new System.Drawing.Size(804, 321);
            this.dgvOrdenCarga.TabIndex = 608;
            // 
            // colNumeroMovimiento2
            // 
            this.colNumeroMovimiento2.HeaderText = "Ordern de carga";
            this.colNumeroMovimiento2.Name = "colNumeroMovimiento2";
            this.colNumeroMovimiento2.Width = 250;
            // 
            // colMovimiento2
            // 
            this.colMovimiento2.HeaderText = "Producto";
            this.colMovimiento2.Name = "colMovimiento2";
            this.colMovimiento2.Width = 300;
            // 
            // colCantidadOC
            // 
            this.colCantidadOC.HeaderText = "Cantidad";
            this.colCantidadOC.Name = "colCantidadOC";
            this.colCantidadOC.Width = 250;
            // 
            // frmRelacionesMovProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(810, 726);
            this.Controls.Add(this.dgvOrdenCarga);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvInsumo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRelacionesMovProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRelacionesMovProduccion";
            this.Load += new System.EventHandler(this.frmRelacionesMovProduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCarga)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInsumo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvOrdenCarga;
        private System.Windows.Forms.Button bunifuFlatButton3;
        private System.Windows.Forms.Button bunifuFlatButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroMovimiento2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovimiento2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadOC;
    }
}