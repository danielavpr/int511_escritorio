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
    class Employee_Ctrl
    {
        public static void CreateEmployee(Employee emp)
        {
            //{ "employee":{ "name":"lalo","last_name":"lalo","date_birth":"2010-02-02","gender":"M","curp":"AAAA000000HAAAAA00","rfc":"AAAA000000000","address":"address","email":"lalo@lalo.com","phone":"4777867","profession":"doctor","job":"doctor","specialty_id":1} }
            string param = "/employee";
            Employe_Tr empTr = new Employe_Tr();
            empTr.employee = emp;
            //string json = String.Format("{ \"employee\":{ \"name\":\"{0}\",\"last_name\":\"{1}\",\"date_birth\":\"{2}\",\"gender\":\"{3}\",\"curp\":\"{4}\",\"rfc\":\"{5}\",\"address\":\"{6}\",\"email\":\"{7}\",\"phone\":\"{8}\",\"profession\":\"{9}\",\"job\":\"{10}\",\"specialty_id\":{11}} }", emp.name, emp.last_name, emp.date_birth, emp.gender, emp.curp, emp.rfc, emp.address, emp.email, emp.phone, emp.profession, emp.job, emp.specialty_id.ToString());
            string json = JsonConvert.SerializeObject(empTr);
            RESTHelper.PostJSON(param, json);
        }
    }
    class Employe_Tr
    {
        public Employee employee { set; get; }
    }
}
