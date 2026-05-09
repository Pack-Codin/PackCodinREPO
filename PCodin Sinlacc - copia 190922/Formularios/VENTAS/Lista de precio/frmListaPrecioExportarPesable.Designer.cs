namespace PCodin_Sinlacc.Formularios.VENTAS.Lista_de_precio
{
    partial class frmListaPrecioExportarPesable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaPrecioExportarPesable));
            this.Label6 = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnElegirRuta = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbBalanzaTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Label6.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(9, 65);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(39, 19);
            this.Label6.TabIndex = 588;
            this.Label6.Text = "Ruta";
            // 
            // txtRuta
            // 
            this.txtRuta.BackColor = System.Drawing.Color.White;
            this.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.ForeColor = System.Drawing.Color.Black;
            this.txtRuta.Location = new System.Drawing.Point(84, 63);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(823, 21);
            this.txtRuta.TabIndex = 587;
            // 
            // btnElegirRuta
            // 
            this.btnElegirRuta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnElegirRuta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnElegirRuta.BackgroundImage")));
            this.btnElegirRuta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnElegirRuta.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnElegirRuta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnElegirRuta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnElegirRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElegirRuta.Location = new System.Drawing.Point(922, 59);
            this.btnElegirRuta.Name = "btnElegirRuta";
            this.btnElegirRuta.Size = new System.Drawing.Size(30, 29);
            this.btnElegirRuta.TabIndex = 589;
            this.btnElegirRuta.UseVisualStyleBackColor = false;
            this.btnElegirRuta.Click += new System.EventHandler(this.btnElegirRuta_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cmbBalanzaTipo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.btnElegirRuta);
            this.panel1.Controls.Add(this.Label6);
            this.panel1.Controls.Add(this.txtRuta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(975, 156);
            this.panel1.TabIndex = 590;
            // 
            // cmbBalanzaTipo
            // 
            this.cmbBalanzaTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBalanzaTipo.FormattingEnabled = true;
            this.cmbBalanzaTipo.Items.AddRange(new object[] {
            "",
            "Cuora Max"});
            this.cmbBalanzaTipo.Location = new System.Drawing.Point(84, 18);
            this.cmbBalanzaTipo.Name = "cmbBalanzaTipo";
            this.cmbBalanzaTipo.Size = new System.Drawing.Size(230, 21);
            this.cmbBalanzaTipo.TabIndex = 681;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 680;
            this.label1.Text = "Balanza";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(3);
            this.panel9.Size = new System.Drawing.Size(969, 2);
            this.panel9.TabIndex = 679;
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.panel14);
            this.pnlInferior.Controls.Add(this.panel10);
            this.pnlInferior.Controls.Add(this.btnExportar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 162);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.pnlInferior.Size = new System.Drawing.Size(975, 42);
            this.pnlInferior.TabIndex = 677;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Transparent;
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(202, 3);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(10, 36);
            this.panel14.TabIndex = 677;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Controls.Add(this.panel13);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(192, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(10, 36);
            this.panel10.TabIndex = 674;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Transparent;
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(10, 36);
            this.panel13.TabIndex = 675;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExportar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnExportar.FlatAppearance.BorderSize = 2;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(8, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(184, 36);
            this.btnExportar.TabIndex = 672;
            this.btnExportar.Text = "   Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmListaPrecioExportarPesable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 204);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaPrecioExportarPesable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar Pesables";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnElegirRuta;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBalanzaTipo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}