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

            char[] letras1 = cad1.ToCharArray();
            char[] letras2 = cad2.ToCharArray();

            bool condicion = true;
            int cont = 0;
            int res = 10;

            while (condicion)
            {
                try
                {
                    int l1 = Convert.ToInt16(letras1[cont]);
                    int l2 = Convert.ToInt16(letras2[cont]);

                    if (l1 < l2)
                    {
                        res = 1;
                        break;
                    }
                    if (l1 > l2)
                    { 
                        res = - 1;
                        break;
                    }
                }
                catch
                {
                    if (letras1.Count() < letras2.Count())
                    { 
                        res = 1;
                        break;
                    }
                    else if (letras1.Count() > letras2.Count())
                    {
                        res = - 1;
                        break;
                    }
                    else if (letras1.Count() == letras2.Count())
                    {
                        res = 0;
                        break;
                    }
                }

                cont++;
            }

            return res;

        }
    }
}
