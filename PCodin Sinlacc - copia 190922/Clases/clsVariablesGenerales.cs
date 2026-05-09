using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Clases
{
    public static class clsVariablesGenerales
    {
        //PARA SABER SI ES PACK-CODIN O PACK.SHOP
        public static string Aplicacion;

        public static int WPantalla;
        public static int HPantalla;

        public static int WpnlCentral;
        public static int HpnlCentral;

        public static List<string> ListaFormAbiertos = new List<string>();

        public static System.Windows.Forms.Panel pnlCentral = new System.Windows.Forms.Panel();

        public static int UsuarioID;
        public static long SesionID;
        public static string UsuarioAPP;
        public static string Modo;
    }
}
