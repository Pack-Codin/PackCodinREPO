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

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmGestorDeClientes : Form
    {
        public frmGestorDeClientes()
        {
            InitializeComponent();
        }
        private void MostrarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from L in hb.Clientes
                                orderby L.Descripcion
                                select new
                                {
                                    L.ID,
                                    L.Descripcion,
                                    L.Tipo,
                                    TipoCliente = L.Tipo_Cliente.Descripcion,
                                    L.Ciudad_ID,
                                    Ciudad = L.Ciudades.Descripcion,
                                    L.Telefono,
                                    L.Email,
                                    L.Estado,
                                    L.Observaciones,   
                                    L.Zona_ID,
                                    Zona = L.ZONA.Descripcion
                                });
               
                if (cmbOrdenar.SelectedIndex == 1) // Descripcion
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Descripcion ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Descripcion descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 2) // Ciudad
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.TipoCliente ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.TipoCliente descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 3) // Ciudad
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Ciudad ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Ciudad descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 4) // Estado
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Estado ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Estado descending
                                    select C);
                }

                if (chkFiltraDescripcion.Checked)
                    Consulta = (from C in Consulta
                                where C.Descripcion.StartsWith(txtFiltraDescripcion.Text)
                                select C);

                if (chkFiltraCiudad.Checked)
                    Consulta = (from C in Consulta
                                where C.Ciudad_ID == (int)cmbFiltraCiudad.SelectedValue
                                select C);

                if (chkFiltraZona.Checked)
                    Consulta = (from C in Consulta
                                where C.Zona_ID  == (int)cmbFiltraZona.SelectedValue
                                select C);

                if (chkFiltraTipoCliente.Checked)
                    Consulta = (from C in Consulta
                                where C.Tipo == cmbFiltaTipoCliente.SelectedValue.ToString()
                                select C);

                if (chkFiltraEstado.Checked)
                    Consulta = (from C in Consulta
                                where C.Estado == cmbFiltraEstado.Text
                                select C);

                var resultados = Consulta.Take(1000).ToList();

                colID.DataPropertyName = "ID";
                colCliente.DataPropertyName = "Descripcion";
                colTipo.DataPropertyName = "TipoCliente";
                colCiudad.DataPropertyName = "Ciudad";
                colZona.DataPropertyName = "Zona";
                colTelefono.DataPropertyName = "Telefono";
                colEmail.DataPropertyName = "Email";
                colEstado.DataPropertyName = "Estado";
                colObservaciones.DataPropertyName = "Observaciones";
                
                lblResultados.Text = resultados.Count().ToString();

                dgvClientes.AutoGenerateColumns = false;
                dgvClientes.DataSource = resultados;
            }
        }
    
        private void AbrirFormCrearEditarCliente(string EditarCrear, int ID)
        {
            var f = new frmAgregarCliente();
            f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAgregarCliente_FormClosed);
            f.PulsoCrearEditarCliente = EditarCrear;
            f.IDRecibido = ID;
            f.ShowDialog();
        }
        private void EliminarCliente()
        {
            if(dgvClientes.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("Esta seguro que desea eliminar este cliente", "Atención", MessageBoxButtons.YesNoCancel);
                if(R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        int ClienteID = (int)dgvClientes.CurrentRow.Cells[0].Value;

                        var ConsultaCliente = (from Cli in hb.Clientes
                                               where Cli.ID == ClienteID
                                               select Cli).FirstOrDefault();

                        var ConsultaPedido = (from PED in hb.Registro_Pedidos
                                              where PED.Cliente_ID == ClienteID
                                              select PED).FirstOrDefault();

                        var ConsultaProductoCliente = (from PROCLI in hb.Producto_Cliente
                                                       where PROCLI.Cliente_ID == ClienteID
                                                       select PROCLI).FirstOrDefault();

                        var ConsultaOrdenCarga = (from OC in hb.Orden_Carga
                                                  where OC.Cliente_ID == ClienteID
                                                  select OC).FirstOrDefault();

                        var ConsultaTicket = (from C in hb.TICKET
                                              where C.Cliente_ID == ClienteID
                                              select C).FirstOrDefault();

                        var ConsultaCuentaCorriente = (from C in hb.MOVIMIENTOCUENTACORRIENTE
                                                       where C.Cliente_ID == ClienteID
                                                       select C).FirstOrDefault();

                        if (ConsultaPedido == null &&
                            ConsultaProductoCliente == null &&
                            ConsultaOrdenCarga == null &&
                            ConsultaTicket == null &&
                            ConsultaCuentaCorriente == null)
                        {
                            hb.Clientes.Remove(ConsultaCliente);
                            hb.SaveChanges();
                            MessageBox.Show("Cliente eliminado correctamente", "Atención");
                            MostrarDatos();
                        }
                        else
                        {
                            MessageBox.Show("El cliente " + ConsultaCliente.Descripcion + " no se pude eliminar ya que está afectado a uno o varios movimientos. Por favor establecerlo como no activo", "Atención");
                        }

                    }
                }
            }
        }
        private void frmAgregarCliente_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void frmAgregarCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            MostrarDatos();
        }
        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            AbrirFormCrearEditarCliente("1", 0); // se pone 0 para que no pase ningun ID
        }

        private void frmGestorDeClientes_Load(object sender, EventArgs e)
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            Reutilizables.RenderizarForm(this);
            cmbFiltraEstado.SelectedIndex = 0;
            MostrarDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.RowCount > 0)
            {
                int ID = (int)dgvClientes.CurrentRow.Cells[0].Value;
                AbrirFormCrearEditarCliente("2", ID); // Editar , ID a editar
            }
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
            Reutilizables.ReubicarFiltros(gbxFiltros, pnlInferior, btnMostrarfiltros);
        }

        private void chkFiltraDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraDescripcion, chkFiltraDescripcion);
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbFiltraEstado);
        }

        private void chkFiltraCiudad_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCiudad(chkFiltraCiudad, cmbFiltraCiudad, txtBuscaCiudad,btnBuscarCiudad);
        }

        private void txtBuscaCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaCiudad.Visible = false;
                clsCargarCombos.MostrarComboCiudades(cmbFiltraCiudad, txtBuscaCiudad, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaCiudad.Visible = false;
                //  clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, false);
            }
        }

        private void cmbFiltraCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboCiudades(cmbFiltraCiudad, txtBuscaCiudad, false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBuscaCiudad.Visible = true;
            txtBuscaCiudad.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.RowCount > 0)
            {
                int ID = (int)dgvClientes.CurrentRow.Cells[0].Value;
                AbrirFormCrearEditarCliente("2", ID); // Editar , ID a editar
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.RowCount > 0)
            {
                int ID = (int)dgvClientes.CurrentRow.Cells[0].Value;
                AbrirFormCrearEditarCliente("2", ID); // Editar , ID a editar
            }
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatos();
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatos();
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dgvClientes.RowCount > 0)
            {
                MostrarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarCliente();
        }

        private void chkTipo_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboTipoCliente(chkFiltraTipoCliente, cmbFiltaTipoCliente);
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvClientes);
        }

        private void pnlSuperior1_Click(object sender, EventArgs e)
        {

        }

        private void chkFiltraZona_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboZona(chkFiltraZona, cmbFiltraZona);
        }

        private void txtFiltraDescripcion_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
