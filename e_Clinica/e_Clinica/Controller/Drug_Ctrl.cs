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
        /// <summary>
        /// Obtiene todos los medicamentos de base de datos 
        /// </summary>
        /// <returns></returns>
        public static List<Drug> GetDrugs()
        {
            
            string res = RESTHelper.Execute("/drug", "", "GET");
            Drug_Tr deserealized = JsonConvert.DeserializeObject<Drug_Tr>(res);
            List<Drug> lstDrugs = new List<Drug>();
            lstDrugs.AddRange(deserealized.drugs);
            return lstDrugs;
        }
        /// <summary>
        /// Obtiene las medicinas de las que se debe solicitar pedido porque su stock es menor al mínimo solicitado
        /// </summary>
        /// <returns>Lista de medicamentos con stock menor</returns>
        public static List<Drug> GetPending()
        {
            string res = RESTHelper.Execute("/drug/status", "", "GET");
            Drug_Tr deserealized = JsonConvert.DeserializeObject<Drug_Tr>(res);
            List<Drug> lstDrugs = new List<Drug>();
            lstDrugs.AddRange(deserealized.drugs);
            return lstDrugs;
        }
        public static void OrderDrugs(List<Drug> pDrugs)
        {
            string param = "/drug/order";
            Drug_Tr transaction = new Drug_Tr();
            transaction.drugs = pDrugs;
            string json = JsonConvert.SerializeObject(transaction);
            RESTHelper.PostJSON(param, json);
        }
    }
    class Drug_Tr
    {
        public List<Drug> drugs { get; set; }
    }
}
