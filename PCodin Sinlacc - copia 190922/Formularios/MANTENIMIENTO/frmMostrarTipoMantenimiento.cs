using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Formularios.MANTENIMIENTO
{
    public partial class frmMostrarTipoMantenimiento : Form
    {
        public frmMostrarTipoMantenimiento()
        {
            InitializeComponent();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void frmMostrarTipoMantenimiento_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            Reutilizables.RenderizarForm(this);
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from MT in hb.MANTENIMIENTOTIPO
                                select new
                                {
                                    MT.ID,
                                    MT.Codigo,
                                    MT.Descripcion,
                                    MT.Estado,
                                });

                if (chkFiltraCodigo.Checked)
                    Consulta = (from C in Consulta
                                where C.Codigo == txtFiltraCodigo.Text
                                select C);

                if (chkFiltraTipoMantenimiento.Checked)
                    Consulta = (from C in Consulta
                                where C.ID == (int)cmbFiltraTipoMantenimiento.SelectedValue
                                select C);

                if (chkFiltraCodigo.Checked)
                    Consulta = (from C in Consulta
                                where C.Estado == cmbFiltraEstado.Text
                                select C);

                var Resultados = Consulta.Take(1000).ToList();

                colID.DataPropertyName = "ID";
                colCodigo.DataPropertyName = "Codigo";
                colDescripcion.DataPropertyName = "Descripcion";
                colEstado.DataPropertyName = "Estado";

                dgvTipoMantenimiento.AutoGenerateColumns = false;
                dgvTipoMantenimiento.DataSource = Resultados;

                lblResultados.Text = Resultados.Count.ToString();
            }
        }
        private void AbrirForm(string Accion)
        {
            int ID;

            var f = new frmTipoMantenimientoAgregar();

            if (Accion == "2") //Editar
            {
                if (dgvTipoMantenimiento.RowCount > 0)
                {
                    ID = Convert.ToInt32(dgvTipoMantenimiento.CurrentRow.Cells["colID"].Value);
                    f.IDRecibido = ID;                  
                }            
            }
            //AddOwnedForm(f);
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Controls.Add(f);
            this.Tag = f;
            f.BringToFront();
            f.Accion = Accion;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirForm("1");
        }

        private void dgvTipoMantenimiento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirForm("2");
        }

        private void txtFiltraCodigo_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscaTipoMantenimiento_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
