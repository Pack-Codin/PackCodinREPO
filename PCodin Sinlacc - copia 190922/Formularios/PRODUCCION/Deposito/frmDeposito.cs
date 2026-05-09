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
using PCodin_Sinlacc.Formularios.Deposito;
using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Formularios.VENTAS;
using PCodin_Sinlacc.Formularios.Orden_Produccion;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmDeposito : Form
    {
        //bool Filtro = 0;
        public frmDeposito()
        {
            InitializeComponent();
        }
        public string Accion;
        public frmDeposito Formulario;
        public frmDeposito2 Formulario2;
        public frmAgregarProdcutoTerminado FormularioAgregar;
        public frmProducirOndenAgregar FormularioAgregar2;
        public string ProductoOrdenCarga; // Codigo de producto traido de la orden de carga para seleccionar deposito
        IEnumerable<Existencia_ProductoTerminado> ConsultaDeposito = Enumerable.Empty<Existencia_ProductoTerminado>();
        object BotonArrastrado;

        //SELECCIONAR DEPOSITO

        public string ProductoID;
        public string ProductoDescripcion;
        public decimal CantidadParaAfectar;
        decimal CantidadAfectadaAcumulada = 0;
        public long OrdenID;
        public long PedidoID;
        public string CrearEditar;
        string AfectarAfectados = "1";
        public string Estado;
        public string DepositoSeleccionado;
        private void frmDeposito_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        public void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                foreach (var control in this.Controls)
                {


                    if (control is Button && ((Button)control).Name != "btnMostrarfiltros") 
                    {
                        if (Accion != "3") // Distinto a Seleccion orden de carga
                        {
                            ConsultaDeposito = (from D in hb.Existencia_ProductoTerminado
                                                where D.Deposito == ((Button)control).Name
                                                    && D.Estado_ID != "ENT"
                                                    && D.Estado_ID != "AN"
                                                select D);
                        }
                        else
                        {
                            ConsultaDeposito = (from D in hb.Existencia_ProductoTerminado
                                                where D.Deposito == ((Button)control).Name
                                                    && D.Estado_ID != "ENT"
                                                    && D.Estado_ID != "AN"
                                                    && D.Produto_ID == ProductoOrdenCarga
                                                select D);

                            chkFiltraInsPro.Enabled = false;
                        }

                            if (chkFiltraInsPro.Checked)
                            {
                                ConsultaDeposito = (from D in ConsultaDeposito
                                                    where D.Produto_ID == cmbFiltraInsPro.SelectedValue.ToString()
                                                    select D);
                            }
                            if (chkFiltraProduccion.Checked && txtFiltraProduccion.TextLength > 0)
                            {
                                string NumeroProduccion = txtFiltraProduccion.Text;

                                ConsultaDeposito = (from D in ConsultaDeposito
                                                    where D.Numero_Produccion == NumeroProduccion
                                                    select D);
                            }
                            if (chkFiltraFicha.Checked)
                            {
                                ConsultaDeposito = (from D in ConsultaDeposito
                                                    where D.Ficha == cmbFiltraFicha.Text
                                                    select D);
                            }
                            if (chkFiltraRetencion.Checked)
                            {
                                ConsultaDeposito = (from D in ConsultaDeposito
                                                    where D.Retencion == cmbFiltraRetencion.Text
                                                    select D);
                            }
                            if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                            {
                                ConsultaDeposito = (from C in ConsultaDeposito
                                                    where C.Fecha >= dtpFechaDesde.Value.Date
                                                    select C);
                            }
                            else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                            {
                                ConsultaDeposito = (from C in ConsultaDeposito
                                                    where C.Fecha <= dtpFechaHasta.Value.Date
                                                    select C);
                            }
                            else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                            {
                                ConsultaDeposito = (from C in ConsultaDeposito
                                                    where C.Fecha >= dtpFechaDesde.Value.Date && C.Fecha <= dtpFechaHasta.Value.Date
                                                    select C);
                            }

                            var Resultados = ConsultaDeposito.FirstOrDefault();

                            if (!chkFiltraInsPro.Checked && !chkFiltraProduccion.Checked && !chkFiltraFicha.Checked && !chkFiltraRetencion.Checked && !chkFechaDesde.Checked && !chkFechaHasta.Checked)
                            {
                                if (Resultados != null)
                                {
                                    if (Resultados.Productos_Insumos.Color != null)
                                    {
                                        ((Button)control).Visible = true;
                                        ((Button)control).BackColor = Color.FromName(Resultados.Productos_Insumos.Color);
                                        ((Button)control).Text = Resultados.Produto_ID;
                                    }
                                    else
                                    {
                                        ((Button)control).Visible = true;
                                        ((Button)control).BackColor = Color.White;
                                        ((Button)control).Text = Resultados.Produto_ID;
                                    }
                                }
                                else
                                {
                                    ((Button)control).Visible = true;
                                    ((Button)control).BackColor = Color.White;
                                    ((Button)control).Text = "";
                                }
                            }
                            else
                            {
                                if (Resultados != null)
                                {
                                    ((Button)control).Visible = true;
                                    ((Button)control).BackColor = Color.FromName(Resultados.Productos_Insumos.Color);
                                    ((Button)control).Text = Resultados.Produto_ID;
                                }
                                else
                                    ((Button)control).Visible = false;
                            }



                            //    var ResultadosUnicos = Consulta.FirstOrDefault();
                            //    var ResultadosLista = Consulta.ToList();

                            //    if (ResultadosUnicos != null)
                            //    {
                            //        ((Button)control).Visible = true;
                            //        ((Button)control).BackColor = Color.FromName(Consulta.ResultadosUnicos.Color);
                            //    }
                            //    else
                            //        ((Button)control).Visible = true;
                            //}
                            //if (chkFiltraInsPro.Checked)
                            //{
                            //    if(chkFiltraInsPro.Checked)
                            //    {
                            //        var Consulta = (from D in hb.Existencia_ProductoTerminado
                            //                        where D.Deposito == ((Button)control).Text
                            //                            && D.Estado_ID == "PEN"
                            //                            && D.Produto_ID == cmbFiltraInsPro.SelectedValue.ToString()
                            //                        select D).FirstOrDefault();

                            //        if (Consulta != null)
                            //        {
                            //            ((Button)control).Visible = true;
                            //            ((Button)control).BackColor = Color.FromName(Consulta.Productos_Insumos.Color);
                            //        }
                            //        else
                            //            ((Button)control).Visible = false;
                            //    }                          
                            //}
                            //if (chkFiltraProduccion.Checked && txtFiltraProduccion.TextLength > 0)
                            //{
                            //    long ProduccioID = Convert.ToInt64(txtFiltraProduccion.Text);

                            //    var Consulta = (from D in hb.Existencia_ProductoTerminado
                            //                    where D.Deposito == ((Button)control).Text
                            //                        && D.Estado_ID == "PEN"
                            //                        && D.ID == ProduccioID
                            //                    select D).FirstOrDefault();

                            //    if (Consulta != null)
                            //    {
                            //        ((Button)control).Visible = true;
                            //        ((Button)control).BackColor = Color.FromName(Consulta.Productos_Insumos.Color);
                            //    }
                            //    else
                            //        ((Button)control).Visible = false;
                            //}
                            //if (chkFiltraFicha.Checked)
                            //{
                            //    var Consulta = (from D in hb.Existencia_ProductoTerminado
                            //                    where D.Deposito == ((Button)control).Text
                            //                        && D.Estado_ID == "PEN"
                            //                        && D.Ficha == "SI"
                            //                    select D).FirstOrDefault();

                            //    if (Consulta != null)
                            //    {
                            //        ((Button)control).Visible = true;
                            //        ((Button)control).BackColor = Color.FromName(Consulta.Productos_Insumos.Color);
                            //    }
                            //    else
                            //        ((Button)control).Visible = false;



                    }
                    
                }
            }
        }
        private void ComenzarArrastre(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.Button BotonSeleccionado = (System.Windows.Forms.Button)sender;

            BotonArrastrado = sender;

            if (e.Button == MouseButtons.Left)
            {
                BotonSeleccionado.DoDragDrop(BotonArrastrado, DragDropEffects.Move);

            }
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from EMP in hb.Existencia_ProductoTerminado
                                where EMP.Deposito == "A1"
                                orderby EMP.Fecha descending, EMP.ID descending
                                select new
                                {
                                    EMP.ID,
                                    EMP.Produto_ID,
                                    EMP.Movimiento_ID,
                                    Movimiento = EMP.Movimientos_Produccion.Descripcion,
                                    Producto = EMP.Productos_Insumos.Descripcion,
                                    EMP.Fecha,
                                    EMP.Medida_ID,
                                    Medida = EMP.Medidas_Producto.Descripcion,
                                    EMP.Empleado_ID,
                                    Empleado = EMP.Empleados.Nombre,
                                    Disponible = EMP.Cantidad - EMP.Cantidad_Utiliz,
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

                if (chkFiltraInsPro.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Produto_ID == cmbFiltraInsPro.Text
                                select C);

                    InicializarForm();
                }

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


                // var Resultado = Consulta.ToList();

                // colFecha.Visible = true;
                // colMovimiento.Visible = true;
                // colRetencion.Visible = true;
                // colFicha.Visible = true;
                // colObservacion.Visible = true;
                // colEmpleado.Visible = true;


                // colID.DataPropertyName = "ID";
                // colFecha.DataPropertyName = "Fecha";
                // colMovimiento.DataPropertyName = "Movimiento";
                // colCodigo.DataPropertyName = "Produto_ID";
                // colProducto.DataPropertyName = "Producto";
                // colCantidadDisponible.DataPropertyName = "Disponible";
                // colMedida.DataPropertyName = "Medida";
                // colRetencion.DataPropertyName = "Retencion";
                // colFicha.DataPropertyName = "Ficha";
                // colEmpleado.DataPropertyName = "Empleado";
                // colObservacion.DataPropertyName = "Observaciones";

                //// txtCantidadResultados.Text = Resultado.Count.ToString();

                // dgvMovimientoProduccion.AutoGenerateColumns = false;
                // dgvMovimientoProduccion.DataSource = Resultado;
            }
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (Accion == "Seleccionar")
            {
                DeleteTT_DepositoSeleccionado();
                this.Hide();
            }
            else
            {
                this.Hide();
            }
            
        }
        public static void DeleteTT_DepositoSeleccionado()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from TTDS in hb.TT_DepositoSeleccionado
                                select TTDS).ToList();

                hb.TT_DepositoSeleccionado.RemoveRange(Consulta);
                hb.SaveChanges();
            }
        }
        private void AbriVisorDeposito(Button btn)
        {
            try
            {
                if (Accion != "Seleccionar")
                {
                    //var f = new frmSeleccionarProducto();
                    //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmSeleccionarProducto_FormClosed);
                    //f.ProductoID = ProductoID;
                    //f.CantidadParaAfectar = CantidadParaAfectar;
                    //f.PedidoID = PedidoID;
                    //f.CrearEditar = CrearEditar;

                    //if (CrearEditar == "1" || CrearEditar == "3")
                    //    f.OrdenID = OrdenID;
                    //if (CrearEditar == "2")
                    //    f.OrdenID = Convert.ToInt64(OrdenID);

                    //f.ProductoDescripcion = ProductoDescripcion;
                    //f.Estado = Estado;
                    //f.ShowDialog();

                    var f = new frmVisorDeposito();
                    f.Deposito = btn.Name;
                    f.TopMost = true;
                    f.Show();
                }
                else
                {
                    using (var hb = new DBdatos())
                    {
                        //FormularioAgregar.IDSalida =
                        if (btn.Name.Length == 8)
                        {
                            if (FormularioAgregar != null)
                            {
                                FormularioAgregar.cmbRack.Text = btn.Name.Remove(2).ToString();
                                FormularioAgregar.cmbEspacio.Text = btn.Name.Substring(2, 2);
                                FormularioAgregar.cmbPiso.Text = btn.Name.Substring(4, 2);
                                FormularioAgregar.cmbLado.Text = btn.Name.Substring(6, 2);
                            }
                            else
                            {
                                FormularioAgregar2.cmbRack.Text = btn.Name.Remove(2).ToString();
                                FormularioAgregar2.cmbEspacio.Text = btn.Name.Substring(2, 2);
                                FormularioAgregar2.cmbPiso.Text = btn.Name.Substring(4, 2);
                                FormularioAgregar2.cmbLado.Text = btn.Name.Substring(6, 2);
                            }

                        }
                        if (btn.Name.Length == 9)
                        {
                            if (FormularioAgregar != null)
                            {
                                FormularioAgregar.cmbRack.Text = btn.Name.Remove(2);
                                FormularioAgregar.cmbEspacio.Text = btn.Name.Substring(2, 3);
                                FormularioAgregar.cmbPiso.Text = btn.Name.Substring(5, 2);
                                FormularioAgregar.cmbLado.Text = btn.Name.Substring(7, 2);
                            }
                            else
                            {
                                FormularioAgregar2.cmbRack.Text = btn.Name.Remove(2);
                                FormularioAgregar2.cmbEspacio.Text = btn.Name.Substring(2, 3);
                                FormularioAgregar2.cmbPiso.Text = btn.Name.Substring(5, 2);
                                FormularioAgregar2.cmbLado.Text = btn.Name.Substring(7, 2);
                            }
                        }

                        this.Hide();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            //AbriVisorDeposito(btnA1);
        }

        private void btnA2_Click(object sender, EventArgs e)
        {
            //AbriVisorDeposito(btnA2);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            InicializarForm();
        }

        private void chkFiltraInsPro_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, btnBuscarInsPro, "PRO", "NO");
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
            btnMostrarfiltros.Text = "";
        }

        private void chkFiltraProduccion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraProduccion, chkFiltraProduccion);
            btnMostrarfiltros.Text = "";
        }

        private void chkFiltraRetencion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraRetencion, cmbFiltraRetencion);

        }

        private void chkFiltraFicha_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraFicha, cmbFiltraFicha);

        }

        private void chkFechaDesde_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaDesde, dtpFechaDesde);

        }

        private void chkFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaHasta, dtpFechaHasta);
        }

        private void gbxFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void R1E1P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void frmDeposito_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void R1E1P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E1P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E1P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E1P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E1P3L2_Click(object sender, EventArgs e)
        {
            AbriVisorDeposito(R1E1P1L2);
        }
        private frmDeposito2 Deposito2 = new frmDeposito2();
        private frmPrueba2 Espera = new frmPrueba2();
        private void btnAbrirSeccion2_Click(object sender, EventArgs e)
        {
            Formulario.Hide();

            Deposito2.FormularioAgregar = FormularioAgregar;
            //Deposito2.Load += new System.EventHandler(this.frmDeposito2_Load);
            Deposito2.FormSeccion1 = Formulario;
            Deposito2.FormSeccion2 = Deposito2;
            Deposito2.Accion = Accion;
            //Deposito2.InicializarForm();
            //Espera.Show();
            Deposito2.Show();
           
        }

        private void frmDeposito2_Load(object sender, EventArgs e)
        {
            //Espera.Hide();
        }

        private void R2E1P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E1P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E1P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E1P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E1P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E1P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E1P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E1P2L2_MouseClick(object sender, MouseEventArgs e)
        {
            var Boton = sender as Button;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formulario.InicializarForm();
        }

        private void R3E1P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E1P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E1P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E1P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E1P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E1P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E1P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E1P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E1P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E1P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E1P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E1P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E1P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E1P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E1P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E1P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E1P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E1P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E1P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E1P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E1P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E1P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E1P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E2P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E2P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E2P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E2P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E2P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E2P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E2P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E2P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E2P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E2P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E2P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E2P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E2P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E2P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E2P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E2P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E2P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E2P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E2P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E2P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E2P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E2P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E2P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E2P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E2P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E2P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E2P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E2P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E2P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E2P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E2P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E2P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E2P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E2P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E2P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E2P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E3P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E3P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E3P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E3P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E3P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E3P1L2_Click(object sender, EventArgs e)
        {

        }

        private void R3E3P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E3P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E3P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E3P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E3P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E3P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E3P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E3P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E3P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E3P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E3P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E3P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E3P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E3P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E3P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E3P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E3P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E3P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E3P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E3P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E3P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E3P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E3P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E3P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E3P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E3P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E3P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E4P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E4P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E4P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E4P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E4P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E4P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E4P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E4P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E4P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E4P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E4P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E4P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E4P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E4P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E4P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E4P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E4P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E4P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E4P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E4P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E4P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E4P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E4P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E4P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E4P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E4P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E4P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E4P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E4P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E4P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E4P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E4P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E4P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E4P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E4P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E4P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E5P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E5P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E5P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E5P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E5P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E5P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E5P3L2_Click(object sender, EventArgs e)
        {

            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E5P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E5P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E5P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E5P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E5P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E5P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E5P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E5P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E5P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E5P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E5P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E5P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E5P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E5P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E5P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E5P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E5P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E5P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E5P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E5P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E5P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E5P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E5P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E5P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E5P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E5P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E5P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E5P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E5P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E6P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E6P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E6P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E6P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E6P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E6P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E6P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E6P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E6P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E6P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E6P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E6P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E6P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E6P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E6P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E6P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E6P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E6P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E6P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E6P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E6P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E6P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E6P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E6P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E6P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E6P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E6P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E6P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E6P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E6P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E6P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E6P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E6P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E6P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E6P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E6P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E7P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E7P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E7P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E7P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E7P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E7P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E7P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E7P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E7P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E7P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E7P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E7P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E7P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E7P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E7P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E7P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E7P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E7P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E7P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E7P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E7P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E7P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E7P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E7P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E7P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E7P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E7P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E7P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E7P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E7P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E7P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E7P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E7P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E7P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E7P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E7P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsPro, txtBuscaInsPro, "PRO", true, "NO");
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

        private void cmbFiltraInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsPro, txtBuscaInsPro, "PRO", false, "NO");
                txtBuscaInsPro.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.SelectAll();
        }

        private void button2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void R1E1P1L1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void R1E1P1L1_MouseDown(object sender, MouseEventArgs e)
        {
           // ComenzarArrastre(sender, e);
        }

        private void button2_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void frmSeleccionarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void txtBuscaInsPro_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
