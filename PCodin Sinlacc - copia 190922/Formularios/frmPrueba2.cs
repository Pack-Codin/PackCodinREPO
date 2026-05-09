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
using PCodin_Sinlacc.Formularios.Deposito;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmPrueba2 : Form
    {
        public frmPrueba2()
        {
            InitializeComponent();
        }

       public frmPantallaEspera PantallaEspera;

        private void button1_Click(object sender, EventArgs e)
        {
            using (var hb = new DBdatos())
            {
               //// string Ruta = textBox1.Text;

               // //string[] Lineas = File.ReadAllLines(Ruta);

               // foreach(var Linea in Lineas)
               // {
               //     var Valores = Linea.Split(';');

               //     var NombreCliente = Valores[1];

               //     if (NombreCliente != "Descripcion")
               //     {

               //         var Consulta = (from C in hb.Clientes
               //                         where C.Descripcion == NombreCliente
               //                         select C).FirstOrDefault();

               //         if (Consulta == null)
               //         {
               //             var i = new Clientes();

               //             i.Descripcion = Valores[1];
               //             i.Ciudad_ID = Convert.ToInt32(Valores[2]);
               //             i.Estado = Valores[3];
               //             i.Telefono = Valores[4];
               //             i.Email = Valores[5];
               //             i.Observaciones = Valores[6];
               //             i.Cliente_Usuario = false;
               //             i.Tipo = Valores[8];
               //             i.Imagen = null;

               //             hb.Clientes.Add(i);
               //             hb.SaveChanges();
               //             //if (Consulta == null)
               //             //{
               //             //    hb.Database.ExecuteSqlCommand("BULK INSERT Clientes FROM" + " " + Ruta + " " + "WITH(FIELDTERMINATOR = ';',ROWTERMINATOR = '\n', FIRSTROW = 2)");
               //             //    hb.SaveChanges();
               //             //}
               //         }
               //         else
               //         {
               //             MessageBox.Show("El cliente " + NombreCliente + " ya esta cargado");
               //         }
               //     }


               // }


            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //using (var hb = new DBdatos())
            //{
            //    foreach (var control in this.Controls)
            //    {
            //        if (control is Button && ((Button)control).Name != "btnMostrarfiltros")
            //        {
            //            var Consulta = (from D in hb.Existencia_ProductoTerminado
            //                            where D.Deposito == ((Button)control).Name
            //                                && D.Estado_ID == "PEN"
            //                            select D);


            //             var Resultados = Consulta.FirstOrDefault();

            //            if (!chkFiltraInsPro.Checked && !chkFiltraProduccion.Checked && !chkFiltraFicha.Checked && !chkFiltraRetencion.Checked && !chkFechaDesde.Checked && !chkFechaHasta.Checked)
            //            {
            //                if (Resultados != null)
            //                {
            //                    if (Resultados.Productos_Insumos.Color != null)
            //                    {
            //                        ((Button)control).Visible = true;
            //                        ((Button)control).BackColor = Color.FromName(Resultados.Productos_Insumos.Color);
            //                        ((Button)control).Text = Resultados.Produto_ID;
            //                    }
            //                    else
            //                    {
            //                        ((Button)control).Visible = true;
            //                        ((Button)control).BackColor = Color.White;
            //                        ((Button)control).Text = Resultados.Produto_ID;
            //                    }
            //                }
            //                else
            //                    ((Button)control).Visible = true;
            //            }
            //            else
            //            {
            //                if (Resultados != null)
            //                {
            //                    ((Button)control).Visible = true;
            //                    ((Button)control).BackColor = Color.FromName(Resultados.Productos_Insumos.Color);
            //                    ((Button)control).Text = Resultados.Produto_ID;
            //                }
            //                else
            //                    ((Button)control).Visible = false;
            //            }
            //        }
            //    }
            //}
        }
        private static void MostrarDpositos(DataGridView DGV, string Rack , string Piso)
        {
            using (var hb = new DBdatos())
            {
                DataGridViewRow Fila = new DataGridViewRow();

                Fila.CreateCells(DGV);
                DGV.Rows.Add(Fila);
               
                var Consulta = (from D in hb.Existencia_ProductoTerminado
                                where D.Deposito.Contains(Rack)
                                    && D.Deposito.Contains(Piso)
                                    && D.Estado_ID != "FI"
                                    && D.Estado_ID != "AN"
                                select D).ToList();

                foreach (var item in Consulta)
                {
                    foreach (var itemDGV in DGV.Columns)
                    {
                        if (item.Deposito == ((DataGridViewColumn)itemDGV).Name)
                        {
                            DGV.Rows[0].Cells[columnName: ((DataGridViewColumn)itemDGV).Name].Value = item.Produto_ID;

                            if (item.Productos_Insumos.Color != null)
                            {
                                DGV.Columns[((DataGridViewColumn)itemDGV).Name].DefaultCellStyle.BackColor = Color.FromName(item.Productos_Insumos.Color);
                                DGV.Columns[((DataGridViewColumn)itemDGV).Name].DefaultCellStyle.SelectionBackColor = Color.FromName(item.Productos_Insumos.Color);
                                DGV.Columns[((DataGridViewColumn)itemDGV).Name].DefaultCellStyle.SelectionForeColor = Color.Black;
                            }
                        }
                    }
                }
            }
        }
        private void frmPrueba2_Load(object sender, EventArgs e)
        {
            //RACK 1
            MostrarDpositos(dgvR1P3,"R1","P3");
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
            //if (Accion != "Seleccionar")
            //{
                var f = new frmVisorDeposito();
                f.Deposito = Posicion;
                f.TopMost = true;
                f.Show();
            //}
            //else
            //{
            //    using (var hb = new DBdatos())
            //    {                  
            //        if (btn.Name.Length == 8)
            //        {
            //            FormularioAgregar.cmbRack.Text = btn.Name.Remove(2).ToString();
            //            FormularioAgregar.cmbEspacio.Text = btn.Name.Substring(2, 2);
            //            FormularioAgregar.cmbPiso.Text = btn.Name.Substring(4, 2);
            //            FormularioAgregar.cmbLado.Text = btn.Name.Substring(6, 2);
            //        }
            //        if (btn.Name.Length == 9)
            //        {
            //            FormularioAgregar.cmbRack.Text = btn.Name.Remove(2);
            //            FormularioAgregar.cmbEspacio.Text = btn.Name.Substring(2, 3);
            //            FormularioAgregar.cmbPiso.Text = btn.Name.Substring(5, 2);
            //            FormularioAgregar.cmbLado.Text = btn.Name.Substring(7, 2);
            //        }

            //        this.Hide();
            //    }
            //}
        }
        private void dgvR1P3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DGV = sender as DataGridView;
            
            string Posicion = DGV.Columns[e.ColumnIndex].Name;
            AbriVisorDeposito(Posicion);
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

        private void frmPrueba2_Shown(object sender, EventArgs e)
        {
            //PantallaEspera.Hide();
        }

        private void frmPrueba2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void frmPrueba2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //PantallaEspera.Hide();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
