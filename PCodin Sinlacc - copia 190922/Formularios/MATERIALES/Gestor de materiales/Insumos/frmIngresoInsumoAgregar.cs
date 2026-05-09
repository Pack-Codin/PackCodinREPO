using PCodin_Sinlacc.Clases;
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
using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Formularios.MATERIALES.Gestor_de_materiales;
using PCodin_Sinlacc.Formularios.MATERIALES.frmIngresoInsumo;
using PCodin_Sinlacc.Formularios.VENTAS.Ticket;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using PCodin_Sinlacc.Formularios.OTROS;

namespace PCodin_Sinlacc.Formularios.MATERIALES.Gestor_de_materiales.Insumos
{
    public partial class frmIngresoInsumoAgregar : Form
    {
        public frmIngresoInsumoAgregar()
        {
            InitializeComponent();
        }
        public DataGridView DGV;
        public TextBox txtCodigoBara;
        public long IDRecibido;
        public string Accion;
        public int ListaPrecio;
        public frmIngresoInsumo.frmIngresoInsumo frmIngresoInsumo;
        public frmAgregarTicket frmAgregarTicket;

        private void frmIngresoInsumoAgregar_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            if (clsVariablesGenerales.Aplicacion != "PACK-SHOP")
            {
                pnlSeleccionRapida.Visible = false;
                btnCalculadora.Visible = false;
            }
                

            if (frmIngresoInsumo != null)
                    lblCostoPrecio.Text = "Costo";
            if (frmAgregarTicket != null)
            {
                lblCostoPrecio.Text = "Precio";
            }

            //clsCargarCombos.MostrarComboInsProConMedida2(cmbInsumo, cmbMedida, txtBuscaInsPro, "INS", false);
            //clsCargarCombos.MostrarComboInsProConMedida(comboBox1, cmbMedida, txtBuscaInsPro, "INS", false);
            //clsCargarCombos.MostrarComboInsProSinCheck(cmbInsumo, txtBuscaInsPro, "INS", false, "NO");
            cmbInsumo.SelectedValue = -1;
            cmbMedida.SelectedIndex = -1;

            if (Accion != "1")
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaCuerpo = (from CU in hb.INGRESOMERCADERIACUERPO
                                          where CU.ID == IDRecibido
                                          select CU).FirstOrDefault();

