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

        public int id_patient
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string name_patient
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _address;

        public string address_p
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _phone;

        public string phone_p
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private DateTime _date;

        public DateTime date_of_birth_p
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _last_name;

        public string last_name_p
        {
            get { return _last_name; }
            set { _last_name = value; }
        }

        private int _user;

        public int user_patient
        {
            get { return _user; }
            set { _user = value; }
        }

        private string _gender;

        public string gender_patient
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _curp;

        public string curp_patient
        {
            get { return _curp; }
            set { _curp = value; }
        }

        private string _rfc;

        public string rfc_patient
        {
            get { return _rfc; }
            set { _rfc = value; }
        }

        private string _email;

        public string email_patient
        {
            get { return _email; }
            set { _email = value; }
        }


        private int _ch;

        public int CH_patient
        {
            get { return _ch; }
            set { _ch = value; }
        }


    }
}
