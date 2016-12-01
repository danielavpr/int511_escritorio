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
    class Drug_Ctrl
    {
        public static List<Drug> GetDrugs()
        {
            
            string res = RESTHelper.Execute("/drug", "", "GET");
            Drug_Tr deserealized = JsonConvert.DeserializeObject<Drug_Tr>(res);
            List<Drug> lstDrugs = new List<Drug>();
            lstDrugs.AddRange(deserealized.drugs);
            return lstDrugs;
        }
    }
    class Drug_Tr
    {
        public List<Drug> drugs { get; set; }
    }
}
