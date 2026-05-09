using System;

namespace PCodin_Sinlacc.Formularios.OTROS
{
    partial class frmCalculadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculadora));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSuma = new System.Windows.Forms.Button();
            this.btnPunto = new System.Windows.Forms.Button();
            this.btnCero = new System.Windows.Forms.Button();
            this.btnNueve = new System.Windows.Forms.Button();
            this.btnOcho = new System.Windows.Forms.Button();
            this.btnSiete = new System.Windows.Forms.Button();
            this.btnSeis = new System.Windows.Forms.Button();
            this.btnCinco = new System.Windows.Forms.Button();
            this.btnCuatro = new System.Windows.Forms.Button();
            this.btnTres = new System.Windows.Forms.Button();
            this.btnDos = new System.Windows.Forms.Button();
            this.btnUno = new System.Windows.Forms.Button();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.cajaResultado = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnCargar);
            this.panel1.Controls.Add(this.btnBorrar);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnSuma);
            this.panel1.Controls.Add(this.btnPunto);
            this.panel1.Controls.Add(this.btnCero);
            this.panel1.Controls.Add(this.btnNueve);
            this.panel1.Controls.Add(this.btnOcho);
            this.panel1.Controls.Add(this.btnSiete);
            this.panel1.Controls.Add(this.btnSeis);
            this.panel1.Controls.Add(this.btnCinco);
            this.panel1.Controls.Add(this.btnCuatro);
            this.panel1.Controls.Add(this.btnTres);
            this.panel1.Controls.Add(this.btnDos);
            this.panel1.Controls.Add(this.btnUno);
            this.panel1.Controls.Add(this.lblHistorial);
            this.panel1.Controls.Add(this.cajaResultado);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(422, 443);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Teal;
            this.pictureBox1.Location = new System.Drawing.Point(41, 315);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 3);
            this.pictureBox1.TabIndex = 682;
            this.pictureBox1.TabStop = false;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCargar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnCargar.FlatAppearance.BorderSize = 2;
            this.btnCargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.Image = ((System.Drawing.Image)(resources.GetObject("btnCargar.Image")));
            this.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargar.Location = new System.Drawing.Point(10, 392);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(402, 41);
            this.btnCargar.TabIndex = 681;
            this.btnCargar.Text = "Adjuntar calculo";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(275, 130);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(46, 41);
            this.btnBorrar.TabIndex = 37;
            this.btnBorrar.Text = "<";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click_1);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(123, 84);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(197, 41);
            this.btnReset.TabIndex = 36;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click_1);
            // 
            // btnSuma
            // 
            this.btnSuma.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSuma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuma.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuma.Location = new System.Drawing.Point(274, 176);
            this.btnSuma.Margin = new System.Windows.Forms.Padding(2);
            this.btnSuma.Name = "btnSuma";
            this.btnSuma.Size = new System.Drawing.Size(46, 41);
            this.btnSuma.TabIndex = 34;
            this.btnSuma.Text = "+";
            this.btnSuma.UseVisualStyleBackColor = false;
            this.btnSuma.Click += new System.EventHandler(this.btnSuma_Click_1);
            // 
            // btnPunto
            // 
            this.btnPunto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPunto.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnPunto.FlatAppearance.BorderSize = 2;
            this.btnPunto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPunto.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPunto.ForeColor = System.Drawing.Color.White;
            this.btnPunto.Location = new System.Drawing.Point(224, 269);
            this.btnPunto.Margin = new System.Windows.Forms.Padding(2);
            this.btnPunto.Name = "btnPunto";
            this.btnPunto.Size = new System.Drawing.Size(46, 41);
            this.btnPunto.TabIndex = 33;
            this.btnPunto.Text = ".";
            this.btnPunto.UseVisualStyleBackColor = false;
            // 
            // btnCero
            // 
            this.btnCero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCero.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCero.FlatAppearance.BorderSize = 2;
            this.btnCero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCero.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCero.ForeColor = System.Drawing.Color.White;
            this.btnCero.Location = new System.Drawing.Point(123, 269);
            this.btnCero.Margin = new System.Windows.Forms.Padding(2);
            this.btnCero.Name = "btnCero";
            this.btnCero.Size = new System.Drawing.Size(96, 41);
            this.btnCero.TabIndex = 32;
            this.btnCero.Text = "0";
            this.btnCero.UseVisualStyleBackColor = false;
            // 
            // btnNueve
            // 
            this.btnNueve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNueve.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnNueve.FlatAppearance.BorderSize = 2;
            this.btnNueve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNueve.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNueve.ForeColor = System.Drawing.Color.White;
            this.btnNueve.Location = new System.Drawing.Point(224, 130);
            this.btnNueve.Margin = new System.Windows.Forms.Padding(2);
            this.btnNueve.Name = "btnNueve";
            this.btnNueve.Size = new System.Drawing.Size(46, 41);
            this.btnNueve.TabIndex = 31;
            this.btnNueve.Text = "9";
            this.btnNueve.UseVisualStyleBackColor = false;
            // 
            // btnOcho
            // 
            this.btnOcho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOcho.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnOcho.FlatAppearance.BorderSize = 2;
            this.btnOcho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOcho.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOcho.ForeColor = System.Drawing.Color.White;
            this.btnOcho.Location = new System.Drawing.Point(173, 130);
            this.btnOcho.Margin = new System.Windows.Forms.Padding(2);
            this.btnOcho.Name = "btnOcho";
            this.btnOcho.Size = new System.Drawing.Size(46, 41);
            this.btnOcho.TabIndex = 30;
            this.btnOcho.Text = "8";
            this.btnOcho.UseVisualStyleBackColor = false;
            // 
            // btnSiete
            // 
            this.btnSiete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSiete.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnSiete.FlatAppearance.BorderSize = 2;
            this.btnSiete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiete.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiete.ForeColor = System.Drawing.Color.White;
            this.btnSiete.Location = new System.Drawing.Point(123, 130);
            this.btnSiete.Margin = new System.Windows.Forms.Padding(2);
            this.btnSiete.Name = "btnSiete";
            this.btnSiete.Size = new System.Drawing.Size(46, 41);
            this.btnSiete.TabIndex = 29;
            this.btnSiete.Text = "7";
            this.btnSiete.UseVisualStyleBackColor = false;
            // 
            // btnSeis
            // 
            this.btnSeis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSeis.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnSeis.FlatAppearance.BorderSize = 2;
            this.btnSeis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeis.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeis.ForeColor = System.Drawing.Color.White;
            this.btnSeis.Location = new System.Drawing.Point(224, 176);
            this.btnSeis.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeis.Name = "btnSeis";
            this.btnSeis.Size = new System.Drawing.Size(46, 41);
            this.btnSeis.TabIndex = 28;
            this.btnSeis.Text = "6";
            this.btnSeis.UseVisualStyleBackColor = false;
            // 
            // btnCinco
            // 
            this.btnCinco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCinco.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCinco.FlatAppearance.BorderSize = 2;
            this.btnCinco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCinco.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCinco.ForeColor = System.Drawing.Color.White;
            this.btnCinco.Location = new System.Drawing.Point(173, 176);
            this.btnCinco.Margin = new System.Windows.Forms.Padding(2);
            this.btnCinco.Name = "btnCinco";
            this.btnCinco.Size = new System.Drawing.Size(46, 41);
            this.btnCinco.TabIndex = 27;
            this.btnCinco.Text = "5";
            this.btnCinco.UseVisualStyleBackColor = false;
            // 
            // btnCuatro
            // 
            this.btnCuatro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCuatro.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCuatro.FlatAppearance.BorderSize = 2;
            this.btnCuatro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuatro.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuatro.ForeColor = System.Drawing.Color.White;
            this.btnCuatro.Location = new System.Drawing.Point(123, 176);
            this.btnCuatro.Margin = new System.Windows.Forms.Padding(2);
            this.btnCuatro.Name = "btnCuatro";
            this.btnCuatro.Size = new System.Drawing.Size(46, 41);
            this.btnCuatro.TabIndex = 26;
            this.btnCuatro.Text = "4";
            this.btnCuatro.UseVisualStyleBackColor = false;
            // 
            // btnTres
            // 
            this.btnTres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTres.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnTres.FlatAppearance.BorderSize = 2;
            this.btnTres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTres.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTres.ForeColor = System.Drawing.Color.White;
            this.btnTres.Location = new System.Drawing.Point(224, 223);
            this.btnTres.Margin = new System.Windows.Forms.Padding(2);
            this.btnTres.Name = "btnTres";
            this.btnTres.Size = new System.Drawing.Size(46, 41);
            this.btnTres.TabIndex = 25;
            this.btnTres.Text = "3";
            this.btnTres.UseVisualStyleBackColor = false;
            // 
            // btnDos
            // 
            this.btnDos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDos.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnDos.FlatAppearance.BorderSize = 2;
            this.btnDos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDos.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDos.ForeColor = System.Drawing.Color.White;
            this.btnDos.Location = new System.Drawing.Point(173, 223);
            this.btnDos.Margin = new System.Windows.Forms.Padding(2);
            this.btnDos.Name = "btnDos";
            this.btnDos.Size = new System.Drawing.Size(46, 41);
            this.btnDos.TabIndex = 24;
            this.btnDos.Text = "2";
            this.btnDos.UseVisualStyleBackColor = false;
            // 
            // btnUno
            // 
            this.btnUno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUno.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnUno.FlatAppearance.BorderSize = 2;
            this.btnUno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUno.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUno.ForeColor = System.Drawing.Color.White;
            this.btnUno.Location = new System.Drawing.Point(123, 223);
            this.btnUno.Margin = new System.Windows.Forms.Padding(2);
            this.btnUno.Name = "btnUno";
            this.btnUno.Size = new System.Drawing.Size(46, 41);
            this.btnUno.TabIndex = 23;
            this.btnUno.Text = "1";
            this.btnUno.UseVisualStyleBackColor = false;
            // 
            // lblHistorial
            // 
            this.lblHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.Location = new System.Drawing.Point(39, 325);
            this.lblHistorial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(348, 35);
            this.lblHistorial.TabIndex = 22;
            this.lblHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHistorial.Click += new System.EventHandler(this.lblHistorial_Click);
            // 
            // cajaResultado
            // 
            this.cajaResultado.BackColor = System.Drawing.Color.White;
            this.cajaResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cajaResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cajaResultado.Location = new System.Drawing.Point(123, 47);
            this.cajaResultado.Margin = new System.Windows.Forms.Padding(2);
            this.cajaResultado.Name = "cajaResultado";
            this.cajaResultado.ReadOnly = true;
            this.cajaResultado.Size = new System.Drawing.Size(198, 32);
            this.cajaResultado.TabIndex = 21;
            this.cajaResultado.Text = "0";
            this.cajaResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cajaResultado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cajaResultado_KeyDown_1);
            // 
            // frmCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 443);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora";
            this.Load += new System.EventHandler(this.frmCalculadora_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSuma;
        private System.Windows.Forms.Button btnPunto;
        private System.Windows.Forms.Button btnCero;
        private System.Windows.Forms.Button btnNueve;
        private System.Windows.Forms.Button btnOcho;
        private System.Windows.Forms.Button btnSiete;
        private System.Windows.Forms.Button btnSeis;
        private System.Windows.Forms.Button btnCinco;
        private System.Windows.Forms.Button btnCuatro;
        private System.Windows.Forms.Button btnTres;
        private System.Windows.Forms.Button btnDos;
        private System.Windows.Forms.Button btnUno;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.TextBox cajaResultado;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}