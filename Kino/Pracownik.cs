using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kino
{
    /// <summary>
    /// Klasa reprezentująca Pracownika kina
    /// </summary>
    class Pracownik : Osoba
    {
        DateTime _data_rozpoczęcia_pracy;
        double _stawka;
        string _funkcja;
        string _pesel;
        public DateTime Data_rozpoczęcia_pracy1 { get => _data_rozpoczęcia_pracy; set => _data_rozpoczęcia_pracy = value; }
        public double Stawka1 { get => _stawka; set => _stawka = value; }
        public string Funkcja1 { get => _funkcja; set => _funkcja = value; }
        public string Pesel
        {
            get => _pesel;
            set
            {
                Regex wzórpesel = new Regex("^[0-11]{9}$");
                if (wzórpesel.IsMatch(value))
                    Pesel = value;
                else
                    throw new BlednyPeselException("PESEL powienie zawierać 11 liczb");
            }
        }
        public Pracownik(string imię, string nazwisko, string email, string nr_tel, płcie płeć, string pesel) : base(imię, nazwisko, email, nr_tel, płeć)
        {
            _pesel = pesel;
        }

        /// <summary>
        /// Obliczanie wynagrodzenia pracownika na podstawie stawki oraz liczby godzin i nadgodzin
        /// </summary>
        /// <param name="liczba_godzin"></param>
        /// <param name="nadgodziny"></param>
        /// <returns></returns>
        public double Wynagrodzenie(int liczba_godzin, int nadgodziny)
        {
            return this._stawka * liczba_godzin + this._stawka * nadgodziny * 1.5;
        }

        public int Doświadczenie()
        {
            return (DateTime.Now.Year - _data_rozpoczęcia_pracy.Year);
        }
       
    }
}
