using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCodin_Sinlacc.Clases.Notificaciones_Ejecutables
{
    class clsEjecutarPcnNotifEjec
    {
        public static void EjecutarPcnNotificacionesEjec()
        {
            Process.Start(@"C:\Program Files (x86)\Pack-Codin\PcnNotificacionEjec.appref-ms");
        }
    }
}
