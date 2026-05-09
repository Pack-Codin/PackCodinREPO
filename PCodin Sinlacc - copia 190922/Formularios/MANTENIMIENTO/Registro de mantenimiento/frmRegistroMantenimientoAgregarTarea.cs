using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Formularios.MANTENIMIENTO.Registro_de_mantenimiento
{
    public partial class frmRegistroMantenimientoAgregarTarea : Form
    {
        public frmRegistroMantenimientoAgregarTarea()
        {
            InitializeComponent();
        }
        public long IDRecibido;
        public DataGridView DGV;
        public string Accion;
        private void frmRegistroMantenimientoAgregarTarea_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {       
            try
            {
                clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
                cmbResponsable.SelectedIndex = -1;
               
                if (Accion == "2")
                {
                    if (DGV.CurrentRow.Cells["colFecha"].Value.ToString() != "")
                        dtpFecha.Value = Convert.ToDateTime(DGV.CurrentRow.Cells["colFecha"].Value).Date;
                    if (DGV.CurrentRow.Cells["colFechaLimite"].Value.ToString() != "")
                        dtpFechaLimite.Value = Convert.ToDateTime(DGV.CurrentRow.Cells["colFechaLimite"].Value).Date;
                    if (DGV.CurrentRow.Cells["colResponsableID"].Value.ToString() != "" && DGV.CurrentRow.Cells["colResponsableID"].Value != null)
                        cmbResponsable.SelectedValue = Convert.ToInt32(DGV.CurrentRow.Cells["colResponsableID"].Value);
                    if (DGV.CurrentRow.Cells["colResponsable"].Value.ToString() != "")
                        cmbResponsable.Text = DGV.CurrentRow.Cells["colResponsable"].Value.ToString();
                    if (DGV.CurrentRow.Cells["colEstado"].Value.ToString() != "")
                        cmbEstado.Text = DGV.CurrentRow.Cells["colEstado"].Value.ToString();
                    else
                        cmbEstado.Text = "Pendiente";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }
        private void CargarDatos()
        {
            try
            {
                //if (Accion == "1")
                //{
                //    using (var hb = new DBdatos())
                //    {
                //        int ID;
                //        //CALCULA EL ID
                //        var ConsultaID = (from T in hb.MANTENIMIENTOTIPOTAREA
                //                          orderby T.ID descending
                //                          select T).Take(1).FirstOrDefault();

                //        if (ConsultaID == null)
                //            ID = 1;
                //        else
                //            ID = ConsultaID.ID + 1;

                //        //AGREGA EL DATO
                //        DGV.Rows.Add(0, txtDescripcion.Text, cmbEstado.Text, "1");
                //    }
                //}
                if (Accion == "2")
                {
                    DGV.CurrentRow.Cells["colFecha"].Value = dtpFecha.Value.Date.ToShortDateString();
                    DGV.CurrentRow.Cells["colFechaLimite"].Value = dtpFechaLimite.Value.Date.ToShortDateString();

                    if (cmbResponsable.SelectedValue != null)
                    {
                        DGV.CurrentRow.Cells["colResponsableID"].Value = (int)cmbResponsable.SelectedValue;
                        DGV.CurrentRow.Cells["colResponsable"].Value = cmbResponsable.Text;
                    }
                    else
                    {
                        DGV.CurrentRow.Cells["colResponsableID"].Value = "";
                        DGV.CurrentRow.Cells["colResponsable"].Value = "";
                    }

                        DGV.CurrentRow.Cells["colEstado"].Value = cmbEstado.Text;
                    DGV.CurrentRow.Cells["colAccion"].Value = Accion;
                }
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void txtBuscarResponsable_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
