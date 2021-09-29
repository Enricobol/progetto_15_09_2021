using NodaTime; // Una libreria per usare LocalTime tipe data
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq; // Una libreria speciale! per cercare dentro un IEnumerable con una LAMBDA

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
            Corso c1 = new Corsi(345, "Matematica", 50, ExperienceLevel.PRINCIPIANTE, "molto bello", 19.99m);
            courses.Add(c1);
            Corso c2 = new Corsi(678, "Inglese", 45, ExperienceLevel.GURU, "molto brutto", 17.99m);
            courses.Add(c2);

            Console.WriteLine("Il numero di corsi nel set è {0}", courses.Count);

            EdizioneCorso e1 = new EdizioneCorso(1124, c1, new LocalDate(2021, 9, 20), new LocalDate(2021, 9, 30), 25, 64.21m);
            courseEditions.Add(e1);
            EdizioneCorso e2 = new EdizioneCorso(1135, c1, new LocalDate(2022, 9, 20), new LocalDate(2022, 9, 30), 18, 32.21m);
            courseEditions.Add(e2);
            EdizioneCorso e3 = new EdizioneCorso(1146, c1, new LocalDate(2023, 9, 20), new LocalDate(2023, 9, 30), 22, 32.21m);
            courseEditions.Add(e3);
            EdizioneCorso e4 = new EdizioneCorso(1157, c1, new LocalDate(2024, 9, 20), new LocalDate(2024, 9, 30), 30, 45.21m);
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
        public IEnumerable<EdizioneCorso> FindEditionByCourse(long courseId)
        {
            List<EdizioneCorso> editions = new List<EdizioneCorso>(); //Variabile lista per ficcarci dentro i corsi giusti
            foreach (var ed in courseEditions)
            {
                if (ed.Corso.Id == courseId) //Dobbiamo cercare per ogni: EdizioneCorso->Corso->ID = courseId
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

        public IEnumerable<EdizioneCorso> FindEditionsByCourse(long idCorso)
        {
            throw new NotImplementedException();
        }


    }
}
