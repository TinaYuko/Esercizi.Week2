using System;

namespace Esercizio_5
{
    class Program
    {
        // Scrivere una funzione che dato un importo di denaro iniziale,
        // un interesse annuo e un numero di anni permette di calcolare
        // l’importo di denaro accresciuto degli interessi dopo il numero di anni passati

        // Esempio
        // Voglio vincolare 10000 euro per 3 anni con un interesse del 3%

        // Dopo 1 anno : 10000 + (10000 * 3 / 100) = 10000 + 300 = 10300
        // Dopo 2 anni : 10300 + (10300 * 3 / 100) = 10300 + 309 = 10609
        // Dopo 3 anni : 10609 + (10609 * 3 / 100) = 10609 + 318,27 = 10927,27

        static void Main(string[] args)
        {
            Console.WriteLine("\nBenvenuto al portale -Pensa al tuo futuro- del Banco di Sardegna!");
            Console.Write("\nSe desidera vincolare una somma di denaro immetta l'importo: ");
            double importoDenaro = Convert.ToDouble(Console.ReadLine());
            Console.Write("Immettere il tasso di interesse: ");
            double tassoInteresse = Convert.ToDouble(Console.ReadLine());
            Console.Write("Dopo quanti anni volete ritirare i soldi? ");
            int anni = Convert.ToInt32(Console.ReadLine());

            double importoMaturato= CalcolareImportoFinale(importoDenaro, tassoInteresse, anni);
            Console.WriteLine($"\nL'importo maturato dopo {anni} anni è {importoMaturato}");

        }

        private static double CalcolareImportoFinale (double importoUtente, double tasso, int anni)
        {
            double importoMaturato = importoUtente;

            for (int i=0; i<anni; i++)
            {
                importoMaturato = importoUtente + (importoMaturato* (tasso / 100));
                importoUtente = importoMaturato;
            }
            return importoMaturato;
        }
    }
}
