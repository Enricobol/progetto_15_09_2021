using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scuola.Entities;

/// <summary>
///  Implementa i metodi specifici solo a Corso
/// </summary>

namespace Scuola.Model.Data.EF
{
    public class EFCorsoRepository : EFCrudRepository<Corso, long> , ICorsoRepository
    {
        public EFCorsoRepository(ScuolaContext ctx) : base(ctx)
        {
            //IMPLEMENTA I METODI DICHIARATI IN ICorsoRepositorty
            //es: IEnumerable<Corso> FindCourseByTitle(string part)
            //{
            //  bla bla bla
            //}
        }

        public IEnumerable<Corso> FindByTitleLike(string part)
        {
            throw new NotImplementedException();
        }
    }
}
