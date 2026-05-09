namespace PCodin_Sinlacc.Formularios
{
    partial class TEST
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
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Deposito", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TEST));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colProducto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCantidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeposito = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAfectados = new System.Windows.Forms.Button();
            this.btnAfectar = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.button8 = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnGenerarCode = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.AllowDrop = true;
            this.textBox2.Location = new System.Drawing.Point(315, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.textBox1.Location = new System.Drawing.Point(274, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.Location = new System.Drawing.Point(364, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(871, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 23);
            this.button2.TabIndex = 605;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(209, 23);
            this.button3.TabIndex = 636;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 54);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(209, 23);
            this.button4.TabIndex = 637;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.AllowDrop = true;
            this.button5.Location = new System.Drawing.Point(651, 21);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(209, 23);
            this.button5.TabIndex = 638;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(651, 50);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(186, 20);
            this.textBox3.TabIndex = 640;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProducto,
            this.colCantidad,
            this.colDeposito});
            listViewGroup2.Header = "Deposito";
            listViewGroup2.Name = "GrupoDeposito";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(642, 449);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(572, 228);
            this.listView1.TabIndex = 641;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colProducto
            // 
            this.colProducto.Text = "Producto";
            this.colProducto.Width = 134;
            // 
            // colCantidad
            // 
            this.colCantidad.Text = "Cantidad";
            this.colCantidad.Width = 131;
            // 
            // colDeposito
            // 
            this.colDeposito.Text = "Deposito";
            this.colDeposito.Width = 142;
            // 
            // txtDataSource
            // 
            this.txtDataSource.AllowDrop = true;
            this.txtDataSource.Location = new System.Drawing.Point(12, 264);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(291, 20);
            this.txtDataSource.TabIndex = 642;
            // 
            // txtDB
            // 
            this.txtDB.AllowDrop = true;
            this.txtDB.Location = new System.Drawing.Point(12, 290);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(291, 20);
            this.txtDB.TabIndex = 644;
            // 
            // txtUser
            // 
            this.txtUser.AllowDrop = true;
            this.txtUser.Location = new System.Drawing.Point(12, 306);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(291, 20);
            this.txtUser.TabIndex = 645;
            // 
            // button6
            // 
            this.button6.AllowDrop = true;
            this.button6.Location = new System.Drawing.Point(12, 202);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(291, 23);
            this.button6.TabIndex = 646;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PCodin_Sinlacc.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(415, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 639;
            this.pictureBox1.TabStop = false;
            // 
            // btnAfectados
            // 
            this.btnAfectados.BackColor = System.Drawing.Color.White;
            this.btnAfectados.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAfectados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAfectados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnAfectados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfectados.Image = ((System.Drawing.Image)(resources.GetObject("btnAfectados.Image")));
            this.btnAfectados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAfectados.Location = new System.Drawing.Point(137, 153);
            this.btnAfectados.Name = "btnAfectados";
            this.btnAfectados.Size = new System.Drawing.Size(147, 28);
            this.btnAfectados.TabIndex = 635;
            this.btnAfectados.Text = "     Pedidos afectados";
            this.btnAfectados.UseVisualStyleBackColor = false;
            this.btnAfectados.Click += new System.EventHandler(this.btnAfectados_Click);
            // 
            // btnAfectar
            // 
            this.btnAfectar.BackColor = System.Drawing.Color.White;
            this.btnAfectar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAfectar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAfectar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnAfectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfectar.Image = ((System.Drawing.Image)(resources.GetObject("btnAfectar.Image")));
            this.btnAfectar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAfectar.Location = new System.Drawing.Point(12, 153);
            this.btnAfectar.Name = "btnAfectar";
            this.btnAfectar.Size = new System.Drawing.Size(128, 28);
            this.btnAfectar.TabIndex = 634;
            this.btnAfectar.Text = "        Afectar pedido";
            this.btnAfectar.UseVisualStyleBackColor = false;
            this.btnAfectar.Click += new System.EventHandler(this.btnAfectar_Click);
            // 
            // txtPass
            // 
            this.txtPass.AllowDrop = true;
            this.txtPass.Location = new System.Drawing.Point(12, 346);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(291, 20);
            this.txtPass.TabIndex = 647;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(609, 360);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(345, 21);
            this.comboBox1.TabIndex = 648;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(642, 407);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(312, 23);
            this.button7.TabIndex = 649;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(585, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(334, 208);
            this.dataGridView1.TabIndex = 650;
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.ForeColor = System.Drawing.Color.Crimson;
            this.circularProgressBar1.InnerColor = System.Drawing.Color.WhiteSmoke;
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(395, 264);
            this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.LightGray;
            this.circularProgressBar1.OuterMargin = -25;
            this.circularProgressBar1.OuterWidth = 26;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.Crimson;
            this.circularProgressBar1.ProgressWidth = 25;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.Size = new System.Drawing.Size(156, 160);
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 1048;
            this.circularProgressBar1.Text = "50 %";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 4, 0, 0);
            this.circularProgressBar1.Value = 50;
            // 
            // button8
            // 
            this.button8.AllowDrop = true;
            this.button8.Location = new System.Drawing.Point(415, 47);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(209, 23);
            this.button8.TabIndex = 1049;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // txtCode
            // 
            this.txtCode.AllowDrop = true;
            this.txtCode.Location = new System.Drawing.Point(24, 449);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(140, 20);
            this.txtCode.TabIndex = 1050;
            // 
            // btnGenerarCode
            // 
            this.btnGenerarCode.AllowDrop = true;
            this.btnGenerarCode.Location = new System.Drawing.Point(199, 449);
            this.btnGenerarCode.Name = "btnGenerarCode";
            this.btnGenerarCode.Size = new System.Drawing.Size(158, 23);
            this.btnGenerarCode.TabIndex = 1051;
            this.btnGenerarCode.Text = "button9";
            this.btnGenerarCode.UseVisualStyleBackColor = true;
            this.btnGenerarCode.Click += new System.EventHandler(this.btnGenerarCode_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(24, 496);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(333, 81);
            this.pictureBox2.TabIndex = 1052;
            this.pictureBox2.TabStop = false;
            // 
            // TEST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 589);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnGenerarCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.circularProgressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtDB);
            this.Controls.Add(this.txtDataSource);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAfectados);
            this.Controls.Add(this.btnAfectar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Name = "TEST";
            this.Text = "TEST";
            this.Load += new System.EventHandler(this.TEST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAfectados;
        private System.Windows.Forms.Button btnAfectar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colProducto;
        private System.Windows.Forms.ColumnHeader colCantidad;
        private System.Windows.Forms.ColumnHeader colDeposito;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnGenerarCode;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}