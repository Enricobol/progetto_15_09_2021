using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model.Data
{
    public interface IRepository
    {

  
        List<Corso> GetCourses(); 
        Corso FindCourseById(long id);
        Corso UpdateCourse(Corso corso);
        IEnumerable<EdizioneCorso> FindEditionsByCourse(long idCorso);
        Corso AddCourse(Corso corso);

        //EdizioneCorso AddEdizione(EdizioneCorso edizioneCorso); //Metodo che aggiunge un'edizione corso 
        //Corso BetterFindById(long id); //Metodo migliore che trova un corso per id
        //Report GenerateReport(long idCorso);
        //bool CourseExists(Corso c); //Scrivi il Metodo + efficente possibile , con i set probabilmente
    }
}
 //IEnumerable è come una sequenza (interfaccia) di oggetti che può essere solo letta