using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scuola.Entities;

namespace Scuola.Model.Data.InMemory
{
    public interface ICourseEditionRepository : ICrudRepository<EdizioneCorso, long> //METODI SPECIFICI PER EDIZIONECORSO
    {
        IEnumerable<EdizioneCorso> FindByTitleLike(string part);
    }
}
