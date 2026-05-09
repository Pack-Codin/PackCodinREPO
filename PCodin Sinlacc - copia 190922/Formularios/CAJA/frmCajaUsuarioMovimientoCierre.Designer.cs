
namespace PCodin_Sinlacc.Formularios.CAJA
{
    partial class frmCajaUsuarioMovimientoCierre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCajaUsuarioMovimientoCierre));
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnCargar = new System.Windows.Forms.Button();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtDejoEnCaja = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEfectivoRetirado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEfectivoCaja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pnlInferior.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.panel14);
            this.pnlInferior.Controls.Add(this.panel10);
            this.pnlInferior.Controls.Add(this.btnCargar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 183);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.pnlInferior.Size = new System.Drawing.Size(800, 42);
            this.pnlInferior.TabIndex = 676;
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
            this.btnCargar.Location = new System.Drawing.Point(8, 3);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(184, 36);
            this.btnCargar.TabIndex = 672;
            this.btnCargar.Text = "   Cerrar caja";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // pnlCentral
            // 
            this.pnlCentral.BackColor = System.Drawing.Color.White;
            this.pnlCentral.Controls.Add(this.btnActualizar);
            this.pnlCentral.Controls.Add(this.txtDejoEnCaja);
            this.pnlCentral.Controls.Add(this.label3);
            this.pnlCentral.Controls.Add(this.txtEfectivoRetirado);
            this.pnlCentral.Controls.Add(this.label2);
            this.pnlCentral.Controls.Add(this.txtEfectivoCaja);
            this.pnlCentral.Controls.Add(this.label1);
            this.pnlCentral.Controls.Add(this.panel9);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(0, 0);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Padding = new System.Windows.Forms.Padding(3);
            this.pnlCentral.Size = new System.Drawing.Size(800, 183);
            this.pnlCentral.TabIndex = 677;
            this.pnlCentral.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCentral_Paint);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar.BackgroundImage")));
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Location = new System.Drawing.Point(410, 106);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(32, 30);
            this.btnActualizar.TabIndex = 685;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtDejoEnCaja
            // 
            this.txtDejoEnCaja.Font = new System.Drawing.Font("Roboto Condensed", 14.25F);
            this.txtDejoEnCaja.Location = new System.Drawing.Point(192, 106);
            this.txtDejoEnCaja.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.txtDejoEnCaja.Name = "txtDejoEnCaja";
            this.txtDejoEnCaja.Size = new System.Drawing.Size(212, 30);
            this.txtDejoEnCaja.TabIndex = 684;
            this.txtDejoEnCaja.Text = "0,00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 683;
            this.label3.Text = "Dejo en caja";
            // 
            // txtEfectivoRetirado
            // 
            this.txtEfectivoRetirado.Font = new System.Drawing.Font("Roboto Condensed", 14.25F);
            this.txtEfectivoRetirado.Location = new System.Drawing.Point(192, 63);
            this.txtEfectivoRetirado.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.txtEfectivoRetirado.Name = "txtEfectivoRetirado";
            this.txtEfectivoRetirado.ReadOnly = true;
            this.txtEfectivoRetirado.Size = new System.Drawing.Size(212, 30);
            this.txtEfectivoRetirado.TabIndex = 682;
            this.txtEfectivoRetirado.Text = "0,00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 681;
            this.label2.Text = "Efectivo retirado";
            // 
            // txtEfectivoCaja
            // 
            this.txtEfectivoCaja.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivoCaja.Location = new System.Drawing.Point(192, 21);
            this.txtEfectivoCaja.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.txtEfectivoCaja.Name = "txtEfectivoCaja";
            this.txtEfectivoCaja.ReadOnly = true;
            this.txtEfectivoCaja.Size = new System.Drawing.Size(212, 30);
            this.txtEfectivoCaja.TabIndex = 680;
            this.txtEfectivoCaja.Text = "0,00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 679;
            this.label1.Text = "Efectivo total en caja";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(794, 2);
            this.panel9.TabIndex = 678;
            // 
            // frmCajaUsuarioMovimientoCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 225);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.pnlInferior);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCajaUsuarioMovimientoCierre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistente de cierre de caja";
            this.Load += new System.EventHandler(this.frmCajaUsuarioMovimientoCierre_Load);
            this.pnlInferior.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.pnlCentral.ResumeLayout(false);
            this.pnlCentral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDejoEnCaja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEfectivoRetirado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEfectivoCaja;
        private System.Windows.Forms.Button btnActualizar;
    }
}