using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class Modulo
    {
        //PROPRIETA'
        public long Id { get; set; }
        public string Nome { get; set; }
        public int NumeroOre { get; set; }
        public string Descrizione { get; set; }
        //PROPRIETA' DI TIPO ASSOCIAZIONE
        public long PersonaId { get; set; }
        public long EdizioneId { get; set; }
        public Persona Persona { get; set; }
        public EdizioneCorso Edizione { get; set; }
        //PROPRIETA' DI TIPO CONTENITORE
        public virtual List<Lezione> Lezioni { get; set; } = new List<Lezione>(); //Un modulo può avere multiple lezioni 



        //COSTRUTTORI
        public Modulo(long id, string nome, int numeroOre , string descrizione , long personaId , long edizioneId)
        {
            Id = id;
            Nome = nome;
            NumeroOre = numeroOre;
            Descrizione = descrizione;
            PersonaId = personaId;
            EdizioneId = edizioneId;

        }

        public Modulo()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString()
        {
            return $"id: {Id} Nome: {Nome} Numero di ore: {NumeroOre} " +
                $"\nDescrizione: {Descrizione}";
        }
    }
}
