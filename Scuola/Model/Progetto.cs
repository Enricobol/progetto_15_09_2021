using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model
{
    public class Progetto
    {
        //PROPRIETA'
        public long Id { get; set; }
        public string Tipologia { get; set; }
        //PROPRIETA' FOREING KEYS
        public long IdAzienda { get; set; }
        //PROPRIETA' CLASSI
        public Azienda Azienda { get; set; }

        //COSTRUTTORI
        public Progetto(long id, string tipologia, long idAzienda)
        {
            Id = id;
            Tipologia = tipologia;
            IdAzienda = idAzienda;
        }

        public Progetto()
        {

        }
    }
}
