using Scuola.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model.Data.InMemory
{
    class InMemoryEdizioneCorsoRepository : ICrudRepository<EdizioneCorso, long>
    {
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

        public IEnumerable<EdizioneCorso> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(EdizioneCorso newElement)
        {
            throw new NotImplementedException();
        }
    }
}
