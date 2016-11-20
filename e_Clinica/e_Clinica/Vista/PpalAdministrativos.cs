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
    public partial class PpalAdministrativos : Form
    {
        public PpalAdministrativos()
        {
            InitializeComponent();
            //prev = dtHorario.Value;
            //   TimeSpan t = new TimeSpan(9, 0, 0);
            cmbHorarios.Items.AddRange(lstHorarios.ToArray());
        }
        #region VARIABLES GLOBALES 
        List<string> lstHorarios = new List<string> {"09:00","09:30","10:00","10:30","11:00" };     
        //private DateTime prev;
        #endregion                
        private void dtHorario_ValueChanged(object sender, EventArgs e)
        {
            //DateTime dt = dtHorario.Value;
            //if ((dt.Minute * 60 + dt.Second) % 300 != 0)
            //{
            //    TimeSpan diff = dt - prev;
            //    if (diff.Ticks < 0) dtHorario.Value = prev.AddMinutes(-30);
            //    else dtHorario.Value = prev.AddMinutes(30);
            //}
            //prev = dtHorario.Value;
        }
    }
}
