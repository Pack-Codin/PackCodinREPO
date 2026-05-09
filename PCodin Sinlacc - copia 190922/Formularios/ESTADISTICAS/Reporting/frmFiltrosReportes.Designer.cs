namespace PCodin_Sinlacc.Formularios
{
    partial class frmFiltrosReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltrosReportes));
            this.label1 = new System.Windows.Forms.Label();
            this.btnListarInf = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(807, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // btnListarInf
            // 
            this.btnListarInf.BackColor = System.Drawing.Color.White;
            this.btnListarInf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnListarInf.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnListarInf.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnListarInf.FlatAppearance.BorderSize = 2;
            this.btnListarInf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnListarInf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnListarInf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarInf.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarInf.Image = ((System.Drawing.Image)(resources.GetObject("btnListarInf.Image")));
            this.btnListarInf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListarInf.Location = new System.Drawing.Point(0, 0);
            this.btnListarInf.Name = "btnListarInf";
            this.btnListarInf.Size = new System.Drawing.Size(326, 41);
            this.btnListarInf.TabIndex = 673;
            this.btnListarInf.Text = "   Listar informe";
            this.btnListarInf.UseVisualStyleBackColor = false;
            this.btnListarInf.Click += new System.EventHandler(this.btnListarInf_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnListarInf);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(1, 378);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 41);
            this.panel1.TabIndex = 674;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // frmFiltrosReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1159, 420);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFiltrosReportes";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "frmFiltrosReportes";
            this.Load += new System.EventHandler(this.frmFiltrosReportes_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnListarInf;
        private System.Windows.Forms.Panel panel1;
    }
}