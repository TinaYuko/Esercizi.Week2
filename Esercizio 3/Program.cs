using System;

namespace Esercizio_3
{
    // Le carte di pagamento sono lunghe 16 cifre. 
    // Le prime 6 cifre rappresentano un numero di identificazione univoco per la banca che ha emesso la carta.
    // Le successive 2 cifre determinano il tipo di carta (ad es. debito, credito, regalo).
    // Le cifre da 9 a 15 sono il numero di serie della carta
    // L'ultima cifra è utilizzata come cifra di controllo per verificare se il numero della carta è valido.

    // Hans Peter ha inventato un metodo per determinare se un numero di carta di credito è sintatticamente valido

    // Step 1 : Vengono raddoppiate le cifre che si trovano in posizione dispari e
    // Step 2 : Se questo "raddoppio" risulta in un numero a due cifre, viene sottratto 9 da esso per ottenere una sola cifra.
    // Step 3 : Vengono sommante tutte le cifre ottenute
    // Step 4 : Vengono aggiunte le cifre nelle posizioni pari
    // Step 5 : Se il risultato è divisibile per 10, il numero della carta è valido; in caso contrario, non è valido.

    // Esempi
    // Carta di pagamento : 4  5  5  6    7  3  7  5   8  6  8  9   9  8  5  5
    // Step 1             : 8  5 10  6   14  3 14  5   16 6  16 9   18 8  10 5
    // Step 2             : 8  5  1  6    5  3  5  5   7  6  7  9   9  8  1  5
    // Step 3             : 8 + 1 + 5 + 5 + 7 + 7 + 9 + 1 = 43
    // Step 4             : 43 + (5+6+3+5+6+9+8+5) = 43 + 47 = 90
    // Step 5             : 90/10 = 9 resto 0 -> Numero della carta valido

    // Esempi
    // Carta di pagamento : 4  0  2  4    0  0  7  1   0  9  0  2   2  1  4  3
    // Step 1             : 8  0  4  4    0  0 14  1   0  9  0  2   4  1  8  3
    // Step 2             : 8  0  4  4    0  0  5  1   0  9  0  2   4  1  8  3
    // Step 3             : 8 + 4 + 0 + 5 + 0 + 0 + 4 + 8 = 29
    // Step 4             : 29 + (0+4+0+1+9+2+1+3) = 29 + 20 = 49
    // Step 5             : 49/10 = 4 resto 9 -> Numero della carta non valido
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ciao, sono Hans Peter e voglio controllare se la tua carta di credito è valida! Eheh");

            
                Console.WriteLine("Prego, immetti le 16 cifre della tua carta di pagamento:");
                int[] creditcardnumber = new int[16];
                for (int i = 0; i < creditcardnumber.Length; i++)
                {
                int numero;
                while(!int.TryParse(Console.ReadLine(), out numero)&& numero >=0 && numero <9)

                {
                    Console.WriteLine("Valore non valido, prego inserire nuovamente.");
                }
                creditcardnumber[i] = numero;
                }

                Console.WriteLine("I numeri della carta sono: ");
                for (int i = 0; i < creditcardnumber.Length; i++)
                {
                    Console.Write($"{creditcardnumber[i]}");
                }

                //Console.Write("Le cifre sono corrette? " +
                //    "\n[S] o [N]");
                //char answer = Console.ReadKey().KeyChar;

                int[] creditnumbersPari=new int[8];
                int[] creditnumberDispari=new int[8];
            int countPari = 0;
            int countDispari = 0;

            for (int i = 0; i < creditcardnumber.Length; i++)
            {
                if (i % 2==0)
                {
                    creditnumberDispari[countDispari] = creditcardnumber[i];
                    countDispari++;
                }
                else
                {
                    creditnumbersPari[countPari] = creditcardnumber[i];
                    countPari++;
                }
            }

            Console.WriteLine("\n\nI numeri di posizione PARI della carta sono: ");
            for (int i = 0; i < creditnumbersPari.Length; i++)
            {
                Console.Write($"{creditnumbersPari[i]}");

            }

            Console.WriteLine("\n\nI numeri di posizione DISPARI della carta sono: ");
            for (int i = 0; i < creditnumberDispari.Length; i++)
            {
                Console.Write($"{creditnumberDispari[i]}");

            }

            for (int i=0; i<creditnumberDispari.Length; i++)
            {
                creditnumberDispari[i] = creditnumberDispari[i] * 2;
            }

            
            
                for (int i=0; i<creditnumberDispari.Length; i++)
                {
                    if (creditnumberDispari[i] >9)
                    {
                    creditnumberDispari[i] = creditnumberDispari[i] - 9;
                    }
                }

            int sommaDispari=0;
            int sommaPari=0;

            for (int i=0; i<creditnumberDispari.Length; i++)
            {
                sommaDispari = sommaDispari + creditnumberDispari[i];
            }

            for (int i = 0; i < creditnumbersPari.Length; i++)
            {
                sommaPari = sommaPari + creditnumbersPari[i];
            }

            int somma = sommaPari + sommaDispari;
            if (somma%9==0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nLa tua carta di credito è valida!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nSi prega di contattare la banca, la tua carta di credito non è valida.");
                Console.ForegroundColor = ConsoleColor.White; 
            }
        }
    }
}
