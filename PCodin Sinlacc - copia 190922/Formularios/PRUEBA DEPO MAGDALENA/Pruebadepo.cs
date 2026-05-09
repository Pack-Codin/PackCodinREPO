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
using System.Drawing.Imaging;
using PCodin_Sinlacc.Clases;

namespace PCodin_Sinlacc.Formularios.PRUEBA_DEPO_MAGDALENA
{
    public partial class Pruebadepo : Form
    {
        public Pruebadepo()
        {
            InitializeComponent();
        }
        // Variable para determinar que Seccion selecionamos al ultimo
        private string SeccionSeleccionada;

        // Estas variables se crean para que indiquen si el form está abierto o no
        public bool SeccionA = false;
        public bool SeccionB = false;
        public bool SeccionC = false;
        public bool SeccionD = false;
        public bool SeccionE = false;
        public bool SeccionF = false;
        public bool SeccionG = false;
        public bool SeccionH = false;
        public bool SeccionI = false;
        public bool SeccionJ = false;

        public string SeccionActiva = "";

        //private frmDepositoA FormDepositoA = new frmDepositoA();
        //private frmDepositoB FormDepositoB = new frmDepositoB();
        //private frmDepositoC FormDepositoC = new frmDepositoC();
        //private frmDepositoD FormDepositoD = new frmDepositoD();
        //private frmDepositoE FormDepositoE = new frmDepositoE();
        //private frmDepositoF FormDepositoF = new frmDepositoF();
        //private frmDepositoG FormDepositoG = new frmDepositoG();
        //private frmDepositoH FormDepositoH = new frmDepositoH();
        //private frmDepositoI FormDepositoI = new frmDepositoI();
        //private frmDepositoJ FormDepositoJ = new frmDepositoJ();

        //public frmDepositoA FormulariaSeccionA;
        //public frmDepositoB FormulariaSeccionB;
        public Pruebadepo FormPrincipal;

        public frmPantallaIncio PantallaIncio;
        public DataSet1 DS = new DataSet1();
        public DataSetFiltros DSFiltros = new DataSetFiltros();

        private frmPantallaEspera PantallaEspera;
        public frmFiltros PantallaFiltros = new frmFiltros();

        IQueryable<DataSet1> ConsultaMadre = Enumerable.Empty<DataSet1>().AsQueryable();

        //FILTROS
        public bool FiltrosActivos = false;
        public string FiltroCodProducto;

        private void Pruebadepo_Load(object sender, EventArgs e)
        {
            InicializarForm();
            this.Focus();
        }
        public void InicializarForm()
        {
            PantallaIncio.Hide();           
        }

