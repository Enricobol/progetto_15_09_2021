using Scuola.Model;
using Scuola.Model.Data;
using System;
using NodaTime;
using System.Collections.Generic;
using Scuola.Entities;
using Scuola.Model.Data.InMemory;
using Scuola.Model.Data.EF;
using Microsoft.EntityFrameworkCore;

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
            //Parto con l'interfaccia utente
            ui.Start();

            //Metodi EntityFramework
            //using (var ctx = new EducationContext())
            //{
            //    var c1 = new Corso()
            //    {
            //        Titolo = "Matematica",
            //        Descrizione = "Addizioni, sottrazioni e divisioni",
            //        AmmontareOre = 2,
            //        CostoRiferimento = 10,
            //        LivelloId = 1,
            //        ProgettoId = 2,
            //        CategoriaId = 1,           
            //    };

            //    EFCrudRepository<Corso, long> repoC = new EFCrudRepository<Corso, long>(ctx);
            //    var s2 = repoC.Create(c1);
            //    Console.WriteLine(s2.Id);
            //    Console.WriteLine(c1.Id);
            //     Console.ReadKey();               

            //}

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
