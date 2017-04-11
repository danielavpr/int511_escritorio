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
    class Specialty_Ctrl
    {
        //{"specialties":[{"opening_time":"08:08:08","name":"lalo","id":1,"extension":"hola","description":"hola","cost":18.89999962,"closing_time":"08:08:08"}]}

        /// <summary>
        /// Obtiene las especialidades disponibles 
        /// </summary>
        /// <returns>Objeto especialidad</returns>
        public static List<Specialty> GetSpecialties()
        {
            List<Specialty> lstSpecialties = new List<Specialty>();
            string url = String.Format("/specialty");
            string res = RESTHelper.Execute(url, "", "GET");
            Specialty_Tr deserealized = JsonConvert.DeserializeObject<Specialty_Tr>(res);
            return deserealized.specialties;
        }

    }
    class Specialty_Tr
    {
        public List<Specialty> specialties { set; get; }
    }
}
