﻿using Librería_de_Clases;
using Laboratorio_02_1169317_1104017.Classes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Laboratorio_02_1169317_1104017.Controllers
{
    public class ArbolBinarioController : Controller
    {
        // GET: ArbolBinario
        // Index del arbol de paises
        public ActionResult Index(int? Tipo)
        {
            if (Tipo == 1)
            {
                return View(DataBase.Instance.ArbolPais.LeerArbol(1));
            }
            else if (Tipo == 2)
            {
                return View(DataBase.Instance.ArbolPais.LeerArbol(2));

            }
            else if (Tipo == 3)
            {
                return View(DataBase.Instance.ArbolPais.LeerArbol(3));
            }
            else
            {

                Tipo = 1;
                string Resultado = DataBase.Instance.ArbolPais.Balanceado();
                if(Resultado == "Balanceado")
                {
                    TempData["msg"] = "<script>alert('El Arbol que se cargo esta Balanceado');</script>";
                    
                }
                else
                {
                    TempData["msg"] = "<script> alert('" + Resultado + " .');</script>";
                }

                string ResultadoDegenerado = DataBase.Instance.ArbolPais.Degenerado();
                if (Resultado == "Degenerado")
                {
                    TempData["msg1"] = "<script>alert('El Arbol que se cargo es Degenerado');</script>";
                }
                else
                {
                    TempData["msg1"] = "<script> alert('El Arbol que se cargo NO es Degenerado');</script>";
                }
                return View(DataBase.Instance.ArbolPais.LeerArbol(1));
            }

           
            return View();
        }

        // Index del arbol de enteros
        public ActionResult IndexInt(int? Tipo)
        {
            if (Tipo == 1)
            {
                return View(DataBase.Instance.Arbolint.LeerArbol(1));
            }
            else if (Tipo == 2)
            {
                return View(DataBase.Instance.Arbolint.LeerArbol(2));

            }
            else if (Tipo == 3)
            {
                return View(DataBase.Instance.Arbolint.LeerArbol(3));
            }
            else
            {
                Tipo = 1;
                return View(DataBase.Instance.Arbolint.LeerArbol(1));
            }

            return View();
        }

        // Index del arbol de strings
        public ActionResult IndexString(int? Tipo)
        {
            if (Tipo == 1)
            {
                return View(DataBase.Instance.Arbolstring.LeerArbol(1));
            }
            else if (Tipo == 2)
            {
                return View(DataBase.Instance.Arbolstring.LeerArbol(2));

            }
            else if (Tipo == 3)
            {
                return View(DataBase.Instance.Arbolstring.LeerArbol(3));
            }
            else
            {
                Tipo = 1;
                return View(DataBase.Instance.Arbolstring.LeerArbol(1));
            }

            return View();
        }

        // GET: ArbolBinario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArbolBinario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArbolBinario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Pais nuevoPais = new Pais(collection["Nombre"], collection["Grupo"]);
                NodoArbol<Pais> nNodo = new NodoArbol<Pais>(nuevoPais, null, null);

                DataBase.Instance.ArbolPais.Insertar(nNodo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: ArbolBinario/CreateInt
        public ActionResult CreateInt(int? item)
        {
            return View();
        }

        // POST: ArbolBinario/CreateInt
        [HttpPost]
        public ActionResult CreateInt(int item)
        {
            try
            {
                NodoArbol<int> nNodo = new NodoArbol<int>(item, null, null);

                DataBase.Instance.Arbolint.Insertar(nNodo);

                return RedirectToAction("IndexInt");
            }
            catch
            {
                return View();
            }
        }

        // GET: ArbolBinario/Create
        public ActionResult CreateString()
        {
            return View();
        }

        // POST: ArbolBinario/Create
        [HttpPost]
        public ActionResult CreateString(string item)
        {
            try
            {
                NodoArbol<string> nNodo = new NodoArbol<string>(item, null, null);

                DataBase.Instance.Arbolstring.Insertar(nNodo);

                return RedirectToAction("IndexString");
            }
            catch
            {
                return View();
            }
        }

        // GET: ArbolBinario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArbolBinario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ArbolBinario/Delete/5
        public ActionResult Delete(int? id)
        {
            return View();
        }

        // POST: ArbolBinario/Delete/5
        [HttpPost]
        public ActionResult Delete(string Nombre, string Grupo)
        {
            try
            {
                Pais paisEliminar = new Pais(Nombre,Grupo);
                NodoArbol<Pais> nodoEliminar = new NodoArbol<Pais>(paisEliminar, null, null);

                DataBase.Instance.ArbolPais.Eliminar(nodoEliminar.valor);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Aca se hace el Ingreso por medio de Archivo de Texto, ya que el Boton de Result esta Linkeado.
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if (Path.GetExtension(file.FileName) != ".json")
            {
                //Aca se debe de Agregar una Vista de Error, o de Datos No Cargados
                return RedirectToAction("Error", "Shared");
            }

            Stream Direccion = file.InputStream;
            //Se lee el Archivo que se subio, por medio del Lector

            StreamReader Lector = new StreamReader(Direccion);
            //El Archivo se lee en una lista para luego ingresarlo

            //Se crea un Jugador Momentaneo para pasar los datos

            string Dato = Lector.ReadLine();
            Dato += Lector.ReadLine();
            string Linea = Dato;

            while (Dato != null)
            {
                Dato = Lector.ReadLine();
                Linea = Linea + Dato;
            }

            try
            {
                NodoArbol<Pais> ListadePaises = JsonConvert.DeserializeObject<NodoArbol<Pais>>(Linea);
                DataBase.Instance.ArbolPais.Insertar(ListadePaises);

                return RedirectToAction("Index");
            }
            catch
            {
                try
                {
                    NodoArbol<int> ListadeNumeros = JsonConvert.DeserializeObject<NodoArbol<int>>(Linea);
                    DataBase.Instance.Arbolint.Insertar(ListadeNumeros);

                    return RedirectToAction("IndexInt");
                }
                catch
                {
                    NodoArbol<string> ListadeTexto = JsonConvert.DeserializeObject<NodoArbol<string>>(Linea);
                    DataBase.Instance.Arbolstring.Insertar(ListadeTexto);

                    return RedirectToAction("IndexString");
                }
            }

        }
    }
}

