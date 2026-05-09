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
using PCodin_Sinlacc.Formularios.ESTADISTICAS.Plantillas;
using CrystalDecisions.Shared;
using PCodin_Sinlacc.Formularios.ESTADISTICAS;
using System.IO;
using System.Drawing;
using QRCoder;
using PCodin_Sinlacc.Formularios.ESTADISTICAS.Plantillas_Dataset;

namespace PCodin_Sinlacc.Clases
{
    class clsQueryPlantillas
    {
        //public static byte[] ConversionImagen(string nombrearchivo)
        //{
        //    //Declaramos fs para poder abrir la imagen.
        //    //FileStream fs = new FileStream(nombrearchivo, FileMode.Open);

        //    //// Declaramos un lector binario para pasar la imagen
        //    //// a bytes
        //    //BinaryReader br = new BinaryReader(fs);
        //    //byte[] imagen = new byte[(int)fs.Length];
        //    //br.Read(imagen, 0, (int)fs.Length);
        //    //br.Close();
        //    //fs.Close();
        //    //return imagen;
        //}
        public static void PlaTicket(long TicketID,frmReporte VisorReporte)
        {
            using (var hb = new DBdatos())
            {
                decimal CantidadArticulos = 0;
                decimal ImporteTotal = 0;

                var ConsultaCliente = (from C in hb.Clientes
                                       where C.Cliente_Usuario == true
                                       select C).FirstOrDefault();

                var ConsultaLogo = (from L in hb.PcnConfiguraciones
                                    select L).FirstOrDefault();

                var ConsultaDimensionLogo = (from L in hb.ClientesLogo
                                             select L).FirstOrDefault();

                var ConsultaCabezal = (from CA in hb.TICKET
                                       where CA.ID == TicketID
                                       select CA).FirstOrDefault();

                var ConsultaCuerpo = (from CU in hb.TICKETCUERPO
                                      where CU.Ticket_ID == TicketID
                                      select new
                                      {
                                          Articulo = CU.Productos_Insumos.Descripcion,
                                          Precio = CU.Precio,
                                          Cantidad = CU.Cantidad
                                      });

                var Resultados = ConsultaCuerpo.ToList();

                DSPlaOrdenCarga Ds = new DSPlaOrdenCarga();
                var report = new PlaTicket();
                
                byte[] Logo = null;

                foreach (var item in Resultados)
                {
                   
                  
                    Ds.Tables["TICKET"].Rows.Add
                    (new object[] {
                                item.Articulo,
                                item.Precio,                                                           
                    });

                    CantidadArticulos = (decimal)(CantidadArticulos + item.Cantidad);
                    ImporteTotal = ImporteTotal + item.Precio;
                }

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                //DATOS EMPRESA
                string Empresa = ResultadosClienteUsuario.Descripcion;
                string CUIT = "30-35246875-8";
                string Direccion = "Bv España 775";
                string Ciudad = "Colazo - Cordoba";
                string CondicionIVA = "RESPONSABLE INSCRIPTO";
                string Comprobante = ConsultaCabezal.MOVIMIENTOS.Descripcion;
                string NumeroComprobante = ConsultaCabezal.NumeroTicket.Substring(0, 4) + " - " + ConsultaCabezal.NumeroTicket.Substring(4, 8);
                string Fecha = ConsultaCabezal.Fecha.ToShortDateString();
                string Hora = ConsultaCabezal.Fecha.ToShortTimeString();
                string Cliente = ConsultaCabezal.Clientes.Descripcion;

                //((PictureObject)report.ReportDefinition.ReportObjects["Picture1"]).Width = ConsultaDimensionLogo.Ancho;
                //((PictureObject)report.ReportDefinition.ReportObjects["Picture1"]).Height = ConsultaDimensionLogo.Largo;

                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Empresa;

                ((TextObject)report.ReportDefinition.ReportObjects["txtCUIT"]).Text = CUIT;
                ((TextObject)report.ReportDefinition.ReportObjects["txtDireccion"]).Text = Direccion;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCondicionIVA"]).Text = CondicionIVA;

                ((TextObject)report.ReportDefinition.ReportObjects["txtComprobante"]).Text = Comprobante;


                //FOOTER
                ((TextObject)report.ReportDefinition.ReportObjects["txtImporteTotal"]).Text = ImporteTotal.ToString("N2");
                ((TextObject)report.ReportDefinition.ReportObjects["txtCantidad"]).Text = CantidadArticulos.ToString();
                ((TextObject)report.ReportDefinition.ReportObjects["txtNumeroComprobante"]).Text = NumeroComprobante;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCliente"]).Text = Cliente;

                CrystalDecisions.Shared.PaperSize DimensionesHoja = new CrystalDecisions.Shared.PaperSize();

                //DimensionesHoja = P

                report.SetDataSource(Ds);
                report.Section3.Height = 400;
                //report.PrintOptions.PaperSize = PaperSize
                VisorReporte.crystalReportViewer1.ReportSource = report;
                report.Section3.Height = 400;
                //VARIABLE QUE SE PASA AL frmReporte para que se pueda refrescar el informe en caso de modificar logo o Margen
                VisorReporte.Informe = report;

                VisorReporte.Show();
            }
        }
        public static void PlaOrdenCarga(long OrdenCargaID, frmReporte VisorReporte)
        {
            using (var hb = new DBdatos())
            {
                var ConsultaCliente = (from C in hb.Clientes
                                       where C.Cliente_Usuario == true
                                       select C).FirstOrDefault();

                var ConsultaLogo = (from L in hb.PcnConfiguraciones
                                    select L).FirstOrDefault();

                var ConsultaDimensionLogo = (from L in hb.ClientesLogo
                                             select L).FirstOrDefault();

                var Consulta = (from OCC in hb.OrdenCarga_Cuerpo
                                join OC in hb.Orden_Carga on OCC.Orden_ID equals OC.ID 
                                where OCC.Orden_ID == OrdenCargaID
                                
                                select new
                                {
                                    OCC.Orden_Carga.Numero_Orden,
                                    OCC.Orden_Carga.Clientes,
                                    Cliente = OCC.Orden_Carga.Clientes.Descripcion,
                                    ClienteID = OCC.Orden_Carga.Cliente_ID,
                                    Producto = OCC.Productos_Insumos.Descripcion,
                                    ProductoID = OCC.Producto_ID,
                                    Medida = OCC.Medidas_Producto.Descripcion,
                                    Medida2 = OCC.Productos_Insumos.Medidas_Producto1.Descripcion,
                                    OCC.Cantidad,
                                    CiudadCli = OCC.Orden_Carga.Clientes.Ciudades.Descripcion,
                                    TelefonoCli = OCC.Orden_Carga.Clientes.Telefono,
                                   
                                });

                var Resultados = Consulta.ToList();

                //DSPlaOrdenCarga Ds = new DSPlaOrdenCarga();
                DSPlaOrdenCarga Ds = new DSPlaOrdenCarga();
                var report = new PlaOrdenCarga();

                byte[] Logo = null;

                foreach (var item in Resultados)
                {
                    decimal CantidadTotalRef = 0;
                    decimal CantidadPenRef = 0;
                    decimal CantidadAfecta = 0;

                    Ds.Tables[0].Rows.Add
                    (new object[] {
                                item.Numero_Orden,
                                item.ClienteID,
                                item.Cliente,
                                item.ProductoID,
                                item.Producto,
                                item.Medida,
                                item.Medida2,
                                item.Cantidad,
                                item.CiudadCli,
                                item.TelefonoCli
                               // ConversionImagen(ConsultaLogo.Logo.ToString())
                    });
                }

                //DATOS EMPRESA
                string Empresa;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                //DATOS EMPRESA
                Empresa = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;

                //DATOS EMPRESA




                ((PictureObject)report.ReportDefinition.ReportObjects["Picture1"]).Width = ConsultaDimensionLogo.Ancho;
                ((PictureObject)report.ReportDefinition.ReportObjects["Picture1"]).Height = ConsultaDimensionLogo.Largo;

                ((TextObject)report.ReportDefinition.ReportObjects["txtFechaEmision"]).Text = DateTime.Now.Date.ToShortDateString();
                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Empresa;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;

                //VARIABLE QUE SE PASA AL frmReporte para que se pueda refrescar el informe en caso de modificar logo o Margen
                VisorReporte.Informe = report;

                VisorReporte.Show();
            }
        }
        public static void PlaOrdenCargaPlanilla(long OrdenCargaID, frmReporte VisorReporte)
        {
            using (var hb = new DBdatos())
            {
                var ConsultaCliente = (from C in hb.Clientes
                                       where C.Cliente_Usuario == true
                                       select C).FirstOrDefault();

                var ConsultaLogo = (from L in hb.PcnConfiguraciones
                                    select L).FirstOrDefault();

                var ConsultaDimensionLogo = (from L in hb.ClientesLogo
                                             select L).FirstOrDefault();
                var ConsultaCabezal = (from OC in hb.Orden_Carga
                                       where OC.ID == OrdenCargaID
                                       select OC).FirstOrDefault();

                var ConsultaCuerpo = (from OCC in hb.OrdenCarga_Cuerpo
                                      join OC in hb.Orden_Carga on OCC.Orden_ID equals OC.ID
                                      where OCC.Orden_ID == OrdenCargaID

                                      select new
                                      {
                                          OCC.Orden_Carga.Numero_Orden,
                                          OCC.Orden_Carga.Clientes,
                                          Cliente = OCC.Clientes.Descripcion,
                                          ClienteID = OCC.Cliente_ID,
                                          Producto = OCC.Productos_Insumos.Descripcion,
                                          ProductoID = OCC.Producto_ID,
                                          Medida = OCC.Medidas_Producto.Descripcion,
                                          Medida2 = OCC.Productos_Insumos.Medidas_Producto1.Descripcion,
                                          OCC.Cantidad,
                                          CiudadCli = OCC.Clientes.Ciudades.Descripcion,
                                          TelefonoCli = OCC.Clientes.Telefono,
                                          OCC.Lote,
                                      });

                var Resultados = ConsultaCuerpo.ToList();

                //DSPlaOrdenCarga Ds = new DSPlaOrdenCarga();
                DSPlaOrdenCarga Ds = new DSPlaOrdenCarga();
                var report = new PlaOrdenCargaPlanilla();

                byte[] Logo = null;

                foreach (var item in Resultados)
                {
                    decimal CantidadTotalRef = 0;
                    decimal CantidadPenRef = 0;
                    decimal CantidadAfecta = 0;

                    Ds.Tables[0].Rows.Add
                    (new object[] {
                                item.Numero_Orden,
                                item.ClienteID,
                                item.Cliente,
                                item.ProductoID,
                                item.Producto,
                                item.Medida,
                                item.Medida2,
                                item.Cantidad,
                                item.CiudadCli,
                                item.TelefonoCli,                              
                                "",
                                item.Lote
                               // ConversionImagen(ConsultaLogo.Logo.ToString())
                    });
                }

                //DATOS EMPRESA
                string Empresa;
                string Telefono;
                string Mail;
                string Chofer;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                //DATOS EMPRESA
                Empresa = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Chofer = ConsultaCabezal.Empleados.Nombre;

                //DATOS EMPRESA




                ((PictureObject)report.ReportDefinition.ReportObjects["Picture1"]).Width = ConsultaDimensionLogo.Ancho;
                ((PictureObject)report.ReportDefinition.ReportObjects["Picture1"]).Height = ConsultaDimensionLogo.Largo;

                ((TextObject)report.ReportDefinition.ReportObjects["txtFechaEmision"]).Text = DateTime.Now.Date.ToShortDateString();
                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Empresa;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtChofer"]).Text = Chofer;

                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;

                //VARIABLE QUE SE PASA AL frmReporte para que se pueda refrescar el informe en caso de modificar logo o Margen
                VisorReporte.Informe = report;

                VisorReporte.Show();
            }
        }
        public static void PlaPresupuesto001(DataGridView DGV,frmReporte VisorReporte , int ClienteID , string SubTotal , string DescuentoPorcentaje , string DescuentoAplicado)
        {
            using (var hb = new DBdatos())
            {
               
                var ConsultaLogo = (from L in hb.PcnConfiguraciones
                                    select L).FirstOrDefault();

                var ConsultaDimensionLogo = (from L in hb.ClientesLogo
                                             select L).FirstOrDefault();

                DSPlaPresupuesto001 Ds = new DSPlaPresupuesto001();
                var report = new PlaPresupuesto001();

                byte[] Logo = null;

                for (var i = 0; i < DGV.RowCount; i++)
                {
                    

                    Ds.Tables[0].Rows.Add
                    (new object[] {
                                DGV.Rows[i].Cells["colCodigo"].Value.ToString(),
                                DGV.Rows[i].Cells["colArticulo"].Value.ToString(),
                                Convert.ToDecimal(DGV.Rows[i].Cells["colCantidad"].Value),
                                Convert.ToDecimal(DGV.Rows[i].Cells["colPrecio"].Value),
                                Convert.ToDecimal(DGV.Rows[i].Cells["colTotal"].Value),

                    });
                }

                //DATOS EMPRESA
                string Empresa;
                string Telefono;
                string Mail;
                string Ciudad;

                var ConsultaClienteUsuario = (from C in hb.Clientes
                                              where C.Cliente_Usuario == true
                                              select C);

                var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                //DATOS EMPRESA
                Empresa = ResultadosClienteUsuario.Descripcion;
                Telefono = ResultadosClienteUsuario.Telefono;
                Mail = ResultadosClienteUsuario.Email;
                Ciudad = ResultadosClienteUsuario.Ciudades.Descripcion;

                //DATOS EMPRESA
                ((PictureObject)report.ReportDefinition.ReportObjects["Picture1"]).Width = ConsultaDimensionLogo.Ancho;
                ((PictureObject)report.ReportDefinition.ReportObjects["Picture1"]).Height = ConsultaDimensionLogo.Largo;

                ((TextObject)report.ReportDefinition.ReportObjects["txtFechaEmision"]).Text = DateTime.Now.Date.ToShortDateString();
                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Empresa;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;
                
                ((TextObject)report.ReportDefinition.ReportObjects["txtDescuentoAplicado"]).Text = DescuentoAplicado;
                ((TextObject)report.ReportDefinition.ReportObjects["txtSubTotal"]).Text = SubTotal;

                if(DescuentoAplicado != "0,00" && DescuentoAplicado != "0")
                {                   
                    ((TextObject)report.ReportDefinition.ReportObjects["txtDescuentoPorcentaje"]).Text = (DescuentoPorcentaje + " % ");                 
                }
                else
                {
                    ((TextObject)report.ReportDefinition.ReportObjects["txtLeyendaDescuento"]).Text = "";
                    ((TextObject)report.ReportDefinition.ReportObjects["txtDescuentoPorcentaje"]).Text = "";
                }


                //DATOS CLIENTE
                string Cliente="";
                string ClienteCiudad="";
                string ClienteTelefono="";

                var ConsultaCliente = (from C in hb.Clientes
                                       where C.ID == ClienteID
                                       select C).FirstOrDefault();

                Cliente = ConsultaCliente.Descripcion;
                ClienteCiudad = ConsultaCliente.Ciudades.Descripcion;
                ClienteTelefono = ConsultaCliente.Telefono;

                //DATOS CLIENTE
                ((TextObject)report.ReportDefinition.ReportObjects["txtClienteNombre"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtClienteCiudad"]).Text = ClienteCiudad;
                ((TextObject)report.ReportDefinition.ReportObjects["txtClienteTel"]).Text = ClienteTelefono;

                report.SetDataSource(Ds);
                VisorReporte.crystalReportViewer1.ReportSource = report;

                //VARIABLE QUE SE PASA AL frmReporte para que se pueda refrescar el informe en caso de modificar logo o Margen
                VisorReporte.Informe = report;

                VisorReporte.Show();
            }
        }
        public static void EtiquetaCarga001(long OrdenCargaID, frmReporte VisorReporte , string TipoImpresion , long ExitenciaProductoID , int Copias , string Impresora , long OrdenCargaCuerpo_ID)
        {
            using (var hb = new DBdatos())
            {
                var report = new EtiquetaCarga001();
                //var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                //                   where EPT.OrdenCargaID == OrdenCargaID
                //                        && EPT.Productos_Insumos.Pallet == "SI"
                //                        && EPT.Estado_ID != "AN"
                //                   select EPT);

                var ConsultaPrincipal = (from OCC in hb.OrdenCarga_Cuerpo
                                         where OCC.Orden_ID == OrdenCargaID
                                         && OCC.Orden_Carga.Estado_ID != "AN"                                        
                                         select OCC);

                if (TipoImpresion == "Individual")
                {

                    ConsultaPrincipal = (from C in ConsultaPrincipal
                                         where C.ID == OrdenCargaCuerpo_ID
                                         select C);
                   
                }
                    

                var Resultados = ConsultaPrincipal.ToList();
                //List<string> PalletsYaImpresos = new List<string>();

                foreach (var item in Resultados)
                {
                    if (item.TipoPallet != "Suelto")
                    {
                        int CantidadCopias = 0;

                        if (TipoImpresion == "Multiple")
                        {
                            if (item.Pallets < 1)
                                CantidadCopias = 1;
                            else
                                CantidadCopias = Convert.ToInt32(item.Pallets);
                        }
                        if (TipoImpresion == "Individual")
                            CantidadCopias = Copias;



                        var ConsultaNumProduccion = (from EPT in hb.Existencia_ProductoTerminado
                                                     where EPT.OrdenCargaID == OrdenCargaID
                                                        && EPT.OrdenCargaCuerpo_ID == item.ID
                                                     // && !PalletsYaImpresos.Contains(EPT.Numero_Produccion)                                                
                                                     select EPT);

                        if (TipoImpresion == "Individual")
                        {
                            //ConsultaNumProduccion = (from C in ConsultaNumProduccion
                            //                         where C.OrdenCargaCuerpo_ID == OrdenCargaCuerpo_ID
                            //                         orderby C.Numero_Produccion
                            //                         select C);
                        }

                        var ResultadosNumProduccion = ConsultaNumProduccion.FirstOrDefault();

                        //VARIABLE PARA SABER LAS CANTIDADES DE UNIDADES POR PALLET
                        decimal CantidadUnidades = 0;

                        if (item.TipoPallet == "Mixto")
                            CantidadUnidades = item.Cantidad;
                        else
                        {
                            var ConsultaUnidades = (from PRO in hb.Productos_Insumos
                                                    where PRO.Pallet == "SI"
                                                        && PRO.ProductoPallet == item.Producto_ID
                                                        && PRO.Estado == "SI"
                                                    select PRO).FirstOrDefault();

                            CantidadUnidades = (decimal)ConsultaUnidades.ProductoPalletCantidad;
                        }


                        //PalletsYaImpresos.Add(ResultadosNumProduccion.Numero_Produccion);

                        //var ConsultaOC = (from OC in hb.Orden_Carga
                        //                  where OC.ID == item.OrdenCargaID
                        //                  select OC).FirstOrDefault();                 

                        //var ConsultaOCC = (from OCC in hb.OrdenCarga_Cuerpo
                        //                   where OCC.Orden_ID == item.OrdenCargaID
                        //                    && OCC.Producto_ID == item.Productos_Insumos.ProductoPallet
                        //                   select OCC).FirstOrDefault();

                        var ConsultaLogo = (from L in hb.PcnConfiguraciones
                                            select L).FirstOrDefault();

                        var ConsultaDimensionLogo = (from L in hb.ClientesLogo
                                                     select L).FirstOrDefault();

                        DSEtiquetaCarga001 Ds = new DSEtiquetaCarga001();
                        //var report = new EtiquetaCarga001();

                        Ds.Tables[0].Rows.Add
                            (new object[] {
                                ResultadosNumProduccion.Numero_Produccion
                            });


                        //DATOS ETIQUETA
                        string ProductoID = item.Producto_ID;
                        string Producto = item.Productos_Insumos.Descripcion;
                        string Lote = item.Lote;
                        string Unidades = CantidadUnidades.ToString();
                        string Humedad = item.Humedad.ToString() + " %";
                        string Acidez = item.Acidez.ToString() + " %";
                        string Chofer = item.Orden_Carga.Empleados.Nombre;
                        string Ciudad = item.Clientes.Ciudades.Descripcion;
                        string Cliente = item.Clientes.Descripcion;
                        string ClienteID = item.Cliente_ID.ToString();

                        var ConsultaClienteUsuario = (from C in hb.Clientes
                                                      where C.Cliente_Usuario == true
                                                      select C);

                        var ResultadosClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();
                        var ResultadosClienteUsuario2 = ConsultaClienteUsuario.ToList();

                        ((TextObject)report.ReportDefinition.ReportObjects["txtProducto"]).Text = Producto;
                        ((TextObject)report.ReportDefinition.ReportObjects["txtCodProducto"]).Text = ProductoID;
                        ((TextObject)report.ReportDefinition.ReportObjects["txtLote"]).Text = Lote;
                        ((TextObject)report.ReportDefinition.ReportObjects["txtUnidades"]).Text = Unidades;
                        ((TextObject)report.ReportDefinition.ReportObjects["txtHumedad"]).Text = Humedad;
                        ((TextObject)report.ReportDefinition.ReportObjects["txtAcidez"]).Text = Acidez;
                        ((TextObject)report.ReportDefinition.ReportObjects["txtChofer"]).Text = Chofer;
                        ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;
                        ((TextObject)report.ReportDefinition.ReportObjects["txtCliente"]).Text = Cliente;
                        ((TextObject)report.ReportDefinition.ReportObjects["txtClienteID"]).Text = ClienteID;

                        report.SetDataSource(Ds);
                        //VisorReporte.crystalReportViewer1.ReportSource = report;

                        //VARIABLE QUE SE PASA AL frmReporte para que se pueda refrescar el informe en caso de modificar logo o Margen
                        // VisorReporte.Informe = report;

                        if (Impresora != "")
                            report.PrintOptions.PrinterName = Impresora;
                        else
                        {
                            MessageBox.Show("No selecciono impresora", "Error");
                            break;
                        }

                        report.PrintToPrinter(CantidadCopias, false, 1, 1);
                    }
                }


                //VisorReporte.Show();


            }
        }
    }
}
