using System;
using System.Collections.Generic;
using System.Text;

namespace progetto_15_09_2021
{
    public class Account
    {

        public decimal Saldo { get; set; }

        public Account(decimal saldo)
        {
            Saldo = saldo;
        }

        #region esercizzi mattinata

        //private decimal saldo; //Ignorance is bliss

        //public decimal Saldo //Getsaldo con sintassi semplificata pubblica, agisce come una emplice variabile! Si dice una proprietà!
        //{
        //    get 
        //    {
        //        return saldo;
        //    }
        //    set
        //    {
        //        saldo = value;
        //    }
        //}

        //public int Saldo { get; set; }
        //public int Saldo { get; } = 89;


        //public Account(decimal newSaldo)
        //{
        //    //saldo = newSaldo;
        //    F1(3.4, 8); //chiamo la prima funzione
        //    F1(12, 4.23); //Chiamo la seconda
        //}
        ////overloading dei costruttori = avere multipli costruttori
        //public Account() { }//Costruttore standard 

        ////public decimal GetSaldo() //Ottieni il saldo se fosse privato
        ////{
        ////    return saldo;
        ////}
        ////public void SetSaldo(decimal newSaldo) //modificatore di saldo se fosse privato
        ////{
        ////    saldo = newSaldo;
        ////}


        ////Posso avere più funzioni con lo stesso nome con diversi tipi di parametri senza andare in conflitto
        ////Questo perchè quando invoco una funzione i parametri devono essere obligatoriamente aggiunti perciò il programma capische quale funzione chiamo.
        //public void F1(int x, double z) { }// Nome funzione + lista parametri = firma del metodo
        //public void F1(double x, int z) { }

        //Invece se cambia solo il ritorno di una funzione il programma non può fare distinzione visto che specificare il ritorno nel main non è obbligatorio
        //public int F1(double z, int z) { }
//public è un modificatore di visibilità
//Public = visiblile all'interno dello stesso programma ed altri programmi
//Internal = visibile all'interno solo dello stesso programma
//Private = visibile solo all'interno della stessa classe
        #endregion
    }
}
