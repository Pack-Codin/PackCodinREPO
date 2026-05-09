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

namespace PCodin_Sinlacc.Formularios.Circuito_Productivo
{
    public partial class frmAgregarCircuito : Form
    {
        public string CrearEditar;
        public string CodigoProduto;
        public string Producto;
        string SeccionFinal = "NO"; // variable creada para determinar si la sección es la final o no
        public int UsuarioID;
        public frmAgregarCircuito()
        {
            InitializeComponent();
        }

        private void frmAgregarCircuito_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);

            using (var hb = new DBdatos())
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbProducto, txtProducto, "PRO", false,"NO");
                //MostrarComboInsumoPorFormula();
                cmbProducto.SelectedIndex = -1;
                cmbInsumo.SelectedIndex = -1;
                clsCargarCombos.MostrarSeccion(cmbSeccion);
                cmbInsumo.SelectedIndex = -1;
                cmbSeccion.SelectedIndex = -1;
                
                if (CrearEditar == "2")
                {
                    var Consulta = (from FP in hb.Seccion_Circuito
                                    where FP.Producto_ID == CodigoProduto
                                    orderby FP.Orden, FP.Insumo_ID
                                    select FP).ToList();

                    cmbProducto.SelectedValue = CodigoProduto;
                    cmbProducto.Text = Producto;

                    foreach (var Item in Consulta)
                    {
                        DataGridViewRow Fila = new DataGridViewRow();

                        Fila.CreateCells(dgvCircuitoProd);
                        Fila.Cells[0].Value = Item.Orden;
                        if (Item.Insumo_ID != null)
                        {
                            Fila.Cells[1].Value = Item.Insumo_ID;
                            Fila.Cells[2].Value = Item.Productos_Insumos1.Descripcion;
                        }
                      
                        Fila.Cells[3].Value = Item.Seccion_ID;
                        Fila.Cells[4].Value = Item.Seccion.Descripcion;
                        Fila.Cells[5].Value = Item.Tiempo_Estimado.ToString();

                        dgvCircuitoProd.Rows.Add(Fila);
                    }
                    btnCargar.Text = "Editar circuito";
                    txtProducto.Text = Producto + " - " + CodigoProduto;
                }
            }
        }
        private void MostrarComboInsumoPorFormula()
        {
            using (var hb = new DBdatos())
            {
                if (cmbProducto.SelectedValue != null)
                {
                    var Consulta = (from FP in hb.Formula_Producto
                                    where FP.Producto_ID == cmbProducto.SelectedValue.ToString()
                                    select new
                                    {
                                        ID = FP.Insumo_ID,
                                        Tittle = FP.Productos_Insumos.Descripcion
                                    });

                    var Resultados = Consulta.ToList();

                    cmbInsumo.ValueMember = "ID";
                    cmbInsumo.DisplayMember = "Tittle";
                    cmbInsumo.DataSource = Resultados;
                }
            }
        }
        private void AgregarItemALista()
        {
            if (cmbSeccion.SelectedIndex != -1 && txtOrden.TextLength > 0 && cmbProducto.SelectedIndex != -1)
            {
                DataGridViewRow Fila = new DataGridViewRow();

                Fila.CreateCells(dgvCircuitoProd);
                Fila.Cells[0].Value = Convert.ToInt32(txtOrden.Text);
                if (SeccionFinal == "SI")
                {
                    Fila.Cells[1].Value = null;
                    Fila.Cells[2].Value = null;
                }
                Fila.Cells[3].Value = cmbSeccion.SelectedValue;
                Fila.Cells[4].Value = cmbSeccion.Text;
                Fila.Cells[5].Value = txtHora.Text + ":" + txtMinutos.Text;

                for (var i = 1; i <= dgvCircuitoProd.RowCount; i++)
                {
                    string CodInsumo = dgvCircuitoProd.Rows[i - 1].Cells[columnName: "colInsumoID"].Value.ToString();
                    string CodSeccion = dgvCircuitoProd.Rows[i - 1].Cells[columnName: "colSeccionID"].Value.ToString();
                    if (CodInsumo == cmbInsumo.SelectedValue.ToString() && CodSeccion == cmbSeccion.SelectedValue.ToString())
                    {
                        MessageBox.Show("El insumo " + cmbInsumo.Text + " " + "ya está definido para la sección " + cmbSeccion.Text, "Atención");
                        return;
                    }
                }
                dgvCircuitoProd.Rows.Add(Fila);
                //dgvCircuitoProd.Sort(colOrden, ListSortDirection.Ascending);
            }
            else
            {
                MessageBox.Show("Faltan datos", "Atención");
            }
        }
        private void CargarDatos()
        {
            if (dgvCircuitoProd.RowCount > 0)
            {
                using (var hb = new DBdatos())
                { 
                    var Consulta = (from FP in hb.Seccion_Circuito
                                where FP.Producto_ID == CodigoProduto
                                select FP).ToList();

                    hb.Seccion_Circuito.RemoveRange(Consulta);
                    hb.SaveChanges(); // ELIMINA TODOS LOS REGISTROS DE LA TABLA DEL PRODUCTO SELECCIONADO
                    
                    for (var i = 1; i <= dgvCircuitoProd.RowCount; i++)
                    {
                        string InsumoID = "";
                        if (SeccionFinal == "NO")
                        {
                            InsumoID = dgvCircuitoProd.Rows[i - 1].Cells[columnName: "colInsumoID"].Value.ToString();
                        }

                        int SecciónID = (int)dgvCircuitoProd.Rows[i - 1].Cells[columnName: "colSeccionID"].Value;
                        int Orden = Convert.ToInt32(dgvCircuitoProd.Rows[i - 1].Cells[columnName: "colOrden"].Value);
                        string Hora = dgvCircuitoProd.Rows[i - 1].Cells[columnName: "colTiempoEstimado"].Value.ToString();

                        DateTime Estimado = Convert.ToDateTime(Hora);
                        //   DateTime Estimado = Convert.ToDateTime(dgvCircuitoProd.Rows[i - 1].Cells[columnName: "colTiempoEstimado"].Value).TimeOfDay;

                        //var Consulta = (from FP in hb.Seccion_Circuito
                        //                where FP.Producto_ID == Codigo
                        //                    && FP.Insumo_ID == InsumoID
                        //                    && FP.Seccion_ID == SecciónID
                        //                select FP).FirstOrDefault();

                        //if (Consulta == null) // se usa este dato como referencia para saber que hay o no registro de seccion
                        //{
                        int ID;

                        var ConsultaID = (from FP in hb.Seccion_Circuito
                                          orderby FP.ID descending
                                          select FP).FirstOrDefault();

                        if (ConsultaID == null)
                            ID = 1;
                        else
                            ID = ConsultaID.ID + 1;

                        var z = new Seccion_Circuito();

                        z.ID = ID;
                        if(SeccionFinal == "SI")                       
                            z.Insumo_ID = null;                     
                        else
                            z.Insumo_ID = InsumoID;

                        z.Producto_ID = CodigoProduto;
                        
                        z.Seccion_ID = SecciónID;
                        z.Orden = Orden;
                        z.Tiempo_Estimado = Estimado.TimeOfDay;

                        hb.Seccion_Circuito.Add(z);
                        hb.SaveChanges();

                            //Consulta.Seccion_ID = SecciónID;
                            //Consulta.Orden = Orden;
                            //Consulta.Tiempo_Estimado = Estimado.TimeOfDay;

                            
                        //}
                    }
                    MessageBox.Show("Datos cargados correctamente", "Atención");
                    this.Hide();
                }
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //AgregarItemALista();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvCircuitoProd.RowCount > 0)
                dgvCircuitoProd.Rows.Remove(dgvCircuitoProd.CurrentRow);
        }
        private void MostrarEnColoresSecciones(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCircuitoProd.RowCount > 0)
            {
                using (var hb = new DBdatos())
                {
                    if (this.dgvCircuitoProd.Columns[e.ColumnIndex].Name == "colSeccion")
                    {
                      //  int ID = Convert.ToInt32(e.Value);

                        var Consulta = (from S in hb.Seccion
                                        where S.Descripcion == e.Value.ToString()
                                        select S).FirstOrDefault();

                        if (Consulta != null)
                        {
                            // dgvCircuitoProd.Columns[columnName : "colOrden"]
                            e.CellStyle.BackColor = Color.FromName(Consulta.Color);
                            e.CellStyle.SelectionBackColor = Color.FromName(Consulta.Color);

                            //foreach(var Col in dgvCircuitoProd.Columns)
                            //{
                            //    ((DataGridViewColumn)Col).DefaultCellStyle.SelectionBackColor = Color.FromName(Consulta.Color);
                            //}
                        }
                        
                    }
                }
            }
        }
        private void dgvCircuitoProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MostrarEnColoresSecciones(e);
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarComboInsumoPorFormula();
            if (cmbProducto.SelectedValue != null)
            {
                txtProducto.Text = cmbProducto.Text;
                if (CrearEditar == "1")
                    CodigoProduto = cmbProducto.SelectedValue.ToString();
            }
            else
            {
                txtProducto.Text = "";
            }
        }

        private void cmbProducto_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProducto.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbProducto, txtBuscarProducto, "PRO", true, "NO");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarProducto.Visible = false;
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void cmbSeccion_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Visible = true;
            txtBuscarProducto.Select();
        }

        private void txtBuscarInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarInsumo.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbInsumo, txtBuscarInsumo, "INS", true, "SI");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarInsumo.Visible = false;
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void cmbInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbInsumo, txtBuscarInsumo, "INS", false,"SI");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void cmbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbProducto, txtBuscarProducto, "PRO", false,"NO");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarInsumo_Click(object sender, EventArgs e)
        {
            txtBuscarInsumo.Visible = true;
            txtBuscarInsumo.Select();
        }

        private void cmbSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeccion.SelectedValue != null)
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from SEC in hb.Seccion
                                    where SEC.ID == (int)cmbSeccion.SelectedValue
                                    select SEC).FirstOrDefault();

                    if (Consulta.Seccion_Final == "SI")
                    {
                        SeccionFinal = "SI";
                        cmbInsumo.Enabled = false;
                        txtBuscarInsumo.Enabled = false;
                        btnBuscarInsumo.Enabled = false;
                    }
                }
            }
        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void pnlInferior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregarDGV_Click(object sender, EventArgs e)
        {
            AgregarItemALista();
        }

        private void txtBuscarProducto_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtOrden_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtHora_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtMinutos_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
