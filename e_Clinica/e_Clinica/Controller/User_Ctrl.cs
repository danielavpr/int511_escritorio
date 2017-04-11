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
    class User_Ctrl
    {
        public static User LogIn(string usr, string pwd)
        {
            string url = String.Format("/login?username={0}&password={1}", usr, pwd);
            string res = RESTHelper.Execute(url, "", "GET");
            User_Tr deserealized = JsonConvert.DeserializeObject<User_Tr>(res);
            return deserealized.user;
        }
        public static bool CreatePatientUsr(int id, string username, string password)           
        {
            //id_patient, username, password 
            return false;
        }
        public static bool CreateDoctorUsr(int id, string username, string password)
        {
            //id_doctor, username, password 
            string param = String.Format("/doctor/user");
            DoctorUsr usr = new DoctorUsr();
            usr.id_doctor = id;
            usr.username = username;
            usr.password = password;
            string json = JsonConvert.SerializeObject(usr);
            RESTHelper.PostJSON(param, json);
            return false;
        }
        public static bool CreateAdminUsr(int id, string username, string password)
        {
            //id_admin, username, password 
            string param = String.Format("/administrative/user");
            AdminUsr usr = new AdminUsr();
            usr.id_admin = id;
            usr.username = username;
            usr.password = password;
            string json = JsonConvert.SerializeObject(usr);
            RESTHelper.PostJSON(param, json);
            return false;
        }
    }

class User_Tr
{
    public User user { get; set; }
}
class PatientUsr
    {
        public int id_patient { set; get; }
        public string username { set; get; }
        public string password { set; get; }
    }
    class DoctorUsr
    {
        public int id_doctor { set; get; }
        public string username { set; get; }
        public string password { set; get; }
    }
    class AdminUsr
    {
        public int id_admin { set; get; }
        public string username { set; get; }
        public string password { set; get; }
    }
}
