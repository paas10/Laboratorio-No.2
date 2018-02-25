using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laboratorio_02_1169317_1104017
{
    public class Pais : IComparable
    {

        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre del Pais es requerido")]
        public string NombrePais { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre del Grupo es requerido")]
        public string Grupo { get; set; }

        public int CompareTo(Pais other)
        {
            return other.ID < ID ? -1 : other.ID == ID ? 0 : 1;
        }

        public Comparison<Pais> CompareById = delegate (Pais i, Pais j)
        {
            return i.CompareTo(j);
        };

        public Comparison<Pais> CompareByName = delegate (Pais i, Pais j)
        {
            return i.NombrePais.CompareTo(j.NombrePais);
        };

        public Comparison<Pais> CompareByGroup = delegate (Pais i, Pais j)
        {
            return i.Grupo.CompareTo(j.Grupo);
        };

        public override string ToString()
        {
            return $"{ID}|{NombrePais}|{Grupo}";
        }

        public bool Equals(Pais pais)
        {
            bool igual = pais.NombrePais == NombrePais;
            igual = igual && pais.Grupo == Grupo;
            return igual;
        }

        public int CompareTo(object obj)
        {
            try
            {
                Pais pais = obj as Pais;
                return pais.ID < ID ? -1 : pais.ID == ID ? 0 : 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
