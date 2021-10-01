using NodaTime;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Scuola.Entities
{
    public class EdizioneCorso
    {
        //PROPRIETA'
        public long Id { get; set; }
        public int CodiceEdizione { get; set; }
        public LocalDate DataInizio { get; set; }
        public LocalDate DataFine { get; set; }
        public decimal PrezzoFinale { get; set; }
        public int MinNumStudenti { get; set; }
        public int MaxNumStudenti { get; set; }
        public bool InPresenze { get; set; }

        //PROPRIETA' FOREING KEYS
        public int AulaId { get; set; }
        public int EnteFinanzianteId { get; set; }
        public int CorsoId { get; set; }
        //PROPRIETA' CLASSI
        public EnteFinanziante EnteFinanziante { get; set; }
        public Aula Aula { get; set; }
        public Corso Corso { get; set; }

        //private AddStudents ad; //Creo un delegato di classe AddStudents

        //COSTRUTTORE
        public EdizioneCorso(long id, int codiceEdizione, LocalDate dataInizio, LocalDate dataFine, decimal prezzoFinale, int minNumStudenti, int maxNumStudenti, 
                             bool inPresenze , int enteFinanzianteId, int aulaId, int corsoId)
        {
            Id = id;
            CodiceEdizione = codiceEdizione;
            DataInizio = dataInizio;
            DataFine = dataFine;
            PrezzoFinale = prezzoFinale;
            MinNumStudenti = minNumStudenti;
            MaxNumStudenti = maxNumStudenti;
            InPresenze = inPresenze;
            EnteFinanzianteId = enteFinanzianteId;
            AulaId = aulaId;
            CorsoId = corsoId;

            //ad += Iscrivi; //Uso un delegato
        }


        //METODO Override per stampare i dati nella classe
        public override string ToString()  //Sovrascrive il metodo virtuale dell'oggetto per stampare quello che vogliamo
        {
            return $"id: {Id} CodiceEdizione:{CodiceEdizione} Data inizio: {DataInizio} Prezzo finale: {PrezzoFinale}"; //Non è una stringa normale con $, ma posso ficcarci dentro le variabili
        }

        #region Esempi di funzioni delegate
        ////FUNZIONI DELEGATE
        //public int Iscrivi()
        //{
        //    return 10;
        //}
        //public void AggiornaEdizione()
        //{
        //    NumStudents += ad();
        //}
        //public void ChangeAdder(AddStudents x) //Passo un oggetto di classe Addstudents alla funzione
        //{
        //    ad = x;
        //}
        #endregion

    }

    //DELEGATI
    //public delegate int AddStudents(); //Posso puntare tutte le funzioni che ritornano un int e non prendono nulla  ----> FUNC
    //public delegate void EnrollStudents(int x); // "" "" "" non ritornano nulla ma richiedono un int
}
