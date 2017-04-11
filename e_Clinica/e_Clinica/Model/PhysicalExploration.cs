using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class PhysicalExploration
    {

        public int clinical_history_id { set; get; }
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private double _temperature;

        public double temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        private double _bloodP;

        public double blood_pressure
        {
            get { return _bloodP; }
            set { _bloodP = value; }
        }

        private int _heartR;

        public int heart_rate
        {
            get { return _heartR; }
            set { _heartR = value; }
        }

        private int _breathing;

        //public int breathing_rate
        //{
        //    get { return _breathing; }
        //    set { _breathing = value; }
        //}

        private string _observ;

        public string observations
        {
            get { return _observ; }
            set { _observ = value; }
        }
        public int breathing_frec { set; get; }

    }
}
