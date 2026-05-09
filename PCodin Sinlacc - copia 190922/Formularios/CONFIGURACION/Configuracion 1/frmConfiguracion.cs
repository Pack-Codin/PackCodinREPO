using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Clases;
using System.IO;

namespace PCodin_Sinlacc.Formularios.Configuracion
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }
        bool Inicia = true;
        private frmConfigMateriales frmConfigMateriales = new frmConfigMateriales();
        private frmConfigProduccion frmConfigProduccion = new frmConfigProduccion();
        private frmConfigConfiguracion frmConfigConfiguracion = new frmConfigConfiguracion();

        public int UsuarioID;
        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbGrupo.SelectedIndex == 0)
            //{
            //    AbrirFormulariosEnPanel.AbrirFormulariosHijos(frmConfigMateriales, pnlConfig, label1);
            //}

            if(cmbGrupo.SelectedValue != null && Inicia == false)
            {
                if ((int)cmbGrupo.SelectedValue == 0) //PRODUCCION
                {
                    if (pnlConfig.Controls.Count > 0)
                    {
                        pnlConfig.Controls.RemoveAt(0);
                    }

                    frmConfigProduccion.UsuarioID = UsuarioID;
                    frmConfigProduccion.TopLevel = false;
                    frmConfigProduccion.ModuloID = (int)cmbGrupo.SelectedValue;
                    pnlConfig.Controls.Add(frmConfigProduccion);
                    pnlConfig.Tag = frmConfigProduccion;
                    frmConfigProduccion.WindowState = FormWindowState.Maximized;
                    frmConfigProduccion.Show();
                }
                if ((int)cmbGrupo.SelectedValue == 1) //MATERIALES
                {
                    if (pnlConfig.Controls.Count > 0)
                    {
                        pnlConfig.Controls.RemoveAt(0);
                    }
                    //var f = new frmConfigMateriales();
                    frmConfigMateriales.TopLevel = false;
                    frmConfigMateriales.ModuloID = (int)cmbGrupo.SelectedValue;
                    pnlConfig.Controls.Add(frmConfigMateriales);
                    pnlConfig.Tag = frmConfigMateriales;
                    frmConfigMateriales.WindowState = FormWindowState.Maximized;
                    frmConfigMateriales.Show();
                }
                if ((int)cmbGrupo.SelectedValue == 5) //CONFIGURACION
                {
                    if (pnlConfig.Controls.Count > 0)
                    {
                        pnlConfig.Controls.RemoveAt(0);
                    }
                    //var f = new frmConfigMateriales();
                    frmConfigConfiguracion.TopLevel = false;                  
                    pnlConfig.Controls.Add(frmConfigConfiguracion);
                    pnlConfig.Tag = frmConfigConfiguracion;
                    frmConfigConfiguracion.WindowState = FormWindowState.Maximized;
                    frmConfigConfiguracion.UsuarioID = UsuarioID;
                    frmConfigConfiguracion.Show();
                }
            }
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            clsCargarCombos.MostrarModulo(cmbGrupo);
            cmbGrupo.SelectedIndex = -1;
            Inicia = false;
            InicializarForm();
        }
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.PcnConfiguraciones
                                select C).FirstOrDefault();

                var ConsultaProduccionDiaria = (from P in hb.ConfigDiasProduccion
                                                select P).FirstOrDefault();

                if(Consulta != null)
                {
                    //MATERIALES
                    frmConfigMateriales.txtProdDiaria.Text = ConsultaProduccionDiaria.DiasProduccion.ToString();

                    if (Consulta.TrabajaConStockNegativo == "SI")
                        frmConfigMateriales.chkTrabajaStockNegativo.Checked = true;
                    else
                        frmConfigMateriales.chkTrabajaStockNegativo.Checked = false;

                    //PRODUCCION

                    if (Consulta.TipoDeposito == "BASE")
                        frmConfigProduccion.rdbBase.Checked = true;
                    else
                        frmConfigProduccion.rdbFull.Checked = true;
                }                
            }
        }
        private void CargarDatos()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaConfig = (from CONF in hb.PcnConfiguraciones
                                      //where CONF.Modulo_ID == (int)cmbGrupo.SelectedValue
                                      select CONF).FirstOrDefault();

                if (frmConfigMateriales.txtProdDiaria.TextLength > 0)
                {
                    var Consulta = (from DP in hb.ConfigDiasProduccion
                                    select DP);

                    var Resultados = Consulta.FirstOrDefault();

                    if (ConsultaConfig == null)
                    {
                        var i = new ConfigDiasProduccion();

                        i.DiasProduccion = Convert.ToInt16(frmConfigMateriales.txtProdDiaria.Text);

                        hb.ConfigDiasProduccion.Add(i);
                        hb.SaveChanges();
                        MessageBox.Show("Datos cargados correctamente", "Atención");
                    }
                    else
                    {
                        Resultados.DiasProduccion = Convert.ToInt16(frmConfigMateriales.txtProdDiaria.Text);
                    }

                    if (frmConfigMateriales.chkTrabajaStockNegativo.Checked)
                    {
                        ConsultaConfig.TrabajaConStockNegativo = "SI";
                    }
                    else
                    {
                        ConsultaConfig.TrabajaConStockNegativo = "NO";
                    }
                }
                else
                {
                    MessageBox.Show("No ingresó datos", "Atención");
                    return;
                }

                                                 // CONFIGURACION
                if(ConsultaConfig != null)
                {
                    if (frmConfigProduccion.rdbBase.Checked)
                        ConsultaConfig.TipoDeposito = "Base";
                    else
                        ConsultaConfig.TipoDeposito = "Full";
                }

                if (frmConfigConfiguracion.txtDireccion.TextLength > 0)
                {                   
                    byte[] file = null; // Carga la foto
                    Stream myStream = frmConfigConfiguracion.openFileDialog1.OpenFile();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        myStream.CopyTo(ms);
                        file = ms.ToArray();

                    }
                    ConsultaConfig.FondoInicio = file;
                }
                if(frmConfigConfiguracion.TemaSeleccionado != "")
                {
                    var ConsultaTema = (from UT in hb.USUARIOTEMA
                                        where UT.Usuario == UsuarioID
                                        select UT).FirstOrDefault();

                    ConsultaTema.Tema = frmConfigConfiguracion.TemaSeleccionado;
                }
                if(frmConfigConfiguracion.txtAncho.Text != "" && frmConfigConfiguracion.txtAlto.Text != "")
                {
                    var consultaPantalla = (from UP in hb.USUARIOCONFIG
                                            where UP.Usuario_ID == UsuarioID
                                            select UP).FirstOrDefault();

                    if(consultaPantalla == null)
                    {
                        var i = new USUARIOCONFIG();

                        i.AnchoPantalla = Convert.ToInt32(frmConfigConfiguracion.txtAncho.Text);
                        i.AltoPantalla = Convert.ToInt32(frmConfigConfiguracion.txtAlto.Text);
                        i.Usuario_ID = UsuarioID;

                        hb.USUARIOCONFIG.Add(i);
                    }
                    else
                    {
                        consultaPantalla.AnchoPantalla = Convert.ToInt32(frmConfigConfiguracion.txtAncho.Text);
                        consultaPantalla.AltoPantalla = Convert.ToInt32(frmConfigConfiguracion.txtAlto.Text);
                    }
                }
                
                hb.SaveChanges();
                MessageBox.Show("Datos cargados correctamente", "Atención");
            }
            
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
