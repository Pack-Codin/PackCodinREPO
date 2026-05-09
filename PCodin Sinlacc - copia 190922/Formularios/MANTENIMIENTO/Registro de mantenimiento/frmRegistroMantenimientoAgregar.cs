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

namespace PCodin_Sinlacc.Formularios.MANTENIMIENTO.Registro_de_mantenimiento
{
    public partial class frmRegistroMantenimientoAgregar : Form
    {
        public frmRegistroMantenimientoAgregar()
        {
            InitializeComponent();
        }
        public string Accion;
        public long IDRecibido;
        bool Autorizar = false;

        private void frmRegistroMantenimientoAgregar_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            clsCargarCombos.MostrarComboMantemimientoTipo(cmbTipoMantenimiento, txtBuscaTipoMantenimiento, false);
            cmbTipoMantenimiento.SelectedIndex = -1;

            if (Accion == "2")
            {
                using (var hb = new DBdatos())
                {
                    Autorizar = true;

                    var ConsultaMantenimiento = (from RM in hb.MANTENIMIENTOREGISTRO
                                                 where RM.ID == IDRecibido
                                                 select RM).FirstOrDefault();

                    dtpFecha.Value = ConsultaMantenimiento.Fecha;

                    if (ConsultaMantenimiento.Estado == "PEN")
                        cmbEstado.Text = "Pendiente";
                    if (ConsultaMantenimiento.Estado == "FI")
                        cmbEstado.Text = "Finalizado";
                    if (ConsultaMantenimiento.Estado == "CAN")
                        cmbEstado.Text = "Cancelada";

                    cmbTipoMantenimiento.SelectedValue = ConsultaMantenimiento.MantenimientoTipo_ID;
                    cmbTipoMantenimiento.Text = ConsultaMantenimiento.MANTENIMIENTOTIPO.Descripcion;
                    dgvMantenimientoTarea.Rows.Clear();
                    LLenarGrillaTarea();

                    cmbTipoMantenimiento.Enabled = false;
                    btnBuscarProveedor.Enabled = false;
                    Autorizar = false;
                }
            }
                
        }
        private void LLenarGrillaTarea()
        {
            try
            {
                if(Accion == "2")
                {

                }
                if (cmbTipoMantenimiento.SelectedIndex != -1 && cmbTipoMantenimiento.SelectedValue != null && Autorizar == true)
                {
                    if (Accion == "1")
                    {
                        dgvMantenimientoTarea.Rows.Clear();

                        using (var hb = new DBdatos())
                        {
                            var ConsultaTarea = (from T in hb.MANTENIMIENTOTIPOTAREA
                                                 where T.MantenimientoTipo_ID == (int)cmbTipoMantenimiento.SelectedValue
                                                    && T.Estado == "SI"
                                                 select T).ToList();

                            foreach (var Tarea in ConsultaTarea)
                            {
                                dgvMantenimientoTarea.Rows.Add("",
                                                               Tarea.ID,
                                                               Tarea.Descripcion,
                                                               "",
                                                               "",
                                                               "",
                                                               "",
                                                               "Pendiente");
                            }
                            lblResultados.Text = ConsultaTarea.Count.ToString();
                        }
                    }
                    if(Accion == "2")
                    {
                        using (var hb = new DBdatos())
                        {
                            var ConsultaMantenimientoCuerpo = (from RMC in hb.MANTENIMIENTOREGISTROCUERPO
                                                               where RMC.MantenimientoRegistro_ID == IDRecibido
                                                               select RMC).ToList();

                            foreach (var RegistroCuerpo in ConsultaMantenimientoCuerpo)
                            {
                                string Estado = "Pendiente";
                                string ResponsableID = "";
                                string Responsable = "";

                                if (RegistroCuerpo.Estado == "FI")
                                    Estado = "Finalizada";
                                if (RegistroCuerpo.Estado == "CAN")
                                    Estado = "Cancelada";

                                if (RegistroCuerpo.Responsable_ID == null)
                                {
                                    ResponsableID = "";
                                    Responsable = "";
                                }
                                else
                                {
                                    ResponsableID = RegistroCuerpo.Responsable_ID.ToString();
                                    Responsable = RegistroCuerpo.Empleados.Nombre;
                                }
                                    

                                    dgvMantenimientoTarea.Rows.Add(
                                                                    RegistroCuerpo.ID,
                                                                    RegistroCuerpo.MantenimientoTarea_ID,
                                                                    RegistroCuerpo.MANTENIMIENTOTIPOTAREA.Descripcion,
                                                                    RegistroCuerpo.Fecha.ToString(),
                                                                    RegistroCuerpo.FechaLimite.ToString(),
                                                                    ResponsableID,
                                                                    Responsable,
                                                                    Estado,
                                                                    "0");
                            }
                            lblResultados.Text = ConsultaMantenimientoCuerpo.Count.ToString();
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void cmbFiltraTipoMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarGrillaTarea();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFiltraTipoMantenimiento_Click(object sender, EventArgs e)
        {
            Autorizar = true;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    if (cmbTipoMantenimiento.SelectedIndex != -1 && cmbEstado.SelectedIndex != -1)
                    {
                        long IDTarea;
                        bool FinalizaMantenimiento = true;

                        if (Accion == "1")
                        {
                            long ID;

                            //CONSULTA ID MANTENIMIENTOREGISTRO
                            var ConsultaID = (from MT in hb.MANTENIMIENTOREGISTRO
                                              orderby MT.ID descending
                                              select MT).FirstOrDefault();

                            if (ConsultaID == null)
                                ID = 1;
                            else
                                ID = ConsultaID.ID + 1;

                            //CARGA UN NUEVO MANTENIMIENTO
                            var MantenientoRegistro = new MANTENIMIENTOREGISTRO();

                            MantenientoRegistro.ID = ID;
                            MantenientoRegistro.MantenimientoTipo_ID = (int)cmbTipoMantenimiento.SelectedValue;
                            MantenientoRegistro.Fecha = dtpFecha.Value.Date;

                            if (cmbEstado.Text == "Pendiente")
                                MantenientoRegistro.Estado = "PEN";
                            if (cmbEstado.Text == "Finalizado")
                                MantenientoRegistro.Estado = "FI";
                            if (cmbEstado.Text == "Cancelada")
                                MantenientoRegistro.Estado = "CAN";

                            //CARGA MANTENIMIENTO REGISTRO CUERPO
                            if (dgvMantenimientoTarea.RowCount > 0)
                            {
                                //CONSULTA EL ULTIMO ID DE LA TAREA
                                var ConsultaTareaID = (from T in hb.MANTENIMIENTOREGISTROCUERPO
                                                       orderby T.ID descending
                                                       select T).FirstOrDefault();

                                if (ConsultaTareaID == null)
                                    IDTarea = 1;
                                else
                                    IDTarea = ConsultaTareaID.ID + 1;

                                for (var i = 0; i < dgvMantenimientoTarea.RowCount; i++)
                                {
                                    var MantenimientoCuerpo = new MANTENIMIENTOREGISTROCUERPO();

                                    MantenimientoCuerpo.ID = IDTarea;
                                    MantenimientoCuerpo.MantenimientoRegistro_ID = ID;
                                    MantenimientoCuerpo.MantenimientoTarea_ID = Convert.ToInt32(dgvMantenimientoTarea.Rows[i].Cells["colTareaID"].Value);
                                    MantenimientoCuerpo.Fecha = Convert.ToDateTime(dgvMantenimientoTarea.Rows[i].Cells["colFecha"].Value).Date;
                                    MantenimientoCuerpo.FechaLimite = Convert.ToDateTime(dgvMantenimientoTarea.Rows[i].Cells["colFechaLimite"].Value).Date;
                                    if (dgvMantenimientoTarea.Rows[i].Cells["colResponsableID"].Value.ToString() != "")
                                        MantenimientoCuerpo.Responsable_ID = Convert.ToInt32(dgvMantenimientoTarea.Rows[i].Cells["colResponsableID"].Value);
                                    else
                                        MantenimientoCuerpo.Responsable_ID = null;

                                    if (dgvMantenimientoTarea.Rows[i].Cells["colEstado"].Value.ToString() == "Pendiente")
                                    {
                                        MantenimientoCuerpo.Estado = "PEN";
                                        FinalizaMantenimiento = false;
                                    }                                    
                                    if (dgvMantenimientoTarea.Rows[i].Cells["colEstado"].Value.ToString() == "Finalizada")                                  
                                        MantenimientoCuerpo.Estado = "FI";
                                    if (dgvMantenimientoTarea.Rows[i].Cells["colEstado"].Value.ToString() == "Cancelada")
                                        MantenimientoCuerpo.Estado = "CAN";

                                    hb.MANTENIMIENTOREGISTROCUERPO.Add(MantenimientoCuerpo);
                                    IDTarea = IDTarea + 1;
                                }
                                //VALIDA QUE SI TODAS LAS TAREAS ESTAN FINALIZADAS FINALIZA EL MANTENIMIENTO
                                if (FinalizaMantenimiento == true)
                                    MantenientoRegistro.Estado = "FI";
                                else
                                    MantenientoRegistro.Estado = "PEN";

                                hb.MANTENIMIENTOREGISTRO.Add(MantenientoRegistro);
                            }
                            hb.SaveChanges();
                            MessageBox.Show("Datos cargados correctamente", "Atención");
                        }
                        if (Accion == "2")
                        {
                            bool Error = false;
                            string ErrorMensaje = "";

                            //CONSULTA LOS DATOS DE MANTENIMIENTOTIPO
                            var ConsultaMantenimientoRegistro = (from MT in hb.MANTENIMIENTOREGISTRO
                                                                 where MT.ID == IDRecibido
                                                                 select MT).FirstOrDefault();

                            //MODIFICA LOS DATOS DEL MANTENIMIENTO
                            ConsultaMantenimientoRegistro.Fecha = dtpFecha.Value.Date;

                            if (cmbEstado.Text == "Pendiente")
                                ConsultaMantenimientoRegistro.Estado = "PEN";
                            if (cmbEstado.Text == "Finalizado")
                                ConsultaMantenimientoRegistro.Estado = "FI";
                            if (cmbEstado.Text == "Cancelada")
                                ConsultaMantenimientoRegistro.Estado = "CAN";

                            //CONSULTA EL ULTIMO ID DE MANTENIMIENTOREGISTROCUERPO
                            var ConsultaTareaID = (from T in hb.MANTENIMIENTOREGISTROCUERPO
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

                                //if (Accion == "1") //CREAR
                                //{
                                //    var MantenimientoCuerpo = new MANTENIMIENTOREGISTROCUERPO();

                                //    MantenimientoCuerpo.ID = IDTarea;
                                //    Tarea.MantenimientoTipo_ID = IDRecibido;
                                //    Tarea.Descripcion = dgvMantenimientoTarea.Rows[i].Cells["colTarea"].Value.ToString();
                                //    Tarea.Estado = dgvMantenimientoTarea.Rows[i].Cells["colEstado"].Value.ToString();

                                //    hb.MANTENIMIENTOTIPOTAREA.Add(Tarea);
                                //    IDTarea = IDTarea + 1;
                                //}
                                if (Accion == "2") //EDITAR
                                {
                                    int IDTareaEditar = Convert.ToInt32(dgvMantenimientoTarea.Rows[i].Cells["colID"].Value);

                                    var ConsultaCuerpo = (from T in hb.MANTENIMIENTOREGISTROCUERPO
                                                          where T.ID == IDTareaEditar
                                                          select T).FirstOrDefault();

                                    ConsultaCuerpo.Fecha = Convert.ToDateTime(dgvMantenimientoTarea.Rows[i].Cells["colFecha"].Value.ToString()).Date;
                                    ConsultaCuerpo.FechaLimite = Convert.ToDateTime(dgvMantenimientoTarea.Rows[i].Cells["colFechaLimite"].Value.ToString()).Date;
                                    ConsultaCuerpo.Responsable_ID = Convert.ToInt32(dgvMantenimientoTarea.Rows[i].Cells["colResponsableID"].Value);

                                    if (dgvMantenimientoTarea.Rows[i].Cells["colEstado"].Value.ToString() == "Pendiente") 
                                    {
                                        ConsultaCuerpo.Estado = "PEN";
                                        FinalizaMantenimiento = false;
                                    }
                                       
                                    if (dgvMantenimientoTarea.Rows[i].Cells["colEstado"].Value.ToString() == "Finalizada")                                   
                                        ConsultaCuerpo.Estado = "FI";
                                    if (dgvMantenimientoTarea.Rows[i].Cells["colEstado"].Value.ToString() == "Cancelada")
                                        ConsultaCuerpo.Estado = "CAN";

                                    if (FinalizaMantenimiento == true)
                                        ConsultaMantenimientoRegistro.Estado = "FI";
                                    else
                                        ConsultaMantenimientoRegistro.Estado = "PEN";
                                }
                                //if (Accion == "3") //ELIMINAR
                                //{
                                //    int IDTareaEliminar = Convert.ToInt32(dgvMantenimientoTarea.Rows[i].Cells["colID"].Value);

                                //    var ConsultaTarea = (from T in hb.MANTENIMIENTOTIPOTAREA
                                //                         where T.ID == IDTareaEliminar
                                //                         select T).FirstOrDefault();

                                //    hb.MANTENIMIENTOTIPOTAREA.Remove(ConsultaTarea);
                                //}
                            }
                            hb.SaveChanges();
                            MessageBox.Show("Datos cargados correctamente", "Atención");
                            this.Hide();




                        }
                    }
                }
                    
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void AbrirForm(string Accion)
        {
            long ID;

            var f = new frmRegistroMantenimientoAgregarTarea();

            if (Accion == "2") //Editar
            {
                //if (dgvMantenimientoTarea.RowCount > 0)
                //{
                //    ID = Convert.ToInt64(dgvMantenimientoTarea.CurrentRow.Cells["colID"].Value);
                //    f.IDRecibido = ID;
                //}
            }
            f.Accion = Accion;
            f.DGV = dgvMantenimientoTarea;
            f.ShowDialog();
        }
        private void FormatearCeldas(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMantenimientoTarea.RowCount > 0)
            {
                if (this.dgvMantenimientoTarea.Columns[e.ColumnIndex].Name == "colEstado")
                {
                    if (e.Value.ToString() == "Finalizada")
                    {
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.Green;
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);                      
                    }
                    if (e.Value.ToString() == "Pendiente" || e.Value.ToString() == "Cancelada")
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.Font = new Font("Roboto Condensed", 9, FontStyle.Bold);                    
                    }
                }
            }
        }
        private void dgvMantenimientoTarea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirForm("2");
        }

        private void dgvMantenimientoTarea_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearCeldas(e);
        }

        private void txtBuscaTipoMantenimiento_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
