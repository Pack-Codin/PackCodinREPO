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

namespace PCodin_Sinlacc.Formularios.MANTENIMIENTO.Registro_de_mantenimiento
{
    public partial class frmMostrarRegistroMantenimiento : Form
    {
        public frmMostrarRegistroMantenimiento()
        {
            InitializeComponent();
        }

        private void frmMostrarRegistroMantenimiento_Load(object sender, EventArgs e)
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
                var Consulta = (from RM in hb.MANTENIMIENTOREGISTRO
                                orderby RM.Fecha
                                select new
                                {
                                    RM.ID,
                                    RM.MantenimientoTipo_ID,
                                    RM.MANTENIMIENTOTIPO.Descripcion,
                                    RM.Fecha,
                                    RM.Estado,

                                }).Take(1000);

                if (chkFiltraTipoMantenimiento.Checked)
                    Consulta = (from C in Consulta
                                where C.MantenimientoTipo_ID == (int)cmbFiltraTipoMantenimiento.SelectedValue
                                select C);

                if(chkFiltraEstado.Checked)
                    Consulta = (from C in Consulta
                                where C.Estado == cmbFiltraEstado.Text
                                select C);

                if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFechaDesde.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha <= dtpFechaHasta.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFechaDesde.Value.Date && C.Fecha <= dtpFechaHasta.Value.Date
                                select C);
                }

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colMantenimientoTipoID.DataPropertyName = "MantenimientoTipo_ID";
                colMantenimientoTipo.DataPropertyName = "Descripcion";
                colFecha.DataPropertyName = "Fecha";
                colEstado.DataPropertyName = "Estado";

                dgvRegistroMantenimiento.DataSource = Resultados;
                lblResultados.Text = Resultados.Count.ToString();

            }
        }
        private void AbrirForm(string Accion)
        {
            try
            {
                long ID;

                var f = new frmRegistroMantenimientoAgregar();

                if (Accion == "2") //Editar
                {
                    if (dgvRegistroMantenimiento.RowCount > 0)
                    {
                        ID = Convert.ToInt64(dgvRegistroMantenimiento.CurrentRow.Cells["colID"].Value);
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
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void FormatearCeldas(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRegistroMantenimiento.RowCount > 0)
            {
                if (this.dgvRegistroMantenimiento.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "FI")
                    {
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.Green;
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                        e.Value = "Finalizado";
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);
                        e.Value = "Pendiente";
                    }
                }           
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirForm("1");
        }

        private void dgvRegistroMantenimiento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirForm("2");
        }

        private void dgvRegistroMantenimiento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRegistroMantenimiento.RowCount > 0)
            {
                try
                {
                    DialogResult R = MessageBox.Show("Seguro que desea elimar el registro seleccionado ?", "Atencion", MessageBoxButtons.YesNoCancel);

                    if (R == DialogResult.Yes)
                    {
                        long ID = Convert.ToInt64(dgvRegistroMantenimiento.CurrentRow.Cells["colID"].Value);

                        using (var hb = new DBdatos())
                        {
                            var Consulta = (from C in hb.MANTENIMIENTOREGISTRO
                                            where C.ID == ID
                                            select C).FirstOrDefault();

                            var ConsultaCuerpo = (from C in hb.MANTENIMIENTOREGISTROCUERPO
                                                  where C.MantenimientoRegistro_ID == ID
                                                  select C).ToList();

                            hb.MANTENIMIENTOREGISTROCUERPO.RemoveRange(ConsultaCuerpo);
                            hb.MANTENIMIENTOREGISTRO.Remove(Consulta);
                            hb.SaveChanges();
                            MessageBox.Show("Registro eliminado correctamente", "Atencion");

                            MostrarDatos();
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error");
                }
               
            }
        }
    }
}
