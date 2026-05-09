using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Clases.Formularios.Ventas.OrdenCarga
{
    public class clsfrmAgregarOrdenCarga
    {


        public void Consultas()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from P in hb.Registro_Pedidos
                                join PC in hb.Pedido_Cuerpo on P.ID equals PC.Pedido_ID
                                where
                                     P.Cliente_ID == 22
                                     && PC.Cantidad > 0
                                select new
                                {
                                    P.Clientes.Descripcion
                                });

            }
            //public long PedidoID { get; set; }
            //public string NumeroPedido { get; set; }
            //public string CodProducto { get; set; }
            //public string Producto { get; set; }
            //public string Medida { get; set; }
            //public decimal CantidadPend { get; set; }
            //public decimal CantidadAfec { get; set; }
            //public long PedidoCuerpoID { get; set; }
        }
    }
}
