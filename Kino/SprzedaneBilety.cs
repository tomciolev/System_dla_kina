using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kino
{
    /// <summary>
    /// Klasa reprezentująca Sprzedane bilety
    /// </summary>
    ///<remarks>
    ///Klasa stworzona w celu kontrolowania i zbierania informacji o sprzedaży biletów w kinie
    ///</remarks> 
    [Serializable]
    public class SprzedaneBilety
    {
        int _liczbaSprzedanychBiletow = 0;
        static int id_Sprzedazy;
        int numerSprzedazy;
        public List<Bilet> _sprzedaneBilety;
        static SprzedaneBilety()
        {
            id_Sprzedazy = 0;
        }
        
        public SprzedaneBilety()
        {
            _sprzedaneBilety = new List<Bilet>();
            numerSprzedazy = id_Sprzedazy++;
        }
        /// <summary>
        /// Dodawanie nowego biletu do listy sprzedanych biletu
        /// </summary>
        /// <param name="bilet"></param>
        public void DodajBilet(Bilet bilet) 
        {
            _sprzedaneBilety.Add(bilet);
            _liczbaSprzedanychBiletow++;
        }
        /// <summary>
        /// zapisyawnie sprzedanych biletów do pliku XML
        /// </summary>
        /// <param name="nazwa"></param>
        /// <param name="sprzedaneBilety"></param>
        public static void ZapiszXML(string nazwa, SprzedaneBilety sprzedaneBilety)
        {
            var fs1 = new FileStream(nazwa, FileMode.Create);
            var xmls1 = new XmlSerializer(typeof(SprzedaneBilety));
            xmls1.Serialize(fs1, sprzedaneBilety);
            fs1.Close();
        }
        public static SprzedaneBilety OdczytajXML(string nazwa)
        {
            object wynik = null;
            var fs1 = new FileStream(nazwa, FileMode.Open);
            var xmls1 = new XmlSerializer(typeof(SprzedaneBilety));
            wynik = xmls1.Deserialize(fs1);
            fs1.Close();
            return wynik as SprzedaneBilety;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Bilet bilet in _sprzedaneBilety)
                sb.AppendLine(bilet.ToString());
            return sb.ToString();
        }
        /*public List<Bilet> biletyNaDanySeans(Seans seans)
        {
            return _sprzedaneBilety.FindAll(x => x._seans.Equals(seans));
        }
        public string WypiszBiletyNaDanySeans(Seans seans)
        {
            List<Bilet> lista = biletyNaDanySeans(seans);
            StringBuilder sb = new StringBuilder();
            foreach (Bilet bilet in _sprzedaneBilety)
                sb.AppendLine(bilet.ToString());
            return sb.ToString();
        }*/

        /// <summary>
        /// Pobiera ostatnio dodany seans
        /// </summary>
        /// <returns></returns>
        public Seans OstatnioDodany()
        {
            Bilet bilet =_sprzedaneBilety.First();
            return bilet._seans as Seans;
        }
        public int LiczbaBiletow()
        {
            return _sprzedaneBilety.Count();
        }
    }
}
