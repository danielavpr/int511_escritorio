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
            string url = String.Format("/login?username={0}&password={1}",usr,pwd);
            string res = RESTHelper.Execute(url,"", "GET");
            User_Tr deserealized = JsonConvert.DeserializeObject<User_Tr>(res);
            return deserealized.user; 
        }
    }
    class User_Tr
    {
        public User user {get;set;}
    }
}
