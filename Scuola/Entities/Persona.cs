using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class Persona
    {
        //PROPRIETA'
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataDiNascita { get; set; }
        public string Cf { get; set; }
        public string Sesso { get; set; }
        public string CittàResidenza { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Ruolo { get; set; }
        public string PartitaIva { get; set; }
        //PROPRIETA' FOREING KEYS
        public long AziendaId { get; set; }
        //PROPRIETA' CLASSI
        public Azienda Azienda { get; set; }

        //COSTRUTTORI
        public Persona(long id , string nome, string cognome, DateTime dataDiNascita, string cf, string sesso, string cittàResidenza, string email , string telefono , string ruolo, string partitaIva)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            DataDiNascita = dataDiNascita;
            Cf = cf;
            Sesso = sesso;
            CittàResidenza = cittàResidenza;
            Email = email;
            Telefono = telefono;
            Ruolo = ruolo;
            PartitaIva = partitaIva;
        }

        public Persona()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Nome: {Nome} Cognome: {Cognome} Data di Nascita: {DataDiNascita} " +
                $"\nCittà di residenza: {CittàResidenza} Email: {Email} Telefono: {Telefono} Ruolo: {Ruolo} ";
        }

    }
}
