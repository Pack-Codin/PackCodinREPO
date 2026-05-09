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

namespace PCodin_Sinlacc.Formularios.Deposito
{
    public partial class frmVisorDeposito : Form
    {
        public string Deposito;
        private long IDSeleccionado;
        private long ProduccionID;
        private string ProductoID; 
        public frmVisorDeposito()
        {
            InitializeComponent();
        }

        private void frmVisorDeposito_Load(object sender, EventArgs e)
        {
            Reutilizables.RenderizarForm(this);
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from EMP in hb.Existencia_ProductoTerminado
                                where EMP.Deposito == Deposito
                                    && EMP.Estado_ID == "PEN"
                                    && EMP.Movimiento_ID == "IPT"
                                orderby EMP.Fecha, EMP.ID
                                select new
                                {
                                    EMP.ID,
                                    EMP.Numero_Produccion,
                                    EMP.Produto_ID,
                                    EMP.Movimiento_ID,
                                    Movimiento = EMP.Movimientos_Produccion.Descripcion,
                                    Producto = EMP.Productos_Insumos.Descripcion,
                                    EMP.Fecha,
                                    EMP.Medida_ID,
                                    Medida = EMP.Medidas_Producto.Descripcion,
                                    EMP.Empleado_ID,
                                    Empleado = EMP.Empleados.Nombre,
                                    EMP.Cantidad,
                                    EMP.Cantidad_Utiliz,
                                    Disponible = EMP.Cantidad - EMP.Cantidad_Utiliz,
                                    EMP.Lote,
                                    EMP.Ficha,
                                    EMP.Retencion,
                                    EMP.Estado_ID,
                                    Estado = EMP.Estado_ExistenciaProductoTerminado.Descripcion,
                                    EMP.Productos_Insumos.Categoria_ID,
                                    EMP.Observaciones

                                }).Take(1000);

                //if (cmbOrdenar.SelectedIndex == 1) // FECha
                //{
                //    if (btnBuscarDesc.Visible)
                //        Consulta = (from C in Consulta
                //                    orderby C.Fecha descending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.Fecha ascending
                //                    select C);
                //}
                //if (cmbOrdenar.SelectedIndex == 2) // FECha
                //{
                //    if (btnBuscarDesc.Visible)
                //        Consulta = (from C in Consulta
                //                    orderby C.Movimiento descending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.Movimiento ascending
                //                    select C);
                //}
                //if (cmbOrdenar.SelectedIndex == 3) // Codigo de producto
                //{
                //    if (btnBuscarDesc.Visible)
                //        Consulta = (from C in Consulta
                //                    orderby C.Produto_ID descending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.Produto_ID ascending
                //                    select C);
                //}
                //if (cmbOrdenar.SelectedIndex == 4) // Producto
                //{
                //    if (btnBuscarDesc.Visible)
                //        Consulta = (from C in Consulta
                //                    orderby C.Producto descending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.Producto ascending
                //                    select C);
                //}
                //if (cmbOrdenar.SelectedIndex == 5) // Cantidad
                //{
                //    if (btnBuscarDesc.Visible)
                //        Consulta = (from C in Consulta
                //                    orderby C.Cantidad descending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.Cantidad ascending
                //                    select C);
                //}
                //if (cmbOrdenar.SelectedIndex == 6) // Medida
                //{
                //    if (btnBuscarDesc.Visible)
                //        Consulta = (from C in Consulta
                //                    orderby C.Medida descending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.Medida ascending
                //                    select C);
                //}
                //if (cmbOrdenar.SelectedIndex == 7) // Retencion
                //{
                //    if (btnBuscarDesc.Visible)
                //        Consulta = (from C in Consulta
                //                    orderby C.Retencion descending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.Retencion ascending
                //                    select C);
                //}
                //if (cmbOrdenar.SelectedIndex == 8) // Ficha
                //{
                //    if (btnBuscarDesc.Visible)
                //        Consulta = (from C in Consulta
                //                    orderby C.Ficha descending
                //                    select C);
                //    else
                //        Consulta = (from C in Consulta
                //                    orderby C.Ficha ascending
                //                    select C);
                //}
                ////if (cmbOrdenar.SelectedIndex == 9) // Estado
                ////{
                ////    if (btnBuscarDesc.Visible)
                ////        Consulta = (from C in Consulta
                ////                    orderby C.Estado descending
                ////                    select C);
                ////    else
                ////        Consulta = (from C in Consulta
                ////                    orderby C.Estado ascending
                ////                    select C);
                ////}

                ////if (chkFiltraCodigo.Checked)
                ////    Consulta = (from C in Consulta
                ////                where C.Produto_ID == txtFiltraDescripcion.Text
                ////                select C);

