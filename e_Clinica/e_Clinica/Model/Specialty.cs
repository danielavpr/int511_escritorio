using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Specialty
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private DateTime _open_time;

        public DateTime opening_time
        {
            get { return _open_time; }
            set { _open_time = value; }
        }

        private DateTime _close_time;

        public DateTime closing_time
        {
            get { return _close_time; }
            set { _close_time = value; }
        }

        private string _extension;

        public string extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        private double _cost;

        public double cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        private int _manager;

        public int manager_id
        {
            get { return _manager; }
            set { _manager = value; }
        }

        //private int _clinic;

        //public int clinic_id
        //{
        //    get { return _clinic; }
        //    set { _clinic = value; }
        //}
    }
}
