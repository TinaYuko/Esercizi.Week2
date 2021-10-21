using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Agenda
{
    public static class Menu
    {
        public static void Start()
        {
            /* L’utente può:
             1.Visualizzare i tasks;
             2.Aggiungere un nuovo task;
             3.Eliminare un task esistente;
             4.Filtrare i tasks per importanza(ovvero per livello di priorità);*/


            Console.WriteLine("Benvenuto nell'Agenda SCOMIX 2021/2022");
            AgendaManager.AggiungoTaskProva();
            AgendaManager.LeggoTask();
            bool exit = true;
            do
            {
                Console.WriteLine("\nPremi: \n[1] per visualizzare i tasks presenti!" +
                    "\n[2] per aggiungere tasks (nel caso ti stia annoiando)." +
                    "\n[3] per eliminare tasks (se sei troppo impegnat*)." +
                    "\n[4] per filtrare i tasks per importanza." +
                    "\n[0] per uscire!");
                
                int choice;
                do
                {
                    Console.WriteLine("Su, forza! Scegli!");
                }
                while (!(int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice < 5));

                switch (choice)
                {
                    case 1:
                        AgendaManager.VisualizzaTask();
                        break;
                    case 2:
                        AgendaManager.AggiungiTask();
                       
                        break;
                    case 3:
                        AgendaManager.EliminaTask();
                        break;
                    case 4:
                        AgendaManager.FiltraTask();
                        break;
                    case 0:
                        AgendaManager.SalvaTask();
                        Console.WriteLine("Tutto fatto? Bene, ciao!!!");
                        exit = false;
                        break;
                }
            }
            while (exit);
        }
    }
}
