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
    class Ailment_Ctrl
    {
        //{"ailment":{"main_symptom":"enfermo","date_of_detection":"2016-02-02","symptom_location":"brazo","colateral_symptom":"enfermo","clinical_history_id":1}} return id 
        /// <summary>
        /// Crea un nuevo padecimiento 
        /// </summary>
        /// <param name=""></param>
        public static int CreateAilment(Ailment pAilment)
        {
            string param = "/ailment";
            Ailment_Tr transaction = new Ailment_Tr();
            transaction.ailment = pAilment;
            string json = JsonConvert.SerializeObject(transaction);
            RESTHelper.PostJSON(param, json);
            return 0; 
        }
    }
    class Ailment_Tr
    {
        public Ailment ailment { set; get; }
    }
}
