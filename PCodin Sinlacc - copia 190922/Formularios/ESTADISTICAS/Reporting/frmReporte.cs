using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Datos;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PCodin_Sinlacc.Formularios.Reportes;
using System.IO;
using System.Diagnostics;
using PCodin_Sinlacc.Clases;
using System.Reflection;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }
        private frmPantallaEspera PantallaEspera = new frmPantallaEspera();
        public ReportDocument Informe = new ReportDocument();
        private void frmReporte_Load(object sender, EventArgs e)
        {
            AjustarLogo();
            Reutilizables.RenderizarForm(this);
        }
        private void frmReporte_Shown(object sender, EventArgs e)
        {
            // PantallaEspera.Close();
        }
        private void btnAjustarLogo_Click(object sender, EventArgs e)
        {

        }
        private void AjustarLogo() //DESCOMENTAR
        {
            //using (var hb = new DBdatos())
            //{
            //    var Consulta = (from L in hb.ClientesLogo
            //                    select L).FirstOrDefault();

            //    ((PictureObject)Informe.ReportDefinition.ReportObjects["Picture1"]).Width = Consulta.Ancho;
            //    ((PictureObject)Informe.ReportDefinition.ReportObjects["Picture1"]).Height = Consulta.Largo;

            //    crystalReportViewer1.ReportSource = Informe;
            //    //this.Informe.Refresh();
            //}
        }

        private void MostrarOcultarMenu()
        {
            if (pnlMenu.Visible == false)
                pnlMenu.Visible = true;
            else
                pnlMenu.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MostrarOcultarMenu();
        }
        private void AbrirFormAjustePagina()
        {
            var f = new frmAjustarInforme();
            f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAjustarInforme_FormClosed);
            f.ShowDialog();
        }

        private void frmAjustarInforme_FormClosed(object sender, FormClosedEventArgs e)
        {
            AjustarLogo();
        }

        private void btnAjustarInforme_Click(object sender, EventArgs e)
        {
            AbrirFormAjustePagina();
        }
        private void ChangeExportButton()
        {
            foreach (Control ctrl in crystalReportViewer1.Controls)
            {
                //Buscar toolstrip del visor de informes
                if (ctrl is ToolStrip)
                {
                    ToolStrip ts = (ToolStrip)ctrl;
                    foreach (ToolStripItem tsi in ts.Items)
                    {
                        //Buscar el botón exportar por un ImageIndex
                        if (tsi is ToolStripButton && tsi.ImageIndex == 8)
                        {

                            ToolStripButton crXb = (ToolStripButton)tsi;
                            //Clonar el aspecto
                            ToolStripButton tsb = new ToolStripButton();
                            tsb.Size = crXb.Size;
                            tsb.Padding = crXb.Padding;
                            tsb.Margin = crXb.Margin;
                            tsb.TextImageRelation = crXb.TextImageRelation;
                            tsb.Text = crXb.Text;
                            tsb.ToolTipText = crXb.ToolTipText;
                            tsb.ImageScaling = crXb.ImageScaling;
                            tsb.ImageAlign = crXb.ImageAlign;
                            tsb.ImageIndex = crXb.ImageIndex;
                            tsb.Visible = crXb.Visible;
                            tsb.Enabled = crXb.Enabled;
                            //Añadir el nuevo botón
                            ts.Items.Insert(0, tsb);
                            tsb.Click += new EventHandler(Export_Click);


                            break;
                        }
                    }
                }
            }
        }
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string CarpetaDocumentosTemp = "";
                string NombreArchivo = "";
                string RutaArchivo;

               
                if (clsVariablesGenerales.Modo == "Escritorio")
                    CarpetaDocumentosTemp = @"C:\DocsTemp";
                if (clsVariablesGenerales.Modo == "Mobile")
                    CarpetaDocumentosTemp = @"\\tsclient\Local Storage\Download";

               
               // string CarpetaDocumentosTemp = @"\\tsclient\C\DocsTemp";
               

                DirectoryInfo Busqueda = new DirectoryInfo(CarpetaDocumentosTemp);

                var Consulta = (from A in Busqueda.GetFiles()
                                orderby A.Name descending
                                select A).FirstOrDefault();

                if (clsVariablesGenerales.Modo == "Mobile")
                {
                    string Hora = DateTime.Now.ToShortTimeString();
                    Hora = Hora.Replace(":", "-");

                    NombreArchivo = Informe.Name + " " + Hora;
                }
                if (clsVariablesGenerales.Modo == "Escritorio")
                {
                    if (Consulta == null)
                    {
                        NombreArchivo = "01";
                    }
                    else
                    {
                        NombreArchivo = Consulta.Name;
                        if (NombreArchivo.Contains(".pdf"))
                            NombreArchivo = NombreArchivo.Replace(".pdf", "");
                        if (NombreArchivo.Contains(".xlsx"))
                            NombreArchivo = NombreArchivo.Replace(".xlsx", "");

                        List<string> Lista = new List<string>();

                        Lista.Add("01");
                        Lista.Add("02");
                        Lista.Add("03");
                        Lista.Add("04");
                        Lista.Add("05");
                        Lista.Add("06");
                        Lista.Add("07");
                        Lista.Add("08");
                        Lista.Add("09");

                        if (Lista.Contains(NombreArchivo))
                        {
                            if(NombreArchivo == "09")
                                NombreArchivo = (Convert.ToInt32(NombreArchivo) + 1).ToString();
                            else
                                NombreArchivo = "0" + (Convert.ToInt32(NombreArchivo) + 1).ToString();
                        }
                        else
                            NombreArchivo = (Convert.ToInt32(NombreArchivo) + 1).ToString();
                    }
                }
                RutaArchivo = @"" + CarpetaDocumentosTemp + @"\" + NombreArchivo + ".pdf";
                
                Informe.ExportToDisk(ExportFormatType.PortableDocFormat, RutaArchivo);
                MessageBox.Show("EXPORTACION CORRECTA", "Atencion");

                if (clsVariablesGenerales.Modo == "Mobile")
                    Process.Start(RutaArchivo);

            }
            catch (Exception Error)
            {

                MessageBox.Show(Error.Message);
            }
                        




            //foreach (var Controles in Informe.Subreports)
            //{

            //    ReportDocument D = new ReportDocument();
            //    D.Subreports[0].ex
            //    D = ((CrystalDecisions.CrystalReports.Engine.Subreports)Controles);

            //    D[0].ExportToDisk(ExportFormatType.PortableDocFormat, RutaArchivo);

            //        //D.ExportToDisk(ExportFormatType.PortableDocFormat, RutaArchivo);
            //        Process.Start(RutaArchivo);

            //}


            // Informe.ExportToDisk(ExportFormatType.PortableDocFormat, RutaArchivo);


            //ReportDocument SubInforme = (ReportDocument)crystalReportViewer1.ReportSource;
            //SubInforme.ExportToDisk(ExportFormatType.PortableDocFormat, RutaArchivo);

            //Process.Start(RutaArchivo);
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmReporte_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Export_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
