using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class User
    {
        private int _id;

        public int id_user
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string name_user
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _pswd;

        public string pswd_user
        {
            get { return _pswd; }
            set { _pswd = value; }
        }

        private string _level;

        public string level_user
        {
            get { return _level; }
            set { _level = value; }
        }

    }
}
