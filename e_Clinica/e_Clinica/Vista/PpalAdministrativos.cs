using e_Clinica.Controller;
using e_Clinica.Helpers;
using e_Clinica.Model;
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
            this.activeUser = usr;
            lblUsuario.Text = usr.name;
            List<Drug> lstDrugs = Drug_Ctrl.GetDrugs();
            foreach (var item in lstDrugs)
            {
                lstMedicamentos.Items.Add(item.name);
            }
            //prev = dtHorario.Value;
            //   TimeSpan t = new TimeSpan(9, 0, 0);
            cmbHorarios.Items.AddRange(lstHorarios.ToArray());
        }
        #region VARIABLES GLOBALES 
        User activeUser = new User();
        List<string> lstHorarios = new List<string> {"09:00","09:30","10:00","10:30","11:00" };     
        //private DateTime prev;
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
            //{ "employee":{ "name":"lalo","last_name":"lalo","date_birth":"2010-02-02","gender":"M","curp":"AAAA000000HAAAAA00","rfc":"AAAA000000000","address":"address","email":"lalo@lalo.com","phone":"4777867","profession":"doctor","job":"doctor","specialty_id":1} }
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
            emp.specialty_id = cmbEspecialidad.SelectedIndex+1;
            Employee_Ctrl.CreateEmployee(emp);
        }
    }
}
