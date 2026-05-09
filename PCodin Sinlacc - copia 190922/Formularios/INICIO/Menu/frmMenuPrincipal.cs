using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Clases.Notificaciones_Ejecutables.Humano;
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Formularios.CAJA;
using PCodin_Sinlacc.Formularios.Circuito_Productivo;
using PCodin_Sinlacc.Formularios.Configuracion;
using PCodin_Sinlacc.Formularios.CONFIGURACION.Accesos;
using PCodin_Sinlacc.Formularios.Deposito;
using PCodin_Sinlacc.Formularios.Gastos;
using PCodin_Sinlacc.Formularios.MANTENIMIENTO;
using PCodin_Sinlacc.Formularios.MANTENIMIENTO.Registro_de_mantenimiento;
using PCodin_Sinlacc.Formularios.MATERIALES.frmIngresoInsumo;
using PCodin_Sinlacc.Formularios.Menu;
using PCodin_Sinlacc.Formularios.Notificación;
using PCodin_Sinlacc.Formularios.NOTIFICACION;
using PCodin_Sinlacc.Formularios.Orden_Produccion;
using PCodin_Sinlacc.Formularios.Productos___Insumos;
using PCodin_Sinlacc.Formularios.Secciones;
using PCodin_Sinlacc.Formularios.VENTAS;
using PCodin_Sinlacc.Formularios.VENTAS.Lista_de_precio;
using PCodin_Sinlacc.Formularios.VENTAS.Ticket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using Twilio.Http;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PCodin_Sinlacc
{
    public partial class frmMenu : Form
    {
        private int OcultarMostrarMenu;
        public int UsuarioID;
        public string Usuarios;
        public string ClienteUsuario;
        int IndiceModulo = 0;
        string NombreFormAbierto; // Propiedad Name del form en pantalla
        string NombreNodoFormAbierto; // Nombre del btn del nodo que tiene el form mostrando en pantalla
        string EstadoMenu; // Indica como esta el estado del menu si contraido o normal
        string ColorNodos;
        string ColorSubNodos;
        string ColorMenu;

        public frmLogin FormularioLogin;
        public frmInicio FormularioInicio;
        public frmReporte FormularioReportes;

        List<string> ListaFormulariosAbiertosBoton = new List<string>();
        List<string> ListaFormulariosAbiertosForm = new List<string>();
        // List<object> ListaFormAbiertos = new List<object>();

        public frmMenu()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);
            this.FormClosing += new FormClosingEventHandler(frmPrueba2_FormClosing);
        }

        private void frmPrueba2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            CerrarSeccion();
            //  Application.Exit();
        }
        public void AbrirFormulariosHijos(object FormHijo)
        {
            if (this.pnlCentral.Controls.Count > 0)
            {
                this.pnlCentral.Controls.RemoveAt(0);
            }
            Form f = FormHijo as Form;
            f.TopLevel = false;
            this.pnlCentral.Controls.Add(f);
            this.pnlCentral.Tag = f;
            f.Show();

        }
        private void CerrarSeccion()
        {
            DialogResult R = System.Windows.Forms.MessageBox.Show("¿Está seguro que desea cerrar sesion?. Se borraran los datos o movimientos que no estén finalizados", "Atención", MessageBoxButtons.YesNo);
            if (R == DialogResult.Yes)
            {
                SoundPlayer SonidoSalida = new SoundPlayer(@"C:\Program Files (x86)\Pack-Codin\Sound\CerrarSistema.wav");
                SonidoSalida.Play();
                System.Windows.Forms.Application.Exit();
            }
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            RenderizarForm();
            InicializarForm();
            FormularioLogin.Hide();
            FormularioInicio.Hide();          
        }
        private void RenderizarForm()
        {
            clsVariablesGenerales.WPantalla = (int)SystemParameters.FullPrimaryScreenWidth + 20;
            clsVariablesGenerales.HPantalla = (int)SystemParameters.FullPrimaryScreenHeight + 20;

            using (var hb = new DBdatos())
            {
                var ConsultaPantalla = (from C in hb.USUARIOCONFIG
                                         where C.Usuario_ID == UsuarioID
                                         select C).FirstOrDefault();

                if(ConsultaPantalla != null)
                {
                    clsVariablesGenerales.WPantalla = (int)ConsultaPantalla.AnchoPantalla;
                    clsVariablesGenerales.HPantalla = (int)ConsultaPantalla.AltoPantalla;
                }
            
            }

            // clsVariablesGenerales.WPantalla = (int)SystemParameters.FullPrimaryScreenWidth + 20;
            //clsVariablesGenerales.HPantalla = (int)SystemParameters.FullPrimaryScreenHeight + 20;


           


            this.Size = new System.Drawing.Size((int)clsVariablesGenerales.WPantalla, clsVariablesGenerales.HPantalla);
//            this.Size = new System.Drawing.Size((int)SystemParameters.FullPrimaryScreenWidth, (int)SystemParameters.FullPrimaryScreenHeight + 20);
            this.Location = new System.Drawing.Point(0, 0);
            pnlCentral.Size = new System.Drawing.Size(this.Width - pnlMenu.Width, this.Height - pnlSuperior.Height);

            clsVariablesGenerales.WpnlCentral = this.Width - pnlMenu.Width;
            clsVariablesGenerales.HpnlCentral = this.Height - pnlSuperior.Height;

        }
        private void DefinirVersion()
        {
            if(clsVariablesGenerales.Modo == "Mobile")
            {
                pnlMenu.Width = 100;
                treeView1.Visible = false;
                pnlMenuMobile.Visible = true;
                btnDesplegarMenu.Visible = false;
                lblUsuario.Text = "";
                lblCliente.Text = "";
                pnlinfoSesion.Visible = false;
                //picUsuario.Dock = DockStyle.Top;
                //picCliente.Dock = DockStyle.Top;
                //picUsuario.Height = 31;
                //picCliente.Height = 31;
            }
        }
        private void DefinirProducto()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.INFOSISTEMA
                                select C).FirstOrDefault();

                if (Consulta.Producto == "PACK-CODIN")
                {
                    picPackCodin.Visible = true;
                    picPackShop.Visible = false;
                }
                if (Consulta.Producto == "PACK-SHOP")
                {
                    picPackCodin.Visible = false;
                    picPackShop.Visible = true;
                }

            }
        }
        private void InicializarForm()
        {
            DefinirProducto();
            DefinirVersion();
            VerificarUsuario();
            Clases.Formularios.Inicio.frmMenu.pnlCentral2 = new System.Windows.Forms.Panel();
            //clsUsuarioTema.UsuarioTemaMenuPrincipal(UsuarioID, lblCliente , pnlSuperior);
            clsVariablesGenerales.pnlCentral = new System.Windows.Forms.Panel();
            // ABRE FORM DE KPI 
            var Indicador = new frmIndicadores();
            Indicador.UsuarioID = UsuarioID;
            FormularioReportes = new frmReporte();
            Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Indicadores.png");
            AbrirFormulariosEnPanel.AbrirFormulariosHijos(Indicador, pnlCentral, lblTituloForm);
            GuardarFormSesionesAbiertas("asd", "frmIndicadores", "Indicadores", 0,"NO");
            NombreFormAbierto = "frmIndicadores";
            lblTituloForm.Text = "Indicadores";
            //clsNotificacion.NotificarFechaLimiteOrdenProduccion(UsuarioID);
            //clsNotificacion.MostrarCantidadNotificacionesNoLeidas(lblCantidadNotificaciones);          
        }
        private void DefinirColorNodosSegunTema(ref string ColorNodos)
        {
            using (var hb = new DBdatos())
            {
                var ConsultaTema = (from UT in hb.USUARIOTEMA
                                    where UT.Usuario == UsuarioID
                                    select UT).FirstOrDefault();

                if (ConsultaTema.Tema == "PACK-CODIN")
                {
                    ColorNodos = "Sienna";
                    ColorSubNodos = "Black";
                    ColorMenu = "WhiteSmoke";
                }
                if (ConsultaTema.Tema == "PINKY")
                {                    
                    ColorNodos = "DarkMagenta";
                    ColorSubNodos = "Black";
                    ColorMenu = "LavenderBlush";
                }
                if (ConsultaTema.Tema == "CARBON")
                {
                    ColorNodos = "MediumTurquoise";
                    ColorSubNodos = "White";
                    ColorMenu = "DimGray";
                }
            }
        }
        private void VerificarUsuario()
        {
           
            using (var hb = new DBdatos())
            {
                DefinirColorNodosSegunTema(ref ColorNodos);

                List<string> ListaItemModulosHabilitados = new List<string>();
                List<int> ListaModulosEliminar = new List<int>();
                List<string> ListaItemEliminar = new List<string>();

                var ConsultaItemhabilitados = (from AU in hb.Acceso_Usuario
                                               where AU.Usuario_ID == UsuarioID
                                               && AU.Menu_Item.Tipo != "Informe"
                                               orderby AU.Menu_Item.Descripcion
                                               select AU).ToList();

                var ConsultaModulosHabilitados = (from AU in hb.Acceso_Usuario
                                                  where AU.Menu_ID == AU.Menu_Item.ID 
                                                        && AU.Usuario_ID == UsuarioID
                                                        && AU.Menu_Item.Tipo != "Informe"
                                                  group AU by new { AU.Menu_Item.Modulos.NombreBoton, AU.Menu_Item.Modulo_ID , AU.Menu_Item.Modulos.Nombre } into Grupo
                                                  orderby Grupo.Key.Nombre                                               
                                                  select new
                                                  {
                                                      Grupo.Key.NombreBoton,
                                                      Grupo.Key.Modulo_ID,
                                                      Grupo.Key.Nombre
                                                  }).ToList();
              
                foreach(var Modulos in ConsultaModulosHabilitados)
                {                  
                    if (Modulos.NombreBoton.StartsWith("M"))
                    {                      
                        int ModuloID = (int)Modulos.Modulo_ID;

                        treeView1.Nodes.Add(Name = Modulos.NombreBoton, text: Modulos.Nombre);
                        if(ColorNodos.Contains(";"))
                        {
                            ColorNodos.Replace(";", ",");
                            //treeView1.Nodes[IndiceModulo].ForeColor = Color.FromArgb(ColorNodos);
                        }
                        else
                        {
                            treeView1.Nodes[IndiceModulo].ForeColor = Color.FromName(ColorNodos); //Color.PowderBlue;
                            treeView1.ForeColor = Color.FromName(ColorSubNodos);
                            treeView1.BackColor = Color.FromName(ColorMenu);
                        }                     
                        treeView1.Nodes[IndiceModulo].NodeFont = new Font("Roboto", 11);

                        foreach (var Items in ConsultaItemhabilitados)
                        {
                            if (Items.Menu_Item.Modulo_ID == ModuloID)
                            {                              
                                treeView1.Nodes[IndiceModulo].Nodes.Add(Name = Items.Menu_Item.Boton, text: Items.Menu_Item.Descripcion);
                            }
                        }
                        IndiceModulo = IndiceModulo + 1;
                    }
                }
               
                if(clsVariablesGenerales.Modo == "Escritorio")
                {
                    lblUsuario.Text = Usuarios;
                    lblCliente.Text = ClienteUsuario;
                }
                if (clsVariablesGenerales.Modo == "Mobile")
                {
                    lblUsuarioMOBILE.Text = Usuarios;
                    lblClienteMobile.Text = ClienteUsuario;
                }
                if (Usuarios == "Modo seguro")
                {
                    btnLicencia.Visible = true;
                }
            }
        }    
        private void button1_Click(object sender, EventArgs e)
        {

            //  AbrirFormulariosEnPanel.AbrirFormulariosHijos(q,pnlCentral);
            //  picIconoCabezal.Image = button1.Image;
        }
       
        private frmMostrarInsumoProducto f = new frmMostrarInsumoProducto();
        private void NotificarCumpleaños()
        {
            DateTime Fecha = DateTime.Now.Date;

            using (var hb = new DBdatos())
            {
                var ConsultaCumpleaños = (from EMP in hb.Empleados
                                          where EMP.Fecha_Nacimiento.Day == Fecha.Day
                                                && EMP.Fecha_Nacimiento.Month == Fecha.Month
                                          && EMP.Estado == "SI"
                                          select EMP);



                var ResultadosCumpleaños = ConsultaCumpleaños.ToList();

                if (ResultadosCumpleaños.Count > 0)
                {
                    foreach (var item in ResultadosCumpleaños)
                    {
                        var C = new Notificaciones();

                        C.Fecha = Fecha;
                        C.Hora = DateTime.Now.TimeOfDay;
                        C.Tipo_ID = 2;
                        C.Descripcion = "Hoy es el cumpleaños de " + item.Nombre + " le deseamos lo mejor en su día";
                        C.Leida = "NO";

                        var ConsultaNotificacion = (from N in hb.Notificaciones
                                                    where N.Descripcion == "Hoy es el cumpleaños de " + item.Nombre + " le deseamos lo mejor en su día"
                                                        && N.Fecha == Fecha
                                                    select N).FirstOrDefault();

                        if (ConsultaNotificacion == null)
                        {
                            hb.Notificaciones.Add(C);
                            hb.SaveChanges();

                            var f = new frmAlertas();
                            f.Cumpleañero = item.Nombre;
                            f.Tipo = "Cumpleaños";
                            f.ShowDialog();
                        }
                    }

                }
            }
        }
        private void picPackCodin_Click(object sender, EventArgs e)
        {
            var Indicador = new frmIndicadores();
            Indicador.UsuarioID = UsuarioID;
            Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Indicadores.png");
            AbrirFormulariosEnPanel.AbrirFormulariosHijos(Indicador, pnlCentral, lblTituloForm);
            lblTituloForm.Text = "Indicadores";
            GuardarFormSesionesAbiertas("asd", "frmIndicadores", "Indicadores", 0, "NO");
            NombreFormAbierto = "frmIndicadores";
        }
        private frmGestorDeUsuarios Usuario = new frmGestorDeUsuarios();
   
        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            clsNotificacion.MostrarCantidadNotificacionesNoLeidas(lblCantidadNotificaciones);
            var f = new frmNotificaciones();
            AbrirFormulariosEnPanel.AbrirFormulariosHijos(f, pnlCentral, lblTituloForm);
            f.FormMenu = this;
            lblTituloForm.Text = "Notificaciones";
            picIconoCabezal.Image = System.Drawing.Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Notificacion.png");
            GuardarFormSesionesAbiertas("btnNotificaciones", "frmNotificaciones", "Notificaciones", 0,"NO");
            NombreFormAbierto = "frmNotificaciones";
            NombreNodoFormAbierto = "btnNotificaciones";
            f.UsuarioID = UsuarioID;
            Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
        }
        private void btningresarLicencia_Click(object sender, EventArgs e)
        {
            if (txtIngresoLicencia.TextLength > 0)
            {
                if (txtIngresoLicencia.Text == "123456")
                {
                    pnlLicencia.Visible = true;

                    using (var hb = new DBdatos())
                    {
                        var Consulta = (from L in hb.Licencia
                                        select L).FirstOrDefault();

                        if (Consulta == null)
                        {
                            System.Windows.MessageBox.Show("El cliente no tiene Licencia, por favor seleccione un fecha de vencimiento");
                            dtpFechaVenc.Value = DateTime.Now.Date;
                        }
                        else
                        {
                            dtpFechaVenc.Value = Consulta.FechaVencimientoLicencia.Value;
                        }
                        dtpFechaVenc.Visible = true;
                        btnAceptar.Visible = true;
                        btnSalir.Visible = true;
                    }
                }
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            txtIngresoLicencia.Text = "";
            dtpFechaVenc.Visible = false;
            btnAceptar.Visible = false;
            btnSalir.Visible = false;
            pnlLicencia.Visible = false;
        }
        private void btnLicencia_Click(object sender, EventArgs e)
        {
            var f = new frmLicencia();
            f.ShowDialog();
        }

     
        private void GuardarFormSesionesAbiertas(string btnName , string formName ,string Text , int LocImagen , string EstaDentroMenuPrincipal)
        {
            if(!ListaFormulariosAbiertosBoton.Contains(btnName))
            {
                ListaFormulariosAbiertosBoton.Add(btnName);
                ListaFormulariosAbiertosForm.Add(formName);
                clsVariablesGenerales.ListaFormAbiertos.Add(formName);
                //treeView2.ImageList = imageList1;

                if (EstaDentroMenuPrincipal == "SI")
                    treeView2.Nodes.Add(Name = btnName, text: Text);             
            }
        }

        public frmMostrarMovProduccion MovProduccion;
        public frmControlStock ControlStock;
        public frmMostrarOrdenProduccion OrdenProduccion;
        public frmMostrarSecciones Seccion;
        public frmMostrarCircuito CircuitoProd;
        public frmMostrarInsumoProducto GestorInsumoProducto;
        public frmConfiguracion Config;
        public frmIngresoInsumoMostrar IngresoInsumo;
        public frmIngresoInsumo IngresoMercaderia;
        public frmMostrarGastos Gastos;
        public frmGestorDeClientes GestorCliente;
        public frmMostrarOrdenesCarga OrdenCarga;
        public frmReporting Estadisticas;
        public frmRegistroDePedidos NuevoPedido;
        public frmAgregarNuevoPedidoMOB NuevoPedidoMOB;
        public frmGestorPersonal GestorPersonal;
        public frmDeposito Deposito;
        public frmDeposito2 Deposito2;
        public frmDepositoBase DepositoBase;
        public frmImportarClientes ImportarCliente;
        public frmMostrarTicket Ticket;
        public frmListaPrecio ListaPrecio;
        public frmMostrarTipoMantenimiento Mantenimiento;
        public frmMostrarRegistroMantenimiento MantenimientoRegistro;
        public frmNotificacionConfigurableMostrar NotificacionConfig;
        public frmMenuAcceso MenuAcceso;
        public frmCajaMostrar Caja;
        public frmCajaUsuarioMostrar CajaUsuario;









        //private frmMostrarMovProduccion MovProduccion = new frmMostrarMovProduccion();
        //private frmControlStock ControlStock = new frmControlStock();
        //private frmMostrarOrdenProduccion OrdenProduccion = new frmMostrarOrdenProduccion();
        //private frmMostrarSecciones Seccion = new frmMostrarSecciones();
        //private frmMostrarCircuito CircuitoProd = new frmMostrarCircuito();
        //private frmMostrarInsumoProducto GestorInsumoProducto = new frmMostrarInsumoProducto();
        //private frmConfiguracion Config = new frmConfiguracion();
        //private frmIngresoInsumoMostrar IngresoInsumo = new frmIngresoInsumoMostrar();
        //private frmIngresoInsumo IngresoMercaderia = new frmIngresoInsumo();
        //private frmMostrarGastos Gastos = new frmMostrarGastos();
        //private frmGestorDeClientes GestorCliente = new frmGestorDeClientes();
        //private frmMostrarOrdenesCarga OrdenCarga = new frmMostrarOrdenesCarga();
        //private frmReporting Estadisticas = new frmReporting();
        //private frmRegistroDePedidos NuevoPedido = new frmRegistroDePedidos();
        //private frmGestorPersonal GestorPersonal = new frmGestorPersonal();
        //private frmDeposito Deposito = new frmDeposito();
        //private frmDeposito2 Deposito2 = new frmDeposito2();
        //private frmDepositoBase DepositoBase = new frmDepositoBase();
        //private frmImportarClientes ImportarCliente = new frmImportarClientes();
        //private frmMostrarTicket Ticket = new frmMostrarTicket();
        //private frmListaPrecio ListaPrecio = new frmListaPrecio();


        private void MostrarFormConEspera()
        {
            using (var dialogo = new PantallaEspera2(MostrarDeposito, "Cargando depósito"))
            {
                dialogo.ShowDialog(this);
                
                Deposito = new frmDeposito();              
                Deposito.Formulario = Deposito;              
                Deposito.TopMost = true;
                Deposito.Show();                          
            }
        }
        public void MostrarDeposito()
        {
            
            using (var hb = new DBdatos())
            {
                var ConsultaConfig = (from C in hb.PcnConfiguraciones
                                      select C).FirstOrDefault();

                Deposito.Accion = "";

                if (ConsultaConfig.TipoDeposito == "Base")
                {
                    var f = new frmDepositoBase();
                    f.TopMost = true;
                    f.Show();

                    // DepositoBase.Formulario = Deposito;
                    DepositoBase.TopMost = true;
                    DepositoBase.Show();
                }
                else
                {
                    Deposito.Formulario = Deposito;
                    Deposito.InicializarForm();
                    //Deposito.TopMost = true;
                    //Deposito.Show();
                }
            }
        }
        private void frmPantallaEspera_Shown(object sender, EventArgs e)
        {
            
            
           
        }

        private void AbrirFormSegunNodoSeleccionado(TreeNodeMouseClickEventArgs e , string EstaAbierto)
        {
            if (treeView1.SelectedNode != null)
            {
                             
                if (e.Node.Name == "btnMnuMovimientosProd")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuMovimientosProd"))
                    {
                        MovProduccion = new frmMostrarMovProduccion();
                        MovProduccion.FormularioMenu = this;
                    }
                    MovProduccion.UsuarioID = UsuarioID;                   
                    MovProduccion.FormularioDeposito = Deposito;
                    MovProduccion.FormularioDeposito2 = Deposito2;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Movimientos de produccion.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(MovProduccion, pnlCentral, lblTituloForm);
                    MovProduccion.PanelCental = pnlCentral;
                    lblTituloForm.Text = "Movimientos de producción";
                    GuardarFormSesionesAbiertas("btnMnuMovimientosProd", "frmMostrarMovProduccion", "Movimientos de producción", 0,"SI");
                    NombreFormAbierto = "frmMostrarMovProduccion";
                    NombreNodoFormAbierto = "btnMnuMovimientosProd";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuControlStock")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuControlStock"))
                    {
                        ControlStock = new frmControlStock();
                    }

                    
                    ControlStock.UsuarioID = UsuarioID;
                    ControlStock.FormularioReporte = this.FormularioReportes;

                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Stock.png");
                   
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(ControlStock, pnlCentral, lblTituloForm);

                    lblTituloForm.Text = "Inteligencia de stock";

                   if (EstaAbierto == "NO")
                        GuardarFormSesionesAbiertas("btnMnuControlStock", "frmControlStock", "Inteligencia de stock", 1, "SI");

                    NombreFormAbierto = "frmControlStock";
                    NombreNodoFormAbierto = "btnMnuControlStock";

                   foreach(var Nodo in treeView2.Nodes)
                    {
                        if(((System.Windows.Forms.TreeNode)Nodo).Name == NombreNodoFormAbierto)
                        {
                            ((System.Windows.Forms.TreeNode)Nodo).ImageIndex = 1;
                        }
                    }
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuOrdenProd")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuOrdenProd"))
                    {
                        OrdenProduccion = new frmMostrarOrdenProduccion();
                    }

                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Orden de produccion.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(OrdenProduccion, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Orden de producción";
                    GuardarFormSesionesAbiertas("btnMnuOrdenProd", "frmMostrarOrdenProduccion", "Orden de producción", 2, "SI");
                    NombreFormAbierto = "frmMostrarOrdenProduccion";
                    NombreNodoFormAbierto = "btnMnuOrdenProd";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuDeposito")
                {
                    //MostrarFormConEspera();
                    using (var hb = new DBdatos())
                    {
                        var ConsultaConfig = (from C in hb.PcnConfiguraciones
                                              select C).FirstOrDefault();

                        Deposito.Accion = "";

                        if (ConsultaConfig.TipoDeposito == "Base")
                        {
                            var f = new frmDepositoBase();
                            f.TopMost = true;
                            f.Show();

                            //DepositoBase.Formulario = Deposito;
                            //DepositoBase.TopMost = true;
                            //DepositoBase.Show();
                        }
                        else
                        {
                            Deposito.Formulario = Deposito;
                            Deposito.TopMost = true;
                            Deposito.Show();
                        }
                    }
                }
                if (e.Node.Name == "btnMnuSecciones")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuSecciones"))
                    {
                        Seccion = new frmMostrarSecciones();
                    }

                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Seccion.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Seccion, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Secciones";
                    GuardarFormSesionesAbiertas("btnMnuSecciones", "frmMostrarSecciones", "Secciones", 3, "SI");
                    NombreFormAbierto = "frmMostrarSecciones";
                    NombreNodoFormAbierto = "btnMnuSecciones";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuCirProd")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuCirProd"))
                    {
                        CircuitoProd = new frmMostrarCircuito();
                    }

                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/CircuitoProd.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(CircuitoProd, pnlCentral, lblTituloForm);
                    CircuitoProd.UsuarioID = UsuarioID;
                    CircuitoProd.AA = UsuarioID;
                    lblTituloForm.Text = "Circuito productivo";
                    GuardarFormSesionesAbiertas("btnMnuCirProd", "frmMostrarCircuito", "Circuito productivo", 4, "SI");
                    NombreFormAbierto = "frmMostrarCircuito";
                    NombreNodoFormAbierto = "btnMnuCirProd";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuGestInsuProd")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuGestInsuProd"))
                    {
                        GestorInsumoProducto = new frmMostrarInsumoProducto();
                    }

                    GestorInsumoProducto.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Gestor de inspro.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(GestorInsumoProducto, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Gestor de insumos / productos";
                    GuardarFormSesionesAbiertas("btnMnuGestInsuProd", "frmMostrarInsumoProducto", "Gestor de insumos / productos", 5, "SI");
                    ListaFormulariosAbiertosForm.Add("frmMostrarInsumoProducto");
                    NombreFormAbierto = "frmMostrarInsumoProducto";
                    NombreNodoFormAbierto = "btnMnuGestInsuProd";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuIngresarIns")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuIngresarIns"))
                    {
                        IngresoInsumo = new frmIngresoInsumoMostrar();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Ingreso insumos.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(IngresoInsumo, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Ingreso de articulos";
                    GuardarFormSesionesAbiertas("btnMnuIngresarIns", "frmIngresoInsumoMostrar", "Ingreso de articulos", 6, "SI");
                    NombreFormAbierto = "frmIngresoInsumoMostrar";
                    NombreNodoFormAbierto = "btnMnuIngresarIns";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                //if (e.Node.Name == "btnMnuIngresoMercaderia")
                //{
                //    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuIngresoMercaderia"))
                //    {
                //        IngresoMercaderia = new frmIngresoInsumo();
                //    }
                //    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Ingreso insumos.png");
                //    AbrirFormulariosEnPanel.AbrirFormulariosHijos(IngresoInsumo, pnlCentral, lblTituloForm);
                //    lblTituloForm.Text = "Ingreso mercaderia";
                //    GuardarFormSesionesAbiertas("btnMnuIngresoMercaderia", "frmIngresoInsumo", "Ingreso mercaderia", 6, "SI");
                //    NombreFormAbierto = "frmIngresoInsumo";
                //    NombreNodoFormAbierto = "btnMnuIngresoMercaderia";
                //}
                if (e.Node.Name == "btnMnuGastos")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuGastos"))
                    {
                        Gastos = new frmMostrarGastos();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Gastos.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Gastos, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Cobros";
                    GuardarFormSesionesAbiertas("btnMnuGastos", "frmMostrarGastos", "Cobros", 7, "SI");
                    NombreFormAbierto = "frmMostrarGastos";
                    NombreNodoFormAbierto = "btnMnuGastos";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuRegistroPedidos")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuRegistroPedidos"))
                    {
                       
                            NuevoPedido = new frmRegistroDePedidos();
                            NuevoPedido.FormMenu = this;
                       
                                                                          
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Registro Pedidos.png");
                   
                        AbrirFormulariosEnPanel.AbrirFormulariosHijos(NuevoPedido, pnlCentral, lblTituloForm);
                        NombreFormAbierto = "frmRegistroDePedidos";
                        GuardarFormSesionesAbiertas("btnMnuRegistroPedidos", "frmRegistroDePedidos", "Registro de pedido", 8, "SI");
                    

                    //if (clsVariablesGenerales.Modo == "Mobile")
                    //{
                    //    AbrirFormulariosEnPanel.AbrirFormulariosHijos(NuevoPedidoMOB, pnlCentral, lblTituloForm);
                    //    NombreFormAbierto = "frmRegistroDePedidosMOB";
                    //    GuardarFormSesionesAbiertas("btnMnuRegistroPedidos", "frmRegistroDePedidosMOB", "Registro de pedido", 8, "SI");
                    //}

                    lblTituloForm.Text = "Registro de pedido";
                    GuardarFormSesionesAbiertas("btnMnuRegistroPedidos", "frmRegistroDePedidos", "Registro de pedido", 8, "SI");
                    NombreFormAbierto = "frmRegistroDePedidos";
                    NombreNodoFormAbierto = "btnMnuRegistroPedidos";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuOrdenCarga")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuOrdenCarga"))
                    {
                        OrdenCarga = new frmMostrarOrdenesCarga();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Orden carga.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(OrdenCarga, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Orden de carga";
                    GuardarFormSesionesAbiertas("btnMnuOrdenCarga", "frmMostrarOrdenesCarga", "Orden de carga", 0, "SI");
                    NombreFormAbierto = "frmMostrarOrdenesCarga";
                    NombreNodoFormAbierto = "btnMnuOrdenCarga";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuTicket")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuTicket"))
                    {
                        Ticket = new frmMostrarTicket();                      
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Ticket.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Ticket, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Ticket";
                    GuardarFormSesionesAbiertas("btnMnuTicket", "frmMostrarTicket", "Ticket", 8, "SI");
                    NombreFormAbierto = "frmMostrarTicket";
                    NombreNodoFormAbierto = "btnMnuTicket";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuListaPrecio")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuListaPrecio"))
                    {
                        ListaPrecio = new frmListaPrecio();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/ListaPrecio.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(ListaPrecio, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Lista de Precio";
                    GuardarFormSesionesAbiertas("btnMnuListaPrecio", "frmListaPrecio", "Lista de Precio", 8, "SI");
                    NombreFormAbierto = "frmListaPrecio";
                    NombreNodoFormAbierto = "btnMnuListaPrecio";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuGestorPersonal")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuGestorPersonal"))
                    {
                        GestorPersonal = new frmGestorPersonal();
                    }
                    
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Gestor de personal.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(GestorPersonal, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Gestor de pesonal";
                    GuardarFormSesionesAbiertas("btnMnuGestorPersonal", "frmGestorPersonal", "Gestor de personal", 0, "SI");
                    NombreFormAbierto = "frmGestorPersonal";
                    NombreNodoFormAbierto = "btnMnuGestorPersonal";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuClientes")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuClientes"))
                    {
                        GestorCliente = new frmGestorDeClientes();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Clientes.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(GestorCliente, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Gestor de clientes";
                    GuardarFormSesionesAbiertas("btnMnuClientes", "frmGestorDeClientes", "Gestor de clientes", 0, "SI");
                    NombreFormAbierto = "frmGestorDeClientes";
                    NombreNodoFormAbierto = "btnMnuClientes";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuImportarClientes")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuImportarClientes"))
                    {
                        ImportarCliente = new frmImportarClientes();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Importador.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(ImportarCliente, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Importador de clientes y proveedores";
                    GuardarFormSesionesAbiertas("btnMnuImportarClientes", "frmImportarClientes", "Importador de clientes y proveedores", 0, "SI");
                    NombreFormAbierto = "frmImportarClientes";
                    NombreNodoFormAbierto = "btnMnuImportarClientes";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuEstadisticas")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuEstadisticas"))
                    {
                        Estadisticas = new frmReporting();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Informes.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Estadisticas, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Reporting";
                    GuardarFormSesionesAbiertas("btnMnuEstadisticas", "frmReporting", "Reporting", 0, "SI");
                    NombreFormAbierto = "frmReporting";
                    NombreNodoFormAbierto = "btnMnuEstadisticas";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuGestorUsuarios")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuGestorUsuarios"))
                    {
                        Usuario = new frmGestorDeUsuarios();
                    }

                    Usuario.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/GestorUsuario.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Usuario, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Gestor de usuarios";
                    GuardarFormSesionesAbiertas("btnMnuGestorUsuarios", "frmGestorDeUsuarios", "Gestor de usuarios", 0, "SI");
                    NombreFormAbierto = "frmGestorDeUsuarios";
                    NombreNodoFormAbierto = "btnMnuGestorUsuarios";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuCopiaSeguridad")
                {

                    var CopiaSeguridad = new frmBackup();
                    CopiaSeguridad.Usario_ID = UsuarioID;
                    CopiaSeguridad.ShowDialog();
                    //AbrirFormulariosEnPanel.AbrirFormulariosHijos(CopiaSeguridad, pnlCentral, lblTituloForm);
                    //lblTituloForm.Text = "Copia de seguridad";
                    //picIconoCabezal.Image = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Copia de seguridad.png");
                    //Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMnuConfig")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuConfig"))
                    {
                        Config = new frmConfiguracion();
                    }
                    Config.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Configuracion.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Config, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Configuración";
                    GuardarFormSesionesAbiertas("btnMnuConfig", "frmConfiguracion", "Configuración", 0, "SI");
                    NombreFormAbierto = "frmConfiguracion";
                    NombreNodoFormAbierto = "btnMnuConfig";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMantenimiento")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMantenimiento"))
                    {
                        Mantenimiento = new frmMostrarTipoMantenimiento();
                    }

                    Usuario.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Mod_Mantenimiento.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Mantenimiento, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Mantenimientos";
                    GuardarFormSesionesAbiertas("btnMantenimiento", "frmMostrarTipoMantenimiento", "Mantenimientos", 0, "SI");
                    NombreFormAbierto = "frmMostrarTipoMantenimiento";
                    NombreNodoFormAbierto = "btnMantenimiento";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnRegistroMantenimiento")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnRegistroMantenimiento"))
                    {
                        MantenimientoRegistro = new frmMostrarRegistroMantenimiento();
                    }

                    Usuario.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Mod_Mantenimiento.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(MantenimientoRegistro, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Registro de mantenimiento";
                    GuardarFormSesionesAbiertas("btnRegistroMantenimiento", "frmMostrarRegistroMantenimiento", "Registro de mantenimiento", 0, "SI");
                    NombreFormAbierto = "frmMostrarRegistroMantenimiento";
                    NombreNodoFormAbierto = "btnRegistroMantenimiento";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnNotiConf")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnNotiConf"))
                    {
                        NotificacionConfig = new frmNotificacionConfigurableMostrar();
                    }

                    Usuario.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/NotificacionConfigurable.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(NotificacionConfig, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Notificacion configurable";
                    GuardarFormSesionesAbiertas("btnNotiConf", "frmNotificacionConfigurableMostrar", "Notificacion configurable", 0, "SI");
                    NombreFormAbierto = "frmNotificacionConfigurableMostrar";
                    NombreNodoFormAbierto = "btnNotiConf";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnMenuAccesos")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMenuAccesos"))
                    {
                        MenuAcceso = new frmMenuAcceso();
                    }

                    Usuario.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Mod_Mantenimiento.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(MenuAcceso, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Accesos";
                    GuardarFormSesionesAbiertas("btnMenuAccesos", "frmMenuAcceso", "Accesos", 0, "SI");
                    NombreFormAbierto = "frmMenuAcceso";
                    NombreNodoFormAbierto = "btnMenuAccesos";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);

                }
                if (e.Node.Name == "btnMnuCaja")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuCaja"))
                    {
                        Caja = new frmCajaMostrar();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Caja.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Caja, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Cajas";
                    GuardarFormSesionesAbiertas("btnMnuCaja", "frmCajaMostrar", "Cajas", 0, "SI");
                    NombreFormAbierto = "frmCajaMostrar";
                    NombreNodoFormAbierto = "btnMnuCaja";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (e.Node.Name == "btnCajaUsuario")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnCajaUsuario"))
                    {
                        CajaUsuario = new frmCajaUsuarioMostrar();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Caja.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(CajaUsuario, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Caja Movimientos";
                    GuardarFormSesionesAbiertas("btnCajaUsuario", "frmCajaUsuarioMostrar", "Cajas", 0, "SI");
                    NombreFormAbierto = "frmCajaUsuarioMostrar";
                    NombreNodoFormAbierto = "btnCajaUsuario";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }

            }
            
        }

        private void treeView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.IsExpanded)
            {
                e.Node.Collapse();
            }
            else
            {
                e.Node.Expand();
            }
            AbrirFormSegunNodoSeleccionado(e,"NO");           
            clsNotificacion.MostrarCantidadNotificacionesNoLeidas(lblCantidadNotificaciones);
        }
        private void ActualizarMenu()
        {
            treeView1.Nodes.Clear();
            IndiceModulo = 0;
            VerificarUsuario();
            clsNotificacion.MostrarCantidadNotificacionesNoLeidas(lblCantidadNotificaciones);
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            ActualizarMenu();
        }
        DataSet1 Ds = new DataSet1();

        private void GuardarFormEnLista(Form Formulario , string Name , string Text)
        {
            var Consulta = (from D in Ds.ListaFormAbiertos
                            where D.Form == Formulario
                            select D).FirstOrDefault();

            if (Consulta != null)
                return;
            else
            {
                Ds.Tables[name : "ListaFormAbiertos"].Rows.Add
                    (new object[] {
                               Formulario,
                               Name,
                               Text
                    });
            }

            //foreach(var Form in Ds.ListaFormAbiertos)
            //{
            //    if()
            //}
                                     
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            int ind = 0;
            if (pnlCentral.Controls.Count > 0)
            {
                for (int i = 1; i <= pnlCentral.Controls.Count; i++)
                {
                    pnlCentral.Controls.RemoveAt(ind);

                    ind = ind + 1;
                }
            }           
            pnlCentral.Controls.Add(treeView2);
            pnlCentral.Tag = treeView2;
            treeView2.Show();
            

            //var f = new frmderueba();
            //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmderueba_FormClosed);
            //f.DS = this.Ds;
            //f.Show();

            //foreach (var Form in pnlCentral.Controls)
            //{
            //    if (Form is Form && ((Form)Form).WindowState != FormWindowState.Minimized)
            //    {
            //        string NombreForm;
            //        List<object> ListaFormAbiertos = new List<object>();

            //        NombreForm = ((Form)Form).Name;
            //        ListaFormAbiertos.Add(Form);
            //    }
            //}
        }
        private void frmderueba_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void treeView2_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            
        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            AbrirFormSegunNodoSeleccionado(e,"SI");
            clsNotificacion.MostrarCantidadNotificacionesNoLeidas(lblCantidadNotificaciones);
        }

        private void txtTituloForm_TextChanged(object sender, EventArgs e)
        {

        }
        private void AbrirTreeViewFormAbiertos()
        {
            int ind = 0;
            if (pnlCentral.Controls.Count > 0)
            {
                int CantidadDeForms = pnlCentral.Controls.Count;

                for (int i = 1; i <= CantidadDeForms; i++)
                {
                    pnlCentral.Controls.RemoveAt(ind);

                    //ind = ind + 1;
                }
            }
            pnlCentral.Controls.Add(treeView2);
            pnlCentral.Tag = treeView2;
            lblTituloForm.Text = "Vistas";
            picIconoCabezal.ImageLocation = "C:/Program Files (x86)/Pack-Codin/Images/FormAbiertos.png";         
            treeView2.Show();
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
        private void btnFormularios_Click(object sender, EventArgs e)
        {
            AbrirTreeViewFormAbiertos();
        }
        private void button1_Click_4(object sender, EventArgs e)
        {
           
        }

        private void frmPrueba2_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        public void Abrir()
        {
          
            
        }
        private void CerrarForm()
        {
            foreach (var Control in pnlCentral.Controls)
            {
                if (Control is Form && ((Form)Control).Name == NombreFormAbierto)
                {
                    ((Form)Control).Close();

                    foreach (var Nodo in treeView2.Nodes)
                    {
                        if (Nodo is System.Windows.Forms.TreeNode && ((System.Windows.Forms.TreeNode)Nodo).Name == NombreNodoFormAbierto)
                        {
                            ((System.Windows.Forms.TreeNode)Nodo).Remove();
                            ListaFormulariosAbiertosBoton.Remove(NombreNodoFormAbierto);
                            clsVariablesGenerales.ListaFormAbiertos.Remove(NombreNodoFormAbierto);

                            pnlCentral.Tag = treeView2;
                            treeView2.Show();

                            AbrirTreeViewFormAbiertos();
                        }
                    }
                }
            }
        }
        private void btnCerrarForm_Click(object sender, EventArgs e)
        {
            CerrarForm();
        }

        private void btnActualizarMenu_Click(object sender, EventArgs e)
        {
            ActualizarMenu();
        }
        private void OcultarMenu()
        {
            pnlMenu.Visible = false;
            pnlMenuCabezal.Size = new System.Drawing.Size(12, 29);
            treeView1.Size = new System.Drawing.Size(13, 605);
            picBarraDiv.Location = new System.Drawing.Point(15, 40);
            pnlCentral.Location = new System.Drawing.Point(15, 40);
            pnlCentral.Size = new System.Drawing.Size(1358, 694);

            // Crea instancia para mostrar el form que esta abierto
            Form FormAbierto = new Form();

            foreach (var Control in pnlCentral.Controls)
            {
                if (Control is Form)
                {
                    //foreach (var Control2 in ((Form)Control).Controls)
                    //{
                    //    if (Control2 is Form)
                    //    {
                    //        FormAbierto = ((Form)Control2);

                    //        int Indice = ((Form)Control).Controls.IndexOf(((Form)Control2));

                    //        ((Form)Control).Controls.RemoveAt(Indice);
                    //        pnlCentral.Location = new Point(15, 40);
                    //        pnlCentral.Size = new Size(1363, 694);
                    //        pnlCentral.Controls.Add(((Form)Control));
                    //        pnlCentral.Tag = ((Form)Control2);
                    //       // ((Form)Control2).Size = new Size(1358, 694);
                    //        //((Form)Control2).Dock = DockStyle.Fill;
                    //        ((Form)Control2).WindowState = FormWindowState.Maximized;

                    //        ((Form)Control2).Show();
                    //    }
                    //}
                    if (ListaFormulariosAbiertosForm.Contains(((Form)Control).Name)) 
                    {
                        if (((Form)Control).Name == NombreFormAbierto)
                        {
                            FormAbierto = ((Form)Control);

                            int Indice = pnlCentral.Controls.IndexOf(((Form)Control));

                            pnlCentral.Controls.RemoveAt(Indice);
                            pnlCentral.Location = new System.Drawing.Point(15, 40);
                            pnlCentral.Size = new System.Drawing.Size(1363, 694);
                            pnlCentral.Controls.Add(((Form)Control));
                            pnlCentral.Tag = ((Form)Control);
                            //((Form)Control).Size = new Size(1358, 694);
                            //((Form)Control).Dock = DockStyle.Fill;
                            ((Form)Control).WindowState = FormWindowState.Maximized;

                            ((Form)Control).Show();
                        }
                    }
                    foreach (var Control2 in ((Form)Control).Controls)
                    {
                        if (Control2 is Form)
                        {
                            FormAbierto = ((Form)Control2);

                            int Indice = ((Form)Control).Controls.IndexOf(((Form)Control2));

                            ((Form)Control).Controls.RemoveAt(Indice);
                            pnlCentral.Location = new System.Drawing.Point(15, 40);
                            pnlCentral.Size = new System.Drawing.Size(1363, 694);
                            pnlCentral.Controls.Add(((Form)Control2));
                            //pnlCentral.Tag = ((Form)Control2);
                            // ((Form)Control2).Size = new Size(1358, 694);
                            //((Form)Control2).Dock = DockStyle.Fill;
                            ((Form)Control2).WindowState = FormWindowState.Maximized;

                            ((Form)Control2).Show();
                        }
                    }

                }                        
            }
            treeView2.Size = new System.Drawing.Size(1358, 694);
            lblCliente.Visible = false;
            lblUsuario.Visible = false;
            btnMostrarMenu2.Visible = true;
            picUsuario.Visible = false;
            picCliente.Visible = false;

           // pnlCentral.Tag = FormAbierto;
            // ((Form)Control).Size = new Size(1358, 694);
           // FormAbierto.WindowState = FormWindowState.Maximized;

           // FormAbierto.Show();

        }
        private void btnOcultarMenu_Click_1(object sender, EventArgs e)
        {
            OcultarMenu();          
        }
        private void MostrarMenu()
        {

            pnlMenuCabezal.Size = new System.Drawing.Size(200, 29);
            treeView1.Size = new System.Drawing.Size(201, 605);
            picBarraDiv.Location = new System.Drawing.Point(203, 40);
            pnlCentral.Location = new System.Drawing.Point(206, 40);
            pnlCentral.Size = new System.Drawing.Size(1162, 690);
            treeView2.Size = new System.Drawing.Size(1162, 690);

            foreach (var Control in pnlCentral.Controls)
            {
                if (Control is Form)
                {
                    if (ListaFormulariosAbiertosForm.Contains(((Form)Control).Name))
                    {                 
                        int SubIndice = pnlCentral.Controls.IndexOf(((Form)Control));
                        pnlCentral.Controls.RemoveAt(SubIndice);

                        pnlCentral.Controls.Add(((Form)Control));
                        pnlCentral.Tag = ((Form)Control);
                        ((Form)Control).WindowState = FormWindowState.Maximized;
                        //((Form)Control).Size = new Size(1358, 694);

                        ((Form)Control).FindForm();                       
                    }
                    else
                    {
                        ((Form)Control).Close();
                    }
                }

                        //int Indice = pnlCentral.Controls.IndexOf(((Form)Control));
                        //pnlCentral.Controls.RemoveAt(Indice);

                        //pnlCentral.Controls.Add(((Form)Control));
                        //pnlCentral.Tag = ((Form)Control);
                        //((Form)Control).WindowState = FormWindowState.Maximized;
                        ////((Form)Control).Size = new Size(1358, 694);

                    //    //((Form)Control).Show();
                    //}
                    //    int Indice = pnlCentral.Controls.IndexOf(((Form)Control));
                    //    pnlCentral.Controls.RemoveAt(Indice);

                    //    pnlCentral.Controls.Add(((Form)Control));
                    //    pnlCentral.Tag = ((Form)Control);
                    //    ((Form)Control).WindowState = FormWindowState.Maximized;
                    //    //((Form)Control).Size = new Size(1358, 694);

                    //    ((Form)Control).Show();
                    
                    //int Indice = pnlCentral.Controls.IndexOf(((Form)Control));
                    //pnlCentral.Controls.RemoveAt(Indice);

                    //pnlCentral.Controls.Add(((Form)Control));
                    //pnlCentral.Tag = ((Form)Control);
                    //((Form)Control).WindowState = FormWindowState.Maximized;

                    //((Form)Control).Show();
                
            }
            lblCliente.Visible = true;
            lblUsuario.Visible = true;
            btnMostrarMenu2.Visible = false;
            picUsuario.Visible = true;
            picCliente.Visible = true;

           
        }
        private void MostrarMenu2()
        {
            pnlMenuCabezal.Size = new System.Drawing.Size(200, 29);
            treeView1.Size = new System.Drawing.Size(201, 605);
            picBarraDiv.Location = new System.Drawing.Point(203, 40);
            pnlCentral.Location = new System.Drawing.Point(206, 40);
            pnlCentral.Size = new System.Drawing.Size(1162, 690);
            treeView2.Size = new System.Drawing.Size(1162, 690);

            // Crea instancia para mostrar el form que esta abierto
            Form FormAbierto = new Form();

            foreach (var Control in pnlCentral.Controls)
            {
                if (Control is Form)
                {
                    //foreach (var Control2 in ((Form)Control).Controls)
                    //{
                    //    if (Control2 is Form)
                    //    {
                    //        FormAbierto = ((Form)Control2);

                    //        int Indice = ((Form)Control).Controls.IndexOf(((Form)Control2));

                    //        ((Form)Control).Controls.RemoveAt(Indice);
                    //        pnlCentral.Location = new Point(206, 40);
                    //        pnlCentral.Size = new Size(1162, 694);
                    //        pnlCentral.Controls.Add(((Form)Control));
                            
                    //        ((Form)Control2).Size = new Size(1162, 694);
                    //        ((Form)Control2).WindowState = FormWindowState.Maximized;
                    //        ((Form)Control2).Show();
                    //       // pnlCentral.Tag = ((Form)Control2);
                    //        //((Form)Control2).Dock = DockStyle.Fill;
                            

                           
                    //    }
                    //}
                    if (ListaFormulariosAbiertosForm.Contains(((Form)Control).Name))
                    {
                        if (((Form)Control).Name == NombreFormAbierto)
                        {
                            FormAbierto = ((Form)Control);

                            int Indice = pnlCentral.Controls.IndexOf(((Form)Control));

                            pnlCentral.Controls.RemoveAt(Indice);
                            pnlCentral.Location = new System.Drawing.Point(206, 40);
                            pnlCentral.Size = new System.Drawing.Size(1162, 694);
                            pnlCentral.Controls.Add(((Form)Control));
                            
                            ((Form)Control).Size = new System.Drawing.Size(1162, 694);
                            ((Form)Control).WindowState = FormWindowState.Maximized;
                            ((Form)Control).Show();
                           // pnlCentral.Tag = ((Form)Control);
                            //((Form)Control).Dock = DockStyle.Fill;
                            

                           
                        }
                    }
                    foreach (var Control2 in ((Form)Control).Controls)
                    {
                        if (Control2 is Form)
                        {
                            FormAbierto = ((Form)Control2);

                            int Indice = ((Form)Control).Controls.IndexOf(((Form)Control2));

                            ((Form)Control).Controls.RemoveAt(Indice);
                            pnlCentral.Location = new System.Drawing.Point(206, 40);
                            pnlCentral.Size = new System.Drawing.Size(1162, 694);
                            pnlCentral.Controls.Add(((Form)Control2));

                            ((Form)Control2).Size = new System.Drawing.Size(1162, 694);
                            ((Form)Control2).WindowState = FormWindowState.Maximized;
                            ((Form)Control2).Show();
                            // pnlCentral.Tag = ((Form)Control2);
                            //((Form)Control2).Dock = DockStyle.Fill;



                        }
                    }

                }
            }
            lblCliente.Visible = true;
            lblUsuario.Visible = true;
            btnMostrarMenu2.Visible = false;
            picUsuario.Visible = true;
            picCliente.Visible = true;
        }
        private void AbrirPanelFunciones(int ModuloID)
        {
            dgvFuncones.Rows.Clear();

            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.Acceso_Usuario
                                where C.Menu_Item.Modulo_ID == ModuloID
                                    && C.Usuario_ID == clsVariablesGenerales.UsuarioID
                                select C).ToList();

                foreach (var item in Consulta)
                {
                    dgvFuncones.Rows.Add("", item.Menu_Item.Descripcion, item.Menu_Item.Boton);
                }
            }

            int ind = 0;
            if (pnlCentral.Controls.Count > 0)
            {
                int CantidadDeForms = pnlCentral.Controls.Count;

                for (int i = 1; i <= CantidadDeForms; i++)
                {
                    pnlCentral.Controls.RemoveAt(ind);

                    //ind = ind + 1;
                }
            }
            pnlFunciones.Visible = true;
            pnlCentral.Controls.Add(pnlFunciones);
            pnlCentral.Tag = pnlFunciones;

            pnlFunciones.Visible = true;
            pnlFunciones.Show();
        }
        private void btnMostrarMenu2_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = true;
           MostrarMenu2();
        }

        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            var f = new frmCotizacionMoneda();
            f.ShowDialog();
        }

        private void frmMenu_Shown(object sender, EventArgs e)
        {
            //NotificarCumpleaños();
            //clsNotificarCumpleañosEmpleado.NotificarCumpleañosEmpleado();
            clsNotificacion.MostrarCantidadNotificacionesNoLeidas(lblCantidadNotificaciones);
           
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btnMostrarMenu_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CerrarSeccion();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            cmsMenu.PointToScreen(new System.Drawing.Point(100,500)) ;
            cmsMenu.Show();
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            cmsMenu.Show(btnDesplegarMenu.PointToScreen(e.Location));
        }

        private void btnMenuPantallaCompleta_Click(object sender, EventArgs e)
        {
            Clases.Formularios.Inicio.frmMenu.PantallaCompleta(pnlMenu,pnlCentral, clsVariablesGenerales.ListaFormAbiertos,btnMenuPantallaCompleta,btnPantallaReducida);         
        }
        private void btnPantallaReducida_Click(object sender, EventArgs e)
        {
            Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);                
        }

        private void btnDesplegarMenu_Click(object sender, EventArgs e)
        {

        }

        private void btnITWins_Click(object sender, EventArgs e)
        {
           
        }

        private void btnModCompras_Click(object sender, EventArgs e)
        {
            AbrirPanelFunciones(7);
        }

        private void btnModConfiguracion_Click(object sender, EventArgs e)
        {
            AbrirPanelFunciones(5);
        }

        private void btnModMantenimiento_Click(object sender, EventArgs e)
        {
            AbrirPanelFunciones(8);
        }

        private void btnModMariales_Click(object sender, EventArgs e)
        {
            AbrirPanelFunciones(1);
        }

        private void btnModHumano_Click(object sender, EventArgs e)
        {
            AbrirPanelFunciones(3);
        }

        private void btnModEstadisticas_Click(object sender, EventArgs e)
        {
            AbrirPanelFunciones(4);
        }

        private void btnModProduccion_Click(object sender, EventArgs e)
        {
            AbrirPanelFunciones(0);
        }

        private void btnModVentas_Click(object sender, EventArgs e)
        {
            AbrirPanelFunciones(2);
        }

        private void picUsuario_Click(object sender, EventArgs e)
        {

        }
        private void AbrirFormSegunNodoSeleccionadoMOBILE(DataGridView DGVFunciones, string EstaAbierto)
        {
            if (DGVFunciones.RowCount > 0)
            {

                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuMovimientosProd")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuMovimientosProd"))
                    {
                        MovProduccion = new frmMostrarMovProduccion();
                        MovProduccion.FormularioMenu = this;
                    }
                    MovProduccion.UsuarioID = UsuarioID;
                    MovProduccion.FormularioDeposito = Deposito;
                    MovProduccion.FormularioDeposito2 = Deposito2;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Movimientos de produccion.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(MovProduccion, pnlCentral, lblTituloForm);
                    MovProduccion.PanelCental = pnlCentral;
                    lblTituloForm.Text = "Movimientos de producción";
                    GuardarFormSesionesAbiertas("btnMnuMovimientosProd", "frmMostrarMovProduccion", "Movimientos de producción", 0, "SI");
                    NombreFormAbierto = "frmMostrarMovProduccion";
                    NombreNodoFormAbierto = "btnMnuMovimientosProd";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuControlStock")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuControlStock"))
                    {
                        ControlStock = new frmControlStock();
                    }


                    ControlStock.UsuarioID = UsuarioID;
                    ControlStock.FormularioReporte = this.FormularioReportes;

                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Stock.png");

                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(ControlStock, pnlCentral, lblTituloForm);

                    lblTituloForm.Text = "Inteligencia de stock";

                    if (EstaAbierto == "NO")
                        GuardarFormSesionesAbiertas("btnMnuControlStock", "frmControlStock", "Inteligencia de stock", 1, "SI");

                    NombreFormAbierto = "frmControlStock";
                    NombreNodoFormAbierto = "btnMnuControlStock";

                    foreach (var Nodo in treeView2.Nodes)
                    {
                        if (((System.Windows.Forms.TreeNode)Nodo).Name == NombreNodoFormAbierto)
                        {
                            ((System.Windows.Forms.TreeNode)Nodo).ImageIndex = 1;
                        }
                    }
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuOrdenProd")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuOrdenProd"))
                    {
                        OrdenProduccion = new frmMostrarOrdenProduccion();
                    }

                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Orden de produccion.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(OrdenProduccion, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Orden de producción";
                    GuardarFormSesionesAbiertas("btnMnuOrdenProd", "frmMostrarOrdenProduccion", "Orden de producción", 2, "SI");
                    NombreFormAbierto = "frmMostrarOrdenProduccion";
                    NombreNodoFormAbierto = "btnMnuOrdenProd";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuDeposito")
                {
                    //MostrarFormConEspera();
                    using (var hb = new DBdatos())
                    {
                        var ConsultaConfig = (from C in hb.PcnConfiguraciones
                                              select C).FirstOrDefault();

                        Deposito.Accion = "";

                        if (ConsultaConfig.TipoDeposito == "Base")
                        {
                            var f = new frmDepositoBase();
                            f.TopMost = true;
                            f.Show();

                            //DepositoBase.Formulario = Deposito;
                            //DepositoBase.TopMost = true;
                            //DepositoBase.Show();
                        }
                        else
                        {
                            Deposito.Formulario = Deposito;
                            Deposito.TopMost = true;
                            Deposito.Show();
                        }
                    }
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuSecciones")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuSecciones"))
                    {
                        Seccion = new frmMostrarSecciones();
                    }

                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Seccion.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Seccion, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Secciones";
                    GuardarFormSesionesAbiertas("btnMnuSecciones", "frmMostrarSecciones", "Secciones", 3, "SI");
                    NombreFormAbierto = "frmMostrarSecciones";
                    NombreNodoFormAbierto = "btnMnuSecciones";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuCirProd")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuCirProd"))
                    {
                        CircuitoProd = new frmMostrarCircuito();
                    }

                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/CircuitoProd.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(CircuitoProd, pnlCentral, lblTituloForm);
                    CircuitoProd.UsuarioID = UsuarioID;
                    CircuitoProd.AA = UsuarioID;
                    lblTituloForm.Text = "Circuito productivo";
                    GuardarFormSesionesAbiertas("btnMnuCirProd", "frmMostrarCircuito", "Circuito productivo", 4, "SI");
                    NombreFormAbierto = "frmMostrarCircuito";
                    NombreNodoFormAbierto = "btnMnuCirProd";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuGestInsuProd")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuGestInsuProd"))
                    {
                        GestorInsumoProducto = new frmMostrarInsumoProducto();
                    }

                    GestorInsumoProducto.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Gestor de inspro.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(GestorInsumoProducto, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Gestor de insumos / productos";
                    GuardarFormSesionesAbiertas("btnMnuGestInsuProd", "frmMostrarInsumoProducto", "Gestor de insumos / productos", 5, "SI");
                    ListaFormulariosAbiertosForm.Add("frmMostrarInsumoProducto");
                    NombreFormAbierto = "frmMostrarInsumoProducto";
                    NombreNodoFormAbierto = "btnMnuGestInsuProd";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuIngresarIns")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuIngresarIns"))
                    {
                        IngresoInsumo = new frmIngresoInsumoMostrar();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Ingreso insumos.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(IngresoInsumo, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Ingreso de insumos";
                    GuardarFormSesionesAbiertas("btnMnuIngresarIns", "frmIngresoInsumoMostrar", "Ingreso de insumos", 6, "SI");
                    NombreFormAbierto = "frmIngresoInsumoMostrar";
                    NombreNodoFormAbierto = "btnMnuIngresarIns";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuGastos")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuGastos"))
                    {
                        Gastos = new frmMostrarGastos();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Gastos.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Gastos, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Cobros";
                    GuardarFormSesionesAbiertas("btnMnuGastos", "frmMostrarGastos", "Cobros", 7, "SI");
                    NombreFormAbierto = "frmMostrarGastos";
                    NombreNodoFormAbierto = "btnMnuGastos";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuRegistroPedidos")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuRegistroPedidos"))
                    {

                        NuevoPedido = new frmRegistroDePedidos();
                        NuevoPedido.FormMenu = this;


                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Registro Pedidos.png");

                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(NuevoPedido, pnlCentral, lblTituloForm);
                    NombreFormAbierto = "frmRegistroDePedidos";
                    GuardarFormSesionesAbiertas("btnMnuRegistroPedidos", "frmRegistroDePedidos", "Registro de pedido", 8, "SI");


                    //if (clsVariablesGenerales.Modo == "Mobile")
                    //{
                    //    AbrirFormulariosEnPanel.AbrirFormulariosHijos(NuevoPedidoMOB, pnlCentral, lblTituloForm);
                    //    NombreFormAbierto = "frmRegistroDePedidosMOB";
                    //    GuardarFormSesionesAbiertas("btnMnuRegistroPedidos", "frmRegistroDePedidosMOB", "Registro de pedido", 8, "SI");
                    //}

                    lblTituloForm.Text = "Registro de pedido";
                    GuardarFormSesionesAbiertas("btnMnuRegistroPedidos", "frmRegistroDePedidos", "Registro de pedido", 8, "SI");
                    NombreFormAbierto = "frmRegistroDePedidos";
                    NombreNodoFormAbierto = "btnMnuRegistroPedidos";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuOrdenCarga")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuOrdenCarga"))
                    {
                        OrdenCarga = new frmMostrarOrdenesCarga();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Orden carga.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(OrdenCarga, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Orden de carga";
                    GuardarFormSesionesAbiertas("btnMnuOrdenCarga", "frmMostrarOrdenesCarga", "Orden de carga", 0, "SI");
                    NombreFormAbierto = "frmMostrarOrdenesCarga";
                    NombreNodoFormAbierto = "btnMnuOrdenCarga";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuTicket")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuTicket"))
                    {
                        Ticket = new frmMostrarTicket();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Registro Pedidos.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Ticket, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Ticket";
                    GuardarFormSesionesAbiertas("btnMnuTicket", "frmMostrarTicket", "Ticket", 8, "SI");
                    NombreFormAbierto = "frmMostrarTicket";
                    NombreNodoFormAbierto = "btnMnuTicket";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuListaPrecio")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuListaPrecio"))
                    {
                        ListaPrecio = new frmListaPrecio();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Registro Pedidos.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(ListaPrecio, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Lista de Precio";
                    GuardarFormSesionesAbiertas("btnMnuListaPrecio", "frmListaPrecio", "Lista de Precio", 8, "SI");
                    NombreFormAbierto = "frmListaPrecio";
                    NombreNodoFormAbierto = "btnMnuListaPrecio";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuGestorPersonal")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuGestorPersonal"))
                    {
                        GestorPersonal = new frmGestorPersonal();
                    }

                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Gestor de personal.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(GestorPersonal, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Gestor de pesonal";
                    GuardarFormSesionesAbiertas("btnMnuGestorPersonal", "frmGestorPersonal", "Gestor de personal", 0, "SI");
                    NombreFormAbierto = "frmGestorPersonal";
                    NombreNodoFormAbierto = "btnMnuGestorPersonal";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuClientes")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuClientes"))
                    {
                        GestorCliente = new frmGestorDeClientes();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Clientes.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(GestorCliente, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Gestor de clientes";
                    GuardarFormSesionesAbiertas("btnMnuClientes", "frmGestorDeClientes", "Gestor de clientes", 0, "SI");
                    NombreFormAbierto = "frmGestorDeClientes";
                    NombreNodoFormAbierto = "btnMnuClientes";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuImportarClientes")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuImportarClientes"))
                    {
                        ImportarCliente = new frmImportarClientes();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Importador.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(ImportarCliente, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Importador de clientes y proveedores";
                    GuardarFormSesionesAbiertas("btnMnuImportarClientes", "frmImportarClientes", "Importador de clientes y proveedores", 0, "SI");
                    NombreFormAbierto = "frmImportarClientes";
                    NombreNodoFormAbierto = "btnMnuImportarClientes";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuEstadisticas")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuEstadisticas"))
                    {
                        Estadisticas = new frmReporting();
                    }
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Informes.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Estadisticas, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Reporting";
                    GuardarFormSesionesAbiertas("btnMnuEstadisticas", "frmReporting", "Reporting", 0, "SI");
                    NombreFormAbierto = "frmReporting";
                    NombreNodoFormAbierto = "btnMnuEstadisticas";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuGestorUsuarios")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuGestorUsuarios"))
                    {
                        Usuario = new frmGestorDeUsuarios();
                    }

                    Usuario.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/GestorUsuario.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Usuario, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Gestor de usuarios";
                    GuardarFormSesionesAbiertas("btnMnuGestorUsuarios", "frmGestorDeUsuarios", "Gestor de usuarios", 0, "SI");
                    NombreFormAbierto = "frmGestorDeUsuarios";
                    NombreNodoFormAbierto = "btnMnuGestorUsuarios";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuCopiaSeguridad")
                {

                    var CopiaSeguridad = new frmBackup();
                    CopiaSeguridad.Usario_ID = UsuarioID;
                    CopiaSeguridad.ShowDialog();
                    //AbrirFormulariosEnPanel.AbrirFormulariosHijos(CopiaSeguridad, pnlCentral, lblTituloForm);
                    //lblTituloForm.Text = "Copia de seguridad";
                    //picIconoCabezal.Image = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Copia de seguridad.png");
                    //Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMnuConfig")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMnuConfig"))
                    {
                        Config = new frmConfiguracion();
                    }
                    Config.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Configuracion.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Config, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Configuración";
                    GuardarFormSesionesAbiertas("btnMnuConfig", "frmConfiguracion", "Configuración", 0, "SI");
                    NombreFormAbierto = "frmConfiguracion";
                    NombreNodoFormAbierto = "btnMnuConfig";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnMantenimiento")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnMantenimiento"))
                    {
                        Mantenimiento = new frmMostrarTipoMantenimiento();
                    }

                    Usuario.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Mod_Mantenimiento.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(Mantenimiento, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Mantenimientos";
                    GuardarFormSesionesAbiertas("btnMantenimiento", "frmMostrarTipoMantenimiento", "Mantenimientos", 0, "SI");
                    NombreFormAbierto = "frmMostrarTipoMantenimiento";
                    NombreNodoFormAbierto = "btnMantenimiento";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnRegistroMantenimiento")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnRegistroMantenimiento"))
                    {
                        MantenimientoRegistro = new frmMostrarRegistroMantenimiento();
                    }

                    Usuario.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/Mod_Mantenimiento.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(MantenimientoRegistro, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Registro de mantenimiento";
                    GuardarFormSesionesAbiertas("btnRegistroMantenimiento", "frmMostrarRegistroMantenimiento", "Registro de mantenimiento", 0, "SI");
                    NombreFormAbierto = "frmMostrarRegistroMantenimiento";
                    NombreNodoFormAbierto = "btnRegistroMantenimiento";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }
                if (dgvFuncones.CurrentRow.Cells["colBoton"].Value.ToString() == "btnNotiConf")
                {
                    if (!ListaFormulariosAbiertosBoton.Contains("btnNotiConf"))
                    {
                        NotificacionConfig = new frmNotificacionConfigurableMostrar();
                    }

                    Usuario.UsuarioID = UsuarioID;
                    Reutilizables.CargarImagenCabezal(picIconoCabezal, "C:/Program Files (x86)/Pack-Codin/Images/NotificacionConfigurable.png");
                    AbrirFormulariosEnPanel.AbrirFormulariosHijos(NotificacionConfig, pnlCentral, lblTituloForm);
                    lblTituloForm.Text = "Notificacion configurable";
                    GuardarFormSesionesAbiertas("btnNotiConf", "frmNotificacionConfigurableMostrar", "Notificacion configurable", 0, "SI");
                    NombreFormAbierto = "frmNotificacionConfigurableMostrar";
                    NombreNodoFormAbierto = "btnNotiConf";
                    Clases.Formularios.Inicio.frmMenu.PantallaReducida(pnlMenu, pnlCentral, ListaFormulariosAbiertosForm, btnMenuPantallaCompleta, btnPantallaReducida);
                }

            }
        }
        private void dgvFuncones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlFunciones.Visible = false;
            AbrirFormSegunNodoSeleccionadoMOBILE(dgvFuncones, "NO");
        }

        private void btnLicencias_Click(object sender, EventArgs e)
        {
            var f = new frmLicencia();
            f.ShowDialog();
            //RenovarConsultaLicencia();
        }

        private void picPackCodin_Click_1(object sender, EventArgs e)
        {

        }
    }
}
