﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Model
{
    public class Image_Study
    {

        private int _id;

        public int id_image
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _study;

        public int id_study_img
        {
            get { return _study; }
            set { _study = value; }
        }

        private Image img;

        public Image image_study
        {
            get { return img; }
            set { img = value; }
        }

    }
}
