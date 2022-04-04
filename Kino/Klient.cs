using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    /// <summary>
    /// Klasa reprezentuje klineta
    /// </summary>
    /// <remarks>
    /// Klasa zawiera pola do których przypiywane najważniejsze informacje na temat klienta 
    /// </remarks>
    [Serializable]
    public class Klient : Osoba
    {
        public int _iloscZakupionychBiletow;
        public Klient() { }
        public Klient(string imię, string nazwisko, string email, string nr_tel, płcie płeć) : base(imię, nazwisko, email, nr_tel, płeć)
        {
            _iloscZakupionychBiletow = 0;
        }
        public override string ToString()
        {
            return $"{base.ToString()} Dotychczasowa ilosc zakupionych biletow: {_iloscZakupionychBiletow}"; 
        }
    }
}
