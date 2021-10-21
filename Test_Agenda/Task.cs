using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Agenda
{
    public class Task
    {
        /* I tasks sono oggetti che possiedono:
             • una descrizione
             • una data di scadenza
             • un livello di priorità(Alto, Medio, Basso)*/

        public string Descrizione { get; set; }
        public DateTime DataScadenza { get; set; }
        public Livello Priorità { get; set; }

        //Costruttore
        public Task()
        {

        }
    }

    public enum Livello
    {
        Basso=1,
        Medio=2,
        Alto=3,
    }
}
