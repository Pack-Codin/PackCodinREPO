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

namespace PCodin_Sinlacc.Formularios.Deposito
{
    public partial class frmDeposito2 : Form
    {
        public frmDeposito2()
        {
            InitializeComponent();
        }
        public string Accion;
        public Form FormSeccion1;
        public Form FormSeccion2;
        public frmAgregarProdcutoTerminado FormularioAgregar;

        private void btnAbrirSeccion1_Click(object sender, EventArgs e)
        {
            FormSeccion2.Hide();
            FormSeccion1.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            InicializarForm();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
            btnMostrarfiltros.Text = "";
        }

        private void frmDeposito2_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        public void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                foreach (var control in this.Controls)
                {
                    if (control is Button && ((Button)control).Name != "btnMostrarfiltros")
                    {
                        var Consulta = (from D in hb.Existencia_ProductoTerminado
                                        where D.Deposito == ((Button)control).Name
                                            && D.Estado_ID == "PEN"
                                        select D);

                        if (chkFiltraInsPro.Checked)
                        {
                            Consulta = (from D in Consulta
                                        where D.Produto_ID == cmbFiltraInsPro.SelectedValue.ToString()
                                        select D);
                        }
                        if (chkFiltraProduccion.Checked && txtFiltraProduccion.TextLength > 0)
                        {
                            long ProduccioID = Convert.ToInt64(txtFiltraProduccion.Text);

                            Consulta = (from D in Consulta
                                        where D.ID == ProduccioID
                                        select D);
                        }
                        if (chkFiltraFicha.Checked)
                        {
                            Consulta = (from D in Consulta
                                        where D.Ficha == cmbFiltraFicha.Text
                                        select D);
                        }
                        if (chkFiltraRetencion.Checked)
                        {
                            Consulta = (from D in Consulta
                                        where D.Retencion == cmbFiltraRetencion.Text
                                        select D);
                        }
                        if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                        {
                            Consulta = (from C in Consulta
                                        where C.Fecha >= dtpFechaDesde.Value.Date
                                        select C);
                        }
                        else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                        {
                            Consulta = (from C in Consulta
                                        where C.Fecha <= dtpFechaHasta.Value.Date
                                        select C);
                        }
                        else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                        {
                            Consulta = (from C in Consulta
                                        where C.Fecha >= dtpFechaDesde.Value.Date && C.Fecha <= dtpFechaHasta.Value.Date
                                        select C);
                        }

                        var Resultados = Consulta.FirstOrDefault();

                        if (!chkFiltraInsPro.Checked && !chkFiltraProduccion.Checked && !chkFiltraFicha.Checked && !chkFiltraRetencion.Checked && !chkFechaDesde.Checked && !chkFechaHasta.Checked)
                        {
                            if (Resultados != null)
                            {
                                if (Resultados.Productos_Insumos.Color != null)
                                {
                                    ((Button)control).Visible = true;
                                    ((Button)control).BackColor = Color.FromName(Resultados.Productos_Insumos.Color);
                                    ((Button)control).Text = Resultados.Produto_ID;
                                }
                                else
                                {
                                    ((Button)control).Visible = true;
                                    ((Button)control).BackColor = Color.White;
                                    ((Button)control).Text = Resultados.Produto_ID;
                                }
                            }
                            else
                                ((Button)control).Visible = true;
                        }
                        else
                        {
                            if (Resultados != null)
                            {
                                ((Button)control).Visible = true;
                                ((Button)control).BackColor = Color.FromName(Resultados.Productos_Insumos.Color);
                                ((Button)control).Text = Resultados.Produto_ID;
                            }
                            else
                                ((Button)control).Visible = false;
                        }
                    }
                }
            }
        }
        private void AbriVisorDeposito(Button btn)
        {
            if (Accion != "Seleccionar")
            {
                var f = new frmVisorDeposito();
                f.Deposito = btn.Name;
                f.Show();
            }
            else
            {
                using (var hb = new DBdatos())
                {
                    //frmDeposito.DeleteTT_DepositoSeleccionado();

                    // var i = new TT_DepositoSeleccionado();

                    // i.DepositoSeleccionado = btn.Name;

                    // hb.TT_DepositoSeleccionado.Add(i);
                    // hb.SaveChanges();

                    // this.Hide();
                    // FormSeccion1.Hide();

                    if (btn.Name.Length == 8)
                    {
                        FormularioAgregar.cmbRack.Text = btn.Name.Remove(2);
                        FormularioAgregar.cmbEspacio.Text = btn.Name.Substring(2, 2);
                        FormularioAgregar.cmbPiso.Text = btn.Name.Substring(4, 2);
                        FormularioAgregar.cmbLado.Text = btn.Name.Substring(6, 2);
                    }
                    if (btn.Name.Length == 9)
                    {
                        FormularioAgregar.cmbRack.Text = btn.Name.Remove(2);
                        FormularioAgregar.cmbEspacio.Text = btn.Name.Substring(2, 3);
                        FormularioAgregar.cmbPiso.Text = btn.Name.Substring(5, 2);
                        FormularioAgregar.cmbLado.Text = btn.Name.Substring(7, 2);

                         this.Hide();
                         FormSeccion1.Hide();
                    }
                }
            }
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (Accion == "Seleccionar")
            {
                frmDeposito.DeleteTT_DepositoSeleccionado();
                this.Hide();
            }
            else
            {
                this.Hide();
            }
        }

        private void R1E8P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E8P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E8P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E8P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E8P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E8P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void button88_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InicializarForm();
        }

        private void R2E8P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E8P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E8P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E8P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E8P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E8P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E8P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E8P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E8P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E8P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E8P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E8P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E8P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E8P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E8P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E8P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E8P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E8P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E8P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E9P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E8P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E8P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E8P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E8P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E8P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E8P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E8P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E8P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E8P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E8P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E8P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E9P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E9P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E9P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E9P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E9P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E9P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E9P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E9P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E9P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E9P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E9P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E9P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E9P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E9P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E9P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E9P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E9P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E9P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E9P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E9P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E9P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E9P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E9P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E9P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E9P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E9P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E9P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E9P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E9P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E9P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E9P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E9P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E9P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E9P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E9P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E10P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E10P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E10P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E10P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E10P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E10P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E10P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E10P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E10P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E10P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E10P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E10P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E10P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E10P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E10P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E10P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E10P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E10P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E10P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E10P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E10P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E10P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E10P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E10P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E10P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E10P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E10P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E10P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E10P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E10P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E10P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E10P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E10P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E10P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E10P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E10P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E11P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E11P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E11P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E11P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E11P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E11P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E11P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E11P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E11P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E11P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E11P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E11P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E11P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E11P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E11P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E11P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E11P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E11P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E11P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E11P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E11P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E11P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E11P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E11P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E11P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E11P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E11P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E11P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E11P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E11P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E11P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E11P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E11P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E11P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E11P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E11P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E12P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E12P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E12P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E12P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E12P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E12P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E12P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E12P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E12P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E12P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E12P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E12P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E12P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E12P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E12P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E12P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E12P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void button207_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E12P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E12P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E12P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E12P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E12P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E12P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E12P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E12P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E12P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E12P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E12P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E12P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E12P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E12P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E12P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E12P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E12P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E12P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E13P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E13P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E13P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E13P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E13P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E13P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E13P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E13P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E13P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E13P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E13P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E13P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E13P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E13P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E13P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E13P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E13P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E13P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E13P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E13P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E13P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E13P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E13P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E13P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E13P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E13P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E13P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E13P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E13P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E13P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E13P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E13P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E13P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E13P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E13P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E13P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E14P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E14P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E14P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E14P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E14P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E14P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E14P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E14P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E14P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E14P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E14P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E14P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E14P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E14P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E14P3L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E14P2L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E14P1L2_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E14P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E14P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R1E14P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E14P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E14P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R2E14P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E14P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E14P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R3E14P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E14P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E14P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R4E14P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E14P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E14P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R5E14P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E14P3L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E14P2L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void R6E14P1L1_Click(object sender, EventArgs e)
        {
            var Boton = sender as Button;
            AbriVisorDeposito(Boton);
        }

        private void chkFiltraInsPro_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, btnBuscarInsPro, "PRO", "NO");
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsPro, txtBuscaInsPro, "PRO", true, "NO");
                txtBuscaInsPro.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaInsPro.Visible = false;
                txtBuscaInsPro.Focus();
                e.Handled = true;
            }
        }

        private void cmbFiltraInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraInsPro, txtBuscaInsPro, "PRO", false, "NO");
                txtBuscaInsPro.Focus();
                e.Handled = true;
            }
        }

        private void chkFiltraProduccion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraProduccion, chkFiltraProduccion);
        }

        private void chkFiltraRetencion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraRetencion, cmbFiltraRetencion);
        }

        private void chkFiltraFicha_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraFicha, cmbFiltraFicha);
        }

        private void chkFechaDesde_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaDesde, dtpFechaDesde);
        }

        private void chkFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaHasta, dtpFechaHasta);
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }

        private void txtBuscaInsPro_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
