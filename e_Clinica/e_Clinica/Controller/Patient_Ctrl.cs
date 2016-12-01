using e_Clinica.Helpers;
using e_Clinica.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Controller
{
    class Patient_Ctrl
    {
        public static Patient GetPatientById(int id)
        {
            Patient objPatient=new Patient();
            string url = String.Format("/patient/{0}",id);
            string res = RESTHelper.Execute(url, "", "GET");
            Patient_Tr deserealized = JsonConvert.DeserializeObject<Patient_Tr>(res);
            return deserealized.patient;
        }
    }
    class Patient_Tr
    {
        public Patient patient { get; set; }
    }
}
