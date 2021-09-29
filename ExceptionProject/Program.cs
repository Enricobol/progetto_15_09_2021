using System;
using System.IO;

namespace ExceptionProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Conto c = new Conto();
            c.Saldo = 1000;
            try
            {
            c.Ritira(500);
            c.Ritira(501);
            }
            catch(FondiInsufficientException fe)
            {
                Console.WriteLine(fe.Message);
            }


            Console.WriteLine("Inizio Main : ");
            F1();
            Console.WriteLine("Fine Main : ");
        }

        static void F1()
        {
            Console.WriteLine("Inizio F1 : ");
            F2();
            Console.WriteLine("Fine F1 : ");
        }
        static void F2()
        {
            Console.WriteLine("Inizio F2 : ");
            try
            {
                F3();
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(FileNotFoundException fen)
            {
                Console.WriteLine(fen.Message);
            }
            catch(IOException sql)
            {
                Console.WriteLine(sql.Message);
            }
            finally
            {

            }
            
            Console.WriteLine("Fine F2 : ");
        }
        static void F3()
        {
            Console.WriteLine("Inizio F3 : ");
            int x;
            x =  int.Parse("Ciccio");

            #region Tento di gestire l'eccezione in F3
            //try
            //{
            //    int.Parse("Ciccio");
            //}
            //catch (FormatException fe)
            //{
            //    x = -1;
            //}
            #endregion

            Console.WriteLine("Fine F3 : ");
        }
    }
}
