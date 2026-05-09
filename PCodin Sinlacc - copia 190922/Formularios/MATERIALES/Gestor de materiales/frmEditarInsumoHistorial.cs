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
    public partial class frmEditarInsumoHistorial : Form
    {
        public long IDRecibido;
        public frmEditarInsumoHistorial()
        {
            InitializeComponent();
        }

        private void frmEditarInsumoHistorial_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from H in hb.Historial_Insumos
                                where H.ID == IDRecibido
                                select H);

                var Resultados = Consulta.FirstOrDefault();

                if(Resultados != null)
                {                 
                    clsCargarCombos.MostrarComboInsProConMedida(cmbInsumo, cmbMedida, txtBuscaInsPro, "INS",false);
                    clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
                    dtpFecha.Value = Resultados.Fecha;
                    cmbInsumo.SelectedValue = Resultados.Insumo_ID;
                    cmbInsumo.Text = Resultados.Productos_Insumos.Descripcion;
                    txtCantidad.Text = Resultados.Cantidad.ToString();
                    cmbMedida.SelectedValue = Resultados.Medida_ID;
                    cmbMedida.Text = Resultados.Medidas_Producto.Descripcion;
                    cmbResponsable.SelectedValue = Resultados.Responsable_ID;
                    cmbResponsable.Text = Resultados.Empleados.Nombre;
                }
            }
        }
        //private void EditarInsumo()
        //{
        //    using (var hb = new DBdatos())
        //    {
        //        var ConsultaEditar = (from H in hb.Historial_Insumos
        //                        where H.ID == IDRecibido
        //                        select H);

        //        var ResultadosEditar = ConsultaEditar.FirstOrDefault();

        //        var ConsultaExistencia = (from E in hb.Existencia_Insumos
        //                                  where E.Insumo_ID == ResultadosEditar.Insumo_ID
        //                                  select E);

        //        var ResultadosExistencia = ConsultaExistencia.FirstOrDefault();

        //        if(ResultadosExistencia == null)
        //        {
        //            ResultadosEditar.
        //        }


        //        if (Resultados != null)
        //        {
        //            Resultados.Fecha = dtpFecha.Value.Date;
        //            Resultados.Insumo_ID = cmbInsumo.SelectedValue.ToString();
        //            Resultados.Cantidad = Convert.ToDecimal(txtCantidad.Text);
        //            Resultados.Medida_ID = (int)cmbMedida.SelectedValue;
        //            Resultados.Responsable_ID = (int)cmbResponsable.SelectedValue;
        //        }

        //    }
        //}
        private void frmEditarInsumoHistorial_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void OnOffbtnEditar()
        {
            if (cmbInsumo.SelectedIndex != -1 && txtCantidad.TextLength > 0 && cmbMedida.SelectedIndex != -1 && cmbResponsable.SelectedIndex != -1)
            {              
                btnEditarRegistro.Enabled = true;
            }
            else
            {                
                btnEditarRegistro.Enabled = false;
            }
        }
        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                clsCargarCombos.MostrarComboInsProConMedida(cmbInsumo, cmbMedida, txtBuscaInsPro, "INS", true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaInsPro.Visible = false;
            }
        }

        private void cmbInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbInsumo, txtBuscaInsPro,"INS",false, "NO");
            }
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }

        private void txtBuscarResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarResponsable.Visible = false;
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarResponsable.Visible = false;
            }
        }

        private void cmbResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboEmpleados(cmbInsumo, txtBuscaInsPro, false);
            }
        }

        private void btnBuscarResponsable_Click(object sender, EventArgs e)
        {
            txtBuscarResponsable.Visible = true;
            txtBuscarResponsable.Select();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            OnOffbtnEditar();
        }

        private void cmbInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnEditar();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnEditar();
        }

        private void cmbResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnEditar();
        }
    }
}
