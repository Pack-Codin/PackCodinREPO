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
using PCodin_Sinlacc.Formularios.MANTENIMIENTO;
using PCodin_Sinlacc.Formularios.NOTIFICACION.NotificacionConfigurable;

namespace PCodin_Sinlacc.Formularios.NOTIFICACION
{
    public partial class frmNotificacionConfigurableMostrar : Form
    {
        public frmNotificacionConfigurableMostrar()
        {
            InitializeComponent();
        }

        private void frmNotificacionConfigurableMostrar_Load(object sender, EventArgs e)
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
                var Consulta = (from N in hb.NOTIFICACIONCONFIGURABLE
                                orderby N.Descripcion
                                select new
                                {
                                    N.ID,
                                    N.Descripcion,
                                    N.Estado,
                                    
                                });

                if (chkFiltraDescipcion.Checked)
                    Consulta = (from C in Consulta
                                where C.Descripcion.Contains(txtFiltraDescripcion.Text)
                                select C);

                if (chkFiltraEstado.Checked)
                    Consulta = (from C in Consulta
                                where C.Estado == cmbFiltraEstado.Text
                                select C);

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colDescripcion.DataPropertyName = "Descripcion";
                colEstado.DataPropertyName = "Estado";             
                dgvNotificacionConfigurable.DataSource = Resultados;
                lblResultados.Text = Resultados.Count.ToString();
            }
        }
        private void AbrirForm(string Accion)
        {
            int ID;

            var f = new frmNotificacionConfigurableAgregar();

            if (Accion == "2") //Editar
            {
                if (dgvNotificacionConfigurable.RowCount > 0)
                {
                    ID = Convert.ToInt32(dgvNotificacionConfigurable.CurrentRow.Cells["colID"].Value);
                    f.IDRecibido = ID;
                }
            }
            AddOwnedForm(f);
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirForm("1");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirForm("2");
        }

        private void dgvNotificacionConfigurable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirForm("2");
        }

        private void txtFiltraDescripcion_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
