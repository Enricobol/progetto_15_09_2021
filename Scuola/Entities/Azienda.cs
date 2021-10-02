using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
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
        //PROPRIETA' DI TIPO CONTENITORE
        public virtual List<Persona> Persone { get; set; } = new List<Persona>(); //Un'azienda può avere più persone
        public virtual List<Progetto> Progetti { get; set; } = new List<Progetto>(); //Un'azienda può avere progetti



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
        //COSTRUTTORE VUOTO
        public Azienda()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Nome: {Nome} Indirizzo: {Indirizzo} Citta: {Citta}  CodicePostale: {CodicePostale} Email: {Email} PartitaIva: {PartitaIva}";
        }

    }
}
