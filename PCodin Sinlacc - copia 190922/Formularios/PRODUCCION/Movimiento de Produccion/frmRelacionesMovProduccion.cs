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

namespace PCodin_Sinlacc.Formularios.Movimiento_de_Produccion
{
    public partial class frmRelacionesMovProduccion : Form
    {
        public string Formulario;
        public long IDRecibido;
        public string NumeroOrden;
        public string NumeroOrdenAsociada;
        public frmRelacionesMovProduccion()
        {
            InitializeComponent();
        }

        private void frmRelacionesMovProduccion_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                if (Formulario == "EPT")
                {
                    //var ConsultaInsumos = (from EI in hb.ExistenciaProducto_ExistenciaInsumo
                    //                       where EI.ExitenciaProducto_ID == IDRecibido
                    //                       orderby EI.ExistenciaInsumo_ID
                    //                       select new
                    //                       {
                    //                           EI.ExistenciaInsumo_ID,
                    //                           Insumo = EI.Existencia_Insumos.Productos_Insumos.Descripcion,
                    //                           EI.Cantidad
                    //                       });

                    //var ResultadosInsumo = ConsultaInsumos.ToList();




                    var ConsultaOP = (from OP in hb.Orden_Produccion1
                                      where OP.NumeroOrden == NumeroOrden
                                        || OP.NumeroOrden == NumeroOrdenAsociada
                                      select new
                                      {
                                          OP.NumeroOrden,
                                          Nombre = "Orden de Produción",

                                      }).ToList();

                    colNumeroMovimiento.DataPropertyName = "NumeroOrden";
                    colMovimiento.DataPropertyName = "Nombre";
                    colCantidad.DataPropertyName = "Cantidad";

                    dgvInsumo.AutoGenerateColumns = false;
                    dgvInsumo.DataSource = ConsultaOP;

                    var ConsultaOrdenCarga = (from OCAFEC in hb.Producto_Afec_OrdenCarga
                                              where OCAFEC.ExitenciaProTer_ID == IDRecibido
                                              orderby OCAFEC.Orden_ID
                                              select new
                                              {
                                                  OCAFEC.Orden_ID,
                                                  Producto = OCAFEC.Productos_Insumos.Descripcion,
                                                  OCAFEC.Cantidad
                                              });

                    var ResultadoOrdenCarga = ConsultaOrdenCarga.ToList();

                    colNumeroMovimiento2.DataPropertyName = "Orden_ID";
                    colMovimiento2.DataPropertyName = "Producto";
                    colCantidadOC.DataPropertyName = "Cantidad";

                    dgvOrdenCarga.AutoGenerateColumns = false;
                    dgvOrdenCarga.DataSource = ResultadoOrdenCarga;
                }
                if(Formulario == "PED")
                {
                    lbl1.Text = "Ordenes de producción";
                    lbl2.Text = "Ordenes de carga";

                    var Consulta = (from OPC in hb.OrdenProduccion_Cuerpo
                                    where OPC.Pedido_ID == IDRecibido
                                    orderby OPC.Orden_Produccion.NumeroOrden
                                    group OPC by new { OPC.Orden_Produccion.NumeroOrden } into Grupo
                                    select new
                                    {
                                        Grupo.Key.NumeroOrden,
                                        Movimiento = "Orden de producción"
                                    });

                    var Resultados1 = Consulta.ToList();

                    colNumeroMovimiento.DataPropertyName = "NumeroOrden";
                    colMovimiento.DataPropertyName = "Movimiento";

                    dgvInsumo.AutoGenerateColumns = false;
                    dgvInsumo.DataSource = Resultados1;

                    var ConsultaOrdenCarga = (from OCC in hb.OrdenCarga_Cuerpo
                                              where OCC.Pedido_ID == IDRecibido
                                              orderby OCC.Orden_Carga.Numero_Orden
                                              group OCC by new { OCC.Orden_Carga.Numero_Orden } into Grupo
                                              select new
                                              {
                                                  //OCC.Orden_ID,
                                                  Grupo.Key.Numero_Orden,
                                                  Movimiento = "Orden de carga",
                                                  //OCAFEC.Cantidad
                                              }) ;

                    var Resultados2 = ConsultaOrdenCarga.ToList();

                    colNumeroMovimiento2.DataPropertyName = "Numero_Orden";
                    colMovimiento2.DataPropertyName = "Movimiento";
                    colCantidadOC.DataPropertyName = "Cantidad";

                    dgvOrdenCarga.AutoGenerateColumns = false;
                    dgvOrdenCarga.DataSource = Resultados2;

                }
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvInsumo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
