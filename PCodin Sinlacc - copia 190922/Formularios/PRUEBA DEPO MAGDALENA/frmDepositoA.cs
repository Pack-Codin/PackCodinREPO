using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Clases;
using ImageMagick;
using System.Diagnostics;
using System.IO;
using PCodin_Sinlacc.Formularios.ESTADISTICAS.Informes;
using System.Threading;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;

namespace PCodin_Sinlacc.Formularios.PRUEBA_DEPO_MAGDALENA
{
    public partial class frmDepositoA : Form
    {
        public frmDepositoA()
        {
            InitializeComponent();
        }
        decimal CantidadDepositos = 0;
        decimal CantidadOcupados = 0;

        public bool SeccionA;
        public Pruebadepo PantallaPrincipal;        
        public DataSet1 DS;
        public DataSetFiltros DSFiltros;

        public List<string> ListaProductos = new List<string>();

        frmPantallaEspera PantallaEspera;
        frmPrueba2 FormReporte;

        public bool FiltroActivo;
        public Panel pnlBotones;

        ArrayList ProductoDescripcion = new ArrayList();
        ArrayList ProductoCantidad = new ArrayList();
        ArrayList ColorProducto = new ArrayList();

        //public frmDepositoA FormDepositoA;
        //public frmDepositoB FormDepositoB;
        //public frmDepositoC FormDepositoC;
        //public frmDepositoD FormDepositoD;
        //public frmDepositoE FormDepositoE;
        //public frmDepositoF FormDepositoF;
        //public frmDepositoG FormDepositoG;
        //public frmDepositoH FormDepositoH;
        //public frmDepositoI FormDepositoI;
        //public frmDepositoJ FormDepositoJ;


