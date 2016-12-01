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
using e_Clinica.Model;
using e_Clinica.Controller;

namespace e_Clinica.Vista
{
    public partial class PpalMedicos : Form
    {
        public PpalMedicos(User usr)
        {
            InitializeComponent();
            //Usuario que inició sesión 
            activeUser = new User();
            activeUser = usr;
            //Citas del médico con sesión activa
            appointments = new List<Appointment>();
            appointments=Appointment_Ctrl.GetAppointments(DateTime.Today.Date.ToString("yyyy-MM-dd"), activeUser.id.ToString());
            foreach (var item in appointments)
            {
                lstPacientes.Items.Add(item.patient_name);
            }
            //
            //btnAnalyze.Visible = false;
           
        }

        private void btnRegExploracion_Click(object sender, EventArgs e)
        {
            PhysicalExploration objExpl = new PhysicalExploration();
            objExpl.temperature = double.Parse(txtTemperatura.Text);
            objExpl.blood_pressure = double.Parse(txtPresion.Text);
            objExpl.heart_rate = int.Parse(txtFrecuenciaArt.Text);
            objExpl.breathing_rate = int.Parse(txtFrecuenciaResp.Text);
            PhysicalExploration_Ctrl.CreatePhysicalExploration(objExpl, 2);
        }


        #region Global Variables
        User activeUser;
        List<Appointment> appointments;
        Patient objPatient;
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
            lblUsuario.Text = activeUser.name;
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

        private void tbConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPatient = new Patient();
            Appointment objAp = appointments.ElementAt<Appointment>(lstPacientes.SelectedIndex);
            objPatient = Patient_Ctrl.GetPatientById(objAp.patient_id);
            txtNombre.Text = objPatient.name;
            txtApellido.Text = objPatient.last_name;
            txtNacimiento.Text = objPatient.date_of_birth.ToString();
            txtSexo.Text = objPatient.gender;
            txtRFC.Text = objPatient.rfc;
            txtDomicilio.Text = objPatient.address;
            txtCorreo.Text = objPatient.email;
            txtTelefono.Text = objPatient.phone;
        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            tbcDoctores.SelectTab(1);
        }

        private void btnBuscarHist_Click(object sender, EventArgs e)
        {
            objPatient = new Patient();
            objPatient = Patient_Ctrl.GetPatientById(int.Parse(txtHistPaciente.Text));
        }
    }
}
