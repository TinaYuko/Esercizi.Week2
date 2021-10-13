using System;
using System.IO;

namespace Esercizio_4
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("        Benvenuto a... Indovina il numero!! ");
            Console.Write("Come ti chiami? ");
            string name = Console.ReadLine();
            Console.WriteLine($"Ciao {name}!!");
            int numberRnd;
            char choice = SceltaMenu();

            if (choice.ToString().ToUpper() == "S")

            {
                numberRnd = GeneraNumeroSegreto();
                Console.WriteLine("\nVuoi vincere una coccoi di tzia Maria?");
                ControlloVincita(numberRnd);

            }

            else
            {
                Console.WriteLine("Adios!!");
            }
        }
        private static int GeneraNumeroSegreto()
        {
            string path = @"C:\Users\Marti\Desktop\Pink Academy\Week2\Esercizio 4\NumeroDaIndovinare.txt";
            Random rnd = new Random();
            int numberRnd = rnd.Next(1, 101);
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(numberRnd);
            }
            return numberRnd;
        }
        private static char SceltaMenu ()
            {
            
            Console.WriteLine("Vuoi giocare?" +
                "\n[S] per giocare" +
                "\n[N] per uscire.");
            char choice = Console.ReadKey().KeyChar;
            return choice;
            }

        private static void ControlloVincita(int numberRnd)
        {
            int tentativi = 0;
            int numeroScelto;
            string suggerimento;
            bool trovato = false;

            do
            {

                Console.WriteLine($"Finora hai effettuato {tentativi} tentativi.");
                tentativi++;
                Console.WriteLine($"Fai il tuo {tentativi}° tentativo!");
                while (!(int.TryParse(Console.ReadLine(), out numeroScelto) && numeroScelto >= 0 && numeroScelto <= 100))
                {
                    Console.WriteLine("Eh no, devi inserire un numero compreso tra 1 e 100!");
                    Console.WriteLine($"Fai il tuo {tentativi}° tentativo");
                    Console.WriteLine("Se vuoi interrompere la partita, schiaccia 0!");
                }

                if (numeroScelto == 0)
                {
                    Console.WriteLine($"Partita interrotta! Il numero segreto era {numberRnd}");
                }
                else if (numeroScelto == numberRnd)
                {
                    Console.WriteLine($"Hai vinto la coccoi, con soli {tentativi} tentativi!!!");
                    trovato = true;
                }
                else
                {
                    if (numeroScelto < numberRnd)
                    {
                        suggerimento = "Prova un numero più alto!";
                    }
                    else
                    {
                        suggerimento = "Prova un numero più basso!";
                    }
                    Console.WriteLine($"Suggerimento: {suggerimento}");
                }
            }
            while (trovato == false); 
        }

    }
}
