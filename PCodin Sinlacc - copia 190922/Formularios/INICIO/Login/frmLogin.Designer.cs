namespace PCodin_Sinlacc.Formularios
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.chkmodoSeguro = new System.Windows.Forms.CheckBox();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.btnActualizarLicencia = new System.Windows.Forms.Button();
            this.btnModoMobile = new System.Windows.Forms.Button();
            this.btnModoEscritorio = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlPrincipal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::PCodin_Sinlacc.Properties.Resources.Logo_Pack_Codin;
            this.pictureBox2.Location = new System.Drawing.Point(106, 51);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(279, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 596;
            this.pictureBox2.TabStop = false;
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.White;
            this.txtPass.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(73, 283);
            this.txtPass.Multiline = true;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(331, 37);
            this.txtPass.TabIndex = 593;
            this.txtPass.Click += new System.EventHandler(this.txtPass_Click);
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(255, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 591;
            this.label1.Text = "Usuario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.Font = new System.Drawing.Font("Roboto Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(73, 195);
            this.txtUsuario.MaxLength = 32555;
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(331, 37);
            this.txtUsuario.TabIndex = 590;
            this.txtUsuario.WordWrap = false;
            this.txtUsuario.Click += new System.EventHandler(this.txtUsuario_Click);
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // chkmodoSeguro
            // 
            this.chkmodoSeguro.AutoSize = true;
            this.chkmodoSeguro.BackColor = System.Drawing.Color.Transparent;
            this.chkmodoSeguro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkmodoSeguro.ForeColor = System.Drawing.Color.Black;
            this.chkmodoSeguro.Location = new System.Drawing.Point(15, 426);
            this.chkmodoSeguro.Name = "chkmodoSeguro";
            this.chkmodoSeguro.Size = new System.Drawing.Size(458, 17);
            this.chkmodoSeguro.TabIndex = 597;
            this.chkmodoSeguro.Text = "Modo seguro";
            this.chkmodoSeguro.UseVisualStyleBackColor = false;
            // 
            // btnIngreso
            // 
            this.btnIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnIngreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnIngreso.FlatAppearance.BorderSize = 0;
            this.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngreso.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreso.Location = new System.Drawing.Point(15, 379);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(458, 47);
            this.btnIngreso.TabIndex = 600;
            this.btnIngreso.Text = "Ingresar";
            this.btnIngreso.UseVisualStyleBackColor = false;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Controls.Add(this.btnActualizarLicencia);
            this.pnlPrincipal.Controls.Add(this.btnModoMobile);
            this.pnlPrincipal.Controls.Add(this.btnModoEscritorio);
            this.pnlPrincipal.Controls.Add(this.panel1);
            this.pnlPrincipal.Controls.Add(this.pnlUsuario);
            this.pnlPrincipal.Controls.Add(this.btnIngreso);
            this.pnlPrincipal.Controls.Add(this.chkmodoSeguro);
            this.pnlPrincipal.Controls.Add(this.pictureBox2);
            this.pnlPrincipal.Controls.Add(this.txtUsuario);
            this.pnlPrincipal.Controls.Add(this.txtPass);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(4, 4);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Padding = new System.Windows.Forms.Padding(15);
            this.pnlPrincipal.Size = new System.Drawing.Size(488, 458);
            this.pnlPrincipal.TabIndex = 601;
            // 
            // btnActualizarLicencia
            // 
            this.btnActualizarLicencia.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizarLicencia.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizarLicencia.BackgroundImage")));
            this.btnActualizarLicencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizarLicencia.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnActualizarLicencia.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnActualizarLicencia.FlatAppearance.BorderSize = 0;
            this.btnActualizarLicencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnActualizarLicencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarLicencia.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarLicencia.ForeColor = System.Drawing.Color.White;
            this.btnActualizarLicencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarLicencia.Location = new System.Drawing.Point(434, 3);
            this.btnActualizarLicencia.Name = "btnActualizarLicencia";
            this.btnActualizarLicencia.Size = new System.Drawing.Size(51, 38);
            this.btnActualizarLicencia.TabIndex = 605;
            this.btnActualizarLicencia.UseVisualStyleBackColor = false;
            this.btnActualizarLicencia.Click += new System.EventHandler(this.btnActualizarLicencia_Click);
            // 
            // btnModoMobile
            // 
            this.btnModoMobile.BackColor = System.Drawing.Color.Transparent;
            this.btnModoMobile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnModoMobile.BackgroundImage")));
            this.btnModoMobile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnModoMobile.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnModoMobile.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnModoMobile.FlatAppearance.BorderSize = 0;
            this.btnModoMobile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnModoMobile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModoMobile.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModoMobile.ForeColor = System.Drawing.Color.White;
            this.btnModoMobile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModoMobile.Location = new System.Drawing.Point(49, 3);
            this.btnModoMobile.Name = "btnModoMobile";
            this.btnModoMobile.Size = new System.Drawing.Size(51, 38);
            this.btnModoMobile.TabIndex = 604;
            this.btnModoMobile.UseVisualStyleBackColor = false;
            this.btnModoMobile.Click += new System.EventHandler(this.btnModoMobile_Click);
            // 
            // btnModoEscritorio
            // 
            this.btnModoEscritorio.BackColor = System.Drawing.Color.Orange;
            this.btnModoEscritorio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnModoEscritorio.BackgroundImage")));
            this.btnModoEscritorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnModoEscritorio.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnModoEscritorio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnModoEscritorio.FlatAppearance.BorderSize = 0;
            this.btnModoEscritorio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnModoEscritorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModoEscritorio.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModoEscritorio.ForeColor = System.Drawing.Color.White;
            this.btnModoEscritorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModoEscritorio.Location = new System.Drawing.Point(3, 3);
            this.btnModoEscritorio.Name = "btnModoEscritorio";
            this.btnModoEscritorio.Size = new System.Drawing.Size(51, 38);
            this.btnModoEscritorio.TabIndex = 603;
            this.btnModoEscritorio.UseVisualStyleBackColor = false;
            this.btnModoEscritorio.Click += new System.EventHandler(this.btnModoEscritorio_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(73, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 29);
            this.panel1.TabIndex = 602;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(277, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 591;
            this.label3.Text = "Pass";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlUsuario.Controls.Add(this.label1);
            this.pnlUsuario.Location = new System.Drawing.Point(73, 160);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(331, 29);
            this.pnlUsuario.TabIndex = 601;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(496, 466);
            this.Controls.Add(this.pnlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.Opacity = 0.9D;
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlUsuario.ResumeLayout(false);
            this.pnlUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.CheckBox chkmodoSeguro;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnModoMobile;
        private System.Windows.Forms.Button btnModoEscritorio;
        private System.Windows.Forms.Button btnActualizarLicencia;
    }
}