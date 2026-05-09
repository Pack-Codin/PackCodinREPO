using PCodin_Sinlacc.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios.MANTENIMIENTO
{
    public partial class frmTipoMantenimientoAgregarTarea : Form
    {
        public frmTipoMantenimientoAgregarTarea()
        {
            InitializeComponent();
        }
        public int IDRecibido;
        public DataGridView DGV;
        public string Accion;
        private void frmTipoMantenimientoAgregarTarea_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            try
            {
                cmbEstado.SelectedIndex = 0;
                if (Accion == "2")
                {
                    txtDescripcion.Text = DGV.CurrentRow.Cells["colTarea"].Value.ToString();
                    cmbEstado.Text = DGV.CurrentRow.Cells["colEstado"].Value.ToString();
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
                if(Accion == "1")
                {
                    using (var hb = new DBdatos())
                    {
                        int ID;
                        //CALCULA EL ID
                        var ConsultaID = (from T in hb.MANTENIMIENTOTIPOTAREA
                                          orderby T.ID descending
                                          select T).Take(1).FirstOrDefault();

                        if (ConsultaID == null)
                            ID = 1;
                        else
                            ID = ConsultaID.ID + 1;
                        
                        //AGREGA EL DATO
                        DGV.Rows.Add(0,txtDescripcion.Text , cmbEstado.Text,"1");                       
                    }                       
                }
                if (Accion == "2")
                {                
                    DGV.CurrentRow.Cells["colTarea"].Value = txtDescripcion.Text;
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

        private void txtDescripcion_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
