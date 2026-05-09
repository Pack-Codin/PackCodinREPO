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
using Transitions;
using System.Net;
using System.Net.Mail;
using PCodin_Sinlacc.Clases;
using PCodin_Sinlacc.Formularios.Deposito;
using PCodin_Sinlacc.Formularios;

namespace PCodin_Sinlacc
{
    public partial class frmderueba : Form
    {
        public DataSet1 DS;
        int Pulso = 0;
        private frmDeposito Deposito = new frmDeposito();
        public frmderueba()
        {
            InitializeComponent();
        }

        private void Produccion_Click(object sender, EventArgs e)
        {

        }
        private void EnviarMail()
        {
            string EmailOrigen = "francopeirone@gmail.com";
            string EmailDestino = "camilakacc@gmail.com";
            string Contraseña = "dkgidusravngshtn";
            //string path = @"C:\turuta\burger.png";
            //string path2 = @"C:\turuta\a.jpg";

            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "este es un asunto", "<b>soy texto negro</b>");
            //oMailMessage.Attachments.Add(new Attachment(path));
            //oMailMessage.Attachments.Add(new Attachment(path2));

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpCliente = new SmtpClient("smtp.gmail.com");
            oSmtpCliente.EnableSsl = true;
            oSmtpCliente.UseDefaultCredentials = false;
            oSmtpCliente.Port = 587;
            oSmtpCliente.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

            oSmtpCliente.Send(oMailMessage);

            oSmtpCliente.Dispose();
        }

        private void frmderueba_Load(object sender, EventArgs e)
        {

            using (var hb = new DBdatos())
            {
                var Consulta = (from A in hb.Empleados
                                where A.Estado == "SI"
                                select A).ToList();

                foreach (var item in Consulta)
                {
                    checkedListBox1.Items.Add(item.Nombre + " - " + item.ID);
                }





            }





            //var consulta = (from DT in DS.ListaFormAbiertos
            //                select DT).ToList();

            //foreach(var Form in consulta)
            //{
            //    treeView1.Nodes.Add(Name = Form.Name, text: Form.Text);



            //  //  int LocX = 12;
            //  //  int LocY = 12;

            //  //  Button Boton = new Button();
            //  //  Boton.Location = new Point(LocX, LocY);
            //  //  Boton.Size = new Size(111, 59);
            //  //  Boton.Name = Form.Name;
            //  //  Boton.Text = Form.Text;

            //  //  LocY = LocY + 150;
            //  //  Controls.Add(Boton);
            //  ////  Boton.Click += button_Click;
            //}
            ////private void 

        }

        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            var f = new frmBackup();
            f.ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataSet1 DS2 = new DataSet1();

            //var Consulta = (from D in DS.ListaFormAbiertos
            //                where D.Name == treeView1.SelectedNode.Name
            //                select D).FirstOrDefault();

            //DS2.Tables[name: "FormRestaurar"].Rows.Add
            //        (new object[] {
            //                   Consulta.Form,
            //                   Name,
            //                   Text
            //        });


        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.TreeView.Focus() == true)
            {
                this.Close();
            }

        }

        private void frmderueba_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void MostrarDEposito()
        {
            Deposito.ShowDialog();
        }
        private void Finalizar()
        {
           // pictureBox1.Visible = false;
            Deposito.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        { 

            BackgroundWorker bw = new BackgroundWorker();
           // pictureBox1.Visible = true; //Muestras tu imagen de cargando, por ejemplo, una rueda girando.

            bw.DoWork += (s, args) => MostrarDEposito();

            bw.RunWorkerCompleted += (s, args) => Finalizar();

            if (!bw.IsBusy) //Esto hace que no se choquen los hilos
            {
                bw.RunWorkerAsync();//Ejecutas el contenido del evento DoWork del BackgroundWorker
            }
        }






        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Transition T = new Transition(new TransitionType_EaseInEaseOut(300));
           // T.add(pictureBox1, "Left" , -300);
            T.run();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //EnviarMail();
            clsNotificacion.EnviarMail("francopeirone@gmail.com", "Hola gente");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox7.Text.Replace(",", Environment.NewLine);
        }
    }
}
