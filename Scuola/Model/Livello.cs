using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model
{
    public class Livello
    {
        //PROPRIETA'
        public long Id { get; set; }
        public string Tipologia { get; set; }
        public string Descrizione { get; set; }

        //COSTRUTTORI
        public Livello(long id, string tipologia, string descrizione)
        {
            Id = id;
            Tipologia = tipologia;
            Descrizione = descrizione;
        }

        public Livello()
        {

        }

    }
}
