using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Clinica.Helpers
{
    public class ParkingLotHelper
    {
    }
    class Empleado
    {
        public string Genero { set; get; }
        public int IdEmpleado { set; get; }
        public string Nombre { set; get; }
        public int Status { set; get; }
        public string apMaterno { set; get; }
        public string apPaterno { set; get; }
    }
    class EmpleadoHelper
    {
        List<Empleado> Empleados { set; get; }
    }
}
