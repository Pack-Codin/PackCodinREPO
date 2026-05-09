using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Clases.Formularios.Inicio
{
    public class frmMenu
    {
        public static Panel pnlCentral2;
        public static void PantallaCompleta(Panel pnlMenu, Panel pnlCentral , List<string> ListaFormulariosAbiertosForm, Button btnPantallaCompleta , Button btnPantallaReducida)
        {
            pnlMenu.Visible = false;
            pnlCentral.Size = new System.Drawing.Size(clsVariablesGenerales.WPantalla, clsVariablesGenerales.HPantalla);

            foreach (var Control in pnlCentral.Controls)
            {
                if (Control is Form)
                {
                    if (ListaFormulariosAbiertosForm.Contains(((Form)Control).Name))
                    {
                        int SubIndice = pnlCentral.Controls.IndexOf(((Form)Control));
                        pnlCentral.Controls.RemoveAt(SubIndice);

                        pnlCentral.Controls.Add(((Form)Control));
                        pnlCentral.Tag = ((Form)Control);
                        ((Form)Control).WindowState = FormWindowState.Maximized;
                        //((Form)Control).Size = new Size(1358, 694);

                        ((Form)Control).FindForm();

                        foreach(var SubControles in ((Form)Control).Controls)
                        {
                            if (SubControles is Form)
                            {
                                int SubIndice2 = ((Form)Control).Controls.IndexOf(((Form)SubControles));
                                ((Form)Control).Controls.RemoveAt(SubIndice2);

                                ((Form)Control).Controls.Add(((Form)SubControles));
                                ((Form)Control).Tag = ((Form)SubControles);
                                ((Form)SubControles).WindowState = FormWindowState.Maximized;
                                //((Form)Control).Size = new Size(1358, 694);

                                ((Form)SubControles).FindForm();

                                foreach (var SubControles2 in ((Form)SubControles).Controls)
                                {
                                    if (SubControles2 is Form)
                                    {
                                        int SubIndice3 = ((Form)SubControles).Controls.IndexOf(((Form)SubControles2));
                                        ((Form)SubControles).Controls.RemoveAt(SubIndice3);

                                        ((Form)SubControles).Controls.Add(((Form)SubControles2));
                                        ((Form)SubControles).Tag = ((Form)SubControles2);
                                        ((Form)SubControles2).WindowState = FormWindowState.Maximized;
                                        //((Form)Control).Size = new Size(1358, 694);

                                        ((Form)SubControles2).FindForm();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ((Form)Control).Close();
                    }
                }
            }
          
            btnPantallaCompleta.BackColor = Color.Orange;
            btnPantallaReducida.BackColor = Color.Transparent;
        }
        public interface IActiveForm
        {
            
        }
        public static void PantallaReducida(Panel pnlMenu, Panel pnlCentral, List<string> ListaFormulariosAbiertosForm, Button btnPantallaCompleta, Button btnPantallaReducida)
        {
            Form FormAbierto = new Form();
            pnlCentral.Size = new System.Drawing.Size(clsVariablesGenerales.WpnlCentral, clsVariablesGenerales.HpnlCentral);
            pnlMenu.Visible = true;
            foreach (var Control in pnlCentral.Controls)
            {
                if (Control is Form)
                {

                    if (ListaFormulariosAbiertosForm.Contains(((Form)Control).Name))
                    {
                        int SubIndice = pnlCentral.Controls.IndexOf(((Form)Control));
                        pnlCentral.Controls.RemoveAt(SubIndice);

                        pnlCentral.Controls.Add(((Form)Control));
                        ((Form)Control).TopLevel = false;
                        pnlCentral.Tag = ((Form)Control);
                        ((Form)Control).WindowState = FormWindowState.Normal;
                        ((Form)Control).StartPosition = FormStartPosition.CenterParent;

                        ((Form)Control).Size = new System.Drawing.Size(pnlCentral.Width, pnlCentral.Height);

                        ((Form)Control).FindForm();

                        foreach (var SubControles in ((Form)Control).Controls)
                        {
                            if (SubControles is Form)
                            {
                                int SubIndice2 = ((Form)Control).Controls.IndexOf(((Form)SubControles));
                                ((Form)Control).Controls.RemoveAt(SubIndice2);

                                ((Form)Control).Controls.Add(((Form)SubControles));
                                ((Form)Control).Tag = ((Form)SubControles);
                                ((Form)SubControles).WindowState = FormWindowState.Maximized;
                               
                                ((Form)SubControles).FindForm();

                                foreach (var SubControles2 in ((Form)SubControles).Controls)
                                {
                                    if (SubControles2 is Form)
                                    {
                                        int SubIndice3 = ((Form)SubControles).Controls.IndexOf(((Form)SubControles2));
                                        ((Form)SubControles).Controls.RemoveAt(SubIndice3);

                                        ((Form)SubControles).Controls.Add(((Form)SubControles2));
                                        ((Form)SubControles).Tag = ((Form)SubControles2);
                                        ((Form)SubControles2).WindowState = FormWindowState.Maximized;
                                        //((Form)Control).Size = new Size(1358, 694);

                                        ((Form)SubControles2).FindForm();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ((Form)Control).Close();
                    }
                }
            }
            btnPantallaCompleta.BackColor = Color.Transparent;
            btnPantallaReducida.BackColor = Color.Orange;
        }
    }
}
