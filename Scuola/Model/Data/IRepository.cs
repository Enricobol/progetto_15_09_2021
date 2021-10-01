using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scuola.Entities;

namespace Scuola.Model.Data
{
    public interface IRepository
    {
       
  
        IEnumerable<Corso> GetCourses();
        Corso FindCourseById(long id);
        Corso UpdateCourse(Corso corso);
        IEnumerable<EdizioneCorso> FindEditionsByCourse(long idCorso);
        Corso AddCourse(Corso corso);
        EdizioneCorso AddEdizione(EdizioneCorso edizioneCorso); 
        bool CourseExists(Corso c); 

        //Corso BetterFindCourseById(long id); //Metodo migliore che trova un corso per id
        //Report GenerateReport(long idCorso);

    }
}
 //IEnumerable è come una sequenza (interfaccia) di oggetti che può essere solo letta