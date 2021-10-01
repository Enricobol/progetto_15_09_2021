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
        public virtual DbSet<Aula> Aule { get; set; }
        public virtual DbSet<Azienda> Aziende { get; set; }
        public virtual DbSet<Categoria> Categorie { get; set; }
        public virtual DbSet<Competenza> Competenze { get; set; }
        public virtual DbSet<Corso> Corsi { get; set; }

        public virtual DbSet<EdizioneCorso> EdizioniCorsi { get; set; }
        public virtual DbSet<EnteFinanziante> EntiFinanzianti { get; set; }
        public virtual DbSet<Iscrizione> Iscrizioni { get; set; }
        public virtual DbSet<Lezione> Lezioni { get; set; }
        public virtual DbSet<Livello> Livelli { get; set; }

        public virtual DbSet<Modulo> Moduli { get; set; }
        public virtual DbSet<Persona> Persone { get; set; }
        public virtual DbSet<Presenza> Presenze { get; set; }
        public virtual DbSet<Progetto> Progetti { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        //EFFETTUIAMO L'OVERRIDE
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = datahost; database = Education; User Id = sa; Password = 1Secure*Password;")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name, DbLoggerCategory.Database.Transaction.Name }, //Stampa in output sulla console tutti i comandi e le transizioni che lancia.
                LogLevel.Information).EnableSensitiveDataLogging(); //Abilita il sensitive data logging, logga la query e anche i parametri.
        }
    }
}
