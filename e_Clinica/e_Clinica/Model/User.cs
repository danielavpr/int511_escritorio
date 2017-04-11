using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class User
    {

        private string _name;
        private string _level;
        private int _id;

        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string level
        {
            get
            {
                return _level;
            }

            set
            {
                _level = value;
            }
        }

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
    }
}
