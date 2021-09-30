using Scuola.Model.Data.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Scuola.Model.Data.EF.EFCrudRepository;

namespace Scuola.Model.Data.EF
{
    class EFCourseEditionRepository :CrudRepository<EdizioneCorso,long> , ICourseEditionRepository
    {
    }
}
