using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Formularios.Asistentes
{
    public partial class frmQuickAgregarProductoListaPrecio : Form
    {
        public frmQuickAgregarProductoListaPrecio()
        {
            InitializeComponent();
        }
        public string ProductoID;
        public string Producto;
        public int ListaPrecioID;
        public string ListaPrecio;
        private void frmQuickAgregarProductoListaPrecio_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private async void InicializarForm()
        {
            try
            {              
                if (ProductoID != "" && Producto != "")
                {                   
                    lblProducto.Text = Producto;
                }
                clsCargarCombos.MostrarCombomListaPrecio(cmbListaPrecio, ListaPrecioID);
               
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Error");
            }                       
        }
        private async void CargarProductoLista()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaPrecio = (from C in hb.LISTAPRECIOCUERPO
                                          where C.Articulo_ID == ProductoID
                                          select C).FirstOrDefault();
                    
                    decimal PrecioOriginal;
                    decimal Precio = Convert.ToDecimal(txtPrecio.Text);

                    //if(ConsultaPrecio != null)
                    //PrecioOriginal = (decimal)ConsultaPrecio.Precio;

                    if(Precio > 0)
                    {
                        if(ConsultaPrecio == null)
                        {
                            var i = new LISTAPRECIOCUERPO();

                            i.ListaPrecio_ID = ListaPrecioID;
                            i.Articulo_ID = ProductoID;
                            i.Costo = 0;
                            i.Precio = Precio;

                            hb.LISTAPRECIOCUERPO.Add(i);
                        }
                        if(ConsultaPrecio != null)
                        {
                            ConsultaPrecio.Precio = Precio;
                        }
                        hb.SaveChanges();
                        MessageBox.Show("Precio registrado correctamente", "Ateción");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El precio tiene que ser mayor a 0", "Error");
                        return;
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Error");              
            }
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtPrecio);
        }

        private void txtPrecio_Click(object sender, EventArgs e)
        {
            txtPrecio.SelectAll();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarProductoLista();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    CargarProductoLista();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error");
                }
                
            }
        }
    }
}
