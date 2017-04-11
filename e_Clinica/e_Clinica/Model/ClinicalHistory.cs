using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class ClinicalHistory
    {
        private PhysicalExploration _last_exploration;
        private List<Antecedent> _antecedents;
        private List<Ailment> _ailments;
        public PhysicalExploration last_exploration
        {
            get { return _last_exploration; }
            set { _last_exploration = value; }
        }
        public List<Antecedent>antecedents
        {
            get { return _antecedents; }
            set { _antecedents = value; }
        }
        public List<Ailment> ailments
        {
            get { return _ailments; }
            set { _ailments = value; }
        }
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
