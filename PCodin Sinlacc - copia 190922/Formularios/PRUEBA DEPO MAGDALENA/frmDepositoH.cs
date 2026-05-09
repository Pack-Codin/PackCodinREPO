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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using System.Collections;


namespace PCodin_Sinlacc.Formularios.PRUEBA_DEPO_MAGDALENA
{
    public partial class frmDepositoH : Form
    {
        public frmDepositoH()
        {
            InitializeComponent();
        }
        public bool SeccionB;
        public Pruebadepo PantallaPrincipal;
        public DataSet1 DS;
        public DataSetFiltros DSFiltros;

        decimal CantidadDepositos = 0;
        decimal CantidadOcupados = 0;

        public List<string> ListaProductos = new List<string>();

        frmPantallaEspera PantallaEspera;
        frmPrueba2 FormReporte;

        public bool FiltroActivo = false;
        public Panel pnlBotones;

        ArrayList ProductoDescripcion = new ArrayList();
        ArrayList ProductoCantidad = new ArrayList();
        ArrayList ColorProducto = new ArrayList();


        private async void frmDepositoB_Load(object sender, EventArgs e)
        {
            PantallaPrincipal.panel1.AutoScroll = false;
            PantallaPrincipal.panel1.HorizontalScroll.Value = 20;

            frmDepositoA.MostraPantallaEspera(ref PantallaEspera, "Actualizando deposito");

            Task Tarea1 = new Task(MostrarSeccionD);
            Tarea1.Start();
            await Tarea1;

            frmDepositoA.OcultarPantallaEspera(ref PantallaEspera);

            this.Focus();
            this.Select();
        }
        private void EliminarFilas()
        {
            foreach (var Control in this.Controls)
            {
                if (Control is DataGridView)
                {
                    if (((DataGridView)Control).RowCount > 0)
                    {
                        int CantidadTotal = ((DataGridView)Control).RowCount;

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            ((DataGridView)Control).Rows.RemoveAt(CantidadTotal - i);
                        }
                    }
                }
            }
        }
        private void MostrarSeccionD()
        {           
            using (var hb = new DBdatos2())
            {
                CantidadOcupados = 0;
                CheckForIllegalCrossThreadCalls = false;

                EliminarFilas();

                frmDepositoA.MostrarDatos(H00, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H01, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H02, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H03, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H04, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H05, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H06, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H07, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H08, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H09, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H10, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H11, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H12, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H13, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H14, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H15, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H16, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H17, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H18, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H19, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H20, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(H21, DS, DSFiltros, "H", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion, ProductoCantidad, ColorProducto, chart1);



                //frmDepositoA.MostrarDatos(D22, DS,DSFiltros, "D", dgvLeyenda, ListaProductos, ref CantidadOcupados,ref FiltroActivo);
                //frmDepositoA.MostrarDatos(D23, DS,DSFiltros, "D", dgvLeyenda, ListaProductos, ref CantidadOcupados,ref FiltroActivo);
                //frmDepositoA.MostrarDatos(D24, DS,DSFiltros, "D", dgvLeyenda, ListaProductos, ref CantidadOcupados,ref FiltroActivo);
                //frmDepositoA.MostrarDatos(D25, DS,DSFiltros, "D", dgvLeyenda, ListaProductos, ref CantidadOcupados,ref FiltroActivo);
                //frmDepositoA.MostrarDatos(D28, DS,DSFiltros, "D", dgvLeyenda, ListaProductos, ref CantidadOcupados,ref FiltroActivo);
                //frmDepositoA.MostrarDatos(D29, DS,DSFiltros, "D", dgvLeyenda, ListaProductos, ref CantidadOcupados,ref FiltroActivo);
                //frmDepositoA.MostrarDatos(D30, DS,DSFiltros, "D", dgvLeyenda, ListaProductos, ref CantidadOcupados,ref FiltroActivo);
                //frmDepositoA.MostrarDatos(D31, DS,DSFiltros, "D", dgvLeyenda, ListaProductos, ref CantidadOcupados,ref FiltroActivo);
                //frmDepositoA.MostrarDatos(D32, DS,DSFiltros, "D", dgvLeyenda, ListaProductos, ref CantidadOcupados,ref FiltroActivo);
                //frmDepositoA.MostrarDatos(D33, DS,DSFiltros, "D", dgvLeyenda, ListaProductos, ref CantidadOcupados,ref FiltroActivo);


                if (FiltroActivo == true)
                {
                    frmDepositoA.MostrarLeyenda(DSFiltros, dgvLeyenda, lblSeccion, colColor, colCodigo, colProducto, colCantidad, ProductoDescripcion, ProductoCantidad, chart1);

                    lblLibres.Text = "0,00";
                    lblOcupados.Text = "0,00";
                    lblPorcentaje.Text = "0,00 %";
                }
                else
                {
                    frmDepositoA.MostrarLeyenda(DS, dgvLeyenda, lblSeccion, colColor, colCodigo, colProducto, colCantidad, ProductoDescripcion, ProductoCantidad, chart1);
                    frmDepositoA.KPIPorcentajeOcupacion(lblSeccion.Text, ref CantidadDepositos, ref CantidadOcupados, lblPorcentaje, lblLibres, lblOcupados, circularProgressBar1);
                }










                //    frmDepositoA.KPIPorcentajeOcupacion(lblSeccion.Text, ref CantidadDepositos, ref CantidadOcupados, lblPorcentaje, lblLibres, lblOcupados);

                //    if (HayFiltroActivo == true)
                //    {
                //        lblLibres.Text = "0,00";
                //        lblOcupados.Text = "0,00";
                //        lblPorcentaje.Text = "0,00 %";
                //    }
                //    else
                //    {
                //        frmDepositoA.KPIPorcentajeOcupacion(lblSeccion.Text, ref CantidadDepositos, ref CantidadOcupados, lblPorcentaje, lblLibres, lblOcupados);
                //    }

                //    //PantallaPrincipal.SeccionA = true;
                //    //PantallaPrincipal.FormulariaSeccionA = this;

                //    if (HayFiltroActivo == true)
                //    {
                //        foreach (var Botones in pnlBotones.Controls)
                //        {
                //            if (Botones is Button)
                //            {
                //                string SeccionBoton = ((Button)Botones).Name.Replace("btn", "");

                //                var ConsultaGeneral = (from C in DS.Tables["Deposito"].AsEnumerable()
                //                                       where C.Field<string>("CodProducto").Contains(cmbFiltraProducto.SelectedValue.ToString())
                //                                            && C.Field<string>("Seccion") == SeccionBoton
                //                                       select C).FirstOrDefault();

                //                if (ConsultaGeneral != null)
                //                    ((Button)Botones).Visible = true;
                //                else
                //                    ((Button)Botones).Visible = false;
                //            }
                //        }                                      
                //    }
                //    else
                //    {
                //        foreach (var Botones in pnlBotones.Controls)
                //        {
                //            if (Botones is Button)
                //            {
                //                ((Button)Botones).Visible = true;

                //            }
                //        }
                //    }
            }
        }

        private void dgvLeyenda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgvLeyenda_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            frmDepositoA.FormatearCeldas(dgvLeyenda, e);
        }

        private void btnImprimir_MouseEnter(object sender, EventArgs e)
        {
            PantallaPrincipal.panel1.AutoScroll = false;

            PantallaPrincipal.panel1.HorizontalScroll.Value = 20;
        }

        private void btnImprimir_MouseLeave(object sender, EventArgs e)
        {
            PantallaPrincipal.panel1.AutoScroll = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmDepositoA.ImprimirDeposito(PantallaPrincipal, picPreImagen);
        }

        private void D01_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D02_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D03_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D04_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D05_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D06_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D07_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D08_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D09_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D11_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D12_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D13_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D14_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D15_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D16_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D17_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void D18_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C19_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C20_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C21_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C22_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C23_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C24_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C25_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C26_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C27_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C28_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C29_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C30_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C31_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C32_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C33_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C34_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C35_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C36_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void dgvLeyenda_CellFormatting_2(object sender, DataGridViewCellFormattingEventArgs e)
        {
            frmDepositoA.FormatearCeldas(dgvLeyenda, e);
        }

        private void frmDepositoH_KeyDown(object sender, KeyEventArgs e)
        {
            frmDepositoA.AbrirFormSegunLetraPresiona(e, PantallaPrincipal, dgvLeyenda, picPreImagen);
        }
    }
}
