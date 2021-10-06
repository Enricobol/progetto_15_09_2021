﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scuola.Model.Data.EF;

namespace Scuola.Migrations
{
    [DbContext(typeof(ScuolaContext))]
    partial class EducationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Scuola.Entities.Aula", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapMax")
                        .HasColumnType("int")
                        .HasColumnName("capMax");

                    b.Property<bool?>("HaProiettore")
                        .HasColumnType("bit")
                        .HasColumnName("proiettore");

                    b.Property<bool?>("IsComputerizzata")
                        .HasColumnType("bit")
                        .HasColumnName("computerizzata");

                    b.Property<bool>("IsFisica")
                        .HasColumnType("bit")
                        .HasColumnName("fisica");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Aule");
                });

            modelBuilder.Entity("Scuola.Entities.Azienda", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Citta")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("città");

                    b.Property<string>("CodicePostale")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("codicePostale");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("indirizzo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("nome");

                    b.Property<string>("PartitaIva")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("partitaIva");

                    b.HasKey("Id");

                    b.ToTable("Aziende");
                });

            modelBuilder.Entity("Scuola.Entities.Categoria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("descrizione");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("Scuola.Entities.Competenza", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("LivelloId")
                        .HasColumnType("bigint")
                        .HasColumnName("idLivello");

                    b.Property<string>("Note")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("note");

                    b.Property<long>("PersonaId")
                        .HasColumnType("bigint")
                        .HasColumnName("idPersona");

                    b.Property<long>("SkillId")
                        .HasColumnType("bigint")
                        .HasColumnName("idSkill");

                    b.HasKey("Id");

                    b.HasIndex("LivelloId");

                    b.HasIndex("PersonaId");

                    b.HasIndex("SkillId");

                    b.ToTable("Competenze");
                });

            modelBuilder.Entity("Scuola.Entities.Corso", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmmontareOre")
                        .HasColumnType("int")
                        .HasColumnName("ammontareOre");

                    b.Property<long>("CategoriaId")
                        .HasColumnType("bigint")
                        .HasColumnName("idCategoria");

                    b.Property<decimal>("CostoRiferimento")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("costoRiferimento");

                    b.Property<string>("Descrizione")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("descrizione");

                    b.Property<long>("LivelloId")
                        .HasColumnType("bigint")
                        .HasColumnName("idLivello");

                    b.Property<long>("ProgettoId")
                        .HasColumnType("bigint")
                        .HasColumnName("idProgetto");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("titolo");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("LivelloId");

                    b.HasIndex("ProgettoId");

                    b.ToTable("Corsi");
                });

            modelBuilder.Entity("Scuola.Entities.EdizioneCorso", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AulaId")
                        .HasColumnType("bigint")
                        .HasColumnName("idAula");

                    b.Property<int>("CodiceEdizione")
                        .HasColumnType("int")
                        .HasColumnName("codiceEdizione");

                    b.Property<long>("CorsoId")
                        .HasColumnType("bigint")
                        .HasColumnName("idCorso");

                    b.Property<long>("EnteFinanzianteId")
                        .HasColumnType("bigint")
                        .HasColumnName("idEntiFinanzianti");

                    b.Property<bool>("InPresenze")
                        .HasColumnType("bit")
                        .HasColumnName("inPresenze");

                    b.Property<int>("MaxNumStudenti")
                        .HasColumnType("int")
                        .HasColumnName("maxNumStudenti");

                    b.Property<int>("MinNumStudenti")
                        .HasColumnType("int")
                        .HasColumnName("minNumStudenti");

                    b.Property<decimal>("PrezzoFinale")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("prezzoFinale");

                    b.HasKey("Id");

                    b.HasIndex("AulaId");

                    b.HasIndex("CorsoId");

                    b.HasIndex("EnteFinanzianteId");

                    b.ToTable("EdizioniCorsi");
                });

            modelBuilder.Entity("Scuola.Entities.EnteFinanziante", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("descrizione");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("titolo");

                    b.HasKey("Id");

                    b.ToTable("EntiFinanzianti");
                });

            modelBuilder.Entity("Scuola.Entities.Iscrizione", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataIscrizioni")
                        .HasColumnType("date")
                        .HasColumnName("dataIscrizioni");

                    b.Property<long>("EdizioneCorsoId")
                        .HasColumnType("bigint")
                        .HasColumnName("idEdizioneCorso");

                    b.Property<bool>("Pagata")
                        .HasColumnType("bit")
                        .HasColumnName("pagata");

                    b.Property<long>("PersonaId")
                        .HasColumnType("bigint")
                        .HasColumnName("idPersona");

                    b.Property<string>("ValutazioneCorsi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("valutazioneCorsi");

                    b.Property<int>("ValutazioneStudente")
                        .HasColumnType("int")
                        .HasColumnName("valutazioneStudente");

                    b.Property<int>("VotoCorsi")
                        .HasColumnType("int")
                        .HasColumnName("votoCorsi");

                    b.HasKey("Id");

                    b.HasIndex("EdizioneCorsoId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Iscrizioni");
                });

            modelBuilder.Entity("Scuola.Entities.Lezione", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AulaId")
                        .HasColumnType("bigint")
                        .HasColumnName("idAula");

                    b.Property<string>("Descrizione")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("descrizione");

                    b.Property<DateTime>("Fine")
                        .HasColumnType("date")
                        .HasColumnName("fine");

                    b.Property<DateTime>("Inizio")
                        .HasColumnType("date")
                        .HasColumnName("inizio");

                    b.Property<long>("ModuloId")
                        .HasColumnType("bigint")
                        .HasColumnName("idModulo");

                    b.Property<long>("PersonaId")
                        .HasColumnType("bigint")
                        .HasColumnName("idPersona");

                    b.HasKey("Id");

                    b.HasIndex("AulaId");

                    b.HasIndex("ModuloId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Lezioni");
                });

            modelBuilder.Entity("Scuola.Entities.Livello", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("descrizione");

                    b.Property<string>("Tipologia")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("tipologia");

                    b.HasKey("Id");

                    b.ToTable("Livelli");
                });

            modelBuilder.Entity("Scuola.Entities.Modulo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("descrizione");

                    b.Property<long>("EdizioneCorsoId")
                        .HasColumnType("bigint")
                        .HasColumnName("idEdizioneCorso");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("nome");

                    b.Property<int>("NumeroOre")
                        .HasColumnType("int")
                        .HasColumnName("numeroOre");

                    b.Property<long>("PersonaId")
                        .HasColumnType("bigint")
                        .HasColumnName("idPersona");

                    b.HasKey("Id");

                    b.HasIndex("EdizioneCorsoId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Moduli");
                });

            modelBuilder.Entity("Scuola.Entities.Persona", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AziendaId")
                        .HasColumnType("bigint")
                        .HasColumnName("idAzienda");

                    b.Property<string>("Cf")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("cf");

                    b.Property<string>("CittàResidenza")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("cittàResidenza");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("cognome");

                    b.Property<DateTime>("DataDiNascita")
                        .HasColumnType("date")
                        .HasColumnName("dataDiNascita");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("nome");

                    b.Property<string>("PartitaIva")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("partitaIva");

                    b.Property<string>("Ruolo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("ruolo");

                    b.Property<string>("Sesso")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("sesso");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .HasColumnName("telefono")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.HasIndex("AziendaId");

                    b.ToTable("Persone");
                });

            modelBuilder.Entity("Scuola.Entities.Presenza", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fine")
                        .HasColumnType("date")
                        .HasColumnName("fine");

                    b.Property<DateTime>("Inizio")
                        .HasColumnType("date")
                        .HasColumnName("inizio");

                    b.Property<long>("LezioneId")
                        .HasColumnType("bigint")
                        .HasColumnName("idLezione");

                    b.Property<string>("Nota")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nota");

                    b.Property<long>("PersonaId")
                        .HasColumnType("bigint")
                        .HasColumnName("idPersona");

                    b.HasKey("Id");

                    b.HasIndex("LezioneId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Presenze");
                });

            modelBuilder.Entity("Scuola.Entities.Progetto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AziendaId")
                        .HasColumnType("bigint")
                        .HasColumnName("idAzienda");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("titolo");

                    b.HasKey("Id");

                    b.HasIndex("AziendaId");

                    b.ToTable("Progetti");
                });

            modelBuilder.Entity("Scuola.Entities.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("descrizione");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Scuola.Entities.Competenza", b =>
                {
                    b.HasOne("Scuola.Entities.Livello", "Livello")
                        .WithMany("Competenze")
                        .HasForeignKey("LivelloId")
                        .HasConstraintName("FK_Competenze_Livelli")
                        .IsRequired();

                    b.HasOne("Scuola.Entities.Persona", "Persona")
                        .WithMany("Competenze")
                        .HasForeignKey("PersonaId")
                        .HasConstraintName("FK_Competenze_Persone")
                        .IsRequired();

                    b.HasOne("Scuola.Entities.Skill", "Skill")
                        .WithMany("Competenze")
                        .HasForeignKey("SkillId")
                        .HasConstraintName("FK_Competenze_Skills")
                        .IsRequired();

                    b.Navigation("Livello");

                    b.Navigation("Persona");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Scuola.Entities.Corso", b =>
                {
                    b.HasOne("Scuola.Entities.Categoria", "Categoria")
                        .WithMany("Corsi")
                        .HasForeignKey("CategoriaId")
                        .HasConstraintName("FK_Corsi_Categorie")
                        .IsRequired();

                    b.HasOne("Scuola.Entities.Livello", "Livello")
                        .WithMany("Corsi")
                        .HasForeignKey("LivelloId")
                        .HasConstraintName("FK_Corsi_Livelli")
                        .IsRequired();

                    b.HasOne("Scuola.Entities.Progetto", "Progetto")
                        .WithMany("Corsi")
                        .HasForeignKey("ProgettoId")
                        .HasConstraintName("FK_Corsi_Progetti")
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Livello");

                    b.Navigation("Progetto");
                });

            modelBuilder.Entity("Scuola.Entities.EdizioneCorso", b =>
                {
                    b.HasOne("Scuola.Entities.Aula", "Aula")
                        .WithMany("EdizioniCorsi")
                        .HasForeignKey("AulaId")
                        .HasConstraintName("FK_EdizioniCorsi_Aule")
                        .IsRequired();

                    b.HasOne("Scuola.Entities.Corso", "Corso")
                        .WithMany("EdizioniCorsi")
                        .HasForeignKey("CorsoId")
                        .HasConstraintName("FK_EdizioniCorsi_Corsi")
                        .IsRequired();

                    b.HasOne("Scuola.Entities.EnteFinanziante", "EnteFinanziante")
                        .WithMany("EdizioniCorsi")
                        .HasForeignKey("EnteFinanzianteId")
                        .HasConstraintName("FK_EdizioniCorsi_EntiFinanzianti")
                        .IsRequired();

                    b.Navigation("Aula");

                    b.Navigation("Corso");

                    b.Navigation("EnteFinanziante");
                });

            modelBuilder.Entity("Scuola.Entities.Iscrizione", b =>
                {
                    b.HasOne("Scuola.Entities.EdizioneCorso", "EdizioneCorso")
                        .WithMany("Iscrizioni")
                        .HasForeignKey("EdizioneCorsoId")
                        .HasConstraintName("FK_Iscrizioni_EdizioniCorsi")
                        .IsRequired();

                    b.HasOne("Scuola.Entities.Persona", "Persona")
                        .WithMany("Iscrizioni")
                        .HasForeignKey("PersonaId")
                        .HasConstraintName("FK_Iscrizioni_Persone")
                        .IsRequired();

                    b.Navigation("EdizioneCorso");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Scuola.Entities.Lezione", b =>
                {
                    b.HasOne("Scuola.Entities.Aula", "Aula")
                        .WithMany("Lezioni")
                        .HasForeignKey("AulaId")
                        .HasConstraintName("FK_Lezioni_Aule")
                        .IsRequired();

                    b.HasOne("Scuola.Entities.Modulo", "Modulo")
                        .WithMany("Lezioni")
                        .HasForeignKey("ModuloId")
                        .HasConstraintName("FK_Lezioni_Moduli")
                        .IsRequired();

                    b.HasOne("Scuola.Entities.Persona", "Persona")
                        .WithMany("Lezioni")
                        .HasForeignKey("PersonaId")
                        .HasConstraintName("FK_Lezioni_Persone")
                        .IsRequired();

                    b.Navigation("Aula");

                    b.Navigation("Modulo");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Scuola.Entities.Modulo", b =>
                {
                    b.HasOne("Scuola.Entities.EdizioneCorso", "EdizioneCorso")
                        .WithMany("Moduli")
                        .HasForeignKey("EdizioneCorsoId")
                        .HasConstraintName("FK_Moduli_EdizioneCorso")
                        .IsRequired();

                    b.HasOne("Scuola.Entities.Persona", "Persona")
                        .WithMany("Moduli")
                        .HasForeignKey("PersonaId")
                        .HasConstraintName("FK_Moduli_Persona")
                        .IsRequired();

                    b.Navigation("EdizioneCorso");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Scuola.Entities.Persona", b =>
                {
                    b.HasOne("Scuola.Entities.Azienda", "Azienda")
                        .WithMany("Persone")
                        .HasForeignKey("AziendaId")
                        .HasConstraintName("FK_Persone_Aziende")
                        .IsRequired();

                    b.Navigation("Azienda");
                });

            modelBuilder.Entity("Scuola.Entities.Presenza", b =>
                {
                    b.HasOne("Scuola.Entities.Lezione", "Lezione")
                        .WithMany("Presenze")
                        .HasForeignKey("LezioneId")
                        .HasConstraintName("FK_Presenze_Lezioni")
                        .IsRequired();

                    b.HasOne("Scuola.Entities.Persona", "Persona")
                        .WithMany("Presenze")
                        .HasForeignKey("PersonaId")
                        .HasConstraintName("FK_Presenze_Persone")
                        .IsRequired();

                    b.Navigation("Lezione");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Scuola.Entities.Progetto", b =>
                {
                    b.HasOne("Scuola.Entities.Azienda", "Azienda")
                        .WithMany("Progetti")
                        .HasForeignKey("AziendaId")
                        .HasConstraintName("FK_Progetti_Azienda")
                        .IsRequired();

                    b.Navigation("Azienda");
                });

            modelBuilder.Entity("Scuola.Entities.Aula", b =>
                {
                    b.Navigation("EdizioniCorsi");

                    b.Navigation("Lezioni");
                });

            modelBuilder.Entity("Scuola.Entities.Azienda", b =>
                {
                    b.Navigation("Persone");

                    b.Navigation("Progetti");
                });

            modelBuilder.Entity("Scuola.Entities.Categoria", b =>
                {
                    b.Navigation("Corsi");
                });

            modelBuilder.Entity("Scuola.Entities.Corso", b =>
                {
                    b.Navigation("EdizioniCorsi");
                });

            modelBuilder.Entity("Scuola.Entities.EdizioneCorso", b =>
                {
                    b.Navigation("Iscrizioni");

                    b.Navigation("Moduli");
                });

            modelBuilder.Entity("Scuola.Entities.EnteFinanziante", b =>
                {
                    b.Navigation("EdizioniCorsi");
                });

            modelBuilder.Entity("Scuola.Entities.Lezione", b =>
                {
                    b.Navigation("Presenze");
                });

            modelBuilder.Entity("Scuola.Entities.Livello", b =>
                {
                    b.Navigation("Competenze");

                    b.Navigation("Corsi");
                });

            modelBuilder.Entity("Scuola.Entities.Modulo", b =>
                {
                    b.Navigation("Lezioni");
                });

            modelBuilder.Entity("Scuola.Entities.Persona", b =>
                {
                    b.Navigation("Competenze");

                    b.Navigation("Iscrizioni");

                    b.Navigation("Lezioni");

                    b.Navigation("Moduli");

                    b.Navigation("Presenze");
                });

            modelBuilder.Entity("Scuola.Entities.Progetto", b =>
                {
                    b.Navigation("Corsi");
                });

            modelBuilder.Entity("Scuola.Entities.Skill", b =>
                {
                    b.Navigation("Competenze");
                });
#pragma warning restore 612, 618
        }
    }
}