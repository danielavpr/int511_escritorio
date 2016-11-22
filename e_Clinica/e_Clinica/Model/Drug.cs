using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Drug
    {
        private int _id;

        public int id_drug
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _sku;

        public int sku
        {
            get { return _sku; }
            set { _sku = value; }
        }

        private string _name;

        public string name_drug
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;

        public string description_drug
        {
            get { return _description; }
            set { _description = value; }
        }

        private double _purchase;

        public double purchase_price
        {
            get { return _purchase; }
            set { _purchase = value; }
        }

        private double _sell;

        public double sell_price
        {
            get { return _sell; }
            set { _sell = value; }
        }

        private int _quantity;

        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

    }
}
