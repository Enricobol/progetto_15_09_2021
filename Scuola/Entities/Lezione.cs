using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class Lezione
    {
        //PROPRIETA'
        public long Id { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public string Descrizione { get; set; }
        //PROPRIETA' DI TIPO ASSOCIAZIONE
        public long AulaId { get; set; }
        public long PersonaId { get; set; }
        public long ModuloId { get; set; }
        public Aula Aula { get; set; }
        public Persona Persona { get; set; }
        public Modulo Modulo { get; set; }
        //PROPRIETA' DI TIPO CONTENITORE
        public virtual List<Presenza> Presenze { get; set; } = new List<Presenza>(); //Una lezione può avere più presenze


        //COSTRUTTORI
        public Lezione(long id, DateTime inizio, DateTime fine, string descrizione, long aulaId, long personaId, long moduloId)
        {
            Id = id;
            Inizio = inizio;
            Fine = fine;
            Descrizione = descrizione;
            AulaId = aulaId;
            PersonaId = personaId;
            ModuloId = moduloId;
        }

        public Lezione()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Data di inizio: {Inizio}  Data di fine: {Fine} ID Aula: {AulaId}" +
                $"\n Descrizione : {Descrizione}";

        }
    }
}
