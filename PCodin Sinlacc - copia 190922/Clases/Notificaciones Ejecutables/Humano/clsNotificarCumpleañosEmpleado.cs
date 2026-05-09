using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios.Notificación;
using PCodin_Sinlacc.Clases.Notificaciones_Ejecutables;

namespace PCodin_Sinlacc.Clases.Notificaciones_Ejecutables.Humano
{
    class clsNotificarCumpleañosEmpleado
    {
        public static void NotificarCumpleañosEmpleado()
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
                        string Mensaje = "Hoy es el cumpleaños de " + item.Nombre + " le deseamos lo mejor en su día";

                        //Verifica que no hay una misma notificacion no ledia ya cargada
                        var ConsultaNotificacion = (from N in hb.Notificaciones
                                                    where N.Descripcion == "Hoy es el cumpleaños de " + item.Nombre + " le deseamos lo mejor en su día"
                                                        && N.Fecha == Fecha
                                                    select N).FirstOrDefault();

                        if (ConsultaNotificacion == null)
                        {
                            clsCrearNotificacion.CrearNotificacion(Fecha, 2, Mensaje, "NO", DateTime.Now.TimeOfDay, "NO", "NO");
                            clsEjecutarPcnNotifEjec.EjecutarPcnNotificacionesEjec();
                            clsAbriFormNotificacion.AbriFormNotificacion("FELICIDADES", Mensaje);                           
                        }
                    }                  
                }
            }
        }
    }
}
