using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Librería_de_Clases
{

    public class ArbolBinario<T>: IEnumerable<T> where T : IComparable
    {

        public NodoArbol<T> nRaiz;
        int iElementos;

        public ArbolBinario()
        {
            this.nRaiz = null;
            this.iElementos = 0;
        }


        public void Insertar(NodoArbol<T> nNuevo)
        {
            if (nRaiz == null)
            {
                nRaiz = nNuevo;
            }
            else
            {
                NodoArbol<T> nodoAuxiliar = nRaiz;
                NodoArbol<T> nodoPadre = nRaiz;
                bool bDerecha = false;

                while (nodoAuxiliar != null)
                {
                    nodoPadre = nodoAuxiliar;

                    if (nNuevo.valor.CompareTo(nodoAuxiliar.valor) > 0)
                    {
                        nodoAuxiliar = nodoAuxiliar.derecho;
                        bDerecha = true;
                    }
                    else
                    {
                        nodoAuxiliar = nodoAuxiliar.izquierdo;
                        bDerecha = false;
                    }
                }

                if (bDerecha)
                    nodoPadre.derecho = nNuevo;
                else
                    nodoPadre.izquierdo = nNuevo;

            }
        }

        private void PreOrden(NodoArbol<T> nodoAuxiliar, ref List<T> resultado)
        {
            if (nodoAuxiliar != null)
            {
                resultado.Add(nodoAuxiliar.valor);
                PreOrden(nodoAuxiliar.izquierdo, ref resultado);
                PreOrden(nodoAuxiliar.derecho, ref resultado);
            }
        }

        private void InOrden(NodoArbol<T> nodoAuxiliar, ref List<T> resultado)
        {
            if (nodoAuxiliar != null)
            {
                InOrden(nodoAuxiliar.izquierdo, ref resultado);
                resultado.Add(nodoAuxiliar.valor);
                InOrden(nodoAuxiliar.derecho, ref resultado);
            }
        }

        private void PostOrden(NodoArbol<T> nodoAuxiliar, ref List<T> resultado)
        {
            if (nodoAuxiliar != null)
            {
                PostOrden(nodoAuxiliar.izquierdo, ref resultado);
                PostOrden(nodoAuxiliar.derecho, ref resultado);
                resultado.Add(nodoAuxiliar.valor);
            }
        }

        /// <summary>
        /// Muestra el arbol en los distintos ordenes
        /// </summary>
        /// <param name="code">1. Pre-Orden  2. In-Orden  3. Post-Orden</param>
        /// <param name="dt">DataTable donde se almacena la informacion de los nodos</param>
        public List<T> LeerArbol(int code)
        {
            List<T> resultado = new List<T>();
            switch (code)
            {
                case 1: PreOrden(nRaiz, ref resultado); break;
                case 2: InOrden(nRaiz, ref resultado); break;
                case 3: PostOrden(nRaiz, ref resultado); break;
            }

            return resultado;
        }

        public IEnumerator<T> GetEnumerator()
        {
            NodoArbol<T> current = nRaiz;
            int i = 0;
            while (current != null && i < iElementos)
            {
                yield return current.valor;
                current = current.izquierdo;
                current = current.derecho;
                i++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}