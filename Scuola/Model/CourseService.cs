using Scuola.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq; // Una libreria speciale! per cercare dentro un IEnumerable con una LAMBDA!

namespace Scuola.Model
{
    public class CourseService
    {
        //PROPRIETA'
        public IRepository Repository { get; private set; }

        //COSTRUTTORE
        public CourseService(IRepository repo)
        {
            Repository = repo;
        }

        #region MyRegion Vecchi metodi
        //METODI
        #region METODI GetAllCourses, CreateCourse, GetCourseEdition : richiamano metodi in memoria (repositroy) per gestire i corsi.
        public IEnumerable<Corso> GetAllCourses()
        {
            return Repository.GetCourses();
        }

        public Corso CreateCourse(Corso c)
        {
            return Repository.AddCourse(c);
        }

        public IEnumerable<EdizioneCorso> GetCourseEdition(long id)
        {
            return Repository.FindEditionsByCourse(id);
        }
        #endregion


        public IEnumerable<EdizioneCorso> FindEditionsByCourse(long id)
        {
            return Repository.FindEditionsByCourse(id);
        }
        #endregion

        #region METODO CreateCurseEdition : Crea un'edizione corso, trova un corso in memoria è c'è la inserisce dentro.
        public EdizioneCorso CreateCurseEdition(EdizioneCorso e, long idCorso)
        {
            Corso found = Repository.FindCourseById(idCorso);
            if (found == null)
            {
                return null; //GENERA UN'ECCEZIONE CORSO => entitynotfoundexp
            }
            e.Corso = found;
            
            Repository.AddEdizione(e);
            return e;
        }
        #endregion

        #region METODO GenerateReport : Inserisco Id corso, cerco quel corso e poi, per tutte le sue edizoni, ritorno un sacco di dati.
        public Report GenerateReport(long idCorso)  //In un grio di Aggregate cerca di trovare tutte le info necessarie per il report
        {
            Report report = new Report();
            Corso found = Repository.FindCourseById(idCorso); //Cerco in memoria se quel corso esiste
            if (found == null)
            {
                return null;
            }

            IEnumerable<EdizioneCorso> editions = Repository.FindEditionsByCourse(idCorso);

            //Popolo il report di valoi
            report.NumEditions = editions.Count(); //USA LAMBDA
            report.SumPrice = editions.Sum(e => e.PrezzoFinale);
            report.AveragePrice = report.SumPrice / report.NumEditions;
            report.MedianPrice = CalculateMedianPrice(editions);
            report.ModaPrice = CalculateModaPrice(editions);//Moda vai a vedere i dizionari!      
            report.NumMaxStudents = editions.Max(e => e.MaxNumStudenti);
            report.NumMinStudents = editions.Min(e => e.MinNumStudenti);

            #region METODI ALTERNATIVI CON I LAMBDA
            List<int> nums = new List<int> { 1, 2, 3, 4, 5 };
            nums.Aggregate((a, b) => a + b); //Operatore che prende le prime 2 edizione corso e ne tira fuori un'altra che è la sua aggregazione ((((1 +2) +3) +4) +5) = 15
            nums.Aggregate((a, b) => a * b); // ((((1 *2) *3) *4) *5) = 120
            nums.Aggregate((a, b) => a > b ? a : b); //Trovo il massimo 5
            var r = editions.Aggregate(new EditionData(), (a, e) =>  //Prendo dentro un accumulatore (new EditionData) , lo aggiorno ed infine lo ritorno
            {
                a.NumElements++;
                a.TotalPrice += e.PrezzoFinale;
                return a;
            });
            var avg1 = r.TotalPrice / r.NumElements; // Media calcolata
            var avg2 = editions.Aggregate(new EditionData(), (a, e) =>  //Combino 2 steps per avg2
            {
                a.NumElements++;
                a.TotalPrice += e.PrezzoFinale;
                return a;
            }, a => a.TotalPrice / a.NumElements);
            #endregion
            return report;

        }
        #endregion

        #region METODO GenerateReportAggregate : Come generateReport, ma usa Aggregate per far tutto in un'unica riga di codice!
        public Report GenerateReportAggregate(long id)
        {
            Corso selectedCourse = Repository.FindCourseById(id);
            List<EdizioneCorso> editions = (List<EdizioneCorso>)Repository.FindEditionsByCourse(id);

            List<decimal> prices = new List<decimal>();
            return editions.Aggregate(new Report(0, 0, 0, 0, 0, 0, 0), (report, edition) =>
            {
                prices.Add(edition.PrezzoFinale);
                report.NumEditions++;
                report.SumPrice += edition.PrezzoFinale;
                report.AveragePrice = report.SumPrice / report.NumEditions;
                report.MedianPrice = CalculateMedianPrice(editions);
                report.ModaPrice = CalculateModaPrice(editions);
                report.NumMinStudents = edition.MaxNumStudenti < report.NumMinStudents ? edition.MaxNumStudenti : report.NumMinStudents;
                report.NumMaxStudents = edition.MaxNumStudenti > report.NumMaxStudents ? edition.MaxNumStudenti : report.NumMaxStudents;
                return report;
            });
        }
        #endregion

        #region METODO CalculateModaPrice : Calcola la moda dei prezzi
        private decimal CalculateModaPrice(IEnumerable<EdizioneCorso> editions)
        {
            decimal modaPrice = editions.GroupBy(e => e.PrezzoFinale).OrderByDescending(g => g.Count()).FirstOrDefault().Key;
            return modaPrice;

        }
        #endregion

        #region METODO CalculateMedianPrice : Calcola la mediana dei prezzi di tutte le edizioni di  un corso
        private decimal CalculateMedianPrice(IEnumerable<EdizioneCorso> editions)
        {
            var prices = editions.Select(e => e.PrezzoFinale).OrderBy(r => r).ToList(); //Enumerazione di prezzi ordinati dal più piccolo al più grande
                                                                                     //Se gli elementi sono dispari seleziono l'elemento in mezzo
                                                                                     //Se sono pari prendo i 2 in mezzo e ne faccio la media
            if (prices.Count % 2 != 0)
            {
                return prices[(prices.Count / 2)];
            }
            return (prices[(prices.Count / 2)] + prices[(prices.Count / 2) - 1]) / 2;
        }
        #endregion
    }

    public class EditionData //PER ESEMPI CON I LAMBDA
    {
        public decimal TotalPrice { get; set; }
        public int NumElements { get; set; }

    }
}
