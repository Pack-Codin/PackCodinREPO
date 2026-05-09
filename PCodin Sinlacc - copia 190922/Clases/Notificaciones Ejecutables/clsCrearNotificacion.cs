using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Clases.Notificaciones_Ejecutables
{
    class clsCrearNotificacion
    {
        public static void CrearNotificacion(DateTime Fecha , int TipoID , string Descripcion , string Leida , TimeSpan Hora , string EnviaEmail , string SaltoLineaPorComa)
        {
            using (var hb = new DBdatos())
            {
                var i = new Notificaciones();

                i.Fecha = Fecha;
                i.Tipo_ID = TipoID;
                i.Descripcion = Descripcion;
                i.Leida = Leida;
                i.Hora = Hora;
                i.EnviaMail = EnviaEmail;
                i.SaltoLineaPorComa = SaltoLineaPorComa;

                hb.Notificaciones.Add(i);
                hb.SaveChanges();
            }
        }
    }
}
