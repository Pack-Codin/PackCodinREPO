using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;
using System.Diagnostics;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmFormMovimientoFinalizado : Form
    {
        public frmFormMovimientoFinalizado()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmFormMovimientoFinalizado_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(-200, 3);

            Transition T1 = new Transition(new TransitionType_EaseInEaseOut(350));
            T1.add(panel1, "Left", 11);
            T1.run();
        }

        private void frmFormMovimientoFinalizado_Shown(object sender, EventArgs e)
        {
           
        }

        private void btnProducirOrden_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
