using PCodin_Sinlacc.Clases.UsuarioTema;
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
using static System.Windows.Forms.MonthCalendar;

namespace PCodin_Sinlacc.Formularios.MANTENIMIENTO
{
    public partial class frmTipoMantenimientoAgregar : Form
    {
        public frmTipoMantenimientoAgregar()
        {
            InitializeComponent();
        }
        public int IDRecibido;
        public DataGridView DGV;
        public string Accion;
        private void frmTipoMantenimientoAgregar_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            Reutilizables.RenderizarForm(this);

            if (Accion == "2")
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaMantenimiento = (from MT in hb.MANTENIMIENTOTIPO
                                                 where MT.ID == IDRecibido
                                                 select MT).FirstOrDefault();

                    var ConsultaTareas = (from T in hb.MANTENIMIENTOTIPOTAREA
                                          where T.MantenimientoTipo_ID == IDRecibido
                                          select T).ToList();

                    txtCodigo.Text = ConsultaMantenimiento.Codigo;
                    txtDescripcion.Text = ConsultaMantenimiento.Descripcion;
                    cmbEstado.Text = ConsultaMantenimiento.Estado;

                    foreach (var Tarea in ConsultaTareas)
                    {
                        dgvMantenimientoTarea.Rows.Add(Tarea.ID,
                                                       Tarea.Descripcion,
                                                       Tarea.Estado,
                                                       "0");
                    }
                }
            }
            else
                cmbEstado.SelectedIndex = 0;
        }
        private void AbrirForm(string Accion)
        {
            int ID;

            var f = new frmTipoMantenimientoAgregarTarea();

            if (Accion == "2") //Editar
            {
                if (dgvMantenimientoTarea.RowCount > 0)
                {
                    ID = Convert.ToInt32(dgvMantenimientoTarea.CurrentRow.Cells["colID"].Value);
                    f.IDRecibido = ID;
                }
            }          
            f.Accion = Accion;
            f.DGV = dgvMantenimientoTarea;
            f.ShowDialog();
        }
        private void CargarDatos()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    if (txtCodigo.Text != "" && txtDescripcion.Text != "" && cmbEstado.SelectedIndex != -1)
                    {
                        int IDTarea;
                        
                        if (Accion == "1")
                        {
                            int ID;

                            //CONSULTA ID
                            var ConsultaID = (from MT in hb.MANTENIMIENTOTIPO
                                              orderby MT.ID descending
                                              select MT).FirstOrDefault();

                            if (ConsultaID == null)
                                ID = 1;
                            else
                                ID = ConsultaID.ID + 1;

                            //VALIDA QUE NO EXISTA EL MISMO CODIGO EN LA TABLA DBO.MANTENIMIENTOTIPO
                            var ConsultaCodigo = (from MT in hb.MANTENIMIENTOTIPO
                                                  where MT.Codigo == txtCodigo.Text
                                                  select MT).FirstOrDefault();

                            if (ConsultaCodigo == null)
                            {
                                //CARGA UN NUEVO MANTENIMIENTO
                                var Manteniento = new MANTENIMIENTOTIPO();

                                Manteniento.ID = ID;
                                Manteniento.Codigo = txtCodigo.Text;
                                Manteniento.Descripcion = txtDescripcion.Text;
                                Manteniento.Estado = cmbEstado.Text;

                                hb.MANTENIMIENTOTIPO.Add(Manteniento);

                                //CARGA LAS TAREAS DEL MANTENIMIENTO
                                if (dgvMantenimientoTarea.RowCount > 0)
                                {
                                    

                                    //CONSULTA EL ULTIMO ID DE LA TAREA
                                    var ConsultaTareaID = (from T in hb.MANTENIMIENTOTIPOTAREA
                                                           orderby T.ID descending
                                                           select T).FirstOrDefault();

                                    if (ConsultaTareaID == null)
                                        IDTarea = 1;
                                    else
                                        IDTarea = ConsultaTareaID.ID + 1;

                                    for (var i = 0; i < dgvMantenimientoTarea.RowCount; i++)
                                    {
                                        var Tarea = new MANTENIMIENTOTIPOTAREA();

                                        Tarea.ID = IDTarea;
                                        Tarea.MantenimientoTipo_ID = ID;
                                        Tarea.Descripcion = dgvMantenimientoTarea.Rows[i].Cells["colTarea"].Value.ToString();
                                        Tarea.Estado = dgvMantenimientoTarea.Rows[i].Cells["colEstado"].Value.ToString();

                                        hb.MANTENIMIENTOTIPOTAREA.Add(Tarea);
                                        IDTarea = IDTarea + 1;
                                    }
                                }
                                hb.SaveChanges();
                                MessageBox.Show("Datos cargados correctamente", "Atención");
                            }
                            else
                            {
                                MessageBox.Show("El codigo ingresado ya esta siendo utilizado por otro manteniemineto. Ingrese uno distinto para poder continuar", "Atención");
                            }
                        }
                        if(Accion == "2")
                        {
                            bool Error = false;
                            string ErrorMensaje = "";
                            //CONSULTA LOS DATOS DE MANTENIMIENTOTIPO
                            var ConsultaMantenimiento = (from MT in hb.MANTENIMIENTOTIPO
                                                         where MT.ID == IDRecibido                                                      
                                                         select MT).FirstOrDefault();

                            //VALIDA QUE NO EXISTA EL MISMO CODIGO EN LA TABLA DBO.MANTENIMIENTOTIPO

                            if(ConsultaMantenimiento.Codigo != txtCodigo.Text)
                            {
                                var ConsultaCodigo = (from MT in hb.MANTENIMIENTOTIPO
                                                      where MT.Codigo == txtCodigo.Text
                                                      select MT).FirstOrDefault();

                                if(ConsultaCodigo != null)
                                {
                                    Error = true;
                                    ErrorMensaje = "Ya exite Mantenimiento con el código " + txtCodigo.Text;

                                }

                            }

                            if (Error == false)
                            {
                                

                                //MODIFICA LOS DATOS DEL MANTENIMIENTO
                                ConsultaMantenimiento.Codigo = txtCodigo.Text;
                                ConsultaMantenimiento.Descripcion = txtDescripcion.Text;
                                ConsultaMantenimiento.Estado = cmbEstado.Text;
                                
                                //CONSULTA EL ULTIMO ID DE LA TAREA
                                var ConsultaTareaID = (from T in hb.MANTENIMIENTOTIPOTAREA
                                                       orderby T.ID descending
                                                       select T).FirstOrDefault();

                                if (ConsultaTareaID == null)
                                    IDTarea = 1;
                                else
                                    IDTarea = ConsultaTareaID.ID + 1;

                                //MODIFICA LOS DATOS DE TAREAS
                                for (var i = 0; i < dgvMantenimientoTarea.RowCount; i++)
                                {
                                    string Accion;

                                    Accion = dgvMantenimientoTarea.Rows[i].Cells["colAccion"].Value.ToString();

                                    if (Accion == "1") //CREAR
                                    {
                                        var Tarea = new MANTENIMIENTOTIPOTAREA();

                                        Tarea.ID = IDTarea;
                                        Tarea.MantenimientoTipo_ID = IDRecibido;
                                        Tarea.Descripcion = dgvMantenimientoTarea.Rows[i].Cells["colTarea"].Value.ToString();
                                        Tarea.Estado = dgvMantenimientoTarea.Rows[i].Cells["colEstado"].Value.ToString();

                                        hb.MANTENIMIENTOTIPOTAREA.Add(Tarea);
                                        IDTarea = IDTarea + 1;
                                    }
                                    if (Accion == "2") //EDITAR
                                    {
                                        int IDTareaEditar = Convert.ToInt32(dgvMantenimientoTarea.Rows[i].Cells["colID"].Value);

                                        var ConsultaTarea = (from T in hb.MANTENIMIENTOTIPOTAREA
                                                             where T.ID == IDTareaEditar
                                                             select T).FirstOrDefault();

                                        ConsultaTarea.Descripcion = dgvMantenimientoTarea.Rows[i].Cells["colTarea"].Value.ToString();
                                        ConsultaTarea.Estado = dgvMantenimientoTarea.Rows[i].Cells["colEstado"].Value.ToString();
                                    }
                                    if (Accion == "3") //ELIMINAR
                                    {
                                        int IDTareaEliminar = Convert.ToInt32(dgvMantenimientoTarea.Rows[i].Cells["colID"].Value);

                                        var ConsultaTarea = (from T in hb.MANTENIMIENTOTIPOTAREA
                                                             where T.ID == IDTareaEliminar
                                                             select T).FirstOrDefault();

                                        hb.MANTENIMIENTOTIPOTAREA.Remove(ConsultaTarea);
                                    }
                                }
                                hb.SaveChanges();
                                MessageBox.Show("Datos cargados correctamente", "Atención");
                                this.Hide();
                            }
                            else
                                MessageBox.Show(ErrorMensaje, "Error");
                        }
                    }
                    else
                    {
                        if (txtCodigo.Text == "")
                            MessageBox.Show("No ingresó código", "Atención");
                        if (txtDescripcion.Text == "")
                            MessageBox.Show("No ingresó descripción", "Atención");
                        if (cmbEstado.SelectedIndex == -1)
                            MessageBox.Show("No ingresó estado", "Atención");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            
            }
        }
        private void EliminarTarea()
        {
            if(dgvMantenimientoTarea.RowCount > 0)
            {
                if (Accion == "1")
                    dgvMantenimientoTarea.Rows.Remove(dgvMantenimientoTarea.CurrentRow);
                if (Accion == "2")
                {
                    dgvMantenimientoTarea.CurrentRow.Cells["colAccion"].Value = "3";
                    dgvMantenimientoTarea.CurrentRow.DefaultCellStyle.ForeColor = Color.IndianRed;
                }
                   
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirForm("1");
        }

        private void dgvMantenimientoTarea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirForm("2");
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarTarea();
        }

        private void txtCodigo_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtDescripcion_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
