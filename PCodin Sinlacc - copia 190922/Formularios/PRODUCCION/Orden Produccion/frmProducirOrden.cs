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

namespace PCodin_Sinlacc.Formularios.Orden_Produccion
{
    public partial class frmProducirOrden : Form
    {
        public long IdRecibido; // orden produccion ID
        string SeccionFinal;
        string EstadoID;
        public frmProducirOrden()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MostrarDatos(); // SE HACE PARA QUE REFRESQUE LA INFO Y LOS TXT DE AVANCE PARA VER SI LOS FINALIZA
            FinalizarOrden();
            this.Close();
        }
        private void FinalizarOrden()
        {
            using (var hb = new DBdatos())
            {
                if(txtAvanceGral.Text != "")
                {
                    string Avance = txtAvanceGral.Text;
                    Avance = Avance.Replace("%", "");
                    Avance = Avance.Replace(" ", "");

                    if (Convert.ToDecimal(Avance) == 100)
                    {
                        var Consulta = (from OP in hb.Orden_Produccion1
                                        where OP.ID == IdRecibido
                                        select OP).FirstOrDefault();

                        if (Consulta.Estado_ID != "FI")
                        {
                            Consulta.Estado_ID = "FI";
                            hb.SaveChanges();
                        }
                    }
                }
            }
        }
        private void frmProducirOrden_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                try
                {
                    Reutilizables.RenderizarForm(this);

                    var Consulta = (from OPP in hb.Orden_Produccion_Parte
                                    where OPP.OrdenProduccion_Cuerpo.OrdenProd_ID == IdRecibido
                                    select OPP).FirstOrDefault();

                    EstadoID = Consulta.OrdenProduccion_Cuerpo.Orden_Produccion.Estado_ID;


                    if (Consulta != null)
                    {
                        txtNumeroOrden.Text = Consulta.OrdenProduccion_Cuerpo.Orden_Produccion.NumeroOrden.ToString();
                        //txtProducto.Text = Consulta.OrdenProduccion_Cuerpo.Productos_Insumos.Descripcion;                   
                    }
                    clsCargarCombos.MostrarSeccion(cmbSeccion);
                    //  clsCargarCombos.MostrarSeccionSegunProducto(cmbSeccion, ProductoID)
                    cmbSeccion.SelectedIndex = -1;
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message,"Error");
                }
               
            }

        }
        private void CalcularTiempoYAvanceTotal()
        {
            using (var hb = new DBdatos())
            {
                if (dataGridView1.RowCount > 0)
                {
                    long OrdenProdParte_ID;
                    int HorasTotal = 0;
                    int MinutosTotal = 0;
                    decimal AvanceTotal = 0;
                    decimal CantidadTotal = 0;
                    decimal CantidadProducida = 0;

                    var ConsultaAvanceTotal = (from VOPP in hb.Vista_OrdenProduccionParte
                                               where VOPP.OrdenProducionID == IdRecibido
                                               select VOPP).ToList();

                    foreach (var item in ConsultaAvanceTotal)
                    {
                        HorasTotal = HorasTotal + Convert.ToInt32(item.Horas);
                        MinutosTotal = MinutosTotal + Convert.ToInt32(item.Minutos);
                        //AvanceTotal = AvanceTotal + Convert.ToDecimal(item.Avance);
                        CantidadTotal = CantidadTotal + Convert.ToDecimal(item.Cantidad);
                        CantidadProducida = CantidadProducida + Convert.ToDecimal(item.CantidadProducida);
                    }
                    if (MinutosTotal >= 60)
                    {
                        HorasTotal = HorasTotal + 1;
                        MinutosTotal = MinutosTotal - 60;
                    }

                    txtTiempoGral.Text = HorasTotal.ToString() + " " + "h" + "  " + MinutosTotal.ToString() + " " + "min";
                    

                    if (ConsultaAvanceTotal.Count > 0)
                    {
                        //AvanceTotal = AvanceTotal / ConsultaAvanceTotal.Count;
                        AvanceTotal = (CantidadProducida * 100) / CantidadTotal;
                        cpbAvanceGeneral.Value = Convert.ToInt32(AvanceTotal);

                        txtAvanceGral.Text = AvanceTotal.ToString("N2") + " % ";
                        cpbAvanceGeneral.Text = AvanceTotal.ToString("N2") + " % ";
                    }
                    else
                    {
                        txtAvanceGral.Text = "0";
                        cpbAvanceGeneral.Text = "0 %";
                    }





                    if (AvanceTotal >= 0 && AvanceTotal <= 20)
                    {
                        txtAvanceGral.ForeColor = Color.Red;
                        cpbAvanceGeneral.ProgressColor = Color.Red;
                    }
                    if (AvanceTotal >= 21 && AvanceTotal <= 40)
                    {
                        txtAvanceGral.ForeColor = Color.OrangeRed;
                        cpbAvanceGeneral.ProgressColor = Color.OrangeRed;
                    }
                    if (AvanceTotal >= 41 && AvanceTotal <= 60)
                    {
                        txtAvanceGral.ForeColor = Color.FromArgb(192, 192, 0);
                        cpbAvanceGeneral.ProgressColor = Color.FromArgb(192, 192, 0);
                    }
                    if (AvanceTotal >= 61 && AvanceTotal <= 80)
                    {
                        txtAvanceGral.ForeColor = Color.YellowGreen;
                        cpbAvanceGeneral.ProgressColor = Color.YellowGreen;
                    }
                    if (AvanceTotal >= 81 && AvanceTotal <= 100)
                    {
                        txtAvanceGral.ForeColor = Color.FromArgb(0, 192, 0);
                        cpbAvanceGeneral.ProgressColor = Color.FromArgb(0, 192, 0);
                    }

                    txtTiempoGral.Text = HorasTotal.ToString() + " " + "h" + "  " + MinutosTotal.ToString() + " " + "min";
                }
            }
        }
        private void CalcularTiempoYAvanceTotalSeccion()
        {
            using (var hb = new DBdatos())
            {
                if (dataGridView1.RowCount > 0)
                {
                    long OrdenProdParte_ID;
                    int HorasTotal = 0;
                    int MinutosTotal = 0;
                    decimal AvanceTotal = 0;
                    decimal CantidadTotal = 0;
                    decimal CantidadProducida = 0;

                    var Consulta = (from VOPP in hb.Vista_OrdenProduccionParte
                                    where VOPP.OrdenProducionID == IdRecibido
                                        && VOPP.CodSeccion == (int)cmbSeccion.SelectedValue
                                    select VOPP).ToList();

                    var ConsultaAvanceTotal = (from VOPP in hb.Vista_OrdenProduccionParte
                                               where VOPP.OrdenProducionID == IdRecibido
                                               select VOPP).ToList();



                    foreach (var item in Consulta)
                    {
                        HorasTotal = HorasTotal + Convert.ToInt32(item.Horas);
                        MinutosTotal = MinutosTotal + Convert.ToInt32(item.Minutos);
                        AvanceTotal = AvanceTotal + Convert.ToDecimal(item.Avance);
                        CantidadTotal = CantidadTotal + Convert.ToDecimal(item.Cantidad);
                        CantidadProducida = CantidadProducida + Convert.ToDecimal(item.CantidadProducida);
                    }

                    if (MinutosTotal >= 60)
                    {
                        HorasTotal = HorasTotal + 1;
                        MinutosTotal = MinutosTotal - 60;
                    }

                    txtTiempoTotal.Text = HorasTotal.ToString() + " " + "h" + "  " + MinutosTotal.ToString() + " " + "min";

                    if (Consulta.Count > 0)
                    {
                        AvanceTotal = (CantidadProducida * 100) / CantidadTotal;
                        cpbAvanceSeccion.Value = Convert.ToInt32(AvanceTotal);
                        
                        txtAvance.Text = AvanceTotal.ToString("N2") + " % ";
                        cpbAvanceSeccion.Text = AvanceTotal.ToString("N2") + " % ";
                    }
                    else
                        txtAvance.Text = "0";

                    if (AvanceTotal >= 0 && AvanceTotal <= 20)
                    {
                        txtAvance.ForeColor = Color.Red;
                        cpbAvanceSeccion.ProgressColor = Color.Red;
                    }
                    if (AvanceTotal >= 21 && AvanceTotal <= 40)
                    {
                        txtAvance.ForeColor = Color.OrangeRed;
                        cpbAvanceSeccion.ProgressColor = Color.OrangeRed;
                    }
                    if (AvanceTotal >= 41 && AvanceTotal <= 60)
                    {
                        txtAvance.ForeColor = Color.FromArgb(192, 192, 0);
                        cpbAvanceSeccion.ProgressColor = Color.FromArgb(192, 192, 0);
                    }
                    if (AvanceTotal >= 61 && AvanceTotal <= 80)
                    {
                        txtAvance.ForeColor = Color.YellowGreen;
                        cpbAvanceSeccion.ProgressColor = Color.YellowGreen;
                    }
                    if (AvanceTotal >= 81 && AvanceTotal <= 100)
                    {
                        txtAvance.ForeColor = Color.FromArgb(0, 192, 0);
                        cpbAvanceSeccion.ProgressColor = Color.FromArgb(0, 192, 0);
                    }



                    //for (var i = 1; i <= dataGridView1.RowCount; i++)
                    //{
                    //    OrdenProdParte_ID = (long)dataGridView1.Rows[i - 1].Cells[columnName: "colOrdProdParteID"].Value;

                    //    var Consulta = (from VOPP in hb.Vista_OrdenProduccionParte
                    //                    where VOPP.OrdenProdParteID == OrdenProdParte_ID
                    //                        && VOPP.CodSeccion == (int)cmbSeccion.SelectedValue
                    //                    select VOPP).FirstOrDefault();

                    //    HorasTotal = HorasTotal + Convert.ToInt32(Consulta.Horas);
                    //    MinutosTotal = MinutosTotal + Convert.ToInt32(Consulta.Minutos);
                    //    AvanceTotal = AvanceTotal + Convert.ToDecimal(Consulta.Avance);
                    //}

                    //if(MinutosTotal >= 60)
                    //{
                    //    HorasTotal = HorasTotal + 1;
                    //    MinutosTotal = MinutosTotal - 60;
                    //}

                    txtTiempoTotal.Text = HorasTotal.ToString() + " " + "h" + "  " + MinutosTotal.ToString() + " " + "min";
                }
            }
        }
        //CALCULA LA CANTIDAD REAL SUMA DE LOS MOV DE PRODUCCION CARGADOS MANUALMENTE AFECTADOS
        private void CalcularCantidadReal()
        {
            decimal CantidadReal = 0;
            decimal CantidadEnOrden = 0;
            decimal CantidadAgregada = 0;

            using (var hb = new DBdatos())
            {
                var ConsultaOPC = (from OPC in hb.OrdenProduccion_Cuerpo
                                   where OPC.OrdenProd_ID == IdRecibido
                                   select OPC);

                var ConsultaEPT = (from EPT in hb.Existencia_ProductoTerminado
                                   where EPT.OrdenProduccion_ID == IdRecibido
                                   select EPT);

                if(chkFiltraProducto.Checked)
                {
                    ConsultaOPC = (from C in ConsultaOPC
                                   where C.Producto_ID == cmbProducto.SelectedValue.ToString()
                                   select C);

                    ConsultaEPT = (from C2 in ConsultaEPT
                                   where C2.Produto_ID == cmbProducto.SelectedValue.ToString()
                                        && C2.Estado_ID != "AN"
                                   select C2);
                }

                foreach(var itemOPC in ConsultaOPC)
                {
                    CantidadReal = CantidadReal + itemOPC.Cantidad;
                    CantidadEnOrden = CantidadEnOrden + itemOPC.Cantidad;
                }
                foreach(var itemEPT in ConsultaEPT)
                {
                    CantidadReal = CantidadReal + itemEPT.Cantidad;
                    CantidadAgregada = CantidadAgregada + itemEPT.Cantidad;
                }

                lblCantidadReal.Text = CantidadReal.ToString("N2");
                lblCantidaEnOrden.Text = CantidadEnOrden.ToString("N2");
                lblCantidadAgregada.Text = CantidadAgregada.ToString("N2");
            }
        }

        public void MostrarDatos()
        {
            if (cmbSeccion.SelectedValue != null)
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from VOPP in hb.Vista_OrdenProduccionParte
                                    where VOPP.CodSeccion == (int)cmbSeccion.SelectedValue
                                        && VOPP.OrdenProducionID == IdRecibido
                                    orderby VOPP.OrdenProdCuerpoID, VOPP.DescripcionInsumo
                                    select new
                                    {
                                        VOPP.OrdenProdParteID,
                                        VOPP.OrdenProdCuerpoID,
                                        VOPP.NroPedido,
                                        VOPP.Numero_Pedido,
                                        VOPP.CodigoInsumo,
                                        VOPP.DescripcionInsumo,
                                        VOPP.Cantidad,
                                        VOPP.CantidadProducida,
                                        VOPP.CantidadPendiente,
                                        VOPP.CodProducto,
                                        VOPP.DescripcionProducto,
                                        VOPP.CodSeccion,
                                        VOPP.DescripcionSeccion,
                                        TiempoEmpleadoTotal = VOPP.Horas + ":" + VOPP.Minutos,
                                        VOPP.Avance
                                    });

                    if (cmbOrdenar.SelectedIndex == 1)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.NroPedido ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.NroPedido descending
                                        select C);
                    }
                    if (cmbOrdenar.SelectedIndex == 2)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.CodigoInsumo ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.CodigoInsumo descending
                                        select C);
                    }
                    if (cmbOrdenar.SelectedIndex == 3)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.DescripcionInsumo ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.DescripcionInsumo descending
                                        select C);
                    }
                    if (cmbOrdenar.SelectedIndex == 4)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.Cantidad ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.Cantidad descending
                                        select C);
                    }
                    if (cmbOrdenar.SelectedIndex == 5)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.CantidadPendiente ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.CantidadPendiente descending
                                        select C);
                    }
                    if (cmbOrdenar.SelectedIndex == 6)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.CantidadProducida ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.CantidadProducida descending
                                        select C);
                    }
                    if (cmbOrdenar.SelectedIndex == 7)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.TiempoEmpleadoTotal ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.TiempoEmpleadoTotal descending
                                        select C);
                    }
                    if (cmbOrdenar.SelectedIndex == 8)
                    {
                        if (btnBuscarAsc.Visible == true)
                            Consulta = (from C in Consulta
                                        orderby C.Avance ascending
                                        select C);
                        else
                            Consulta = (from C in Consulta
                                        orderby C.Avance descending
                                        select C);
                    }

                    if (chkFiltraNumPedido.Checked)
                    {
                        long PedidoID = Convert.ToInt64(txtFiltraNumPedido.Text);

                        Consulta = (from C in Consulta
                                    where C.NroPedido == PedidoID
                                    select C);
                    }
                    if (chkFiltraProducto.Checked)
                    {

                        chkFiltraInsumo.Enabled = true;

                        Consulta = (from C in Consulta
                                    where C.CodProducto == cmbProducto.SelectedValue.ToString()
                                    select C);
                    }
                    if (chkFiltraInsumo.Checked)
                    {
                        if (chkFiltraProducto.Checked && cmbProducto.SelectedValue != null)
                        {
                            Consulta = (from C in Consulta
                                        where C.CodProducto == cmbProducto.SelectedValue.ToString()
                                        select C);
                        }
                        else
                        {

                        }
                    }

                    var Resultado = Consulta.ToList();

                    colOrdProdParteID.DataPropertyName = "OrdenProdParteID";
                    colOrdenProdCuerpID.DataPropertyName = "OrdenProdCuerpoID";
                    colNumPedido.DataPropertyName = "Numero_Pedido";

                    if (SeccionFinal == "SI")
                    {
                        colInsumo.HeaderText = "Producto";
                        colInsumoID.DataPropertyName = "CodProducto";
                        colInsumo.DataPropertyName = "DescripcionProducto";
                        CalcularCantidadReal();
                    }
                    else
                    {
                        colInsumo.HeaderText = "Insumo";
                        colInsumoID.DataPropertyName = "CodigoInsumo";
                        colInsumo.DataPropertyName = "DescripcionInsumo";
                    }
                    colCantidad.DataPropertyName = "Cantidad";
                    colCantPend.DataPropertyName = "CantidadPendiente";
                    colCantProd.DataPropertyName = "CantidadProducida";
                    colTiempoEmpleado.DataPropertyName = "TiempoEmpleadoTotal";
                    colAvance.DataPropertyName = "Avance";

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = Resultado;

                    CalcularTiempoYAvanceTotalSeccion();
                    CalcularTiempoYAvanceTotal();
                    CalcularCantidadReal();

                }
            }
        }
        private void FormatearCeldas(DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colCantidad")
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.SelectionForeColor = Color.Black;
                    e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);            
                }
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colCantPend")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                    e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                }
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colCantProd")
                {
                    e.CellStyle.ForeColor = Color.DarkGreen;
                    e.CellStyle.SelectionForeColor = Color.DarkGreen;
                    e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                }
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colAvance")
                {
                    if (Convert.ToInt32(e.Value) >= 0 && Convert.ToInt32(e.Value) <= 33)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                        //e.CellStyle.BackColor = Color.DarkGray;
                        //e.CellStyle.SelectionBackColor = Color.DarkGray;
                    }
                    if (Convert.ToInt32(e.Value) >= 34 && Convert.ToInt32(e.Value) <= 76)
                    {
                        e.CellStyle.ForeColor = Color.DarkCyan;
                        e.CellStyle.SelectionForeColor = Color.DarkCyan;
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                        //e.CellStyle.BackColor = Color.DarkGray;
                        //e.CellStyle.SelectionBackColor = Color.DarkGray;
                    }
                    if (Convert.ToInt32(e.Value) >= 77 && Convert.ToInt32(e.Value) <= 100)
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(0, 192, 0);
                        e.CellStyle.SelectionForeColor = Color.FromArgb(0, 192, 0);
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                        //e.CellStyle.BackColor = Color.DarkGray;
                        //e.CellStyle.SelectionBackColor = Color.DarkGray;
                    }
                    //if (Convert.ToInt32(e.Value) >= 61 && Convert.ToInt32(e.Value) <= 80)
                    //{
                    //    e.CellStyle.ForeColor = Color.YellowGreen;
                    //    e.CellStyle.SelectionForeColor = Color.YellowGreen;
                    //    e.CellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    //    e.CellStyle.BackColor = Color.DarkGray;
                    //    e.CellStyle.SelectionBackColor = Color.DarkGray;
                    //}
                    //if (Convert.ToInt32(e.Value) >= 81 && Convert.ToInt32(e.Value) <= 100)
                    //{
                    //    e.CellStyle.ForeColor = Color.FromArgb(0, 192, 0);
                    //    e.CellStyle.SelectionForeColor = Color.FromArgb(0, 192, 0);
                    //    e.CellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    //    e.CellStyle.BackColor = Color.DarkGray;
                    //    e.CellStyle.SelectionBackColor = Color.DarkGray;
                    //}
                }
            }
        }
        private void MostrarSeccionSegunProducto()
        {
            //using (var hb = new DBdatos())
            //{
            //    var ConsultaOP = (from OPC in hb.OrdenProduccion_Cuerpo
            //                      where OPC.OrdenProd_ID == IdRecibido
            //                      select OPC);

            //    var ConsultaSC = (from SC in hb.Seccion_Circuito
            //                    group SC by new { SC.Seccion_ID , SC.Seccion.Descripcion , SC.Producto_ID , SC.Orden } into Grupo
            //                    where Grupo.Key.Producto_ID
            //                        && S.
            //                    orderby S.Descripcion
            //                    select new
            //                    {
            //                        Id = S.ID,
            //                        Tittle = S.Descripcion,
            //                    });

            //    var Resultados = Consulta.ToList();

            //    Combo.ValueMember = "Id";
            //    Combo.DisplayMember = "Tittle";
            //    Combo.DataSource = Resultados;
            //}
        }
        private void MostrarDatosAgrupados()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from OPP in hb.Orden_Produccion_Parte
                                where OPP.OrdenProduccion_Cuerpo.OrdenProd_ID == IdRecibido
                                orderby OPP.OrdenProduccion_Cuerpo.Pedido_ID, OPP.OrdenProduccion_Cuerpo.Productos_Insumos.Descripcion
                                select new
                                {
                                    OPP.OrdenProduccion_Cuerpo.ID,
                                    OPP.OrdenProduccion_Cuerpo.Producto_ID,
                                    Producto = OPP.OrdenProduccion_Cuerpo.Productos_Insumos.Descripcion,
                                    OPP.OrdenProduccion_Cuerpo.Cantidad,
                                    CantidadPend = OPP.OrdenProduccion_Cuerpo.Cantidad - OPP.Cantidad_Producida,
                                    CantidadProd = OPP.Cantidad_Producida,
                                    OPP.Avance
                                });

                var Resultados = Consulta.ToList();

                //colOrdProdCuerpID.DataPropertyName = "ID";
                //colProductoID.DataPropertyName = "Producto_ID";
                //colProducto.DataPropertyName = "Producto";
                //colCantGral.DataPropertyName = "Cantidad";
                //colCantPend.DataPropertyName = "CantidadPend";
                //colCantProduc.DataPropertyName = "CantidadProd";
                //colAvance.DataPropertyName = "Avance";

                //dgvCircuitoProd.AutoGenerateColumns = false;
                //dgvCircuitoProd.DataSource = Resultados;
            }
        }
        //private void MostrarDatos()
        //{
        //    if (cmbSeccion.SelectedIndex != -1)
        //    {
        //        using (var hb = new DBdatos())
        //        {
        //            var Consulta = (from OPP in hb.Orden_Produccion_Parte
        //                            join SC in hb.Seccion_Circuito on OPP.OrdenProduccion_Cuerpo.Producto_ID equals SC.Producto_ID
        //                            where OPP.OrdenProduccion_Cuerpo.OrdenProd_ID == IdRecibido
        //                                && OPP.Insumo_ID == SC.Insumo_ID
        //                                && OPP.Seccion_ID == (int)cmbSeccion.SelectedValue
        //                            orderby OPP.OrdenProduccion_Cuerpo.Productos_Insumos.Descripcion
        //                            select new
        //                            {
        //                                OPP.ID,
        //                                OPP.OrdenProducCuerpo_ID,
        //                                OPP.Insumo_ID,
        //                                Insumo = OPP.OrdenProduccion_Cuerpo.Productos_Insumos.Descripcion,
        //                                OPP.Seccion_ID,
        //                                Secciones = OPP.Seccion.Descripcion,
        //                                OPP.OrdenProduccion_Cuerpo.Cantidad, // Cantidad genereal
        //                                CantidadPendiente = OPP.Cantidad - OPP.Cantidad_Producida,
        //                                CantidadProducida = OPP.Cantidad_Producida,
        //                                SC.Tiempo_Estimado,
        //                                OPP.Tiempo_Empleado
        //                            });

        //            var Resultado = Consulta.ToList();

        //            colOrdProParteID.DataPropertyName = "ID";
        //            colOrdProdCuerpID.DataPropertyName = "OrdenProducCuerpo_ID";
        //            colInsumoID.DataPropertyName = "Insumo_ID";
        //            colInsumo.DataPropertyName = "Insumo";
        //            colSeccionID.DataPropertyName = "Seccion_ID";
        //            colSeccion.DataPropertyName = "Secciones";
        //            colCantidad.DataPropertyName = "Cantidad";
        //            colCantidadPend.DataPropertyName = "CantidadPendiente";
        //            colCantProd.DataPropertyName = "CantidadProducida";
        //            colTiempoEstimado.DataPropertyName = "Tiempo_Estimado";
        //            colTiempoEmpleado.DataPropertyName = "Tiempo_Empleado";

        //            dgvCircuitoProd.AutoGenerateColumns = false;
        //            dgvCircuitoProd.DataSource = Resultado;
        //        }
        //    }
        //}
        private void AbrirForm()
        {
            if (dataGridView1.RowCount > 0)
            {
                long OrdenProdCuerpoID = (long)dataGridView1.CurrentRow.Cells[columnName: "colOrdenProdCuerpID"].Value;
                using (var hb = new DBdatos())
                {
                    var Consulta = (from OPC in hb.OrdenProduccion_Cuerpo
                                    where OPC.OrdenProd_ID == IdRecibido
                                        && OPC.ID == OrdenProdCuerpoID
                                    select OPC).FirstOrDefault();


                    var f = new frmProducirOndenAgregar();
                    //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarOrdenCarga_FormClosed);

                    f.FormularioProducirOrden = this;
                    f.OrdenProdPartID = (long)dataGridView1.CurrentRow.Cells[columnName: "colOrdProdParteID"].Value;
                    f.InsumoID = dataGridView1.CurrentRow.Cells[columnName: "colInsumoID"].Value.ToString();
                    f.Insumo = dataGridView1.CurrentRow.Cells[columnName: "colInsumo"].Value.ToString();
                    f.CantidadGeneral = (decimal)dataGridView1.CurrentRow.Cells[columnName: "colCantidad"].Value;
                    f.SeccionID = (int)cmbSeccion.SelectedValue;
                    f.OrdenProdID = IdRecibido;
                    f.ProductoID = Consulta.Producto_ID;
                    f.NumeroPedido = dataGridView1.CurrentRow.Cells[columnName: "colNumPedido"].Value.ToString();
                    f.EstadoID = EstadoID;

                    AddOwnedForm(f);
                    f.TopLevel = false;
                    f.Dock = DockStyle.Fill;
                    this.Controls.Add(f);
                    this.Tag = f;
                    f.WindowState = FormWindowState.Maximized;
                    f.BringToFront();
                    f.Show();
                }
            }
        }
        private void DefinirSeccionFinal()
        {
            if (cmbSeccion.SelectedValue != null)
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from SEC in hb.Seccion
                                    where SEC.ID == (int)cmbSeccion.SelectedValue
                                    select SEC).FirstOrDefault();

                    if (Consulta.Seccion_Final == "SI")
                        SeccionFinal = "SI";
                    else
                        SeccionFinal = "NO";
                }
            }
        }
        private void cmbSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeccion.SelectedIndex != -1)
            {
                DefinirSeccionFinal();
                MostrarDatos();
            }
            else
                dataGridView1.DataSource = null;//  MostrarDatos();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirForm();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(e);
        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraProducto, cmbProducto, txtBuscarProducto, btnBuscarIProducto, "PRO", "NO");
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

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void chkFiltraInsumo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiltraProducto.Checked && cmbProducto.SelectedValue != null)
                Reutilizables.ActivarFiltroInsumoSegunProductoSeleccionado(chkFiltraInsumo, cmbFiltraInsumo, cmbProducto, txtBuscaInsumo, btnBuscaInsumo);
            else
                Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsumo, cmbFiltraInsumo, txtBuscaInsumo, btnBuscaInsumo, "INS","SI");
        }

        private void txtBuscaInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsumo.Visible = false;
                if (chkFiltraProducto.Checked && cmbProducto.SelectedValue != null)
                    clsCargarCombos.MostrarComboInsumoSegunProductoSeleccionado(cmbFiltraInsumo, cmbProducto, txtBuscaInsumo, true);
                else
                    clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsumo, txtBuscaInsumo, "INS", true,"SI");

                txtBuscaInsumo.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaInsumo.Visible = false;
                txtBuscaInsumo.Focus();
                e.Handled = true;
            }
        }

        private void cmbFiltraInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                if (chkFiltraProducto.Checked && cmbProducto.SelectedValue != null)
                    clsCargarCombos.MostrarComboInsumoSegunProductoSeleccionado(cmbFiltraInsumo, cmbProducto, txtBuscaInsumo, false);
                else
                    clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsumo, txtBuscaInsumo, "INS", false,"SI"); txtBuscaInsumo.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscaInsumo_Click(object sender, EventArgs e)
        {
            txtBuscaInsumo.Visible = true;
            txtBuscaInsumo.Select();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dataGridView1);
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatos();
            btnBuscarAsc.Focus();
            btnBuscarAsc.Select();
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatos();         
            btnBuscarDesc.Focus();
            btnBuscarDesc.Select();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCantidadAgregada_Click(object sender, EventArgs e)
        {
            var f = new frmMostrarProduccionesRelacionadas();
            f.OrdenProd_ID = IdRecibido;
            f.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.RowCount > 0)
            {
                txtCantidad.Text = dataGridView1.CurrentRow.Cells[columnName: "colCantidad"].Value.ToString();
            }
        }
        private void ReducirOrdenProduccion()
        {
            DialogResult R = MessageBox.Show("¿Seguro que desea modificar la cantidad del orden solicitada?", "Atención", MessageBoxButtons.YesNoCancel);

            if (R == DialogResult.Yes)
            {
                if (txtCantidad.TextLength > 0)
                {
                    decimal CantidadOriginal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[columnName: "colCantidad"].Value);
                    decimal NuevaCantidad = Convert.ToDecimal(txtCantidad.Text);
                    decimal CantidadProducida = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[columnName: "colCantProd"].Value);
                    string NumeroPedido = dataGridView1.CurrentRow.Cells[columnName: "colNumPedido"].Value.ToString();
                    string ProductoID = dataGridView1.CurrentRow.Cells[columnName: "colInsumoID"].Value.ToString();

                    // CUANDO SE REDUCE LA CANTIDAD
                    if (NuevaCantidad < CantidadOriginal)
                    {
                        if (NuevaCantidad >= CantidadProducida)
                        {
                            using (var hb = new DBdatos())
                            {

                                var ConsultaPedido = (from PED in hb.Pedido_Cuerpo
                                                      where PED.Registro_Pedidos.Numero_Pedido == NumeroPedido
                                                        && PED.Producto_ID == ProductoID
                                                      select PED).FirstOrDefault();

                                // TRAE EL OPP ID
                                long OPP_ID = (long)dataGridView1.CurrentRow.Cells[columnName: "colOrdProdParteID"].Value;

                                var ConsultaOPP = (from OPP in hb.Orden_Produccion_Parte
                                                   where OPP.ID == OPP_ID
                                                   select OPP).FirstOrDefault();

                                var ConsultaConfig = (from CONF in hb.PcnConfiguraciones
                                                      where CONF.Modulo_ID == 1
                                                      select CONF).FirstOrDefault();

                                // CONSULTA PARA ELIMINAR LA ORDENPRODUCCION CUERPO 
                                var ConsultaOPC = (from OPC in hb.OrdenProduccion_Cuerpo
                                                   where OPC.OrdenProd_ID == IdRecibido
                                                        && OPC.Registro_Pedidos.Numero_Pedido == NumeroPedido
                                                        && OPC.Producto_ID == ProductoID
                                                   select OPC).FirstOrDefault();

                                //var ConsultaINS = (from INS in hb.ExistenciaProducto_ExistenciaInsumo
                                //                   where INS.OrdenProduccion_ID == IdRecibido
                                //                        && INS.);

                                // MODIFICA EL PENDIENTE DE PRODUCIR DE PEDIDO CUERPO // EL 0 QUITA EL PENDIENTE
                                if (NuevaCantidad == 0)
                                {
                                    if (dataGridView1.RowCount == 1)
                                    {
                                        MessageBox.Show("No se puede QUITAR el unico registro de la orden de producción. Se recomienda ANULAR la misma", "Atención");
                                        return;
                                    }
                                    else
                                    {
                                        //ConsultaPedido.Cantidad_Pend_Producir = ConsultaPedido.Cantidad_Pend_Producir - CantidadOriginal;
                                        ConsultaPedido.Cantidad_Total_Producida = ConsultaPedido.Cantidad_Total_Producida - CantidadProducida;
                                        ConsultaPedido.Cantidad_Afec_Producir = ConsultaPedido.Cantidad_Afec_Producir - CantidadOriginal;

                                        // ELIMINA LA ORDENPRODUCCION PARTE
                                        hb.Orden_Produccion_Parte.Remove(ConsultaOPP);
                                        //ELIMINA LA ORDENPRODUCCION CUERPO
                                        hb.OrdenProduccion_Cuerpo.Remove(ConsultaOPC);
                                    }
                                }
                                // MODIFICA EL PENDIENTE DE PRODUCIR DE PEDIDO CUERPO
                                else
                                {
                                    //ConsultaPedido.Cantidad_Pend_Producir = ConsultaPedido.Cantidad_Pend_Producir - NuevaCantidad;
                                    //ConsultaPedido.Cantidad_Total_Producida = ConsultaPedido.Cantidad_Total_Producida - NuevaCantidad;
                                    ConsultaPedido.Cantidad_Afec_Producir = ConsultaPedido.Cantidad_Afec_Producir - (CantidadOriginal - NuevaCantidad);

                                    //MODIFICA LA CANTIDAD DEL PEDIDO CUERPO
                                    ConsultaOPC.Cantidad = NuevaCantidad;


                                    //MODIFICA LA CANTIDAD DE LA TABLA OPP
                                    ConsultaOPP.Cantidad = NuevaCantidad;
                                }

                                if (ConsultaConfig.TrabajaConStockNegativo != "SI")
                                {
                                    // AQUI COMIENZA EL CODIGO PARA DEVOLVER INSUMOS -- ES LO CONTRARIO DEL QUE AGREGA
                                    var ConsultaCantInsAsociados = (from FP in hb.Formula_Producto
                                                                    where FP.Producto_ID == ProductoID
                                                                        && FP.Productos_Insumos.Subproducto == "NO"
                                                                    select FP).ToList();

                                    foreach (var item2 in ConsultaCantInsAsociados)
                                    {
                                        var ConsultaExistenciIns = (from EI in hb.Existencia_Insumos
                                                                    where EI.Insumo_ID == item2.Insumo_ID
                                                                    //&& EI.Productos_Insumos.Subproducto == "NO" // QUE SOLO VALORE PARA DESCONTAR STOCKS DE INSUMO LOS QUE NO SON SUBPRODUCTOS
                                                                    group EI by new { EI.Insumo_ID } into Grupo
                                                                    select new
                                                                    {
                                                                        Grupo.Key.Insumo_ID,
                                                                        CantidadDisponible = Grupo.Sum(x => x.Cantidad) - Grupo.Sum(x => x.Cantidad_Utilizada)
                                                                    });

                                        var ResultadosExistenciIns = ConsultaExistenciIns.FirstOrDefault();

                                        if (ResultadosExistenciIns != null)
                                        {
                                            decimal CantidadRequerida = NuevaCantidad * item2.Cantidad; // CANTIDAD DE LA ORDEN DE PRODUCCION X LA CANTIDAD DE LA FORMULA
                                            decimal CantidadDisponible = ResultadosExistenciIns.CantidadDisponible;

                                            decimal CantidadAcumulada = 0;
                                            decimal CantidadParcial = CantidadRequerida; // Esta es la cantidad requerida , la diferencia que se le va restando las cantidades
                                            List<long?> ListaID = new List<long?>();

                                            while (CantidadRequerida != CantidadAcumulada)
                                            {
                                                decimal CantidadDisponiblePorRegistro = 0;

                                                var ConsultaExistenciaIns2 = (from EI in hb.Existencia_Insumos
                                                                              where EI.Insumo_ID == item2.Insumo_ID
                                                                                //&& EI.Cantidad != EI.Cantidad_Utilizada
                                                                                && !ListaID.Contains(EI.ID)
                                                                              select EI);

                                                var ResultadoConsultaExistenciaIns2 = ConsultaExistenciaIns2.FirstOrDefault();


                                                CantidadDisponiblePorRegistro = ResultadoConsultaExistenciaIns2.Cantidad_Utilizada;

                                                // AQUI SE MODIFICAN O ELIMINAN LOS REGISTROS DE LA TABLA EXISTENCIAPRODUCTO_EXISTENCIAINSUMO                                         

                                                var ConsultaEIEP = (from EIEP in hb.ExistenciaProducto_ExistenciaInsumo
                                                                    where EIEP.ExistenciaInsumo_ID == ResultadoConsultaExistenciaIns2.ID
                                                                    select EIEP).FirstOrDefault();

                                                if (CantidadDisponiblePorRegistro >= CantidadParcial)
                                                {
                                                    ResultadoConsultaExistenciaIns2.Cantidad_Utilizada = ResultadoConsultaExistenciaIns2.Cantidad_Utilizada - CantidadParcial;
                                                    CantidadAcumulada = CantidadAcumulada + CantidadParcial;

                                                    //if (ResultadoConsultaExistenciaIns2.Cantidad == ResultadoConsultaExistenciaIns2.Cantidad_Utilizada)
                                                    //    ResultadoConsultaExistenciaIns2.Estado_ID = "COM";
                                                    if (ResultadoConsultaExistenciaIns2.Cantidad > ResultadoConsultaExistenciaIns2.Cantidad_Utilizada)
                                                        ResultadoConsultaExistenciaIns2.Estado_ID = "PEN";

                                                    ConsultaEIEP.Cantidad = ConsultaEIEP.Cantidad - CantidadParcial;

                                                    ListaID.Add(ResultadoConsultaExistenciaIns2.ID);
                                                }
                                                else
                                                {
                                                    ResultadoConsultaExistenciaIns2.Cantidad_Utilizada = 0; // DEVUELVE TODO
                                                    CantidadAcumulada = CantidadAcumulada + CantidadDisponiblePorRegistro;
                                                    ResultadoConsultaExistenciaIns2.Estado_ID = "PEN";

                                                    CantidadParcial = CantidadRequerida - CantidadDisponiblePorRegistro;
                                                    ListaID.Add(ResultadoConsultaExistenciaIns2.ID);

                                                    hb.ExistenciaProducto_ExistenciaInsumo.Remove(ConsultaEIEP);
                                                }
                                            }

                                            //var ConsultaEIEP = (from EIEP in hb.ExistenciaProducto_ExistenciaInsumo
                                            //                    where ListaID.Contains(EIEP.ExistenciaInsumo_ID)
                                            //                    select EIEP).ToList();

                                            //hb.ExistenciaProducto_ExistenciaInsumo.RemoveRange(ConsultaEIEP);


                                        }
                                        else
                                        {
                                            MessageBox.Show("No hay ningun registro del insumo " + item2.Productos_Insumos.Descripcion + " en el sistema. Para poder cargar un producto final deberá primero cargar este insumo", "Atención");
                                            return;
                                        }
                                    }
                                }
                                hb.SaveChanges();
                                MostrarDatos();
                            }
                        }
                        else
                        {
                            MessageBox.Show("La nueva cantidad no debe ser menor a la cantidad producida", "Atención");
                            return;
                        }
                    }
                    if (NuevaCantidad > CantidadOriginal)
                    {
                        if (NuevaCantidad == CantidadOriginal)
                            MessageBox.Show("La cantidad a modificar no debe ser IGUAL a la cantidad en pantalla", "Atención");
                        if (NuevaCantidad > CantidadOriginal)
                            MessageBox.Show("La cantidad a modificar no debe ser MAYOR a la cantidad en pantalla", "Atención");

                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No ingresó cantidad o la cantidad debe ser mayor a 0", "Atención");
                    return;
                }
            }
        }

        private void chkReducirCantidad_CheckedChanged(object sender, EventArgs e)
        {
            if(chkReducirCantidad.Checked)
            {
                txtCantidad.Enabled = true;
                btnReducirCantidad.Enabled = true;
            }
            else
            {
                txtCantidad.Enabled = false;
                btnReducirCantidad.Enabled = false;
            }
        }

        private void btnReducirCantidad_Click(object sender, EventArgs e)
        {
            ReducirOrdenProduccion();
        }

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarProducto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscaInsumo_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
