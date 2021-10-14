using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_6
{
    public static class Menu
    {
        public static void Start()
        {
            Console.WriteLine("Benvenuto nella libreria!");

            bool exit = true;

            do
            {
                Console.WriteLine("\nPremi [1] per aggiungere un libro." +
                    "\nPremi [2] per eliminare un libro." +
                    "\nPremi [3] per modificare un libro." +
                    "\nPremi [4] per stampare i libri." +
                    "\nPremi [5] per estrarre i libri per genere." +
                    "\nPremi [0] per uscire");

                int scelta;
                do
                {
                    Console.WriteLine("Fai la tua scelta tra le possibili richieste");
                }
                while (!int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta < 5);

                switch (scelta)
                {
                    case 1:
                        //Aggiungi libro
                        LibreriaManager.AggiungiLibro();

                        break;
                    case 2:
                        //Elimina libro
                        LibreriaManager.Eliminalibro();
                        break;
                    case 3:
                        //Modifica libro
                        LibreriaManager.ModificaLibro();
                        break;
                    case 4:
                        //Stampare libri
                        LibreriaManager.StampaLibro();
                        break;
                    case 5:
                        //Filtra libri
                        LibreriaManager.FiltraLibro();
                        break;
                    case 0:
                        Console.WriteLine("Arrivederci!");
                        exit = false;
                        break;
                }
            }
            while (exit); //oppure exit==true
        }
    }
}