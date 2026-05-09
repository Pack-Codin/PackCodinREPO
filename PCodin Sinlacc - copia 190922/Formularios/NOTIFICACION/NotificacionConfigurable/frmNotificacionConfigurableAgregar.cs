using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Datos;
using TextBox = System.Windows.Forms.TextBox;

namespace PCodin_Sinlacc.Formularios.NOTIFICACION.NotificacionConfigurable
{
    public partial class frmNotificacionConfigurableAgregar : Form
    {
        public frmNotificacionConfigurableAgregar()
        {
            InitializeComponent();
        }
        public string Accion;
        public int IDRecibido;
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNotificacionConfigurableAgregar_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            Reutilizables.RenderizarForm(this);
            clsCargarCombos.MostrarComboUsuario(cmbUsuario);
            clsCargarCombos.MostrarModulo(cmbModulo);
            cmbUsuario.SelectedIndex = -1;


            if (Accion == "2")
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaNotificacion = (from MT in hb.NOTIFICACIONCONFIGURABLE
                                                 where MT.ID == IDRecibido
                                                 select MT).FirstOrDefault();

                    var ConsultaContactos = (from T in hb.NOTIFICACIONCONFIGURABLEENVIO
                                          where T.NotificacionConfigurable_ID == IDRecibido
                                          select T).ToList();

                    var ConsultaModulo = (from M in hb.Modulos
                                          where M.ID == ConsultaNotificacion.Modulo
                                          select M).FirstOrDefault();

                    txtDescripcion.Text = ConsultaNotificacion.Descripcion;
                    //Agregar aqui cmbEstado
                    txtAsunto.Text = ConsultaNotificacion.EmailAsunto;
                    txtMensaje.Text = ConsultaNotificacion.EmailMensaje;
                    txtConsulta.Text = ConsultaNotificacion.Consulta;
                    txtHtml.Text = ConsultaNotificacion.HTML;
                    cmbEstado.Text = ConsultaNotificacion.Estado;
                    cmbParametros.Text = ConsultaNotificacion.ParametrosCantidad.ToString();
                    cmbModulo.SelectedValue = (int)ConsultaNotificacion.Modulo;
                    cmbModulo.Text = ConsultaModulo.Nombre;

                    if (ConsultaNotificacion.NotificaProveedor == "SI")
                        chkNotificaProveedor.Checked = true;
                    else
                        chkNotificaProveedor.Checked = false;

