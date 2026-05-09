using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Formularios;

namespace PCodin_Sinlacc
{
    class AbrirFormulariosEnPanel
    {
        public static void AbrirFormulariosHijos(object FormHijo,Panel Panel ,Label lblTitulo)
        {
            if (Panel.Controls.Count > 0)
            {              
                Panel.Controls.RemoveAt(0);
                Panel.Controls.Clear();
            }
            Form f = FormHijo as Form;
            
            f.TopLevel = false;          
            Panel.AutoScroll = true;
            Panel.Size = new System.Drawing.Size(clsVariablesGenerales.WpnlCentral, clsVariablesGenerales.HpnlCentral);
            Panel.Controls.Add(f);
            Panel.Tag = f;

            //Panel2.AutoScroll = true;
            //Panel2.Size = new System.Drawing.Size(clsVariablesGenerales.WpnlCentral, clsVariablesGenerales.HpnlCentral);
            //Panel2.Controls.Add(f);
            //Panel2.Tag = f;

            //f.Size = new System.Drawing.Size(clsVariablesGenerales.WpnlCentral, clsVariablesGenerales.HpnlCentral);
            f.StartPosition = FormStartPosition.CenterParent;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        public static void AbrirFormulariosHijosDeposito(object FormHijo, Panel Panel)
        {
            if (Panel.Controls.Count > 0)
            {
                Panel.Controls.Clear();
            }
            Form f = FormHijo as Form;
            f.TopLevel = false;
            Panel.AutoScroll = true;
            Panel.Controls.Add(f);
            Panel.Tag = f;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }
}
