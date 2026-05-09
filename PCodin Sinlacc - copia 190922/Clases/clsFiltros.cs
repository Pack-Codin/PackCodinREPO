using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Clases
{
    public class clsFiltros
    {
        public static void FiltroActivar(TextBox txt)
        {
            txt.Visible = true;
            txt.Select();
        }
        public static void FiltroProductoInsumoBuscar( string Control ,object sender, KeyPressEventArgs e, TextBox txt, ComboBox cmb , string InsPro , string SubProducto)
        {
            if (Control == "Text")
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    txt.Visible = false;
                    clsCargarCombos.MostrarComboInsProSinCheck(cmb, txt, InsPro, true, SubProducto);
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
            if(Control == "Combo")
            {
                if (e.KeyChar == Convert.ToChar(Keys.Escape))
                {
                    clsCargarCombos.MostrarComboInsProSinCheck(cmb, txt, InsPro, false, SubProducto);
                    txt.Focus();
                    e.Handled = true;
                }
            }
        }
    
    }
}
