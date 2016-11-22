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

        public int id_clinical_h
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _clinic;

        public int clinic
        {
            get { return _clinic; }
            set { _clinic = value; }
        }

    }
}
