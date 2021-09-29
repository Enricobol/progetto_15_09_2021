using Scuola.Model.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model.Data
{
    public class FileDepository : IRepository
    {
        public Corso AddCourse(Corso corso)
        {
            try
            {
                return null; 
            }
            catch (IOException e)
            {
                Console.WriteLine("error: " + e);
                SchoolDataException de = new SchoolDataException(e.Message, e);
                throw de;
            }
        }

        public Corso FindCourseById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EdizioneCorso> FindEditionsByCourse(long idCorso)
        {
            throw new NotImplementedException();
        }

        public List<Corso> GetCourses()
        {
            throw new NotImplementedException();
        }

        public Corso UpdateCourse(Corso corso)
        {
            throw new NotImplementedException();
        }
    }
}
