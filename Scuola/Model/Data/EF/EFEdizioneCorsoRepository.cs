using Scuola.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model.Data.EF
{
    public class EFEdizioneCorsoRepository : EFCrudRepository<EdizioneCorso, long>, EFIEdizioneCorsoRepository
    {
        public EFEdizioneCorsoRepository(EducationContext ctx) : base(ctx)
        {
            //IMPLEMENTA I METODI DICHIARATI IN EFIEdizioneCorsoRepository
            //es: IEnumerable<EdizioneCorso> FindAllCoursesByCourseId(string part)
            //{
            //  bla bla bla
            //}
        }
    }
}
