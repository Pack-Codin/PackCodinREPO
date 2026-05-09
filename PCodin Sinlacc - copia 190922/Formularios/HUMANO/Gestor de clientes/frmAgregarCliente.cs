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
using System.IO;
using PCodin_Sinlacc.Formularios.HUMANO.Gestor_de_clientes;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmAgregarCliente : Form
    {
        public string PulsoCrearEditarCliente;
        public int IDRecibido;
        public frmAgregarCliente()
        {
            InitializeComponent();
        }

        private void frmAgregarCliente_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscarCiudad, false);
            clsCargarCombos.MostrarComboTipoCliente(cmbTipoCliente);
            clsCargarCombos.MostrarComboZona(cmbZona);

            if (PulsoCrearEditarCliente == "1")
            {
                btnCargar.Text = "Registrar cliente";
                txtCabezal.Text = "Registrar Cliente";
                cmbZona.SelectedIndex = -1;
            }
            if (PulsoCrearEditarCliente == "2") // editar
            {
                btnCargar.Text = "Editar cliente";
                txtCabezal.Text = "Editar cliente";

                using (var hb = new DBdatos())
                {
                    var Consulta = (from E in hb.Clientes
                                    where E.ID == IDRecibido
                                    select E);

                    var Resultados = Consulta.FirstOrDefault();

                    if (Resultados != null)
                    {
                        txtNombreCliente.Text = Resultados.Descripcion;

                        if (Resultados.Cliente_Usuario == true)
                            chkclienteUsuario.Checked = true;
                        else
                            chkclienteUsuario.Checked = false;

                        cmbTipoCliente.SelectedValue = Resultados.Tipo;
                        cmbTipoCliente.Text = Resultados.Tipo_Cliente.Descripcion;
                        cmbCiudad.SelectedValue = Resultados.Ciudad_ID;
                        cmbCiudad.Text = Resultados.Ciudades.Descripcion;

                        if (Resultados.Zona_ID != null)
                        {
                            cmbZona.SelectedValue = Resultados.Zona_ID;
                            cmbZona.Text = Resultados.ZONA.Descripcion;
                        }
                        else
                            cmbZona.SelectedValue = -1;

                        txtDNI.Text = Resultados.DNI;
                        txtTelefono.Text = Resultados.Telefono;
                        txtEmail.Text = Resultados.Email;
                        cmbEstado.Text = Resultados.Estado;
                        txtObservaciones.Text = Resultados.Observaciones;

                        if (Resultados.Imagen != null)
                        {
                            var img = hb.Clientes.Find(Resultados.ID);

                            MemoryStream ms = new MemoryStream(img.Imagen);
                            Bitmap bit = new Bitmap(ms);

                            picImagen.Image = bit;
                        }
                    }
                }
            }                  
        }
        private void EditarCliente()
        {
            if(PulsoCrearEditarCliente == "2")
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from E in hb.Clientes
                                    where E.ID == IDRecibido
                                    select E);

                    var Resultados = Consulta.FirstOrDefault();

                    if(Resultados != null)
                    {
                        Resultados.Descripcion = txtNombreCliente.Text;

                        if (chkclienteUsuario.Checked)
                            Resultados.Cliente_Usuario = true;
                        else
                            Resultados.Cliente_Usuario = false;

                        Resultados.Tipo = cmbTipoCliente.SelectedValue.ToString();
                        Resultados.Ciudad_ID = (int)cmbCiudad.SelectedValue;

                        if (cmbZona.SelectedIndex != -1)
                            Resultados.Zona_ID = (int)cmbZona.SelectedValue;
                        else
                            Resultados.Zona_ID = null;

                        Resultados.Telefono = txtTelefono.Text;
                        Resultados.Email = txtEmail.Text;
                        Resultados.DNI = txtDNI.Text;
                        Resultados.Estado = cmbEstado.Text;
                        Resultados.Observaciones = txtObservaciones.Text;

                        if (txtDireccion.TextLength > 0)
                        {
                            byte[] file = null; // Carga la foto
                            Stream myStream = openFileDialog1.OpenFile();

                            using (MemoryStream ms = new MemoryStream())
                            {
                                myStream.CopyTo(ms);
                                file = ms.ToArray();

                            }
                            Resultados.Imagen = file;
                        }

                        hb.SaveChanges();
                        MessageBox.Show("Datos modificados correctamente", "Atención");

                    }
                }
            }
        }
        private void MostrarFotoSeleccionada()
        {
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) // abre el explorador archivos
            {
                txtDireccion.Text = openFileDialog1.FileName;
            }

            if (txtDireccion.TextLength == 0)
            {
                MessageBox.Show("No se ha elegido ninguna imagen");
                return;
            }
            picImagen.ImageLocation = txtDireccion.Text;
        }
        private void OnOffbtnCargarEditar()
        {
            if(txtNombreCliente.TextLength > 0
                && cmbCiudad.SelectedIndex != -1
                && cmbEstado.SelectedIndex != -1)
            {
                btnCargar.Enabled = true;
            }
            else
            {
                btnCargar.Enabled = false;
            }
        }
        private void AgregarCliente()
        {
            using (var hb = new DBdatos())
            {             
                var i = new Clientes();

                i.Descripcion = txtNombreCliente.Text;

                if (chkclienteUsuario.Checked)
                    i.Cliente_Usuario = true;
                else
                    i.Cliente_Usuario = false;

                i.Tipo = cmbTipoCliente.SelectedValue.ToString();
                i.Ciudad_ID = (int)cmbCiudad.SelectedValue;
                if(cmbZona.SelectedIndex != -1)
                    i.Zona_ID = (int)cmbZona.SelectedValue;
                i.Telefono = txtTelefono.Text;
                i.Email = txtEmail.Text;
                i.Estado = cmbEstado.Text;
                i.DNI = txtDNI.Text;

                if (txtDireccion.TextLength > 0)
                {
                    byte[] file = null; // Carga la foto
                    Stream myStream = openFileDialog1.OpenFile();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        myStream.CopyTo(ms);
                        file = ms.ToArray();

                    }
                    i.Imagen = file;
                }

                hb.Clientes.Add(i);
                hb.SaveChanges();
                MessageBox.Show("Cliente cargado correctamente", "Atención");
            }
        }
        private void EliminarCategoría()  // CONFIGURAR AL ULTIMO
        {
            //if (cmbCiudad.SelectedIndex != -1)
            //{
            //    DialogResult R = MessageBox.Show("¿Seguro que desea eliminar esta ciudad?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (R == DialogResult.Yes)
            //    {
            //        using (var hb = new DBdatos())
            //        {
            //            long ID = (int)cmbCiudad.SelectedValue;

            //            var Consulta = (from C in hb.Ciudades
            //                            where C.ID == ID
            //                            select C); // Trae el Id a eliminar

            //            //var ConsultaGeneral = (from C in hb.Productos_Insumos
            //            //                       where C.Categoria_ID == ID
            //            //                       select C); // Consulta global para que ver que ver si hay articulo con esta categoría

            //            var Resultados = Consulta.FirstOrDefault();
            //            //var ResultadosGeneral = ConsultaGeneral.ToList();

            //            if (Resultados == )
            //            {
            //                hb.Categorias_InsPro.Remove(Resultados);
            //                hb.SaveChanges();
            //                MessageBox.Show("Datos eliminados correctamente", "Atención");
            //                clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, false, chkMuestraCategActivasInact);
            //            }
            //            else
            //            {
            //                MessageBox.Show("No se puede eliminar esta categoría porque ya está afectada a otro artículo o producto. Solo puede darla de baja", "Atención");
            //            }
            //        }
            //    }
            //}
        }
        private void frmAgregarCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsCargarCombos.MostrarComboCiudades(cmbCiudad,txtBuscarCiudad,false);
        }
        private void AbrirFormCargar(string CrearEditar, string Accion ,int ID)
        {
            var f = new frmCrearCategoria();
            f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmCrearCategoria_FormClosed);
            f.PulsoAgregarEditar = CrearEditar;
            f.PulsoCategoriaPuestoCiudadConcepto = Accion;
            f.txtCabezal.Text = "Nueva Ciudad";
            f.ShowDialog();
        }
        private void frmCrearCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscarCiudad, false);
        }
        private void btnAgregarPuesto_Click(object sender, EventArgs e)
        {
            AbrirFormCargar("1","3",0); // accion 3 ciudades
        }
        private void AbrirFormEditar()
        {
            if (cmbCiudad.SelectedIndex != -1)
            {
                using (var hb = new DBdatos())
                {
                    //var Consulta = (from C in hb.Categorias_InsPro
                    //                where C.ID == (int)cmbCategoria.SelectedValue
                    //                select C);

                    //var Resultados = Consulta.FirstOrDefault();

                    var f = new frmCrearCategoria();
                    f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmCrearCategoria_FormClosed);
                    f.txtDescripcion.Text = cmbCiudad.Text;

                    //if (Resultados.Estado == "SI")
                    //    f.cmbEstado.SelectedIndex = 0;
                    //else
                    //    f.cmbEstado.SelectedIndex = 1;

                    f.IDRecibCategoriaEditarEliminar = (int)cmbCiudad.SelectedValue;
                    f.PulsoAgregarEditar = "2"; // editar
                    f.PulsoCategoriaPuestoCiudadConcepto = "3"; // Categoria
                    f.ShowDialog();
                }
            }
        }
        private void AbrirFormZona(string Accion , int ZonaID)
        {
            var f = new frmMostrarZona();
            f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmMostrarZona_FormClosed);
            f.Accion = Accion;         
            f.ShowDialog();
        }
        private void AbrirFormZonaEditar()
        {
            try
            {
                var f = new frmMostrarZona();
                f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmMostrarZona_FormClosed);
                f.Accion = "2";
                f.pnlSuperior.Visible = false;
                if (cmbZona.SelectedIndex != -1)
                    f.IdRecibido = (int)cmbZona.SelectedValue;
                else
                    MessageBox.Show("No seleccino zona para editar", "Atencion");

                using (var hb = new DBdatos())
                {
                    var Consulta = (from C in hb.ZONA
                                    where C.ID == (int)cmbZona.SelectedValue
                                    select C).FirstOrDefault();

                    f.pnlAgregar.Visible = true;

                    f.txtZona.Text = Consulta.Descripcion;
                    f.cmbEstado.Text = Consulta.Estado;
                    f.txtObservaciones.Text = Consulta.Observacion;

                    f.ShowDialog();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
            


            
        }
        private void frmMostrarZona_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsCargarCombos.MostrarComboZona(cmbZona);
        }

        private void btnEditarPuesto_Click(object sender, EventArgs e)
        {
            AbrirFormEditar();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscarCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarCiudad.Visible = false;
                clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscarCiudad, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarCiudad.Visible = false;
                //  clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, false);
            }
        }

        private void cmbCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboCiudades(cmbCiudad, txtBuscarCiudad, false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBuscarCiudad.Visible = true;
            txtBuscarCiudad.Select();
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargarEditar();
        }

        private void cmbCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargarEditar();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargarEditar();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargarEditar();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargarEditar();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

        }
        
        private void btnImagen_Click(object sender, EventArgs e)
        {
            MostrarFotoSeleccionada();
        }

        private void btnCargar1_Click(object sender, EventArgs e)
        {
            if (PulsoCrearEditarCliente == "1")
                AgregarCliente();
            else
                EditarCliente();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarZona_Click(object sender, EventArgs e)
        {
            AbrirFormZona("1", 0);
        }

        private void btnEditarZona_Click(object sender, EventArgs e)
        {
            AbrirFormZonaEditar();
        }

        private void txtNombreCliente_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarCiudad_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtTelefono_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtDNI_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtEmail_Click(object sender, EventArgs e)
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
