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
        private static ISet<Corso> corsi = new HashSet<Corso>();
        static long lastIdCourse = 0;

        public IEnumerable<Corso> GetAll()
        {
            return corsi;
        }

        public Corso Create(Corso newElement)
        {
            bool added = corsi.Add(newElement);
            return added ? newElement : null;
        }

        public bool Delete(long key)
        {
            int count = corsi.Count;
            corsi = corsi.Where(c => c.Id != key).ToList();
            return corsi.Count != count;
        }

        public bool Delete(Corso newElement)
        {
            return Delete(newElement.Id);
        }

        public Corso FindById(long key)
        {
            throw new NotImplementedException();
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
