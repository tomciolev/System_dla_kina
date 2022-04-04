using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kino
{
    public class Klienci 
    {
        public List<Klient> _klienci;
        int liczbaKlientow;
        public Klienci()
        {
            _klienci = new List<Klient>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Klient klient in _klienci)
            {
                sb.AppendLine(klient.ToString());
            }
            return sb.ToString();
        }
        public void Dodaj(Klient klient)
        {
            foreach(Klient k in _klienci)
            {
                if (k.Equals(klient))
                    throw new Exception("Klient juz jest w bazie");
            }
            _klienci.Add(klient);
        }
        public static void ZapiszXML(string nazwa, Klienci klienci)
        {
            var fs = new FileStream(nazwa, FileMode.Create);
            var xmls = new XmlSerializer(typeof(Klienci));
            xmls.Serialize(fs, klienci);
            fs.Close();
        }
        /// <summary>
        /// Odczytywanie harmonogramu zapisanego w pliku XML
        /// </summary>
        /// <param name="nazwa"></param>
        /// <returns></returns>
        public static Klienci OdczytajXML(string nazwa)
        {
            object wynik = null;
            var fs = new FileStream(nazwa, FileMode.Open);
            var xmls = new XmlSerializer(typeof(Klienci));
            wynik = xmls.Deserialize(fs);
            return wynik as Klienci;
        }
    }
}
