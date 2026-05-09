using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Formularios.Configuracion
{
    public partial class frmConfigProduccion : Form
    {
        public frmConfigProduccion()
        {
            InitializeComponent();
        }
        public int ModuloID;
        public int UsuarioID;
        private void frmConfigProduccion_Load(object sender, EventArgs e)
        {

        }
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                //var Consulta = (from C in hb.PcnConfiguraciones
                //                );
            }
        }
    }
}
