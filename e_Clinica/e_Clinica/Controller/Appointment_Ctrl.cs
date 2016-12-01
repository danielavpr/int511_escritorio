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
    class Appointment_Ctrl
    {
        public static List<Appointment> GetAppointments(string date, string id)
        {
            string url = String.Format("/appointment/day?date={0}&id_doctor={1}", date, id);
            string res = RESTHelper.Execute(url, "", "GET");
            Appointment_Tr deserealized = JsonConvert.DeserializeObject<Appointment_Tr>(res);
            return deserealized.appointments;
        }
    }
    class Appointment_Tr
    {
        public List<Appointment> appointments { set; get; }
    }
}

