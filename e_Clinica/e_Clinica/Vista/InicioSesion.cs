using e_Clinica.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Clinica
{
    public partial class InicioSesion : Form
    {
        int user; 
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            user = Int32.Parse(txtUsuario.Text);
            if (user == 1)
            {
                PpalMedicos p = new PpalMedicos();
                p.ShowDialog();
            }
            else if (user == 2)
            {
                PpalAdministrativos pA = new PpalAdministrativos();
                pA.ShowDialog();
            }
            else if (user == 3)
            {
                PruebasImg prueba = new PruebasImg();
                prueba.ShowDialog(); 
            }
        }
    }
}
