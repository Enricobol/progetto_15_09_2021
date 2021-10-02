using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scuola.Entities;

namespace Scuola.Model.Data
{
    public interface ICorsoRepository : ICrudRepository<Corso , long>  //METODI SPECIFICI PER CORSO
    {
        IEnumerable<Corso> FindByTitleLike(string part);
    }
}
