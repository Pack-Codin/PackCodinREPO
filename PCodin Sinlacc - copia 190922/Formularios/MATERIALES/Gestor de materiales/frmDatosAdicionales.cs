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
using PCodin_Sinlacc.Formularios;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Formularios.Productos___Insumos
{
    public partial class frmDatosAdicionales : Form
    {
        public string CrearEditar;
        public string ProductoID;
        public string InsPro;
        public int UsuarioID;
        public frmDatosAdicionales()
        {
            InitializeComponent();
        }

        private void frmDatosAdicionales_Load(object sender, EventArgs e)
        {
            InicializarForm();
            lblColor.ForeColor = Color.FromArgb(255,0,64,128);
            gbxClienteProveedor.Controls.Add(dgvProveedor);
            gbxClienteProveedor.Controls.Add(txtCosto);
        }
        public void CargarColoresEnCombo()
        {
            cmbColor.Items.Clear();
            string[] Colores = Enum.GetNames(typeof(System.Drawing.KnownColor));
            cmbColor.Items.AddRange(Colores);
        }
        private void InicializarForm()
        {
            using (var hb = new DBdatos())
            {
                var ConsultaUsuario = (from U in hb.Usuarios
                                       where U.ID == UsuarioID
                                       select U).FirstOrDefault();

                if (ConsultaUsuario.Monetizado == "NO")
                {
                    gbxClienteProveedor.Visible = false;
                    btnConfirmarReceta.Visible = false;
                }
                else
                {
                    gbxClienteProveedor.Visible = true;
                    btnConfirmarReceta.Visible = true;
                }

                clsCargarCombos.MostrarMedidas(cmbMedidaRef);
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
                clsCargarCombos.MostrarComboClientes(cmbProvCli, txtBuscarProvCli, false, "PRO", 0);
                clsCargarCombos.MostrarMoneda(cmbMoneda);

                cmbResponsable.SelectedIndex = -1;
                cmbProvCli.SelectedIndex = -1;
                cmbMoneda.SelectedIndex = -1;

                if (InsPro == "PRO")
                {
                    lblTituloProvClie.Text = "Precio por cliente";
                    lblProCli.Text = "Clientes";
                    lblCostoPrecio.Text = "Precio";
                    colProveedor.HeaderText = "Cliente";
                    colCosto.HeaderText = "Precio";
                    //colPrincipal.Visible = false;
                    //btnMarcarPrincipal.Enabled = false;
                    clsCargarCombos.MostrarComboClientes(cmbProvCli, txtBuscarProvCli, false, "CLI", 0);
                    cmbColor.Enabled = true;
                    CargarColoresEnCombo();
                    cmbColor.SelectedIndex = -1;
                    chkSubProducto.Enabled = false;
                }
                if (CrearEditar == "2") // si es para editar datos
                {
                    //using (var hb = new DBdatos())
                    //{
                    var Consulta_Editar = (from IP in hb.Productos_Insumos
                                           where IP.Codigo == ProductoID
                                           select IP);

                    var ConsultaProveedor = (from IPRO in hb.Insumo_Proveedor
                                             where IPRO.Insumo_ID == ProductoID
                                             select IPRO);

                    var ConsultaCliente = (from CLI in hb.Producto_Cliente
                                           where CLI.Producto_ID == ProductoID
                                           select CLI);

                    var Resultados = Consulta_Editar.FirstOrDefault();
                    var ResultadosIPRO = ConsultaProveedor.ToList();
                    var ResultadosPROCLI = ConsultaCliente.ToList();

                    if (Resultados.Cantidad_Ref != null)
                        txtCantidadRef.Text = Resultados.Cantidad_Ref.ToString();
                    else
                        txtCantidadRef.Text = "";

                    if (Resultados.Medida2 != null)
                    {
                        cmbMedidaRef.SelectedValue = Resultados.Medida2;
                        cmbMedidaRef.Text = Resultados.Medidas_Producto1.Descripcion;
                    }
                    else
                    {
                        cmbMedidaRef.SelectedIndex = -1;
                    }
                    if (Resultados.NotificaStockMin == "SI")
                        chkNotificaStockMin.Checked = true;
                    else
                        chkNotificaStockMin.Checked = false;

                    txtStockMin.Text = Resultados.StockMin.ToString();
                    txtMaxProduccion.Text = Resultados.MaxProducción.ToString();

                    if (Resultados.Subproducto == "SI")
                        chkSubProducto.Checked = true;
                    else
                        chkSubProducto.Checked = false;

                    if (Resultados.Responsable_ID != null)
                    {
                        cmbResponsable.SelectedValue = Resultados.Responsable_ID;
                        cmbResponsable.Text = Resultados.Empleados.Nombre;
                    }
                    else
                    {
                        cmbResponsable.SelectedIndex = -1;
                    }
                    if(Resultados.Pallet == "SI")
                    {
                        chkPallet.Checked = true;
                        cmbProductoPallet.SelectedValue = Resultados.ProductoPallet;
                        cmbProductoPallet.Text = Resultados.Productos_Insumos3.Descripcion;
                        txtProductoPalletCantidad.Text = Resultados.ProductoPalletCantidad.ToString();
                    }
                        
                    
                    if (Resultados.Color != null)
                    {
                        cmbColor.Text = Resultados.Color;
                        btnColorMuestra.BackColor = Color.FromName(Resultados.Color);
                    }
                    // txtCosto.Text = Resultados.Costo.ToString();

                    if (ResultadosIPRO.Count > 0 || ResultadosPROCLI.Count > 0)
                    {
                        if (InsPro == "INS")
                        {
                            foreach (var item in ResultadosIPRO)
                            {
                                DataGridViewRow Fila = new DataGridViewRow();

                                Fila.CreateCells(dgvProveedor);
                                Fila.Cells[0].Value = item.Proveedor_ID;
                                Fila.Cells[1].Value = item.Clientes.Descripcion;
                                Fila.Cells[2].Value = item.Costo;
                                Fila.Cells[3].Value = item.Moneda_ID;
                                Fila.Cells[4].Value = item.Proveedor_Principal;

                                dgvProveedor.Rows.Add(Fila);
                            }
                        }
                        else
                        {
                            foreach (var item in ResultadosPROCLI)
                            {
                                DataGridViewRow Fila = new DataGridViewRow();

                                Fila.CreateCells(dgvProveedor);
                                Fila.Cells[0].Value = item.Cliente_ID;
                                Fila.Cells[1].Value = item.Clientes.Descripcion;
                                Fila.Cells[2].Value = item.Valor;
                                Fila.Cells[3].Value = item.Moneda_ID;
                                Fila.Cells[4].Value = item.Principal;

                                dgvProveedor.Rows.Add(Fila);
                            }
                        }

                    }
                }
            }
        }
        private void txtBuscarResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarResponsable.Visible = false;
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, true);
                cmbResponsable.Visible = true;
                txtBuscarResponsable.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarResponsable.Visible = false;
                txtBuscarResponsable.Focus();
                e.Handled = true;
            }
        }
        private void MostrarColorDeMuestra()
        {
            if(cmbColor.SelectedIndex != -1)
            {
                btnColorMuestra.BackColor = Color.FromName(cmbColor.Text);
            }
        }
        public static void AgregarProveedorALista(DataGridView DGV, ComboBox ComboProveedor, TextBox TCosto , ComboBox ComboMoneda) // el ultimo string es para dar señal si esta en el modulo productos o pedidos
        {
            if (ComboProveedor.SelectedIndex != -1 && TCosto.TextLength > 0 && ComboMoneda.SelectedIndex != -1)
            {
                DataGridViewRow Fila = new DataGridViewRow();

                Fila.CreateCells(DGV);
                Fila.Cells[0].Value = ComboProveedor.SelectedValue.ToString();
                Fila.Cells[1].Value = ComboProveedor.Text;
                Fila.Cells[2].Value = Convert.ToDecimal(TCosto.Text);
                Fila.Cells[3].Value = ComboMoneda.SelectedValue.ToString();
                Fila.Cells[4].Value = "NO";

                for (var i = 1; i <= DGV.RowCount; i++)
                {
                    if (DGV.Rows[i - 1].Cells[0].Value.ToString() == ComboProveedor.SelectedValue.ToString())
                    {
                        MessageBox.Show("El sujeto " + ComboProveedor.Text + " " + "ya está en la lista", "Atención");
                        return;
                    }
                }

                DGV.Rows.Add(Fila);
            }

        }

        //else
        //{
        //    MessageBox.Show("Para agregar un insumo a la fórmula debe tener los campos Insumo, medida y cantidad completos");
        //}

        private void EliminarProveedorLista()
        {
            if (dgvProveedor.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Seguro que desea eliminar este item de la fórmula?", "Atención", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        dgvProveedor.Rows.Remove(dgvProveedor.CurrentRow);                                          
                    }
                }
            }
        }
        private void cmbResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
                txtBuscarResponsable.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarResponsable_Click(object sender, EventArgs e)
        {
            txtBuscarResponsable.Visible = true;
            cmbResponsable.Visible = false;
            txtBuscarResponsable.Select();
        }

        private void btnConfirmarReceta_Click(object sender, EventArgs e)
        {
            AgregarProveedorALista(dgvProveedor, cmbProvCli, txtCosto,cmbMoneda);
        }

        private void btnEliminarIns_Click(object sender, EventArgs e)
        {
            EliminarProveedorLista();
        }
        private void MostrarCosto()
        {
            if(dgvProveedor.RowCount > 0)
            {
                decimal Costo = (decimal)dgvProveedor.CurrentRow.Cells[2].Value;
                txtCosto.Text = Costo.ToString("N2");
            }
        }
        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarCosto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dgvProveedor.RowCount > 0)
            {
                for (var i = 1; i <= dgvProveedor.RowCount; i++)
                {
                    dgvProveedor.Rows[i - 1].Cells[columnName: "colPrincipal"].Value = "NO";
                }
                dgvProveedor.CurrentRow.Cells[columnName: "colPrincipal"].Value = "SI";
            }
        }

        private void txtBuscarProvCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProvCli.Visible = false;

                if (InsPro == "PRO")
                    clsCargarCombos.MostrarComboClientes(cmbProvCli, txtBuscarProvCli, true, "CLI", 0);
                else
                    clsCargarCombos.MostrarComboClientes(cmbProvCli, txtBuscarProvCli, true, "PRO", 0);

                txtBuscarProvCli.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarProvCli.Visible = false;
                txtBuscarProvCli.Focus();
                e.Handled = true;
            }


        }

        private void cmbProvCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                if (InsPro == "PRO")
                    clsCargarCombos.MostrarComboClientes(cmbProvCli, txtBuscarProvCli, false, "CLI", 0);
                else
                    clsCargarCombos.MostrarComboClientes(cmbProvCli, txtBuscarProvCli, false, "PRO", 0);

            }
        }

        private void btnBuscarProvCli_Click(object sender, EventArgs e)
        {
            txtBuscarProvCli.Visible = true;
            txtBuscarProvCli.Select();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                string Texto = cmbColor.Items[e.Index].ToString();
                Brush Borde = new SolidBrush(e.ForeColor);
                Color Color = Color.FromName(Texto);
                Brush pincel = new SolidBrush(Color);
                Pen Boli = new Pen(e.ForeColor);

                e.Graphics.DrawRectangle(Boli, new Rectangle ( e.Bounds.Left + 2, e.Bounds.Top + 2, 20, e.Bounds.Height - 4));
                e.Graphics.FillRectangle(pincel, new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 3, 20, e.Bounds.Height - 6));
                e.Graphics.DrawString(Texto,e.Font,Borde,e.Bounds.Left + 30, e.Bounds.Top + 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarColorDeMuestra();
        }
        private void txtCosto_Leave_1(object sender, EventArgs e)
        {
            //Reutilizables.ValidarSoloNumeros(txtCosto);
        }

        private void txtCosto_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCosto);
        }

        private void txtBuscarProductoPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProductoPallet.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbProductoPallet, txtBuscarProductoPallet, "PRO", true, "NO");
                txtBuscarProductoPallet.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarProductoPallet.Visible = false;
                txtBuscarProductoPallet.Focus();
                e.Handled = true;
            }
        }

        private void cmbProductoPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbProductoPallet, txtBuscarProductoPallet, "PRO", true, "NO");
                txtBuscarProductoPallet.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarIProductoPallet_Click(object sender, EventArgs e)
        {
            txtBuscarProductoPallet.Visible = true;
            txtBuscarProductoPallet.Select();
        }

        private void chkPallet_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkPallet, cmbProductoPallet, txtBuscarProductoPallet, btnBuscarIProductoPallet, "PRO", "NO");
        }

        private void txtProductoPalletCantidad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtProductoPalletCantidad);
        }
    }
}
