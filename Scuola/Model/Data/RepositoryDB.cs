using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scuola.Extensions;
using Scuola.Entities;
using Scuola.Entities.Exceptions;
using Scuola.Model.Data.Exceptions;

namespace Scuola.Model.Data
{
    class RepositoryDB : IRepository
    {
        private ISet<Corso> courses = new HashSet<Corso>(); //Set di elementi: Rifiuta i duplicati ed è estremamente efficiente nel trovare gli elementi
        private ISet<EdizioneCorso> courseEditions = new HashSet<EdizioneCorso>();

        const string CONNECTION_STRING = @"
            Server = localhost; 
            User = sa;
            Password = 1Secure*Password;
            Database = scuola
         ";

        const string SELECT_ALL_COURSES = @"SELECT  id , titolo , descrizione , ammontareOre , costoRiferimento , idLivello , idProgetto , idCategoria 
                                            FROM dbo.Corsi";
        const string SELECT_COURSE_BY_ID = @"SELECT id , titolo , descrizione , ammontareOre , costoRiferimento , idLivello , idProgetto , idCategoria 
                                            FROM dbo.Corsi 
                                            WHERE id = @idSearch";
        const string UPDATE_COURSE_BY_ID = @"UPDATE dbo.aule SET titolo = @newTitolo, descrizione = @newDescrizione, ammontareOre = @newAmmontareOre,
                                            costoRiferimento = @newCostoRiferimento, idLivello = @newIdLivello , idProgetto = @newIdProgetto  , idCategoria = @newIdCategoria
                                            WHERE id = @idCorso";
        const string CREATE_COURSE = @"INSERT INTO dbo.Corsi (id , titolo , descrizione , ammontareOre , costoRiferimento , idLivello , idProgetto , idCategoria)
                                       OUTPUT INSERTED.id                                      
                                       VALUES (@titolo , @descrizione , @ammontareOre , @costoRiferimento , @idLivello , @idProgetto , @idCategoria)";
        const string FIND_EDITION_BY_COURSE_ID = @"SELECT id , codiceEdizione , dataInizio , dataFine , prezzoFinale , minNumStudenti , maxNumStudenti , inPresenze , idAula , idEntiFinanzianti , idCorso
                                                FROM dbo.Edizioni
                                                WHERE idCorso = (SELECT id
                                                                FROM dbo.Corsi
                                                                WHERE id = @idCorso)";
        const string CREATE_EDITION = @"SELECT id, codiceEdizione, dataInizio, dataFine, prezzoFinale, minNumStudenti, maxNumStudenti, inPresenze, idAula, idEntiFinanzianti, idCorso
                                       OUTPUT INSERTED.id                                      
                                       VALUES (@id, @codiceEdizione, @dataInizio, @dataFine, @prezzoFinale, @minNumStudenti, @maxNumStudenti, @inPresenze, @idAula, @idEntiFinanzianti, @idCorso)";

        //Aggiunta di un nuovo corso nel database
        //RepositoryDB.AddCourse();


        #region METODO DB AddCourse : Aggiungi un corso al Database
        public Corso AddCourse(Corso c)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(CREATE_COURSE);

                    conn.Open();

                    cmd.Parameters["@titolo"].Value = c.Titolo;
                    cmd.Parameters["@descrizione"].Value = c.Descrizione;
                    cmd.Parameters["@ammontareOre"].Value = c.AmmontareOre;
                    cmd.Parameters["@costoRiferimento"].Value = c.CostoRiferimento;
                    cmd.Parameters["@idLivello"].Value = c.LivelloId;
                    cmd.Parameters["@idProgetto"].Value = c.ProgettoId;
                    cmd.Parameters["@idCategoria"].Value = c.CategoriaId;

                    //cmd.ExecuteNonQuery();
                    c.Id = (long)cmd.ExecuteScalar(); //Ritrona l'id del corso appena inserito

                    return c;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("error: " + e);

