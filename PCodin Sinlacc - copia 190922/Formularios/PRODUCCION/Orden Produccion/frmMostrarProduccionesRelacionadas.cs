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

namespace PCodin_Sinlacc.Formularios.Orden_Produccion
{
    public partial class frmMostrarProduccionesRelacionadas : Form
    {
        public frmMostrarProduccionesRelacionadas()
        {
            InitializeComponent();
        }

        public long OrdenProd_ID;

        private void frmMostrarProduccionesRelacionadas_Load(object sender, EventArgs e)
        {
            dtpFechaHasta.Value = DateTime.Now.Date;
            dtpFechaDesde.Value = DateTime.Now.Date.AddDays(-30);
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from EMP in hb.Existencia_ProductoTerminado
                                where EMP.OrdenProduccion_ID == OrdenProd_ID
                                    && EMP.Estado_ID != "AN"
                                orderby EMP.Fecha descending, EMP.ID descending
                                select new
                                {
                                    EMP.ID,
                                    EMP.Produto_ID,
                                    EMP.Movimiento_ID,
                                    EMP.Numero_Produccion,
                                    Movimiento = EMP.Movimientos_Produccion.Descripcion,
                                    Producto = EMP.Productos_Insumos.Descripcion,
                                    EMP.Fecha,
                                    EMP.Medida_ID,
                                    Medida = EMP.Medidas_Producto.Descripcion,
                                    EMP.Empleado_ID,
                                    Empleado = EMP.Empleados.Nombre,
                                    EMP.Cantidad,
                                    EMP.Cantidad_Utiliz,
                                    Disponible = EMP.Cantidad - EMP.Cantidad_Utiliz,
                                    EMP.Ficha,
                                    EMP.Retencion,
                                    EMP.Estado_ID,
                                    Estado = EMP.Estado_ExistenciaProductoTerminado.Descripcion,
                                    EMP.Productos_Insumos.Categoria_ID,
                                    EMP.Observaciones

                                }).Take(1000);

              
                if (chkFiltraInsPro.Checked)
                    Consulta = (from C in Consulta
                                where C.Produto_ID == cmbFiltraInsPro.SelectedValue.ToString()
                                select C);

                if (chkFiltraCategoria.Checked)
                    Consulta = (from C in Consulta
                                where C.Categoria_ID == (int)cmbFiltraCategoria.SelectedValue
                                select C);

                if (chkFiltraEstado.Checked)
                    Consulta = (from C in Consulta
                                where C.Estado_ID == cmbFiltraEstado.Text
                                select C);

                if (chkFiltraRetencion.Checked)
                    Consulta = (from C in Consulta
                                where C.Retencion == cmbFiltraRetencion.Text
                                select C);

                if (chkFiltraFicha.Checked)
                    Consulta = (from C in Consulta
                                where C.Ficha == cmbFiltraFicha.Text
                                select C);

               

