﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Drug
    {
        private string _quantity;

        public string quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
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

        private string _description;

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        private double _purchase;

        public double purchase
        {
            get { return _purchase; }
            set { _purchase = value; }
        }

        private double _sell;

        public double price
        {
            get { return _sell; }
            set { _sell = value; }
        }

       

    }
}
