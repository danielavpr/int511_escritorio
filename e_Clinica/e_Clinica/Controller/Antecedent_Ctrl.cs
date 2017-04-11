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
    class Antecedent_Ctrl
    {
        //{"antecedent":{"name":"lalo","description":"descripcion","type":"heredofamiliar","clinical_history_id":"1"}}  return id
        private void CreateAntecedent(Antecedent pAntecedent)
        {
            string param = "/antecedent";
            Antecedent_Tr transaction = new Antecedent_Tr();
            transaction.antecedent = pAntecedent;
            string json = JsonConvert.SerializeObject(transaction);
            RESTHelper.PostJSON(param, json);
        }
    }
    class Antecedent_Tr
    {
        public Antecedent antecedent { set; get; }
    }
}
