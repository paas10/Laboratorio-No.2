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
                bool bIzquierda = false;

                while (nodoAuxiliar != null)
                {
                    nodoPadre = nodoAuxiliar;

                    if (nNuevo.valor.CompareTo(nodoAuxiliar.valor) < 0)
                    {
                        nodoAuxiliar = nodoAuxiliar.izquierdo;
                        bIzquierda = true;
                    }
                    else if (nNuevo.valor.CompareTo(nodoAuxiliar.valor) > 0)
                    {
                        nodoAuxiliar = nodoAuxiliar.derecho;
                        bIzquierda = false;
                    }
                    else
                        return;
                }

                if (bIzquierda)
                    nodoPadre.izquierdo = nNuevo;
                else
                    nodoPadre.derecho = nNuevo;

            }
        }

      /*  public void Eliminar(NodoArbol<T> nEliminar)
        {
            NodoArbol<T> nodoAuxiliar = nRaiz;
            NodoArbol<T> nodoPadre = nRaiz;
            bool bIzquierda = false;

            while (nodoAuxiliar != null)
            {
                nodoPadre = nodoAuxiliar;

                if (nEliminar.valor.CompareTo(nodoAuxiliar.valor) > 0)
                {
                    nodoAuxiliar = nodoAuxiliar.izquierdo;
                    bIzquierda = true;
                }
                else if (nEliminar.valor.CompareTo(nodoAuxiliar.valor) < 0)
                {
                    nodoAuxiliar = nodoAuxiliar.derecho;
                    bIzquierda = false;
                }
                else
                {
                    if (determinarEstado(nodoAuxiliar) == "Hoja")
                    {
                        if (bIzquierda == true)
                            nodoPadre.izquierdo = null;
                        else
                            nodoPadre.derecho = null;
                        break;
                    }
                    else if (determinarEstado(nodoAuxiliar) == "Un Hijo")
                    {
                        if (nodoAuxiliar.derecho == null)
                        {
                            if (bIzquierda == true)
                                nodoPadre.derecho = nodoAuxiliar.izquierdo;
                            else
                                nodoPadre.izquierdo = nodoAuxiliar.izquierdo;
                        }
                        else
                        {
                            if (bIzquierda == true)
                                nodoPadre.derecho = nodoAuxiliar.derecho;
                            else
                                nodoPadre.izquierdo = nodoAuxiliar.derecho;
                        }
                    }
                    else if (determinarEstado(nodoAuxiliar) == "Dos Hijos")
                    {
                        NodoArbol<T> nodoMiniPadre = nodoAuxiliar;

                        if (bIzquierda == false)
                        {
                            nodoMiniPadre = nodoAuxiliar;
                            nodoAuxiliar = nodoAuxiliar.izquierdo;

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

                                nodoPadre.derecho = nodoAuxiliar;
                                nodoMiniPadre.izquierdo = null;
                            }
                        }
                        else
                        {
                            nodoMiniPadre = nodoAuxiliar;
                            nodoAuxiliar = nodoAuxiliar.derecho;

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
                    }
                }
            }
        }*/

        /// <summary>
        /// Eliminar la primera apracición de un valor en el Arbol
        /// </summary>
        /// <param name="valor">Valor a Eliminar</param>
        /// <returns>Nodo Eliminado</returns>
        public NodoArbol<T> Eliminar(T valor)
        {
            NodoArbol<T> auxiliar = nRaiz;
            NodoArbol<T> padre = nRaiz;
            bool esHijoIzquierdo = true;
            while (auxiliar.valor.CompareTo(valor) != 0)
            {
                padre = auxiliar;
                if (valor.CompareTo(auxiliar.valor) < 0)
                {
                    esHijoIzquierdo = true;
                    auxiliar = auxiliar.izquierdo;
                }
                else
                {
                    esHijoIzquierdo = false;
                    auxiliar = auxiliar.derecho;
                }
                if (auxiliar == null)
                {
                    return null;
                }
            }// Fin ciclo inicial
            if (auxiliar.EsHoja)
            {
                if (auxiliar == nRaiz)
                {
                    nRaiz = null;
                }
                else if (esHijoIzquierdo)
                {
                    padre.izquierdo = null;
                }
                else
                {
                    padre.derecho = null;
                }
            }
            else if (auxiliar.derecho == null)
            {
                NodoArbol<T> temp = auxiliar.izquierdo;
                if (auxiliar == nRaiz)
                {
                    nRaiz = temp;
                }
                else if (esHijoIzquierdo)
                {
                    padre.izquierdo = temp;
                }
                else
                {
                    padre.derecho = temp;
                }
            }
            else if (auxiliar.izquierdo == null)
            {
                NodoArbol<T> temp = auxiliar.derecho;
                if (auxiliar == nRaiz)
                {
                    nRaiz = temp;
                }
                else if (esHijoIzquierdo)
                {
                    padre.izquierdo = temp;
                }
                else
                {
                    padre.derecho = temp;
                }
            }
            else
            {
                NodoArbol<T> reemplazo = Reemplazar(auxiliar);
                if (auxiliar == nRaiz)
                {
                    nRaiz = reemplazo;
                }
                else if (esHijoIzquierdo)
                {
                    padre.izquierdo = reemplazo;
                }
                else
                {
                    padre.derecho = reemplazo;
                }
                reemplazo.izquierdo = auxiliar.izquierdo;

            }
            return auxiliar;
        }
        /// <summary>
        /// Elimina un Nodo mediante sustitucion
        /// </summary>
        /// <param name="NodoAEliminar">Nodo a Eliminar </param>
        /// <returns>Nodo de Reemplazo</returns>
        private NodoArbol<T> Reemplazar(NodoArbol<T> NodoAEliminar)
        {
            NodoArbol<T> remplazoPadre = NodoAEliminar;
            NodoArbol<T> reemplazo = NodoAEliminar;
            NodoArbol<T> auxiliar = NodoAEliminar.derecho;
            while (auxiliar != null)
            {
                remplazoPadre = reemplazo;
                reemplazo = auxiliar;
                auxiliar = auxiliar.izquierdo;
            }
            if (reemplazo != NodoAEliminar.derecho)
            {
                remplazoPadre.izquierdo = reemplazo.derecho;
                reemplazo.derecho = NodoAEliminar.derecho;
            }
            return reemplazo;
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