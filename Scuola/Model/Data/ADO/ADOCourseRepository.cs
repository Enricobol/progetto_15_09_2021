﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model.Data.ADO
{
    class ADOCourseRepository : ICourseRepository
    {
        public void Create(Corso newElement)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Corso newElement)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long key)
        {
            throw new NotImplementedException();
        }

        public Corso FindById(long key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Corso> FindByTitleLike(string part)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Corso> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Corso newElement)
        {
            throw new NotImplementedException();
        }
    }
}
