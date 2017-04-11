using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace e_Clinica.ManejoImagen
{
    public class AnalizeImg
    {
       
        
        public static string AnalizeMole(int _tone, int _pColor, bool _elipse)
        {
            string analisis = ""; 
            if(_elipse == true && _tone > 120 && _pColor < 90)
                analisis = "Bajo riesgo: Simetría, poca variación de tonos";
            else if (_elipse == true && _tone < 120 && _pColor > 90)
                analisis = "Poco riesgo: Simetría, poca saturación de rojos";
            else if (_elipse == true && _tone > 120 && _pColor > 90)
                analisis = "Medio riesgo: Simetría, predominancia de rojo";
            else if (_elipse == false && _tone > 120 && _pColor > 90)
                analisis = "Alto riesgo: Asimetría, bordes no definidos, alta variación de tonos";
            return analisis;  
        }
    }
}
