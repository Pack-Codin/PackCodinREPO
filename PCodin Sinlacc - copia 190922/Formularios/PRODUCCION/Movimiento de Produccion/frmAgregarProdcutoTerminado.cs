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
using PCodin_Sinlacc.Formularios.Notificación;
using PCodin_Sinlacc.Formularios.Deposito;
using PCodin_Sinlacc.Clases.Notificaciones_Ejecutables.Produccion;
using PCodin_Sinlacc.Clases.UsuarioTema;
using System.Windows.Forms.DataVisualization.Charting;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmAgregarProdcutoTerminado : Form
    {
        public string CrearEditar;
        public long IdRecibido;
        private long ProduccionID;
        string AsociarOrdenProduccion = "NO";
        long OrdenProduccion_ID;
        public long IDSalida; // Hecha para los Egresos
        public frmDeposito FormularioDeposito;
        public frmDeposito2 FormularioDeposito2;
        public frmAgregarProdcutoTerminado FormularioAgregar;
        public int UsuarioID;
        public frmMenu FormularioMenu; // Solo para traer el label de la cantidad de notificaciones
        public Panel PanelCentral;
         
        public frmAgregarProdcutoTerminado()
        {
            InitializeComponent();
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

        private void cmbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProConMedida(cmbProducto, cmbMedida, txtBuscarProducto, "PRO", false);              
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
        }

        private void frmAgregarProdcutoTerminado_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void MostrarDatosSegunMovimiento()
        {
            if (cmbMovimiento.SelectedValue != null)
            {
                if (cmbMovimiento.SelectedValue.ToString() == "CINS")
                {
                    clsCargarCombos.MostrarComboInsProConMedida(cmbProducto, cmbMedida, txtBuscarProducto, "INS", false);
                }
                else
                {
                    clsCargarCombos.MostrarComboInsProConMedida(cmbProducto, cmbMedida, txtBuscarProducto, "PRO", true);
                }
            }
            //{
            //    if (cmbMovimiento.SelectedValue.ToString() == "IPT")
            //        pnlDatosAdicionales.Visible = false;
            //    if (cmbMovimiento.SelectedValue.ToString() == "EPT")
            //        pnlDatosAdicionales.Visible = true;
            //}
        }
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(UsuarioID,pnlMenu,pnlMenu,this);

            clsCargarCombos.MostrarComboInsProConMedida(cmbProducto, cmbMedida, txtBuscarProducto, "PRO", false);
            clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
            clsCargarCombos.MostrarCombomMovProduccion(cmbMovimiento,"PRO");
            //clsCargarCombos.MostrarComboClientes(cmbTransportista,txtBuscaTransportista,false,"TRA", 0);
            //clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscaCiudad, false);
            cmbMovimiento.Select();
            cmbProducto.SelectedIndex = -1;
            cmbResponsable.SelectedIndex = -1;
            cmbMovimiento.SelectedIndex = -1;
            //cmbTransportista.SelectedIndex = -1;
            //cmbCiudad.SelectedIndex = -1;

            MostrarDatosSegunMovimiento();

            //CREAR
            if (CrearEditar == "1")
            {
                try
                {
                    CalculaNúmeroDeProduccion();
                    txtCantidad.Text = "0,00";
                    btnInvalidar.Enabled = false;
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message);
                }
                            
            }

            // EDITAR
            if (CrearEditar == "2" || CrearEditar == "3")
            {
                try
                {
                    using (var hb = new DBdatos())
                    {
                        var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                           where EPT.ID == IdRecibido
                                           select EPT);

                        var ResultadosEPT = ConsultaEPT.FirstOrDefault();

                        if (ResultadosEPT != null)
                        {
                            // SI EL MOVIMIENTO FUE PRODUCIDO POR UNA ORDEN
                            if (ResultadosEPT.OrdenProduccionParteCuerpo_ID != null)
                            {
                                //IMPIDE VISUALIZAR LA AFECCION DE UNA OP
                                gbxAfectarOrdenProd.Visible = false;
                            }

                            if (CrearEditar == "3")
                            {
                                CalculaNúmeroDeProduccion();
                                btnInvalidar.Enabled = false;
                                btnCargar.Visible = true;
                                btnCargar.Text = "Cargar Productos";
                            }
                            else
                            {
                                cmbMovimiento.Enabled = false;
                                btnBuscarProducto.Enabled = false;
                                cmbProducto.Enabled = false;
                                txtCantidad.Enabled = false;
                                btnEstimarProduccion.Enabled = false;
                                txtNumeroProduccion.Text = ResultadosEPT.Numero_Produccion.ToString();
                                txtEstado.Text = ResultadosEPT.Estado_ExistenciaProductoTerminado.Descripcion;
                                btnInvalidar.Enabled = true;
                                btnCargar.Text = "Editar movimiento";

                                if (ResultadosEPT.Estado_ID == "PEN")
                                {
                                    cmbRack.Enabled = true;
                                    cmbEspacio.Enabled = true;
                                    cmbLado.Enabled = true;
                                    cmbPiso.Enabled = true;
                                }
                                else
                                {
                                    cmbRack.Enabled = false;
                                    cmbEspacio.Enabled = false;
                                    cmbLado.Enabled = false;
                                    cmbPiso.Enabled = false;
                                }
                            }

                            cmbMovimiento.SelectedValue = ResultadosEPT.Movimiento_ID;
                            cmbMovimiento.Text = ResultadosEPT.Movimientos_Produccion.Descripcion;
                            dtpFecha.Value = ResultadosEPT.Fecha;
                            cmbProducto.SelectedValue = ResultadosEPT.Produto_ID;
                            cmbProducto.Text = ResultadosEPT.Productos_Insumos.Descripcion;
                            txtCantidad.Text = ResultadosEPT.Cantidad.ToString();
                            txtHumedad.Text = ResultadosEPT.Humedad.ToString();
                            txtAcidez.Text = ResultadosEPT.Acidez.ToString();

                            if (ResultadosEPT.Lote != null && ResultadosEPT.Lote != "")
                            {
                                string Lote = ResultadosEPT.Lote;
                                Lote = Lote.Insert(2, "/");
                                Lote = Lote.Insert(5, "/");

                                dtpLote.Value = Convert.ToDateTime(Lote);
                                txtLote.Text = ResultadosEPT.Lote;
                            }
                            else
                            {
                                dtpLote.Text = "01/01/1990";
                                txtLote.Text = "";
                            }


                            if (ResultadosEPT.Movimiento_ID == "EPT")
                            {
                                cmbMovimiento.Text = "Egreso producto terminado";

                                if (ResultadosEPT.Cliente_ID != null)
                                {
                                    //cmbTransportista.SelectedValue = ResultadosEPT.Cliente_ID;
                                    //cmbTransportista.Text = ResultadosEPT.Clientes.Descripcion;
                                }
                                if (ResultadosEPT.Ciudad_ID != null)
                                {
                                    //cmbCiudad.SelectedValue = ResultadosEPT.Ciudad_ID;
                                    //cmbCiudad.Text = ResultadosEPT.Ciudades.Descripcion;
                                }
                                if (ResultadosEPT.Ingreso_ID != null)
                                {
                                    var Consulta = (from ING in hb.Existencia_ProductoTerminado
                                                    where ING.ID == ResultadosEPT.Ingreso_ID
                                                    select ING).FirstOrDefault();

                                    txtIngreso.Text = Consulta.Numero_Produccion;
                                }
                            }

                            if (ResultadosEPT.Deposito != null && ResultadosEPT.Deposito != "")
                            {
                                if (ResultadosEPT.Deposito.Length == 8)
                                {
                                    cmbRack.Text = ResultadosEPT.Deposito.Remove(2).ToString();
                                    cmbEspacio.Text = ResultadosEPT.Deposito.Substring(2, 2);
                                    cmbPiso.Text = ResultadosEPT.Deposito.Substring(4, 2);
                                    cmbLado.Text = ResultadosEPT.Deposito.Substring(6, 2);
                                }
                                if (ResultadosEPT.Deposito.Length == 9)
                                {
                                    cmbRack.Text = ResultadosEPT.Deposito.Remove(2);
                                    cmbEspacio.Text = ResultadosEPT.Deposito.Substring(2, 3);
                                    cmbPiso.Text = ResultadosEPT.Deposito.Substring(5, 2);
                                    cmbLado.Text = ResultadosEPT.Deposito.Substring(7, 2);
                                }
                            }
                            else
                            {
                                cmbRack.Text = "";
                                cmbEspacio.Text = "";
                                cmbPiso.Text = "";
                                cmbLado.Text = "";
                            }

                            if (ResultadosEPT.Retencion == "SI")
                                rdbRetencionSi.Checked = true;
                            else
                                rdbRetencionNo.Checked = true;

                            if (ResultadosEPT.Ficha == "SI")
                                rdbFichaSi.Checked = true;
                            else
                                rdbFichaNo.Checked = true;

                            if (ResultadosEPT.Empleado_ID != null)
                            {
                                cmbResponsable.SelectedValue = ResultadosEPT.Empleado_ID;
                                cmbResponsable.Text = ResultadosEPT.Empleados.Nombre;
                            }
                            else
                                cmbResponsable.SelectedIndex = -1;

                            txtObservaciones.Text = ResultadosEPT.Observaciones;
                            OnOffbtnCargar();

                            if (ResultadosEPT.Estado_ID != "AN")
                                btnInvalidar.Visible = true;
                            else
                                btnInvalidar.Visible = false;

                            if (ResultadosEPT.Estado_ID == "ENT")
                                txtEstado.ForeColor = Color.Green;
                            if (ResultadosEPT.Estado_ID == "PEN")
                                txtEstado.ForeColor = Color.DarkRed;
                            if (ResultadosEPT.Estado_ID == "PEN")
                                txtEstado.ForeColor = Color.Red;

                            //DATOS ADICIONALES

                            if (ResultadosEPT.OrdenCargaID != null)
                            {
                                txtNumOrdenCarga.Text = "OC" + ResultadosEPT.OrdenCargaID.ToString();

                                if (ResultadosEPT.OrdenCargaCuerpo_ID != null)
                                {
                                    var ConsultaCliente = (from OCC in hb.OrdenCarga_Cuerpo
                                                           where OCC.ID == ResultadosEPT.OrdenCargaCuerpo_ID
                                                           select OCC).FirstOrDefault();

                                    if (ConsultaCliente != null)
                                        txtCliente.Text = ConsultaCliente.Clientes.Descripcion;
                                }
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                  
                }
            }
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
        private void CargarProducto()
        {
            try
            {
                string Error = "";
                using (var hb = new DBdatos())
                {
                    // VALIDACION PARA VER QUE LOS INSUMOS DISPONIBLES ALCANCEN PARA PRODUCIR
                    var ConsultaCantInsAsociados = (from FP in hb.Formula_Producto
                                                    where FP.Producto_ID == cmbProducto.SelectedValue.ToString()
                                                        && FP.Productos_Insumos.Subproducto != "SI"
                                                    select FP);

                    var ConsultaConfig = (from CONF in hb.PcnConfiguraciones
                                          where CONF.Modulo_ID == 1
                                          select CONF).FirstOrDefault();


                    var ResultadosCantInsAsociados = ConsultaCantInsAsociados.ToList();

                    if (cmbMovimiento.SelectedValue.ToString() == "IPT" && txtLote.Text == "")
                    {
                        if (ConsultaConfig.TrabajaConStockNegativo == "NO")
                        {
                            foreach (var item in ResultadosCantInsAsociados)
                            {
                                var ConsultaExistenciIns = (from EI in hb.Existencia_Insumos
                                                            where EI.Insumo_ID == item.Insumo_ID
                                                            group EI by new { EI.Insumo_ID } into Grupo
                                                            select new
                                                            {
                                                                Grupo.Key.Insumo_ID,
                                                                CantidadDisponible = Grupo.Sum(x => x.Cantidad) - Grupo.Sum(x => x.Cantidad_Utilizada)
                                                            });

                                var ResultadosExistenciIns = ConsultaExistenciIns.FirstOrDefault();

                                if (ResultadosExistenciIns != null)
                                {
                                    decimal CantidadRequerida = item.Cantidad * Convert.ToDecimal(txtCantidad.Text); // CANTIDAD DE LA ORDEN DE PRODUCCION X LA CANTIDAD DE LA FORMULA
                                    decimal CantidadDisponible = ResultadosExistenciIns.CantidadDisponible;

                                    if (CantidadDisponible < CantidadRequerida) // CORROBORAR LAS CANTIDADES DE INSUMOS
                                    {
                                        string Mensaje = "La cantidad del insumo " + item.Productos_Insumos.Descripcion + " - " + item.Productos_Insumos.Codigo + " no abastece la cantidad requerida"
                                            + "\r\n"
                                            + "\r\n"
                                            + "Cantidad Requerida  = " + CantidadRequerida.ToString("N2") + "  " + item.Productos_Insumos.Medidas_Producto.Descripcion
                                            + "\r\n"
                                            + "Cantidad Disponible = " + CantidadDisponible.ToString("N2") + "  " + item.Productos_Insumos.Medidas_Producto.Descripcion
                                            + "\r\n"
                                            + "                                 ____________________"
                                            + "\r\n"
                                            + "Faltantes                        " + (CantidadRequerida - CantidadDisponible).ToString("N2") + "  " + item.Productos_Insumos.Medidas_Producto.Descripcion;

                                        MessageBox.Show(Mensaje, "Atención");
                                        return;
                                    }
                                    else
                                    {
                                        decimal CantidadAcumulada = 0;
                                        decimal CantidadParcial = CantidadRequerida; // Esta es la cantidad requerida , la diferencia que se le va restando las cantidades
                                        List<long?> ListaID = new List<long?>();

                                        while (CantidadRequerida != CantidadAcumulada)
                                        {
                                            decimal CantidadDisponiblePorRegistro = 0;

                                            var ConsultaExistenciaIns2 = (from EI in hb.Existencia_Insumos
                                                                          where EI.Insumo_ID == item.Insumo_ID
                                                                            && EI.Cantidad != EI.Cantidad_Utilizada
                                                                            && !ListaID.Contains(EI.ID)
                                                                          select EI);

                                            var ResultadoConsultaExistenciaIns2 = ConsultaExistenciaIns2.FirstOrDefault();


                                            CantidadDisponiblePorRegistro = ResultadoConsultaExistenciaIns2.Cantidad - ResultadoConsultaExistenciaIns2.Cantidad_Utilizada;

                                            if (CantidadDisponiblePorRegistro >= CantidadParcial)
                                            {
                                                ResultadoConsultaExistenciaIns2.Cantidad_Utilizada = ResultadoConsultaExistenciaIns2.Cantidad_Utilizada + CantidadParcial;
                                                CantidadAcumulada = CantidadAcumulada + CantidadParcial;

                                                if (ResultadoConsultaExistenciaIns2.Cantidad == ResultadoConsultaExistenciaIns2.Cantidad_Utilizada)
                                                    ResultadoConsultaExistenciaIns2.Estado_ID = "COM";
                                                if (ResultadoConsultaExistenciaIns2.Cantidad > ResultadoConsultaExistenciaIns2.Cantidad_Utilizada)
                                                    ResultadoConsultaExistenciaIns2.Estado_ID = "PEN";
                                            }
                                            else
                                            {
                                                ResultadoConsultaExistenciaIns2.Cantidad_Utilizada = ResultadoConsultaExistenciaIns2.Cantidad; // usa todo
                                                CantidadAcumulada = CantidadAcumulada + CantidadDisponiblePorRegistro;
                                                ResultadoConsultaExistenciaIns2.Estado_ID = "COM";

                                                CantidadParcial = CantidadRequerida - CantidadDisponiblePorRegistro;
                                                ListaID.Add(ResultadoConsultaExistenciaIns2.ID);
                                            }
                                            // AQUI CARGA LOS DATOS EN LA TABLA EXISTENCIAINSUMOS_EXISTENCIA PRODUCTOS PARA HACER TRAZABILIDAD
                                            var I = new ExistenciaProducto_ExistenciaInsumo();

                                            I.ExistenciaInsumo_ID = ResultadoConsultaExistenciaIns2.ID;
                                            I.ExitenciaProducto_ID = ProduccionID;
                                            I.OrdenProduccion_ID = null; // NULL PORQUE SE CARGA MANUALMENTE Y NO POR ORDEN DE PRODUCCIÓN
                                            I.Cantidad = CantidadRequerida;

                                            hb.ExistenciaProducto_ExistenciaInsumo.Add(I);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No hay ningun registro del insumo " + item.Productos_Insumos.Descripcion + " en el sistema. Para poder cargar un producto final deberá primero cargar este insumo", "Atención");
                                    return;
                                }
                            }
                        }
                    }
                    ///////////////////////////// HASTA ACA VALIDACION //////////////////////////////////////////////

                    var Consulta = (from EPT in hb.Existencia_ProductoTerminado
                                    where EPT.Produto_ID == cmbProducto.SelectedValue.ToString()
                                    select EPT);

                    var Resultados = Consulta.FirstOrDefault();

                    var z = new Existencia_ProductoTerminado();

                    z.ID = ProduccionID;
                    z.Numero_Produccion = txtNumeroProduccion.Text;
                    z.Fecha = dtpFecha.Value.Date;
                    z.Produto_ID = cmbProducto.SelectedValue.ToString();

                    if (rdbRetencionSi.Checked)
                        z.Retencion = "SI";
                    else
                        z.Retencion = "NO";

                    if (rdbFichaSi.Checked)
                        z.Ficha = "SI";
                    else
                        z.Ficha = "NO";

                    z.Movimiento_ID = cmbMovimiento.SelectedValue.ToString();
                    z.Medida_ID = (int)cmbMedida.SelectedValue;
                    z.Empleado_ID = (int)cmbResponsable.SelectedValue;
                    z.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                    z.Cantidad_Utiliz = 0;
                    z.Lote = txtLote.Text;
                    z.Humedad = Convert.ToDecimal(txtHumedad.Text);
                    z.Acidez = Convert.ToDecimal(txtAcidez.Text);

                    if (cmbMovimiento.SelectedValue.ToString() == "EPT")
                    {
                        //if (cmbTransportista.SelectedIndex != -1)
                        //    z.Cliente_ID = (int)cmbTransportista.SelectedValue;
                        //else
                        //    z.Cliente_ID = null;

                        //if (cmbCiudad.SelectedIndex != -1)
                        //    z.Ciudad_ID = (int)cmbCiudad.SelectedValue;
                        //else
                        //    z.Ciudad_ID = null;
                    }
                    else
                    {
                        z.Cliente_ID = null;
                        z.Ciudad_ID = null;
                    }

                    z.Estado_ID = "PEN";

                    if (AsociarOrdenProduccion == "SI")
                        z.OrdenProduccion_ID = OrdenProduccion_ID;

                    z.Observaciones = txtObservaciones.Text;
                    //z.Deposito = cmbRack.Text + cmbEspacio.Text + cmbPiso.Text + cmbLado.Text;
                    //z.Turno = cmbTurno.Text;
                    // AQUI SE AGREGAN LOS DATOS DEL DEPOSITO
                    //var d = new Deposito();

                    //d.Deposito1 = cmbCalle.Text + cmbNumeroCalle.Text;
                    //d.MovProduccion_ID = ProduccionID;

                    if (cmbRack.Text != "")
                    {
                        var ConsultaDeposito = (from EPT in hb.Existencia_ProductoTerminado
                                                where EPT.Deposito == cmbRack.Text + cmbEspacio.Text
                                                    && EPT.Estado_ID == "PEN"
                                                select EPT).FirstOrDefault();

                        if (ConsultaDeposito != null)
                        {
                            DialogResult R = MessageBox.Show("Esta ubicación ya contiene producciones. ¿Desea ensimar la mismas?", "Atención", MessageBoxButtons.YesNo);
                            if (R == DialogResult.Yes)
                            {
                                if (ConsultaDeposito.Produto_ID == cmbProducto.SelectedValue.ToString())
                                {
                                    z.Deposito = cmbRack.Text + cmbEspacio.Text + cmbPiso.Text + cmbLado.Text;
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
                            z.Deposito = cmbRack.Text + cmbEspacio.Text + cmbPiso.Text + cmbLado.Text;
                        }
                    }
                    else
                    {
                        DialogResult R = MessageBox.Show("No seleccionó depósito. ¿Desea continuar?", "Atención", MessageBoxButtons.YesNoCancel);

                        if (R == DialogResult.Yes)
                        {
                            z.Deposito = "";
                        }
                        else
                        {
                            return;
                        }
                    }


                    //if (cmbMovimiento.SelectedValue.ToString() == "IPT")
                    //{
                    //    if (Convert.ToDecimal(txtCantidad.Text) > 0)
                    //    {
                    //        z.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                    //        z.Cantidad_Utiliz = 0;
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("La cantidad para este movimiento debe ser un número mayor a 0");
                    //        return;
                    //    }
                    //}
                    //if (cmbMovimiento.SelectedValue.ToString() == "AJUPO")
                    //{
                    //    if (Convert.ToDecimal(txtCantidad.Text) > 0)
                    //    {
                    //        z.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                    //        z.Cantidad_Utiliz = 0;
                    //    }

                    //}
                    //if (cmbMovimiento.SelectedValue.ToString() == "AJUNE")
                    //{
                    //    if (Convert.ToDecimal(txtCantidad.Text) > 0)
                    //    {
                    //        z.Cantidad = Convert.ToDecimal(txtCantidad.Text) * -1;
                    //        z.Cantidad_Utiliz = 0;
                    //    }
                    //}

                    hb.Existencia_ProductoTerminado.Add(z);

                    if (cmbMovimiento.SelectedIndex != -1)
                    {
                        if (txtLote.Text == "")
                            Error = "No selecciono Lote";
                        if (txtCantidad.Text == "0,00")
                            Error = "No ingreso cantidad";
                        //if (txtAcidez.Text == "0,00")
                        //    Error = "No ingreso acidez";
                        //if (txtHumedad.Text == "0,00")
                        //    Error = "No ingreso humedad";



                    }
                    else
                        Error = "No selecciono movimiento";

                    if (Error == "")
                    {
                        hb.SaveChanges();
                        MessageBox.Show("Datos guardados correctamente", "Atención");
                        this.Close();
                    }                        
                    else
                    {
                        MessageBox.Show(Error, "Error");
                    }
                    

                    if (cmbMovimiento.SelectedValue.ToString() == "IPT") // LOS AJUSTES NO AFECTAN A LOS INSUMOS YA QUE SON CANTIDADES AJUSTADAS
                    {
                        //// AQUI RECALCULA EL PUNTO DE PEDIDO 
                        //bool AbrirAlerta = false;

                        //var ConsultaFormulaProducto = (from FP in hb.Formula_Producto
                        //                               where FP.Producto_ID == cmbProducto.SelectedValue.ToString()
                        //                                    && FP.Productos_Insumos.Subproducto == "NO"
                        //                               select FP).ToList();

                        //// ESTAS 2 CONSULTAS SE HACEN PARA COMPARAR LOS STOCKS MINIMOS Y VER SI HAY QUE NOTIFICAR
                        //var ConsultaStockMin = (from EPT in hb.Productos_Insumos
                        //                         where EPT.Codigo == cmbProducto.SelectedValue.ToString()
                        //                         select EPT).FirstOrDefault();

                        //var ConsultaStockMinActual = (from VS in hb.Vista_Stock
                        //                              where VS.Codigo == cmbProducto.SelectedValue.ToString()
                        //                              select VS).FirstOrDefault();

                        //if (ConsultaStockMinActual.StockReal <= ConsultaStockMin.StockMin)
                        //{
                        //    var i = new Notificaciones();

                        //    i.Descripcion = "El producto " + ConsultaStockMin.Descripcion + " - " + ConsultaStockMin.Codigo + " alcanzó su stock mínimo";
                        //    i.Leida = "NO";
                        //    i.Tipo_ID = 1;
                        //    i.Fecha = DateTime.Now.Date;
                        //    i.Hora = DateTime.Now.TimeOfDay;

                        //    hb.Notificaciones.Add(i);
                        //    MessageBox.Show("El producto " + ConsultaStockMin.Descripcion + " - " + ConsultaStockMin.Codigo + " alcanzó su stock mínimo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        //    AbrirAlerta = true;
                        //}

                        //if (ConsultaFormulaProducto.Count > 0)
                        //{
                        //    foreach (var item in ConsultaFormulaProducto)
                        //    {
                        //        var ConsultaPuntoPedido = (from VPP in hb.Vista_CalcularPuntoPedido
                        //                                   where VPP.Codigo == item.Insumo_ID
                        //                                   select VPP).FirstOrDefault();

                        //        var ConsultaExistenciaIns = (from E in hb.Existencia_Insumos
                        //                                     join VPP in hb.Vista_CalcularPuntoPedido on E.Insumo_ID equals VPP.Codigo
                        //                                     where VPP.Codigo == item.Insumo_ID
                        //                                     group new { E, VPP } by new
                        //                                     {
                        //                                         E.Insumo_ID,
                        //                                         Insumo = E.Productos_Insumos.Descripcion,
                        //                                         E.Medida_ID,
                        //                                         Medida = E.Medidas_Producto.Descripcion,
                        //                                         Categoria = E.Productos_Insumos.Categoria_ID,
                        //                                         VPP.PuntoPedido
                        //                                     } into Group
                        //                                     orderby Group.Key.Insumo
                        //                                     select new
                        //                                     {
                        //                                         Group.Key.Insumo_ID,
                        //                                         Group.Key.Insumo,
                        //                                         Existencia = Group.Sum(x => x.E.Cantidad) - Group.Sum(x => x.E.Cantidad_Utilizada),
                        //                                         Group.Key.Medida_ID,
                        //                                         Group.Key.Medida,
                        //                                         Stockmin = Group.Sum(x => x.E.Productos_Insumos.StockMin),
                        //                                         Group.Key.Categoria,
                        //                                         Group.Key.PuntoPedido
                        //                                         //PuntoPedido = Group.Sum(x => x.VPP.PuntoPedido)
                        //                                     }).FirstOrDefault();


                        //        var ConsultaNotifica = (from PI in hb.Productos_Insumos
                        //                                where PI.Codigo == item.Insumo_ID
                        //                                select PI).FirstOrDefault();

                        //        if (ConsultaExistenciaIns != null)
                        //        {

                        //            if (ConsultaExistenciaIns.Existencia <= ConsultaPuntoPedido.PuntoPedido && ConsultaNotifica.NotificaPuntoPedido == "SI") //AGREGA LA NOTIFICACION en caso de que se cumpla la condicion
                        //            {
                        //                var i = new Notificaciones();

                        //                i.Descripcion = "El insumo " + ConsultaExistenciaIns.Insumo + " - " + ConsultaExistenciaIns.Insumo_ID + " alcanzó su punto de pedido";
                        //                i.Leida = "NO";
                        //                i.Tipo_ID = 1;
                        //                i.Fecha = DateTime.Now.Date;
                        //                i.Hora = DateTime.Now.TimeOfDay;

                        //                hb.Notificaciones.Add(i);
                        //                MessageBox.Show("El insumo " + ConsultaExistenciaIns.Insumo + " alcanzó su punto de pedido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        //                AbrirAlerta = true;
                        //            }
                        //        }                   
                        //    }
                        //    if (AbrirAlerta == true) // si hay notificaciones Abre la alerta
                        //    {
                        //        var f = new frmAlertas();
                        //        f.ShowDialog();
                        //    }
                        //}
                    }
                   //// hb.SaveChanges();
                   // this.Hide();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }
        private void EditarProducto()
        {
            using (var hb = new DBdatos())
            {
                //decimal NuevaCantidad = Convert.ToDecimal(txtCantidad.Text);
                //decimal CantidadUtilizada = 0;

                var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                   where EPT.ID == IdRecibido
                                   select EPT);

                var ResultadosEPT = ConsultaEPT.FirstOrDefault();

                ResultadosEPT.Fecha = dtpFecha.Value.Date;
                // ResultadosEPT.Produto_ID = (string)cmbProducto.SelectedValue;

                if (rdbRetencionSi.Checked)
                    ResultadosEPT.Retencion = "SI";
                else
                    ResultadosEPT.Retencion = "NO";

                if (rdbFichaSi.Checked)
                    ResultadosEPT.Ficha = "SI";
                else
                    ResultadosEPT.Ficha = "NO";

                if (AsociarOrdenProduccion == "SI")
                    ResultadosEPT.OrdenProduccion_ID = OrdenProduccion_ID;
                else
                    ResultadosEPT.OrdenProduccion_ID = null;

                ResultadosEPT.Deposito = cmbRack.Text + cmbEspacio.Text + cmbPiso.Text + cmbLado.Text;

                ResultadosEPT.Empleado_ID = (int)cmbResponsable.SelectedValue;
                //ResultadosEPT.Turno = cmbTurno.Text;
                ResultadosEPT.Observaciones = txtObservaciones.Text;
                ResultadosEPT.Lote = txtLote.Text;

                //if (cmbTransportista.SelectedIndex != -1)
                //    ResultadosEPT.Cliente_ID = (int)cmbTransportista.SelectedValue;

                //else
                //    ResultadosEPT.Cliente_ID = null;

                //if (cmbCiudad.SelectedIndex != -1)
                //    ResultadosEPT.Ciudad_ID = (int)cmbCiudad.SelectedValue;

                //else
                //    ResultadosEPT.Ciudad_ID = null;

                // VALIDA DEPOSITO

                string DepositoOriginal = ResultadosEPT.Deposito;
                string NuevoDeposito = cmbRack.Text + cmbEspacio.Text + cmbPiso.Text + cmbLado.Text;

                if (NuevoDeposito != DepositoOriginal)
                {
                    var ConsultaDeposito = (from EPT in hb.Existencia_ProductoTerminado
                                            where EPT.Deposito == cmbRack.Text + cmbEspacio.Text + cmbPiso.Text + cmbLado.Text
                                                && EPT.Estado_ID == "PEN"
                                            select EPT);

                    var ResultadosDeposito = ConsultaDeposito.FirstOrDefault();

                    if (ResultadosDeposito != null)
                    {
                        DialogResult R = MessageBox.Show("Esta ubicación ya contiene producciones. ¿Desea ensimar la mismas?", "Atención", MessageBoxButtons.YesNo);
                        if (R == DialogResult.Yes)
                        {
                            if (ResultadosDeposito.Produto_ID == cmbProducto.SelectedValue.ToString())
                            {
                                ResultadosEPT.Deposito = cmbRack.Text + cmbEspacio.Text + cmbPiso.Text + cmbLado.Text;
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
                        ResultadosEPT.Deposito = cmbRack.Text + cmbEspacio.Text + cmbPiso.Text + cmbLado.Text;
                    }
                }
                hb.SaveChanges();
                MessageBox.Show("Datos modificados correctamente", "Atención");
                this.Hide();

                //CantidadUtilizada = (decimal)ResultadosEPT.Cantidad_Utiliz;

                //if(NuevaCantidad <= CantidadUtilizada)
                //{
                //    ResultadosEPT.Cantidad = NuevaCantidad;

                //    if (NuevaCantidad == CantidadUtilizada)
                //        ResultadosEPT.Estado_ID = "ENT";
                //}
                //// RECALCULAR EXISTENCIA DE INSUMOS

                //var ConsultaExistenciaProductosInsumos = (from EPI in hb.ExistenciaProducto_ExistenciaInsumo
                //                                          where EPI.ExitenciaProducto_ID == IdRecibido
                //                                          select EPI).ToList();

                //foreach (var item in ConsultaExistenciaProductosInsumos)
                //{
                //    item.Cantidad = item.
                //}

            }
            

            //    var ConsultaExistenciaProductosInsumos = (from EPI in hb.ExistenciaProducto_ExistenciaInsumo
            //                                              where EPI.ExitenciaProducto_ID == IdRecibido
            //                                              select EPI).ToList();

            //    foreach (var item in ConsultaExistenciaProductosInsumos)
            //    {
            //        item.Cantidad = item.
            //    }

            //    NuevoStockReal = ((decimal)(ResultadoStock.Existencia - Convert.ToDecimal(txtCantidad.Text) + ResultadoStock.Pendiente));

            //    if (ResultadosEPT.Movimiento_ID == "AJUNE")
            //    {
            //        ConsultaStock = (from C in ConsultaStock
            //                         where C.Codigo == ResultadosEPT.Produto_ID
            //                         select C);

            //        ResultadoStock = ConsultaStock.FirstOrDefault();



            //        if (ResultadoStock.StockReal + (ResultadosEPT.Cantidad * -1) - Convert.ToDecimal(txtCantidad.Text) < 0) // NUEVO STOCK
            //        {
            //            DialogResult R = MessageBox.Show("Si aplica está modificación quedará el stock real en negativo.¿Desea continuar?", "Atención", MessageBoxButtons.YesNo);
            //            if (R == DialogResult.Yes)
            //            {
            //                ResultadosEPT.Cantidad = -Convert.ToDecimal(txtCantidad.Text); //Modifica la cantidad en negativo  
            //                hb.SaveChanges();
            //                MessageBox.Show("Producto modificado correctamente", "Atención");
            //                this.Hide();
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            ResultadosEPT.Cantidad = -Convert.ToDecimal(txtCantidad.Text); //Modifica la cantidad en negativo  
            //            hb.SaveChanges();
            //            MessageBox.Show("Producto modificado correctamente", "Atención");
            //            this.Hide();
            //        }
            //    }

            //    hb.SaveChanges();
            //    MessageBox.Show("Producto modificado correctamente", "Atención");
            //    this.Hide();

            //    RECALCULA PUNTO DE PEDIDO
            //    var ConsultaFormulaProducto = (from FP in hb.Formula_Producto
            //                                   where FP.Producto_ID == cmbProducto.SelectedValue.ToString()
            //                                   select FP).ToList();

            //    if (ConsultaFormulaProducto.Count > 0)
            //    {
            //        foreach (var item in ConsultaFormulaProducto)
            //        {
            //            var ConsultaPuntoPedido = (from VPP in hb.Vista_CalcularPuntoPedido
            //                                       where VPP.Codigo == item.Insumo_ID
            //                                       select VPP).FirstOrDefault();

            //            var ConsultaExistenciaIns = (from E in hb.Existencia_Insumos
            //                                         where E.Insumo_ID == item.Insumo_ID
            //                                         group E by new
            //                                         {
            //                                             E.Insumo_ID,
            //                                             Insumo = E.Productos_Insumos.Descripcion,
            //                                             E.Medida_ID,
            //                                             Medida = E.Medidas_Producto.Descripcion,
            //                                             Categoria = E.Productos_Insumos.Categoria_ID,
            //                                         } into Group
            //                                         orderby Group.Key.Insumo
            //                                         select new
            //                                         {
            //                                             Group.Key.Insumo_ID,
            //                                             Group.Key.Insumo,
            //                                             Existencia = Group.Sum(x => x.Cantidad) - Group.Sum(x => x.Cantidad_Utilizada),
            //                                             Group.Key.Medida_ID,
            //                                             Group.Key.Medida,
            //                                             Stockmin = Group.Sum(x => x.Productos_Insumos.StockMin),
            //                                             Group.Key.Categoria,
            //                                             PuntoPedido = Group.Sum(x => x.Productos_Insumos.Punto_Pedido)
            //                                         }).FirstOrDefault();

            //            if (ConsultaExistenciaIns != null)
            //            {
            //                if (ConsultaExistenciaIns.Existencia <= ConsultaPuntoPedido.PuntoPedido) //AGREGA LA NOTIFICACION
            //                {
            //                    var i = new Notificaciones();

            //                    i.Descripcion = "El insumo " + ConsultaExistenciaIns.Insumo + " alcanzó su punto de pedido";
            //                    i.Leida = "NO";
            //                    i.Tipo_ID = 1;
            //                    i.Fecha = DateTime.Now.Date;

            //                    hb.Notificaciones.Add(i);
            //                    MessageBox.Show("El insumo " + ConsultaExistenciaIns.Insumo + " alcanzó su punto de pedido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                }
            //            }
            //        }

            //    }
            //    hb.SaveChanges();
            //    this.Hide();
            //}
        }
        private void AnularMovimiento()
        {
            DialogResult R = MessageBox.Show("¿Está seguro de anular este movimiento", "Atención", MessageBoxButtons.YesNo);
            if(R == DialogResult.Yes)
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                       where EPT.ID == IdRecibido
                                       select EPT);
                   
                    var Consulta = (from POC in hb.Producto_Afec_OrdenCarga
                                    where POC.ExitenciaProTer_ID == IdRecibido
                                        && POC.Orden_Carga.Estado_ID != "AN"
                                    select POC);

                    var ResultadosEPT = ConsultaEPT.FirstOrDefault();
                    var Resultados = Consulta.FirstOrDefault();

                    if (Resultados == null)
                    {
                        var ConsultaOPPC = (from OPPC in hb.OrdenProduccionParteCuerpo
                                            where OPPC.ID == ResultadosEPT.OrdenProduccionParteCuerpo_ID
                                            select OPPC).FirstOrDefault();

                        if (ConsultaOPPC != null)
                        {
                            //VUELVE LA ORDEN A ESTADO "PRO"
                            ConsultaOPPC.Orden_Produccion_Parte.OrdenProduccion_Cuerpo.Orden_Produccion.Estado_ID = "PRO";

                            //ELIMINA EL OPPC
                            hb.OrdenProduccionParteCuerpo.Remove(ConsultaOPPC);

                            var ConsultaExistenciaInsumoProducto = (from EIEP in hb.ExistenciaProducto_ExistenciaInsumo
                                                                    where EIEP.ExitenciaProducto_ID == IdRecibido
                                                                    select EIEP).ToList();

                            foreach (var item in ConsultaExistenciaInsumoProducto)
                            {
                                var ConsultaExistenciaInsumo = (from EI in hb.Existencia_Insumos
                                                                where EI.ID == item.ExistenciaInsumo_ID
                                                                select EI).FirstOrDefault();

                                ConsultaExistenciaInsumo.Cantidad_Utilizada = ConsultaExistenciaInsumo.Cantidad_Utilizada - item.Cantidad;
                                ConsultaExistenciaInsumo.Estado_ID = "PEN";

                                hb.ExistenciaProducto_ExistenciaInsumo.RemoveRange(ConsultaExistenciaInsumoProducto);
                            }                            
                        }
                        else
                        {
                           if(ResultadosEPT.Movimiento_ID == "EPT") //EGRESO
                           {
                                var ConsultaIngreso = (from ING in hb.Existencia_ProductoTerminado
                                                      where ING.ID == ResultadosEPT.Ingreso_ID
                                                      select ING).FirstOrDefault();

                                ConsultaIngreso.Cantidad_Utiliz = ConsultaIngreso.Cantidad_Utiliz - ResultadosEPT.Cantidad;
                           }
                        }
                        ResultadosEPT.Estado_ID = "AN";
                        hb.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("El movimiento está afectado por 1 o más ordernes de carga", "Atención");
                        return;
                    }
                    //// AQUI RECALCULA EL PUNTO DE PEDIDO                
                    var ConsultaFormulaProducto = (from FP in hb.Formula_Producto
                                                   where FP.Producto_ID == ResultadosEPT.Produto_ID
                                                   select FP).ToList();

                    if (ConsultaFormulaProducto.Count > 0)
                    {
                        foreach (var item in ConsultaFormulaProducto)
                        {
                            var ConsultaPuntoPedido = (from VPP in hb.Vista_CalcularPuntoPedido
                                                       where VPP.Codigo == item.Insumo_ID
                                                       select VPP).FirstOrDefault();

                            var ConsultaExistenciaIns = (from E in hb.Existencia_Insumos
                                                         where E.Insumo_ID == item.Insumo_ID
                                                         group E by new
                                                         {
                                                             E.Insumo_ID,
                                                             Insumo = E.Productos_Insumos.Descripcion,
                                                             E.Medida_ID,
                                                             Medida = E.Medidas_Producto.Descripcion,
                                                             Categoria = E.Productos_Insumos.Categoria_ID,
                                                         } into Group
                                                         orderby Group.Key.Insumo
                                                         select new
                                                         {
                                                             Group.Key.Insumo_ID,
                                                             Group.Key.Insumo,
                                                             Existencia = Group.Sum(x => x.Cantidad) - Group.Sum(x => x.Cantidad_Utilizada),
                                                             Group.Key.Medida_ID,
                                                             Group.Key.Medida,
                                                             Stockmin = Group.Sum(x => x.Productos_Insumos.StockMin),
                                                             Group.Key.Categoria,
                                                             PuntoPedido = Group.Sum(x => x.Productos_Insumos.Punto_Pedido)
                                                         }).FirstOrDefault();

                            if (ConsultaExistenciaIns != null)
                            {
                                //if (ConsultaExistenciaIns.Existencia <= ConsultaPuntoPedido.PuntoPedido) //AGREGA LA NOTIFICACION
                                //{
                                //    var i = new Notificaciones();

                                //    i.Descripcion = "El insumo " + ConsultaExistenciaIns.Insumo + " alcanzó su punto de pedido";
                                //    i.Leida = "NO";
                                //    i.Tipo_ID = 1;
                                //    i.Fecha = DateTime.Now.Date;

                                //    hb.Notificaciones.Add(i);
                                //    MessageBox.Show("El insumo " + ConsultaExistenciaIns.Insumo + " alcanzó su punto de pedido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //}
                            }
                        }
                    }               
                    hb.SaveChanges();
                    MessageBox.Show("Movimiento anulado correctamente", "Atención");
                    this.Hide();
                }
            }
        }
        private void OnOffbtnCargar()
        {
            if(cmbProducto.SelectedIndex != -1
                && txtCantidad.TextLength > 0
                && cmbProducto.SelectedIndex != -1
                && cmbResponsable.SelectedIndex != -1)
            {
                btnCargar.Enabled = true;
            }
            else
            {
                btnCargar.Enabled = false;
            }
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
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
            }
        }

        private void btnBuscarResponsable_Click(object sender, EventArgs e)
        {
            txtBuscarResponsable.Visible = true;
            txtBuscarResponsable.Select();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void rdbSi_CheckedChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void rdbNo_CheckedChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void cmbResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void txtCantidad_TabIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnCargar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            txtCantidad.Text = "";
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularMovimiento();
        }

        private void btnEstimarProduccion_Click(object sender, EventArgs e)
        {
            decimal Cantidad = 0;

            if (txtCantidad.TextLength > 0)
                Cantidad = Convert.ToDecimal(txtCantidad.Text);

            if (txtCantidad.TextLength > 0 && Cantidad > 0 && cmbProducto.SelectedIndex != -1)
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaCantInsAsociados = (from FP in hb.Formula_Producto
                                                    where FP.Producto_ID == cmbProducto.SelectedValue.ToString()
                                                        && FP.Productos_Insumos.Subproducto == "NO"
                                                    select FP);

                    var ResultadosCantInsAsociados = ConsultaCantInsAsociados.ToList();

                    foreach (var item in ResultadosCantInsAsociados)
                    {
                        var ConsultaExistenciIns = (from EI in hb.Existencia_Insumos
                                                    where EI.Insumo_ID == item.Insumo_ID
                                                    group EI by new { EI.Insumo_ID } into Grupo
                                                    select new
                                                    {
                                                        Grupo.Key.Insumo_ID,
                                                        CantidadDisponible = Grupo.Sum(x => x.Cantidad) - Grupo.Sum(x => x.Cantidad_Utilizada)
                                                    });

                        var ResultadosExistenciIns = ConsultaExistenciIns.FirstOrDefault();

                        if (ResultadosExistenciIns != null)
                        {
                            decimal CantidadRequerida = Convert.ToDecimal(txtCantidad.Text) * item.Cantidad;
                            decimal CantidadDisponible = ResultadosExistenciIns.CantidadDisponible;

                            if (CantidadDisponible < CantidadRequerida)
                            {
                                string Mensaje = "La cantidad del insumo " + item.Productos_Insumos.Descripcion + " - " + item.Productos_Insumos.Codigo + " no abastece la cantidad requerida"
                                    + "\r\n"
                                    + "\r\n"
                                    + "Cantidad Requerida  = " + CantidadRequerida.ToString("N2") + "  " + item.Productos_Insumos.Medidas_Producto.Descripcion
                                    + "\r\n"
                                    + "Cantidad Disponible = " + CantidadDisponible.ToString("N2") + "  " + item.Productos_Insumos.Medidas_Producto.Descripcion
                                    + "\r\n"
                                    + "                                 ____________________"
                                    + "\r\n"
                                    + "Faltantes                        " + (CantidadRequerida - CantidadDisponible).ToString("N2") + "  " + item.Productos_Insumos.Medidas_Producto.Descripcion;

                                MessageBox.Show(Mensaje, "Atención");
                            }
                            else
                            {
                                string Mensaje = "La cantidad del insumo " + item.Productos_Insumos.Descripcion + " - " + item.Productos_Insumos.Codigo + " abastece la cantidad requerida";
                                MessageBox.Show(Mensaje,"Atención");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay registro del insumo " + item.Productos_Insumos.Descripcion,"Atención");
                        }
                        
                    }
                }
            }
            else
            {
                if (Cantidad == 0 || txtCantidad.TextLength == 0)
                    MessageBox.Show("Para estimar producción la cantidad debe ser mayor a 0", "Atención");
                if(cmbProducto.SelectedIndex == -1)
                    MessageBox.Show("Para estimar producción primero seleccione un producto", "Atención");
            }
        }

        private void cmbMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMovimiento.SelectedIndex != -1)
            {
                if (cmbMovimiento.SelectedValue.ToString() != "IPT")
                    btnEstimarProduccion.Enabled = false;
                else
                    btnEstimarProduccion.Enabled = true;
            }
            MostrarDatosSegunMovimiento();
        }
        //private frmDeposito FormularioDeposito = new frmDeposito();
        private void btnMostraDeposito_Click(object sender, EventArgs e)
        {

            using (var hb = new DBdatos())
            {
                var ConsultaDeposito = (from D in hb.PcnConfiguraciones
                                        select D).FirstOrDefault();

                if (ConsultaDeposito.TipoDeposito == "Base")
                {
                    var f = new frmDepositoBase();
                    f.FormularioAgregar = FormularioAgregar;
                    f.Accion = "Seleccionar";
                    f.Show();
                }
                else
                {
                    FormularioDeposito.Accion = "Seleccionar";
                    FormularioDeposito.FormularioAgregar = FormularioAgregar;
                    FormularioDeposito.Formulario = FormularioDeposito;
                    FormularioDeposito.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmDeposito_FormClosed);
                    FormularioDeposito2.FormSeccion2 = FormularioDeposito2;
                    //f. += new System.Windows.Forms.FormClosedEventHandler(frmDeposito_FormClosed);
                    FormularioDeposito.InicializarForm();
                    FormularioDeposito.Show();
                }

                //var f = new frmDeposito();
                //f.Accion = "Seleccionar";
                //f.FormularioAgregar = FormularioAgregar;
                //f.Formulario = FormularioDeposito;
                //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmDeposito_FormClosed);
                ////f. += new System.Windows.Forms.FormClosedEventHandler(frmDeposito_FormClosed);
                //f.Show();
            }
        }
        private void frmDeposito_FormClosed(object sender, FormClosedEventArgs e)
        {
            //using (var hb = new DBdatos())
            //{
            //    var Consulta = (from TTDS in hb.TT_DepositoSeleccionado
            //                    select TTDS).FirstOrDefault();

            //    if(Consulta != null)
            //    {
            //        string CadenaGeneral = Consulta.DepositoSeleccionado;

            //        if(CadenaGeneral.Length == 8)
            //        {
            //            cmbRack.Text = CadenaGeneral.Remove(2);
            //            cmbEspacio.Text = CadenaGeneral.Substring(2, 2);
            //            cmbPiso.Text = CadenaGeneral.Substring(4, 2);
            //            cmbLado.Text = CadenaGeneral.Substring(6, 2);
            //        }
            //        if (CadenaGeneral.Length == 9)
            //        {
            //            cmbRack.Text = CadenaGeneral.Remove(2);
            //            cmbEspacio.Text = CadenaGeneral.Substring(2, 3);
            //            cmbPiso.Text = CadenaGeneral.Substring(5, 2);
            //            cmbLado.Text = CadenaGeneral.Substring(7, 2);
            //        }
            //    }
            //}
        }
        private void AsociarOrdenProd()
        {
            if (txtIngresarOrdenProd.TextLength > 0)
            {
                lblEstadoOrden.Visible = true;

                using (var hb = new DBdatos())
                {
                    var Consulta = (from OP in hb.Orden_Produccion1
                                    where OP.NumeroOrden == txtIngresarOrdenProd.Text
                                        && OP.Estado_ID != "AN"
                                    select OP).FirstOrDefault();

                    if (Consulta != null)
                    {
                        AsociarOrdenProduccion = "SI";
                        OrdenProduccion_ID = Consulta.ID;
                        txtIngresarOrdenProd.Text = Consulta.NumeroOrden;
                        lblEstadoOrden.Text = "Orden encontrada";
                        lblEstadoOrden.ForeColor = Color.DarkGreen;
                        txtIngresarOrdenProd.ReadOnly = true;
                    }
                    else
                    {
                        AsociarOrdenProduccion = "NO";
                        txtIngresarOrdenProd.Text = txtIngresarOrdenProd.Text;
                        lblEstadoOrden.Text = "Orden no encontrada";
                        lblEstadoOrden.ForeColor = Color.Red;
                        txtIngresarOrdenProd.ReadOnly = false;
                    }
                }
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
        private void btnBuscarOrdenProd_Click(object sender, EventArgs e)
        {
            AsociarOrdenProd();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtIngresarOrdenProd.Text = "";
            lblEstadoOrden.Visible = false;
            AsociarOrdenProduccion = "NO";
            txtIngresarOrdenProd.ReadOnly = false;
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void txtIngresarOrdenProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AsociarOrdenProd();
            }
        }

        private void cmbRack_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEspacio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            if (CrearEditar == "1" || CrearEditar == "3")
                CargarProducto();
            if (CrearEditar == "2")
                EditarProducto();

            clsNotificaStockMinimo.NotificaStockMinimo();
            clsNotificacion.MostrarCantidadNotificacionesNoLeidas(FormularioMenu.lblCantidadNotificaciones);
        }

        private void btnInvalidar_Click(object sender, EventArgs e)
        {
            AnularMovimiento();
        }

        private void btnCargar_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                OnOffbtnCargar();
                if (btnCargar.Enabled == true)
                {
                    if (CrearEditar == "1")
                        CargarProducto();
                    if (CrearEditar == "2")
                        EditarProducto();
                }
            }
        }

        private void txtCantidadRotos_Enter(object sender, EventArgs e)
        {
            txtCantidad.Text = "";
        }

        private void txtCantidadRotos_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void btnBuscaTransportista_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBuscaCiudad_Click(object sender, EventArgs e)
        {
           
        }

        private void txtBuscaTransportista_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBuscaCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbTransportista_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtHumedad_Click(object sender, EventArgs e)
        {
            txtHumedad.SelectAll();
        }

        private void txtHumedad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtHumedad);
        }

        private void txtAcidez_Click(object sender, EventArgs e)
        {
            txtHumedad.SelectAll();
        }

        private void txtAcidez_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtAcidez);
        }

        private void dtpLote_ValueChanged(object sender, EventArgs e)
        {
            FormatearLote();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBuscarProducto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarResponsable_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtObservaciones_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtIngresarOrdenProd_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
