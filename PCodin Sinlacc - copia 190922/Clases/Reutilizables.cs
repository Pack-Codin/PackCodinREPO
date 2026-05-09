using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Formularios.APP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Button = System.Windows.Forms.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using GroupBox = System.Windows.Forms.GroupBox;
using Label = System.Windows.Forms.Label;
using MessageBox = System.Windows.MessageBox;
using objExcel = Microsoft.Office.Interop.Excel;
using TextBox = System.Windows.Forms.TextBox;

namespace PCodin_Sinlacc
{
    public class Reutilizables
    {
        private static EventHandler Check_CheckedChanged1;

        public static EventHandler Check_CheckedChanged { get; private set; }

        public static void ConectarSQL(int NotificacionConfigurable_ID , TextBox txt)
        {
            using (var hb = new DBdatos())
            {
                var ConsultaNoti = (from NC in hb.NOTIFICACIONCONFIGURABLE
                                    where NC.ID == NotificacionConfigurable_ID
                                    select NC).FirstOrDefault();

                string Cadena = hb.Database.Connection.ConnectionString;

                SqlConnection Conexion = new SqlConnection(Cadena);
                Conexion.Open();

                SqlCommand Consulta = new SqlCommand(ConsultaNoti.Consulta,Conexion);
                SqlDataReader Registro = Consulta.ExecuteReader();

                int CantidadRegistros = 0;

                while (Registro.Read())
                {
                    CantidadRegistros = CantidadRegistros + 1;
                    
                }
               // txt.Text = CantidadRegistros.ToString();
                //if (Registro.Read())
                //{
                //    txt.Text = Registro["KILOS"].ToString();
                //}

            }


        }

