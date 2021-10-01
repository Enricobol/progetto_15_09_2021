using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class Progetto
    {
        //PROPRIETA'
        public long Id { get; set; }
        public string Tipologia { get; set; }
        //PROPRIETA' FOREING KEYS
        public long AziendaId { get; set; }
        //PROPRIETA' CLASSI
        public Azienda Azienda { get; set; }

        //COSTRUTTORI
        public Progetto(long id, string tipologia, long aziendaId)
        {
            Id = id;
            Tipologia = tipologia;
            AziendaId = aziendaId;
        }

        public Progetto()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Tipologia: {Tipologia}";

        }
    }
}
