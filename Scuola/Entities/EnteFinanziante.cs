using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class EnteFinanziante
    {
        //PROPRIETA'
        public long Id { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }

        //COSTRUTTORI
        public EnteFinanziante(long id, string titolo, string descrizione)
        {
            Id = id;
            Titolo = titolo;
            Descrizione = descrizione;
        }

        public EnteFinanziante()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Titolo: {Titolo} \nDescrizione: {Descrizione} ";
        }
    }
}
