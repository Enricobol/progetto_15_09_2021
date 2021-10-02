using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Entities
{
    public class Aula
    {
        // PROPRIETA'
        public long Id { get; set; }
        public string Nome { get; set; }
        public int CapMax { get; set; }
        public bool IsFisica { get; set; }
        public bool? IsComputerizzata { get; set; }
        public bool? HaProiettore { get; set; }
        //PROPRIETA' DI TIPO CONTENITORE
        public virtual List<EdizioneCorso> EdizioniCorsi { get; set; } = new List<EdizioneCorso>(); //Un'aula può avere più edizioni di un corso
        public virtual List<Lezione> Lezioni { get; set; } = new List<Lezione>(); //Un'aula può avere più lezioni
        
        
        //COSTRUTTORI
        public Aula(long id, string nome, int capMax, bool isFisica, bool? isComputerizzata, bool? haProiettore)
        {
            Id = id;
            Nome = nome;
            CapMax = capMax;
            IsFisica = isFisica;
            IsComputerizzata = isComputerizzata;
            HaProiettore = haProiettore;
        }
        //COSTRUTTORE VUOTO
        public Aula()
        {

        }

        //METODO Override per stampare i dati nella classe
        public override string ToString() 
        {
            return $"id: {Id} Nome: {Nome} Massimo numero studenti: {CapMax} In presenza: {IsFisica}  Computerizzata: {IsComputerizzata} Proiettore: {HaProiettore}";
        }

    }

}
