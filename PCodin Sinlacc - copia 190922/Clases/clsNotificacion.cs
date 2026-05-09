using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios.Notificación;
using System.Windows.Forms;
using System.Net.Mail;

namespace PCodin_Sinlacc.Clases
{
    class clsNotificacion
    {
        private static long NotificacionID = 1;
        private static long IDFicticio = 0;
        private static string EmailDestino;
        private static string EmailMensaje;
        private static frmAlertas FormNotificacion;
        private static Timer Timer = new Timer();
        private static void CalcularIDNotficacion(long NotificacionID, long IDFicticio)
        {
            using (var hb = new DBdatos())
            {
                var ConsultaID = (from N in hb.Notificaciones
                                  orderby N.ID descending
                                  select N).FirstOrDefault();

                
                if(ConsultaID == null)
                {
                    IDFicticio = 1;
                    NotificacionID = 1;
                }
                else
                {
                    IDFicticio = IDFicticio + 1;
                    NotificacionID = ConsultaID.ID + IDFicticio;
                }
            }
        }
        public static void MostrarCantidadNotificacionesNoLeidas(Label lblCantidad)
        {
            
            int CantidadOriginal = Convert.ToInt32(lblCantidad.Text);
            int CantidadActualizada = 0;

            using (var hb = new DBdatos())
            {
                var ConsultaNotificacion = (from N in hb.Notificaciones
                                            where N.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                && N.Leida == "NO"
                                            select N).ToList();

                if (ConsultaNotificacion.Count == 0)
                    lblCantidad.Visible = false;
                else
                {
                    lblCantidad.Visible = true;
                    lblCantidad.Text = ConsultaNotificacion.Count.ToString();

                    CantidadActualizada = ConsultaNotificacion.Count;

                    if(CantidadActualizada > CantidadOriginal)
                    {
                        
                        Timer.Tick += Timer_Tick;
                        Timer.Interval = 5000;
                        Timer.Enabled = true;
                        Timer.Start();

                        FormNotificacion = new frmAlertas();
                        FormNotificacion.lblDetalle.Text = "Usted tiene " + "( " + (CantidadActualizada - CantidadOriginal).ToString() + " ) " + "nuevas notificiones";
                        FormNotificacion.picCumple1.Visible = false;
                        FormNotificacion.picCumple2.Visible = false;
                        FormNotificacion.TopMost = true;                     
                        FormNotificacion.Show();

                        
                    }
                }
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;
            FormNotificacion.Close();
        }

        //public static void NotificarStockMinimoInsumo(int UsuarioID)
        //{
        //    using (var hb = new DBdatos())
        //    {
        //        string Notifica = "NO";
        //        int CantidadNotificaciones = 0;

        //        var ConsultaFecha = (from F in hb.StockFecha
        //                             orderby F.ID descending
        //                             select F).FirstOrDefault();

        //        var ConsultaStockInsumo = (from SINS in hb.ftStockInsumos3(ConsultaFecha.Fecha_Stock)
        //                                     where SINS.StockMin <= SINS.Existencia
        //                                     select SINS).ToList();

        //        var ConsuntalPuntoPedido = (from PINS in hb.ftStockInsumos3(ConsultaFecha.Fecha_Stock)
        //                                    where PINS.Existencia <= PINS.Existencia
        //                                    select PINS).ToList();

        //        foreach (var item in ConsultaStockInsumo)
        //        {                   
        //            var ConsultaNotificacion = (from N in hb.Notificaciones
        //                                        where N.Descripcion.Contains("El insumo " + item.Insumo + " - " + item.InsumoID + " alcanzó su stock mínimo")
        //                                            && N.Leida == "NO"
        //                                        select N).FirstOrDefault();

        //            if (ConsultaNotificacion == null)
        //            {
        //                var i = new Notificaciones();

        //                i.Fecha = DateTime.Now.Date;
        //                i.Tipo_ID = 1;
        //                i.Descripcion = "El insumo " + item.Insumo + " - " + item.InsumoID + " alcanzó su stock mínimo";
        //                i.Leida = "NO";
        //                i.Hora = DateTime.Now.TimeOfDay;

        //                Notifica = "SI";
        //                hb.Notificaciones.Add(i);
        //                CantidadNotificaciones = CantidadNotificaciones + 1;
        //            }
        //        }
        //        foreach (var item in ConsuntalPuntoPedido)
        //        {
        //            var ConsultaNotificacion = (from N in hb.Notificaciones
        //                                        where N.Descripcion.Contains("El insumo " + item.Insumo + " - " + item.InsumoID + " alcanzó su punto de pedido")
        //                                            && N.Leida == "NO"
        //                                        select N).FirstOrDefault();

        //            if (ConsultaNotificacion == null)
        //            {
        //                var ConsultaInsumo = (from INS in hb.Productos_Insumos
        //                                      where INS.Codigo == item.InsumoID
        //                                      select INS).FirstOrDefault();

        //                if (ConsultaInsumo.NotificaPuntoPedido == "SI")
        //                {
        //                    var i = new Notificaciones();

        //                    i.Fecha = DateTime.Now.Date;
        //                    i.Tipo_ID = 1;
        //                    i.Descripcion = "El insumo " + item.Insumo + " - " + item.InsumoID + " alcanzó su punto de pedido";
        //                    i.Leida = "NO";
        //                    i.Hora = DateTime.Now.TimeOfDay;

        //                    Notifica = "SI";
        //                    hb.Notificaciones.Add(i);
        //                    CantidadNotificaciones = CantidadNotificaciones + 1;
        //                }
        //            }
        //        }
        //        hb.SaveChanges();

        //        if (Notifica == "SI")
        //        {
        //            var f = new frmAlertas();
        //            f.lblDescripcion.Visible = true;
        //            f.lblDescripcion.Text = "Usted tiene " + "( " + CantidadNotificaciones + " ) " + "notificaciones " + "nuevas";                   
        //            f.Formulario = f;
        //            f.UsuarioID = UsuarioID;
        //            f.ShowDialog();
        //        }
        //    }
        // }
        public static void NotificarStockMinimoProducto(int UsuarioID)
        {
            using (var hb = new DBdatos())
            {
                string Notifica = "NO";
                int CantidadNotificaciones = 0;
                string Mensaje = "";

                var ConsultaFecha = (from F in hb.StockFecha
                                     orderby F.ID descending
                                     select F).FirstOrDefault();

                //var ConsultaStockProducto = (from SPRO in hb.ftStockProductoFinal(ConsultaFecha.Fecha_Stock , 0 , "")
                //                             where SPRO.StockMinimo <= SPRO.StockReal
                //                             select SPRO).ToList();

            //    foreach(var item in ConsultaStockProducto)
            //    {
            //        var ConsultaNotificacion = (from N in hb.Notificaciones
            //                                    where N.Descripcion.Contains("El producto " + item.Producto + " - " + item.ProductoID + " alcanzó su stock mínimo")
            //                                    select N).FirstOrDefault();



            //        if (ConsultaNotificacion != null)
            //        {
            //            if (ConsultaNotificacion.Leida == "NO")
            //            {
            //                Mensaje = "El producto " + item.Producto + " - " + item.ProductoID + " alcanzó su stock mínimo";
            //                EmailMensaje = Mensaje;

            //               // EnviarMail(EmailDestino, EmailMensaje);

            //                //CalcularIDNotficacion(NotificacionID, IDFicticio);
            //                CantidadNotificaciones = CantidadNotificaciones + 1;

            //                var i = new Notificaciones();

            //               // i.ID = NotificacionID;
            //                i.Fecha = DateTime.Now.Date;
            //                i.Tipo_ID = 1;
            //                i.Descripcion = Mensaje;
            //                i.Leida = "NO";
            //                i.Hora = DateTime.Now.TimeOfDay;

            //                Notifica = "SI";
            //                hb.Notificaciones.Add(i);
            //            }
            //        }                   
            //    }
            //    hb.SaveChanges();

            //    if(Notifica == "SI")
            //    {
                    
                    
            //        var f = new frmAlertas();
            //        f.lblSubtitulo.Text = "Usted tiene " + "( " + CantidadNotificaciones + " ) " + "notificaciones "+ "nuevas";
            //        f.lblSubtitulo.Visible = true;
            //        f.Formulario = f;
            //        f.UsuarioID = UsuarioID;
            //        f.ShowDialog();
            //    }
            }
        }
        public static void NotificarCumpleaños()
        {
            DateTime Fecha = DateTime.Now.Date;

            using (var hb = new DBdatos())
            {
                var ConsultaCumpleaños = (from EMP in hb.Empleados
                                          where EMP.Fecha_Nacimiento.Day == Fecha.Day
                                                && EMP.Fecha_Nacimiento.Month == Fecha.Month
                                          && EMP.Estado == "SI"
                                          select EMP);

                var ResultadosCumpleaños = ConsultaCumpleaños.ToList();

                if (ResultadosCumpleaños.Count > 0)
                {
                    foreach (var item in ResultadosCumpleaños)
                    {
                        var C = new Notificaciones();

                        C.Fecha = Fecha;
                        C.Hora = DateTime.Now.TimeOfDay;
                        C.Tipo_ID = 2;
                        C.Descripcion = "Hoy es el cumpleaños de " + item.Nombre + " le deseamos lo mejor en su día";
                        C.Leida = "NO";

                        var ConsultaNotificacion = (from N in hb.Notificaciones
                                                    where N.Descripcion == "Hoy es el cumpleaños de " + item.Nombre + " le deseamos lo mejor en su día"
                                                        && N.Fecha == Fecha
                                                    select N).FirstOrDefault();

                        if (ConsultaNotificacion == null)
                        {
                            EmailMensaje = "Hoy es el cumpleaños de " + item.Nombre + " le deseamos lo mejor en su día";
                            //EnviarMail(EmailDestino, EmailMensaje);

                            hb.Notificaciones.Add(C);
                            hb.SaveChanges();

                            var f = new frmAlertas();
                            f.Cumpleañero = item.Nombre;
                            f.Tipo = "Cumpleaños";
                            f.ShowDialog();                                                   
                        }
                    }
                }
            }
        }
        public static void NotificarFechaLimiteOrdenProduccion(int UsuarioID)
        {
            using (var hb = new DBdatos())
            {
                string Notifica = "NO";
                int CantidadNotificaciones = 0;
                DateTime FechaHoy = DateTime.Now.Date;

                var ConsultaFechaLimite = (from F in hb.Orden_Produccion1
                                           where F.Fecha_Limite >= FechaHoy
                                                && F.Estado_ID != "FI"
                                                && F.Estado_ID != "AN"
                                           select F).ToList();

                foreach (var item in ConsultaFechaLimite)
                {
                    DateTime FechaLimite = item.Fecha_Limite.Value;
                    int Dias = (FechaLimite - FechaHoy).Days;

                    if (Dias < 5 && Dias >= 0)
                    {
                        var ConsultaNotificacion = (from OP in hb.Notificaciones
                                                    where OP.Descripcion == "La orden de producción " + item.NumeroOrden + " está a " + Dias.ToString() + " días" + " de alcanzar su fecha límite"
                                                        || OP.Descripcion == "La orden de producción " + item.NumeroOrden + " acaba de alcanzar su fecha límite"
                                                    select OP).FirstOrDefault();

                        if (ConsultaNotificacion == null)
                        {
                            string Mensage;

                            if (Dias == 0)
                                Mensage = "La orden de producción " + item.NumeroOrden + " acaba de alcanzar su fecha límite";
                            else
                                Mensage = "La orden de producción " + item.NumeroOrden + " está a " + Dias.ToString() + " días" + " de alcanzar su fecha límite";

                            EmailMensaje = Mensage;

                            var i = new Notificaciones();

                            i.Fecha = DateTime.Now.Date;
                            i.Tipo_ID = 1;
                            i.Descripcion = Mensage;
                            i.Leida = "NO";
                            i.Hora = DateTime.Now.TimeOfDay;

                            Notifica = "SI";
                            hb.Notificaciones.Add(i);
                            CantidadNotificaciones = CantidadNotificaciones + 1;
                            EmailMensaje = Mensage;
                        }
                    }
                }
                hb.SaveChanges();
                if (Notifica == "SI")
                {
                    var f = new frmAlertas();
                    f.lblSubtitulo.Text = "Usted tiene " + "( " + CantidadNotificaciones + " ) " + "notificaciones " + "nuevas";
                    f.lblSubtitulo.Visible = true;
                    f.Formulario = f;
                    f.UsuarioID = UsuarioID;
                    f.ShowDialog();
                   
                   // clsNotificacion.EnviarMail(EmailDestino,EmailMensaje);
                }
            }
        }
        public static void EnviarMail(string Destino, string Mensaje)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from U in hb.Usuarios
                                where U.Estado == "SI"
                                    && U.EnviaNotificacion == "SI"
                                select U).ToList();

                foreach(var item in Consulta)
                {
                    if (item.Email != "")
                    {
                        try
                        {
                            EmailDestino = item.Email;

                            string EmailOrigen = "francopeirone@gmail.com";
                            string Contraseña = "dkgidusravngshtn";
                            //EmailDestino = "camilakacc@gmail.com";

                            //string path = @"C:\turuta\burger.png";
                            //string path2 = @"C:\turuta\a.jpg";

                            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino,"Nueva notificación de PACK-CODIN", "<b>" + Mensaje + "</b>");
                            //oMailMessage.Attachments.Add(new Attachment(path));
                            //oMailMessage.Attachments.Add(new Attachment(path2));
                            
                            oMailMessage.IsBodyHtml = true;

                            SmtpClient oSmtpCliente = new SmtpClient("smtp.gmail.com");
                            oSmtpCliente.EnableSsl = true;
                            oSmtpCliente.UseDefaultCredentials = false;
                            oSmtpCliente.Port = 587;
                            oSmtpCliente.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

                            oSmtpCliente.Send(oMailMessage);

                            oSmtpCliente.Dispose();
                        }
                        catch (Exception)
                        {
                           
                        }

                    }
                   
                }
                                
            }
           
        }

    }
}
