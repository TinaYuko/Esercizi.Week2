using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_7
{
    public static class Menu
    {
        public static void Start()
        {
            Console.WriteLine("Benvenuto nel portale della Banca ISP");

            bool continua = true;

            do
            {
                Console.WriteLine("Premi \n[1] per registrare un conto." +
                    "\n[2] per estinguere il conto." +
                    "\n[3] per modificare il tuo conto." +
                    "\n[4] per avere la stampa dei conti." +
                    "\n[5] per filtrare i conti che si desidera vedere." +
                    "\n[0] per uscire.");

                int choice;

                do
                {
                    Console.Write("Premi il numero desiderato: ");
                }
                while (!(int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice < 6));


                switch (choice)
                {
                    case 1:
                        //aprire un conto
                        BancaManager.RegistraConto();
                        break;
                    case 2:
                        //estinguere il conto
                        BancaManager.EstinguiConto();
                       
                        break;
                    case 3:
                        //modificare il conto
                        BancaManager.ModificaConto();
                        break;
                    case 4:
                        //stampare il conto
                        BancaManager.StampaConto();
                        break;
                    case 5:
                        //filtrare i conti
                        BancaManager.FiltraConto();
                        break;
                    case 0:
                        Console.WriteLine("Grazie per aver utilizzato il nostro portale.");
                        continua = false;
                        break;
                }
               
            }
            while (continua);
        }
    }
}
