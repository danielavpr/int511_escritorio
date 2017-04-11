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
        /// <summary>
        /// Retorna todos los pacientes en base de datos
        /// </summary>
        /// <returns>Lista de pacientes</returns>
        public static List<Patient> GetAllPatients()
        {
            Patient objPatient = new Patient();
            string url = String.Format("/patient");
            string res = RESTHelper.Execute(url, "", "GET");
            Patient_Tr deserealized = JsonConvert.DeserializeObject<Patient_Tr>(res);
            return deserealized.patients;
        }
        /// <summary>
        /// Retorna el paciente con el id indicado
        /// </summary>
        /// <param name="id">id de paciente</param>
        /// <returns>Objeto paciente </returns>
        public static Patient GetPatientById(int id)
        {
            Patient objPatient=new Patient();
            string url = String.Format("/patient/{0}",id);
            string res = RESTHelper.Execute(url, "", "GET");
            Patient_Tr deserealized = JsonConvert.DeserializeObject<Patient_Tr>(res);
            return deserealized.patient;
        }
        //	{"patient":{"name":"lalo","last_name":"lalo","date_of_birth":"2010-02-02","address":"calle","phone":"456456","gender":"M","curp":"AAAA000000HAAAAA00","rfc":"AAAA000000000","email":"lalo@lalo.com"}}
        //{"id":1013,"clinical_history_id":4}
        public static void CreatePatient(Patient obj)
        {
            string param = "/patient";
            Patient_Tr pTransaction = new Patient_Tr();
            pTransaction.patient = obj;          
            string json = JsonConvert.SerializeObject(pTransaction);
            string jsonText=RESTHelper.PostJSON(param, json);


            var jss = new JsonSerializer();
           // var des = jss.Deserialize<Dictionary<string, string>>(jsonText);
        }
    }
    class Patient_Tr
    {
        public Patient patient { get; set; }
        public List<Patient> patients { get; set; }
    }
}
