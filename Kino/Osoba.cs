using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kino
{
    /// <summary>
    /// Klasa abstarakcyjna tworząca Osobę 
    /// </summary>
    [Serializable]
    public abstract class Osoba : IEquatable<Osoba>
    {
        public enum płcie { K, M }
        public string _imię;
        public string _nazwisko;
        public string _email;
        public string _nr_tel;
        public płcie _płeć;
        /// <summary>
        /// Konstruktor Imienia sprawdzający poprawność zapisu
        /// </summary>
        /// <remarks>Sprawdza czy imię zawiera się z samych liter oraz zaczyna się z dużej
        /// litery w przeciwnym razie wyrzuca wyjątek z inforamcją o błędzie
        /// </remarks>
        public string Imię
        {
            get => _imię;
            set
            {
                Regex rx = new Regex("[A-Z]+");
                if (rx.IsMatch(value))
                {
                    _imię = value;
                }

                else
                    throw new BlednyZapisException("Imie powinno zaczynać się z dużej litery i składać się z samych liter");

            }
        }
        /// <summary>
        /// Konstruktor Nazwiska sprawdzający poprawność zapisu
        /// </summary>
        /// <remarks>Sprawdza czy nazwisko zawiera się z samych liter oraz zaczyna się z dużej
        /// litery w przeciwnym razie wyrzuca wyjątek z inforamcją o błędzie
        /// </remarks>
        public string Nazwisko
        {
            get => _nazwisko;
            set
            {
                Regex rx = new Regex("[A-Z]+");
                if (rx.IsMatch(value))
                    _nazwisko = value;
                else
                    throw new BlednyZapisException("Nazwisko powinno zaczynać się z dużej litery i składać się z samych liter");
            }
        }
        public string Email { get => _email; set => _email = value; }
        public płcie Płeć { get => this._płeć; set => this._płeć = value; }
        /// <summary>
        /// Konstruktor dla Telefonu sprawdzający poprawność zapisu
        /// </summary>
        /// <remarks>
        /// Sprawdzanie czy telefon składa się 9 cyfr w przeciwnym wypadku zostaje wyrzucony wyjątek z informacją
        /// o błędzie
        /// </remarks>
        public string Nr_tel
        {
            get => _nr_tel;
            set
            {
                Regex wzórntel = new Regex("^[0-9]{9}$");
                if (wzórntel.IsMatch(value))
                    _nr_tel = value;
                else
                    throw new BlednyNumerTelefonuException();
            }
        }
        public Osoba()
        {

        }
        public Osoba(string imię, string nazwisko, płcie płeć)
        {
            Imię = imię;
            Nazwisko = nazwisko;
            this._płeć = płeć;
        }
        protected Osoba(string imię, string nazwisko, string email, string nr_tel, płcie płeć) : this(imię,nazwisko,płeć)
        {
            this._email = email;
            Nr_tel = nr_tel;
            
        }
        /// <summary>
        /// Rozróżnianie osób po numerze telefonu
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Osoba other)
        {
            return this.Nr_tel.Equals(other.Nr_tel);
        }
        public override string ToString()
        {
            return $"{this.Imię} {Nazwisko} {_email} {Nr_tel}";
        }

    }
}
