using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Clinica.Vista
{
    public partial class PruebasImg : Form
    {
        public PruebasImg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qrValue = textBox1.Text;
            pictureBox1.Image = ManejoImagen.GenerateQRCode.fromString(qrValue); 
        }
    }
}
