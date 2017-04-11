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
        /// <summary>
        /// Crea un empleado 
        /// </summary>
        /// <param name="emp">Objeto empleado</param>
        public static string CreateEmployee(Employee emp)
        {
            //{ "employee":{ "name":"lalo","last_name":"lalo","date_birth":"2010-02-02","gender":"M","curp":"AAAA000000HAAAAA00","rfc":"AAAA000000000","address":"address","email":"lalo@lalo.com","phone":"4777867","profession":"doctor","job":"doctor","specialty_id":1} }
            string param = "/employee";
            Employe_Tr empTr = new Employe_Tr();
            empTr.employee = emp;
            //string json = String.Format("{ \"employee\":{ \"name\":\"{0}\",\"last_name\":\"{1}\",\"date_birth\":\"{2}\",\"gender\":\"{3}\",\"curp\":\"{4}\",\"rfc\":\"{5}\",\"address\":\"{6}\",\"email\":\"{7}\",\"phone\":\"{8}\",\"profession\":\"{9}\",\"job\":\"{10}\",\"specialty_id\":{11}} }", emp.name, emp.last_name, emp.date_birth, emp.gender, emp.curp, emp.rfc, emp.address, emp.email, emp.phone, emp.profession, emp.job, emp.specialty_id.ToString());
            string json = JsonConvert.SerializeObject(empTr);
            string resp=RESTHelper.PostJSON(param, json);
            return resp;
        }
        /// <summary>
        /// Obtiene todos los doctores
        /// </summary>
        /// <returns></returns>
        public static List<Employee> GetAllDoctors()
        {
            return null;
        }
        /// <summary>
        /// Obtiene los doctores filtrados por su especialidad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Employee> GetDoctorBySpecialty(int id)
        {
            string url = String.Format("/specialty/{0}/doctors", id);
            string res = RESTHelper.Execute(url, "", "GET");
            Employe_Tr deserealized = JsonConvert.DeserializeObject<Employe_Tr>(res);
            return deserealized.doctors;
        }
        //GET /doctor
        //	NULL	{"doctors":[{"specialty":"lalo","name":"hola","id":5}]}

    }
    class Employe_Tr
    {
        public Employee employee { set; get; }
        public List<Employee> doctors { set; get; }
    }
}
