using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scuola.Entities;
using Microsoft.Extensions.Logging; //L' EF stampa i comandi Sql

/// <summary>
/// Contesto di scuola: mappatura delle entità tra c# e il database
/// </summary>

namespace Scuola.Model.Data.EF
{
    public partial class ScuolaContext : DbContext
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
            optionsBuilder.UseSqlServer("Server = datahost; database = scuola2; User Id = sa; Password = 1Secure*Password;")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name, DbLoggerCategory.Database.Transaction.Name }, //Stampa in output sulla console tutti i comandi e le transizioni che lancia.
                LogLevel.Information).EnableSensitiveDataLogging(); //Abilita il sensitive data logging, logga la query e anche i parametri.
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.ToTable("Aule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CapMax).HasColumnName("capMax");

                entity.Property(e => e.IsComputerizzata).HasColumnName("computerizzata");

                entity.Property(e => e.IsFisica).HasColumnName("fisica");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nome");

                entity.Property(e => e.HaProiettore).HasColumnName("proiettore");
            });

            modelBuilder.Entity<Azienda>(entity =>
            {
                entity.ToTable("Aziende");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Citta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("città");

                entity.Property(e => e.CodicePostale)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("codicePostale");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Indirizzo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("indirizzo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nome");

                entity.Property(e => e.PartitaIva)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("partitaIva");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categorie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(100)
                    .HasColumnName("descrizione");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Competenza>(entity =>
            {
                entity.ToTable("Competenze");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LivelloId).HasColumnName("idLivello");

                entity.Property(e => e.PersonaId).HasColumnName("idPersona");

                entity.Property(e => e.SkillId).HasColumnName("idSkill");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note");

                entity.HasOne(d => d.Livello)
                    .WithMany(p => p.Competenze)
                    .HasForeignKey(d => d.LivelloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competenze_Livelli");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Competenze)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competenze_Persone");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Competenze)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competenze_Skills");
            });

            modelBuilder.Entity<Corso>(entity =>
            {
                entity.ToTable("Corsi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmmontareOre).HasColumnName("ammontareOre");

                entity.Property(e => e.CostoRiferimento)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("costoRiferimento");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(100)
                    .HasColumnName("descrizione");

                entity.Property(e => e.CategoriaId).HasColumnName("idCategoria");

                entity.Property(e => e.LivelloId).HasColumnName("idLivello");

                entity.Property(e => e.ProgettoId).HasColumnName("idProgetto");

                entity.Property(e => e.Titolo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("titolo");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Corsi)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Corsi_Categorie");

                entity.HasOne(d => d.Livello)
                    .WithMany(p => p.Corsi)
                    .HasForeignKey(d => d.LivelloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Corsi_Livelli");

                entity.HasOne(d => d.Progetto)
                    .WithMany(p => p.Corsi)
                    .HasForeignKey(d => d.ProgettoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Corsi_Progetti");
            });

            modelBuilder.Entity<EdizioneCorso>(entity =>
            {
                entity.ToTable("Edizioni");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodiceEdizione).HasColumnName("codiceEdizione");

                entity.Ignore(e => e.DataFine);

                entity.Ignore(e => e.DataInizio);

                entity.Property(e => e.AulaId).HasColumnName("idAula");

                entity.Property(e => e.CorsoId).HasColumnName("idCorso");

                entity.Property(e => e.EnteFinanzianteId).HasColumnName("idEntiFinanzianti");

                entity.Property(e => e.InPresenze).HasColumnName("inPresenze");

                entity.Property(e => e.MaxNumStudenti).HasColumnName("maxNumStudenti");

                entity.Property(e => e.MinNumStudenti).HasColumnName("minNumStudenti");

                entity.Property(e => e.PrezzoFinale)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("prezzoFinale");

                entity.HasOne(d => d.Aula)
                    .WithMany(p => p.EdizioniCorsi)
                    .HasForeignKey(d => d.AulaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Edizioni_Aule");

                entity.HasOne(d => d.Corso)
                    .WithMany(p => p.EdizioniCorsi)
                    .HasForeignKey(d => d.CorsoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Edizioni_Corsi");

                entity.HasOne(d => d.EnteFinanziante)
                    .WithMany(p => p.EdizioniCorsi)
                    .HasForeignKey(d => d.EnteFinanzianteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Edizioni_EntiFinanzianti");
            });

            modelBuilder.Entity<EnteFinanziante>(entity =>
            {
                entity.ToTable("EntiFinanzianti");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(100)
                    .HasColumnName("descrizione");

                entity.Property(e => e.Titolo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("titolo");
            });

            modelBuilder.Entity<Iscrizione>(entity =>
            {
                entity.ToTable("Iscrizioni");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataIscrizioni)
                    .HasColumnType("date")
                    .HasColumnName("dataIscrizioni");

                entity.Property(e => e.EdizioneCorsoId).HasColumnName("idEdizione");

                entity.Property(e => e.PersonaId).HasColumnName("idPersona");

                entity.Property(e => e.Pagata).HasColumnName("pagata");

                entity.Property(e => e.ValutazioneCorsi)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("valutazioneCorsi");

                entity.Property(e => e.ValutazioneStudente).HasColumnName("valutazioneStudente");

                entity.Property(e => e.VotoCorsi).HasColumnName("votoCorsi");

                entity.HasOne(d => d.EdizioneCorso)
                    .WithMany(p => p.Iscrizioni)
                    .HasForeignKey(d => d.EdizioneCorsoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Iscrizioni_Edizioni");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Iscrizioni)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Iscrizioni_Persone");
            });

            modelBuilder.Entity<Lezione>(entity =>
            {
                entity.ToTable("Lezioni");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(100)
                    .HasColumnName("descrizione");

                entity.Property(e => e.Fine)
                    .HasColumnType("date")
                    .HasColumnName("fine");

                entity.Property(e => e.AulaId).HasColumnName("idAula");

                entity.Property(e => e.ModuloId).HasColumnName("idModulo");

                entity.Property(e => e.PersonaId).HasColumnName("idPersona");

                entity.Property(e => e.Inizio)
                    .HasColumnType("date")
                    .HasColumnName("inizio");

                entity.HasOne(d => d.Aula)
                    .WithMany(p => p.Lezioni)
                    .HasForeignKey(d => d.AulaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lezioni_Aule");

                entity.HasOne(d => d.Modulo)
                    .WithMany(p => p.Lezioni)
                    .HasForeignKey(d => d.ModuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lezioni_Moduli");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Lezioni)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lezioni_Persone");
            });

            modelBuilder.Entity<Livello>(entity =>
            {
                entity.ToTable("Livelli");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(100)
                    .HasColumnName("descrizione");

                entity.Property(e => e.Tipologia)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("tipologia");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("Moduli");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(100)
                    .HasColumnName("descrizione");

                entity.Property(e => e.EdizioneCorsoId).HasColumnName("idEdizione");

                entity.Property(e => e.PersonaId).HasColumnName("idPersona");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nome");

                entity.Property(e => e.NumeroOre).HasColumnName("numeroOre");

                entity.HasOne(d => d.EdizioneCorso)
                    .WithMany(p => p.Moduli)
                    .HasForeignKey(d => d.EdizioneCorsoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Moduli_Edizione");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Moduli)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Moduli_Persona");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cf)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("cf");

                entity.Property(e => e.CittàResidenza)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("cittàResidenza");

                entity.Property(e => e.Cognome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("cognome");

                entity.Property(e => e.DataDiNascita)
                    .HasColumnType("date")
                    .HasColumnName("dataDiNascita");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.AziendaId).HasColumnName("idAzienda");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nome");

                entity.Property(e => e.PartitaIva)
                    .HasMaxLength(15)
                    .HasColumnName("partitaIva");

                entity.Property(e => e.Ruolo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ruolo");

                entity.Property(e => e.Sesso)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("sesso");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telefono")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Azienda)
                    .WithMany(p => p.Persone)
                    .HasForeignKey(d => d.AziendaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persone_Aziende");
            });

            modelBuilder.Entity<Presenza>(entity =>
            {
                entity.ToTable("Presenze");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fine)
                    .HasColumnType("date")
                    .HasColumnName("fine");

                entity.Property(e => e.LezioneId).HasColumnName("idLezione");

                entity.Property(e => e.PersonaId).HasColumnName("idPersona");

                entity.Property(e => e.Inizio)
                    .HasColumnType("date")
                    .HasColumnName("inizio");

                entity.Property(e => e.Nota)
                    .HasMaxLength(100)
                    .HasColumnName("nota");

                entity.HasOne(d => d.Lezione)
                    .WithMany(p => p.Presenze)
                    .HasForeignKey(d => d.LezioneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Presenze_Lezioni");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Presenze)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Presenze_Persone");
            });

            modelBuilder.Entity<Progetto>(entity =>
            {
                entity.ToTable("Progetti");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AziendaId).HasColumnName("idAzienda");

                entity.Property(e => e.Titolo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("titolo");

                entity.HasOne(d => d.Azienda)
                    .WithMany(p => p.Progetti)
                    .HasForeignKey(d => d.AziendaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Progetti_Azienda");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(100)
                    .HasColumnName("descrizione");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);







    }
}
