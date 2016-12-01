using e_Clinica.Helpers;
using e_Clinica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Controller
{
    class PhysicalExploration_Ctrl
    {
        public static void CreatePhysicalExploration(PhysicalExploration exploration, int idHist)
        {
            //{"last_exploration":{"temperature":18.0,"observations":null,"heart_rate":17,"breathing_frec":17,"blood_pressure":17.0} 
            string param = "/exploration";
            string json = "";
            RESTHelper.PostJSON(param,json);
        }
    }
    class PhysicalExploration_Tr
    {

    }
}
