using NodaTime;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Scuola.Model
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
        public int IdAula { get; set; }
        public int IdEnteFinanziante { get; set; }
        public int IdCorso { get; set; }
        //PROPRIETA' CLASSI
        public EnteFinanziante EnteFinanziante { get; set; }
        public Aula Aula { get; set; }
        public Corso Corso { get; set; }

        //private AddStudents ad; //Creo un delegato di classe AddStudents

        //COSTRUTTORE
        public EdizioneCorso(long id, int codiceEdizione, LocalDate dataInizio, LocalDate dataFine, decimal prezzoFinale, int minNumStudenti, int maxNumStudenti, 
                             bool inPresenze , int idEnteFinanziante ,int idAula , int idCorso)
        {
            Id = id;
            CodiceEdizione = codiceEdizione;
            DataInizio = dataInizio;
            DataFine = dataFine;
            PrezzoFinale = prezzoFinale;
            MinNumStudenti = minNumStudenti;
            MaxNumStudenti = maxNumStudenti;
            InPresenze = inPresenze;
            IdEnteFinanziante = idEnteFinanziante;
            IdAula = idAula;
            IdCorso = idCorso;

            //ad += Iscrivi; //Uso un delegato
        }

        public override string ToString()  //Sovrascrive il metodo virtuale dell'oggetto per stampare quello che vogliamo
        {
            return $"id: {Id} titolo: {Corso.Titolo} Data inizio: {DataInizio} Prezzo finale: {PrezzoFinale}"; //Non è una stringa normale con $, ma posso ficcarci dentro le variabili
        }

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


    }

    //DELEGATI
    public delegate int AddStudents(); //Posso puntare tutte le funzioni che ritornano un int e non prendono nulla  ----> FUNC
    public delegate void EnrollStudents(int x); // "" "" "" non ritornano nulla ma richiedono un int
}
