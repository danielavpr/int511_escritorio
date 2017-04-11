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
    class Study_Ctrl
    {
       // date, type, diagnosis, result, indications, treatment, id_doctor, id_history
        public void CreateStudy(Study Obj)
        {
            string param = "/study";
            Study_Tr studyTr = new Study_Tr();
            studyTr.study = Obj;
            string json = JsonConvert.SerializeObject(studyTr);
            RESTHelper.PostJSON(param, json);
        }
        
        //	{"treatment":"study","result":"study","indications":"study","id":1,"diagosis":"study","date":"2016-01-11"}
        //list	id_patient	{"studies":[{"id":1, "date":"YYYY-MM-DD", "type":"type"}]}
    }
    public class Study_Tr
    {
        public Study study { set; get; }
    }
}
