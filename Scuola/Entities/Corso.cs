using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace Scuola.Entities
{
    public class Corso
    {
        //PROPRIETA'
        public long Id { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public int AmmontareOre { get; set; }
        public decimal CostoRiferimento { get; set; }
        //PROPRIETA' DI TIPO ASSOCIAZIONE
        public long LivelloId { get; set; }
        public long ProgettoId { get; set; }
        public long CategoriaId { get; set; }
        public Livello Livello { get; set; }
        public Progetto Progetto { get; set; }
        public Categoria Categoria { get; set; }
        //PROPRIETA' DI TIPO CONTENITORE
        public virtual List<EdizioneCorso> EdizioniCorso { get; set; } = new List<EdizioneCorso>(); //Un corso può avere più edizioni corso




        //COSTRUTTORE
        public Corso(long id, string titolo, string descrizione, int ammontareOre,
                    decimal costoRiferimento, long livelloId, long progettoId, long categoriaId)
        {
            Id = id;
            Titolo = titolo;
            Descrizione = descrizione;
            AmmontareOre = ammontareOre;
            CostoRiferimento = costoRiferimento;
            LivelloId = livelloId;  
            ProgettoId = progettoId;
            CategoriaId = categoriaId;
        }


        //METODO Override per stampare i dati nella classe
        public override string ToString() //Sovrascrive il metodo virtuale dell'oggetto per stampare quello che vogliamo
        {
            return $"id: {Id} titolo: {Titolo} ammontare ore: {AmmontareOre} costo riferimento: {CostoRiferimento} " +
                   $"\nDescrizione: {Descrizione}"; //Non è una stringa normale con $, ma posso ficcarci dentro le variabili
        }

        //Sovrascrivo il metodo base per comparare 2 oggetti di tipo Corso, comparando solo l'Id!
        public override bool Equals(object obj)
        {
            return obj is Corso corso && Id == corso.Id;
        }

        //Sovrascrivo il metodo base per generare il GetHashCode dell'oggetto in modo che diventi l'id dell'oggetto!
        public override int GetHashCode()
        {
            return (int)Id;
        }
        
    }

    //public ExperienceLevel EntryLevel { get; set; }
    //public enum ExperienceLevel
    //{
    //    PRINCIPIANTE, MEDIO, ESPERTO, GURU
    //}
}
