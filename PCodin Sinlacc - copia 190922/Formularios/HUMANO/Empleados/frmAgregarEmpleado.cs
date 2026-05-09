using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Clases;
using System.IO;
using PCodin_Sinlacc.Clases.UsuarioTema;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmAgregarEmpleado : Form
    {
        public string PulsoCrearEditarEmpleado;
        public int IDRecibido;
        public frmAgregarEmpleado()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {            
            clsCargarCombos.MostrarComboPuestos(cmbPuesto);
            clsCargarCombos.MostrarSeccion(cmbSeccion);
            clsCargarCombos.MostrarComboZona(cmbZona);

            if (PulsoCrearEditarEmpleado == "2") // editar
            {
                btnCargar.Text = "Editar empleado";
                using (var hb = new DBdatos())
                {
                    var Consulta = (from E in hb.Empleados
                                    where E.ID == IDRecibido
                                    select E);

                    var Resultados = Consulta.FirstOrDefault();

                    if(Resultados != null)
                    {
                        txtNombreEmp.Text = Resultados.Nombre;
                        txtDNIEmp.Text = Resultados.Documento;
                        txtTel2Emp.Text = Resultados.Telefono;
                        dtpFechaNacimientoEmp.Value = Resultados.Fecha_Nacimiento;
                        cmbSexoEmp.Text = Resultados.Sexo;
                        dtpFechaAltaEmp.Value = Resultados.Fecha_Alta;
                        cmbPuesto.SelectedValue = Resultados.Puesto_ID;
                        cmbPuesto.Text = Resultados.Puestos.Descripcion;

                        if(Resultados.Zona_ID != null)
                        {
                            cmbZona.SelectedValue = Resultados.Zona_ID;
                            cmbZona.Text = Resultados.ZONA.Descripcion;
                        }
                        else
                            cmbZona.SelectedIndex = -1;

                        if (Resultados.Seccion_ID != null)
                        {
                            cmbSeccion.SelectedValue = Resultados.Seccion_ID;
                            cmbSeccion.Text = Resultados.Seccion.Descripcion;
                        }
                        cmbEstadoEmp.Text = Resultados.Estado;
                        txtObservacionesEmp.Text = Resultados.Observaciones;

                        if (Resultados.Foto != null)
                        {
                            var img = hb.Empleados.Find(Resultados.ID);

                            MemoryStream ms = new MemoryStream(img.Foto);
                            Bitmap bit = new Bitmap(ms);

                            picFotoEmp.Image = bit;
                        }
                    }
                }
            }
            if (PulsoCrearEditarEmpleado == "1")
            {
                cmbZona.SelectedIndex = -1;
            }
        }
        private void CargarEmpleado()
        {
            using (var hb = new DBdatos())
            {
                var i = new Empleados();

                i.Nombre = txtNombreEmp.Text;
                i.Documento = txtDNIEmp.Text;
                i.Telefono = txtTel2Emp.Text;
                i.Sexo = cmbSexoEmp.Text;
                i.Fecha_Nacimiento = dtpFechaNacimientoEmp.Value.Date;
                i.Fecha_Alta = dtpFechaAltaEmp.Value.Date;
                i.Puesto_ID = (int)cmbPuesto.SelectedValue;
                i.Seccion_ID = (int)cmbSeccion.SelectedValue;

                if (cmbZona.SelectedIndex == -1)
                    i.Zona_ID = null;
                else
                    i.Zona_ID = (int)cmbZona.SelectedValue;

                i.Estado = cmbEstadoEmp.Text;
                i.Observaciones = txtObservacionesEmp.Text;

                if (txtDireccion.TextLength > 0)
                {
                    byte[] file = null; // Carga la foto
                    Stream myStream = openFileDialog1.OpenFile();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        myStream.CopyTo(ms);
                        file = ms.ToArray();

                    }
                    i.Foto = file;
                }

                hb.Empleados.Add(i);
                hb.SaveChanges();
                MessageBox.Show("Datos Cargados Correctamente", "Atención");
                this.Hide();
            }
        }
        private void EditarEmpleado()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from E in hb.Empleados
                                where E.ID == IDRecibido
                                select E);

                var Resultados = Consulta.FirstOrDefault();

                if (Resultados != null)
                {
                    Resultados.Nombre = txtNombreEmp.Text;
                    Resultados.Documento = txtDNIEmp.Text;
                    Resultados.Telefono = txtTel2Emp.Text;
                    Resultados.Sexo = cmbSexoEmp.Text;
                    Resultados.Fecha_Nacimiento = dtpFechaNacimientoEmp.Value.Date;
                    Resultados.Fecha_Alta = dtpFechaAltaEmp.Value.Date;
                    Resultados.Puesto_ID = (int)cmbPuesto.SelectedValue;
                    if (cmbZona.SelectedValue != null)
                        Resultados.Zona_ID = (int)cmbZona.SelectedValue;
                    else
                        Resultados.Zona_ID = null;

                    if (cmbSeccion.SelectedValue != null)
                        Resultados.Seccion_ID = (int)cmbSeccion.SelectedValue;

                    Resultados.Estado = cmbEstadoEmp.Text;
                    Resultados.Observaciones = txtObservacionesEmp.Text;

                    if (txtDireccion.TextLength > 0)
                    {
                        byte[] file = null; // Carga la foto
                        Stream myStream = openFileDialog1.OpenFile();

                        using (MemoryStream ms = new MemoryStream())
                        {
                            myStream.CopyTo(ms);
                            file = ms.ToArray();

                        }
                        Resultados.Foto = file;
                    }
                }
                hb.SaveChanges();
                MessageBox.Show("Datos editados correctamente", "Atención");
                this.Hide();
            }
        }
        private void ActivarbtnCargarEmpleado()
        {
            if (txtNombreEmp.TextLength > 0 && dtpFechaNacimientoEmp != null && cmbSexoEmp.SelectedIndex != -1 && cmbPuesto.SelectedIndex != -1 && cmbEstadoEmp.SelectedIndex != -1)
                btnCargar.Enabled = true;
            else
                btnCargar.Enabled = false;
        }
        public void AbrirFormCrearModifPuesto(string CrearEditar) // se reutiliza eb PUESTOS
        {
            var f = new frmCrearCategoria();
            f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmCrearCategoria_FormClosed);
            f.PulsoAgregarEditar = CrearEditar;
            f.btnCargar.Text = "Cargar puesto";
            if (CrearEditar == "2") // si va a editar manda el id del combo
                f.IDRecibCategoriaEditarEliminar = (int)cmbPuesto.SelectedValue; //           
            f.PulsoCategoriaPuestoCiudadConcepto = "2";
            f.ShowDialog();
        }
        private void frmCrearCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsCargarCombos.MostrarComboPuestos(cmbPuesto);
        }
        private void btnAgregarPuesto_Click(object sender, EventArgs e)
        {
            AbrirFormCrearModifPuesto("1");
        }

        private void btnEditarPuesto_Click(object sender, EventArgs e)
        {
            AbrirFormCrearModifPuesto("2");
        }
        private void EliminarPuesto()
        {
            if (cmbPuesto.SelectedIndex != -1)
            {
                if (cmbPuesto.SelectedIndex != -1)
                {
                    DialogResult R = MessageBox.Show("¿Seguro que desea eliminar esta puesto?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (R == DialogResult.Yes)
                    {
                        using (var hb = new DBdatos())
                        {
                            long ID = (int)cmbPuesto.SelectedValue;

                            var Consulta = (from C in hb.Puestos
                                            where C.ID == ID
                                            select C); // Trae el Id a eliminar

                            var ConsultaGeneral = (from C in hb.Empleados
                                                   where C.Puesto_ID == ID
                                                   select C); // Consulta global para que ver que ver si hay articulo con esta categoría

                            var Resultados = Consulta.FirstOrDefault();
                            var ResultadosGeneral = ConsultaGeneral.ToList();

                            if (ResultadosGeneral.Count == 0)
                            {
                                hb.Puestos.Remove(Resultados);
                                hb.SaveChanges();
                                MessageBox.Show("Datos eliminados correctamente", "Atención");
                                clsCargarCombos.MostrarComboPuestos(cmbPuesto);
                            }
                            else
                            {
                                MessageBox.Show("No se puede eliminar esta categoría porque ya está afectada a otros empelados. Solo puede darla de baja", "Atención");
                            }
                        }
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
            picFotoEmp.ImageLocation = txtDireccion.Text;
        }
        private void EliminarFoto()
        {
            picFotoEmp.ImageLocation = "C:/Users/franc/Documents/Kacos/Proyectos propios/VerificacionBobinas/Images/user.png";

            using (var hb = new DBdatos())
            {
                //int ID = Convert.ToInt32(lblIDEmpleado.Text);

                //var consulta = (from D in hb.Empleado
                //                where D.ID == ID
                //                select D);

                //var resultado = consulta.FirstOrDefault();

                //if (resultado.Foto != null)
                //{
                //    resultado.Foto = null;
                //    hb.SaveChanges();
                //}
            }
        }
        private void btnEliminarPuesto_Click(object sender, EventArgs e)
        {
            EliminarPuesto();
        }

        private void txtNombreEmp_TextChanged(object sender, EventArgs e)
        {
            ActivarbtnCargarEmpleado();
        }

        private void txtApeEmp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDNIEmp_TextChanged(object sender, EventArgs e)
        {
            ActivarbtnCargarEmpleado();
        }

        private void txtTel2Emp_TextChanged(object sender, EventArgs e)
        {
            ActivarbtnCargarEmpleado();
        }

        private void dtpFechaNacimientoEmp_ValueChanged(object sender, EventArgs e)
        {
            ActivarbtnCargarEmpleado();
        }

        private void cmbSexoEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarbtnCargarEmpleado();
        }

        private void dtpFechaAltaEmp_ValueChanged(object sender, EventArgs e)
        {
            ActivarbtnCargarEmpleado();
        }

        private void cmbPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarbtnCargarEmpleado();
        }

        private void cmbEstadoEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarbtnCargarEmpleado();
        }

        private void txtObservacionesEmp_TextChanged(object sender, EventArgs e)
        {
            ActivarbtnCargarEmpleado();
        }

        private void btnCargarEmp_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarFoto_Click(object sender, EventArgs e)
        {
            MostrarFotoSeleccionada();
        }

        private void frmAgregarEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void cmsEditarEliminarFotoPC_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnEliminarFoto_Click(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (PulsoCrearEditarEmpleado == "1")
                CargarEmpleado();
            if (PulsoCrearEditarEmpleado == "2")
                EditarEmpleado();
        }

        private void txtNombreEmp_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtDNIEmp_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtTel2Emp_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtObservacionesEmp_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
