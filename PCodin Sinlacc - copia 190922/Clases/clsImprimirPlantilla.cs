using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Datos;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using QRCoder;
using Microsoft.Office.Interop.Excel;
using Font = System.Drawing.Font;

namespace PCodin_Sinlacc.Clases
{
    public  class clsImprimirPlantilla
    {
        //PARAMETROS
        public long ID = 0;
        public PrintDocument PD = new PrintDocument();
        public PrintPreviewDialog PPD = new PrintPreviewDialog();
        public int LargoPapel;
        public DataGridView DGV;

        public void ImprimirTicket(long IDImprimir , DataGridView DGVImprimir , System.Windows.Forms.CheckBox chkAutomatico)
        {
            ID = IDImprimir;
            DGV = DGVImprimir;
            PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);
            PD.BeginPrint += new PrintEventHandler(PD_BeginPrint);

            PPD.Document = PD;
            if (chkAutomatico.Checked)
                PD.Print();
            else
            {
                (PPD as Form).WindowState = FormWindowState.Maximized;
                PPD.ShowDialog();
                PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);
                PD.BeginPrint += new PrintEventHandler(PD_BeginPrint);


            }          
        }
        public void ImprimirTicketCobro(long IDImprimir, System.Windows.Forms.CheckBox chkAutomatico)
        {
            ID = IDImprimir;
           
            PD.PrintPage += new PrintPageEventHandler(PD_PrintPageTicketCobro);
            PD.BeginPrint += new PrintEventHandler(PD_BeginPrintTicketCobro);

            PPD.Document = PD;
            if (chkAutomatico.Checked)
                PD.Print();
            else
            {
                (PPD as Form).WindowState = FormWindowState.Maximized;
                PPD.ShowDialog();
                PD.PrintPage += new PrintPageEventHandler(PD_PrintPageTicketCobro);
                PD.BeginPrint += new PrintEventHandler(PD_BeginPrintTicketCobro);


            }
        }
        public void ImprimirEtiquetaPrecio(long IDImprimir, DataGridView DGVImprimir , bool Automatico)
        {
            ID = IDImprimir;
            DGV = DGVImprimir;
            PD.PrintPage += new PrintPageEventHandler(PD_PrintPageEtiquetaPrecio);
            PD.BeginPrint += new PrintEventHandler(PD_BeginPrintEtiquetaPrecio);

            PPD.Document = PD;

            if(Automatico == true)
             PD.Print();
            else
            {
                (PPD as Form).WindowState = FormWindowState.Maximized;
                PPD.ShowDialog();
                PD.PrintPage += new PrintPageEventHandler(PD_PrintPageEtiquetaPrecio);
                PD.BeginPrint += new PrintEventHandler(PD_BeginPrintEtiquetaPrecio);
            }
            
        }
        public void ImprimirEtiqueta001(long IDImprimir, DataGridView DGVImprimir, System.Windows.Forms.CheckBox chkAutomatico)
        {
            ID = IDImprimir;
            DGV = DGVImprimir;
            PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);
            PD.BeginPrint += new PrintEventHandler(PD_BeginPrint);

            PPD.Document = PD;
            if (chkAutomatico.Checked)
                PD.Print();
            else
            {
                (PPD as Form).WindowState = FormWindowState.Maximized;
                PPD.ShowDialog();
                PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);
                PD.BeginPrint += new PrintEventHandler(PD_BeginPrint);


            }


        }
        public void PD_BeginPrintEtiquetaPrecio(object sender, PrintEventArgs e)
        {
            //LargoPapel = 86;

            //PageSettings pagesetup = new PageSettings();
            //pagesetup.PaperSize = new PaperSize("Custom", D, LargoPapel);
            //PD.DefaultPageSettings = pagesetup;

            int dpi = 203; // estándar térmico

            // 👉 Elegí ancho según impresora
            int anchoMM = 80; // 58, 60, 80, etc.

            int anchoPx = (int)(anchoMM * dpi / 25.4);

            PD.DefaultPageSettings.Margins = new Margins(1, 1, 1, 1);
            PD.DefaultPageSettings.PaperSize = new PaperSize("Custom", 290, 1000); // alto grande temporal
        }
        public void PD_BeginPrintTicketCobro(object sender, PrintEventArgs e)
        {
            LargoPapel = 220;

            PageSettings pagesetup = new PageSettings();
            pagesetup.PaperSize = new PaperSize("Custom", 270, LargoPapel);
            PD.DefaultPageSettings = pagesetup;
        }
        public void PD_BeginPrint(object sender, PrintEventArgs e)
        {
            int CantidadArticulos = 0;
            for (int row = 0; row < DGV.RowCount; row++)
            {
                CantidadArticulos++;
                if (DGV.Rows[row].Cells["colArticulo"].Value.ToString().Length > 26)
                    CantidadArticulos++;
            }
            LargoPapel = CantidadArticulos * 15 + 300;

            PageSettings pagesetup = new PageSettings();
            pagesetup.PaperSize = new PaperSize("Custom", 270, LargoPapel);
            PD.DefaultPageSettings = pagesetup;
        }
        public void PD_PrintPageEtiquetaPrecio(object sender, PrintPageEventArgs e)
        {
            //Font f12b = new Font("Calibri", 13, FontStyle.Bold);
            //Font f10b = new Font("Roboto", 25, FontStyle.Bold);

            //int leftmargin = PD.DefaultPageSettings.Margins.Left;
            //int centermargin = PD.DefaultPageSettings.PaperSize.Width / 2;
            //int rightmargin = PD.DefaultPageSettings.Margins.Right;

            //StringFormat right = new StringFormat();
            //StringFormat center = new StringFormat();
            //right.Alignment = StringAlignment.Far;
            //center.Alignment = StringAlignment.Center;

            //using (var hb = new DBdatos())
            //{
            //    string Articulo;

            //    var Consulta = (from C in hb.LISTAPRECIOCUERPO
            //                    where C.ID == ID
            //                    select C).FirstOrDefault();

            //    e.Graphics.DrawString(Consulta.Productos_Insumos.Descripcion, f12b, Brushes.Black, centermargin, 10, center);
            //    e.Graphics.DrawString(Consulta.Precio.ToString(), f10b, Brushes.Black, centermargin, 50, center);
            //}

            //*********************************************************************
            Font fDesc = new Font("Arial", 10, FontStyle.Bold);
            Font fPrecio = new Font("Arial Black", 28, FontStyle.Bold);
            Font fSmall = new Font("Arial", 7, FontStyle.Regular);

            int width = e.PageBounds.Width;
            int center = width / 2;

            StringFormat centerFmt = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat leftFmt = new StringFormat() { Alignment = StringAlignment.Near };
            StringFormat rightFmt = new StringFormat() { Alignment = StringAlignment.Far };

            using (var hb = new DBdatos())
            {
                var c = hb.LISTAPRECIOCUERPO.FirstOrDefault(x => x.ID == ID);

                string descripcion = c.Productos_Insumos.Descripcion.ToUpper();
                string precio = "$ " +c.Precio.ToString();

                // 🔤 WRAP automático (multilínea real)
                RectangleF rectDesc = new RectangleF(0, 0, width, 100);
                SizeF sizeDesc = e.Graphics.MeasureString(descripcion, fDesc, width);

                float y = 0;

                // =========================
                // 🟩 CABECERA NEGRA
                // =========================
                e.Graphics.FillRectangle(Brushes.Black, 0, y, width, sizeDesc.Height + 6);
                e.Graphics.DrawString(descripcion, fDesc, Brushes.White,
                                      new RectangleF(0, y + 2, width, sizeDesc.Height),
                                      centerFmt);

                y += sizeDesc.Height + 10;

                // =========================
                // 💲 PRECIO + LÍNEAS
                // =========================
                e.Graphics.DrawLine(Pens.Black, 0, y, width, y);
                y += 5;

                e.Graphics.DrawString(precio, fPrecio, Brushes.Black, center, y, centerFmt);

                SizeF sizePrecio = e.Graphics.MeasureString(precio, fPrecio);

                y += sizePrecio.Height + 5;

                e.Graphics.DrawLine(Pens.Black, 0, y, width, y);
                y += 10;

                // =========================
                // 🔎 INFO FINAL
                // =========================
                e.Graphics.DrawString("COD: " + c.Articulo_ID, fSmall, Brushes.Black, 5, y, leftFmt);
                e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yy"), fSmall, Brushes.Black, width - 5, y, rightFmt);

                y += 20;

                // =========================
                // 🔲 AJUSTE FINAL DEL PAPEL
                // =========================
                PD.DefaultPageSettings.PaperSize = new PaperSize("Custom", width, (int)y);

                //**************************************************************************

                //Font fHeader = new Font("Arial", 11, FontStyle.Bold);
                //Font fPrecio = new Font("Arial Black", 34, FontStyle.Bold);
                //Font fDetalle = new Font("Calibri", 9, FontStyle.Regular);
                //Font fSmall = new Font("Calibri", 8, FontStyle.Regular);

                //int width = PD.DefaultPageSettings.PaperSize.Width;
                //int center = width / 2;

                //StringFormat fmtCenter = new StringFormat() { Alignment = StringAlignment.Center };
                //StringFormat fmtLeft = new StringFormat() { Alignment = StringAlignment.Near };
                //StringFormat fmtRight = new StringFormat() { Alignment = StringAlignment.Far };

                //using (var hb = new DBdatos())
                //{
                //    var c = hb.LISTAPRECIOCUERPO.FirstOrDefault(x => x.ID == ID);

                //    string descripcion = c.Productos_Insumos.Descripcion.ToUpper();
                //    decimal precio = (decimal)c.Precio;

                //    // 👉 SIMULACIÓN (podés reemplazar por datos reales de balanza)
                //    decimal peso = 1.250m; // kg
                //    decimal precioKg = (decimal)c.Precio;

                //// =========================
                //// 🔲 CABECERA NEGRA
                //// =========================
                //float y = 0;
                //    SizeF sizeHeader = e.Graphics.MeasureString(descripcion, fHeader);

                //    e.Graphics.FillRectangle(Brushes.Black, 0, y, width, sizeHeader.Height + 6);
                //    e.Graphics.DrawString(descripcion, fHeader, Brushes.White, center, y + 2, fmtCenter);

                //    y += sizeHeader.Height + 10;

                //    // =========================
                //    // ⚖️ DETALLE (peso / kg)
                //    // =========================
                //    e.Graphics.DrawString("PESO:", fDetalle, Brushes.Black, 5, y, fmtLeft);
                //    e.Graphics.DrawString(peso.ToString("0.000") + " kg", fDetalle, Brushes.Black, width - 5, y, fmtRight);

                //    y += 15;

                //    e.Graphics.DrawString("PRECIO/KG:", fDetalle, Brushes.Black, 5, y, fmtLeft);
                //    e.Graphics.DrawString("$ " + precioKg.ToString("0.00"), fDetalle, Brushes.Black, width - 5, y, fmtRight);

                //    y += 20;

                //    // =========================
                //    // 💲 PRECIO GRANDE
                //    // =========================
                //    e.Graphics.DrawLine(Pens.Black, 0, y, width, y); // separador
                //    y += 5;

                //    e.Graphics.DrawString("$ " + precio.ToString("0"), fPrecio, Brushes.Black, center, y, fmtCenter);

                //    y += 60;

                //    // =========================
                //    // 🔎 INFO FINAL
                //    // =========================
                //    e.Graphics.DrawLine(Pens.Black, 0, y, width, y);
                //    y += 5;

                //    e.Graphics.DrawString("COD: " + c.ID.ToString(), fSmall, Brushes.Black, 5, y, fmtLeft);
                //    e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), fSmall, Brushes.Black, width - 5, y, fmtRight);

                //    // =========================
                //    // 🔲 BORDE GENERAL
                //    // =========================
                //    e.Graphics.DrawRectangle(Pens.Black, 0, 0, width - 1, y + 20);
                //}
            }
        }
        public void PD_PrintPage(object sender, PrintPageEventArgs e)
        {
                 
            Font f7 = new Font("Calibri", 7, FontStyle.Regular);
            Font f8 = new Font("Calibri", 8, FontStyle.Regular);
            Font f10 = new Font("Calibri", 10, FontStyle.Regular);
            Font f10b = new Font("Calibri", 10, FontStyle.Bold);
            Font f12N = new Font("Calibri", 12, FontStyle.Bold);
            Font f14 = new Font("Calibri", 14, FontStyle.Bold);


            int leftmargin = PD.DefaultPageSettings.Margins.Left;
            int centermargin = PD.DefaultPageSettings.PaperSize.Width / 2;
            int rightmargin = PD.DefaultPageSettings.PaperSize.Width;

            StringFormat right = new StringFormat();
            StringFormat center = new StringFormat();
            right.Alignment = StringAlignment.Far;
            center.Alignment = StringAlignment.Center;

            string line = "****************************************************************";
            //string line = "________________________________________________________________";

            //Image logoImage = Properties.Resources.logo;
            //e.Graphics.DrawImage(logoImage, (e.PageBounds.Width - 50) / 2, 5, 50, 35);

            using (var hb = new DBdatos())
            {
                string Empresa;
                string CUIT;
                string Direccion;
                string Ciudad;
                string CondicionIVA;
                string Comprobante;
                string NumeroComprobante;
                string Fecha;
                string Hora;
                string Cliente;
                decimal CantidadArticulo = 0;
                decimal ImporteTotal = 0;
                string CondicionPago;
                string Cuenta;

                var ConsultaCliente = (from CLI in hb.Clientes
                                       where CLI.Cliente_Usuario == true
                                       select CLI).FirstOrDefault();

               

                //CLIENTE
                if (ConsultaCliente != null)
                    Empresa = ConsultaCliente.Descripcion;
                else
                    Empresa = "";

                CUIT = ConsultaCliente.DNI;
                Direccion = ConsultaCliente.Direccion;
                Ciudad = ConsultaCliente.Ciudades.Descripcion;
                CondicionIVA = "RESPONSABLE INSCRIPTO";

                

                //CABEZAL
                var ConsultaCabezal = (from CAB in hb.TICKET
                                       where CAB.ID == ID
                                       select CAB).FirstOrDefault();

               
                Comprobante = ConsultaCabezal.MOVIMIENTOS.Descripcion + " - " + ConsultaCabezal.Letra;
                NumeroComprobante = ConsultaCabezal.NumeroTicket.Substring(0, 4) + " - " + ConsultaCabezal.NumeroTicket.Substring(4, 8);
                Fecha = ConsultaCabezal.Fecha.ToShortDateString();
                Hora = ConsultaCabezal.Fecha.ToShortTimeString();
                Cliente = ConsultaCabezal.Clientes.Descripcion;
                CondicionPago = ConsultaCabezal.MEDIOPAGO1.Descripcion;
                Cuenta = ConsultaCabezal.Clientes.Descripcion;
               
                //CUERPO
                var ConsultaCuerpo = (from CU in hb.TICKETCUERPO
                                      where CU.Ticket_ID == ID
                                      select CU).ToList();

                LargoPapel = ConsultaCuerpo.Count * 15 + 240;

                e.Graphics.DrawString(Empresa, f12N, Brushes.Black, centermargin, 10, center);
                e.Graphics.DrawString(CUIT, f10, Brushes.Black, centermargin, 35, center);
                e.Graphics.DrawString(Direccion, f10, Brushes.Black, centermargin, 50, center);
                e.Graphics.DrawString(Ciudad, f10, Brushes.Black, centermargin, 65, center);
                e.Graphics.DrawString(Comprobante, f12N, Brushes.Black, centermargin, 90, center);

                e.Graphics.DrawString("Factura N", f8, Brushes.Black, 0, 120); // SEPARA 20
                e.Graphics.DrawString(":", f8, Brushes.Black, 50, 120);
                e.Graphics.DrawString(NumeroComprobante, f8, Brushes.Black, 70, 120);

                e.Graphics.DrawString("Fecha: " + DateTime.Now.ToShortDateString() + " - Hora: " + DateTime.Now.ToShortTimeString(), f8, Brushes.Black, 0, 130);
                e.Graphics.DrawString("Medio pago: " + CondicionPago, f8, Brushes.Black, 0, 140);
                e.Graphics.DrawString("Cuenta: " + Cuenta, f8, Brushes.Black, 0, 150);

                e.Graphics.DrawString(line, f8, Brushes.Black, 0, 160);

                int height = 0;
                decimal i;
                //DataGridView1.AllowUserToAddRows = false;

                foreach (var item in ConsultaCuerpo)
                {
                    string Articulo1 = item.Productos_Insumos.Descripcion;
                    decimal Total = (decimal)item.ImporteTotal;
                    decimal Cantidad = (decimal)item.Cantidad;

                    if (Articulo1.Length > 26)
                    {
                        string Articulo2 = Articulo1.Remove(0, 26); // SALTO LINEA NOMBRE MUY LARGO


                        height += 15;
                        Articulo1 = Articulo1.Substring(0, 26);
                        e.Graphics.DrawString(Articulo1, f8, Brushes.Black, 0, 160 + height);
                        e.Graphics.DrawString(Cantidad.ToString("N2"), f8, Brushes.Black, 160, 160 + height);
                        e.Graphics.DrawString(Total.ToString("N2"), f8, Brushes.Black, 210, 160 + height);
                        height = height + 15;
                        //Articulo = item.Productos_Insumos.Descripcion.Substring(39, item.Productos_Insumos.Descripcion.Length - 1);
                        e.Graphics.DrawString(Articulo2, f8, Brushes.Black, 0, 160 + height);
                        e.Graphics.DrawString("", f8, Brushes.Black, 210, 160 + height);
                    }
                    else
                    {
                        height = height + 15; //Espacio entre lineas
                        e.Graphics.DrawString(Articulo1, f8, Brushes.Black, 0, 160 + height);
                        e.Graphics.DrawString(Cantidad.ToString("N2"), f8, Brushes.Black, 160, 160 + height);
                        e.Graphics.DrawString(Total.ToString("N2"), f8, Brushes.Black, 210, 160 + height);
                    }
                    //height += 15; //Espacio entre lineas
                    //e.Graphics.DrawString(Articulo, f7, Brushes.Black, 0, 140 + height);
                    //e.Graphics.DrawString(item.Precio.ToString("N2"), f7, Brushes.Black, rightmargin, 140 + height);


                    //i = Convert.ToDecimal(DataGridView1.Rows[row].Cells[2].Value);
                    //DataGridView1.Rows[row].Cells[2].Value = i.ToString("##,##0");

                    //e.Graphics.DrawString(DataGridView1.Rows[row].Cells[2].Value.ToString(), f8, Brushes.Black, 180, 115 + height, right);
                    var Consulta = (from P in hb.Productos_Insumos
                                    where P.Codigo == item.Insumo_ID
                                    select P).FirstOrDefault();

                    if (Consulta.PLU != null)
                        CantidadArticulo = CantidadArticulo + 1;
                    else
                        CantidadArticulo = (decimal)(CantidadArticulo + item.Cantidad);

                    ImporteTotal = ImporteTotal + Convert.ToDecimal(item.ImporteTotal);
                    //e.Graphics.DrawString(totalprice.ToString("##,##0"), f8, Brushes.Black, rightmargin, 115 + height, right);
                }

                int height2 = 175 + height;

                //sumprice();
                e.Graphics.DrawString(line, f8, Brushes.Black, 0, height2);
                e.Graphics.DrawString("Total: " + ImporteTotal.ToString("N2"), f10b, Brushes.Black, rightmargin, 20 + height2, right);
                e.Graphics.DrawString("Articulos: " + CantidadArticulo.ToString("N2"), f10, Brushes.Black, 0, 20 + height2);

                e.Graphics.DrawString("~ GRACIAS POR SU COMPRA ~", f10, Brushes.Black, centermargin, 50 + height2, center);
                //e.Graphics.DrawString("~ Documento generado por: Nombre del software ~", f8, Brushes.Black, centermargin, 85 + height2, center);  

            }
            
        }
        public void PD_PrintPageTicketCobro(object sender, PrintPageEventArgs e)
        {

            Font f7 = new Font("Calibri", 7, FontStyle.Regular);
            Font f8 = new Font("Calibri", 8, FontStyle.Regular);
            Font f10 = new Font("Calibri", 10, FontStyle.Regular);
            Font f10b = new Font("Calibri", 10, FontStyle.Bold);
            Font f12N = new Font("Calibri", 12, FontStyle.Bold);
            Font f14 = new Font("Calibri", 14, FontStyle.Bold);


            int leftmargin = PD.DefaultPageSettings.Margins.Left;
            int centermargin = PD.DefaultPageSettings.PaperSize.Width / 2;
            int rightmargin = PD.DefaultPageSettings.PaperSize.Width;

            StringFormat right = new StringFormat();
            StringFormat center = new StringFormat();
            right.Alignment = StringAlignment.Far;
            center.Alignment = StringAlignment.Center;

            string line = "****************************************************************";
            //string line = "________________________________________________________________";

            //Image logoImage = Properties.Resources.logo;
            //e.Graphics.DrawImage(logoImage, (e.PageBounds.Width - 50) / 2, 5, 50, 35);

            using (var hb = new DBdatos())
            {
                string Empresa;
                string CUIT;
                string Direccion;
                string Ciudad;
                string CondicionIVA;
                string Comprobante;
                string NumeroComprobante;
                string Fecha;
                string Hora;
                string Cliente;
                decimal CantidadArticulo = 0;
                decimal ImporteTotal = 0;
                string CondicionPago;
                string Cuenta;

                var ConsultaCliente = (from CLI in hb.Clientes
                                       where CLI.Cliente_Usuario == true
                                       select CLI).FirstOrDefault();



                //CLIENTE
                if (ConsultaCliente != null)
                    Empresa = ConsultaCliente.Descripcion;
                else
                    Empresa = "";

                CUIT = ConsultaCliente.DNI;
                Direccion = ConsultaCliente.Direccion;
                Ciudad = ConsultaCliente.Ciudades.Descripcion;
                CondicionIVA = "RESPONSABLE INSCRIPTO";



                //CABEZAL
                var ConsultaCabezal = (from CAB in hb.MOVIMIENTOCUENTACORRIENTE
                                       where CAB.ID == ID
                                       select CAB).FirstOrDefault();


                Comprobante = ConsultaCabezal.MOVIMIENTOS.Descripcion;
                NumeroComprobante = ConsultaCabezal.NumeroComprobante.Substring(0, 4) + " - " + ConsultaCabezal.NumeroComprobante.Substring(4, 8);
                Fecha = ConsultaCabezal.Fecha.ToString();
                Hora = ConsultaCabezal.Fecha.ToString();
                Cliente = ConsultaCabezal.Clientes.Descripcion;
                //CondicionPago = ConsultaCabezal.MEDIOPAGO1.Descripcion;
                Cuenta = ConsultaCabezal.Clientes.Descripcion;
                ImporteTotal = (decimal)ConsultaCabezal.Valor;

                e.Graphics.DrawString(Empresa, f12N, Brushes.Black, centermargin, 10, center);
                e.Graphics.DrawString(CUIT, f10, Brushes.Black, centermargin, 35, center);
                e.Graphics.DrawString(Direccion, f10, Brushes.Black, centermargin, 50, center);
                e.Graphics.DrawString(Ciudad, f10, Brushes.Black, centermargin, 65, center);
                e.Graphics.DrawString(Comprobante, f12N, Brushes.Black, centermargin, 90, center);

                e.Graphics.DrawString(line, f8, Brushes.Black, 0, 110);

                e.Graphics.DrawString("Cobro N", f8, Brushes.Black, 0, 120); // SEPARA 20
                e.Graphics.DrawString(":", f8, Brushes.Black, 50, 120);
                e.Graphics.DrawString(NumeroComprobante, f8, Brushes.Black, 70, 120);

                e.Graphics.DrawString("Fecha: " + DateTime.Now.ToShortDateString() + " - Hora: " + DateTime.Now.ToShortTimeString(), f8, Brushes.Black, 0, 130);
                //e.Graphics.DrawString("Medio pago: " + CondicionPago, f8, Brushes.Black, 0, 140);
                e.Graphics.DrawString("Cuenta: " + Cuenta, f8, Brushes.Black, 0, 150);

                e.Graphics.DrawString(line, f8, Brushes.Black, 0, 160);

                e.Graphics.DrawString("Total: " + ImporteTotal.ToString("N2"), f12N, Brushes.Black, rightmargin, 170, right);





                //sumprice();


                //e.Graphics.DrawString("Articulos: " + CantidadArticulo.ToString(), f10, Brushes.Black, 0, 20 + height2);

                e.Graphics.DrawString("~ GRACIAS POR SU PAGO ~", f10, Brushes.Black, centermargin, 50 + 150, center);
                //e.Graphics.DrawString("~ Documento generado por: Nombre del software ~", f8, Brushes.Black, centermargin, 85 + height2, center);  

            }

        }
        public void ImprimirEtiquetaQR(long IDImprimir)
        {
            ID = IDImprimir;
            PD.PrintPage += new PrintPageEventHandler(PD_PrintPageEtiqueta);
            PD.BeginPrint += new PrintEventHandler(PD_BeginPrintEtiqueta);

            PPD.Document = PD;

            (PPD as Form).WindowState = FormWindowState.Maximized;
            PPD.ShowDialog();
            PD.PrintPage += new PrintPageEventHandler(PD_PrintPageEtiqueta);
            PD.BeginPrint += new PrintEventHandler(PD_BeginPrintEtiqueta);
        }
        public void PD_BeginPrintEtiqueta(object sender, PrintEventArgs e)
        {
            PageSettings pagesetup = new PageSettings();
            pagesetup.PaperSize = new PaperSize("Custom", 378, 378); //Esto esta en pixeles seria 10 cm x 10 cm
            PD.DefaultPageSettings = pagesetup;
        }
        public void PD_PrintPageEtiqueta(object sender, PrintPageEventArgs e)
        {
            //FUENTES
            Font f7b = new Font("Calibri", 7, FontStyle.Bold);
            Font f8 = new Font("Calibri", 8, FontStyle.Regular);
            Font f10 = new Font("Calibri", 10, FontStyle.Regular);
            Font f10b = new Font("Calibri", 10, FontStyle.Bold);
            Font f12N = new Font("Calibri", 12, FontStyle.Bold);
            Font f14 = new Font("Calibri", 14, FontStyle.Bold);

            int leftmargin = 10;
            int centermargin = PD.DefaultPageSettings.PaperSize.Width / 2;
            int rightmargin = PD.DefaultPageSettings.PaperSize.Width;

            int Separador = 10;

            StringFormat right = new StringFormat();
            StringFormat center = new StringFormat();
            StringFormat left = new StringFormat();
            right.Alignment = StringAlignment.Far;
            center.Alignment = StringAlignment.Center;
            left.Alignment = StringAlignment.Near;

            using (var hb = new DBdatos())
            {
                string CodArticulo;
                string Articulo;
                decimal Cantidad;
                string Lote;
                string Deposito;

                Bitmap QR;

                var Consulta = (from EP in hb.Existencia_ProductoTerminado
                                where EP.ID == ID
                                select EP).FirstOrDefault();



                //CODIGO GENERADOR QR
                string Contenido = ID.ToString();
                QRCodeGenerator qrGenerador = new QRCodeGenerator();
                QRCodeData qrDatos = qrGenerador.CreateQrCode(Contenido, QRCodeGenerator.ECCLevel.H);
                QRCode qrCodigo = new QRCode(qrDatos);

               

                QR = qrCodigo.GetGraphic(5, Color.Black, Color.White, true);
                PointF Ubicacion = new PointF(50, 50);

                QR.SetResolution(300, 300);
                int TamanoX = 200;
                int TamanoY = 200;

                e.Graphics.DrawString("PRODUCTO :", f12N, Brushes.Black, leftmargin, Separador, left);
                e.Graphics.DrawString(Consulta.Productos_Insumos.Descripcion, f10b, Brushes.Black, centermargin, Separador, center);
                Separador = Separador + 30;
                e.Graphics.DrawString("CODIGO :", f10b, Brushes.Black, leftmargin, Separador, left);
                e.Graphics.DrawString(Consulta.Productos_Insumos.Codigo, f10b, Brushes.Black, centermargin, Separador, center);
                Separador = Separador  + 30;
                e.Graphics.DrawString("LOTE :", f12N, Brushes.Black, leftmargin, Separador, left);
                e.Graphics.DrawString(Consulta.Lote, f10b, Brushes.Black, centermargin, Separador, center);
                Separador = Separador + 30;
                e.Graphics.DrawString("FECHA :", f12N, Brushes.Black, leftmargin, Separador, left);
                e.Graphics.DrawString(Consulta.Fecha.ToShortDateString(), f10b, Brushes.Black, centermargin, Separador, center);
                Separador = Separador + 30; 
                e.Graphics.DrawString("DEPOSITO :", f12N, Brushes.Black, leftmargin, Separador, left);
                e.Graphics.DrawString(Consulta.Deposito, f10b, Brushes.Black, centermargin, Separador, center);

                e.Graphics.DrawImage(QR, centermargin - (TamanoX / 2) , PD.DefaultPageSettings.PaperSize.Height - (TamanoY + 15), TamanoX, TamanoY);
            }
        }
        public void MostrarImpresion()
        {

        }
    }
}
