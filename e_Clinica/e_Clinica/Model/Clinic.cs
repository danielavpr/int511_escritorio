using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Clinic
    {
        //        id_clinic int
        //name_clinic string
        //address_clinic string
        //phone_clinic string
        //manager_clinic int
        //opent_time_c time
        //close_time_c time

        private int _id;

        public int id_clinic
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string name_clinic
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _address;

        public string address_clinic
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _phone;

        public string phone_clinic
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private int _manager;

        public int manager_clinic
        {
            get { return _manager; }
            set { _manager = value; }
        }

        private DateTime _open_time;

        public DateTime open_time_c
        {
            get { return _open_time; }
            set { _open_time = value; }
        }

        private DateTime _close_time;

        public DateTime close_time_c
        {
            get { return _close_time; }
            set { _close_time = value; }
        }

    }
}
