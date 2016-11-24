using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Prescription
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

        public int patient_id
        {
            get { return _patient; }
            set { _patient = value; }
        }

        private int _employee;

        public int employee_id
        {
            get { return _employee; }
            set { _employee = value; }
        }

    }
}
