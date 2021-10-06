using Scuola.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Implementa i metodi specifici solo ad EdizioneCorso
/// </summary>

namespace Scuola.Model.Data.EF
{
    public class EFEdizioneCorsoRepository : EFCrudRepository<EdizioneCorso, long>, IEdizioneCorsoRepository
    {
        public EFEdizioneCorsoRepository(ScuolaContext ctx) : base(ctx)
        {
            //IMPLEMENTA I METODI DICHIARATI IN IEdizioneCorsoRepository
            //es: IEnumerable<EdizioneCorso> FindAllCoursesByCourseId(string part)
            //{
            //  bla bla bla
            //}
        }
    }
}
