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

namespace PCodin_Sinlacc.Formularios.Secciones
{
    public partial class frmAgregarSeccion : Form
    {
        public string CodigoSeccion;
        public string CrearEditar;

        string CodigoOriginal;
        string DescripcionOriginal;
        public frmAgregarSeccion()
        {
            InitializeComponent();
        }
        private void InicializarForm()
        {
            Reutilizables.RenderizarForm(this);
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            using (var hb = new DBdatos())
            {
                Reutilizables.CargarColoresEnCombo(cmbColor);

                if (CrearEditar == "2")
                {
                    btnCargar.Text = "Editar Seccion";


                    var Consulta = (from S in hb.Seccion
                                    where S.Codigo == CodigoSeccion
                                    select S).FirstOrDefault();

                    txtCodigo.Text = Consulta.Codigo;
                    txtDescripcion.Text = Consulta.Descripcion;
                    cmbEstado.Text = Consulta.Estado_ID;

                    if(Consulta.Color != null)
                        btnColorMuestra.BackColor = Color.FromName(Consulta.Color);

                    CodigoOriginal = txtCodigo.Text;
                    DescripcionOriginal = txtDescripcion.Text;
                }
            }
        }
        private void EditarSeccion()
        {
            using (var hb = new DBdatos())
            {

                var ConsultaEditar = (from S in hb.Seccion
                                      where S.Codigo == CodigoSeccion
                                      select S).FirstOrDefault();


                if (CodigoOriginal != txtCodigo.Text || DescripcionOriginal != txtDescripcion.Text)
                {
                    if (CodigoOriginal != txtCodigo.Text)
                    {
                        var Consulta = (from S in hb.Seccion
                                        where S.Codigo == txtCodigo.Text
                                        select S).FirstOrDefault();

                        if (Consulta == null)
                        {
                            ConsultaEditar.Codigo = txtCodigo.Text;
                        }
                        else
                        {
                            MessageBox.Show("El código que desea cargar ya exite en la base de datos", "Atención");
                            return;
                        }

                    }
                    if (DescripcionOriginal != txtDescripcion.Text)
                    {
                        var Consulta = (from S in hb.Seccion
                                        where S.Descripcion == txtDescripcion.Text
                                        select S).FirstOrDefault();

                        if (Consulta == null)
                        {                        
                            ConsultaEditar.Descripcion = txtDescripcion.Text;
                        }
                        else
                        {
                            MessageBox.Show("La descripción que desea cargar ya exite en la base de datos", "Atención");
                            return;
                        }

                    }                  
                }
                ConsultaEditar.Color = cmbColor.Text;
                ConsultaEditar.Estado_ID = cmbEstado.Text;

                hb.SaveChanges();
                MessageBox.Show("Datos modificados correctamente", "Atención");
                this.Hide();
            }
        }
        private void CargarSeccion()
        {
            using (var hb = new DBdatos())
            {

                var Consulta = (from S in hb.Seccion
                                where S.Codigo == txtCodigo.Text || S.Descripcion == txtDescripcion.Text
                                select S).FirstOrDefault();

                if (Consulta == null)
                {
                    var i = new Seccion();

                    i.Codigo = txtCodigo.Text;
                    i.Descripcion = txtDescripcion.Text;
                    i.Estado_ID = cmbEstado.Text;
                    i.Color = cmbColor.Text;

                    hb.Seccion.Add(i);
                    hb.SaveChanges();
                    MessageBox.Show("Datos cargados correctamente", "Atención");
                }
                else
                {
                    if (Consulta.Codigo == txtCodigo.Text)
                        MessageBox.Show("El código que desea cargar ya exite en la base de datos", "Atención");
                    if (Consulta.Descripcion == txtDescripcion.Text)
                        MessageBox.Show("La descripción que desea cargar ya exite en la base de datos", "Atención");
                }
                this.Hide();
            }
        }
        private void OnOffbtnCargar()
        {
            if (txtCodigo.TextLength > 0 && txtDescripcion.TextLength > 0 && cmbEstado.Text != "")
                btnCargar.Enabled = true;
            else
                btnCargar.Enabled = false;
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {

        }

        private void frmAgregarSeccion_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbColor.SelectedIndex != -1)
            {
                btnColorMuestra.BackColor = Color.FromName(cmbColor.Text);
            }
        }

        private void cmbColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                string Texto = cmbColor.Items[e.Index].ToString();
                Brush Borde = new SolidBrush(e.ForeColor);
                Color Color = Color.FromName(Texto);
                Brush pincel = new SolidBrush(Color);
                Pen Boli = new Pen(e.ForeColor);

                e.Graphics.DrawRectangle(Boli, new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, 20, e.Bounds.Height - 4));
                e.Graphics.FillRectangle(pincel, new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 3, 20, e.Bounds.Height - 6));
                e.Graphics.DrawString(Texto, e.Font, Borde, e.Bounds.Left + 30, e.Bounds.Top + 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            if (CrearEditar == "1")
                CargarSeccion();
            else
                EditarSeccion();
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
