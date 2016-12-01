using e_Clinica.Controller;
using e_Clinica.Model;
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
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            User objUser = new User();
            objUser = User_Ctrl.LogIn(txtUsuario.Text, txtClave.Text);
            if (objUser.level == "doctor")
            {
                PpalMedicos p = new PpalMedicos(objUser);
                
                p.ShowDialog();
            }
            else if (objUser.level == "adm")
            {
                PpalAdministrativos pA = new PpalAdministrativos(objUser);
                pA.ShowDialog();
            }
            else
            {
                MessageBox.Show("Intente nuevamente");
            }
        }
    }
}
