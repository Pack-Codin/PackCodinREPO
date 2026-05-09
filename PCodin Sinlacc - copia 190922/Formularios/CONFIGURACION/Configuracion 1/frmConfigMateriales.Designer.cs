
namespace PCodin_Sinlacc.Formularios.Configuracion
{
    partial class frmConfigMateriales
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
            this.txtProdDiaria = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkTrabajaStockNegativo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtProdDiaria
            // 
            this.txtProdDiaria.Location = new System.Drawing.Point(157, 8);
            this.txtProdDiaria.Name = "txtProdDiaria";
            this.txtProdDiaria.Size = new System.Drawing.Size(172, 20);
            this.txtProdDiaria.TabIndex = 529;
            this.txtProdDiaria.Click += new System.EventHandler(this.txtProdDiaria_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 21);
            this.label10.TabIndex = 528;
            this.label10.Text = "Días de Producción";
            // 
            // chkTrabajaStockNegativo
            // 
            this.chkTrabajaStockNegativo.AutoSize = true;
            this.chkTrabajaStockNegativo.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.chkTrabajaStockNegativo.Location = new System.Drawing.Point(12, 47);
            this.chkTrabajaStockNegativo.Name = "chkTrabajaStockNegativo";
            this.chkTrabajaStockNegativo.Size = new System.Drawing.Size(316, 25);
            this.chkTrabajaStockNegativo.TabIndex = 530;
            this.chkTrabajaStockNegativo.Text = "Trabaja con stock en negativo de insumos";
            this.chkTrabajaStockNegativo.UseVisualStyleBackColor = true;
            // 
            // frmConfigMateriales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1157, 596);
            this.Controls.Add(this.chkTrabajaStockNegativo);
            this.Controls.Add(this.txtProdDiaria);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConfigMateriales";
            this.Text = "frmConfigMateriales";
            this.Load += new System.EventHandler(this.frmConfigMateriales_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtProdDiaria;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.CheckBox chkTrabajaStockNegativo;
    }
}