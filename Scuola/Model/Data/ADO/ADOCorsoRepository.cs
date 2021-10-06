using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scuola.Entities;
/// <summary>
///  Implementa i metodi specifici solo a Corso
/// </summary>
namespace Scuola.Model.Data.ADO
{
    public class ADOCorsoRepository : ADOCrudRepository<Corso, long>, ICorsoRepository
    {
        public IEnumerable<Corso> FindByTitleLike(string part)
        {
            throw new NotImplementedException();
        }
    }
}
