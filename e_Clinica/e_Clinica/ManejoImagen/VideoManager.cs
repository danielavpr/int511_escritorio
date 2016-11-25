using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.ManejoImagen
{
    public class VideoManager
    {
        private bool existeCamara;
        private bool activaCaptura = false;

        //private string dispositivoActual = "";
        public List<string> lstDispositivos;
        public Bitmap imgGeneral = null;
        public System.Windows.Forms.PictureBox pbxCamera;
        public string cameraStatus = "Capturar"; 

        private FilterInfoCollection coleccionDispositivos;
        private VideoCaptureDevice capturaVideo = null;

        public void BuscarDispositivos()
        {
            coleccionDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (coleccionDispositivos.Count == 0)
                existeCamara = false;
            else
            {
                existeCamara = true;
                CargaDispositivos(coleccionDispositivos);
            }
        }

        private void CargaDispositivos(FilterInfoCollection dispositivos)
        {
            if (dispositivos.Count > 0)
            {
                lstDispositivos = new List<string>();
                for (int i = 0; i < dispositivos.Count; i++)
                {
                    lstDispositivos.Add(dispositivos[i].Name);
                }
            } 
        }

        public void Video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
            //REcorte
            Crop recorte = new Crop(new Rectangle(0, 50, imagen.Size.Width - 20, imagen.Size.Height - 20));
            //imgGeneral es toda la imagen que captura la camara
            imgGeneral = recorte.Apply(imagen);
            Mirror m = new Mirror(false, true);
            m.ApplyInPlace(imgGeneral); 
            pbxCamera.Image = imgGeneral; 
            //return imgGeneral; 
        }

        public void CapturarVideo(int device)
        {
            if (!activaCaptura)
            {
                if (existeCamara)
                {
                    //Declaración de objeto para el manejo del dispositivo
                    //Y asiganciòn del dispositivo actual 
                    capturaVideo = new VideoCaptureDevice(coleccionDispositivos[device].MonikerString);
                    //Configurando el método que obtiene los frames  
                    capturaVideo.NewFrame += new AForge.Video.NewFrameEventHandler(Video_NuevoFrame);
                    //Obtiene imágenes fijas 
                    capturaVideo.ProvideSnapshots = true;
                    capturaVideo.SnapshotResolution = capturaVideo.VideoCapabilities[capturaVideo.VideoCapabilities.Length - 1];
                    capturaVideo.VideoResolution = capturaVideo.VideoCapabilities[capturaVideo.VideoCapabilities.Length - 1];
                    capturaVideo.Start();
                    activaCaptura = true;
                    cameraStatus = "Detener";
                }
            }
            else
            {
                if (capturaVideo.IsRunning)
                {
                    TerminarCapturaVideo();
                    cameraStatus = "Capturar";
                    activaCaptura = false;
                }
            }
        }

        private void TerminarCapturaVideo()
        {
            if (capturaVideo != null)
            {
                if (capturaVideo.IsRunning)
                {
                    capturaVideo.SignalToStop();
                    capturaVideo = null;
                }
            }
        }
    }
}
