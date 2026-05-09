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

namespace PCodin_Sinlacc.Formularios.Productos___Insumos
{
    public partial class frmInicioProductoInsumo : Form
    {
        public string CrearEditar;
        public string ProductoID;
        public string InsPro;
        string Name;
        public int UsuarioID;
        List<long> IDCodBarraEliminar = new List<long>();
        public frmInicioProductoInsumo()
        {
            InitializeComponent();
        }
        private frmCrearInsumoProducto frmGeneral = new frmCrearInsumoProducto();
        private void button1_Click(object sender, EventArgs e)
        {
            frmGeneral.CrearEditar = CrearEditar;
            frmGeneral.ProductoID = ProductoID;
            AbrirFormulariosEnPanel.AbrirFormulariosHijos(frmGeneral, pnlSecundario, label1);
            Name = btnGeneral.Name;
            CambiarColorbtones();
        }
        private frmProductoInsumoAbastecimiento frmAbastecimiento = new frmProductoInsumoAbastecimiento();
        private void btnAfectar_Click(object sender, EventArgs e)
        {
            frmAbastecimiento.CrearEditar = CrearEditar;
            frmAbastecimiento.ProductoID = ProductoID;
            frmAbastecimiento.DescripcionMedida = frmGeneral.cmbMedida.Text;
            frmAbastecimiento.InsPro = InsPro;
            Name = btnAbastecimiento.Name;
            CambiarColorbtones();
            AbrirFormulariosEnPanel.AbrirFormulariosHijos(frmAbastecimiento, pnlSecundario, label1);
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarInsumoProducto();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInicioProductoInsumo_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            frmDatosAdicionales.UsuarioID = UsuarioID;
            frmGeneral.CrearEditar = CrearEditar;
            frmGeneral.ProductoID = ProductoID;
            frmAbastecimiento.CrearEditar = CrearEditar;
            frmAbastecimiento.ProductoID = ProductoID;
            frmDatosAdicionales.CrearEditar = CrearEditar;
            frmDatosAdicionales.ProductoID = ProductoID;
            frmGeneral.InsPro = InsPro;
            frmDatosAdicionales.InsPro = InsPro;
            Reutilizables.RenderizarForm(this);
                        // SE REALIZA PARA ABIR TODOS LOS FORM DE LAS PESTAÑAS ASI TODOS TRAEN SUS DATOS AUNQUE NO SE VEAN.

            AbrirFormulariosEnPanel.AbrirFormulariosHijos(frmAbastecimiento, pnlSecundario, label1);
            AbrirFormulariosEnPanel.AbrirFormulariosHijos(frmDatosAdicionales, pnlSecundario, label1);
            AbrirFormulariosEnPanel.AbrirFormulariosHijos(frmGeneral, pnlSecundario, label1);

            if (CrearEditar == "1") 
            {
                btnCargar.Enabled = true;
                btnEditar.Enabled = false;             
            }
            if (CrearEditar == "2")
            {
                btnCargar.Enabled = false;
                btnEditar.Enabled = true;
            }

            if (InsPro == "INS")
            {
                btnCargar.Text = "Cargar insumo";
                btnEditar.Text = "Editar insumo";
            }
        }
        private frmDatosAdicionales frmDatosAdicionales = new frmDatosAdicionales();
        private void btnDatosAdicionales_Click(object sender, EventArgs e)
        {
            frmDatosAdicionales.CrearEditar = CrearEditar;

            if (CrearEditar == "1" && frmGeneral.txtCodigo.TextLength > 0)
                frmDatosAdicionales.ProductoID = frmGeneral.txtCodigo.Text;
            else
                frmDatosAdicionales.ProductoID = ProductoID;

            frmDatosAdicionales.InsPro = InsPro;

            Name = btnDatosAdicionales.Name;
            CambiarColorbtones();
            //frmDatosAdicionales.UsuarioID = UsuarioID;
            AbrirFormulariosEnPanel.AbrirFormulariosHijos(frmDatosAdicionales, pnlSecundario, label1);
        }
        private void CambiarColorbtones()
        {           
            foreach(var Control in pnlMenu.Controls)
            {
                if (((Control)Control) is Button)
                {
                    if (((Button)Control).Name == Name)
                    {
                        ((Button)Control).BackColor = Color.Orange;
                    }
                    else
                    {
                        if (((Button)Control).Name != "btnVolver")
                        {
                            ((Button)Control).BackColor = Color.White;
                        }
                    }
                }
                
            }
        }
        private void CargarInsumoProducto()
        {
            if (frmGeneral.txtCodigo.TextLength > 0 &&
                  frmGeneral.txtDescripcion.TextLength > 0 &&
                  frmGeneral.cmbCategoria.SelectedIndex != -1 &&
                  frmGeneral.cmbEstado.SelectedIndex != -1 &&
                  frmGeneral.cmbMedida.SelectedIndex != -1)
            { // VALIDACION PARA QUE NO CARGUE DATOS VACIOS O NULOS
                using (var hb = new DBdatos())
                {
                    btnCargar.Enabled = true;
                    btnEditar.Enabled = false;

                    string Codigo = frmGeneral.txtCodigo.Text;

                    var Consulta = (from T in hb.Productos_Insumos
                                    where T.Codigo == Codigo
                                    || T.Descripcion == frmGeneral.txtDescripcion.Text
                                    select T); // valida que no haya un insumo o producto con mismo codigo o descrip

                    var ConsultaCodigoBarra = (from CB in hb.CODIGOBARRA
                                               where CB.CodigoBarra1 == frmGeneral.txtCodigoBarra.Text
                                               select CB).FirstOrDefault();

                    var Resultado = Consulta.FirstOrDefault();
                    

                    if (frmGeneral.rdbInsumo.Checked)  // agrega insumo
                    {
                        if (Resultado != null)
                        {
                            if (Resultado.Codigo == Codigo) // si hay uno con codigo igual no crea nada y avisa
                            {
                                MessageBox.Show("Ya existe un insumo con el código" + " " + " " + Codigo, "Error");
                            }
                            if (Resultado.Descripcion == frmGeneral.txtDescripcion.Text) // si hay uno con descrip igual no crea nada y avisa
                            {
                                MessageBox.Show("Ya existe un insumo con la descripción" + " " + " " + frmGeneral.txtDescripcion.Text, "Error");
                            }
                        }
                        else if (ConsultaCodigoBarra != null)
                            MessageBox.Show("Ya existe un articulo con codigo de barra" + " " + " " + frmGeneral.txtCodigoBarra.Text, "Error");
                        else // si no hay ninguno con mismo codigo y descrip  procede a crear uno nuevo
                        {
                            //GENERAL
                            var i = new Productos_Insumos();

                            i.Codigo = Codigo;
                            i.Descripcion = frmGeneral.txtDescripcion.Text;
                            i.Categoria_ID = (int)frmGeneral.cmbCategoria.SelectedValue;
                            i.Ins_Prod = "INS";
                            i.Estado = frmGeneral.cmbEstado.Text;
                            i.Apodo = frmGeneral.txtApodo.Text;
                            i.Medida = (int)frmGeneral.cmbMedida.SelectedValue;

                            //CODIGO BARRA

                            for (int x = 0; x < frmGeneral.dgvCodBarra.RowCount; x++)
                            {
                                string CodigoBarra = frmGeneral.dgvCodBarra.Rows[x].Cells["colCodigoBarra"].Value.ToString();
                                string Estado = frmGeneral.dgvCodBarra.Rows[x].Cells["colEstadoCodigo"].Value.ToString();

                                var ConsultaCodBarra = (from CB in hb.CODIGOBARRA
                                                        where CB.CodigoBarra1 == CodigoBarra
                                                        select CB).FirstOrDefault();

                                if(ConsultaCodBarra == null)
                                {
                                    var NuevoCodBarra = new CODIGOBARRA();

                                    NuevoCodBarra.CodigoBarra1 = CodigoBarra;
                                    NuevoCodBarra.Estado = Estado;
                                    NuevoCodBarra.Producto_ID = frmGeneral.txtCodigo.Text;

                                    hb.CODIGOBARRA.Add(NuevoCodBarra);
                                }
                                else
                                {
                                    MessageBox.Show("Ya existe articulo con el códgio de barras " + CodigoBarra + ". El mismo está definido para el artículo " + ConsultaCodBarra.Productos_Insumos.Descripcion + " - " + ConsultaCodBarra.Productos_Insumos.Codigo);
                                }
                            }

                            //    var NuevoCodigoBarra = new CODIGOBARRA();

                            //NuevoCodigoBarra.Producto_ID = Codigo;
                            //NuevoCodigoBarra.CodigoBarra1 = frmGeneral.txtCodigoBarra.Text;
                            //NuevoCodigoBarra.Estado = "SI";

                            //ABASTECIMIENTO
                            if (frmAbastecimiento.txtDiasProduccion.TextLength > 0)
                                i.Dias_Produccion = Convert.ToDecimal(frmAbastecimiento.txtDiasProduccion.Text);
                            else
                                i.Dias_Produccion = null;

                            if (frmAbastecimiento.txtProducciónDiaria.TextLength > 0)
                                i.Produccion_Diaria = Convert.ToDecimal(frmAbastecimiento.txtProducciónDiaria.Text);
                            else
                                i.Produccion_Diaria = null;

                            if (frmAbastecimiento.txtDemoraProveedor.TextLength > 0)
                                i.Demora_Entrega = Convert.ToDecimal(frmAbastecimiento.txtDemoraProveedor.Text);
                            else
                                i.Demora_Entrega = null;

                            if (frmAbastecimiento.lblPuntoPedido.Text != "")
                                i.Punto_Pedido = frmAbastecimiento.PuntoDePedido;
                            else
                                i.Punto_Pedido = null;

                            if (frmAbastecimiento.cmbNotifica.SelectedIndex == 1)
                                i.NotificaPuntoPedido = "SI";
                            if (frmAbastecimiento.cmbNotifica.SelectedIndex == 2)
                                i.NotificaPuntoPedido = "NO";

                            //DATOS ADICIONALES
                            i.Medida2 = (int)frmDatosAdicionales.cmbMedidaRef.SelectedValue;

                            if (frmDatosAdicionales.txtStockMin.TextLength > 0)
                                i.StockMin = Convert.ToDecimal(frmDatosAdicionales.txtStockMin.Text);
                            else
                                i.StockMin = 0;

                            if (frmDatosAdicionales.chkNotificaStockMin.Checked)
                                i.NotificaStockMin = "SI";
                            else
                                i.NotificaStockMin = "NO";

                            if (frmDatosAdicionales.txtMaxProduccion.TextLength > 0)
                                i.MaxProducción = Convert.ToDecimal(frmDatosAdicionales.txtMaxProduccion.Text);
                            else
                                i.MaxProducción = 0;

                            if (frmDatosAdicionales.txtCantidadRef.TextLength > 0)
                                i.Cantidad_Ref = Convert.ToDecimal(frmDatosAdicionales.txtCantidadRef.Text);

                            if (frmDatosAdicionales.chkSubProducto.Checked)
                                i.Subproducto = "SI";
                            else
                                i.Subproducto = "NO";

                            i.Responsable_ID = (int?)frmDatosAdicionales.cmbResponsable.SelectedValue;


                            //if (frmDatosAdicionales.txtCosto.TextLength > 0)
                            //    i.Costo = Convert.ToDecimal(frmDatosAdicionales.txtCosto.Text);

                            hb.Productos_Insumos.Add(i);

                            long IDFicticio = 0;

                            var ConsultaID = (from I in hb.Insumo_Proveedor
                                              orderby I.ID descending
                                              select I).FirstOrDefault();

                            for (int c = 1; c <= frmDatosAdicionales.dgvProveedor.Rows.Count; c++)
                            {
                                var w = new Insumo_Proveedor();

                                if(ConsultaID == null)
                                {
                                    IDFicticio = IDFicticio + 1;
                                    w.ID = IDFicticio;
                                }
                                else
                                {
                                    IDFicticio = IDFicticio + 1;
                                    w.ID = ConsultaID.ID + IDFicticio;
                                }

                                w.Insumo_ID = frmGeneral.txtCodigo.Text;
                                w.Proveedor_ID = Convert.ToInt32(frmDatosAdicionales.dgvProveedor.Rows[c - 1].Cells[columnName: "colProveedorID"].Value);
                                w.Costo = Convert.ToDecimal(frmDatosAdicionales.dgvProveedor.Rows[c - 1].Cells[columnName: "colCosto"].Value);
                                w.Moneda_ID = frmDatosAdicionales.dgvProveedor.Rows[c - 1].Cells[columnName: "colMoneda"].Value.ToString();
                                w.Proveedor_Principal = frmDatosAdicionales.dgvProveedor.Rows[c - 1].Cells[columnName: "colPrincipal"].Value.ToString();

                                hb.Insumo_Proveedor.Add(w);
                            }

                            var z = new Existencia_Insumos();

                            z.Cantidad = 0;

                            hb.SaveChanges();

                            MessageBox.Show("El insumo se cargo correctamente", "Atencion");
                        }
                    }
                    if (frmGeneral.rdbProductoFinal.Checked) // agrega producto
                    {
                        if (Resultado != null) // si hay uno igual no crea nada
                        {
                            if (Resultado != null)
                            {
                                if (Resultado.Codigo == Codigo) // si hay uno con codigo igual no crea nada y avisa
                                {
                                    MessageBox.Show("Ya existe un producto con el código" + " " + " " + Codigo, "Error");
                                }
                                if (Resultado.Descripcion == frmGeneral.txtDescripcion.Text) // si hay uno con descrip igual no crea nada y avisa
                                {
                                    MessageBox.Show("Ya existe un producto con la descripción" + " " + " " + frmGeneral.txtDescripcion.Text, "Error");
                                }
                            }
                        }
                        else // si no hay ninguno procede a crear uno nuevo
                        {
                            //GENERAL
                            var i = new Productos_Insumos();

                            i.Codigo = frmGeneral.txtCodigo.Text;
                            i.Descripcion = frmGeneral.txtDescripcion.Text;
                            i.Categoria_ID = (int)frmGeneral.cmbCategoria.SelectedValue;
                            i.Ins_Prod = "PRO";// codigo del producto
                            i.Estado = frmGeneral.cmbEstado.Text;
                            i.Medida = (int)frmGeneral.cmbMedida.SelectedValue;

                            //DATOS ADICIONALES
                            i.Medida2 = (int)frmDatosAdicionales.cmbMedidaRef.SelectedValue;

                            for (int x = 0; x < frmGeneral.dgvCodBarra.RowCount; x++)
                            {
                                string CodigoBarra = frmGeneral.dgvCodBarra.Rows[x].Cells["colCodigoBarra"].Value.ToString();
                                string Estado = frmGeneral.dgvCodBarra.Rows[x].Cells["colEstadoCodigo"].Value.ToString();

                                var ConsultaCodBarra = (from CB in hb.CODIGOBARRA
                                                        where CB.CodigoBarra1 == CodigoBarra
                                                        select CB).FirstOrDefault();

                                if (ConsultaCodBarra == null)
                                {
                                    var NuevoCodBarra = new CODIGOBARRA();

                                    NuevoCodBarra.CodigoBarra1 = CodigoBarra;
                                    NuevoCodBarra.Estado = Estado;
                                    NuevoCodBarra.Producto_ID = frmGeneral.txtCodigo.Text;

                                    hb.CODIGOBARRA.Add(NuevoCodBarra);
                                }
                                else
                                {
                                    MessageBox.Show("Ya existe articulo con el códgio de barras " + CodigoBarra + ". El mismo está definido para el artículo " + ConsultaCodBarra.Productos_Insumos.Descripcion + " - " + ConsultaCodBarra.Productos_Insumos.Codigo);
                                }
                            }

                            if (frmDatosAdicionales.txtStockMin.TextLength > 0)
                                i.StockMin = Convert.ToDecimal(frmDatosAdicionales.txtStockMin.Text);
                            else
                                i.StockMin = 0;

                            if (frmDatosAdicionales.txtMaxProduccion.TextLength > 0)
                                i.MaxProducción = Convert.ToDecimal(frmDatosAdicionales.txtMaxProduccion.Text);
                            else
                                i.MaxProducción = 0;

                            if (frmDatosAdicionales.txtCantidadRef.TextLength > 0)
                                i.Cantidad_Ref = Convert.ToDecimal(frmDatosAdicionales.txtCantidadRef.Text);

                            if (frmDatosAdicionales.chkPallet.Checked && frmDatosAdicionales.cmbProductoPallet.SelectedIndex != -1)
                            {
                                i.Pallet = "SI";
                                i.ProductoPallet = frmDatosAdicionales.cmbProductoPallet.SelectedValue.ToString();
                                i.ProductoPalletCantidad = Convert.ToDecimal(frmDatosAdicionales.txtProductoPalletCantidad.Text);
                            }                               
                            else
                                i.Pallet = "NO";



                            if (frmDatosAdicionales.cmbColor.SelectedIndex != -1)
                                i.Color = frmDatosAdicionales.cmbColor.Text;

                            i.Subproducto = "NO";

                            int IDFicticioProCli = 0;

                            var ConsultaIDProCli = (from I in hb.Producto_Cliente
                                                    orderby I.ID descending
                                                    select I).FirstOrDefault();

                            for (int c = 1; c <= frmDatosAdicionales.dgvProveedor.Rows.Count; c++)
                            {
                                var w = new Producto_Cliente();


                                if (ConsultaIDProCli == null)
                                {
                                    IDFicticioProCli = IDFicticioProCli + 1;
                                    w.ID = IDFicticioProCli;
                                }
                                else
                                {
                                    IDFicticioProCli = IDFicticioProCli + 1;
                                    w.ID = ConsultaIDProCli.ID + IDFicticioProCli;

                                }

                                w.Producto_ID = frmGeneral.txtCodigo.Text;
                                w.Cliente_ID = Convert.ToInt32(frmDatosAdicionales.dgvProveedor.Rows[c - 1].Cells[columnName: "colProveedorID"].Value);
                                w.Valor = Convert.ToDecimal(frmDatosAdicionales.dgvProveedor.Rows[c - 1].Cells[columnName: "colCosto"].Value);
                                w.Moneda_ID = frmDatosAdicionales.dgvProveedor.Rows[c - 1].Cells[columnName: "colMoneda"].Value.ToString();
                                w.Principal = frmDatosAdicionales.dgvProveedor.Rows[c - 1].Cells[columnName: "colPrincipal"].Value.ToString();

                                hb.Producto_Cliente.Add(w);
                            }
                            // FORMULA
                          
                            long IDFicticioFormula = 0;

                            var ConsultaIDFormula = (from F in hb.Formula_Producto
                                              orderby F.ID descending
                                              select F).FirstOrDefault();                          

                            for (int c = 1; c <= frmGeneral.dgvReceta.Rows.Count; c++)
                            {
                                var z = new Formula_Producto();

                                if (ConsultaIDFormula == null)
                                {
                                    IDFicticioFormula = IDFicticioFormula + 1;
                                    z.ID = IDFicticioFormula;
                                }
                                else
                                {
                                    IDFicticioFormula = IDFicticioFormula + 1;
                                    z.ID = ConsultaIDFormula.ID + IDFicticioFormula;

                                }
                                
                                z.Producto_ID = frmGeneral.txtCodigo.Text;
                                z.Insumo_ID = frmGeneral.dgvReceta.Rows[c - 1].Cells[1].Value.ToString();
                                z.Cantidad = Convert.ToDecimal(frmGeneral.dgvReceta.Rows[c - 1].Cells[4].Value);
                                z.Medida = (int)frmGeneral.cmbMedida.SelectedValue;

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
            else
            {
                MessageBox.Show("Datos incompletos en 'General'", "Atención");
                return;
            }
        }
        private void EditarProductoInsumo()
        {
            if (CrearEditar == "2")
            {
                using (var hb = new DBdatos())
                {
                    var Consulta_Editar = (from IP in hb.Productos_Insumos
                                           where IP.Codigo == ProductoID
                                           select IP);

                    var Consulta_Descrip = (from IP in hb.Productos_Insumos
                                            where IP.Codigo == ProductoID || IP.Descripcion == frmGeneral.txtDescripcion.Text
                                            select IP);

                    var ConsultaCodigoBarraEliminar = (from CB in hb.CODIGOBARRA
                                                       where CB.Producto_ID == ProductoID
                                                        && frmGeneral.IDCodBarraEliminar.Contains(CB.ID)
                                                       select CB).ToList();


                    var ResultadoEditar = Consulta_Editar.FirstOrDefault();
                    var Validacion_Descrip = Consulta_Descrip.FirstOrDefault();

                    if (Validacion_Descrip == null || (ProductoID == frmGeneral.txtCodigo.Text)) // si no hay ninguna descripcion igual
                    {
                        //GENERAL
                        ResultadoEditar.Codigo = frmGeneral.txtCodigo.Text;
                        ResultadoEditar.Descripcion = frmGeneral.txtDescripcion.Text;
                        ResultadoEditar.Apodo = frmGeneral.txtApodo.Text;
                        ResultadoEditar.Categoria_ID = (int)frmGeneral.cmbCategoria.SelectedValue;
                        ResultadoEditar.Estado = frmGeneral.cmbEstado.Text;
                        ResultadoEditar.Medida = (int)frmGeneral.cmbMedida.SelectedValue;

                        for(int i = 0; i < frmGeneral.dgvCodBarra.RowCount;i++)
                        {

                            long IDCodigoBarra = 0;
                            string CodigoBarra = frmGeneral.dgvCodBarra.Rows[i].Cells["colCodigoBarra"].Value.ToString();
                            string Estado = frmGeneral.dgvCodBarra.Rows[i].Cells["colEstadoCodigo"].Value.ToString();
                           

                            if (frmGeneral.dgvCodBarra.Rows[i].Cells["colCodBarraID"].Value.ToString() != "")
                                IDCodigoBarra = Convert.ToInt64(frmGeneral.dgvCodBarra.Rows[i].Cells["colCodBarraID"].Value);

                            if (frmGeneral.dgvCodBarra.Rows[i].Cells["colCodBarraID"].Value.ToString() == "")
                            {
                                var NuevoCodBarra = new CODIGOBARRA();

                                NuevoCodBarra.CodigoBarra1 = frmGeneral.dgvCodBarra.Rows[i].Cells["colCodigoBarra"].Value.ToString();
                                NuevoCodBarra.Estado = frmGeneral.dgvCodBarra.Rows[i].Cells["colEstadoCodigo"].Value.ToString();
                                NuevoCodBarra.Producto_ID = frmGeneral.ProductoID.ToString();

                                hb.CODIGOBARRA.Add(NuevoCodBarra);
                            }
                            else
                            {
                                var ConsultaCodigoBarra = (from CB in hb.CODIGOBARRA
                                                           where CB.ID == IDCodigoBarra
                                                           select CB).FirstOrDefault();

                                ConsultaCodigoBarra.CodigoBarra1 = CodigoBarra;
                                ConsultaCodigoBarra.Estado = Estado;                               
                            }                            
                        }
                        hb.CODIGOBARRA.RemoveRange(ConsultaCodigoBarraEliminar);
                        //if(frmGeneral.CodigoBarraOriginal != frmGeneral.txtCodigoBarra.Text)
                        //{
                        //    if (ConsultaCodigoBarra == null)
                        //        ResultadoEditar.CodigoBarra = frmGeneral.txtCodigoBarra.Text;
                        //    else
                        //        MessageBox.Show("Ya existe un articulo con el código ingresado", "Error");
                        //}
                        

                        //ABASTECIMIENTOS
                        if (frmAbastecimiento.txtDiasProduccion.TextLength > 0)
                            ResultadoEditar.Dias_Produccion = Convert.ToDecimal(frmAbastecimiento.txtDiasProduccion.Text);
                        else
                            ResultadoEditar.Dias_Produccion = null;

                        if (frmAbastecimiento.txtProducciónDiaria.TextLength > 0)
                            ResultadoEditar.Produccion_Diaria = Convert.ToDecimal(frmAbastecimiento.txtProducciónDiaria.Text);
                        else
                            ResultadoEditar.Produccion_Diaria = null;

                        if (frmAbastecimiento.txtDemoraProveedor.TextLength > 0)
                            ResultadoEditar.Demora_Entrega = Convert.ToDecimal(frmAbastecimiento.txtDemoraProveedor.Text);
                        else
                            ResultadoEditar.Demora_Entrega = null;

                        if (frmAbastecimiento.lblPuntoPedido.Text != "")
                            ResultadoEditar.Punto_Pedido = Convert.ToDecimal(frmAbastecimiento.lblPuntoPedido.Text);
                        else
                            ResultadoEditar.Punto_Pedido = null;

                        if (frmAbastecimiento.cmbNotifica.SelectedIndex == 1)
                            ResultadoEditar.NotificaPuntoPedido = "SI";
                        if (frmAbastecimiento.cmbNotifica.SelectedIndex == 2)
                            ResultadoEditar.NotificaPuntoPedido = "NO";

                        //DATOS ADICIONALES
                        if (frmDatosAdicionales.cmbMedidaRef.SelectedIndex != -1)
                            ResultadoEditar.Medida2 = (int)frmDatosAdicionales.cmbMedidaRef.SelectedValue;
                        else
                            ResultadoEditar.Medida2 = null;

                            ResultadoEditar.Responsable_ID = (int?)frmDatosAdicionales.cmbResponsable.SelectedValue;

                        if (frmDatosAdicionales.txtStockMin.TextLength > 0)
                            ResultadoEditar.StockMin = Convert.ToDecimal(frmDatosAdicionales.txtStockMin.Text);
                        else
                            ResultadoEditar.StockMin = 0;

                        if (frmDatosAdicionales.chkNotificaStockMin.Checked)
                            ResultadoEditar.NotificaStockMin = "SI";
                        else
                            ResultadoEditar.NotificaStockMin = "NO";

                        if (frmDatosAdicionales.txtMaxProduccion.TextLength > 0)
                            ResultadoEditar.MaxProducción = Convert.ToDecimal(frmDatosAdicionales.txtMaxProduccion.Text);
                        else
                            ResultadoEditar.MaxProducción = 0;

                        if (frmDatosAdicionales.txtCantidadRef.TextLength > 0)
                            ResultadoEditar.Cantidad_Ref = Convert.ToDecimal(frmDatosAdicionales.txtCantidadRef.Text);
                        else
                            ResultadoEditar.Cantidad_Ref = 0;

                        if (frmDatosAdicionales.chkPallet.Checked && frmDatosAdicionales.cmbProductoPallet.SelectedIndex != -1)
                        {
                            ResultadoEditar.Pallet = "SI";
                            ResultadoEditar.ProductoPallet = frmDatosAdicionales.cmbProductoPallet.SelectedValue.ToString();
                            ResultadoEditar.ProductoPalletCantidad = Convert.ToDecimal(frmDatosAdicionales.txtProductoPalletCantidad.Text);
                        }
                        else
                            ResultadoEditar.Pallet = "NO";

                        if (frmDatosAdicionales.cmbColor.SelectedIndex != -1)
                            ResultadoEditar.Color = frmDatosAdicionales.cmbColor.Text;

                        if (frmDatosAdicionales.chkSubProducto.Checked)
                            ResultadoEditar.Subproducto = "SI";
                        else
                            ResultadoEditar.Subproducto = "NO";

                        ResultadoEditar.Responsable_ID = (int?)frmDatosAdicionales.cmbResponsable.SelectedValue;

                        if (frmDatosAdicionales.txtCosto1.TextLength > 0)
                            ResultadoEditar.Costo = Convert.ToDecimal(frmDatosAdicionales.txtCosto1.Text);
                        else
                            ResultadoEditar.Costo = 0;

                        var ConsultaIPRO = (from IPRO in hb.Insumo_Proveedor
                                            where IPRO.Insumo_ID == ProductoID
                                            select IPRO).ToList();

                        hb.Insumo_Proveedor.RemoveRange(ConsultaIPRO);

                        int IDFicticoInsPro = 0;

                        var ConsultaID = (from I in hb.Insumo_Proveedor
                                          orderby I.ID descending
                                          select I).FirstOrDefault();

                        for (int c = 1; c <= frmDatosAdicionales.dgvProveedor.Rows.Count; c++)
                        {
                            int Proveedor = Convert.ToInt32(frmDatosAdicionales.dgvProveedor.Rows[c - 1].Cells[columnName: "colProveedorID"].Value);
                            decimal Costo = Convert.ToDecimal(frmDatosAdicionales.dgvProveedor.Rows[c - 1].Cells[columnName: "colCosto"].Value);
                            string Moneda = frmDatosAdicionales.dgvProveedor.Rows[c - 1].Cells[columnName: "colMoneda"].Value.ToString();
                            string Principal = frmDatosAdicionales.dgvProveedor.Rows[c - 1].Cells[columnName: "colPrincipal"].Value.ToString();

                            var z = new Insumo_Proveedor();

                            if (ConsultaID == null)
                            {
                                IDFicticoInsPro = IDFicticoInsPro + 1;
                                z.ID = IDFicticoInsPro;
                            }
                            else
                            {
                                IDFicticoInsPro = IDFicticoInsPro + 1;
                                z.ID = ConsultaID.ID + IDFicticoInsPro;
                            }

                            z.Insumo_ID = ProductoID;
                            z.Proveedor_ID = Proveedor;
                            z.Costo = Costo;
                            z.Moneda_ID = Moneda;
                            z.Proveedor_Principal = Principal;

                            hb.Insumo_Proveedor.Add(z);
                        }                   
                        if (frmGeneral.rdbInsumo.Checked)
                        {
                            hb.SaveChanges();
                            MessageBox.Show("Datos modificados correctamente", "Atención");
                        }
                    }
                    else
                    if (Validacion_Descrip.Descripcion == frmGeneral.txtDescripcion.Text
                            && (Validacion_Descrip.Codigo == frmGeneral.txtCodigo.Text && frmGeneral.txtCodigo.Text == ProductoID)
                            && (ResultadoEditar.Estado != frmGeneral.cmbEstado.Text
                            || ResultadoEditar.Categorias_InsPro != frmGeneral.cmbCategoria.SelectedValue
                            || ResultadoEditar.Apodo != frmGeneral.txtApodo.Text
                            || ResultadoEditar.StockMin.ToString() != frmDatosAdicionales.txtStockMin.Text
                            || ResultadoEditar.MaxProducción.ToString() != frmDatosAdicionales.txtMaxProduccion.Text
                            || ResultadoEditar.Medida != (int)frmGeneral.cmbMedida.SelectedValue))  // Esto es para cambiar solamente el estado
                    {
                        ResultadoEditar.Apodo = frmGeneral.txtApodo.Text;
                        ResultadoEditar.Categoria_ID = (int)frmGeneral.cmbCategoria.SelectedValue;
                        ResultadoEditar.Estado = frmGeneral.cmbEstado.Text;
                        ResultadoEditar.Medida = (int)frmGeneral.cmbMedida.SelectedValue;
                        
                        //DATOS ADICIONALES
                        ResultadoEditar.Medida2 = (int)frmDatosAdicionales.cmbMedidaRef.SelectedValue;
                        ResultadoEditar.Responsable_ID = (int?)frmDatosAdicionales.cmbResponsable.SelectedValue;
                        ResultadoEditar.Cantidad_Ref = Convert.ToDecimal(frmDatosAdicionales.txtCantidadRef.Text);

                        if (frmDatosAdicionales.txtStockMin.TextLength > 0)
                            ResultadoEditar.StockMin = Convert.ToDecimal(frmDatosAdicionales.txtStockMin.Text);
                        else
                            ResultadoEditar.StockMin = 0;

                        if (frmDatosAdicionales.txtMaxProduccion.TextLength > 0)
                            ResultadoEditar.MaxProducción = Convert.ToDecimal(frmDatosAdicionales.txtMaxProduccion.Text);
                        else
                            ResultadoEditar.MaxProducción = 0;

                        if (frmDatosAdicionales.txtCantidadRef.TextLength > 0)
                            ResultadoEditar.Cantidad_Ref = Convert.ToDecimal(frmDatosAdicionales.txtCantidadRef.Text);
                        else
                            ResultadoEditar.Cantidad_Ref = null;

                        ResultadoEditar.Responsable_ID = (int?)frmDatosAdicionales.cmbResponsable.SelectedValue;

                        if (frmDatosAdicionales.txtCosto1.TextLength > 0)
                            ResultadoEditar.Costo = Convert.ToDecimal(frmDatosAdicionales.txtCosto1.Text);
                        else
                            ResultadoEditar.Costo = null;

                        if (frmGeneral.rdbInsumo.Checked)
                        {
                            hb.SaveChanges();
                            MessageBox.Show("Datos modificados correctamente", "Atención");
                        }
                    }
                    else
                    {
                        if (frmGeneral.rdbInsumo.Checked) // para que cambie el mensaje segun si es insumo o producto
                        {
                            if (frmGeneral.txtDescripcion.Text == Validacion_Descrip.Descripcion)
                                MessageBox.Show("Ya existe un insumo con la descripción " + " " + frmGeneral.txtDescripcion.Text, "Atención");
                            if (frmGeneral.txtCodigo.Text == Validacion_Descrip.Codigo)
                                MessageBox.Show("Ya existe un insumo con el código " + " " + frmGeneral.txtCodigo.Text, "Atención");
                        }
                        else
                        {
                            if (frmGeneral.txtDescripcion.Text == Validacion_Descrip.Descripcion)
                                MessageBox.Show("Ya existe un producto con la descripción " + " " + frmGeneral.txtDescripcion.Text, "Atención");
                            if (frmGeneral.txtCodigo.Text == Validacion_Descrip.Codigo)
                                MessageBox.Show("Ya existe un producto con el código " + " " + frmGeneral.txtCodigo.Text, "Atención");
                        }
                    }
                    if (frmGeneral.rdbProductoFinal.Checked) // Aqui se cargan solamente los datos de la formula
                    {
                        var Consulta = (from FP in hb.Formula_Producto
                                        where FP.Producto_ID == ProductoID
                                        select FP).ToList();

                        hb.Formula_Producto.RemoveRange(Consulta);
                        hb.SaveChanges();

                        long IDFicticio = 0;

                        var ConsultaID = (from I in hb.Formula_Producto
                                          orderby I.ID descending
                                          select I).FirstOrDefault();


                        for (int c = 1; c <= frmGeneral.dgvReceta.Rows.Count; c++)
                        {
                           

                            string InsumoID = frmGeneral.dgvReceta.Rows[c - 1].Cells[1].Value.ToString();
                            string Medida = frmGeneral.dgvReceta.Rows[c - 1].Cells[3].Value.ToString();
                            decimal Cantidad = Convert.ToDecimal(frmGeneral.dgvReceta.Rows[c - 1].Cells[4].Value);
                            int MedidaID = (int)frmGeneral.dgvReceta.Rows[c - 1].Cells[5].Value;
                           
                            //var Validacion = Consulta.FirstOrDefault(); // Validación para no cargar renglon con mismo formula

                            var z = new Formula_Producto();

                            if (ConsultaID == null)
                            {
                                IDFicticio = IDFicticio + 1;
                                z.ID = IDFicticio;
                            }
                            else
                            {
                                IDFicticio = IDFicticio + 1;
                                z.ID = ConsultaID.ID + IDFicticio;
                            }

                            z.Producto_ID = ProductoID;
                            z.Insumo_ID = InsumoID;
                            z.Cantidad = Cantidad;
                            z.Medida = MedidaID;

                            hb.Formula_Producto.Add(z);

                            var ConsultaIPRO = (from ICLI in hb.Producto_Cliente
                                                where ICLI.Producto_ID == ProductoID
                                                select ICLI).ToList();

                            hb.Producto_Cliente.RemoveRange(ConsultaIPRO);
                        }
                        int IdFicticioProCli = 0;

                        var ConsultaIDProCli = (from I in hb.Producto_Cliente
                                                orderby I.ID descending
                                                select I).FirstOrDefault();

                        for (int t = 1; t <= frmDatosAdicionales.dgvProveedor.Rows.Count; t++)
                        {
                            int Proveedor = Convert.ToInt32(frmDatosAdicionales.dgvProveedor.Rows[t - 1].Cells[columnName:"colProveedorID"].Value);
                            decimal Valor = Convert.ToDecimal(frmDatosAdicionales.dgvProveedor.Rows[t - 1].Cells[columnName: "colCosto"].Value);
                            string Moneda = frmDatosAdicionales.dgvProveedor.Rows[t - 1].Cells[columnName: "colMoneda"].Value.ToString();
                            string Principal = frmDatosAdicionales.dgvProveedor.Rows[t - 1].Cells[columnName: "colPrincipal"].Value.ToString();

                            var T = new Producto_Cliente();

                            if (ConsultaID == null)
                            {
                                IdFicticioProCli = IdFicticioProCli + 1;
                                T.ID = IdFicticioProCli;
                            }
                            else
                            {
                                IdFicticioProCli = IdFicticioProCli + 1;
                                T.ID = ConsultaIDProCli.ID + IdFicticioProCli;
                            }
                            T.Producto_ID = ProductoID;
                            T.Cliente_ID = Proveedor;
                            T.Valor = Valor;
                            T.Moneda_ID = Moneda;
                            T.Principal = Principal;

                            hb.Producto_Cliente.Add(T);
                        }
                        hb.SaveChanges();
                        MessageBox.Show("Datos modificados correctamente", "Atención");
                        this.Hide();
                    }

                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarProductoInsumo();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            CargarInsumoProducto();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            EditarProductoInsumo();       
        }
    }
}
