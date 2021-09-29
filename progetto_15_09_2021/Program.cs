using System;

namespace progetto_15_09_2021
{
    class Program
    {
       static void Main(string[] args)
        {

            #region esercizzi mattinata
            //            Account a1 = new Account(100);
            //            Account a2 = new Account(200);
            //            Account a3 = new Account();

            //            Swap(a1, a2);//Cerco di invertire gli account per value !!! Non funziona bene !!!

            //            //Console.WriteLine("{0}  {1}", a1.saldo, a2.saldo);

            //            Swap(ref a1, ref a2);//Cerco di invertire gli account per reference !!! Metodo giusto

            //            //Console.WriteLine("{0}  {1}", a1.saldo, a2.saldo);

            //            //a1.saldo = 90// Modifica di saldo se fosse Public
            //            //Console.WriteLine("{0}  {1}", a1.GetSaldo(), a2.GetSaldo()); //Scrivo il saldo anche se fosse privato
            //            //a1.SetSaldo(90); //Funzione che permette di modificare il saldo se fosse privato

            //            //a1.Saldo = 200; //Utilizzo la variabile pubblica speciale che utilizza la variabile privata
            //            Console.WriteLine(a1.Saldo);
            //        }
            //        #region 1
            //        static void Swap(Account tipo1, Account tipo2) //Sto cercando di swappere per value
            //        {
            //            //Account temp = tipo1; //Non funziona scambiare gli account per value
            //            //tipo1 = tipo2;
            //            //tipo2 = temp;

            //            //decimal temp = tipo1.saldo; //Funziona solo con public
            //            //tipo1.saldo = tipo2.saldo;
            //            //tipo2.saldo = temp;
            //        }
            //        #endregion 1
            //        static void Swap(ref Account pippo1, ref Account pippo2) //Swappo invece per reference
            //        {
            //            Account temp = pippo2;
            //            pippo1 = pippo2;
            //            pippo2 = temp;
            #endregion

            //BankManager.HandleBank(); //Chiamata dinamica, direttamente tramite il metodo

            BankManager bm1 = new BankManager(1000); //Chiamata Statica, necessita un oggetto della classe 
            bm1.HandleBank();
            Console.WriteLine(bm1.InitialBalance);

            BankManager bm2 = new BankManager(500); 
            bm2.HandleBank();
            Console.WriteLine(bm2.InitialBalance);


            Account a1 = new Account(bm1.InitialBalance);
            Account a2 = new Account(bm1.InitialBalance);
            Account a3 = new Account(bm1.InitialBalance);
            Account a4 = new Account(bm1.InitialBalance);
            Account a5 = new Account(bm1.InitialBalance);
            Account a6 = new Account(bm1.InitialBalance);

            Client c1 = new Client("Mario", "Rossi", "abcd123", new DateTime(1990, 1, 24));
            Client c2 = new Client("Gino", "Carlo", "efgh456", new DateTime(1980, 2, 26));

            #region Vecchio inserimento accounts
            ////Vecchio metodo per Inserire gli account nei Client (in realtà inserisco l'indirizzo degli account negli array)
            //c1.Accounts[0] = a1;
            //c1.Accounts[1] = a2;
            //c1.Accounts[2] = a3;
            //c2.Accounts[0] = a4;
            #endregion

            c1.AddAccount(a1);
            c1.AddAccount(a2);
            c1.AddAccount(a3);
            c1.AddAccount(a4);
            c1.AddAccount(a5);
            c2.AddAccount(a6);

            bm1.AddClient(c1);
            bm1.AddClient(c2);


            c1.PrintReport();
            Console.WriteLine("****");

            c1.RemoveAccount(4);
            c1.PrintReport();
            Console.ReadKey();

            bm1.Report(); //Stampa Nomi e totali di Bm1
        }
    }

    
}
