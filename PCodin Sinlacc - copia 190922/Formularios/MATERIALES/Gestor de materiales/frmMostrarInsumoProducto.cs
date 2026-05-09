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
using PCodin_Sinlacc.Formularios.Productos___Insumos;
using System.Data.Entity;
using PCodin_Sinlacc.Clases.UsuarioTema;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmMostrarInsumoProducto : Form
    {
        private string ProductoInsumo = ""; // sirve como pulso para determinar si se van a mostrar los insumos o productos
        public int UsuarioID;
        public frmMostrarInsumoProducto()
        {
            InitializeComponent();
        }

        private void frmCrearInsumoProducto_Load(object sender, EventArgs e)
        {
            Reutilizables.RenderizarForm(this);
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
        }
        private void MostrarInsumosProductos(string InsPro)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from IP in hb.Productos_Insumos
                                where IP.Ins_Prod == InsPro
                                orderby IP.Descripcion
                                select new
                                {
                                    IP.Codigo,
                                    IP.Descripcion,
                                    IP.Apodo,
                                    IP.Categoria_ID,
                                    Categoria = IP.Categorias_InsPro.Descripcion,
                                    IP.Estado
                                });

                if (cmbOrdenar.SelectedIndex == 1) // Codigo
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Codigo ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Codigo descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 2) // Descripcion
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Descripcion ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Descripcion descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 3) // Categoria
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Categoria ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Categoria descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 4) // Apodo
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Apodo ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Apodo descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 4) // Estado
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Estado ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Estado descending
                                    select C);
                }

                if (chkFiltraDescripion.Checked)
                    Consulta = (from C in Consulta
                                where C.Descripcion.StartsWith(txtFiltraDescripcion.Text)
                                    || C.Descripcion.Contains(txtFiltraDescripcion.Text)
                                select C);

                if (chkFiltraCodBarra.Checked)
                {
                    var ConsultaCodBarra = (from CB in hb.CODIGOBARRA
                                            where CB.CodigoBarra1 == txtCodBarra.Text
                                            select new
                                            {
                                                CB.Producto_ID
                                            }).ToList();

                    if(ConsultaCodBarra.Count > 0)
                    {
                        List<string>ListaAriculos = new List<string>();

                        foreach(var item in ConsultaCodBarra)
                        {
                            ListaAriculos.Add(item.Producto_ID);
                        }

                        Consulta = (from C in Consulta
                                    where ListaAriculos.Contains(C.Codigo)
                                    select C);
                    }

                   
                }           
                if (chkFiltraInsPro.Checked)
                    Consulta = (from C in Consulta
                                where C.Codigo == cmbFiltraInsPro.SelectedValue.ToString()
                                select C);

                if (chkFiltraCategoria.Checked)
                    Consulta = (from C in Consulta
                                where C.Categoria_ID == (int)cmbFiltraCategoria.SelectedValue
                                select C);

                if (chkFiltraEstado.Checked)
                    Consulta = (from C in Consulta
                                where C.Estado == cmbFiltraEstado.Text
                                select C);

                var Resultados = Consulta.Take(1000).ToList();

                colCodigo.DataPropertyName = "Codigo";
                colDescripcion.DataPropertyName = "Descripcion";
                colApodo.DataPropertyName = "Apodo";
                colCategoria.DataPropertyName = "Categoria";
                colCategoriaID.DataPropertyName = "Categoria_ID";
                colEstado.DataPropertyName = "Estado";
               
                dgvInsumos.AutoGenerateColumns = false;
                dgvInsumos.DataSource = Resultados;

               lblResultados.Text = Resultados.Count.ToString();
            }
        }
        private void EliminarInsPro()
        {
            int CantidadRegistros = 0;
            DialogResult R = MessageBox.Show("¿Seguro que desea eliminar este Insumo/Producto?", "Atención",MessageBoxButtons.YesNo);
            if(R == DialogResult.Yes && dgvInsumos.RowCount > 0)
            {
                using (var hb = new DBdatos())
                {
                    string ID = dgvInsumos.CurrentRow.Cells[0].Value.ToString();

                    var ConsultaExistenciaProdTerminda = (from EPT in hb.Existencia_ProductoTerminado
                                                          where EPT.Produto_ID == ID
                                                          select EPT);

                    var ResultadosExistenciaProdTerminda = ConsultaExistenciaProdTerminda.ToList();

                    if (ResultadosExistenciaProdTerminda.Count > 0)
                        CantidadRegistros = CantidadRegistros + 1;

                    var ConsultaPedidoCuerpo = (from PC in hb.Pedido_Cuerpo
                                                          where PC.Producto_ID == ID
                                                          select PC);

                    var ResultadosPedidoCuerpo = ConsultaPedidoCuerpo.ToList();

                    if (ResultadosPedidoCuerpo.Count > 0)
                        CantidadRegistros = CantidadRegistros + 1;

                    if (ProductoInsumo == "INS")
                    {
                        var ConsultaFormula = (from F in hb.Formula_Producto
                                               where F.Insumo_ID == ID
                                               select F);

                        var ResultadoFormula = ConsultaFormula.ToList();

                        if(ResultadoFormula.Count > 0)
                            CantidadRegistros = CantidadRegistros + 1;
                    }
                    if (ProductoInsumo == "PRO")
                    {
                        var ConsultaFormula = (from F in hb.Formula_Producto
                                               where F.Producto_ID == ID
                                               select F);

                        var ResultadoFormula = ConsultaFormula.ToList();

                        if (ResultadoFormula.Count > 0)
                            CantidadRegistros = CantidadRegistros + 1;
                    }
                    if (CantidadRegistros == 0)
                    {
                        var ConsultaProducto = (from PI in hb.Productos_Insumos
                                                    where PI.Codigo == ID
                                                    select PI);
                      
                        var ResultadosProducto = ConsultaProducto.FirstOrDefault();

                        if(ResultadosProducto != null)
                        {
                            hb.Productos_Insumos.Remove(ResultadosProducto);
                            hb.SaveChanges();
                            MessageBox.Show("Producto/Insumo eliminado correctamente", "Atención");
                            MostrarInsumosProductos("PRO");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto/insumo tiene afectados movimientos, por lo cual es imposible de eliminar. Solo puede darlo de baja", "Atención");
                    }
                }
            }
        }
        private void Eliminar()
        {
            try
            {
                DialogResult R = MessageBox.Show("¿Seguro que desea eliminar este Insumo/Producto?", "Atención", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes && dgvInsumos.RowCount > 0)
                {
                    using (var hb = new DBdatos())
                    {
                        string ID = dgvInsumos.CurrentRow.Cells[0].Value.ToString();

                        if (ProductoInsumo == "PRO")
                        {

                            var ConsultaExistenciaProdTerminda = (from EPT in hb.Existencia_ProductoTerminado
                                                                  where EPT.Produto_ID == ID
                                                                  select EPT);

                            var ResultadosExistenciaProdTerminda = ConsultaExistenciaProdTerminda.FirstOrDefault();

                            if (ResultadosExistenciaProdTerminda == null)
                            {
                                var Consulta1 = (from FP in hb.Formula_Producto
                                                 where FP.Producto_ID == ID
                                                 select FP).ToList();

                                var Consulta2 = (from PC in hb.Producto_Cliente
                                                 where PC.Producto_ID == ID
                                                 select PC).ToList();

                                var Consulta3 = (from PI in hb.Productos_Insumos
                                                 where PI.Codigo == ID
                                                 select PI).FirstOrDefault();

                                var Consulta4 = (from CIR in hb.Seccion_Circuito
                                                 where CIR.Producto_ID == ID
                                                 select CIR).ToList();

                                var Consulta5 = (from LP in hb.LISTAPRECIOCUERPO
                                                 where LP.Articulo_ID == ID
                                                 select LP).ToList();

                                var Consulta6 = (from CB in hb.CODIGOBARRA
                                                 where CB.Producto_ID == ID
                                                 select CB).ToList();

                                if (Consulta1.Count > 0)
                                    hb.Formula_Producto.RemoveRange(Consulta1);
                                if (Consulta2.Count > 0)
                                    hb.Producto_Cliente.RemoveRange(Consulta2);
                                if (Consulta4.Count > 0)
                                    hb.Seccion_Circuito.RemoveRange(Consulta4);
                                if (Consulta5.Count > 0)
                                    hb.LISTAPRECIOCUERPO.RemoveRange(Consulta5);
                                if (Consulta6.Count > 0)
                                    hb.CODIGOBARRA.RemoveRange(Consulta6);



                                hb.Productos_Insumos.Remove(Consulta3);

                                hb.SaveChanges();
                                MessageBox.Show("Datos eliminados correctamente", "Atención");
                                MostrarInsumosProductos(ProductoInsumo);
                            }
                            else
                            {
                                MessageBox.Show("El producto/insumo tiene afectados movimientos, por lo cual es imposible de eliminar. Solo puede darlo de baja", "Atención");
                            }
                        }
                        if (ProductoInsumo == "INS")
                        {
                            var ConsultaExistencia = (from EI in hb.Existencia_Insumos
                                                      where EI.Insumo_ID == ID
                                                      select EI).FirstOrDefault();

                            var ConsultaFormula = (from FP in hb.Formula_Producto
                                                   where FP.Insumo_ID == ID
                                                   select FP).FirstOrDefault();

                            if (ConsultaExistencia == null && ConsultaFormula == null)
                            {
                                var Consulta1 = (from PINS in hb.Insumo_Proveedor
                                                 where PINS.Insumo_ID == ID
                                                 select PINS).ToList();

                                var Consulta2 = (from INS in hb.Productos_Insumos
                                                 where INS.Codigo == ID
                                                 select INS).FirstOrDefault();

                                if (Consulta1.Count > 0)
                                    hb.Insumo_Proveedor.RemoveRange(Consulta1);

                                hb.Productos_Insumos.Remove(Consulta2);

                                hb.SaveChanges();
                                MessageBox.Show("Datos eliminados correctamente", "Atención");
                                MostrarInsumosProductos(ProductoInsumo);
                            }
                            else
                            {
                                if (ConsultaExistencia != null)
                                {
                                    MessageBox.Show("El insumo tiene afectados movimientos, por lo cual es imposible de eliminar. Solo puede darlo de baja", "Atención");
                                }
                                if (ConsultaFormula != null)
                                {
                                    MessageBox.Show("El insumo está afectado a la formula de uno o mas productos, por lo cual es imposible de eliminar. Solo puede darlo de baja", "Atención");
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
            
        }
        private void btnEliminarInsumo_Click(object sender, EventArgs e)
        {

        }
        //private frmCrearInsumoProducto f = new frmCrearInsumoProducto();
        //clsOcultarCerrarForm Form = new clsOcultarCerrarForm();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ProductoInsumo != "")
                AbrirFormCrearEditar("1");
            else
                MessageBox.Show("Seleccione primero PRODUCTO o INSUMO", "Atención");
        }
        private void AbrirFormCrearEditar(string CrearEditar)
        {
            //if (dgvInsumos.RowCount > 0)
            //{
                var f = new frmInicioProductoInsumo();
            //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmInicioProductoInsumo_FormClosed);
            f.UsuarioID = UsuarioID;
                f.CrearEditar = CrearEditar;
                if (CrearEditar == "2")
                    f.ProductoID = dgvInsumos.CurrentRow.Cells[0].Value.ToString();
                AddOwnedForm(f);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                this.Controls.Add(f);
                this.Tag = f;
                f.InsPro = ProductoInsumo;
                f.BringToFront();
                f.Show();
            //}
        }
        
        private void frmCrearInsumoProducto_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
            Reutilizables.ReubicarFiltros(gbxFiltros, pnlInferior, btnMostrarfiltros);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirFormCrearEditar("2");
        }
        private void MostrarOcultarInsumosProductos(string Pulso)
        {
            if(Pulso == "INS")
            {
                btnMostrarInsumos.BackColor = Color.DarkOrange;
                btnMostrarProductos.BackColor = Color.White;
                ProductoInsumo = "INS"; 
                MostrarInsumosProductos("INS");
            }
            if(Pulso == "PRO")
            {
                btnMostrarInsumos.BackColor = Color.White;
                btnMostrarProductos.BackColor = Color.DarkOrange;
                ProductoInsumo = "PRO";
                MostrarInsumosProductos("PRO");
            }
        }
        private void btnMostrarInsumos_Click(object sender, EventArgs e)
        {
            MostrarOcultarInsumosProductos("INS");
            btnActualizar.Enabled = true;
        }

        private void btnMostrarProductos_Click(object sender, EventArgs e)
        {
            MostrarOcultarInsumosProductos("PRO");
            btnActualizar.Enabled = true;
        }

        private void cmbFiltraCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarCategorias(cmbFiltraCategoria, txtBuscaCategoria, false);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtBuscaCategoria.Visible = true;
            txtBuscaCategoria.Select();
        }

        private void txtBuscaCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaCategoria.Visible = false;
                clsCargarCombos.MostrarCategorias(cmbFiltraCategoria, txtBuscaCategoria, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaCategoria.Visible = false;
                //  clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, false);
            }
        }
        private void chkFiltraDescripion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraDescripcion, chkFiltraDescripion);
        }

        private void chkFiltraApodo_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chkFiltraInsPro_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsProConCheck(chkFiltraInsPro, cmbFiltraInsPro, txtBuscaInsPro, chkMuestraInsProActInac, btnBuscarInsPro);
        }
        
        private void chkFiltraCategoria_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboCategorias(chkFiltraCategoria, cmbFiltraCategoria, txtBuscaCategoria, btnBuscarCategoria);
        }

        private void cmbFiltraInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsumosProductos(cmbFiltraInsPro, txtBuscaInsPro, false , chkMuestraInsProActInac);
            }
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscaInsPro.Visible = false;
                clsCargarCombos.MostrarComboInsumosProductos(cmbFiltraInsPro, txtBuscaInsPro, true , chkMuestraInsProActInac);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscaInsPro.Visible = false;
            }
        }

        private void btnBuscarInsPro_Click(object sender, EventArgs e)
        {
            txtBuscaInsPro.Visible = true;
            txtBuscaInsPro.Select();
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbFiltraEstado);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ProductoInsumo == "INS")
                MostrarInsumosProductos("INS");
            if(ProductoInsumo == "PRO")
                MostrarInsumosProductos("PRO");
        }

        private void gbxFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();

           // EliminarInsPro();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(ProductoInsumo == "INS")
            {
                MostrarInsumosProductos("INS");
            }
            else
            {
                MostrarInsumosProductos("PRO");
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvInsumos);
        }

        private void dgvInsumos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirFormCrearEditar("2");
        }

        private void btnExcel_Click_1(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvInsumos);
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            if (ProductoInsumo == "INS")
                MostrarInsumosProductos("INS");
            if (ProductoInsumo == "PRO")
                MostrarInsumosProductos("PRO");
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            if (ProductoInsumo == "INS")
                MostrarInsumosProductos("INS");
            if (ProductoInsumo == "PRO")
                MostrarInsumosProductos("PRO");
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvInsumos.RowCount > 0)
            {
                if (ProductoInsumo == "INS")
                    MostrarInsumosProductos("INS");
                if (ProductoInsumo == "PRO")
                    MostrarInsumosProductos("PRO");
            }
        }

        private void chkFiltraCodBarra_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtCodBarra,chkFiltraCodBarra);
        }

        private void txtBuscaInsPro_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscaCategoria_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtCodBarra_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraDescripcion_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void pnlFiltroGeneral_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
