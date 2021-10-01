using NodaTime; // Una libreria per usare LocalTime tipe data
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq; // Una libreria speciale! per cercare dentro un IEnumerable con una LAMBDA
using Scuola.Entities;

namespace Scuola.Model.Data
{
    public class InMemoryRepository : IRepository //Implemento (Figlia di) IRepository
    {

        //VARIABILI
        // private List<Corso> courses = new List<Corso>(); //Lista di corsi
        // private List<EdizioneCorso> courseEditions = new List<EdizioneCorso>(); //Lista di edizioni corsi

        //Posso passare da list a set senza problemi
        private ISet<Corso> courses = new HashSet<Corso>(); //Set di elementi: Rifiuta i duplicati ed è estremamente efficiente nel trovare gli elementi
        private ISet<EdizioneCorso> courseEditions = new HashSet<EdizioneCorso>();

        //COSTRUTTORE
        public InMemoryRepository()
        {

            #region MyRegion VECCHIA CREAZIONE DATI
            //Popolo con dei corsi ed edizioni per vedere se funziona
            //long id, string titolo, string descrizione, int ammontareOre, decimal costoRiferimento, int idLivello, int idProgetto, int idCategoria
            Corso c1 = new Corso(345, "MateFagoilatica","Addizioni e sottrazioni legumari", 50, 500.50m, 1 , 1 , 1);
            courses.Add(c1);
            Corso c2 = new Corso(678, "AncheIProgrammMangianoFagiol", "Impara a mangiare i fagioli", 999, 0.50m, 1, 2, 2);
            courses.Add(c2);

            Console.WriteLine("Il numero di corsi nel set è {0}", courses.Count);
            //long id, int codiceEdizione, LocalDate dataInizio, LocalDate dataFine, decimal prezzoFinale, int minNumStudenti, int maxNumStudenti,bool inPresenze, int idEnteFinanziante,int idAula, int idCorso
            EdizioneCorso e1 = new EdizioneCorso(0, 0, new LocalDate(2022, 9, 20), new LocalDate(2022, 9, 23), 29.99m, 3, 24, true, 1, 2, 4);
            e1.Corso = c1;
            courseEditions.Add(e1);
            EdizioneCorso e2 = new EdizioneCorso(1, 1, new LocalDate(2022, 8, 20), new LocalDate(2022, 8, 23), 500.99m, 5, 32, false, 2, 1, 4);
            e2.Corso = c1;
            courseEditions.Add(e2);
            EdizioneCorso e3 = new EdizioneCorso(3, 3, new LocalDate(2023, 9, 20), new LocalDate(2023, 9, 23), 79.99m, 12, 44, true, 1, 2, 5);
            e3.Corso = c2;
            courseEditions.Add(e3);
            EdizioneCorso e4 = new EdizioneCorso(4, 4, new LocalDate(2023, 9, 10), new LocalDate(2023, 10, 23), 20.99m, 53, 1000, false, 2, 1, 5);
            e4.Corso = c2;
            courseEditions.Add(e4);

            #endregion

        }

        
           
        #region METODO AddCourse : Aggiunge un corso nella lista, a meno che non sia già dentro, ritrona il corso come flag.
        public Corso AddCourse(Corso corso)
        {
            bool added = courses.Add(corso);
            return added ? corso : null;
        }

        //public Corso AddCourse(Corso corso)
        //{
        //    if (courses.Contains(corso))
        //    {
        //        return null;
        //    } 

        //    courses.Add(corso);
        //    return corso; //Flag per dire che lo abbiamo aggiunto             
        //}
        #endregion

        #region METODO FindEditionByCourse : Dato il numero ID voglio tutte le edizioni di corso con quell'id inseriti in un IEnumerable.
        public IEnumerable<EdizioneCorso> FindEditionsByCourse(long courseId)
        {
            List<EdizioneCorso> editions = new List<EdizioneCorso>(); //Variabile lista per ficcarci dentro i corsi giusti
            foreach (var ed in courseEditions)
            {

                if ((int)ed.Corso.Id == (int)courseId) //Dobbiamo cercare per ogni: EdizioneCorso->Corso->ID = courseId
                {
                    editions.Add(ed); //Ficco nella lista che ritornerò il corso con l'Id
                    
                }
            }
            return editions;
        }
        #endregion

        # region METODO GetCourses : Ritira la lista dei corsi, ma rendila più sicura tramite l'use di IEnumerable.
        public IEnumerable<Corso> GetCourses()
        {
            return courses;
        }
        #endregion

        #region METODO AddEdizione : Aggiunge Edizone corso alla lista Edizioni
        public EdizioneCorso AddEdizione(EdizioneCorso e)
        {
            courseEditions.Add(e);
            return e;
        }
        #endregion

        #region METODO BetterFindCourseById : Utilizza la funzione speciale LAMBDA
        public Corso BetterFindCourseById(long id)
        {
            Corso found = courses.SingleOrDefault(c => c.Id == id); //Metodo che ricerca un unico elemento che rispetta la ricerca, altrimenti ritorna un default. Si chiama Lambda
                                                                    //input => output :  Cerca nella lista un c tale che c.id sia uguale a id
            return found;
        }
        #endregion

        #region METODO GenerateReport
        public Report GenerateReport(long idCorso)
        {
            return new Report();
        }
        #endregion

        #region METODO CourseExists
        public bool CourseExists(Corso c) //Cerco se esiste un corso nella lista, in caso ritorno un bool
        {
            bool itExist = courses.Contains(c);
            //Posso usare equals che è modificato.
            return itExist;
        }
        #endregion


        //METODI DATABASE
        public Corso FindCourseById(long id)
        {
            throw new NotImplementedException();
        }

        public Corso UpdateCourse(Corso corso)
        {
            throw new NotImplementedException();
        }

    }
}
