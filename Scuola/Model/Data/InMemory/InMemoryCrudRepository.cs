using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model.Data.InMemory
{
    public class InMemoryCrudRepository<T, K> : ICrudRepository<T, K> where T : class //Una sola repository dove il tipo viene lasciato flessibile così può gestire tutti i tipi di classi.
    {
        public T Create(T newElement)
        {
            throw new NotImplementedException();
        }

        public bool Delete(K key)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T newElement)
        {
            throw new NotImplementedException();
        }

        public T FindById(K key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(T newElement)
        {
            throw new NotImplementedException();
        }
    }
}
