﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scuola.Entities;

namespace Scuola.Model.Data.InMemory
{
    class InMemoryCourseEditionRepository : ICrudRepository<EdizioneCorso, long>
    {

        public IEnumerable<EdizioneCorso> GetAll()
        {
            throw new NotImplementedException();
        }

        public EdizioneCorso Create(EdizioneCorso newElement)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long key)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EdizioneCorso newElement)
        {
            throw new NotImplementedException();
        }

        public EdizioneCorso FindById(long key)
        {
            throw new NotImplementedException();
        }

        public bool Update(EdizioneCorso newElement)
        {
            throw new NotImplementedException();
        }
    }
}
