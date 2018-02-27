using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laboratorio_02_1169317_1104017
{
    public class Pais : IComparable
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre del Pais es requerido")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre del Grupo es requerido")]
        public string Grupo { get; set; }

        public Pais(string Nombre, string Grupo)
        {
            this.Nombre = Nombre;
            this.Grupo = Grupo;
        }

       
        public Comparison<Pais> CompareByName = delegate (Pais i, Pais j)
        {
            return i.Nombre.CompareTo(j.Nombre);
        };

        public Comparison<Pais> CompareByGroup = delegate (Pais i, Pais j)
        {
            return i.Grupo.CompareTo(j.Grupo);
        };

        public override string ToString()
        {
            return $"{Nombre}|{Grupo}";
        }
        
        public bool Equals(Pais pais)
        {
            bool igual = pais.Nombre == Nombre;
            igual = igual && pais.Grupo == Grupo;
            return igual;
        }

        public int CompareTo(object obj)
        {
            return Nombre.CompareTo(obj);
        }

    }
}
