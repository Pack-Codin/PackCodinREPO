using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Formularios.CONFIGURACION.Accesos;
using PCodin_Sinlacc.Formularios.INICIO.Login;
using PCodin_Sinlacc.Formularios.MANTENIMIENTO;
using PCodin_Sinlacc.Formularios.MATERIALES.Gestor_de_materiales.Insumos;
using PCodin_Sinlacc.Formularios.Notificación;
using PCodin_Sinlacc.Formularios.NOTIFICACION;
using PCodin_Sinlacc.Formularios.NOTIFICACION.NotificacionConfigurable;
using PCodin_Sinlacc.Formularios.OTROS;
using PCodin_Sinlacc.Formularios.PRUEBA_DEPO_MAGDALENA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Reutilizables.ProtegerCadenaConexion();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);        
            Application.Run(new frmInicio());
        }
    }
}
