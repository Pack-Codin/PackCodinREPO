using Microsoft.Office.Interop.Excel;
using PCodin_Sinlacc.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios.VENTAS.Lista_de_precio
{
    public partial class frmListaPrecioConfig : Form
    {
        public frmListaPrecioConfig()
        {
            InitializeComponent();
        }

        private void frmListaPrecioConfig_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from C in hb.LISTAPRECIOCONFIG
                                    select C).FirstOrDefault();

                    if (Consulta != null)
                    {
                        if (Consulta.ActualizaCostoEnTodasListas == "SI")
                            chkActualizaAutoCostos.Checked = true;
                        else
                            chkActualizaAutoCostos.Checked = false;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }
        private void CargarDatos()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from C in hb.LISTAPRECIOCONFIG
                                    select C).FirstOrDefault();

                    if (Consulta == null)
                    {
                        var i = new LISTAPRECIOCONFIG();

                        if (chkActualizaAutoCostos.Checked == true)
                            i.ActualizaCostoEnTodasListas = "SI";
                        else
                            i.ActualizaCostoEnTodasListas = "NO";

                        hb.LISTAPRECIOCONFIG.Add(i);
                    }
                    else
                    {
                        if (chkActualizaAutoCostos.Checked == true)
                            Consulta.ActualizaCostoEnTodasListas = "SI";
                        else
                            Consulta.ActualizaCostoEnTodasListas = "NO";
                    }
                    hb.SaveChanges();
                    MessageBox.Show("Datos cargados correctamente","Atención");
                    this.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
