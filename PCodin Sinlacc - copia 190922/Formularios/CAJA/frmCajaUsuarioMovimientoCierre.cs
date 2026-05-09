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

namespace PCodin_Sinlacc.Formularios.CAJA
{
    public partial class frmCajaUsuarioMovimientoCierre : Form
    {
        public frmCajaUsuarioMovimientoCierre()
        {
            InitializeComponent();
        }
        public long CajaUsuarioID;
        public int CajaID;
        private void frmCajaUsuarioMovimientoCierre_Load(object sender, EventArgs e)
        {
            MostraDatos();
        }
        private void MostraDatos()
        {
            try
            {
                using (var hb = new DBdatos())
                {
                    var ConsultaEfectivo = (from C in hb.VistaCajaMovimientosTotales001
                                            where C.CajaID == CajaID
                                            select C).FirstOrDefault();

                    txtEfectivoCaja.Text = ConsultaEfectivo.Efectivo.ToString("N2");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
            
        }
        private void Actualizar()
        {
            if(txtDejoEnCaja.Text != "")
            {
                try
                {
                    decimal EfectivoTotal = Convert.ToDecimal(txtEfectivoCaja.Text);
                    decimal EfectivoDejoEncaja = Convert.ToDecimal(txtDejoEnCaja.Text);
                    if(EfectivoDejoEncaja <= EfectivoTotal)
                    {
                        decimal EfectivoRetirado = EfectivoTotal - EfectivoDejoEncaja;
                        txtEfectivoRetirado.Text = EfectivoRetirado.ToString("N2");
                    }
                    else
                    {
                        MessageBox.Show("El efectivo retirado no puede ser mayor al total de efectivo en caja", "Error");
                        txtDejoEnCaja.Text = "0,00";
                    }
                    
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error"); 
                }
                
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDejoEnCaja.Text != "")
                {
                    using (var hb = new DBdatos())
                    {
                        string PuntoVenta = "";
                        string Numero = "";

                        var Consulta = (from CLI in hb.Clientes
                                        where CLI.Cliente_Usuario == true
                                        select CLI).FirstOrDefault();

                        var ConsultaCajaUsuario = (from CU in hb.CAJAUSUARIO
                                                   where CU.ID == CajaUsuarioID
                                                   select CU).FirstOrDefault();

                        var ConsultaMedioPago = (from MP in hb.MEDIOPAGO
                                                 where MP.Codigo == "EFE"
                                                 select MP).FirstOrDefault();

                        var ConsultaMovimientos = (from M in hb.MOVIMIENTOS
                                                   where M.Codigo == "RETD"
                                                   select M).FirstOrDefault();



                        decimal EfectivoTotal = Convert.ToDecimal(txtEfectivoCaja.Text);
                        decimal EfectivoDejoEncaja = Convert.ToDecimal(txtDejoEnCaja.Text);
                        decimal EfectivoRetirado = 0;

                        if (EfectivoDejoEncaja <= EfectivoTotal)
                        {
                            EfectivoRetirado = EfectivoTotal - EfectivoDejoEncaja;

                            var i = new CAJAMOVIMIENTO();

                            i.CajaUsuario_ID = CajaUsuarioID;
                            i.Cliente_ID = Consulta.ID;
                            i.Estado = "FI";
                            i.Fecha = DateTime.Now.Date;
                            i.Importe = EfectivoRetirado;
                            i.MedioPago_ID = ConsultaMedioPago.ID;
                            i.Modulo_ID = 10;
                            i.Movimiento_ID = ConsultaMovimientos.ID;

                            var ConsultaNumeracion = (from C in hb.CAJAMOVIMIENTO
                                                      orderby C.NumeroComprobante descending
                                                      select C).FirstOrDefault();

                            if (Consulta == null)
                            {
                                PuntoVenta = "0001";
                                Numero = "00000001";
                            }
                            else
                            {
                                long NumeroComprobante = Convert.ToInt64(ConsultaNumeracion.NumeroComprobante.Substring(4, 8));
                                NumeroComprobante = NumeroComprobante + 1;

                                PuntoVenta = ConsultaNumeracion.NumeroComprobante.Substring(0, 4);
                                Numero = NumeroComprobante.ToString("D8");
                            }

                            i.NumeroComprobante = PuntoVenta + Numero;

                            ConsultaCajaUsuario.Estado = "FI";
                            ConsultaCajaUsuario.FechaCierre = DateTime.Now.Date;

                            hb.CAJAMOVIMIENTO.Add(i);
                            hb.SaveChanges();
                            MessageBox.Show("Caja cerrada correctamente", "Error");
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("El efectivo en caja no puede ser mayor al total de efectivo en caja", "Error");
                            //txtDejoEnCaja.Text = "0,00";
                        }
                    }
                }                                 
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void pnlCentral_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
