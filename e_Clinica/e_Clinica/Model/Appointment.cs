using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Appointment
    {
        
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _date;

        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }

        private int _patient;

        public int patient
        {
            get { return _patient; }
            set { _patient = value; }
        }

        private int _employee;

        public int employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        private int _status;

        public int status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _satisfaction;

        public int satisfaction
        {
            get { return _satisfaction; }
            set { _satisfaction = value; }
        }

    }
}
