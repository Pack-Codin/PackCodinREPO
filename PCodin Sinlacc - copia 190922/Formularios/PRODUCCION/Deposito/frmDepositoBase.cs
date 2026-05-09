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

namespace PCodin_Sinlacc.Formularios.Deposito
{
    public partial class frmDepositoBase : Form
    {
        public frmDepositoBase()
        {
            InitializeComponent();
        }

        public string Accion;
        public frmAgregarProdcutoTerminado FormularioAgregar;
        public frmDepositoBase2 FormularioDeposito2;

        private void frmDepositoBase_Load(object sender, EventArgs e)
        {
            IniciabilizarForm();
        }
        public void MostrarDpositos(DataGridView DGV, string Rack,string Piso)
        {
            using (var hb = new DBdatos())
            {
                int Espacio = 8;
                int indiceColumna = 0;

                DGV.Refresh();

                if (DGV.RowCount > 0)
                {
                    DGV.Rows.RemoveAt(0);

                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                    DGV.Columns.RemoveAt(0);
                }

                for (int i = 1; i <= 7; i++)
                {
                    Espacio = Espacio - 1;
                    

                    DataGridViewTextBoxColumn Columna = new DataGridViewTextBoxColumn();
                    Columna.Name = Rack  + "E" + Espacio.ToString() + Piso + "L1";

                    Columna.DefaultCellStyle.BackColor = Color.White;
                    Columna.DefaultCellStyle.SelectionBackColor = Color.White;
                    Columna.DefaultCellStyle.ForeColor = Color.Black;
                    Columna.DefaultCellStyle.SelectionForeColor = Color.Black;
                    Columna.Width = 80;
                    Columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                    DGV.Columns.Add(Columna);

                    DataGridViewTextBoxColumn Columna2 = new DataGridViewTextBoxColumn();
                    Columna2.Name = Rack + "E" + Espacio.ToString() + Piso + "L2";
                    Columna2.DefaultCellStyle.BackColor = Color.White;
                    Columna2.DefaultCellStyle.SelectionBackColor = Color.White;
                    Columna2.DefaultCellStyle.ForeColor = Color.Black;
                    Columna2.DefaultCellStyle.SelectionForeColor = Color.Black;
                    Columna2.Width = 80;
                    Columna2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    DGV.Columns.Add(Columna2);
                }
                
                DataGridViewRow Fila = new DataGridViewRow();

               
                DGV.Rows.Add(Fila);
                int ind = Fila.Index;

                var Consulta = (from D in hb.Existencia_ProductoTerminado
                                where D.Deposito.Contains(Rack)
                                    && D.Deposito.Contains(Piso)
                                    && D.Estado_ID != "ENT"
                                    && D.Estado_ID != "AN"
                                    && D.Deposito != null
                                    && D.Deposito != ""
                                select D);

                if (chkFiltraInsPro.Checked)
                    Consulta = (from C in Consulta
                                where C.Produto_ID == cmbFiltraProducto.SelectedValue.ToString()
                                select C);

                if (chkFiltraProduccion.Checked)
                    Consulta = (from C in Consulta
                                where C.Numero_Produccion == txtFiltraProduccion.Text
                                select C);

                if(chkFiltraRetencion.Checked)
                    Consulta = (from C in Consulta
                                where C.Retencion == cmbFiltraRetencion.Text
                                select C);

                if (chkFiltraRetencion.Checked)
                    Consulta = (from C in Consulta
                                where C.Ficha == cmbFiltraFicha.Text
                                select C);

                if (chkFechaDesde.Checked && chkFechaHasta.Checked == false)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFechaDesde.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked == false && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha <= dtpFechaHasta.Value.Date
                                select C);
                }
                else if (chkFechaDesde.Checked && chkFechaHasta.Checked)
                {
                    Consulta = (from C in Consulta
                                where C.Fecha >= dtpFechaDesde.Value.Date && C.Fecha <= dtpFechaHasta.Value.Date
                                select C);
                }

                var Resultados = Consulta.ToList();

                foreach (var itemDGV in DGV.Columns)
                {
                    //foreach (var item in Resultados.Where(x => x.Deposito == ((DataGridViewColumn)itemDGV).Name))
                    foreach(var item in Resultados)
                    {
                        if (((DataGridViewTextBoxColumn)itemDGV).Name == item.Deposito)
                        {
                            DGV.Rows[Fila.Index].Cells[columnName: ((DataGridViewTextBoxColumn)itemDGV).Name].Value = item.Produto_ID;

                            if (item.Productos_Insumos.Color != null)
                            {
                                DGV.Columns[((DataGridViewTextBoxColumn)itemDGV).Name].DefaultCellStyle.BackColor = Color.FromName(item.Productos_Insumos.Color);
                                DGV.Columns[((DataGridViewTextBoxColumn)itemDGV).Name].DefaultCellStyle.SelectionBackColor = Color.FromName(item.Productos_Insumos.Color);
                                DGV.Columns[((DataGridViewTextBoxColumn)itemDGV).Name].DefaultCellStyle.SelectionForeColor = Color.Black;
                            }
                        }
                        else
                        {
                            //DGV.Rows[Fila.Index].Cells[columnName: ((DataGridViewTextBoxColumn)itemDGV).Name].Value = "";

                            //DGV.Columns[((DataGridViewTextBoxColumn)itemDGV).Name].DefaultCellStyle.BackColor = Color.White;
                            //DGV.Columns[((DataGridViewTextBoxColumn)itemDGV).Name].DefaultCellStyle.SelectionBackColor = Color.White;
                            //DGV.Columns[((DataGridViewTextBoxColumn)itemDGV).Name].DefaultCellStyle.SelectionForeColor = Color.Black;

                          
                        }

                       
                    }
                }



