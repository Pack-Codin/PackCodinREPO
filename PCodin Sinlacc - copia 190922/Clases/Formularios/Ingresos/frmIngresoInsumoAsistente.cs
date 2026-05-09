using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Clases.Formularios.Ingresos
{
    public class frmIngresoInsumoAsistente
    {
        public static void CalcularTotal(DataGridView DGV,TextBox txtImporteTotal)
        {
            if (DGV.RowCount > 0)
            {
                decimal Total = 0;

                for (var i = 1; i <= DGV.RowCount; i++)
                {
                    decimal TotalFila = 0;

                    string Cantidad = DGV.Rows[i - 1].Cells["colCantidad"].Value.ToString();
                    string Costo = DGV.Rows[i - 1].Cells["colCosto"].Value.ToString();

                    if (!Cantidad.Contains(",") && Cantidad.Contains("."))
                        Cantidad = Cantidad.ToString().Replace(".", ",");
                    else
                        Cantidad = Cantidad.ToString();

                    if (!Costo.Contains(",") && Costo.Contains("."))
                        Costo = Costo.ToString().Replace(".", ",");
                    else
                        Costo = Costo.ToString();

                    TotalFila = Convert.ToDecimal(Cantidad) * Convert.ToDecimal(Costo);
                    DGV.Rows[i - 1].Cells["colImporteTotal"].Value = TotalFila.ToString("N2");
                    Total = Total + Convert.ToDecimal(DGV.Rows[i - 1].Cells["colImporteTotal"].Value);
                }
                txtImporteTotal.Text = Total.ToString("N2");
            }
        }
    }
}
