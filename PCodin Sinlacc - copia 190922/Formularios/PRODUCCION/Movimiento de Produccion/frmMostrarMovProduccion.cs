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
using PCodin_Sinlacc.Formularios.Movimiento_de_Produccion;
using PCodin_Sinlacc.Formularios.Deposito;
using PCodin_Sinlacc.Clases.UsuarioTema;
using System.Drawing.Printing;
using PCodin_Sinlacc.Properties;
using PCodin_Sinlacc.Formularios.PRODUCCION.Movimiento_de_Produccion;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmMostrarMovProduccion : Form
    {
        public frmMostrarMovProduccion()
        {
            InitializeComponent();
        }
        public frmDeposito FormularioDeposito;
        public frmDeposito2 FormularioDeposito2;
        public frmMenu FormularioMenu;
        public int UsuarioID;
        public Panel PanelCental;
        private frmPantallaEspera PantallaEspera = new frmPantallaEspera();
        private frmReporte VisorReporte = new frmReporte();

        private void AbrirformAgregarEditarProducto(string AgregarEditar, long ID , Panel PanelCental)
        {
            var f = new frmAgregarProdcutoTerminado();
            //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarNuevoPedido_FormClosed);
            f.FormularioDeposito = FormularioDeposito;
            f.FormularioDeposito2 = FormularioDeposito2;
            f.CrearEditar = AgregarEditar;
            f.FormularioAgregar = f;
            f.FormularioMenu = FormularioMenu;
            f.UsuarioID = UsuarioID;
            f.IdRecibido = ID;
            
           // PanelCental.Controls.Add(f);
            AddOwnedForm(f);
            
            f.WindowState = FormWindowState.Maximized;
            f.TopLevel = false;
            this.Controls.Add(f);
            this.Tag = f;
            //f.BringToFront();
            f.Show();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirformAgregarEditarProducto("1", 0 , PanelCental);
        }
        private void frmMostrarMovProduccion_Load(object sender, EventArgs e)
        {
            Reutilizables.RenderizarForm(this);
            clsUsuarioTema.UsuarioTema(UsuarioID, pnlSuperior, pnlInferior,this);
            dtpFechaHasta.Value = DateTime.Now.Date;
            dtpFechaDesde.Value = DateTime.Now.Date.AddDays(-30);
            //MostrarDatos();

            clsNotificacion.MostrarCantidadNotificacionesNoLeidas(FormularioMenu.lblCantidadNotificaciones);
            //LLenarComboOrdenar();
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from EMP in hb.Existencia_ProductoTerminado
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
                                    EMP.Lote,
                                    EMP.Medida_ID,
                                    Medida = EMP.Medidas_Producto.Descripcion,
                                    EMP.Empleado_ID,
                                    Empleado = EMP.Empleados.Nombre,
                                    EMP.Cantidad,
                                    EMP.Cantidad_Utiliz,
                                    Disponible = EMP.Cantidad - EMP.Cantidad_Utiliz,
                                    EMP.Ficha,
                                    EMP.Retencion,
                                    EMP.Estado_ID,                                   
                                    OrdenAsociada = EMP.Orden_Produccion.NumeroOrden,
                                    Estado = EMP.Estado_ExistenciaProductoTerminado.Descripcion,
                                    EMP.Deposito,
                                    EMP.Productos_Insumos.Categoria_ID,
                                    //EMP.OrdenProduccion_ID,
                                    EMP.OrdenProduccionParteCuerpo.Orden_Produccion_Parte.OrdenProduccion_Cuerpo.Orden_Produccion.NumeroOrden,
                                    //EMP.Orden_Produccion.NumeroOrden,
                                    EMP.Observaciones,
                                    NumeroOrdenCarga = EMP.Orden_Carga.Numero_Orden,
                                    EMP.OrdenCargaID,
                                    EMP.Productos_Insumos.Pallet
                                });

                if (cmbOrdenar.SelectedIndex == 1) // FECha
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Numero_Produccion descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Numero_Produccion ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 2) // FECha
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Fecha descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Fecha ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 3)
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Movimiento descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Movimiento ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 4) // Codigo de producto
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Produto_ID descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Produto_ID ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 5) // Producto
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Producto descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Producto ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 6) // Cantidad
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Cantidad descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Cantidad ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 7) // Cantidad
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Cantidad_Utiliz descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Cantidad_Utiliz ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 8) // Cantidad
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Disponible descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Disponible ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 9) // Medida
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Medida descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Medida ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 10) // Retencion
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Retencion descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Retencion ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 11) // Ficha
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Ficha descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Ficha ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 12) // Estado
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Estado descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Estado ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 13) // Estado
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Empleado descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Empleado ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 14) // Estado
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.NumeroOrden descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.NumeroOrden ascending
                                    select C);
                }

                if (chkFiltraMovimiento.Checked)
                    Consulta = (from C in Consulta
                                where C.Movimiento_ID == cmbFiltraMovimiento.SelectedValue.ToString()
                                select C);

                if (chkFiltraInsPro.Checked)
                    Consulta = (from C in Consulta
                                where C.Produto_ID == cmbFiltraInsPro.SelectedValue.ToString()
                                select C);

                if (chkFiltraCategoria.Checked)
                    Consulta = (from C in Consulta
                                where C.Categoria_ID == (int)cmbFiltraCategoria.SelectedValue
                                select C);

                if (chkFiltraEstado.Checked)
                    Consulta = (from C in Consulta
                                where C.Estado_ID == cmbFiltraEstado.Text
                                select C);

                if (chkFiltraRetencion.Checked)
                    Consulta = (from C in Consulta
                                where C.Retencion == cmbFiltraRetencion.Text
                                select C);

                if (chkFiltraFicha.Checked)
                    Consulta = (from C in Consulta
                                where C.Ficha == cmbFiltraFicha.Text
                                select C);

                if (chkFiltraOrdenProduccion.Checked)
                    Consulta = (from C in Consulta
                                where C.NumeroOrden == txtFiltraNumOrden.Text
                                    || C.OrdenAsociada == txtFiltraNumOrden.Text
                                select C);

                if (chkFiltraLote.Checked)
                {                  
                    string Lote = dtpLote.Value.ToShortDateString();
                    Lote = Lote.Replace("/", "");
                    //Lote = Lote.Insert(2, "/");
                    //Lote = Lote.Insert(5, "/");

                    Consulta = (from C in Consulta
                                where C.Lote == Lote
                                select C);
                }
                if (chkNumeroProduccion.Checked)
                    Consulta = (from C in Consulta
                                where C.Numero_Produccion == txtFiltraNumProduccion.Text
                                select C);

                if (chkFiltraOrdenCarga.Checked)
                    Consulta = (from C in Consulta
                                where C.OrdenCargaID == Convert.ToInt64(txtFiltraOrdenCarga.Text)
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

                if (chkMuestraPallets.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Pallet == "SI"
                                select C);
                }
                else
                {
                    Consulta = (from C in Consulta
                                where C.Pallet == "NO"
                                select C);
                }


                var Resultado = Consulta.Take(1000).ToList();

                colFecha.Visible = true;
                colMovimiento.Visible = true;
                colRetencion.Visible = true;
                colFicha.Visible = true;
                colObservacion.Visible = true;
                colEmpleado.Visible = true;
                colEstado.Visible = true;

                colID.DataPropertyName = "ID";
                colNumeroProduccion.DataPropertyName = "Numero_Produccion";
                colFecha.DataPropertyName = "Fecha";
                colLote.DataPropertyName = "Lote";
                colMovimiento.DataPropertyName = "Movimiento";
                colCodigo.DataPropertyName = "Produto_ID";
                colProducto.DataPropertyName = "Producto";
                colCantidad.DataPropertyName = "Cantidad";
                colCantidadUtiliz.DataPropertyName = "Cantidad_Utiliz";
                colCantidadDisponible.DataPropertyName = "Disponible";
                colNumOrdenCarga.DataPropertyName = "NumeroOrdenCarga";
                colOrdenCargaID.DataPropertyName = "OrdenCargaID";
                colMedida.DataPropertyName = "Medida";
                colRetencion.DataPropertyName = "Retencion";
                colFicha.DataPropertyName = "Ficha";
                colEstado.DataPropertyName = "Estado";
                colEmpleado.DataPropertyName = "Empleado";
                colNumOrdenProd.DataPropertyName = "NumeroOrden";
                colOrdenAsociada.DataPropertyName = "OrdenAsociada";
                colObservacion.DataPropertyName = "Observaciones";

                lblResultados.Text = Resultado.Count.ToString();

                dgvMovimientoProduccion.AutoGenerateColumns = false;
                dgvMovimientoProduccion.DataSource = Resultado;
            }
        }
        private void MostrarProductosAgrupados()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from EPT in hb.Existencia_ProductoTerminado
                                group EPT by new
                                {
                                    EPT.Produto_ID,
                                    Producto = EPT.Productos_Insumos.Descripcion,
                                    //EPT.Estado_ID,
                                    //Estado = EPT.Estado_Pedido_Cuerpo.Descripcion,
                                    EPT.Medida_ID,
                                    Medida = EPT.Medidas_Producto.Descripcion,
                                    EPT.Productos_Insumos.Categoria_ID,
                                    EPT.Fecha
                                } into Grupo
                                orderby Grupo.Key.Fecha descending, Grupo.Key.Produto_ID
                                select new
                                {
                                    Grupo.Key.Produto_ID,
                                    Grupo.Key.Producto,
                                    Grupo.Key.Medida_ID,
                                    Grupo.Key.Medida,
                                    //Grupo.Key.Estado_ID,
                                    //Grupo.Key.Estado,
                                    Grupo.Key.Categoria_ID,
                                    Grupo.Key.Fecha,
                                    Cantidad = Grupo.Sum(x => x.Cantidad)
                                }).Take(1000);

                if (cmbOrdenar.SelectedIndex == 1) // FECha
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Fecha descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Fecha ascending
                                    select C);
                }             
                if (cmbOrdenar.SelectedIndex == 2) // Codigo de producto
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Produto_ID descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Produto_ID ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 3) // Producto
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Producto descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Producto ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 4) // Cantidad
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Cantidad descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Cantidad ascending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 5) // Medida
                {
                    if (btnBuscarDesc.Visible)
                        Consulta = (from C in Consulta
                                    orderby C.Medida descending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Medida ascending
                                    select C);
                }                

                //if (chkFiltraCodigo.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Produto_ID == txtFiltraCodigo.Text
                //                select C);

                //if (chkFiltraDescripion.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Producto.StartsWith(txtFiltraDescripcion.Text)
                //                    || C.Producto.Contains(txtFiltraDescripcion.Text)
                //                select C);

                if (chkFiltraInsPro.Checked)
                    Consulta = (from C in Consulta
                                where C.Produto_ID == cmbFiltraInsPro.SelectedValue.ToString()
                                select C);

                if (chkFiltraCategoria.Checked)
                    Consulta = (from C in Consulta
                                where C.Categoria_ID == (int)cmbFiltraCategoria.SelectedValue
                                select C);

                //if (chkFiltraEstado.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Estado_ID == cmbFiltraEstado.Text
                //                select C);

                var Resultados = Consulta.ToList();

                //colFecha.Visible = false;
                colMovimiento.Visible = false;
                colRetencion.Visible = false;
                colFicha.Visible = false;
                colObservacion.Visible = false;
                colEmpleado.Visible = false;
                colEstado.Visible = false;

                colFecha.DataPropertyName = "Fecha";
                colCodigo.DataPropertyName = "Produto_ID";
                colProducto.DataPropertyName = "Producto";
                colCantidad.DataPropertyName = "Cantidad";
                colMedida.DataPropertyName = "Medida";
                colEstado.DataPropertyName = "Estado";

                dgvMovimientoProduccion.AutoGenerateColumns = false;
                dgvMovimientoProduccion.DataSource = Resultados;

                lblResultados.Text = Resultados.Count.ToString();
            }
        }
        private void EliminarProductos()
        {
            if (dgvMovimientoProduccion.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Está seguro que desea eliminar los productos selecionados?", "Atención",MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    long ID = (long)dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colID"].Value;
                    using (var hb = new DBdatos())
                    {
                        var ConsultaTTEPT = (from TTEPT in hb.TT_Existencia_ProductoTerminado
                                             where TTEPT.IDaModificar == ID
                                             select TTEPT).ToList();


                        var ConsultaInsumoProducto = (from IP in hb.ExistenciaProducto_ExistenciaInsumo
                                                      where IP.ExitenciaProducto_ID == ID
                                                      select IP).ToList();

                        hb.ExistenciaProducto_ExistenciaInsumo.RemoveRange(ConsultaInsumoProducto);
                        hb.TT_Existencia_ProductoTerminado.RemoveRange(ConsultaTTEPT);

                        var Consulta = (from EPT in hb.Existencia_ProductoTerminado
                                        where EPT.ID == ID
                                        select EPT).FirstOrDefault();
                   
                        if (Consulta != null && Consulta.Estado_ID == "AN")
                        {
                            hb.Existencia_ProductoTerminado.Remove(Consulta);
                            hb.SaveChanges();
                            MostrarDatos();
                        }
                        else
                        {
                            MessageBox.Show("Solo se pueden eliminar producciones en estado 'Anulado' ", "Atención");
                            return;
                        }
                    }
                }
            }
        }
        
        private void LLenarComboOrdenar()
        {
            //cmbOrdenar.Items.Clear();

            //cmbOrdenar.Items.Add("");
            //cmbOrdenar.Items.Add("Fecha");
            //cmbOrdenar.Items.Add("Movimiento");
            //cmbOrdenar.Items.Add("Codigo");
            //cmbOrdenar.Items.Add("Producto");
            //cmbOrdenar.Items.Add("Cantidad");
            //cmbOrdenar.Items.Add("Medida");
            //cmbOrdenar.Items.Add("Retencion");
            //cmbOrdenar.Items.Add("Ficha");
            //cmbOrdenar.Items.Add("Estado");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportExcel(dgvMovimientoProduccion);
           // Reutilizables.ExportarExcel(dgvMovimientoProduccion);
        }
        private void MostrarEstadosEnColores(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMovimientoProduccion.RowCount > 0)
            {
                if (this.dgvMovimientoProduccion.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "Pendiente")
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                    }
                    if (e.Value.ToString() == "Entregado")
                    {
                        e.CellStyle.ForeColor = Color.Green;
                        e.CellStyle.SelectionForeColor = Color.Green;
                    }
                }
            }
        }
        private void FormatearCeldas(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMovimientoProduccion.RowCount > 0)
            {
                if (this.dgvMovimientoProduccion.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "Entregado")
                    {
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.Green;
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                    }
                }
                if (this.dgvMovimientoProduccion.Columns[e.ColumnIndex].Name == "colCantidad")
                {
                    e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                }
                if (this.dgvMovimientoProduccion.Columns[e.ColumnIndex].Name == "colCantidadUtiliz")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                    e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                }
                if (this.dgvMovimientoProduccion.Columns[e.ColumnIndex].Name == "colCantidadDisponible")
                {
                    e.CellStyle.ForeColor = Color.DarkGreen;
                    e.CellStyle.SelectionForeColor = Color.DarkGreen;
                    e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                }
            }
        }
        private void MostrarPantallaEspera(Image Gif)
        {
            PantallaEspera = new frmPantallaEspera();
            VisorReporte = new frmReporte();
            PantallaEspera.picGif.Image = Gif;
            PantallaEspera.textBox1.Text = "Imprimiendo Etiquetas";

            PantallaEspera.Shown += new System.EventHandler(frmPantallaEspera_Shown);
            PantallaEspera.ShowDialog();
        }

        private void frmPantallaEspera_Shown(object sender, EventArgs e)
        {
            try
            {
                //frmReporte frmReporte = new frmReporte();
                if (dgvMovimientoProduccion.CurrentRow.Cells["colOrdenCargaID"].Value.ToString() != "")
                {
                    long OrdenCargaID = Convert.ToInt64(dgvMovimientoProduccion.CurrentRow.Cells["colOrdenCargaID"].Value);
                    long ExistenciaProductoID = Convert.ToInt64(dgvMovimientoProduccion.CurrentRow.Cells["colID"].Value);

                   //clsQueryPlantillas.EtiquetaCarga001(OrdenCargaID, VisorReporte, "Individual", ExistenciaProductoID, Convert.ToInt32(txtNumCopias.Value), cmbImpresoras.Text);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            PantallaEspera.Close();
        }

        private void dgvMovimientoProduccion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMovimientoProduccion.RowCount > 0)
            {
                long ID = (long)dgvMovimientoProduccion.CurrentRow.Cells[0].Value;
                AbrirformAgregarEditarProducto("2", ID, PanelCental);
            }
        }
        private void dgvMovimientoProduccion_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void chkFiltraCodigo_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkFiltraDescripion_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkFiltraInsPro_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, btnBuscarInsPro,"PRO", "NO");
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, btnBuscarInsPro, "PRO", "NO");
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
                Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, btnBuscarInsPro, "PRO", "NO");
            }
        }

        private void chkFiltraMovimiento_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraMovimiento, cmbFiltraMovimiento);
            clsCargarCombos.MostrarCombomMovProduccion(cmbFiltraMovimiento,"PRO");
        }

        private void chkFiltraCategoria_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCategorias(chkFiltraCategoria, cmbFiltraCategoria, txtBuscaCategoria, btnBuscarCategoria);
        }

        private void txtBuscaCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaCategoria.Visible = false;
                clsCargarCombos.MostrarCategorias(cmbFiltraCategoria, txtBuscaCategoria, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaCategoria.Visible = false;
                //  clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, false);
            }
        }

        private void cmbFiltraCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarCategorias(cmbFiltraCategoria, txtBuscaCategoria, false);
            }
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            txtBuscaCategoria.Visible = true;
            txtBuscaCategoria.Select();
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbFiltraEstado);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void rdbAgrupado_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarProductos();
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatos();
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            //MostrarDatos();Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatos();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (dgvMovimientoProduccion.RowCount > 0)
            {
                long ID = (long)dgvMovimientoProduccion.CurrentRow.Cells[0].Value;
                AbrirformAgregarEditarProducto("3", ID, PanelCental);
            }
        }
        private void AbrirFormRelaciones()
        {
            if (dgvMovimientoProduccion.RowCount > 0)
            {
                long ID = (long)dgvMovimientoProduccion.CurrentRow.Cells[0].Value;

               



                var f = new frmRelacionesMovProduccion();
                f.IDRecibido = ID;
                f.Formulario = "EPT";

                if (dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colNumOrdenProd"].Value != null)
                    f.NumeroOrden = dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colNumOrdenProd"].Value.ToString();

                if (dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colOrdenAsociada"].Value != null)
                    f.NumeroOrdenAsociada = dgvMovimientoProduccion.CurrentRow.Cells[columnName: "colOrdenAsociada"].Value.ToString();

                f.Show();
            }
            
        }
        private void AbrirFormLotes()
        {
            var f = new frmLotes();
            f.ShowDialog();
        }
        private void btnRelaciones_Click(object sender, EventArgs e)
        {
            AbrirFormRelaciones();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void btnRelacion_Click(object sender, EventArgs e)
        {
            AbrirFormRelaciones();
        }

        private void dgvMovimientoProduccion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMovimientoProduccion.RowCount > 0)
            {
                long ID = (long)dgvMovimientoProduccion.CurrentRow.Cells[0].Value;

                AbrirformAgregarEditarProducto("2", ID , PanelCental);
            }
        }

        private void btnBuscarDesc_Click_1(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            //MostrarDatos();Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatos();
        }

        private void chkFiltraLote_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDateTime(chkFiltraLote, dtpLote);
        }

        private void chkFiltraOrdenProduccion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraNumOrden, chkFiltraOrdenProduccion);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraOrdenCarga , chkFiltraOrdenCarga);
        }

        private void btnEtiqueta_Click(object sender, EventArgs e)
        {
            if(dgvMovimientoProduccion.RowCount > 0)
            {
                if(pnlImpresionEtiqueta.Visible == false)
                {
                    String pkInstalledPrinters;
                    for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                    {
                        pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                        cmbImpresoras.Items.Add(pkInstalledPrinters);
                    }

                    int Cantidad = Convert.ToInt32(dgvMovimientoProduccion.CurrentRow.Cells["colCantidad"].Value);
                    pnlImpresionEtiqueta.Visible = true;
                    txtNumCopias.Value = Cantidad;

                    
                    pnlImpresionEtiqueta.Location = new System.Drawing.Point(btnEtiqueta.Location.X, dgvMovimientoProduccion.Location.Y);
                }
                else
                    pnlImpresionEtiqueta.Visible = false;
            }  
        }

        private void btnImprimirEtiqueta_Click(object sender, EventArgs e)
        {
            MostrarPantallaEspera(Properties.Resources.codigo_qr);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlImpresionEtiqueta.Visible = false;
        }

        private void pnlImpresionEtiqueta_Leave(object sender, EventArgs e)
        {
            pnlImpresionEtiqueta.Visible = false;
        }

        private void pnlImpresionEtiqueta_MouseLeave(object sender, EventArgs e)
        {
            pnlImpresionEtiqueta.Visible = false;
        }

        private void dgvMovimientoProduccion_Click(object sender, EventArgs e)
        {
            pnlImpresionEtiqueta.Visible = false;
        }

        private void pnlImp1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbImpresoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbImpresoras.SelectedIndex != -1)
                btnImprimirEtiqueta.Enabled = true;
            else
                btnImprimirEtiqueta.Enabled = false;
        }

        private void chkNumeroProduccion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraNumProduccion, chkNumeroProduccion);
        }

        private void btnLotes_Click(object sender, EventArgs e)
        {
            AbrirFormLotes();
        }

        private void txtBuscaCategoria_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraNumProduccion_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraOrdenCarga_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
