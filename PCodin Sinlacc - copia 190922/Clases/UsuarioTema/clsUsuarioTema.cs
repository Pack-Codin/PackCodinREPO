using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCodin_Sinlacc.Datos;
using System.Windows.Forms;
using System.Drawing;

namespace PCodin_Sinlacc.Clases.UsuarioTema
{
    class clsUsuarioTema
    {
        public static void UsuarioTema(int UsuarioID , Panel pnlMenu , Panel pnlInferior ,Form Formulario)
        {
            using (var hb = new DBdatos())
            {
                var ConsultaTema = (from UT in hb.USUARIOTEMA
                                    where UT.Usuario == UsuarioID
                                    select UT).FirstOrDefault();

                if (ConsultaTema.Tema != "PACK-CODIN")
                {
                    string ColorBotonesYpanel = "";
                    string ColorFocoBotones = "";
                    string ColorFondoDGV = "";
                    string ColorFilasDatagridView = "";
                    string ColorFuenteFilasDGV = "";
                    string ColorFuenteFilasDGVSeleccionada = "";
                    string ColorBordeBotonesCargar = "";
                    string ColorEncabezadoDGV = "";
                    string ColorPaneles = "";
                    string ColorLinea = "";
                    string ColorFormulario = "";
                    string ColorBotonesCargar = "";

                    if (ConsultaTema.Tema == "PINKY")
                    {
                        ColorBotonesYpanel = "Pink";
                        ColorBotonesCargar = "Black";
                        ColorFocoBotones = "HotPink";
                        ColorFondoDGV = "LavenderBlush";
                        ColorFilasDatagridView = "Pink";
                        ColorFuenteFilasDGV = "Black";
                        ColorBordeBotonesCargar = "HotPink";
                        ColorEncabezadoDGV = "HotPink";
                        ColorPaneles = "Pink";
                        ColorLinea = "HotPink";
                        ColorFuenteFilasDGVSeleccionada = "Black";
                        ColorFormulario = "LavenderBlush";
                    }
                    if (ConsultaTema.Tema == "CARBON")
                    {
                        ColorBotonesYpanel = "DimGray";
                        ColorBotonesCargar = "WhiteSmoke";
                        ColorFocoBotones = "MediumTurquoise";
                        ColorFondoDGV = "DimGray";
                        ColorFilasDatagridView = "MediumTurquoise";
                        ColorFuenteFilasDGV = "WhiteSmoke";
                        ColorBordeBotonesCargar = "White";
                        ColorEncabezadoDGV = "MediumTurquoise";
                        ColorPaneles = "DimGray";
                        ColorLinea = "MediumTurquoise";
                        ColorFuenteFilasDGVSeleccionada = "Black";
                        ColorFormulario = "DimGray";
                    }
                    Formulario.BackColor = Color.FromName(ColorFormulario);
                    pnlMenu.BackColor = Color.FromName(ColorBotonesYpanel);
                    pnlInferior.BackColor = Color.FromName(ColorPaneles);

                    foreach (var Control in pnlMenu.Controls)
                    {
                        if (((Control)Control) is TreeView)
                        {
                            ((TreeView)Control).BackColor = Color.FromName(ColorFondoDGV);
                        }
                        if (((Control)Control) is Button)
                        {
                            ((Button)Control).FlatAppearance.MouseOverBackColor = Color.FromName(ColorFocoBotones);
                            ((Button)Control).FlatAppearance.MouseDownBackColor = Color.FromName(ColorBotonesYpanel);
                            ((Button)Control).BackColor = Color.FromName(ColorBotonesYpanel);
                        }
                    }
                    foreach (var Control in Formulario.Controls)
                    {
                        if (((Control)Control) is Button)
                        {
                            ((Button)Control).FlatAppearance.MouseOverBackColor = Color.FromName(ColorFocoBotones);
                            ((Button)Control).FlatAppearance.BorderColor = Color.FromName(ColorBotonesYpanel);
                        }
                        if (((Control)Control) is DataGridView)
                        {
                            ((DataGridView)Control).GridColor = Color.FromName(ColorFondoDGV);
                            ((DataGridView)Control).DefaultCellStyle.SelectionBackColor = Color.FromName(ColorFilasDatagridView);
                            ((DataGridView)Control).ColumnHeadersDefaultCellStyle.ForeColor = Color.FromName(ColorEncabezadoDGV);
                        }                      
                        if (((Control)Control) is Panel)
                        {
                            if (((Control)Control) is Panel)
                            {
                                
                                if (((Control)Control).Name.Contains("pnlSuperior"))
                                {
                                    foreach (var ControlesPnlSuperior in ((Control)Control).Controls)
                                    {
                                        if (((Control)ControlesPnlSuperior) is Label)
                                        {
                                            ((Control)ControlesPnlSuperior).ForeColor = Color.FromName(ColorFuenteFilasDGV);
                                        }
                                        if (((Control)ControlesPnlSuperior) is TextBox)
                                        {
                                            ((Control)ControlesPnlSuperior).BackColor = Color.FromName(ColorFormulario);
                                            ((Control)ControlesPnlSuperior).ForeColor = Color.FromName(ColorFuenteFilasDGV);
                                        }
                                    }
                                }
                                if (((Control)Control).Name == "pnlCentral")
                                {
                                    foreach (var ControlesPnlCentral in ((Control)Control).Controls)
                                    {
                                        if (((Control)Control) is DataGridView)
                                        {
                                            ((DataGridView)Control).GridColor = Color.FromName(ColorFondoDGV);
                                            ((DataGridView)Control).DefaultCellStyle.SelectionBackColor = Color.FromName(ColorFilasDatagridView);
                                            ((DataGridView)Control).ColumnHeadersDefaultCellStyle.ForeColor = Color.FromName(ColorEncabezadoDGV);
                                        }
                                        if (((Control)ControlesPnlCentral) is Label)
                                        {
                                            ((Control)ControlesPnlCentral).ForeColor = Color.FromName(ColorFuenteFilasDGV);                                         
                                        }
                                        if (((Control)ControlesPnlCentral).Name == "pnlLinea")
                                            ((Control)ControlesPnlCentral).BackColor = Color.FromName(ColorLinea);
                                    }                                                                                                      
                                }                                   
                            }

                            foreach (var Control2 in ((Panel)Control).Controls)
                            {
                               
                                if (((Control)Control2) is DataGridView)
                                {   //DGV BACKCOLOR
                                    ((DataGridView)Control2).BackgroundColor = Color.FromName(ColorFondoDGV);
                                    ((DataGridView)Control2).GridColor = Color.FromName(ColorFondoDGV);
                                    //FILAS
                                    ((DataGridView)Control2).DefaultCellStyle.ForeColor = Color.FromName(ColorFuenteFilasDGV);
                                    ((DataGridView)Control2).DefaultCellStyle.SelectionForeColor = Color.FromName(ColorFuenteFilasDGVSeleccionada);
                                    ((DataGridView)Control2).RowTemplate.DefaultCellStyle.BackColor = Color.FromName(ColorFondoDGV);
                                    ((DataGridView)Control2).DefaultCellStyle.SelectionBackColor = Color.FromName(ColorFilasDatagridView);
                                    //ENCABEZADOS
                                    ((DataGridView)Control2).ColumnHeadersDefaultCellStyle.ForeColor = Color.FromName(ColorEncabezadoDGV);
                                    ((DataGridView)Control2).ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromName(ColorEncabezadoDGV);
                                    ((DataGridView)Control2).ColumnHeadersDefaultCellStyle.BackColor = Color.FromName(ColorFondoDGV);
                                    ((DataGridView)Control2).ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromName(ColorFondoDGV);
                                }
                            }
                        }
                    }

                    foreach (var Control in pnlInferior.Controls)
                    {
                        if (((Control)Control) is Label)
                        {
                            ((Label)Control).BackColor = Color.FromName(ColorBotonesYpanel);
                        }
                        if (((Control)Control) is Button)
                        {
                            ((Button)Control).ForeColor = Color.FromName(ColorBotonesCargar);
                        }
                    }
                   
                   
                }
            }
        }
        public static void UsuarioTemaMenuPrincipal(int UsuarioID, Label labelCliente , Panel PanelSuperior)
        {
            using (var hb = new DBdatos())
            {
                string ColorBotonesYpanel = "";
                string ColorFocoBotones = "";
                string ColorLabels = "";

                var ConsultaTema = (from UT in hb.USUARIOTEMA
                                    where UT.Usuario == UsuarioID
                                    select UT).FirstOrDefault();

                if (ConsultaTema.Tema == "PACK-CODIN")
                {
                    ColorBotonesYpanel = "Orange";
                    ColorFocoBotones = "Orange";
                    ColorLabels = "Orange";
                }
                if (ConsultaTema.Tema == "PINKY")
                {
                    ColorBotonesYpanel = "Pink";
                    ColorFocoBotones = "HotPink";
                    ColorLabels = "Pink";
                }
                foreach (var Control in PanelSuperior.Controls)
                {
                    if (((Control)Control) is Button)
                    {
                        ((Button)Control).FlatAppearance.MouseOverBackColor = Color.FromName(ColorFocoBotones);
                    }
                }
                labelCliente.ForeColor = Color.FromName(ColorFocoBotones);
            }
        }
    }
}
