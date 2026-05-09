using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Datos;
using Transitions;
using System.Diagnostics;
using PCodin_Sinlacc.Clases.UsuarioTema;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmIndicadores : Form
    {
        Stopwatch STW = new Stopwatch();

        public frmIndicadores()
        {
            InitializeComponent();
        }

        private void frmIndicadores_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        public int UsuarioID;
        private void InicializarForm()
        {

            Reutilizables.RenderizarForm(this);
            MostrarDatosEstadisticosVentas();
            MostrarProductoMasVendido();
            MostrarPedidosCompletosPendientes();
            MostrarPedidosPorCliente();
            MostrarMejorCliente();
            MostrarEmpleadoMasProductivo();
            // MostrarProductoMasProducido();

            //panel1.Location = new Point(-1000, 225);
            //panel2.Location = new Point(-1000, 225);

            //panel4.Location = new Point(-1000, 52);
            //panel5.Location = new Point(-1000, 52);
            //panel6.Location = new Point(-1000, 52);
            //panel7.Location = new Point(-1000, 216);

            clsUsuarioTema.UsuarioTema(UsuarioID, pnlSuperior, pnlSuperior, this);


        }
        private void MostrarDatosEstadisticosVentas()
        {
            using (var hb = new DBdatos())
            {
                DateTime Fecha = DateTime.Now.Date;

                var ConsultaPedidos = (from RP in hb.Registro_Pedidos
                                       where RP.Estado_ID != "AN"
                                            && RP.Fecha.Month == Fecha.Month
                                            && RP.Fecha.Year == Fecha.Year
                                       select RP);

                var ResultadosPedidos = ConsultaPedidos.ToList();

                if (ResultadosPedidos.Count > 0)
                {
                    txtPedidosMensuales.Text = ResultadosPedidos.Count.ToString();
                }
                else
                {
                    txtPedidosMensuales.Text = "0";
                }
            }
        }
        private void MostrarProductoMasVendido()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaOOC = (from OCC in hb.OrdenCarga_Cuerpo
                                   where OCC.Orden_Carga.Estado_ID != "AN"
                                   group OCC by new { OCC.Producto_ID, OCC.Productos_Insumos.Descripcion ,Medida = OCC.Productos_Insumos.Medidas_Producto.Descripcion } into Grupo
                                   select new
                                   {
                                       Grupo.Key.Descripcion,
                                       Grupo.Key.Producto_ID,
                                       Grupo.Key.Medida,
                                       Cantidad = Grupo.Sum(x => x.Cantidad)
                                   }).OrderByDescending(x => x.Cantidad).Take(1);

                var ResultadosOOC = ConsultaOOC.FirstOrDefault();

                if(ResultadosOOC != null)
                {
                    txtProdocMasVendido.Text = ResultadosOOC.Descripcion + " - " + ResultadosOOC.Producto_ID;
                    txtCantidadMasVendida.Text = ResultadosOOC.Cantidad.ToString() + " " + ResultadosOOC.Medida;
                }
                else
                {
                    txtProdocMasVendido.Text = "Ninguno";
                    txtCantidadMasVendida.Text = "0";
                }
            }
        }
        private void MostrarPedidosCompletosPendientes()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaRP = (from RP in hb.Registro_Pedidos
                                  where RP.Estado_ID != "AN"
                                        && RP.Estado_ID != "INF"
                                  group RP by new { RP.Estado_ID } into Grupo
                                  select new
                                  {
                                      Grupo.Key.Estado_ID,
                                      Cantidad = Grupo.Count()
                                  });

                var ResultadoRP = ConsultaRP.ToList();

                if(ResultadoRP.Count > 0)
                {
                    foreach(var item in ResultadoRP)
                    {
                        if (item.Estado_ID == "AU")
                        {
                            txtPedidosPendientes.Text = item.Cantidad.ToString();

                            if (item.Cantidad == 0)
                                txtPedidosPendientes.Text = "0";
                        }
                        if (item.Estado_ID == "FI")
                        {
                            txtPedidosCompletos.Text = item.Cantidad.ToString();

                            if (item.Cantidad == 0)
                                txtPedidosCompletos.Text = "0";
                        }                      
                    }                  
                }
            }
        }
        private void MostrarPedidosPorCliente()
        {
            using (var hb = new DBdatos())
            {
                // DateTime Fecha = DateTime.Now.Date;

                var ConsultaPedidos = (from RP in hb.Registro_Pedidos
                                       where RP.Estado_ID != "AN"
                                            && RP.Estado_ID != "INF"
                                       group RP by new { RP.Cliente_ID, RP.Clientes.Descripcion} into Grupo
                                       //&& RP.Fecha.Month == Fecha.Month
                                       //&& RP.Fecha.Year == Fecha.Year
                                       select new
                                       {
                                           Grupo.Key.Descripcion,
                                           CantidadPendiente = Grupo.Where(x=>x.Estado_ID == "AU").Count(),
                                           CantidadCompleta = Grupo.Where(x => x.Estado_ID == "FI").Count()
                                       }).OrderByDescending(x => x.CantidadCompleta);

                var ResultadosPedidos = ConsultaPedidos.ToList();

                colCliente.DataPropertyName = "Descripcion";
                colPendientes.DataPropertyName = "CantidadPendiente";
                colCompletos.DataPropertyName = "CantidadCompleta";

                dgvPedidosPorCliente.AutoGenerateColumns = false;
                dgvPedidosPorCliente.DataSource = ResultadosPedidos;
            }
        }
        private void MostrarMejorCliente()
        {
            if(dgvPedidosPorCliente.RowCount > 0 && (int)dgvPedidosPorCliente.Rows[0].Cells[2].Value > 0) // Lo segundo corrsponde a la cantidad de pedidos COMPLETOS
            {
                txtMejorCliente.Text = dgvPedidosPorCliente.Rows[0].Cells[0].Value.ToString();
                txtCantPedidoMejorCliente.Text = dgvPedidosPorCliente.Rows[0].Cells[2].Value.ToString() + " " + "pedidos";
            }
            else
            {
                txtMejorCliente.Text = "Ninguno";
                txtCantPedidoMejorCliente.Text = "0";
            }
        }
        private void MostrarEmpleadoMasProductivo()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                   where EPT.Movimiento_ID == "IPT"
                                        && EPT.Estado_ID != "AN"
                                   group EPT by new { EPT.Empleado_ID , EPT.Empleados.Nombre} into Grupo
                                   select new
                                   {
                                       Grupo.Key.Nombre,                     
                                       Total = Grupo.Sum(x => x.Cantidad)                                      
                                   }).OrderByDescending(x => x.Total).Take(1);

                var ResultadoEPT = ConsultaEPT.FirstOrDefault();

                if(ResultadoEPT != null)
                {
                    txtEmpleadoMasProductivo.Text = ResultadoEPT.Nombre;
                    lblEmpleadoMasProductivo.Text = ResultadoEPT.Total.ToString("N2");
                }
            }
        }
        private void MostrarProductoMasProducido()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                   where EPT.Movimiento_ID == "IPT"
                                        && EPT.Estado_ID != "AN"
                                   group EPT by new { EPT.Produto_ID,EPT.Productos_Insumos.Descripcion,Medida = EPT.Medidas_Producto.Descripcion} into Grupo
                                   select new
                                   {
                                       Grupo.Key.Produto_ID,
                                       Grupo.Key.Descripcion,
                                       Grupo.Key.Medida,
                                       Cantidad = Grupo.Sum(x=>x.Cantidad)
                                   }).OrderByDescending(x => x.Cantidad).Take(1);

                var ResultadoEPT = ConsultaEPT.FirstOrDefault();

                if(ResultadoEPT != null)
                {
                    //txtProductoMasProducido.Text = ResultadoEPT.Descripcion + " - " + ResultadoEPT.Produto_ID;
                    //txtCantidadProdMasProd.Text = ResultadoEPT.Cantidad.ToString() + " " + ResultadoEPT.Medida;
                }
                else
                {
                    //txtProductoMasProducido.Text = "Ninguno";
                    //txtCantidadProdMasProd.Text = "0";
                }
            }
        }
        private void NotificarCumpleaños()
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

                if(ResultadosCumpleaños.Count > 0)
                {
                    foreach( var item in ResultadosCumpleaños)
                    {
                        var C = new Notificaciones();

                        C.Fecha = Fecha;
                        C.Tipo_ID = 2;
                        C.Descripcion = "Hoy es el cumpleaños de " + item.Nombre + " le deseamos lo mejor en su día";
                        C.Leida = "NO";

                        hb.Notificaciones.Add(C);
                        hb.SaveChanges();
                    }
                }
            }
        }
        private void EliminarNotificaciones()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaNotificaciones = (from N in hb.Notificaciones
                                              select N).ToList();

                hb.Notificaciones.RemoveRange(ConsultaNotificaciones);
                hb.SaveChanges();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmIndicadores_Shown(object sender, EventArgs e)
        {
            //Transition T1 = new Transition(new TransitionType_EaseInEaseOut(1300));
            //T1.add(panel1, "Left", 0);
            //T1.run();

            //Transition T2 = new Transition(new TransitionType_EaseInEaseOut(1300));
            //T2.add(panel2, "Left", 375);
            //T2.run();

            STW.Start();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan T = new TimeSpan(0,0,0,0,(int)STW.ElapsedMilliseconds);

            label8.Text = T.Seconds.ToString();

            if(T.Seconds.ToString() == "1")
            {
                Transition T1 = new Transition(new TransitionType_EaseInEaseOut(1000));
                T1.add(panel1, "Left", 0);
                T1.run();

                Transition T2 = new Transition(new TransitionType_EaseInEaseOut(1000));
                T2.add(panel2, "Left", 375);
                T2.run();



                Transition T4 = new Transition(new TransitionType_EaseInEaseOut(1000));
                T4.add(panel4, "Left", 375);
                T4.run();

                Transition T5 = new Transition(new TransitionType_EaseInEaseOut(1000));
                T5.add(panel5, "Left", 0);
                T5.run();

                Transition T6 = new Transition(new TransitionType_EaseInEaseOut(1000));
                T6.add(panel6, "Left", 787);
                T6.run();

                Transition T7 = new Transition(new TransitionType_EaseInEaseOut(1000));
                T7.add(panel7, "Left", 787);
                T7.run();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(-1000, 225);
            panel2.Location = new Point(-1000, 225);
            
            panel4.Location = new Point(-1000, 52);
            panel5.Location = new Point(-1000, 52);
            panel6.Location = new Point(-1000, 52);
            panel7.Location = new Point(-1000, 216);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Transition T1 = new Transition(new TransitionType_EaseInEaseOut(1000));
            T1.add(panel1, "Left", 0);
            T1.run();

            Transition T2 = new Transition(new TransitionType_EaseInEaseOut(1000));
            T2.add(panel2, "Left", 375);
            T2.run();

           

            Transition T4 = new Transition(new TransitionType_EaseInEaseOut(1000));
            T4.add(panel4, "Left", 375);
            T4.run();

            Transition T5 = new Transition(new TransitionType_EaseInEaseOut(1000));
            T5.add(panel5, "Left", 0);
            T5.run();

            Transition T6 = new Transition(new TransitionType_EaseInEaseOut(1000));
            T6.add(panel6, "Left", 787);
            T6.run();

            Transition T7 = new Transition(new TransitionType_EaseInEaseOut(1000));
            T7.add(panel7, "Left", 787);
            T7.run();
        }
    }
}
