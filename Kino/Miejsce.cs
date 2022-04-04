using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    /// <summary>
    /// Klasa reprezetująca miejsca
    /// </summary>
    public class Miejsce
    {
        //pola
        public int _rzad;
        public int _miejsce;
        public bool _wolne;
        //konstruktory
        public Miejsce() { }
        public Miejsce(int rzad, int miejsce)
        {
            _rzad = rzad;
            _miejsce = miejsce;
            _wolne = true;
        }
        public override string ToString()
        {
            return $"Rząd: {_rzad} Miejsce: {_miejsce} Status: {(_wolne == true ? "Wolne" : "Zajete")}"; 
        }

    }
}
