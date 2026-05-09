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

namespace PCodin_Sinlacc.Formularios.Orden_Produccion
{
    public partial class frmMostrarOrdenProduccion : Form
    {

        public frmMostrarOrdenProduccion()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirformAgregarOrdenProduccion("1");
        }

        private void frmMostrarOrdenProduccion_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            dtpFechaDesde.Value = DateTime.Now.Date;
            dtpFechaHasta.Value = DateTime.Now.Date;

            MostrarDatos();
        }
        public void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OP in hb.Orden_Produccion1
                                orderby OP.ID
                                select new
                                {
                                    OP.ID,
                                    OP.Fecha,
                                    OP.Fecha_Limite,
                                    OP.Estado_Ord_Carga.Descripcion,
                                    OP.Estado_ID,
                                    OP.Empleados.Nombre,
                                    OP.NumeroOrden,
                                    OP.Responsable_ID,                                  
                                });

                if (cmbOrdenar.SelectedIndex == 1)
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.NumeroOrden ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.NumeroOrden descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 2)
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Fecha ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Fecha descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 3)
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Fecha_Limite ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Fecha_Limite descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 4)
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Nombre ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Nombre descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 5)
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Descripcion ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Descripcion descending
                                    select C);
                }
                if (chkFiltraOrdenProd.Checked)
                    Consulta = (from C in Consulta
                                where C.NumeroOrden == txtFiltraNumOrden.Text
                                select C);

                if (chkFiltraNroPedido.Checked && txtFiltraNroPedido.TextLength > 0)
                {
                    List<long> ListOrdenID = new List<long>();

                    long PedidoID = Convert.ToInt64(txtFiltraNroPedido.Text);

                    var ConsultaOPC = (from OPC in hb.OrdenProduccion_Cuerpo
                                       where OPC.Pedido_ID == PedidoID
                                       select OPC).ToList();

                    foreach (var item in ConsultaOPC)
                    {
                        ListOrdenID.Add(item.OrdenProd_ID);
                    }

                    Consulta = (from C in Consulta
                                where ListOrdenID.Contains(C.ID)
                                select C);
                }

                if (chkFiltraCliente.Checked)
                {
                    List<long> ListOrdenID = new List<long>();

                    var ConsultaOPC = (from OPC in hb.OrdenProduccion_Cuerpo
                                       where OPC.Registro_Pedidos.Cliente_ID == (int)cmbFiltraCliente.SelectedValue
                                       select OPC).ToList();

                    foreach (var item in ConsultaOPC)
                    {
                        ListOrdenID.Add(item.OrdenProd_ID);
                    }

                    Consulta = (from C in Consulta
                                where ListOrdenID.Contains(C.ID)
                                select C);
                }

                if (chkFiltraProducto.Checked)
                {
                    List<long> ListOrdenID = new List<long>();

                    var ConsultaOPC = (from OPC in hb.OrdenProduccion_Cuerpo
                                       where OPC.Producto_ID == cmbFiltraProducto.SelectedValue.ToString()
                                       select OPC).ToList();

                    foreach (var item in ConsultaOPC)
                    {
                        ListOrdenID.Add(item.OrdenProd_ID);
                    }

                    Consulta = (from C in Consulta
                                where ListOrdenID.Contains(C.ID)
                                select C);
                }

                if (chkFiltraResponsable.Checked)

                    Consulta = (from C in Consulta
                                where C.Responsable_ID == (int)cmbFiltraResponsable.SelectedValue
                                select C);

                if (chkFiltraEstado.Checked)
                    Consulta = (from C in Consulta
                                where C.Estado_ID == cmbFiltraEstado.Text
                                select C);

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

                colOrdenID.DataPropertyName = "ID";
                colNroOrden.DataPropertyName = "NumeroOrden";
                colFecha.DataPropertyName = "Fecha";
                colFechaLimite.DataPropertyName = "Fecha_Limite";
                colEstado.DataPropertyName = "Descripcion";
                colResponsable.DataPropertyName = "Nombre";

                lblResultados.Text = Resultados.Count.ToString();

                dgvOrdenPedido.AutoGenerateColumns = false;
                dgvOrdenPedido.DataSource = Resultados;
            }
        }
        private void AbrirformAgregarOrdenProduccion(string AgregarEditar)
        {
            var f = new frmAgregaOrdenProduccion();
            //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarOrdenCarga_FormClosed);
            f.CrearEditar = AgregarEditar;
            if (AgregarEditar != "1")
                f.IDRecibido = (long)dgvOrdenPedido.CurrentRow.Cells[0].Value;

            f.FormularioMostrarOrdenProd = this;
            AddOwnedForm(f);
            f.TopLevel = false;
            //f.Dock = DockStyle.Fill;
            this.Controls.Add(f);
            this.Tag = f;
            f.BringToFront();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        private void AbrirformProducirOrden(string AgregarEditar)
        {
            var f = new frmProducirOrden();
            //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarOrdenCarga_FormClosed);
            //f.CrearEditar = AgregarEditar;
            //if (AgregarEditar == "2")
            f.IdRecibido = (long)dgvOrdenPedido.CurrentRow.Cells[0].Value;

            AddOwnedForm(f);

            f.WindowState = FormWindowState.Maximized;
            f.TopLevel = false;          
            this.Controls.Add(f);
            this.Tag = f;
                       
            f.Show();

            //AddOwnedForm(f);

            //f.WindowState = FormWindowState.Maximized;
            //f.TopLevel = false;
            //this.Controls.Add(f);
            //this.Tag = f;
            ////f.BringToFront();
            //f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void dgvOrdenPedido_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirformAgregarOrdenProduccion("2");
        }
        private void ProducirOrden()
        {
            if (dgvOrdenPedido.RowCount > 0)
            {
                long OrdenProdID = (long)dgvOrdenPedido.CurrentRow.Cells[columnName: "colOrdenID"].Value;
                string EstadoID = dgvOrdenPedido.CurrentRow.Cells[columnName: "colEstado"].Value.ToString();

                using (var hb = new DBdatos())
                {
                    if (EstadoID == "En proceso" || EstadoID == "Finalizado")
                    {
                       
                        AbrirformProducirOrden("1");
                        MostrarDatos();
                        return;
                    }
                    if (EstadoID == "Anulado")
                    {
                        var ConsultaOPP = (from OPP in hb.Orden_Produccion_Parte
                                           where OPP.OrdenProduccion_Cuerpo.OrdenProd_ID == OrdenProdID
                                           select OPP).FirstOrDefault();

                        if (ConsultaOPP != null)
                        {                          
                            AbrirformProducirOrden("1");
                            MostrarDatos();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("La orden de producción seleccionada nunca fue producida", "Atención");
                            return;
                        }

                    }
                    DialogResult R = MessageBox.Show("¿Seguro que desea producir la orden de produción N° " + OrdenProdID, "Atención", MessageBoxButtons.YesNoCancel);
                    if (R == DialogResult.Yes)
                    {                        
                        var ConsultaOP = (from OP in hb.Orden_Produccion1
                                          where OP.ID == OrdenProdID
                                          select OP).FirstOrDefault();

                        if (ConsultaOP.Estado_ID != "PRO")
                        {
                            ConsultaOP.Estado_ID = "PRO"; // CAMBIA EL ESTADO DE LA ORDEN

                            var ConsultaConfig = (from CONF in hb.PcnConfiguraciones
                                                  where CONF.Modulo_ID == 1
                                                  select CONF).FirstOrDefault();

                            
                            var ConsultaOPC = (from OPC in hb.OrdenProduccion_Cuerpo
                                               where OPC.OrdenProd_ID == OrdenProdID
                                               select OPC).ToList();

                            foreach (var item in ConsultaOPC)
                            {

                                var ConsultaCantInsAsociados = (from FP in hb.Formula_Producto
                                                                where FP.Producto_ID == item.Producto_ID
                                                                    && FP.Productos_Insumos.Subproducto == "NO"
                                                                select FP).ToList();

                                foreach (var item2 in ConsultaCantInsAsociados)
                                {
                                    var ConsultaExistenciIns = (from EI in hb.Existencia_Insumos
                                                                where EI.Insumo_ID == item2.Insumo_ID
                                                                //&& EI.Productos_Insumos.Subproducto == "NO" // QUE SOLO VALORE PARA DESCONTAR STOCKS DE INSUMO LOS QUE NO SON SUBPRODUCTOS
                                                                group EI by new { EI.Insumo_ID } into Grupo
                                                                select new
                                                                {
                                                                    Grupo.Key.Insumo_ID,
                                                                    CantidadDisponible = Grupo.Sum(x => x.Cantidad) - Grupo.Sum(x => x.Cantidad_Utilizada)
                                                                });

                                    var ResultadosExistenciIns = ConsultaExistenciIns.FirstOrDefault();

                                    if (ConsultaConfig.TrabajaConStockNegativo == "NO") // SI NO TRABAJA CON STOCK NEGATIVO
                                    {
                                        if (ResultadosExistenciIns != null)
                                        {
                                            decimal CantidadRequerida = item.Cantidad * item2.Cantidad; // CANTIDAD DE LA ORDEN DE PRODUCCION X LA CANTIDAD DE LA FORMULA
                                            decimal CantidadDisponible = ResultadosExistenciIns.CantidadDisponible;

                                            if (CantidadDisponible < CantidadRequerida) // CORROBORAR LAS CANTIDADES DE INSUMOS
                                            {
                                                string Mensaje = "La cantidad del insumo " + item2.Productos_Insumos.Descripcion + " - " + item2.Productos_Insumos.Codigo + " no abastece la cantidad requerida"
                                                    + "\r\n"
                                                    + "\r\n"
                                                    + "Cantidad Requerida  = " + CantidadRequerida.ToString("N2") + "  " + item2.Productos_Insumos.Medidas_Producto.Descripcion
                                                    + "\r\n"
                                                    + "Cantidad Disponible = " + CantidadDisponible.ToString("N2") + "  " + item2.Productos_Insumos.Medidas_Producto.Descripcion
                                                    + "\r\n"
                                                    + "                                 ____________________"
                                                    + "\r\n"
                                                    + "Faltantes                        " + (CantidadRequerida - CantidadDisponible).ToString("N2") + "  " + item2.Productos_Insumos.Medidas_Producto.Descripcion;

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
                                                                                  where EI.Insumo_ID == item2.Insumo_ID
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
                                                    I.ExitenciaProducto_ID = null;
                                                    I.OrdenProduccion_ID = (long)dgvOrdenPedido.CurrentRow.Cells[0].Value;
                                                    I.Cantidad = CantidadRequerida;

                                                    hb.ExistenciaProducto_ExistenciaInsumo.Add(I);
                                                }
                                            }
                                        }

                                        else
                                        {
                                            MessageBox.Show("No hay ningun registro del insumo " + item2.Productos_Insumos.Descripcion + " en el sistema. Para poder cargar un producto final deberá primero cargar este insumo", "Atención");
                                            return;
                                        }
                                    }
                                }

                                var ConsultaCircuito = (from CIR in hb.Seccion_Circuito
                                                        where CIR.Producto_ID == item.Producto_ID
                                                        select CIR).ToList();

                                foreach (var item2 in ConsultaCircuito)
                                {
                                    var ConsultaFormula = (from FP in hb.Formula_Producto
                                                           where FP.Producto_ID == item.Producto_ID
                                                                && FP.Insumo_ID == item2.Insumo_ID
                                                           select FP).FirstOrDefault();

                                    if (ConsultaFormula != null)
                                    {
                                        var i = new Orden_Produccion_Parte();

                                        i.OrdenProducCuerpo_ID = item.ID;
                                        i.Insumo_ID = item2.Insumo_ID;
                                        i.Seccion_ID = item2.Seccion_ID;
                                        i.Cantidad = item.Cantidad * ConsultaFormula.Cantidad; // CANTIDAD A PRODUCIR X CANTIDAD DE LA FORMULA
                                        i.Cantidad_Producida = 0;
                                        i.Avance = 0;
                                        i.Estado_ID = "PEN";

                                        hb.Orden_Produccion_Parte.Add(i);
                                    }
                                    else
                                    {
                                        var i = new Orden_Produccion_Parte();

                                        i.OrdenProducCuerpo_ID = item.ID;
                                        i.Insumo_ID = null;
                                        i.Seccion_ID = item2.Seccion_ID;
                                        i.Cantidad = item.Cantidad; // CANTIDAD A PRODUCIR X CANTIDAD DE LA FORMULA
                                        i.Cantidad_Producida = 0;
                                        i.Avance = 0;
                                        i.Estado_ID = "PEN";

                                        hb.Orden_Produccion_Parte.Add(i);
                                    }
                                }
                            }
                            hb.SaveChanges();
                            //MessageBox.Show("Orden lista para ser producida", "Atención");

                            var f = new frmFormMovimientoFinalizado();
                            f.picImagen.Image = Image.FromFile("C:/Program Files (x86)/Pack-Codin/Images/ProducirOrden.png");
                            f.lblMensaje.Text = "O. Producción lista para producir";
                            f.ShowDialog();
                            
                        }

                        AbrirformProducirOrden("1");
                        MostrarDatos();
                    }
                }
            }
        }
        private void btnProducirOrden_Click(object sender, EventArgs e)
        {
            ProducirOrden();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
            Reutilizables.ReubicarFiltros(gbxFiltros, pnlInferior, btnMostrarfiltros);
        }

        private void chkFiltraOrdenProd_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraNumOrden, chkFiltraOrdenProd);
        }

        private void chkFiltraNroPedido_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraNroPedido, chkFiltraNroPedido);
        }

        private void chkFiltraCliente_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCliente(chkFiltraCliente, cmbFiltraCliente, txtBuscarCliente, btnBuscarCliente);
        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraProducto, cmbFiltraProducto, txtBuscarProducto, btnBuscarProducto, "PRO", "NO");
        }

        private void chkFiltraResponsable_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboEmpleados(chkFiltraResponsable, txtBuscarResponsable, cmbFiltraResponsable, btnBuscarResponsable);
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbFiltraEstado);
        }

        private void txtBuscarResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarResponsable.Visible = false;
                clsCargarCombos.MostrarComboCiudades(cmbFiltraResponsable, txtBuscarResponsable, true);
                txtBuscarResponsable.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarResponsable.Visible = false;
            }
        }

        private void cmbFiltraResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboEmpleados(cmbFiltraResponsable, txtBuscarResponsable, false);
                e.Handled = true;
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Visible = true;
            txtBuscarCliente.Visible = true;
        }
        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProducto.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraProducto, txtBuscarProducto, "PRO", true,"NO");
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

        private void cmbFiltraProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraProducto, txtBuscarProducto, "PRO", true,"NO");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
        }
        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarCliente.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbFiltraCliente, txtBuscarCliente, true, "CLI", 0);
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

        private void cmbFiltraCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboClientes(cmbFiltraCliente, txtBuscarCliente, false, "CLI", 0);
                txtBuscarCliente.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarResponsable_Click(object sender, EventArgs e)
        {
            txtBuscarResponsable.Visible = true;
            txtBuscarResponsable.Select();
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatos();
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatos();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvOrdenPedido);
        }
        private void EliminarOrdenProduccion()
        {
            DialogResult R = MessageBox.Show("¿Seguro que desea eliminar la orden seleccionada?", "Atención", MessageBoxButtons.YesNoCancel);

            if (R == DialogResult.Yes)
            {
                using (var hb = new DBdatos())
                {
                    long ID = (long)dgvOrdenPedido.CurrentRow.Cells[0].Value;
                    string Estado = dgvOrdenPedido.CurrentRow.Cells[columnName: "colEstado"].Value.ToString();

                    if (Estado == "Anulado")
                    {
                        var ConsultaOPPC = (from OPPC in hb.OrdenProduccionParteCuerpo
                                            where OPPC.Orden_Produccion_Parte.OrdenProduccion_Cuerpo.OrdenProd_ID == ID
                                            select OPPC).ToList();

                        var ConsultaOPP = (from OPP in hb.Orden_Produccion_Parte
                                           where OPP.OrdenProduccion_Cuerpo.OrdenProd_ID == ID
                                           select OPP).ToList();

                        var ConsultaEIP = (from EPI in hb.ExistenciaProducto_ExistenciaInsumo
                                           where EPI.OrdenProduccion_ID == ID
                                           select EPI).ToList();

                        var ConsultaOPC = (from OPC in hb.OrdenProduccion_Cuerpo
                                           where OPC.OrdenProd_ID == ID
                                           select OPC).ToList();

                        var ConsultaOP = (from OP in hb.Orden_Produccion1
                                          where OP.ID == ID
                                          select OP).FirstOrDefault();

                        hb.OrdenProduccionParteCuerpo.RemoveRange(ConsultaOPPC);
                        hb.Orden_Produccion_Parte.RemoveRange(ConsultaOPP);
                        hb.OrdenProduccion_Cuerpo.RemoveRange(ConsultaOPC);
                        hb.ExistenciaProducto_ExistenciaInsumo.RemoveRange(ConsultaEIP);
                        hb.Orden_Produccion1.Remove(ConsultaOP);

                        MessageBox.Show("Orden de producción eliminada correctamente", "Atención");
                        hb.SaveChanges();
                        MostrarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Solo se pueden eliminar Ordenes de producción anuladas", "Atención");
                    }
                }

            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenPedido.RowCount > 0)
                EliminarOrdenProduccion();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenPedido.RowCount > 0)
                AbrirformAgregarOrdenProduccion("3");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenPedido.RowCount > 0)
                AbrirformAgregarOrdenProduccion("2");
        }
        private void MostrarEstadosEnColores(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrdenPedido.RowCount > 0)
            {
                if (this.dgvOrdenPedido.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "Anulado")
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    }
                    if (e.Value.ToString() == "Finalizado")
                    {
                        e.CellStyle.ForeColor = Color.Green;
                        e.CellStyle.SelectionForeColor = Color.Green;
                        e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    }
                    if (e.Value.ToString() == "En proceso")
                    {
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.SelectionForeColor = Color.Black;
                        e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    }
                    if (e.Value.ToString() == "Autorizado")
                    {
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.SelectionForeColor = Color.Black;
                        e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    }
                }
            }
        }
        private void dgvOrdenPedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MostrarEstadosEnColores(e);
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           


        }

        private void btnAsistente_MouseClick(object sender, MouseEventArgs e)
        {
            cmsAsistente.Show(btnAsistente.PointToScreen(e.Location));
        }

        private void CmsBtnAgregarPedOrden_Click(object sender, EventArgs e)
        {
            AbrirformAgregarOrdenProduccion("4");
        }

        private void txtBuscarCliente_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
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
    }
}