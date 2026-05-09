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

namespace PCodin_Sinlacc.Formularios.Productos___Insumos
{
    public partial class frmAgregarCompraInsumo : Form
    {
        public string CrearEditarCopiar;
        public long ID;
        
        public frmAgregarCompraInsumo()
        {
            InitializeComponent();
        }

        private void frmAgregarCompraInsumo_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsCargarCombos.MostrarCombomMovProduccion(cmbMovimiento, "INS");
            //clsCargarCombos.MostrarComboInsProSinCheck2(cmbInsumo, cmbMedida, txtBuscaInsPro, "INS", false);
            clsCargarCombos.MostrarComboInsProConMedida2(cmbInsumo, cmbMedida, txtBuscaInsPro, "INS", false);
            clsCargarCombos.MostrarComboInsProConMedida(comboBox1, cmbMedida, txtBuscaInsPro, "INS", false);
            //clsCargarCombos.MostrarComboClientes(cmbProveedor, txtBuscaProveedor, false, "PRO");
            clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
            

            if(CrearEditarCopiar == "1")
            {
                cmbInsumo.SelectedIndex = -1;
                cmbProveedor.SelectedIndex = -1;
                cmbMovimiento.SelectedIndex = -1;
                cmbResponsable.SelectedIndex = -1;

                txtCantidad.Text = "0,00";
                txtEstado.Text = "";
                txtEstado.ForeColor = Color.Red;
                txtCantidadUtilizada.Text = "0";
                btnCargar.Text = "Cargar insumo";
                btnInvalidar.Enabled = false;
            }
            if (CrearEditarCopiar == "2" || CrearEditarCopiar == "3")
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from EI in hb.Existencia_Insumos
                                    where EI.ID == ID
                                    select EI);

                    var Resultados = Consulta.FirstOrDefault();

