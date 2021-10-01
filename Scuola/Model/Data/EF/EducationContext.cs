using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scuola.Entities;
using Microsoft.Extensions.Logging; //L' EF stampa i comandi Sql

namespace Scuola.Model.Data.EF
{
    public class EducationContext : DbContext
    {
        //PROPRIETA'
        public virtual DbSet<Persona> Persone { get; set; }
        public virtual DbSet<Corso> Corsi { get; set; }
        public virtual DbSet<Aula> Aule { get; set; }

        metti tutti i dbsets!

        //EFFETTUIAMO L'OVERRIDE
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = datahost; database = Education; User Id = sa; Password = 1Secure*Password;")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name, DbLoggerCategory.Database.Transaction.Name }, //Stampa in output sulla console tutti i comandi e le transizioni che lancia.
                LogLevel.Information).EnableSensitiveDataLogging(); //Abilita il sensitive data logging, logga la query e anche i parametri.
        }
    }
}
