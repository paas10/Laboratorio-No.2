using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio_02_1169317_1104017
{
    public class NodoArbol<T>
    {
        public T valor;
        public NodoArbol<T> nIzquierda;
        public NodoArbol<T> nDerecha;

       public NodoArbol(T Valor, NodoArbol<T> izquierda, NodoArbol<T> derecha)
        {
            this.valor = Valor;
            nIzquierda = izquierda;
            nDerecha = derecha;
        }

        public NodoArbol(T Valor) : this(Valor, null, null) { }

    }

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
                        nodoAuxiliar = nodoAuxiliar.nDerecha;
                        bDerecha = true;
                    }
                    else
                    {
                        nodoAuxiliar = nodoAuxiliar.nIzquierda;
                        bDerecha = false;
                    }
                }

                if (bDerecha)
                    nodoPadre.nDerecha = nNuevo;
                else
                    nodoPadre.nIzquierda = nNuevo;

            }
        }

        private void PreOrden(NodoArbol<T> nodoAuxiliar, ref List<NodoArbol<T>> resultado)
        {
            if (nodoAuxiliar != null)
            {
                resultado.Add(nodoAuxiliar);
                PreOrden(nodoAuxiliar.nIzquierda, ref resultado);
                PreOrden(nodoAuxiliar.nDerecha, ref resultado);
            }
        }

        private void InOrden(NodoArbol<T> nodoAuxiliar, ref List<NodoArbol<T>> resultado)
        {
            if (nodoAuxiliar != null)
            {
                InOrden(nodoAuxiliar.nIzquierda, ref resultado);
                resultado.Add(nodoAuxiliar);
                InOrden(nodoAuxiliar.nDerecha, ref resultado);
            }
        }

        private void PostOrden(NodoArbol<T> nodoAuxiliar, ref List<NodoArbol<T>> resultado)
        {
            if (nodoAuxiliar != null)
            {
                PostOrden(nodoAuxiliar.nIzquierda, ref resultado);
                PostOrden(nodoAuxiliar.nDerecha, ref resultado);
                resultado.Add(nodoAuxiliar);
            }
        }

        /// <summary>
        /// Muestra el arbol en los distintos ordenes
        /// </summary>
        /// <param name="code">1. Pre-Orden  2. In-Orden  3. Post-Orden</param>
        /// <param name="dt">DataTable donde se almacena la informacion de los nodos</param>
        public void LeerArbol(int code, ref List<NodoArbol<T>> resultado)
        {
            switch (code)
            {
                case 1: PreOrden(nRaiz, ref resultado); break;
                case 2: InOrden(nRaiz, ref resultado); break;
                case 3: PostOrden(nRaiz, ref resultado); break;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            NodoArbol<T> current = nRaiz;
            int i = 0;
            while (current != null && i < iElementos)
            {
                yield return current.valor;
                current = current.nIzquierda;
                current = current.nDerecha;
                i++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}