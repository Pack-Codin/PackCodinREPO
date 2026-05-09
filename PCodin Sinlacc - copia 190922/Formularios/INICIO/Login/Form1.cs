using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Formularios.Circuito_Productivo;
using PCodin_Sinlacc.Formularios.Configuracion;
using PCodin_Sinlacc.Formularios.Deposito;
using PCodin_Sinlacc.Formularios.Gastos;
using PCodin_Sinlacc.Formularios.MANTENIMIENTO;
using PCodin_Sinlacc.Formularios.MATERIALES.frmIngresoInsumo;
using PCodin_Sinlacc.Formularios.Orden_Produccion;
using PCodin_Sinlacc.Formularios.Productos___Insumos;
using PCodin_Sinlacc.Formularios.Secciones;
using PCodin_Sinlacc.Formularios.VENTAS.Lista_de_precio;
using PCodin_Sinlacc.Formularios.VENTAS.Ticket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios.INICIO.Login
{
    public partial class frmCargandoSistema : Form
    {
        public frmCargandoSistema()
        {
            InitializeComponent();
        }
        
        private void frmCargandoSistema_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private async void InicializarForm()
        {
            RenderizarForm();

            timer1.Enabled = true;
        }
        private async void RenderizarForm()
        {
            clsVariablesGenerales.WPantalla = (int)SystemParameters.FullPrimaryScreenWidth;
            clsVariablesGenerales.HPantalla = (int)SystemParameters.FullPrimaryScreenHeight;

            pnlLeft.Size = new System.Drawing.Size(clsVariablesGenerales.WPantalla / 3, clsVariablesGenerales.HPantalla);
            pnlCenter.Size = new System.Drawing.Size(clsVariablesGenerales.WPantalla / 3, clsVariablesGenerales.HPantalla);
            pnlRight.Size = new System.Drawing.Size(clsVariablesGenerales.WPantalla / 3, clsVariablesGenerales.HPantalla);

            pnlCenter1.Size = new System.Drawing.Size(clsVariablesGenerales.WPantalla / 3, clsVariablesGenerales.HPantalla / 4);
            pnlCenter2.Size = new System.Drawing.Size(clsVariablesGenerales.WPantalla / 3, clsVariablesGenerales.HPantalla / 2);
            pnlCenter3.Size = new System.Drawing.Size(clsVariablesGenerales.WPantalla / 3, clsVariablesGenerales.HPantalla / 4);

           



        //this.Size = new System.Drawing.Size((int)SystemParameters.FullPrimaryScreenWidth, (int)SystemParameters.FullPrimaryScreenHeight + 20);
        //this.Location = new System.Drawing.Point(0, 0);
        //pnlCentral.Size = new System.Drawing.Size(this.Width - pnlMenu.Width, this.Height - pnlSuperior.Height);

    }

    private async void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;
            this.Close();
        }
    }
}