        public void PintarBoton(string SeccionSeleccionada)
        {
            foreach(var boton in pnlBotones.Controls)
            {
                if(boton is Button && ((Button)boton).Name == SeccionSeleccionada)
                {
                    ((Button)boton).BackColor = Color.Orange;
                }
                else
                {
                    if (boton is Button)
                        ((Button)boton).BackColor = Color.White;
                }
            }
        }
        //public static void AbrirFormDepositoA(Pruebadepo FormPrincipal , Panel pnlBotones , DataSet1 DS , DataSetFiltros DSFiltros, bool FiltrosActivos, Panel PanelPrincipal)
        //{
        //    var f = new frmDepositoA();
        //    f.PantallaPrincipal = FormPrincipal;
        //    f.pnlBotones = pnlBotones;
        //    f.KeyPreview = true;
        //    f.Focus();
        //    f.Select();
        //    f.DS = DS;
        //    f.DSFiltros = DSFiltros;
        //    f.FiltroActivo = FiltrosActivos;
        //    AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, PanelPrincipal);
        //}
        public void AbrirFormDepositoA()
        {
            var f = new frmDepositoA();
            f.PantallaPrincipal = this;
            f.pnlBotones = pnlBotones;
            f.KeyPreview = true;
            f.Focus();
            f.Select();
            f.DS = DS;
            f.DSFiltros = DSFiltros;
            f.FiltroActivo = FiltrosActivos;
            f.dgvLeyenda.Focus();
            SeccionActiva = "A";
            AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }
        public void AbrirFormDepositoB()
        {
            var f = new frmDepositoB();
            f.PantallaPrincipal = this;
            f.pnlBotones = pnlBotones;
            f.KeyPreview = true;
            f.Focus();
            f.Select();
            f.DS = DS;
            f.DSFiltros = DSFiltros;
            f.FiltroActivo = FiltrosActivos;
            f.dgvLeyenda.Focus();
            SeccionActiva = "B";
            AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);

        }
        public void AbrirFormDepositoC()
        {
            var f = new frmDepositoC();
            f.PantallaPrincipal = this;
            f.pnlBotones = pnlBotones;
            f.KeyPreview = true;
            f.Focus();
            f.Select();
            f.DS = DS;
            f.DSFiltros = DSFiltros;
            f.FiltroActivo = FiltrosActivos;
            f.dgvLeyenda.Focus();
            SeccionActiva = "C";
            AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }
        public void AbrirFormDepositoD()
        {
            var f = new frmDepositoD();
            f.PantallaPrincipal = this;
            f.pnlBotones = pnlBotones;
            f.KeyPreview = true;
            f.Focus();
            f.Select();
            f.DS = DS;
            f.DSFiltros = DSFiltros;
            f.FiltroActivo = FiltrosActivos;
            f.dgvLeyenda.Focus();
            SeccionActiva = "D";
            AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }
        public void AbrirFormDepositoE()
        {
            var f = new frmDepositoE();
            f.PantallaPrincipal = this;
            f.pnlBotones = pnlBotones;
            f.KeyPreview = true;
            f.Focus();
            f.Select();
            f.DS = DS;
            f.DSFiltros = DSFiltros;
            f.FiltroActivo = FiltrosActivos;
            AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }
        public void AbrirFormDepositoF()
        {
            var f = new frmDepositoF();
            f.PantallaPrincipal = this;
            f.pnlBotones = pnlBotones;
            f.KeyPreview = true;
            f.Focus();
            f.Select();
            f.DS = DS;
            f.DSFiltros = DSFiltros;
            f.FiltroActivo = FiltrosActivos;
            AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }
        public void AbrirFormDepositoG()
        {
            var f = new frmDepositoG();
            f.PantallaPrincipal = this;
            f.pnlBotones = pnlBotones;
            f.KeyPreview = true;
            f.Focus();
            f.Select();
            f.DS = DS;
            f.DSFiltros = DSFiltros;
            f.FiltroActivo = FiltrosActivos;
            AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }
        public void AbrirFormDepositoH()
        {
            var f = new frmDepositoH();
            f.PantallaPrincipal = this;
            f.pnlBotones = pnlBotones;
            f.KeyPreview = true;
            f.Focus();
            f.Select();
            f.DS = DS;
            f.DSFiltros = DSFiltros;
            f.FiltroActivo = FiltrosActivos;
            AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }
        public void AbrirFormDepositoI()
        {
            var f = new frmDepositoI();
            f.PantallaPrincipal = this;
            f.pnlBotones = pnlBotones;
            f.KeyPreview = true;
            f.Focus();
            f.Select();
            f.DS = DS;
            f.DSFiltros = DSFiltros;
            f.FiltroActivo = FiltrosActivos;
            AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }
        public void AbrirFormDepositoJ()
        {
            var f = new frmDepositoJ();
            f.PantallaPrincipal = this;
            f.pnlBotones = pnlBotones;
            f.KeyPreview = true;
            f.Focus();
            f.Select();
            f.DS = DS;
            f.DSFiltros = DSFiltros;
            f.FiltroActivo = FiltrosActivos;
            AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }
        public void btnA_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;

            PintarBoton(Boton.Name);

            AbrirFormDepositoA();

