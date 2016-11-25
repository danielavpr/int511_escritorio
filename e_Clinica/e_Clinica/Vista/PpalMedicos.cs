using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_Clinica.ManejoImagen; 

namespace e_Clinica.Vista
{
    public partial class PpalMedicos : Form
    {
        public PpalMedicos()
        {
            InitializeComponent();
            btnAnalyze.Visible = false;
        }

<<<<<<< HEAD
        private void btnRegExploracion_Click(object sender, EventArgs e)
        {
            
        }

=======
        #region Local Variables
        VideoManager vManager;
        int device = 0; 
        #endregion

        private void PpalMedicos_Load(object sender, EventArgs e)
        {
            vManager = new VideoManager();
            vManager.BuscarDispositivos();
            vManager.pbxCamera = pbxCamera;
            btnTake.Text = vManager.cameraStatus;
            cmbDispositivo.DataSource = vManager.lstDispositivos; 
        }

        #region Camera Managment
        private void btnTake_Click(object sender, EventArgs e)
        {
            vManager.CapturarVideo(0);
            btnTake.Text = vManager.cameraStatus;
            if (btnTake.Text == "Capturar")
                btnAnalyze.Visible = true; 
            else
                btnAnalyze.Visible = false;
        }

        private void cmbDispositivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = cmbDispositivo.SelectedIndex; 
        }
        #endregion


>>>>>>> ffdb44cc436bf2c4ca75caefa1be6d6be8907130
    }
}
