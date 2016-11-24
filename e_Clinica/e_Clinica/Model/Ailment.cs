using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Ailment
    {
        private int _id_ailment;

        public int id
        {
            get { return _id_ailment; }
            set { _id_ailment = value; }
        }

        private string _main_symp;

        public string main_symptom
        {
            get { return _main_symp; }
            set { _main_symp = value; }
        }

        private DateTime _date_detection;

        public DateTime date_of_detection
        {
            get { return _date_detection; }
            set { _date_detection = value; }
        }

        private string _symp_location;

        public string symptom_location
        {
            get { return _symp_location; }
            set { _symp_location = value; }
        }

        private string _collateral;

        public string collateral_symptom
        {
            get { return _collateral; }
            set { _collateral = value; }
        }

        private DateTime _end_date;

        public DateTime end_date
        {
            get { return _end_date; }
            set { _end_date = value; }
        }

        private int _id_CH;

        public int clinical_history_id
        {
            get { return _id_CH; }
            set { _id_CH = value; }
        }

    }
}
