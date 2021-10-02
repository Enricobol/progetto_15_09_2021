using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class Iscrizione
    {
        //PROPRIETA'
        public long Id { get; set; }
        public DateTime DataIscrizioni { get; set; }
        public string ValutazioneCorsi { get; set; }
        public int VotoCorsi { get; set; }
        public int ValutazioneStudente { get; set; }
        public bool Pagata { get; set; }
        //PROPRIETA' DI TIPO ASSOCIAZIONE
        public long PersonaId { get; set; }
        public long EdizioneCorsoId { get; set; }
        public Persona Persona { get; set; }
        public EdizioneCorso EdizioneCorso { get; set; }


        //COSTRUTTORI
        public Iscrizione(long id, DateTime dataIscrizioni, string valutazioneCorsi, int votoCorsi, int valutazioneStudente, bool pagata)
        {
            Id = id;
            DataIscrizioni = dataIscrizioni;
            ValutazioneCorsi = valutazioneCorsi;
            VotoCorsi = votoCorsi;
            ValutazioneStudente = valutazioneStudente;
            Pagata = pagata;
        }
        //COSTRUTTORE VUOTO
        public Iscrizione()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Data Iscrizione: {DataIscrizioni} Pagata: {Pagata}";

        }
    }
}
