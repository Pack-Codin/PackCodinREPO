using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;

namespace PCodin_Sinlacc.Formularios
{
    public partial class frmTestCam : Form
    {
        public frmTestCam()
        {
            InitializeComponent();
        }

        private void frmTestCam_Load(object sender, EventArgs e)
        {
            CargarDisp();
        }
        private bool Haydisp;
        FilterInfoCollection MisDispositivos;
        private VideoCaptureDevice MiCamara;


        private void CargarDisp()
        {
            MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MisDispositivos.Count > 0)
            {
                Haydisp = true;
                for (int i = 0; i < MisDispositivos.Count; i++)
                {
                    comboBox1.Items.Add(MisDispositivos[i].Name.ToString());
                   
                }
                comboBox1.Text = MisDispositivos[0].ToString();
            }
            else
            {
                Haydisp = false;
            }
        }
        private void cerrarCamara()
        {
            if (MiCamara != null && MiCamara.IsRunning)
            {
                MiCamara.SignalToStop();
                MiCamara = null;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarCamara();
                int i = comboBox1.SelectedIndex;
                string NombreVideo = MisDispositivos[i].MonikerString;
                MiCamara = new VideoCaptureDevice(NombreVideo);
                MiCamara.NewFrame += new NewFrameEventHandler(CapturarVideo);
                MiCamara.Start();
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
           

        }
        private void CapturarVideo(object sender , NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = Imagen;
        }

        private void frmTestCam_FormClosed(object sender, FormClosedEventArgs e)
        {
            cerrarCamara();
        }
    }
}
