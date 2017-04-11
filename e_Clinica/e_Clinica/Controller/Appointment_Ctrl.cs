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
        /// <summary>
        /// Horarios que ya tienen una cita, para ser eliminados de los disponibles al agendar una cita 
        /// </summary>
        /// <param name="date">Fecha solicitada</param>
        /// <param name="id_doctor">Doctor del cual se van a consultar horarios</param>
        /// <returns></returns>
        public static List<Appointment>ExistentHours(string date, int id_doctor)
        {
            string url = String.Format("/appointment/existent?date={0}&id_doctor={1}", date, id_doctor);
            string res = RESTHelper.Execute(url, "", "GET");
            Appointment_Tr deserialized = JsonConvert.DeserializeObject<Appointment_Tr>(res);
            return deserialized.appointments; 
        }
        /// <summary>
        /// Obtiene las citas agendadas para el día indicado 
        /// </summary>
        /// <param name="date">Día de citas a consultar (hoy)</param>
        /// <param name="id">id de médico</param>
        /// <returns>Cita(nombre_paciente, id, num de cita)</returns>
        public static List<Appointment> GetPacientsAppointments(string date, string id)
        {
            string url = String.Format("/appointment/day?date={0}&id_doctor={1}", date, id);
            string res = RESTHelper.Execute(url, "", "GET");
            Appointment_Tr deserealized = JsonConvert.DeserializeObject<Appointment_Tr>(res);
            return deserealized.appointments;
        }
        //{"appointment":{"date":"2010-02-02 10:00:00","type":"rutina","patient_id":2,"employee_id":5}}
        /// <summary>
        /// Crea un nuevo padecimiento
        /// </summary>
        /// <param name="obj">Objeto padecimiento </param>
        /// return id padecimiento creado 
        public static int CreateAppointment(Appointment obj)
        {
            return 0;
        }
    }
    class Appointment_Tr
    {
        public List<Appointment> appointments { set; get; }
    }
}

