using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using PCodin_Sinlacc.Clases.Formularios.Ventas.OrdenCarga;
using PCodin_Sinlacc.Datos;
using System.Windows.Documents;
using System.Data.Entity;
using Newtonsoft.Json.Converters;
using static PCodin_Sinlacc.Formularios.TEST;
using Twilio.TwiML.Messaging;
using Twilio.TwiML.Voice;
using System.Data.Entity.Core.Metadata.Edm;
using Microsoft.Office.Interop.Excel;
using QRCoder;
using PCodin_Sinlacc.Clases;
using System.Configuration;
using Microsoft.Vbe.Interop;
using System.Windows;


using MessageBox = System.Windows.Forms.MessageBox;
using Application = System.Windows.Forms.Application;
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.Windows.Media.Media3D;
using System.Windows.Forms.DataVisualization.Charting;

namespace PCodin_Sinlacc.Formularios
{
    public partial class TEST : Form
    {
        public TEST()
        {
            InitializeComponent();
        }
        //IQueryable listData = Enumerable.Empty<PCodin>().AsQueryable();
        IEnumerable<Vista_OrdenCargaAfectar> Consulta;
        object BotonArrastrado;  ///IMPROTANTE
        clsImprimirPlantilla C = new clsImprimirPlantilla();
        public class Productos
       {
            long CodCiudad { get; set; }
            string Ciudad { get; set; }
       }

        //public List<Ciudades> GetAllData(string idUser, string Tipo)
        //{
        //    //if (string.IsNullOrEmpty(idUser)
        //    //    || string.IsNullOrEmpty(Tipo))
        //    //    return null;

        //    //if (Tipo != "P")
        //    //    return null;

        //    //using (var bd = new DBdatos())
        //    //{
        //    //    short iduser = Convert.ToInt16(idUser);

        //    //    var query = (from m in bd.Ciudades                                                        
        //    //                 select new
        //    //                 {
        //    //                     Id = m.ID,
        //    //                     Nombre = m.Descripcion,
                                
        //    //        }).ToList();

        //    //    return query;
        //    //}
        //}
        private void button1_Click(object sender, EventArgs e)
        {

            string Porcentaje = "79%";
            Porcentaje = Porcentaje.Replace("%", "");
            Porcentaje = Porcentaje.Replace(" ", "");
            // Porcentaje = Porcentaje.Replace(",", ".");

            int Numero = Convert.ToInt32(Convert.ToDecimal(Porcentaje));


            circularProgressBar1.Value = Numero;
            circularProgressBar1.Text = "79%";
        }
        private void ComenzarArrastre(object sender , MouseEventArgs e)
        { 
        //{
        //    System.Windows.Forms.Button BotonSeleccionado = (System.Windows.Forms.Button)sender;
        //    BotonSeleccionado.Cursor =  Cursors.
        //    BotonArrastrado = sender;

        //    if(e.Button == MouseButtons.Left)
        //    {
        //        BotonSeleccionado.DoDragDrop(Origen, DragDropEffects.Move);
                    
        //    }
            


        }
        private void PruebaQuery()
        {
            using (var hb = new DBdatos())
            {
                using (var cmd = hb.Database.Connection.CreateCommand())
                {
                    cmd.Connection.Open();
                    cmd.CommandText = "SELECT ID FROM MANTENIMIENTOREGISTRO";
                    var results = cmd.ExecuteReader();

                    foreach(var i in results)
                    {
                        
                    }
                }
            }
              
        }
        private void TEST_Load(object sender, EventArgs e)
        {
            PruebaQuery();
            //var Consulta = Enumerable.Empty<Ciudades>();




            //using (var hb = new DBdatos())
            //{
            //    Consulta = (from C in hb.Vista_OrdenCargaAfectar                         
            //                select C
                            

            //                );





            //    //Consulta =  (from P in hb.Registro_Pedidos
            //    //            join PC in hb.Pedido_Cuerpo on P.ID equals PC.Pedido_ID
            //    //            where
            //    //                 P.Cliente_ID == 22
            //    //                 && PC.Cantidad > 0
            //    //            select P                                                 );


            //    var Resultados = Consulta.ToList();


            //    dgvPedidoProductos.DataSource = Resultados;

            //    colID.DataPropertyName = "Pedido_ID";
            //    colNumeroPedido.DataPropertyName = "Numero_Pedido";
            //    colProductoID.DataPropertyName = "Cod_Producto";
            //    colProductoDescrip.DataPropertyName = "Producto";
            //    colMedida.DataPropertyName = "Medida";
            //    colCantidad.DataPropertyName = "Cantidad_pend";
            //    colCantidadAfec.DataPropertyName = "Cantidad_afec";
            //    colPCID.DataPropertyName = "PedidoCuerpo_ID";

            //    //        P.ID AS[Pedido_ID],
            //    //P.Numero_Pedido AS[Numero Pedido],
            //    //PRO.Codigo AS[Cod Producto],
            //    //PRO.Descripcion AS[Producto],
            //    //MED.Descripcion AS[Medida],
            //    //PC.Cantidad AS[Cantidad pend],
            //    //PC.Cantidad_Entregada AS[Cantidad afec],
            //    //PC.ID AS[PedidoCuerpo_ID]








            //}

                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            



        }