                //}
            }
        }
        private void IniciabilizarForm()
        {
            dtpFechaDesde.Value = DateTime.Now.Date;
            dtpFechaHasta.Value = DateTime.Now.Date;

            //RACK 1
            MostrarDpositos(dgvR1P3, "R1", "P3");
            MostrarDpositos(dgvR1P2, "R1", "P2");
            MostrarDpositos(dgvR1P1, "R1", "P1");

            //RACK 2
            MostrarDpositos(dgvR2P3, "R2", "P3");
            MostrarDpositos(dgvR2P2, "R2", "P2");
            MostrarDpositos(dgvR2P1, "R2", "P1");

            //RACK 3
            MostrarDpositos(dgvR3P3, "R3", "P3");
            MostrarDpositos(dgvR3P2, "R3", "P2");
            MostrarDpositos(dgvR3P1, "R3", "P1");

            //RACK 4
            MostrarDpositos(dgvR4P3, "R4", "P3");
            MostrarDpositos(dgvR4P2, "R4", "P2");
            MostrarDpositos(dgvR4P1, "R4", "P1");

            //RACK 5
            MostrarDpositos(dgvR5P3, "R5", "P3");
            MostrarDpositos(dgvR5P2, "R5", "P2");
            MostrarDpositos(dgvR5P1, "R5", "P1");

            //RACK 6
            MostrarDpositos(dgvR6P3, "R6", "P3");
            MostrarDpositos(dgvR6P2, "R6", "P2");
            MostrarDpositos(dgvR6P1, "R6", "P1");
        }
        
        private void AbriVisorDeposito(string Posicion)
        {
            if (Accion != "Seleccionar")
            {
                var f = new frmVisorDeposito();
                f.Deposito = Posicion;
                f.TopMost = true;
                f.Show();
            }
            else
            {
                using (var hb = new DBdatos())
                {
                    if (Posicion.Length == 8)
                    {
                        FormularioAgregar.cmbRack.Text = Posicion.Remove(2).ToString();
                        FormularioAgregar.cmbEspacio.Text = Posicion.Substring(2, 2);
                        FormularioAgregar.cmbPiso.Text = Posicion.Substring(4, 2);
                        FormularioAgregar.cmbLado.Text = Posicion.Substring(6, 2);
                    }
                    if (Posicion.Length == 9)
                    {
                        FormularioAgregar.cmbRack.Text = Posicion.Remove(2);
                        FormularioAgregar.cmbEspacio.Text = Posicion.Substring(2, 3);
                        FormularioAgregar.cmbPiso.Text = Posicion.Substring(5, 2);
                        FormularioAgregar.cmbLado.Text = Posicion.Substring(7, 2);
                    }

                    this.Hide();
                }
            }
        }

        private void dgvR1P3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);        
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnMostrarfiltros_Click(object sender, EventArgs e)
        {
            Reutilizables.MostrarOcultarFiltros(gbxFiltros, btnMostrarfiltros, lblfiltros);
            btnMostrarfiltros.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            IniciabilizarForm();
        }

        private void chkFiltraInsPro_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboInsPro(chkFiltraInsPro, cmbFiltraProducto, txtBuscarProducto, btnBuscarInsPro, "PRO", "NO");
        }

        private void chkFiltraProduccion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroTexbox(txtFiltraProduccion, chkFiltraProduccion);
            btnMostrarfiltros.Text = "";
        }

        private void chkFiltraRetencion_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraRetencion, cmbFiltraRetencion);
        }

        private void chkFiltraFicha_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroComboSimple(chkFiltraFicha, cmbFiltraFicha);
        }

        private void chkFechaDesde_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaDesde, dtpFechaDesde);
        }

        private void txtBuscaInsPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtBuscarProducto.Visible = false;
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraProducto, txtBuscarProducto, "PRO", true, "NO");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtBuscarProducto.Visible = false;
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void cmbFiltraProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                clsCargarCombos.MostrarComboInsProSinCheck(cmbFiltraProducto, txtBuscarProducto, "PRO", false, "NO");
                txtBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnAbrirSeccion2_Click(object sender, EventArgs e)
        {
            this.Hide();

            var f = new frmDepositoBase2();

            f.FormularioAgregar = FormularioAgregar;
            f.FormularioDeposito = this;
            f.Accion = Accion;
            f.TopMost = true;

            f.Show();
           
        }

        private void dgvR1P2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR1P1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR2P3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR2P2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR2P1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR3P3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR3P2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR3P1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR4P3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR4P2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR4P1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR5P3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR5P2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR5P1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR6P3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR6P2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void dgvR6P1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;

            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
        }

        private void chkFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            Reutilizables.ActivarFiltroDtpFecha(chkFechaHasta, dtpFechaDesde);
        }
    }
}
