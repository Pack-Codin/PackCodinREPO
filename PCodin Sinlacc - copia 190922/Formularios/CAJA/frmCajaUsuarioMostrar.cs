using PCodin_Sinlacc.Clases;
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

namespace PCodin_Sinlacc.Formularios.CAJA
{
    public partial class frmCajaUsuarioMostrar : Form
    {
        public frmCajaUsuarioMostrar()
        {
            InitializeComponent();
        }

        private void frmCajaUsuarioMostrar_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            cmbFiltraEstado.Enabled = true;
            cmbFiltraEstado.SelectedIndex = 0;
            dtpFechaDesde.Value = DateTime.Now.Date;
            dtpFechaHasta.Value = DateTime.Now.Date;
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from IM in hb.CAJAUSUARIO
                                orderby IM.FechaApertura
                                select new
                                {
                                    IM.ID,
                                    IM.Caja_ID,
                                    Codigo = IM.CAJA.Codigo,
                                    Caja = IM.CAJA.Descripcion,
                                    IM.FechaApertura,
                                    IM.FechaCierre,
                                    IM.Estado,
                                    IM.Usuario_ID,
                                    Usuario = IM.Usuarios.Nombre,
                                    
                                });

                if(chkFiltraEstado.Checked)
                {
                    string EstadoFormat = string.Empty;

                    if (cmbFiltraEstado.Text == "Abierta")
                        EstadoFormat = "PEN";
                    if (cmbFiltraEstado.Text == "Cerrada")
                        EstadoFormat = "FI";

                    Consulta = (from C in Consulta
                                where C.Estado == EstadoFormat
                                select C);
                }

                var Resultados = Consulta.Take(1000).ToList();

                colID.DataPropertyName = "ID";
                colCajaID.DataPropertyName = "Caja_ID";
                colCodigo.DataPropertyName = "Codigo";
                colDescripcion.DataPropertyName = "Caja";
                colEstado.DataPropertyName = "Estado";
                colUsuario.DataPropertyName = "Usuario";

                lblResultados.Text = Resultados.Count.ToString();

                dgvCaja.AutoGenerateColumns = false;
                dgvCaja.DataSource = Resultados;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void AbrirFormAperturar()
        {
            var f = new frmCajaUsuarioAgregar();
            f.ShowDialog();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirFormAperturar();
        }

        private void dgvCaja_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCaja.RowCount > 0)
            {
                if (this.dgvCaja.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "FI")
                    {
                        e.Value = "Cerrada";
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    }
                    if (e.Value.ToString() == "PEN")
                    {
                        e.Value = "Abierta";
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.Green;
                        e.CellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                     
                    }
                }
            }
        }
        private void AbrirForm()
        {
            if (dgvCaja.RowCount > 0)
            {
                var f = new frmCajaUsuarioMovimiento();

                f.IDRecibido = Convert.ToInt32(dgvCaja.CurrentRow.Cells["colID"].Value);
                AddOwnedForm(f);
                f.WindowState = FormWindowState.Maximized;
                f.TopLevel = false;
                this.Controls.Add(f);
                this.Tag = f;
                f.BringToFront();
                f.Show();
            }
                
               
        }
        private void dgvCaja_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirForm();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }
    }
}
