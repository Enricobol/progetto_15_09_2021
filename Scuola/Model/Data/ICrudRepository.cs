using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model.Data
{
    public interface ICrudRepository<T, K> //T = tipo con cui lavoro (Course, Studenti, ...), K = tipo della primary key, di T
    {
        IEnumerable<T> GetAll();
        void Create(T newElement);
        bool Delete(T newElement);
        bool Delete(K key);
        bool Update(T newElement);
        T FindById(K key);
    }
}