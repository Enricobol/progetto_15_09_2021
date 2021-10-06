using NodaTime;
using Scuola.Entities;
using Scuola.Model.Data;
using Scuola.Model.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq; // Una libreria speciale! per cercare dentro un IEnumerable con una LAMBDA!
using System.Text;
using System.Threading.Tasks;
using static System.Console; //Aggiungi questa riga per scrivere Writeline più velocemente

namespace Scuola.Model
{
    public class UserInterface
    {
        public CourseService CourseService { get; set; }
        const string MAIN_MENU = "Operazioni disponibili:\n inserisci a per vedere tutti i corsi \n inserisci c per inserire un corso \n " +
            "inserisci e per ricercare le edizioni di un corso\n inserisci b per creare edizione di un corso per id\n inserisci r per fare un report Id \n " +
            "inserisci q per uscire dal menu";
        const string BASE_PROMPT = "->";


        //COSTRUTTORE
        public UserInterface(CourseService service)
        {
            CourseService = service;
        }


        //METODI
        public void Start()
        {
            #region MAIN_MENU : Mostra il menu principale, richiede all'utente un tasto per scegliere la funzione
            bool quit = false;
            do
            {
                WriteLine(MAIN_MENU);
                char c = ReadChar(BASE_PROMPT);
                try
                {
                    switch (c)
                    {
                        case 'a':
                            ShowCourses();
                            break;
                        case 'c':
                            CreateCourse();
                            break;
                        case 'e':
                            ShowCoursesEditionByCourse();
                            break;
                        case 'b':
                            CreateCourseEdition();
                            break;
                        case 'r':
                            GenerateReport();
                            break;
                        case 'q':
                            quit = true;
                            break;
                        default:
                            WriteLine("Comando non riconosciuto");
                            break;
                    }
                }
                #region Catch sbagliati, non sono raggruppati
                //catch (SqlException se) //Catch sbagliati
                //{
                //    Console.WriteLine(se.Message);
                //}
                //catch (InputOutputException se)
                //{
                //    Console.WriteLine(se.Message);
                //}
                #endregion
                catch (SchoolDataException e) //Gestico le eccezioni qui, con un'eccezione standard
                {
                    Console.WriteLine("Errore interno : " + e.Message);
                    String answer = ReadString("Scrivi y per riprovare , e per uscire");
                    if (answer[0].Equals("e"))
                    {
                        break;
                    }
                }

            } while (!quit);
            #endregion

        }

        //METODI DELL'USER INTERFACE 
        #region METODO ShowCoursesEditionByCourse : Stampa tutte le edizioni di uno specifico corso, basandosi sull ID
        private void ShowCoursesEditionByCourse()
        {
            long id = ReadLong("Inserisci l'id del corso da ricercare: ");

            IEnumerable<EdizioneCorso> editions = CourseService.GetCourseEdition(id);
            foreach (var c in editions) //Stampo tutti i corsi
            {
                WriteLine(c.ToString()); //Vai a vedere in Corso come funziona
            }
        }
        #endregion

        #region METODO CreateCourse : Crea le variabili da inserire nel corso e richiedi all'utente di compilarle
        private void CreateCourse()
        {

            long id = ReadLong("Inserisci l'id del corso: ");
            string titolo = ReadString("Inserisci il nome del corso: ");
            string descrizione = ReadString("Inserisci la durata in ore del corso: ");
            int ammontareOre = ReadInt("Inserisci l'id del livello: "); ;
            decimal costoRiferimento = ReadDecimal("Inserici il costo del corso: ");
            int idLivello = ReadInt("Inserisci l'id del livello: ");
            int idProgetto = ReadInt("Inserisci l'id del progetto: ");
            int idCategoria = ReadInt("Inserisci l'id della categoria: "); ;
            //Inserisci le variabili all'interno di un nuovo corso
            Corso c = new Corso(id, titolo, descrizione, ammontareOre,
                    costoRiferimento, idLivello, idProgetto, idCategoria);
            CourseService.CreateCourse(c);
            WriteLine("Corso inserito.");
        }
        #endregion

        #region ShowCourses : Stampa tutti i corsi
        private void ShowCourses()
        {
            IEnumerable<Corso> courses = CourseService.GetAllCourses();
            foreach (var c in courses) //Stampo tutti i corsi
            {
                WriteLine(c.ToString()); //Vai a vedere in Corso come funziona
            }
        }
        #endregion