                    foreach (var item in ConsultaContactos) 
                    {
                        dgvUsuarios.Rows.Add(item.ID,
                                             item.Usuario_ID,
                                             item.Usuarios.Nombre,
                                             "0");
                    }
                }
            }
            //else
                //cmbEstado.SelectedIndex = 0;


        }

        private void btnConfirmarProducto_Click(object sender, EventArgs e)
        {
            if(cmbUsuario.SelectedIndex != -1)
            {
                bool Error = false;
                for (var i = 0; i < dgvUsuarios.RowCount; i++)
                {
                    

                    if (Convert.ToInt32(dgvUsuarios.Rows[i].Cells["colID"].Value) != (int)cmbUsuario.SelectedValue)
                    {
                        Error = false;
                    }
                    else
                    {
                        Error = false;
                    }                  
                }
                if (Error == false)
                    dgvUsuarios.Rows.Add("",cmbUsuario.SelectedValue, cmbUsuario.Text, "1");
                else
                    MessageBox.Show("El usuario " + cmbUsuario.Text + " ya esta en la lista", "Atención");
            }
        }
        private void CargarDatos()
        {
            using (var hb = new DBdatos())
            {
                try
                {
                    int ID;

                    if (Accion == "1")
                    {


                        var ConsultaID = (from NC in hb.NOTIFICACIONCONFIGURABLE
                                          orderby NC.ID descending
                                          select NC).Take(1).FirstOrDefault();

                        if (ConsultaID == null)
                            ID = 1;
                        else
                            ID = ConsultaID.ID + 1;

                        var NotificacionConfigurable = new NOTIFICACIONCONFIGURABLE();

                        NotificacionConfigurable.ID = ID;
                        NotificacionConfigurable.Descripcion = txtDescripcion.Text;
                        NotificacionConfigurable.EmailAsunto = txtAsunto.Text;
                        NotificacionConfigurable.EmailMensaje = txtMensaje.Text;
                        NotificacionConfigurable.HTML = txtHtml.Text;
                        NotificacionConfigurable.Consulta = txtConsulta.Text;
                        NotificacionConfigurable.Estado = cmbEstado.Text;
                        NotificacionConfigurable.ParametrosCantidad = Convert.ToInt32(cmbParametros.Text);
                        NotificacionConfigurable.Modulo = (int)cmbModulo.SelectedValue;

                        if (chkNotificaProveedor.Checked)
                            NotificacionConfigurable.NotificaProveedor = "SI";
                        else
                            NotificacionConfigurable.NotificaProveedor = "NO";

                        hb.NOTIFICACIONCONFIGURABLE.Add(NotificacionConfigurable);


                        if (dgvUsuarios.RowCount > 0)
                        {



                            int NotificacionConfigurableEnvioID;

                            var ConsultaEnvioID = (from NC in hb.NOTIFICACIONCONFIGURABLEENVIO
                                                   orderby NC.ID descending
                                                   select NC).FirstOrDefault();

                            if (ConsultaID == null)
                                NotificacionConfigurableEnvioID = 1;
                            else
                                NotificacionConfigurableEnvioID = ConsultaEnvioID.ID + 1;



                            for (var i = 0; i < dgvUsuarios.RowCount; i++)
                            {
                                var NotificacionConfigurableEnvio = new NOTIFICACIONCONFIGURABLEENVIO();

                                NotificacionConfigurableEnvio.ID = NotificacionConfigurableEnvioID;
                                NotificacionConfigurableEnvio.Usuario_ID = Convert.ToInt32(dgvUsuarios.Rows[i].Cells["colUsuarioID"].Value);
                                NotificacionConfigurableEnvio.NotificacionConfigurable_ID = ID;

                                NotificacionConfigurableEnvioID = NotificacionConfigurableEnvioID + 1;

                                hb.NOTIFICACIONCONFIGURABLEENVIO.Add(NotificacionConfigurableEnvio);

                            }
                        }
                    }
                    if (Accion == "2")
                    {
                        var ConsultaNotificacion = (from NC in hb.NOTIFICACIONCONFIGURABLE
                                                    where NC.ID == IDRecibido
                                                    select NC).FirstOrDefault();

                        ConsultaNotificacion.Descripcion = txtDescripcion.Text;
                        ConsultaNotificacion.EmailAsunto = txtAsunto.Text;
                        ConsultaNotificacion.EmailMensaje = txtMensaje.Text;
                        ConsultaNotificacion.HTML = txtHtml.Text;
                        ConsultaNotificacion.Consulta = txtConsulta.Text;
                        ConsultaNotificacion.Estado = cmbEstado.Text;
                        ConsultaNotificacion.ParametrosCantidad = Convert.ToInt32(cmbParametros.Text);
                        ConsultaNotificacion.Modulo = (int)cmbModulo.SelectedValue;

                        if (chkNotificaProveedor.Checked)
                            ConsultaNotificacion.NotificaProveedor = "SI";
                        else
                            ConsultaNotificacion.NotificaProveedor = "NO";

                        if (dgvUsuarios.RowCount > 0)
                        {
                            var ConsultaContactosID = (from NC in hb.NOTIFICACIONCONFIGURABLEENVIO
                                                       orderby NC.ID descending
                                                       select NC).FirstOrDefault();

                            int NotificacionConfigurableEnvioID;

                            if (ConsultaContactosID == null)
                                NotificacionConfigurableEnvioID = 1;
                            else
                                NotificacionConfigurableEnvioID = ConsultaContactosID.ID + 1;

                            for (var i = 0; i < dgvUsuarios.RowCount; i++)
                            {
                                string AccionGrilla = dgvUsuarios.Rows[i].Cells["colAccion"].Value.ToString();

                                if (AccionGrilla == "1")
                                {
                                    var NotificacionConfigurableEnvio = new NOTIFICACIONCONFIGURABLEENVIO();

                                    NotificacionConfigurableEnvio.ID = NotificacionConfigurableEnvioID;
                                    NotificacionConfigurableEnvio.Usuario_ID = Convert.ToInt32(dgvUsuarios.Rows[i].Cells["colUsuarioID"].Value);
                                    NotificacionConfigurableEnvio.NotificacionConfigurable_ID = IDRecibido;

                                    NotificacionConfigurableEnvioID = NotificacionConfigurableEnvioID + 1;

                                    hb.NOTIFICACIONCONFIGURABLEENVIO.Add(NotificacionConfigurableEnvio);
                                }
                                if (AccionGrilla == "2")
                                {
                                    int IDModificar = Convert.ToInt32(dgvUsuarios.Rows[i].Cells["colID"].Value);

                                    var ConsultaContactos = (from C in hb.NOTIFICACIONCONFIGURABLEENVIO
                                                             where C.ID == IDModificar
                                                             select C).FirstOrDefault();

                                    ConsultaContactos.Usuario_ID = Convert.ToInt32(dgvUsuarios.Rows[i].Cells["colUsuarioID"].Value);

                                }
                                if (AccionGrilla == "3")
                                {
                                    int IDEliminar = Convert.ToInt32(dgvUsuarios.Rows[i].Cells["colID"].Value);

                                    var ConsultaContactos = (from C in hb.NOTIFICACIONCONFIGURABLEENVIO
                                                             where C.ID == IDEliminar
                                                             select C).FirstOrDefault();

                                    hb.NOTIFICACIONCONFIGURABLEENVIO.Remove(ConsultaContactos);
                                }
                            }
                        }

                    }
                    hb.SaveChanges();
                    MessageBox.Show("Datos cargados correctamente", "Atención");
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message, "Atención");
                }

            }
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void EliminarUsuario()
        {
            if (dgvUsuarios.RowCount > 0)
            {
                if (Accion == "1")
                    dgvUsuarios.Rows.Remove(dgvUsuarios.CurrentRow);
                if (Accion == "2")
                {
                    dgvUsuarios.CurrentRow.Cells["colAccion"].Value = "3";
                    dgvUsuarios.CurrentRow.DefaultCellStyle.ForeColor = Color.IndianRed;
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           // Reutilizables.ConectarSQL(1, textBox1);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarUsuario();
        }

        private void btnTexto_Click(object sender, EventArgs e)
        {
            txtMensaje.Visible = true;
            txtHtml.Visible = false;

            btnTexto.BackColor = Color.Orange;
            btnHTLM.BackColor = Color.White;
        }

        private void btnHTLM_Click(object sender, EventArgs e)
        {
            txtMensaje.Visible = false;
            txtHtml.Visible = true;

            btnTexto.BackColor = Color.White;
            btnHTLM.BackColor = Color.Orange;
        }

        private void txtDescripcion_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtAsunto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtConsulta_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void cmbParametros_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
