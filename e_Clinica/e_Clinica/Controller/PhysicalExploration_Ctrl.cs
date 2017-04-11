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
    class PhysicalExploration_Ctrl
    {
        public static void CreatePhysicalExploration(PhysicalExploration exploration)
        {
            //{"last_exploration":{"temperature":18.0,"observations":null,"heart_rate":17,"breathing_frec":17,"blood_pressure":17.0}
            //{"exploration":{"temperature":17.0,"blood_pressure":17.0,"heart_rate":17,"breathing_frec":17,"observations":"lalala","clinical_history_id":"1"}}	
            string param = "/exploration";
            PhysicalExploration_Tr transaction= new PhysicalExploration_Tr();
            transaction.exploration = exploration;
            string json = JsonConvert.SerializeObject(transaction);
            RESTHelper.PostJSON(param,json);
        }
    }
    class PhysicalExploration_Tr
    {
        public PhysicalExploration exploration { set; get; }
    }
}
