using Microsoft.Office.Interop.Excel;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCodin_Sinlacc.Formularios.CAJA
{
    public partial class frmCajaUsuarioAgregar : Form
    {
        public frmCajaUsuarioAgregar()
        {
            InitializeComponent();
        }

        private void frmCajaUsuarioAgregar_Load(object sender, EventArgs e)
        {
            InicializarForm();
        }
        private void InicializarForm()
        {
            try
            {
                clsCargarCombos.MostrarComboUsuarios(cmbUsuario);
                clsCargarCombos.MostrarComboCaja(cmbCaja);
                cmbCaja.SelectedIndex = -1;
                cmbUsuario.SelectedIndex = -1;
                dtpFechaApertura.Value = DateTime.Now.Date;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
            
        }
        private void CargarDatos()
        {
            try
            {
                if (cmbCaja.SelectedIndex != -1 && cmbUsuario.SelectedIndex != -1)
                {
                    using (var hb = new DBdatos())
                    {
                        //VALIDA QUE NO HAYA UNA MISMA CAJA ABIERTA
                        var ConsultaVal = (from V in hb.CAJAUSUARIO
                                           where V.Caja_ID == (int)cmbCaja.SelectedValue
                                            && V.Estado == "PEN"
                                           select V).FirstOrDefault();

                        //BUSCA LA ULTIMA CAJA FINALIZADA PARA OBTENERLE EL SALDO
                        var ConsultaVal2 = (from V2 in hb.CAJAUSUARIO
                                            where V2.Caja_ID == (int)cmbCaja.SelectedValue
                                             && V2.Estado == "FI"
                                            orderby V2.ID descending
                                            select V2).FirstOrDefault();

                        if (ConsultaVal == null)
                        {
                            var i = new CAJAUSUARIO();

                            i.Caja_ID = (int)cmbCaja.SelectedValue;
                            i.FechaApertura = dtpFechaApertura.Value;
                            i.Usuario_ID = (int)cmbUsuario.SelectedValue;
                            i.Estado = "PEN";
                            
                            if(ConsultaVal2 == null)
                            {
                                i.Efectivo = 0;
                                i.Debito = 0;
                                i.Transferencia = 0;
                                i.Retirado = 0;
                                i.Cheque = 0;
                                i.Debito = 0;
                                i.Ingresado = 0;
                                i.Saldo = 0;
                            }
                            else
                            {
                                i.Efectivo = ConsultaVal2.Efectivo;
                                i.Debito = ConsultaVal2.Debito;
                                i.Transferencia = ConsultaVal2.Transferencia;
                                i.Retirado = ConsultaVal2.Retirado;
                                i.Cheque = ConsultaVal2.Cheque;                               
                                i.Ingresado = ConsultaVal2.Ingresado;
                                i.Saldo = ConsultaVal2.Saldo;
                            }
                            hb.CAJAUSUARIO.Add(i);
                            hb.SaveChanges();
                            MessageBox.Show("Caja aperturada correctamente", "Atencion");
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una sesion de caja abierta para " + ConsultaVal.CAJA.Descripcion, "Atencion");
                        }
                    }
                }
                else
                {
                    if(cmbCaja.SelectedIndex == -1)
                        MessageBox.Show("No selecciono caja", "Error");
                    if (cmbUsuario.SelectedIndex == -1)
                        MessageBox.Show("No selecciono usuario", "Error");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
