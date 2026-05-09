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

namespace PCodin_Sinlacc.Formularios.Secciones
{
    public partial class frmMostrarSecciones : Form
    {
        
        public frmMostrarSecciones()
        {
            InitializeComponent();
        }

        private void frmMostrarSecciones_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            Reutilizables.RenderizarForm(this);
           // clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from S in hb.Seccion
                                where S.Estado_ID == "SI"
                                orderby S.ID
                                select new
                                {
                                    S.ID,
                                    S.Codigo,
                                    S.Descripcion,
                                    S.Seccion_Final
                                });

                var Resultado = Consulta.ToList();

                colSeccionCodigo.DataPropertyName = "Codigo";
                colSeccion.DataPropertyName = "Descripcion";
                colSeccionFinal.DataPropertyName = "Seccion_Final";
                colSeccionID.DataPropertyName = "ID";

                dgvSeccion.AutoGenerateColumns = false;
                dgvSeccion.DataSource = Resultado;
            }
        }
        private void AbrirformAgregarEditarProducto(string AgregarEditar)
        {
            var f = new frmAgregarSeccion();
            //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarNuevoPedido_FormClosed);
            f.CrearEditar = AgregarEditar;
            if(AgregarEditar == "2")
            {
                f.CodigoSeccion = dgvSeccion.CurrentRow.Cells[columnName: "colSeccionCodigo"].Value.ToString();
            }
            AddOwnedForm(f);
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Controls.Add(f);
            this.Tag = f;
            f.BringToFront();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirformAgregarEditarProducto("1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSeccion.RowCount > 0)
                AbrirformAgregarEditarProducto("2");
        }

        private void dgvSeccion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSeccion.RowCount > 0)
                AbrirformAgregarEditarProducto("2");
        }

        private void btnSeccionFinal_Click(object sender, EventArgs e)
        {
            if(dgvSeccion.RowCount > 0)
            {
                string Seccion = dgvSeccion.CurrentRow.Cells[columnName: "colSeccion"].Value.ToString();
                string Codigo = dgvSeccion.CurrentRow.Cells[columnName: "colSeccion_ID"].Value.ToString();

                DialogResult R = MessageBox.Show("¿Seguro que desea seleccionar a la sección " + Seccion + " como final?", "Atención",MessageBoxButtons.YesNoCancel);
                if(R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        var Consulta1 = (from SEC in hb.Seccion
                                        where SEC.Seccion_Final == "SI"
                                        select SEC).FirstOrDefault();

                        if(Consulta1 != null)
                        {
                            Consulta1.Seccion_Final = null;                          
                        }
                        
                        var Consulta2 = (from SEC in hb.Seccion
                                         where SEC.Codigo == Codigo
                                         select SEC).FirstOrDefault();

                        Consulta2.Seccion_Final = "SI";
                        hb.SaveChanges();
                        MostrarDatos();
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSeccion.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Esta seguro que desea eliminar esta sección?", "Atención", MessageBoxButtons.YesNoCancel);


                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        int SeccionID = (int)dgvSeccion.CurrentRow.Cells[columnName: "colSeccionID"].Value;

                        var ConsultaCircuito = (from S in hb.Seccion_Circuito
                                                where S.Seccion_ID == SeccionID
                                                select S).FirstOrDefault();

                        var ConsultaEmpleadoSeccion = (from SE in hb.Empleados
                                                       where SE.Seccion_ID == SeccionID
                                                       select SE).FirstOrDefault();

                        if (ConsultaCircuito == null && ConsultaEmpleadoSeccion == null)
                        {
                            var ConsultaSeccion = (from SEC in hb.Seccion
                                                   where SEC.ID == SeccionID
                                                   select SEC).FirstOrDefault();

                            hb.Seccion.Remove(ConsultaSeccion);
                            hb.SaveChanges();
                            MessageBox.Show("Sección eliminada correctamente", "Atención");
                            MostrarDatos();
                        }
                        else
                        {
                            if (ConsultaCircuito != null)
                                MessageBox.Show("No se puede eliminar la sección " + "'" + ConsultaCircuito.Seccion.Descripcion + "'" + " porque es parte de un circuito productivo. Si no desea visualar mas puede darla de baja", "Atención");
                            if(ConsultaEmpleadoSeccion != null)
                                MessageBox.Show("No se puede eliminar la sección " + "'" + ConsultaEmpleadoSeccion.Seccion.Descripcion + "'" + " porque está definida para uno o varios empleados. Si no desea visualar mas puede darla de baja", "Atención");
                        }
                    }
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvSeccion);
        }
    }
}
