using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scuola.Entities;

namespace Scuola.Model.Data.InMemory
{
    public class InMemoryCourseRepository : ICrudRepository<Corso, long>
    {
        private static List<Corso> corsi = new List<Corso>();
        static long lastIdCourse = 0;
        public void Create(Corso newElement)
        {

        }

        public bool Delete(Corso newElement)
        {
            return Delete(newElement.Id);
        }

        public bool Delete(long key)
        {
            int count = corsi.Count;
            corsi = corsi.Where(c => c.Id != key).ToList();
            return corsi.Count != count;
        }

        public Corso FindById(long key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Corso> GetAll()
        {
            return corsi;
        }

        public bool Update(Corso newElement)
        {
            bool wasRemoved = Delete(newElement.Id);
            if (!wasRemoved)
            {
                return wasRemoved;
            }
            corsi.Add(newElement);
            return wasRemoved;
        }

        public IEnumerable<Corso> FindByTitleLike(string part)
        {
            return corsi.Where(c =>  c.Titolo.Contains(part));
        }
    }
}
