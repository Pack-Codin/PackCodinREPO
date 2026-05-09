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
using PCodin_Sinlacc.Clases;
using System.Configuration;

namespace PCodin_Sinlacc.Formularios
{
   
    public partial class frmAfeccionCuerpo : Form
    {
        public int IDClienteRecibido;
        public int IDCiudadRecibido;
        public long IDPedidoRecibido;

        private decimal CantidadOriginal;
        private decimal CantidadAfectOriginal;
        public frmAfeccionCuerpo()
        {
            InitializeComponent();
        }
        
        private void frmAfeccionCuerpo_Load(object sender, EventArgs e)
        {
            dtpFechaHasta.Value = DateTime.Now.Date;
            dtpFechaDesde.Value = DateTime.Now.Date.AddDays(-30);
            MostrarPedidoCuerpo();

            var DB = new DBdatos();
            DB.Database.Connection.ConnectionString = "asdjasahdhkdas";
            
        }
        private void MostrarCantidadesOriginales()
        {
            
        }
        private void MostrarPedidoCuerpo()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OP in hb.Registro_Pedidos
                                join PC in hb.Pedido_Cuerpo on OP.ID equals PC.Pedido_ID
                                join PRO in hb.Productos_Insumos on PC.Producto_ID equals PRO.Codigo
                                where OP.Cliente_ID == IDClienteRecibido
                                    && OP.ID == IDPedidoRecibido
                                orderby OP.Fecha descending
                                select new
                                {
                                    OP.ID,
                                    OP.Fecha,
                                    OP.Cliente_ID,
                                    Cliente = OP.Clientes.Descripcion,
                                    OP.Ciudad_ID,
                                    Ciudad = OP.Ciudades.Descripcion,
                                    OP.Estado_ID,
                                    Estado = OP.Estado_Ord_Carga.Descripcion,
                                    PC.Cantidad,
                                    PC.Producto_ID,
                                    PC.Cantidad_Entregada,
                                    EstadoPC = PC.Estado_Pedido_Cuerpo.Descripcion, // Completo - Pendiente
                                    OP.Observaciones,
                                    PRO.Codigo,
                                    PRO.Descripcion,
                                    Medida = PRO.Medidas_Producto.Descripcion
                                }).Take(1000);

                //if (chkFiltraCliente.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Cliente_ID == (int)cmbCliente.SelectedValue
                //                select C);

                //if (chkFiltraCiudad.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Ciudad_ID == (int)cmbCiudad.SelectedValue
                //                select C);

                if (chkFiltraNroPedido.Checked)
                {
                    long NroPedido = Convert.ToInt64(txtFiltraNroPedido.Text);

                    Consulta = (from C in Consulta
                                where C.ID == NroPedido
                                select C);
                }

                if (chkFiltraProducto.Checked)
                    Consulta = (from C in Consulta
                                where C.Codigo == cmbProducto.SelectedValue.ToString()
                                select C);

                //if (chkFiltraEstado.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Estado == cmbFiltraEstado.Text
                //                select C);

