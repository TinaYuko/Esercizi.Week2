using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_7
{
    /*I conti hanno:
             * Intestatario
             * Tipo di Conto -> se è un conto corrente semplice, conto corrente con carta di credito/debito, ecc
             * Saldo
             * Numero conto
             * Data scadenza */
    public class Conto
    {
        //Elenco proprietà conto
        public string Intestatario { get; set; }
        public string NumeroConto { get; set; }

        public double Saldo { get; set; }
        public TipoConto TipoDiConto { get; set; }
        public DateTime DataScadenza { get; set; }

        //Costruttore
        public Conto()
        {

        }
    }

    public enum TipoConto
    {
        ContoCorrente=1,
        ContoCorrenteDebito=2,
        ContoCorrenteCredito=3,
        ContoCorrenteRicaricabile=4

    }
}
