
namespace PCodin_Sinlacc.Formularios.Configuracion
{
    partial class frmConfigProduccion
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
            this.label10 = new System.Windows.Forms.Label();
            this.rdbBase = new System.Windows.Forms.RadioButton();
            this.rdbFull = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 21);
            this.label10.TabIndex = 529;
            this.label10.Text = "Tipo de depósito";
            // 
            // rdbBase
            // 
            this.rdbBase.AutoSize = true;
            this.rdbBase.Checked = true;
            this.rdbBase.Location = new System.Drawing.Point(24, 12);
            this.rdbBase.Name = "rdbBase";
            this.rdbBase.Size = new System.Drawing.Size(49, 17);
            this.rdbBase.TabIndex = 530;
            this.rdbBase.TabStop = true;
            this.rdbBase.Text = "Base";
            this.rdbBase.UseVisualStyleBackColor = true;
            // 
            // rdbFull
            // 
            this.rdbFull.AutoSize = true;
            this.rdbFull.Location = new System.Drawing.Point(142, 12);
            this.rdbFull.Name = "rdbFull";
            this.rdbFull.Size = new System.Drawing.Size(41, 17);
            this.rdbFull.TabIndex = 531;
            this.rdbFull.Text = "Full";
            this.rdbFull.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbFull);
            this.groupBox1.Controls.Add(this.rdbBase);
            this.groupBox1.Location = new System.Drawing.Point(143, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 40);
            this.groupBox1.TabIndex = 532;
            this.groupBox1.TabStop = false;
            // 
            // frmConfigProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1157, 596);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConfigProduccion";
            this.Text = "frmConfigProduccion";
            this.Load += new System.EventHandler(this.frmConfigProduccion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rdbBase;
        public System.Windows.Forms.RadioButton rdbFull;
    }
}