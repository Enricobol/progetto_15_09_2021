using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class Skill
    {
        //PROPRIETA'
        public long Id { get; set; }
        public string Tipo { get; set; }
        public string Descrizione { get; set; }



        //COSTRUTTORI
        public Skill(long id, string tipo, string descrizione)
        {
            Id = id;
            Tipo = tipo;
            Descrizione = descrizione;
        }

        public Skill()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Tipo: {Tipo} Descrizione: {Descrizione} ";
        }

    }
}
