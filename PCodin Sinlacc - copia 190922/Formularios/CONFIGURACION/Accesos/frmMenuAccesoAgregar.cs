using PCodin_Sinlacc.Clases;
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

namespace PCodin_Sinlacc.Formularios.CONFIGURACION.Accesos
{
    public partial class frmMenuAccesoAgregar : Form
    {
        public frmMenuAccesoAgregar()
        {
            InitializeComponent();
        }
        public int IdRecibido;
        public string Accion;
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMenuAccesoAgregar_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            try
            {
                clsCargarCombos.MostrarModulo(cmbModulo);
                cmbModulo.SelectedIndex = -1;

                if (Accion == "2")
                {
                    using (var hb = new DBdatos())
                    {
                        var Consulta = (from C in hb.Menu_Item
                                        where C.ID == IdRecibido
                                        select C).FirstOrDefault();

                        txtDescripcion.Text = Consulta.Descripcion;
                        cmbModulo.SelectedValue = Consulta.Modulo_ID;
                        cmbModulo.Text = Consulta.Modulos.Nombre;
                        txtAplicacion.Text = Consulta.Boton;
                        txtPage.Text = Consulta.Page;
                        cmbTipo.Text = Consulta.Tipo;
                        cmbEstado.Text = Consulta.Estado;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                throw;
            }
           
        }
        private void CargarAcceso()
        {
            using (var hb = new DBdatos())
            {
                try
                {
                    if (txtDescripcion.Text != "" &&
                        cmbModulo.SelectedIndex != -1 &&
                        cmbTipo.SelectedIndex != -1 &&
                        txtAplicacion.Text != "" &&
                        cmbEstado.SelectedIndex != -1)
                    {
                        if(Accion == "1")
                        {
                            var i = new Menu_Item();

                            i.Descripcion = txtDescripcion.Text;
                            i.Modulo_ID = (int)cmbModulo.SelectedValue;
                            i.Tipo = cmbTipo.Text;
                            i.Boton = txtAplicacion.Text;
                            i.Page = txtPage.Text;
                            i.Estado = cmbEstado.Text;

                            hb.Menu_Item.Add(i);
                        }
                        if(Accion == "2")
                        {
                            var Consulta = (from C in hb.Menu_Item
                                            where C.ID == IdRecibido
                                            select C).FirstOrDefault();

                            Consulta.Descripcion = txtDescripcion.Text;
                            Consulta.Modulo_ID = (int)cmbModulo.SelectedValue;
                            Consulta.Tipo = cmbTipo.Text;
                            Consulta.Boton = txtAplicacion.Text;
                            Consulta.Page = txtPage.Text;
                            Consulta.Estado = cmbEstado.Text;
                        }
                        hb.SaveChanges();
                        MessageBox.Show("Datos cargados correctamente", "Atencion");
                        this.Hide();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error");
                    return;
                }
            }
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarAcceso();
        }
    }
}