            //var f = new frmDepositoA();
            //f.PantallaPrincipal = this;
            //f.pnlBotones = pnlBotones;
            //f.KeyPreview = true;
            //f.Focus();
            //f.Select();
            //f.DS = DS;
            //f.DSFiltros = DSFiltros;
            //f.FiltroActivo = FiltrosActivos;
            //AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }             
        private void CambiarColorLetraBlanco(Button btn , string ColorLetra)
        {
            btn.ForeColor = Color.FromName(ColorLetra);
        }

        private void pnlBotones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnA_MouseEnter(object sender, EventArgs e)
        {
            CambiarColorLetraBlanco(btnA,"White");
        }

        private void btnA_MouseLeave(object sender, EventArgs e)
        {
            CambiarColorLetraBlanco(btnA, "Black");
        }
        public void LlenarDataSet()
        {
            using (var hb = new DBdatos2())
            {               
                DS.Tables[name: "Deposito"].Clear();
                DS.Tables[name: "DepositoCantidad"].Clear();
                DSFiltros.Tables[name: "Deposito"].Clear();
                DSFiltros.Tables[name: "DepositoCantidad"].Clear();


                var Consulta = (from C in hb.Vst_Deposito2
                                where C.DescDepo != "NC"
                                select C);

                var Consulta2 = (from C in Consulta
                                 orderby C.DescDepo
                                 group C by new { C.DescArticulo, C.Articulo , C.Color ,C.DescDepo} into Grupo
                                 select new
                                 {
                                     Grupo.Key.DescArticulo,
                                     Cantidad2 = Grupo.Count(),
                                     Grupo.Key.Color,
                                     Grupo.Key.DescDepo,
                                     Grupo.Key.Articulo

                                 }).ToList();

                foreach (var item2 in Consulta2)
                {

                    DS.Tables[name: "DepositoCantidad"].Rows.Add
                                (new object[] {

                                    item2.DescArticulo,
                                    item2.Cantidad2.ToString("N2"),
                                    item2.Color,
                                    item2.DescDepo,
                                    item2.Articulo
                                });
                }

                var Resultados = Consulta.ToList();

                foreach (var item1 in Resultados)
                {
                    string Seccion = "";

                    if(item1.DescDepo.Length ==3)
                    {
                        Seccion = item1.DescDepo.Remove(1, 2);
                    }
                    DS.Tables[name: "Deposito"].Rows.Add
                                (new object[] {

                                    item1.DescDepo,
                                    item1.Articulo,
                                    item1.Cantidad,
                                    item1.Color,
                                    item1.DescArticulo,
                                    item1.DescCalidad,
                                    item1.SerieLote,
                                    item1.DescCentroOperativo,
                                    Seccion,
                                    item1.Deposito,
                                    item1.Existencia,
                                });
                }

            }
        }
        private async void btnConectar_Click(object sender, EventArgs e)
        {
            MostrarPantallaEspera();

            Task Tarea1 = new Task(LlenarDataSet);
            Tarea1.Start();

            await Tarea1;

            lblTitulo1.Visible = false;
            lblTitulo2.Visible = false;
            lblTitulo3.Visible = false;

            btnA.Visible = true;
            btnB.Visible = true;
            btnC.Visible = true;
            btnD.Visible = true;
            btnE.Visible = true;
            btnF.Visible = true;
            btnG.Visible = true;
            btnH.Visible = true;
            btnI.Visible = true;
            btnJ.Visible = true;
            
            OcultarPantallaEspera();

            MostrarUltimaSincronizacion();
        }
        private void MostrarUltimaSincronizacion()
        {
            lblTituloSincronizacion.Visible = true;
            lblUltimaSincronizacion.Visible = true;
            lblUltimaSincronizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }
        private void MostrarPantallaEspera()
        {
            PantallaEspera = new frmPantallaEspera();
            PantallaEspera.textBox1.Text = "Sincronizando depósito";
            PantallaEspera.Show();
        }
        private void OcultarPantallaEspera()
        {
            if (PantallaEspera != null)
                PantallaEspera.Close();
        }

        private void btnConectar_MouseEnter(object sender, EventArgs e)
        {
            CambiarColorLetraBlanco(btnSincronizar, "White");
        }

