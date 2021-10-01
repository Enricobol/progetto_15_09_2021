using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class Presenza
    {
        //PROPRIETA'
        public long Id { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public string Nota { get; set; }
        //PROPRIETA' DI TIPO ASSOCIAZIONE
        public long PersonaId { get; set; }
        public long LezioneId { get; set; }
        public Persona Persona { get; set; }
        public Lezione Lezione { get; set; }


        //COSTRUTTORI
        public Presenza(long id, DateTime inizio, DateTime fine, string nota, long personaId, long lezioneId)
        {
            Id = id;
            Inizio = inizio;
            Fine = fine;
            Nota = nota;
            PersonaId = personaId;
            LezioneId = lezioneId;
        }

        public Presenza()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Inizio: {Inizio} Fine: {Fine}" +
                $"\n Nota: {Nota}";
        }
    }
}
