using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionProject
{
    public class Conto
    {
        public  decimal Saldo { get; set; }

        public decimal Ritira( decimal somma)
        {
            if(Saldo >= somma)
            {
                Saldo -= somma;
                return Saldo;
            }
            //FondiInsufficientException fe = new FondiInsufficientException("Fondi insufficienti ", Saldo, somma);
            //throw fe;
            throw new FondiInsufficientException("Fondi insufficienti ", Saldo, somma);
        }
    }
}
