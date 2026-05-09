using PCodin_Sinlacc.Datos;
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
namespace PCodin_Sinlacc.Formularios.Menu
{
    public partial class frmLicencia : Form
    {
        public frmLicencia()
        {
            InitializeComponent();
        }

        private void pnlLicencia_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ModificarLicencia()
        {
            //using (var hb = new DBdatos())
            //{
            //    var Consulta = (from L in hb.Licencia
            //                    select L).FirstOrDefault();

            //    if (Consulta == null)
            //    {
            //        var i = new Licencia();

            //        i.FechaVencimientoLicencia = dtpFechaVenc.Value.Date;
            //        hb.Licencia.Add(i);
            //    }
            //    else
            //    {
            //        Consulta.FechaVencimientoLicencia = dtpFechaVenc.Value.Date;
            //    }
            //    hb.SaveChanges();
            //    MessageBox.Show("Licencia modificada correctamente", "Atención");
            //}
        }
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                try
                {
                    var Consulta = (from L in hb.Licencia
                                    select L).FirstOrDefault();

                    var ConsultaCliente = (from C in hb.Clientes
                                           where C.Cliente_Usuario == true
                                           select C).FirstOrDefault();

                    if (Consulta != null && ConsultaCliente != null)
                    {
                        dgvMercaderia.Rows.Clear();

                        string Estado;
                        if (DateTime.Now.Date < Consulta.FechaVencimientoLicencia)
                            Estado = "Activa";
                        else
                            Estado = "Inactiva";

                        dgvMercaderia.Rows.Add(ConsultaCliente.ID,
                                               ConsultaCliente.Descripcion,
                                               Consulta.FechaVencimientoLicencia,
                                               Estado);
                     
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error");
                    throw;
                }
               
            }
        }
        private void FormatearGrilla(DataGridViewCellFormattingEventArgs e)
        {
            if(dgvMercaderia.RowCount > 0)
            {
                if (this.dgvMercaderia.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if(e.Value.ToString() == "Activa")
                    {
                        e.CellStyle.ForeColor = Color.ForestGreen;
                        e.CellStyle.SelectionForeColor = Color.ForestGreen;
                    }
                    if (e.Value.ToString() == "Inactiva")
                    {
                        e.CellStyle.ForeColor = Color.Maroon;
                        e.CellStyle.SelectionForeColor = Color.Maroon;
                    }
                }
            }
            
        }
        private async void RenovarConsultaLicencia()
        {
            try
            {
                int ID_Usuario = 0;
                using (var hb = new DBdatos())
                {
                    var ConsutaCliente = (from C in hb.Clientes
                                          where C.Cliente_Usuario == true
                                          select C).FirstOrDefault();

                    if (ConsutaCliente != null)
                        ID_Usuario = (int)ConsutaCliente.ID_Licencia;
                }

                string Cadena = "Server=PCODIN\\PCODIN;Database=AUDITHOR;User Id=sa;Password=pcn1971@;";
                string Consulta = "SELECT FechaLicenciaHasta FROM CLIENTE WHERE ID = " + ID_Usuario.ToString();
                DateTime FechaLicencia = DateTime.MinValue;

                SqlConnection Conexion = new SqlConnection(Cadena);
                Conexion.Open();

                //HACE LA CONSULTA
                SqlCommand Consultar = new SqlCommand(Consulta, Conexion);
                SqlDataReader Registro = Consultar.ExecuteReader();

                while (Registro.Read())
                {
                    FechaLicencia = Convert.ToDateTime(Registro["FechaLicenciaHasta"]).Date;
                }

                using (var hb = new DBdatos())
                {
                    var ConsultaLicencia = (from C in hb.Licencia
                                            select C).FirstOrDefault();

                    ConsultaLicencia.FechaVencimientoLicencia = FechaLicencia;
                    hb.SaveChanges();
                    MessageBox.Show("Licencia habilitada hasta " + FechaLicencia.ToShortDateString());
                    InicializarForm();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }


            ////pnlMenu.Width = 100;
            ////treeView1.Visible = false;
            ////pnlMenuMobile.Visible = true;
            ////btnDesplegarMenu.Visible = false;
            //var f = new TEST();
            //f.Show();
        }
        private void frmLicencia_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }

        private void btningresarLicencia_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            ModificarLicencia();
        }

        private void dgvMercaderia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearGrilla(e);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            RenovarConsultaLicencia();
        }
    }
}
