﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Study
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _date;

        public string date
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _diagnosis;

        public string diagnosis
        {
            get { return _diagnosis; }
            set { _diagnosis = value; }
        }

        private string _result;

        public string result
        {
            get { return _result; }
            set { _result = value; }
        }


        private string _indication;

        public string indications
        {
            get { return _indication; }
            set { _indication = value; }
        }

        private string _treatment;

        public string treatment
        {
            get { return _treatment; }
            set { _treatment = value; }
        }

        private int _employee;

        public int id_doctor
        {
            get { return _employee; }
            set { _employee = value; }
        }

        private int _id_CH;

        public int id_history
        {
            get { return _id_CH; }
            set { _id_CH = value; }
        }
        private string _type;
        public string type { set; get; }
    }
}
