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
using System.IO;
using PCodin_Sinlacc.Clases;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmImportarClientes : Form
    {
        public frmImportarClientes()
        {
            InitializeComponent();
        }
        private void SeleccionarArchivo()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // abre el explorador archivos
            {
                txtRuta.Text = openFileDialog1.FileName;
            }
        }
        private void btnElegirRuta_Click(object sender, EventArgs e)
        {
            SeleccionarArchivo();
        }
        private void ImportarDatos()
        {
            int CantidadRegistrosImportados = 0;
            int CantidadErrores = 0;

            if (txtRuta.Text != "")
            {
                dgvErrores.Rows.Clear();

                using (var hb = new DBdatos())
                {
                    string Ruta = "";
                    string[] Lineas;
                    try
                    {
                        Ruta = txtRuta.Text;

                        Lineas = File.ReadAllLines(Ruta);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (var Linea in Lineas)
                    {
                        if (cmbDato.Text == "Productos / Insumos")
                        {
                            var Valores = Linea.Split(';');

                            var CodigoProducto = Valores[0];
                            var NombreProducto = Valores[1];

                            if (CodigoProducto != "Codigo" && NombreProducto != "Descripcion")
                            {
                                var Consulta = (from C in hb.Productos_Insumos
                                                where C.Codigo == CodigoProducto
                                                    || C.Descripcion == NombreProducto
                                                select C).FirstOrDefault();

                                if (Consulta == null)
                                {
                                    //try
                                    //{
                                        if(Valores[0].Trim().ToString() != "")
                                        {
                                            var i = new Productos_Insumos();

                                            i.Codigo = Valores[0];
                                            i.Descripcion = Valores[1];

                                            if (Valores[2] != "")
                                                i.Apodo = Valores[2];
                                            else
                                                i.Apodo = null;

                                            i.Categoria_ID = Convert.ToInt32(Valores[3]);

                                            if (Valores[4] != "")
                                                i.MaxProducción = Convert.ToDecimal(Valores[4]);
                                            else
                                                i.MaxProducción = 0;

                                            if (Valores[5] != "")
                                                i.StockMin = Convert.ToDecimal(Valores[5]);
                                            else
                                                i.StockMin = 0;

                                            i.Ins_Prod = Valores[6];
                                            i.Estado = Valores[7];
                                            i.Medida = Convert.ToInt32(Valores[8]);


                                            if (Valores[9] != "")
                                                i.Responsable_ID = Convert.ToInt32(Valores[9]);
                                            else
                                                i.Responsable_ID = null;

                                            if (Valores[10] != "")
                                                i.Medida2 = Convert.ToInt32(Valores[10]);
                                            else
                                                i.Medida2 = null;

                                            if (Valores[11] != "")
                                                i.Cantidad_Ref = Convert.ToDecimal(Valores[11]);
                                            else
                                                i.Cantidad_Ref = 0;
                                            if (Valores[12] != "")
                                                i.Dias_Produccion = Convert.ToDecimal(Valores[12]);
                                            else
                                                i.Dias_Produccion = null;
                                            if (Valores[13] != "")
                                                i.Produccion_Diaria = Convert.ToDecimal(Valores[13]);
                                            else
                                                i.Produccion_Diaria = null;

                                            if (Valores[14] != "")
                                                i.Demora_Entrega = Convert.ToDecimal(Valores[14]);
                                            else
                                                i.Demora_Entrega = null;
                                            //i.Punto_Pedido = Convert.ToDecimal(Valores[15];
                                            //i.Costo = Valores[16];
                                            if (Valores[17] != "")
                                                i.NotificaPuntoPedido = Valores[17];
                                            else
                                                i.NotificaPuntoPedido = null;

                                            if (Valores[18] != "")
                                                i.Color = Valores[18];
                                            else
                                                i.Color = null;

                                            i.Subproducto = Valores[19];

                                            if(Valores[20].Trim().ToString() != "")
                                            {
                                                var CB = new CODIGOBARRA();

                                                CB.Producto_ID = CodigoProducto;
                                                CB.CodigoBarra1 = Valores[20].ToString();
                                                CB.Estado = "SI";

                                                hb.CODIGOBARRA.Add(CB);
                                            }
                                            
                                            hb.Productos_Insumos.Add(i);
                                            hb.SaveChanges();

                                            CantidadRegistrosImportados = CantidadRegistrosImportados + 1;
                                        }
                                        

                                   // }
                                    //catch (Exception e)
                                    //{
                                    //    string Mensage = "El producto / insumo " + NombreProducto + " - " + CodigoProducto + " No se pudo exportar correctamente. " + e.Message;

                                    //    DataGridViewRow Fila = new DataGridViewRow();

                                    //    Fila.CreateCells(dgvErrores);
                                    //    Fila.Cells[0].Value = Mensage;

                                    //    dgvErrores.Rows.Add(Fila);
                                    //    CantidadErrores = CantidadErrores + 1;
                                    //}
                                }
                                else
                                {
                                    string Mensage = "";

                                    if (Consulta.Codigo == CodigoProducto)
                                        Mensage = "El producto / insumo " + "con código " + "'" + CodigoProducto + "'" + " ya está registrado en la base de datos";
                                    if(Consulta.Descripcion == NombreProducto)
                                        Mensage = "El producto / insumo " + "con descripción " + "'" + NombreProducto + "'" + " ya está registrado en la base de datos";

                                    DataGridViewRow Fila = new DataGridViewRow();

                                    Fila.CreateCells(dgvErrores);
                                    Fila.Cells[0].Value = Mensage;

                                    dgvErrores.Rows.Add(Fila);
                                    CantidadErrores = CantidadErrores + 1;
                                }
                            }
                        }
                        if (cmbDato.Text == "Fórmula")
                        {
                            var Valores = Linea.Split(';');

                            var CodigoProducto = Valores[0];
                            var CodigoInsumo = Valores[1];


                            if (CodigoProducto != "Producto_ID" && CodigoInsumo != "Insumo_ID")
                            {
                                long ID;

                                var ConsultaID = (from I in hb.Formula_Producto
                                                  orderby I.ID descending
                                                  select I).FirstOrDefault();

                                if (ConsultaID == null)
                                    ID = 1;
                                else
                                    ID = ConsultaID.ID + 1;

                                var Consulta = (from C in hb.Formula_Producto
                                                where C.Producto_ID == CodigoProducto
                                                    && C.Insumo_ID == CodigoInsumo
                                                select C).FirstOrDefault();

                                if (Consulta == null)
                                {
                                    try
                                    {
                                        var i = new Formula_Producto();

                                        i.ID = ID;
                                        i.Producto_ID = Valores[0];
                                        i.Insumo_ID = Valores[1];
                                        i.Medida = Convert.ToInt32(Valores[2]);
                                        i.Cantidad = Convert.ToDecimal(Valores[3]);
                                     
                                        hb.Formula_Producto.Add(i);
                                        hb.SaveChanges();

                                        CantidadRegistrosImportados = CantidadRegistrosImportados + 1;

                                    }
                                    catch (Exception e)
                                    {
                                        string Mensage = "La fórrmula " + "Producto = " +CodigoProducto + " / " + "Insumo = " + CodigoInsumo + " No se pudo exportar correctamente. " + e.Message;

                                        DataGridViewRow Fila = new DataGridViewRow();

                                        Fila.CreateCells(dgvErrores);
                                        Fila.Cells[0].Value = Mensage;

                                        dgvErrores.Rows.Add(Fila);
                                        CantidadErrores = CantidadErrores + 1;
                                    }
                                }
                                else
                                {
                                    string Mensage = "";

                                    Mensage = "La fórrmula " + "Producto = " + CodigoProducto + " / " + "Insumo = " + CodigoInsumo + " ya está cargada en la base de datos.";

                                    DataGridViewRow Fila = new DataGridViewRow();

                                    Fila.CreateCells(dgvErrores);
                                    Fila.Cells[0].Value = Mensage;

                                    dgvErrores.Rows.Add(Fila);
                                    CantidadErrores = CantidadErrores + 1;
                                }
                            }
                        }
                        if (cmbDato.Text == "Lista de pecio de productos")
                        {
                            var Valores = Linea.Split(';');

                           

                            var CodigoProducto = Valores[0];
                            var Precio = Valores[1];

                            if (CodigoProducto != "Codigo")
                            {
                                //long ID;

                                //var ConsultaID = (from I in hb.LISTAPRECIOCUERPO
                                //                  orderby I.ID descending
                                //                  select I).FirstOrDefault();

                                //if (ConsultaID == null)
                                //    ID = 1;
                                //else
                                //    ID = ConsultaID.ID + 1;

                                var Consulta = (from C in hb.LISTAPRECIOCUERPO
                                                where C.Articulo_ID == CodigoProducto
                                                select C).FirstOrDefault();

                                if (Consulta != null)
                                {
                                    try
                                    {
                                        Consulta.Precio = Convert.ToDecimal(Precio);
                                        hb.SaveChanges();
                                        //var i = new Producto_Cliente();

                                        //i.ID = Convert.ToInt32(ID);
                                        //i.Producto_ID = Valores[0];
                                        //i.Cliente_ID = Convert.ToInt32(Valores[1]);
                                        //i.Valor = Convert.ToDecimal(Valores[2]);
                                        //i.Moneda_ID = Valores[3];
                                        //i.Principal = "NO";

                                        //hb.Producto_Cliente.Add(i);
                                        //hb.SaveChanges();

                                        CantidadRegistrosImportados = CantidadRegistrosImportados + 1;

                                    }
                                    catch (Exception e)
                                    {                                      
                                        DataGridViewRow Fila = new DataGridViewRow();

                                        Fila.CreateCells(dgvErrores);
                                        Fila.Cells[0].Value = e.Message;

                                        dgvErrores.Rows.Add(Fila);
                                        CantidadErrores = CantidadErrores + 1;
                                    }
                                }
                                else
                                {
                                    string Mensage = "";

                                    Mensage = "El producto " + CodigoProducto + " no esta creado en la base de datos ";

                                    DataGridViewRow Fila = new DataGridViewRow();

                                    Fila.CreateCells(dgvErrores);
                                    Fila.Cells[0].Value = Mensage;

                                    dgvErrores.Rows.Add(Fila);
                                    CantidadErrores = CantidadErrores + 1;
                                }
                            }
                        }
                        if (cmbDato.Text == "Lista de pecio de Insumos / Mercaderia")
                        {
                            var Valores = Linea.Split(';');

                            int ClienteID = 0;
                            var CodigoInsumo = Valores[0];

                            if (Valores[1].ToString() != "Proveedor_ID")
                                ClienteID = Convert.ToInt32(Valores[1]);


                            if (CodigoInsumo != "Insumo_ID")
                            {
                                long ID;

                                var ConsultaID = (from I in hb.Insumo_Proveedor
                                                  orderby I.ID descending
                                                  select I).FirstOrDefault();

                                if (ConsultaID == null)
                                    ID = 1;
                                else
                                    ID = ConsultaID.ID + 1;

                                var Consulta = (from C in hb.Insumo_Proveedor
                                                where C.Insumo_ID == CodigoInsumo
                                                    && C.Proveedor_ID == ClienteID
                                                select C).FirstOrDefault();

                                if (Consulta == null)
                                {
                                    try
                                    {
                                        var i = new Insumo_Proveedor();

                                        i.ID = Convert.ToInt32(ID);
                                        i.Insumo_ID = Valores[0];
                                        i.Proveedor_ID = Convert.ToInt32(Valores[1]);
                                        i.Costo = Convert.ToDecimal(Valores[2]);
                                        i.Proveedor_Principal ="NO";
                                        i.Moneda_ID = Valores[4];

                                        hb.Insumo_Proveedor.Add(i);
                                        hb.SaveChanges();

                                        CantidadRegistrosImportados = CantidadRegistrosImportados + 1;

                                    }
                                    catch (Exception e)
                                    {
                                        string Mensage = "El valor para el insumo " + CodigoInsumo + " para el cliente " + ClienteID + " No se pudo exportar correctamente. " + e.Message;

                                        DataGridViewRow Fila = new DataGridViewRow();

                                        Fila.CreateCells(dgvErrores);
                                        Fila.Cells[0].Value = Mensage;

                                        dgvErrores.Rows.Add(Fila);
                                        CantidadErrores = CantidadErrores + 1;
                                    }
                                }
                                else
                                {
                                    string Mensage = "";

                                    Mensage = "El valor para el insumo " + CodigoInsumo + " para el cliente " + ClienteID + " ya está cargado en la base de datos";

                                    DataGridViewRow Fila = new DataGridViewRow();

                                    Fila.CreateCells(dgvErrores);
                                    Fila.Cells[0].Value = Mensage;

                                    dgvErrores.Rows.Add(Fila);
                                    CantidadErrores = CantidadErrores + 1;
                                }
                            }
                        }
                        if (cmbDato.Text == "Clientes / Proveedores")
                        {
                            var Valores = Linea.Split(';');

                            var NombreCliente = Valores[1];

                            if (NombreCliente != "Descripcion")
                            {

                                var Consulta = (from C in hb.Clientes
                                                where C.Descripcion == NombreCliente
                                                select C).FirstOrDefault();

                                if (Consulta == null)
                                {
                                    try
                                    {
                                        var i = new Clientes();

                                        i.Descripcion = Valores[1];
                                        i.Ciudad_ID = Convert.ToInt32(Valores[2]);
                                        i.Estado = Valores[3];
                                        i.DNI = Valores[4];
                                        i.Telefono = Valores[5];
                                        i.Email = Valores[6];
                                        i.Observaciones = Valores[7];
                                        i.Cliente_Usuario = false;
                                        i.Tipo = Valores[9];
                                        i.Imagen = null;
                                        if (Valores[11] != "")
                                            i.Zona_ID = Convert.ToInt32(Valores[11]);
                                        else
                                            i.Zona_ID = null;

                                        hb.Clientes.Add(i);
                                        hb.SaveChanges();

                                        CantidadRegistrosImportados = CantidadRegistrosImportados + 1;
                                        //if (Consulta == null)
                                        //{
                                        //    hb.Database.ExecuteSqlCommand("BULK INSERT Clientes FROM" + " " + Ruta + " " + "WITH(FIELDTERMINATOR = ';',ROWTERMINATOR = '\n', FIRSTROW = 2)");
                                        //    hb.SaveChanges();
                                    }
                                    catch(Exception e)
                                    {
                                        string Mensage = "El cliente o proveedor " + NombreCliente + " No se pudo exportar correctamente. " + e.Message ;

                                        DataGridViewRow Fila = new DataGridViewRow();

                                        Fila.CreateCells(dgvErrores);
                                        Fila.Cells[0].Value = Mensage;

                                        dgvErrores.Rows.Add(Fila);
                                        CantidadErrores = CantidadErrores + 1;
                                    }
                                }
                                else
                                {
                                    string Mensage = "El cliente o proveedor " + "'" + NombreCliente + "'" + " ya está registrado en la base de datos";

                                    DataGridViewRow Fila = new DataGridViewRow();

                                    Fila.CreateCells(dgvErrores);
                                    Fila.Cells[0].Value = Mensage;

                                    dgvErrores.Rows.Add(Fila);
                                    CantidadErrores = CantidadErrores + 1;
                                }
                            }
                        }
                        if (cmbDato.Text == "Ciudades")
                        {
                            var Valores = Linea.Split(';');

                            var NombreCiudad = Valores[0];

                            if (NombreCiudad != "Descripcion")
                            {
                                var ConsultaID = (from I in hb.Ciudades
                                                  orderby I.ID descending
                                                  select I).FirstOrDefault();

                                var Consulta = (from C in hb.Clientes
                                                where C.Descripcion == NombreCiudad
                                                select C).FirstOrDefault();

                                if (Consulta == null)
                                {
                                    try
                                    {
                                        var i = new Ciudades();

                                        if (ConsultaID == null)
                                            i.ID = 1;
                                        else
                                            i.ID = ConsultaID.ID + 1;

                                        i.Descripcion = Valores[0];                                      
                                        i.Estado = Valores[1];
                                       

                                        hb.Ciudades.Add(i);
                                        hb.SaveChanges();

                                        CantidadRegistrosImportados = CantidadRegistrosImportados + 1;
                                        //if (Consulta == null)
                                        //{
                                        //    hb.Database.ExecuteSqlCommand("BULK INSERT Clientes FROM" + " " + Ruta + " " + "WITH(FIELDTERMINATOR = ';',ROWTERMINATOR = '\n', FIRSTROW = 2)");
                                        //    hb.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        string Mensage = "La ciudad " + NombreCiudad + " No se pudo exportar correctamente. " + e.Message;

                                        DataGridViewRow Fila = new DataGridViewRow();

                                        Fila.CreateCells(dgvErrores);
                                        Fila.Cells[0].Value = Mensage;

                                        dgvErrores.Rows.Add(Fila);
                                        CantidadErrores = CantidadErrores + 1;
                                    }
                                }
                                else
                                {
                                    string Mensage = "La ciudad " + NombreCiudad + " No se pudo exportar correctamente porque ya está registrado en la base de datos";

                                    DataGridViewRow Fila = new DataGridViewRow();

                                    Fila.CreateCells(dgvErrores);
                                    Fila.Cells[0].Value = Mensage;

                                    dgvErrores.Rows.Add(Fila);
                                    CantidadErrores = CantidadErrores + 1;
                                }
                            }
                        }
                    }                  
                }
                txtArchvosImportados.Text = CantidadRegistrosImportados.ToString();
                txtErrores.Text = CantidadErrores.ToString();
                txtTotal.Text = (CantidadErrores + CantidadRegistrosImportados).ToString();
            }
            else
            {
                MessageBox.Show("No selecciono archivo", "Atención");
            }
        }

        private void frmImportarClientes_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            clsCargarCombos.MostrarModulo(cmbModulo);
            cmbModulo.SelectedIndex = -1;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            ImportarDatos();
        }

        private void txtRuta_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbModulo.SelectedValue != null)
            {
                if(cmbModulo.SelectedValue.Equals(1)) // MATERIALES
                {
                    cmbDato.Items.Clear();

                    cmbDato.Items.Add("Productos / Insumos");
                    cmbDato.Items.Add("Fórmula");
                    cmbDato.Items.Add("Lista de pecio de productos");
                    cmbDato.Items.Add("Lista de pecio de Insumos / Mercaderia");               
                }
                if(cmbModulo.SelectedValue.Equals(3)) //HUMANO
                {
                    cmbDato.Items.Clear();

                    cmbDato.Items.Add("Clientes / Proveedores");
                    cmbDato.Items.Add("Empleados");
                    cmbDato.Items.Add("Ciudades");
                }
            }
        }
    }
}
