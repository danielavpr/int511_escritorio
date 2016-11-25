using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class ClinicalHistory
    {

        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _clinic;

        public int clinic_id
        {
            get { return _clinic; }
            set { _clinic = value; }
        }

        private int _patient_id;

        public int patient_id
        {
            get { return _patient_id; }
            set { _patient_id = value; }
        }

    }
}
