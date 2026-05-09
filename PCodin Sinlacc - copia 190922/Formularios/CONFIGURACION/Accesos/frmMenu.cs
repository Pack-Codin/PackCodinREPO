using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios.MANTENIMIENTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios.CONFIGURACION.Accesos
{
    public partial class frmMenuAcceso : Form
    {
        public frmMenuAcceso()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
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
                var Consulta = (from C in hb.Menu_Item
                                orderby C.Modulos.Nombre
                                select new
                                {
                                    C.ID,
                                    C.Descripcion,
                                    C.Modulo_ID,
                                    Modulo = C.Modulos.Nombre,
                                    C.Estado
                                });

                //FILTROS

                ////

                var Resultados = Consulta.Take(1000).ToList();

                colID.DataPropertyName = "ID";
                colDescripcion.DataPropertyName = "Descripcion";
                colModulo.DataPropertyName = "Modulo";
                colEstado.DataPropertyName = "Estado";

                dgvMenuItems.AutoGenerateColumns = false;
                dgvMenuItems.DataSource = Resultados;

                lblResultados.Text = Resultados.Count.ToString();


            }
        }
        private void AbrirForm(string Accion)
        {
            int ID;

            var f = new frmMenuAccesoAgregar();

            if (Accion == "2") //Editar
            {
                if (dgvMenuItems.RowCount > 0)
                {
                    ID = Convert.ToInt32(dgvMenuItems.CurrentRow.Cells["colID"].Value);
                    f.IdRecibido = ID;
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

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void dgvMenuItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirForm("2");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirForm("1");
        }
    }
}
