using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios.PRODUCCION.Movimiento_de_Produccion
{
    public partial class frmLotes : Form
    {
        public frmLotes()
        {
            InitializeComponent();
        }
        string Accion;
        int IDEditar;
        string LoteOriginal;
        string ProductoOrinal;
        private void frmLotes_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            try
            {
                clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
                clsCargarCombos.MostrarComboInsProConMedida(cmbProducto, cmbMedida, txtBuscarProducto, "PRO", false);
                cmbProducto.SelectedIndex = -1;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }
        private void MostrarLotes()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from L in hb.LOTEPRODUCCION
                                    orderby L.Lote
                                    select new
                                    {
                                        L.ID,
                                        L.Lote,
                                        L.Producto_ID,
                                        Producto = L.Productos_Insumos.Descripcion,
                                        L.Humedad,
                                        L.Acidez
                                    });

                    if (chkFiltraLote.Checked)
                    {
                        string Lote = dtpFiltraLote.Value.ToShortDateString();
                        Lote = Lote.Replace("/", "");
                        //Lote = Lote.Insert(2, "/");
                        //Lote = Lote.Insert(5, "/");

                        Consulta = (from C in Consulta
                                    where C.Lote == Lote
                                    select C);
                    }
                    if (chkFiltraProducto.Checked)
                        Consulta = (from C in Consulta
                                    where C.Producto_ID == cmbFiltraProducto.SelectedValue.ToString()
                                    select C);
                   

                    var Resultados = Consulta.ToList();

                    colID.DataPropertyName = "ID";
                    colLote.DataPropertyName = "Lote";
                    colCodigo.DataPropertyName = "Producto_ID";
                    colProducto.DataPropertyName = "Producto";
                    colHumedad.DataPropertyName = "Humedad";
                    colAcidez.DataPropertyName = "Acidez";

                    dgvLotes.DataSource = Resultados;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }
        private void CargarDatos()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    if(txtLote.Text != "" && cmbProducto.SelectedIndex != -1 && txtHumedad.Text != "0,00" && txtAcidez.Text != "0,00")
                    {
                        if(Accion == "1")
                        {
                            var ConsultaLote = (from L in hb.LOTEPRODUCCION
                                                where L.Lote == txtLote.Text
                                                    && L.Producto_ID == cmbProducto.SelectedValue.ToString()
                                                select L).FirstOrDefault();

                            if (ConsultaLote == null)
                            {
                                var i = new LOTEPRODUCCION();

                                i.Lote = txtLote.Text;
                                i.Producto_ID = cmbProducto.SelectedValue.ToString();
                                i.Humedad = Convert.ToDecimal(txtHumedad.Text);
                                i.Acidez = Convert.ToDecimal(txtAcidez.Text);

                                hb.LOTEPRODUCCION.Add(i);

                                var ConsultaMovimientos = (from EPT in hb.Existencia_ProductoTerminado
                                                           where EPT.Lote == txtLote.Text
                                                            && EPT.Produto_ID == cmbProducto.SelectedValue.ToString()
                                                           select EPT).ToList();

                                foreach (var item in ConsultaMovimientos)
                                {
                                    item.Humedad = Convert.ToDecimal(txtHumedad.Text);
                                    item.Acidez = Convert.ToDecimal(txtAcidez.Text);
                                }

                                hb.SaveChanges();
                                MessageBox.Show("Lote cargado correctamente", "Atención");

                                //Resetea  todos los campos 
                                dtpLote.Value = DateTime.Now.Date;
                                txtLote.Text = "";
                                cmbProducto.SelectedIndex = -1;
                                txtHumedad.Text = "0,00";
                                txtAcidez.Text = "0,00";

                                pnlSuperior2.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Ya existe el lote " + ConsultaLote.Lote + " - " + ConsultaLote.Productos_Insumos.Descripcion);
                            }
                        }
                        else
                        {
                            int ID = Convert.ToInt32(dgvLotes.CurrentRow.Cells["colID"].Value);

                            var ConsultaLote = (from L in hb.LOTEPRODUCCION
                                                where L.ID == ID                                                 
                                                select L).FirstOrDefault();

                            //VALIDA QUE NO HAYA OTRO IGUAL
                            var ConsultaLoteValidar = (from LV in hb.LOTEPRODUCCION
                                                       where LV.Lote == txtLote.Text
                                                        && LV.Producto_ID == cmbProducto.SelectedValue.ToString()
                                                        && LV.Producto_ID != ProductoOrinal
                                                        && LV.Lote != LoteOriginal
                                                       select LV).FirstOrDefault();

                            if (ConsultaLoteValidar == null)
                            {
                                if (ConsultaLote != null)
                                {
                                    ConsultaLote.Lote = txtLote.Text;
                                    ConsultaLote.Producto_ID = cmbProducto.SelectedValue.ToString();
                                    ConsultaLote.Humedad = Convert.ToDecimal(txtHumedad.Text);
                                    ConsultaLote.Acidez = Convert.ToDecimal(txtAcidez.Text);

                                    var ConsultaMovimientos = (from EPT in hb.Existencia_ProductoTerminado
                                                               where EPT.Lote == txtLote.Text
                                                                && EPT.Produto_ID == cmbProducto.SelectedValue.ToString()
                                                               select EPT).ToList();

                                    foreach (var item in ConsultaMovimientos)
                                    {
                                        item.Humedad = Convert.ToDecimal(txtHumedad.Text);
                                        item.Acidez = Convert.ToDecimal(txtAcidez.Text);
                                    }

                                    hb.SaveChanges();
                                    MessageBox.Show("Lote editado correctamente", "Atención");
                                    MostrarLotes();

                                    //Resetea  todos los campos 
                                    dtpLote.Value = DateTime.Now.Date;
                                    txtLote.Text = "";
                                    cmbProducto.SelectedIndex = -1;
                                    txtHumedad.Text = "0,00";
                                    txtAcidez.Text = "0,00";

                                    pnlSuperior2.Visible = false;
                                }
                            
                            }
                            else
                            {
                                MessageBox.Show("Ya existe el lote " + ConsultaLoteValidar.Lote + " - " + ConsultaLoteValidar.Productos_Insumos.Descripcion);
                            }
                            
                        }
                    }
                    else
                    {
                        if (txtLote.Text == "")
                            MessageBox.Show("No selecciono lote", "Atención");
                        if (cmbProducto.SelectedIndex < 0)
                            MessageBox.Show("No selecciono producto", "Atención");
                        if (txtHumedad.Text == "0,00")
                            MessageBox.Show("No definio humedad", "Atención");
                        if (txtLote.Text == "0,00")
                            MessageBox.Show("No definio acidez", "Atención");
                    }
                    


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void FormatearLote()
        {
            try
            {
                txtLote.Text = dtpLote.Value.ToShortDateString().Replace("/", "");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }
        private void dtpLote_ValueChanged(object sender, EventArgs e)
        {
            FormatearLote();
        }

        private void cmbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProConMedida(cmbProducto, cmbMedida, txtBuscarProducto, "PRO", false);
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProducto.Visible = false;
                clsCargarCombos.MostrarComboInsProConMedida(cmbProducto, cmbMedida, txtBuscarProducto, "PRO", true);
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarProducto.Visible = false;
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
        }

        private void txtHumedad_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado); txtHumedad.SelectAll();
        }

        private void txtHumedad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtHumedad);
        }

        private void txtAcidez_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtAcidez);
        }

        private void txtAcidez_Click(object sender, EventArgs e)
        {
            txtAcidez.SelectAll();
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void chkFiltraLote_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFiltraLote, dtpFiltraLote);
        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraProducto, cmbFiltraProducto, txtBuscarProducto, btnBuscarProducto, "PRO", "NO");
        }

        private void txtFiltraProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtFiltraProducto.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraProducto, txtFiltraProducto, "PRO", true, "NO");
                txtFiltraProducto.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtFiltraProducto.Visible = false;
                txtFiltraProducto.Focus();
                e.Handled = true;
            }
        }

        private void cmbFiltraProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraProducto, txtFiltraProducto, "PRO", false, "NO");
                txtFiltraProducto.Focus();
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFiltraProducto.Visible = true;
            txtFiltraProducto.Select();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarLotes();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Accion = "1";
            pnlSuperior2.Visible = true;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarLotes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvLotes.RowCount > 0)
                {
                    Accion = "2";
                    pnlSuperior2.Visible = true;

                    txtLote.Text = dgvLotes.CurrentRow.Cells["colLote"].Value.ToString();
                    cmbProducto.SelectedValue = dgvLotes.CurrentRow.Cells["colCodigo"].Value.ToString();
                    cmbProducto.Text = dgvLotes.CurrentRow.Cells["colProducto"].Value.ToString();
                    txtHumedad.Text = dgvLotes.CurrentRow.Cells["colHumedad"].Value.ToString();
                    txtAcidez.Text = dgvLotes.CurrentRow.Cells["colAcidez"].Value.ToString();

                    IDEditar = Convert.ToInt32(dgvLotes.CurrentRow.Cells["colID"].Value);
                    LoteOriginal = dgvLotes.CurrentRow.Cells["colLote"].Value.ToString();
                    ProductoOrinal = dgvLotes.CurrentRow.Cells["colCodigo"].Value.ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void txtBuscarProducto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraProducto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
