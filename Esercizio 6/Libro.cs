using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_6
{
    /* Un libro è un entità che ha:
         * Codice
         * Titolo
         * Autore 
         * Genere
         * Prezzo
         * Data pubblicazione */

    public class Libro
    {
        //Eleneco proprietà dell'entità Libro
        //prop e doppio tab
        public string Codice { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public Genere Genere { get; set; }
        public double Prezzo { get; set; }
        public DateTime DataPubblicazione { get; set; }

        //Costruttore
        //ctor e doppio tab
        public Libro()
        {

        }
    }
    public enum Genere
    {
        Narrativa=1,
        Storico=2,
        Fantasy=3,
        Horror=4
    }
}
