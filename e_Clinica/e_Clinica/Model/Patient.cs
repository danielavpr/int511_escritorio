using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Patient
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _address;

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _phone;

        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private DateTime _date;

        public DateTime date_of_birth
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _last_name;

        public string last_name
        {
            get { return _last_name; }
            set { _last_name = value; }
        }

        private int _user;

        public int user_id
        {
            get { return _user; }
            set { _user = value; }
        }

        private string _gender;

        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _curp;

        public string curp
        {
            get { return _curp; }
            set { _curp = value; }
        }

        private string _rfc;

        public string rfc
        {
            get { return _rfc; }
            set { _rfc = value; }
        }

        private string _email;

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

    }
}