        #region CreateCourseEdition : Crea una nuova edizone corso chiedendo all'utente di compilare
        private void CreateCourseEdition()
        {
            long id = ReadLong("Inserisci l'id edizione corso: ");
            int codiceEdizione = ReadInt("Inserisci l'id corso a cui appartiene: ");
            LocalDate dataInizio = ReadLocalDate("Inserisci data di inizio: ");
            LocalDate dataFine = ReadLocalDate("Inserisci data di termine: ");
            decimal prezzoFinale = ReadDecimal("Inserici il prezzo finale edizione corso: ");
            int minNumStudenti = ReadInt("Inserisci il numero degli studenti: ");
            int maxNumStudenti = ReadInt("Inserisci il numero degli studenti: ");
            bool inPresenze = ReadBool("Inserisci y se e' in presenza e n se e' in SmartWorking");
            int idEnteFinanziante = ReadInt("Inserisci l'id del ente finanziatore: ");
            int idAula = ReadInt("Inserisci l'id dell'aula: ");
            int idCorso = ReadInt("Inserisci l'id del corso: ");
            EdizioneCorso edition = new EdizioneCorso(id, codiceEdizione, dataInizio, dataFine,
                                                        prezzoFinale, minNumStudenti, maxNumStudenti,
                                                        inPresenze, idEnteFinanziante, idAula, idCorso);
            CourseService.CreateCurseEdition(edition, idCorso);
        }
        #endregion

        #region GenerateReport : Genera un report contenente molte informazioni sui prezzi del corso
        public void GenerateReport()
        {
            long id = ReadLong("Inserisci l'id del corso di cui generare il report: ");
            Report report = CourseService.GenerateReport(id);
            WriteLine(report.ToString());

        }
        #endregion


        //METODI per lettura stringhe 
        #region METODO ReadChar : Per leggere un tasto, se il tasto è nulloa avvisa ripeti. (usa ReadString)
        private char ReadChar(string prompt)
        {
            return ReadString(prompt)[0];
        }
        #endregion

        #region METODO ReadBool : Per leggere un tasto, ritorna vero o falso
        private bool ReadBool(string prompt)
        {
            if (prompt == "y")
            {
                return true;
            }
            return false;
        }
        #endregion

        #region METODO ReadLong : Prendi una stringa e cerca di ottenere un long, ripeti in caso di errore. (usa ReadString)
        private long ReadLong(string prompt)
        {
            bool isNumber = false;
            long num;

            do
            {
                string answer = ReadString(prompt);
                isNumber = long.TryParse(answer, out num); //Prende una stringa e prova a convertirla in un numero, ti dice anche se ci riesce.
                if (!isNumber)
                {
                    WriteLine("Devi inserire un numero!");
                }

            } while (!isNumber);
            return num;
        }
        #endregion

        #region METODO ReadInt : Prendi una stringa e cerca di ottenere un int, ripeti in caso di errore. (usa ReadString)
        private int ReadInt(string prompt)
        {
            bool isNumber = false;
            int num;

            do
            {
                string answer = ReadString(prompt);
                isNumber = int.TryParse(answer, out num); //Prende una stringa e prova a convertirla in un numero, ti dice anche se ci riesce.
                if (!isNumber)
                {
                    WriteLine("Devi inserire un numero!");
                }

            } while (!isNumber);
            return num;
        }
        #endregion

        #region METODO ReadDecimal : Prendi una stringa e cerca di ottenere un decimal, ripeti in caso di errore. (usa ReadString)
        private decimal ReadDecimal(string prompt)
        {
            bool isNumber = false;
            decimal num;

            do
            {
                string answer = ReadString(prompt);
                isNumber = decimal.TryParse(answer, out num); //Prende una stringa e prova a convertirla in un numero, ti dice anche se ci riesce.
                if (!isNumber)
                {
                    WriteLine("Devi inserire un numero!");
                }

            } while (!isNumber);
            return num;
        }
        #endregion

        #region METODO ReadString : Per leggere una stringa intera, controlla se hai passato almeno un carattero.
        private string ReadString(string prompt)
        {
            string answer = null;
            do
            {
                Write(prompt);
                answer = ReadLine().Trim();//Trim rimuove gli spazio vuoti da una stringa 
                if (string.IsNullOrEmpty(answer))
                {
                    WriteLine("Devi inserire almeno un carattere!");
                }

            } while (string.IsNullOrEmpty(answer));

            return answer;
        }
        #endregion

        #region METODO RealLocalDate : Per leggere una stringa e passarla ad un tipo LocalDate
        private LocalDate ReadLocalDate(string prompt)
        {
            do
            {
                try
                {
                    string ans = ReadString(prompt);
                    var pattern = NodaTime.Text.LocalDatePattern.CreateWithInvariantCulture("yyyy-mm-dd");
                    var parseResult = pattern.Parse(ans);
                    LocalDate localDate = parseResult.GetValueOrThrow();
                }
                catch (NodaTime.Text.UnparsableValueException ue)
                {
                    WriteLine("Data non valida!" +ue.Message);
                }


            } while (true);
        }
        #endregion 
    }
}
