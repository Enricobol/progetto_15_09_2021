using Scuola.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model.Data.EF
{
    interface EFIEdizioneCorsoRepository : ICrudRepository<EdizioneCorso, long>
    {
        //Dichiara UN METODO SPECIFICO SOLO AD EDIZIONE CORSO
        //es: IEnumerable<EdizioneCorso> FindAllCoursesByCourseId(string part);
    }
}
