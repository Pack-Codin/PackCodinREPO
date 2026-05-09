using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PCodin_Sinlacc.Formularios
{
    public partial class frmPantallaEspera : Form
    {      
        //public Action Proceso { get; set; }
      
        public frmPantallaEspera()
        {
            InitializeComponent();
            //label1.Text = Titulo;
            //Proceso = proceso;
        }
        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    Task.Factory.StartNew(Proceso).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        //}
        private void frmPantallaEspera_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
            textBox2.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
