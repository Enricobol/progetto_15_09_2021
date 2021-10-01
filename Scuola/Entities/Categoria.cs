using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class Categoria
    {
        //PROPRIETA'
        public long Id { get; set; }
        public string Tipo { get; set; }
        public string Descrizione { get; set; }
        //PROPRIETA' DI TIPO CONTENITORE
        public virtual List<Corso> Corsi { get; set; } = new List<Corso>(); //Una categoria può avere più corsi a lei associata


        //COSTRUTTORI
        public Categoria(long id, string tipo, string descrizione)
        {
            Id = id;
            Tipo = tipo;
            Descrizione = descrizione;
        }

        public Categoria()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Tipo: {Tipo} \nDescrizione: {Descrizione} ";
        }

    }
}
