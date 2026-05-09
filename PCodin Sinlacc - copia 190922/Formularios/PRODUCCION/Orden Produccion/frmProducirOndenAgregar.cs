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
using PCodin_Sinlacc.Formularios.Notificación;
using PCodin_Sinlacc.Formularios.Deposito;

namespace PCodin_Sinlacc.Formularios.Orden_Produccion
{
    public partial class frmProducirOndenAgregar : Form
    {
        public long OrdenProdPartID;
        public long OrdenProdID;
        public string ProductoID;
        public string InsumoID;
        public string Insumo;
        public decimal CantidadGeneral;
        public int SeccionID;
        decimal CantidadProducida = 0;
        string AnularCarga = "NO";
        long ExisProdterm_ID = 0;
        long OrdenProduccionParteCuerpoID = 0; // variable que sirve para calcular el ID a la hora de agregar un nuevo registro cuando la seccion es la final
        List<long> ListaOrdenProdParteCuerpo_ID = new List<long>(); // Lista para que se carguen los ordprodpartescuerpoID que estaban al comienzo para que cuando eliminemos sepan cuales faltan y así eliminar solo los que faltan
        string SeccionFinal;
        public string NumeroPedido;
        string EliminarEPT = "NO"; // lo que hace es dar una orden para eliminar un movimento de produccion producido
        List<long> ListaOrdenProdParteCuerpo_ID_Eliminar = new List<long>();
        string Inicio = "NO";
        long NuevoOPPC_ID;
        long NuevoEPT_ID;
        string NumeroProduccion;
        public frmProducirOrden FormularioProducirOrden;
        public string EstadoID;
        private frmDeposito FormularioDeposito = new frmDeposito();
        private frmDeposito2 FormularioDeposito2 = new frmDeposito2();
        

        public frmProducirOndenAgregar()
        {
            InitializeComponent();
        }

        private void frmProducirOndenAgregar_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        
        private void InicializarForm()
        {
            Reutilizables.RenderizarForm(this);

            if (EstadoID == "AN" || EstadoID == "FI")
                btnCargar.Visible = false;
            else
                btnCargar.Visible = true;

            dtpFechaDesde.Value = DateTime.Now.Date;
            dtpFechaHasta.Value = DateTime.Now.Date;
            clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
            cmbResponsable.SelectedIndex = -1;
            MostrarDatos("NO");
            CalcularCantidadPendProducidas();
        }
        private void MostrarDatosFiltrados()
        {
            int CantidadDeRegistros = 0;

            for (var i = 1; i <= dgvAgregar.RowCount; i++)
            {
                if (chkFiltraResponsable.Checked)
                {
                    
                    int EmpleadoID = (int)dgvAgregar.Rows[i - 1].Cells[columnName: "colResponsableID"].Value;

                    if (EmpleadoID != (int)cmbFiltraResponsable.SelectedValue)
                    {
                        dgvAgregar.Rows[i - 1].Visible = false;
                    }  
                    else
                    {
                        dgvAgregar.Rows[i - 1].Visible = true;
                        CantidadDeRegistros = CantidadDeRegistros + 1;
                    }
                }
                else
                {
                     dgvAgregar.Rows[i - 1].Visible = true;
                    CantidadDeRegistros = CantidadDeRegistros + 1;
                }
            }
            txtCantidadResultados.Text = CantidadDeRegistros.ToString();
        }
        private void DefinirSeccionFinal()
        {
            
                using (var hb = new DBdatos())
                {
                    var Consulta = (from SEC in hb.Seccion
                                    where SEC.ID == SeccionID
                                    select SEC).FirstOrDefault();

                    if (Consulta.Seccion_Final == "SI")
                        SeccionFinal = "SI";
                    else
                        SeccionFinal = "NO";
                }
            
        }
        private void ApagarbtnCargar()
        {
            //if(chkFiltraResponsable.Checked ||
            //   chkFechaDesde.Checked ||
            //   chkFechaHasta.Checked)
            //{
            //    btnCargar.Enabled = false;
            //}
           
        }
        private void OnOffbtnCargar()
        {
            if (!chkFiltraResponsable.Checked &&
               !chkFechaDesde.Checked &&
               !chkFechaHasta.Checked)
            {
                btnCargar.Enabled = true;
                picFiltroActivo.Visible = false;
                picFiltroInactivo.Visible = true;
            }
            else
            {
                btnCargar.Enabled = false;
                picFiltroActivo.Visible = true;
                picFiltroInactivo.Visible = false;
            }
        }
        private void MostrarDatos(string UsaFiltro)
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    dgvAgregar.Rows.Clear();

