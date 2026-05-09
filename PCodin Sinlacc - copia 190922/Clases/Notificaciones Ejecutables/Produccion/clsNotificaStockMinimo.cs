using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Clases.Notificaciones_Ejecutables.Produccion
{
    class clsNotificaStockMinimo
    {
        private static void EjecutarPcnNotificacionesEjec()
        {
            Process.Start(@"C:\Program Files (x86)\Pack-Codin\PcnNotificacionEjec.appref-ms");
        }
        public static void NotificaStockMinimo()
        {
            using (var hb = new DBdatos())
            {
            //    string Subtitulo = "Productos en stock crítico";
            //    string Detalle = "Hay productos que alcanzaron su stock mínimo";
                
            //    List<string> Productos = new List<string>();

            //    var ConsultaStockFecha = (from F in hb.StockFecha
            //                         orderby F.Fecha_Stock descending
            //                         select F).FirstOrDefault();

            //    var ConsultaStock = (from S in hb.ftStockProductoFinal(ConsultaStockFecha.Fecha_Stock, 0, "")
            //                         join PRO in hb.Productos_Insumos on S.ProductoID equals PRO.Codigo
            //                         where S.StockReal <= S.StockMinimo
            //                            && PRO.NotificaStockMin == "SI"
            //                         select S).ToList();
               
            //    if (ConsultaStock.Count > 0)
            //    {
            //        foreach (var item in ConsultaStock)
            //        {
            //            Productos.Add(item.Producto + " - " + item.ProductoID);
            //        }


            //        string Mensage = "Los siguientes productos alcanzaron su Stock mínimo:,,";                                 

            //        foreach(var item in Productos)
            //        {
            //            Mensage = Mensage  + item.ToString() + ",";
            //        }

            //        Mensage = Mensage + ","
            //                 + "Fabor de corroborar";

            //        clsCrearNotificacion.CrearNotificacion(    DateTime.Now.Date,
            //                                                   1,
            //                                                   Mensage,
            //                                                   "NO",
            //                                                   DateTime.Now.TimeOfDay,
            //                                                   "NO",
            //                                                   "SI");

            //        Task Tarea = new Task(EjecutarPcnNotificacionesEjec);
            //        Tarea.Start();

            //        clsAbriFormNotificacion.AbriFormNotificacion(Subtitulo,Detalle);
            //    }
            }
        }
    }
}