                if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFechaDesde.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha <= dtpFechaHasta.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFechaDesde.Value.Date && C.Fecha <= dtpFechaHasta.Value.Date
                                select C);
                }


                var Resultado = Consulta.ToList();

                colFecha.Visible = true;
                colMovimiento.Visible = true;
                colRetencion.Visible = true;
                colFicha.Visible = true;
                colObservacion.Visible = true;
                colEmpleado.Visible = true;
                colEstado.Visible = true;

                colID.DataPropertyName = "ID";
                colNumeroProduccion.DataPropertyName = "Numero_Produccion";
                colFecha.DataPropertyName = "Fecha";
                colMovimiento.DataPropertyName = "Movimiento";
                colCodigo.DataPropertyName = "Produto_ID";
                colProducto.DataPropertyName = "Producto";
                colCantidad.DataPropertyName = "Cantidad";
                colCantidadUtiliz.DataPropertyName = "Cantidad_Utiliz";
                colCantidadDisponible.DataPropertyName = "Disponible";
                colMedida.DataPropertyName = "Medida";
                colRetencion.DataPropertyName = "Retencion";
                colFicha.DataPropertyName = "Ficha";
                colEstado.DataPropertyName = "Estado";
                colEmpleado.DataPropertyName = "Empleado";
                colObservacion.DataPropertyName = "Observaciones";

                txtCantidadResultados.Text = Resultado.Count.ToString();

                dgvMovimientoProduccion.AutoGenerateColumns = false;
                dgvMovimientoProduccion.DataSource = Resultado;
            }
        }
        private void ChkFiltraInsPro_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, btnBuscarInsPro, "PRO", "NO");
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, btnBuscarInsPro, "PRO", "NO");
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
                Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, btnBuscarInsPro, "PRO", "NO");
            }
        }

        private void chkFiltraMovimiento_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraMovimiento, cmbFiltraMovimiento);
            clsCargarCombos.MostrarCombomMovProduccion(cmbFiltraMovimiento, "PRO");
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

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            txtBuscaCategoria.Visible = true;
            txtBuscaCategoria.Select();
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbFiltraEstado);
        }

        private void chkFiltraRetencion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraRetencion, cmbFiltraRetencion);
        }

        private void chkFiltraFicha_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraFicha, cmbFiltraFicha);
        }

        private void chkFechaDesde_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaDesde, dtpFechaDesde);
        }

        private void chkFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaHasta, dtpFechaHasta);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }
        private void FormatearCeldas(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMovimientoProduccion.RowCount > 0)
            {
                if (this.dgvMovimientoProduccion.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "Entregado")
                    {
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.Green;
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                    }
                }
                if (this.dgvMovimientoProduccion.Columns[e.ColumnIndex].Name == "colCantidad")
                {
                    e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                }
                if (this.dgvMovimientoProduccion.Columns[e.ColumnIndex].Name == "colCantidadUtiliz")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                    e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                }
                if (this.dgvMovimientoProduccion.Columns[e.ColumnIndex].Name == "colCantidadDisponible")
                {
                    e.CellStyle.ForeColor = Color.DarkGreen;
                    e.CellStyle.SelectionForeColor = Color.DarkGreen;
                    e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                }
            }
        }

        private void dgvMovimientoProduccion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(e);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnMostrarfiltros_Click_1(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros,btnMostrarfiltros,lblfiltros);
        }

        private void chkFiltraInsPro_CheckedChanged_1(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, btnBuscarInsPro, "PRO", "NO");
        }

        private void chkFiltraMovimiento_CheckedChanged_1(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraMovimiento, cmbFiltraMovimiento);
            clsCargarCombos.MostrarCombomMovProduccion(cmbFiltraMovimiento, "PRO");
        }

        private void chkFiltraCategoria_CheckedChanged_1(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCategorias(chkFiltraCategoria, cmbFiltraCategoria, txtBuscaCategoria, btnBuscarCategoria);
        }

        private void chkFiltraRetencion_CheckedChanged_1(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraRetencion, cmbFiltraRetencion);
        }

        private void chkFechaDesde_CheckedChanged_1(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaDesde, dtpFechaDesde);
        }

        private void chkFechaHasta_CheckedChanged_1(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaHasta, dtpFechaHasta);
        }

        private void txtBuscaInsPro_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, btnBuscarInsPro, "PRO", "NO");
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaInsPro.Visible = false;
            }
        }

        private void cmbFiltraInsPro_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, btnBuscarInsPro, "PRO", "NO");
            }
        }

        private void btnBuscarInsPro_Click_1(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }

        private void txtBuscaCategoria_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void cmbFiltraCategoria_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarCategorias(cmbFiltraCategoria, txtBuscaCategoria, false);
            }
        }

        private void btnBuscarCategoria_Click_1(object sender, EventArgs e)
        {
            txtBuscaCategoria.Visible = true;
            txtBuscaCategoria.Select();
        }

        private void chkFiltraEstado_CheckedChanged_1(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbFiltraEstado);
        }

        private void chkFiltraFicha_CheckedChanged_1(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraFicha, cmbFiltraFicha);
        }
    }
}
