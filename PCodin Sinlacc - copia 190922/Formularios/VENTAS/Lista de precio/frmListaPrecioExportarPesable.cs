using Microsoft.Win32;
using PCodin_Sinlacc.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios.VENTAS.Lista_de_precio
{
    public partial class frmListaPrecioExportarPesable : Form
    {
        public frmListaPrecioExportarPesable()
        {
            InitializeComponent();
        }
        private void ExportarPesable()
        {
            using (var hb = new DBdatos())
            {
                if (cmbBalanzaTipo.SelectedIndex != -1 && txtRuta.Text != "")
                {
                    try
                    {
                        var ConsultaPensable = (from C in hb.LISTAPRECIOCUERPO
                                                where C.Productos_Insumos.PLU != null
                                                    && C.Productos_Insumos.Estado == "SI"
                                                select C).ToList();

                        if (cmbBalanzaTipo.Text == "Cuora Max")
                        {
                            string rutaArchivo = Path.Combine(txtRuta.Text);

                            using (StreamWriter sw = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
                            {
                                // Cabecera EXACTA
                                sw.WriteLine("Nombre de la sección:;Código de PLU;Descripción;Número de PLU;Precio Lista 1;Precio Lista 2;Tipo de Venta;Vencimiento;Otros;Tara");

                                foreach (var item in ConsultaPensable)
                                {
                                    var prod = item.Productos_Insumos;

                                    string seccion = prod.Categorias_InsPro.Descripcion;
                                    string codigoPLU = prod.PLU.ToString();
                                    string descripcion = prod.Descripcion ?? "";
                                    string numeroPLU = prod.PLU.ToString();

                                    string precio1 = item.Precio.ToString();
                                    string precio2 = item.Precio.ToString();

                                    string tipoVenta = "Peso"; // P = Pesable (puede cambiar según tu lógica)
                                    string vencimiento = "0";
                                    string otros = "";
                                    string tara = "0";

                                    string linea = string.Join(";",
                                        seccion,
                                        codigoPLU,
                                        descripcion,
                                        numeroPLU,
                                        precio1,
                                        precio2,
                                        tipoVenta,
                                        vencimiento,
                                        otros,
                                        tara
                                    );

                                    sw.WriteLine(linea);
                                }
                            }

                            MessageBox.Show("CSV exportado correctamente.");
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Error");
                    }
                    
                }
            }
        }
        private void SeleccionarArchivo()
        {
            try
            {
                using (System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog())
                {
                    sfd.Title = "Guardar archivo CSV";
                    sfd.Filter = "Archivo CSV (*.csv)|*.csv";
                    sfd.FileName = "PreciosCUORAMAX.csv"; // nombre sugerido
                    sfd.DefaultExt = "csv";
                    sfd.AddExtension = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        txtRuta.Text = sfd.FileName;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message,"Error");
            }
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarPesable();
        }

        private void btnElegirRuta_Click(object sender, EventArgs e)
        {
            SeleccionarArchivo();
        }
    }
}
