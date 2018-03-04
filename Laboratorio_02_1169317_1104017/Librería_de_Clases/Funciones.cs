using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería_de_Clases
{
    public class Funciones
    {
        /// <summary>
        /// Funcion que compara dos cadenas
        /// </summary>
        /// <returns>
        /// Cadena1 < Cadena2  > -1
        /// Cadena1 == Cadena2 > 0
        /// Cadena1 > Cadena2  > 1
        /// </Cadena2></returns>
        public int CompararCadena(string cad1, string cad2)
          {
              cad1 = cad1.ToUpper();
              cad2 = cad2.ToUpper();

              int res = 0;

              if (cad1.CompareTo(cad2) < 0)
                  res = -1;              
              else if (cad1.CompareTo(cad2) > 0)
                  res = 1;

              return res;

          }
      }
    }

