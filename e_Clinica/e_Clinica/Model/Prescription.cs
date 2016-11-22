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

        public int id_prescription
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _date;

        public DateTime date_presc
        {
            get { return _date; }
            set { _date = value; }
        }

        private int _patient;

        public int patient_presc
        {
            get { return _patient; }
            set { _patient = value; }
        }

        private int _employee;

        public int employee_presc
        {
            get { return _employee; }
            set { _employee = value; }
        }

    }
}
