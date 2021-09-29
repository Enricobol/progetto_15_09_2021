using Scuola.Model;
using Scuola.Model.Data;
using System;
using NodaTime;
using System.Collections.Generic;

namespace Scuola
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repo = new InMemoryRepository(); //Creo una nuova reopsitry dove memorizzare Corsi ed Edizioni
            CourseService cs = new CourseService(repo);  //Creo un servizio corsi e gli ignetto la repositry in modo che la usi
            UserInterface ui = new UserInterface(cs);    //Creo l'interfaccia utente e gli ignetto il servizio



            //Parto con l'interfaccia
            ui.Start();

            #region Esempi di Delegati 
            //EdizioneCorso ed = new EdizioneCorso(1124, null, new LocalDate(2021, 9, 20), new LocalDate(2021, 9, 30), 25, 64.21m);
            //Console.WriteLine(ed.NumStudents);
            //ed.AggiornaEdizione();
            //Console.WriteLine(ed.NumStudents);
            //ed.ChangeAdder(Enroll); //Equivale a: ed.ChangeAdder(new Addstudents(Enroll))
            //ed.AggiornaEdizione();
            //Console.WriteLine(ed.NumStudents);

            //Func<int> myFunc = Enroll; //Equivale a: Func<int> myFunc2 = new Func<int>(Enroll); Che equivale a: AddStudents ads = new AddStudents(Enroll);

            #endregion
            //1
            //Modificare le classi edizioneCoros e Corso in base alle specifiche presenti nel database così da essere coerenti
            // rispetto al database scuola. Modificare il codice esistente di conseguenza.

            //2
            //Creare una seconda implementazione di IRepository che vada ad agire direttamente sul database tramite ADO.net che riesca
            //a gestire le modifiche e le richieste sul DB

            Console.WriteLine("Prendi tutti i corsi dal Database\n");
            RepositoryDB repoDB = new RepositoryDB();
            IEnumerable<Corso> cl = new List<Corso>();
            cl = repoDB.GetCourses();
            foreach (var Id in cl)
            {
                Console.WriteLine(Id.ToString());
            }


            //IEnumerable<EdizioneCorso> ecl = new List<EdizioneCorso>();
            //ecl = repoDB.FindEditionsByCourse(1);
            //foreach (var Id in ecl)
            //{
            //    Console.WriteLine(Id.Id);
            //}
            Console.WriteLine("Missione compiuta\n");
            Console.ReadKey();
        }

        //static int Enroll()
        //{
        //    return 20;
        //}
    }
}
