using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public enum Gatunki { Sensacyjny, Dramat, Komedia, Romantyczny, Fantasy }
    public enum Typy { Dubbing, Napisy, Lektor}
    public enum KategorieWiekowe { P0, P12, P15, P18} // P - powyżej (P18 - powyżej 18 lat)
    /// <summary>
    /// Klasa reprezentuje film
    /// </summary>
    /// <remarks>
    /// klasa film zawiera pola zawierające specyfikacje filmu
    /// </remarks>
    [Serializable]
    public class Film
    {
        //pola
        public string _tytul;
        public string _reżyser;
        public Gatunki _gatunek;
        public Typy _typ;
        public TimeSpan _czasTrwania;
        public double _czasTrwaniaMinuty;
        public string _krajProdukcji;
        public string _rokProdukcji;
        public KategorieWiekowe _kategoriaWiekowa;
        public string _opis;
        //konstruktory
        public Film() { }
        public Film(string tytul, string rezyser)
        {
            _tytul = tytul;
            _reżyser = rezyser;
        }
        public Film(string tytul, string rezyser, Gatunki gatunek, Typy typ, TimeSpan czasTrwania) :
            this(tytul, rezyser)
        {
            _gatunek = gatunek;
            _typ = typ;
            _czasTrwania = czasTrwania;
            _czasTrwaniaMinuty = czasTrwania.TotalMinutes;
        }
        public Film(string tytul, string rezyser, Gatunki gatunek, Typy typ, TimeSpan czasTrwania, string krajProdukcji, string rokProdukcji, string opis, KategorieWiekowe kategoriaWiekowa) :
            this(tytul, rezyser, gatunek, typ, czasTrwania)
        {
            _krajProdukcji = krajProdukcji;
            _rokProdukcji = rokProdukcji;
            _opis = opis;
            _kategoriaWiekowa = kategoriaWiekowa;
        }
        //metody
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Tytuł: ").AppendLine(_tytul);
            sb.Append("Reżyser: ").AppendLine(_reżyser);
            sb.Append("Gatunek: ").AppendLine(_gatunek.ToString());
            sb.Append("Typ: ").AppendLine(_typ.ToString());
            sb.Append("Czas trwania:  ").AppendLine(_czasTrwaniaMinuty.ToString() + " min");
            return sb.ToString();
        }

        /// <summary>
        /// Wykazanie dokładanych szczegółów dotyczących wybranego filmu
        /// </summary>
        /// <returns></returns>
        public string PodajSzczegoly()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Kraj produkcji: ").AppendLine(_krajProdukcji);
            sb.Append("Rok produkcji: ").AppendLine(_rokProdukcji);
            sb.Append("Kategoria wiekowa: ").AppendLine(_kategoriaWiekowa.ToString());
            sb.Append("Opis filmu: ").AppendLine(_opis);
            return sb.ToString();
        }
    }
}
