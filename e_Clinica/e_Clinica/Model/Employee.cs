using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Employee
    {
        //{"employee":{"name":"lalo","last_name":"lalo","date_birth":"2010-02-02","gender":"M","curp":"AAAA000000HAAAAA00","rfc":"AAAA000000000","address":"address","email":"lalo@lalo.com","phone":"4777867","profession":"doctor","job":"doctor","specialty_id":1}}
        private int _id;
        private string _name;
        private string _address;
        private string _phone;
        private string _date;
        private string _last_name;
        private int _user;
        private string _gender;
        private string _curp;
        private string _rfc;
        private string _email;
        private string _profession;
        private string _job;
        private int _specialty_id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string date_birth
        {
            get { return _date; }
            set { _date = value; }
        }
        public string last_name
        {
            get { return _last_name; }
            set { _last_name = value; }
        }
        public int user_id
        {
            get { return _user; }
            set { _user = value; }
        }
        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public string curp
        {
            get { return _curp; }
            set { _curp = value; }
        }
        public string rfc
        {
            get { return _rfc; }
            set { _rfc = value; }
        }
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }   
        public string profession
        {
            get { return _profession; }
            set { _profession = value; }
        }
        public string job
        {
            get { return _job; }
            set { _job = value; }
        }
        public int specialty_id
        {
            get { return _specialty_id; }
            set { _specialty_id = value; }
        }

    }
}
