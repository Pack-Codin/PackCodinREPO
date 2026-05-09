using Microsoft.Office.Interop.Excel;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios.Productos___Insumos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = System.Drawing.Font;
using TextBox = System.Windows.Forms.TextBox;


namespace PCodin_Sinlacc.Formularios.Gastos
{
    public partial class frmAgregarGastos : Form
    {
        public long ID;
        public long IDImprimir;
        public string CrearEditarCopiar;
        public long CajaUsuarioID;
        public int ModuloID;
        clsImprimirPlantilla C = new clsImprimirPlantilla();
        public frmAgregarGastos()
        {
            InitializeComponent();
        }
        public class ListComprobantesPendientes
        {
            public long ID { get; set; }
            public string NumeroTicket { get; set; }
            public int Cliente_ID { get; set; }
            public int MedioPago { get; set; }
            public DateTime Fecha { get; set; }
            public int Movimiento_ID { get; set; }
            public string Movimiento { get; set; } = string.Empty;
            public decimal Importe { get; set; }
            public decimal ImporteAfectado { get; set; }
        }
        List<ListComprobantesPendientes> ListComprobantes = new List<ListComprobantesPendientes>();

        decimal ImporteTotalAfectado = 0;
        decimal ImporteTotal = 0;
        private void frmAgregarGastos_Load(object sender, EventArgs e)
        {
            InicializarForm();   
        }
        private void InicializarForm()
        {
            try
            {
                Reutilizables.RenderizarForm(this);
                if (ModuloID == 6)
                    Reutilizables.AutoNumerarComprobanteCuentaCorriente(txtPuntoVenta, txtNumeroComprobante);
                if (ModuloID == 10)
                    Reutilizables.AutoNumerarComprobanteCaja(txtPuntoVenta, txtNumeroComprobante);

                clsCargarCombos.MostrarComboConceptosAI(cmbConcepto, txtBuscarConcepto, chkActivoInactivo, false);
                clsCargarCombos.MostrarComboMovimientos(cmbMovimiento, ModuloID, "");
                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI", -1);

                pnlTotalDeuda.Width = (pnlComprobanteTotal.Width / 3);
                pnlTotalAfectado.Width = (pnlComprobanteTotal.Width / 3);
                pnlTotalCobro.Width = (pnlComprobanteTotal.Width / 3);

                cmbCliente.SelectedIndex = -1;
                cmbConcepto.SelectedIndex = -1;

                if (CrearEditarCopiar == "1")
                {
                    btnCargar.Text = "Cargar Movimiento";
                }
                else
                {
                    if (CrearEditarCopiar == "2")
                    {
                        btnCargar.Visible = false;
                    }
                    using (var hb = new DBdatos())
                    {
                        if (ModuloID == 6)
                        {
                            var Consulta = (from G in hb.MOVIMIENTOCUENTACORRIENTE
                                            where G.ID == ID
                                            select G).FirstOrDefault();

                            if (Consulta.MOVIMIENTOS.Descripcion.StartsWith("GASTO"))
                            {
                                pnlConcepto.Visible = true;
                                cmbConcepto.SelectedValue = Consulta.Tipo_Gasto_ID;
                                cmbConcepto.Text = Consulta.Tipo_Gasto.Descripcion;
                            }

                            cmbMovimiento.SelectedValue = Consulta.Movimiento_ID;
                            cmbMovimiento.Text = Consulta.MOVIMIENTOS.Descripcion;
                            dtpFecha.Value = (DateTime)Consulta.Fecha;
                            cmbCliente.SelectedValue = Consulta.Cliente_ID;
                            cmbCliente.Text = Consulta.Clientes.Descripcion;

                            if (Consulta.MedioPago_ID == 1)
                                rdbEfectivo.Checked = true;
                            if (Consulta.MedioPago_ID == 2)
                                rdbDebito.Checked = true;
                            if (Consulta.MedioPago_ID == 3)
                                rdbCredito.Checked = true;
                            if (Consulta.MedioPago_ID == 4)
                                rdbCC.Checked = true;

                            txtTotalCobro.Text = Consulta.Valor?.ToString("N2");
                            //Reutilizables.ConvertirValorMoneda(txtValor);
                            txtObservaciones.Text = Consulta.Observaciones;
                            if (CrearEditarCopiar != "3")
                            {
                                txtPuntoVenta.Text = Consulta.NumeroComprobante.Substring(0, 4);
                                txtNumeroComprobante.Text = Consulta.NumeroComprobante.Substring(4, 8);
                            }
                        }
                        if(ModuloID == 10)
                        {
                            var Consulta = (from G in hb.CAJAMOVIMIENTO
                                            where G.ID == ID
                                            select G).FirstOrDefault();

                            cmbMovimiento.SelectedValue = Consulta.Movimiento_ID;
                            cmbMovimiento.Text = Consulta.MOVIMIENTOS.Descripcion;
                            dtpFecha.Value = (DateTime)Consulta.Fecha;
                            cmbCliente.SelectedValue = Consulta.Cliente_ID;
                            cmbCliente.Text = Consulta.Clientes.Descripcion;

                            if (Consulta.MedioPago_ID == 1)
                                rdbEfectivo.Checked = true;
                            if (Consulta.MedioPago_ID == 2)
                                rdbDebito.Checked = true;
                            if (Consulta.MedioPago_ID == 3)
                                rdbCredito.Checked = true;
                            if (Consulta.MedioPago_ID == 4)
                                rdbCC.Checked = true;

                            txtTotalCobro.Text = Consulta.Importe?.ToString("N2");
                            //Reutilizables.ConvertirValorMoneda(txtValor);
                            txtObservaciones.Text = Consulta.Observaciones;
                            if (CrearEditarCopiar != "3")
                            {
                                txtPuntoVenta.Text = Consulta.NumeroComprobante.Substring(0, 4);
                                txtNumeroComprobante.Text = Consulta.NumeroComprobante.Substring(4, 8);
                            }
                        }

                        //CUERPO

                    }
                    if (CrearEditarCopiar == "2")
                        btnCargar.Text = "Editar Movimiento";
                    else
                        btnCargar.Text = "Cargar Movimiento";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
            
        }
        private void AbriFormTipoGasos(string CrearEditar)
        {
            var f = new frmCrearCategoria();
            f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmCrearCategoria_FormClosed);
            f.PulsoAgregarEditar = CrearEditar;
            f.PulsoCategoriaPuestoCiudadConcepto = "4";
            f.IDRecibCategoriaEditarEliminar = (int)cmbConcepto.SelectedValue;
            f.ShowDialog();
        }
        private void EliminarConcepto()
        {
            if (cmbConcepto.SelectedIndex != -1)
            {
                DialogResult R = MessageBox.Show("¿Seguro que desea eliminar esta categoría?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        long ID = (int)cmbConcepto.SelectedValue;

                        var Consulta = (from C in hb.Tipo_Gasto
                                        where C.ID == ID
                                        select C); // Trae el Id a eliminar

                        var ConsultaGeneral = (from C in hb.Gastos
                                               where C.TipoGasto_ID == ID
                                               select C); // Consulta global para que ver que ver si hay articulo con esta categoría

                        var Resultados = Consulta.FirstOrDefault();
                        var ResultadosGeneral = ConsultaGeneral.FirstOrDefault();

                        if (ResultadosGeneral == null)
                        {
                            hb.Tipo_Gasto.Remove(Resultados);
                            hb.SaveChanges();
                            MessageBox.Show("Datos eliminados correctamente", "Atención");
                            clsCargarCombos.MostrarComboConceptosAI(cmbConcepto, txtBuscarConcepto, chkActivoInactivo,false);
                        }
                        else
                        {
                            MessageBox.Show("No se puede eliminar esta concepto porque ya está afectado a un gasto. Solo puede darla de baja", "Atención");
                        }
                    }
                }
            }
        }
        private void CargarGastos()
        {
            try
            {
                long ID;
                decimal valor = Convert.ToDecimal(txtValor.Text);
                string NumeroComprobante = "";
                if (cmbMovimiento.SelectedIndex != -1 &&
                    cmbCliente.SelectedIndex != -1 &&
                    (txtTotalAfectado.Text != "0,00" || txtTotalCobro.Text != "0,00")
                    && (rdbEfectivo.Checked
                       || rdbDebito.Checked
                       || rdbCredito.Checked
                       || rdbCC.Checked))
                {
                    using (var hb = new DBdatos())
                    {
                        //long ID;
                        //decimal Importe = Convert.ToDecimal(txtValor.Text);
                        //string NumeroComprobante = "";
                        if (ModuloID == 6)
                        {
                            //CABEZAL
                            var i = new MOVIMIENTOCUENTACORRIENTE();

                            var Consulta = (from G in hb.MOVIMIENTOCUENTACORRIENTE
                                            orderby G.ID descending
                                            select G).Take(1).FirstOrDefault();

                            if (Consulta == null)
                                ID = 1;
                            else
                                ID = Consulta.ID + 1;

                            i.ID = ID;
                            i.Movimiento_ID = (int)cmbMovimiento.SelectedValue;
                            i.Cliente_ID = (int)cmbCliente.SelectedValue;
                            i.Fecha = dtpFecha.Value.Date;

                            if (rdbEfectivo.Checked)
                            {
                                i.MedioPago_ID = 1;
                            }
                            if (rdbDebito.Checked)
                            {
                                i.MedioPago_ID = 2;
                            }
                            if (rdbCredito.Checked)
                            {
                                i.MedioPago_ID = 3;
                            }
                            if (rdbCC.Checked)
                            {
                                i.MedioPago_ID = 4;
                            }
                            try
                            {
                                Convert.ToInt16(txtPuntoVenta.Text);
                                NumeroComprobante = txtPuntoVenta.Text;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Punto de venta incorrecto", "Atencion");
                                return;
                            }
                            try
                            {
                                Convert.ToInt32(txtNumeroComprobante.Text);
                                NumeroComprobante = NumeroComprobante + txtNumeroComprobante.Text;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Numero de comprobante incorrecto", "Atencion");
                                return;
                            }

                            i.NumeroComprobante = NumeroComprobante;

                            if (cmbConcepto.SelectedValue != null && cmbConcepto.SelectedIndex != -1)
                                i.Tipo_Gasto_ID = (int)cmbConcepto.SelectedValue;
                            else
                                i.Tipo_Gasto_ID = null;

                            if (Convert.ToDecimal(txtTotalCobro.Text) > 0)
                                i.Valor = Convert.ToDecimal(txtTotalCobro.Text);
                            else
                                i.Valor = Convert.ToDecimal(txtTotalAfectado.Text);

                            i.Estado_ID = "FI";
                            i.Observaciones = txtObservaciones.Text;
                            i.CajaUsuario_ID = CajaUsuarioID;

                            if (cmbMovimiento.Text.StartsWith("GASTO") && cmbConcepto.SelectedValue == null)
                            {
                                MessageBox.Show("No selecciono Concepto", "Atencion");
                            }

                            hb.MOVIMIENTOCUENTACORRIENTE.Add(i);

                            //CUERPO
                            foreach (var z in ListComprobantes)
                            {
                                //SOLO SE GRABARAN LOS QUE TENGAN IMPORTE AFECTADO
                                if (z.ImporteAfectado > 0)
                                {
                                    var x = new MOVIMIENTOCUENTACORRIENTECUERPO();

                                    x.MovimientoCuentaCorriente_ID = ID;
                                    x.Movimiento_ID = z.ID;
                                    x.ImporteAfectado = z.ImporteAfectado;

                                    var ConsultaTicket = (from C in hb.TICKET
                                                          where C.ID == z.ID
                                                          select C).FirstOrDefault();

                                    ConsultaTicket.ImporteAfectado = ConsultaTicket.ImporteAfectado + z.ImporteAfectado;

                                    hb.MOVIMIENTOCUENTACORRIENTECUERPO.Add(x);
                                }

                            }
                            hb.SaveChanges();
                            MessageBox.Show("Datos cargados correctamente", "Atención");
                            C.ImprimirTicketCobro(ID, chkImprimir);
                            this.Hide();

                        }
                        if(ModuloID == 10)
                        {

                            if (cmbMovimiento.SelectedIndex != -1 &&
                                cmbCliente.SelectedIndex != -1 &&
                                (txtTotalAfectado.Text != "0,00" || txtTotalCobro.Text != "0,00")
                                && (rdbEfectivo.Checked
                                   || rdbDebito.Checked
                                   || rdbCredito.Checked
                                   || rdbCC.Checked))
                            {

                               
                                    //CABEZAL
                                    var i = new CAJAMOVIMIENTO();

                                    i.Modulo_ID = ModuloID;
                                    i.Movimiento_ID = (int)cmbMovimiento.SelectedValue;
                                    i.Cliente_ID = (int)cmbCliente.SelectedValue;
                                    i.Fecha = dtpFecha.Value.Date;

                                    if (rdbEfectivo.Checked)
                                    {
                                        i.MedioPago_ID = 1;
                                    }
                                    if (rdbDebito.Checked)
                                    {
                                        i.MedioPago_ID = 2;
                                    }
                                    if (rdbCredito.Checked)
                                    {
                                        i.MedioPago_ID = 3;
                                    }
                                    if (rdbCC.Checked)
                                    {
                                        i.MedioPago_ID = 4;
                                    }
                                    try
                                    {
                                        Convert.ToInt16(txtPuntoVenta.Text);
                                        NumeroComprobante = txtPuntoVenta.Text;
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Punto de venta incorrecto", "Atencion");
                                        return;
                                    }
                                    try
                                    {
                                        Convert.ToInt32(txtNumeroComprobante.Text);
                                        NumeroComprobante = NumeroComprobante + txtNumeroComprobante.Text;
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Numero de comprobante incorrecto", "Atencion");
                                        return;
                                    }

                                    i.NumeroComprobante = NumeroComprobante;

                                    //if (cmbConcepto.SelectedValue != null && cmbConcepto.SelectedIndex != -1)
                                    //    i.Tipo_Gasto_ID = (int)cmbConcepto.SelectedValue;
                                    //else
                                    //    i.Tipo_Gasto_ID = null;

                                    if (Convert.ToDecimal(txtTotalCobro.Text) > 0)
                                        i.Importe = Convert.ToDecimal(txtTotalCobro.Text);
                                    else
                                        i.Importe = Convert.ToDecimal(txtTotalAfectado.Text);

                                    i.Estado = "FI";
                                    i.Observaciones = txtObservaciones.Text;
                                    i.CajaUsuario_ID = CajaUsuarioID;
                                
                                    hb.CAJAMOVIMIENTO.Add(i);

                                    ////CUERPO
                                    //foreach (var z in ListComprobantes)
                                    //{
                                    //    //SOLO SE GRABARAN LOS QUE TENGAN IMPORTE AFECTADO
                                    //    if (z.ImporteAfectado > 0)
                                    //    {
                                    //        var x = new MOVIMIENTOCUENTACORRIENTECUERPO();

                                    //        x.MovimientoCuentaCorriente_ID = ID;
                                    //        x.Movimiento_ID = z.ID;
                                    //        x.ImporteAfectado = z.ImporteAfectado;

                                    //        var ConsultaTicket = (from C in hb.TICKET
                                    //                              where C.ID == z.ID
                                    //                              select C).FirstOrDefault();

                                    //        ConsultaTicket.ImporteAfectado = ConsultaTicket.ImporteAfectado + z.ImporteAfectado;

                                    //        hb.MOVIMIENTOCUENTACORRIENTECUERPO.Add(x);
                                    //    }

                                    //}
                                    hb.SaveChanges();
                                    MessageBox.Show("Datos cargados correctamente", "Atención");
                                    //C.ImprimirTicketCobro(ID, chkImprimir);
                                    this.Hide();
                                
                            }
                        }
                    }
                        
                }
                else
                {
                    if (cmbMovimiento.SelectedIndex < 0)
                        MessageBox.Show("No selecciono Movimiento", "Atención");
                    if (cmbCliente.SelectedIndex < 0)
                        MessageBox.Show("No selecciono cliente", "Atención");
                    if (txtTotalAfectado.Text == "0,00" && txtTotalCobro.Text == "0,00")
                        MessageBox.Show("No afecto ningun valor", "Atención");
                    if ((!rdbEfectivo.Checked
                       && !rdbDebito.Checked
                       && !rdbCredito.Checked
                       && !rdbCC.Checked))
                    {
                        MessageBox.Show("No selecciono forma de pago. Por favor seleccione uno para continuar", "Atención");
                    }

                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
                return;
            }
            
        }
        private void EditarGastos()
        {
            //using (var hb = new DBdatos())
            //{
            //    var Consulta = (from G in hb.MOVIMIENTOCUENTACORRIENTE
            //                    where G.ID == ID
            //                    select G).FirstOrDefault();

            //    Consulta.Movimiento_ID = (int)cmbMovimiento.SelectedValue;
            //    Consulta.Cliente_ID = (int)cmbCliente.SelectedValue;
            //    Consulta.Fecha = dtpFecha.Value;
            //    Consulta.Tipo_Gasto_ID = (int)cmbConcepto.SelectedValue;
            //    Consulta.Valor = Convert.ToDecimal(txtValor.Text);
            //    Consulta.Observaciones = txtObservaciones.Text;

            //    hb.SaveChanges();
            //    MessageBox.Show("Datos editados correctamente", "Atención");
            //    this.Hide();
            //}
        }
        private void MostrarComprobantes(bool Actualiza)
        {
            using (var hb = new DBdatos())
            {
                int ClienteID;
                if (cmbCliente.SelectedIndex == -1)
                    ClienteID = -1;
                else
                    ClienteID = (int)cmbCliente.SelectedValue;

                List<TICKET>Consulta = new List<TICKET>();
                
                if(CrearEditarCopiar == "1")
                {
                    //CONSLTA PARA LLENAR EL DGV
                    Consulta = (from C in hb.TICKET
                                where C.Cliente_ID == ClienteID
                                    && C.MEDIOPAGO1.Codigo == "CC"
                                    && C.ImporteTotal != C.ImporteAfectado
                                select C).ToList();

                }
                if(CrearEditarCopiar == "2")
                {
                    List<long>ListaID = new List<long>();

                    var ConsultaMovimientoCuentaCorrienteCuerpo = (from MCC in hb.MOVIMIENTOCUENTACORRIENTECUERPO
                                                                   where MCC.MovimientoCuentaCorriente_ID == ID
                                                                   select new
                                                                   {
                                                                       MCC.Movimiento_ID
                                                                   }).ToList();

                    foreach(var i in ConsultaMovimientoCuentaCorrienteCuerpo)
                    {
                        ListaID.Add(i.Movimiento_ID);
                    }

                    Consulta = (from C in hb.TICKET
                                where ListaID.Contains(C.ID)                                  
                                select C).ToList();
                }

                //LLENA LA LISTA
                if (Actualiza == false)
                {                   
                    decimal ImporteTotalAfectado = 0;
                    ImporteTotal = 0;

                    foreach (var i in Consulta)
                    {
                        decimal ImporteAfectadoN = 0;
                       
                        if (CrearEditarCopiar == "2")
                        {
                            var ConsultaImporteAfectado = (from C in hb.MOVIMIENTOCUENTACORRIENTECUERPO
                                                           where C.Movimiento_ID == i.ID
                                                                && C.MovimientoCuentaCorriente_ID == ID
                                                           select C).FirstOrDefault();

                            ImporteAfectadoN = (decimal)ConsultaImporteAfectado.ImporteAfectado;
                            ImporteTotalAfectado = ImporteTotalAfectado + (decimal)ConsultaImporteAfectado.ImporteAfectado;
                        }
                            
                        ListComprobantes.Add(new ListComprobantesPendientes
                        {
                            ID = i.ID,
                            NumeroTicket = i.NumeroTicket.Substring(0, 4) + "-" + i.NumeroTicket.Substring(4, 8),
                            Cliente_ID = i.Cliente_ID,
                            MedioPago = (int)i.MedioPago,
                            Fecha = i.Fecha,
                            Movimiento_ID = (int)i.Movimiento_ID,
                            Movimiento = i.MOVIMIENTOS.Descripcion,
                            Importe = ((decimal)i.ImporteTotal - (decimal)i.ImporteAfectado),
                            ImporteAfectado = ImporteAfectadoN
                        });
                        ImporteTotal = ImporteTotal + ((decimal)i.ImporteTotal - (decimal)i.ImporteAfectado);
                    }
                    txtTotalAfectado.Text = ImporteTotalAfectado.ToString("N2");
                    txtTotalDeuda.Text = ImporteTotal.ToString("N2");
                }
                

                var ConsultaComprobantes = (from C in ListComprobantes
                                            orderby C.Fecha
                                            select new
                                            {
                                                C.ID,
                                                C.Movimiento,
                                                C.Movimiento_ID,
                                                C.NumeroTicket,
                                                C.Fecha,
                                                C.Cliente_ID,
                                                C.Importe,
                                                C.ImporteAfectado
                                            }).ToList();

                colID.DataPropertyName = "ID";
                colMovimiento.DataPropertyName = "Movimiento";
                colNumeroComprobante.DataPropertyName = "NumeroTicket";
                colFecha.DataPropertyName = "Fecha";
                colImportePendiente.DataPropertyName = "Importe";
                colImporteAfectado.DataPropertyName = "ImporteAfectado";

                dgvComprobantesAfectar.AutoGenerateColumns = false;
                dgvComprobantesAfectar.DataSource = ConsultaComprobantes;


            }
        }
        private async void Afectar()
        {
            try
            {
                long IDModificar;               
                decimal ImporteAfectar;

                if (dgvComprobantesAfectar.RowCount > 0)
                {

                    IDModificar = Convert.ToInt64(dgvComprobantesAfectar.CurrentRow.Cells["colID"].Value);
                    ImporteAfectar = Convert.ToDecimal(txtValor.Text);

                    var Consulta = (from C in ListComprobantes
                                    where C.ID == IDModificar
                                    select C).FirstOrDefault();

                    if (Consulta.Importe > 0)
                    {
                        if(ImporteAfectar <= Consulta.Importe)
                        {
                            Consulta.Importe = Consulta.Importe - ImporteAfectar;
                            Consulta.ImporteAfectado = Consulta.ImporteAfectado + ImporteAfectar;
                            ImporteTotalAfectado = ImporteTotalAfectado + ImporteAfectar;
                            ImporteTotal = ImporteTotal - ImporteAfectar;
                            txtTotalDeuda.Text = ImporteTotal.ToString("N2");
                            txtTotalAfectado.Text = ImporteTotalAfectado.ToString("N2");

                            MostrarComprobantes(true);
                        }
                        else
                        {
                            MessageBox.Show("Esta afectando un importe mayor al pendiente de afectar", "Atencion");
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
                return;
            }                     
        }
        private async void AfectarTodo()
        {
            try
            {
                if (dgvComprobantesAfectar.RowCount > 0)
                {
                    var Consulta = (from C in ListComprobantes
                                    select C).ToList();

                    ImporteTotal = 0;
                    ImporteTotalAfectado = 0;

                    foreach(var i in Consulta)
                    {
                        i.ImporteAfectado = i.ImporteAfectado + i.Importe;                                     
                        ImporteTotalAfectado = ImporteTotalAfectado + i.ImporteAfectado;
                        ImporteTotal = 0;
                        txtTotalDeuda.Text = ImporteTotal.ToString("N2");
                        txtTotalAfectado.Text = ImporteTotalAfectado.ToString("N2");
                        i.Importe = 0;

                        MostrarComprobantes(true);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
             
            }
        }
        private void Desafectar()
        {
            try
            {
                long IDModificar;
                decimal ImporteAfectar;

                if (dgvComprobantesAfectar.RowCount > 0)
                {

                    IDModificar = Convert.ToInt64(dgvComprobantesAfectar.CurrentRow.Cells["colID"].Value);
                    ImporteAfectar = Convert.ToDecimal(dgvComprobantesAfectar.CurrentRow.Cells["colImporteAfectado"].Value);

                    var Consulta = (from C in ListComprobantes
                                    where C.ID == IDModificar
                                    select C).FirstOrDefault();

                    if (Consulta.ImporteAfectado > 0)
                    {
                        Consulta.Importe = Consulta.Importe + ImporteAfectar;
                        Consulta.ImporteAfectado = Consulta.ImporteAfectado - ImporteAfectar;
                        ImporteTotalAfectado = ImporteTotalAfectado - ImporteAfectar;
                        ImporteTotal = ImporteTotal + ImporteAfectar;
                        txtTotalDeuda.Text = ImporteTotal.ToString("N2");
                        txtTotalAfectado.Text = ImporteTotalAfectado.ToString("N2");

                        MostrarComprobantes(true);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
                return;
            }
        }
        private async void TraerDeudaCobroCliente()
        {
            using (var hb = new DBdatos())
            {
                try
                {
                    if (cmbCliente.SelectedIndex != -1 && cmbCliente.SelectedValue != null && cmbMovimiento.Text == "COBRO")
                    {
                        var Consulta = (from C in hb.VISTA_RESUMENCUENTA001
                                        where C.ClienteID == (int)cmbCliente.SelectedValue
                                        select C).FirstOrDefault();

                        if (Consulta != null)
                            txtTotalDeuda.Text = Consulta.Importe.ToString("N2");
                        else
                            txtTotalDeuda.Text = "0,00";
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error");
                    return;
                }              
            }
        }
        private void FormatearCeldas(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvComprobantesAfectar.RowCount > 0)
            {
                if (this.dgvComprobantesAfectar.Columns[e.ColumnIndex].Name == "colImportePendiente")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                    e.CellStyle.Font = new Font("Roboto Condensed", 10, FontStyle.Bold);
                }
                if (this.dgvComprobantesAfectar.Columns[e.ColumnIndex].Name == "colImporteAfectado")
                {
                    e.CellStyle.ForeColor = Color.DarkGreen;
                    e.CellStyle.SelectionForeColor = Color.DarkGreen;
                    e.CellStyle.Font = new Font("Roboto Condensed", 10, FontStyle.Bold);
                }
            }
        }
        private void OnOffbtnCargar()
        {
            
        }
        private void frmCrearCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsCargarCombos.MostrarComboConceptosAI(cmbConcepto, txtBuscarConcepto, chkActivoInactivo, false);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbriFormTipoGasos("1");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbriFormTipoGasos("2");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarConcepto();
        }

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            txtValor.SelectAll();
        }

        private void txtBuscarConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarConcepto.Visible = false;
                clsCargarCombos.MostrarCategorias(cmbConcepto, txtBuscarConcepto, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarConcepto.Visible = false;
            }
        }

        private void cmbConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarCategorias(cmbConcepto, txtBuscarConcepto, false);
            }
        }

        private void btnBuscarConcepto_Click(object sender, EventArgs e)
        {
            txtBuscarConcepto.Visible = true;
            txtBuscarConcepto.Select();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

        }

        private void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtValor);
            OnOffbtnCargar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            Reutilizables.ConvertirValorMoneda(txtValor);
        }

