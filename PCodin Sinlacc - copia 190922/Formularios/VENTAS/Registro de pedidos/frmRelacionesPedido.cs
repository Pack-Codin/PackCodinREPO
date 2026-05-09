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

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmRelacionesPedido : Form
    {
        public long PedidoID_Recibido;
        public string ProductoID_Recibido;
        public frmRelacionesPedido()
        {
            InitializeComponent();
        }

        private void frmRelacionesPedido_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OCC in hb.OrdenCarga_Cuerpo
                                where OCC.Pedido_ID == PedidoID_Recibido
                                    && OCC.Producto_ID == ProductoID_Recibido
                                    && OCC.Orden_Carga.Estado_ID != "AN"
                                select new
                                {
                                    OCC.Orden_Carga.Fecha,
                                    OrdenCarga_ID = OCC.Orden_Carga.ID,
                                    Cliente = OCC.Orden_Carga.Clientes.Descripcion,
                                    Ciudad = OCC.Orden_Carga.Ciudades.Descripcion,
                                    OCC.ID,
                                    OCC.Pedido_ID,
                                    OCC.Producto_ID,
                                    OCC.Cantidad,
                                }) ;

                var Resultados = Consulta.ToList();

                colFecha.DataPropertyName = "Fecha";
                colPedido_ID.DataPropertyName = "Pedido_ID";
                colOrden_ID.DataPropertyName = "OrdenCarga_ID";
                colCliente.DataPropertyName = "Cliente";
                colCiudad.DataPropertyName = "Ciudad";
                colCantidad.DataPropertyName = "Cantidad";

                dgvOrdenPedido.AutoGenerateColumns = false;
                dgvOrdenPedido.DataSource = Resultados;
            }
        }
        private void Copiar()
        {
            Clipboard.SetText(string.Join(",", dgvOrdenPedido.CurrentCell.Value.ToString()));
        }
        private void btnRelacion_Click(object sender, EventArgs e)
        {
            Copiar();
        }
    }
}
