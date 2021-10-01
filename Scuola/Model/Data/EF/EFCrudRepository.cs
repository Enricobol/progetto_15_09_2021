using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model.Data.EF
{
    public class EFCrudRepository
    {
        public class CrudRepository<T, K> : ICrudRepository<T, K> where T : class //Una sola repository dove il tipo viene lasciato flessibile così può gestire tutti i tipi di classi.
        {
            private readonly EducationContext ctx;
            private DbSet<T> entities;

            public CrudRepository(EducationContext ctx)
            {
                this.ctx = ctx;
                this.entities = ctx.Set<T>();
            }


            //METODI
            public IEnumerable<T> GetAll() //Metodo per recuperare tutte le entità in una determinata classe.
            {
                return entities.AsEnumerable();
            }

            public T Create(T newElement) //Crea un nuovo elemento, ritornalo per conferma
            {
                entities.Add(newElement);
                ctx.SaveChanges();
                return newElement;
            }

            public T Delete(K key) //Elimino elemento di classe per id
            {
                T found = entities.Find(key);
                if (found == null)//Controllo so trovato qualcosa
                {
                    return null;
                }
                entities.Remove(found);
                ctx.SaveChanges();
                return found;
            }

            public T Delete(T element) //Elimino elemento di classe cercando proprio l'elemento
            {
                entities.Remove(element);
                int changes = ctx.SaveChanges();
                if (changes == 0)//Controllo so ho eliminato qualcosa
                {
                    return null;
                }
                return element;
            }

            public T FindById(K key) //Trova un'entità di una determinata classe per id.
            {
                return entities.Find(key);
            }

            public void Update(T newElement) //Metodo per aggiornare l'entità in una determinata classe.
            {
                entities.Update(newElement);
                ctx.SaveChanges();
            }
        }
    }
}
