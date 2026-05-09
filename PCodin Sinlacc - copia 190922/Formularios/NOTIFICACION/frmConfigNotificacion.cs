using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Formularios.Notificación
{
    public partial class frmConfigNotificacion : Form
    {
        public frmConfigNotificacion()
        {
            InitializeComponent();
        }
        List<string> Productos = new List<string>();
        private void frmConfigNotificacion_Load(object sender, EventArgs e)
        {
            Productos.Add("22222");
            Productos.Add("33333");

            string Mensaje = "";

           foreach(var item in Productos)
            {
                Mensaje = Mensaje + "\n\r" + item.ToString() + "\n\r";
            }

            textBox1.Text = Mensaje;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var hb = new DBdatos())
            {
                string Consulta = "SELECT * FROM CLIENTES WHERE ID = 55555555555";

                SqlDataAdapter Datos = new SqlDataAdapter(Consulta, (SqlConnection)hb.Database.Connection);
                DataTable dt = new DataTable();
                

               
                
                    Datos.Fill(dt);
                    dataGridView1.DataSource = dt;
                
                    
            }
        }
    }
}
