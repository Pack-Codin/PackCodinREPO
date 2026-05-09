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
using PCodin_Sinlacc.Clases;
using System.Data.Entity;
using PCodin_Sinlacc.Formularios.MATERIALES.Gestor_de_materiales.Insumos;
using Microsoft.Office.Interop.Excel;
using TextBox = System.Windows.Forms.TextBox;

namespace PCodin_Sinlacc.Formularios.VENTAS.Lista_de_precio
{
    public partial class frmListaPrecio : Form
    {
        clsImprimirPlantilla C = new clsImprimirPlantilla();
        public frmListaPrecio()
        {
            InitializeComponent();
        }
        bool Incio = false;
        string ValorOriginal;
    
        private void frmListaPrecio_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
                         
            clsCargarCombos.MostrarCombomListaPrecio(cmbListaPrecio,0);
            cmbListaPrecio.SelectedIndex = -1;

            MostrarDatos();
        }
        private void MostrarDatos()
        {
            if (Incio == true)
            {
                using (var hb = new DBdatos())
                {
                    if (cmbListaPrecio.SelectedValue != null)
                    {
                        dgvListaPrecio.Rows.Clear();
                        int CantidadRegistros = 0;

                        var ConsultaActualizacion = (from LP in hb.LISTAPRECIO
                                                     where LP.ID == (int)cmbListaPrecio.SelectedValue
                                                     select LP).FirstOrDefault();

                        if(ConsultaActualizacion != null && ConsultaActualizacion.UltimaActualizacion != null)
                        {
                            lblUltimaActualizacion.Text = ConsultaActualizacion.UltimaActualizacion.Value.ToShortDateString() + " - " + ConsultaActualizacion.UltimaActualizacion.Value.ToShortTimeString();
                        }
                        else
                        {
                            lblUltimaActualizacion.Text = "";
                        }

                            var Consulta = (from LPC in hb.LISTAPRECIOCUERPO
                                            where LPC.ListaPrecio_ID == (int)cmbListaPrecio.SelectedValue
                                            select new
                                            {
                                                LPC.ID,
                                                LPC.Articulo_ID,
                                                LPC.Productos_Insumos.Descripcion,
                                                LPC.Costo,
                                                LPC.Precio,
                                                LPC.Productos_Insumos.Categoria_ID
                                            });

                        if (chkFiltraArticulo.Checked)
                            Consulta = (from C in Consulta
                                        where C.Articulo_ID == cmbFiltraInsPro.SelectedValue.ToString()
                                        select C);

                        if (chkFiltraCodigoBarra.Checked)
                        {
                            var ConsultaCodigoBarra = (from CB in hb.CODIGOBARRA
                                                       where CB.CodigoBarra1 == txtFiltraCodigoBarra.Text
                                                            && CB.Estado == "SI"
                                                       select CB).FirstOrDefault();

                            if (ConsultaCodigoBarra != null)
                            {
                                Consulta = (from C in Consulta
                                            where C.Articulo_ID == ConsultaCodigoBarra.Producto_ID
                                            select C);
                            }
                        }
                        if (chkFiltraCategoria.Checked)
                            Consulta = (from C in Consulta
                                        where C.Categoria_ID == (int)cmbFiltraCategoria.SelectedValue
                                        select C);

                        if (chkFiltraCosto.Checked)
                        {
                            try
                            {
                                decimal Costo1 = Convert.ToDecimal(txtFiltraCosto1.Text);
                                decimal Costo2 = Convert.ToDecimal(txtFiltraCosto2.Text);
                              
                                Consulta = (from C in Consulta
                                            where C.Costo >= Costo1 && C.Costo <= Costo2
                                            select C);
                            }
                            catch (Exception E)
                            {

                                MessageBox.Show(E.Message);
                            }
                        }
                        if (chkFiltraPrecio.Checked)
                        {
                            try
                            {
                                decimal Precio1 = Convert.ToDecimal(txtFiltraPrecio1.Text);
                                decimal Precio2 = Convert.ToDecimal(txtFiltraPrecio2.Text);

                                Consulta = (from C in Consulta
                                            where C.Precio >= Precio1 && C.Precio <= Precio2
                                            select C);
                            }
                            catch (Exception E)
                            {

                                MessageBox.Show(E.Message);
                            }
                        }

                        foreach (var item in Consulta)
                        {
                            CantidadRegistros++;                           
                            dgvListaPrecio.Rows.Add(item.ID,
                                                    item.Articulo_ID,
                                                    item.Descripcion,
                                                    item.Costo,
                                                    item.Precio
                                                    );

                        }
                        lblCantidad.Text = CantidadRegistros.ToString();
                    }
                }
            }
            Incio = true;
        }
        private void BuscarDatos()
        {
            System.Data.DataTable DT = new System.Data.DataTable();

            foreach (var ColumnaDGV in dgvListaPrecio.Columns)
            {
                DT.Columns.Add(((DataGridViewColumn)ColumnaDGV).Name);
            }
            foreach(var RowsDGV in dgvListaPrecio.Rows)
            {             
                
            }
            

            dgvListaPrecio.DataSource = DT;
            //    try
            //{
            //    foreach (var Row in dgvListaPrecio.Columns)
            //    {
                    
            //    }
            //    for (int i = 0; i < dgvListaPrecio.RowCount; i++)
            //    {
            //        dgvListaPrecio.Rows[i].DefaultCellStyle.BackColor = Color.White;
            //        dgvListaPrecio.Rows[i].DefaultCellStyle.SelectionBackColor = Color.PaleTurquoise;
            //        dgvListaPrecio.Rows[i].Visible = true;

            //        if (chkFiltraArticulo.Checked)
            //        {
            //            if (dgvListaPrecio.Rows[i].Cells["colCodigo"].Value.ToString() == cmbFiltraInsPro.SelectedValue.ToString())
            //            {
            //                dgvListaPrecio.Rows[i].DefaultCellStyle.BackColor = Color.Coral;
            //                dgvListaPrecio.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Coral;
            //                dgvListaPrecio.Rows[i].Visible = true;
            //            }
            //            else
            //            {
            //                dgvListaPrecio.Rows[i].Visible = false;
            //            }
            //        }

            //    }



                //DataTable DT = new DataTable();

                //foreach (DataGridViewColumn columna in this.dgvMercaderia.Columns)
                //{

                //}

                //dgvMercaderia.DataSource = DT;

                //var Consulta = (from C in DT.AsEnumerable()
                //                select C).FirstOrDefault();

                //dgvMercaderia.DataSource = DT;
                ////for (int i = 0; i < dgvMercaderia.RowCount; i++)
                ////{                  
                ////    DT.Columns.Add(dgvMercaderia.Columns[i].Name);
                ////}
                //for (int i = 0; i < dgvMercaderia.RowCount; i++)
                //{
                //    DT.Rows.Add(dgvMercaderia.Rows[i].Cells[])
            //    //}
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
        private void cmbListaPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void dgvListaPrecio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvListaPrecio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvListaPrecio.RowCount > 0)
            {
                if (this.dgvListaPrecio.Columns[e.ColumnIndex].Name == "colModificar")
                {
                    if (e.Value != null)
                    {
                        if (e.Value.ToString() == "*")
                        {
                            e.CellStyle.BackColor = Color.ForestGreen;
                            e.CellStyle.SelectionBackColor = Color.ForestGreen;
                            e.CellStyle.ForeColor = Color.White;
                            e.CellStyle.SelectionForeColor = Color.White;
                            e.CellStyle.Font = new System.Drawing.Font("Roboto Condensed", 10, FontStyle.Bold);
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.White;                           
                            e.CellStyle.ForeColor = Color.Black;
                            e.CellStyle.SelectionForeColor = Color.Black;
                        }
                    }
                }
            }       
        }

        private void dgvListaPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvListaPrecio_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvListaPrecio.Columns[e.ColumnIndex].Name == "colCosto" || this.dgvListaPrecio.Columns[e.ColumnIndex].Name == "colPrecio")
            {
                try
                {                   
                    if (!dgvListaPrecio.CurrentRow.Cells[e.ColumnIndex].Value.ToString().Contains(",") && dgvListaPrecio.CurrentRow.Cells[e.ColumnIndex].Value.ToString().Contains("."))
                        dgvListaPrecio.CurrentRow.Cells[e.ColumnIndex].Value = dgvListaPrecio.CurrentRow.Cells[e.ColumnIndex].Value.ToString().Replace(".", ",");
                    else
                        dgvListaPrecio.CurrentRow.Cells[e.ColumnIndex].Value = Convert.ToDecimal(dgvListaPrecio.CurrentRow.Cells[e.ColumnIndex].Value).ToString("N2");

                    dgvListaPrecio.CurrentRow.Cells["colModificar"].Value = "*";                  
                }
                catch (Exception)
                {
                    dgvListaPrecio.CurrentRow.Cells[e.ColumnIndex].Value = ValorOriginal;
                    dgvListaPrecio.CurrentRow.Cells["colModificar"].Value = "";
                }
            }          
        }

        private void dgvListaPrecio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ValorOriginal = "";

                if (this.dgvListaPrecio.Columns[e.ColumnIndex].Name == "colCosto" || this.dgvListaPrecio.Columns[e.ColumnIndex].Name == "colPrecio")
                    ValorOriginal = dgvListaPrecio.CurrentRow.Cells[e.ColumnIndex].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);            
            }
           
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if(dgvListaPrecio.RowCount > 0)
            {
               
                try
                {
                    using (var hb = new DBdatos())
                    {
                        var ConsultaLP = (from LP in hb.LISTAPRECIO
                                          where LP.ID == (int)cmbListaPrecio.SelectedValue
                                          select LP).FirstOrDefault();

                        var ConsultaLPconfig = (from LC in hb.LISTAPRECIOCONFIG
                                                select LC).FirstOrDefault();

                        foreach (DataGridViewRow row in dgvListaPrecio.Rows)
                        {
                            if (row.Cells["colModificar"].Value != null)
                            {
                                if (row.Cells["colModificar"].Value.ToString() == "*")
                                {
                                    int ListaPrecio = (int)cmbListaPrecio.SelectedValue;
                                    string Articulo = row.Cells["colCodigo"].Value.ToString();
                                    decimal Precio = Convert.ToDecimal(row.Cells["colPrecio"].Value);
                                    decimal Costo = Convert.ToDecimal(row.Cells["colCosto"].Value);

                                    var Consulta = (from LPC in hb.LISTAPRECIOCUERPO
                                                    where LPC.ListaPrecio_ID == ListaPrecio
                                                        && LPC.Articulo_ID == Articulo
                                                    select LPC).FirstOrDefault();

                                    if (Consulta != null)
                                    {
                                        Consulta.Precio = Precio;
                                        Consulta.Costo = Costo;

                                        if (ConsultaLPconfig != null)
                                        {
                                            if (ConsultaLPconfig.ActualizaCostoEnTodasListas == "SI")
                                            {
                                                var ConsultaActualizaLP = (from LPC in hb.LISTAPRECIOCUERPO
                                                                           where LPC.Articulo_ID == Articulo
                                                                            && LPC.ListaPrecio_ID != (int)cmbListaPrecio.SelectedValue
                                                                           select LPC).ToList();

                                                foreach (var item in ConsultaActualizaLP)
                                                {
                                                    item.Costo = Costo;

                                                    if (item.Precio == null)
                                                    {
                                                        item.Precio = 0;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        hb.SaveChanges();
                        MessageBox.Show("Lista de precios modificada correctamente","Atención");
                        ConsultaLP.UltimaActualizacion = DateTime.Now;
                        hb.SaveChanges();
                        MostrarDatos();
                    }
                }              
                catch (Exception Error)
                {
                    MessageBox.Show(Error.Message);
                }
            }           
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvListaPrecio);
        }

        private void btnRefrescarLista_Click(object sender, EventArgs e)
        {
            if(cmbListaPrecio.SelectedValue != null)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvListaPrecio.Rows)
                    {
                        if (row.Cells["colCosto"].Value != null && row.Cells["colPrecio"].Value != null)
                        {
                            decimal Costo = Convert.ToDecimal(row.Cells["colCosto"].Value);
                            decimal Precio = Convert.ToDecimal(row.Cells["colPrecio"].Value);

                            decimal PrecioFinal;

                            if (cmbPrecioCosto.Text == "Costo")
                            {
                                PrecioFinal = Costo + ((Convert.ToDecimal(txtGanancia.Text) / 100) * Costo);
                                row.Cells["colPrecio"].Value = PrecioFinal;
                                row.Cells["colModificar"].Value = "*";
                            }
                            if (cmbPrecioCosto.Text == "Precio")
                            {
                                PrecioFinal = Precio + ((Convert.ToDecimal(txtGanancia.Text) / 100) * Precio);
                                row.Cells["colPrecio"].Value = PrecioFinal;
                                row.Cells["colModificar"].Value = "*";
                            }
                        }
                    }
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message);
                }
               
            }
        }
        

        private void chkFiltraCodigoBarra_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraCodigoBarra, chkFiltraCodigoBarra);
        }

        private void chkFiltraCosto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDobleTexbox(txtFiltraCosto1, txtFiltraCosto2 ,chkFiltraCosto);      
        }

        private void chkFiltraPrecio_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDobleTexbox(txtFiltraPrecio1, txtFiltraPrecio2, chkFiltraPrecio);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatos();           
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
            Reutilizables.ReubicarFiltros(gbxFiltros, pnlInferior, btnMostrarfiltros);
        }

        private void chkFiltraArticulo_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraArticulo,cmbFiltraInsPro,txtBuscaInsPro,btnBuscarInsPro,"INS","NO");
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsPro, txtBuscaInsPro, "INS", true, "NO");
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaInsPro.Visible = false;
            }
        }

        private void cmbFiltraInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsPro, txtBuscaInsPro, "INS", false, "NO");
            }
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cmbListaPrecio.SelectedIndex != -1)
            {
                var f = new frmIngresoInsumoAsistente();
                f.WindowState = FormWindowState.Maximized;
                f.ListaPrecioID = (int)cmbListaPrecio.SelectedValue;
                f.Accion = "ListaPrecio";
                f.Show();
            }
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvListaPrecio.RowCount > 0)
            {
                long IDImprimir = Convert.ToInt64(dgvListaPrecio.CurrentRow.Cells["colID"].Value);
                C.ImprimirEtiquetaPrecio(IDImprimir, dgvListaPrecio,false);
            }
        }

        private void txtGanancia_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void btnAgregarNuevaCategoria_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(cmbListaPrecio.SelectedIndex != -1)
            {
                MostrarDatos();
            }
        }

        private void chkFiltraCategoria_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCategorias(chkFiltraCategoria, cmbFiltraCategoria, txtBuscaCategoria, btnBuscarCategoria);
        }

        private void txtBuscaCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaCategoria.Visible = false;
                clsCargarCombos.MostrarCategorias(cmbFiltraCategoria, txtBuscaCategoria, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaCategoria.Visible = false;
                //  clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, false);
            }
        }

        private void cmbFiltraCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarCategorias(cmbFiltraCategoria, txtBuscaCategoria, false);
            }
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            txtBuscaCategoria.Visible = true;
            txtBuscaCategoria.Select();
        }

        private void btnExportarPesables_Click(object sender, EventArgs e)
        {
            var f = new frmListaPrecioExportarPesable();
            f.ShowDialog();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            var f = new frmListaPrecioConfig();
            f.ShowDialog();
        }
    }
}
