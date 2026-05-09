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

namespace PCodin_Sinlacc.Formularios.CAJA
{
    public partial class frmCajaMostrar : Form
    {
        public frmCajaMostrar()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void frmCajaMostrar_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            cmbFiltraEstado.Enabled = true;
            cmbFiltraEstado.SelectedIndex = 0;
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from IM in hb.CAJA
                                orderby IM.Codigo
                                select new
                                {
                                    IM.ID,
                                    IM.Codigo,
                                    IM.Descripcion,                     
                                    IM.Estado
                                });
               
                if(chkFiltraEstado.Checked)
                {                  
                    Consulta = (from C in Consulta
                                where C.Estado == cmbFiltraEstado.Text
                                select C);
                }

                var Resultados = Consulta.Take(1000).ToList();

                colID.DataPropertyName = "ID";
                colCodigo.DataPropertyName = "Codigo";
                colDescripcion.DataPropertyName = "Descripcion";
                colEstado.DataPropertyName = "Estado";
               
                lblResultados.Text = Resultados.Count.ToString();

                dgvCaja.AutoGenerateColumns = false;
                dgvCaja.DataSource = Resultados;
            }
        }
        private void AbrirForm(string Accion)
        {
            var f = new frmCajaAgregar();
            f.Accion = Accion;
            if (Accion != "1")
            {
                if (dgvCaja.RowCount > 0)
                    f.IDRecibido = Convert.ToInt32(dgvCaja.CurrentRow.Cells["colID"].Value);
            }
            AddOwnedForm(f);
            f.WindowState = FormWindowState.Maximized;
            f.TopLevel = false;
            this.Controls.Add(f);
            this.Tag = f;
            f.BringToFront();
            f.Show();
        }
        private void Eliminar()
        {
            try
            {
                if(dgvCaja.RowCount > 0)
                {
                    int IDSeleccionado = Convert.ToInt32(dgvCaja.CurrentRow.Cells["colID"].Value);

                    DialogResult R = MessageBox.Show("Esta seguro que desea eliminar esta caja", "Atención", MessageBoxButtons.YesNoCancel);
                    if (R == DialogResult.Yes)
                    {
                        using (var hb = new DBdatos())
                        {
                            var Consulta = (from C in hb.CAJAUSUARIO
                                            where C.Caja_ID == IDSeleccionado
                                            select C).FirstOrDefault();

                            if(Consulta == null)
                            {
                                var ConsultaCaja = (from C in hb.CAJA
                                                    where C.ID == IDSeleccionado
                                                    select C).FirstOrDefault();

                                hb.CAJA.Remove(ConsultaCaja);
                                hb.SaveChanges();
                                MessageBox.Show("Caja eliminada correctamemte", "Atencion");
                                MostrarDatos();
                            }
                            else
                            {
                                MessageBox.Show("No se puede eliminar la caja " + Consulta.CAJA.Descripcion + " ya que tiene movimientos afectados", "Error");
                            }    
                        }
                    }
                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");              
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirForm("1");
        }

        private void dgvCaja_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirForm("2");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirForm("2");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
