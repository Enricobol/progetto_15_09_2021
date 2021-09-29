using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model
{
    public class Azienda
    {
        // PROPRIETA'
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string CodicePostale { get; set; }
        public string Email { get; set; }
        public string PartitaIva { get; set; }

        //COSTRUTTORI
        public Azienda(long id, string nome, string indirizzo, string citta, string codicePostale, string email, string partitaIva)
        {
            Id = id;
            Nome = nome;
            Indirizzo = indirizzo;
            Citta = citta;
            CodicePostale = codicePostale;
            Email = email;
            PartitaIva = partitaIva;
        }

        public Azienda()
        {

        }
    }
}