                SchoolDataException de = new SchoolDataException(e.Message, e);
                throw de;
            }
        }
        #endregion

        #region METODO DB FindCourseById : Cerca un corso usando il sui Id
        public Corso FindCourseById(long idSearch)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(SELECT_COURSE_BY_ID, conn);
                    cmd.Parameters.Add("@idSearch", SqlDbType.Int);
                    conn.Open();
                    cmd.Parameters["@idSearch"].Value = idSearch;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Corso c = new Corso(
                                id: (long)reader.GetInt32("id"),
                                titolo: reader.GetString("titolo"),
                                descrizione: reader.GetString("descrizione"),
                                ammontareOre: reader.GetInt32("ammontareOre"),
                                costoRiferimento: (decimal)reader.GetInt32("costoRiferimento"),
                                livelloId: reader.GetInt32("idLivello"),
                                progettoId: reader.GetInt32("idProgetto"),
                                categoriaId: reader.GetInt32("idCategoria")
                                );
                            return c;
                        }
                        return null;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("error: " + e);

                SchoolDataException de = new SchoolDataException(e.Message, e);
                throw de;
            }
        }
        #endregion

        #region METODO DB GetCourses : Connetti al server, Leggi, Crea una lista di corsi
        public IEnumerable<Corso> GetCourses()
        {
            List<Corso> cs = new List<Corso>();
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SELECT_ALL_COURSES, conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Corso c = new Corso(
                                id: (long)reader.GetInt32("id"),
                                titolo: reader.GetString("titolo"),
                                descrizione: reader.GetString("descrizione"),
                                ammontareOre: reader.GetInt32("ammontareOre"),
                                costoRiferimento: reader.GetDecimal("costoRiferimento"),
                                livelloId: reader.GetInt32("idLivello"),
                                progettoId: reader.GetInt32("idProgetto"),
                                categoriaId: reader.GetInt32("idCategoria")
                                );
                            cs.Add(c);
                        }
                        return cs;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("error: " + e);

                SchoolDataException de = new SchoolDataException(e.Message, e);
                throw de;
            }
        }
        #endregion

        #region METODO DB UpdateCourse : Gli dai una Corso e va a sostituirla con il corso esistente dello stesso id, ritorna il vecchio corso.       
        public Corso UpdateCourse(Corso c)
        {
            Corso cVecchio = FindCourseById(c.Id);

            EntityNotFound cnf = new EntityNotFound("Aula non trovata", c.Id);
            if (FindCourseById(c.Id) == null)
            {
                throw new EntityNotFound("La classe con id {0} non esiste ", c.Id);
            }
            try
            {
                //AUTOMATICAMENTE QUANDO SI ESCE DAL USING{...} VERRA' CHIAMATO DISPOSE PER IL CODICE AL SUO INTERNO
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(UPDATE_COURSE_BY_ID, conn);
                    cmd.Parameters.Add("@idClasse", SqlDbType.Int);
                    cmd.Parameters.Add("@newTitolo", SqlDbType.NVarChar, 30);
                    cmd.Parameters.Add("@newDescrizione", SqlDbType.NVarChar, 100);
                    cmd.Parameters.Add("@newAmmontareOre", SqlDbType.Int);
                    cmd.Parameters.Add("@newCostoRiferimento", SqlDbType.Decimal);
                    cmd.Parameters.Add("@newIdLivello", SqlDbType.Int);
                    cmd.Parameters.Add("@newIdProgetto", SqlDbType.Int);
                    cmd.Parameters.Add("@newIdCategoria", SqlDbType.Int);

                    conn.Open();

                    cmd.Parameters["@idClasse"].Value = c.Id;
                    cmd.Parameters["@newTitolo"].Value = c.Titolo;
                    cmd.Parameters["@newDescrizione"].Value = c.Descrizione;
                    cmd.Parameters["@newAmmontareOre"].Value = c.AmmontareOre;
                    cmd.Parameters["@newCostoRiferimento"].Value = c.CostoRiferimento;
                    cmd.Parameters["@newIdLivello"].Value = c.LivelloId;
                    cmd.Parameters["@newIdProgetto"].Value = c.ProgettoId;
                    cmd.Parameters["@newIdCategoria"].Value = c.CategoriaId;

                    cmd.ExecuteNonQuery();
                    return cVecchio;

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("error: " + e);

                SchoolDataException de = new SchoolDataException(e.Message, e);
                throw de;
            }

        }
        #endregion

        #region METODO DB FindEditionsByCourse : Cerca tutte le edizioni di un corso cercandole per id Corso
        public IEnumerable<EdizioneCorso> FindEditionsByCourse(long idCorso)
        {
            List<EdizioneCorso> eds = new List<EdizioneCorso>();
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(FIND_EDITION_BY_COURSE_ID, conn);
                    cmd.Parameters.AddWithValue("@idCorso", idCorso);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EdizioneCorso ed = new EdizioneCorso(
                            id: (long)reader.GetInt32("id"),
                            codiceEdizione: reader.GetInt32("codiceEdizione"),
                            dataInizio: reader.GetLocalDate("dataInizio"),
                            dataFine: reader.GetLocalDate("dataFine"),
                            prezzoFinale: reader.GetDecimal("prezzoFinale"),
                            minNumStudenti: reader.GetInt32("minNumStudenti"),
                            maxNumStudenti: reader.GetInt32("maxNumStudenti"),
                            inPresenze: reader.GetBoolean("inPresenze"),
                            aulaId: reader.GetInt32("idAula"),
                            enteFinanzianteId: reader.GetInt32("idEntiFinanzianti"),
                            corsoId: reader.GetInt32("idCorso")
                        );
                            eds.Add(ed);
                        }
                    }
                    return eds;
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine("error: " + e);

                SchoolDataException de = new SchoolDataException(e.Message, e);
                throw de;
            }
        }
        #endregion

        public EdizioneCorso AddEdizione(EdizioneCorso ec)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(CREATE_COURSE);

                    conn.Open();

                    cmd.Parameters["@codiceEdizione"].Value = ec.CodiceEdizione;
                    cmd.Parameters["@dataInizio"].Value = ec.DataInizio;
                    cmd.Parameters["@dataFine"].Value = ec.DataFine;
                    cmd.Parameters["@prezzoFinale"].Value = ec.PrezzoFinale;
                    cmd.Parameters["@minNumStudenti"].Value = ec.MinNumStudenti;
                    cmd.Parameters["@maxNumStudenti"].Value = ec.MaxNumStudenti;
                    cmd.Parameters["@inPresenze"].Value = ec.InPresenze;
                    cmd.Parameters["@idAula"].Value = ec.AulaId;
                    cmd.Parameters["@idEntiFinanzianti"].Value = ec.EnteFinanzianteId;
                    cmd.Parameters["@idCorso"].Value = ec.CorsoId;

                    //cmd.ExecuteNonQuery();
                    ec.Id = (long)cmd.ExecuteScalar(); //Ritrona l'id del corso appena inserito

                    return ec;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("error: " + e);

                SchoolDataException de = new SchoolDataException(e.Message, e);
                throw de;
            }
        }


        public Corso BetterFindCourseById(long id)
        {
            throw new NotImplementedException();
        }

        public Report GenerateReport(long idCorso)
        {
            throw new NotImplementedException();
        }

        public bool CourseExists(Corso c)
        {
            throw new NotImplementedException();
        }
    }
}