        private async void frmDepositoA_Load(object sender, EventArgs e)
        {
            //PantallaPrincipal.panel1.AutoScroll = true;

            ////this.HorizontalScroll.Visible = true;

            //PantallaPrincipal.panel1.VerticalScroll.Visible = false;

            //// this.VerticalScroll.Visible = false;

            PantallaPrincipal.panel1.AutoScroll = false;

            PantallaPrincipal.panel1.HorizontalScroll.Value = 20;

            MostraPantallaEspera(ref PantallaEspera, "Actualizando deposito");

            Task Tarea1 = new Task(MostrarSeccionA);
            Tarea1.Start();
            await Tarea1;

            OcultarPantallaEspera(ref PantallaEspera);

            this.Focus();
            this.Select();

        }
        public static void LlenarDataSet(DataSet Data, string Seccion)
        {
           
        }
        private void EliminarFilas()
        {
            foreach (var Control in this.Controls)
            {
                if (Control is DataGridView)
                {
                    if (((DataGridView)Control).RowCount > 0 && ((DataGridView)Control).Name != "dgvLeyenda")
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
        public static void MostrarDatos(DataGridView DGV, DataSet Data, DataSet DataFiltros ,string Seccion, DataGridView DGVLeyenda, List<string> ListaProductos, ref decimal DepositosOcupados ,ref bool FiltroActivo , ArrayList ProductoDescripcion , ArrayList ProductoCantidad , ArrayList ColorProducto , Chart Chart1)
        {
            DGV.DataSource = null;
            CheckForIllegalCrossThreadCalls = false;

            int IND = 0;
            bool IncrementarIndice = false; // Sirve para indicar si indice comienza a crecer.

            var Consulta = (from C in Data.Tables[name: "Deposito"].AsEnumerable()
                            where C.Field<string>("Deposito").StartsWith(Seccion)
                            select C);

            if (FiltroActivo == true)
            {
                Consulta = (from C in DataFiltros.Tables[name: "Deposito"].AsEnumerable()
                            where C.Field<string>("Deposito").StartsWith(Seccion)
                            select C);
            }         
            //if (chkFiltraProducto.Checked)
            //{
            //    Consulta = (from C in Consulta
            //                where C.Field<string>("CodProducto") == cmbFiltraProducto.SelectedValue.ToString()
            //                select C);

            //    HayFiltroActivo = true;
            //}

            //if(HayFiltroActivo == true)
            //{
            //    foreach(var Botones in PnlBotones.Controls)
            //    {
            //        if (Botones is Button)
            //        {
            //            string SeccionBoton = ((Button)Botones).Name.Replace("btn","");
            //            //string SeccionBoton = ((Button)Botones).Name.Remove(0,2);

            //            ConsultaGeneral = (from C in ConsultaGeneral
            //                               where C.Field<string>("CodProducto").Contains(cmbFiltraProducto.SelectedValue.ToString())
            //                                    && C.Field<string>("Seccion") == SeccionBoton
            //                               select C);

            //            var Resultado = ConsultaGeneral.FirstOrDefault();

            //            if(Resultado == null)
            //            {
            //                ((Button)Botones).Visible = false;
            //            }
            //            else
            //            {
            //                ((Button)Botones).Visible = true;
            //            }
                        
            //        }
            //    }
            //}
            //while(bool HayFiltroActivo )
            //foreach(var Control in pnlFiltros.Controls)
            //{
            //    if(Control is CheckBox && ((CheckBox)Control).Checked)
            //    {

            //    }
            //}

            //if (chkFiltraProducto.Checked)
            //    Consulta = (from C in Consulta
            //                where C.Field<string>("SerieLote") == 
            //                select C);

            var Resultados = Consulta.ToList();
           
            foreach(var item in Resultados)
            {

                // podemos crear un nueva variable temporal datatable para poder filtrar 
                if (item["Deposito"].ToString() == DGV.Name)
                {                    
                    DepositosOcupados = DepositosOcupados + 1;

                    if (IncrementarIndice == true)
                        IND = IND + 1;

                    string Columna = "";

                    // ESTA CONDICION SE HACE PORQUE EN LA SECCION D PUSE COMO NOMBRE DE COLUMNA 
                    // D01 , D02 Y SON IGUALES AL NOMBRE DE EL DGV. POR LO TANTO CAMBIO NOMBRE DE
                    // COLUMNA A DE01, DE02
                    if (Seccion != "D")
                        Columna = DGV.Name.Replace(Seccion, "D");
                    else
                        Columna = DGV.Name.Replace(Seccion, "DE");

                    DGV.Rows.Add(item["CodProducto"].ToString());

                    //ProductoDescripcion.Add(item["Producto"]);
                    //ProductoCantidad.Add(Convert.ToDecimal(item["Cantidad"]));

                    if (item["Color"].ToString() != "")
                    {
                        DGV.Rows[IND].DefaultCellStyle.BackColor = Color.FromName(item["Color"].ToString());
                        DGV.Rows[IND].DefaultCellStyle.SelectionBackColor = Color.FromName(item["Color"].ToString());
                        ColorProducto.Add(item["Color"].ToString());
                    }
                    else
                    {
                        DGV.Rows[IND].DefaultCellStyle.BackColor = Color.FromName("White");
                        DGV.Rows[IND].DefaultCellStyle.SelectionBackColor = Color.FromName("White");
                        ColorProducto.Add("Write");
                    }

                    DGV.Rows[IND].DefaultCellStyle.SelectionForeColor = Color.FromName("Black");
                    DGV.Rows[IND].DefaultCellStyle.Font = new Font("Roboto Condensed ", 9 );
                    DGV.Rows[IND].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DGV.Columns[columnName: Columna].Width = 75;
                    DGV.RowTemplate.Height = 22;
                    DGV.ReadOnly = true;
                    DGV.AllowUserToResizeRows = false;
                    
                    if (IND == 0)
                    {
                        IncrementarIndice = true;
                    }

                    if (Convert.ToInt32(item["Cantidad"]) == 1)
                        DGV.Size = new Size(75, 22);
                    if (Convert.ToInt32(item["Cantidad"]) == 2)
                        DGV.Size = new Size(75, 44);
                    if (Convert.ToInt32(item["Cantidad"]) == 3)
                        DGV.Size = new Size(75, 66);
                    if (Convert.ToInt32(item["Cantidad"]) == 4)
                        DGV.Size = new Size(75, 88);
                    if (Convert.ToInt32(item["Cantidad"]) == 5)
                        DGV.Size = new Size(75, 110);
                    if (Convert.ToInt32(item["Cantidad"]) == 6)
                        DGV.Size = new Size(75, 132);

                    
                }

            }

           
            //Chart1.Series[0].LabelForeColor = Color.FromName("Red");
        }
        private void FormatearCeldas(DataGridView DGV, string NombreColumna, DataGridViewCellFormattingEventArgs e)
        {
            //if (DGV.RowCount > 0)
            //{
            //    if (DGV.Columns[e.ColumnIndex].Name == "NombreColumna")
            //    {
            //        var Consulta = (from D in DS.Tables["Deposito"].AsEnumerable()
            //                        where D.Field<string>("Deposito") == DGV.Name
            //                        select D).FirstOrDefault();


            //        e.CellStyle.ForeColor = Color.Black;
            //        e.CellStyle.SelectionForeColor = Color.Black;
            //        e.CellStyle.BackColor = Color.FromName(Consulta.Field<string>("Color"));
            //        //foreach(var item in DGV.Columns)
            //        //{

            //        //}



            //        //if (e.Value.ToString() == "Entregado")
            //        //{
            //        //    e.CellStyle.ForeColor = Color.DarkGreen;
            //        //    e.CellStyle.SelectionForeColor = Color.Green;
            //        //    e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            //        //}
            //        //else
            //        //{
            //        //    e.CellStyle.ForeColor = Color.Red;
            //        //    e.CellStyle.SelectionForeColor = Color.Red;
            //        //    e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            //        //}
            //    }
            //}
        }
        public static void ImprimirDeposito(Pruebadepo PantallaPrincipal , PictureBox picPreImagen)
        {
            try
            {
                //CheckForIllegalCrossThreadCalls = false;

                var f = new frmReporte();

                Bitmap BitCaptura = new Bitmap(PantallaPrincipal.panel1.Width, 600, PixelFormat.Format32bppArgb);

                Rectangle Rectagunlo = Screen.AllScreens[0].Bounds;

                Graphics Captura = Graphics.FromImage(BitCaptura);

                Captura.CopyFromScreen(0, 120, 0, 0, Rectagunlo.Size);

                //SaveFileDialog RutaGuardado = new SaveFileDialog();

                //if (RutaGuardado.ShowDialog() == DialogResult.OK)
                //{
                //BitCaptura.Save(RutaGuardado.FileName + ".png", ImageFormat.Png);

                //string PDF = RutaGuardado.FileName + ".pdf";

                picPreImagen.Image = BitCaptura;

                //using (MagickImageCollection Colleccion = new MagickImageCollection())
                //{
                //    //Colleccion.Add(RutaGuardado.FileName + ".png");
                //    //Colleccion.Write(PDF);
                //    //Process.Start(PDF);


                //}

                // }

                //FormReporte = new frmPrueba2();
                //FormReporte.Show();


                // clsQueryInformes.rptDeposito(FormReporte, pictureBox20);

                clsQueryInformes.rptDeposito(f, picPreImagen);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
       
        public  static void KPIPorcentajeOcupacion(string Seccion , ref decimal CantidadDepositos , ref decimal CantidadOcupados , Label lblPorcentaje,Label lblLibres , Label lblOcupados , CircularProgressBar.CircularProgressBar Circular)
        {
            decimal PorcentajeOcupacion = 0;
            CantidadDepositos = 0;

            using (var hb = new DBdatos2())
            {
                //var ConsultaCantidad = (from D in hb.DEPOSITO
                //                        join DC in hb.DEPOSITOCAPACIDAD on D.DepositoCapacidad equals DC.IDTabla
                //                        where D.Descripcion.StartsWith(Seccion)                                
                //                        select new
                //                        {
                //                            CantidadDepositos = DC.Cantidad

                //                        }).ToList();

                //if(ConsultaCantidad.Count > 0)
                //{
                //    foreach(var item in ConsultaCantidad)
                //    {
                //        CantidadDepositos = (decimal)(CantidadDepositos + item.CantidadDepositos);
                //    }
                //}
                //PorcentajeOcupacion = (CantidadOcupados * 100) / CantidadDepositos;

                //lblPorcentaje.Text = PorcentajeOcupacion.ToString("N2") + " " + "%";
                //lblLibres.Text = (CantidadDepositos - CantidadOcupados).ToString();
                //lblOcupados.Text = CantidadOcupados.ToString();

                //string Porcentaje = lblPorcentaje.Text;
                //Porcentaje = Porcentaje.Replace("%", "");
                //Porcentaje = Porcentaje.Replace(" ", "");

                //int Numero = Convert.ToInt32(Convert.ToDecimal(Porcentaje));

                //Circular.Value = 100;
                //Circular.Value = Numero;
                //Circular.Text = lblPorcentaje.Text;

                //if (Numero <= 25)
                //{
                //    Circular.ProgressColor = Color.FromName("Green");
                //    Circular.ForeColor = Color.FromName("Green");
                //}
                //if (Numero >= 25 && Numero <= 50)
                //{
                //    Circular.ProgressColor = Color.FromName("Goldenrod");
                //    Circular.ForeColor = Color.FromName("Goldenrod");
                //}
                //if (Numero >= 50 && Numero <= 75)
                //{
                //    Circular.ProgressColor = Color.FromName("DarkOrange");
                //    Circular.ForeColor = Color.FromName("DarkOrange");
                //}
                //if (Numero >= 75 && Numero <= 100)
                //{
                //    Circular.ProgressColor = Color.FromName("Crimson");
                //    Circular.ForeColor = Color.FromName("Crimson");
                //}
            }
        }
        public static void MostrarLeyenda(DataSet Data , DataGridView DGV ,Label Seccíon , DataGridViewColumn colColor , DataGridViewColumn colCodigo, DataGridViewColumn colProducto, DataGridViewColumn colCantidad , ArrayList ProductoDescricion , ArrayList ProductoCantidad , Chart Chart1)
        {         
            List<int> ListaCodDepositos = new List<int>();

            //ACA SE GUARDAN LOS IDTABLA DE LOS DEPOSITOS POR SECCION. SIRVE PARA FILTRAR
            if (Seccíon.Text == "A")
            {
                ListaCodDepositos.Add(36);
                ListaCodDepositos.Add(37);
                ListaCodDepositos.Add(38);
                ListaCodDepositos.Add(39);
                ListaCodDepositos.Add(40);
                ListaCodDepositos.Add(41);
                ListaCodDepositos.Add(42);
                ListaCodDepositos.Add(43);
                ListaCodDepositos.Add(44);
                ListaCodDepositos.Add(45);
                ListaCodDepositos.Add(46);
                ListaCodDepositos.Add(47);
                ListaCodDepositos.Add(48);
                ListaCodDepositos.Add(49);
                ListaCodDepositos.Add(50);
                ListaCodDepositos.Add(51);
                ListaCodDepositos.Add(52);
                ListaCodDepositos.Add(53);
                ListaCodDepositos.Add(54);
                ListaCodDepositos.Add(55);
                ListaCodDepositos.Add(56);
                ListaCodDepositos.Add(57);
                ListaCodDepositos.Add(58);
                ListaCodDepositos.Add(59);
                ListaCodDepositos.Add(60);
                ListaCodDepositos.Add(61);
                ListaCodDepositos.Add(62);
                ListaCodDepositos.Add(63);
                ListaCodDepositos.Add(64);
                ListaCodDepositos.Add(124);
                ListaCodDepositos.Add(129);
                ListaCodDepositos.Add(130);
                ListaCodDepositos.Add(131);
                ListaCodDepositos.Add(132);
                ListaCodDepositos.Add(133);
                ListaCodDepositos.Add(123);
            }
            if (Seccíon.Text == "B")
            {
                ListaCodDepositos.Add(65);
                ListaCodDepositos.Add(66);
                ListaCodDepositos.Add(67);
                ListaCodDepositos.Add(68);
                ListaCodDepositos.Add(69);
                ListaCodDepositos.Add(70);
                ListaCodDepositos.Add(71);
                ListaCodDepositos.Add(72);
                ListaCodDepositos.Add(73);
                ListaCodDepositos.Add(74);
                ListaCodDepositos.Add(75);
                ListaCodDepositos.Add(76);
                ListaCodDepositos.Add(77);
                ListaCodDepositos.Add(78);
                ListaCodDepositos.Add(79);
                ListaCodDepositos.Add(80);
                ListaCodDepositos.Add(81);
                ListaCodDepositos.Add(82);
                ListaCodDepositos.Add(83);
                ListaCodDepositos.Add(84);
                ListaCodDepositos.Add(85);
                ListaCodDepositos.Add(86);
                ListaCodDepositos.Add(87);
                ListaCodDepositos.Add(88);
                ListaCodDepositos.Add(89);
                ListaCodDepositos.Add(90);
                ListaCodDepositos.Add(91);
                ListaCodDepositos.Add(92);
                ListaCodDepositos.Add(93);
                ListaCodDepositos.Add(125);
                ListaCodDepositos.Add(134);
                ListaCodDepositos.Add(135);
                ListaCodDepositos.Add(136);
                ListaCodDepositos.Add(137);
                ListaCodDepositos.Add(138);
                ListaCodDepositos.Add(128);
            }
            if (Seccíon.Text == "C")
            {
                ListaCodDepositos.Add(139);
                ListaCodDepositos.Add(140);
                ListaCodDepositos.Add(141);
                ListaCodDepositos.Add(142);
                ListaCodDepositos.Add(143);
                ListaCodDepositos.Add(144);
                ListaCodDepositos.Add(145);
                ListaCodDepositos.Add(146);
                ListaCodDepositos.Add(147);
                ListaCodDepositos.Add(148);
                ListaCodDepositos.Add(149);
                ListaCodDepositos.Add(150);
                ListaCodDepositos.Add(151);
                ListaCodDepositos.Add(152);
                ListaCodDepositos.Add(153);
                ListaCodDepositos.Add(154);
                ListaCodDepositos.Add(155);
                ListaCodDepositos.Add(156);
                ListaCodDepositos.Add(157);
                ListaCodDepositos.Add(158);
                ListaCodDepositos.Add(159);
                ListaCodDepositos.Add(160);
                ListaCodDepositos.Add(161);
                ListaCodDepositos.Add(162);
                ListaCodDepositos.Add(273);
            }
            if (Seccíon.Text == "D")
            {
                ListaCodDepositos.Add(163);
                ListaCodDepositos.Add(164);
                ListaCodDepositos.Add(165);
                ListaCodDepositos.Add(166);
                ListaCodDepositos.Add(167);
                ListaCodDepositos.Add(168);
                ListaCodDepositos.Add(169);
                ListaCodDepositos.Add(170);
                ListaCodDepositos.Add(171);
                ListaCodDepositos.Add(172);
                ListaCodDepositos.Add(173);
                ListaCodDepositos.Add(174);
                ListaCodDepositos.Add(175);
                ListaCodDepositos.Add(176);
                ListaCodDepositos.Add(177);
                ListaCodDepositos.Add(178);
                ListaCodDepositos.Add(179);
                ListaCodDepositos.Add(180);
                ListaCodDepositos.Add(181);
                ListaCodDepositos.Add(182);
                ListaCodDepositos.Add(183);
                ListaCodDepositos.Add(184);
                ListaCodDepositos.Add(185);
                ListaCodDepositos.Add(186);
                ListaCodDepositos.Add(274);
            }
            if (Seccíon.Text == "E")
            {
                ListaCodDepositos.Add(260);
                ListaCodDepositos.Add(261);
                ListaCodDepositos.Add(262);
                ListaCodDepositos.Add(263);
                ListaCodDepositos.Add(264);
                ListaCodDepositos.Add(265);
                ListaCodDepositos.Add(266);
                ListaCodDepositos.Add(267);
                ListaCodDepositos.Add(268);
                ListaCodDepositos.Add(269);
                ListaCodDepositos.Add(270);
                ListaCodDepositos.Add(271);
                ListaCodDepositos.Add(289);
            }
            if (Seccíon.Text == "F")
            {
                ListaCodDepositos.Add(200);
                ListaCodDepositos.Add(201);
                ListaCodDepositos.Add(202);
                ListaCodDepositos.Add(203);
                ListaCodDepositos.Add(204);
                ListaCodDepositos.Add(205);
                ListaCodDepositos.Add(206);
                ListaCodDepositos.Add(207);
                ListaCodDepositos.Add(208);
                ListaCodDepositos.Add(209);
                ListaCodDepositos.Add(210);
                ListaCodDepositos.Add(211);
                ListaCodDepositos.Add(212);
                ListaCodDepositos.Add(213);
                ListaCodDepositos.Add(214);
                ListaCodDepositos.Add(215);
                ListaCodDepositos.Add(216);
                ListaCodDepositos.Add(291);
                ListaCodDepositos.Add(295);
            }
            if (Seccíon.Text == "G")
            {
                ListaCodDepositos.Add(297);
                ListaCodDepositos.Add(217);
                ListaCodDepositos.Add(218);
                ListaCodDepositos.Add(219);
                ListaCodDepositos.Add(220);
                ListaCodDepositos.Add(221);
                ListaCodDepositos.Add(222);
                ListaCodDepositos.Add(223);
                ListaCodDepositos.Add(224);
                ListaCodDepositos.Add(225);
                ListaCodDepositos.Add(226);
                ListaCodDepositos.Add(227);
                ListaCodDepositos.Add(228);
                ListaCodDepositos.Add(229);
                ListaCodDepositos.Add(230);
                ListaCodDepositos.Add(231);
                ListaCodDepositos.Add(281);
                ListaCodDepositos.Add(282);
                ListaCodDepositos.Add(283);
                ListaCodDepositos.Add(284);
                ListaCodDepositos.Add(285);
                ListaCodDepositos.Add(286);
            }
            if (Seccíon.Text == "H")
            {
                ListaCodDepositos.Add(296);
                ListaCodDepositos.Add(232);
                ListaCodDepositos.Add(233);
                ListaCodDepositos.Add(234);
                ListaCodDepositos.Add(235);
                ListaCodDepositos.Add(236);
                ListaCodDepositos.Add(237);
                ListaCodDepositos.Add(238);
                ListaCodDepositos.Add(239);
                ListaCodDepositos.Add(240);
                ListaCodDepositos.Add(241);
                ListaCodDepositos.Add(242);
                ListaCodDepositos.Add(243);
                ListaCodDepositos.Add(244);
                ListaCodDepositos.Add(245);
                ListaCodDepositos.Add(246);
                ListaCodDepositos.Add(275);
                ListaCodDepositos.Add(276);
                ListaCodDepositos.Add(277);
                ListaCodDepositos.Add(278);
                ListaCodDepositos.Add(287);
                ListaCodDepositos.Add(288);
            }
            if (Seccíon.Text == "I")
            {
                ListaCodDepositos.Add(298);
                ListaCodDepositos.Add(247);
                ListaCodDepositos.Add(248);
                ListaCodDepositos.Add(249);
                ListaCodDepositos.Add(250);
                ListaCodDepositos.Add(251);
                ListaCodDepositos.Add(252);
                ListaCodDepositos.Add(253);
                ListaCodDepositos.Add(254);
                ListaCodDepositos.Add(255);
                ListaCodDepositos.Add(256);
                ListaCodDepositos.Add(257);
                ListaCodDepositos.Add(258);
                ListaCodDepositos.Add(259);
                ListaCodDepositos.Add(293);
            }
            if (Seccíon.Text == "J")
            {
                ListaCodDepositos.Add(299);
                ListaCodDepositos.Add(187);
                ListaCodDepositos.Add(188);
                ListaCodDepositos.Add(189);
                ListaCodDepositos.Add(190);
                ListaCodDepositos.Add(191);
                ListaCodDepositos.Add(192);
                ListaCodDepositos.Add(193);
                ListaCodDepositos.Add(194);
                ListaCodDepositos.Add(195);
                ListaCodDepositos.Add(196);
                ListaCodDepositos.Add(197);
                ListaCodDepositos.Add(198);
                ListaCodDepositos.Add(199);
                ListaCodDepositos.Add(272);
            }

            var Consulta = (from L in Data.Tables["Deposito"].AsEnumerable()
                            where ListaCodDepositos.Contains(L.Field<int>("CodDeposito"))
                            orderby L.Field<string>("Producto")
                            group L by new
                            {
                                CodigoProducto = L.Field<string>("CodProducto"),
                                Producto = L.Field<string>("Producto"),
                                Color = L.Field<string>("Color")
                            
                            } into Grupo 
                            select new
                            {
                                Grupo.Key.Color,
                                Grupo.Key.CodigoProducto,
                                Grupo.Key.Producto,
                                Cantidad = Grupo.Count()
                            });
          
            var Resultados = Consulta.ToList();
            var ResultadosUnicos = Consulta.FirstOrDefault();

            colColor.DataPropertyName = "Color";
            colCodigo.DataPropertyName = "CodigoProducto";
            colProducto.DataPropertyName = "Producto";
            colCantidad.DataPropertyName = "Cantidad";

            DGV.DataSource = Resultados;

            foreach(var item in Resultados)
            {
                ProductoDescricion.Add(item.Producto);
                ProductoCantidad.Add(item.Cantidad);
            }
            Chart1.Series[0].Points.DataBindXY(ProductoDescricion, ProductoCantidad );
           
            foreach(var item2 in Chart1.Series[0].Points)
            {
                var ConsultaColor = (from C in Consulta
                                     where C.Producto == item2.AxisLabel.ToString()
                                     select C).FirstOrDefault();

                if(ConsultaColor != null)
                {
                    item2.Color = Color.FromName(ConsultaColor.Color);
                }
                else
                {
                    item2.Color = Color.FromName("Write");
                }              
            }
            
           




        }
        public static void DefinirSiHayFiltroActivo(Panel pnlFiltros , ref bool HayFiltroActivo)
        {
            foreach (var Control in pnlFiltros.Controls)
            {
                if(Control is CheckBox)
                {
                    if (((CheckBox)Control).Checked == true)
                        HayFiltroActivo = true;
                    else
                        HayFiltroActivo = false;
                }
            }
        }
        private void MostrarSeccionA()
        {
            using (var hb = new DBdatos2())
            {
                

                CantidadOcupados = 0;
                CheckForIllegalCrossThreadCalls = false;
                //Ajusta pantalla
                PantallaPrincipal.panel1.AutoScroll = false;
                PantallaPrincipal.panel1.HorizontalScroll.Value = 20;

                EliminarFilas();

                //if (FiltroActivo == true)
                //    MostrarLeyenda(DSFiltros, dgvLeyenda, lblSeccion, colColor, colCodigo, colProducto, colCantidad);
                //else
                //    MostrarLeyenda(DS, dgvLeyenda, lblSeccion, colColor, colCodigo, colProducto, colCantidad);


                //var Consulta = (from L in DS.Tables["DepositoCantidad"].AsEnumerable()
                //                where L.Field<string>("Deposito").StartsWith(lblSeccion.Text)
                //                group L by new
                //                {
                //                    CodigoProducto = L.Field<string>("Codigo"),
                //                    Producto = L.Field<string>("Producto"),
                //                    Color = L.Field<string>("Color")
                //                } into Grupo
                //                select new
                //                {
                //                    Grupo.Key.Color,
                //                    Grupo.Key.CodigoProducto,
                //                    Grupo.Key.Producto,
                //                    Cantidad = Grupo.Count()
                //                });

                //if (chkFiltraProducto.Checked)
                //    Consulta = (from C in Consulta
                //                where C.Producto == cmbFiltraProducto.SelectedValue.ToString()
                //                select C);

                //var Resultados = Consulta.ToList();

                //colColor.DataPropertyName = "Color";
                //colCodigo.DataPropertyName = "CodigoProducto";
                //colProducto.DataPropertyName = "Producto";
                //colCantidad.DataPropertyName = "Cantidad";

                //dgvLeyenda.DataSource = Resultados;


                MostrarDatos(A02, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A03, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A04, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A05, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A06, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A07, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A08, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A09, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A10, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A11, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A12, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A13, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A14, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A15, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A16, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A17, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A18, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A19, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A20, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A21, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A22, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A23, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A24, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A25, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A28, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A29, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A30, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A31, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A32, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);
                MostrarDatos(A33, DS,DSFiltros, "A", dgvLeyenda, ListaProductos, ref CantidadOcupados, ref FiltroActivo,ProductoDescripcion,ProductoCantidad,ColorProducto,chart1);

                if (FiltroActivo == true)
                {
                    MostrarLeyenda(DSFiltros, dgvLeyenda, lblSeccion, colColor, colCodigo, colProducto, colCantidad , ProductoDescripcion , ProductoCantidad , chart1);

                    lblLibres.Text = "0,00";
                    lblOcupados.Text = "0,00";
                    lblPorcentaje.Text = "0,00 %";
                }
                else
                {
                    MostrarLeyenda(DS, dgvLeyenda, lblSeccion, colColor, colCodigo, colProducto, colCantidad , ProductoDescripcion, ProductoCantidad , chart1);
                    KPIPorcentajeOcupacion(lblSeccion.Text, ref CantidadDepositos, ref CantidadOcupados, lblPorcentaje, lblLibres, lblOcupados , circularProgressBar1);
                }

               

               

                //if (FiltroActivo == true)
                //{
                //    lblLibres.Text = "0,00";
                //    lblOcupados.Text = "0,00";
                //    lblPorcentaje.Text = "0,00 %";
                //}
                //else
                //{
                //    KPIPorcentajeOcupacion(lblSeccion.Text, ref CantidadDepositos, ref CantidadOcupados, lblPorcentaje, lblLibres, lblOcupados);
                //}

                //PantallaPrincipal.SeccionA = true;
                //PantallaPrincipal.FormulariaSeccionA = this;

                //if (HayFiltroActivo == true)
                //{
                //    var ConsultaGeneral = (from C in DSFiltros.Tables["Deposito"].AsEnumerable()
                //                           where C.Field<string>("CodProducto").Contains(cmbFiltraProducto.SelectedValue.ToString())                                                
                //                           select C).ToList();

                //    foreach (var Botones in pnlBotones.Controls)
                //    {                       
                //        if (Botones is Button)
                //        {
                //            string SeccionBoton = ((Button)Botones).Name.Replace("btn", "");

                //            var NuevaConsulta = (from C in DSFiltros.Tables["Deposito"].AsEnumerable()
                //                                 where C.Field<string>("CodProducto").Contains(cmbFiltraProducto.SelectedValue.ToString())
                //                                      && C.Field<string>("Seccion") == SeccionBoton
                //                                 select C).ToList();

                //            if (NuevaConsulta.Count > 0)
                //                ((Button)Botones).Visible = true;
                //            else
                //                ((Button)Botones).Visible = false;
                //        }
                //    }
                //    if (ConsultaGeneral.Count > 0)
                //    {
                //        var NewDataset = new DataSet1();

                //        foreach(var item in ConsultaGeneral)
                //        {
                //            NewDataset.Tables[name: "Deposito"].Rows.Add
                //                (new object[] {

                //                    item.Field<string>("Deposito"),
                //                    item.Field<string>("CodProducto"),
                //                    item.Field<string>("Cantidad"),
                //                    item.Field<string>("Color"),
                //                    item.Field<string>("Producto"),
                //                    item.Field<string>("Calidad"),
                //                    item.Field<string>("SerieLote"),
                //                    item.Field<string>("CentroOperativo"),
                //                    item.Field<string>("Seccion")
                //                });
                //        }
                //        PantallaPrincipal.DS = NewDataset;
                //    }                  
                //}
                //else
                //{
                //    foreach (var Botones in pnlBotones.Controls)
                //    {
                //        if (Botones is Button)
                //        {
                //            ((Button)Botones).Visible = true;

                //        }
                //    }
                //   // PantallaPrincipal.DS = DS;
                //}
            }
        }
        public static void MostraPantallaEspera(ref frmPantallaEspera PantallaEspera,string Mensaje)
        {
            PantallaEspera = new frmPantallaEspera();
            PantallaEspera.textBox1.Text = Mensaje;
            PantallaEspera.Show();            
        }
        public static void OcultarPantallaEspera(ref frmPantallaEspera PantallaEspera)
        {    
            if(PantallaEspera != null)
                PantallaEspera.Hide();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirDeposito(PantallaPrincipal, picPreImagen);
            //var f = new frmReporte();
            //// OcultarPantallaEspera();
            //Task Tarea1 = new Task(ImprimirDeposito);
            //Tarea1.Start();
            //await Tarea1;

           //clsQueryInformes.rptDeposito(f, picPreImagen);                    
        }
        public static void FormatearCeldas(DataGridView DGV,DataGridViewCellFormattingEventArgs e)
        {
            if (DGV.RowCount > 0)
            {
                DGV.AllowUserToResizeColumns = false;
                DGV.ReadOnly = true;

                if (DGV.Columns[e.ColumnIndex].Name == "colColor")
                {
                    if (e.Value.ToString() == "")
                    {
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.SelectionForeColor = Color.Gray;
                        e.CellStyle.SelectionBackColor = Color.Gray;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.FromName(e.Value.ToString());
                        e.CellStyle.BackColor = Color.FromName(e.Value.ToString());
                        e.CellStyle.SelectionForeColor = Color.FromName(e.Value.ToString());
                        e.CellStyle.SelectionBackColor = Color.FromName(e.Value.ToString());
                        e.Value = "";
                    }
                }
                if (DGV.Columns[e.ColumnIndex].Name == "colProducto" || DGV.Columns[e.ColumnIndex].Name == "colCodigo")
                {
                    e.CellStyle.BackColor = Color.FromArgb(64, 64, 64);
                    e.CellStyle.SelectionForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.Teal;
                    e.CellStyle.Font = new Font("Roboto", 9, FontStyle.Regular);
                    e.CellStyle.ForeColor = Color.White;
                }
                
                if (DGV.Columns[e.ColumnIndex].Name == "colCantidad")
                {
                    e.CellStyle.BackColor = Color.FromArgb(64, 64, 64);
                    e.CellStyle.SelectionForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.Teal;
                    e.CellStyle.Font = new Font("Roboto Condensed", 9 , FontStyle.Bold);
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }
        private void dgvLeyenda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(dgvLeyenda,e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.HorizontalScroll.Visible = false;
            this.HorizontalScroll.Value = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

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
        public static void AbrirDetalle(DataSet1 DS , object sender , DataGridViewCellEventArgs e )
        {
            var DGV = sender as DataGridView;

           //string Deposito = DGV.Name;

            var f = new frmVisorDepo();
            f.Deposito = DGV.Name;
            f.DS = DS;
            f.ShowDialog();           
        }
        private void A02_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
            //var DGV = sender as DataGridView;

            //string Deposito = DGV.Name;
            //AbrirDetalle(Deposito , DS);
        }

        private void A03_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var DGV = sender as DataGridView;

            FormatearCeldas(DGV, "D03", e);
        }

        private void frmDepositoA_KeyDown(object sender ,KeyEventArgs e)
        {
            AbrirFormSegunLetraPresiona(e,PantallaPrincipal,dgvLeyenda, picPreImagen);
        }

        private void frmDepositoA_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private void A03_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A04_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A05_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A06_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A07_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A08_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A09_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A11_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A12_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A13_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A14_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A15_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A16_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A17_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A18_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A19_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A20_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A21_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A22_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A23_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A24_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A25_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A26_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A27_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A28_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A29_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A30_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A31_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A32_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A33_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A34_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A35_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A36_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        private void A07_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirDetalle(DS, sender, e);
        }

        ArrayList Productos = new ArrayList();
        ArrayList Cantidad = new ArrayList();

        private void button1_Click(object sender, EventArgs e)
        {
            string Porcentaje = lblPorcentaje.Text;
            Porcentaje = Porcentaje.Replace("%", "");
            Porcentaje = Porcentaje.Replace(" ", "");
           // Porcentaje = Porcentaje.Replace(",", ".");

            int Numero = Convert.ToInt32(Convert.ToDecimal(Porcentaje));
       

            circularProgressBar1.Value = Numero;
            circularProgressBar1.Text = lblPorcentaje.Text;
        //    using (var hb = new DBdatos())
        //    {
        //        var Consulta = (from PRO in hb.Existencia_ProductoTerminado
        //                        select PRO);

            //        var Resultado = Consulta.ToList();


            //        foreach(var item in DS.Deposito)
            //        {
            //            //Productos.Add(item.Productos_Insumos.Descripcion);
            //            //Cantidad.Add(item.Cantidad);
            //        }

            //        chart1.Series[0].Points.DataBindXY(Productos, Cantidad);
            //        chart1.Series[0].Color = Color.FromName("Red");
            //    }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        public static void AbrirFormSegunLetraPresiona(KeyEventArgs B , Pruebadepo PantallaPrincipal , DataGridView DgvLeyenda , PictureBox picPreImagen)
        {
            if (B.KeyCode == Keys.A)
            {
                PantallaPrincipal.PintarBoton("btnA");
                PantallaPrincipal.AbrirFormDepositoA();
            }
            if (B.KeyCode == Keys.B)
            {
                PantallaPrincipal.PintarBoton("btnB");
                PantallaPrincipal.AbrirFormDepositoB();
            }
            if (B.KeyCode == Keys.C)
            {
                PantallaPrincipal.PintarBoton("btnC");
                PantallaPrincipal.AbrirFormDepositoC();
            }
            if (B.KeyCode == Keys.D)
            {
                PantallaPrincipal.PintarBoton("btnD");
                PantallaPrincipal.AbrirFormDepositoD();
            }
            if (B.KeyCode == Keys.E)
            {
                PantallaPrincipal.PintarBoton("btnE");
                PantallaPrincipal.AbrirFormDepositoE();
            }
            if (B.KeyCode == Keys.F)
            {
                PantallaPrincipal.PintarBoton("btnF");
                PantallaPrincipal.AbrirFormDepositoF();
            }
            if (B.KeyCode == Keys.G)
            {
                PantallaPrincipal.PintarBoton("btnG");
                PantallaPrincipal.AbrirFormDepositoG();
            }
            if (B.KeyCode == Keys.H)
            {
                PantallaPrincipal.PintarBoton("btnH");
                PantallaPrincipal.AbrirFormDepositoH();
            }
            if (B.KeyCode == Keys.I)
            {
                PantallaPrincipal.PintarBoton("btnI");
                PantallaPrincipal.AbrirFormDepositoI();
            }
            if (B.KeyCode == Keys.J)
            {
                PantallaPrincipal.PintarBoton("btnJ");
                PantallaPrincipal.AbrirFormDepositoJ();
            }
            if (Convert.ToInt32(B.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.P))
            //if (B.KeyCode == (Keys.Control | Keys.P))
            {
                ImprimirDeposito(PantallaPrincipal, picPreImagen);               
            }

            DgvLeyenda.Select();
            DgvLeyenda.Focus();

        }
        public static void AbrirFormSegunLetraPresionaFiltros(string SeccionActiva , Pruebadepo PantallaPrincipal)
        {
            if (SeccionActiva == "A")
            {
                PantallaPrincipal.PintarBoton("btnA");
                PantallaPrincipal.AbrirFormDepositoA();
            }
            if (SeccionActiva == "B")
            {
                PantallaPrincipal.PintarBoton("btnB");
                PantallaPrincipal.AbrirFormDepositoB();
            }
            if (SeccionActiva == "C")
            {
                PantallaPrincipal.PintarBoton("btnC");
                PantallaPrincipal.AbrirFormDepositoC();
            }
            if (SeccionActiva == "D")
            {
                PantallaPrincipal.PintarBoton("btnD");
                PantallaPrincipal.AbrirFormDepositoD();
            }
        }

        private void dgvLeyenda_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(dgvLeyenda,e);
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
