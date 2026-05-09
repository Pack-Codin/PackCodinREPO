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
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using PCodin_Sinlacc.Formularios.ESTADISTICAS.Informes;
using System.Data.Sql;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmEstadisticas : Form
    {
        public frmEstadisticas()
        {
            InitializeComponent();
        }
        private void MostrarMaestroPedidos()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaPedido = (from RP in hb.Pedido_Cuerpo
                                      where (RP.Registro_Pedidos.Estado_ID == "FI" || RP.Registro_Pedidos.Estado_ID == "AU")
                                      orderby RP.Registro_Pedidos.Clientes.Descripcion
                                      select new
                                      {
                                          RP.Pedido_ID,
                                          RP.Registro_Pedidos.Fecha,
                                          Cliente = RP.Registro_Pedidos.Clientes.Descripcion,
                                          Ciudad = RP.Registro_Pedidos.Ciudades.Descripcion,
                                          RP.Producto_ID,
                                          EstadoPedido= RP.Registro_Pedidos.Estado_ID,
                                          Producto = RP.Productos_Insumos.Descripcion,
                                          CantidadTotal = RP.Cantidad_Total_Entregada + RP.Cantidad,
                                          CantidadPend = RP.Cantidad,
                                          CantidadAfecta = RP.Cantidad_Total_Entregada
                                      });


                if (chkFiltraProducto.Checked)
                    ConsultaPedido = (from C in ConsultaPedido
                                      where C.Producto_ID == cmbFiltraProducto.SelectedValue.ToString()
                                      select C);

                if (chkFiltraEstado.Checked)
                    ConsultaPedido = (from C in ConsultaPedido
                                      where C.EstadoPedido == cmbFiltraEstado.Text
                                      select C);

                if (chkFiltraFechaDesde.Checked && chkFiltraFechaHasta.Checked == false)
                {
                    ConsultaPedido = (from C in ConsultaPedido
                                      where C.Fecha >= dtpFiltraFechaDesde.Value.Date
                                select C);
                }
                else if (chkFiltraFechaDesde.Checked == false && chkFiltraFechaHasta.Checked)
                {
                    ConsultaPedido = (from C in ConsultaPedido
                                      where C.Fecha <= dtpFiltraFechaHasta.Value.Date
                                select C);
                }
                else if (chkFiltraFechaDesde.Checked && chkFiltraFechaHasta.Checked)
                {
                    ConsultaPedido = (from C in ConsultaPedido
                                      where C.Fecha >= dtpFiltraFechaDesde.Value.Date && C.Fecha <= dtpFiltraFechaHasta.Value.Date
                                select C);
                }

                var Resultados = ConsultaPedido.ToList();

                colNroPedido.DataPropertyName = "Pedido_ID";
                colFecha.DataPropertyName = "Fecha";
                colCliente.DataPropertyName = "Cliente";
                
                colProducto.DataPropertyName = "Producto";
                colCantidadTotal.DataPropertyName = "CantidadTotal";
                colCantidadPend.DataPropertyName = "CantidadPend";
                colCantidadEntreg.DataPropertyName = "CantidadAfecta";

                dgvEmpleados.AutoGenerateColumns = false;
                dgvEmpleados.DataSource = Resultados;
            }
        }
        private void gbxFiltrosTermo_Enter(object sender, EventArgs e)
        {

        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProducto.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraProducto, txtBuscarProducto, "PRO", true, "NO");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarProducto.Visible = false;
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void cmbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraProducto, txtBuscarProducto, "PRO", false, "NO");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbInformes.SelectedIndex == 1)
                MostrarMaestroPedidos();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.RowCount > 0)
                MaestroDePedidos();
        }
        private void MaestroDePedidos()
        {
            var f = new frmReporte();

            //var Consulta = (from );

            DataSet1 Ds = new DataSet1();
            int Filas = dgvEmpleados.RowCount;

            var report = new rptMaestroDePedidos();

            for (int i = 1; i <= Filas; i++)
            {
                DateTime Fecha = Convert.ToDateTime(dgvEmpleados.Rows[i - 1].Cells[0].Value);

                Ds.Tables[0].Rows.Add
                (new object[] {                 
                                Fecha.ToShortDateString(),
                                this.dgvEmpleados.Rows[i-1].Cells[1].Value.ToString(),                            
                                this.dgvEmpleados.Rows[i-1].Cells[2].Value.ToString(),
                                this.dgvEmpleados.Rows[i-1].Cells[3].Value.ToString(),
                                this.dgvEmpleados.Rows[i-1].Cells[4].Value.ToString(),
                                this.dgvEmpleados.Rows[i-1].Cells[5].Value.ToString(),
                                this.dgvEmpleados.Rows[i-1].Cells[6].Value.ToString(),
                });
            }
            using (var hb = new DBdatos())
            {
                string Cliente;
                string Telefono;
                string Mail;
                string Ciudad;
                                     
                                 
                var Consulta = (from C in hb.Clientes
                                where C.Cliente_Usuario == true
                                select C);

                var Resultados = Consulta.FirstOrDefault();
                var Resultados2 = Consulta.ToList();

                Cliente = Resultados.Descripcion;
                Telefono = Resultados.Telefono;
                Mail = Resultados.Email;
                Ciudad = Resultados.Ciudades.Descripcion;


                ((TextObject)report.ReportDefinition.ReportObjects["txtEmpresa"]).Text = Cliente;
                ((TextObject)report.ReportDefinition.ReportObjects["txtTelefono"]).Text = Telefono;
                ((TextObject)report.ReportDefinition.ReportObjects["txtMail"]).Text = Mail;
                ((TextObject)report.ReportDefinition.ReportObjects["txtCiudad"]).Text = Ciudad;

                if (chkFiltraProducto.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroProducto"]).Text = cmbFiltraProducto.Text;

                if (chkFiltraEstado.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroEstado"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroEstado"]).Text = cmbFiltraEstado.Text;

                if (chkFiltraFechaDesde.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroDesde"]).Text = "";
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroDesde"]).Text = dtpFiltraFechaDesde.Value.Date.ToShortDateString();

                if (chkFiltraFechaHasta.Checked == false)
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroHasta"]).Text = DateTime.Now.Date.ToShortDateString();
                else
                    ((TextObject)report.ReportDefinition.ReportObjects["txtFiltroHasta"]).Text = dtpFiltraFechaHasta.Value.Date.ToShortDateString();

                //((TextObject)report.ReportDefinition.ReportObjects["Text9"]).Text = "LISTADO DE CLIENTES";
                //report.Load("C:/Users/franc/Documents/Kacos/Proyectos propios/Copia Seguridad Pack-Coding/VerificacionBobinas/rptPallets.rpt");
                // report.SetParameterValue("Text9", "aaaaa");
                report.SetDataSource(Ds);
                f.crystalReportViewer1.ReportSource = report;

                f.ShowDialog();
            }
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbFiltraEstado);
        }

        private void chkFiltraProducto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraProducto, cmbFiltraProducto, txtBuscarProducto, btnBuscarProducto,"PRO","NO");
        }

        private void frmEstadisticas_Load(object sender, EventArgs e)
        {
            dtpFiltraFechaDesde.Value = DateTime.Now.AddDays(-30);
            dtpFiltraFechaHasta.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new frmReporting();
            f.Show();
        }

        private void chkFiltraFechaDesde_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text =  dgvEmpleados.CurrentRow.Cells[columnName: "colCliente"].Value.ToString();
        }
    }
}
