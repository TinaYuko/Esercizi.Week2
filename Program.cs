using System;

namespace Esercizio_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola!!! Questa sarà una calcolatrice");
            Console.WriteLine("\nCome ti chiami? :D");
            //string username= "Martina"; in questo caso l'ho già inizializzato

            string username;
            username= Console.ReadLine();

            Console.WriteLine($"Ciao {username}!");

            Console.Write("Inserisci il primo numero: ");
            int num1;
            bool esitoConversione = int.TryParse(Console.ReadLine(), out num1);
            while (esitoConversione==false)
            {
                Console.Write("Hai inserito un valore errato. " +
                    "Inserisci nuovamente un numero, pls: ");
                esitoConversione = int.TryParse(Console.ReadLine(), out num1);
            }

            Console.WriteLine($"Il primo numero inserito è {num1}");
            //il try parse prova a convertire il numero,
            //cercando di non arrivare all'accezzione

            //Oppure possiamo fare così
            int num2;
            do
            {
                Console.Write("Inserisci il secondo numero: ");
            }

            while (!int.TryParse(Console.ReadLine(), out num2));
            Console.WriteLine($"Il secondo numero inserito è {num2}");


            bool exit = true;
            do
            {
                Console.WriteLine("\nScegli un'opzione: " +
                    "\n[1] Somma" +
                    "\n[2] Sottrazione" +
                    "\n[3] Moltiplicazione" +
                    "\n[4] Divisione" +
                    "\n[Q] Esci");


                char choice = Console.ReadKey().KeyChar;
                // Il readkey legge un solo carattere anzichè tutta la linea
                //Il keychar proprio per prendere il carattere


                switch (choice.ToString().ToUpper())
                {
                    case "1":
                        int sum = Sum(num1, num2);
                        Console.WriteLine($"\nLa somma è: {sum}");
                        break;
                    case "2":
                        int sottr = Subtract(num1, num2);
                        Console.WriteLine($"\nLa sottrazione è: {sottr}");
                        break;
                    case "3":
                        int molt = Multiply(num1, num2);
                        Console.WriteLine($"\nLa moltiplicazione è: {molt}");
                        break;
                    case "4":

                        if (num2 == 0)
                        {
                            Console.WriteLine("\nImpossibile se il denominatore è zero!");
                        }
                        else
                        {

                        double div = Divide(num1, num2);
                        Console.WriteLine($"\nLa divisione è: {div}");
                        }
                        break;
                    case "Q":
                        exit = false;
                        break;

                }
            }

            while (exit);


            //int a = 1;
            //int b = 2;
            //StampaValori(a, b);
            //ModificaValori(a, b);
            //Console.WriteLine($"i due valori, sono: {a} e {b}");
            ////Mi rimane sempre 1 e 2 perchè non ho restituito nulla

            ////In questo caso, per riferimento mi restituisce proprio i nuovi valori
            //ModificaValoribyRef(ref a, ref b);
            //Console.WriteLine($"i due valori, sono: {a} e {b}");

            ////Mentre l'out si sfrutta quando vogliamo un altro tipo di ritorno
            //int somma= SumAndMultiply(a, b, out int prodotto);

            //int somma2= SommaEDifferenza(12, 3, out string Differenza);
            //Console.WriteLine("La differenza è: " + Differenza + $"\nLa somma è {somma2}");


        }

        private static double Divide(double n, double m)
        {
                double div = n / m;
                return div;
        }
        private static int Multiply(int n, int m)
        {
            int molt = n * m;
            return molt;    
        }

        private static int Subtract(int n, int m)
        {
            int sottr = n - m;
            return sottr;  
        }

        private static int Sum(int n, int m)
        {
            int somma = n + m;
            return somma; 
        }

        //Triplo slash per poter aggiungere commenti nella funzione
        //che appare nel main

        ///// <summary>
        ///// Questo metodo mi restituisce la somma dei due valori passati in input. 
        ///// Mentre nel prodotto mi restituisce il prodotto dei due valori
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="m"></param>
        ///// <param name="prodotto"></param>
        ///// <returns></returns>
        //private static int SumAndMultiply(int n, int m, out int prodotto)
        //{ 
           
        //    int sommaValori = n + m;
        //    prodotto = n * m;
        //    return sommaValori;
        //}

        //private static void ModificaValoribyRef(ref int n, ref int m)
        //{
        //    n = 10;
        //    m++;
        //}

        //private static void ModificaValori(int n, int m)
        //{
        //    n = 5;
        //    m = 6;
        //    Console.WriteLine($"i due valori, sono: {n} e {m}");

        //}

        //private static void StampaValori(int n, int m)
        //{
        //    Console.WriteLine($"i due valori, sono: {n} e {m}");
        //}

        ///// <summary>
        ///// Oltre alla somma mi restituisce una stringa che mi dice
        ///// se la differenza è un valore positivo
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="m"></param>
        ///// <param name="esitoDifferenza"></param>
        ///// <returns>Somma dei due valori n e m passati in input</returns>
        //private static int SommaEDifferenza (int n, int m, out string esitoDifferenza)
        //{
        //    if (n-m>=0)
        //    {
        //        esitoDifferenza = "positiva";
        //    }
        //    else
        //    {
        //        esitoDifferenza = "negativa";
        //    }
        //    return n + m;

        //}
    }
}
