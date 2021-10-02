using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model.Data.EF
{
    public class EFCrudRepository<T, K> : ICrudRepository<T, K> where T : class //Una sola repository dove il tipo viene lasciato flessibile così può gestire tutti i tipi di classi.
    {
        private readonly EducationContext ctx;
        private DbSet<T> entities;

        public EFCrudRepository(EducationContext ctx)
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

        public bool Delete(K key) //Elimino elemento di classe per id
        {
            T found = entities.Find(key);
            if (found == null)//Controllo so trovato qualcosa
            {
                return false;
            }
            entities.Remove(found);
            ctx.SaveChanges();
            return true;
        }

        public bool Delete(T newElement) //Elimino elemento di classe cercando proprio l'elemento
        {
            entities.Remove(newElement);
            int changes = ctx.SaveChanges();
            if (changes == 0)//Controllo so ho eliminato qualcosa
            {
                return false;
            }
            return true;
        }

        public T FindById(K key) //Trova un'entità di una determinata classe per id.
        {
            return entities.Find(key);
        }

        public bool Update(T newElement) //Metodo per aggiornare l'entità in una determinata classe.
        {
            
            entities.Update(newElement);
            ctx.SaveChanges();
            return true;
        }
    }
}