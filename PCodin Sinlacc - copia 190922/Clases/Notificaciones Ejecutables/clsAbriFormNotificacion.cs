using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCodin_Sinlacc.Formularios.Notificación;

namespace PCodin_Sinlacc.Clases.Notificaciones_Ejecutables
{
    class clsAbriFormNotificacion
    {
        public static void AbriFormNotificacion(string Subtitulo , string Detalle)
        {
            var f = new frmAlertas();
            f.lblSubtitulo.Text = Subtitulo;
            f.lblDetalle.Text = Detalle;

            f.ShowDialog();
        }

    }
}
