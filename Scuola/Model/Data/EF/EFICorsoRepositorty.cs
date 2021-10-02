using Scuola.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model.Data.EF
{
    interface EFICorsoRepositorty : ICrudRepository<Corso , long>
    {
        //DICHIARA UN METODO SPECIFICO SOLO A CORSO
        //es: IEnumerable<Corso> FindCourseByTitle(string part);
    }
}