        public static void Teclado(TextBox txtSeleccionado)
        {
            if (clsVariablesGenerales.Modo == "Mobile")
            {
                var f = new frmTecladoVirtual();
                f.txtSelecionado = txtSeleccionado;
                f.txtResultado.Text = txtSeleccionado.Text;
                f.ShowDialog();             
            }

            
        }
        public static void FiltroBuscar(object sender, KeyPressEventArgs e , TextBox txt , ComboBox cmb)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txt.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmb, txt, "PRO", true, "NO");
                txt.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txt.Visible = false;
                txt.Focus();
                e.Handled = true;
            }
        }
        public static void FiltroActivar(TextBox txt)
        {
            txt.Visible = true;
            txt.Select();
        }
        public static void ProtegerCadenaConexion()
        {
            // Abre la configuración del ejecutable actual
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Obtenemos la sección de cadenas de conexión
            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;

            if (section != null && !section.SectionInformation.IsProtected)
            {
                // Aplicamos protección DPAPI (ligada a la máquina local)
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

                // Guardamos los cambios en el archivo App.config (o NombeApp.exe.config)
                section.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Modified);

                // Refresca la sección en memoria para que EF la use inmediatamente
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }


        public static void MostrarOcultarFiltros(System.Windows.Forms.GroupBox groupBox, Button btnMostrar, Label lblEstado)
        {
            if (groupBox.Visible)
            {
                groupBox.Visible = false;
                lblEstado.Visible = false;
                btnMostrar.Text = "Mostrar filtros";
            }
            else
            {
                groupBox.Visible = true;
                lblEstado.Visible = true;
                btnMostrar.Text = "Ocultar filtros";
            }
        }
        public static void ActivarFiltroTexbox(TextBox txt, CheckBox check)
        {
            if (check.Checked)
            {
                txt.Enabled = true;
                txt.Select();
            }
            else
                txt.Enabled = false;
        }
        public static void ActivarFiltroDobleTexbox(TextBox txt1, TextBox txt2 ,CheckBox check)
        {
            if (check.Checked)
            {
                txt1.Enabled = true;
                txt2.Enabled = true;
                txt1.Select();
            }
            else
            {
                txt1.Enabled = false;
                txt2.Enabled = false;
            }
        }
        public static void ActivarFiltroComboCategorias(CheckBox Check, ComboBox Combo, TextBox txt,Button btnBuscar)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;
             
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarCategorias(Combo, txt, false);
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;                
                txt.Visible = false;
            }
        }
        public static void ActivarFiltroComboZona(CheckBox Check, ComboBox Combo)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;                            
                clsCargarCombos.MostrarComboZona(Combo);
            }
            else
            {
                Combo.Enabled = false;             
            }
        }
        public static void ActivarFiltroMedioPago(CheckBox Check, ComboBox Combo)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                            
                clsCargarCombos.MostrarComboMedioPago(Combo);
            }
            else
            {
                Combo.Enabled = false;             
            }
        }
        public static void ActivarFiltroMedioPago2(CheckBox Check, ComboBox Combo , TextBox txt , ref int MedioPagoIDSeleccionado)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;
                
                clsCargarCombos.MostrarComboMedioPago(Combo);
                Combo.SelectedValue  = 0;
            }
            else
            {
                Combo.Enabled = false;
                txt.Enabled = false;
                if (Combo.SelectedValue != null)
                    MedioPagoIDSeleccionado = (int)Combo.SelectedValue;

                Combo.SelectedValue = 0;               
            }
        }
        public static void ActivarFiltroComboInsProConCheck(CheckBox Check, ComboBox Combo, TextBox txt, CheckBox CheckAI, Button btnBuscar)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;
                CheckAI.Enabled = true;
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarComboInsumosProductos(Combo, txt, false, CheckAI);
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;
                CheckAI.Enabled = false;
                txt.Visible = false;
            }
        }
        public static void ActivarFiltroComboInsPro(CheckBox Check, ComboBox Combo, TextBox txt, Button btnBuscar,string INSPRO,string Subproducto)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;               
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarComboInsProSinCheck(Combo, txt, INSPRO, false, Subproducto);
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;               
                txt.Visible = false;
            }
        }
        public static void ActivarFiltroComboInsPro2(CheckBox Check, ComboBox Combo, TextBox txt, Button btnBuscar) // SinFiltroINSPRO
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarComboInsPro(Combo, txt, false);
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;
                txt.Visible = false;
            }
        }
        public static void ActivarFiltroComboArticulosMagdalena(CheckBox Check, ComboBox Combo, TextBox txt, Button btnBuscar) // EXCLUSIVO PARA MAGADALENA
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarComboArticulosMagdalena(Combo, txt, false);
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;
                txt.Visible = false;
            }
        }
        public static void ActivarFiltroComboSubProducto(CheckBox Check, ComboBox Combo, TextBox txt, Button btnBuscar) // SinFiltroINSPRO
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarComboSubProductos(Combo, txt, false);
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;
                txt.Visible = false;
            }
        }
        public static void ActivarFiltroInsumoSegunProductoSeleccionado(CheckBox Check, ComboBox Combo, ComboBox ComboProducto,TextBox txt, Button btnBuscar)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarComboInsumoSegunProductoSeleccionado(Combo, ComboProducto, txt, false);
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;
                txt.Visible = false;
            }
        }
        public static void ActivarFiltroInsumoSegunProductoSeleccionado2(CheckBox Check, ComboBox Combo, string ProductoID, TextBox txt, Button btnBuscar)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarComboInsumoSegunProductoSeleccionado2(Combo, ProductoID, txt, false);
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;
                txt.Visible = false;
            }
        }
        public static void ActivarFiltroComboCiudad(CheckBox Check, ComboBox Combo, TextBox txt, Button btnBuscar)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;             
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarComboCiudades(Combo, txt, false);
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;                
                txt.Visible = false;
            }
        }
        public static void ActivarFiltroComboTipoCliente(CheckBox Check, ComboBox Combo)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                clsCargarCombos.MostrarComboTipoCliente(Combo);
            }
            else
            {
                Combo.Enabled = false;
            }
        }
        public static void ActivarFiltroComboSeccion(CheckBox Check, ComboBox Combo)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                clsCargarCombos.MostrarSeccion(Combo);
            }
            else
            {
                Combo.Enabled = false;
            }
        }
        //internal static void Check_CheckedChanged(CheckBox check)
        //{
        //    throw new NotImplementedException();
        //}

        public static void ActivarFiltroComboPuestos(CheckBox Check, ComboBox Combo)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;               
                clsCargarCombos.MostrarComboPuestos(Combo);
            }
            else
            {
                Combo.Enabled = false;                        
            }
        }
        public static void ActivarFiltroComboSimple(CheckBox Check, ComboBox Combo)
        {
            if (Check.Checked)
                Combo.Enabled = true;
            else
                Combo.Enabled = false;
        }
        public static void ActivarFiltroDateTime(CheckBox Check, DateTimePicker DTP)
        {
            if (Check.Checked)
                DTP.Enabled = true;
            else
                DTP.Enabled = false;
        }
        public static void ActivarFiltroComboMedida(CheckBox Check, ComboBox Combo)
        {
            if (Check.Checked)
            {
                clsCargarCombos.MostrarMedidas(Combo);
                Combo.Enabled = true;
            }
            else
                Combo.Enabled = false;
        }
        public static void ActivarFiltroComboEmpleados(CheckBox Check, TextBox text, ComboBox Combo,Button btn)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                btn.Enabled = true;
                clsCargarCombos.MostrarComboEmpleados(Combo , text ,false);
            }
            else
            {
                Combo.Enabled = false;
                btn.Enabled = false;
            }
        }
        public static void ActivarFiltroComboChofer(CheckBox Check, TextBox text, ComboBox Combo, Button btn)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                btn.Enabled = true;
                clsCargarCombos.MostrarComboChofer(Combo, text, false);
            }
            else
            {
                Combo.Enabled = false;
                btn.Enabled = false;
            }
        }
        public static void ActivarFiltroComboCiudades(CheckBox Check, TextBox text, ComboBox Combo)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                clsCargarCombos.MostrarComboCiudades(Combo, text, false);
            }
            else
            {
                Combo.Enabled = false;
            }
        }
        public static void ActivarFiltroDtpFecha(CheckBox Check, DateTimePicker dateTimePicker)
        {
            if (Check.Checked)
                dateTimePicker.Enabled = true;
            else
                dateTimePicker.Enabled = false;
        }
        public static void ActivarFiltroComboCliente(CheckBox Check, ComboBox Combo, TextBox txt, Button btnBuscar)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarComboClientes(Combo, txt, false, "CLI", 0);
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;
                txt.Visible = false;
            }
        }
        
        public static void ActivarFiltroComboProveedor(CheckBox Check, ComboBox Combo, TextBox txt, Button btnBuscar)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarComboClientes(Combo, txt, false, "PRO", 0    );
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;
                txt.Visible = false;
            }
        }
        public static void ActivarFiltroComboVendedor(CheckBox Check, ComboBox Combo, TextBox txt, Button btnBuscar)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarComboVendores(Combo, txt, false);
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;
                txt.Visible = false;
            }
        }
        public static void ActivarFiltroComboConceptos(CheckBox Check, ComboBox Combo, TextBox txt, Button btnBuscar)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;
                txt.Enabled = true;
                btnBuscar.Enabled = true;
                clsCargarCombos.MostrarComboConcepto(Combo, txt, false);
            }
            else
            {
                Combo.Enabled = false;
                btnBuscar.Enabled = false;
                txt.Visible = false;
            }
        }
        public static void ActivarFiltroComboUsuarios(CheckBox Check, ComboBox Combo)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;            
                clsCargarCombos.MostrarComboUsuarios(Combo);
            }
            else
            {
                Combo.Enabled = false;               
            }
        }
        public static void AbriFormFinalizado(string RutaImagen, string Mensaje)
        {
            var f = new frmFormMovimientoFinalizado();
            f.picImagen.Image = System.Drawing.Image.FromFile(RutaImagen);
            f.lblMensaje.Text = Mensaje;
            f.ShowDialog();
        }
        public static void EnviarMail(string EmailDestino , string Mensaje)
        {
            string EmailOrigen = "francopeirone@gmail.com";
            string Contraseña = "dkgidusravngshtn";
            //EmailDestino = "camilakacc@gmail.com";

            //string path = @"C:\turuta\burger.png";
            //string path2 = @"C:\turuta\a.jpg";

            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Nueva notificación en PACK-CODIN", "<b>" +  Mensaje + "</b>");
            //oMailMessage.Attachments.Add(new Attachment(path));
            //oMailMessage.Attachments.Add(new Attachment(path2));

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpCliente = new SmtpClient("smtp.gmail.com");
            oSmtpCliente.EnableSsl = true;
            oSmtpCliente.UseDefaultCredentials = false;
            oSmtpCliente.Port = 587;
            oSmtpCliente.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

            oSmtpCliente.Send(oMailMessage);

            oSmtpCliente.Dispose();
        }
        public static void ActivarFiltroComboInformes(ComboBox Combo, TextBox txt, Button btnBuscar)
        {
            //if (Check.Checked)
            //{
            //    Combo.Enabled = true;
            //    txt.Enabled = true;               
            //    btnBuscar.Enabled = true;
            //    clsCargarCombos.MostrarComboInformes(Combo, txt, false);
            //}
            //else
            //{
            //    Combo.Enabled = false;
            //    btnBuscar.Enabled = false;                
            //    txt.Visible = false;
            //}
        }
        public static void CargarImagenCabezal(PictureBox Pic , string Localizacion)
        {
            Pic.ImageLocation = Localizacion;
        }
        public static void ExportExcel(DataGridView DGV)
        {
            try
            {
                string NombreArchivo = "";
                string CarpetaDocumentosTemp = @"\\tsclient\C\DocsTemp";
                //string CarpetaDocumentosTemp = @"\\tsclient\C\DocsTemp";
                string RutaArchivo;

                DirectoryInfo Busqueda = new DirectoryInfo(CarpetaDocumentosTemp);

                var Consulta = (from A in Busqueda.GetFiles()
                                orderby A.Name descending
                                select A).FirstOrDefault();

                if (Consulta == null)
                {
                    NombreArchivo = "1";
                }
                else
                {
                    NombreArchivo = Consulta.Name;
                    if(NombreArchivo.Contains(".pdf"))
                        NombreArchivo = NombreArchivo.Replace(".pdf", "");
                    if(NombreArchivo.Contains(".xlsx"))
                        NombreArchivo = NombreArchivo.Replace(".xlsx", "");
                    
                    NombreArchivo = (Convert.ToInt32(NombreArchivo) + 1).ToString();
                }

                RutaArchivo = @"" + CarpetaDocumentosTemp + @"\" + NombreArchivo + ".xlsx";

                objExcel.Application objAplicacion = new objExcel.Application();
                Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;

                foreach (DataGridViewColumn columna in DGV.Columns)
                {
                    objHoja.Cells[1, columna.Index + 1] = columna.HeaderText;
                    foreach (DataGridViewRow fila in DGV.Rows)
                    {
                        objHoja.Cells[fila.Index + 2, columna.Index + 1] = fila.Cells[columna.Index].Value;
                    }
                }

                objLibro.SaveAs(RutaArchivo);
                objLibro.Close();
                objAplicacion.Quit();
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
           
        }
        public static void ExportarExcel(DataGridView DGV)
        {
            if (DGV.RowCount > 0)
            {
                Microsoft.Office.Interop.Excel.Application ExportarExcel = new Microsoft.Office.Interop.Excel.Application();

                ExportarExcel.Application.Workbooks.Add(true);

                int indiceColum = 0;

                foreach (DataGridViewColumn Columna in DGV.Columns)
                {
                    if (Columna.Visible == true)
                    {
                        indiceColum++;
                        ExportarExcel.Cells[1, indiceColum] = Columna.HeaderText;
                    }
                }

                int IndiceFila = 0;

                foreach (DataGridViewRow Fila in DGV.Rows)
                {
                    IndiceFila++;
                    indiceColum = 0;

                    foreach (DataGridViewColumn columna in DGV.Columns)
                    {
                        if (columna.Visible == true)
                        {
                            indiceColum++;
                            ExportarExcel.Cells[IndiceFila + 1, indiceColum] = Fila.Cells[columna.Name].Value;
                        }
                    }
                }
                
                ExportarExcel.Visible = true;
            }
        }
        public static void CambiarOrdenacionAscDesc(Button btnAcs, Button btnDesc)
        {
            if (btnDesc.Visible == true)
            {
                btnDesc.Visible = false;
                btnAcs.Visible = true;
                return;
            }
            if (btnAcs.Visible == true)
            {
                btnDesc.Visible = true;
                btnAcs.Visible = false;
                return;
            }
        }
        public static void MostrarCiudadAutomaticamente(ComboBox ComboCliente, ComboBox ComboCiudad)
        {
            if (ComboCliente.SelectedIndex != -1)
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from C in hb.Clientes
                                    where C.ID == (int)ComboCliente.SelectedValue
                                    select C);

                    var Resultados = Consulta.FirstOrDefault();

                    if (Resultados != null)
                    {
                        ComboCiudad.SelectedValue = Resultados.Ciudad_ID;
                        ComboCiudad.Text = Resultados.Ciudades.Descripcion;                        
                    }
                }
            }
        }
        public static void MostrarProveedorAutomaticamente(ComboBox ComboInsumo, ComboBox ComboProveedor)
        {
            if (ComboInsumo.SelectedIndex != -1)
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from C in hb.Insumo_Proveedor
                                    where C.Insumo_ID == ComboInsumo.SelectedValue.ToString()
                                    select new
                                    {
                                        ID = C.Clientes.ID,
                                        Descripcion = C.Clientes.Descripcion
                                    });

                    var Resultados = Consulta.ToList();

                    if (Resultados != null)
                    {
                        ComboProveedor.ValueMember = "ID";
                        ComboProveedor.DisplayMember = "Descripcion";
                        ComboProveedor.DataSource = Resultados;
                    }
                }
            }
        }
        public static void ActivarFiltroComboUsuario(CheckBox Check, ComboBox Combo)
        {
            if (Check.Checked)
            {
                Combo.Enabled = true;               
                clsCargarCombos.MostrarComboUsuario(Combo);
            }
            else
            {
                Combo.Enabled = false;               
            }
        }
       

        
        public static void AgregarComboFiltroProducto(ref string checkName , ref string cmbName , ref string txtName , ref string btnName, ref int CheckX , ref int CheckY, ref int ControlX , ref int ControlY , ref int BtnX , ref int BtnY, Control.ControlCollection Controls)
        {
            CheckBox Check = new CheckBox();

            Check.AutoSize = true;
            Check.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Check.Location = new System.Drawing.Point(CheckX, CheckY);
            Check.Size = new System.Drawing.Size(57, 17);
            Check.Name = "chkFiltraProducto";
            Check.Text = "Producto";
            CheckY = CheckY * 2;
            checkName = "chkFiltraProducto";
            Controls.Add(Check);
           // Check.CheckedChanged += Check_CheckedChanged1;

            ComboBox Combo = new ComboBox();

            Combo.Location = new System.Drawing.Point(ControlX, ControlY);
            Combo.Name = cmbName;
            Combo.Size = new System.Drawing.Size(350, 17);
            Combo.Enabled = false;
            Controls.Add(Combo);

            TextBox Textbox = new TextBox();

            Textbox.Location = new System.Drawing.Point(ControlX, ControlY);
            Textbox.Name = txtName;
            Textbox.Size = new System.Drawing.Size(350, 17);
            Textbox.Enabled = false;
            Textbox.Visible = false;
            ControlY = ControlY * 2;
            Controls.Add(Textbox);


            Button button = new Button();

            button.Location = new System.Drawing.Point(BtnX, BtnY);
            button.Size = new System.Drawing.Size(22, 22);
            button.BackColor = System.Drawing.Color.WhiteSmoke;
            button.BackgroundImage = System.Drawing.Bitmap.FromFile("C:/Users/franc/Documents/Kacos/Pack-Codin/Sinlacc/PCodin Sinlacc/Images/buscar.png");
            button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button.Cursor = System.Windows.Forms.Cursors.Hand;
            button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Name = btnName;
            button.TabIndex = 586;
            BtnY = BtnY * 2;
            button.UseVisualStyleBackColor = false;
            //button.Click += button_Click;

            Controls.Add(button);
        }
        public static bool ValidarSoloNumeros(TextBox textBox)
        {
            try
            {
                decimal d = Convert.ToDecimal(textBox.Text);
                if(!textBox.Text.Contains(".") && !textBox.Text.Contains(","))
                {
                   if(textBox.Text.Contains("."))
                   {
                        textBox.Text = textBox.Text.Replace(".", ",");
                        int longintub = textBox.Text.Length;
                        textBox.SelectionStart = longintub;
                        Reutilizables.ConvertirValorMoneda(textBox);
                       
                   }
                   else
                   {
                        Reutilizables.ConvertirValorMoneda(textBox);
                   }
                }
                return true;
            }
            catch
            {
                textBox.Text = "0,00";
                textBox.Select(0, textBox.TextLength);

                return false;
            }
        }
        public static bool ValidarSoloNumeros2(TextBox textBox)
        {
            try
            {
                decimal d = Convert.ToDecimal(textBox.Text);
                //textBox.Text = textBox.Text.Replace(".", ",");
                int longintub = textBox.Text.Length;
                textBox.SelectionStart = longintub;
                //Reutilizables.ConvertirValorMoneda(textBox);
                return true;
            }
            catch
            {
                textBox.Text = "0,00";
                textBox.Select(0, textBox.TextLength);

                return false;
            }
        }
        //public static bool ValidarSoloNumerosDGVTickets(DataGridView dgv,string colCantidad, string colPrecioCosto)
        //{
        //    //try
        //    //{
        //    //    string Cantidad = dgv.CurrentRow.Cells[colCantidad].Value.ToString();
        //    //    string PrecioCosto = dgv.CurrentRow.Cells[colPrecioCosto].Value.ToString();

        //    //    decimal NCantidad = Convert.ToDecimal(Cantidad);
        //    //    decimal NPrecioCosto = Convert.ToDecimal(PrecioCosto);

        //    //    dgv.CurrentRow.Cells[colCantidad].Value = 


        //    //    textBox.Text = textBox.Text.Replace(".", ",");
        //    //    int longintub = textBox.Text.Length;
        //    //    textBox.SelectionStart = longintub;
        //    //    Reutilizables.ConvertirValorMoneda(textBox);
        //    //    return true;
        //    //}
        //    //catch
        //    //{
        //    //    textBox.Text = "0,00";
        //    //    textBox.Select(0, textBox.TextLength);

        //    //    return false;
        //    //}
        //}
        public static void RenderizarForm(Form Formulario)
        {
            //Formulario.Size = new System.Drawing.Size((int)SystemParameters.FullPrimaryScreenWidth, (int)SystemParameters.FullPrimaryScreenHeight + 20);
            //Formulario.Location = new System.Drawing.Point(0, 0);
            Formulario.Size = new System.Drawing.Size(clsVariablesGenerales.WpnlCentral,clsVariablesGenerales.HpnlCentral);
        }
        public static bool ValidarSoloLetras(TextBox textBox)
        {
            try
            {
                decimal d = Convert.ToDecimal(textBox.Text);
                textBox.Text = "";
                return true;
            }
            catch
            {
                textBox.Text = textBox.Text;
                textBox.Select(0, textBox.TextLength);
                return false;
            }
        }
        //public static bool ValidarSoloNumeros2(TextBox textBox)
        //{
        //    try
        //    {
        //        decimal d = Convert.ToDecimal(textBox.Text);
        //        textBox.Text = textBox.Text.Replace(".", ",");
        //        int longintub = textBox.Text.Length;
        //        textBox.SelectionStart = longintub;
        //        //Reutilizables.ConvertirValorMoneda(textBox);
        //        return true;
        //    }
        //    catch
        //    {
        //        textBox.Text = "";
        //        textBox.Select(0, textBox.TextLength);

        //        return false;
        //    }
        //}
        public static void CargarColoresEnCombo(ComboBox combo)
        {
            combo.Items.Clear();
            string[] Colores = Enum.GetNames(typeof(System.Drawing.KnownColor));
            combo.Items.AddRange(Colores);
        }
        public static void FormatearLote(DateTimePicker dtpLote ,TextBox txtLote)
        {
            try
            {
                txtLote.Text = dtpLote.Value.ToShortDateString().Replace("/", "");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        public static void MOstrarHoraAutomatica(TextBox Hora, TextBox Hora1, TextBox Minutos, Control BotonAutomatico, Control BotonManual, Label lblSeparado)
        {
            Hora.Text = DateTime.Now.ToShortTimeString();
            if (Hora.Text.Length == 4)
                Hora.Text = "0" + Hora.Text;
            Hora.Visible = true;
            BotonAutomatico.Visible = false;
            BotonManual.Visible = true;
            Hora1.Visible = false;
            Minutos.Visible = false;
            lblSeparado.Visible = false;


        }
        public static void VolverAHoraManual(TextBox Hora, TextBox Hora1, TextBox Minutos, Control BotonAutomatico, Control BotonManual , Label lblSeparado)
        {
            BotonManual.Visible = false;
            BotonAutomatico.Visible = true;
            Hora1.Visible = true;
            Minutos.Visible = true;
            Hora.Visible = false;
            Hora1.Select();
            lblSeparado.Visible = true;
        }
        public static void PasarHoraManualAlTexbox(TextBox Hora, TextBox Horas, TextBox Minutos)
        {
            if (Horas.TextLength == 2 && Minutos.TextLength == 2)
            {
                if (Hora.Visible == false)
                    Hora.Text = Horas.Text + ":" + Minutos.Text;
                else
                    Hora.Text = DateTime.Now.ToShortTimeString();

            }
            else if (Hora.Visible == true)
            {
                Hora.Text = DateTime.Now.ToShortTimeString();
            }
            else
            {
                Hora.Text = "";
            }
        }
        public static void CoregirHora(TextBox Horas, TextBox Minutos)
        {
            int Hora = 0;

            if (Horas.TextLength == 2)
            {
                Hora = Convert.ToInt32(Horas.Text);
                if ((Hora >= 0) && (Hora < 24))
                {
                    if (Hora == 0)
                    {
                        Horas.Text = "00";
                        Minutos.Select();
                    }
                    else if (Hora >= 1 && Hora <= 9)
                    {
                        Horas.Text = "0" + Hora.ToString();
                        Minutos.Select();
                    }
                    else
                    {
                        Horas.Text = Hora.ToString();
                        Minutos.Select();
                    }

                }
                else
                {
                    System.Windows.MessageBox.Show("La Hora debe tener un valor entre 00-23", "Advertencia", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Exclamation);
                    Horas.Text = "";
                    Horas.Select();
                }

            }
            else
                Hora = 0;

        }
        public static void CorregirMinutos(TextBox Horas, TextBox Minutos)
        {
            int Minuto = 0;

            if (Minutos.TextLength == 2)
            {
                Minuto = Convert.ToInt32(Minutos.Text);

                if ((Minuto >= 0) && (Minuto < 60))
                {
                    if (Minuto == 0)
                        Minutos.Text = "00";
                    else if (Minuto >= 1 && Minuto <= 9)
                        Minutos.Text = "0" + Minuto.ToString();
                    else
                        Minutos.Text = Minuto.ToString();
                }
                else
                {
                    System.Windows.MessageBox.Show("Los minutos deben tener un valor entre 00-59", "Advertencia", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Exclamation);
                    Minutos.Text = "";
                    Minutos.Select();
                }

            }
            else
                Minuto = 0;
        }
        public static void ConvertirValorMoneda(TextBox txt)
        {
            using (var hb = new DBdatos())
            {
                
                if (txt.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    decimal Valor;

                    Valor = Convert.ToDecimal(txt.Text);
                    txt.Text = Valor.ToString("N2");
                }
            }
        }
       
        public static void ReubicarFiltros(GroupBox gbxFiltros , Panel pnlFiltros , Button btnFiltros)
        {
            gbxFiltros.Location = new System.Drawing.Point(btnFiltros.Location.X, pnlFiltros.Location.Y - gbxFiltros.Height - 2);
        }
        public static void PantallaEspera()
        {
            //close
            //Thread t = new Thread(new ThreadStart())
        }
        public static void AutoNumerarComprobanteCompra(TextBox txtPuntoVenta, TextBox txtNumeroComprobante)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.INGRESOMERCADERIA
                                orderby C.NumeroComprobante descending
                                select C).FirstOrDefault();

                if (Consulta == null)
                {
                    txtPuntoVenta.Text = "0001";
                    txtNumeroComprobante.Text = "00000001";
                }
                else
                {
                    long NumeroComprobante = Convert.ToInt64(Consulta.NumeroComprobante.Substring(4, 8));
                    NumeroComprobante = NumeroComprobante + 1;

                    txtPuntoVenta.Text = Consulta.NumeroComprobante.Substring(0, 4);
                    txtNumeroComprobante.Text = NumeroComprobante.ToString("D8");
                }

            }
        }
        public static void AutoNumerarComprobanteVenta(TextBox txtPuntoVenta , TextBox txtNumeroComprobante)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.TICKET
                                orderby C.NumeroTicket descending
                                select C).FirstOrDefault();

                if(Consulta == null)
                {
                    txtPuntoVenta.Text = "0001";
                    txtNumeroComprobante.Text = "00000001";
                }
                else
                {
                    long NumeroComprobante = Convert.ToInt64(Consulta.NumeroTicket.Substring(4, 8));
                    NumeroComprobante = NumeroComprobante + 1;

                    txtPuntoVenta.Text = Consulta.NumeroTicket.Substring(0, 4);
                    txtNumeroComprobante.Text = NumeroComprobante.ToString("D8");
                }
               
            }
        }
        public static void AutoNumerarComprobanteCuentaCorriente(TextBox txtPuntoVenta, TextBox txtNumeroComprobante)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.MOVIMIENTOCUENTACORRIENTE
                                orderby C.NumeroComprobante descending
                                select C).FirstOrDefault();

                if (Consulta == null)
                {
                    txtPuntoVenta.Text = "0001";
                    txtNumeroComprobante.Text = "00000001";
                }
                else
                {
                    long NumeroComprobante = Convert.ToInt64(Consulta.NumeroComprobante.Substring(4, 8));
                    NumeroComprobante = NumeroComprobante + 1;

                    txtPuntoVenta.Text = Consulta.NumeroComprobante.Substring(0, 4);
                    txtNumeroComprobante.Text = NumeroComprobante.ToString("D8");
                }

            }
        }
        public static void AutoNumerarComprobanteCaja(TextBox txtPuntoVenta, TextBox txtNumeroComprobante)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.CAJAMOVIMIENTO
                                orderby C.NumeroComprobante descending
                                select C).FirstOrDefault();

                if (Consulta == null)
                {
                    txtPuntoVenta.Text = "0001";
                    txtNumeroComprobante.Text = "00000001";
                }
                else
                {
                    long NumeroComprobante = Convert.ToInt64(Consulta.NumeroComprobante.Substring(4, 8));
                    NumeroComprobante = NumeroComprobante + 1;

                    txtPuntoVenta.Text = Consulta.NumeroComprobante.Substring(0, 4);
                    txtNumeroComprobante.Text = NumeroComprobante.ToString("D8");
                }

            }
        }
        
        public static void CalcularPrecioArticulo(int ListaPrecio , string CodigoArticulo , TextBox txtPrecio)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from PP in hb.LISTAPRECIOCUERPO
                                where PP.ListaPrecio_ID == ListaPrecio
                                    && PP.Articulo_ID == CodigoArticulo
                                select PP).FirstOrDefault();

                if (Consulta != null)
                    txtPrecio.Text = Consulta.Precio.ToString();
                else
                    txtPrecio.Text = "0,00";
            }
        }
    }
}
