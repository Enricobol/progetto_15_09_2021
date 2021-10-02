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
        public string Titolo { get; set; }
        //PROPRIETA' DI TIPO ASSOCIAZIONE
        public long AziendaId { get; set; }
        public Azienda Azienda { get; set; }
        //PROPRIETA' DI TIPO CONTENITORE
        public virtual List<Corso> Corsi { get; set; } = new List<Corso>(); //Un progetto può avere multipli corsi



        //COSTRUTTORI
        public Progetto(long id, string titolo, long aziendaId)
        {
            Id = id;
            Titolo = titolo;
            AziendaId = aziendaId;
        }
        //COSTRUTTORE VUOTO
        public Progetto()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Titolo: {Titolo}";

        }
    }
}
