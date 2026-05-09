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
using System.IO;
using PCodin_Sinlacc.Clases.UsuarioTema;
using PCodin_Sinlacc.Clases;

namespace PCodin_Sinlacc
{
    public partial class frmGestorPersonal : Form
    {
        public frmGestorPersonal()
        {
            InitializeComponent();
        }
        private frmPantallaEspera PantallaEspera;

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void AbrirFormCrearEditarEmpleado(string EditarCrear , int ID)
        {
            var f = new frmAgregarEmpleado();
            f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmPrueba2_FormClosed);
            AddOwnedForm(f);
            f.TopLevel = false;
           // f.Dock = DockStyle.Fill;
            this.Controls.Add(f);            
            f.PulsoCrearEditarEmpleado = EditarCrear;
            f.StartPosition = FormStartPosition.CenterParent;
            f.IDRecibido = ID;
            this.Tag = f;
            f.BringToFront();
            f.Show();

            
            f.WindowState = FormWindowState.Maximized;
            Clases.Formularios.Inicio.frmMenu.pnlCentral2.Controls.Add(f);
            Clases.Formularios.Inicio.frmMenu.pnlCentral2.Tag = f;
            this.Controls.Add(f);
            this.Tag = f;
            f.BringToFront();
            f.Show();
        }
        private void frmPrueba2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            AbrirFormCrearEditarEmpleado("1",0); // se pone 0 para que no pase ningun ID
        }

        private void frmGestorPersonal_Load(object sender, EventArgs e)
        {
            clsUsuarioTema.UsuarioTema(clsVariablesGenerales.UsuarioID, pnlSuperior, pnlInferior, this);
            cmbFiltraEstado.SelectedIndex = 0; // para que busque automaticamente por estado activo
            MostrarDatosEmpleados();           
        }
        private void MostrarDatosEmpleados()
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from L in hb.Empleados
                                orderby L.Nombre
                                select new
                                {
                                    L.ID,
                                    L.Nombre,                                  
                                    L.Telefono,
                                    L.Fecha_Alta,
                                    L.Fecha_Nacimiento,
                                    L.Documento,
                                    L.Estado,
                                    L.Observaciones,
                                    L.Puestos.Descripcion,
                                    L.Puesto_ID,
                                    Puesto = L.Puestos.Descripcion,
                                    L.Sexo,
                                });

                if (cmbOrdenar.SelectedIndex == 1) // Nombre
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Nombre ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Nombre descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 2) // Puesto
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Puesto ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Puesto descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 3) // Fecha_Nacimiento
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Fecha_Nacimiento ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Fecha_Nacimiento descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 4) // Fecha_Alta
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Fecha_Alta ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Fecha_Alta descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 5) // Estado
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
                if (cmbOrdenar.SelectedIndex == 6) // Estado
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
                if (cmbOrdenar.SelectedIndex == 7) // Estado
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
                if (cmbOrdenar.SelectedIndex == 8) // Documento
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Documento ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Documento descending
                                    select C);
                }
                if (cmbOrdenar.SelectedIndex == 9) // Sexo
                {
                    if (btnBuscarAsc.Visible == true)
                        Consulta = (from C in Consulta
                                    orderby C.Sexo ascending
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    orderby C.Sexo descending
                                    select C);
                }
                if (chkFiltraDescripcion.Checked)
                    Consulta = (from C in Consulta
                                where C.Nombre.StartsWith(txtFiltraDescripcion.Text)
                                select C);

                if (chkFiltraPuesto.Checked)
                    Consulta = (from C in Consulta
                                where C.Puesto_ID == (int)cmbFiltraPuesto.SelectedValue
                                select C);

                if (chkFiltraEstado.Checked)
                    Consulta = (from C in Consulta
                                where C.Estado == cmbFiltraEstado.Text
                                select C);

                if (chkFiltraSexo.Checked)
                    Consulta = (from C in Consulta
                                where C.Sexo == cmbFiltraSexo.Text
                                select C);

                if (rdbFechaNacimiento.Checked)
                {
                    if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                    {
                        Consulta = (from C in Consulta
                                    where C.Fecha_Nacimiento >= dtpFechaDesde.Value.Date
                                    select C);
                    }
                    else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Fecha_Nacimiento <= dtpFechaHasta.Value.Date
                                    select C);
                    }
                    else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Fecha_Nacimiento >= dtpFechaDesde.Value.Date && C.Fecha_Nacimiento <= dtpFechaHasta.Value.Date
                                    select C);
                    }
                }
                if (rdbFechaAlta.Checked)
                {
                    if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                    {
                        Consulta = (from C in Consulta
                                    where C.Fecha_Alta >= dtpFechaDesde.Value.Date
                                    select C);
                    }
                    else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Fecha_Alta <= dtpFechaHasta.Value.Date
                                    select C);
                    }
                    else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Fecha_Alta >= dtpFechaDesde.Value.Date && C.Fecha_Alta <= dtpFechaHasta.Value.Date
                                    select C);
                    }
                }

                var resultados = Consulta.ToList();

                colID.DataPropertyName = "ID";
                colNombre.DataPropertyName = "Nombre";              
                colFechaAlta.DataPropertyName = "Fecha_Alta";
                colFechaNacimiento.DataPropertyName = "Fecha_Nacimiento";
                colDNI.DataPropertyName = "Documento";
                colTelefono.DataPropertyName = "Telefono";
                colPuesto.DataPropertyName = "Descripcion";
                colSexo.DataPropertyName = "Sexo";
                colEstado.DataPropertyName = "Estado";
                colObservaciones.DataPropertyName = "Observaciones";
               // txtCantidadResultados.Text = resultados.Count().ToString();

                dgvEmpleados.AutoGenerateColumns = false;
                dgvEmpleados.DataSource = resultados;               
            }
        }
        private void CargarFichaPersonal()
        {
            DateTime FechaNacimiento = (DateTime)dgvEmpleados.CurrentRow.Cells[3].Value;
            DateTime FechaIngreso = (DateTime)dgvEmpleados.CurrentRow.Cells[4].Value;
            int MesActual = DateTime.Today.Date.Month;
            int AñoActual = DateTime.Today.Date.Year;
            int MesPersona = FechaNacimiento.Date.Month;
            int AñoPersona = FechaNacimiento.Date.Year;
            int AñoIngreso = FechaIngreso.Date.Year;
            int MesIngreso = FechaIngreso.Date.Month;

            txtNombreApeEmp.Text = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();
            if (MesActual < MesPersona)
                txtEdadEmp.Text = (AñoActual - AñoPersona - 1).ToString() + " " + "Años";
            else
                txtEdadEmp.Text = (AñoActual - AñoPersona).ToString();
            if (MesActual > MesIngreso)
            {
                txtAntiguedadEmp.Text = (AñoActual - AñoIngreso).ToString() + " " + "Años" + " " + "Y" + " " + (MesActual - MesIngreso).ToString() + " " + "Meses";
            }
            else if (MesActual < MesIngreso)
            {
                txtAntiguedadEmp.Text = (AñoActual - AñoIngreso - 1).ToString() + " " + "Años" + " " + "Y" + " " + (12 - MesIngreso + MesActual).ToString() + " " + "Meses";
            }
            else if (MesActual == MesIngreso)
            {
                txtAntiguedadEmp.Text = (AñoActual - AñoIngreso).ToString() + " " + "Años";
            }

            txtPuestoEmp.Text = dgvEmpleados.CurrentRow.Cells[2].Value.ToString();

            if (dgvEmpleados.CurrentRow.Cells[5].Value.ToString() == "SI")
                txtEstadoEmp.Text = "Activo";
            else
                txtEstadoEmp.Text = "Inactivo";

            if (txtEstadoEmp.Text == "Activo")
                txtEstadoEmp.ForeColor = Color.Green;
            else
                txtEstadoEmp.ForeColor = Color.Red;

            using (var hb = new DBdatos())
            {
                int ID = (int)dgvEmpleados.CurrentRow.Cells[0].Value;

                var ConsultaFoto = (from F in hb.Empleados
                                    where F.ID == ID
                                    select F);

                var ResuñtadoFoto = ConsultaFoto.FirstOrDefault();

                if (ResuñtadoFoto.Foto != null)
                {
                    var img = hb.Empleados.Find(ResuñtadoFoto.ID);

                    MemoryStream ms = new MemoryStream(img.Foto);
                    Bitmap bit = new Bitmap(ms);

                    picFotoEmp.Image = bit;
                }
                else
                {
                    picFotoEmp.ImageLocation = "C:/Users/franc/Documents/Kacos/Pack-Codin/PCodin Sinlacc/Images/Perfiles/user.png";
                }
            }
        }
        private void EliminarEmpleado()
        {
            DialogResult M = MessageBox.Show("¿Seguro que desea eliminar estos registros?", "Atención", MessageBoxButtons.YesNo);

            if (M == DialogResult.Yes)
            {
                using (var hb = new DBdatos())
                {
                    int ID = (int)dgvEmpleados.CurrentRow.Cells[0].Value;

                    var ConsultaEmpleado = (from E in hb.Empleados  // trae el registro a eliminar de la tabla trazabilidad
                                            where E.ID == ID
                                            select E);

                    // se hacen todas estas consultas para verificar que no haya registros de este empleado en las suiguientes tablas
                    var ConsultaInsumo = (from I in hb.Historial_Insumos
                                          where I.Responsable_ID == ID
                                          select I);

                    var ConsultaExistenciaProductoTerminado = (from I in hb.Existencia_ProductoTerminado
                                                               where I.Empleado_ID == ID
                                                               select I);

                    var ConsultaOrdenProduccion = (from OP in hb.Orden_Produccion1
                                                   where OP.Responsable_ID == ID
                                                   select OP).FirstOrDefault();

                    var ConsultaOrdenProduccionParteCuerpo = (from OP in hb.OrdenProduccionParteCuerpo
                                                              where OP.Responsable_ID == ID
                                                              select OP).FirstOrDefault();

                    var ResultadoEmpleado = ConsultaEmpleado.FirstOrDefault();
                    var ResultadosInsumo = ConsultaInsumo.FirstOrDefault();
                    var ResultadosExistenciaProductoTerminado = ConsultaExistenciaProductoTerminado.FirstOrDefault();

                    if (ResultadosInsumo != null && 
                        ResultadosExistenciaProductoTerminado != null &&
                        ConsultaOrdenProduccion != null &&
                        ConsultaOrdenProduccionParteCuerpo != null)
                    {
                        DialogResult R = MessageBox.Show("El empleado" + " " + ResultadoEmpleado.Nombre + " "  + " " + "tiene movimientos, por lo tanto no se puede eliminar. ¿Desea dar de baja esté empleado?", "Atención", MessageBoxButtons.YesNo);
                        if (R == DialogResult.Yes)
                        {
                            ResultadoEmpleado.Estado = "NO";
                            hb.SaveChanges();
                        }
                    }
                    else
                    {
                        hb.Empleados.Remove(ResultadoEmpleado);
                        hb.SaveChanges();
                        MessageBox.Show("Datos eliminados Correctamente", "Atención");
                        MostrarDatosEmpleados();
                    }
                }
            }
        }
        private void MostrarOcultarFichaPerosnal()
        {
            if (gbxFichaPersonal.Visible)
            {
                gbxFichaPersonal.Visible = false;               
                btnMostrarFicha.Text = "Mostrar ficha personal";
                dgvEmpleados.Size = new Size(1268, 621);
            }
            else
            {
                gbxFichaPersonal.Visible = true;
                btnMostrarFicha.Text = "Ocultar ficha personal";              
                dgvEmpleados.Size = new Size(1268, 445);
            }
        }
        private void frmAgregarEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            MostrarDatosEmpleados();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDatosEmpleados();
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarFichaPersonal();
        }

        private void dgvEmpleados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CargarFichaPersonal();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.RowCount > 0)
                AbrirFormCrearEditarEmpleado("2" , (int)dgvEmpleados.CurrentRow.Cells[0].Value);
        }

        private void dgvEmpleados_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            CargarFichaPersonal();
        }

        private void chkEmpNombre_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraDescripcion, chkFiltraDescripcion);
        }

        private void chkFiltraPuesto_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboPuestos(chkFiltraPuesto , cmbFiltraPuesto);
        }
        private void chkFiltraEstado_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraEstado, cmbFiltraEstado);
        }

        private void chkFultraSexo_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraSexo, cmbFiltraSexo);
        }

        private void chkFechaDesde_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaDesde, dtpFechaDesde);
        }

        private void chkFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaHasta, dtpFechaHasta);
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
        }

        private void btnMostrarFicha_Click(object sender, EventArgs e)
        {
            MostrarOcultarFichaPerosnal();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarEmpleado();
        }

        private void dgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmpleados.RowCount > 0)
                AbrirFormCrearEditarEmpleado("2", (int)dgvEmpleados.CurrentRow.Cells[0].Value);
        }

        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatosEmpleados();
        }

        private void btnBuscarAsc_Click(object sender, EventArgs e)
        {
            Reutilizables.CambiarOrdenacionAscDesc(btnBuscarAsc, btnBuscarDesc);
            MostrarDatosEmpleados();
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.RowCount > 0)
                MostrarDatosEmpleados();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            Reutilizables.ExportarExcel(dgvEmpleados);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarDatosEmpleados();
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarFichaPersonal();
        }

        private void txtFiltraDescripcion_Click(object sender, EventArgs e)
        {
            var txtSeleccionado = sender as TextBox;
            Reutilizables.Teclado(txtSeleccionado);
        }
    }
}
