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
using PCodin_Sinlacc.Formularios.Asistentes;
using PCodin_Sinlacc.Formularios.MATERIALES.frmIngresoInsumo;
using System.Web.Caching;
using static Bunifu.UI.WinForms.BunifuSnackbar;
using PCodin_Sinlacc.Formularios.Productos___Insumos;
using PCodin_Sinlacc.Formularios.MATERIALES.Gestor_de_materiales.Insumos;

namespace PCodin_Sinlacc.Formularios.MATERIALES.Gestor_de_materiales.Insumos
{
    public partial class frmIngresoInsumoAsistente : Form
    {
        public frmIngresoInsumoAsistente()
        {
            InitializeComponent();
        }
        public string Accion = "";
        public PCodin_Sinlacc.Formularios.MATERIALES.frmIngresoInsumo.frmIngresoInsumo FormInsumo;
        public int ListaPrecioID;
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgvMercaderia.Rows.Add("","","",0,0,0,0,0);
            //btnGuardar.Enabled = false;
        }

        private void dgvTicket_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMercaderia.RowCount > 0) 
            {
                try
                {
                    bool Cancelar = false;
                    string CodigoBarra;
                    string Articulo = "";
                    int ListaPrecioID = 0;
                    string Costo = dgvMercaderia.Rows[e.RowIndex].Cells["colCosto"].Value.ToString();
                    string Precio = dgvMercaderia.Rows[e.RowIndex].Cells["colPrecio"].Value.ToString();

                    using (var hb = new DBdatos())
                    {
                        if (dgvMercaderia.Columns[e.ColumnIndex].Name == "colCodigoBarra")
                        {
                            try
                            {
                                CodigoBarra = dgvMercaderia.Rows[e.RowIndex].Cells["colCodigoBarra"].Value.ToString();
                                //Articulo = dgvMercaderia.Rows[e.RowIndex].Cells["colCodigo"].Value.ToString();
                                if (cmbListaPrecio.SelectedValue != null)
                                    ListaPrecioID = (int)cmbListaPrecio.SelectedValue;

                                //var ConsultaArticulo = (from AR in hb.Productos_Insumos
                                //                        where AR.Codigo == Articulo
                                //                        select AR).FirstOrDefault();

                                var ConsultaArticuloBarra = (from A in hb.CODIGOBARRA
                                                             where A.CodigoBarra1 == CodigoBarra
                                                             select A).FirstOrDefault();

                                var ConsultaArticuloCodigo = (from C in hb.Productos_Insumos
                                                              where C.Codigo == CodigoBarra
                                                              select C).FirstOrDefault();

                                if (ConsultaArticuloBarra == null && ConsultaArticuloCodigo == null)
                                {
                                    DialogResult R = MessageBox.Show("El articulo con código " + CodigoBarra + " no exite en la base de datos. ¿Desea crearlo?", "Atención", MessageBoxButtons.YesNo);
                                    {
                                        if (R == DialogResult.Yes)
                                        {
                                            var f = new frmQuickCrearArticulo();
                                            f.StartPosition = FormStartPosition.CenterScreen;
                                            f.CodigoBarra = CodigoBarra;
                                            f.DGV = this.dgvMercaderia;
                                            f.Modulo = Accion;
                                            f.ShowDialog();
                                        }
                                        else
                                        {
                                            dgvMercaderia.Rows.Remove(dgvMercaderia.CurrentRow);
                                            Cancelar = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (ConsultaArticuloBarra != null)
                                        Articulo = ConsultaArticuloBarra.Producto_ID;
                                    if (ConsultaArticuloCodigo != null)
                                        Articulo = ConsultaArticuloCodigo.Codigo;
                                }


                                if (Cancelar == true)
                                    return;

                                //var Consulta = (from A in hb.CODIGOBARRA
                                //                where A.CodigoBarra1 == CodigoBarra
                                //                select A).FirstOrDefault();

                                var ConsultaListaPrecio = (from LPC in hb.LISTAPRECIOCUERPO
                                                           where LPC.ListaPrecio_ID == ListaPrecioID
                                                            && LPC.Articulo_ID == Articulo
                                                           select LPC).FirstOrDefault();


                                if (ConsultaArticuloBarra != null)
                                {
                                    dgvMercaderia.Rows[e.RowIndex].Cells["colCodigo"].Value = ConsultaArticuloBarra.Productos_Insumos.Codigo;
                                    dgvMercaderia.Rows[e.RowIndex].Cells["colArticulo"].Value = ConsultaArticuloBarra.Productos_Insumos.Descripcion;
                                }
                                if (ConsultaArticuloCodigo != null)
                                {
                                    dgvMercaderia.Rows[e.RowIndex].Cells["colCodigo"].Value = ConsultaArticuloCodigo.Codigo;
                                    dgvMercaderia.Rows[e.RowIndex].Cells["colArticulo"].Value = ConsultaArticuloCodigo.Descripcion;
                                }

                                if (ConsultaListaPrecio != null)
                                {
                                    dgvMercaderia.Rows[e.RowIndex].Cells["colCostoOriginal"].Value = ConsultaListaPrecio.Costo;
                                    dgvMercaderia.Rows[e.RowIndex].Cells["colPrecioOriginal"].Value = ConsultaListaPrecio.Precio;
                                }
                                else
                                {
                                    dgvMercaderia.Rows[e.RowIndex].Cells["colCostoOriginal"].Value = 0;
                                    dgvMercaderia.Rows[e.RowIndex].Cells["colPrecioOriginal"].Value = 0;
                                }

                                //dgvMercaderia.CurrentCell = dgvMercaderia.Rows[e.RowIndex].Cells["colCantidad"];
                                //dgvMercaderia.BeginEdit(true);
                            }
                            catch (Exception Error)
                            {

                                MessageBox.Show(Error.Message);
                            }
                        }
                        if (this.dgvMercaderia.Columns[e.ColumnIndex].Name == "colCosto" || this.dgvMercaderia.Columns[e.ColumnIndex].Name == "colPrecio")
                        {
                            if (!Precio.Contains(",") && Precio.Contains("."))
                                Precio = Precio.ToString().Replace(".", ",");
                            else
                                Precio = Precio.ToString();

                            if (!Costo.Contains(",") && Costo.Contains("."))
                                Costo = Costo.ToString().Replace(".", ",");
                            else
                                Costo = Costo.ToString();

                            Costo = Convert.ToDecimal(Costo).ToString("N2");
                            Precio = Convert.ToDecimal(Precio).ToString("N2");

                            dgvMercaderia.Rows[e.RowIndex].Cells["colCosto"].Value = Costo;
                            dgvMercaderia.Rows[e.RowIndex].Cells["colPrecio"].Value = Precio;


                        }
                        Clases.Formularios.Ingresos.frmIngresoInsumoAsistente.CalcularTotal(dgvMercaderia, txtImporteTotal);


                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error");
                }
                
            }
                
        }

        private void frmIngresoInsumoAsistente_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            dgvMercaderia.MultiSelect = false;

            if (Accion == "Compra")
            {
                clsCargarCombos.MostrarComboClientes(cmbProveedor, txtBuscarProveedor, false, "PRO", 0);
                clsCargarCombos.MostrarCombomListaPrecio(cmbListaPrecio, 1);
                cmbProveedor.SelectedIndex = -1;
               // cmbListaPrecio.SelectedIndex = -1;
            }
            if(Accion == "ListaPrecio")
            {
                clsCargarCombos.MostrarCombomListaPrecio(cmbListaPrecio, ListaPrecioID);
                colCantidad.Visible = false;
                lblProveedor.Visible = false;
                cmbProveedor.Visible = false;
                btnBuscarProveedor.Visible = false;
                txtBuscarProveedor.Visible = false;
                lblProveedor.Visible = false;
                lblFecha.Visible = false;
                dtpFecha.Visible = false;
                pnlSuperior2.Visible = false;

                btnCargar.Text = "Cargar a lista";

            }

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void AgregarCompra()
        {
            if (dgvMercaderia.RowCount > 0)
            {
                try
                {
                    if (cmbProveedor.SelectedIndex != -1
                       && dgvMercaderia.RowCount > 0)
                    {
                        using (var hb = new DBdatos())
                        {
                            //CABEZAL
                            long IDCabezal = 0;
                            string NumeroComprobante = "";
                            bool Error = false;

                            var N = new INGRESOMERCADERIA();

                            var ConsultaID = (from ID in hb.INGRESOMERCADERIA
                                              orderby ID.ID descending
                                              select ID).FirstOrDefault();

                            var ConsultaLPconfig = (from C in hb.LISTAPRECIOCONFIG
                                                    select C).FirstOrDefault();

                            if (ConsultaID == null)
                            {
                                N.ID = 1;
                                IDCabezal = 1;
                            }
                            else
                            {
                                N.ID = ConsultaID.ID + 1;
                                IDCabezal = ConsultaID.ID + 1;
                            }

                            N.Fecha = DateTime.Now.Date;
                            N.Movimiento_ID = 1;
                            N.Proveedor_ID = (int)cmbProveedor.SelectedValue;
                            N.Estado = "FI";

                            try
                            {
                                if (txtLetraComprobante.Text == "A"
                                     || txtLetraComprobante.Text == "B"
                                     || txtLetraComprobante.Text == "M"
                                     || txtLetraComprobante.Text == "")

                                    N.LetraComprobante = txtLetraComprobante.Text;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Letra de comprobante incorrecta", "Atencion");
                                Error = true;
                            }
                            try
                            {
                                Convert.ToInt16(txtPuntoVenta.Text);
                                NumeroComprobante = txtPuntoVenta.Text;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Punto de venta incorrecto", "Atencion");
                                Error = true;
                            }
                            try
                            {
                                Convert.ToInt32(txtNumeroComprobante.Text);
                                NumeroComprobante = NumeroComprobante + txtNumeroComprobante.Text;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Numero de comprobante incorrecto", "Atencion");
                                Error = true;
                            }
                            if (Error == true)
                                return;


                            N.NumeroComprobante = NumeroComprobante;

                            // CUERPO
                            long IDinicial = 0;
                            decimal ImporteTotal = 0;

                            var ConsultaCuerpoID = (from ID in hb.INGRESOMERCADERIACUERPO
                                                    orderby ID.ID descending
                                                    select ID).FirstOrDefault();

                            if (ConsultaCuerpoID == null)
                                IDinicial = 1;
                            else
                                IDinicial = ConsultaCuerpoID.ID + 1;

                            for (var i = 0; i < dgvMercaderia.RowCount; i++)
                            {

                                if (dgvMercaderia.Rows[i].Cells["colCodigoBarra"].Value.ToString() != "" || dgvMercaderia.Rows[i].Cells["colCodigoBarra"].Value != null)
                                {
                                    var NC = new INGRESOMERCADERIACUERPO();

                                    string CodigoArticulo = dgvMercaderia.Rows[i].Cells["colCodigo"].Value.ToString();

                                    var ConsultaArticulo = (from AR in hb.Productos_Insumos
                                                            where AR.Codigo == CodigoArticulo
                                                                && AR.UtilizaEquivalencia == "SI"
                                                            select AR).FirstOrDefault();

                                    if (ConsultaArticulo != null)
                                    {
                                        if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCantidad"].Value) > 0)
                                            NC.Cantidad = (decimal)(Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCantidad"].Value) * ConsultaArticulo.EquivalenciaCantidad);

                                        CodigoArticulo = ConsultaArticulo.Codigo;

                                    }

                                    //MODIFICA LISTA PRECIO
                                    var ConsultaListaPrecio = (from LPC in hb.LISTAPRECIOCUERPO
                                                               where LPC.ListaPrecio_ID == (int)cmbListaPrecio.SelectedValue
                                                                && LPC.Articulo_ID == CodigoArticulo
                                                               select LPC).FirstOrDefault();

                                    if (ConsultaListaPrecio != null)
                                    {
                                        if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value) > 0)
                                            ConsultaListaPrecio.Costo = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value);

                                        if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecio"].Value) > 0)
                                            ConsultaListaPrecio.Precio = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecio"].Value);
                                        else
                                        {
                                            if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecioOriginal"].Value) > 0)
                                                ConsultaListaPrecio.Precio = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecioOriginal"].Value);
                                            else
                                                ConsultaListaPrecio.Precio = 0;
                                        }
                                        if (ConsultaLPconfig != null)
                                        {
                                            if (ConsultaLPconfig.ActualizaCostoEnTodasListas == "SI")
                                            {
                                                var ConsultaActualizaLP = (from LPC in hb.LISTAPRECIOCUERPO
                                                                           where LPC.Articulo_ID == CodigoArticulo
                                                                            && LPC.ListaPrecio_ID != (int)cmbListaPrecio.SelectedValue
                                                                           select LPC).ToList();

                                                foreach (var item in ConsultaActualizaLP)
                                                {
                                                    item.Costo = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value);

                                                    if (item.Precio == null)
                                                    {
                                                        item.Precio = 0;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var NewListaPrecio = new LISTAPRECIOCUERPO();

                                        NewListaPrecio.ListaPrecio_ID = (int)cmbListaPrecio.SelectedValue;
                                        NewListaPrecio.Articulo_ID = dgvMercaderia.Rows[i].Cells["colCodigo"].Value.ToString();

                                        if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value) > 0)
                                            NewListaPrecio.Costo = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value);
                                        else
                                            NewListaPrecio.Costo = 0;

                                        if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecio"].Value) > 0)
                                            NewListaPrecio.Precio = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecio"].Value);
                                        else
                                            NewListaPrecio.Precio = 0;

                                        hb.LISTAPRECIOCUERPO.Add(NewListaPrecio);
                                    }
                                    if (i == 0)
                                        NC.ID = IDinicial;
                                    else
                                        NC.ID = IDinicial + i;

                                    NC.Ingreso_ID = IDCabezal;
                                    NC.Insumo_ID = dgvMercaderia.Rows[i].Cells["colCodigo"].Value.ToString();

                                    if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCantidad"].Value) > 0)
                                        NC.Cantidad = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCantidad"].Value);
                                    else
                                    {
                                        MessageBox.Show("El articulo " + dgvMercaderia.Rows[i].Cells["colArticulo"].Value.ToString() + " tiene cantidad 0");
                                        Error = true;
                                    }
                                    if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value) >= 0)
                                        NC.Costo = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value);
                                    else
                                    {
                                        MessageBox.Show("El articulo " + dgvMercaderia.Rows[i].Cells["colArticulo"].Value.ToString() + " tiene Costo negativo");
                                        Error = true;
                                    }

                                    //ImporteTotal = ImporteTotal + (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value * );

                                    hb.INGRESOMERCADERIACUERPO.Add(NC);
                                }
                            }
                            if (Error == false)
                            {
                                N.ImporteTotal = Convert.ToDecimal(txtImporteTotal.Text);
                                hb.INGRESOMERCADERIA.Add(N);

                                hb.SaveChanges();
                                MessageBox.Show("Datos cargados correctamente", "Atencion");
                                this.Hide();
                                FormInsumo.Hide();
                            }
                            else
                                return;
                        }
                    }
                }
                catch (Exception Error)
                {
                    MessageBox.Show(Error.Message, "Error");
                }
            }
        }
        private void AgregarArticuloListaPrecio()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaLPconfig = (from C in hb.LISTAPRECIOCONFIG
                                            select C).FirstOrDefault();

                    for (var i = 0; i < dgvMercaderia.RowCount; i++)
                    {
                        string CodigoArticulo = dgvMercaderia.Rows[i].Cells["colCodigo"].Value.ToString();

                        var ConsultaArticulo = (from AR in hb.Productos_Insumos
                                                where AR.Codigo == CodigoArticulo
                                                    && AR.UtilizaEquivalencia == "SI"
                                                select AR).FirstOrDefault();

                        if (ConsultaArticulo != null)
                        {
                            //if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCantidad"].Value) > 0)
                            //    NC.Cantidad = (decimal)(Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCantidad"].Value) * ConsultaArticulo.EquivalenciaCantidad);

                            CodigoArticulo = ConsultaArticulo.Codigo;

                        }

                        //MODIFICA LISTA PRECIO
                        var ConsultaListaPrecio = (from LPC in hb.LISTAPRECIOCUERPO
                                                   where LPC.ListaPrecio_ID == (int)cmbListaPrecio.SelectedValue
                                                    && LPC.Articulo_ID == CodigoArticulo
                                                   select LPC).FirstOrDefault();

                        if (ConsultaListaPrecio != null)
                        {
                            if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value) > 0)
                                ConsultaListaPrecio.Costo = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value);
                            if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecio"].Value) > 0)
                                ConsultaListaPrecio.Precio = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecio"].Value);

                            if(ConsultaLPconfig != null)
                            {
                                if(ConsultaLPconfig.ActualizaCostoEnTodasListas == "SI")
                                {
                                    var ConsultaActualizaLP = (from LPC in hb.LISTAPRECIOCUERPO
                                                               where LPC.Articulo_ID == CodigoArticulo
                                                                && LPC.ListaPrecio_ID != (int)cmbListaPrecio.SelectedValue
                                                               select LPC).ToList();

                                    foreach(var item in ConsultaActualizaLP)
                                    {
                                        item.Costo = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value);

                                        if(item.Precio == null)
                                        {
                                            item.Precio = 0;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            var NewListaPrecio = new LISTAPRECIOCUERPO();

                            NewListaPrecio.ListaPrecio_ID = (int)cmbListaPrecio.SelectedValue;
                            NewListaPrecio.Articulo_ID = dgvMercaderia.Rows[i].Cells["colCodigo"].Value.ToString();
                            if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value) > 0)
                                NewListaPrecio.Costo = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value);
                            else
                                NewListaPrecio.Costo = 0;

                            if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecio"].Value) > 0)
                                NewListaPrecio.Precio = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecio"].Value);
                            else
                                NewListaPrecio.Precio = 0;

                            hb.LISTAPRECIOCUERPO.Add(NewListaPrecio);
                        }
                    }
                    hb.SaveChanges();
                    MessageBox.Show("Datos cargardos correctamente", "Atención");
                }
            }
            catch (Exception ER)
            {
                MessageBox.Show(ER.Message, "Error");                
            }
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (Accion == "Compra")
                AgregarCompra();
            if (Accion == "ListaPrecio")
                AgregarArticuloListaPrecio();
        }

        private void dgvMercaderia_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            dgvMercaderia.CurrentCell = dgvMercaderia.Rows[e.RowIndex].Cells["colCodigoBarra"];
            dgvMercaderia.BeginEdit(true);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMercaderia.RowCount > 0)
                dgvMercaderia.Rows.Remove(dgvMercaderia.CurrentRow);
        }

        private void pnlInferior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvMercaderia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvMercaderia.CurrentCell = dgvMercaderia.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvMercaderia.BeginEdit(true);
            }
            catch (Exception)
            {

                
            }
           
        }

        private void dgvMercaderia_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvMercaderia_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgvMercaderia_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {



                dgvMercaderia.CurrentCell = dgvMercaderia.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                dgvMercaderia.BeginEdit(true);
                
                 
            }
            catch (Exception)
            {
               // MessageBox.Show(error.Message);

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (var hb = new DBdatos())
            {
                try
                {
                    if (dgvMercaderia.RowCount > 0)
                    {
                        if ((cmbProveedor.SelectedIndex != -1 || Accion == "ListaPrecio") && cmbListaPrecio.SelectedIndex != -1 && (txtPuntoVenta.TextLength == 4 || Accion == "ListaPrecio") && (txtNumeroComprobante.TextLength == 8 || Accion == "ListaPrecio"))
                        {
                            var ConsultaEliminar = (from IM_M in hb.INGRESOMERCADERIA_MEMOS
                                                    where IM_M.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                    select IM_M).FirstOrDefault();

                            //ELIMINA LOS REGISTROS QUE YA TENGA CARGADO EL USUARIO
                            if (ConsultaEliminar != null)
                            {
                                var ConsultaEliminarCuerpo = (from IMC_M in hb.INGRESOMERCADERIACUERPO_MEMOS
                                                              where IMC_M.Ingreso_ID == ConsultaEliminar.ID
                                                              select IMC_M).ToList();

                                hb.INGRESOMERCADERIACUERPO_MEMOS.RemoveRange(ConsultaEliminarCuerpo);
                                hb.INGRESOMERCADERIA_MEMOS.Remove(ConsultaEliminar);
                                hb.SaveChanges();
                            }

                            //CREA Y GUARDA NUEVA LISTA

                            //CABEZAL
                            int IDCabezal = 0;
                            //string NumeroComprobante = "";
                            bool Error = false;

                            var N = new INGRESOMERCADERIA_MEMOS();

                            var ConsultaID = (from ID in hb.INGRESOMERCADERIA_MEMOS
                                              orderby ID.ID descending
                                              select ID).FirstOrDefault();

                            if (ConsultaID == null)
                            {
                                N.ID = 1;
                                IDCabezal = 1;
                            }
                            else
                            {
                                N.ID = ConsultaID.ID + 1;
                                IDCabezal = ConsultaID.ID + 1;
                            }

                            N.Fecha = DateTime.Now.Date;
                            N.Movimiento_ID = 1;
                            if (Accion == "ListaPrecio")
                            {
                                N.Proveedor_ID = null;
                                N.LetraComprobante = "";
                                N.NumeroComprobante = "0000-00000000";
                            }
                            else
                            {
                                N.Proveedor_ID = (int)cmbProveedor.SelectedValue;
                                N.Proveedor = cmbProveedor.Text;
                                N.LetraComprobante = txtLetraComprobante.Text;
                                N.NumeroComprobante = txtPuntoVenta.Text + txtNumeroComprobante.Text;
                            }
                                
                            
                            N.ListaPrecio_ID = (int)cmbListaPrecio.SelectedValue;
                            N.ListaPrecio = cmbListaPrecio.Text;
                            N.Usuario_ID = clsVariablesGenerales.UsuarioID;
                            N.Fecha_Guardado = DateTime.Now.Date;

                            if (txtLetraComprobante.Text == "A"
                                    || txtLetraComprobante.Text == "B"
                                    || txtLetraComprobante.Text == "M"
                                    || txtLetraComprobante.Text == "")

                                
                            
                            N.ImporteTotal = Convert.ToDecimal(txtImporteTotal.Text);
                            N.Observaciones = "";
                          



                            if (Error == true)
                                return;




                            hb.INGRESOMERCADERIA_MEMOS.Add(N);
                            hb.SaveChanges();

                            int IDinicial = 0;
                            decimal ImporteTotal = 0;

                            var ConsultaCuerpoID = (from ID in hb.INGRESOMERCADERIACUERPO_MEMOS
                                                    orderby ID.ID descending
                                                    select ID).FirstOrDefault();

                            if (ConsultaCuerpoID == null)
                                IDinicial = 1;
                            else
                                IDinicial = ConsultaCuerpoID.ID + 1;

                            for (var i = 0; i < dgvMercaderia.RowCount; i++)
                            {
                                if (dgvMercaderia.Rows[i].Cells["colCodigoBarra"].Value.ToString() != "")
                                {
                                    var NC = new INGRESOMERCADERIACUERPO_MEMOS();

                                    string CodigoArticulo = dgvMercaderia.Rows[i].Cells["colCodigo"].Value.ToString();

                                    //if (i == 0)
                                    //    NC.ID = IDinicial;
                                    //else
                                    //    NC.ID = IDinicial + i;

                                    NC.Ingreso_ID = IDCabezal;
                                    NC.CodigoBarra = dgvMercaderia.Rows[i].Cells["colCodigoBarra"].Value.ToString();
                                    NC.Articulo_ID = dgvMercaderia.Rows[i].Cells["colCodigo"].Value.ToString();
                                    NC.Articulo = dgvMercaderia.Rows[i].Cells["colArticulo"].Value.ToString();

                                    if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCantidad"].Value) > 0)
                                        NC.Cantidad = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCantidad"].Value);
                                    else
                                    {
                                        if(Accion == "ListaPrecio")
                                        {
                                            NC.Cantidad = 0;
                                        }
                                        else
                                        {
                                            MessageBox.Show("El articulo " + dgvMercaderia.Rows[i].Cells["colArticulo"].Value.ToString() + " tiene cantidad 0");
                                            Error = true;
                                        }
                                        
                                    }
                                    if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value) > 0)
                                        NC.Costo = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value);
                                    else
                                    {
                                        if (Accion == "ListaPrecio")
                                        {
                                            NC.Costo = 0;
                                        }
                                        else
                                        {
                                            MessageBox.Show("El articulo " + dgvMercaderia.Rows[i].Cells["colArticulo"].Value.ToString() + " tiene Costo 0");
                                            Error = true;
                                        }
                                           
                                    }

                                    NC.Precio = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecio"].Value);
                                    if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCostoOriginal"].Value) > 0)
                                        NC.CostoOriginal = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCostoOriginal"].Value);
                                    else
                                        NC.CostoOriginal = 0;
                                    if (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecioOriginal"].Value) > 0)
                                        NC.PrecioOriginal = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colPrecioOriginal"].Value);
                                    else
                                        NC.PrecioOriginal = 0;

                                        NC.ImporteTotal = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colImporteTotal"].Value);


                                    //ImporteTotal = ImporteTotal + (Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value * );

                                    hb.INGRESOMERCADERIACUERPO_MEMOS.Add(NC);
                                }
                                else
                                {
                                    MessageBox.Show("No se puede guardar ya que no está definido el articulo");
                                    Error = true;
                                }
                            }
                            if (Error == false)
                            {
                                //N.ImporteTotal = Convert.ToDecimal(lblTotal.Text);
                                //hb.INGRESOMERCADERIA_MEMOS.Add(N);

                                hb.SaveChanges();
                                MessageBox.Show("Datos salvados correctamente", "Atencion");
                            }
                            else
                                return;
                        }
                        else
                        {
                            if (cmbProveedor.SelectedIndex == -1)
                                MessageBox.Show("No selecciono PROVEEDOR", "Atención");
                            if (cmbListaPrecio.SelectedIndex == -1)
                                MessageBox.Show("No selecciono LISTA DE PRECIO", "Atención");
                            if (txtPuntoVenta.TextLength <4)
                                MessageBox.Show("PUNTO DE VENTA incorrecto", "Atención");
                            if (txtNumeroComprobante.TextLength < 8)
                                MessageBox.Show("NUMERO DE COMPROBANTE incorrecto", "Atención");
                        }
                    }
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult R = MessageBox.Show("Esta seguro que desea cargar los ultimos datos guardados ?. Se borraran todos los registros que estan en la grilla", "Atención", MessageBoxButtons.YesNoCancel);
            if (R == DialogResult.Yes)
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaCargar = (from IM_M in hb.INGRESOMERCADERIA_MEMOS
                                          where IM_M.Usuario_ID == clsVariablesGenerales.UsuarioID
                                          select IM_M).FirstOrDefault();

                    if (ConsultaCargar != null)
                    {
                        try
                        {
                            cmbProveedor.SelectedValue = ConsultaCargar.Proveedor_ID;
                            cmbProveedor.Text = ConsultaCargar.Proveedor;

                            cmbListaPrecio.SelectedValue = ConsultaCargar.ListaPrecio_ID;
                            cmbListaPrecio.Text = ConsultaCargar.ListaPrecio;

                            dtpFecha.Value = (DateTime)ConsultaCargar.Fecha;

                            txtLetraComprobante.Text = ConsultaCargar.LetraComprobante.ToUpper();
                            txtPuntoVenta.Text = ConsultaCargar.NumeroComprobante.Substring(0, 4);
                            txtNumeroComprobante.Text = ConsultaCargar.NumeroComprobante.Substring(4, 8);

                            txtImporteTotal.Text = ConsultaCargar.ImporteTotal.ToString();

                            var ConsultaCargarCuerpo = (from IMC_M in hb.INGRESOMERCADERIACUERPO_MEMOS
                                                        where IMC_M.Ingreso_ID == ConsultaCargar.ID
                                                        select IMC_M).ToList();

                            foreach (var item in ConsultaCargarCuerpo)
                            {
                                dgvMercaderia.Rows.Add(item.CodigoBarra, item.Articulo_ID, item.Articulo, item.Cantidad, item.Costo, item.Precio, item.CostoOriginal, item.PrecioOriginal, item.ImporteTotal);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }



                    }
                }
            }
               
        }
        private void AbrirFormItherio()
        {
            var f = new frmIngresoInsumoAsistenteITHERIO();
            f.DGV = dgvMercaderia;
            f.txtImporteTotal  = txtImporteTotal;
            f.ShowDialog();
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvMercaderia);
        }

        private void txtBuscarProveedor_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtLetraComprobante_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtPuntoVenta_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtNumeroComprobante_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void btnImprimirPresupuesto_Click(object sender, EventArgs e)
        {
            AbrirFormItherio();
        }

        private void txtImporteTotal_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtImporteTotal);
        }
    }
}
