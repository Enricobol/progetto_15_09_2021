using Scuola.Model.Data.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Scuola.Model.Data.EF.EFCrudRepository;
using Scuola.Entities;

namespace Scuola.Model.Data.EF
{
    public class EFCourseEditionRepository : CrudRepository<EdizioneCorso,long> , ICourseEditionRepository
    {
    }
}
