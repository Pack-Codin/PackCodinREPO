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
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmIngresoDeInsumos : Form
    {

        private long IDaEditar;
        public frmIngresoDeInsumos()
        {
            InitializeComponent();
        }

        private void cmbFiltraInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbInsumo,txtBuscaInsPro, "INS",false, "NO");
            }
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                clsCargarCombos.MostrarComboInsProConMedida(cmbInsumo, cmbMedida, txtBuscaInsPro, "INS", true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaInsPro.Visible = false;               
            }
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }

        private void frmIngresoDeInsumos_Load(object sender, EventArgs e)
        {
            clsCargarCombos.MostrarComboInsProConMedida(cmbInsumo, cmbMedida, txtBuscaInsPro, "INS", false);
            clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
            MostrarDatosEnLista();
        }

        private void txtBuscarResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarResponsable.Visible = false;
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarResponsable.Visible = false;
            }
        }
        private void OnOffbtnCargarEnLista()
        {
            if (cmbInsumo.SelectedIndex != -1 && txtCantidad.TextLength > 0 && cmbMedida.SelectedIndex != -1 && cmbResponsable.SelectedIndex != -1)
            {
                btnCargarEnLista.Enabled = true;
                btnEditarRegistro.Enabled = true;
            }
            else
            {
                btnCargarEnLista.Enabled = false;
                btnEditarRegistro.Enabled = false;
            }
        }
        private void cmbResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
            }
        }
        private void CargarInsumosALista()
        {
            using (var hb = new DBdatos())
            {              
                string ID_Insumo = cmbInsumo.SelectedValue.ToString(); // Saca el ID del Tipo de Insumo y NO EL ID DEL INSUMO

                var Consulta = (from I in hb.TT_Lista_Insumos
                                where I.Insumo_ID == ID_Insumo 
                                select I);

                var ConsultaParaCategoriaInsumo = (from I in hb.Productos_Insumos  // Consulta para saber la categoria del insumo que se esta
                                                   where I.Codigo == ID_Insumo // pasando a la lista
                                                   select I);

                var resultados = Consulta.Count();  // Muestra si hay resultados, Si los hay quiere decir que ya hay insumo cargado de ese tipo por lo tanto procedera a modificar la cantidad y no a cargar uno nuevo
                var filaModificar = Consulta.FirstOrDefault(); // Insumo a editar si ya hay uno cargado del mismo tipo
                var resultadosCategoriaInsumo = ConsultaParaCategoriaInsumo.FirstOrDefault(); // Categoria de los insumos.

                if (resultados > 0) // si hay un mismo tipo de insumo
                {
                    filaModificar.Cantidad = (decimal)(filaModificar.Cantidad + Convert.ToDecimal(txtCantidad.Text));                                
                }
                else // si no hay ningun tipo de insumo en lista, crea uno nuevo
                {
                  
                    
                   
                        var i = new TT_Lista_Insumos();

                        i.Fecha = dtpFecha.Value;
                        i.Insumo_Descrip = cmbInsumo.Text;
                        i.Insumo_ID = cmbInsumo.SelectedValue.ToString();
                        i.Responsable_Descip = cmbResponsable.Text;
                        i.Responsable_ID = (int)cmbResponsable.SelectedValue;
                        i.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                    i.Medida_ID = (int)cmbMedida.SelectedValue;
                    i.Medida = cmbMedida.Text;

                        hb.TT_Lista_Insumos.Add(i);
                    
                }

                hb.SaveChanges();
                
            }

        }
        private void MostrarDatosEnLista()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from LI in hb.TT_Lista_Insumos
                                    // group LI by new { LI.InsumoID,LI.Insumo,LI.Fecha,LI.ResponsableID,LI.Responsa_Carga } into Grupo
                                select new
                                {

                                    LI.ID,
                                    LI.Insumo_Descrip,
                                    LI.Insumo_ID,
                                    LI.Fecha,
                                    LI.Cantidad,
                                    LI.Responsable_ID,
                                    LI.Responsable_Descip,
                                    LI.Medida_ID,
                                    LI.Medida,                                    
                                }); 

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colIDInsumo.DataPropertyName = "Insumo_ID";
                colFecha.DataPropertyName = "Fecha";
                colInsumo.DataPropertyName = "Insumo_Descrip";
                colCantidad.DataPropertyName = "Cantidad";
                colID_Responsable.DataPropertyName = "Responsable_ID";
                colResponsable.DataPropertyName = "Responsable_Descip";
                colMedida.DataPropertyName = "Medida";
                colMedidaID.DataPropertyName = "Medida_ID";

                dgvInsumos.AutoGenerateColumns = false;
                dgvInsumos.DataSource = Resultados;

            }
        }
        private void LLenarControlesEditar()
        {
            if (dgvInsumos.RowCount > 0)
            {
                IDaEditar = (long)dgvInsumos.CurrentRow.Cells[0].Value;

                dtpFecha.Value = (DateTime)dgvInsumos.CurrentRow.Cells[4].Value;
                txtBuscaInsPro.Visible = false;
                cmbInsumo.SelectedValue = dgvInsumos.CurrentRow.Cells[1].Value.ToString();
                cmbInsumo.Text = dgvInsumos.CurrentRow.Cells[5].Value.ToString();
                txtCantidad.Text = dgvInsumos.CurrentRow.Cells[6].Value.ToString();
                cmbResponsable.SelectedValue = dgvInsumos.CurrentRow.Cells[2].Value;
                cmbResponsable.Text = dgvInsumos.CurrentRow.Cells[8].Value.ToString();
                txtBuscarResponsable.Visible = false;
                btnEditarRegistro.Visible = true;
                btnCargarEnLista.Visible = false;
                btnCancelarEdicion.Visible = true;
            }
        }
        private void EliminarItemDelista()
        {
            if (dgvInsumos.RowCount > 0)
            {
                DialogResult M = MessageBox.Show("¿Seguro que desea eliminar estos registros?", "Atención", MessageBoxButtons.YesNo);
                if (M == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        for (int i = 0; i < dgvInsumos.SelectedRows.Count; i++)
                        {
                            string ID = dgvInsumos.SelectedRows[i].Cells[1].Value.ToString(); // Saca el ID a eliminar

                            var Consulta = (from T in hb.TT_Lista_Insumos
                                            where T.Insumo_ID == ID
                                            select T);

                            var Resultados = Consulta.FirstOrDefault();  // Aqui se cuenta la cantidad de elementos a eliminar

                            if (Resultados != null)
                            {
                                hb.TT_Lista_Insumos.Remove(Resultados);
                            }
                        }
                        hb.SaveChanges();
                        MostrarDatosEnLista();
                    }
                }
            }
        }
        private void LimpiarLista()
        {
            if (dgvInsumos.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Seguro que desea limpiar completamente la lista?", "Atención", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        var ListaParaBorrar = hb.TT_Lista_Insumos.ToList(); // Una vez cargada la lista borra todos los registros de la tabla
                        hb.TT_Lista_Insumos.RemoveRange(ListaParaBorrar);
                        hb.SaveChanges();
                        MostrarDatosEnLista();
                    }
                }
            }
        }
        private void CargarInsumosDefinitivo()
        {         
            using (var hb = new DBdatos())
            {
                if (dgvInsumos.RowCount > 0) // Valida que haya registros PARA CARGAR
                {
                    for (int i = 1; i <= dgvInsumos.RowCount; i++) // Dependiendo la cantidad de registros va a realizar el ciclo
                    {
                        decimal Cantidad = (decimal)dgvInsumos.Rows[i - 1].Cells[6].Value; // Calcula la cantidad de insumos a agregar
                        string Insumo_ID = dgvInsumos.Rows[i - 1].Cells[1].Value.ToString();

                        //var ConsultaExistencia = (from E in hb.Existencia_Insumos
                        //                          where E.Insumo_ID == Insumo_ID
                        //                          select E);

                        //var ResultadosExistencia = ConsultaExistencia.FirstOrDefault();

                        var z = new Existencia_Insumos(); // Carga hisumos en la tabla Historial

                        z.Fecha = (DateTime)dgvInsumos.Rows[i - 1].Cells[4].Value;
                        z.Insumo_ID = dgvInsumos.Rows[i - 1].Cells[1].Value.ToString();
                        z.Cantidad = (decimal)dgvInsumos.Rows[i - 1].Cells[6].Value;
                        z.Cantidad_Utilizada = 0;
                        z.Medida_ID = (int)dgvInsumos.Rows[i - 1].Cells[3].Value;
                        z.Responsable_ID = (int)dgvInsumos.Rows[i - 1].Cells[2].Value;

                        hb.Existencia_Insumos.Add(z);  

                        //if(ResultadosExistencia == null)
                        //{
                        //    var H = new Existencia_Insumos();

                        //    H.Insumo_ID = Insumo_ID;
                        //    H.Medida_ID = (int)dgvInsumos.Rows[i - 1].Cells[3].Value;
                        //    H.Existencia = (decimal)dgvInsumos.Rows[i - 1].Cells[6].Value;

                        //    hb.Existencia_Insumos.Add(H);
                        //}
                        //else
                        //{
                        //    ResultadosExistencia.Existencia = ResultadosExistencia.Existencia + (decimal)dgvInsumos.Rows[i - 1].Cells[6].Value;
                        //}                                              
                    }
                    hb.SaveChanges();
                    MessageBox.Show("Datos Cargados Correctamente", "Atención");

                    var ListaParaBorrar = hb.TT_Lista_Insumos.ToList(); // Una vez cargada la lista borra todos los registros de la tabla
                    hb.TT_Lista_Insumos.RemoveRange(ListaParaBorrar);
                    hb.SaveChanges();                  
                    MostrarDatosEnLista();
                }
                else  // Si no hay registros
                {
                    MessageBox.Show("No hay insumos en la lista", "Atención");
                }
            }
        }
        private void EditarRegistros()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from TT in hb.TT_Lista_Insumos
                                where TT.ID == IDaEditar
                                select TT);

                var Resultados = Consulta.FirstOrDefault();

                if (Resultados != null)
                {
                    Resultados.Fecha = dtpFecha.Value.Date;
                    Resultados.Insumo_ID = cmbInsumo.SelectedValue.ToString();
                    Resultados.Insumo_Descrip = cmbInsumo.Text;
                    Resultados.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                    Resultados.Medida_ID = (int)cmbMedida.SelectedValue;
                    Resultados.Medida = cmbMedida.Text;
                    Resultados.Responsable_ID = (int)cmbResponsable.SelectedValue;
                    Resultados.Responsable_Descip = cmbResponsable.Text;
                   
                }
                hb.SaveChanges();
                MostrarDatosEnLista();
                MessageBox.Show("Datos editados correctamente", "Atención");
            }
        }
        private void btnBuscarResponsable_Click(object sender, EventArgs e)
        {
            txtBuscarResponsable.Visible = true;
            txtBuscarResponsable.Select();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            OnOffbtnCargarEnLista();
        }

        private void cmbInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargarEnLista();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargarEnLista();
        }

        private void cmbMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargarEnLista();
        }

        private void cmbResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargarEnLista();
        }

        private void btnCargarEnLista_Click(object sender, EventArgs e)
        {
            CargarInsumosALista();
            MostrarDatosEnLista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItemDelista();
        }

        private void btnLimpliarLista_Click(object sender, EventArgs e)
        {
            LimpiarLista();
        }

        private void btnCargarInsumosDefinitivo_Click(object sender, EventArgs e)
        {
            CargarInsumosDefinitivo();
        }
        private void btnEditarLista_Click(object sender, EventArgs e)
        {
            LLenarControlesEditar();
        }
        private void CancelarEdicionDatos()
        {
            btnEditarRegistro.Visible = false;
            btnCargarEnLista.Visible = true;
            btnCancelarEdicion.Visible = false;
            clsCargarCombos.MostrarComboInsProConMedida(cmbInsumo, cmbMedida, txtBuscaInsPro, "INS", false);
            clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
            txtCantidad.Text = "";
        }
        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            CancelarEdicionDatos();
        }

        private void btnEditarRegistro_Click(object sender, EventArgs e)
        {
            EditarRegistros();
        }
    }
}