                ////if (chkFiltraDescripion.Checked)
                ////    Consulta = (from C in Consulta
                ////                where C.Producto.StartsWith(txtFiltraDescripcion.Text)
                ////                    || C.Producto.Contains(txtFiltraDescripcion.Text)
                ////                select C);

                ////if (chkFiltraMovimiento.Checked)
                ////    Consulta = (from C in Consulta
                ////                where C.Movimiento_ID == (int)cmbFiltraMovimiento.SelectedValue
                ////                select C);

                //if (chkFiltraInsPro.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Produto_ID == cmbFiltraInsPro.SelectedValue.ToString()
                //                select C);

                //if (chkFiltraCategoria.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Categoria_ID == (int)cmbFiltraCategoria.SelectedValue
                //                select C);

                //if (chkFiltraEstado.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Estado_ID == cmbFiltraEstado.Text
                //                select C);

                //if (chkFiltraRetencion.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Retencion == cmbFiltraRetencion.Text
                //                select C);

                //if (chkFiltraFicha.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Ficha == cmbFiltraFicha.Text
                //                select C);

                ////if (rdbAgrupado.Checked)
                ////{
                ////    MostrarProductosAgrupados();
                ////}

                //if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                //{
                //    Consulta = (from C in Consulta
                //                where C.Fecha >= dtpFechaDesde.Value.Date
                //                select C);
                //}
                //else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                //{
                //    Consulta = (from C in Consulta
                //                where C.Fecha <= dtpFechaHasta.Value.Date
                //                select C);
                //}
                //else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                //{
                //    Consulta = (from C in Consulta
                //                where C.Fecha >= dtpFechaDesde.Value.Date && C.Fecha <= dtpFechaHasta.Value.Date
                //                select C);
                //}


                var Resultado = Consulta.ToList();

                colFecha.Visible = true;
                colMovimiento.Visible = true;
                colRetencion.Visible = true;
                colFicha.Visible = true;
                colObservacion.Visible = true;
                colEmpleado.Visible = true;
                

                colID.DataPropertyName = "ID";
                colNumProduccion.DataPropertyName = "Numero_Produccion";
                colFecha.DataPropertyName = "Fecha";
                colMovimiento.DataPropertyName = "Movimiento";
                colCodigo.DataPropertyName = "Produto_ID";
                colProducto.DataPropertyName = "Producto";               
                colCantidadDisponible.DataPropertyName = "Disponible";
                colCantidadOriginal.DataPropertyName = "Cantidad";
                colCantidadEntregada.DataPropertyName = "Cantidad_Utiliz";
                colLote.DataPropertyName = "Lote";
                colMedida.DataPropertyName = "Medida";
                colMedidaID.DataPropertyName = "Medida_ID";
                colRetencion.DataPropertyName = "Retencion";
                colFicha.DataPropertyName = "Ficha";               
                colEmpleado.DataPropertyName = "Empleado";
                colObservacion.DataPropertyName = "Observaciones";

                lblResultados.Text = Resultado.Count.ToString();

                dgvMovimientoProduccion.AutoGenerateColumns = false;
                dgvMovimientoProduccion.DataSource = Resultado;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvMovimientoProduccion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlEgreso.Visible = true;
         
            IDSeleccionado = Convert.ToInt64(dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colID"].Value);
            clsCargarCombos.MostrarComboMedida(cmbMedida);
            clsCargarCombos.MostrarComboEmpleados(cmbResponsable,txtBuscarResponsable,false);
            clsCargarCombos.MostrarComboClientes(cmbTransportista, txtBuscaTransportista, false, "TRA", 0);
            clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscaCiudad, false);

            cmbMedida.SelectedIndex = -1;
            cmbResponsable.SelectedIndex = -1;
            txtCantidad.Text = "0,00";
            cmbTransportista.SelectedIndex = -1;
            cmbCiudad.SelectedIndex = -1;