                    cmbInsumo.SelectedValue = ConsultaCuerpo.Insumo_ID;
                    cmbInsumo.Text = ConsultaCuerpo.Productos_Insumos.Descripcion;
                    txtCantidad.Text = ConsultaCuerpo.Cantidad.ToString("N2");
                    txtCosto.Text = ConsultaCuerpo.Costo.Value.ToString("N2");
                }
            }
        }
        private void CargarArticulo()
        {
            if (cmbInsumo.SelectedValue != null
                && Convert.ToDecimal(txtCantidad.Text) > 0
                && Convert.ToDecimal(txtCosto.Text) > 0)
            {
                if (Accion == "1")
                {
                    DGV.Rows.Add("", cmbInsumo.SelectedValue, cmbInsumo.Text, txtCantidad.Text, txtCosto.Text);

                    if (frmIngresoInsumo != null)
                        frmIngresoInsumo.CalcularTotal();
                    if (frmAgregarTicket != null)
                        frmAgregarTicket.CalcularTotal();
                    //DataGridViewRow Fila = new DataGridViewRow();

                    //Fila.CreateCells(DGV);

                    //Fila.Cells[1].Value = cmbInsumo.SelectedValue.ToString();
                    //Fila.Cells[2].Value = cmbInsumo.Text;
                    //Fila.Cells[3].Value = txtCantidad.Text;
                    //Fila.Cells[4].Value = txtCosto.Text;
                    //// Fila.Cells[5].Value = 100 * 10;

                    //DGV.Rows.Add(Fila);
                }
                if (Accion == "2")
                {
                    if (frmIngresoInsumo != null)
                    {
                        DGV.CurrentRow.Cells["colCodigo"].Value = cmbInsumo.SelectedValue;
                        DGV.CurrentRow.Cells["colArticulo"].Value = cmbInsumo.Text;
                        DGV.CurrentRow.Cells["colCantidad"].Value = txtCantidad.Text;
                        DGV.CurrentRow.Cells["colCosto"].Value = txtCosto.Text;

                        frmIngresoInsumo.CalcularTotal();
                    }
                    if (frmAgregarTicket != null)
                    {
                        DGV.CurrentRow.Cells["colCodigo"].Value = cmbInsumo.SelectedValue;
                        DGV.CurrentRow.Cells["colArticulo"].Value = cmbInsumo.Text;
                        DGV.CurrentRow.Cells["colCantidad"].Value = txtCantidad.Text;
                        DGV.CurrentRow.Cells["colPrecio"].Value = txtCosto.Text;

                        frmAgregarTicket.CalcularTotal();
                    }
                }
                
               
                //lblEstadoLector.Text = "Leyendo";
                //lblEstadoLector.ForeColor = Color.ForestGreen;
                this.Close();
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CargarArticulo();          
        }

        private void txtCosto_Click(object sender, EventArgs e)
        {
            txtCosto.SelectAll();
        }

        private void txtCosto_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCosto);
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLector_Click(object sender, EventArgs e)
        {

        }
        private void cmbInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                
                //clsCargarCombos.MostrarComboInsProSinCheck(cmbInsumo, txtBuscaInsPro, "INS", false, "NO");
                txtBuscaInsPro.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }
        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbInsumo, txtBuscaInsPro, "INS", true, "NO");
                txtBuscaInsPro.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaInsPro.Visible = false;
                txtBuscaInsPro.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscaInsumo_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            //if (txtCodigoBarra.TextLength > 0)
            //{
            //    using (var hb = new DBdatos())
            //    {
            //        var Consulta = (from I in hb.Productos_Insumos
            //                        where I.CodigoBarra == txtCodigoBarra.Text
            //                        select I).FirstOrDefault();

            //        if(Consulta != null)
            //        {
            //            cmbInsumo.SelectedValue = Consulta.Codigo;
            //            cmbInsumo.Text = Consulta.Descripcion;
            //        }
            //        else
            //        {
            //            MessageBox.Show("No se encuentra articulo con el codigo de barra " + " " + txtCodigoBarra.Text );                      
            //        }
            //        txtCodigoBarra.Text = "";
            //    }
            //}
        }

        private void cmbInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInsumo.SelectedValue != null)
            {
                txtCosto.Text = "0,00";
                Reutilizables.CalcularPrecioArticulo(ListaPrecio, cmbInsumo.SelectedValue.ToString(), txtCosto);
            }
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            Clases.Formularios.clsfrmIngresoInsumoaAgregar.BuscarPorCodigoBarra(txtCodigoBarra, cmbInsumo, txtCosto);
        }

        private void btnCarniceria_Click(object sender, EventArgs e)
        {
            SeleccionRapida(cmbInsumo, sender,txtCantidad,txtCosto);
        }
        private void SeleccionRapida(ComboBox ComboArticulo, object objeto, TextBox Tcantidad , TextBox Tprecio)
        {
            try
            {
                Button boton = objeto as Button;

                if(boton.Name == "btnCarniceria")                             
                    clsCargarCombos.MostrarComboArticuloPorCodigo(cmbInsumo, txtBuscaInsPro, "CARNI");         
                if (boton.Name == "btnVerduleria")         
                    clsCargarCombos.MostrarComboArticuloPorCodigo(cmbInsumo, txtBuscaInsPro, "VERDU");                                
                if (boton.Name == "btnFiambreria")               
                    clsCargarCombos.MostrarComboArticuloPorCodigo(cmbInsumo, txtBuscaInsPro, "FIAMB");                               
                if (boton.Name == "btnPanaderia")               
                    clsCargarCombos.MostrarComboArticuloPorCodigo(cmbInsumo, txtBuscaInsPro, "PANA");
                if (boton.Name == "btnVarios")
                    clsCargarCombos.MostrarComboArticuloPorCodigo(cmbInsumo, txtBuscaInsPro, "VAR");

                boton.BackColor = Color.Khaki;
                Tcantidad.Text = "1,00";        
                Tprecio.Focus();
                Tprecio.SelectAll();

                foreach (var Controles in pnlSeleccionRapida.Controls)
                {
                    if (Controles is Button)
                    {
                        if (((Button)Controles).Name != boton.Name)
                            ((Button)Controles).BackColor = Color.Transparent;
                    }
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }

        private void btnVerduleria_Click(object sender, EventArgs e)
        {
            SeleccionRapida(cmbInsumo, sender, txtCantidad, txtCosto);
        }

        private void btnFiambreria_Click(object sender, EventArgs e)
        {
            SeleccionRapida(cmbInsumo, sender, txtCantidad, txtCosto);
        }

        private void btnPanaderia_Click(object sender, EventArgs e)
        {
            SeleccionRapida(cmbInsumo, sender, txtCantidad, txtCosto);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                CargarArticulo();
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                CargarArticulo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new frmCalculadora();
            f.frmIngresoInsumoAgregar = this;
            f.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cmbInsumo.Text = "aaaaa";
        }

        private void frmIngresoInsumoAgregar_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmIngresoInsumoAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.NumPad1))
            {
                clsCargarCombos.MostrarComboArticuloPorCodigo(cmbInsumo, txtBuscaInsPro, "CARNI");
            }
            //if (e.KeyChar == Convert.ToChar(Keys))
            //{
            //    txtBuscaInsPro.Visible = false;
            //    txtBuscaInsPro.Focus();
            //    e.Handled = true;
            //}
        }

        private void txtCodigoBarra_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscaInsPro_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void btnVarios_Click(object sender, EventArgs e)
        {
            SeleccionRapida(cmbInsumo, sender, txtCantidad, txtCosto);
        }
    }
}