                    if(Resultados != null)
                    {
                        cmbMovimiento.SelectedValue = Resultados.Movimiento_ID;
                        cmbMovimiento.Text = Resultados.Movimientos_Produccion.Descripcion;
                        dtpFecha.Value = Resultados.Fecha.Date;
                        cmbInsumo.SelectedValue = Resultados.Insumo_ID;
                        cmbInsumo.Text = Resultados.Productos_Insumos.Descripcion;                        
                        cmbProveedor.SelectedValue = Resultados.Proveedor_ID;
                        cmbProveedor.Text = Resultados.Clientes.Descripcion;
                        txtCantidad.Text = Resultados.Cantidad.ToString("N2");

                        if (CrearEditarCopiar == "2")
                        {
                            txtCantidadUtilizada.Text = Resultados.Cantidad_Utilizada.ToString("N2");
                            cmbMovimiento.Enabled = false;
                            if (Resultados.Estado_ID != "AN")
                            {
                                btnInvalidar.Enabled = true;                               
                            }
                            else
                            {
                                btnInvalidar.Enabled = false;
                                btnCargar.Enabled = false;
                            }
                        }
                        if (CrearEditarCopiar == "3")
                        {
                            txtCantidadUtilizada.Text = "0,00";
                            cmbMovimiento.Enabled = true;
                            btnInvalidar.Enabled = false;
                        }
                        cmbMedida.SelectedValue = Resultados.Medida_ID;
                        cmbMedida.Text = Resultados.Medidas_Producto.Descripcion;
                        cmbResponsable.SelectedValue = Resultados.Responsable_ID;
                        cmbResponsable.Text = Resultados.Empleados.Nombre;
                        txtObservaciones.Text = Resultados.Observaciones;

                        if (CrearEditarCopiar == "2")
                        {
                            if (Resultados.Estado_ID == "FI")
                            {
                                txtEstado.Text = Resultados.Estado_Ord_Carga1.Descripcion;
                                txtEstado.ForeColor = Color.Green;
                            }
                            if (Resultados.Estado_ID == "AN")
                            {
                                txtEstado.Text = Resultados.Estado_Ord_Carga1.Descripcion;
                                txtEstado.ForeColor = Color.Red;
                            }
                            //if (Resultados.Estado_ID == "AN")
                            //{
                            //    txtEstado.Text = Resultados.Estado_Ord_Carga1.Descripcion;
                            //    txtEstado.ForeColor = Color.DarkRed;
                            //}
                        }
                        if (CrearEditarCopiar == "3")
                        {
                            txtEstado.Text = "";
                            txtEstado.ForeColor = Color.Red;
                        }
                    }
                    if (CrearEditarCopiar == "2")
                        btnCargar.Text = "Editar insumo";
                }
            }
        }
        private void OnOffbtnCargar()
        {
            //decimal Cantidad = 0;

            //if (txtCantidad.TextLength > 0 )
            //{    
            //    Cantidad = Convert.ToDecimal(txtCantidad.Text);
            //}

            //if(cmbInsumo.SelectedIndex != -1 &&
            //    cmbProveedor.SelectedIndex != -1 &&
            //    txtCantidad.TextLength > 0 &&
            //    Cantidad > 0 &&
            //    cmbResponsable.SelectedIndex != -1 &&
            //    cmbMedida.SelectedIndex != -1 &&
            //    cmbMovimiento.SelectedIndex != -1)
            //{
            //    btnCargar.Enabled = true;
            //}
            //else
            //{
            //    btnCargar.Enabled = false;
            //}
        }
        private void CargarDatos()
        {
            using (var hb = new DBdatos())
            {
                var Z = new Existencia_Insumos();

                Z.Fecha = dtpFecha.Value.Date;
                Z.Movimiento_ID = cmbMovimiento.SelectedValue.ToString();
                Z.Insumo_ID = cmbInsumo.SelectedValue.ToString();
                Z.Proveedor_ID = (int?)cmbProveedor.SelectedValue;

                if (cmbMovimiento.SelectedValue.ToString() == "AJUNEINS")
                    Z.Cantidad = Convert.ToDecimal(txtCantidad.Text) * -1;
                else
                    Z.Cantidad = Convert.ToDecimal(txtCantidad.Text);

                Z.Cantidad_Utilizada = 0;
                //Z.Medida_ID = (int)cmbMedida.SelectedValue; Esto sacarlo
                Z.Responsable_ID = (int)cmbResponsable.SelectedValue;
                Z.Observaciones = txtObservaciones.Text;
                Z.Estado_ID = "FI";

                hb.Existencia_Insumos.Add(Z);
                hb.SaveChanges();
                MessageBox.Show("Datos cargados correctamente", "Atención");
                this.Hide();
            }
        }
        private void EditarDatos()
        {
            using (var hb = new DBdatos())
            {
                decimal NuevaCantidad = 0;

                if (txtCantidad.TextLength > 0)
                    NuevaCantidad = Convert.ToDecimal(txtCantidad.Text);

                var Consulta = (from EI in hb.Existencia_Insumos
                                where EI.ID == ID
                                select EI);

                var Resultados = Consulta.FirstOrDefault();

                if (NuevaCantidad >= Resultados.Cantidad_Utilizada)
                {
                    if (Resultados != null)
                    {                       
                        Resultados.Fecha = dtpFecha.Value;
                        //Resultados.Movimiento_ID = cmbMovimiento.SelectedValue.ToString();
                        Resultados.Insumo_ID = cmbInsumo.SelectedValue.ToString();
                        Resultados.Proveedor_ID = (int?)cmbProveedor.SelectedValue;
                        Resultados.Cantidad = NuevaCantidad;
                        Resultados.Medida_ID = (int)cmbMedida.SelectedValue;
                        Resultados.Responsable_ID = (int)cmbResponsable.SelectedValue;
                        Resultados.Observaciones = txtObservaciones.Text;

                        //if (NuevaCantidad == Resultados.Cantidad_Utilizada)
                        //    Resultados.Estado_ID = "COM";
                        //else
                        //    Resultados.Estado_ID = "PEN";
                    }
                }
                else
                {
                    MessageBox.Show("La cantidad no puede ser menor a la cantidad utilizada");
                    return;
                }
                hb.SaveChanges();
                MessageBox.Show("Datos modificados correctamente", "Atención");
                this.Hide();
            }
        }
        private void SeleccionarProveedorAuto()
        {
            if (cmbInsumo.SelectedIndex != -1)
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from PROV in hb.Insumo_Proveedor
                                    where PROV.Insumo_ID == cmbInsumo.SelectedValue.ToString()
                                    orderby PROV.Clientes.Descripcion
                                    select new
                                    {
                                        ID = PROV.Clientes.ID,
                                        Descripcion = PROV.Clientes.Descripcion
                                    });

                    var Resultados = Consulta.ToList();

                    if(Resultados != null)
                    {
                        cmbProveedor.ValueMember = "ID";
                        cmbProveedor.DisplayMember = "Descripcion";
                        cmbProveedor.DataSource = Resultados;
                    }
                    
                }
            }
        }
        private void AnularMovimiento()
        {
            DialogResult R = MessageBox.Show("¿Está seguro de anular este movimiento", "Atención", MessageBoxButtons.YesNo);
            if (R == DialogResult.Yes)
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaEINS = (from EINS in hb.Existencia_Insumos
                                       where EINS.ID == ID
                                       select EINS);

                    var ConsultaEIP = (from EIP in hb.ExistenciaProducto_ExistenciaInsumo
                                    where EIP.ExistenciaInsumo_ID == ID
                                    select EIP);

                    var ResultadosEINS = ConsultaEINS.FirstOrDefault();
                    var ResultadosEIP = ConsultaEIP.FirstOrDefault();

                    if (ResultadosEIP == null)
                    {
                        ResultadosEINS.Estado_ID = "AN";
                        MessageBox.Show("Movimiento anulado correctamente", "Atención");
                        hb.SaveChanges();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("El movimiento está afectado por 1 o más 'Movimientos de producción'", "Atención");
                        return;
                    }
                  
                }
            }
        }
        private void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
        }

        private void cmbInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          //  Reutilizables.MostrarProveedorAutomaticamente(cmbInsumo, cmbProveedor);
            SeleccionarProveedorAuto();
           // SeleccionarProveedorAuto();
           // OnOffbtnCargar();
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbInsumo, txtBuscaInsPro, "INS", true, "NO");
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

        private void cmbInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbInsumo, txtBuscaInsPro, "INS", false, "NO");
                txtBuscaInsPro.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }

        private void txtBuscaProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaProveedor.Visible = false;
                clsCargarCombos.MostrarComboClientes(cmbProveedor, txtBuscaProveedor, true,"PRO", 0);
                txtBuscaProveedor.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaProveedor.Visible = false;
                txtBuscaProveedor.Focus();
                e.Handled = true;
            }
        }

        private void cmbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboClientes(cmbProveedor, txtBuscaProveedor, false, "PRO", 0);
                txtBuscaProveedor.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscaProveedor_Click(object sender, EventArgs e)
        {
            txtBuscaProveedor.Visible = true;
            txtBuscaProveedor.Select();
        }

        private void txtBuscarResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarResponsable.Visible = false;
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, true);
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

        private void cmbResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboEmpleados(cmbResponsable, txtBuscarResponsable, false);
                txtBuscarResponsable.Focus();
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
            OnOffbtnCargar();
        }

        private void cmbResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void txtObservaciones_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (CrearEditarCopiar != "2")
                CargarDatos();
            else
                EditarDatos();
            
        }

        private void cmbMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionarProveedorAuto();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularMovimiento();
        }

        private void cmbMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void txtCantidad_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