                if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFechaDesde.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha <= dtpFechaHasta.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFechaDesde.Value.Date && C.Fecha <= dtpFechaHasta.Value.Date
                                select C);
                }

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colProducto_ID.DataPropertyName = "Producto_ID";
                colProducto.DataPropertyName = "Descripcion";
                colMedida.DataPropertyName = "Medida";
                colCantidad.DataPropertyName = "Cantidad";
                colCantidadAfec.DataPropertyName = "Cantidad_Afectada";
                colEstado.DataPropertyName = "Estado";
                colObservacion.DataPropertyName = "Observaciones";

                dgvOrdenPedido.AutoGenerateColumns = false;
                dgvOrdenPedido.DataSource = Resultados;
              
            }
        }
        private void ModificarCantidad()
        {
            AfectarPedido("2"); // Parcial
        }
        private void CancelarAfeccion() // Cancela la afeccion realizada para que no se guarden los cambios en otras palabras restablece todo
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from PC in hb.Pedido_Cuerpo
                                where PC.Pedido_ID == IDPedidoRecibido
                                    && PC.Registro_Pedidos.Cliente_ID == IDClienteRecibido
                                select PC);

                var Resultado = Consulta.ToList();

                foreach(var item in Resultado)
                {
                    if(item.Cantidad_Entregada != 0)
                    {
                        //decimal CantidadOriginal;
                        //decimal CantidadAfecOriginal;

                        //item.Cantidad = item.Cantidad + item.Cantidad_Afectada;
                        //item.Cantidad_Afectada = 0;

                        //if (item.Cantidad_AfecOri == 0)
                        //{
                        //    item.Cantidad = item.Cantidad + item.Cantidad_Afectada;
                        //    item.Cantidad_Afectada = 0;
                        //    item.Estado_ID = "PEN";
                        //}
                        //else // si este se ya viene afectada se carga aca
                        //{
                        //    item.Cantidad = item.Cantidad_Ori;
                        //    item.Cantidad_Afectada = item.Cantidad_AfecOri;
                            
                        //    if(item.Cantidad_AfecOri == item.Cantidad_Ori)
                        //        item.Estado_ID = "COM";
                        //    else
                        //        item.Estado_ID = "PEN";
                        //}
                    }
                }
                hb.SaveChanges();
            }
        }
        private void OnOffbtnEditarCantidad()
        {
            if (txtCantidad.TextLength > 0)
                btnEditar.Enabled = true;
            else
                btnEditar.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkFiltraNroPedido_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraNroPedido, chkFiltraNroPedido);
        }

        private void gbxFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsProConCheck(chkFiltraProducto, cmbProducto, txtBuscarProducto, chkMuestraInsProActInac, btnBuscarIProducto);
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProducto.Visible = false;
                clsCargarCombos.MostrarComboProducto(cmbProducto, txtBuscarProducto, true, chkMuestraInsProActInac);
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarProducto.Visible = false;
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void cmbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboProducto(cmbProducto, txtBuscarProducto, false, chkMuestraInsProActInac);
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarIProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
        }
        private void MostrarCantidadEntxt()
        {
            if(dgvOrdenPedido.RowCount > 0)
            {
                txtCantidad.Text = dgvOrdenPedido.CurrentRow.Cells[5].Value.ToString();
            //    CantidadOriginal = (decimal)dgvOrdenPedido.CurrentRow.Cells[4].Value; // Guarda en variable la cantidad Original
            //    CantidadAfectOriginal = (decimal)dgvOrdenPedido.CurrentRow.Cells[5].Value; // Guarda en variable la cantidad afectada original
            }
        }
        private void dgvOrdenPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarCantidadEntxt();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarPedidoCuerpo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            CancelarAfeccion();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ModificarCantidad();
           // dgvOrdenPedido.Refresh();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            using (var hb = new DBdatos())
            {
                CargarOrdenCarga();
            }
        }
       
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnEditarCantidad();
        }

        private void dgvOrdenPedido_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MostrarCantidadEntxt();
        }
        private void AfectarPedido(string CompletoParcial) // Afecta pedidos si , tiene funcionalidad para completo o parcial
        {
            if (dgvOrdenPedido.RowCount > 0)
            {
                using (var hb = new DBdatos())
                {
                    long Pedido_ID = (long)dgvOrdenPedido.CurrentRow.Cells[0].Value;

                    var ConsultaPedido = (from PC in hb.Pedido_Cuerpo
                                          where PC.Pedido_ID == Pedido_ID
                                          select PC);

                    var ResultadoPedido = ConsultaPedido.FirstOrDefault();

                    if (ResultadoPedido != null)
                    {
                        if (CompletoParcial == "1") // Lo que hace esto es acomodar las cantidades pendientes y afectadas
                        {
                            ResultadoPedido.Cantidad_Entregada = ResultadoPedido.Cantidad_Entregada + ResultadoPedido.Cantidad;
                            ResultadoPedido.Cantidad = 0; // Cantidad pendiente
                            ResultadoPedido.Estado_ID = "COM";
                        }
                        else // Lo que hace esto es acomodar las cantidades pendientes y afectadas
                        {
                            decimal CantidadAfeAnterior = ResultadoPedido.Cantidad_Entregada;

                            if (txtCantidad.TextLength > 0)
                                ResultadoPedido.Cantidad_Entregada = Convert.ToDecimal(txtCantidad.Text);
                            else
                                ResultadoPedido.Cantidad_Entregada = 0;

                            ResultadoPedido.Cantidad = ResultadoPedido.Cantidad + CantidadAfeAnterior - ResultadoPedido.Cantidad_Entregada;  // pendiente

                            if(ResultadoPedido.Cantidad == 0)
                            {
                                ResultadoPedido.Estado_ID = "COM";
                            }
                            if(ResultadoPedido.Cantidad > 0)
                            {
                                ResultadoPedido.Estado_ID = "PEN";
                            }
                        }
                    }
                    if (ResultadoPedido.Cantidad >= 0) // Validacion para que la cantidad no sea negativa.
                        hb.SaveChanges();
                    else
                        MessageBox.Show("La cantidad pendiente no puede ser negativa", "Atención");

                    MostrarPedidoCuerpo();
                }
            }
        }     
        private void btnAfec_Click(object sender, EventArgs e)
        {
            AfectarPedido("1");
        }
        private void CargarOrdenCarga()
        {
            using (var hb = new DBdatos())
            {
                var i = new Orden_Carga();

                //i.Cliente_ID = 

                for (int c = 1; c <= dgvOrdenPedido.Rows.Count; c++)
                {
                   if((decimal)dgvOrdenPedido.Rows[c - 1].Cells[5].Value > 0)
                   {
                        
                   }
                }
            }
        }
        private void dgvOrdenPedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrdenPedido.RowCount > 0) 
            {
                if(this.dgvOrdenPedido.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "Completo")
                    {
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.Green;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                    }
                }
              
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }
    }
}
    

