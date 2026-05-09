using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace PCodin_Sinlacc
{
    public partial class frmBackup : Form
    {
        public int Usario_ID;
        public frmBackup()
        {
            InitializeComponent();
        }

       // SqlConnection Conexion = new SqlConnection("Data Source=DESKTOP-C0S4J3P\\SQLEXPRESS;initial catalog=Pcodin_Sinlacc;integrated security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            //Conexion.Open();

        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from CB in hb.Control_Backup
                                orderby CB.Fecha descending, CB.Hora descending
                                select new
                                {
                                    CB.Fecha,
                                    CB.Hora,
                                    CB.Tipo,
                                    CB.Usuario_ID,
                                    CB.Usuarios.Nombre
                                });

                if (chkFiltraTipo.Checked)
                    Consulta = (from C in Consulta
                                where C.Tipo == cmbFiltraTipo.Text
                                select C);

                if (chkFiltraUsurio.Checked)
                    Consulta = (from C in Consulta
                                where C.Usuario_ID == (int)cmbFiltraUsuario.SelectedValue
                                select C);

                if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFechaDesde.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha <= dtpFechaHasta.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFechaDesde.Value.Date && C.Fecha <= dtpFechaHasta.Value.Date
                                select C);
                }

                var Resultados = Consulta.ToList();

                colFecha.DataPropertyName = "Fecha";
                colHora.DataPropertyName = "Hora";
                colTipo.DataPropertyName = "Tipo";
                colUsuario.DataPropertyName = "Nombre";

                dgvBackup.AutoGenerateColumns = false;
                dgvBackup.DataSource = Resultados;
            }
        }
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            dtpFechaHasta.Value = DateTime.Now.Date;
            dtpFechaDesde.Value = DateTime.Now.Date.AddDays(-30);          

            using (var hb = new DBdatos())
            {
                var Consulta = (from CB in hb.Control_Backup
                                orderby CB.Fecha descending , CB.Hora descending
                                select CB);

                var Resultados = Consulta.FirstOrDefault();

                if(Resultados == null)
                {
                    txtFechaUltCopia.Text = "";
                    txtHoraUltCopia.Text = "";
                    txtRuta.Text = "";
                }
                else
                {
                    txtFechaUltCopia.Text = Resultados.Fecha.ToString();
                    txtHoraUltCopia.Text = Resultados.Hora.ToString();
                    txtRuta.Text = Resultados.Ruta;
                }
                txtDB.Text = hb.Database.Connection.Database.ToString();
                MostrarDatos();
                OnOffbtnCargar();
            }
        }
        private void frmBackup_Load(object sender, EventArgs e)
        {
            Reutilizables.RenderizarForm(this);
            InicializarForm();
        }
        private void SeleccionarRuta()
        {
           // folderBrowserDialog1.RestoreDirectory = true;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) // abre el explorador archivos
            {
                txtRuta.Text = folderBrowserDialog1.SelectedPath;
            }

            //if (txtRuta.TextLength == 0)
            //{
            //    MessageBox.Show("No se ha elegido ninguna imagen");
            //    return;
            //}
        }
        private void RealizarCopiaSeguridad()
        {
            using (var hb = new DBdatos())
            {
                //string Cadena = "Data Source=PCODIN\\PCODIN;initial catalog=" + txtDB.Text + ";integrated security=False;user id=sa;password=pcn1971@";
                string Cadena = hb.Database.Connection.ConnectionString;
                SqlConnection Conexion = new SqlConnection(Cadena);           
                
                string NombreFinal;
                string Script;
                string BaseDatos = hb.Database.Connection.Database.ToString() ;

                string Fecha = DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + "_";
                string Hora = DateTime.Now.TimeOfDay.Hours.ToString() + DateTime.Now.TimeOfDay.Minutes.ToString() + DateTime.Now.TimeOfDay.Seconds.ToString();

                if (rdbBak.Checked)
                {
                    NombreFinal = txtDB.Text + "_Backup" + Fecha + Hora + ".bak";
                    Script = "BACKUP DATABASE [" +txtDB.Text+"] TO  DISK = N'" + txtRuta.Text + "\\" + NombreFinal + "' WITH NOFORMAT, NOINIT,  NAME = N'" +txtDB.Text+"-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                }
                else
                {
                    NombreFinal = txtDB.Text + "_Backup" + Fecha + Hora + ".diff";
                    Script = "BACKUP DATABASE [" + txtDB.Text + "] TO  DISK = N'" + txtRuta.Text + "\\" + NombreFinal + "' WITH DIFFERENTIAL, NOINIT,  NAME = N'" + txtDB.Text + "-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                }

               // string Scripts = "BACKUP DATABASE [Pcodin_Sinlacc] TO  DISK = N'C:/Program Files/Microsoft SQL Server/MSSQL15.SQLEXPRESS/MSSQL/Backup/Pruebas de back C#\\" + NombreFinal + "' WITH NOFORMAT, NOINIT, SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

                SqlCommand cmd = new SqlCommand(Script, Conexion);

                try
                {
                    Conexion.Open();
                    cmd.ExecuteNonQuery();
          
                    var i = new Control_Backup();

                    i.ID = 1;
                    i.Fecha = DateTime.Today.Date;
                    i.Hora = DateTime.Now.TimeOfDay;
                    i.Ruta = txtRuta.Text;
                    if (rdbBak.Checked)
                        i.Tipo = "BAK";
                    else
                        i.Tipo = "DIFF";
                    i.Usuario_ID = Usario_ID;

                  

                    hb.Control_Backup.Add(i);
           
                    hb.SaveChanges();
                    MessageBox.Show("La copia se realizo correctamente");
                    MostrarDatos();
                    //InicializarForm();


                    string RutaArchivoComprimir = txtRuta.Text + "\\" + NombreFinal;
                    string RutaGuardado = txtRuta.Text;


                  

                    CrearZIP(RutaArchivoComprimir, RutaGuardado);
                    
                    string[] CarpetaBackup = Directory.GetFiles(RutaGuardado);

                    foreach (string Archivos in CarpetaBackup)
                    {
                        string ArchivosBorrar = Archivos.Replace(RutaGuardado, "");
                        ArchivosBorrar = ArchivosBorrar.Replace("\\","");

                        if (ArchivosBorrar == (NombreFinal) && !NombreFinal.EndsWith(".zip")) //&& !Archivos.EndsWith("zip"))
                        {
                            File.Delete(Archivos);
                            
                        }
                    }

                    ////RutaGuardado = RutaGuardado.Replace("/", "e");

                        //ZipFile.CreateFromDirectory(ArchivoComprimir, RutaGuardado);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Conexion.Close();
                    Conexion.Dispose();
                }
            }
        }
        public string CrearZIP(string FileToAdd , string Ruta)
        {
            //string[] Names = FileToAdd//.Split('.');
            string FileZipName = FileToAdd.ToString() + ".zip";

            using (FileStream fOrigen = File.OpenRead(Path.Combine(Ruta + @"\Data\", FileToAdd)))
            {
                using (FileStream fDestino = File.Create(Path.Combine(Ruta + @"\Envio\", FileZipName)))
                {

                    byte[] buffer = new byte[fOrigen.Length];
                    fOrigen.Read(buffer, 0, buffer.Length);

                    using (GZipStream output = new GZipStream(fDestino, CompressionMode.Compress))
                    {
                        output.Write(buffer, 0, buffer.Length);
                    }
                }
            }

            return FileZipName;
        }
        private void OnOffbtnCargar()
        {
            if (txtDB.TextLength > 0 && txtRuta.TextLength > 0)
                btnBackup.Enabled = true;
            else
                btnBackup.Enabled = false;
        }
        private void btnElegirRuta_Click(object sender, EventArgs e)
        {
            SeleccionarRuta();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            RealizarCopiaSeguridad();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtFechaUltCopia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoraUltCopia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void chkFiltraTipo_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraTipo, cmbFiltraTipo);
        }

        private void chkFiltraUsurio_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboUsuario(chkFiltraUsurio, cmbFiltraUsuario);
        }

        private void txtDB_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void txtRuta_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            RealizarCopiaSeguridad();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlSuperior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDB_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
