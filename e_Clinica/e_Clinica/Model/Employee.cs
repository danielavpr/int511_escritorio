using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Employee
    {
        private int _id;

        public int id_emp
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string name_emp
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _address;

        public string address_emp
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _phone;

        public string phone_emp
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private DateTime _date;

        public DateTime date_birth_emp
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _last_name;

        public string last_name_emp
        {
            get { return _last_name; }
            set { _last_name = value; }
        }

        private int _user;

        public int user_emp
        {
            get { return _user; }
            set { _user = value; }
        }

        private string _gender;

        public string gender_emp
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _curp;

        public string curp_emp
        {
            get { return _curp; }
            set { _curp = value; }
        }

        private string _rfc;

        public string rfc_emp
        {
            get { return _rfc; }
            set { _rfc = value; }
        }

        private string _email;

        public string email_emp
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _profession;

        public string profession
        {
            get { return _profession; }
            set { _profession = value; }
        }

        private string _job;

        public string job
        {
            get { return _job; }
            set { _job = value; }
        }

    }
}