        private void btnAfectar_Click(object sender, EventArgs e)
        {
           


               



            
               
        }

        private void btnAfectados_Click(object sender, EventArgs e)
        {
            


            //long PedidoCuerpoID = (long)dgvPedidoProductos.CurrentRow.Cells["colPCID"].Value;

            //dgvPedidoProductos.CurrentRow.Cells["colCantidad"].Value = 0;

            ////for(int i = 0; i < dgvPedidoProductos.RowCount; i++)
            ////{
            ////    if (Convert.ToInt64(dgvPedidoProductos.Rows[i].Cells["colPCID"].Value) == PedidoCuerpoID)
            ////    {
            ////        dgvPedidoProductos.
            ////    }
            ////}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var hb = new DBdatos())
            {
                var consultaC = (from C in hb.Ciudades
                                 select C).ToList();

                //foreach (var item in consultaC)
                //{
                //    var i = new TT_CIUDAD();

                //    i.Id = item.ID;
                //    i.CODCIUDUAD = item.ID.ToString();
                //    i.NOMBRE = item.Descripcion;

                //    hb.TT_CIUDAD.Add(i);
                //}
                //hb.SaveChanges();

                //dgvPedidoProductos.DataSource = hb.TT_CIUDAD.ToList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var hb = new DBdatos())
            {
                
            }
                
        }

       

      

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            ComenzarArrastre(sender,e);
        }

      
        private void button5_Click(object sender, EventArgs e)
        {
            using (var hb = new DBdatos())
            {
                string Cadena = hb.Database.Connection.ConnectionString;

                SqlConnection Conexion = new SqlConnection(Cadena);
                Conexion.Open();

                SqlCommand Consulta = new SqlCommand(@"SELECT
		SUM(MP.Cantidad * FP.Cantidad) AS KILOS
FROM Existencia_ProductoTerminado AS MP
INNER JOIN Formula_Producto AS FP ON FP.Producto_ID = MP.Produto_ID AND Insumo_ID ='00657'
WHERE MP.Fecha >= (SELECT TOP 1 Fecha FROM MANTENIMIENTOREGISTRO ORDER BY Fecha DESC)
HAVING SUM(MP.Cantidad * MP.Cantidad) >= 10000", Conexion);
                SqlDataReader Registro = Consulta.ExecuteReader();
                if(Registro.Read())
                {
                    txtUser.Text = Registro["KILOS"].ToString();
                }

            }
               
            //string Cadenass = "Data Source=PCODIN\\PCODIN;initial catalog=" + txtDB.Text + ";integrated security=False;user id=sa;password=pcn1971@";
           

        }
        public void ModificarCadena(string Cadena)
        {
            String NuevaCadena = Cadena;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["DBdatos"].ConnectionString = NuevaCadena;
            config.Save(ConfigurationSaveMode.Modified, true);
            Properties.Settings.Default.Save();
            MessageBox.Show("Cadena Modifica");
            Application.Restart();           
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string NuevaCadena = "metadata=res://*/Datos.ModeloDatos.csdl|res://*/Datos.ModeloDatos.ssdl|res://*/Datos.ModeloDatos.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=tcp:" + txtDataSource + ";initial catalog=" + txtDB.Text +";integrated security=False;persist security info=False;user id=" + txtUser.Text + ";password=" + txtPass.Text + ";MultipleActiveResultSets=True;App=EntityFramework&quot;";
            ModificarCadena(NuevaCadena);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                comboBox1.Items.Add(pkInstalledPrinters);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Posición del cursor: " + textBox3.SelectionStart);
        }

        private void btnGenerarCode_Click(object sender, EventArgs e)
        {
            Zen.Barcode.Code128BarcodeDraw generador = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

            pictureBox2.Image = generador.Draw(txtCode.Text, 60);
        }
    }
}
