using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCodin_Sinlacc.Datos;
using System.Windows.Forms;
using PCodin_Sinlacc.Formularios;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms.DataVisualization.Charting;

namespace PCodin_Sinlacc.Clases.Formularios
{
    public class clsfrmIngresoInsumoaAgregar
    {
        public static void BuscarPorCodigoBarra(TextBox txtCodigoBarra , ComboBox cmbArticulo ,TextBox txtCosto)
        {
            using (var hb = new DBdatos())
            {
                if(txtCodigoBarra.Text != "")
                {
                    try
                    {
                        var ConsultaCodigoBarra = (from CB in hb.CODIGOBARRA
                                                   where CB.CodigoBarra1 == txtCodigoBarra.Text
                                                   select CB).FirstOrDefault();

                        if (ConsultaCodigoBarra != null)
                        {
                            var ConsultaCosto = (from CO in hb.LISTAPRECIOCUERPO
                                                 where CO.Articulo_ID == ConsultaCodigoBarra.Producto_ID
                                                 select CO).FirstOrDefault();

                            clsCargarCombos.MostrarComboArticuloPorCodigo(cmbArticulo, ConsultaCodigoBarra.Producto_ID);

                            cmbArticulo.Text = ConsultaCodigoBarra.Productos_Insumos.Descripcion;
                            cmbArticulo.SelectedValue = ConsultaCodigoBarra.Producto_ID;
                            
                            txtCosto.Text = ConsultaCosto.Precio.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No existe articulo con el Código de barras " + txtCodigoBarra.Text);
                            return;
                        }
                    }
                   
                    
                     catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                }
            }
        }
    }
}