        private void txtValor_Leave_1(object sender, EventArgs e)
        {
            //Reutilizables.ConvertirValorMoneda(txtValor);

            //if (textBox1.Text == string.Empty)
            //{
            //    return;
            //}
            //else
            //{
            //    decimal Valor;

            //    Valor = Convert.ToDecimal(textBox1.Text);
            //    textBox1.Text = Valor.ToString("N2");
            //}
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void txtValor_Leave_2(object sender, EventArgs e)
        {
            Reutilizables.ConvertirValorMoneda(txtValor);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (CrearEditarCopiar != "2")
                CargarGastos();
            else
                EditarGastos();
        }

        private void txtValor_TextChanged_1(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void txtBuscarConcepto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtValor_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtObservaciones_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void cmbMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMovimiento.SelectedValue != null)
            {
                if (cmbMovimiento.Text.StartsWith("GASTO"))
                {
                    pnlConcepto.Visible = true;
                }
                else
                {
                    pnlConcepto.Visible = false;
                }
                TraerDeudaCobroCliente();
            }
            
        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarCliente.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, true, "CLI", -1);
                txtBuscarCliente.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarCliente.Visible = false;
                txtBuscarCliente.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Visible = true;
            txtBuscarCliente.Select();
        }

        private void cmbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboClientes(cmbCliente, txtBuscarCliente, false, "CLI", -1);
                txtBuscarCliente.Focus();
                e.Handled = true;
            }
        }

        private void txtBuscarConcepto_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnAfectar_Click(object sender, EventArgs e)
        {

        }

        private void dgvComprobantesAfectar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtValor.Text = dgvComprobantesAfectar.CurrentRow.Cells["colImportePendiente"].Value.ToString();
            Reutilizables.ConvertirValorMoneda(txtValor);
        }

        private  void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraerDeudaCobroCliente();
            //ListComprobantes.Clear();
            //MostrarComprobantes(false);

        }

        private void dgvComprobantesAfectar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtValor.Text = dgvComprobantesAfectar.CurrentRow.Cells["colImportePendiente"].Value.ToString();
            Reutilizables.ConvertirValorMoneda(txtValor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Afectar();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if(CrearEditarCopiar == "2")
                {
                    using (var hb = new DBdatos())
                    {
                        if(ModuloID == 6)
                        {
                            var ConsultaCabezal = (from M in hb.MOVIMIENTOCUENTACORRIENTE
                                                   where M.ID == ID
                                                   select M).FirstOrDefault();

                            ConsultaCabezal.Estado_ID = "AN";

                            var ConsultaCuerpo = (from MC in hb.MOVIMIENTOCUENTACORRIENTECUERPO
                                                  where MC.MovimientoCuentaCorriente_ID == ID
                                                  select MC).ToList();

                            foreach (var i in ConsultaCuerpo)
                            {
                                var ConsultaComprobante = (from T in hb.TICKET
                                                           where T.ID == i.Movimiento_ID
                                                           select T).FirstOrDefault();

                                ConsultaComprobante.ImporteAfectado = ConsultaComprobante.ImporteAfectado - i.ImporteAfectado;
                            }
                        }
                        if(ModuloID == 10)
                        {
                            var ConsultaCabezal = (from M in hb.CAJAMOVIMIENTO
                                                   where M.ID == ID
                                                   select M).FirstOrDefault();

                            ConsultaCabezal.Estado = "AN";
                        }
                        hb.SaveChanges();
                        MessageBox.Show("Movimiento invalidado correctamente", "Atención");
                        this.Hide();
                    }
                }     
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
                return;
            }
        }

        private void dgvComprobantesAfectar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(e);
        }

        private void btnDesafectar_Click(object sender, EventArgs e)
        {
            Desafectar();
        }

        private void btnAfectarTodo_Click(object sender, EventArgs e)
        {
            AfectarTodo();
        }

        private void btnAfectar_Click_1(object sender, EventArgs e)
        {
            ListComprobantes.Clear();
            MostrarComprobantes(false);
        }

        private void txtTotalCobro_Leave(object sender, EventArgs e)
        {
            Reutilizables.ConvertirValorMoneda(txtTotalCobro);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (CrearEditarCopiar != "2")
                IDImprimir = ID;
            else
                IDImprimir = ID;

            C.ImprimirTicketCobro(IDImprimir, chkImprimir);
        }
    }
}
