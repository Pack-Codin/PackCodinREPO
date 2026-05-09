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

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmCrearInsumoProducto : Form
    {
        public int CerrarOcultarForm;
        public string CrearEditar;
        public string ProductoID;
        public string IDEmiCategoriaEditarEliminar;
        public string InsPro;
        public string CodigoBarraOriginal = "";
        public List<long> IDCodBarraEliminar = new List<long>();

        public frmCrearInsumoProducto()
        {
            InitializeComponent();
        }
        
        private void frmCrearInsumoProducto_Load(object sender, EventArgs e)
        {           
            
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, false);
            clsCargarCombos.MostrarMedidas(cmbMedida);
            cmbMedida.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;

            if (clsVariablesGenerales.Aplicacion == "PACK-SHOP")
            {
                picFormulaOferta.Image = Image.FromFile(@"C:\Program Files (x86)\Pack-Codin\Images\Oferta.png");
                lblFormulaOferta.Text = "Oferta";
                lblArticuloInsumo.Text = "Articulo";
            }
                

            if (InsPro == "PRO")
                rdbProductoFinal.Checked = true;
            if (InsPro == "INS")
                rdbInsumo.Checked = true;

            if (CrearEditar == "2") // si es para editar datos
            {
                using (var hb = new DBdatos())
                {
                    var Consulta_Editar = (from IP in hb.Productos_Insumos
                                           where IP.Codigo == ProductoID
                                           select IP);

                    var ConsultaCodigoBarra = (from CB in hb.CODIGOBARRA
                                               where CB.Producto_ID == ProductoID
                                               orderby CB.ID descending
                                               select CB).ToList();

                    var Resultados = Consulta_Editar.FirstOrDefault();

                    if (Resultados != null)
                    {
                        txtCodigo.Text = Resultados.Codigo.ToString();

                        if (Resultados.Ins_Prod == "INS")
                            rdbInsumo.Checked = true;
                        else
                            rdbProductoFinal.Checked = true;

                        txtDescripcion.Text = Resultados.Descripcion.ToString();

                        if (Resultados.Apodo != null)
                            txtApodo.Text = Resultados.Apodo;
                        else
                            txtApodo.Text = "";

                        cmbCategoria.SelectedValue = Resultados.Categoria_ID;
                        cmbCategoria.Text = Resultados.Categorias_InsPro.Descripcion;
                        cmbEstado.Text = Resultados.Estado;
                        cmbMedida.SelectedValue = Resultados.Medida;
                        cmbMedida.Text = Resultados.Medidas_Producto.Descripcion;

                        foreach(var CB in ConsultaCodigoBarra)
                        {
                           dgvCodBarra.Rows.Add(CB.ID,CB.CodigoBarra1,CB.Estado);
                        }


                        //txtCodigoBarra.Text = ConsultaCodigoBarra.CodigoBarra1;
                        //CodigoBarraOriginal = ConsultaCodigoBarra.CodigoBarra1;

                        //if (Resultados.Cantidad_Ref != null)
                        //    txtCantidadRef.Text = Resultados.Cantidad_Ref.ToString();
                        //else
                        //    txtCantidadRef.Text = "";

                        //if(Resultados.Medida2 != null)
                        //{
                        //    cmbMedidaRef.SelectedValue = Resultados.Medida2;
                        //    cmbMedidaRef.Text = Resultados.Medidas_Producto1.Descripcion;
                        //}
                        //else
                        //{
                        //    cmbMedidaRef.SelectedIndex = -1;
                        //}
                        //txtStockMin.Text = Resultados.StockMin.ToString();
                        //txtMaxProduccion.Text = Resultados.MaxProducción.ToString();
                        //if (Resultados.Responsable_ID != null)
                        //{
                        //    cmbResponsable.SelectedValue = Resultados.Responsable_ID;
                        //    cmbResponsable.Text = Resultados.Empleados.Nombre;
                        //}
                        //else
                        //{
                        //    cmbResponsable.SelectedIndex = -1;
                        //}

                        if (rdbProductoFinal.Checked)
                        {

                            var ConsultaFormula = (from F in hb.Formula_Producto
                                                   where F.Producto_ID == ProductoID
                                                   select F);

                            var ResultadosFormula = ConsultaFormula.ToList();

                            foreach (var item in ResultadosFormula)
                            {
                                DataGridViewRow Fila = new DataGridViewRow();

                                Fila.CreateCells(dgvReceta);
                                Fila.Cells[0].Value = item.ID;
                                Fila.Cells[1].Value = item.Insumo_ID;
                                Fila.Cells[2].Value = item.Productos_Insumos.Descripcion;
                                Fila.Cells[3].Value = item.Productos_Insumos.Medidas_Producto.Descripcion;
                                Fila.Cells[4].Value = item.Cantidad;
                                Fila.Cells[5].Value = item.Medida;
                               
                                dgvReceta.Rows.Add(Fila);
                            }
                        }
                    }
                }
                btnCargar.Focus();
                btnCargar.Select();
            }
        }
        private void EditarProductoInsumo()
        {
            if(CrearEditar == "2")
            {
                using (var hb = new DBdatos())
                {
                    var Consulta_Editar = (from IP in hb.Productos_Insumos
                                       where IP.Codigo == ProductoID
                                       select IP);

                    var Consulta_Descrip = (from IP in hb.Productos_Insumos
                                            where IP.Codigo == ProductoID || IP.Descripcion == txtDescripcion.Text
                                            select IP);

                    var ResultadoEditar = Consulta_Editar.FirstOrDefault();
                    var Validacion_Descrip = Consulta_Descrip.FirstOrDefault();

                    if (Validacion_Descrip == null || (ProductoID == txtCodigo.Text)) // si no hay ninguna descripcion igual
                    {
                        ResultadoEditar.Codigo = txtCodigo.Text;
                        ResultadoEditar.Descripcion = txtDescripcion.Text;
                        ResultadoEditar.Apodo = txtApodo.Text;
                        ResultadoEditar.Categoria_ID = (int)cmbCategoria.SelectedValue;
                        ResultadoEditar.Estado = cmbEstado.Text;
                        ResultadoEditar.Medida = (int)cmbMedida.SelectedValue;
                        //ResultadoEditar.Medida2 = (int)cmbMedidaRef.SelectedValue;
                        //ResultadoEditar.Responsable_ID = (int?)cmbResponsable.SelectedValue;
                        //ResultadoEditar.Cantidad_Ref = Convert.ToDecimal(txtCantidadRef.Text);

                        //if (txtStockMin.TextLength > 0)
                        //    ResultadoEditar.StockMin = Convert.ToDecimal(txtStockMin.Text);
                        //else
                        //    ResultadoEditar.StockMin = 0;

                        //if (txtMaxProduccion.TextLength > 0)
                        //    ResultadoEditar.MaxProducción = Convert.ToDecimal(txtMaxProduccion.Text);
                        //else
                        //    ResultadoEditar.MaxProducción = 0;

                       
                        
                        if (rdbInsumo.Checked)
                        {
                            hb.SaveChanges();
                            MessageBox.Show("Datos modificados correctamente", "Atención");
                        }
                    }
                    else 
                    if (Validacion_Descrip.Descripcion == txtDescripcion.Text
                            && (Validacion_Descrip.Codigo == txtCodigo.Text && txtCodigo.Text == ProductoID)
                            && (ResultadoEditar.Estado != cmbEstado.Text
                            || ResultadoEditar.Categorias_InsPro != cmbCategoria.SelectedValue
                            || ResultadoEditar.Apodo != txtApodo.Text))
                            //|| ResultadoEditar.StockMin.ToString() != txtStockMin.Text
                            //|| ResultadoEditar.MaxProducción.ToString() != txtMaxProduccion.Text
                            //|| ResultadoEditar.Medida != (int)cmbMedida.SelectedValue))  // Esto es para cambiar solamente el estado
                    {
                        ResultadoEditar.Apodo = txtApodo.Text;
                        ResultadoEditar.Categoria_ID = (int)cmbCategoria.SelectedValue;
                        ResultadoEditar.Estado = cmbEstado.Text;
                        ResultadoEditar.Medida = (int)cmbMedida.SelectedValue;
                        //ResultadoEditar.Medida2 = (int)cmbMedidaRef.SelectedValue;
                        //ResultadoEditar.Cantidad_Ref = Convert.ToDecimal(txtCantidadRef.Text);

                        //if (txtStockMin.TextLength > 0)
                        //    ResultadoEditar.StockMin = Convert.ToDecimal(txtStockMin.Text);
                        //else
                        //    ResultadoEditar.StockMin = 0;

                        //if (txtMaxProduccion.TextLength > 0)
                        //    ResultadoEditar.MaxProducción = Convert.ToDecimal(txtMaxProduccion.Text);
                        //else
                        //    ResultadoEditar.MaxProducción = 0;

                        if (rdbInsumo.Checked)
                        {
                            hb.SaveChanges();
                            MessageBox.Show("Datos modificados correctamente", "Atención");
                        }
                    }
                    else
                    {
                        if (rdbInsumo.Checked) // para que cambie el mensaje segun si es insumo o producto
                        {
                            if (txtDescripcion.Text == Validacion_Descrip.Descripcion)
                                MessageBox.Show("Ya existe un insumo con la descripción " + " " + txtDescripcion.Text, "Atención");
                            if (txtCodigo.Text == Validacion_Descrip.Codigo)
                                MessageBox.Show("Ya existe un insumo con el código " + " " + txtCodigo.Text, "Atención");
                        }
                        else
                        {
                            if (txtDescripcion.Text == Validacion_Descrip.Descripcion)
                                MessageBox.Show("Ya existe un producto con la descripción " + " " + txtDescripcion.Text, "Atención");
                            if (txtCodigo.Text == Validacion_Descrip.Codigo)
                                MessageBox.Show("Ya existe un producto con el código " + " " + txtCodigo.Text, "Atención");
                        }
                    }
                    if(rdbProductoFinal.Checked) // Aqui se cargan solamente los datos de la formula
                    {
                        
                        for (int c = 1; c <= dgvReceta.Rows.Count; c++)
                        {
                            string InsumoID = dgvReceta.Rows[c - 1].Cells[1].Value.ToString();
                            string Medida = dgvReceta.Rows[c - 1].Cells[3].Value.ToString();
                            decimal Cantidad = (decimal)dgvReceta.Rows[c - 1].Cells[4].Value;

                            var Consulta = (from FP in hb.Formula_Producto
                                            where FP.Producto_ID == txtCodigo.Text
                                                && FP.Insumo_ID == InsumoID
                                                && FP.Medidas_Producto.Descripcion == Medida
                                                && FP.Cantidad == Cantidad
                                            select FP); 

                            var Validacion = Consulta.FirstOrDefault(); // Validación para no cargar renglon con mismo formula

                            if (Validacion == null) // si no hay ninguno igual
                            {                               
                                var z = new Formula_Producto();

                                z.Producto_ID = txtCodigo.Text;
                                z.Insumo_ID = dgvReceta.Rows[c - 1].Cells[1].Value.ToString();
                                z.Cantidad = Convert.ToDecimal(dgvReceta.Rows[c - 1].Cells[4].Value);
                                z.Medida = (int)cmbMedidaFormula.SelectedValue;

                                hb.Formula_Producto.Add(z);                              
                            }                            
                        }
                        hb.SaveChanges();
                        MessageBox.Show("Datos modificados correctamente", "Atención");
                        this.Hide();
                    }
                    
                }                   
            }
        }
        private void EliminarInsumoDeFormula()
        {
            DialogResult R = MessageBox.Show("¿Seguro que desea eliminar este item de la fórmula?","Atención",MessageBoxButtons.YesNo);
            if(R == DialogResult.Yes)
            {
                if (dgvReceta.RowCount > 0)
                {
                    using (var hb = new DBdatos())
                    {
                        long ID = (long)dgvReceta.CurrentRow.Cells[0].Value; // Id de la formula a eliminar

                        var Consulta = (from IP in hb.Formula_Producto
                                        where IP.ID == ID
                                        select IP);

                        var Resultado = Consulta.FirstOrDefault();

                        if (Resultado != null)
                        {
                            hb.Formula_Producto.Remove(Resultado);
                            dgvReceta.Rows.Remove(dgvReceta.CurrentRow);
                            hb.SaveChanges();
                            MessageBox.Show("El item fue eliminado correctamente","Atención");
                        }
                    }
                }
            }
            
        }
        private void CargarInsumoProducto()
        {
            using (var hb = new DBdatos())
            {
                string Codigo = txtCodigo.Text;

                var Consulta = (from T in hb.Productos_Insumos
                                where T.Codigo == Codigo
                                || T.Descripcion == txtDescripcion.Text
                                select T); // valida que no haya un insumo o producto con mismo codigo o descrip

                var Resultado = Consulta.FirstOrDefault();

                if (rdbInsumo.Checked)  // agrega insumo
                {                  
                    if (Resultado != null)
                    {
                        if (Resultado.Codigo == Codigo) // si hay uno con codigo igual no crea nada y avisa
                        {
                            MessageBox.Show("Ya existe un insumo con el código" + " " + " " + Codigo, "Error");
                        }
                        if (Resultado.Descripcion == txtDescripcion.Text) // si hay uno con descrip igual no crea nada y avisa
                        {
                            MessageBox.Show("Ya existe un insumo con la descripción" + " " + " " + txtDescripcion.Text, "Error");
                        }
                    }
                    else // si no hay ninguno con mismo codigo y descrip  procede a crear uno nuevo
                    {
                        var i = new Productos_Insumos();

                        i.Codigo = Codigo;
                        i.Descripcion = txtDescripcion.Text;
                        i.Categoria_ID = (int)cmbCategoria.SelectedValue;
                        i.Ins_Prod = "INS";
                        i.Estado = cmbEstado.Text;
                        i.Apodo = txtApodo.Text;
                        i.Medida = (int)cmbMedida.SelectedValue;
                        //i.Medida2 = (int)cmbMedidaRef.SelectedValue;

                        //if (txtStockMin.TextLength > 0)
                        //    i.StockMin = Convert.ToDecimal(txtStockMin.Text);
                        //else
                        //    i.StockMin = 0;

                        //if (txtMaxProduccion.TextLength > 0)
                        //    i.MaxProducción = Convert.ToDecimal(txtMaxProduccion.Text);
                        //else
                        //    i.MaxProducción = 0;

                        //if (txtCantidadRef.TextLength > 0)
                        //    i.Cantidad_Ref = Convert.ToDecimal(txtCantidadRef.Text);

                        hb.Productos_Insumos.Add(i);

                        var z = new Existencia_Insumos();

                        z.Cantidad = 0;
                        
                        
                        hb.SaveChanges();

                        MessageBox.Show("El insumo se cargo correctamente", "Atencion");
                    }
                }
                if (rdbProductoFinal.Checked) // agrega producto
                {                
                    if (Resultado != null) // si hay uno igual no crea nada
                    {
                        if (Resultado != null)
                        {
                            if (Resultado.Codigo == Codigo) // si hay uno con codigo igual no crea nada y avisa
                            {
                                MessageBox.Show("Ya existe un producto con el código" + " " + " " + Codigo, "Error");
                            }
                            if (Resultado.Descripcion == txtDescripcion.Text) // si hay uno con descrip igual no crea nada y avisa
                            {
                                MessageBox.Show("Ya existe un producto con la descripción" + " " + " " + txtDescripcion.Text, "Error");
                            }
                        }
                    }
                    else // si no hay ninguno procede a crear uno nuevo
                    {
                        var i = new Productos_Insumos();

                        i.Codigo = txtCodigo.Text;
                        i.Descripcion = txtDescripcion.Text;
                        i.Categoria_ID = (int)cmbCategoria.SelectedValue;
                        i.Ins_Prod = "PRO";// codigo del producto
                        i.Estado = cmbEstado.Text;
                        i.Medida = (int)cmbMedida.SelectedValue;
                        //i.Medida2 = (int)cmbMedidaRef.SelectedValue;
                        //i.Apodo = txtApodo.Text;
                        //i.Responsable_ID = (int?)cmbResponsable.SelectedValue;

                        //if (txtCantidadRef.TextLength > 0)
                        //    i.Cantidad_Ref = Convert.ToDecimal(txtCantidadRef.Text);

                        //if (txtStockMin.TextLength > 0)
                        //    i.StockMin = Convert.ToDecimal(txtStockMin.Text);
                        //else
                        //    i.StockMin = 0;

                        //if (txtMaxProduccion.TextLength > 0)
                        //    i.MaxProducción = Convert.ToDecimal(txtMaxProduccion.Text);
                        //else
                        //    i.MaxProducción = 0;

                        for (int c = 1; c <= dgvReceta.Rows.Count; c++)
                        {                          
                            var z = new Formula_Producto();

                            z.Producto_ID = txtCodigo.Text;
                            z.Insumo_ID = dgvReceta.Rows[c - 1].Cells[1].Value.ToString();
                            z.Cantidad = Convert.ToDecimal(dgvReceta.Rows[c - 1].Cells[4].Value);
                            z.Medida = (int)cmbMedida.SelectedValue;

                            hb.Formula_Producto.Add(z);
                        }
                        hb.Productos_Insumos.Add(i);
                        hb.SaveChanges();
                        MessageBox.Show("El producto se cargo correctamente", "Atencion");
                        this.Hide();
                    }
                }
            }
        }
        private void OnOffbtnReceta()
        {
            if (rdbInsumo.Checked)
            {               
                btnEliminarIns.Enabled = false;
                btnConfirmarReceta.Enabled = false;
                cmbInsumo.Enabled = false;
                btnBuscarIns.Enabled = false;
                cmbMedida.Enabled = false;
                txtCantidad.Enabled = false;
            }
            else
            {               
                btnEliminarIns.Enabled = true;
                btnConfirmarReceta.Enabled = true;
                cmbInsumo.Enabled = true;
                btnBuscarIns.Enabled = true;
                cmbMedida.Enabled = true;
                txtCantidad.Enabled = true;
            }
        }
        private void EliminarCategoría()
        {
            if (cmbCategoria.SelectedIndex != -1)
            {
                DialogResult R = MessageBox.Show("¿Seguro que desea eliminar esta categoría?", "Atención",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        long ID = (int)cmbCategoria.SelectedValue;

                        var Consulta = (from C in hb.Categorias_InsPro
                                        where C.ID == ID
                                        select C); // Trae el Id a eliminar

                        var ConsultaGeneral = (from C in hb.Productos_Insumos
                                               where C.Categoria_ID == ID
                                               select C); // Consulta global para que ver que ver si hay articulo con esta categoría

                        var Resultados = Consulta.FirstOrDefault();
                        var ResultadosGeneral = ConsultaGeneral.ToList();

                        if (ResultadosGeneral.Count == 0)
                        {
                            hb.Categorias_InsPro.Remove(Resultados);
                            hb.SaveChanges();
                            MessageBox.Show("Datos eliminados correctamente", "Atención");
                            clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, false);
                        }
                        else
                        {
                            MessageBox.Show("No se puede eliminar esta categoría porque ya está afectada a otro artículo o producto. Solo puede darla de baja", "Atención");
                        }
                    }
                }               
            }
        }
        private void ActivarbtnCargarEditarInsumo()
        {
            if (txtCodigo.TextLength>0 && txtDescripcion.TextLength > 0 && cmbCategoria.SelectedIndex != -1 && cmbEstado.SelectedIndex != -1 && txtBuscarCategoria.Visible == false)
            {
                btnCargar.Enabled = true;
                btnEditar.Enabled = true;
            }
            else
            {
                btnCargar.Enabled = false;
                btnEditar.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CerrarOcultarForm = 1;
        }
        private void OnOffbtnCargar()
        {          
                if(txtCodigo.TextLength > 0 && 
                   txtDescripcion.TextLength > 0 &&
                   cmbCategoria.SelectedIndex != -1 &&
                   cmbEstado.SelectedIndex != -1 &&
                   cmbMedida.SelectedIndex != -1)
                {
                    if (CrearEditar == "1") // Si es para crear
                        btnCargar.Enabled = true;
                    if (CrearEditar == "2")// Si es para editar
                        btnEditar.Enabled = true;
                }
                else
                {
                    if (CrearEditar == "1")
                        btnCargar.Enabled = false;
                    if (CrearEditar == "2")
                        btnEditar.Enabled = false;
                }
        }
        private void EditaFormula()
        {
            if(dgvReceta.RowCount>0)
            {
                cmbInsumo.SelectedValue = dgvReceta.CurrentRow.Cells[0].Value;
                cmbInsumo.Text = dgvReceta.CurrentRow.Cells[1].Value.ToString();
                cmbMedida.Text = dgvReceta.CurrentRow.Cells[2].Value.ToString();
                txtCantidad.Text = dgvReceta.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Mo hay Insumo seleccionado", "Atención");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();           
        }
        private void txtCódigo_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void txtDescripcionInsumo_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void txtAgregarCategoria_TextChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }

        private void cmbEstadoinsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOffbtnCargar();
        }
        private void frmCrearCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, false);
        }
        private void btnAgregarNuevaCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormAgregar("1");
        }
        public void AbrirFormAgregar(string CrearEditar) // se reutiliza eb PUESTOS
        {
            var f = new frmCrearCategoria();
            f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmCrearCategoria_FormClosed);
            f.PulsoAgregarEditar = CrearEditar;
            f.PulsoCategoriaPuestoCiudadConcepto = "1";
            f.ShowDialog();
        }
        private void AbrirFormEditar()
        {
            if (cmbCategoria.SelectedIndex != -1)
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from C in hb.Categorias_InsPro
                                    where C.ID == (int)cmbCategoria.SelectedValue
                                    select C);

                    var Resultados = Consulta.FirstOrDefault();

                    var f = new frmCrearCategoria();
                    f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmCrearCategoria_FormClosed);
                    f.txtDescripcion.Text = cmbCategoria.Text;
                    
                    //if (Resultados.Estado == "SI")
                    //    f.cmbEstado.SelectedIndex = 0;
                    //else
                    //    f.cmbEstado.SelectedIndex = 1;

                    f.IDRecibCategoriaEditarEliminar = (int)cmbCategoria.SelectedValue;
                    f.PulsoAgregarEditar = "2"; // editar
                    f.PulsoCategoriaPuestoCiudadConcepto = "1"; // Categoria
                    f.ShowDialog();
                }
            }
        }
        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormEditar();
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            EliminarCategoría();
        }

        private void btnBuscarInsumo_Click(object sender, EventArgs e)
        {
            clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, true);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtBuscarCategoria.Visible = true;
            txtBuscarCategoria.Select();
        }

        private void txtBuscarCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarCategoria.Visible = false;
                clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarCategoria.Visible = false;
              //  clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, false);
            }
        }
        private void cmbCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
               clsCargarCombos.MostrarCategorias(cmbCategoria, txtBuscarCategoria, false);
            }
        }
        public static void AgregarRecetaALista(DataGridView DGV, ComboBox ComboInsPro, ComboBox CMedida, TextBox TCantidad, string ProductoPedido, string EstadoOrden) // el ultimo string es para dar señal si esta en el modulo productos o pedidos
        {
            if (ComboInsPro.SelectedIndex != -1 && CMedida.SelectedIndex != -1 && TCantidad.TextLength > 0)
            {

                //DGV.Rows.Add("", ComboInsPro.SelectedValue.ToString() , ComboInsPro.Text, CMedida.Text, Convert.ToDecimal(TCantidad.Text))

                DataGridViewRow Fila = new DataGridViewRow();

                Fila.CreateCells(DGV);
                Fila.Cells[1].Value = ComboInsPro.SelectedValue.ToString();
                Fila.Cells[2].Value = ComboInsPro.Text;
                Fila.Cells[3].Value = CMedida.Text;
                Fila.Cells[4].Value = Convert.ToDecimal(TCantidad.Text);
                Fila.Cells[8].Value = Convert.ToInt32(CMedida.SelectedValue);

                for (var i = 1; i <= DGV.RowCount; i++)
                {
                    if (DGV.Rows[i - 1].Cells[1].Value.ToString() == ComboInsPro.SelectedValue.ToString() && ProductoPedido == "1")
                    {
                        MessageBox.Show("El insumo " + ComboInsPro.Text + " " + "ya está en la lista", "Atención");
                        return;
                    }
                }

              //  DGV.Rows.Add(Fila);

                if (ProductoPedido == "2") // Si estamos en el modulo pedidos
                {
                    Fila.Cells[6].Value = Convert.ToDecimal(TCantidad.Text);
                    Fila.Cells[7].Value = 0;
                    Fila.Cells[8].Value = "Pendiente";
                    Fila.Cells[9].Value = CMedida.SelectedValue;
                    Fila.Cells[10].Value = "PEN";
                    Fila.Cells[11].Value = Convert.ToDecimal(TCantidad.Text);
                    Fila.Cells[12].Value = 0;

                    //VALIDACION PARA QUE NO HAYA 2 PRODUCTOS IGUALES EN UN MISMO PEDIDO
                    for (var i = 1; i <= DGV.RowCount; i++)
                    {
                        if (DGV.Rows[i - 1].Cells[1].Value.ToString() == ComboInsPro.SelectedValue.ToString())
                        {
                            MessageBox.Show("El producto " + ComboInsPro.Text + " " + "ya está en la lista de pedidos", "Atención");
                            return;
                        }
                    }

                    // CONTROLA EL STOCK
                    //using (var hb = new DBdatos())
                    //{
                    //        string ProductoID = ComboInsPro.SelectedValue.ToString();
                    //        string Producto_Descrip = ComboInsPro.Text;
                    //        decimal Cantidad = Convert.ToDecimal(TCantidad.Text);

                    //        var ConsultaStock = (from VS in hb.Vista_Stock
                    //                             where VS.Codigo == ComboInsPro.SelectedValue.ToString()
                    //                             select VS);

                    //        var ResultadosStock = ConsultaStock.FirstOrDefault();


                    //        if (ResultadosStock != null && (EstadoOrden == "AU" || EstadoOrden == "INF"))
                    //        {
                    //            if (EstadoOrden == "AU")
                    //            {
                    //                if (ResultadosStock.StockReal < Convert.ToDecimal(TCantidad.Text))
                    //                {
                    //                    string Mensaje = "La cantidad del producto " + Producto_Descrip + " " + "es insuficiente para completar este pedido" + "\r\n" + "\r\n"
                    //                                    + "Cantidad requerida: " + Cantidad.ToString("N2") + "\r\n"
                    //                                    + "Stock real: " + ResultadosStock.StockReal.ToString() + "\r\n" + "\r\n"
                    //                                    + "Necesita para completar pedido: " + (Cantidad - ResultadosStock.StockReal).ToString();

                    //                    MessageBox.Show(Mensaje, "Atención");
                    //                    return;
                    //                }
                    //                else
                    //                {
                    //                    string Mensaje = "Stock suficiente para el producto " + Producto_Descrip + "\r\n" + "\r\n"
                    //                                    + "Stock disponible: " + (ResultadosStock.StockReal - Cantidad).ToString();

                    //                    decimal NuevoStockPendiente = Convert.ToDecimal(ResultadosStock.Pendiente) - (Convert.ToDecimal(TCantidad.Text));
                    //                    Fila.Cells[11].Value = NuevoStockPendiente; // SE AGREGA PARA AYUDAR A LA EDICION DE PEDIDOS
                    //                    MessageBox.Show(Mensaje, "Atención");
                    //                }
                    //            }
                    //            if (EstadoOrden == "INF")
                    //            {
                    //                Fila.Cells[11].Value = ResultadosStock.Pendiente - Convert.ToDecimal(TCantidad.Text) * -1;
                    //            }
                    //        }
                    //    }
                    //}
                    
                }
                DGV.Rows.Add(Fila);
            }
            else
            {
                MessageBox.Show("Para agregar un insumo a la fórmula debe tener los campos Insumo, medida y cantidad completos");
            }
        }
        
        private void EliminarInsFormula(string CrearEditar)
        {
            if (dgvReceta.RowCount > 0)
            {
                DialogResult R = MessageBox.Show("¿Seguro que desea eliminar este item de la fórmula?", "Atención", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        if (CrearEditar == "1")
                        {
                            dgvReceta.Rows.Remove(dgvReceta.CurrentRow);
                        }
                        if (CrearEditar == "2")
                        {
                            long ID = 0;

                            if (dgvReceta.CurrentRow.Cells[0].Value != null)
                                ID = (long)dgvReceta.CurrentRow.Cells[0].Value; // Id de la formula a eliminar
                            else
                            {
                                dgvReceta.Rows.Remove(dgvReceta.CurrentRow);
                                return;
                            }
                            

                            var Consulta = (from IP in hb.Formula_Producto
                                            where IP.ID == ID
                                            select IP);

                            var Resultado = Consulta.FirstOrDefault();

                            if (Resultado != null)
                            {
                                hb.Formula_Producto.Remove(Resultado);
                                dgvReceta.Rows.Remove(dgvReceta.CurrentRow);
                                hb.SaveChanges();
                                MessageBox.Show("El item fue eliminado correctamente", "Atención");
                            }
                        }
                    }
                }
            }
        }      
        private void chkMuestraCategActivasInact_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void frmCrearInsumoProducto_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarInsumoProducto();
        }
        private void rdbInsumo_CheckedChanged(object sender, EventArgs e)
        {
            InsPro = "INS";
            OnOffbtnReceta();
            //dgvReceta.DataSource = "";
        }
        private void rdbProductoFinal_CheckedChanged(object sender, EventArgs e)
        {
            OnOffbtnReceta();
            clsCargarCombos.MostrarComboInsProConMedida(cmbInsumo, cmbMedidaFormula, txtBuscarIns,"INS", false);
            clsCargarCombos.MostrarMedidas(cmbMedida);
            InsPro = "PRO";
        }
        private void btnConfirmarReceta_Click(object sender, EventArgs e)
        {
            dgvReceta.Rows.Add("", cmbInsumo.SelectedValue.ToString(), cmbInsumo.Text, cmbMedida.Text, Convert.ToDecimal(txtCantidad.Text), cmbMedida.SelectedValue);
            //AgregarRecetaALista(dgvReceta, cmbInsumo, cmbMedidaFormula,txtCantidad,"1","");
        }
        private void btnBuscarIns_Click(object sender, EventArgs e)
        {
            txtBuscarIns.Visible = true;
            txtBuscarIns.Select();
        }
        private void cmbInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                if (clsVariablesGenerales.Aplicacion == "PACK-CODIN")
                    clsCargarCombos.MostrarComboInsProConMedida(cmbInsumo, cmbMedidaFormula, txtBuscarIns, "INS", false);
                if (clsVariablesGenerales.Aplicacion == "PACK-SHOP")
                    clsCargarCombos.MostrarComboInsProConMedida(cmbInsumo, cmbMedidaFormula, txtBuscarIns, "PRO", false);
            }
        }
        private void txtBuscarIns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarIns.Visible = false;
                if (clsVariablesGenerales.Aplicacion == "PACK-CODIN")
                    clsCargarCombos.MostrarComboInsProConMedida(cmbInsumo, cmbMedidaFormula, txtBuscarIns, "INS", true);
                if (clsVariablesGenerales.Aplicacion == "PACK-SHOP")
                    clsCargarCombos.MostrarComboInsProConMedida(cmbInsumo, cmbMedidaFormula, txtBuscarIns, "PRO", true);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarIns.Visible = false;
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarProductoInsumo();
        }
        private void btnEliminarIns_Click(object sender, EventArgs e)
        {
            EliminarInsFormula(CrearEditar);
        }
        private void cmbInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtBuscaResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void cmbResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void btnBuscarResponsable_Click(object sender, EventArgs e)
        {
            
        }
        private void cmbMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cmbMedida.SelectedIndex != -1)
            //{
            //    //lblUnidadRef.Text = "Cuantos " + cmbMedida.Text + " Equivalen a la unidad de referencia";
            //    cmbMedidaRef.Enabled = true;
            //    txtCantidadRef.Enabled = true;
            //}
            //else
            //{
            //    cmbMedidaRef.Enabled = false;
            //    txtCantidadRef.Enabled = false;
            //}
        }
        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }
        private void txtStockMin_KeyUp(object sender, KeyEventArgs e)
        {
           // Reutilizables.ValidarSoloNumeros(txtStockMin);
        }
        private void txtMaxProduccion_KeyUp(object sender, KeyEventArgs e)
        {
           // Reutilizables.ValidarSoloNumeros(txtMaxProduccion); 
        }
        private void txtCantidadRef_KeyUp(object sender, KeyEventArgs e)
        {
           // Reutilizables.ValidarSoloNumeros(txtCantidadRef);
        }

        private frmAgregarProdcutoTerminado f = new frmAgregarProdcutoTerminado();
        private void btnAfectar_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //AbrirFormulariosEnPanel.AbrirFormulariosHijos(f, pnlProductos, textBox1);
        }
        private void pnlProductos_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            Reutilizables.ValidarSoloNumeros(txtCantidad);
        }

        private void btnAgregarCodBarra_Click(object sender, EventArgs e)
        {
            dgvCodBarra.Rows.Add("", "", "SI");
        }

        private void dgvCodBarra_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvCodBarra.CurrentCell = dgvCodBarra.Rows[e.RowIndex].Cells["colCodigoBarra"];
            dgvCodBarra.BeginEdit(true);
        }

        private void btnEliminarCodBarra_Click(object sender, EventArgs e)
        {
            if (dgvCodBarra.CurrentRow.Cells["colCodBarraID"].Value.ToString() != "")       
                IDCodBarraEliminar.Add(Convert.ToInt64(dgvCodBarra.CurrentRow.Cells["colCodBarraID"].Value));

            dgvCodBarra.Rows.Remove(dgvCodBarra.CurrentRow);
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

        private void txtApodo_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarCategoria_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtBuscarIns_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
