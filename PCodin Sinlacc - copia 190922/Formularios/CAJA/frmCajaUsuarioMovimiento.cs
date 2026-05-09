using PCodin_Sinlacc.Datos;
using PCodin_Sinlacc.Formularios.Gastos;
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

namespace PCodin_Sinlacc.Formularios.CAJA
{
    public partial class frmCajaUsuarioMovimiento : Form
    {
        public frmCajaUsuarioMovimiento()
        {
            InitializeComponent();
        }
        public long IDRecibido;
        private int CajaID;
        private frmPantallaEspera PantallaEspera = new frmPantallaEspera();
        private frmReporte VisorReporte = new frmReporte();
        private void frmCajaUsuarioMovimiento_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            MostrarTotales();
        }
            
        private void MostrarTotales()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    dgvCajaSaldos.Rows.Clear();

                    string EstadoFormat = string.Empty;

                    var ConsultaCaja = (from C in hb.CAJAUSUARIO
                                        where C.ID == IDRecibido
                                        select C).FirstOrDefault();

                    CajaID = (int)ConsultaCaja.Caja_ID;

                    var ConsultaCajaTotales = (from V in hb.VistaCajaMovimientosTotales001
                                               where V.CajaID == ConsultaCaja.Caja_ID
                                               select V).FirstOrDefault();


                    lblCajaCodigo.Text = ConsultaCaja.CAJA.Codigo;
                    lblCajaDescripcion.Text = ConsultaCaja.CAJA.Descripcion;

                    if (ConsultaCaja.Estado == "FI")
                        lblCajaEstado.Text = "Cerrada";
                    if (ConsultaCaja.Estado == "PEN")
                        lblCajaEstado.Text = "Abierta";

                    if (ConsultaCajaTotales != null)
                    {
                        lblEfectivo.Text = ConsultaCajaTotales.Efectivo.ToString("N2");
                        //dgvCajaSaldos.Rows.Add(ConsultaCajaTotales.Efectivo,
                        //                   ConsultaCajaTotales.Transferencia,
                        //                   ConsultaCajaTotales.Debito,
                        //                   ConsultaCajaTotales.Credito,
                        //                   ConsultaCajaTotales.Cheque
                        //                   );
                    }
                    else
                    {


                        dgvCajaSaldos.Rows.Add(0,
                                               0,
                                               0,
                                               0,
                                               0
                                               );
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }       
        private void MostrarMovimientos()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from C in hb.VistaCajaMovimientos001
                                    where C.CajaUsuarioID == IDRecibido
                                    orderby C.Fecha
                                    select new
                                    {
                                        C.ID,
                                        C.ModuloID,
                                        C.Fecha,
                                        C.Movimiento,
                                        C.MedioPagoID,
                                        C.MedioPago,
                                        C.ClienteID,
                                        C.Cliente,
                                        NumeroComprobante = C.NumeroComprobante.Substring(0, 4) + "-" + C.NumeroComprobante.Substring(4, 11),
                                        C.Importe
                                    });

                    var Resultados = Consulta.Take(1000).ToList();

                    colID.DataPropertyName = "ID";
                    colModuloID.DataPropertyName = "ModuloID";
                    colFecha.DataPropertyName = "Fecha";
                    colMovimiento.DataPropertyName = "Movimiento";
                    colNumeroComprobante.DataPropertyName = "NumeroComprobante";
                    colCliente.DataPropertyName = "Cliente";
                    colImporte.DataPropertyName = "Importe";

                    dgvCajaMovimiento.AutoGenerateColumns = false;
                    dgvCajaMovimiento.DataSource = Resultados;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }
        private void CerrarCaja()
        {
            try
            {
                DialogResult R = MessageBox.Show("Esta seguro que desea cerrar la caja " + lblCajaDescripcion.Text + " - " + lblCajaCodigo.Text, "Atención", MessageBoxButtons.YesNoCancel);
                if (R == DialogResult.Yes)
                {
                    using (var hb = new DBdatos())
                    {
                        var Consulta = (from C in hb.CAJAUSUARIO
                                        where C.ID == IDRecibido
                                        select C).FirstOrDefault();

                        if(Consulta.Estado == "PEN")
                        {
                            var f = new frmCajaUsuarioMovimientoCierre();
                            f.CajaID = CajaID;
                            f.CajaUsuarioID = IDRecibido;
                            f.ShowDialog();
                            //Consulta.Estado = "FI";
                            //hb.SaveChanges();
                            //MessageBox.Show("Caja cerrada correctamente", "Atención");
                            //this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("La caja " + Consulta.CAJA.Descripcion + " ya se esncuentra cerrada", "Error");
                        }                      
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }
        private void AbrirForm(string Accion)
        {
            try
            {
                using (var hb = new DBdatos())
                {                   
                    var ConsultaUsuario = (from U in hb.Usuarios where U.ID == clsVariablesGenerales.UsuarioID select U).FirstOrDefault();

                    var ConsultaValCaja = (from C in hb.CAJAUSUARIO
                                           where C.Usuario_ID == clsVariablesGenerales.UsuarioID
                                                && C.ID == IDRecibido
                                                && C.Estado == "PEN"
                                           select C).FirstOrDefault();

                    if (ConsultaValCaja != null || ConsultaUsuario.AdminCaja == "SI")
                    {
                        var f = new frmAgregarGastos();
                        //f.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmInicioProductoInsumo_FormClosed);
                        f.CrearEditarCopiar = Accion;
                        f.CajaUsuarioID = IDRecibido;
                        f.ModuloID = 10;
                        if (Accion != "1")
                            f.ID = (long)dgvCajaMovimiento.CurrentRow.Cells[0].Value;
                        AddOwnedForm(f);
                        f.TopLevel = false;
                        f.Dock = DockStyle.Fill;
                        this.Controls.Add(f);
                        this.Tag = f;
                        f.BringToFront();
                        f.WindowState = FormWindowState.Maximized;
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("No hay ninguna caja abierta para el usuario o no tiene permisos para utilizarla" + ConsultaUsuario.Nombre + ". Por favor aperture una CAJA para poder cargar movimientos con dicho usuario");
                    }

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarTotales();
            MostrarMovimientos();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            CerrarCaja();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirForm("1");
        }
        private void ListarArqueo()
        {
            try
            {               
                clsQueryInformes.rptCajaArqueo001(VisorReporte, IDRecibido, CajaID);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }
        private void MostrarPantallaEspera()
        {
            PantallaEspera = new frmPantallaEspera();
            VisorReporte = new frmReporte();

            PantallaEspera.Shown += new System.EventHandler(frmPantallaEspera_Shown);
            PantallaEspera.ShowDialog();
        }

        private void frmPantallaEspera_Shown(object sender, EventArgs e)
        {
            ListarArqueo();         
            PantallaEspera.Close();
        }
        private void btnArqueo_Click(object sender, EventArgs e)
        {
            MostrarPantallaEspera();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirForm("2");
        }
    
    }
}
