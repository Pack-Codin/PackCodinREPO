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

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmHistorialInsumos : Form
    {
        
        public frmHistorialInsumos()
        {
            InitializeComponent();
        }

        private void frmHistorialInsumos_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from H in hb.Historial_Insumos
                                orderby H.Fecha descending
                                select new
                                {
                                    H.ID,
                                    H.Fecha,
                                    H.Insumo_ID,
                                    H.Productos_Insumos.Descripcion,
                                    H.Cantidad,
                                    H.Medida_ID,
                                    Medida = H.Medidas_Producto.Descripcion,
                                    H.Responsable_ID,
                                    H.Empleados.Nombre,
                                    H.Productos_Insumos.Categoria_ID

                                }).Take(1000);

                if (chkFiltraInsPro.Checked)
                    Consulta = (from C in Consulta
                                where C.Insumo_ID == cmbFiltraInsPro.SelectedValue.ToString()
                                select C);

                if (chkFiltraCategoria.Checked)
                    Consulta = (from C in Consulta
                                where C.Categoria_ID == (int)cmbFiltraCategoria.SelectedValue
                                select C);

                if (chkFiltraMedida.Checked)
                    Consulta = (from C in Consulta
                                where C.Medida_ID ==(int)cmbFiltraMedida.SelectedValue
                                select C);

                if (chkFiltraResponsable.Checked)
                    Consulta = (from C in Consulta
                                where C.Responsable_ID == (int)cmbFiltraResponsable.SelectedValue
                                select C);

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colFecha.DataPropertyName = "Fecha";
                colInsumo_ID.DataPropertyName = "Insumo_ID";
                colInsumo.DataPropertyName = "Descripcion";
                colCantidad.DataPropertyName = "Cantidad";
                colMedida.DataPropertyName = "Medida";
                colResponsable.DataPropertyName = "Nombre";

                txtResultados.Text = Resultados.Count.ToString();

                dgvHistorialInsumos.AutoGenerateColumns = false;
                dgvHistorialInsumos.DataSource = Resultados;
            }
        }
        private void DesafectarRegistro()
        {
            if(dgvHistorialInsumos.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Seguro que desea desafectar este insumo?", "Atención", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        long IDHistorial = (long)dgvHistorialInsumos.CurrentRow.Cells[0].Value;
                        string IDExistencia = dgvHistorialInsumos.CurrentRow.Cells[1].Value.ToString();

                        var ConsultaHistorial = (from His in hb.Historial_Insumos
                                                 where His.ID == IDHistorial
                                                 select His);

                        var ConsultaExistencia = (from H in hb.Existencia_Insumos
                                                  where H.Insumo_ID == IDExistencia
                                                  select H);

                        var ResultadosHistorial = ConsultaHistorial.FirstOrDefault();
                        var ResultadosExistencia = ConsultaExistencia.FirstOrDefault();

                        if (ResultadosHistorial != null && ResultadosExistencia != null)
                        {
                            decimal CantidadDesafectar = (decimal)dgvHistorialInsumos.CurrentRow.Cells[4].Value;

                            ResultadosExistencia.Cantidad = ResultadosExistencia.Cantidad - CantidadDesafectar;

                            hb.Historial_Insumos.Remove(ResultadosHistorial);
                        }
                        hb.SaveChanges();
                        MessageBox.Show("Insumo desafectado correctamente", "Atención");
                        MostrarDatos();
                    }
                }
            }
        }
        private void frmEditarInsumoHistorial_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void txtBuscarResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarResponsable.Visible = false;
                clsCargarCombos.MostrarComboEmpleados(cmbFiltraResponsable, txtBuscarResponsable, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarResponsable.Visible = false;
            }
        }

        private void cmbFiltraResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboEmpleados(cmbFiltraResponsable, txtBuscarResponsable, false);
            }
        }

        private void btnBuscarResponsable_Click(object sender, EventArgs e)
        {
            txtBuscarResponsable.Visible = true;
            txtBuscarResponsable.Select();
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Convert.ToChar(Keys.Enter))
            //{
            //    txtBuscaInsPro.Visible = false;
            //    clsCargarCombos.MostrarInsumosSolamente(cmbFiltraInsPro, txtBuscaInsPro, true, chkMuestraInsProActInac);
            //}
            //if (e.KeyChar == Convert.ToChar(Keys.Escape))
            //{
            //    txtBuscaInsPro.Visible = false;
            //}
        }

        private void cmbFiltraInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Convert.ToChar(Keys.Escape))
            //{
            //    clsCargarCombos.MostrarInsumosSolamente(cmbFiltraInsPro, txtBuscaInsPro, false,chkMuestraInsProActInac);
            //}
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
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

        private void chkFiltraInsPro_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsProConCheck(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, chkMuestraInsProActInac, btnBuscarInsPro);
        }

        private void chkFiltraCategoria_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCategorias(chkFiltraCategoria, cmbFiltraCategoria, txtBuscaCategoria, btnBuscarCategoria);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboEmpleados(chkFiltraResponsable, txtBuscarResponsable, cmbFiltraResponsable,btnBuscar);
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboMedida(chkFiltraMedida, cmbFiltraMedida);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnEliminarInsumo_Click(object sender, EventArgs e)
        {
            DesafectarRegistro();
        }
    }
}
