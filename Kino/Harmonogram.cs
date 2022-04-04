using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Kino
{
    public class SalaComparator : Comparer<Seans>
    {
        public override int Compare(Seans x, Seans y)
        {
            return x._sala._idSali.CompareTo(y._sala._idSali);
        }
    }
    /// <summary>
    /// Klasa reprezentująca Harmonogram seansów
    /// </summary>
    [Serializable]
    public class Harmonogram: IHarmonogram
    {
        public int _iloscSeansow = 0;
        public List<Seans> _seanse;
        public Harmonogram()
        {
            _seanse = new List<Seans>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Seans s in _seanse)
            {
                sb.AppendLine(s.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Sortowanie seansów po według ich rozpoczęcia
        /// </summary>
        public void SortujPoDacieRozpoczecia()
        {
            _seanse.Sort();
        }
        /// <summary>
        /// Posrtowanie filmów po sali
        /// </summary>
        public void SortujPoSali()
        {
            _seanse.Sort(new SalaComparator());
        }
        /// <summary>
        /// Usuwa wszystkie seanse z danego harmonogramu
        /// </summary>
        public void Wyczysc()
        {
           _seanse.Clear();
        }
        /// <summary>
        /// Oblicza Ilosć seansów w danym harmonogramie
        /// </summary>
        /// <returns></returns>
        public int PodajIlosc()
        {
           return  _seanse.Count();
        }
        /// <summary>
        /// Usuwanie wybranego seansu Seansu z harmonogramu
        /// </summary>
        /// <param name="seans"></param>
        public void Usun(Seans seans)
        {
            _seanse.Remove(seans);
        }
        /// <summary>
        /// Dodawanie seansu do harmonograu
        /// </summary>
        /// <param name="seans"></param>
        /// <reamrks>
        /// Podczas dodawanie seansu sprawdza liste z seansami aby zapobiec dodania seansu podczas trwania już innnego
        /// seansu
        /// </reamrks>>
        public void Dodaj(Seans seans)
        {
            foreach (Seans s in _seanse)
            {
                if (s._sala._idSali == seans._sala._idSali)
                {
                    if ((s._dokladnaDataRozpoczecia <= seans._dokladnaDataRozpoczecia & s._dokladnaDataZakonczenia >= seans._dokladnaDataRozpoczecia) ||
                        (s._dokladnaDataRozpoczecia <= seans._dokladnaDataZakonczenia & s._dokladnaDataZakonczenia >= seans._dokladnaDataZakonczenia)
                        || (seans._dokladnaDataRozpoczecia <= s._dokladnaDataRozpoczecia & seans._dokladnaDataZakonczenia >= s._dokladnaDataZakonczenia))
                    {
                        Console.WriteLine("Podany termin jest niedostępny. Spójrz na harmonogram");
                        this.SortujPoDacieRozpoczecia();
                        Console.WriteLine(this);
                        throw new WSaliTrwaAktulanieInnySeansException();
                        
                    }
                }
            }
            _seanse.Add(seans);
            _iloscSeansow++;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<Seans> SeansyWDanymDniu(DateTime data)
        {
            return _seanse.FindAll(x => x._dokladnaDataRozpoczecia.ToShortDateString().Equals(data.ToShortDateString()));
        }
        /// <summary>
        /// Wypisywanie seansów w wybraniu dniu zastosowane do wyświetlania ich w GUI
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string WypiszSeansyWDanymDniu(DateTime data)
        {
            List<Seans> lista =  SeansyWDanymDniu(data);
            StringBuilder sb = new StringBuilder();
            foreach(Seans seans in lista)
                sb.AppendLine(seans.ToString());
            return sb.ToString();

        }
        /// <summary>
        /// Zapisywanie harmonogramu do pliku XML
        /// </summary>
        /// <param name="nazwa"></param>
        /// <param name="harmonogram"></param>
        public static void ZapiszXML(string nazwa, Harmonogram harmonogram)
        {
            var fs = new FileStream(nazwa, FileMode.Create);
            var xmls = new XmlSerializer(typeof(Harmonogram));
            xmls.Serialize(fs, harmonogram);
            fs.Close();
        }
        /// <summary>
        /// Odczytywanie harmonogramu zapisanego w pliku XML
        /// </summary>
        /// <param name="nazwa"></param>
        /// <returns></returns>
        public static Harmonogram OdczytajXML(string nazwa)
        {
            object wynik = null;
            var fs = new FileStream(nazwa, FileMode.Open);
            var xmls = new XmlSerializer(typeof(Harmonogram));
            wynik = xmls.Deserialize(fs);
            return wynik as Harmonogram;
        }
        
    }
}
