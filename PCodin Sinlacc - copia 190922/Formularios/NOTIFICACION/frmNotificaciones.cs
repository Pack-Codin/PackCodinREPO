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
using PCodin_Sinlacc.Clases.UsuarioTema;

namespace PCodin_Sinlacc.Formularios.Notificación
{
    public partial class frmNotificaciones : Form
    {
        string Leida = "NO";
        public int UsuarioID;
        public frmMenu FormMenu;
        public frmNotificaciones()
        {
            InitializeComponent();
        }

        private void frmNotificaciones_Load(object sender, EventArgs e)
        {
            Reutilizables.RenderizarForm(this);
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            MostrarNotificaciones(Leida);
        }    
        private void MostrarNotificaciones(string Leida)
        {
            using (var hb = new DBdatos())
            {
                var ConsultaNotificaciones = (from N in hb.Notificaciones
                                              where N.Leida == Leida
                                              orderby N.Fecha , N.Hora
                                              select new
                                              {
                                                  N.ID,
                                                  N.SaltoLineaPorComa,
                                                  N.Fecha,
                                                  N.Hora,
                                                  N.Descripcion,
                                                  Tipo = N.Tipo_Noticacion.Descripcion,
                                                  Usuario = N.Usuarios.Nombre,
                                                  N.Usuario_ID
                                              });

                if (cmbOrdenar.SelectedIndex == 1) 
                {
                    if (btnBuscarDesc.Visible)
                        ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                                  orderby C.Tipo descending
                                                  select C);
                    else
                        ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                                  orderby C.Tipo ascending
                                                  select C);
                }
                if (cmbOrdenar.SelectedIndex == 2)
                {
                    if (btnBuscarDesc.Visible)
                        ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                                  orderby C.Fecha descending
                                                  select C);
                    else
                        ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                                  orderby C.Fecha ascending
                                                  select C);
                }
                if (cmbOrdenar.SelectedIndex == 3)
                {
                    if (btnBuscarDesc.Visible)
                        ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                                  orderby C.Hora descending
                                                  select C);
                    else
                        ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                                  orderby C.Hora ascending
                                                  select C);
                }
                if (cmbOrdenar.SelectedIndex == 4)
                {
                    if (btnBuscarDesc.Visible)
                        ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                                  orderby C.Descripcion descending
                                                  select C);
                    else
                        ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                                  orderby C.Descripcion ascending
                                                  select C);
                }
                if (cmbOrdenar.SelectedIndex == 5)
                {
                    if (btnBuscarDesc.Visible)
                        ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                                  orderby C.Usuario descending
                                                  select C);
                    else
                        ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                                  orderby C.Usuario ascending
                                                  select C);
                }

                if (chkFiltraDescripcion.Checked)
                    ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                              where C.Descripcion.Contains(txtFiltraDescipcion.Text)
                                              select C);

                if (chkFiltraLeidaPor.Checked)
                    ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                              where C.Usuario_ID == (int)cmbFiltraLeidaPor.SelectedValue
                                              select C);

                if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                {
                    ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                              where C.Fecha >= dtpFechaDesde.Value.Date
                                              select C);
                }
                else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                {
                    ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                              where C.Fecha <= dtpFechaHasta.Value.Date
                                              select C);
                }
                else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                {
                    ConsultaNotificaciones = (from C in ConsultaNotificaciones
                                              where C.Fecha >= dtpFechaDesde.Value.Date && C.Fecha <= dtpFechaHasta.Value.Date
                                              select C);
                }

                var ResultadosNotificaciones = ConsultaNotificaciones.Take(1000).ToList();

                colNotificacionID.DataPropertyName = "ID";
                colEspacioPorComa.DataPropertyName = "SaltoLineaPorComa";
                colFecha.DataPropertyName = "Fecha";
                colHora.DataPropertyName = "Hora";
                colDescripcion.DataPropertyName = "Descripcion";
                colTipo.DataPropertyName = "Tipo";
                colLeidaPor.DataPropertyName = "Usuario";
                

                lblResultados.Text = ResultadosNotificaciones.Count.ToString();

                dgvNotificaciones.AutoGenerateColumns = false;
                dgvNotificaciones.DataSource = ResultadosNotificaciones;
            }
        }
        private void MarcarNotificacionComoVista()
        {
            if (dgvNotificaciones.RowCount > 0)
            {
                long NotificacionID = (long)dgvNotificaciones.CurrentRow.Cells[0].Value;
                using (var hb = new DBdatos())
                {
                    var Consulta = (from N in hb.Notificaciones
                                    where N.ID == NotificacionID
                                    select N).FirstOrDefault();

                    Consulta.Leida = "SI";
                    Consulta.Usuario_ID = UsuarioID;
                    hb.SaveChanges();
                    MostrarNotificaciones(Leida);
                }
            }
        }
        private void btnMostrarNoVistas_Click(object sender, EventArgs e)
        {
            btnMostrarNoVistas.BackColor = Color.Orange;
            btnMostrarVistas.BackColor = Color.White;
            Leida = "NO";
            btnMarcarComoVista.Enabled = true;
            MostrarNotificaciones(Leida);
        }

        private void btnMostrarVistas_Click(object sender, EventArgs e)
        {
            btnMostrarVistas.BackColor = Color.Orange;
            btnMostrarNoVistas.BackColor = Color.White;
            Leida = "SI";
            btnMarcarComoVista.Enabled = false;
            MostrarNotificaciones(Leida);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMarcarComoVista_Click(object sender, EventArgs e)
        {
            MarcarNotificacionComoVista();
            clsNotificacion.MostrarCantidadNotificacionesNoLeidas(FormMenu.lblCantidadNotificaciones);
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarNotificaciones(Leida);
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarNotificaciones(Leida);
        }

        private void chkFiltraDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraDescipcion, chkFiltraDescripcion);
        }

        private void chkFiltraLeidaPor_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboUsuarios(chkFiltraLeidaPor, cmbFiltraLeidaPor);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarNotificaciones(Leida);
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }
        private void MostrarObservaciones()
        {
            txtObservaciones.Visible = true;
            txtObservaciones.Focus();

            string Fecha = Convert.ToDateTime(dgvNotificaciones.CurrentRow.Cells[columnName: "colFecha"].Value).ToShortDateString();
            string Hora = dgvNotificaciones.CurrentRow.Cells[columnName: "colHora"].Value.ToString();
            string Descripcion = dgvNotificaciones.CurrentRow.Cells[columnName: "colDescripcion"].Value.ToString();

            string Mensaje = "Fecha: " + Fecha + Environment.NewLine
                            + "Hora : " + Hora + Environment.NewLine
                            + Environment.NewLine
                            + Descripcion;

            if (dgvNotificaciones.CurrentRow.Cells[columnName: "colEspacioPorComa"].Value.ToString() == "SI")
            {
                txtObservaciones.Text = Mensaje.Replace(",", Environment.NewLine);
            }
            else
            {
                txtObservaciones.Text = Mensaje;
            }
        }

        private void txtObservaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtObservaciones.Text = "";              
                txtObservaciones.Visible = false;
            }
        }

        private void dgvNotificaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarObservaciones();
        }

        private void txtFiltraDescipcion_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
