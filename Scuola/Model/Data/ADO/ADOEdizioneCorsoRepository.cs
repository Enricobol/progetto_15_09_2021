using Scuola.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Implementa i metodi specifici solo ad EdizioneCorso
/// </summary>
/// 
namespace Scuola.Model.Data.ADO
{
    class ADOEdizioneCorsoRepository : ADOCrudRepository<EdizioneCorso, long> , IEdizioneCorsoRepository
    {

    }
}
