using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Formularios.MATERIALES.Gestor_de_materiales.Insumos;

namespace PCodin_Sinlacc.Formularios.MATERIALES.frmIngresoInsumo
{
    public partial class frmIngresoInsumo : Form
    {
        public frmIngresoInsumo()
        {
            InitializeComponent();
        }

        private void frmIngresoInsumo_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        clsImprimirPlantilla C = new clsImprimirPlantilla();
        public long IDRecibido;
        public string Accion;

       // DataTable DS = new DataTable();
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            clsCargarCombos.MostrarComboMovimientos(cmbMovimiento, 7, "INGMER");
            clsCargarCombos.MostrarComboClientes(cmbProveedor, txtBuscaProveedor, false, "PRO", 0);
            dtpFecha.Value = DateTime.Now.Date;

            cmbMovimiento.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;

            //Reutilizables.AutoNumerarComprobanteCompra(txtPuntoVenta,txtNumeroComprobante);

            using (var hb = new DBdatos())
            {
                if(Accion != "1") //EDITAR o COPIAR
                {
                    //CABEZAL
                    var ConsultaCabezal = (from CCA in hb.INGRESOMERCADERIA
                                           where CCA.ID == IDRecibido
                                           select CCA).FirstOrDefault();

                    cmbMovimiento.SelectedValue = ConsultaCabezal.Movimiento_ID;
                    cmbMovimiento.Text = ConsultaCabezal.MOVIMIENTOS.Descripcion;
                    cmbProveedor.SelectedValue = ConsultaCabezal.Proveedor_ID;
                    cmbProveedor.Text = ConsultaCabezal.Clientes.Descripcion;
                    dtpFecha.Value = (DateTime)ConsultaCabezal.Fecha;
                    txtObservaciones.Text = ConsultaCabezal.Observaciones;

                    if (ConsultaCabezal.Estado == "FI")
                        cmbEstado.Text = "Finalizado";
                    if (ConsultaCabezal.Estado == "PEN")
                        cmbEstado.Text = "Pendiente";
                    if (ConsultaCabezal.Estado == "AN")
                        cmbEstado.Text = "Cancelado";

                    if (Accion == "2")
                    {
                        if (ConsultaCabezal.LetraComprobante != null && ConsultaCabezal.LetraComprobante != "")
                        {
                            txtLetraComprobante.Text = ConsultaCabezal.LetraComprobante.ToUpper();
                            if (ConsultaCabezal.NumeroComprobante != "0")
                            {
                                txtPuntoVenta.Text = ConsultaCabezal.NumeroComprobante.Substring(0, 4);
                                txtNumeroComprobante.Text = ConsultaCabezal.NumeroComprobante.Substring(4, 8);
                            }
                            else
                            {
                                txtPuntoVenta.Text = "0000";
                                txtNumeroComprobante.Text = "00000000";
                            }
                            
                        }
                    }                   
                    lblEstadoComprobante.Text = ConsultaCabezal.Estado;

                    if(ConsultaCabezal.Estado == "FI")
                    {
                        lblEstadoComprobante.Text = "Finalizado";
                        lblEstadoComprobante.ForeColor = Color.ForestGreen;
                    }
                    if (ConsultaCabezal.Estado == "PEN")
                    {
                        lblEstadoComprobante.Text = "Pendiente";
                        lblEstadoComprobante.ForeColor = Color.ForestGreen;
                    }
                    if (ConsultaCabezal.Estado == "AN")
                    {
                        if (Accion == "3")
                        {
                            lblEstadoComprobante.Text = "";                         
                        }
                        else

                        {
                            lblEstadoComprobante.Text = "Anulado";
                            lblEstadoComprobante.ForeColor = Color.FromArgb(192, 0, 0);
                            btnCargar.Enabled = false;
                            btnInvalidar.Enabled = false;
                        }
                    }
                    //CUERPO
                    var CosnultaCuerpo = (from CCU in hb.INGRESOMERCADERIACUERPO
                                          where CCU.Ingreso_ID == IDRecibido
                                          select new
                                          {
                                              CCU.ID,
                                              Codigo = CCU.Insumo_ID,
                                              Articulo = CCU.Productos_Insumos.Descripcion,
                                              Cantidad = CCU.Cantidad,
                                              Costo = CCU.Costo
                                          }).ToList();

                    foreach (var item in CosnultaCuerpo)
                    {
                        dgvMercaderia.Rows.Add(
                                                item.ID,
                                                item.Codigo,
                                                item.Articulo,
                                                item.Cantidad,
                                                item.Costo
                                                );
                    }
                    lblItems.Text = dgvMercaderia.RowCount.ToString("N2");
                    CalcularTotal();                   
                }             
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtCodigoBarra.Focus();
            txtCodigoBarra.Select();
            AbrirFormAgregar("1");          
        }
        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigoBarra.TextLength > 0)
            {
                DataGridViewRow Fila = new DataGridViewRow();

                Fila.CreateCells(dgvMercaderia);

                Fila.Cells[1].Value = txtCodigoBarra.Text;
                Fila.Cells[2].Value = "Aceite";
                Fila.Cells[3].Value = 100;
                Fila.Cells[4].Value = 10;
                Fila.Cells[5].Value = 100 * 10;

                dgvMercaderia.Rows.Add(Fila);

                txtCodigoBarra.Text = "";
                txtCodigoBarra.Focus();
                txtCodigoBarra.Select();


            }
            CalcularTotal();
        }
        public void CalcularTotal()
        {
            if (dgvMercaderia.RowCount > 0)
            {
                decimal Total = 0;

                for (var i = 1; i <= dgvMercaderia.RowCount; i++)
                {
                    decimal TotalFila = 0;

                    string Cantidad = dgvMercaderia.Rows[i - 1].Cells["colCantidad"].Value.ToString();
                    string Costo = dgvMercaderia.Rows[i - 1].Cells["colCosto"].Value.ToString();

                    if (!Cantidad.Contains(",") && Cantidad.Contains("."))
                        Cantidad = Cantidad.ToString().Replace(".", ",");
                    else
                        Cantidad = Cantidad.ToString();

                    if (!Costo.Contains(",") && Costo.Contains("."))
                        Costo = Costo.ToString().Replace(".", ",");
                    else
                        Costo = Costo.ToString();

                    TotalFila = Convert.ToDecimal(Cantidad) * Convert.ToDecimal(Costo);
                    dgvMercaderia.Rows[i - 1].Cells["colImporteTotal"].Value = TotalFila.ToString("N2");
                    Total = Total + Convert.ToDecimal(dgvMercaderia.Rows[i - 1].Cells["colImporteTotal"].Value);
                }
                txtImporteTotal.Text = Total.ToString("N2");
            }
        }
        private void CargarDatos()
        {
            try
            {
                if (cmbMovimiento.SelectedIndex != -1
                   && cmbProveedor.SelectedIndex != -1
                   && dgvMercaderia.RowCount > 0)
                {
                    using (var hb = new DBdatos())
                    {
                        if (Accion != "") //AGREGAR o COPIAR
                        {
                            if (Accion == "2") // Si edita elimina todos los registros de ese ingreso
                            {
                                
                                var ConsultaCuerpoEliminar = (from E in hb.INGRESOMERCADERIACUERPO
                                                              where E.Ingreso_ID == IDRecibido
                                                              select E);

                                hb.INGRESOMERCADERIACUERPO.RemoveRange(ConsultaCuerpoEliminar);

                                var ConsultaEliminar = (from E in hb.INGRESOMERCADERIA
                                                              where E.ID == IDRecibido
                                                              select E);

                                hb.INGRESOMERCADERIA.RemoveRange(ConsultaEliminar);                             
                            }
                            //CABEZAL
                            long IDCabezal = 0;
                            string NumeroComprobante = "";
                            bool Error = false;

                            var N = new INGRESOMERCADERIA();

                            var ConsultaID = (from ID in hb.INGRESOMERCADERIA
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

                            N.Fecha = dtpFecha.Value;
                            N.Movimiento_ID = (int)cmbMovimiento.SelectedValue;
                            N.Proveedor_ID = (int)cmbProveedor.SelectedValue;
                            N.Estado = "FI";
                            //if (cmbEstado.Text == "Pendiente")
                            //    N.Estado = "PEN";
                            //if (cmbEstado.Text == "Finalizado")
                            //    N.Estado = "FI";                          

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
                                MessageBox.Show("Punto de venta incorrecto","Atencion");
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
                            try
                            {
                                //var ConsultaCabezal = (from CC in hb.INGRESOMERCADERIA
                                //                       where CC.NumeroComprobante == txtPuntoVenta.Text + txtNumeroComprobante.Text
                                //                       select CC).FirstOrDefault();

                                //if (ConsultaCabezal != null)
                                //{
                                //    MessageBox.Show("Ya hay ingreso cargado con la siguiente numeraciòn " + txtPuntoVenta.Text + " - " + txtNumeroComprobante.Text, "Atencion");
                                //    Error = true;
                                //}
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Numero de comprobante incorrecto", "Atencion");
                                Error = true;
                            }
                            if (Error == true)
                                return;

                           
                            N.NumeroComprobante = NumeroComprobante;
                            N.ImporteTotal = Convert.ToDecimal(txtImporteTotal.Text);
                            N.Observaciones = txtObservaciones.Text;
                            
                            hb.INGRESOMERCADERIA.Add(N);

                            // CUERPO
                            long IDinicial = 0;

                            var ConsultaCuerpoID = (from ID in hb.INGRESOMERCADERIACUERPO
                                                    orderby ID.ID descending
                                                    select ID).FirstOrDefault();

                            if (ConsultaCuerpoID == null)
                                IDinicial = 1;
                            else
                                IDinicial = ConsultaCuerpoID.ID + 1;

                            for (var i = 0; i < dgvMercaderia.RowCount; i++)
                            {
                                var NC = new INGRESOMERCADERIACUERPO();

                                if (i == 0)
                                    NC.ID = IDinicial;
                                else
                                    NC.ID = IDinicial + i;

                                NC.Ingreso_ID = IDCabezal;
                                NC.Insumo_ID = dgvMercaderia.Rows[i].Cells["colCodigo"].Value.ToString();
                                NC.Cantidad = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCantidad"].Value);
                                NC.Costo = Convert.ToDecimal(dgvMercaderia.Rows[i].Cells["colCosto"].Value);

                                hb.INGRESOMERCADERIACUERPO.Add(NC);
                            }
                            hb.SaveChanges();
                            MessageBox.Show("Datos cargados correctamente", "Atencion");
                            this.Hide();
                        }
                    }
                }          
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMercaderia.RowCount > 0)
            {
                if (dgvMercaderia.RowCount == 1)
                  //  txtImporteTotal.Text = "0,00";

                dgvMercaderia.Rows.Remove(dgvMercaderia.CurrentRow);
                CalcularTotal();
            }
        }
        private void AbrirFormAgregar(string Accion)
        {
            var f = new frmIngresoInsumoAgregar();
            if (Accion == "2" && dgvMercaderia.RowCount > 0 && dgvMercaderia.CurrentRow.Cells["colID"].Value.ToString() != "")
                f.IDRecibido = Convert.ToInt64(dgvMercaderia.CurrentRow.Cells["colID"].Value);
            else
            {

            }
            f.frmIngresoInsumo = this;
            f.DGV = dgvMercaderia;
            f.Accion = Accion;
            f.ShowDialog();
        }
        private void Anular()
        {
            try
            {
                DialogResult R = MessageBox.Show("¿Esta seguro que desea anular este ingreso", "Atención", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        var ConsultaCabezal = (from CC in hb.INGRESOMERCADERIA
                                               where CC.ID == IDRecibido
                                               select CC).FirstOrDefault();

                        if (ConsultaCabezal.Estado != "AN")
                            ConsultaCabezal.Estado = "AN";
                        else
                        {
                            MessageBox.Show("El ingreso ya fue anulado", "Atencion");
                            return;
                        }

                        hb.SaveChanges();
                        MessageBox.Show("Ingreso anulado correctamente", "Atencion");
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Error");
            }
        }

        private void dgvTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMercaderia.RowCount > 0)
            {
                bool Salir = false;
                try
                {
                    if (Salir == false)
                    {
                        string Valor = dgvMercaderia.CurrentRow.Cells[e.ColumnIndex].Value.ToString();
                        if (Valor.Contains("."))
                            Valor = Valor.Replace(".", ",");

                        Valor = (Convert.ToDecimal(Valor)).ToString("N2");
                        Salir = true;
                        dgvMercaderia.CurrentRow.Cells[e.ColumnIndex].Value = Valor;
                        CalcularTotal();
                    }
                }
                catch (Exception)
                {
                    dgvMercaderia.CurrentRow.Cells[e.ColumnIndex].Value = "0,00";
                }

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dgvTicket_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    string Valor = dgv.CurrentRow.Cells[e.ColumnIndex].Value.ToString();
            //    Valor = Valor.Replace(".", ",");

            //    Convert.ToDecimal(Valor);

            //    dgvMercaderia.CurrentRow.Cells[e.ColumnIndex].Value = Valor;

            //}
            //catch (Exception)
            //{
            //   // dgvMercaderia.CurrentRow.Cells[e.ColumnIndex].Value = "0,00";
            //}





            //CalcularTotal();
        }

        private void btnInvalidar_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void txtBuscaCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaProveedor.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbProveedor, txtBuscaProveedor, true, "PRO", 0);
                txtBuscaProveedor.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaProveedor.Visible = false;
                txtBuscaProveedor.Focus();
                e.Handled = true;
            }
        }

        private void cmbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboClientes(cmbProveedor, txtBuscaProveedor, false, "PRO", 0);
                txtBuscaProveedor.Focus();
                e.Handled = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            txtBuscaProveedor.Visible = true;
            txtBuscaProveedor.Select();
        }

        private void txtBuscaCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvMercaderia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          //  AbrirFormAgregar("2");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirFormAgregar("2");
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtPuntoVenta);
        }

        private void txtNumeroComprobante_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtNumeroComprobante);
        }

        private void txtLetraComprobante_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloLetras(txtLetraComprobante);
        }

        private void dgvMercaderia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvMercaderia_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotal();
        }

        private void dgvMercaderia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvMercaderia.RowCount > 0)
            //{
            if (this.dgvMercaderia.Columns[e.ColumnIndex].Name == "colCantidad")
            {
                try
                {
                    if (!e.Value.ToString().Contains(",") && e.Value.ToString().Contains("."))
                        e.Value = e.Value.ToString().Replace(".", ",");
                    else
                        e.Value = Convert.ToDecimal(e.Value).ToString("N2");

                }
                catch (Exception)
                {
                    e.Value = "0,00";
                }
            }
            if (this.dgvMercaderia.Columns[e.ColumnIndex].Name == "colCosto")
            {
                try
                {
                    if (!e.Value.ToString().Contains(",") && e.Value.ToString().Contains("."))
                        e.Value = e.Value.ToString().Replace(".", ",");
                    else
                        e.Value = Convert.ToDecimal(e.Value).ToString("N2");

                }
                catch (Exception)
                {
                    e.Value = "0,00";
                }
            }
            //    if (this.dgvMercaderia.Columns[e.ColumnIndex].Name == "colCosto")
            //    {
            //        try
            //        {
            //            string Valor = dgvMercaderia.CurrentRow.Cells[e.ColumnIndex].Value.ToString();

            //            if (!Valor.Contains(",") && Valor.Contains("."))
            //                Valor = Valor.Replace(".", ",");

            //            decimal Cantidad = Convert.ToDecimal(Valor);
            //            e.Value = Cantidad;
            //            //CalcularTotal();
            //        }
            //        catch (Exception)
            //        {
            //            e.Value = "0,00";
            //        }
            //    }
            //    if (this.dgvMercaderia.Columns[e.ColumnIndex].Name == "colImporteTotal")
            //    {
            //        try
            //        {
            //            string ValorCantidad = dgvMercaderia.CurrentRow.Cells["colCantidad"].Value.ToString();
            //            if (!ValorCantidad.Contains(",") && ValorCantidad.Contains("."))
            //                ValorCantidad = ValorCantidad.Replace(".", ",");

            //            string ValorCosto = dgvMercaderia.CurrentRow.Cells["colCosto"].Value.ToString();
            //            if (!ValorCosto.Contains(",") && ValorCosto.Contains("."))
            //                ValorCosto.Replace(".", ",");

            //            decimal Cantidad = Convert.ToDecimal(ValorCantidad) * Convert.ToDecimal(ValorCosto);
            //            e.Value = Cantidad;
            //        }
            //        catch (Exception)
            //        {
            //            e.Value = "0,00";
            //        }
            //    }
            //}
        }
        private void BuscarDatos()
        {
            try
            {
                for (int i = 0; i < dgvMercaderia.RowCount; i++)
                {
                    dgvMercaderia.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dgvMercaderia.Rows[i].DefaultCellStyle.SelectionBackColor = Color.PaleTurquoise;
                    dgvMercaderia.Rows[i].Visible = true;

                    if (chkFiltraArticulo.Checked)
                    {
                        if (dgvMercaderia.Rows[i].Cells["colCodigo"].Value.ToString() == cmbFiltraInsPro.SelectedValue.ToString())
                        {
                            dgvMercaderia.Rows[i].DefaultCellStyle.BackColor = Color.Coral;
                            dgvMercaderia.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Coral;
                            dgvMercaderia.Rows[i].Visible = true;
                        }                 
                        else
                        {
                            dgvMercaderia.Rows[i].Visible = false;
                        }
                    }
                   
                }



                //DataTable DT = new DataTable();

                    //foreach (DataGridViewColumn columna in this.dgvMercaderia.Columns)
                    //{

                    //}

                    //dgvMercaderia.DataSource = DT;

                    //var Consulta = (from C in DT.AsEnumerable()
                    //                select C).FirstOrDefault();

                    //dgvMercaderia.DataSource = DT;
                    ////for (int i = 0; i < dgvMercaderia.RowCount; i++)
                    ////{                  
                    ////    DT.Columns.Add(dgvMercaderia.Columns[i].Name);
                    ////}
                    //for (int i = 0; i < dgvMercaderia.RowCount; i++)
                    //{
                    //    DT.Rows.Add(dgvMercaderia.Rows[i].Cells[])
                    //}
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ImprimirPrecios()
        {
            try
            {
                DialogResult R = MessageBox.Show("Esta seguro que desea imprimir los precios de esta compra?. Total de articulos : " + lblItems.Text, "Atención", MessageBoxButtons.YesNoCancel);
                if (R == DialogResult.Yes)
                {
                    if (dgvMercaderia.RowCount > 0)
                    {


                        using (var hb = new DBdatos())
                        {
                            List<string> ProductosYaImpresos = new List<string>();

                            for (int i = 0; i < dgvMercaderia.RowCount; i++)
                            {
                                string CodigoProducto = dgvMercaderia.Rows[i].Cells["colCodigo"].Value.ToString();



                                var ConsultaLP = (from C in hb.LISTAPRECIOCUERPO
                                                  where C.Articulo_ID == CodigoProducto
                                                    && C.ListaPrecio_ID == 1
                                                    && !ProductosYaImpresos.Contains(C.Articulo_ID)
                                                  select C).FirstOrDefault();

                                if (ConsultaLP != null)
                                {
                                    ProductosYaImpresos.Add(CodigoProducto);
                                    C.ImprimirEtiquetaPrecio(ConsultaLP.ID, dgvMercaderia, true);
                                }

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
        private void dgvMercaderia_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new frmIngresoInsumoAsistente();
            f.WindowState = FormWindowState.Maximized;
            f.FormInsumo = this;
            pnlAsistente.Visible = false;
            f.Accion = "Compra";
            f.Show();
            //if(pnlAsistente.Visible)
            //    pnlAsistente.Visible = false;
            //else
            //    pnlAsistente.Visible = true;
        }

        private void btnAsistenteOK_Click(object sender, EventArgs e)
        {
            var f = new frmIngresoInsumoAsistente();
            f.WindowState = FormWindowState.Maximized;
            pnlAsistente.Visible = false;
            f.Accion = "Compra";
            f.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
            Reutilizables.ReubicarFiltros(gbxFiltros, pnlInferior, btnMostrarfiltros);
        }

        private void chkFiltraArticulo_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraArticulo, cmbFiltraInsPro, txtBuscaInsPro, btnBuscarInsPro, "INS", "NO");
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsPro, txtBuscaInsPro,"INS" ,true, "NO");
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
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsPro, txtBuscaInsPro, "INS",false, "NO");
            }
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }

        private void txtBuscaProveedor_Click(object sender, EventArgs e)
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

        private void txtBuscaInsPro_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void btnImprimirPrecios_Click(object sender, EventArgs e)
        {
            ImprimirPrecios();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void txtImporteTotal_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtImporteTotal);
        }
    }
}