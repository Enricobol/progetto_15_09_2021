﻿using Scuola.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Implementa i metodi specifici solo ad EdizioneCorso
/// </summary>

namespace Scuola.Model.Data.InMemory
{
    class InMemoryEdizioneCorsoRepository : InMemoryCrudRepository<EdizioneCorso, long> , IEdizioneCorsoRepository
    {

    }
}
