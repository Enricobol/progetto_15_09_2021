using Scuola.Model;
using Scuola.Model.Data;
using System;
using NodaTime;
using System.Collections.Generic;
using Scuola.Entities;
using Scuola.Model.Data;
using Scuola.Model.Data.InMemory;

namespace Scuola
{
    class Program
    {
        static void Main(string[] args)
        {
            //METODI IN MEMORIA
            IRepository repo = new InMemoryRepository(); //Creo una nuova reopsitry dove memorizzare Corsi ed Edizioni
            CourseService cs = new CourseService(repo);  //Creo un servizio corsi e gli ignetto la repositry in modo che la usi
            UserInterface ui = new UserInterface(cs);    //Creo l'interfaccia utente e gli ignetto il servizio


            var corso1 = new Corso(1, "Matematica molto bello", "Non so cosa sia", 20, 500, 1, 1, 1);
            ICrudRepository<Corso, long> repo2 = new InMemoryCourseRepository();
            var coso = repo2.Create(corso1);



            //Parto con l'interfaccia
            ui.Start();

            ////METODI ADO
            //Console.WriteLine("Prendi tutti i corsi dal Database\n");
            //RepositoryDB repoDB = new RepositoryDB();
            //IEnumerable<Corso> cl = new List<Corso>();
            //cl = repoDB.GetCourses();

            //foreach (var Id in cl)
            //{
            //    Console.WriteLine(Id.ToString());
            //}

            //Console.WriteLine("Prendi tutte le edizioni corso di 2\n");
            //IEnumerable<EdizioneCorso> ecl = new List<EdizioneCorso>();
            //ecl = repoDB.FindEditionsByCourse(2);
            //foreach (var Id in ecl)
            //{
            //    Console.WriteLine(Id.ToString());
            //}
            //Console.WriteLine("Missione compiuta\n");
            //Console.ReadKey();
        }

        //static int Enroll()
        //{
        //    return 20;
        //}

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
    }
}
