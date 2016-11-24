using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class PrescriptionDetail
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _quantity;

        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }


        private double _price;

        public double price
        {
            get { return _price; }
            set { _price = value; }
        }


        private int _description;

        public int description
        {
            get { return _description; }
            set { _description = value; }
        }

        private int _drug;

        public int drug_id
        {
            get { return _drug; }
            set { _drug = value; }
        }
        private int _prescription;

        public int prescription
        {
            get { return _prescription; }
            set { _prescription = value; }
        }


    }
}
