using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio_02_1169317_1104017.Classes.Models
{
    public class NodoArbol<T>
    {
        public T valor;
        public NodoArbol<T> izquierdo;
        public NodoArbol<T> derecho;

        public NodoArbol(T Valor, NodoArbol<T> izquierda, NodoArbol<T> derecha)
        {
            this.valor = Valor;
            izquierdo = izquierda;
            derecho = derecha;
        }

    }
}