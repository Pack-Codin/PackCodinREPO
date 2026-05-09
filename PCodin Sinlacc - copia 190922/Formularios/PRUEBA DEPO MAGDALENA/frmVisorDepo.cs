using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios.PRUEBA_DEPO_MAGDALENA
{
    public partial class frmVisorDepo : Form
    {
        public frmVisorDepo()
        {
            InitializeComponent();
        }
        public string Deposito;
        public DataSet1 DS;
        private void frmVisorDepo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            DataTable DataTable = DS.Tables["Deposito"];

            var Consulta = (from C in DataTable.AsEnumerable()
                            where C.Field<string>("Deposito") == Deposito
                            select new
                            {
                                Deposito = C.Field<string>("Deposito"),
                                Producto = C.Field<string>("Producto") + " - " + C.Field<string>("CodProducto"),
                                Cantidad = C.Field<decimal>("Existencia"),
                                Calidad = C.Field<string>("Calidad"),
                                SerieLote = C.Field<string>("SerieLote"),
                                CentroOpertativo = C.Field<string>("CentroOperativo")
                            });

            var Resultados = Consulta.ToList();

            colProducto.DataPropertyName = "Producto";
            colCantidad.DataPropertyName = "Cantidad";
            colCentroOperativo.DataPropertyName = "CentroOpertativo";
            colCalidad.DataPropertyName = "Calidad";
            colSerieLote.DataPropertyName = "SerieLote";
            colCentroOperativo.DataPropertyName = "CentroOpertativo";

            dgvDetalle.DataSource = Resultados;
        }
    }
}
