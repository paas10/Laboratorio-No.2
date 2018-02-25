﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio_02_1169317_1104017.Classes.Models
{
    public class DataBase
    {
        private static DataBase instance;
        public static DataBase Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataBase();
                return instance;
            }
        }


        public ArbolBinario<string> Arbolstring;
        public ArbolBinario<int> Arbolint;

        public DataBase()
        {
            Arbolstring = new ArbolBinario<string>();
            Arbolint = new ArbolBinario<int>();
        }
    }
}