using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Implementa i metodi comuni a tutte le entità in ADO.
/// </summary>
/// 
namespace Scuola.Model.Data.ADO
{
    public class ADOCrudRepository<T, K> : ICrudRepository<T, K> where T : class //Una sola repository dove il tipo viene lasciato flessibile così può gestire tutti i tipi di classi.
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
