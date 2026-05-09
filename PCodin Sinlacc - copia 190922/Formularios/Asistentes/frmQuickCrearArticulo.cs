using PCodin_Sinlacc;
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
    public partial class frmQuickCrearArticulo : Form
    {
        public frmQuickCrearArticulo()
        {
            InitializeComponent();
        }
        public string CodigoBarra;
        public DataGridView DGV;
        public string Modulo;
        public decimal Cantidad;
        private void InicializarForm()
        {
            clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, false);
            clsCargarCombos.MostrarComboMedida(cmbMedida);
            clsCargarCombos.MostrarComboMedida(cmbMedidaEquiv);
            clsCargarCombos.MostrarCombomListaPrecio(cmbListaPrecio, 0);
            clsCargarCombos.MostrarComboInsPro(cmbFiltraInsPro, txtBuscaInsPro, false);
            cmbCategoria.SelectedIndex = -1;
            cmbMedida.SelectedIndex = -1;
            cmbListaPrecio.SelectedIndex = -1;

            if(CodigoBarra != "")
                txtCodigoBarra.Text = CodigoBarra;
        }
        private void CargarDatos()
        {
            if( txtCodArticulo.TextLength > 0
                && txtCodigoBarra.TextLength > 0
                && txtDescripcionAriculo.TextLength > 0
                && cmbMedida.SelectedIndex != -1
                && cmbListaPrecio.SelectedIndex != -1)
            {
                try
                {
                    bool Error = false;

                    using (var hb = new DBdatos())
                    {
                        string CodArticulo = txtCodArticulo.Text;
                        string Articulo = txtDescripcionAriculo.Text;

                        var ConsultaArticulo = (from AR in hb.Productos_Insumos
                                                where AR.Codigo == CodArticulo
                                                select AR).FirstOrDefault();

                        var ConsultaArticuloPLU = (from AR in hb.Productos_Insumos
                                                where AR.PLU == txtPLU.Text
                                                select AR).FirstOrDefault();

                        if (ConsultaArticulo == null && ConsultaArticuloPLU == null)
                        {
                            //DATOS ARTICULO
                            var NuevoArticulo = new Productos_Insumos();

                            NuevoArticulo.Codigo = CodArticulo;
                            NuevoArticulo.Descripcion = Articulo.ToUpper();
                            NuevoArticulo.Apodo = "";
                            NuevoArticulo.Categoria_ID = (int)cmbCategoria.SelectedValue;
                            NuevoArticulo.MaxProducción = 0;
                            NuevoArticulo.StockMin = 0;
                            NuevoArticulo.Ins_Prod = "PRO";
                            NuevoArticulo.Estado = "SI";
                            NuevoArticulo.Medida = (int)cmbMedida.SelectedValue;
                            NuevoArticulo.Cantidad_Ref = 0;
                            NuevoArticulo.Dias_Produccion = 0;
                            NuevoArticulo.Produccion_Diaria = 0;
                            NuevoArticulo.Demora_Entrega = 0;
                            NuevoArticulo.Punto_Pedido = 0;
                            NuevoArticulo.Costo = 0;
                            NuevoArticulo.NotificaPuntoPedido = "NO";
                            NuevoArticulo.Color = "";
                            NuevoArticulo.NotificaStockMin = "NO";
                            if (txtPLU.Text != "")
                                NuevoArticulo.PLU = txtPLU.Text;

                            if (chkUsaEquivalencia.Checked)
                            {
                                if(Convert.ToDecimal(txtCantEquivalencia.Text) > 0 && cmbMedida.SelectedIndex != -1 && cmbFiltraInsPro.SelectedIndex != -1)
                                {
                                    NuevoArticulo.UtilizaEquivalencia = "SI";
                                    NuevoArticulo.EquivalenciaCantidad = Convert.ToDecimal(txtCantEquivalencia.Text);
                                    NuevoArticulo.EquivalenciaMedida = (int)cmbCategoria.SelectedValue;
                                    NuevoArticulo.EquivalenciaProducto = cmbFiltraInsPro.SelectedValue.ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Faltan datos de completar en Equivalencias", "Atencion");
                                    Error = true;
                                }
                               
                            }
                            
                            hb.Productos_Insumos.Add(NuevoArticulo);

                            //CODIGO DE BARRA
                            var NuevoCodBarra = new CODIGOBARRA();

                            NuevoCodBarra.Producto_ID = CodArticulo;
                            NuevoCodBarra.CodigoBarra1 = CodigoBarra;
                            NuevoCodBarra.Estado = "SI";

                            hb.CODIGOBARRA.Add(NuevoCodBarra);

                            //DATOS MONETARIOS
                            var NuevaListaPrecioCuerpo = new LISTAPRECIOCUERPO();

                            NuevaListaPrecioCuerpo.ListaPrecio_ID = (int)cmbListaPrecio.SelectedValue;
                            NuevaListaPrecioCuerpo.Articulo_ID = CodArticulo;
                            NuevaListaPrecioCuerpo.Costo = Convert.ToDecimal(txtCosto.Text);
                            NuevaListaPrecioCuerpo.Precio = Convert.ToDecimal(txtPrecio.Text);

                            hb.LISTAPRECIOCUERPO.Add(NuevaListaPrecioCuerpo);
                            if(Error == false)
                            {
                                hb.SaveChanges();
                                MessageBox.Show("Articulo cargado correctamente", "Atención");

                                DGV.Rows.Add(CodigoBarra,
                                             CodArticulo,
                                             Articulo.ToUpper(),
                                             Cantidad,
                                             txtCosto.Text,
                                             txtPrecio.Text,
                                             0,
                                             0,
                                             (Cantidad * Convert.ToDecimal(txtCosto.Text)).ToString("N2"));
                                this.Close();
                            }                          
                        }
                        else
                        {
                            if(ConsultaArticulo != null)
                                MessageBox.Show("Ya existe un articulo con el condigo " + CodArticulo, "Error");
                            if (ConsultaArticuloPLU != null)
                                MessageBox.Show("Ya existe un articulo con el condigo " + txtPLU.Text, "Error");
                        }
                    }
                }
                catch(Exception Error)
                {
                    MessageBox.Show(Error.Message, "Error");
                }            
            }
            else
            {
                string MensajeError = "";

                if (txtCodArticulo.TextLength == 0)
                    MensajeError = "Debe ingresar codigo de articulo";
                if (txtCodigoBarra.TextLength == 0)
                    MensajeError = "Debe ingresar codigo de barras";
                if (txtDescripcionAriculo.TextLength == 0)
                    MensajeError = "Debe ingresar descripción de artículo";
                if (cmbMedida.SelectedIndex < 0)
                    MensajeError = "Debe seleccionar medida";
                if (cmbListaPrecio.SelectedIndex < 0)
                    MensajeError = "Debe seleccionar lista de precio";

                MessageBox.Show(MensajeError, "Error");
            }
        }
        private void CopiarCodBarras()
        {
            try
            {
                if (txtCodigoBarra.Text != "")
                    txtCodArticulo.Text = txtCodigoBarra.Text;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }                                    
        }
        private void frmQuickCrearArticulo_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void frmQuickCrearArticulo_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (Modulo != "TICKET" && Modulo != "ComprasAsisITherio")
                    DGV.Rows.Remove(DGV.CurrentRow);
               
            }
            catch (Exception)
            {
               
            }
            
        }

        private void chkUsaEquivalencia_CheckedChanged(object sender, EventArgs e)
        {
            if(chkUsaEquivalencia.Checked)
            {
                txtCantEquivalencia.Visible = true;
                cmbMedidaEquiv.Visible = true;
                cmbFiltraInsPro.Visible = true;
                btnBuscarInsPro.Visible=true;
            }
            else
            {
                txtCantEquivalencia.Visible = false;
                cmbMedidaEquiv.Visible = false;
                cmbFiltraInsPro.Visible = false;
                btnBuscarInsPro.Visible = false;
            }
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsPro, txtBuscaInsPro, "INS", true, "NO");
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaInsPro.Visible = false;
            }
        }

        private void cmbFiltraInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsPro, txtBuscaInsPro, "INS", false, "NO");
            }
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtPrecio);
        }

        private void txtCosto_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCosto);
        }

        private void txtCantEquivalencia_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantEquivalencia);
        }

        private void btnCopiarCodBarras_Click(object sender, EventArgs e)
        {
            CopiarCodBarras();
        }
    }
}
