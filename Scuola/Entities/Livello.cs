using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class Livello
    {
        //PROPRIETA'
        public long Id { get; set; }
        public string Tipologia { get; set; }
        public string Descrizione { get; set; }
        //PROPRIETA' DI TIPO CONTENITORE
        public virtual List<Competenza> Competenze { get; set; } = new List<Competenza>(); //Un Livello può avere multiple competenze 
        public virtual List<Corso> Corsi { get; set; } = new List<Corso>(); //Un Livello può avere multipli corsi 



        //COSTRUTTORI
        public Livello(long id, string tipologia, string descrizione)
        {
            Id = id;
            Tipologia = tipologia;
            Descrizione = descrizione;
        }
        //COSTRUTTORE VUOTO
        public Livello()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Tipologia: {Tipologia} \nDescrizione: {Descrizione} ";
        }

    }
}
