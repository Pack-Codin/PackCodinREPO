using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios.APP;
using PCodin_Sinlacc.Formularios.CAJA;
using PCodin_Sinlacc.Formularios.Circuito_Productivo;
using PCodin_Sinlacc.Formularios.Configuracion;
using PCodin_Sinlacc.Formularios.CONFIGURACION.Accesos;
using PCodin_Sinlacc.Formularios.Deposito;
using PCodin_Sinlacc.Formularios.Gastos;
using PCodin_Sinlacc.Formularios.INICIO.Login;
using PCodin_Sinlacc.Formularios.MANTENIMIENTO;
using PCodin_Sinlacc.Formularios.MANTENIMIENTO.Registro_de_mantenimiento;
using PCodin_Sinlacc.Formularios.MATERIALES.frmIngresoInsumo;
using PCodin_Sinlacc.Formularios.NOTIFICACION;
using PCodin_Sinlacc.Formularios.Orden_Produccion;
using PCodin_Sinlacc.Formularios.Productos___Insumos;
using PCodin_Sinlacc.Formularios.Secciones;
using PCodin_Sinlacc.Formularios.VENTAS.Lista_de_precio;
using PCodin_Sinlacc.Formularios.VENTAS.Ticket;
using PCodin_Sinlacc.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmLogin : Form
    {
        string Usuario;
        string Clave;
        public Form FormularioInicio;
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ImagenInicio();
        }
        //CARGAR FORMULARIOS
        private frmMostrarMovProduccion MovProduccion = new frmMostrarMovProduccion();
        private frmControlStock ControlStock = new frmControlStock();
        private frmMostrarOrdenProduccion OrdenProduccion = new frmMostrarOrdenProduccion();
        private frmMostrarSecciones Seccion = new frmMostrarSecciones();
        private frmMostrarCircuito CircuitoProd = new frmMostrarCircuito();
        private frmMostrarInsumoProducto GestorInsumoProducto = new frmMostrarInsumoProducto();
        private frmConfiguracion Config = new frmConfiguracion();
        private frmIngresoInsumoMostrar IngresoInsumo = new frmIngresoInsumoMostrar();
        private frmIngresoInsumo IngresoMercaderia = new frmIngresoInsumo();
        private frmMostrarGastos Gastos = new frmMostrarGastos();
        private frmGestorDeClientes GestorCliente = new frmGestorDeClientes();
        private frmMostrarOrdenesCarga OrdenCarga = new frmMostrarOrdenesCarga();
        private frmReporting Estadisticas = new frmReporting();
        private frmRegistroDePedidos NuevoPedido = new frmRegistroDePedidos();
        private frmGestorPersonal GestorPersonal = new frmGestorPersonal();
        private frmDeposito Deposito = new frmDeposito();
        private frmDeposito2 Deposito2 = new frmDeposito2();
        private frmDepositoBase DepositoBase = new frmDepositoBase();
        private frmImportarClientes ImportarCliente = new frmImportarClientes();
        private frmMostrarTicket Ticket = new frmMostrarTicket();
        private frmListaPrecio ListaPrecio = new frmListaPrecio();
        private frmMostrarTipoMantenimiento Mantenimiento = new frmMostrarTipoMantenimiento();
        private frmMostrarRegistroMantenimiento MantenimientoRegistro = new frmMostrarRegistroMantenimiento();
        private frmNotificacionConfigurableMostrar NotificacionConf = new frmNotificacionConfigurableMostrar();
        private frmMenuAcceso MenuAcceso = new frmMenuAcceso();
        private frmCajaMostrar Caja = new frmCajaMostrar();
        private frmCajaUsuarioMostrar CajaUsuario = new frmCajaUsuarioMostrar();
        private void ImagenInicio()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    clsVariablesGenerales.Modo = "Escritorio";

                    var Consulta = (from C in hb.INFOSISTEMA
                                    select C).FirstOrDefault();

                    if (Consulta != null)
                    {
                        if (Consulta.Producto == "PACK-CODIN")
                        {
                            pictureBox2.Image = Resources.Logo_Pack_Codin;
                            clsVariablesGenerales.Aplicacion = "PACK-CODIN";
                        }
                        if (Consulta.Producto == "PACK-SHOP")
                        {
                            pictureBox2.Image = Resources.Logo;
                            clsVariablesGenerales.Aplicacion = "PACK-SHOP";
                        }

                    }

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
           
        }
        
        private void IniciarSistema()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaUsuario = (from U in hb.Usuarios
                                       where U.Nombre == txtUsuario.Text && U.Clave == txtPass.Text
                                       select U);

                var ConsultaClienteUsuario = (from CU in hb.Clientes
                                              where CU.Cliente_Usuario == true
                                              select CU);

                var ConsultaLicencia = (from L in hb.Licencia
                                        select L).FirstOrDefault();

                var ResultadoUsuario = ConsultaUsuario.FirstOrDefault();
                var ResultadoClienteUsuario = ConsultaClienteUsuario.FirstOrDefault();

                if (chkmodoSeguro.Checked == false)
                {
                    if (ResultadoUsuario != null)
                    {

                        DateTime FechaActual = DateTime.Now.Date;

                        //var client = new TcpClient("time.nist.gov", 13);
                        //using (var streamReader = new StreamReader(client.GetStream()))
                        //{
                        //    var response = streamReader.ReadToEnd();
                        //    var utcDateTimeString = response.Substring(7, 17);
                        //    var localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                        //    FechaActual = localDateTime.Date; // DESCOMENTAR PARA QUE FUNCIONE BIEN
                        //    FechaActual = DateTime.Now.Date;
                        //}
                        if (FechaActual < ConsultaLicencia.FechaVencimientoLicencia)
                        {
                            long SesionID = 0;
                            DateTime FechaHoy = DateTime.Now.Date;

                            //CALCULA EL NUMERO DE SESION
                            var ConsultaSesion = (from S in hb.USUARIOSESION
                                                  orderby S.ID descending
                                                  select S).FirstOrDefault();

                            if(ConsultaSesion == null)
                            {
                                SesionID = 1;
                            }
                            else
                            {
                                SesionID = ConsultaSesion.ID + 1;
                            }

                            var NewSesion = new USUARIOSESION();

                            NewSesion.ID = SesionID;
                            NewSesion.Usuario_ID = ResultadoUsuario.ID;
                            NewSesion.Fecha = DateTime.Now;

                            hb.USUARIOSESION.Add(NewSesion);
                            hb.SaveChanges();

                            //AGREGA EL USURIO Y NUMERO DE SESION A LAS VARIABLES GENERALES
                            clsVariablesGenerales.UsuarioID = ResultadoUsuario.ID;
                            clsVariablesGenerales.SesionID = SesionID;
                            FormularioInicio.Hide();
                            this.Hide();

                            //ABRE FORM CARGANDO
                            if(FechaHoy.Day >= 8 && FechaHoy.Day <= 25 && FechaHoy.Month == 12 )
                            {
                                //NAVIDAD
                                var FormCargando = new frmPortada();
                                FormCargando.pnlGeneral.BackgroundImage = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Portadas\PortadaNavidad.png");
                                FormCargando.ShowDialog();
                            }
                            else if(FechaHoy.Day >= 1 && FechaHoy.Day <= 3 && FechaHoy.Month == 1)
                            {
                                //AÑO NUEVO
                                var FormCargando = new frmPortada();
                                FormCargando.pnlGeneral.BackgroundImage = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Portadas\PortadaAnoNuevo.jpg");
                                FormCargando.ShowDialog();
                            }
                            else
                            {
                                var FormCargando = new frmCargandoSistema();
                                FormCargando.ShowDialog();
                            }
                                
                            //ABRE EL SISTEMA
                            var f = new frmMenu();
                            SoundPlayer SonidoIngreso = new SoundPlayer(@"C:\Program Files (x86)\Pack-Codin\Sound\AbrirSistema.wav");
                            f.UsuarioID = ResultadoUsuario.ID;
                            f.Usuarios = ResultadoUsuario.Nombre;
                            
                            if (ResultadoClienteUsuario != null)
                                f.ClienteUsuario = ResultadoClienteUsuario.Descripcion;
                            SonidoIngreso.Play();
                            f.FormularioLogin = this;
                            f.FormularioInicio = (frmInicio)FormularioInicio;

                            //FORMULARIOS
                            f.MovProduccion = new frmMostrarMovProduccion();
                            f. ControlStock = new frmControlStock();
                            f.OrdenProduccion = new frmMostrarOrdenProduccion();
                            f.Seccion = new frmMostrarSecciones();
                            f.CircuitoProd = new frmMostrarCircuito();
                            f.GestorInsumoProducto = new frmMostrarInsumoProducto();
                            f.Config = new frmConfiguracion();
                            f.IngresoInsumo = new frmIngresoInsumoMostrar();
                            f.IngresoMercaderia = new frmIngresoInsumo();
                            f.Gastos = new frmMostrarGastos();
                            f.GestorCliente = new frmGestorDeClientes();
                            f.OrdenCarga = new frmMostrarOrdenesCarga();
                            f.Estadisticas = new frmReporting();
                            f.NuevoPedido = new frmRegistroDePedidos();
                            f.GestorPersonal = new frmGestorPersonal();
                            f.Deposito = new frmDeposito();
                            f.Deposito2 = new frmDeposito2();
                            f.DepositoBase = new frmDepositoBase();
                            f.ImportarCliente = new frmImportarClientes();
                            f.Ticket = new frmMostrarTicket();
                            f.ListaPrecio = new frmListaPrecio();
                            f.Mantenimiento = new frmMostrarTipoMantenimiento();
                            f.MantenimientoRegistro = new frmMostrarRegistroMantenimiento();
                            f.NotificacionConfig = new frmNotificacionConfigurableMostrar();
                            f.MenuAcceso = new frmMenuAcceso();
                            f.Caja = new frmCajaMostrar();
                            f.CajaUsuario = new frmCajaUsuarioMostrar();

                            f.ShowDialog();
                            txtUsuario.Text = "";
                            txtPass.Text = "";
                            txtUsuario.Select();
                            btnIngreso.Enabled = false;
                            


                        }
                        else
                        {
                            MessageBox.Show("La licencia a caducado, por favor comuniquese con el administrador del sistema para habilitarla nuevamente");
                            return;
                        }

                        //else
                        //{
                        //    if (txtPass.Text == "123456")
                        //    {
                        //        var f = new frmMenu();
                        //        SoundPlayer SonidoIngreso = new SoundPlayer(@"C:\Program Files (x86)\Pack-Codin\Sound\AbrirSistema.wav");
                        //        f.UsuarioID = 1;
                        //        f.Usuarios = ResultadoUsuario.Nombre;
                        //        if (ResultadoClienteUsuario != null)
                        //            f.ClienteUsuario = ResultadoClienteUsuario.Descripcion;
                        //        SonidoIngreso.Play();
                        //        f.ShowDialog();
                        //        txtUsuario.Text = "";
                        //        txtPass.Text = "";
                        //        txtUsuario.Select();
                        //        btnIngresar.Enabled = false;
                        //    }
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Usuario o pass incorrectos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (txtPass.Text == "**********")
                    {
                        var f = new frmMenu();
                        SoundPlayer SonidoIngreso = new SoundPlayer(@"C:\Program Files (x86)\Pack-Codin\Sound\AbrirSistema.wav");
                        f.UsuarioID = 1;
                        f.Usuarios ="Modo seguro";
                        if (ResultadoClienteUsuario != null)
                            f.ClienteUsuario = ResultadoClienteUsuario.Descripcion;
                        SonidoIngreso.Play();
                        f.btnLicencia.Enabled = true;
                        f.ShowDialog();
                        txtUsuario.Text = "";
                        txtPass.Text = "";
                        txtUsuario.Select();
                        btnIngreso.Enabled = false;
                    }
                }

            }
        }
        private void OnOffbtnIngresar()
        {
            if (txtUsuario.TextLength > 0 && txtPass.TextLength > 0)
                btnIngreso.Enabled = true;
            else
                btnIngreso.Enabled = false;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnIngresar();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnIngresar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OnOffbtnIngresar();
        }
        
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IniciarSistema();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Convert.ToChar(Keys.Alt))
            //{
            //    chkmodoSeguro.Visible = true;
            //}
            //else
            //{
            //    chkmodoSeguro.Visible = false;
            //}
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Usuario = txtUsuario.Text;
                txtUsuario.Text = Usuario.Replace(" ", string.Empty);                           
                e.Handled = true;
                //this.Hide();
                IniciarSistema();              
            } 
        }
        
        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Clave = txtPass.Text;
                txtPass.Text = Clave.Replace(" ", string.Empty);
                e.Handled = true;
                IniciarSistema();
            }
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IniciarSistema();
        }

        private void btnModoEscritorio_Click(object sender, EventArgs e)
        {
            clsVariablesGenerales.Modo = "Escritorio";
            btnModoEscritorio.BackColor = Color.Orange;
            btnModoMobile.BackColor = Color.Transparent;
        }

        private void btnModoMobile_Click(object sender, EventArgs e)
        {
            clsVariablesGenerales.Modo = "Mobile";
            btnModoEscritorio.BackColor = Color.Transparent;
            btnModoMobile.BackColor = Color.Orange;
        }
        private void Teclado(TextBox txtSeleccionado)
        {
            var f = new frmTecladoVirtual();
            f.txtSelecionado = txtSeleccionado;
            f.txtResultado.Text = txtSeleccionado.Text;
            f.ShowDialog();
        }
        private void txtUsuario_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);

            //if (clsVariablesGenerales.Modo == "Mobile")
            //{
            //    var txtSeleccionado = sender as TextBox;
            //    Teclado(txtSeleccionado);
            //}
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
        private void btnActualizarLicencia_Click(object sender, EventArgs e)
        {
            RenovarConsultaLicencia();
        }
    }
}
