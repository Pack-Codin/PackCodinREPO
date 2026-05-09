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
    public partial class frmDepositoC : Form
    {
        public frmDepositoC()
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

            Task Tarea1 = new Task(MostrarSeccionC);
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
        private void MostrarSeccionC()
        {
            using (var hb = new DBdatos2())
            {
                CantidadOcupados = 0;
                CheckForIllegalCrossThreadCalls = false;

                EliminarFilas();

                frmDepositoA.MostrarDatos(C02, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo, ProductoDescripcion, ProductoCantidad, ColorProducto, chart1);
                frmDepositoA.MostrarDatos(C03, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C04, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C05, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C06, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C07, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C08, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C09, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C10, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C11, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C12, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C13, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C14, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C15, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C16, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C17, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C18, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C19, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C20, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C21, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C22, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C23, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C24, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C25, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C28, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C29, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C30, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C31, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C32, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                frmDepositoA.MostrarDatos(C33, DS, DSFiltros, "C", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);


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

        private void C01_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C02_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C03_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C04_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C05_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C06_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C07_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C08_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C09_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C11_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C12_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C13_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C14_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C15_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C16_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C17_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C18_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C36_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C35_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C34_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C33_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C32_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C31_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C30_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C29_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C28_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C27_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C26_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C25_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C24_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C23_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C22_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C21_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C20_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void C19_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDepositoA.AbrirDetalle(DS, sender, e);
        }

        private void dgvLeyenda_CellFormatting_2(object sender, DataGridViewCellFormattingEventArgs e)
        {
            frmDepositoA.FormatearCeldas(dgvLeyenda, e);
        }

        private void frmDepositoC_KeyDown(object sender, KeyEventArgs e)
        {
            frmDepositoA.AbrirFormSegunLetraPresiona(e, PantallaPrincipal, dgvLeyenda, picPreImagen);
        }
    }
}
