using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    /// <summary>
    /// Klasa reprezentująca Seanse
    /// </summary>
    /// <remarks>
    /// W klasie tej tworzony jest seans na podstawie filmu oraz sali w której film jest grany seansowi przypisywane 
    /// jest także czas jego trwania
    /// </remarks>
    [Serializable]
    public class Seans : IComparable<Seans>, ICloneable, IEquatable<Seans>
    {
        public static int idSeansu = 0;
        public int nrSeansu;
        public DateTime _dokladnaDataRozpoczecia;
        public DateTime _dokladnaDataZakonczenia;
        public Film _film;
        public Sala _sala;
        public Seans() 
        {
            nrSeansu = idSeansu++;
        }

        public Seans (Film film,Sala sala, DateTime dokladnaDataRozpoczecia) :this()
        {
            _film = film;
            _sala = sala;
            _dokladnaDataRozpoczecia = dokladnaDataRozpoczecia;
            _dokladnaDataZakonczenia = dokladnaDataRozpoczecia + _film._czasTrwania + new TimeSpan(0, 15, 0) + new TimeSpan(0, 30, 0); //timespan to reklamy i sprzątanie
        }
        public override string ToString()
        {
            return $"Tytuł: {_film._tytul}  Start: {_dokladnaDataRozpoczecia.Hour}:{_dokladnaDataRozpoczecia.Minute.ToString("D2")} ";
        }
        /// <summary>
        /// Porównanie dwóch seansów na podstawie daty rozpoczęcia
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Seans other)
        {
            return _dokladnaDataRozpoczecia.CompareTo(other._dokladnaDataRozpoczecia);
        }

        /// <summary>
        /// Klonowanie Seansów 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone() as Seans;
        }
        /// <summary>
        /// Rozróżnianie seansów na podstawie ich daty rozpoczęcia
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Seans other)
        {
            return this._dokladnaDataRozpoczecia.Equals(other._dokladnaDataRozpoczecia);
        }
    }
}