        private void btnConectar_MouseLeave(object sender, EventArgs e)
        {
            CambiarColorLetraBlanco(btnSincronizar, "Black");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;

            PintarBoton(Boton.Name);

            AbrirFormDepositoC();

            //var f = new frmDepositoC();
            //f.PantallaPrincipal = this;
            //f.pnlBotones = pnlBotones;
            //f.KeyPreview = true;
            //f.Focus();
            //f.Select();
            //f.DS = DS;
            //f.DSFiltros = DSFiltros;
            //f.FiltroActivo = FiltrosActivos;
            //AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }

        private void btnMostrarFiltros_Click(object sender, EventArgs e)
        {
            PantallaFiltros.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFiltros_FormClosed);          
            PantallaFiltros.PantallaPrincipal = this;
            PantallaFiltros.DS = DS;
            PantallaFiltros.SeccionActiva = SeccionActiva;
            PantallaFiltros.ShowDialog();
        }

        private void frmFiltros_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        public void FiltrarDatos()
        {
            bool FiltrosActivos = false;
                    
            var ConsultaSinFiltro = (from C in DS.Tables["Deposito"].AsEnumerable()
                                     select C);

            var ConsultaFiltro = (from C in DS.Tables["Deposito"].AsEnumerable()
                                     select C);

            if (FiltroCodProducto != "")
            {
                ConsultaFiltro = (from C in ConsultaSinFiltro
                                  where C.Field<string>("CodProducto") == FiltroCodProducto
                                  select C);

                FiltrosActivos = true;
            }
            if (FiltrosActivos == true)
            {
                btnSincronizar.Enabled = false;

                DSFiltros.Tables[name: "Deposito"].Clear();

                foreach (var item in ConsultaFiltro)
                {
                    DSFiltros.Tables[name: "Deposito"].Rows.Add
                        (new object[] {

                                    item.Field<string>("Deposito"),
                                    item.Field<string>("CodProducto"),
                                    item.Field<string>("Cantidad"),
                                    item.Field<string>("Color"),
                                    item.Field<string>("Producto"),
                                    item.Field<string>("Calidad"),
                                    item.Field<string>("SerieLote"),
                                    item.Field<string>("CentroOperativo"),
                                    item.Field<string>("Seccion"),
                                    item.Field<int>("CodDeposito"),
                                    item.Field<decimal>("Existencia")
                        });

                    foreach(var Boton in pnlBotones.Controls)
                    {
                        if(Boton is Button)
                        {
                            string SeccionBoton = ((Button)Boton).Name.Replace("btn", "");

                            var NuevaConsulta = (from C in DSFiltros.Tables["Deposito"].AsEnumerable()
                                                 where C.Field<string>("CodProducto").Contains(FiltroCodProducto)
                                                      && C.Field<string>("Seccion") == SeccionBoton
                                                 select C).ToList();

                            if (NuevaConsulta.Count > 0)
                                ((Button)Boton).Visible = true;
                            else
                                ((Button)Boton).Visible = false;
                        }
                    }
                }   
                
            }
            else
            {
                btnSincronizar.Enabled = true;

                foreach (var Boton in pnlBotones.Controls)
                {
                    if (Boton is Button)
                    {
                        ((Button)Boton).Visible = true;
                    }
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBuscaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cmbFiltraProducto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnB_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;

            PintarBoton(Boton.Name);

            AbrirFormDepositoB();

            //var f = new frmDepositoB();
            //f.PantallaPrincipal = this;
            //f.pnlBotones = pnlBotones;
            //f.KeyPreview = true;
            //f.Focus();
            //f.Select();
            //f.DS = DS;
            //f.DSFiltros = DSFiltros;
            //f.FiltroActivo = FiltrosActivos;
            //AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);

            
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;

            PintarBoton(Boton.Name);

            AbrirFormDepositoD();

            //var f = new frmDepositoD();
            //f.PantallaPrincipal = this;
            //f.pnlBotones = pnlBotones;
            //f.KeyPreview = true;
            //f.Focus();
            //f.Select();
            //f.DS = DS;
            //f.DSFiltros = DSFiltros;
            //f.FiltroActivo = FiltrosActivos;
            //AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;

            PintarBoton(Boton.Name);

            AbrirFormDepositoE();

            //var f = new frmDepositoE();
            //f.PantallaPrincipal = this;
            //f.pnlBotones = pnlBotones;
            //f.KeyPreview = true;
            //f.Focus();
            //f.Select();
            //f.DS = DS;
            //f.DSFiltros = DSFiltros;
            //f.FiltroActivo = FiltrosActivos;
            //AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;

            PintarBoton(Boton.Name);

            AbrirFormDepositoF();

            //var f = new frmDepositoF();
            //f.PantallaPrincipal = this;
            //f.pnlBotones = pnlBotones;
            //f.KeyPreview = true;
            //f.Focus();
            //f.Select();
            //f.DS = DS;
            //f.DSFiltros = DSFiltros;
            //f.FiltroActivo = FiltrosActivos;
            //AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;

            PintarBoton(Boton.Name);

            AbrirFormDepositoG();

            //var f = new frmDepositoG();
            //f.PantallaPrincipal = this;
            //f.pnlBotones = pnlBotones;
            //f.KeyPreview = true;
            //f.Focus();
            //f.Select();
            //f.DS = DS;
            //f.DSFiltros = DSFiltros;
            //f.FiltroActivo = FiltrosActivos;
            //AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;

            PintarBoton(Boton.Name);

            AbrirFormDepositoH();

            //var f = new frmDepositoH();
            //f.PantallaPrincipal = this;
            //f.pnlBotones = pnlBotones;
            //f.KeyPreview = true;
            //f.Focus();
            //f.Select();
            //f.DS = DS;
            //f.DSFiltros = DSFiltros;
            //f.FiltroActivo = FiltrosActivos;
            //AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;

            PintarBoton(Boton.Name);

            AbrirFormDepositoI();

            //var f = new frmDepositoI();
            //f.PantallaPrincipal = this;
            //f.pnlBotones = pnlBotones;
            //f.KeyPreview = true;
            //f.Focus();
            //f.Select();
            //f.DS = DS;
            //f.DSFiltros = DSFiltros;
            //f.FiltroActivo = FiltrosActivos;
            //AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;

            PintarBoton(Boton.Name);

            AbrirFormDepositoJ();

            //var f = new frmDepositoJ();
            //f.PantallaPrincipal = this;
            //f.pnlBotones = pnlBotones;
            //f.KeyPreview = true;
            //f.Focus();
            //f.Select();
            //f.DS = DS;
            //f.DSFiltros = DSFiltros;
            //f.FiltroActivo = FiltrosActivos;
            //AbrirFormulariosEnPanel.AbrirFormulariosHijosDeposito(f, panel1);

        }

        private void Pruebadepo_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.S)
            //{
                
            //    btnA.Text = "Weeeee";
            //    e.Handled = true;
            //    //MessageBox.Show("AAA");
            //    //MostrarPantallaEspera();

            //    //Task Tarea1 = new Task(LlenarDataSet);
            //    //Tarea1.Start();

            //    //await Tarea1;

            //    //lblTitulo1.Visible = false;
            //    //lblTitulo2.Visible = false;
            //    //lblTitulo3.Visible = false;

            //    //btnA.Visible = true;
            //    //btnB.Visible = true;
            //    //btnC.Visible = true;
            //    //btnD.Visible = true;
            //    //btnE.Visible = true;
            //    //btnF.Visible = true;
            //    //btnG.Visible = true;
            //    //btnH.Visible = true;
            //    //btnI.Visible = true;
            //    //btnJ.Visible = true;

            //    //OcultarPantallaEspera();

            //    //MostrarUltimaSincronizacion();
            //}
        }

        private void Pruebadepo_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.S)
            {
               
                MessageBox.Show("AAA");
                FormPrincipal.Focus();
                FormPrincipal.Select();
                
            }
        }

        private void Pruebadepo_Shown(object sender, EventArgs e)
        {
            this.Select();
            this.Focus();
            
        }
    }
}
