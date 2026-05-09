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
    public partial class PantallaEspera2 : Form
    {
        public Action Proceso { get; set; }
        public PantallaEspera2(Action proceso, string Titulo)
        {
            InitializeComponent();
            label1.Text = Titulo;
            Proceso = proceso;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Proceso).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PantallaEspera2_Load(object sender, EventArgs e)
        {

        }
    }
}
