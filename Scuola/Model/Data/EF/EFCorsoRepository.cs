using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scuola.Entities;

namespace Scuola.Model.Data.EF
{
    public class EFCorsoRepository : EFCrudRepository<Corso, long> , EFICorsoRepositorty
    {
        public EFCorsoRepository(EducationContext ctx) : base(ctx)
        {
            //IMPLEMENTA I METODI DICHIARATI IN EFICorsoRepositorty
            //es: IEnumerable<Corso> FindCourseByTitle(string part)
            //{
            //  bla bla bla
            //}
        }
    }
}
