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
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Clases;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmGestorDeUsuarios : Form
    {
        public frmGestorDeUsuarios()
        {
            InitializeComponent();
        }

        public int UsuarioID;
        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            AbrirFormAgregarEditarUsuario("1", 0 , UsuarioID);
        }

        private void frmGestorDeUsuarios_Load(object sender, EventArgs e)
        {
            IncializarForm();
        }
        private void IncializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            Reutilizables.RenderizarForm(this);
            clsUsuarioTema.UsuarioTema(UsuarioID,pnlSuperior,pnlInferior,this);

            cmbFiltraEstado.SelectedIndex = 0;
            MostrarUsuarios();        
        }
        private void AbrirFormAgregarEditarUsuario(string AgregarEditar , int ID , int UsuarioID)
        {

            //if (UsuarioID == 4)
            //{
                var f = new frmCrearEditarUsuario();
                //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarNuevoPedido_FormClosed);
                f.CrearEditar = AgregarEditar;
                f.UsuarioID = UsuarioID;
                f.IdRecibido = ID;
                AddOwnedForm(f);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                this.Controls.Add(f);
                this.Tag = f;
                f.BringToFront();
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Solo el usuario Administrador tiene acceso a la creacion de usuarios", "Atención");
            //}
        }
        private void MostrarUsuarios()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaUsuario = (from U in hb.Usuarios
                                       orderby U.Nombre
                                       //where U.Nombre != "Administrador"
                                       select new
                                       {
                                           U.ID,
                                           U.Nombre,
                                           U.Estado
                                       });

                if (cmbOrdenar.SelectedIndex == 1) // Nombre
                {
                    if (btnBuscarAsc.Visible == true)
                        ConsultaUsuario = (from C in ConsultaUsuario
                                           orderby C.Nombre ascending
                                    select C);
                    else
                        ConsultaUsuario = (from C in ConsultaUsuario
                                           orderby C.Nombre descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 2) // Estado
                {
                    if (btnBuscarAsc.Visible == true)
                        ConsultaUsuario = (from C in ConsultaUsuario
                                           orderby C.Estado ascending
                                           select C);
                    else
                        ConsultaUsuario = (from C in ConsultaUsuario
                                           orderby C.Estado descending
                                           select C);
                }

                if (chkFiltraDescripcion.Checked)
                    ConsultaUsuario = (from C in ConsultaUsuario
                                       where C.Nombre.Contains(txtFiltraDescripcion.Text) 
                                            || C.Nombre.StartsWith(txtFiltraDescripcion.Text)
                                       select C);

                if (chkFiltraEstado.Checked)
                    ConsultaUsuario = (from C in ConsultaUsuario
                                       where C.Estado == cmbFiltraEstado.Text
                                       select C);

                var ResultadoUsuario = ConsultaUsuario.ToList();

                colID.DataPropertyName = "ID";
                colNombre.DataPropertyName = "Nombre";
                colEstado.DataPropertyName = "Estado";

                lblResultados.Text = ResultadoUsuario.Count.ToString();

                dgvEmpleados.AutoGenerateColumns = false;
                dgvEmpleados.DataSource = ResultadoUsuario;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvEmpleados.CurrentRow.Cells[0].Value;
            AbrirFormAgregarEditarUsuario("2", ID, UsuarioID);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvEmpleados);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void dgvEmpleados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = (int)dgvEmpleados.CurrentRow.Cells[0].Value;
            AbrirFormAgregarEditarUsuario("2", ID , UsuarioID);
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarUsuarios();
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarUsuarios();
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.RowCount > 0)
                MostrarUsuarios();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }
        private void chkFiltraDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraDescripcion, chkFiltraDescripcion);
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbFiltraEstado);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void dgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = (int)dgvEmpleados.CurrentRow.Cells[0].Value;
            AbrirFormAgregarEditarUsuario("2", ID , UsuarioID);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
         
        }

        private void txtFiltraDescripcion_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
