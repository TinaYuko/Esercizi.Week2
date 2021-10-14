using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_6
{
   public static class LibreriaManager
    {

        //Mi creo qui i metodi

        public static List<Libro> libri = new List<Libro>();
        public static void AggiungiLibro()
        {
            Libro libro = new Libro(); //libro "vuoto"
            Console.WriteLine("Inserisci codice libro");
            libro.Codice = Console.ReadLine();
            Console.WriteLine("Inserisci titolo libro");
            libro.Titolo = Console.ReadLine();
            Console.WriteLine("Inserisci l'autore del libro");
            libro.Autore = Console.ReadLine();

            //Console.WriteLine("Inserisci prezzo del libro");
            //libro.Prezzo = Convert.ToDouble(Console.ReadLine());
            libro.Prezzo = InserisciPrezzo();
            libro.DataPubblicazione = InserisciData();
            libro.Genere = InserisciGenere();
            libri.Add(libro);
            Console.WriteLine("Libro aggiunto correttamente");

        }

        private static Genere InserisciGenere()
        {
            Console.WriteLine("Inserisci il genere");
            Console.WriteLine($"Premi {(int)Genere.Narrativa} per il genere {Genere.Narrativa}. ");
            Console.WriteLine($"Premi {(int)Genere.Storico} per il genere {Genere.Storico}. ");
            Console.WriteLine($"Premi {(int)Genere.Fantasy} per il genere {Genere.Fantasy}. ");
            Console.WriteLine($"Premi {(int)Genere.Horror} per il genere {Genere.Horror}. ");

            int genere;
            do
            {
                Console.WriteLine("Fai la tua scelta");

            }
            while (!(int.TryParse(Console.ReadLine(), out genere) && genere >= 1 && genere < 5));
            return (Genere)genere; //Faccio il cast affinché con l'enum non mi restituisca il numero ma proprio il genere

        }

        private static DateTime InserisciData()
        {
            DateTime data;
            do
            {
                Console.WriteLine("Inserisci data pubblicazione del libro");
            }
            while (!(DateTime.TryParse(Console.ReadLine(), out data) && data <= DateTime.Today));
            return data;
        }

        private static double InserisciPrezzo()
        {
            double prezzo;
            do
            {
                Console.WriteLine("Inserisci prezzo del libro");
            }
            while (!(double.TryParse(Console.ReadLine(), out prezzo) && prezzo > 0));
            return prezzo;
        }

        public static void Eliminalibro()
        {
            Console.WriteLine("I libri presenti nella libreria sono: ");
            StampaLibro();
            Console.Write("Scrivi il codice del libro che vuoi eliminare: ");
            string codiceDaCercare = Console.ReadLine();
            Libro libroTrovato= CercaLibro(codiceDaCercare);
            if (libroTrovato==null)
            {
                Console.WriteLine("Libro non pervenuto. Codice errato!");

            }
            else
            {
                libri.Remove(libroTrovato);
                Console.WriteLine("Libro eliminato correttamente");
            }

        }

        private static Libro CercaLibro(string codice)
        {
            foreach (var item in libri)
            {
                if (item.Codice == codice)
                {
                    return item;
                }
                
            }
            return null;
        }

        public static void ModificaLibro()
        {
            Console.WriteLine("I libri della libreria sono: ");
            StampaLibro();
            //Scegli il libro che vuoi modificare
            Console.Write("Scrivi il codice del libro che vuoi modificare: ");
            string codiceDaCercare = Console.ReadLine();
            Libro libroTrovato = CercaLibro(codiceDaCercare);
            //Facciamo un controllo
            if (libroTrovato == null)
            {
                Console.WriteLine("Libro non pervenuto. Codice errato!");

            }
            else
            {
                bool continua = true;
                do
                {
                    //Menu con le possibili opzioni
                    Console.WriteLine("Premi [1] per modificare il Titolo." +
                        "\n[2] per modificare l'autore." +
                        "\n[3] per modificare il genere." +
                        "\n[4] per il prezzo." +
                        "\n[5] per la data di pubblicazione." +
                        "\n[0] per uscire e non rompere più le palle.");

                    int scelta;
                    do
                    {
                        Console.WriteLine("Fai la tua scelta tra le possibili richieste");
                    }
                    while (!int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta < 6);

                    switch (scelta)
                    {
                        case 1:
                            Console.Write("inserisci il nuovo titolo: ");
                            string titoloNuovo = Console.ReadLine();
                            libroTrovato.Titolo = titoloNuovo;
                            break;
                        case 2:
                            Console.Write("inserisci il nuovo autore: ");
                            libroTrovato.Autore = Console.ReadLine();
                            break;
                        case 3:
                            libroTrovato.Genere = InserisciGenere();
                            break;
                        case 4:

                            libroTrovato.Prezzo = InserisciPrezzo();
                            break;
                        case 5:
                            libroTrovato.DataPubblicazione = InserisciData();
                            break;
                        case 0:
                            continua = false;
                            break;
                    }
                }
                while (continua);

                Console.WriteLine("I libri con i nuovi aggiornamenti, sono: ");
                StampaLibro();
            }
            
            //Modifica sul campo desiderato


        }

        public static void StampaLibro()
        {
            StampaLibriDiUnaLista(libri);
        }

        public static void StampaLibriDiUnaLista(List<Libro> listaLibri)
        {
            //Questo metodo mi serve per prendere in input una lista di libri e controllare
            //se la lista è piena
            //In questo modo posso stampare liste generiche
            if(listaLibri.Count==0)
            {
                Console.WriteLine("Lista vuota");

            }
            else
            {
                Console.WriteLine("Codice\t\tTitolo\t\tAutore\t\tGenere\t\tPrezzo\t\tData");
                foreach (Libro libro in listaLibri) //oppure va bene anche lasciare var item in listaLibri
                {
                    Console.WriteLine($"{libro.Codice}\t\t{libro.Titolo}\t\t{libro.Autore}\t\t{libro.Genere}\t\t{libro.Prezzo}\t\t{libro.DataPubblicazione}");
                    //se lascio item, ricorda di mettere item.Titolo ecc
                }
            }
        }

        public static void FiltraLibro()
        {
            //Dobbiamo filtrare i libri per genere
            //possiamo riutilizzare un metodo già utilizzato
            Genere g = InserisciGenere();
            List<Libro> libriPerGenere = new List<Libro>();

            foreach (var item in libri)
            {
                //mi salvo i libri per genere in una nuova lista
                if (item.Genere == g)
                {
                    libriPerGenere.Add(item);
                }

            }
            //e uso il metodo per stampare una lista generica per stamparmi questa lista nuova
            StampaLibriDiUnaLista(libriPerGenere);    
        }
    }
}
