using System;
using System.Collections;
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


namespace PCodin_Sinlacc.Formularios.PRUEBA_DEPO_MAGDALENA
{
    public partial class frmDepositoB : Form
    {
        public frmDepositoB()
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

        public frmDepositoA FormDepositoA;
        public frmDepositoB FormDepositoB;
        public frmDepositoC FormDepositoC;
        public frmDepositoD FormDepositoD;
        public frmDepositoE FormDepositoE;
        public frmDepositoF FormDepositoF;
        public frmDepositoG FormDepositoG;
        public frmDepositoH FormDepositoH;
        public frmDepositoI FormDepositoI;
        public frmDepositoJ FormDepositoJ;

        private async void frmDepositoB_Load(object sender, EventArgs e)
        {
            //Ajusta la pantalla
            PantallaPrincipal.panel1.AutoScroll = false;
            PantallaPrincipal.panel1.HorizontalScroll.Value = 20;

            frmDepositoA.MostraPantallaEspera(ref PantallaEspera, "Actualizando deposito");

            Task Tarea1 = new Task(MostrarSeccionB);
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
        private void MostrarSeccionB()
        {
            using (var hb = new DBdatos2())
            {
                CantidadOcupados = 0;
                CheckForIllegalCrossThreadCalls = false;

                EliminarFilas();

                frmDepositoA.MostrarDatos(B01, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B02, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B03, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B04, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B05, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B06, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B07, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B08, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B09, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B10, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B11, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B12, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B13, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B14, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B15, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B16, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B17, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B18, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B19, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B20, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B21, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B22, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B23, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B24, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B25, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B28, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B29, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B30, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B31, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B32, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(B33, DS, DSFiltros, "B", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion, ProductoCantidad, ColorProducto, chart1);


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
            }
        }

        private void dgvLeyenda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgvLeyenda_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            frmDepositoA.FormatearCeldas(dgvLeyenda, e);
        }

        private void B01_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B02_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B03_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B04_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B05_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B06_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B07_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B08_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B09_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B11_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B12_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B13_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B14_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B15_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B16_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B17_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B18_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B19_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B20_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B21_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B22_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B23_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B24_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B25_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B26_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B27_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B28_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B29_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B30_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B31_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B32_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B33_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B34_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B35_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void B36_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
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

        private void dgvLeyenda_CellFormatting_2(object sender, DataGridViewCellFormattingEventArgs e)
        {
            frmDepositoA.FormatearCeldas(dgvLeyenda, e);
        }

        private void frmDepositoB_KeyDown(object sender, KeyEventArgs e)
        {

            frmDepositoA.AbrirFormSegunLetraPresiona(e,PantallaPrincipal,dgvLeyenda,picPreImagen);
            //if (e.KeyCode == Keys.A)
            //{
            //    PantallaPrincipal.PintarBoton("btnA");
            //    PantallaPrincipal.AbrirFormDepositoA();                
            //}
        }
    }
}
