using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scuola.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aule",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    capMax = table.Column<int>(type: "int", nullable: false),
                    fisica = table.Column<bool>(type: "bit", nullable: false),
                    computerizzata = table.Column<bool>(type: "bit", nullable: true),
                    proiettore = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aule", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Aziende",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    indirizzo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    città = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    codicePostale = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    partitaIva = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aziende", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EntiFinanzianti",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titolo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntiFinanzianti", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Livelli",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipologia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livelli", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Persone",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    cognome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    dataDiNascita = table.Column<DateTime>(type: "date", nullable: false),
                    cf = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    sesso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    cittàResidenza = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    telefono = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    ruolo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    partitaIva = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    idAzienda = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persone", x => x.id);
                    table.ForeignKey(
                        name: "FK_Persone_Aziende",
                        column: x => x.idAzienda,
                        principalTable: "Aziende",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Progetti",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titolo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    idAzienda = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progetti", x => x.id);
                    table.ForeignKey(
                        name: "FK_Progetti_Azienda",
                        column: x => x.idAzienda,
                        principalTable: "Aziende",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competenze",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    idPersona = table.Column<long>(type: "bigint", nullable: false),
                    idSkill = table.Column<long>(type: "bigint", nullable: false),
                    idLivello = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competenze", x => x.id);
                    table.ForeignKey(
                        name: "FK_Competenze_Livelli",
                        column: x => x.idLivello,
                        principalTable: "Livelli",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competenze_Persone",
                        column: x => x.idPersona,
                        principalTable: "Persone",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competenze_Skills",
                        column: x => x.idSkill,
                        principalTable: "Skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Corsi",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titolo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ammontareOre = table.Column<int>(type: "int", nullable: false),
                    costoRiferimento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    idLivello = table.Column<long>(type: "bigint", nullable: false),
                    idProgetto = table.Column<long>(type: "bigint", nullable: false),
                    idCategoria = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corsi", x => x.id);
                    table.ForeignKey(
                        name: "FK_Corsi_Categorie",
                        column: x => x.idCategoria,
                        principalTable: "Categorie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Corsi_Livelli",
                        column: x => x.idLivello,
                        principalTable: "Livelli",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Corsi_Progetti",
                        column: x => x.idProgetto,
                        principalTable: "Progetti",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EdizioniCorsi",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codiceEdizione = table.Column<int>(type: "int", nullable: false),
                    prezzoFinale = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    minNumStudenti = table.Column<int>(type: "int", nullable: false),
                    maxNumStudenti = table.Column<int>(type: "int", nullable: false),
                    inPresenze = table.Column<bool>(type: "bit", nullable: false),
                    idAula = table.Column<long>(type: "bigint", nullable: false),
                    idEntiFinanzianti = table.Column<long>(type: "bigint", nullable: false),
                    idCorso = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdizioniCorsi", x => x.id);
                    table.ForeignKey(
                        name: "FK_EdizioniCorsi_Aule",
                        column: x => x.idAula,
                        principalTable: "Aule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EdizioniCorsi_Corsi",
                        column: x => x.idCorso,
                        principalTable: "Corsi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EdizioniCorsi_EntiFinanzianti",
                        column: x => x.idEntiFinanzianti,
                        principalTable: "EntiFinanzianti",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Iscrizioni",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataIscrizioni = table.Column<DateTime>(type: "date", nullable: false),
                    valutazioneCorsi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    votoCorsi = table.Column<int>(type: "int", nullable: false),
                    valutazioneStudente = table.Column<int>(type: "int", nullable: false),
                    pagata = table.Column<bool>(type: "bit", nullable: false),
                    idPersona = table.Column<long>(type: "bigint", nullable: false),
                    idEdizioneCorso = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iscrizioni", x => x.id);
                    table.ForeignKey(
                        name: "FK_Iscrizioni_EdizioniCorsi",
                        column: x => x.idEdizioneCorso,
                        principalTable: "EdizioniCorsi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Iscrizioni_Persone",
                        column: x => x.idPersona,
                        principalTable: "Persone",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Moduli",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    numeroOre = table.Column<int>(type: "int", nullable: false),
                    descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    idPersona = table.Column<long>(type: "bigint", nullable: false),
                    idEdizioneCorso = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moduli", x => x.id);
                    table.ForeignKey(
                        name: "FK_Moduli_EdizioneCorso",
                        column: x => x.idEdizioneCorso,
                        principalTable: "EdizioniCorsi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moduli_Persona",
                        column: x => x.idPersona,
                        principalTable: "Persone",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lezioni",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inizio = table.Column<DateTime>(type: "date", nullable: false),
                    fine = table.Column<DateTime>(type: "date", nullable: false),
                    descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    idAula = table.Column<long>(type: "bigint", nullable: false),
                    idPersona = table.Column<long>(type: "bigint", nullable: false),
                    idModulo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lezioni", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lezioni_Aule",
                        column: x => x.idAula,
                        principalTable: "Aule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lezioni_Moduli",
                        column: x => x.idModulo,
                        principalTable: "Moduli",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lezioni_Persone",
                        column: x => x.idPersona,
                        principalTable: "Persone",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presenze",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inizio = table.Column<DateTime>(type: "date", nullable: false),
                    fine = table.Column<DateTime>(type: "date", nullable: false),
                    nota = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    idPersona = table.Column<long>(type: "bigint", nullable: false),
                    idLezione = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenze", x => x.id);
                    table.ForeignKey(
                        name: "FK_Presenze_Lezioni",
                        column: x => x.idLezione,
                        principalTable: "Lezioni",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presenze_Persone",
                        column: x => x.idPersona,
                        principalTable: "Persone",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competenze_idLivello",
                table: "Competenze",
                column: "idLivello");

            migrationBuilder.CreateIndex(
                name: "IX_Competenze_idPersona",
                table: "Competenze",
                column: "idPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Competenze_idSkill",
                table: "Competenze",
                column: "idSkill");

            migrationBuilder.CreateIndex(
                name: "IX_Corsi_idCategoria",
                table: "Corsi",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Corsi_idLivello",
                table: "Corsi",
                column: "idLivello");

            migrationBuilder.CreateIndex(
                name: "IX_Corsi_idProgetto",
                table: "Corsi",
                column: "idProgetto");

            migrationBuilder.CreateIndex(
                name: "IX_EdizioniCorsi_idAula",
                table: "EdizioniCorsi",
                column: "idAula");

            migrationBuilder.CreateIndex(
                name: "IX_EdizioniCorsi_idCorso",
                table: "EdizioniCorsi",
                column: "idCorso");

            migrationBuilder.CreateIndex(
                name: "IX_EdizioniCorsi_idEntiFinanzianti",
                table: "EdizioniCorsi",
                column: "idEntiFinanzianti");

            migrationBuilder.CreateIndex(
                name: "IX_Iscrizioni_idEdizioneCorso",
                table: "Iscrizioni",
                column: "idEdizioneCorso");

            migrationBuilder.CreateIndex(
                name: "IX_Iscrizioni_idPersona",
                table: "Iscrizioni",
                column: "idPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Lezioni_idAula",
                table: "Lezioni",
                column: "idAula");

            migrationBuilder.CreateIndex(
                name: "IX_Lezioni_idModulo",
                table: "Lezioni",
                column: "idModulo");

            migrationBuilder.CreateIndex(
                name: "IX_Lezioni_idPersona",
                table: "Lezioni",
                column: "idPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Moduli_idEdizioneCorso",
                table: "Moduli",
                column: "idEdizioneCorso");

            migrationBuilder.CreateIndex(
                name: "IX_Moduli_idPersona",
                table: "Moduli",
                column: "idPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Persone_idAzienda",
                table: "Persone",
                column: "idAzienda");

            migrationBuilder.CreateIndex(
                name: "IX_Presenze_idLezione",
                table: "Presenze",
                column: "idLezione");

            migrationBuilder.CreateIndex(
                name: "IX_Presenze_idPersona",
                table: "Presenze",
                column: "idPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Progetti_idAzienda",
                table: "Progetti",
                column: "idAzienda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competenze");

            migrationBuilder.DropTable(
                name: "Iscrizioni");

            migrationBuilder.DropTable(
                name: "Presenze");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Lezioni");

            migrationBuilder.DropTable(
                name: "Moduli");

            migrationBuilder.DropTable(
                name: "EdizioniCorsi");

            migrationBuilder.DropTable(
                name: "Persone");

            migrationBuilder.DropTable(
                name: "Aule");

            migrationBuilder.DropTable(
                name: "Corsi");

            migrationBuilder.DropTable(
                name: "EntiFinanzianti");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Livelli");

            migrationBuilder.DropTable(
                name: "Progetti");

            migrationBuilder.DropTable(
                name: "Aziende");
        }
    }
}
