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
using PCodin_Sinlacc.Clases.UsuarioTema;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmCrearEditarUsuario : Form
    {
        public string CrearEditar;
        public int IdRecibido;
        public frmCrearEditarUsuario()
        {
            InitializeComponent();
        }
       
        private void frmCrearEditarUsuario_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        public int UsuarioID;
        private void InicializarForm()
        {
            Reutilizables.RenderizarForm(this);
            clsUsuarioTema.UsuarioTema(UsuarioID, pnlSuperior,pnlMenu,this);

            clsCargarCombos.MostrarModulos(cmbModulo,cmbItem);
            clsCargarCombos.MostrarItem(cmbModulo, cmbItem);
            clsCargarCombos.MostrarComboClientes(cmbClienteWeb, txtBuscaClienteWeb, false, "CLI", 0);
            cmbModulo.SelectedIndex = -1;
            cmbItem.SelectedIndex = -1;
            cmbClienteWeb.SelectedIndex = -1;
           
            if (CrearEditar == "2")
            {
                btnCargar.Text = "Editar usuario";

                using (var hb = new DBdatos())
                {
                    var ConsultaUsuario = (from U in hb.Usuarios
                                           where U.ID == IdRecibido
                                           select U);

                    var ConsultaAccesoUsuario = (from U in hb.Acceso_Usuario
                                                 where U.Usuario_ID == IdRecibido
                                                 orderby U.Menu_Item.Modulos.Nombre ascending,U.Menu_Item.Descripcion ascending
                                                 select U);

                    var ConsultaRectriccion = (from C in hb.USUARIORESTRICCION
                                               where C.UsuarioID == IdRecibido
                                               select C).ToList();

                    var ResultadoUsuario = ConsultaUsuario.FirstOrDefault();
                    var ResultadoAccesoUsuario = ConsultaAccesoUsuario.ToList();

                    if(ResultadoUsuario != null)
                    {
                        txtUsuario.Text = ResultadoUsuario.Nombre;
                        txtClave.Text = ResultadoUsuario.Clave;
                        cmbEstado.Text = ResultadoUsuario.Estado;
                        txtEmail.Text = ResultadoUsuario.Email;

                        if (ResultadoUsuario.EnviaNotificacion == "SI")
                            chkRecibeNotificaciones.Checked = true;
                        else
                            chkRecibeNotificaciones.Checked = false;

                        if (ResultadoUsuario.Monetizado == "SI")
                            chkMonetiza.Checked = true;
                        else
                            chkMonetiza.Checked = false;

                        if (ResultadoUsuario.UsuarioAPP == "SI")
                            chkUsuarioWeb.Checked = true;
                        else
                            chkUsuarioWeb.Checked = false;

                        if (ResultadoUsuario.AdminCaja == "SI")
                            chkAdministradorCaja.Checked = true;
                        else
                            chkAdministradorCaja.Checked = false;

                        if (ResultadoAccesoUsuario.Count > 0)
                        {
                            foreach (var item in ResultadoAccesoUsuario)
                            {
                                DataGridViewRow Fila = new DataGridViewRow();

                                Fila.CreateCells(dgvModulos);
                                Fila.Cells[0].Value = item.Menu_ID;
                                Fila.Cells[1].Value = item.Menu_Item.Descripcion;
                                Fila.Cells[3].Value = item.Menu_Item.Modulos.Nombre;
                                Fila.Cells[4].Value = item.Menu_Item.Tipo;

                                dgvModulos.Rows.Add(Fila);
                            }
                        }
                        if(ConsultaRectriccion.Count > 0)
                        {
                            foreach (var item in ConsultaRectriccion)
                            {
                                dgvRentriciones.Rows.Add(item.ID, item.ClienteID ,item.Clientes.Descripcion,"0");
                            }
                        }
                    }
                }
            }
            //dgvModulos.Sort(colMenu, ListSortDirection.Ascending);
            //dgvModulos.Sort(colModulo , ListSortDirection.Ascending );
            
        }
        private void AgregarModuloALista()
        {
            if(cmbModulo.SelectedIndex != -1)
            {
                string Tipo;

                using (var hb = new DBdatos())
                {
                    var Consulta = (from I in hb.Informes
                                    where I.Descripcion == cmbItem.Text
                                    select I).FirstOrDefault();

                    if (Consulta == null)
                        Tipo = "Menu";
                    else
                        Tipo = "Informe";
                }
                    


                DataGridViewRow Fila = new DataGridViewRow();

                Fila.CreateCells(dgvModulos);
                Fila.Cells[0].Value = cmbItem.SelectedValue;
                Fila.Cells[1].Value = cmbItem.Text;
                //Fila.Cells[3].Value = cmbModulo.SelectedValue;
                Fila.Cells[3].Value = cmbModulo.Text;
                Fila.Cells[4].Value = Tipo;

                for (var i = 1; i <= dgvModulos.RowCount; i++)
                {
                    int Menu_ID = (int)dgvModulos.Rows[i - 1].Cells[0].Value;

                    if ( Menu_ID == (int)cmbItem.SelectedValue) 
                    {
                        MessageBox.Show("El modulo " + cmbModulo.Text + " ya esta en la lista");
                        return;
                    }
                    
                }
                dgvModulos.Rows.Add(Fila);
                dgvModulos.Sort(colModulo,ListSortDirection.Ascending);
            }
        }
        private void ControlTotal()
        {
          DialogResult R = MessageBox.Show("¿Está seguro que le quiere dar 'Control total' a este a usuario?", "Atención",MessageBoxButtons.YesNo);
            if (R == DialogResult.Yes)
            {
                using (var hb = new DBdatos())
                {
                    dgvModulos.Rows.Clear();

                    var ConsultaMnuItem = (from MI in hb.Menu_Item
                                           orderby MI.Descripcion
                                           select MI);

                    var ResultadosMnuItem = ConsultaMnuItem.ToList();

                    foreach (var item in ResultadosMnuItem)
                    {
                        DataGridViewRow Fila = new DataGridViewRow();

                        Fila.CreateCells(dgvModulos);
                        Fila.Cells[0].Value = item.ID;
                        Fila.Cells[1].Value = item.Descripcion;
                        Fila.Cells[2].Value = item.Modulo_ID;
                        Fila.Cells[3].Value = item.Modulos.Nombre;

                        dgvModulos.Rows.Add(Fila);
                    }
                }
            }
        }
        private void CargarUsuario()
        {
            using (var hb = new DBdatos())
            {
                try
                {
                    var U = new Usuarios();

                    U.Nombre = txtUsuario.Text;
                    U.Clave = txtClave.Text;
                    U.Estado = cmbEstado.Text;
                    U.Email = txtEmail.Text;

                    if (chkRecibeNotificaciones.Checked)
                        U.EnviaNotificacion = "SI";
                    else
                        U.EnviaNotificacion = "NO";

                    if (chkMonetiza.Checked)
                        U.Monetizado = "SI";
                    else
                        U.Monetizado = "NO";

                    if (chkUsuarioWeb.Checked)
                        U.UsuarioAPP = "SI";
                    else
                        U.UsuarioAPP = "NO";

                    if (chkAdministradorCaja.Checked)
                        U.AdminCaja = "SI";
                    else
                        U.AdminCaja = "NO";

                    hb.Usuarios.Add(U);
                   // hb.SaveChanges();

                    for (var i = 1; i <= dgvModulos.RowCount; i++)
                    {
                        var z = new Acceso_Usuario();

                        z.Usuario_ID = U.ID;
                        z.Menu_ID = (int)dgvModulos.Rows[i - 1].Cells[0].Value;

                        hb.Acceso_Usuario.Add(z);
                    }
                    for (var w = 1; w <= dgvRentriciones.RowCount; w++)
                    {
                        var x = new USUARIORESTRICCION();

                        x.UsuarioID = U.ID;
                        x.ClienteID = (int)dgvRentriciones.Rows[w - 1].Cells["colCuentaID"].Value;

                        hb.USUARIORESTRICCION.Add(x);
                    }
                    if (UsuarioID == 4)
                    {
                        hb.SaveChanges();
                        MessageBox.Show("Usuario cargado correctamente", "Atención");
                        this.Hide();
                    }                       
                    else
                    {
                        if (chkUsuarioWeb.Checked == true)
                        {
                            hb.SaveChanges();
                            MessageBox.Show("Usuario cargado correctamente", "Atención");
                            this.Hide();
                        }                         
                        else
                            MessageBox.Show("Solo tiene permiso para crear usuarios WEB", "Atención");
                    }                                                              
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error");
                }                
            }
        }
        private void EditarUsuario()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaUsuarioValidacion = (from U in hb.Usuarios
                                                 where U.Nombre == txtUsuario.Text
                                                    && U.ID != IdRecibido
                                                 select U);

                var ConsultaUsuario = (from U in hb.Usuarios
                                       where U.ID == IdRecibido
                                       select U);
             
                var ResultadoUsuario = ConsultaUsuario.FirstOrDefault();
                
                var Validacion = ConsultaUsuarioValidacion.FirstOrDefault();

                if(ResultadoUsuario != null)
                {
                    if(Validacion == null)
                    {
                        ResultadoUsuario.Nombre = txtUsuario.Text;
                        ResultadoUsuario.Clave = txtClave.Text;
                        ResultadoUsuario.Estado = cmbEstado.Text;
                        ResultadoUsuario.Email = txtEmail.Text;

                        if (chkRecibeNotificaciones.Checked)
                            ResultadoUsuario.EnviaNotificacion = "SI";
                        else
                            ResultadoUsuario.EnviaNotificacion = "NO";

                        if (chkMonetiza.Checked)
                            ResultadoUsuario.Monetizado = "SI";
                        else
                            ResultadoUsuario.Monetizado = "NO";

                        if (chkUsuarioWeb.Checked)
                            ResultadoUsuario.UsuarioAPP = "SI";
                        else
                            ResultadoUsuario.UsuarioAPP = "NO";

                        if (chkAdministradorCaja.Checked)
                            ResultadoUsuario.AdminCaja = "SI";
                        else
                            ResultadoUsuario.AdminCaja = "NO";

                        var ConsultaAccesoUsuario = (from U in hb.Acceso_Usuario
                                                         where U.Usuario_ID == IdRecibido
                                                         select U).ToList();

                        hb.Acceso_Usuario.RemoveRange(ConsultaAccesoUsuario);
                        
                        for (var i = 1; i <= dgvModulos.RowCount; i++)
                        {
                            int Menu_ID = (int)dgvModulos.Rows[i - 1].Cells[0].Value;

                            var z = new Acceso_Usuario();

                            z.Usuario_ID = IdRecibido;
                            z.Menu_ID = Menu_ID;

                            hb.Acceso_Usuario.Add(z);
                        }
                        for (var w = 1; w <= dgvRentriciones.RowCount; w++)
                        {
                            if(dgvRentriciones.RowCount > 0)
                            {
                                if (dgvRentriciones.Rows[w - 1].Cells["colAccion"].Value.ToString() == "3")
                                {
                                    int IDEliminar = Convert.ToInt32(dgvRentriciones.Rows[w - 1].Cells["colIDTabla"].Value);

                                    var ConsultaEliminar = (from C in hb.USUARIORESTRICCION
                                                            where C.ID == IDEliminar
                                                            select C).FirstOrDefault();

                                    hb.USUARIORESTRICCION.Remove(ConsultaEliminar);
                                }
                                if (dgvRentriciones.Rows[w - 1].Cells["colAccion"].Value.ToString() == "1")
                                {
                                    var x = new USUARIORESTRICCION();

                                    x.UsuarioID = IdRecibido;
                                    x.ClienteID = (int)dgvRentriciones.Rows[w - 1].Cells["colCuentaID"].Value;

                                    hb.USUARIORESTRICCION.Add(x);
                                }
                            }                          
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un usuario con el nombre " + txtUsuario.Text);
                        return;
                    }
                }
                if (UsuarioID == 4)
                {
                    hb.SaveChanges();
                    MessageBox.Show("Usuario cargado correctamente", "Atención");
                    this.Hide();
                }
                else
                {
                    if (chkUsuarioWeb.Checked == true)
                    {
                        hb.SaveChanges();
                        MessageBox.Show("Usuario cargado correctamente", "Atención");
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Solo tiene permiso para crear usuarios WEB", "Atención");
                }
            }
        }
        private void btnConfirmarmarModulo_Click(object sender, EventArgs e)
        {
            AgregarModuloALista();
            OnOffbtnCargar();
        }
        private void OnOffbtnCargar()
        {
            //if(txtUsuario.TextLength > 0 && txtClave.TextLength> 0 && cmbEstado.SelectedIndex != -1 && dgvModulos.RowCount > 0)
            //{
            //    btnCargar.Enabled = true;
            //}
            //else
            //{
            //    btnCargar.Enabled = false;
            //}
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvModulos.RowCount > 0)
                dgvModulos.Rows.Remove(dgvModulos.CurrentRow);

            OnOffbtnCargar();
        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
            clsCargarCombos.MostrarItem(cmbModulo, cmbItem);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void btnControlTotal_Click(object sender, EventArgs e)
        {
            ControlTotal();
            OnOffbtnCargar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            if (CrearEditar == "1")
                CargarUsuario();
            if (CrearEditar == "2")
                EditarUsuario();
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtClave_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void btnAgregarCuentaWeb_Click(object sender, EventArgs e)
        {
            if(cmbClienteWeb.SelectedIndex != -1)
            {
                try
                {
                    bool Agregar = true;
                    if (dgvRentriciones.RowCount > 0)
                    {
                        for (var i = 1; i <= dgvRentriciones.RowCount; i++)
                        {
                            if (Convert.ToInt32(dgvRentriciones.Rows[i - 1].Cells["colCuentaID"].Value) == (int)cmbClienteWeb.SelectedValue)
                            {
                                MessageBox.Show("La cuenta seleccionada ya esta incluida en la grilla");
                                Agregar = false;
                            }                          
                        }
                        if(Agregar == true)
                            dgvRentriciones.Rows.Add(0,cmbClienteWeb.SelectedValue, cmbClienteWeb.Text,"1");
                    }
                    else if(dgvRentriciones.RowCount == 0)
                        dgvRentriciones.Rows.Add(0,cmbClienteWeb.SelectedValue, cmbClienteWeb.Text,"1");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error");                  
                }

            }
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRentriciones.RowCount > 0)
                {
                    if (CrearEditar == "1")
                        dgvRentriciones.Rows.Remove(dgvRentriciones.CurrentRow);
                    if (CrearEditar == "2")
                    {
                        dgvRentriciones.CurrentRow.Cells["colAccion"].Value = "3";
                        dgvRentriciones.CurrentRow.Visible = false;
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
