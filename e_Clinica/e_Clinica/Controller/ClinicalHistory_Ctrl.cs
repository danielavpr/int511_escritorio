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
    class ClinicalHistory_Ctrl
    {
        //{{"last_exploration":{"temperature":18.0,"observations":null,"heart_rate":17,"breathing_frec":17,"blood_pressure":17.0},"antecedents":[{"type":"patologico ","name":"antecedent","description":"antecedent"}],"ailments":[{"symptom_location":"mucho dolor","main_symptom":"dolor","end_date":"2013-01-11","date_of_detection":"2016-01-29","colateral_symptom":"dolor"}]}
        public static ClinicalHistory GetClinicalHistory(int id)
        {
            string url = String.Format("/history?id_patient={0}", id);
            string res = RESTHelper.Execute(url, "", "GET");
            ClinicalHistory_Tr deserealized = JsonConvert.DeserializeObject<ClinicalHistory_Tr>(res);
            //ClinicalHistory_Tr transaction = new ClinicalHistory_Tr();
            ClinicalHistory History = new ClinicalHistory();
            History.ailments = deserealized.ailments;
            History.last_exploration = deserealized.last_exploration;
            History.antecedents = deserealized.antecedents;
            return History;

        }
    }
    class ClinicalHistory_Tr
    {
        public PhysicalExploration last_exploration { set; get; }        
        public List<Antecedent> antecedents { set; get; }
        public List<Ailment> ailments { set; get; }
    }
}
