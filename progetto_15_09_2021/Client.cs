using System;
using System.Collections.Generic;
using System.Text;

namespace progetto_15_09_2021
{
    public class Client
    {
        //Lista delle proprietà
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; } //Codice fiscale
        public DateTime DateOfBirth { get; set; }
        public int NumberOfAccounts { get; private set; } //posso vedere il numero ma non settarlo

        public Account[] Accounts { get; set; } //Array di account, metodo incorretto

        public Client(string name, string lastName, string ssn, DateTime dateOfBirth)
        {
            Name = name;
            LastName = lastName;
            Ssn = ssn;
            DateOfBirth = dateOfBirth;
            Accounts = new Account[5];
            //NumberOfAccounts viene automaticamente settato su 0
        }

        #region  BadAddAccount
        //public int BadAddAccount(Account a) //Metodo aggiungi account, ritorna -1 se non riesce ad aggiungere, altrimenti il numero di accounts
        //{
        //    for (int i = 0; i < Accounts.Length; i++)
        //    {
        //        if (Accounts[i] == null)
        //        {
        //            Accounts[i] = a;
        //            NumberOfAccounts++;
        //            return NumberOfAccounts;
        //        }
        //    }
        //    return -1;
        //}

        #endregion

        public int AddAccount(Account a) //Metodo aggiungi account, ritorna -1 se non riesce ad aggiungere, altrimenti il numero di accounts
        {
            if (NumberOfAccounts >= Accounts.Length) { return -1; }

            #region Utilizzo strano del ++
            //Accounts[NumberOfAccounts++] = a; //In questo caso il ++ viene applicato dopo l'assegnazione, quindi prima fa N.O.A. = a e poi N.O.A.++
            //return ++NumberOfAccounts; //In alternativa possiamo incremetare N.O.A. prima di ritornarlo, in entrambi i casi è sconsigliato perchè è facile non vederlo
            #endregion

            Accounts[NumberOfAccounts] = a;
            NumberOfAccounts++;
            return NumberOfAccounts;

        }

        #region BadRemoveAccount
        //public Account BadRemoveAccount(int pos) //Rimuovi account dalla posizione, ritorna l'account eliminato, riorganizza gli account rimanenti
        //{
        //    Account removed = Accounts[pos];
        //    Accounts[pos] = null;
        //    NumberOfAccounts--;
        //    for (int i = pos; i < Accounts.Length-1; i++)
        //    {
        //        if(Accounts[i+1] != null)
        //        {
        //            Accounts[i] = Accounts[i + 1];
        //        }
        //        else
        //        {
        //            Accounts[i] = null;
        //        }
        //    }
        //    if (NumberOfAccounts == 4)
        //    {
        //        Accounts[NumberOfAccounts] = null;
        //    }
        //    return removed;
        //}
        #endregion

        public Account RemoveAccount(int pos) //Rimuovi account dalla posizione, ritorna l'account eliminato, riorganizza gli account rimanenti
        {
            if(pos < 0 || pos > Accounts.Length -1 || NumberOfAccounts <= 0) //Controllo di non avere una posizione errata
            {
                return null;
            }
         
            #region Vecchio controllo posizione
            //if(pos == Accounts.Length - 1) //Controllo se è l'ultima posizione che cerco di eliminare, in caso elimino solo quella senza scorrere.
            //{
            //    Accounts[NumberOfAccounts] = null;
            //    NumberOfAccounts--;
            //    return removed;
            //}
            #endregion

            Account removed = Accounts[pos];

            for (int i = pos; i < Accounts.Length - 1; i++)
            {
                Accounts[i] = Accounts[i + 1];
            }
            NumberOfAccounts--;
            Accounts[NumberOfAccounts] = null;
            return removed;
        }


        public void PrintReport()
        {
            for (int i = 0; i < Accounts.Length; i++)
            {
                if(Accounts[i] != null)
                {
                    Console.WriteLine("pos: " + i + " saldo: " + Accounts[i].Saldo);
                }
                else
                {
                    Console.WriteLine("pos: " + i + " posizione disponibile!");
                }
            }
        }

        public decimal TotalBalance() //Ottieni bilancio totale
        {
            var total = 0.0m; //var assume il tipo di variabile che gli viene assegnata, in questo caso var = decimal!
            foreach (var acc in Accounts )
            {
                if (acc != null) //Devo verificare che un cliente non abbia accounts nulli
                {   
                    total += acc.Saldo;
                }
            }
            return total;
        }

    }
}
