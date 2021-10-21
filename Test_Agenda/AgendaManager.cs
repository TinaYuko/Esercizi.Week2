using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Agenda
{
    public static class AgendaManager
    {
        public static List<Task> tasks = new List<Task>();

        //Creo un task di prova per vedere subito se la stampa mi funziona eheh
        public static void AggiungoTaskProva()
        {
            Task taskProva = new Task()
            {
                Descrizione = "fare la spesa",
                DataScadenza = new DateTime(2021, 10, 16, 10, 30, 00),
                Priorità = (Livello)2
            };
            tasks.Add(taskProva);
        }


        //Metodi nel caso l'utente prema tasto 1
        public static void VisualizzaTask()
        {
            VisualizzaTaskDiUnaLista(tasks);
        }

        public static void VisualizzaTaskDiUnaLista(List<Task> listaTask)
        {
            if (listaTask.Count==0)
            {
                Console.WriteLine("Non sono presenti task in Agenda, che fortunat*!");
            }
            else
            {
                foreach (var item in listaTask)
                {
                    Console.WriteLine($"\n\nDESCRIZIONE: {item.Descrizione}" + $"\nSCADENZA: {item.DataScadenza}" +
                     $"\nPRIORITA': {item.Priorità}");
                }
            }
        }

        //Metodi nel caso l'utente prema tasto 2
        public static void AggiungiTask()
        {
            Task task = new Task();
           
            Console.Write("Inserisci descrizione del task: ");
            task.Descrizione = Console.ReadLine();
            //Controllo sulla descrizione   
            ControlloDescrizioneTask(task.Descrizione);
            task.DataScadenza = InserisciDataScadenza();
            task.Priorità = InserisciPriorità();

            tasks.Add(task);
            Console.WriteLine("Hai un nuovo impegno!");
        }

        private static void ControlloDescrizioneTask(string descrizione)
        {
           
            foreach (var item in tasks)
            {
                bool exit = true;
                if (item.Descrizione == descrizione)
                {
                    Console.Write("Descrizione già presente! Mettine una nuova: ");
                    item.Descrizione = Console.ReadLine();
                }
                else
                {
                    exit = false;
                }
            }
        }

        private static Livello InserisciPriorità()
        {
            Console.WriteLine("Inserisci il livello di priorità: ");
            Console.WriteLine($"Premi [{(int)Livello.Basso}] per inserire un livello di priorità {Livello.Basso}");
            Console.WriteLine($"Premi [{(int)Livello.Medio}] per inserire un livello di priorità {Livello.Medio}");
            Console.WriteLine($"Premi [{(int)Livello.Alto}] per inserire un livello di priorità {Livello.Alto}");
            int livello;
            do
            {
                Console.Write("Quale scegli? ");
            }
            while (!(int.TryParse(Console.ReadLine(), out livello) && livello > 0 && livello < 4));
            return (Livello)livello;
        }

        private static DateTime InserisciDataScadenza()
        {
            DateTime data;
            do
            {
                Console.Write("Inserisci data di scadenza: ");

            }
            while (!(DateTime.TryParse(Console.ReadLine(), out data) && data > DateTime.Now));
            return data;
        }

        //Metodi nel caso l'utente prema tasto 3
        public static void EliminaTask()
        {
            Console.WriteLine("I tasks presenti sono: ");
            VisualizzaTask();
            Console.Write("Scrivi la descrizione del task da eliminare: ");
            string descrizioneToCheck = Console.ReadLine();
            Task taskTrovato=CercaTask(descrizioneToCheck);
            if (taskTrovato==null)
            {
                Console.WriteLine("Non esiste nessun task con questa descrizione!!");
            }
            else
            {
                tasks.Remove(taskTrovato);
                Console.WriteLine("Il task è stato eliminato con successo!");
            }


        }

        private static Task CercaTask(string descrizione)
        {
            foreach (var item in tasks)
            {
                if (item.Descrizione==descrizione)
                {
                    return item;
                }

            }
            return null;
        }

        //Metodi nel caso l'utente prema tasto 4
        public static void FiltraTask()
        {
            Livello p = InserisciPriorità();
            List<Task> taskFiltrati = new List<Task>();
            foreach (var item in tasks)
            {
                if (item.Priorità==p)
                {
                    taskFiltrati.Add(item);
                }
            }
            VisualizzaTaskDiUnaLista(taskFiltrati);
        }

        //Salvataggio su file
        public static void SalvaTask()
        {
            string path = @"C:\Users\Marti\Desktop\Pink Academy\Week2\Test_Agenda\FileTask.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var item in tasks)
                {
                    sw.WriteLine($"\n{item.Descrizione}" + $"\n{item.DataScadenza}" +
                     $"\n{item.Priorità}");
                }

            }
        }

        //Lettura da file
        public static void LeggoTask()
        {
            string path = @"C:\Users\Marti\Desktop\Pink Academy\Week2\Test_Agenda\FileTask.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                if (File.Exists(path))
                {
                    string contenutoFile = sr.ReadToEnd();
                    var arrayDiRighe = contenutoFile.Split("\r\n");
                    
                        /*foreach (var item in arrayDiRighe)
                        {
                            if (item = ?)
                            {
                                //Il mio intento era quello di scorrere l'array e aggiungere gli oggetti 
                                //dello stesso tipo nell'allocazione corretta...
                                //Eheh ma non mi è riuscito l'intento!
                            }
                        }*/
                 
                }

            }
          
        }
    }
}
