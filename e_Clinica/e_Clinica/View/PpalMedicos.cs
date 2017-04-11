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
using e_Clinica.Helpers;

namespace e_Clinica.Vista
{
    public partial class PpalMedicos : Form
    {
        public PpalMedicos(User usr)
        {
            //Patient pt = new Patient();
            InitializeComponent();
            //private Patient actualP{get;set;}
            
            try
            {
                //Usuario que inició sesión 
                activeUser = new User();
                actualPatient = new Patient();
                activeUser = usr;
                //Citas del médico con sesión activa
                appointments = new List<Appointment>();
                appointments = Appointment_Ctrl.GetPacientsAppointments(DateTime.Today.Date.ToString("yyyy-MM-dd"), activeUser.id.ToString());
                foreach (var item in appointments)
                {
                    lstPacientes.Items.Add(item.patient_name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //
            //btnAnalyze.Visible = false;

        }
        #region Global Variables
       
        List<Appointment> appointments;
        Patient actualPatient;
        User activeUser;
        VideoManager vManager;
        int device = 0;
        #endregion
        private void btnRegExploracion_Click(object sender, EventArgs e)
        {
            try {
                PhysicalExploration objExpl = new PhysicalExploration();
                objExpl.temperature = double.Parse(txtTemperatura.Text);
                objExpl.blood_pressure = double.Parse(txtPresion.Text);
                objExpl.heart_rate = int.Parse(txtFrecuenciaArt.Text);
                objExpl.breathing_frec = int.Parse(txtFrecuenciaResp.Text);
                objExpl.clinical_history_id = int.Parse(idHist.ToString());
                objExpl.observations = txtComentarios.Text;
                PhysicalExploration_Ctrl.CreatePhysicalExploration(objExpl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void PpalMedicos_Load(object sender, EventArgs e)
        {
            try
            {
                vManager = new VideoManager();
                vManager.BuscarDispositivos();
                vManager.pbxCamera = pbxCamera;
                btnTake.Text = vManager.cameraStatus;
                cmbDispositivo.DataSource = vManager.lstDispositivos;
                lblUsuario.Text = activeUser.name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            try {
                actualPatient = new Patient();
                Appointment objAp = appointments.ElementAt<Appointment>(lstPacientes.SelectedIndex);
                actualPatient = Patient_Ctrl.GetPatientById(objAp.patient_id);
                txtNombre.Text = actualPatient.name;
                txtApellido.Text = actualPatient.last_name;
                txtNacimiento.Text = actualPatient.date_of_birth.ToString();
                txtSexo.Text = actualPatient.gender;
                txtRFC.Text = actualPatient.rfc;
                txtDomicilio.Text = actualPatient.address;
                txtCorreo.Text = actualPatient.email;
                txtTelefono.Text = actualPatient.phone;
                idHist.Text = actualPatient.clinical_history_id.ToString();           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            tbcDoctores.SelectTab(1);
        }

        private void btnBuscarHist_Click(object sender, EventArgs e)
        {
            try
            {
                ClinicalHistory hist = ClinicalHistory_Ctrl.GetClinicalHistory(int.Parse(txtHistPaciente.Text));
                lblTemp.Text =hist.last_exploration.temperature.ToString();
                lblPresion.Text = hist.last_exploration.blood_pressure.ToString();
                lblFrecResp.Text = hist.last_exploration.breathing_frec.ToString();
                lblFrecCard.Text = hist.last_exploration.heart_rate.ToString();
                lblObservaciones.Text = hist.last_exploration.observations;
                foreach (var item in hist.antecedents)
                {
                    lstAntecedentes.Items.Add(String.Format("{0}: {1}", item.type.ToString(), item.description.ToString()));
                    
                }
                foreach (var item in hist.ailments)
                {
                    lstPacientes.Items.Add(String.Format("Síntoma principal: {0}. ",item.main_symptom));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegPadecimiento_Click(object sender, EventArgs e)
        {
            try
            {
                Ailment objAilment = new Ailment();
                objAilment.main_symptom = txtSintomaPrinc.Text;
                objAilment.date_of_detection = DateTime.Today.ToString("yyyy-MM-dd");
                objAilment.symptom_location = txtLocalizacion.Text;
                objAilment.colateral_symptom = txtSintomaCol.Text;
                objAilment.clinical_history_id = int.Parse(idHist.ToString());
                Ailment_Ctrl.CreateAilment(objAilment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegAnt_Click(object sender, EventArgs e)
        {

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem.ToString() == "patologico")
            {
                string[] patologicas = new string[5] { "Enfermedad crónico-degenerativa", "Alergias", "Intervenciones quirúrgicas", "Transfusiones", "ETS" };
                cmbNombre.Items.AddRange(patologicas);
            }
            else if (cmbTipo.SelectedItem.ToString() == "no patologico")
            {
                string[] noPatologicas = new string[3] { "Consumo de drogas", "Consumo de alcohol", "Consumo de tabaco" };
                cmbNombre.Items.AddRange(noPatologicas);
            }
            else if (cmbTipo.SelectedItem.ToString() == "heredofamiliar")
            {
                string[] heredof = new string[4] { "asma", "diabetes", "cancer", "enfermedad cardiaca" }; cmbNombre.Items.AddRange(heredof);
            }
        }

        private void btnGuardarS_Click(object sender, EventArgs e)
        {
            //date, type, diagnosis, result, indications, treatment, id_doctor, id_history
            Study objStudy = new Study();
            objStudy.id_history = int.Parse(idHist.ToString());
            objStudy.date = DateTime.Today.Date.ToString("yyyy-MM-dd");
            objStudy.diagnosis = txtDiagnostico.Text;
            objStudy.type = "Dermatología";
            objStudy.result = lblResultImg.Text;
            objStudy.indications = txtIndicacion.Text;
            objStudy.treatment = txtTratamiento.Text;
            objStudy.id_doctor = activeUser.id;
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            Filter f = new Filter();
            Image img = pbxCamera.Image;

            img = f.GetBrightness(img);
            img = f.BlurImage(img);
            img = f.GrayScale(img);
            img = f.SobelEdges(img);
            img = f.BlurImage(img);
            img = f.DetectElipse(img);

            pbxAnalizado.Image = img;

            pnlColor.BackColor = f.PredominantColor(pbxCamera.Image);

            lblResultImg.Text = AnalizeImg.AnalizeMole(f._quantity, f._tone, f._elipse); 
        }
    }
}
