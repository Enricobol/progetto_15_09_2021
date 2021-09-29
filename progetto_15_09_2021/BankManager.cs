using System;
using System.Collections.Generic;
using System.Text;

namespace progetto_15_09_2021
{
    public class BankManager
    {
        public decimal InitialBalance { get; set; }

        public static decimal MaxBalance { get; set; }

        public static int NumManager { get; set; } //Numero di Bankmanagers creati

        private Client[] clients;

        public int NumClients { get; set; }

        public BankManager(decimal initialBalance) //Costruttore, Inserisco il deposito iniziale
        {
            InitialBalance = initialBalance;
            BankManager.NumManager++; //Incremento globalmente il numero
            clients = new Client[3];
        }

        public bool AddClient(Client c)
        {
            if(NumClients >= clients.Length) { return false; }
            clients[NumClients] = c;
            NumClients++;
            return true;
        }

        public void Report() //Stampa di ogni cliente il nome, e la somma di tutti i soldi sui loro account.
        {
            for (int i = 0; i < clients.Length; i++)
            {
                if(clients[i] != null)
                {
                    Console.Write("Nome: " + clients[i].Name);
                    Console.Write(" Cognome: " + clients[i].LastName);
                    Console.Write(" Saldo: " + clients[i].TotalBalance());
                    Console.WriteLine();//torno a capo
                }
            }
        }
        //public static void F()
        //{
        //    Console.WriteLine(InitialBalance);
        //}

        public void HandleBank() 
        {
            //double x = Math.Sin(100);//esempi di variabili statiche
            //double p = Math.PI;

        }

    }
}
