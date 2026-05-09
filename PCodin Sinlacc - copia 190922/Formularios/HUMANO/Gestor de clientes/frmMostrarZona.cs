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

namespace PCodin_Sinlacc.Formularios.HUMANO.Gestor_de_clientes
{
    public partial class frmMostrarZona : Form
    {
        public frmMostrarZona()
        {
            InitializeComponent();
        }
        public int IdRecibido;
        public string Accion;
        string NombreOriginal;
        private void frmMostrarZona_Load(object sender, EventArgs e)
        {

        }
        private void InicializarForm()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    if (Accion == "2")
                    {
                        var Consulta = (from Z in hb.ZONA
                                        where Z.ID == IdRecibido
                                        select Z).FirstOrDefault();

                        NombreOriginal = Consulta.Descripcion; //SIRVE PARA VALIDAR

                        txtZona.Text = Consulta.Descripcion;
                        cmbEstado.Text = Consulta.Estado;
                        txtObservaciones.Text = Consulta.Observacion;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }
        private void MostrarZonas()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from Z in hb.ZONA
                                orderby Z.Descripcion
                                select new
                                {
                                    Z.ID,
                                    Z.Descripcion,
                                    Z.Estado,
                                    Z.Observacion
                                }).Take(1000);

                if(chkFiltraZona.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.ID == (int)cmbFiltraZona.SelectedValue
                                select C);
                }
                if(chkFiltraEstado.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Estado == cmbFiltraEstado.Text
                                select C);
                }

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colZona.DataPropertyName = "Descripcion";
                colEstado.DataPropertyName = "Estado";
                colObservacion.DataPropertyName = "Observacion";

                dgvZona.DataSource = Resultados;
                dgvZona.AutoGenerateColumns = false;

                lblResultados.Text = Resultados.Count.ToString();
            }
        }
        private void CargarZona(string Accion)
        {
            using (var hb = new DBdatos())
            {
                try
                {
                    if (Accion == "1")
                    {
                        if (txtZona.Text != "" && cmbEstado.Text != "")
                        {
                            var ConsultaValidacionNombre = (from C in hb.ZONA
                                                            where C.Descripcion == txtZona.Text
                                                            select C).FirstOrDefault();

                            if (ConsultaValidacionNombre == null)
                            {
                                var i = new ZONA();

                                i.Descripcion = txtZona.Text;
                                i.Estado = cmbEstado.Text;
                                i.Observacion = txtObservaciones.Text;

                                hb.ZONA.Add(i);

                                hb.SaveChanges();
                                MessageBox.Show("Zona cargada correctamente", "Atención");
                                pnlAgregar.Visible = false;
                                pnlSuperior.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("Ya existe la zona " + txtZona.Text, "Atención");
                            }
                        }
                    }
                    if(Accion == "2")
                    {
                        
                        if (txtZona.Text != "" && cmbEstado.Text != "" && txtZona.Text != NombreOriginal)
                        {
                            var ConsultaValidacionNombre = (from C in hb.ZONA
                                                            where C.Descripcion == txtZona.Text
                                                            select C).FirstOrDefault();

                            if (ConsultaValidacionNombre == null)
                            {
                                var Consulta = (from Z in hb.ZONA
                                                where Z.ID == IdRecibido
                                                select Z).FirstOrDefault();

                                Consulta.Descripcion = txtZona.Text;
                                Consulta.Estado = cmbEstado.Text;
                                Consulta.Observacion = txtObservaciones.Text;

                                hb.SaveChanges();
                                MessageBox.Show("Zona modificada correctamente", "Atención");
                                pnlAgregar.Visible = false;
                                pnlSuperior.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("Ya existe la zona " + txtZona.Text, "Atención");
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error");
                }
                
            }           
        }
        private void AbrirPanelAgregar(string NuevaAccion)
        {
            if (pnlAgregar.Visible == false)
            {
                Accion = NuevaAccion;
                pnlAgregar.Visible = true;
                pnlSuperior.Visible = false;

                if (NuevaAccion == "1")
                {
                    txtZona.Text = "";
                    cmbEstado.Text = "SI";
                    txtObservaciones.Text = "";
                }
                if (NuevaAccion == "2")
                {
                    if(dgvZona.RowCount > 0)
                    {
                        IdRecibido = Convert.ToInt32(dgvZona.CurrentRow.Cells["colID"].Value);
                        
                        txtZona.Text = dgvZona.CurrentRow.Cells["colZona"].Value.ToString();
                        cmbEstado.Text = dgvZona.CurrentRow.Cells["colEstado"].Value.ToString();
                        txtObservaciones.Text = dgvZona.CurrentRow.Cells["colObservacion"].Value.ToString();
                    }
                   
                }


            }
            else
            {
                pnlAgregar.Visible = false;
                pnlSuperior.Visible = true;
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarZonas();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarZona(Accion);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirPanelAgregar("1");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlAgregar.Visible = false;
            pnlSuperior.Visible = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirPanelAgregar("2");
        }

        private void dgvZona_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirPanelAgregar("2");
        }

        private void chkFiltraZona_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboZona(chkFiltraZona, cmbFiltraZona);
        }

        private void cmbFiltraZona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbEstado);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarZonas();
        }

        private void txtZona_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtObservaciones_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
