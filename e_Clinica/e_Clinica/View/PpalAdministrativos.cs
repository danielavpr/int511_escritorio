using e_Clinica.Controller;
using e_Clinica.Helpers;
using e_Clinica.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Clinica.Vista
{
    public partial class PpalAdministrativos : Form
    {
        public PpalAdministrativos(User usr)
        {
            InitializeComponent();
            #region ACCIONES AL CARGAR LA PANTALLA 
            //Información de usuario
            this.activeUser = usr;
            lblUsuario.Text = usr.name;
            //Mensaje con medicamentos pendientes 
            GetPendingDrugs();
            //Obtener todos los medicamentos 
            AllDrugs = new List<Drug>();
            AllDrugs = Drug_Ctrl.GetDrugs();
            foreach (var item in AllDrugs)
            {
                lstMedicamentos.Items.Add(item.name);
            }
            //Obtener especialidades
            List<Specialty> lstSpecialties = new List<Specialty>();
            lstSpecialties = Specialty_Ctrl.GetSpecialties();
            foreach (var item in lstSpecialties)
            {
                cmbEspecialidad.Items.Add(item.name);
            }
            //Valor mínimo para el calendario de citas 
            mcCalRegistro.MinDate = DateTime.Today;
            #endregion

        }
        #region VARIABLES GLOBALES 
        User activeUser = new User();
        List<string> lstHorarios = new List<string> { "09:00:00", "10:00:00", "11:00:00", "12:00:00", "13:00:00", "14:00:00", "15:00:00", "16:00:00", "17:00:00", "18:00:00", "19:00:00" };
        List<Drug> AllDrugs;
        List<Employee> doctors;
        List<Drug> drugsOrder=new List<Drug>();
        double total = 0;
        #endregion
        #region ACCIONES AL CARGAR LA PANTALLA
        static void GetPendingDrugs()
        {
            List<Drug> PendingDrugs = Drug_Ctrl.GetPending();
            string pDrugs = "";
            foreach (var item in PendingDrugs)
            {
                pDrugs += item.name + ". ";
            }
            MessageBox.Show(String.Format("Medicamentos faltantes: {0} Ir al apartado de medicamentos para realizar pedido.", pDrugs));

        }
        #endregion
        private void dtHorario_ValueChanged(object sender, EventArgs e)
        {
            //DateTime dt = dtHorario.Value;
            //if ((dt.Minute * 60 + dt.Second) % 300 != 0)
            //{
            //    TimeSpan diff = dt - prev;
            //    if (diff.Ticks < 0) dtHorario.Value = prev.AddMinutes(-30);
            //    else dtHorario.Value = prev.AddMinutes(30);
            //}
            //prev = dtHorario.Value;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            bool createUsr = false;
            try {
                //{ "employee":{ "name":"lalo","last_name":"lalo","date_birth":"2010-02-02","gender":"M","curp":"AAAA000000HAAAAA00","rfc":"AAAA000000000","address":"address","email":"lalo@lalo.com","phone":"4777867","profession":"doctor","job":"doctor","specialty_id":1} }
                if (txtNombrePer.Text != "" && txtPrApellidoPer.Text != "" && txtSegApellidoPer.Text != "" && txtFechaNacPer.Text != "" && cmbSexoPer.SelectedIndex >= 0 && txtCURPPers.Text != "" && txtRFCPer.Text != "" && txtDomicilioPers.Text != "" && txtCorreoPers.Text != "" && txtTelefonoPer.Text != "" && cmbNivelEducativo.SelectedIndex >= 0 && cmbPuesto.SelectedIndex >= 0 && cmbEspecialidad.SelectedIndex >= 0 && txtUsuarioEmp.Text != "" && txtPasswordEmp.Text != "")
                {
                    Employee emp = new Employee();
                    emp.name = txtNombrePer.Text;
                    emp.last_name = String.Format("{0} {1}", txtPrApellidoPer.Text, txtSegApellidoPer.Text);
                    emp.date_birth = txtFechaNacPer.Text;
                    emp.gender = cmbSexoPer.SelectedItem.ToString();
                    emp.curp = txtCURPPers.Text;
                    emp.rfc = txtRFCPer.Text;
                    emp.address = txtDomicilioPers.Text;
                    emp.email = txtCorreoPers.Text;
                    emp.phone = txtTelefonoPer.Text;
                    emp.profession = cmbNivelEducativo.SelectedItem.ToString();
                    emp.job = cmbPuesto.SelectedItem.ToString();
                    emp.specialty_id = cmbEspecialidad.SelectedIndex + 1;
                    string ret = Employee_Ctrl.CreateEmployee(emp);
                    if (ret != null)
                    {
                        var def = JObject.Parse(ret);
                        var usr = def.GetValue("id");
                        mensaje += "El empleado se ha creado exitosamente con el id: " + usr;
                        if (cmbPuesto.SelectedItem.ToString() == "doctor") createUsr = User_Ctrl.CreateDoctorUsr((int)usr, txtUsuarioEmp.Text, txtPasswordEmp.Text);
                        else if (cmbPuesto.SelectedItem.ToString() == "adm") createUsr = User_Ctrl.CreateAdminUsr((int)usr, txtUsuarioEmp.Text, txtPasswordEmp.Text);
                        if (createUsr)
                            mensaje += " .El usuario se ha creado exitosamente.";
                    }
                    MessageBox.Show(mensaje);
                }
                else
                {
                    MessageBox.Show("Debe ingresar todos los campos");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al guardar los datos");
            }
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //	{"patient":{"name":"lalo","last_name":"lalo","date_of_birth":"2010-02-02","address":"calle","phone":"456456","gender":"M","curp":"AAAA000000HAAAAA00","rfc":"AAAA000000000","email":"lalo@lalo.com"}}
            Patient pat = new Patient();
            pat.name = txtNombrePa.Text;
            pat.last_name = txtPrApellidoPa.Text + " " + txtSegApellidoPa.Text;
            pat.date_of_birth = txtFechaNacPa.Text;
            pat.address = txtDomicilioPa.Text;
            pat.phone = txtTelefonoPa.Text;
            pat.gender = cmbSexoPa.SelectedItem.ToString();
            pat.curp = txtCURPPa.Text;
            pat.rfc = txtRFCPa.Text;
            pat.email = txtCorreoPa.Text;
            Patient_Ctrl.CreatePatient(pat);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            List<Patient> allPatients = new List<Patient>();
            try
            {
                if (txtPaciente.Text == "")
                {
                    allPatients = Patient_Ctrl.GetAllPatients();
                    foreach (var item in allPatients)
                    {
                        lstPacientes.Items.Add(item.name + " " + item.last_name);
                    }
                }
                else
                {
                    patient = Patient_Ctrl.GetPatientById(int.Parse(txtPaciente.Text));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error en la búsqueda de los pacientes");
            }
        }

        private void cmbEsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                doctors = Employee_Ctrl.GetDoctorBySpecialty(cmbEsp.SelectedIndex + 1);
                foreach (var item in doctors)
                {
                    cmbDoct.Items.Add(item.name);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error al traer los médicos");
            }
        }

        private void cmbDoct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mcCalRegistro_DateChanged(object sender, DateRangeEventArgs e)
        {
            List<string> available = lstHorarios;
            List<Appointment> aux = new List<Appointment>();
            aux = Appointment_Ctrl.ExistentHours(DateTime.Today.Date.ToString("yyyy-MM-dd"),doctors[cmbDoct.SelectedIndex].id);
        }

        private void lstMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNombreMed.Text = lstMedicamentos.SelectedItem.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            Drug drug = new Drug();
            drug.name = lblNombreMed.Text;
            drug.quantity = nCantidad.Value.ToString();          
            drugsOrder.Add(drug);
            lstPedido.Items.Add(String.Format("nombre: {0}   cantidad: {1}   precio: {2}   subtotal: {3}", AllDrugs[lstMedicamentos.SelectedIndex].name, nCantidad.Value, AllDrugs[lstMedicamentos.SelectedIndex].price, AllDrugs[lstMedicamentos.SelectedIndex].price*(int)nCantidad.Value));
            total+= (AllDrugs[lstMedicamentos.SelectedIndex].price * (int)nCantidad.Value);
            lblTotal.Text = "$ " + total;
        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            Drug_Ctrl.OrderDrugs(drugsOrder);
        }
    }
}
