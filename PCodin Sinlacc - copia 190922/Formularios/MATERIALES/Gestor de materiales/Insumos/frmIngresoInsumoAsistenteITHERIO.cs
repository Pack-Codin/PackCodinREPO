using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Clases;
using System.IO;
using PCodin_Sinlacc.Formularios.Asistentes;

namespace PCodin_Sinlacc.Formularios.MATERIALES.Gestor_de_materiales.Insumos
{
    public partial class frmIngresoInsumoAsistenteITHERIO : Form
    {
        public frmIngresoInsumoAsistenteITHERIO()
        {
            InitializeComponent();
        }

        public DataGridView DGV;
        public TextBox txtImporteTotal;
        private void frmIngresoInsumoAsistenteITHERIO_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsCargarCombos.MostrarCombomListaPrecio(cmbListaPrecio, 0);
            cmbListaPrecio.SelectedIndex = -1;
        }
        private void SeleccionarArchivo()
        {
            try
            {
                using (System.Windows.Forms.OpenFileDialog sfd = new System.Windows.Forms.OpenFileDialog())
                {
                    sfd.Title = "Abrir archivo CSV";
                    sfd.Filter = "Archivo CSV (*.csv)|*.csv";
                    //sfd.FileName = "Factura" + cmbProveedor.Text + ".csv"; // nombre sugerido
                    sfd.DefaultExt = "csv";
                    sfd.AddExtension = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        txtRuta.Text = sfd.FileName;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }
        private void btnElegirRuta_Click(object sender, EventArgs e)
        {
            SeleccionarArchivo();
        }
        private void ImportarDatos()
        {
            try
            {
                int CantidadRegistrosImportados = 0;
                int CantidadErrores = 0;

                if(txtRuta.Text != "" && cmbListaPrecio.SelectedIndex != -1 && cmbProveedor.SelectedIndex != -1 && txtPorcentaje.Text != "")
                {
                    using (var hb = new DBdatos())
                    {
                        string Ruta = "";
                        string[] Lineas;
                        try
                        {
                            Ruta = txtRuta.Text;

                            Lineas = File.ReadAllLines(Ruta);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        foreach (var Linea in Lineas)
                        {
                            decimal Precio = 0;
                            decimal ImporteFila = 0;

                            if (cmbProveedor.Text == "Don Emilio" || cmbProveedor.Text == "Don Emilio (Con descuento)")
                            {
                                var Valores = Linea.Split(';');

                                var CodigoBarra = Valores[0];
                                decimal Cantidad = Convert.ToDecimal(Valores[1]);
                                var Producto = Valores[2];
                                decimal Costo = 0;

                                if(cmbProveedor.Text == "Don Emilio")
                                    Costo = Convert.ToDecimal(Valores[3]);
                                if (cmbProveedor.Text == "Don Emilio (Con descuento)")
                                    Costo = Convert.ToDecimal(Valores[4]);

                                decimal Porcentaje = Convert.ToDecimal(txtPorcentaje.Text);
                                decimal CostoOriginal = 0;
                                decimal PrecioOriginal = 0;

                                var ConsultaArticuloBarra = (from A in hb.CODIGOBARRA
                                                             where A.CodigoBarra1 == CodigoBarra
                                                             select A).FirstOrDefault();

                                if (Porcentaje > 0)
                                {
                                    Precio = Costo + (Costo * (Porcentaje / 100));
                                    ImporteFila = Cantidad * Precio;
                                }
                                

                                if (ConsultaArticuloBarra != null)
                                {
                                    var ConsultaLP = (from LP in hb.LISTAPRECIOCUERPO
                                                      where LP.ListaPrecio_ID == (int)cmbListaPrecio.SelectedValue
                                                        && LP.Articulo_ID == ConsultaArticuloBarra.Producto_ID
                                                      select LP).FirstOrDefault();

                                    if(ConsultaLP != null)
                                    {
                                        if (ConsultaLP.Costo == null)
                                            CostoOriginal = 0;
                                        else
                                            CostoOriginal = (decimal)ConsultaLP.Costo;

                                        if (ConsultaLP.Precio == null)
                                            PrecioOriginal = 0;
                                        else
                                            PrecioOriginal = (decimal)ConsultaLP.Precio;
                                    }


                                    DGV.Rows.Add(CodigoBarra.ToString(),
                                                 ConsultaArticuloBarra.Producto_ID,
                                                 Producto.ToString().ToUpper(),
                                                 Cantidad.ToString("N2"),
                                                 Costo.ToString("N2"),
                                                 Precio.ToString("N2"),
                                                 CostoOriginal,
                                                 PrecioOriginal,
                                                 ImporteFila.ToString("N2"));
                                }
                                else
                                {
                                    var f = new frmQuickCrearArticulo();

                                    f.DGV = DGV;
                                    f.Modulo = "ComprasAsisITherio";
                                    f.Cantidad = Cantidad;
                                    f.txtCodigoBarra.Text = CodigoBarra.ToString();
                                    f.txtDescripcionAriculo.Text = Producto.ToString();
                                    f.CodigoBarra = CodigoBarra.ToString();
                                    f.txtPrecio.Text = Precio.ToString("N2");
                                    f.txtCosto.Text = Costo.ToString("N2");

                                    f.ShowDialog();

                                }
                                Clases.Formularios.Ingresos.frmIngresoInsumoAsistente.CalcularTotal(DGV, txtImporteTotal);
                            }
                        }
                    }
                }
                this.Hide();
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
            
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ImportarDatos();
        }
    }
}
