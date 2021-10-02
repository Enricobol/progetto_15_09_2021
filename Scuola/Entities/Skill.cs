using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class Skill
    {
        //PROPRIETA'
        public long Id { get; set; }
        public string Tipo { get; set; }
        public string Descrizione { get; set; }
        //PROPRIETA' DI TIPO CONTENITORE
        public virtual List<Competenza> Competenze { get; set; } = new List<Competenza>(); //Una skill può avere multiple competenze


        //COSTRUTTORI
        public Skill(long id, string tipo, string descrizione)
        {
            Id = id;
            Tipo = tipo;
            Descrizione = descrizione;
        }
        //COSTRUTTORE VUOTO
        public Skill()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Tipo: {Tipo} Descrizione: {Descrizione} ";
        }

    }
}
