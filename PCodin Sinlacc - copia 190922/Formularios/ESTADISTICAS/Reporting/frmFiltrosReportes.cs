using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios.ESTADISTICAS.Informes;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Entity.SqlServer;
using PCodin_Sinlacc.Formularios.ESTADISTICAS.Informes_Dataset;
using System.Threading;
using PCodin_Sinlacc.Formularios;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmFiltrosReportes : Form
    {
        public frmFiltrosReportes()
        {
            InitializeComponent();
        }
        public int InformeID;
        public string Informe;
        private frmPantallaEspera PantallaEspera = new frmPantallaEspera();
        private frmReporte VisorReporte = new frmReporte();
        //private frmReporte Visor = new frmReporte();

        Button BtnListar = new Button();

        CheckBox chkFiltraProducto = new CheckBox();
        ComboBox cmbFiltraProducto = new ComboBox();
        TextBox txtBuscaProducto = new TextBox();
        Button btnBuscaProducto = new Button();

        CheckBox chkFiltraInsumo = new CheckBox();
        ComboBox cmbFiltraInsumo = new ComboBox();
        TextBox txtBuscaInsumo = new TextBox();
        Button btnBuscaInsumo = new Button();

        CheckBox chkFiltraSubproducto = new CheckBox();
        ComboBox cmbFiltraSubproducto = new ComboBox();
        TextBox txtBuscaSubproducto = new TextBox();
        Button btnBuscaSubproducto = new Button();

        //FLITRO BUSCA RUBRO
        CheckBox chkFiltraRubro = new CheckBox();
        ComboBox cmbFiltraRubro = new ComboBox();
        TextBox txtBuscaRubro = new TextBox();
        Button btnBuscaRubro = new Button();

        CheckBox chkFiltraListaEmpleado = new CheckBox();
        CheckedListBox ListaFiltraEmpleados = new CheckedListBox();

        CheckBox chkFiltraFechaDesde = new CheckBox();
        DateTimePicker dtpFiltraFechaDesde = new DateTimePicker();

        CheckBox chkFiltraFechaHasta = new CheckBox();
        DateTimePicker dtpFiltraFechaHasta = new DateTimePicker();

        CheckBox chkFiltraEstadoPed = new CheckBox();
        ComboBox cmbFiltraEstadoPed = new ComboBox();

        //FILTRO CLIENTE
        CheckBox chkFiltraCliente = new CheckBox();
        ComboBox cmbFiltraCliente = new ComboBox();
        TextBox txtBuscaCliente = new TextBox();
        Button btnBuscaCliente = new Button();

        CheckBox chkFiltraSeccion = new CheckBox();
        ComboBox cmbFiltraSeccion = new ComboBox();

        //Filtro para stock
        CheckBox chkFiltraStockMin = new CheckBox();
        CheckBox chkFiltraConExistencia = new CheckBox();
        CheckBox chkFiltraSinExistencia = new CheckBox();

        //FILTRO MEDIOPAGO
        CheckBox chkFiltraMedioPago = new CheckBox();
        ComboBox cmbFiltraMedioPago = new ComboBox();

        //FILTRO NUMERO ORDEN CARGA
        CheckBox chkFiltraNumOredenCarga = new CheckBox();
        TextBox txtFiltraNumOrdenCarga = new TextBox();

        //FILTRO CHOFER
        CheckBox chkFiltraChofer = new CheckBox();
        ComboBox cmbFiltraChofer = new ComboBox();
        TextBox txtBuscaChofer = new TextBox();
        Button btnBuscaChofer = new Button();

        

        int CheckX = 20;
        int CheckY = 25;

        int ControlX = 100;
        int ControlY = 24;

        int btnBuscarX = 470;
        int btnBuscarY = 24;

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltrosReportes));

        //CheckBox chkFiltraProducto = new CheckBox();
        //ComboBox cmbFiltraProducto = new ComboBox();
        //TextBox txtFiltraProducto = new TextBox();
        //Button btnBuscarProducto = new Button();

        private void frmFiltrosReportes_Load(object sender, EventArgs e)
        {
            MostrarFiltrosInformeSeleccionado();
        }
        private void MostrarFiltrosInformeSeleccionado()
        {
            if(Informe == "Maestro de pedidos") //--- rptMaestroDePedidos
            {
                AgregarComboFiltroProducto(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarComboFiltroEstadoPedido(chkFiltraEstadoPed.Text, chkFiltraEstadoPed, cmbFiltraEstadoPed.Text, cmbFiltraEstadoPed, ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarComboFiltroCliente(chkFiltraCliente.Text, chkFiltraCliente, cmbFiltraCliente.Text, cmbFiltraCliente,txtBuscaCliente.Text,txtBuscaCliente,btnBuscaCliente.Text,btnBuscaCliente, ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarFiltroFechaDesde(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
                AgregarFiltroFechaHasta(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
            }
            if (Informe == "Costo material de producto") //--- rptCostoMaterialProducto
            {
                AgregarComboFiltroProducto(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                //AgregarComboFiltroEstadoPedido(chkFiltraEstadoPed.Text, chkFiltraEstadoPed, cmbFiltraEstadoPed.Text, cmbFiltraEstadoPed, ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                //AgregarComboFiltroCliente(chkFiltraCliente.Text, chkFiltraCliente, cmbFiltraCliente.Text, cmbFiltraCliente, txtBuscaCliente.Text, txtBuscaCliente, btnBuscaCliente.Text, btnBuscaCliente, ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);

            }
            if (Informe == "Listado de costo por insumo") //--- rptCostoMaterialProducto
            {
                AgregarComboFiltroInsumo(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);

            }
            if(Informe == "Produccion diaria")
            {
                AgregarComboFiltroProducto(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarFiltroFechaDesde(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
                AgregarFiltroFechaHasta(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
            }
            if(Informe == "Resumen maestro")
            {
                AgregarComboFiltroCliente(chkFiltraCliente.Text, chkFiltraCliente, cmbFiltraCliente.Text, cmbFiltraCliente, txtBuscaCliente.Text, txtBuscaCliente, btnBuscaCliente.Text, btnBuscaCliente, ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarComboFiltroMedioPago(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarFiltroFechaDesde(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
                AgregarFiltroFechaHasta(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);             
            }
            if(Informe == "Produccion por empleado")
            {
                AgregarComboFiltroProducto(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarFiltroSubProducto(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);               
                AgregarFiltroFechaDesde(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
                AgregarFiltroFechaHasta(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
                AgregarFiltroListaEmpleados(ref CheckX, ref CheckY, ref ControlX, ref ControlY);
            }
            if (Informe == "Produccion por empleado por sección")
            {
                AgregarComboFiltroSeccion(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarComboFiltroProducto(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarComboFiltroInsumo(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarFiltroFechaDesde(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
                AgregarFiltroFechaHasta(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
                AgregarFiltroListaEmpleados(ref CheckX, ref CheckY, ref ControlX, ref ControlY);
            }
            if (Informe == "Stock mercaderia")
            {
                AgregarComboFiltroInsumo(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarFiltroFechaDesde(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
                AgregarFiltraStockMin(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarFiltroStockConExistencia(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarFiltroStockSinExistencia(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
            }
            if(Informe == "Ordenes de carga")
            {
                AgregarFiltroNumeroOrdenCarga(ref CheckX, ref CheckY,"N° Orden", ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarComboFiltroCliente(chkFiltraCliente.Text, chkFiltraCliente, cmbFiltraCliente.Text, cmbFiltraCliente, txtBuscaCliente.Text, txtBuscaCliente, btnBuscaCliente.Text, btnBuscaCliente, ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarComboFiltroChofer(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarFiltroFechaDesde(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
                AgregarFiltroFechaHasta(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
            }
            if(Informe == "Stock por lote")
            {
                AgregarComboFiltroProducto(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarFiltroNumeroOrdenCarga(ref CheckX, ref CheckY,"Lote", ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarFiltroFechaDesde(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
            }
            if (Informe == "Resumen de cuenta")
            {
                AgregarComboFiltroCliente(chkFiltraCliente.Text, chkFiltraCliente, cmbFiltraCliente.Text, cmbFiltraCliente, txtBuscaCliente.Text, txtBuscaCliente, btnBuscaCliente.Text, btnBuscaCliente, ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
            }
            if(Informe == "Movimientos Diarios")
            {
                AgregarComboFiltroProducto(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
                AgregarFiltroFechaDesde(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
                AgregarFiltroFechaHasta(ref CheckX, ref CheckY, ref ControlX, ref ControlY, Controls);
            }
            if (Informe == "Lista de precio Codigos")
            {
                AgregarComboFiltroRubro(ref CheckX, ref CheckY, ref ControlX, ref ControlY, ref btnBuscarX, ref btnBuscarY, Controls);
            }



        }

        private void AgregarFiltroSinExistencia(ref int checkX, ref int checkY, ref int controlX, ref int controlY, ref int btnBuscarX, ref int btnBuscarY, Control.ControlCollection controls)
        {
           
        }
        private void AgregarFiltroNumeroOrdenCarga(ref int CheckX, ref int CheckY, string DescripcionFiltro, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraNumOredenCarga.AutoSize = true;
            chkFiltraNumOredenCarga.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraNumOredenCarga.Location = new Point(CheckX, CheckY);
            chkFiltraNumOredenCarga.Size = new System.Drawing.Size(57, 17);
            chkFiltraNumOredenCarga.Name = "chkFiltraNumOredenCarga";
            chkFiltraNumOredenCarga.Text = DescripcionFiltro;
            CheckY = CheckY + 25;
            chkFiltraNumOredenCarga.CheckedChanged += chkFiltraNumOredenCarga_CheckedChanged;
            Controls.Add(chkFiltraNumOredenCarga);

            txtFiltraNumOrdenCarga.Location = new Point(ControlX, ControlY);
            txtFiltraNumOrdenCarga.Name = "txtFiltraNumOrdenCarga";
            txtFiltraNumOrdenCarga.Size = new System.Drawing.Size(350, 100);
            txtFiltraNumOrdenCarga.Enabled = false;
            txtFiltraNumOrdenCarga.Visible = true;
            ControlY = ControlY + 24;
            
            Controls.Add(txtFiltraNumOrdenCarga);

            BtnY = BtnY + 24;
        }

        private void chkFiltraNumOredenCarga_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraNumOrdenCarga, chkFiltraNumOredenCarga);
        }
        private void AgregarComboFiltroProducto(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraProducto.AutoSize = true;
            chkFiltraProducto.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraProducto.Location = new Point(CheckX, CheckY);
            chkFiltraProducto.Size = new System.Drawing.Size(57, 17);
            chkFiltraProducto.Name = "chkFiltraProducto";
            chkFiltraProducto.Text = "Producto";
            CheckY = CheckY + 25;
            Controls.Add(chkFiltraProducto);
            chkFiltraProducto.CheckedChanged += chkFiltraChofer_CheckedChanged1;

            cmbFiltraProducto.Location = new Point(ControlX, ControlY);           
            cmbFiltraProducto.Size = new System.Drawing.Size(350, 17);
            cmbFiltraProducto.Enabled = false;
            cmbFiltraInsumo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltraProducto.KeyPress += cmbFiltraProducto_KeyPress;
            Controls.Add(cmbFiltraProducto);

            txtBuscaProducto.Location = new Point(ControlX, ControlY);
            txtBuscaProducto.Name = "txtBuscaProducto";
            txtBuscaProducto.Size = new System.Drawing.Size(350, 100);
            txtBuscaProducto.Enabled = true;
            txtBuscaProducto.Visible = true;
            ControlY = ControlY + 24;
            txtBuscaProducto.KeyPress += textbox_KeyPress;
            Controls.Add(txtBuscaProducto);

            btnBuscaProducto.Location = new Point(BtnX, BtnY);
            btnBuscaProducto.Size = new System.Drawing.Size(22, 22);
            btnBuscaProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            btnBuscaProducto.BackgroundImage = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\buscar.png");          
            btnBuscaProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnBuscaProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscaProducto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            btnBuscaProducto.FlatAppearance.BorderSize = 0;
            btnBuscaProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            btnBuscaProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;          
            btnBuscaProducto.TabIndex = 586;
            BtnY = BtnY + 24;
            btnBuscaProducto.UseVisualStyleBackColor = false;
            btnBuscaProducto.Enabled = false;
            btnBuscaProducto.Click += button_Click;

            Controls.Add(btnBuscaProducto);           
        }
        private void chkFiltraChofer_CheckedChanged1(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraProducto, cmbFiltraProducto, txtBuscaProducto, btnBuscaProducto,"PRO", "NO");
        }
        private void cmbFiltraProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraProducto, txtBuscaProducto, "PRO", false, "NO");
                txtBuscaProducto.Focus();
                e.Handled = true;
            }
        }
        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaProducto.Visible = false;
                cmbFiltraProducto.Visible = true;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraProducto, txtBuscaProducto, "PRO", true, "NO");
                txtBuscaProducto.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaProducto.Visible = false;
                cmbFiltraProducto.Visible = true;
                txtBuscaProducto.Focus();
                e.Handled = true;
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            txtBuscaProducto.Visible = true;
            cmbFiltraProducto.Visible = false;
            txtBuscaProducto.Select();
        }
        private void AgregarComboFiltroRubro(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraRubro.AutoSize = true;
            chkFiltraRubro.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraRubro.Location = new Point(CheckX, CheckY);
            chkFiltraRubro.Size = new System.Drawing.Size(57, 17);
            chkFiltraRubro.Name = "chkFiltraRubro";
            chkFiltraRubro.Text = "Rubro";
            CheckY = CheckY + 25;
            Controls.Add(chkFiltraRubro);
            chkFiltraRubro.CheckedChanged += chkFiltraRubro_CheckedChanged1;

            cmbFiltraRubro.Location = new Point(ControlX, ControlY);
            cmbFiltraRubro.Size = new System.Drawing.Size(350, 17);
            cmbFiltraRubro.Enabled = false;
            cmbFiltraRubro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltraRubro.KeyPress += cmbFiltraRubro_KeyPress;
            Controls.Add(cmbFiltraRubro);

            txtBuscaRubro.Location = new Point(ControlX, ControlY);
            txtBuscaRubro.Name = "txtBuscaRubro";
            txtBuscaRubro.Size = new System.Drawing.Size(350, 100);
            txtBuscaRubro.Enabled = true;
            txtBuscaRubro.Visible = true;
            ControlY = ControlY + 24;
            txtBuscaRubro.KeyPress += txtBuscaRubro_KeyPress;
            Controls.Add(txtBuscaRubro);

            btnBuscaRubro.Location = new Point(BtnX, BtnY);
            btnBuscaRubro.Size = new System.Drawing.Size(22, 22);
            btnBuscaRubro.BackColor = System.Drawing.Color.WhiteSmoke;
            btnBuscaRubro.BackgroundImage = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\buscar.png");
            btnBuscaRubro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnBuscaRubro.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscaRubro.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            btnBuscaRubro.FlatAppearance.BorderSize = 0;
            btnBuscaRubro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            btnBuscaRubro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscaRubro.TabIndex = 586;
            BtnY = BtnY + 24;
            btnBuscaRubro.UseVisualStyleBackColor = false;
            btnBuscaRubro.Enabled = false;
            btnBuscaRubro.Click += btnBuscaRubro_Click;

            Controls.Add(btnBuscaRubro);
        }

        private void btnBuscaRubro_Click(object sender, EventArgs e)
        {
            txtBuscaRubro.Visible = true;
            cmbFiltraRubro.Visible = false;
            txtBuscaRubro.Select();
        }

        private void txtBuscaRubro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaRubro.Visible = false;
                cmbFiltraRubro.Visible = true;
                clsCargarCombos.MostrarCategorias(cmbFiltraRubro, txtBuscaRubro, true);
                txtBuscaRubro.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaRubro.Visible = false;
                cmbFiltraRubro.Visible = true;
                txtBuscaRubro.Focus();
                e.Handled = true;
            }
        }

        private void cmbFiltraRubro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarCategorias(cmbFiltraRubro, txtBuscaRubro,false);
                txtBuscaRubro.Focus();
                e.Handled = true;
            }
        }

        private void chkFiltraRubro_CheckedChanged1(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCategorias(chkFiltraRubro, cmbFiltraRubro, txtBuscaRubro, btnBuscaRubro);

        }

        private void AgregarComboFiltroInsumo(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraInsumo.AutoSize = true;
            chkFiltraInsumo.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraInsumo.Location = new Point(CheckX, CheckY);
            chkFiltraInsumo.Size = new System.Drawing.Size(57, 17);
            chkFiltraInsumo.Name = "chkFiltraInsumo";
            chkFiltraInsumo.Text = "Insumo";
            CheckY = CheckY + 25;           
            Controls.Add(chkFiltraInsumo);
            
            chkFiltraInsumo.CheckedChanged += chkFiltraInsumo_CheckedChanged;

            cmbFiltraInsumo.Location = new Point(ControlX, ControlY);            
            cmbFiltraInsumo.Size = new System.Drawing.Size(350, 17);
            cmbFiltraInsumo.Enabled = false;
            cmbFiltraInsumo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltraInsumo.KeyPress += cmbFiltraInsumo_KeyPress;
            Controls.Add(cmbFiltraInsumo);

            txtBuscaInsumo.Location = new Point(ControlX, ControlY);
            txtBuscaInsumo.Size = new System.Drawing.Size(350, 100);
            txtBuscaInsumo.Enabled = true;
            txtBuscaInsumo.Visible = true;
            ControlY = ControlY + 24;
            txtBuscaInsumo.KeyPress += txtBuscaInsumo_KeyPress;
            Controls.Add(txtBuscaInsumo);

            btnBuscaInsumo.Location = new Point(BtnX, BtnY);
            btnBuscaInsumo.Size = new System.Drawing.Size(22, 22);
            btnBuscaInsumo.BackColor = System.Drawing.Color.WhiteSmoke;
            btnBuscaInsumo.BackgroundImage = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\buscar.png");          
            btnBuscaInsumo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnBuscaInsumo.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscaInsumo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            btnBuscaInsumo.FlatAppearance.BorderSize = 0;
            btnBuscaInsumo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            btnBuscaInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;           
            btnBuscaInsumo.TabIndex = 586;
            BtnY = BtnY + 24;
            btnBuscaInsumo.UseVisualStyleBackColor = false;
            btnBuscaInsumo.Enabled = false;
            btnBuscaInsumo.Click += btnBuscaInsumo_Click;

            Controls.Add(btnBuscaInsumo);
        }
        private void chkFiltraInsumo_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsumo, cmbFiltraInsumo, txtBuscaInsumo, btnBuscaInsumo,"INS","NO");
        }
        private void cmbFiltraInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsumo, txtBuscaInsumo, "INS", false, "NO");
                txtBuscaInsumo.Focus();
                e.Handled = true;
            }
        }
        private void txtBuscaInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsumo.Visible = false;
                cmbFiltraInsumo.Visible = true;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsumo, txtBuscaInsumo, "INS", true, "NO");
                txtBuscaInsumo.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaInsumo.Visible = false;
                cmbFiltraInsumo.Visible = true;
                txtBuscaInsumo.Focus();
                e.Handled = true;
            }
        }
        private void btnBuscaInsumo_Click(object sender, EventArgs e)
        {
            txtBuscaInsumo.Visible = true;
            cmbFiltraInsumo.Visible = false;
            txtBuscaInsumo.Select();
        }
        private void AgregarFiltroSubProducto(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraSubproducto.AutoSize = true;
            chkFiltraSubproducto.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraSubproducto.Location = new Point(CheckX, CheckY);
            chkFiltraSubproducto.Size = new System.Drawing.Size(57, 17);
            chkFiltraSubproducto.Name = "chkFiltrSubproducto";
            chkFiltraSubproducto.Text = "Subproducto";
            CheckY = CheckY + 25;
            Controls.Add(chkFiltraSubproducto);

            chkFiltraSubproducto.CheckedChanged += chkFiltraSubproducto_CheckedChanged;

            cmbFiltraSubproducto.Location = new Point(ControlX, ControlY);
            cmbFiltraSubproducto.Size = new System.Drawing.Size(350, 17);
            cmbFiltraSubproducto.Enabled = false;
            cmbFiltraSubproducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltraSubproducto.KeyPress += cmbFiltraSubproducto_KeyPress;
            Controls.Add(cmbFiltraSubproducto);

            txtBuscaSubproducto.Location = new Point(ControlX, ControlY);
            txtBuscaSubproducto.Size = new System.Drawing.Size(350, 100);
            txtBuscaSubproducto.Enabled = true;
            txtBuscaSubproducto.Visible = true;
            ControlY = ControlY + 24;
            txtBuscaSubproducto.KeyPress += txtBuscaSubproducto_KeyPress;
            Controls.Add(txtBuscaSubproducto);

            btnBuscaSubproducto.Location = new Point(BtnX, BtnY);
            btnBuscaSubproducto.Size = new System.Drawing.Size(22, 22);
            btnBuscaSubproducto.BackColor = System.Drawing.Color.WhiteSmoke;
            btnBuscaSubproducto.BackgroundImage = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\buscar.png");
            btnBuscaSubproducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnBuscaSubproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscaSubproducto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            btnBuscaSubproducto.FlatAppearance.BorderSize = 0;
            btnBuscaSubproducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            btnBuscaSubproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscaSubproducto.TabIndex = 586;
            BtnY = BtnY + 24;
            btnBuscaSubproducto.UseVisualStyleBackColor = false;
            btnBuscaSubproducto.Enabled = false;
            btnBuscaSubproducto.Click += btnBuscaSubproducto_Click;

            Controls.Add(btnBuscaInsumo);
        }

        private void btnBuscaSubproducto_Click(object sender, EventArgs e)
        {
            txtBuscaSubproducto.Visible = true;
            cmbFiltraSubproducto.Visible = false;
            txtBuscaSubproducto.Select();
        }

        private void txtBuscaSubproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaSubproducto.Visible = false;
                cmbFiltraSubproducto.Visible = true;
                clsCargarCombos.MostrarComboSubProductos(cmbFiltraSubproducto, txtBuscaSubproducto, false);
                txtBuscaSubproducto.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaSubproducto.Visible = false;
                cmbFiltraSubproducto.Visible = true;
                txtBuscaSubproducto.Focus();
                e.Handled = true;
            }
        }

        private void cmbFiltraSubproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboSubProductos(cmbFiltraSubproducto, txtBuscaSubproducto, false);
                txtBuscaInsumo.Focus();
                e.Handled = true;
            }
        }

        private void chkFiltraSubproducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSubProducto(chkFiltraSubproducto, cmbFiltraSubproducto, txtBuscaSubproducto, btnBuscaInsumo);
        }

        private void AgregarComboFiltroEstadoPedido(string checkName, CheckBox chkFiltraEstadoPed, string cmbName, ComboBox cmbFiltraEstadoPed, ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraEstadoPed.AutoSize = true;
            chkFiltraEstadoPed.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraEstadoPed.Location = new Point(CheckX, CheckY);
            chkFiltraEstadoPed.Size = new System.Drawing.Size(57, 17);
            chkFiltraEstadoPed.Name = checkName;
            chkFiltraEstadoPed.Text = "Estado";
            CheckY = CheckY + 25;
            Controls.Add(chkFiltraEstadoPed);
            chkFiltraEstadoPed.CheckedChanged += chkFiltraEstadoPed_CheckedChanged1;
         
            cmbFiltraEstadoPed.Location = new Point(ControlX, ControlY);
            cmbFiltraEstadoPed.Name = cmbName;
            cmbFiltraEstadoPed.Size = new System.Drawing.Size(350, 17);
            cmbFiltraEstadoPed.Enabled = false;
            cmbFiltraEstadoPed.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltraEstadoPed.Items.Add("FI");
            cmbFiltraEstadoPed.Items.Add("AU");
            // cmbFiltraEstadoPed.KeyPress += cmbFiltraEstadoPed_KeyPress;
            ControlY = ControlY + 24;
            Controls.Add(cmbFiltraEstadoPed);

            BtnY = BtnY + 24;
        }       
        private void chkFiltraEstadoPed_CheckedChanged1(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstadoPed, cmbFiltraEstadoPed);
        }
        private void AgregarComboFiltroCliente(string checkName, CheckBox chkFiltraProducto, string cmbName, ComboBox cmbFiltraProducto, string txtName, TextBox txtBuscaProducto, string btnName, Button btnBuscaProducto, ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraCliente.AutoSize = true;
            chkFiltraCliente.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraCliente.Location = new Point(CheckX, CheckY);
            chkFiltraCliente.Size = new System.Drawing.Size(57, 17);
            chkFiltraCliente.Name = chkFiltraEstadoPed.Text;
            chkFiltraCliente.Text = "Cliente";
            CheckY = CheckY + 25;
            Controls.Add(chkFiltraCliente);
            chkFiltraProducto.CheckedChanged += Check_CheckedChanged;

            cmbFiltraCliente.Location = new Point(ControlX, ControlY);
            cmbFiltraCliente.Name = cmbName;
            cmbFiltraCliente.Size = new System.Drawing.Size(350, 17);
            cmbFiltraCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltraCliente.Enabled = false;
            cmbFiltraCliente.KeyPress += cmbFiltraCliente_KeyPress;
            Controls.Add(cmbFiltraCliente);

            txtBuscaCliente.Location = new Point(ControlX, ControlY);
            txtBuscaCliente.Name = txtBuscaCliente.Text;
            txtBuscaCliente.Size = new System.Drawing.Size(350, 17);
            txtBuscaCliente.Enabled = true;
            txtBuscaCliente.Visible = true;
            ControlY = ControlY + 24;
            txtBuscaCliente.KeyPress += txtBuscaCliente_KeyPress;
            Controls.Add(txtBuscaCliente);

            btnBuscaCliente.Location = new Point(BtnX, BtnY);
            btnBuscaCliente.Size = new System.Drawing.Size(22, 22);
            btnBuscaCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            btnBuscaCliente.BackgroundImage = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\buscar.png");
            btnBuscaCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnBuscaCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscaCliente.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            btnBuscaCliente.FlatAppearance.BorderSize = 0;
            btnBuscaCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            btnBuscaCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscaCliente.Name = btnName;
            btnBuscaCliente.TabIndex = 586;
            BtnY = BtnY + 24;
            btnBuscaCliente.UseVisualStyleBackColor = false;
            btnBuscaCliente.Enabled = false;
            btnBuscaCliente.Click += btnBuscaCliente_Click;
           

            Controls.Add(btnBuscaProducto);
        }
        private void cmbFiltraCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboClientes(cmbFiltraCliente, txtBuscaCliente, false, "CLI", 0);
                txtBuscaCliente.Focus();
                e.Handled = true;
            }
        }

        private void txtBuscaCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaCliente.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbFiltraCliente, txtBuscaCliente, true, "CLI", 0  );
                txtBuscaCliente.Focus();
                e.Handled = true;
                cmbFiltraCliente.Visible = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaCliente.Visible = false;
                txtBuscaCliente.Focus();
                e.Handled = true;
                cmbFiltraCliente.Visible = true;
            }

        }
        private void AgregarFiltroFechaDesde(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, Control.ControlCollection Controls)
        {
            chkFiltraFechaDesde.AutoSize = true;
            chkFiltraFechaDesde.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraFechaDesde.Location = new Point(CheckX, CheckY);
            chkFiltraFechaDesde.Size = new System.Drawing.Size(57, 17);
            chkFiltraFechaDesde.Name = "chkFiltraFechaDesde";
            chkFiltraFechaDesde.Text = "Desde";
            CheckY = CheckY + 25;
            chkFiltraFechaDesde.CheckedChanged += chkFiltraFechaDesde_CheckedChanged;
            Controls.Add(chkFiltraFechaDesde);

            dtpFiltraFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFiltraFechaDesde.Location = new Point(ControlX, ControlY);
            dtpFiltraFechaDesde.Name = "dtpFechaDesde";
            dtpFiltraFechaDesde.Size = new System.Drawing.Size(111, 20);
            dtpFiltraFechaDesde.Enabled = false;
            ControlY = ControlY + 24;
            Controls.Add(dtpFiltraFechaDesde);
        }
        // FILTRO CHOFER
        private void AgregarComboFiltroChofer(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraChofer.AutoSize = true;
            chkFiltraChofer.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraChofer.Location = new Point(CheckX, CheckY);
            chkFiltraChofer.Size = new System.Drawing.Size(57, 17);
            chkFiltraChofer.Name = "chkFiltraChofer";
            chkFiltraChofer.Text = "Chofer";
            CheckY = CheckY + 25;
            Controls.Add(chkFiltraChofer);
            chkFiltraChofer.CheckedChanged += chkFiltraChofer_CheckedChanged;

            cmbFiltraChofer.Location = new Point(ControlX, ControlY);
            cmbFiltraChofer.Size = new System.Drawing.Size(350, 100);
            cmbFiltraChofer.Enabled = false;
            cmbFiltraChofer.Visible = true;
            cmbFiltraChofer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltraChofer.KeyPress += cmbFiltraChofer_KeyPress;
            Controls.Add(cmbFiltraChofer);

            txtBuscaChofer.Location = new Point(ControlX, ControlY);
            txtBuscaChofer.Name = "txtBuscaChofer";
            txtBuscaChofer.Size = new System.Drawing.Size(350, 100);
            txtBuscaChofer.Enabled = true;
            txtBuscaChofer.Visible = true;
            ControlY = ControlY + 24;
            txtBuscaChofer.KeyPress += txtBuscaChofer_KeyPress;
            Controls.Add(txtBuscaChofer);

            btnBuscaChofer.Location = new Point(BtnX, BtnY);
            btnBuscaChofer.Size = new System.Drawing.Size(22, 22);
            btnBuscaChofer.BackColor = System.Drawing.Color.WhiteSmoke;
            btnBuscaChofer.BackgroundImage = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\buscar.png");
            btnBuscaChofer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnBuscaChofer.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscaChofer.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            btnBuscaChofer.FlatAppearance.BorderSize = 0;
            btnBuscaChofer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            btnBuscaChofer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscaChofer.TabIndex = 586;
            BtnY = BtnY + 24;
            btnBuscaChofer.UseVisualStyleBackColor = false;
            btnBuscaChofer.Enabled = false;
            btnBuscaChofer.Click += btnBuscaChofer_Click;

            Controls.Add(btnBuscaChofer);
        }

        private void cmbFiltraChofer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboChofer(cmbFiltraChofer, txtBuscaChofer, false);
                txtBuscaChofer.Focus();
                e.Handled = true;
            }
        }

        private void chkFiltraChofer_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboChofer(chkFiltraChofer, txtBuscaChofer, cmbFiltraChofer, btnBuscaChofer);
        }

        private void btnBuscaChofer_Click(object sender, EventArgs e)
        {
            txtBuscaChofer.Visible = true;
            cmbFiltraChofer.Visible = false;
            txtBuscaChofer.Select();
        }

        private void txtBuscaChofer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaChofer.Visible = false;
                clsCargarCombos.MostrarComboChofer(cmbFiltraChofer, txtBuscaChofer, true); ;
                txtBuscaChofer.Focus();
                e.Handled = true;
                cmbFiltraChofer.Visible = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaChofer.Visible = false;
                txtBuscaChofer.Focus();
                e.Handled = true;
                cmbFiltraChofer.Visible = true;
            }
        }

        private void chkFiltraFechaDesde_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFiltraFechaDesde,dtpFiltraFechaDesde);
        }
        private void AgregarFiltroFechaHasta(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, Control.ControlCollection Controls)
        {
            chkFiltraFechaHasta.AutoSize = true;
            chkFiltraFechaHasta.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraFechaHasta.Location = new Point(CheckX, CheckY);
            chkFiltraFechaHasta.Size = new System.Drawing.Size(57, 17);
            chkFiltraFechaHasta.Name = "chkFiltraFechaHasta";
            chkFiltraFechaHasta.Text = "Hasta";
            CheckY = CheckY + 25;
            chkFiltraFechaHasta.CheckedChanged += chkFiltraFechaHasta_CheckedChanged;
            Controls.Add(chkFiltraFechaHasta);

            dtpFiltraFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFiltraFechaHasta.Location = new Point(ControlX, ControlY);
            dtpFiltraFechaHasta.Name = "dtpFechaHasta";
            dtpFiltraFechaHasta.Size = new System.Drawing.Size(111, 20);
            dtpFiltraFechaHasta.Enabled = false;
            ControlY = ControlY + 24;
            Controls.Add(dtpFiltraFechaHasta);
        }
        private void chkFiltraFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFiltraFechaHasta, dtpFiltraFechaHasta);
        }

       

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            txtBuscaCliente.Visible = true;
            cmbFiltraCliente.Visible = false;
            txtBuscaCliente.Select();
        }

        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCliente(chkFiltraCliente, cmbFiltraCliente, txtBuscaCliente, btnBuscaCliente);
        }
        private void AgregarFiltroListaEmpleados(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY)
        {
            chkFiltraListaEmpleado.AutoSize = true;
            chkFiltraListaEmpleado.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraListaEmpleado.Location = new Point(CheckX, CheckY);
            chkFiltraListaEmpleado.Size = new System.Drawing.Size(57, 17);
            chkFiltraListaEmpleado.Name = "chkFiltraListaEmpleado";
            chkFiltraListaEmpleado.Text = "Empleado";
            CheckY = CheckY + 25;
            Controls.Add(chkFiltraListaEmpleado);
            chkFiltraListaEmpleado.CheckedChanged += chkFiltraListaEmpleado_CheckedChanged;

            ListaFiltraEmpleados.Location = new Point(ControlX, ControlY);
            ListaFiltraEmpleados.Size = new System.Drawing.Size(350, 250);
            ListaFiltraEmpleados.Enabled = false;
            ListaFiltraEmpleados.CheckOnClick = true;
           // cmbFiltraProducto.KeyPress += cmbFiltraProducto_KeyPress;
            Controls.Add(ListaFiltraEmpleados);

            //txtBuscaProducto.Location = new Point(ControlX, ControlY);
            //txtBuscaProducto.Name = "txtBuscaProducto";
            ////Textbox.Size = new System.Drawing.Size(350, 100);
            //txtBuscaProducto.Enabled = true;
            //txtBuscaProducto.Visible = true;
            //ControlY = ControlY + 24;
            //txtBuscaProducto.KeyPress += textbox_KeyPress;
            //Controls.Add(txtBuscaProducto);

            //btnBuscaProducto.Location = new Point(BtnX, BtnY);
            //btnBuscaProducto.Size = new System.Drawing.Size(22, 22);
            //btnBuscaProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            //btnBuscaProducto.BackgroundImage = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\buscar.png");
            //btnBuscaProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            //btnBuscaProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            //btnBuscaProducto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            //btnBuscaProducto.FlatAppearance.BorderSize = 0;
            //btnBuscaProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            //btnBuscaProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //btnBuscaProducto.TabIndex = 586;
            //BtnY = BtnY + 24;
            //btnBuscaProducto.UseVisualStyleBackColor = false;
            //btnBuscaProducto.Click += button_Click;

            //Controls.Add(btnBuscaProducto);
        }

        private void chkFiltraListaEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiltraListaEmpleado.Checked)
            {
                ListaFiltraEmpleados.Enabled = true;
                clsCargarCombos.MostrarEmpleadosEnLista(ListaFiltraEmpleados);
            }
            else
            {
                ListaFiltraEmpleados.Enabled = false;
            }
        }
        private void AgregarComboFiltroSeccion(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraSeccion.AutoSize = true;
            chkFiltraSeccion.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraSeccion.Location = new Point(CheckX, CheckY);
            chkFiltraSeccion.Size = new System.Drawing.Size(57, 17);
            chkFiltraSeccion.Name = "chkFiltraSeccion";
            chkFiltraSeccion.Text = "Sección";
            CheckY = CheckY + 25;
            Controls.Add(chkFiltraSeccion);
            chkFiltraSeccion.CheckedChanged += chkFiltraSeccion_CheckedChanged;

            cmbFiltraSeccion.Location = new Point(ControlX, ControlY);
            cmbFiltraSeccion.Size = new System.Drawing.Size(350, 17);
            cmbFiltraSeccion.Enabled = false;
            cmbFiltraSeccion.DropDownStyle = ComboBoxStyle.DropDownList;
            ControlY = ControlY + 24;

            Controls.Add(cmbFiltraSeccion);

            btnBuscarY = btnBuscarY + 24;
        }

        private void chkFiltraSeccion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSeccion(chkFiltraSeccion, cmbFiltraSeccion);
        }      
        private void frmPantallaEspera_Shown(object sender, EventArgs e)
        {
            ListarInformes();
            PantallaEspera.Close();
        }
        //CheckBox chkFiltraStockMin = new CheckBox();
        //CheckBox chkFiltraConExistencia = new CheckBox();
        //CheckBox chkFiltraSinExistencia = new CheckBox();

        private void AgregarFiltraStockMin(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraStockMin.AutoSize = true;
            chkFiltraStockMin.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraStockMin.Location = new Point(CheckX, CheckY);
            chkFiltraStockMin.Size = new System.Drawing.Size(57, 17);
            chkFiltraStockMin.Name = "chkFiltraStockMin";
            chkFiltraStockMin.Text = "Muestra mercaderia por debajo del stock minimo";
            CheckY = CheckY + 25;
            ControlY = ControlY + 24;
            Controls.Add(chkFiltraStockMin);
        }
        private void AgregarFiltroStockConExistencia(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraConExistencia.AutoSize = true;
            chkFiltraConExistencia.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraConExistencia.Location = new Point(CheckX, CheckY);
            chkFiltraConExistencia.Size = new System.Drawing.Size(57, 17);
            chkFiltraConExistencia.Name = "chkFiltraConExistencia";
            chkFiltraConExistencia.Text = "Muestra mercaderia con existencia";
            CheckY = CheckY + 25;
            ControlY = ControlY + 24;
            Controls.Add(chkFiltraConExistencia);
        }
        private void AgregarFiltroStockSinExistencia(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraSinExistencia.AutoSize = true;
            chkFiltraSinExistencia.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraSinExistencia.Location = new Point(CheckX, CheckY);
            chkFiltraSinExistencia.Size = new System.Drawing.Size(57, 17);
            chkFiltraSinExistencia.Name = "chkFiltraSinExistencia";
            chkFiltraSinExistencia.Text = "Muestra mercaderia sin existencia";
            CheckY = CheckY + 25;
            ControlY = ControlY + 24;
            Controls.Add(chkFiltraSinExistencia);
        }

        private void MostrarPantallaEspera()
        {
            PantallaEspera = new frmPantallaEspera();
            VisorReporte = new frmReporte();
            PantallaEspera.textBox1.Text = "Cargando informe";

            PantallaEspera.Shown += new System.EventHandler(frmPantallaEspera_Shown);
            PantallaEspera.ShowDialog();
        }
        private void ListarInformes()
        {
            if (Informe == "rptMaestroDePedidos") // rptMaestroDePedidos
            {
                clsQueryInformes.rptMaestroPedidos(chkFiltraProducto, cmbFiltraProducto, chkFiltraEstadoPed, cmbFiltraEstadoPed, VisorReporte);
            }
            if (Informe == "rptCostoMaterialProducto") // rptCostoMaterialProducto
            {
                clsQueryInformes.rptCostoMaterialProducto(chkFiltraProducto, cmbFiltraProducto, VisorReporte);
            }
            if (Informe == "rptListadoCostoInsumo") // rptListadoCostoInsumo
            {
                clsQueryInformes.rptListadoCostoInsumo(chkFiltraInsumo, cmbFiltraInsumo, VisorReporte);
            }
            if (Informe == "Produccion diaria") // rptProduccionDiaria
            {
                clsQueryInformes.rptProduccionDiaria(chkFiltraProducto, cmbFiltraProducto, chkFiltraFechaDesde, chkFiltraFechaHasta, dtpFiltraFechaDesde, dtpFiltraFechaHasta, VisorReporte);
            }
            if (Informe == "Resumen maestro") // rptResumenMaestro
            {
                clsQueryInformes.rptResumenMaestro(chkFiltraFechaDesde, chkFiltraFechaHasta, dtpFiltraFechaDesde, dtpFiltraFechaHasta, chkFiltraCliente, cmbFiltraCliente, chkFiltraMedioPago,cmbFiltraMedioPago,VisorReporte);
            }
            if (Informe == "Produccion por empleado")
            {
                clsQueryInformes.rptProduccionEmpleado(chkFiltraInsumo, cmbFiltraInsumo, chkFiltraFechaDesde, chkFiltraFechaHasta, dtpFiltraFechaDesde, dtpFiltraFechaHasta, chkFiltraListaEmpleado, ListaFiltraEmpleados, VisorReporte);
            }
            if (Informe == "Produccion por empleado por sección")
                clsQueryInformes.rptProduccionEmpleadoSeccion(dtpFiltraFechaDesde, dtpFiltraFechaHasta, chkFiltraSeccion, cmbFiltraSeccion, chkFiltraProducto, cmbFiltraProducto, chkFiltraInsumo, cmbFiltraInsumo, chkFiltraListaEmpleado, ListaFiltraEmpleados, chkFiltraFechaDesde, chkFiltraFechaHasta, VisorReporte);
            if (Informe == "Stock mercaderia")
                clsQueryInformes.rptStockMercaderia(chkFiltraInsumo, cmbFiltraInsumo, dtpFiltraFechaDesde, 1, chkFiltraStockMin, chkFiltraConExistencia, chkFiltraSinExistencia, VisorReporte);
            if (InformeID == 9)
            {
                var report = new Borrar();

                using (var hb = new DBdatos())
                {
                    var consulta = (from C in hb.VistaDetalleMovimientos
                                    where C.Comprobante == "TICKET"
                                    select C);

                    DataTable DS = new DataTable();

                  



                    DataColumn colID = new DataColumn("ID");
                    DataColumn colComprobante = new DataColumn("Comprobante");
                    DataColumn colCodComprobante = new DataColumn("CodComprobante");
                    DataColumn colNumeroComprobante = new DataColumn("NumeroComprobante");
                    DataColumn colCantidad = new DataColumn("Cantidad");
                    colCantidad.DataType = System.Type.GetType("System.Decimal");
                    DataColumn colPrecio = new DataColumn("Precio");
                    colPrecio.DataType = System.Type.GetType("System.Decimal");
                    DataColumn colTotal = new DataColumn("Total");
                    colTotal.DataType = System.Type.GetType("System.Decimal");

                    DS.Columns.Add(colID);
                    DS.Columns.Add(colComprobante);
                    DS.Columns.Add(colCodComprobante);
                    DS.Columns.Add(colNumeroComprobante);
                    DS.Columns.Add(colCantidad);
                    DS.Columns.Add(colPrecio);
                    DS.Columns.Add(colTotal);

                    var Resultados = consulta.ToList();


                    foreach (var item in Resultados)
                    {


                        DS.Rows.Add
                        (new object[] {
                                item.ID,
                                item.Comprobante,
                                item.CodComprobante,
                                item.Numero_comprobante,
                                item.Cantidad,
                                item.Precio,
                                item.Total
                        });
                     
                    }




                    report.SetDataSource(DS);
                  
                    VisorReporte.crystalReportViewer1.ReportSource = report;
                    VisorReporte.Informe = report;

                  
                    VisorReporte.Show();





                }
            }
            if (Informe == "Ordenes de carga")
                clsQueryInformes.rptOrdenCarga(chkFiltraNumOredenCarga, txtFiltraNumOrdenCarga, chkFiltraCliente, cmbFiltraCliente, chkFiltraChofer, cmbFiltraChofer, dtpFiltraFechaDesde, dtpFiltraFechaHasta, VisorReporte);
            if (Informe == "Stock por lote")
                clsQueryInformes.rptStockPorLote(chkFiltraProducto, cmbFiltraProducto, chkFiltraNumOredenCarga, txtFiltraNumOrdenCarga, chkFiltraFechaDesde, dtpFiltraFechaDesde,VisorReporte);
            if (Informe == "Resumen de cuenta")
                clsQueryInformes.rptResumenCuenta(chkFiltraCliente, cmbFiltraCliente , VisorReporte);
            if (Informe == "Movimientos Diarios")
                clsQueryInformes.rptMovientosDiariosTicket(chkFiltraProducto, cmbFiltraProducto, dtpFiltraFechaDesde,dtpFiltraFechaHasta,VisorReporte);
            if (Informe == "Lista de precio Codigos")
                clsQueryInformes.rptListaPrecioCode(chkFiltraRubro,cmbFiltraRubro,VisorReporte);


        }
        private void AgregarComboFiltroMedioPago(ref int CheckX, ref int CheckY, ref int ControlX, ref int ControlY, ref int BtnX, ref int BtnY, Control.ControlCollection Controls)
        {
            chkFiltraMedioPago.AutoSize = true;
            chkFiltraMedioPago.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            chkFiltraMedioPago.Location = new Point(CheckX, CheckY);
            chkFiltraMedioPago.Size = new System.Drawing.Size(57, 17);
            chkFiltraMedioPago.Name = "chkFiltraMedioPago";
            chkFiltraMedioPago.Text = "Medio Pago";
            CheckY = CheckY + 25;
            Controls.Add(chkFiltraMedioPago);
            chkFiltraMedioPago.CheckedChanged += chkFiltraMedioPago_CheckedChanged;

            cmbFiltraMedioPago.Location = new Point(ControlX, ControlY);
            cmbFiltraMedioPago.Size = new System.Drawing.Size(350, 17);
            cmbFiltraMedioPago.Enabled = false;
            cmbFiltraMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            ControlY = ControlY + 24;

            Controls.Add(cmbFiltraMedioPago);

            btnBuscarY = btnBuscarY + 24;
        }

        private void chkFiltraMedioPago_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroMedioPago(chkFiltraMedioPago, cmbFiltraMedioPago);
        }

        private void btnListarInforme_Click(object sender, EventArgs e)
        {
            MostrarPantallaEspera();
        }

        private void btnListarInf_Click(object sender, EventArgs e)
        {
            MostrarPantallaEspera();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
