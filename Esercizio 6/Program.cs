using System;
using System.Collections.Generic;

namespace Esercizio_6
{
    class Program
    { 
        /*
         * Scrivere un programma che gestisca una libreria.
         * Un libro è un entità che ha:
         * Codice
         * Titolo
         * Autore 
         * Genere
         * Prezzo
         * Data pubblicazione
         * Per il genere usare enum.
         * Sarà possibile inserire un libro, eliminare un libro, modificare un libro o cercare un libro per genere */

        static void Main(string[] args)
        {
            Menu.Start(); //Richiamo il metodo della classe Menu











            /*
            Libro libro1 = new Libro();
            //Costruisco una cassetta Libro che contiene un nuovo libro
            //Il costruttore prepara un pezzetto di memoria per preparare il "cassetto" per libro

            libro1.Codice = "Cod001";
            libro1.Autore = "Manzoni";
            libro1.Titolo = "I promessi sposi";
            libro1.Prezzo= 12.90;
            libro1.DataPubblicazione = new DateTime(1827, 05, 28);
            libro1.Genere = Genere.Narrativa;

            Console.WriteLine($"{libro1.Autore}");

            //Creo un altro libro
            Libro libro2 = new Libro();
            //Col costruttore, gli faccio allocare uno spazietto di memoria per libro2
            //E poi manualmente gli metto le proprietà
            libro2.Codice = "Cod002";
            libro2.Autore = "Dante";
            libro2.Titolo = "La divina commedia";
            libro2.Prezzo = 15.80;
            libro2.DataPubblicazione = new DateTime(1995, 11, 14);
            libro2.Genere = Genere.Narrativa;

            List<Libro> libri = new List<Libro>();
            libri.Add(libro1);
            Console.WriteLine($"La mia lista contiene {libri.Count} libri");
            libri.Add(libro2);
            Console.WriteLine($"La mia lista contiene {libri.Count} libri");
            libri.Remove(libro1);
            Console.WriteLine($"La mia lista contiene {libri.Count} libri");
            */
        }
    }
}
