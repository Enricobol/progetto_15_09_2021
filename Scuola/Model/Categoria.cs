﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model
{
    public class Categoria
    {
        //PROPRIETA'
        public long Id { get; set; }
        public string Tipo { get; set; }
        public string Descrizione { get; set; }

        //COSTRUTTORI
        public Categoria(long id, string tipo, string descrizione)
        {
            Id = id;
            Tipo = tipo;
            Descrizione = descrizione;
        }

        public Categoria()
        {

        }

    }
}
