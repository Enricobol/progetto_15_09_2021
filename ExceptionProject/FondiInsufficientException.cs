using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionProject
{
    class FondiInsufficientException : Exception
    {
        public decimal Saldo { get; set; }
        public decimal AmmontareRichiesto { get; set; }
        public decimal Sforamento { get; set; }
        public FondiInsufficientException(string message , decimal saldo , decimal sommaRichiesta) : base(message)
        {
            Saldo = saldo;
            AmmontareRichiesto = sommaRichiesta;
            Sforamento = sommaRichiesta - saldo;
        }


    }
    
    
}
