namespace PCodin_Sinlacc.Formularios.MANTENIMIENTO.Registro_de_mantenimiento
{
    partial class frmRegistroMantenimientoAgregarTarea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroMantenimientoAgregarTarea));
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscarResponsable = new System.Windows.Forms.TextBox();
            this.cmbResponsable = new System.Windows.Forms.ComboBox();
            this.btnBuscarResponsable = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btnCargar = new System.Windows.Forms.Button();
            this.pnlSuperior.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(140, 17);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(131, 22);
            this.dtpFecha.TabIndex = 671;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 19);
            this.label10.TabIndex = 670;
            this.label10.Text = "Fecha";
            // 
            // dtpFechaLimite
            // 
            this.dtpFechaLimite.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaLimite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLimite.Location = new System.Drawing.Point(140, 63);
            this.dtpFechaLimite.Name = "dtpFechaLimite";
            this.dtpFechaLimite.Size = new System.Drawing.Size(131, 22);
            this.dtpFechaLimite.TabIndex = 673;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 672;
            this.label1.Text = "Fecha limite";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 674;
            this.label2.Text = "Responsable";
            // 
            // txtBuscarResponsable
            // 
            this.txtBuscarResponsable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBuscarResponsable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarResponsable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarResponsable.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarResponsable.Location = new System.Drawing.Point(140, 106);
            this.txtBuscarResponsable.Name = "txtBuscarResponsable";
            this.txtBuscarResponsable.Size = new System.Drawing.Size(340, 22);
            this.txtBuscarResponsable.TabIndex = 754;
            this.txtBuscarResponsable.Visible = false;
            this.txtBuscarResponsable.Click += new System.EventHandler(this.txtBuscarResponsable_Click);
            // 
            // cmbResponsable
            // 
            this.cmbResponsable.BackColor = System.Drawing.Color.White;
            this.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsable.FormattingEnabled = true;
            this.cmbResponsable.Location = new System.Drawing.Point(141, 108);
            this.cmbResponsable.Name = "cmbResponsable";
            this.cmbResponsable.Size = new System.Drawing.Size(340, 21);
            this.cmbResponsable.TabIndex = 752;
            // 
            // btnBuscarResponsable
            // 
            this.btnBuscarResponsable.BackColor = System.Drawing.Color.White;
            this.btnBuscarResponsable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarResponsable.BackgroundImage")));
            this.btnBuscarResponsable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarResponsable.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscarResponsable.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBuscarResponsable.FlatAppearance.BorderSize = 0;
            this.btnBuscarResponsable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnBuscarResponsable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarResponsable.Location = new System.Drawing.Point(498, 105);
            this.btnBuscarResponsable.Name = "btnBuscarResponsable";
            this.btnBuscarResponsable.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarResponsable.TabIndex = 753;
            this.btnBuscarResponsable.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.TabIndex = 755;
            this.label3.Text = "Estado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Pendiente",
            "Finalizada",
            "Cancelada"});
            this.cmbEstado.Location = new System.Drawing.Point(141, 157);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(131, 21);
            this.cmbEstado.TabIndex = 756;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.cmbEstado);
            this.pnlSuperior.Controls.Add(this.label3);
            this.pnlSuperior.Controls.Add(this.btnBuscarResponsable);
            this.pnlSuperior.Controls.Add(this.txtBuscarResponsable);
            this.pnlSuperior.Controls.Add(this.cmbResponsable);
            this.pnlSuperior.Controls.Add(this.label2);
            this.pnlSuperior.Controls.Add(this.dtpFechaLimite);
            this.pnlSuperior.Controls.Add(this.label1);
            this.pnlSuperior.Controls.Add(this.dtpFecha);
            this.pnlSuperior.Controls.Add(this.label10);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(651, 236);
            this.pnlSuperior.TabIndex = 757;
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInferior.Controls.Add(this.btnCargar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 236);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.pnlInferior.Size = new System.Drawing.Size(651, 55);
            this.pnlInferior.TabIndex = 758;
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
            this.btnCargar.Location = new System.Drawing.Point(10, 5);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(208, 45);
            this.btnCargar.TabIndex = 763;
            this.btnCargar.Text = "   Modificar tarea";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // frmRegistroMantenimientoAgregarTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(651, 291);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.pnlInferior);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegistroMantenimientoAgregarTarea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar tarea";
            this.Load += new System.EventHandler(this.frmRegistroMantenimientoAgregarTarea_Load);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFechaLimite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarResponsable;
        private System.Windows.Forms.TextBox txtBuscarResponsable;
        private System.Windows.Forms.ComboBox cmbResponsable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Button btnCargar;
    }
}