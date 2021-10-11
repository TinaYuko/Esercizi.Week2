using System;

namespace Esercizio_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Realizza un menu dove chiede dati utente e kwh consumati
            Richiedi il calcolo del costo della bolletta che è composto da una quota fissa
            di 40 euro più il prodotto tra i kwh e 10
            Stampa a video i valori della bolletta, inclusi i dati e prezzo
            Utilizza le funzioni
            */
            Console.WriteLine("Siamo l'utenza Enel, pronti a fornirti le informazioni che desideri");

            bool exit = true;
            Console.WriteLine("\nPrego, inserire nome e cognome:");
            string name_surname = Console.ReadLine();
            Console.Write("\nInserire kW/h consumati: ");
            double watt = Convert.ToDouble(Console.ReadLine());
            double bill = Bills(watt);

            do
            {
                Console.WriteLine("\nScegli un'operazione da effettuare: " +
                    "\n[1] Per richiedere il fatturato della bolletta." +
                    "\n[2] Per stampare la bolletta. " +
                    "\n[Q] Per uscire.");

               char choice = Console.ReadKey().KeyChar;
               
                switch (choice.ToString().ToUpper())
                {
                    case "1":
                        bill = Bills(watt);
                        Console.WriteLine($"\nHai fatturato {bill} euro.");
                        break;
                    case "2":
                        Stamp(name_surname, bill);
                        break;
                    case "Q":
                        exit = false;
                        break;
                }
            }

            while (exit);

        }

        private static double Bills (double watt)
        {
         
            double bill= 40 + watt * 10;
            return bill;
        }
        private static void Stamp (string name_surname, double bill)
        {
            Console.WriteLine($"\nLa bolletta di {name_surname} è di {bill} euro.");
        }
    }
            






        

    
}
