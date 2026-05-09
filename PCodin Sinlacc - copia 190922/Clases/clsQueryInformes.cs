using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios.ESTADISTICAS.Informes;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using PCodin_Sinlacc.Formularios.ESTADISTICAS.Informes_Dataset;
using PCodin_Sinlacc.Formularios;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace PCodin_Sinlacc.Clases
{
    class clsQueryInformes
    {  
        

        public static void rptMaestroPedidos(CheckBox chkFiltraProducto,
                                             ComboBox cmbFiltraProducto,
                                             CheckBox chkFiltraEstadoPed,
                                             ComboBox cmbFiltraEstadoPed,
                                             frmReporte VisorReporte) // rptMaestroPedidos
        {
            using (var hb = new DBdatos())
            {
                

                var Consulta = (from RP in hb.Pedido_Cuerpo
                                where RP.Registro_Pedidos.Estado_ID == "FI" || RP.Registro_Pedidos.Estado_ID == "AU"
                                orderby RP.Registro_Pedidos.Clientes.Descripcion
                                select new
                                {
                                    RP.Pedido_ID,
                                    RP.Registro_Pedidos.Numero_Pedido,
                                    RP.Registro_Pedidos.Fecha,
                                    Cliente = RP.Registro_Pedidos.Clientes.Descripcion,
                                    Ciudad = RP.Registro_Pedidos.Ciudades.Descripcion,
                                    RP.Producto_ID,
                                    EstadoPedido = RP.Registro_Pedidos.Estado_ID,
                                    Producto = RP.Productos_Insumos.Descripcion,
                                    CantidadTotal = RP.Cantidad_Total_Entregada + RP.Cantidad,
                                    CantidadPend = RP.Cantidad,
                                    CantidadAfecta = RP.Cantidad_Total_Entregada,
                                    CantidadRef = RP.Productos_Insumos.Cantidad_Ref,
                                    Medida = RP.Productos_Insumos.Medidas_Producto.Descripcion
                                });


                if (chkFiltraProducto.Checked)
                    Consulta = (from C in Consulta
                                where C.Producto_ID == cmbFiltraProducto.SelectedValue.ToString()
                                select C);

                if (chkFiltraEstadoPed.Checked)
                    Consulta = (from C in Consulta
                                where C.EstadoPedido == cmbFiltraEstadoPed.Text
                                select C);

                var Resultados = Consulta.ToList();

                DSrptMaestroDePedidos Ds = new DSrptMaestroDePedidos();
                var report = new rptMaestroDePedidos();

                byte[] Logo = null;

                foreach (var item in Resultados)
                {
                    decimal CantidadTotalRef = 0;
                    decimal CantidadPenRef = 0;
                    decimal CantidadAfecta = 0;

                    if (item.Medida != "Litros")
                    {

                        if (item.CantidadRef != null)
                        {
                            CantidadTotalRef = (decimal)(item.CantidadTotal * item.CantidadRef);
                            CantidadPenRef = (decimal)(item.CantidadPend * item.CantidadRef);
                            CantidadAfecta = (decimal)(item.CantidadAfecta * item.CantidadRef);
                        }
                    }

                    Ds.Tables[0].Rows.Add
                    (new object[] {
                                item.Fecha.ToShortDateString(),
                                item.Cliente,
                                item.Producto,
                                item.CantidadTotal,
                                item.CantidadPend,
                                item.CantidadAfecta,
                                item.Numero_Pedido,
                                //item.Pedido_ID,
                                CantidadTotalRef,
                                CantidadPenRef,
                                CantidadAfecta,
                                Logo
                    });
                }

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;


                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                if (ResultadosClienteUsuario != null)
                {
                    //((PictureObject)report.ReportDefinition.ReportObjects["Box1"]).
                }


                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;


                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                if (chkFiltraProducto.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = cmbFiltraProducto.Text;

                if (chkFiltraEstadoPed.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroEstado"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroEstado"]).Text = cmbFiltraEstadoPed.Text;

                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;
                
                VisorReporte.Informe = report; // PARA EXPORTAR A PDF

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }
        }
        public static void rptCostoMaterialProducto(CheckBox chkFiltraProducto, ComboBox cmbFiltraProducto, frmReporte VisorReporte) // rptCostoMaterialProducto
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from FP in hb.Formula_Producto
                                join PRO in hb.Productos_Insumos on FP.Producto_ID equals PRO.Codigo
                                join INS in hb.Productos_Insumos on FP.Insumo_ID equals INS.Codigo
                                join IPRO in hb.Insumo_Proveedor on FP.Insumo_ID equals IPRO.Insumo_ID
                                where IPRO.Proveedor_Principal == "SI"
                                orderby PRO.Descripcion
                                select new
                                {
                                    CodigoProducto = PRO.Codigo,
                                    DescripcionProducto = PRO.Descripcion,
                                    CodigoInsumo = INS.Codigo,
                                    DescripcionInsumo = INS.Descripcion,
                                    ProveedorID = IPRO.Proveedor_ID,
                                    Proveedor = IPRO.Clientes.Descripcion,
                                    FP.Cantidad,
                                    IPRO.Costo,
                                    CostoGeneral = FP.Cantidad * IPRO.Costo,
                                    Medida = INS.Medidas_Producto.Descripcion
                                });

                if (chkFiltraProducto.Checked)
                    Consulta = (from C in Consulta
                                where C.CodigoProducto == cmbFiltraProducto.SelectedValue.ToString()
                                select C);

                var Resultados = Consulta.ToList();
              
                DSrptCostoMaterialProducto Ds = new DSrptCostoMaterialProducto();
                var report = new rptCostoMaterialProducto();

                foreach (var item in Resultados)
                {
                    Ds.Tables[0].Rows.Add
                    (new object[] {
                                item.CodigoProducto,
                                item.DescripcionProducto,
                                item.Cantidad,
                                item.Costo,
                                item.CodigoInsumo,
                                item.DescripcionInsumo,
                                item.CostoGeneral,
                                item.Medida,
                                item.Proveedor
                    });
                }

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;


                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                if (chkFiltraProducto.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = cmbFiltraProducto.Text;

                report.SetDataSource(Ds);
                VisorReporte.Informe = report;

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }
        }
        public static void rptProduccionDiaria(CheckBox chkFiltraProducto, ComboBox cmbFiltraProducto,CheckBox chkFiltraFechaDesde, CheckBox chkFiltraFechaHasta , DateTimePicker dtpFiltraFechaDesde , DateTimePicker dtpFiltraFechaHasta , frmReporte VisorReporte)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from EPT in hb.Existencia_ProductoTerminado
                                where EPT.Movimiento_ID == "IPT"
                                orderby EPT.ID
                                select new
                                {
                                    EPT.Fecha,
                                    CodigoProd = EPT.Produto_ID,
                                    DescripcionProducto = EPT.Productos_Insumos.Descripcion,
                                    EPT.Cantidad,
                                    Medida = EPT.Medidas_Producto.Descripcion,
                                    EPT.Ficha,
                                    EPT.Retencion,
                                    CodEmpleado = EPT.Empleado_ID,
                                    NombreEmpleado = EPT.Empleados.Nombre,
                                    MediadaRef = EPT.Productos_Insumos.Medidas_Producto1.Descripcion,
                                    CantidadRef = EPT.Productos_Insumos.Cantidad_Ref
                                });

                if (chkFiltraProducto.Checked)
                    Consulta = (from C in Consulta
                                where C.CodigoProd == cmbFiltraProducto.SelectedValue.ToString()
                                select C);

                if (chkFiltraFechaDesde.Checked && chkFiltraFechaHasta.Checked == false)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFiltraFechaDesde.Value.Date
                                select C);
                }
                else if (chkFiltraFechaDesde.Checked == false && chkFiltraFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha <= dtpFiltraFechaHasta.Value.Date
                                select C);
                }
                else if (chkFiltraFechaDesde.Checked && chkFiltraFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFiltraFechaDesde.Value.Date && C.Fecha <= dtpFiltraFechaHasta.Value.Date
                                select C);
                }

                var Resultados = Consulta.ToList();
            
                DSrptProduccionDiaria Ds = new DSrptProduccionDiaria();
                var report = new rptProduccionDiaria();

                foreach (var item in Resultados)
                {
                    decimal CantidadRef;

                    if (item.Medida != "Litros" && item.CantidadRef >= 0) //PARA QUE NO CLACULE LITROS SI ESTA EN LITROS
                        CantidadRef = (decimal)(item.Cantidad * item.CantidadRef);
                    else
                        CantidadRef = 0;

                    Ds.Tables[0].Rows.Add
                    (new object[] {
                               item.CodigoProd,
                               item.DescripcionProducto,
                               item.Fecha.Date,
                               item.Cantidad,
                               item.Medida,
                               item.Ficha,
                               item.Retencion,
                               item.NombreEmpleado,
                               item.MediadaRef,
                               CantidadRef
                    });
                }

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;


                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                if (chkFiltraProducto.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = cmbFiltraProducto.Text;

                //if (chkFiltraEstadoPed.Checked == false)
                //    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroEstado"]).Text = "";
                //else
                //    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroEstado"]).Text = cmbFiltraEstadoPed.Text;

                if (chkFiltraFechaDesde.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroDesde"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroDesde"]).Text = dtpFiltraFechaDesde.Value.Date.ToShortDateString();

                if (chkFiltraFechaHasta.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroHasta"]).Text = DateTime.Now.Date.ToShortDateString();
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroHasta"]).Text = dtpFiltraFechaHasta.Value.Date.ToShortDateString();
              
                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;

                VisorReporte.Informe = report;

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }
        }
        public static void rptListadoCostoInsumo(CheckBox chkFiltraInsumo , ComboBox cmbFiltraInsumo , frmReporte VisorReporte) // rptListadoCostoInsumo
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from INS in hb.Productos_Insumos
                                join IPROV in hb.Insumo_Proveedor on INS.Codigo equals IPROV.Insumo_ID
                                where INS.Ins_Prod == "INS"
                                orderby INS.Descripcion
                                select new
                                {
                                    CodigoInsumo = INS.Codigo,
                                    DescripcionInsumo = INS.Descripcion,
                                    ProveedorID = IPROV.Proveedor_ID,
                                    ProveedorDescrip = IPROV.Clientes.Descripcion,
                                    IPROV.Costo,
                                    Medida = INS.Medidas_Producto.Descripcion

                                });

                if (chkFiltraInsumo.Checked)
                    Consulta = (from C in Consulta
                                where C.CodigoInsumo == cmbFiltraInsumo.SelectedValue.ToString()
                                select C);

                var Resultados = Consulta.ToList();
              
                DSrptListadoCostoInsumo Ds = new DSrptListadoCostoInsumo();
                var report = new rptListadosDeCostosInsumo();

                foreach (var item in Resultados)
                {
                    decimal Costo = 0;

                    //if (item.Costo == null)
                    //    Costo = 0;
                    //else
                    //    Costo = (decimal)item.Costo;

                    Ds.Tables[0].Rows.Add
                    (new object[] {
                                0,
                                0,
                                0,
                                item.Costo,
                                item.CodigoInsumo,
                                item.DescripcionInsumo + " - " + item.CodigoInsumo,
                                0,
                                item.Medida,
                                item.ProveedorDescrip
                    });
                }

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;


                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                if (chkFiltraInsumo.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroInsumo"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroInsumo"]).Text = cmbFiltraInsumo.Text;

                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;

                VisorReporte.Informe = report;

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }

        }
        public static void rptResumenMaestro(CheckBox chkFiltraFechaDesde,
                                       CheckBox chkFiltraFechaHasta,
                                       DateTimePicker dtpFiltraFechaDesde,
                                       DateTimePicker dtpFiltraFechaHasta,
                                       CheckBox chkFiltraCliente,
                                       ComboBox cmbFiltraCliente,
                                       CheckBox chkFiltraMedioPago,
                                       ComboBox cmbFiltraMedioPago,
                                       frmReporte VisorReporte
                                       ) // rptResumenMaestro
        {
           

            using (var hb = new DBdatos())
            {
                var report = new rptResumenMaestro();

                var ConsultaDetalle = (from VDM in hb.VistaDetalleMovimientos
                                       select VDM);

                var Consulta = (from VRM in hb.VistaResumenMaestro
                                orderby VRM.Año, VRM.MesNumero
                                select new
                                {
                                    VRM.Fecha,
                                    VRM.Año,
                                    VRM.Mes,
                                    VRM.Movimiento,
                                    VRM.Comprobante,
                                    VRM.Numero_comprobante,
                                    VRM.CliProv,
                                    VRM.CliProvID,
                                    VRM.ValorTotal,
                                    VRM.MesNumero,
                                    VRM.MedioPago
                                }) ;

                if(chkFiltraCliente.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.CliProvID  == (int)cmbFiltraCliente.SelectedValue
                                select C);

                    ((TextObject)report.ReportDefinition.ReportObjects["txtCuenta"]).Text = cmbFiltraCliente.Text;

                    ((TextObject)report.ReportDefinition.ReportObjects["txtTotalMensual"]).ObjectFormat.EnableSuppress = true;
                    ((TextObject)report.ReportDefinition.ReportObjects["txtTotalAnual"]).ObjectFormat.EnableSuppress = true;
                    ((TextObject)report.ReportDefinition.ReportObjects["txtTotalGeneral"]).ObjectFormat.EnableSuppress = true;

                    LineObject linea1 = (LineObject)report.ReportDefinition.ReportObjects["Line1"];
                    LineObject linea2 = (LineObject)report.ReportDefinition.ReportObjects["Line2"];
                    LineObject linea3 = (LineObject)report.ReportDefinition.ReportObjects["Line3"];
                    linea1.ObjectFormat.EnableSuppress = true;
                    linea2.ObjectFormat.EnableSuppress = true;
                    linea3.ObjectFormat.EnableSuppress = true;

                    FieldObject campo1 = (FieldObject)report.ReportDefinition.ReportObjects["SumadeValorTotal1"];
                    FieldObject campo2 = (FieldObject)report.ReportDefinition.ReportObjects["SumadeValorTotal2"];
                    FieldObject campo3 = (FieldObject)report.ReportDefinition.ReportObjects["SumadeValorTotal3"];
                    campo1.ObjectFormat.EnableSuppress = true;
                    campo2.ObjectFormat.EnableSuppress = true;
                    campo3.ObjectFormat.EnableSuppress = true;

                }

                if (chkFiltraMedioPago.Checked)
                    Consulta = (from C in Consulta
                                where C.MedioPago == cmbFiltraMedioPago.Text
                                select C);


                if (chkFiltraFechaDesde.Checked && chkFiltraFechaHasta.Checked == false)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFiltraFechaDesde.Value.Date
                                select C);
                }
                else if (chkFiltraFechaDesde.Checked == false && chkFiltraFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha <= dtpFiltraFechaHasta.Value.Date
                                select C);
                }
                else if (chkFiltraFechaDesde.Checked && chkFiltraFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFiltraFechaDesde.Value.Date && C.Fecha <= dtpFiltraFechaHasta.Value.Date
                                select C);
                }
                var Resultados = Consulta.ToList();
                var ResultadoDetalle = ConsultaDetalle.ToList();

                DSrptResumenMaestro Ds = new DSrptResumenMaestro();
                

                DSSubResumenMaestro DSDetalle = new DSSubResumenMaestro();
                var subreport = new SubResumenMaestro();

                foreach (var item in Resultados)
                {
                    Ds.Tables[0].Rows.Add
                    (new object[] {

                          item.Fecha,
                          item.CliProv,
                          item.ValorTotal,
                          item.Año,
                          item.Mes,
                          item.Movimiento,
                          item.MesNumero,
                          item.Comprobante,
                          item.Numero_comprobante,    
                          item.MedioPago
                         
                    });
                }
                //foreach (var item2 in ResultadoDetalle)
                //{

                //    DSDetalle.Tables["SubResumenMaestro"].Rows.Add
                //    (new object[] {

                //          item2.ID,                         
                //          item2.CodComprobante,                         
                //          item2.Numero_comprobante,
                //          item2.Articulo,
                //          item2.Cantidad,
                //          item2.Precio,
                //          item2.Total,                          
                //          item2.Comprobante
                        
                //    });
                //}

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);


                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;

                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                if (chkFiltraFechaDesde.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroDesde"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroDesde"]).Text = dtpFiltraFechaDesde.Value.Date.ToShortDateString();

                if (chkFiltraFechaHasta.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroHasta"]).Text = DateTime.Now.Date.ToShortDateString();
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroHasta"]).Text = dtpFiltraFechaHasta.Value.Date.ToShortDateString();

                string ServidorSQL = hb.Database.Connection.DataSource;

                AplicarCredencialesCrystal(
                report,
                ServidorSQL,
                hb.Database.Connection.Database.ToString(),
                "sa",
                "pcn1971@"
            );


                // report.SetDatabaseLogon("sa", "admin123" , ServidorSQL, hb.Database.Connection.Database.ToString());
                report.SetDataSource(Ds);
                //subreport.SetDatabaseLogon("sa", "admin123", ServidorSQL, hb.Database.Connection.Database.ToString());
                subreport.SetDataSource(DSDetalle);

                VisorReporte.crystalReportViewer1.ReportSource = report;

                //////////////////
                ///
                //TableLogOnInfos tableLogOnInfos = VisorReporte.crystalReportViewer1.LogOnInfo;

                //ConnectionInfo connectionInfo = new ConnectionInfo();
                //connectionInfo.DatabaseName = hb.Database.Connection.Database.ToString();
                //connectionInfo.UserID = "reporting";
                //connectionInfo.Password = "pcn1971@";


                //foreach (TableLogOnInfo tableLogOnInfo in tableLogOnInfos)
                //{
                //    tableLogOnInfo.ConnectionInfo = connectionInfo;
                //}
                //////


                VisorReporte.Informe = report;

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }
        }
        public static void rptProduccionEmpleado(CheckBox chkFiltraInsumo,
                                                  ComboBox cmbFiltraInsumo,
                                                  CheckBox chkFiltraFechaDesde,
                                                  CheckBox chkFiltraFechaHasta,
                                                  DateTimePicker dtpFiltraFechaDesde,
                                                  DateTimePicker dtpFiltraFechaHasta,
                                                  CheckBox chkFiltraListaEmpleado,
                                                  CheckedListBox ListaFiltraEmpleados,
                                                  frmReporte VisorReporte)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from VRM in hb.VistaProduccionPorEmpleado
                                select new
                                {
                                    VRM.IDEmpleado,
                                    VRM.Empleado,
                                    VRM.CodIsnumo,
                                    VRM.Insumo,
                                    VRM.Horas,
                                    VRM.Minutos,
                                    VRM.Cantidad,
                                    VRM.Fecha,
                                    VRM.Seccion,
                                    VRM.IDSeccion
                                });
   
                if (chkFiltraInsumo.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Insumo == cmbFiltraInsumo.SelectedValue.ToString()
                                select C);
                }
                if (chkFiltraFechaDesde.Checked && chkFiltraFechaHasta.Checked == false)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFiltraFechaDesde.Value.Date
                                select C);
                }
                else if (chkFiltraFechaDesde.Checked == false && chkFiltraFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha <= dtpFiltraFechaHasta.Value.Date
                                select C);
                }
                else if (chkFiltraFechaDesde.Checked && chkFiltraFechaHasta.Checked)
                {
                    //Consulta = (from C in Consulta
                    //            where C.Fecha >= dtpFiltraFechaDesde.Value.Date && C.Fecha <= dtpFiltraFechaHasta.Value.Date
                    //            select C);
                }

                if (chkFiltraListaEmpleado.Checked)
                {
                    List<int> ListaEmpleado_ID = new List<int>();


                    foreach (string Items in ListaFiltraEmpleados.CheckedItems)
                    {
                        string Texto;
                        int Indice;
                        Texto = Items.ToString();
                        Indice = Texto.IndexOf("-");
                        Texto = Texto.Remove(0, Indice + 2);

                        int IDempleado = Convert.ToInt32(Texto);

                        ListaEmpleado_ID.Add(IDempleado);
                    }

                    Consulta = (from C in Consulta
                                where ListaEmpleado_ID.Contains(C.IDEmpleado)
                                select C);
                }
                var Resultados = Consulta.ToList();
           
                DSrptProduccionEmpleadoSeccion Ds = new DSrptProduccionEmpleadoSeccion();
                var report = new rptProduccionEmpleado();

                int EmpleadoID = -1;
                string InsumoID = "-888";
                int SeccionID = -1;

                string Cambio = "SI";


                foreach (var item in Resultados)
                {
                    int Horas = Convert.ToInt32(item.Horas);
                    int Minutos = Convert.ToInt32(item.Minutos);
                    string HorasString = item.Horas.ToString();
                    string MinutosString = item.Minutos.ToString();
                    int HorasTotalesEmpleado = 0;
                    int MinutosTotalesEmpleado = 0;
                    int HorasTotalesProducto = 0;
                    int MinutosTotalesProducto = 0;
                    int HorasTotalesSeccion = 0;
                    int MinutosTotalesSeccion = 0;
                    string HoraTotalesString = "";
                    string MinutosTotalesString = "";
                    string HoraTotalesProductoString = "";
                    string MinutosTotalesProductoString = "";
                    string HoraTotalesSeccionString = "";
                    string MinutosTotalesSeccionString = "";
                    int Hora = 0;
                    int Minuto = 0;
                    int HoraProducto = 0;
                    int MinutoProducto = 0;

                    // CALCULA TIEMPO TOTAL POR EMPLEADO
                    var ConsultaTiempoTotalEmpleado = (from C in hb.VistaProduccionPorEmpleado
                                                       where C.IDEmpleado == item.IDEmpleado
                                                       group C by new { C.IDEmpleado } into Grupo
                                                       select new
                                                       {
                                                           Horas = Grupo.Sum(x => x.Horas),
                                                           Minutos = Grupo.Sum(x => x.Minutos)

                                                       }).FirstOrDefault();

                    if (ConsultaTiempoTotalEmpleado != null)
                    {
                        HorasTotalesEmpleado = (int)ConsultaTiempoTotalEmpleado.Horas;
                        MinutosTotalesEmpleado = (int)ConsultaTiempoTotalEmpleado.Minutos;
                    }
                    if (MinutosTotalesEmpleado > 60)
                    {
                        HorasTotalesEmpleado = HorasTotalesEmpleado + 1;
                        MinutosTotalesEmpleado = MinutosTotalesEmpleado - 60;

                    }
                    if (HorasTotalesEmpleado < 10)
                        HoraTotalesString = "0" + HorasTotalesEmpleado.ToString();
                    else
                        HoraTotalesString = HorasTotalesEmpleado.ToString();

                    if (MinutosTotalesEmpleado < 10)
                        MinutosTotalesString = "0" + MinutosTotalesEmpleado.ToString();
                    else
                        MinutosTotalesString = MinutosTotalesEmpleado.ToString();

                    //CALCULA TIEMPO TOTAL POR PRODUCTO
                    var ConsultaTiempoTotalProducto = (from C in hb.VistaProduccionPorEmpleado
                                                       where C.IDEmpleado == item.IDEmpleado
                                                            && C.IDSeccion == item.IDSeccion
                                                            && C.CodIsnumo == item.CodIsnumo
                                                       group C by new { C.IDEmpleado, C.CodIsnumo, C.IDSeccion } into Grupo
                                                       select new
                                                       {
                                                           Horas = Grupo.Sum(x => x.Horas),
                                                           Minutos = Grupo.Sum(x => x.Minutos)

                                                       }).FirstOrDefault();

                    if (ConsultaTiempoTotalProducto != null)
                    {
                        HorasTotalesProducto = ConsultaTiempoTotalProducto.Horas;
                        MinutosTotalesProducto = ConsultaTiempoTotalProducto.Minutos;
                    }
                    if (MinutosTotalesProducto > 60)
                    {
                        HorasTotalesProducto = HorasTotalesProducto + 1;
                        MinutosTotalesProducto = MinutosTotalesProducto - 60;
                    }

                    if (HorasTotalesProducto < 10)
                        HoraTotalesProductoString = "0" + HorasTotalesProducto.ToString();
                    else
                        HoraTotalesProductoString = HorasTotalesProducto.ToString();

                    if (MinutosTotalesProducto < 10)
                        MinutosTotalesProductoString = "0" + MinutosTotalesProducto.ToString();
                    else
                        MinutosTotalesProductoString = MinutosTotalesProducto.ToString();



                    //CALCULA TIEMPO TOTAL POR SECCION
                    var ConsultaTiempoTotalSeccion = (from C in hb.VistaProduccionPorEmpleado
                                                      where C.IDEmpleado == item.IDEmpleado
                                                           && C.IDSeccion == item.IDSeccion
                                                      group C by new { C.IDEmpleado, C.IDSeccion } into Grupo
                                                      select new
                                                      {
                                                          Horas = Grupo.Sum(x => x.Horas),
                                                          Minutos = Grupo.Sum(x => x.Minutos)

                                                      }).FirstOrDefault();

                    if (ConsultaTiempoTotalSeccion != null)
                    {
                        HorasTotalesSeccion = ConsultaTiempoTotalSeccion.Horas;
                        MinutosTotalesSeccion = ConsultaTiempoTotalSeccion.Minutos;
                    }
                    if (MinutosTotalesSeccion > 60)
                    {
                        HorasTotalesSeccion = HorasTotalesSeccion + 1;
                        MinutosTotalesSeccion = MinutosTotalesSeccion - 60;
                    }

                    if (HorasTotalesSeccion < 10)
                        HoraTotalesSeccionString = "0" + HorasTotalesSeccion.ToString();
                    else
                        HoraTotalesSeccionString = HorasTotalesSeccion.ToString();

                    if (MinutosTotalesSeccion < 10)
                        MinutosTotalesSeccionString = "0" + MinutosTotalesSeccion.ToString();
                    else
                        MinutosTotalesSeccionString = MinutosTotalesSeccion.ToString();




                    ////////////////////////////////////////////////////////////

                    if (item.Minutos > 60)
                    {
                        Horas = Horas + 1;
                        Minutos = Minutos - 60;
                    }

                    if (Horas < 10)
                        HorasString = "0" + Horas.ToString();
                    else
                        HorasString = Horas.ToString();

                    if (Minutos < 10)
                        MinutosString = "0" + Minutos.ToString();
                    else
                        MinutosString = Minutos.ToString();

                    Ds.Tables[name: "rptRankingProduccionEmpleados"].Rows.Add
                        (new object[] {

                          item.Fecha.Date,
                          item.CodIsnumo,
                          item.Insumo,
                          Convert.ToDecimal(item.Cantidad),
                          "0",
                          HorasString + ":" + MinutosString,
                          item.Empleado,
                          HoraTotalesString +":"+ MinutosTotalesString,
                          HoraTotalesProductoString + ":" + MinutosTotalesProductoString,
                          item.Seccion,
                          HoraTotalesSeccionString + ":" + MinutosTotalesSeccionString,
                        });

                    // ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                }

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;


                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                //if (chkFiltraInsumo.Checked == false)
                //    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroInsumo"]).Text = "";
                //else
                //    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroInsumo"]).Text = cmbFiltraInsumo.Text;

                //if (chkFiltraProducto.Checked == false)
                //    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = "";
                //else
                //    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = cmbFiltraProducto.Text;

                if (chkFiltraFechaDesde.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroDesde"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroDesde"]).Text = dtpFiltraFechaDesde.Value.Date.ToShortDateString();

                if (chkFiltraFechaHasta.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroHasta"]).Text = DateTime.Now.Date.ToShortDateString();
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroHasta"]).Text = dtpFiltraFechaHasta.Value.Date.ToShortDateString();

                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;

                VisorReporte.Informe = report;

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }

        }
        public static void rptProduccionEmpleadoSeccion(DateTimePicker dtpFiltraFechaDesde,
                                                  DateTimePicker dtpFiltraFechaHasta,
                                                  CheckBox chkFiltraSeccion,
                                                  ComboBox cmbFiltraSeccion,
                                                  CheckBox chkFiltraProducto,
                                                  ComboBox cmbFiltraProducto,
                                                  CheckBox chkFiltraInsumo,
                                                  ComboBox cmbFiltraInsumo,
                                                  CheckBox chkFiltraListaEmpleado,
                                                  CheckedListBox ListaFiltraEmpleados,
                                                  CheckBox chkFiltraFechaDesde,
                                                  CheckBox chkFiltraFechaHasta,
                                                  frmReporte VisorReporte)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from Ft in hb.ftVistaProduccionEmpleadoSeccion5(dtpFiltraFechaDesde.Value.Date, dtpFiltraFechaHasta.Value.Date)
                                orderby Ft.Efectividad descending
                                select new
                                {
                                    Ft.CodInsumo,
                                    Ft.Insumo,
                                    Ft.ProductoID,
                                    Ft.Producto,
                                    Ft.Cantidad,
                                    Ft.EmpleadoID,
                                    Ft.Empleado,
                                    Ft.SeccionID,
                                    Ft.Horas,
                                    Ft.Minutos,
                                    Ft.Seccion,
                                    Ft.Efectividad
                                });

                if (chkFiltraSeccion.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.SeccionID == (int)cmbFiltraSeccion.SelectedValue
                                select C);
                }
                if (chkFiltraProducto.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.ProductoID == cmbFiltraProducto.SelectedValue.ToString()
                                select C);
                }
                if (chkFiltraInsumo.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.CodInsumo == cmbFiltraInsumo.SelectedValue.ToString()
                                select C);
                }
                if (chkFiltraListaEmpleado.Checked)
                {
                    List<int> ListaEmpleado_ID = new List<int>();


                    foreach (string Items in ListaFiltraEmpleados.CheckedItems)
                    {
                        string Texto;
                        int Indice;
                        Texto = Items.ToString();
                        Indice = Texto.IndexOf("-");
                        Texto = Texto.Remove(0, Indice + 2);

                        int IDempleado = Convert.ToInt32(Texto);

                        ListaEmpleado_ID.Add(IDempleado);
                    }

                    Consulta = (from C in Consulta
                                where ListaEmpleado_ID.Contains((int)C.EmpleadoID)
                                select C);
                }


                var Resultados = Consulta.ToList();
                
                DataSet1 Ds = new DataSet1();
                var report = new rptProduccionEmpleadoSeccion();

                foreach (var item in Resultados)
                {
                    int Hora = (int)item.Horas;
                    int Minuto = (int)item.Minutos;
                    string HoraString = item.Horas.ToString();
                    string MinutoString = item.Minutos.ToString();

                    if (Minuto >= 60)
                    {
                        while (Minuto >= 60)
                        {
                            Hora = Hora + 1;
                            Minuto = Minuto - 60;
                        }
                        HoraString = Hora.ToString();
                        MinutoString = Minuto.ToString();
                    }
                    if (HoraString.Length < 2)
                        HoraString = "0" + Hora;
                    if (MinutoString.Length < 2)
                        MinutoString = "0" + MinutoString;

                    string SeccionFinal; // DETERMINA SI ESTAMOS EN LA SECCION FINAL
                    string ProductoInsumoID;
                    string ProductoInsumo;

                    var ConsultaSeccion = (from SEC in hb.Seccion
                                           where SEC.ID == item.SeccionID
                                           select SEC).FirstOrDefault();

                    if (ConsultaSeccion.Seccion_Final == "SI")
                    {
                        SeccionFinal = "SI";
                        ProductoInsumoID = item.ProductoID;
                        ProductoInsumo = item.Producto;
                    }
                    else
                    {
                        SeccionFinal = "NO";
                        ProductoInsumoID = item.CodInsumo;
                        ProductoInsumo = item.Insumo;
                    }

                    Ds.Tables[name: "rptRankingProduccionEmpleados"].Rows.Add
                       (new object[] {

                          Convert.ToDateTime("01/01/2001"),
                          ProductoInsumoID,
                          ProductoInsumo,
                          Convert.ToDecimal(item.Cantidad),
                          "0",
                          HoraString + ":" + MinutoString,
                          item.Empleado,
                          "",
                          "",
                          item.Seccion,
                          "",
                          item.Efectividad
                       });
                }

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;


                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                if (chkFiltraInsumo.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroInsumo"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroInsumo"]).Text = cmbFiltraInsumo.Text;

                if (chkFiltraProducto.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = cmbFiltraProducto.Text;

                if (chkFiltraFechaDesde.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroDesde"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroDesde"]).Text = dtpFiltraFechaDesde.Value.Date.ToShortDateString();

                if (chkFiltraFechaHasta.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroHasta"]).Text = DateTime.Now.Date.ToShortDateString();
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroHasta"]).Text = dtpFiltraFechaHasta.Value.Date.ToShortDateString();

                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;

                VisorReporte.Informe = report;

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }
        }

        public static void rptDeposito(frmReporte VisorReporte,PictureBox Picture)
        {
            DataSet1 DS = new DataSet1();

            var report = new rptPP();

            DS.Tables[name: "DepositoImagen"].Rows.Add
                        (new object[] {

                                    GetBytes(Picture.Image)

                        });

            report.SetDataSource(DS);
            VisorReporte.crystalReportViewer1.ReportSource = report;

            VisorReporte.Informe = report; // PARA EXPORTAR A PDF

            VisorReporte.WindowState = FormWindowState.Maximized;
            VisorReporte.TopMost = true;
            VisorReporte.Show();
        }
        public static byte[] GetBytes(Image Imagen)
        {
            MemoryStream ms = new MemoryStream();
            Imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            return ms.ToArray();
        }
        public static void rptStockMercaderia(CheckBox chkFiltraArticulo, ComboBox cmbFiltraArticulo, DateTimePicker DTP, int ListaPrecio, CheckBox chkFiltraStockMin ,CheckBox chkFiltraStockConExistencia, CheckBox chkFiltraStockSinExistencia, frmReporte VisorReporte) // rptCostoMaterialProducto
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    DateTime Fecha = Convert.ToDateTime("01/01/2001").Date;

                    if (DTP.Enabled == true)
                        Fecha = DTP.Value.Date;

                    var Consulta = (from C in hb.ftStockMercaderia(Fecha, ListaPrecio)
                                    select new
                                    {
                                        C.CodArticulo,
                                        C.Articulo,
                                        C.Medida,
                                        C.MedidaID,
                                        C.CategoriaID,
                                        C.Costo,
                                        C.ValorPeso,
                                        C.ValorDolar,
                                        C.StockMin,
                                        C.Existencia,
                                        C.UltimaCotizacion
                                    });

                    if (chkFiltraArticulo.Checked)
                        Consulta = (from C in Consulta
                                    where C.CodArticulo == cmbFiltraArticulo.SelectedValue.ToString()
                                    select C);

                    if (chkFiltraStockMin.Checked)
                        Consulta = (from C in Consulta
                                    where C.StockMin > C.Existencia
                                    select C);

                    if (chkFiltraStockConExistencia.Checked)
                        Consulta = (from C in Consulta
                                    where C.Existencia > 0
                                    select C);

                    if (chkFiltraStockSinExistencia.Checked)
                        Consulta = (from C in Consulta
                                    where C.Existencia <= 0
                                    select C);

                    var Resultados = Consulta.ToList();

                    DSrptStockMercaderia Ds = new DSrptStockMercaderia();
                    var report = new rptStockMercaderia();

                    foreach (var item in Resultados)
                    {
                        Ds.Tables[0].Rows.Add
                        (new object[] {
                                item.CodArticulo,
                                item.Articulo,
                                item.Existencia,
                                item.MedidaID,
                                item.Medida,
                                item.CategoriaID,
                                item.StockMin,
                                item.Costo,
                                item.ValorPeso,
                                item.ValorDolar,
                                item.UltimaCotizacion
                        });
                    }

                    string Cliente;
                    string Telefono;
                    string Mail;
                    string Ciudad;

                    var ConsultaClienteUsuario = (from C in hb.Clientes
                                                  where C.Cliente_Usuario == true
                                                  select C);

                    var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                    var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                    Cliente = ResultadosClienteUsuario.Descripcion;
                    Telefono = ResultadosClienteUsuario.Telefono;
                    Mail = ResultadosClienteUsuario.Email;
                    Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;


                    ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                    ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                    ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                    ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                    if (chkFiltraArticulo.Checked == false)
                        ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = "";
                    else
                        ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = chkFiltraArticulo.Text;

                    report.SetDataSource(Ds);
                    VisorReporte.crystalReportViewer1.ReportSource = report;

                    VisorReporte.Informe = report;
                    VisorReporte.WindowState = FormWindowState.Maximized;
                    VisorReporte.TopMost = true;
                    VisorReporte.Show();
                }
                }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
            
            
        }
        public static void rptOrdenCarga(CheckBox chkFiltraNumeroOrden, 
                                         TextBox txtFiltraNumeroOrden,
                                         CheckBox chkFiltraCliente,
                                         ComboBox cmbFiltraCliente,
                                         CheckBox chkFiltraChofer,
                                         ComboBox cmbFiltraChofer,
                                         DateTimePicker dtpFechaDesde,
                                         DateTimePicker dtpFechaHasta,
                                         frmReporte VisorReporte) // rptOrdenCarga
        {
            using (var hb = new DBdatos())
            {            
                var Consulta = (from C in hb.OrdenCarga_Cuerpo
                                where C.Orden_Carga.Estado_ID != "AN"
                                    && (C.Orden_Carga.Fecha >= dtpFechaDesde.Value.Date && C.Orden_Carga.Fecha <= dtpFechaHasta.Value.Date)
                                select new
                                {
                                    C.Orden_ID,
                                    C.Orden_Carga.Fecha,
                                    C.Orden_Carga.Numero_Orden,
                                    C.Orden_Carga.Chofer_ID,
                                    Chofer=C.Orden_Carga.Empleados.Nombre,
                                    C.ID,
                                    C.Producto_ID,
                                    Producto = C.Productos_Insumos.Descripcion,
                                    C.Cantidad,
                                    C.Cliente_ID,
                                    Cliente = C.Clientes.Descripcion,
                                    C.Lote,
                                    PalletCantidad = C.Pallets,
                                    PalletTipo = C.TipoPallet,
                                    C.Humedad,
                                    C.Acidez
                                });

                if (chkFiltraNumeroOrden.Checked)
                    Consulta = (from C in Consulta
                                where C.Numero_Orden == txtFiltraNumeroOrden.Text
                                select C);

                if (chkFiltraCliente.Checked)
                    Consulta = (from C in Consulta
                                where C.Cliente_ID == (int)cmbFiltraCliente.SelectedValue
                                select C);

                if (chkFiltraChofer.Checked)
                    Consulta = (from C in Consulta
                                where C.Chofer_ID == (int)cmbFiltraChofer.SelectedValue
                                select C);


            
                var Resultados = Consulta.ToList();

                DSrptOrdenCarga Ds = new DSrptOrdenCarga();
                var report = new rptOrdenCarga();

                foreach (var item in Resultados)
                {
                    Ds.Tables[0].Rows.Add
                    (new object[] {
                                item.ID,
                                item.Producto_ID,
                                item.Producto,
                                item.Cantidad,
                                item.Cliente_ID,
                                item.Cliente,
                                item.Lote,
                                item.PalletCantidad,
                                item.PalletTipo,
                                item.Humedad,
                                item.Acidez,
                                "",
                                item.Orden_ID,
                                item.Fecha,
                                item.Numero_Orden,
                                item.Chofer_ID,
                                item.Chofer
                    });
                }

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;


                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                //if (chkFiltraArticulo.Checked == false)
                //    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = "";
                //else
                //    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = chkFiltraArticulo.Text;

                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;
                VisorReporte.Informe = report;

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }
        }
        public static void rptResumenCuenta(                                       
                                            CheckBox chkFiltraCliente,
                                            ComboBox cmbFiltraCliente,                                          
                                            frmReporte VisorReporte) // rptOrdenCarga
        {
            using (var hb = new DBdatos())
            {
                //var Consulta =
                //from t in hb.TICKET
                //join cli in hb.Clientes
                //    on t.Cliente_ID equals cli.ID               
                //group t by new
                //{
                //    t.Cliente_ID,
                //    cli.Descripcion
                //}
                //into g
                //orderby g.Key.Descripcion
                //select new
                //{
                //    Cliente_ID = g.Key.Cliente_ID,
                //    Descripcion = g.Key.Descripcion,
                //    SaldoDeudor = g.Sum(x => x.ImporteTotal - x.ImporteAfectado)
                //};
                var Consulta = (from C in hb.VISTA_RESUMENCUENTA001                              
                               select C);




                if (chkFiltraCliente.Checked)
                    Consulta = (from C in Consulta
                                where C.ClienteID == (int)cmbFiltraCliente.SelectedValue
                                select C);
              
                var Resultados = Consulta.ToList();

                DSResumenCuenta Ds = new DSResumenCuenta();
                var report = new rptResumenCuenta();

                foreach (var item in Resultados)
                {
                    Ds.Tables[0].Rows.Add
                    (new object[] {
                                item.ClienteID,
                                item.Cliente,
                                item.Importe                              
                    });
                }

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;

                //FILTROS
                ((TextObject)report.ReportDefinition.ReportObjects["txtFlitroCliente"]).Text = cmbFiltraCliente.Text;

                //CABEZAL
                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;
                VisorReporte.Informe = report;

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }
        }
        public static void rptCajaArqueo001(frmReporte VisorReporte , long CajaUsuarioID , int CajaID) 

        {
            using (var hb = new DBdatos())
            {
                decimal DineroRetirado = 0;

                var ConsultaDetalle = (from C in hb.VistaCajaMovimientos001
                                       where C.CajaUsuarioID == CajaUsuarioID
                                       orderby C.Fecha
                                       select C);

                var ConsultaDetalleSaldos = (from C in hb.VistaCajaMovimientosTotales001
                                             where C.CajaID == CajaID                                           
                                             select C).FirstOrDefault();

                var ConsultaDatos = (from C in hb.CAJAUSUARIO
                                     where C.ID == CajaUsuarioID                     
                                     select C).FirstOrDefault();

                var Resultados = ConsultaDetalle.ToList();

                DSrptCajaArqueo Ds = new DSrptCajaArqueo();
                var report = new rptCajaArqueo001();

                foreach (var item in Resultados)
                {
                    
                    if(item.Movimiento == "RETIRO DINERO")
                    {
                        DineroRetirado = DineroRetirado + (decimal)(item.Importe * -1);
                    }
                    Ds.Tables[0].Rows.Add
                    (new object[] {
                                item.Fecha.Value.ToShortDateString(),
                                item.Movimiento,
                                item.Cliente,                         
                                item.MedioPago,
                                item.NumeroComprobante,
                                item.Importe
                    });
                }

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;
                string CajaCodigo;
                string Caja;
                string FechaCierre = "No definida";
                
                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;

                CajaCodigo = ConsultaDatos.CAJA.Codigo;
                Caja = ConsultaDatos.CAJA.Descripcion;

                if (ConsultaDatos.FechaCierre != null)
                    FechaCierre = ConsultaDatos.FechaCierre.Value.ToShortDateString();
                
               

                //FILTROS
                //((TextObject)report.ReportDefinition.ReportObjects["txtFlitroCliente"]).Text = cmbFiltraCliente.Text;

                //CABEZAL
                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                //CABEZAL CAJA
                ((TextObject)report.ReportDefinition.ReportObjects["txtCodigoCaja"]).Text = CajaCodigo;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCaja"]).Text = Caja;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCajaFechaCierre"]).Text = FechaCierre;

                //FOOTER SALDOS
                ((TextObject)report.ReportDefinition.ReportObjects["txtEfectivo"]).Text = ConsultaDetalleSaldos.Efectivo.ToString("N2");
                ((TextObject)report.ReportDefinition.ReportObjects["txtRetirado"]).Text = DineroRetirado.ToString("N2");
                //((TextObject)report.ReportDefinition.ReportObjects["txtDebito"]).Text = ConsultaDetalleSaldos.Debito.ToString("N2");
                //((TextObject)report.ReportDefinition.ReportObjects["txtCredito"]).Text = ConsultaDetalleSaldos.Credito.ToString("N2"); ;
                //((TextObject)report.ReportDefinition.ReportObjects["txtTranferencia"]).Text = ConsultaDetalleSaldos.Transferencia.ToString("N2");
                //((TextObject)report.ReportDefinition.ReportObjects["txtCuentaCorriente"]).Text = ConsultaDetalleSaldos.Transferencia.ToString("N2");
                ((TextObject)report.ReportDefinition.ReportObjects["txtSaldoTotal"]).Text = ConsultaDetalleSaldos.Saldo.ToString("N2"); ;
                
                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;
                VisorReporte.Informe = report;

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }
        }
        public static void rptMovientosDiariosTicket(
                                            CheckBox chkFiltraProducto,
                                            ComboBox cmbFiltraProducto,
                                            DateTimePicker dtpFechaDesde,
                                            DateTimePicker dtpFechaHasta,
                                            frmReporte VisorReporte) // rptOrdenCarga
        {
            using (var hb = new DBdatos())
            {                

                var Consulta = (from C in hb.TICKETCUERPO
                                where C.TICKET.Estado != "AN"
                                select C);


                if (chkFiltraProducto.Checked)
                    Consulta = (from C in Consulta
                                where C.Insumo_ID == cmbFiltraProducto.SelectedValue.ToString()
                                select C);

                Consulta = (from C in Consulta
                            where C.TICKET.Fecha >= dtpFechaDesde.Value.Date
                            select C);

                Consulta = (from C in Consulta
                            where C.TICKET.Fecha <= dtpFechaHasta.Value.Date
                            select C);

                var Resultados = Consulta.ToList();

                DSrptMovientosDiariosTicket Ds = new DSrptMovientosDiariosTicket();
                var report = new rptMovientosDiariosTicket();

                foreach (var item in Resultados)
                {
                    Ds.Tables[0].Rows.Add
                    (new object[] {
                                item.Insumo_ID,
                                item.Productos_Insumos.Descripcion,
                                item.Cantidad,
                                item.Precio,
                                (item.Cantidad * item.Precio)
                    });
                }

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);


                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;

                //FILTROS
                ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = cmbFiltraProducto.Text;
                ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroDesde"]).Text = dtpFechaDesde.Value.ToShortDateString();
                ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroHasta"]).Text = dtpFechaHasta.Value.ToShortDateString();

                //CABEZAL
                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;
                VisorReporte.Informe = report;

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }
        }
        public static void rptListaPrecioCode(
                                           CheckBox chkFiltraRubro,
                                           ComboBox cmbFiltraRubro,
                                           frmReporte VisorReporte) // rptOrdenCarga
        {
            using (var hb = new DBdatos())
            {
                var report = new rptListaPrecioCode();

                var Consulta = (from C in hb.Productos_Insumos
                                join LP in hb.LISTAPRECIOCUERPO on C.Codigo equals LP.Articulo_ID
                                where C.Estado == "SI"
                                orderby C.Descripcion
                                select new
                                {
                                    C.Codigo,
                                    C.Descripcion,
                                    LP.Precio,
                                    CodBarra = C.Codigo,
                                    RubroID=C.Categoria_ID,
                                    Rubro=C.Categorias_InsPro.Descripcion
                                });


                if (chkFiltraRubro.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.RubroID == (int)cmbFiltraRubro.SelectedValue
                                select C);

                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroRubro"]).Text = cmbFiltraRubro.Text;
                }
                   

                //Consulta = (from C in Consulta
                //            where C.TICKET.Fecha >= dtpFechaDesde.Value.Date
                //            select C);

                //Consulta = (from C in Consulta
                //            where C.TICKET.Fecha <= dtpFechaHasta.Value.Date
                //            select C);

                var Resultados = Consulta.ToList();

                
                DSrptListaPrecioCode Ds = new DSrptListaPrecioCode();
                

                Zen.Barcode.Code128BarcodeDraw generador = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                foreach (var item in Resultados)
                {
                    var imagen = generador.Draw(item.Codigo, 60);

                    byte[] CodigoBarra;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        CodigoBarra = ms.ToArray();
                    }

                    Ds.Tables[0].Rows.Add
                    (new object[] {
                                item.Codigo,
                                item.Descripcion,                              
                                item.Precio,
                                CodigoBarra,
                                item.Rubro,
                                item.RubroID
                    });
                }

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);


                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;

                ////FILTROS
                //((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = cmbFiltraProducto.Text;
                //((TextObject)report.ReportDefinition.ReportObjects["txtFiltroDesde"]).Text = dtpFechaDesde.Value.ToShortDateString();
                //((TextObject)report.ReportDefinition.ReportObjects["txtFiltroHasta"]).Text = dtpFechaHasta.Value.ToShortDateString();

                //CABEZAL
                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;
                VisorReporte.Informe = report;

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }
        }
        public static void rptStockPorLote(CheckBox chkFiltraProducto,
                                           ComboBox cmbFiltraProducto,
                                           CheckBox chkFiltraLote,
                                           TextBox  txtFiltraLote, 
                                           CheckBox chkFiltraFechaDesde,
                                           DateTimePicker dtpFechaDesde,
                                           //CheckBox chkFiltraConExistencia,
                                           frmReporte VisorReporte) // rptOrdenCarga
        {
            using (var hb = new DBdatos())
            {
                DateTime FechaDesde;
                string Lote = "";

                if (chkFiltraFechaDesde.Checked)
                    FechaDesde = dtpFechaDesde.Value.Date;
                else
                    FechaDesde = Convert.ToDateTime("01/01/2001");

                if (chkFiltraLote.Checked)
                    Lote = txtFiltraLote.Text;

                var Consulta = (from C in hb.ftStockProductoFinaLPorLote_01(FechaDesde, 0, Lote)
                                where C.Existencia > 0
                                select new
                                {
                                    C.ProductoID,
                                    C.Producto,
                                    C.Lote,
                                    C.Medida,
                                    C.Existencia,
                                    C.CategoriaID,                                                                   
                                });

                if (chkFiltraProducto.Checked)
                    Consulta = (from C in Consulta
                                where C.ProductoID == cmbFiltraProducto.SelectedValue.ToString()
                                select C);

                if (chkFiltraLote.Checked)
                    Consulta = (from C in Consulta
                                where C.Lote == txtFiltraLote.Text
                                select C);
           
                var Resultados = Consulta.ToList();

                DSrptStockPorLote Ds = new DSrptStockPorLote();
                var report = new rptStockPorLote();

                foreach (var item in Resultados)
                {
                    Ds.Tables[0].Rows.Add
                    (new object[] {
                                item.ProductoID,
                                item.Producto,
                                item.Lote,
                                item.Medida,
                                item.Existencia,
                                item.CategoriaID,
                                ""                               
                    });
                }

                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                Cliente = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;


                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                //if (chkFiltraArticulo.Checked == false)
                //    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = "";
                //else
                //    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = chkFiltraArticulo.Text;

                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;
                VisorReporte.Informe = report;

                VisorReporte.WindowState = FormWindowState.Maximized;
                VisorReporte.TopMost = true;
                VisorReporte.Show();
            }
        }
        public static void AplicarCredencialesCrystal(ReportDocument report, string servidor, string bd, string usuario, string password)
        {
            // Configurar credenciales
            ConnectionInfo connectionInfo = new ConnectionInfo()
            {
                ServerName = servidor,
                DatabaseName = bd,
                UserID = usuario,
                Password = password,
                IntegratedSecurity = false
            };

            // 1) Tablas del reporte principal
            foreach (Table tabla in report.Database.Tables)
            {
                TableLogOnInfo logonInfo = tabla.LogOnInfo;
                logonInfo.ConnectionInfo = connectionInfo;
                tabla.ApplyLogOnInfo(logonInfo);
            }

            // 2) Tablas de los subreportes
            foreach (Section seccion in report.ReportDefinition.Sections)
            {
                foreach (ReportObject obj in seccion.ReportObjects)
                {
                    if (obj.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject sub = (SubreportObject)obj;
                        ReportDocument subDoc = report.OpenSubreport(sub.SubreportName);

                        foreach (Table tabla in subDoc.Database.Tables)
                        {
                            TableLogOnInfo logonInfo = tabla.LogOnInfo;
                            logonInfo.ConnectionInfo = connectionInfo;
                            tabla.ApplyLogOnInfo(logonInfo);
                        }
                    }
                }
            }
        }

    }
}
