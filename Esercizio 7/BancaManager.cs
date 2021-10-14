using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_7
{
    public static class BancaManager
    {
        public static List<Conto> conti = new List<Conto>();
        public static void RegistraConto()
        {
            //Chiedo all'utente le informazioni 
            Conto conto = new Conto();
            Console.Write("Nome e Cognome intestatario: ");
            conto.Intestatario = Console.ReadLine();
            Console.Write("Numero conto: ");
            conto.NumeroConto = Console.ReadLine();

            conto.Saldo = InserisciSaldo();
            conto.TipoDiConto = InserisciTipoDiConto();
            conto.DataScadenza = InserisciData();
            conti.Add(conto);
            Console.WriteLine("Conto registrato correttamente");
        }

        private static DateTime InserisciData()
        {
            DateTime data;
            do
            {
                Console.Write("Inserisci data di scadenza: ");

            }
            while (!(DateTime.TryParse(Console.ReadLine(), out data) && data > DateTime.Today));
            return data;
        }

        private static TipoConto InserisciTipoDiConto()
        {
            Console.WriteLine("Inserisci che Tipo di Conto vuoi registrare.");
            Console.WriteLine($"Premi {(int)TipoConto.ContoCorrente} per registrare {TipoConto.ContoCorrente}");
            Console.WriteLine($"Premi {(int)TipoConto.ContoCorrenteDebito} per registrare {TipoConto.ContoCorrenteDebito}");
            Console.WriteLine($"Premi {(int)TipoConto.ContoCorrenteCredito} per registrare {TipoConto.ContoCorrenteCredito}");
            Console.WriteLine($"Premi {(int)TipoConto.ContoCorrenteRicaricabile} per registrare {TipoConto.ContoCorrenteRicaricabile}");
            int tipoconto;

            do
            {
                Console.Write("Quale scegli? ");
            }
            while (!(int.TryParse(Console.ReadLine(), out tipoconto) && tipoconto > 0 && tipoconto < 5));
            return (TipoConto)tipoconto;
        }

        private static double InserisciSaldo()
        {
            double saldo;
            do
            {
                Console.Write("Inserisci il saldo iniziale: ");
            }
            while (!(double.TryParse(Console.ReadLine(), out saldo) && saldo > 0));
            return saldo;
        }

        public static void EstinguiConto()
        {
            Console.WriteLine("I conti presenti sono: ");
            StampaConto();
            Console.Write("Scrivi il numero del conto che vorresti estinguere: ");
            string contoDaCercare = Console.ReadLine();
            Conto contoTrovato = CercaConto(contoDaCercare);
            if (contoTrovato==null)
            {
                Console.WriteLine("Conto non pervenuto.");
            }
            else
            {
                conti.Remove(contoTrovato);
                Console.WriteLine("Conto estinto.");
            }
        }

        private static Conto CercaConto(string contoDaCercare)
        {
            foreach (var item in conti)
            {
                if (item.NumeroConto==contoDaCercare)
                {
                    return item;
                }
            }
            return null;
        }

        public static void ModificaConto()
        {

            Console.WriteLine("I conti presenti sono: ");
            StampaConto();
            Console.Write("Inserisci il numero di conto da modificare: ");
            string codiceContoModif = Console.ReadLine();
            Conto contoDaModificare = CercaConto(codiceContoModif);

            if (contoDaModificare==null)
            {
                Console.WriteLine("Conto non pervenuto.");

            }
            else
            {
                bool exit = true;

                do
                {
                    Console.WriteLine("Premi \n[1] per modificare l'intestatario." +
                        "\n[2] per il numero conto." +
                        "\n[3] per modificare il saldo." +
                        "\n[4] per modificare il tipo di conto." +
                        "\n[5] per aggiornare la data della scadenza." +
                        "\n[0] per uscire.");

                    int choice;
                    do
                    {
                        Console.Write("Scegli: ");

                    }
                    while (!(int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice < 6));

                    switch (choice)

                    {
                        case 1:
                            //modifica intestatario
                            Console.Write("Nome e Cognome nuovo intestatario: ");
                            contoDaModificare.Intestatario = Console.ReadLine();
                            break;
                        case 2:
                            //modifica numero conto
                            
                            Console.Write("Numero conto aggiornato: ");
                            contoDaModificare.Intestatario = Console.ReadLine();
                            break;
                        case 3:
                            //modifica saldo
                            contoDaModificare.Saldo = InserisciSaldo();
                            break;
                        case 4:
                            //modifica tipo di conto
                            contoDaModificare.TipoDiConto = InserisciTipoDiConto();
                            break;
                        case 5:
                            //aggiornare data scadenza
                            contoDaModificare.DataScadenza = InserisciData();
                            break;
                        case 0:
                            exit = false;
                            break;

                    }
                }
                while (exit);
            }



        }

        public static void StampaConto()
        {
            StampaContiDiUnaLista(conti);
        }
        public static void StampaContiDiUnaLista(List<Conto> contos)
        {
            if (contos.Count==0)
            {
                Console.WriteLine("Non sono ancora presenti conti.");
            }
            else
            {
                foreach (var item in contos)
                {
                    Console.WriteLine($"INTESTATARIO: {item.Intestatario}" + $"\nNUMERO CONTO: {item.NumeroConto}" +
                        $"\nSALDO: {item.Saldo}" + $"\nTIPO DI CONTO: {item.TipoDiConto}" + $"\nSCADENZA: {item.DataScadenza.ToShortDateString()}");
                }
            }
        }

        public static void FiltraConto()
        {
            TipoConto tipo = InserisciTipoDiConto();
            List<Conto> contiFiltrati = new List<Conto>();
            foreach (var item in conti)
            {
                if (item.TipoDiConto== tipo)
                {
                    contiFiltrati.Add(item);
                }
            }
            StampaContiDiUnaLista(contiFiltrati);
        }
    }
}