            if (dgvMovimientoProduccion.RowCount > 0)
            {
                
                ProductoID = dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colCodigo"].Value.ToString();
                cmbMedida.Text = dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colMedida"].Value.ToString();
                cmbMedida.SelectedValue = Convert.ToInt32(dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colMedidaID"].Value);
                dtpLote.Value = Convert.ToDateTime(dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colLote"].Value.ToString());

                lblCantidadOriginal.Text = dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colCantidadOriginal"].Value.ToString();
                lblCantidadEgresada.Text = dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colCantidadEntregada"].Value.ToString();
                lblCantidadDisponible.Text = dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colCantidadDisponible"].Value.ToString();              
            }

            CalculaNúmeroDeProduccion();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void CalculaNúmeroDeProduccion()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OC in hb.Existencia_ProductoTerminado
                                orderby OC.ID descending
                                select OC);

                var Resultados = Consulta.FirstOrDefault();

                if (Resultados == null)
                {
                    ProduccionID = 1;
                    txtNumeroProduccion.Text = "MP1";
                }
                else
                {
                    ProduccionID = Resultados.ID + 1;
                    txtNumeroProduccion.Text = ("MP" + (Resultados.ID + 1)).ToString();
                }
            }
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            using (var hb = new DBdatos())
            {
                decimal CantidadDisponible = Convert.ToDecimal(lblCantidadDisponible.Text);
                decimal CantidadEgresada = Convert.ToDecimal(txtCantidad.Text);
                
                if (CantidadEgresada <= CantidadDisponible && CantidadEgresada != 0 && cmbResponsable.SelectedIndex != -1)
                {
                    var ConsultaMovimientoModificar = (from EPRO in hb.Existencia_ProductoTerminado
                                                       where EPRO.ID == IDSeleccionado
                                                       select EPRO).FirstOrDefault();
                    
                    var z = new Existencia_ProductoTerminado();

                    z.ID = ProduccionID;                   
                    z.Numero_Produccion = txtNumeroProduccion.Text;
                    z.Fecha = dtpFecha.Value.Date;
                    z.Produto_ID = ProductoID;

                    z.Retencion = "";
                    z.Ficha = "";
                    z.Cantidad = CantidadEgresada;
                    z.Movimiento_ID = "EPT";
                    z.Medida_ID = (int)cmbMedida.SelectedValue;
                    z.Empleado_ID = (int)cmbResponsable.SelectedValue;
                    z.Estado_ID = "ENT";
                    z.Lote = dtpLote.Value.Date.ToShortDateString();

                    if (cmbTransportista.SelectedIndex != -1)
                        z.Cliente_ID = (int)cmbTransportista.SelectedValue;
                    else
                        z.Cliente_ID = null;

                    if (cmbCiudad.SelectedIndex != -1)
                        z.Ciudad_ID = (int)cmbCiudad.SelectedValue;
                    else
                        z.Ciudad_ID = null;

                    z.Ingreso_ID = IDSeleccionado;

                    hb.Existencia_ProductoTerminado.Add(z);

                    ConsultaMovimientoModificar.Cantidad_Utiliz = ConsultaMovimientoModificar.Cantidad_Utiliz + CantidadEgresada;

                    if (CantidadEgresada == CantidadDisponible)
                        ConsultaMovimientoModificar.Estado_ID = "ENT";

                    hb.SaveChanges();
                    MessageBox.Show("Datos cargados correctamente","Atención");
                    MostrarDatos();
                    pnlEgreso.Visible = false;

                    dtpFecha.Value = DateTime.Now.Date;
                    cmbResponsable.SelectedIndex = -1;
                    txtCantidad.Text = "0,00";
                }
                else
                {
                    if (CantidadEgresada > CantidadDisponible)
                    {
                        MessageBox.Show("La cantidad egresada debe ser menor o igual a la cantidad disponible [ " + CantidadDisponible.ToString() + " ]", "Error");
                        return;
                    }
                    if (CantidadEgresada > CantidadDisponible)
                    {
                        MessageBox.Show("La cantidad egresada no puede ser 0,00", "Error");

                    }
                    if (cmbResponsable.SelectedIndex == -1)
                    {
                        MessageBox.Show("No selecciono responsable", "Error");
                        return;
                    }
                }
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
        }

        private void btnBuscarResponsable_Click(object sender, EventArgs e)
        {
            txtBuscarResponsable.Visible = true;
            txtBuscarResponsable.Select();
        }

        private void txtBuscarResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarResponsable.Visible = false;
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarResponsable.Visible = false;
            }
        }

        private void cmbResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
        }

        private void btnBuscaTransportista_Click(object sender, EventArgs e)
        {
            txtBuscaTransportista.Visible = true;
            txtBuscaTransportista.Select();
        }

        private void txtBuscaTransportista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaTransportista.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbTransportista, txtBuscaTransportista, true, "TRA", 0);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaTransportista.Visible = false;
            }
        }

        private void cmbTransportista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboClientes(cmbTransportista, txtBuscaTransportista, false, "TRA", 0);
            }
        }

        private void btnBuscaCiudad_Click(object sender, EventArgs e)
        {
            txtBuscaCiudad.Visible = true;
            txtBuscaCiudad.Select();
        }

        private void txtBuscaCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaCiudad.Visible = false;
                clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscaCiudad, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaCiudad.Visible = false;
            }
        }

        private void cmbCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscaCiudad, false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
