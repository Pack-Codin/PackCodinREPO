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
using PCodin_Sinlacc.Formularios.ESTADISTICAS.Informes;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using PCodin_Sinlacc.Clases.Notificaciones_Ejecutables.Produccion;
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Datos.Models;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmControlStock : Form
    {
        private string InsProd = "PRO";
        DateTime FechaStock;
        string Imprime;
        public int UsuarioID;
        public frmReporte FormularioReporte;

        public frmControlStock()
        {
            InitializeComponent();
        }
        private void TraerFechaStock()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from FS in hb.StockFecha
                                orderby FS.ID descending
                                select FS).FirstOrDefault();

                if (Consulta == null)
                    FechaStock = Convert.ToDateTime("01/01/2000");
                else
                    FechaStock = Consulta.Fecha_Stock;
            }
        }
        private void frmControlStock_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior,this);
            Reutilizables.RenderizarForm(this);
            TraerFechaStock();
            MostrarExistenciaProductosPorLote();
            btnProductos.BackColor = Color.DarkOrange;

            using (var hb = new DBdatos())
            {
                var ConsultaUsuario = (from U in hb.Usuarios
                                       where U.ID == UsuarioID
                                       select U).FirstOrDefault();

                if (ConsultaUsuario.Monetizado == "SI")
                    cmsBtnStockMonetizado.Visible = true;
                else
                    cmsBtnStockMonetizado.Visible = false;
            }
        }
        private void MostrarExistenciaSubpructos()
        {
            using (var hb = new DBdatos())
            {

                //var Consulta = (from c in hb.ftVistaStockSubproducto()
                //            select c);



                //var Consulta = (from OPPC in hb.OrdenProduccionParteCuerpo
                //                group new { OPPC } by new 
                //                {
                //                    OPPC.Orden_Produccion_Parte.Insumo_ID ,
                //                       Insumo = OPPC.Orden_Produccion_Parte.Productos_Insumos.Descripcion,
                //                       MedidaID = OPPC.Orden_Produccion_Parte.Productos_Insumos.Medida,
                //                       Medida = OPPC.Orden_Produccion_Parte.Productos_Insumos.Medidas_Producto.Descripcion,
                //                       SeccionID = OPPC.Orden_Produccion_Parte.Seccion_ID,
                //                       Seccion = OPPC.Orden_Produccion_Parte.Seccion.Descripcion
                                       
                //                } into Grupo
                //                select new
                //                {
                //                    Grupo.Key.Insumo_ID,
                //                    Grupo.Key.Insumo,
                //                    Grupo.Key.Medida,
                //                    Grupo.Key.Seccion,
                //                    Existencia = Grupo.Sum(x => x.OPPC.Cantidad),
                //                    Pendiente = Grupo.Sum(x => x.OPPC.Orden_Produccion_Parte.Cantidad - x.OPPC.Cantidad),
                //                  //  Pendiente2 = Grupo.Sum(x => x.OPPC.Orden_Produccion_Parte.Cantidad),                     
                //                });

                //var Resultados = Consulta.ToList();

                //colPuntoPedido.Visible = true;

                //colExistenciaReal.Visible = true;
                //colExistenciaRef.Visible = false;
                //colPendiente.Visible = true;
                //colPendienteRef.Visible = false;
                //colStockRealRef.Visible = false;

                //colInsProdID.DataPropertyName = "Insumo_ID";
                //colInsPro.DataPropertyName = "Insumo";
                //colExistencia.DataPropertyName = "Existencia";
                //colPendiente.DataPropertyName = "Pendiente";
                //colExistenciaReal.DataPropertyName = "StockReal";
                //colMedida.DataPropertyName = "Medida";
                //colStockMin.DataPropertyName = "Stockmin";
                //colPuntoPedido.DataPropertyName = "PuntoPedido";

                //dgvStock.AutoGenerateColumns = false;
                //dgvStock.DataSource = Resultados;
            }
        }
        private void MostrarExistenciaInsumos()
        {
            using (var hb = new DBdatos())
            {
                
                var Consulta = (from VSI in hb.ftStockInsumos3(FechaStock)
                                join INS in hb.Productos_Insumos on VSI.InsumoID equals INS.Codigo
                                where INS.Estado == "SI"
                                orderby VSI.Insumo
                                select new
                                {
                                    VSI.InsumoID,
                                    VSI.Insumo,
                                    VSI.Existencia,
                                    VSI.Medida,
                                    VSI.CategoriaID,
                                    VSI.StockMin,
                                    VSI.PuntoPedido,
                                    VSI.ValorUnidadPeso,
                                    VSI.ValorUnidadDolar,                                   
                                });

                if (chkFiltraInsumo.Checked)
                    Consulta = (from C in Consulta
                                where C.InsumoID == cmbFiltraInsumo.SelectedValue.ToString()
                                select C);

                if (chkFiltraCategoria.Checked)
                    Consulta = (from C in Consulta
                                where C.CategoriaID == (int)cmbFiltraCategoria.SelectedValue
                                select C);

                if (rdbFiltraBajoStock.Checked)
                    Consulta = (from C in Consulta
                                where C.Existencia <= C.StockMin
                                select C);

                if (rdbFiltraStock.Checked)
                    Consulta = (from C in Consulta
                                where C.Existencia > C.StockMin
                                select C);

                var Resultados = Consulta.ToList();

                colPuntoPedido.Visible = true;

                colExistenciaReal.Visible = false;
                colExistenciaRef.Visible = false;
                colPendiente.Visible = false;
                colPendienteRef.Visible = false;
                colStockRealRef.Visible = false;
                colPendProducir.Visible = false;
                colStockMin.Visible = true;
                colStockRealPallet.Visible = false;
                colExistenciaPallet.Visible = false;
                colPendEntregaPallet.Visible = false;

                colInsProdID.DataPropertyName = "InsumoID";
                colInsPro.DataPropertyName = "Insumo";
                colExistencia.DataPropertyName = "Existencia";
                colMedida.DataPropertyName = "Medida";
                colStockMin.DataPropertyName = "StockMin";
                colPuntoPedido.DataPropertyName = "PuntoPedido";
                colValorUnidadPeso.DataPropertyName = "ValorUnidadPeso";
                colValorUnidadDolar.DataPropertyName = "ValorUnidadDolar";

                dgvStock.AutoGenerateColumns = false;
                dgvStock.DataSource = Resultados;
            }
        }
        private void MostrarExistenciaInsumosaVIEJO()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from E in hb.Existencia_Insumos
                                join VPP in hb.Vista_CalcularPuntoPedido on E.Insumo_ID equals VPP.Codigo
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
                                });
          
                if (chkFiltraProducto.Checked)
                    Consulta = (from C in Consulta
                                where C.Insumo_ID == cmbFiltraProducto.SelectedValue.ToString()
                                select C);

                if (chkFiltraCategoria.Checked)
                    Consulta = (from C in Consulta
                                where C.Categoria == (int)cmbFiltraCategoria.SelectedValue
                                select C);

                if (rdbFiltraBajoStock.Checked)
                    Consulta = (from C in Consulta
                                where C.Existencia <= C.Stockmin
                                select C);

                if (rdbFiltraStock.Checked)
                    Consulta = (from C in Consulta
                                where C.Existencia > C.Stockmin
                                select C);

                var Resultados = Consulta.ToList();

                colPuntoPedido.Visible = true;

                colExistenciaReal.Visible = false;
                colExistenciaRef.Visible = false;
                colPendiente.Visible = false;
                colPendienteRef.Visible = false;
                colStockRealRef.Visible = false;
                colPendProducir.Visible = false;
                colStockMin.Visible = true;

                colInsProdID.DataPropertyName = "Insumo_ID";
                colInsPro.DataPropertyName = "Insumo";
                colExistencia.DataPropertyName = "Existencia";
                colMedida.DataPropertyName = "Medida";
                colStockMin.DataPropertyName = "Stockmin";
                colPuntoPedido.DataPropertyName = "PuntoPedido";

                dgvStock.AutoGenerateColumns = false;
                dgvStock.DataSource = Resultados;
            }
        }
        
        private void MostrarExistenciaProductos()
        {
            using (var hb = new DBdatos())
            {
                int CiudadID;
                string Lote = "";

                var ConsultaFecha = (from F in hb.StockFecha
                                     orderby F.Fecha_Stock descending
                                     select F).FirstOrDefault();

                var ConsultaUsuario = (from U in hb.Usuarios
                                       where U.ID == UsuarioID
                                       select U).FirstOrDefault();

                if (ConsultaFecha == null)
                    FechaStock = Convert.ToDateTime("01/01/2000");
                else
                    FechaStock = ConsultaFecha.Fecha_Stock;

                if (chkFiltraCiudad.Checked && cmbCiudad.SelectedIndex != -1)
                {
                    CiudadID = (int)cmbCiudad.SelectedValue;
                }
                else
                {
                    CiudadID = 0;
                }

                if(chkFiltraLote.Checked)
                {
                    try
                    {
                        Lote = dtpFiltraLote.Value.ToShortDateString().Replace("/", "");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }

                }

                var Consulta = hb.Database.SqlQuery<FTSTOCKPRODUCTOFINAL>(
    "SELECT * FROM dbo.ftStockProductoFinal(@p0, @p1, @p2)",
    FechaStock, CiudadID, Lote
).Take(500);

                //var Consulta = (from VS in hb.ftStockProductoFinal003(FechaStock, CiudadID, Lote)
                //                join PRO in hb.Productos_Insumos on VS.ProductoID equals PRO.Codigo
                //                where PRO.Estado == "SI"
                //                orderby VS.ProductoID
                //                select new
                //                {
                //                    VS.ProductoID,
                //                    VS.Producto,
                //                    VS.Medida,
                //                    VS.Existencia,
                //                    VS.ExistenciaPallets,
                //                    VS.PendienteEntrega,
                //                    VS.PendienteEntregarPallets,
                //                    VS.StockReal,
                //                    VS.StockRealPallets,
                //                    VS.PendienteProducir,
                //                    VS.StockMinimo,
                //                    VS.CategoriaID,
                //                    VS.ExistenciaRef,
                //                    VS.PendienteEntregarRef,
                //                    VS.StockRealRef,
                //                    VS.PendienteProducirRef,
                //                    VS.ValorUnidadPeso,
                //                    VS.ValorUnidadDolar


                //                }).Take(1000);

                //    if (cmbOrdenar.SelectedIndex == 1) // Codigo
                //    {
                //        if (btnBuscarAsc.Visible == true)
                //            Consulta = (from C in Consulta
                //                        orderby C.ProductoID ascending
                //                        select C);
                //        else
                //            Consulta = (from C in Consulta
                //                        orderby C.ProductoID descending
                //                        select C);
                //    }
                //    if (cmbOrdenar.SelectedIndex == 2) // Descripcion
                //    {
                //        if (btnBuscarAsc.Visible == true)
                //            Consulta = (from C in Consulta
                //                        orderby C.Producto ascending
                //                        select C);
                //        else
                //            Consulta = (from C in Consulta
                //                        orderby C.Producto descending
                //                        select C);
                //    }
                //    if (cmbOrdenar.SelectedIndex == 3) // Existencia
                //    {
                //        if (btnBuscarAsc.Visible == true)
                //            Consulta = (from C in Consulta
                //                        orderby C.Existencia ascending
                //                        select C);
                //        else
                //            Consulta = (from C in Consulta
                //                        orderby C.Existencia descending
                //                        select C);
                //    }
                //    if (cmbOrdenar.SelectedIndex == 4) // Pendiente de entrega
                //    {
                //        if (btnBuscarAsc.Visible == true)
                //            Consulta = (from C in Consulta
                //                        orderby C.PendienteEntrega ascending
                //                        select C);
                //        else
                //            Consulta = (from C in Consulta
                //                        orderby C.PendienteEntrega descending
                //                        select C);
                //    }
                //    if (cmbOrdenar.SelectedIndex == 5) // Real
                //    {
                //        if (btnBuscarAsc.Visible == true)
                //            Consulta = (from C in Consulta
                //                        orderby C.StockReal ascending
                //                        select C);
                //        else
                //            Consulta = (from C in Consulta
                //                        orderby C.StockReal descending
                //                        select C);
                //    }
                //    if (cmbOrdenar.SelectedIndex == 5) // Pendiente producir
                //    {
                //        if (btnBuscarAsc.Visible == true)
                //            Consulta = (from C in Consulta
                //                        orderby C.PendienteProducir ascending
                //                        select C);
                //        else
                //            Consulta = (from C in Consulta
                //                        orderby C.PendienteProducir descending
                //                        select C);
                //    }

                if (chkFiltraProducto.Checked)
                    Consulta = (from C in Consulta
                                where C.ProductoID == cmbFiltraProducto.SelectedValue.ToString()
                                select C);

                //if (chkFiltraResponsable.Checked)
                //    Consulta = (from C in Consulta
                //                where C.ResponsableID == (int)cmbFiltraResponsable.SelectedValue
                //                select C);

                if (chkFiltraCategoria.Checked)
                    Consulta = (from C in Consulta
                                where C.CategoriaID == (int)cmbFiltraCategoria.SelectedValue
                                select C);

                if (chkMuestraPendEntregar.Checked)
                    Consulta = (from C in Consulta
                                where C.PendienteEntregar < 0
                                select C);

                if (chkMuestraPendProducir.Checked)
                    Consulta = (from C in Consulta
                                where C.PendienteProducir > 0
                                select C);

                if (rdbFiltraBajoStock.Checked)
                    Consulta = (from C in Consulta
                                where C.StockReal <= C.StockMinimo
                                select C);

                if (rdbFiltraStock.Checked)
                    Consulta = (from C in Consulta
                                where C.StockReal > C.StockMinimo
                                select C);


                var Resultados = Consulta.ToList();

                colExistenciaReal.Visible = true;
                //colExistenciaRef.Visible = true;
                colPendiente.Visible = true;
                //colPendProducir.Visible = true;
                //colPendienteRef.Visible = true;
                //colStockRealRef.Visible = true;
                //colPuntoPedido.Visible = false;
                colStockMin.Visible = true;
                //colExistenciaPallet.Visible = true;
                //colPendEntregaPallet.Visible = true;
                //colStockRealPallet.Visible = true;

                colInsProdID.DataPropertyName = "ProductoID";
                colInsPro.DataPropertyName = "Producto";
                colExistencia.DataPropertyName = "Existencia";
                colExistenciaPallet.DataPropertyName = "ExistenciaPallets";
                colPendiente.DataPropertyName = "PendienteEntrega";
                colPendEntregaPallet.DataPropertyName = "PendienteEntregarPallets";
                colExistenciaReal.DataPropertyName = "StockReal";
                colStockRealPallet.DataPropertyName = "StockRealPallets";
                colPendProducir.DataPropertyName = "PendienteProducir";
                colMedida.DataPropertyName = "Medida";
                colStockMin.DataPropertyName = "StockMinimo";
                colExistenciaRef.DataPropertyName = "ExistenciaRef";
                colPendienteRef.DataPropertyName = "PendienteEntregarRef";
                colStockRealRef.DataPropertyName = "StockRealRef";
                colValorUnidadPeso.DataPropertyName = "ValorUnidadPeso";
                colValorUnidadDolar.DataPropertyName = "ValorUnidadDolar";

                if (ConsultaUsuario.Monetizado == "SI")
                {
                    colValorUnidadPeso.Visible = true;
                    colValorUnidadDolar.Visible = true;
                }
                else
                {
                    colValorUnidadPeso.Visible = false;
                    colValorUnidadDolar.Visible = false;
                }

                lblResultados.Text = Resultados.Count.ToString();

                dgvStock.AutoGenerateColumns = false;
                dgvStock.DataSource = Resultados;
            }
        }
        private void MostrarExistenciaProductosPorLote()
        {
            //using (var hb = new DBdatos())
            //{
            //    int CiudadID;

            //    var ConsultaFecha = (from F in hb.StockFecha
            //                         orderby F.Fecha_Stock descending
            //                         select F).FirstOrDefault();

            //    var ConsultaUsuario = (from U in hb.Usuarios
            //                           where U.ID == UsuarioID
            //                           select U).FirstOrDefault();

            //    if (ConsultaFecha == null)
            //        FechaStock = Convert.ToDateTime("01/01/2000");
            //    else
            //        FechaStock = ConsultaFecha.Fecha_Stock;

            //    if (chkFiltraCiudad.Checked && cmbCiudad.SelectedIndex != -1)
            //    {
            //        CiudadID = (int)cmbCiudad.SelectedValue;
            //    }
            //    else
            //    {
            //        CiudadID = 0;
            //    }

            //    var Consulta = (from VS in hb.ftStockProductoFinalPorLote(FechaStock, CiudadID)
            //                    join PRO in hb.Productos_Insumos on VS.ProductoID equals PRO.Codigo
            //                    where PRO.Estado == "SI"
            //                    orderby VS.Lote
            //                    select new
            //                    {
            //                        VS.ProductoID,
            //                        VS.Producto,
            //                        VS.Medida,
            //                        VS.Existencia,
            //                        VS.PendienteEntrega,
            //                        VS.StockReal,
            //                        VS.PendienteProducir,
            //                        VS.StockMinimo,
            //                        VS.CategoriaID,
            //                        VS.ResponsableID,
            //                        VS.Responsable,
            //                        VS.ExistenciaRef,
            //                        VS.PendienteEntregarRef,
            //                        VS.StockRealRef,
            //                        VS.PendienteProducirRef,
            //                        VS.ValorUnidadPeso,
            //                        VS.ValorUnidadDolar,
            //                        VS.Lote


            //                    }).Take(1000);

            //    if (cmbOrdenar.SelectedIndex == 1) // Codigo
            //    {
            //        if (btnBuscarAsc.Visible == true)
            //            Consulta = (from C in Consulta
            //                        orderby C.ProductoID ascending
            //                        select C);
            //        else
            //            Consulta = (from C in Consulta
            //                        orderby C.ProductoID descending
            //                        select C);
            //    }
            //    if (cmbOrdenar.SelectedIndex == 2) // Descripcion
            //    {
            //        if (btnBuscarAsc.Visible == true)
            //            Consulta = (from C in Consulta
            //                        orderby C.Producto ascending
            //                        select C);
            //        else
            //            Consulta = (from C in Consulta
            //                        orderby C.Producto descending
            //                        select C);
            //    }
            //    if (cmbOrdenar.SelectedIndex == 3) // Existencia
            //    {
            //        if (btnBuscarAsc.Visible == true)
            //            Consulta = (from C in Consulta
            //                        orderby C.Existencia ascending
            //                        select C);
            //        else
            //            Consulta = (from C in Consulta
            //                        orderby C.Existencia descending
            //                        select C);
            //    }
            //    if (cmbOrdenar.SelectedIndex == 4) // Pendiente de entrega
            //    {
            //        if (btnBuscarAsc.Visible == true)
            //            Consulta = (from C in Consulta
            //                        orderby C.PendienteEntrega ascending
            //                        select C);
            //        else
            //            Consulta = (from C in Consulta
            //                        orderby C.PendienteEntrega descending
            //                        select C);
            //    }
            //    if (cmbOrdenar.SelectedIndex == 5) // Real
            //    {
            //        if (btnBuscarAsc.Visible == true)
            //            Consulta = (from C in Consulta
            //                        orderby C.StockReal ascending
            //                        select C);
            //        else
            //            Consulta = (from C in Consulta
            //                        orderby C.StockReal descending
            //                        select C);
            //    }
            //    if (cmbOrdenar.SelectedIndex == 5) // Pendiente producir
            //    {
            //        if (btnBuscarAsc.Visible == true)
            //            Consulta = (from C in Consulta
            //                        orderby C.PendienteProducir ascending
            //                        select C);
            //        else
            //            Consulta = (from C in Consulta
            //                        orderby C.PendienteProducir descending
            //                        select C);
            //    }

            //    if (chkFiltraProducto.Checked)
            //        Consulta = (from C in Consulta
            //                    where C.ProductoID == cmbFiltraProducto.SelectedValue.ToString()
            //                    select C);

            //    if (chkFiltraResponsable.Checked)
            //        Consulta = (from C in Consulta
            //                    where C.ResponsableID == (int)cmbFiltraResponsable.SelectedValue
            //                    select C);

            //    if (chkFiltraCategoria.Checked)
            //        Consulta = (from C in Consulta
            //                    where C.CategoriaID == (int)cmbFiltraCategoria.SelectedValue
            //                    select C);

            //    if (chkFiltraLote.Checked)
            //    {
            //        string Lote = dtpLote.Value.Date.ToShortDateString();

            //        Consulta = (from C in Consulta
            //                    where C.Lote == Lote
            //                    select C);
            //    }

            //    if (chkMuestraPendEntregar.Checked)
            //        Consulta = (from C in Consulta
            //                    where C.PendienteEntrega < 0
            //                    select C);

            //    if (chkMuestraPendProducir.Checked)
            //        Consulta = (from C in Consulta
            //                    where C.PendienteProducir > 0
            //                    select C);

            //    if (rdbFiltraBajoStock.Checked)
            //        Consulta = (from C in Consulta
            //                    where C.StockReal <= C.StockMinimo
            //                    select C);

            //    if (rdbFiltraStock.Checked)
            //        Consulta = (from C in Consulta
            //                    where C.StockReal > C.StockMinimo
            //                    select C);


            //    var Resultados = Consulta.ToList();

            //    colExistencia.Visible = true;
            //    colExistenciaRef.Visible = false;
            //    colPendiente.Visible = false;
            //    colLote.Visible = true;
            //    colPendProducir.Visible = false;
            //    colPendienteRef.Visible = false;
            //    colStockRealRef.Visible = false;
            //    colPuntoPedido.Visible = false;
            //    colStockMin.Visible = true;
            //    colValorUnidadPeso.Visible = false;
            //    colValorUnidadDolar.Visible = false;               
            //    colPendProducir.Visible = false;

            //    colInsProdID.DataPropertyName = "ProductoID";
            //    colInsPro.DataPropertyName = "Producto";
            //    colExistencia.DataPropertyName = "Existencia";
            //    colPendiente.DataPropertyName = "PendienteEntrega";
            //    colExistenciaReal.DataPropertyName = "StockReal";
            //    colPendProducir.DataPropertyName = "PendienteProducir";
            //    colMedida.DataPropertyName = "Medida";
            //    colStockMin.DataPropertyName = "StockMinimo";
            //    colExistenciaRef.DataPropertyName = "ExistenciaRef";
            //    colPendienteRef.DataPropertyName = "PendienteEntregarRef";
            //    colStockRealRef.DataPropertyName = "StockRealRef";
            //    colValorUnidadPeso.DataPropertyName = "ValorUnidadPeso";
            //    colValorUnidadDolar.DataPropertyName = "ValorUnidadDolar";
            //    colLote.DataPropertyName = "Lote";

            //    //if (ConsultaUsuario.Monetizado == "SI")
            //    //{
            //    //    colValorUnidadPeso.Visible = true;
            //    //    colValorUnidadDolar.Visible = true;
            //    //}
            //    //else
            //    //{
            //    //    colValorUnidadPeso.Visible = false;
            //    //    colValorUnidadDolar.Visible = false;
            //    //}

            //    txtCantidadResultados.Text = Resultados.Count.ToString();

            //    dgvStock.AutoGenerateColumns = false;
            //    dgvStock.DataSource = Resultados;
            //}
        }
        private void MostrarStockInsumos()
        {         
            MostrarExistenciaInsumos();
            InsProd = "INS";
            btnMostrarStockInsumos.BackColor = Color.Orange;
            btnProductos.BackColor = Color.White;
            btnSubProductos.BackColor = Color.White;
        }
        private void MostrarStockProductos()
        {          
            MostrarExistenciaProductos();
            InsProd = "PRO";
            btnMostrarStockInsumos.BackColor = Color.White;
            btnProductos.BackColor = Color.Orange;
            btnSubProductos.BackColor = Color.White;
        }
        private void MostrarStockSubproductos()
        {
            InsProd = "SUB";
            //MostrarExistenciaSubproductos();           
            btnSubProductos.BackColor = Color.Orange;
            btnProductos.BackColor = Color.White;
            btnMostrarStockInsumos.BackColor = Color.White;
        }
        private void ActuaizarDatos()
        {
            if (InsProd == "INS")
                MostrarExistenciaInsumos();
            if (InsProd == "PRO")
                MostrarExistenciaProductos();
            if (InsProd == "SUB")
                MostrarExistenciaSubproductos();
        }
        private void MostrarenRojoStockCríticoINS() // CORREGIR
        {                  
                //for (int i = 1; i <= dgvStock.RowCount; i++)
                //{                  
                //    decimal Cantidad_Actual = Convert.ToDecimal(dgvStock.Rows[i - 1].Cells[2].Value);
                
                //        if (Cantidad_Actual <= (decimal)dgvStock.Rows[i - 1].Cells[10].Value)
                //        {
                //            dgvStock.Rows[i - 1].DefaultCellStyle.BackColor = Color.DarkRed;
                //            dgvStock.Rows[i - 1].DefaultCellStyle.SelectionBackColor = Color.IndianRed;
                //            dgvStock.Rows[i - 1].DefaultCellStyle.ForeColor = Color.White;
                //            dgvStock.Rows[i - 1].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                //        }                   
               // }          
        }
        private void MostrarenRojoStockCríticoPRO() // CORREGIR
        {
            using (var hb = new DBdatos())
            {
                //if (InsProd != "SUB")
                //{
                //    for (int i = 1; i <= dgvStock.RowCount; i++)
                //    {
                //        decimal Cantidad_Actual = Convert.ToDecimal(dgvStock.Rows[i - 1].Cells[4].Value);

                //        if ((decimal)dgvStock.Rows[i - 1].Cells[6].Value >= Cantidad_Actual)
                //        {
                //            dgvStock.Rows[i - 1].DefaultCellStyle.BackColor = Color.DarkRed;
                //            dgvStock.Rows[i - 1].DefaultCellStyle.SelectionBackColor = Color.IndianRed;
                //            dgvStock.Rows[i - 1].DefaultCellStyle.ForeColor = Color.White;
                //            dgvStock.Rows[i - 1].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                //        }
                //    }
                //}
            }
        }
        private void btnMostraStockFlexible_Click(object sender, EventArgs e)
        {
            MostrarStockInsumos();
            chkFiltraProducto.Checked = false;
            chkFiltraResponsable.Checked = false;
            chkFiltraResponsable.Enabled = false;
            chkFiltraSeccion.Enabled = false;
            chkFiltraSubProducto.Enabled = false;
            chkFiltraSubProducto.Checked = false;
        }

        private void btnMostrarStockProductos_Click(object sender, EventArgs e)
        {
            MostrarStockProductos();
            //MostrarExistenciaProductosPorLote();
            chkFiltraResponsable.Enabled = true;
            chkFiltraProducto.Checked = false;
            chkFiltraSeccion.Enabled = false;
            chkFiltraSubProducto.Enabled = false;
            chkFiltraSubProducto.Checked = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActuaizarDatos();
        }

        private void chkFiltraDescripion_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkFiltraInsPro_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraProducto, cmbFiltraProducto, txtBuscarProducto, btnBuscarProducto, "PRO", "NO");
        }

        private void chkFiltraCategoria_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCategorias(chkFiltraCategoria, cmbFiltraCategoria, txtBuscaCategoria, btnBuscarCategoria);
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
            Reutilizables.ReubicarFiltros(gbxFiltros, pnlInferior, btnMostrarfiltros);
        }

        private void dgvStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (InsProd == "INS" && dgvStock.RowCount > 0)
            {            
                MostrarenRojoStockCríticoINS();
            }
            if (InsProd == "PRO" && dgvStock.RowCount > 0)
            {
                MostrarenRojoStockCríticoPRO();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvStock);
        }

        private void chkFiltraCodigo_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (InsProd == "PRO")
                MostrarStockProductos();
            if (InsProd == "INS")
                MostrarExistenciaInsumos();
            if (InsProd == "SUB")
                MostrarExistenciaSubproductos();
                
        }

        private void txtBuscaResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaResponsable.Visible = false;
                clsCargarCombos.MostrarComboEmpleados(cmbFiltraResponsable, txtBuscaResponsable, true);
                txtBuscaResponsable.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaResponsable.Visible = false;
                txtBuscaResponsable.Focus();
                e.Handled = true;
            }
        }

        private void cmbFiltraResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboEmpleados(cmbFiltraResponsable, txtBuscaResponsable, false);
                txtBuscaResponsable.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarResponsable_Click(object sender, EventArgs e)
        {
            txtBuscaResponsable.Visible = true;
            txtBuscaResponsable.Select();
        }

        private void chkFiltraResponsable_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboEmpleados(chkFiltraResponsable, txtBuscaResponsable, cmbFiltraResponsable,btnBuscarResponsable);

        }

        private void btnSubProductos_Click(object sender, EventArgs e)
        {
            chkFiltraSubProducto.Enabled = true;

            if (chkFiltraSeccion.Checked && cmbFiltraSeccion.SelectedValue != null && chkFiltraProducto.Checked && cmbFiltraProducto.SelectedValue != null)
                MostrarExistenciaSubproductos();
            else
                dgvStock.DataSource = "";

            MostrarStockSubproductos();
            chkFiltraProducto.Checked = false;
            chkFiltraResponsable.Checked = false;
            chkFiltraResponsable.Enabled = false;
            chkFiltraSeccion.Enabled = true;
        }
        private void MostrarExistenciaSubproductos()
        {
            if (chkFiltraSeccion.Checked && cmbFiltraSeccion.SelectedValue != null && chkFiltraProducto.Checked && cmbFiltraProducto.SelectedValue != null)
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaOrden = (from CP in hb.Seccion_Circuito
                                         where CP.Seccion_ID == (int)cmbFiltraSeccion.SelectedValue
                                         select CP).FirstOrDefault();

                    var Consulta = (from F in hb.ftVistaStockSubproducto5(ConsultaOrden.Orden, (int)cmbFiltraSeccion.SelectedValue, cmbFiltraProducto.SelectedValue.ToString())
                                    orderby F.Insumo
                                    select new
                                    {
                                        F.InsumoID,
                                        F.Insumo,
                                        F.Medida,
                                        F.Existencia,
                                        F.CantidadPendiente
                                    });

                    var Resultados = Consulta.ToList();

                    colExistenciaReal.Visible = false;
                    colExistenciaRef.Visible = false;
                    colPendienteRef.Visible = false;
                    colStockRealRef.Visible = false;
                    colPuntoPedido.Visible = false;
                    colPendProducir.Visible = true;
                    colPendiente.Visible = false;
                    colStockMin.Visible = false;

                    colInsProdID.DataPropertyName = "InsumoID";
                    colInsPro.DataPropertyName = "Insumo";
                    colExistencia.DataPropertyName = "Existencia";
                    colPendProducir.DataPropertyName = "CantidadPendiente";
                    colMedida.DataPropertyName = "Medida";
                    colPuntoPedido.DataPropertyName = "PuntoPedido";

                    dgvStock.AutoGenerateColumns = false;
                    dgvStock.DataSource = Resultados;
                }
            }
        }
        private void cmbFiltraSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void chkFiltraSeccion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSeccion(chkFiltraSeccion, cmbFiltraSeccion);
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProducto.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraProducto, txtBuscarProducto, "PRO", true, "NO");
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
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraProducto, txtBuscarProducto, "PRO", false, "NO");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
        }

        private void txtBuscarInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarInsumo.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsumo, txtBuscarInsumo, "INS", true, "NO");
                txtBuscarInsumo.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarInsumo.Visible = false;
                txtBuscarInsumo.Focus();
                e.Handled = true;
            }
        }

        private void cmbFiltraInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsumo, txtBuscarInsumo, "INS", false, "NO");
                txtBuscarInsumo.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarInsumo_Click(object sender, EventArgs e)
        {
            txtBuscarInsumo.Visible = true;
            txtBuscarInsumo.Select();
        }

        private void chkFiltraInsumo_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsumo, cmbFiltraInsumo, txtBuscarInsumo, btnBuscarInsumo, "INS", "NO");
        }

        private void chkFiltraSubProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiltraProducto.Checked && cmbFiltraProducto.SelectedValue != null)
                Reutilizables.ActivarFiltroInsumoSegunProductoSeleccionado(chkFiltraSubProducto, cmbFiltraSubProducto, cmbFiltraProducto, txtBuscarSubProducto, btnBuscarSubProducto);
            else
                Reutilizables.ActivarFiltroComboSubProducto(chkFiltraSubProducto, cmbFiltraSubProducto, txtBuscarSubProducto, btnBuscarSubProducto);
           
        }

        private void txtBuscarSubProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarSubProducto.Visible = false;
                if (chkFiltraProducto.Checked)
                    clsCargarCombos.MostrarComboInsumoSegunProductoSeleccionado(cmbFiltraSubProducto, cmbFiltraProducto, txtBuscarSubProducto, true);
                else
                    clsCargarCombos.MostrarComboSubProductos(cmbFiltraSubProducto, txtBuscarSubProducto,true);

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

        private void cmbFiltraSubProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                if (chkFiltraProducto.Checked && cmbFiltraProducto.SelectedValue != null)
                    clsCargarCombos.MostrarComboInsumoSegunProductoSeleccionado(cmbFiltraSubProducto, cmbFiltraProducto, txtBuscarSubProducto, false);
                else
                    clsCargarCombos.MostrarComboSubProductos(cmbFiltraSubProducto, txtBuscarSubProducto, false);
                e.Handled = true;
            }
        }

        private void btnBuscarSubProducto_Click(object sender, EventArgs e)
        {
            txtBuscarSubProducto.Visible = true;
            txtBuscarSubProducto.Select();
        }

        private void cmbFiltraProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chkFiltraSubProducto.Checked && cmbFiltraProducto.SelectedValue != null)
            {
                clsCargarCombos.MostrarComboInsumoSegunProductoSeleccionado(cmbFiltraSubProducto,cmbFiltraProducto,txtBuscarSubProducto,false);
            }
        }
        private void ReinciarStock()
        {
            DialogResult R = MessageBox.Show("Está seguro que desea reiniciar todos los stocks?", "Atención", MessageBoxButtons.YesNoCancel);

            if (R == DialogResult.Yes)
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaEI = (from EI in hb.Existencia_Insumos
                                      orderby EI.Fecha descending
                                      select EI).FirstOrDefault();

                    FechaStock = ConsultaEI.Fecha;

                    var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                       orderby EPT.Fecha descending
                                       select EPT).FirstOrDefault();

                    if (ConsultaEPT.Fecha > FechaStock)
                        FechaStock = ConsultaEPT.Fecha;

                    var ConsultaStockFecha = (from FS in hb.StockFecha
                                              where FS.Fecha_Stock == FechaStock
                                              select FS).FirstOrDefault();

                    if (ConsultaStockFecha == null)
                    {
                        var i = new StockFecha();

                        i.Fecha = DateTime.Now.Date;
                        i.Fecha_Stock = FechaStock;

                        hb.StockFecha.Add(i);
                        hb.SaveChanges();
                        MessageBox.Show("De ahora en adelante el stock será calculado tomando en cuenta movimientos con fecha mayor e igual a " + FechaStock.ToShortDateString(), "Atención");
                    }
                    else
                    {
                        MessageBox.Show("Ya hay un renicio de stock con la fecha " + FechaStock.ToShortDateString(), "Atención");
                    }
                }
            }
        }
        private void ListarInformeStock()
        {
            decimal Cotizacion = 0;
           
            DataSet1 Ds = new DataSet1();
            int Filas = dgvStock.RowCount;

            var Report = new ReportClass();

            if (Imprime == "ControlStock")
                Report = new rptStock();
            else
            {
                using (var hb = new DBdatos())
                {
                    Report = new rptStockMonetizado();

                    var ConsultaCotizacion = (from COT in hb.MonedaCotizacion
                                              where COT.Moneda_ID == "DO"
                                              orderby COT.Fecha descending
                                              select COT).FirstOrDefault();

                    if (ConsultaCotizacion == null)
                        Cotizacion = 0;
                    else
                        Cotizacion = ConsultaCotizacion.Valor;

                }
            }
            FormularioReporte.Informe = Report;

            for (int i = 1; i <= Filas; i++)
            {
                

                if (Imprime == "ControlStock")
                {
                    Ds.Tables[name: "rptStock"].Rows.Add
                    (new object[] {
                                this.dgvStock.Rows[i-1].Cells[columnName: "colInsProdID"].Value.ToString(),
                                this.dgvStock.Rows[i-1].Cells[columnName: "colInsPro"].Value.ToString(),
                                this.dgvStock.Rows[i-1].Cells[columnName: "colExistencia"].Value,
                                this.dgvStock.Rows[i-1].Cells[columnName: "colPendiente"].Value,
                                this.dgvStock.Rows[i-1].Cells[columnName: "colExistenciaReal"].Value,
                                this.dgvStock.Rows[i-1].Cells[columnName: "colPendProducir"].Value,
                                this.dgvStock.Rows[i-1].Cells[columnName: "colStockMin"].Value,
                                this.dgvStock.Rows[i-1].Cells[columnName: "colPuntoPedido"].Value,
                                this.dgvStock.Rows[i-1].Cells[columnName: "colMedida"].Value,
                                0,
                                0,
                                0,
                                0,
                    });
                }
                else
                {
                    decimal Existencia = Convert.ToDecimal(dgvStock.Rows[i - 1].Cells[columnName: "colExistencia"].Value);
                    decimal UnidadPeso = Convert.ToDecimal(dgvStock.Rows[i - 1].Cells[columnName: "colValorUnidadPeso"].Value);
                    decimal UnidadDolar = Convert.ToDecimal(dgvStock.Rows[i - 1].Cells[columnName: "colValorUnidadDolar"].Value);
                    decimal ValorTotalPeso;
                    decimal ValorTotalDolar;

                    if (Existencia < 0)
                    {
                        ValorTotalPeso = 0;
                        ValorTotalDolar = 0;
                    }
                    else
                    {
                        ValorTotalPeso = Existencia * UnidadPeso;
                        ValorTotalDolar = Existencia * UnidadDolar;
                    }

                    Ds.Tables[name: "rptStock"].Rows.Add
                    (new object[] {
                                this.dgvStock.Rows[i-1].Cells[columnName: "colInsProdID"].Value.ToString(),
                                this.dgvStock.Rows[i-1].Cells[columnName: "colInsPro"].Value.ToString(),
                                this.dgvStock.Rows[i-1].Cells[columnName: "colExistencia"].Value,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,//
                                UnidadPeso,
                                UnidadDolar,
                                ValorTotalPeso,
                                ValorTotalDolar,
                    });
                }
            }
            using (var hb = new DBdatos())
            {
                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;


                var Consulta = (from C in hb.Clientes
                                where C.Cliente_Usuario == true
                                select C);

                var Resultados = Consulta.FirstOrDefault();
                var Resultados2 = Consulta.ToList();

                Cliente = Resultados.Descripcion;
                Telefono = Resultados.Telefono;
                Mail = Resultados.Email;
                Ciudad = Resultados.Ciudades.Descripcion;


                ((TextObject)Report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)Report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)Report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)Report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                if (InsProd == "INS")
                {
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtInsProSub"]).Text = "INSUMO";
                }
                else if (InsProd == "PRO")
                {
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtInsProSub"]).Text = "PRODUCTO";
                }
                else
                {
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtInsProSub"]).Text = "SUBPRODUCTO";
                }

                if (chkFiltraProducto.Checked == false)
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = "";
                else
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = cmbFiltraProducto.Text;

                if (chkFiltraSubProducto.Checked == false)
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtFiltroSubProducto"]).Text = "";
                else
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtFiltroSubProducto"]).Text = cmbFiltraSubProducto.Text;

                if (chkFiltraInsumo.Checked == false)
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtFiltroInsumo"]).Text = "";
                else
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtFiltroInsumo"]).Text = cmbFiltraInsumo.Text;

                if (chkFiltraCategoria.Checked == false)
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtFiltroRubro"]).Text = "";
                else
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtFiltroRubro"]).Text = cmbFiltraCategoria.Text;

                if (chkFiltraSubProducto.Checked == false)
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtFiltroResponsable"]).Text = "";
                else
                    ((TextObject)Report.ReportDefinition.ReportObjects["txtFiltroResponsable"]).Text = cmbFiltraResponsable.Text;

                Report.SetDataSource(Ds);
                FormularioReporte.crystalReportViewer1.ReportSource = Report;

                FormularioReporte.ShowDialog();
            }
        }

        private void btnRestablecerStock_Click(object sender, EventArgs e)
        {
            ReinciarStock();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
           // ListarInformeStock();
        }

        private void CmsBtnAgregarPedOrden_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_MouseClick(object sender, MouseEventArgs e)
        {
            cmsImprimir.Show(btnImprimir.PointToScreen(e.Location));
        }

        private void CmsBtnControlStock_Click(object sender, EventArgs e)
        {
            Imprime = "ControlStock";
            ListarInformeStock();
        }

        private void cmsBtnStockMonetizado_Click(object sender, EventArgs e)
        {
            Imprime = "Monetizado";
            ListarInformeStock();
        }

        private void txtBuscarCiudad_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkFiltraCiudad_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCiudad(chkFiltraCiudad, cmbCiudad, txtBuscarCiudad, btnBuscarCiudad);
        }

        private void txtBuscarCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarCiudad.Visible = false;
                clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscarCiudad, true);
                txtBuscarCiudad.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarCiudad.Visible = false;
                txtBuscarCiudad.Focus();
                e.Handled = true;
            }
        }

        private void cmbCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscarCiudad, false);
                txtBuscarCiudad.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarCiudad_Click(object sender, EventArgs e)
        {
            txtBuscarCiudad.Visible = true;
            cmbCiudad.Visible = false;
            txtBuscarCiudad.Select();
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);

            if (InsProd == "PRO")
                MostrarExistenciaProductos();
            if (InsProd == "INS")
                MostrarExistenciaInsumos();
            if (InsProd == "SUB")
                MostrarExistenciaSubproductos();
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);

            if (InsProd == "PRO")
                MostrarExistenciaProductos();
            if (InsProd == "INS")
                MostrarExistenciaInsumos();
            if (InsProd == "SUB")
                MostrarExistenciaSubproductos();
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsNotificaStockMinimo.NotificaStockMinimo();
        }

        private void chkLote_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFiltraLote, dtpFiltraLote);
        }

        private void txtBuscarProducto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarSubProducto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarInsumo_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscaCategoria_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscaResponsable_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarCiudad_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
