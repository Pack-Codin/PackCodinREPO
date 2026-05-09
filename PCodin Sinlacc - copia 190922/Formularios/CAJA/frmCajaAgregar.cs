using Microsoft.Office.Interop.Excel;
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

namespace PCodin_Sinlacc.Formularios.CAJA
{
    public partial class frmCajaAgregar : Form
    {
        public frmCajaAgregar()
        {
            InitializeComponent();
        }
        public string Accion;
        public int IDRecibido;
        private void frmCajaAgregar_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            try
            {              
                if (Accion == "2")
                {
                    using (var hb = new DBdatos())
                    {
                        var Consulta = (from C in hb.CAJA
                                        where C.ID == IDRecibido
                                        select C).FirstOrDefault();

                        txtCodigo.Text = Consulta.Codigo;
                        txtDescripcion.Text = Consulta.Descripcion;
                        cmbEstado.Text = Consulta.Estado;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
            
        }
        private void CargarDatos()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    if(Accion == "1")
                    {
                        if(txtCodigo.Text != "" && txtDescripcion.Text != "" && cmbEstado.Text != "")
                        {
                            var i = new Datos.CAJA();

                            var ConsultaVal = (from V in hb.CAJA
                                               where V.Codigo == txtCodigo.Text
                                               select V).FirstOrDefault();

                            if(ConsultaVal == null)
                            {
                                i.Codigo = txtCodigo.Text;
                                i.Descripcion = txtDescripcion.Text;
                                i.Estado = cmbEstado.Text;

                                hb.CAJA.Add(i);
                            }
                            else
                            {
                                MessageBox.Show("Ya existe una caja con codigo " + txtCodigo.Text, "Error");
                                return;
                            }

                               
                        }
                        else
                        {
                            if (txtCodigo.Text == "")
                                MessageBox.Show("No ingreso codigo", "Error");
                            if (txtDescripcion.Text == "")
                                MessageBox.Show("No ingreso descripcion", "Error");
                            if (cmbEstado.Text == "")
                                MessageBox.Show("No ingreso estado", "Error");
                        }
                    }
                    if(Accion == "2")
                    {
                        var Consulta = (from C in hb.CAJA
                                        where C.ID == IDRecibido
                                        select C).FirstOrDefault();

                        string CodigoOriginal = Consulta.Descripcion;

                        var ConsultaVal = (from V in hb.CAJA
                                           where V.Codigo == txtCodigo.Text && V.Codigo != CodigoOriginal
                                           select V).FirstOrDefault();

                        if(ConsultaVal == null && txtCodigo.Text != "" && txtDescripcion.Text != "" && cmbEstado.Text != "")
                        {
                            Consulta.Codigo = txtCodigo.Text;
                            Consulta.Descripcion = txtDescripcion.Text;
                            Consulta.Estado = cmbEstado.Text;
                        }
                        else
                        {
                            if (txtCodigo.Text == "")
                                MessageBox.Show("No ingreso codigo", "Error");
                            if (txtDescripcion.Text == "")
                                MessageBox.Show("No ingreso descripcion", "Error");
                            if (cmbEstado.Text == "")
                                MessageBox.Show("No ingreso estado", "Error");
                            if(ConsultaVal != null)
                                MessageBox.Show("Ya existe una caja con codigo " + txtCodigo.Text, "Error");
                        }
                    }
                    hb.SaveChanges();
                    MessageBox.Show("Datos cargados correctamente" ,"Atencion");
                    this.Hide();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
