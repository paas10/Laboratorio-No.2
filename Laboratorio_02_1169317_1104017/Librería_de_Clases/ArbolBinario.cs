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
                    else if (nNuevo.valor.CompareTo(nodoAuxiliar.valor) < 0)
                    {
                        nodoAuxiliar = nodoAuxiliar.izquierdo;
                        bDerecha = false;
                    }
                    else
                        return;
                }

                if (bDerecha)
                    nodoPadre.derecho = nNuevo;
                else
                    nodoPadre.izquierdo = nNuevo;

            }
        }

        public void Eliminar(NodoArbol<T> nEliminar)
        {
            NodoArbol<T> nodoAuxiliar = nRaiz;
            NodoArbol<T> nodoPadre = nRaiz;
            bool bDerecha = false;

            while (nodoAuxiliar != null)
            {
                nodoPadre = nodoAuxiliar;

                if (nEliminar.valor.CompareTo(nodoAuxiliar.valor) > 0)
                {
                    nodoAuxiliar = nodoAuxiliar.derecho;
                    bDerecha = true;
                }
                else if (nEliminar.valor.CompareTo(nodoAuxiliar.valor) < 0)
                {
                    nodoAuxiliar = nodoAuxiliar.izquierdo;
                    bDerecha = false;
                }
                else
                {
                    if (determinarEstado(nodoAuxiliar) == "Hoja")
                    {
                        if (bDerecha == true)
                            nodoPadre.derecho = null;
                        else
                            nodoPadre.izquierdo = null;
                    }
                    else if (determinarEstado(nodoAuxiliar) == "Un Hijo")
                    {
                        if (nodoAuxiliar.derecho == null)
                        {
                            if (bDerecha == true)
                                nodoPadre.derecho = nodoAuxiliar.izquierdo;
                            else
                                nodoPadre.izquierdo = nodoAuxiliar.izquierdo;
                        }
                        else
                        {
                            if (bDerecha == true)
                                nodoPadre.derecho = nodoAuxiliar.derecho;
                            else
                                nodoPadre.izquierdo = nodoAuxiliar.derecho;
                        }
                    }
                    else if (determinarEstado(nodoAuxiliar) == "Dos Hijos")
                    {
                        NodoArbol<T> nodoMiniPadre = nodoAuxiliar;

                        if (bDerecha == true)
                        {
                            nodoMiniPadre = nodoAuxiliar;
                            nodoAuxiliar = nodoAuxiliar.izquierdo;

                            if (nodoAuxiliar.derecho == null)
                            {
                                nodoPadre.derecho = nodoAuxiliar;
                                nodoMiniPadre.derecho = null;
                            }
                            else
                            {
                                while (nodoAuxiliar.derecho != null)
                                {
                                    nodoMiniPadre = nodoAuxiliar;
                                    nodoAuxiliar = nodoAuxiliar.derecho;
                                }

                                nodoPadre.derecho = nodoAuxiliar;
                                nodoMiniPadre.derecho = null;
                            }
                        }
                        else
                        {
                            nodoMiniPadre = nodoAuxiliar;
                            nodoAuxiliar = nodoAuxiliar.derecho;

                            if (nodoAuxiliar.izquierdo == null)
                            {
                                nodoPadre.izquierdo = nodoAuxiliar;
                                nodoMiniPadre.izquierdo = null;
                            }
                            else
                            {
                                while (nodoAuxiliar.izquierdo != null)
                                {
                                    nodoMiniPadre = nodoAuxiliar;
                                    nodoAuxiliar = nodoAuxiliar.izquierdo;
                                }

                                nodoPadre.izquierdo = nodoAuxiliar;
                                nodoMiniPadre.izquierdo = null;
                            }
                        }
                    }
                }
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


        public string determinarEstado(NodoArbol<T> nodo)
        {
            if (nodo.derecho == null && nodo.izquierdo == null)
                return "Hoja";
            else if (nodo.izquierdo == null && nodo.derecho != null || nodo.izquierdo != null && nodo.derecho == null)
                return "Un Hijo";
            else
                return "Dos Hijos";
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