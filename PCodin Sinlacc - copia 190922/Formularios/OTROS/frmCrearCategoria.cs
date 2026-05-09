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

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmCrearCategoria : Form
    {
        public string PulsoAgregarEditar;
        public string PulsoCategoriaPuestoCiudadConcepto;
        public int IDRecibCategoriaEditarEliminar;
        public frmCrearCategoria()
        {
            InitializeComponent();
        }

        private void frmCrearCategoria_Load(object sender, EventArgs e)
        {
            inicializarForm();
        }
        private void inicializarForm()
        {        
            if (PulsoAgregarEditar == "1") // Crear categoría
            {
                if (PulsoCategoriaPuestoCiudadConcepto == "1")
                {

                    txtCabezal.Text = "Crear rubro";
                    btnCargar.Text = "Crear rubro";
                    MostrarCategorias();
                }
                if (PulsoCategoriaPuestoCiudadConcepto == "2")
                {
                    txtCabezal.Text = "Crear puesto";
                    btnCargar.Text = "Crear puesto";
                    MostrarPuestos();
                }
                if (PulsoCategoriaPuestoCiudadConcepto == "3")
                {
                    txtCabezal.Text = "Crear ciudad";
                    btnCargar.Text = "Crear ciudad";
                    MostrarCiudades();
                }
                if (PulsoCategoriaPuestoCiudadConcepto == "4")
                {
                    txtCabezal.Text = "Crear concepto";
                    btnCargar.Text = "Crear concepto";
                    MostrarConceptos();
                }
            }
            if (PulsoAgregarEditar == "2") // Editar categoría
            {
                using (var hb = new DBdatos())
                {
                    if (PulsoCategoriaPuestoCiudadConcepto == "1")
                    {
                        
                        txtCabezal.Text = "Editar rubro";
                        btnCargar.Text = "Editar rubro";
                        MostrarCategorias();
                    }
                    if (PulsoCategoriaPuestoCiudadConcepto == "2")
                    {
                        var Consulta = (from P in hb.Puestos
                                        where P.ID == IDRecibCategoriaEditarEliminar
                                        select P);

                        var Resultado = Consulta.FirstOrDefault();

                        if (Resultado != null)
                        {
                            txtDescripcion.Text = Resultado.Descripcion;
                            //cmbEstado.Text = Resultado.Estado;
                        }

                        txtCabezal.Text = "Editar puesto";
                        btnCargar.Text = "Editar puesto";
                        MostrarPuestos();
                    }
                    if (PulsoCategoriaPuestoCiudadConcepto == "3")
                    {
                        var Consulta = (from P in hb.Ciudades
                                        where P.ID == IDRecibCategoriaEditarEliminar
                                        select P);

                        var Resultado = Consulta.FirstOrDefault();

                        if (Resultado != null)
                        {
                            txtDescripcion.Text = Resultado.Descripcion;                         
                        }
                        txtCabezal.Text = "Editar ciudad";
                        btnCargar.Text = "Editar ciudad";
                        MostrarCiudades();
                    }
                    if (PulsoCategoriaPuestoCiudadConcepto == "4")
                    {
                        var Consulta = (from P in hb.Tipo_Gasto
                                        where P.ID == IDRecibCategoriaEditarEliminar
                                        select P);

                        var Resultado = Consulta.FirstOrDefault();

                        if (Resultado != null)
                        {
                            txtDescripcion.Text = Resultado.Descripcion;
                        }
                        txtCabezal.Text = "Editar concepto";
                        btnCargar.Text = "Editar concepto";
                        MostrarConceptos();
                    }
                }
            }
        }
        private void MostrarCategorias()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.Categorias_InsPro
                                orderby C.Descripcion
                                select new
                                {
                                    C.ID,
                                    C.Descripcion,
                                    C.Estado
                                });

                if (chkFiltraDescripcion.Checked)
                    Consulta = (from C in Consulta
                                where C.Descripcion.StartsWith(txtFiltraDescripción.Text)
                                || C.Descripcion.Contains(txtFiltraDescripción.Text)
                                select C);

                if (chkFiltraEstado.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Estado == cmbFiltraEstado.Text
                                select C) ;
                }

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colCategoria.HeaderText = "Categoría";
                colCategoria.DataPropertyName = "Descripcion";
                colEstado.DataPropertyName = "Estado";
                colEstado.Visible = true;

                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.DataSource = Resultados;

            }
        }
        private void MostrarPuestos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.Puestos
                                orderby C.Descripcion
                                select new
                                {
                                    C.ID,
                                    C.Descripcion,
                                    C.Estado
                                });

                if (chkFiltraDescripcion.Checked)
                    Consulta = (from C in Consulta
                                where C.Descripcion.StartsWith(txtFiltraDescripción.Text)
                                || C.Descripcion.Contains(txtFiltraDescripción.Text)
                                select C);

                if (chkFiltraEstado.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Estado == cmbFiltraEstado.Text
                                select C);
                }

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colCategoria.HeaderText = "Puesto";
                colCategoria.DataPropertyName = "Descripcion";
                colEstado.DataPropertyName = "Estado";
                colEstado.Visible = true;

                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.DataSource = Resultados;

            }
        }
        private void MostrarCiudades()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.Ciudades
                                orderby C.Descripcion
                                select new
                                {
                                    C.ID,
                                    C.Descripcion,                     
                                    C.Estado
                                });

                if (chkFiltraDescripcion.Checked)
                    Consulta = (from C in Consulta
                                where C.Descripcion.StartsWith(txtFiltraDescripción.Text)
                                || C.Descripcion.Contains(txtFiltraDescripción.Text)
                                select C);            

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colEstado.DataPropertyName = "Estado";
                colCategoria.HeaderText = "Ciudad";
                colCategoria.DataPropertyName = "Descripcion";
                colEstado.Visible = true;

                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.DataSource = Resultados;

            }
        }
        private void MostrarConceptos()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from C in hb.Tipo_Gasto
                                orderby C.Descripcion
                                select new
                                {
                                    C.ID,
                                    C.Descripcion,
                                    C.Estado
                                });

                if (chkFiltraDescripcion.Checked)
                    Consulta = (from C in Consulta
                                where C.Descripcion.StartsWith(txtFiltraDescripción.Text)
                                || C.Descripcion.Contains(txtFiltraDescripción.Text)
                                select C);

                var Resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colEstado.DataPropertyName = "Estado";
                colCategoria.DataPropertyName = "Descripcion";
                colCategoria.HeaderText = "Concepto";
                colEstado.Visible = true;

                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.DataSource = Resultados;
            }
        }
        private void CargarDatos()
        {
            using (var hb = new DBdatos())
            {
                if (PulsoAgregarEditar == "1") // crear
                {
                    if (PulsoCategoriaPuestoCiudadConcepto == "1")
                    {
                        var Consulta = (from C in hb.Categorias_InsPro
                                        where C.Descripcion == txtDescripcion.Text
                                        select C);

                        var Resultado = Consulta.FirstOrDefault();

                        if (Resultado == null)
                        {
                            var i = new Categorias_InsPro();

                            i.Descripcion = txtDescripcion.Text;
                            i.Estado = "SI";

                            hb.Categorias_InsPro.Add(i);
                            hb.SaveChanges();
                            MostrarCategorias();
                            MessageBox.Show("Datos cargardos correctamente", "Atención");
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una categoría con la descripción " + " " + txtDescripcion.Text, "Atención");
                        }

                    }
                    if (PulsoCategoriaPuestoCiudadConcepto == "2")
                    {
                        var Consulta = (from C in hb.Puestos
                                        where C.Descripcion == txtDescripcion.Text
                                        select C);

                        var Resultado = Consulta.FirstOrDefault();

                        if (Resultado == null)
                        {
                            var i = new Puestos();

                            i.Descripcion = txtDescripcion.Text;
                            i.Estado = "SI";

                            hb.Puestos.Add(i);
                            hb.SaveChanges();
                            MostrarPuestos();
                            MessageBox.Show("Datos cargardos correctamente", "Atención");
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un puesto con la descripción " + " " + txtDescripcion.Text, "Atención");
                        }
                    }
                    if (PulsoCategoriaPuestoCiudadConcepto == "3")  // ciudades
                    {
                        var ConsultaID = (from I in hb.Ciudades
                                          orderby I.ID descending
                                          select I).FirstOrDefault();

                        var Consulta = (from C in hb.Ciudades
                                        where C.Descripcion == txtDescripcion.Text
                                        select C);

                        var Resultado = Consulta.FirstOrDefault();

                        if (Resultado == null)
                        {
                            var i = new Ciudades();

                            if (ConsultaID == null)
                                i.ID = 1;
                            else
                                i.ID = ConsultaID.ID + 1;

                            i.Descripcion = txtDescripcion.Text;
                            i.Estado = "SI";
                            hb.Ciudades.Add(i);
                            hb.SaveChanges();

                            MessageBox.Show("Datos cargardos correctamente", "Atención");
                            MostrarCiudades();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una ciudad con la descripción " + " " + txtDescripcion.Text, "Atención");
                        }

                    }
                    if (PulsoCategoriaPuestoCiudadConcepto == "4")  // ciudades
                    {
                        var Consulta = (from C in hb.Tipo_Gasto
                                        where C.Descripcion == txtDescripcion.Text
                                        select C);

                        var Resultado = Consulta.FirstOrDefault();

                        if (Resultado == null)
                        {
                            var i = new Tipo_Gasto();

                            i.Descripcion = txtDescripcion.Text;
                            i.Estado = "SI";
                            hb.Tipo_Gasto.Add(i);
                            hb.SaveChanges();

                            MessageBox.Show("Datos cargardos correctamente", "Atención");
                            MostrarConceptos();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un concepto con la descripción " + " " + txtDescripcion.Text, "Atención");
                        }
                    }
                }
            }
                
        }
        private void EditarCategoria()
        {
            using (var hb = new DBdatos())
            {
                if (PulsoAgregarEditar == "2")
                {
                    if (PulsoCategoriaPuestoCiudadConcepto == "1") // categoría
                    {
                        var ConsultaID = (from C in hb.Categorias_InsPro
                                          where C.ID == IDRecibCategoriaEditarEliminar
                                          select C);

                        var ConsultaDescripcion = (from C in hb.Categorias_InsPro
                                                   where C.Descripcion == txtDescripcion.Text
                                                   select C);

                        var ResultadoEditar = ConsultaID.FirstOrDefault();
                        var ResultadosDescripcion = ConsultaDescripcion.FirstOrDefault();

                        if (ResultadosDescripcion == null) // si no hay ninguna descripcion igual
                        {
                            ResultadoEditar.Descripcion = txtDescripcion.Text;
                            ResultadoEditar.Estado = dgvDatos.CurrentRow.Cells[2].Value.ToString();

                            hb.SaveChanges();
                            MessageBox.Show("Datos modificados correctamente", "Atención");
                            MostrarCategorias();
                        }
                        else if (ResultadosDescripcion.Descripcion == ResultadoEditar.Descripcion /*&& ResultadoEditar.Estado != cmbEstado.Text*/) // Esto es para cambiar solamente el estado
                        {
                            ResultadoEditar.Estado = dgvDatos.CurrentRow.Cells[2].Value.ToString();
                            hb.SaveChanges();
                            MessageBox.Show("Datos modificados correctamente", "Atención");
                            MostrarCategorias();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una categoría con la descripción " + " " + txtDescripcion.Text, "Atención");
                        }
                    }
                    if (PulsoCategoriaPuestoCiudadConcepto == "2") // Puesto
                    {
                        var ConsultaID = (from C in hb.Puestos
                                          where C.ID == IDRecibCategoriaEditarEliminar
                                          select C);

                        var ConsultaDescripcion = (from C in hb.Puestos
                                                   where C.Descripcion == txtDescripcion.Text
                                                   select C);

                        var ResultadoEditar = ConsultaID.FirstOrDefault();
                        var ResultadosDescripcion = ConsultaDescripcion.FirstOrDefault();

                        if (ResultadosDescripcion == null) // si no hay ninguna descripcion igual
                        {
                            ResultadoEditar.Descripcion = txtDescripcion.Text;
                            ResultadoEditar.Estado = dgvDatos.CurrentRow.Cells[2].Value.ToString();

                            hb.SaveChanges();
                            MessageBox.Show("Datos modificados correctamente", "Atención");
                            MostrarPuestos();
                        }
                        else if (ResultadosDescripcion.Descripcion == ResultadoEditar.Descripcion /*&& ResultadoEditar.Estado != cmbEstado.Text*/) // Esto es para cambiar solamente el estado
                        {
                            ResultadoEditar.Estado = dgvDatos.CurrentRow.Cells[2].Value.ToString();
                            hb.SaveChanges();
                            MessageBox.Show("Datos modificados correctamente", "Atención");
                            MostrarPuestos();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un puesto con la descripción " + " " + txtDescripcion.Text, "Atención");
                        }
                    }
                    if (PulsoCategoriaPuestoCiudadConcepto == "3") // Ciudades
                    {
                        var ConsultaID = (from C in hb.Ciudades
                                          where C.ID == IDRecibCategoriaEditarEliminar
                                          select C);

                        var ConsultaDescripcion = (from C in hb.Ciudades
                                                   where C.Descripcion == txtDescripcion.Text
                                                   select C);

                        var ResultadoEditar = ConsultaID.FirstOrDefault();
                        var ResultadosDescripcion = ConsultaDescripcion.FirstOrDefault();

                        if (ResultadosDescripcion == null) // si no hay ninguna descripcion igual
                        {
                            ResultadoEditar.Descripcion = txtDescripcion.Text;                          
                            hb.SaveChanges();
                            MessageBox.Show("Datos modificados correctamente", "Atención");
                            MostrarCiudades();
                        }          
                        else
                        {
                            MessageBox.Show("Ya existe una ciudad con la descripción " + " " + txtDescripcion.Text, "Atención");
                        }
                    }
                    if (PulsoCategoriaPuestoCiudadConcepto == "4") // Puesto
                    {
                        var ConsultaID = (from C in hb.Tipo_Gasto
                                          where C.ID == IDRecibCategoriaEditarEliminar
                                          select C);

                        var ConsultaDescripcion = (from C in hb.Tipo_Gasto
                                                   where C.Descripcion == txtDescripcion.Text
                                                   select C);

                        var ResultadoEditar = ConsultaID.FirstOrDefault();
                        var ResultadosDescripcion = ConsultaDescripcion.FirstOrDefault();

                        if (ResultadosDescripcion == null) // si no hay ninguna descripcion igual
                        {
                            ResultadoEditar.Descripcion = txtDescripcion.Text;
                            hb.SaveChanges();
                            MessageBox.Show("Datos modificados correctamente", "Atención");
                            MostrarConceptos();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un concepto con la descripción " + " " + txtDescripcion.Text, "Atención");
                        }
                    }
                } 
            }
        }
        private void ActivarbtnCargar()
        {
            if(txtDescripcion.TextLength >0)
            {
                btnCargar.Enabled = true;
            }
            else
            {
                btnCargar.Enabled = false;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (PulsoAgregarEditar == "1")
                CargarDatos();
            else
                EditarCategoria();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ActivarbtnCargar();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarbtnCargar();
        }

        private void frmCrearCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void chkFiltraDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiltraDescripcion.Checked)
                txtFiltraDescripción.Enabled = true;
            else
                txtFiltraDescripción.Enabled = false;
        }

        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiltraEstado.Checked)
                cmbFiltraEstado.Enabled = true;
            else
                cmbFiltraEstado.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (PulsoCategoriaPuestoCiudadConcepto == "1")
                MostrarCategorias();
            if (PulsoCategoriaPuestoCiudadConcepto == "2")
                MostrarPuestos();
            if (PulsoCategoriaPuestoCiudadConcepto == "3")
                MostrarCiudades();
            if (PulsoCategoriaPuestoCiudadConcepto == "4")
                MostrarConceptos();
        }
        private void ActivarDesactivarbtnAltaBaja() //Activa los btn del cmb segun estado 
        {
            if(dgvDatos.RowCount > 0)
            {
                if (PulsoCategoriaPuestoCiudadConcepto != "3" && PulsoCategoriaPuestoCiudadConcepto != "4")
                {
                    if (dgvDatos.CurrentRow.Cells[2].Value.ToString() == "SI")
                    {
                        btnActivar.Enabled = false;
                        btnDesactivar.Enabled = true;
                    }
                    else
                    {
                        btnActivar.Enabled = true;
                        btnDesactivar.Enabled = false;
                    }
                }
            }
        }
        private void ActivarDesctivarEstado(string Estado)
        {
            using (var hb = new DBdatos())
            {
                int ID = (int)dgvDatos.CurrentRow.Cells[0].Value;

                if (PulsoCategoriaPuestoCiudadConcepto == "1")
                {                   
                    var ConsultaID = (from C in hb.Categorias_InsPro
                                      where C.ID == ID
                                      select C);

                    var Resultados = ConsultaID.FirstOrDefault();

                    Resultados.Estado = Estado;
                    hb.SaveChanges();
                    MostrarCategorias();
                }
                if (PulsoCategoriaPuestoCiudadConcepto == "2")
                {                   
                    var ConsultaID = (from C in hb.Puestos
                                      where C.ID == ID
                                      select C);

                    var Resultados = ConsultaID.FirstOrDefault();

                    Resultados.Estado = Estado;
                    hb.SaveChanges();
                    MostrarPuestos();
                }
                if (PulsoCategoriaPuestoCiudadConcepto == "3")
                {
                    var ConsultaID = (from C in hb.Ciudades
                                      where C.ID == ID
                                      select C);

                    var Resultados = ConsultaID.FirstOrDefault();

                    Resultados.Estado = Estado;
                    hb.SaveChanges();
                    MostrarCiudades();
                }
                if (PulsoCategoriaPuestoCiudadConcepto == "4")
                {
                    var ConsultaID = (from C in hb.Tipo_Gasto
                                      where C.ID == ID
                                      select C);

                    var Resultados = ConsultaID.FirstOrDefault();

                    Resultados.Estado = Estado;
                    hb.SaveChanges();
                    MostrarConceptos();
                }
            }         
        }
        private void DesactivarEstado()
        {
            dgvDatos.CurrentRow.Cells[2].Value = "NO";
        }
        private void btnActivar_Click(object sender, EventArgs e)
        {
            ActivarDesctivarEstado("SI");
        }
        private void dgvInsumosAsociados_SelectionChanged(object sender, EventArgs e)
        {
            ActivarDesactivarbtnAltaBaja();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            ActivarDesctivarEstado("NO");
        }

        private void txtDescripcion_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }

        private void txtFiltraDescripción_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}

