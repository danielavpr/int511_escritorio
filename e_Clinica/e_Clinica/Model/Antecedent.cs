using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Antecedent
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

        private string _desc;

        public string description
        {
            get { return _desc; }
            set { _desc = value; }
        }

        private int _id_CH;

        public int clinical_history_id
        {
            get { return _id_CH; }
            set { _id_CH = value; }
        }

        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

    }
}