                    var Consulta = (from PA in hb.OrdenProduccionParteCuerpo
                                    where PA.OrdenProdParte_ID == OrdenProdPartID
                                    select new
                                    {
                                        PA.Fecha,
                                        PA.Hora,
                                        PA.Orden_Produccion_Parte.Insumo_ID,
                                        PA.Orden_Produccion_Parte.Productos_Insumos.Descripcion,
                                        PA.Cantidad,
                                        PA.Tiempo_Empleado,
                                        ProductoID = PA.Orden_Produccion_Parte.OrdenProduccion_Cuerpo.Producto_ID,
                                        Producto = PA.Orden_Produccion_Parte.OrdenProduccion_Cuerpo.Productos_Insumos.Descripcion,
                                        PA.Responsable_ID,
                                        PA.Empleados.Nombre,
                                        PA.ID,
                                    });

                    if (chkFiltraSubProducto.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Insumo_ID == cmbFiltraSubProducto.SelectedValue.ToString()
                                    select C);
                    }
                    if (chkFiltraResponsable.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Responsable_ID == (int)cmbFiltraResponsable.SelectedValue
                                    select C);
                    }

                    if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                    {
                        Consulta = (from C in Consulta
                                    where C.Fecha >= dtpFechaDesde.Value.Date
                                    select C);
                    }
                    else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Fecha <= dtpFechaHasta.Value.Date
                                    select C);
                    }
                    else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Fecha >= dtpFechaDesde.Value.Date && C.Fecha <= dtpFechaHasta.Value.Date
                                    select C);
                    }

                    var Resultados = Consulta.ToList();

                    txtCantidadResultados.Text = Resultados.Count().ToString();

                    var ConsultaSeccion = (from SEC in hb.Seccion
                                           where SEC.ID == SeccionID
                                           select SEC).FirstOrDefault();

                    if (ConsultaSeccion.Seccion_Final == "SI")
                    {
                        cmbCalle.Enabled = true;
                        cmbNumeroCalle.Enabled = true;
                        //cmbTurno.Enabled = true;
                        btnMostraDeposito.Enabled = true;
                    }
                    foreach (var item in Consulta)
                    {
                        string ProductoInsumo;
                        string ProductoInsumoID;

                        var ConsultaDatosExistencia = (from EPT in hb.Existencia_ProductoTerminado
                                                       where EPT.OrdenProduccionParteCuerpo_ID == item.ID
                                                       select EPT).FirstOrDefault();

                        var ConsultaDeposito = (from EPT in hb.Existencia_ProductoTerminado
                                                where EPT.OrdenProduccionParteCuerpo_ID == item.ID
                                                select EPT).FirstOrDefault();

                        if (SeccionFinal == "NO")
                        {
                            ProductoInsumoID = item.Insumo_ID;
                            ProductoInsumo = item.Descripcion;
                        }
                        else
                        {
                            ProductoInsumoID = item.ProductoID;
                            ProductoInsumo = item.Producto;
                        }

                        dgvAgregar.Rows.Add(
                                               item.Fecha,
                                               item.Hora,
                                               ProductoInsumoID,
                                               ProductoInsumo,
                                               item.Cantidad,
                                               ConsultaDatosExistencia.Lote,
                                               item.Hora,
                                               item.Responsable_ID,
                                               item.Nombre,
                                               item.ID,
                                               ConsultaDatosExistencia.Deposito,
                                               ConsultaDatosExistencia.Humedad,
                                               ConsultaDatosExistencia.Acidez
                                               );
                        //DataGridViewRow Fila = new DataGridViewRow();

                        //Fila.CreateCells(dgvAgregar);
                        //Fila.Cells[0].Value = item.Fecha;
                        //Fila.Cells[1].Value = item.Hora;


                        //Fila.Cells[4].Value = item.Cantidad;
                        //Fila.Cells[5].Value = item.Tiempo_Empleado;
                        //Fila.Cells[6].Value = item.Responsable_ID;
                        //Fila.Cells[7].Value = item.Nombre;
                        //Fila.Cells[8].Value = item.ID;

                        //ListaOrdenProdParteCuerpo_ID.Add(item.ID);

                        //dgvAgregar.Rows.Add(Fila);
                    }
                    if (UsaFiltro == "NO")
                    {
                        CorroborarCantidades();
                        btnCargar.Enabled = true;
                    }
                    else
                    {
                        btnCargar.Enabled = false;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
            
        }
        private void CalcularCantidadPendProducidas()
        {
            if(dgvAgregar.RowCount > 0)
            {
                decimal Cantidad = 0;

                for (var i = 1; i <= dgvAgregar.RowCount; i++)
                {
                    Cantidad = Convert.ToDecimal(dgvAgregar.Rows[i - 1].Cells[columnName: "colCantidad"].Value) + Cantidad;                         
                }
                lblPendiente.Text = (CantidadGeneral - Cantidad).ToString("N2");
                lblProducido.Text = Cantidad.ToString("N2");
                lblTotal.Text = CantidadGeneral.ToString("N2");
            }
            else
            {
                lblPendiente.Text = CantidadGeneral.ToString("N2");
                lblProducido.Text = "0,00";
                lblTotal.Text = CantidadGeneral.ToString("N2");
            }
        }
        private void CorroborarCantidades() // Ayuda a que no ingresemo una cantidad mayor de que se solicita 
        {
            if (dgvAgregar.RowCount > 0)
            {
                CantidadProducida = 0;

                for (var i = 1; i <= dgvAgregar.RowCount; i++)
                {
                    CantidadProducida = CantidadProducida + Convert.ToDecimal(dgvAgregar.Rows[i - 1].Cells[columnName: "colCantidad"].Value);
                }
                CantidadProducida = CantidadProducida + Convert.ToDecimal(txtCantidad.Text);


            }
            else
            {
                if (txtCantidad.TextLength > 0)
                    CantidadProducida = Convert.ToDecimal(txtCantidad.Text);
                else
                    CantidadProducida = 0;      
                
            }
            if (CantidadProducida > CantidadGeneral)
            {
                MessageBox.Show("La cantidad producida no debe ser mayor a " + CantidadGeneral.ToString(), "Atención");
                AnularCarga = "SI";
            }
            else
                AnularCarga = "NO";

        }
        private void AgregarItemALista()
        {
            using (var hb = new DBdatos())
            {
                if (cmbResponsable.SelectedIndex != -1 &&
                txtHora.TextLength > 1 &&
                txtMinuto.TextLength > 1 &&
                txtCantidad.Text != "0,00" &&
                txtCantidad.Text != "0" &&
                txtIngresoHora.TextLength == 5 &&
                txtLote.Text != "" &&
                txtHumedad.Text != "0,00"  &&
                txtAcidez.Text != "0,00")
               


                {
                    CorroborarCantidades();

                    if (AnularCarga == "NO")
                    {
                        string Deposito = "";  
                        //DataGridViewRow Fila = new DataGridViewRow();

                        //Fila.CreateCells(dgvAgregar);
                        //Fila.Cells["colFecha"].Value = dtpFecha.Value.Date;
                        //Fila.Cells[1].Value = txtIngresoHora.Text;
                        //Fila.Cells[2].Value = InsumoID;
                        //Fila.Cells[3].Value = Insumo;
                        //Fila.Cells[4].Value = txtCantidad.Text;
                        //Fila.Cells[5].Value = txtHora.Text + ":" + txtMinuto.Text;
                        //Fila.Cells[6].Value = cmbResponsable.SelectedValue;
                        //Fila.Cells[7].Value = cmbResponsable.Text;

                        var ConsultaDeposito = (from EPT in hb.Existencia_ProductoTerminado
                                                where EPT.Deposito ==  cmbRack.Text + cmbEspacio.Text + cmbPiso.Text + cmbLado.Text
                                                    && EPT.Estado_ID == "PEN"
                                                select EPT).FirstOrDefault();
             
                        var ConsultaSección = (from SEC in hb.Seccion
                                               where SEC.ID == SeccionID
                                               select SEC).FirstOrDefault();

                        //CONSULTA SI DESEA GUARDAR UN PRODUCTO FINAL SIN DEPOSITO
                        if (ConsultaSección.Seccion_Final == "SI")
                        {
                            if (cmbRack.Text != "" || cmbEspacio.Text != "" || cmbPiso.Text != "" || cmbLado.Text != "")
                            {
                                if (ConsultaDeposito != null)
                                {
                                    DialogResult R2 = MessageBox.Show("Esta ubicación ya contiene producto terminado. ¿Desea ensimar la mismas?", "Atención", MessageBoxButtons.YesNo);
                                    
                                    if (R2 == DialogResult.Yes)
                                    {
                                        if (ConsultaDeposito.Produto_ID == ProductoID)
                                        {
                                            Deposito = cmbRack.Text + cmbEspacio.Text + cmbPiso.Text + cmbLado.Text;
                                        }
                                        else
                                        {
                                            MessageBox.Show("No puede haber 2 productos distintos en una misma ubicacion de depósito", "Atención");
                                            return;
                                        }
                                    }
                                    else
                                        return;
                                }
                                else
                                {
                                    Deposito = cmbRack.Text + cmbEspacio.Text + cmbPiso.Text + cmbLado.Text;
                                }
                            }
                            else
                            {
                                DialogResult R = MessageBox.Show("No seleccionó depósito. ¿Desea continuar?", "Atención", MessageBoxButtons.YesNoCancel);
                                if (R != DialogResult.Yes)
                                {
                                    Deposito = "";
                                    return;
                                }
                            }
                        }
                        dgvAgregar.Rows.Add(
                                           dtpFecha.Value,
                                           txtIngresoHora.Text,
                                           InsumoID,
                                           Insumo,
                                           txtCantidad.Text,
                                           txtLote.Text,
                                           txtHora.Text + ":" + txtMinuto.Text,
                                           cmbResponsable.SelectedValue,
                                           cmbResponsable.Text,
                                           "",
                                           Deposito,
                                           txtHumedad.Text,
                                           txtAcidez.Text
                                           );
                    }
                }
                else
                {
                    if(txtIngresoHora.TextLength < 5)
                    {
                        MessageBox.Show("No estableció la hora de ingreso", "Atención");
                        return;
                    }
                    if (cmbResponsable.SelectedIndex < 0)
                    {
                        MessageBox.Show("No seleccionó responsable", "Atención");
                        return;
                    }
                    if (txtHora.TextLength <= 1 || txtMinuto.TextLength <= 1)
                    {
                        MessageBox.Show("La hora del tiempo empleado debe tener el formato 00:00", "Atención");
                        return;
                    }
                    if (txtCantidad.Text == "0,00" || txtCantidad.Text == "0")
                    {
                        MessageBox.Show("La cantidad debe ser mayor a 0", "Atención");
                        return;
                    }
                    if(txtLote.Text == "")
                        MessageBox.Show("No ingresó lote", "Atención");
                    if (txtHumedad.Text == "0,00" || txtHumedad.Text == "0")
                        MessageBox.Show("No ingresó Humedad", "Atención");
                    if (txtAcidez.Text == "0,00" || txtAcidez.Text == "0")
                        MessageBox.Show("No ingresó Acidez", "Atención");
                }

                  
            }
        }
        private void CalcularID()
        {
            using (var hb = new DBdatos())
            {
                if (Inicio == "NO")
                {
                    var Consulta = (from OPPC in hb.OrdenProduccionParteCuerpo
                                    orderby OPPC.ID descending
                                    select OPPC).FirstOrDefault();

                    var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                       orderby EPT.ID descending
                                       select EPT).FirstOrDefault();

                    if (Consulta == null)
                    {
                        OrdenProduccionParteCuerpoID = 1;

                    }
                    else
                    {
                        OrdenProduccionParteCuerpoID = Consulta.ID + 1;
                    }

                    if (ConsultaEPT == null)
                    {
                        ExisProdterm_ID = 1;
                        NumeroProduccion = "MP1";
                    }
                    else
                    {
                        ExisProdterm_ID = ConsultaEPT.ID + 1;
                        NumeroProduccion = "MP" + ExisProdterm_ID.ToString();
                    }

                    Inicio = "SI";
                }
                else
                {
                    OrdenProduccionParteCuerpoID = OrdenProduccionParteCuerpoID + 1;
                    ExisProdterm_ID = ExisProdterm_ID + 1;
                    NumeroProduccion = "MP" + ExisProdterm_ID.ToString();
                }
            }
        }
        private void CargarDatos()
        {
            if (dgvAgregar.RowCount > 0)
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaSeccion = (from SEC in hb.Seccion
                                           where SEC.ID == SeccionID
                                           select SEC).FirstOrDefault();

                    for (var i = 1; i <= dgvAgregar.RowCount; i++)
                    {
                        string Hora = dgvAgregar.Rows[i - 1].Cells[columnName: "colHora"].Value.ToString();

                        DateTime Fecha = Convert.ToDateTime(dgvAgregar.Rows[i - 1].Cells[columnName: "colFecha"].Value).Date;
                        decimal Cantidad = Convert.ToDecimal(dgvAgregar.Rows[i - 1].Cells[columnName: "colCantidad"].Value);
                        int Responsable_ID = (int)dgvAgregar.Rows[i - 1].Cells[columnName: "colResponsableID"].Value;
                        string TiempoEmpleado = dgvAgregar.Rows[i - 1].Cells[columnName: "colTiempoEmpleado"].Value.ToString();
                        string Deposito = "";
                        string Humedad = dgvAgregar.Rows[i - 1].Cells[columnName: "colHumedad"].Value.ToString();
                        string Acidez = dgvAgregar.Rows[i - 1].Cells[columnName: "colAcidez"].Value.ToString();
                        string Lote = dgvAgregar.Rows[i - 1].Cells[columnName: "colLote"].Value.ToString();
                        if (cmbRack.Enabled == true)
                        {
                            if (dgvAgregar.Rows[i - 1].Cells[columnName: "colDeposito"].Value != null)
                            {
                                Deposito = dgvAgregar.Rows[i - 1].Cells[columnName: "colDeposito"].Value.ToString();
                            }
                        }

                        // SI TIENE ORDENPRODPARTECUERPO --> EDITA
                        if (dgvAgregar.Rows[i - 1].Cells[columnName: "colOrdenProdParteCuerpoID"].Value.ToString() != "")
                        {
                            long ID = (long)dgvAgregar.Rows[i - 1].Cells[columnName: "colOrdenProdParteCuerpoID"].Value;

                            var Consulta = (from OPPC in hb.OrdenProduccionParteCuerpo
                                            where OPPC.ID == ID
                                            select OPPC).FirstOrDefault();

                            Consulta.Fecha = Fecha;
                            Consulta.Hora = Convert.ToDateTime(Hora).TimeOfDay;
                            Consulta.Cantidad = Cantidad;
                            Consulta.Responsable_ID = Responsable_ID;
                            Consulta.Tiempo_Empleado = Convert.ToDateTime(TiempoEmpleado).TimeOfDay;


                            decimal CantidadPendiente = Convert.ToDecimal(lblPendiente.Text);

                            if (CantidadPendiente == 0)
                            {
                               // Consulta.Orden_Produccion_Parte.Estado_ID = "FI";
                            }
                        }
                        // SI NO --> CREA
                        else
                        {
                            if(txtLote.Text != "" && txtAcidez.Text != "0,00" && txtHumedad.Text != "0,00")
                            {
                                CalcularID();

                                var z = new OrdenProduccionParteCuerpo();

                                z.ID = OrdenProduccionParteCuerpoID;
                                z.OrdenProdParte_ID = OrdenProdPartID;
                                z.Fecha = Fecha;
                                z.Hora = Convert.ToDateTime(Hora).TimeOfDay;
                                z.Cantidad = Cantidad;
                                z.Responsable_ID = Responsable_ID;
                                z.Tiempo_Empleado = Convert.ToDateTime(TiempoEmpleado).TimeOfDay;

                                hb.OrdenProduccionParteCuerpo.Add(z);


                                if (ConsultaSeccion.Seccion_Final == "SI") // SI LA SECCION ES LA FINAL AGREGA PRODUCTO TERMINADO
                                {

                                    var ConsultaOPP = (from OPP in hb.Orden_Produccion_Parte
                                                       where OPP.ID == OrdenProdPartID
                                                       select OPP).FirstOrDefault();

                                    var ConsultaPedido = (from PED in hb.Pedido_Cuerpo
                                                          where PED.Registro_Pedidos.Numero_Pedido == NumeroPedido
                                                          && PED.Producto_ID == ProductoID
                                                          select PED).FirstOrDefault();

                                    //MODIFICA LA CANTIDAD TOTAL A PRODUCIR
                                    ConsultaPedido.Cantidad_Total_Producida = ConsultaPedido.Cantidad_Total_Producida + Cantidad;
                                    ConsultaPedido.Cantidad_Pend_Producir = ConsultaPedido.Cantidad_Pend_Producir - Cantidad;

                                    var w = new Existencia_ProductoTerminado();

                                    w.ID = ExisProdterm_ID;
                                    w.Numero_Produccion = NumeroProduccion;
                                    w.Fecha = Fecha;
                                    w.Produto_ID = ConsultaOPP.OrdenProduccion_Cuerpo.Producto_ID;
                                    w.Cantidad = Cantidad;
                                    w.Cantidad_Utiliz = 0;
                                    w.Ficha = "NO";
                                    w.Retencion = "NO";
                                    w.Empleado_ID = Responsable_ID;
                                    w.Medida_ID = ConsultaOPP.OrdenProduccion_Cuerpo.Productos_Insumos.Medida;
                                    w.Movimiento_ID = "IPT";
                                    w.Estado_ID = "PEN";
                                    w.Deposito = Deposito;
                                    w.OrdenProduccionParteCuerpo_ID = OrdenProduccionParteCuerpoID;
                                    w.Humedad = Convert.ToDecimal(Humedad);
                                    w.Acidez = Convert.ToDecimal(Acidez);
                                    w.Lote = Lote;

                                    //w.Turno = cmbTurno.Text;

                                    hb.Existencia_ProductoTerminado.Add(w);

                                    decimal CantidadPendiente = Convert.ToDecimal(lblPendiente.Text);

                                    //AQUI FINALIZA LA ORDEN
                                    if (CantidadPendiente == 0)
                                    {
                                        //ConsultaOPP.OrdenProduccion_Cuerpo.Orden_Produccion.Estado_ID = "FI";
                                    }
                                }
                            }
                            else
                            {
                                if (txtLote.Text == "")
                                    MessageBox.Show("No selecciono lote", "Atencion");
                                if(txtAcidez.Text == "0,00")
                                    MessageBox.Show("No indico Acidez", "Atencion");
                                if (txtHumedad.Text == "0,00")
                                    MessageBox.Show("No indico humedad", "Atencion");                                     
                            }
                        }
                       
                    }
                    if (EliminarEPT == "SI")
                    {
                        var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                           where ListaOrdenProdParteCuerpo_ID_Eliminar.Contains((long)EPT.OrdenProduccionParteCuerpo_ID)
                                           select EPT).ToList();

                        hb.Existencia_ProductoTerminado.RemoveRange(ConsultaEPT);

                        var ConsultaOPPC = (from OPPC in hb.OrdenProduccionParteCuerpo
                                            where ListaOrdenProdParteCuerpo_ID_Eliminar.Contains(OPPC.ID)
                                            select OPPC).ToList();

                        foreach(var item in ConsultaOPPC)
                        {
                            var ConsultaPedido = (from PED in hb.Pedido_Cuerpo
                                                  where PED.Registro_Pedidos.ID == item.Orden_Produccion_Parte.OrdenProduccion_Cuerpo.Pedido_ID
                                                  select PED).FirstOrDefault();

                            ConsultaPedido.Cantidad_Total_Producida = ConsultaPedido.Cantidad_Total_Producida - item.Cantidad;
                            ConsultaPedido.Cantidad_Pend_Producir = ConsultaPedido.Cantidad_Pend_Producir + item.Cantidad;
                        }
                        hb.OrdenProduccionParteCuerpo.RemoveRange(ConsultaOPPC);
                       
                    }
                    hb.SaveChanges();
                    MessageBox.Show("Datos cargados correctamente", "Atención");
                    this.Hide();
                    FormularioProducirOrden.MostrarDatos();
                }
            }
        }
        private void btnConfirmarProducto_Click(object sender, EventArgs e)
        {
            AgregarItemALista();
            CalcularCantidadPendProducidas();
        }

        private void txtIngresoHoras_TextChanged(object sender, EventArgs e)
        {
           Reutilizables.CoregirHora(txtIngresoHoras, txtIngresoMinutos); //AYUDA A QUE INGRESEMOS BIEN LA HORA
           Reutilizables.PasarHoraManualAlTexbox(txtIngresoHora, txtIngresoHoras, txtIngresoMinutos);// PASA EN LIMPIO LA HORA DE LOS 2 TEXBOX HORAS-MINUTOS
        }

        private void txtIngresoMinutos_TextChanged(object sender, EventArgs e)
        {
            Reutilizables.CorregirMinutos(txtIngresoHoras, txtIngresoMinutos);
            Reutilizables.PasarHoraManualAlTexbox(txtIngresoHora, txtIngresoHoras, txtIngresoMinutos);
        }

        private void btnHora_Click(object sender, EventArgs e)
        {
            Reutilizables.MOstrarHoraAutomatica(txtIngresoHora, txtIngresoHoras, txtIngresoMinutos, btnHora, btnVolverHoraManual,lblSeparador);
        }

        private void btnVolverHoraManual_Click(object sender, EventArgs e)
        {
            Reutilizables.VolverAHoraManual(txtIngresoHora, txtIngresoHoras, txtIngresoMinutos, btnHora, btnVolverHoraManual , lblSeparador);
        }

        private void txtIngresoHoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtHora);
        }

        private void txtIngresoMinutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtMinuto);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void NotificarPuntoPedido()
        {
            using (var hb = new DBdatos())
            {

                //// AQUI RECALCULA EL PUNTO DE PEDIDO 
                bool AbrirAlerta = false;

                var ConsultaFormulaProducto = (from FP in hb.Formula_Producto
                                               where FP.Producto_ID == ProductoID
                                               select FP).ToList();

                // ESTAS 2 CONSULTAS SE HACEN PARA COMPARAR LOS STOCKS MINIMOS Y VER SI HAY QUE NOTIFICAR
                var ConsultaStockMin = (from EPT in hb.Productos_Insumos
                                        where EPT.Codigo == ProductoID
                                        select EPT).FirstOrDefault();

                var ConsultaStockMinActual = (from VS in hb.Vista_Stock
                                              where VS.Codigo == ProductoID
                                              select VS).FirstOrDefault();

                if (ConsultaFormulaProducto.Count > 0)
                {
                    foreach (var item in ConsultaFormulaProducto)
                    {
                        var ConsultaPuntoPedido = (from VPP in hb.Vista_CalcularPuntoPedido
                                                   where VPP.Codigo == item.Insumo_ID
                                                   select VPP).FirstOrDefault();

                        var ConsultaExistenciaIns = (from E in hb.Existencia_Insumos
                                                     join VPP in hb.Vista_CalcularPuntoPedido on E.Insumo_ID equals VPP.Codigo
                                                     where VPP.Codigo == item.Insumo_ID
                                                     group new { E, VPP } by new
                                                     {
                                                         E.Insumo_ID,
                                                         Insumo = E.Productos_Insumos.Descripcion,
                                                         E.Medida_ID,
                                                         Medida = E.Medidas_Producto.Descripcion,
                                                         Categoria = E.Productos_Insumos.Categoria_ID,
                                                         VPP.PuntoPedido
                                                     } into Group
                                                     orderby Group.Key.Insumo
                                                     select new
                                                     {
                                                         Group.Key.Insumo_ID,
                                                         Group.Key.Insumo,
                                                         Existencia = Group.Sum(x => x.E.Cantidad) - Group.Sum(x => x.E.Cantidad_Utilizada),
                                                         Group.Key.Medida_ID,
                                                         Group.Key.Medida,
                                                         Stockmin = Group.Sum(x => x.E.Productos_Insumos.StockMin),
                                                         Group.Key.Categoria,
                                                         Group.Key.PuntoPedido
                                                         //PuntoPedido = Group.Sum(x => x.VPP.PuntoPedido)
                                                     }).FirstOrDefault();


                        var ConsultaNotifica = (from PI in hb.Productos_Insumos
                                                where PI.Codigo == item.Insumo_ID
                                                select PI).FirstOrDefault();

                        if (ConsultaExistenciaIns != null)
                        {

                            if (ConsultaExistenciaIns.Existencia <= ConsultaPuntoPedido.PuntoPedido && ConsultaNotifica.NotificaPuntoPedido == "SI") //AGREGA LA NOTIFICACION en caso de que se cumpla la condicion
                            {
                                var i = new Notificaciones();

                                i.Descripcion = "El insumo " + ConsultaExistenciaIns.Insumo + " - " + ConsultaExistenciaIns.Insumo_ID + " alcanzó su punto de pedido";
                                i.Leida = "NO";
                                i.Tipo_ID = 1;
                                i.Fecha = DateTime.Now.Date;
                                i.Hora = DateTime.Now.TimeOfDay;

                                hb.Notificaciones.Add(i);
                                MessageBox.Show("El insumo " + ConsultaExistenciaIns.Insumo + " alcanzó su punto de pedido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                AbrirAlerta = true;
                            }
                        }
                        if (ConsultaStockMinActual.StockReal <= ConsultaStockMin.StockMin)
                        {
                            var i = new Notificaciones();

                            i.Descripcion = "El producto " + ConsultaStockMin.Descripcion + " - " + ConsultaStockMin.Codigo + " alcanzó su stock mínimo";
                            i.Leida = "NO";
                            i.Tipo_ID = 1;
                            i.Fecha = DateTime.Now.Date;
                            i.Hora = DateTime.Now.TimeOfDay;

                            hb.Notificaciones.Add(i);
                            MessageBox.Show("El producto " + ConsultaStockMin.Descripcion + " - " + ConsultaStockMin.Codigo + " alcanzó su stock mínimo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            AbrirAlerta = true;
                        }
                    }
                    if (AbrirAlerta == true) // si hay notificaciones Abre la alerta
                    {
                        var f = new frmAlertas();
                        f.ShowDialog();
                    }
                }

                hb.SaveChanges();
                this.Hide();
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvAgregar.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Seguro que desea eliminar el item seleccionado?", "Atención", MessageBoxButtons.YesNoCancel);

                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        var Consulta = (from SEC in hb.Seccion
                                        where SEC.ID == SeccionID
                                        select SEC).FirstOrDefault(); // Consulta para saber si es la sección final

                        // SI NO ES LA SECCION FINAL
                        if (Consulta.Seccion_Final == null)
                        {
                            dgvAgregar.Rows.Remove(dgvAgregar.CurrentRow);
                        }
                        // SI ES SECCION FINAL
                        else
                        {
                            long ID;
                            
                            if (dgvAgregar.CurrentRow.Cells[columnName: "colOrdenProdParteCuerpoID"].Value != null && dgvAgregar.CurrentRow.Cells[columnName: "colOrdenProdParteCuerpoID"].Value.ToString() != "") // si es null quiere decir que es provisorio que se cargo ahora y no esta aun en la base
                            {
                                ID = (long)dgvAgregar.CurrentRow.Cells[columnName: "colOrdenProdParteCuerpoID"].Value; // si tiene esta cargado ya en la base 

                                var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado 
                                                   where EPT.OrdenProduccionParteCuerpo_ID == ID
                                                   select EPT).FirstOrDefault();

                                if (ConsultaEPT.Cantidad_Utiliz > 0) // Procede a verificar si tiene productos afectados a ordenes de cargas. Si tiene afectaciones
                                {
                                    MessageBox.Show("El item seleccionado no se puede eliminar porque está afectado por una o mas ordenes de carga", "Atención");
                                    return; // Avisa y retorna
                                }
                                else
                                { // Si no tiene afectaciones elimina el registro de la tabla provisoria
                                   
                                    //  AQUI SE ALMACENAN LOS ID A ELIMINAR
                                    ListaOrdenProdParteCuerpo_ID_Eliminar.Add(ID);
                                    dgvAgregar.Rows.Remove(dgvAgregar.CurrentRow);
                                    EliminarEPT = "SI";
                                }
                            }
                            else
                            {
                                dgvAgregar.Rows.Remove(dgvAgregar.CurrentRow); // Si es provisorio lo borra directamente
                            }        
                        }
                    }
                }
                CalcularCantidadPendProducidas();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtMinuto_TextChanged(object sender, EventArgs e)
        {
            Reutilizables.CorregirMinutos(txtHora, txtMinuto);
        }

      

        private void cmbFiltraResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboEmpleados(cmbFiltraResponsable, txtFiltraBuscaResponsable, false);
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarSubProducto.Visible = false;
                clsCargarCombos.MostrarComboInsumoSegunProductoSeleccionado2(cmbFiltraSubProducto,ProductoID,txtBuscarSubProducto, true);
                txtBuscarSubProducto.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarSubProducto.Visible = false;
                txtBuscarSubProducto.Focus();
                e.Handled = true;
            }
        }

        private void cmbFiltraProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsumoSegunProductoSeleccionado2(cmbFiltraSubProducto, ProductoID, txtBuscarSubProducto, false);
                txtBuscarSubProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            txtBuscarSubProducto.Visible = true;
            txtBuscarSubProducto.Select();
        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroInsumoSegunProductoSeleccionado2(chkFiltraSubProducto, cmbFiltraSubProducto, ProductoID ,txtBuscarSubProducto, btnBuscarProducto);
        }

        private void txtFiltraBuscaResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtFiltraBuscaResponsable.Visible = false;
                clsCargarCombos.MostrarComboCiudades(cmbFiltraResponsable, txtFiltraBuscaResponsable, true);
                txtFiltraBuscaResponsable.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtFiltraBuscaResponsable.Visible = false;
            }
        }

        private void chkFiltraResponsable_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboEmpleados(chkFiltraResponsable, txtFiltraBuscaResponsable, cmbFiltraResponsable, btnFiltraBuscaResponsable);
            ApagarbtnCargar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatosFiltrados();
            OnOffbtnCargar();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void chkFechaDesde_CheckedChanged(object sender, EventArgs e)
        {
            ApagarbtnCargar();
        }

        private void chkFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            ApagarbtnCargar();
        }

        private void btnMostraDeposito_Click(object sender, EventArgs e)
        {         
            using (var hb = new DBdatos())
            {
                var ConsultaDeposito = (from D in hb.PcnConfiguraciones
                                        select D).FirstOrDefault();

                if (ConsultaDeposito.TipoDeposito == "Base")
                {
                    var f = new frmDepositoBase();
                    //f.FormularioAgregar = this;
                    f.Accion = "Seleccionar";
                    f.Show();
                }
                else
                {
                    FormularioDeposito.Accion = "Seleccionar";
                    FormularioDeposito.FormularioAgregar2 = this;
                    FormularioDeposito.Formulario = FormularioDeposito;
                    FormularioDeposito.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmDeposito_FormClosed);
                    FormularioDeposito2.FormSeccion2 = FormularioDeposito2;
                    //f. += new System.Windows.Forms.FormClosedEventHandler(frmDeposito_FormClosed);
                    FormularioDeposito.InicializarForm();
                    FormularioDeposito.Show();
                }
            }
        }
        private void frmDeposito_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from TTDS in hb.TT_DepositoSeleccionado
                                select TTDS).FirstOrDefault();

                if (Consulta != null)
                {
                    string CadenaGeneral = Consulta.DepositoSeleccionado;

                    if (CadenaGeneral.Length == 8)
                    {
                        cmbRack.Text = CadenaGeneral.Remove(2);
                        cmbEspacio.Text = CadenaGeneral.Substring(2, 2);
                        cmbPiso.Text = CadenaGeneral.Substring(4, 2);
                        cmbLado.Text = CadenaGeneral.Substring(6, 2);
                    }
                }
            }
        }
         
        private void btnEditarCantidad_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }
        private void FormatearDGV(DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvAgregar.Columns[e.ColumnIndex].Name == "colCantidad")
            {
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.SelectionForeColor = Color.Black;
                e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
            }
        }
        private void dgvAgregar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearDGV(e);
        }

        private void dgvAgregar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dtpLote_ValueChanged(object sender, EventArgs e)
        {
            Reutilizables.FormatearLote(dtpLote, txtLote);
        }

        private void txtIngresoHoras_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtIngresoMinutos_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarResponsable_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtHumedad_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtAcidez_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtHora_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtMinuto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraBuscaResponsable_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
