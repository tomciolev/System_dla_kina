using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    /// <summary>
    /// Klasa reprezentująca sale kinową
    /// </summary>
    [Serializable]
    public class Sala
    {
        //pola
        public static int _numerSali;
        public string _idSali;
        public List<Miejsce> _miejsca = new List<Miejsce>();
        //konstruktory
        static Sala()
        {
            _numerSali = 1;
        }
        public Sala()
        {
            _idSali = $"Sala{_numerSali++.ToString("D2")}";
            for (int i = 1; i <= 5; i++)
                for (int j = 1; j <= 6; j++)
                    _miejsca.Add(new Miejsce(i, j));
        }
        //metody
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_idSali).AppendLine();
            int i = 0;
            foreach (Miejsce miejsce in _miejsca)
            {
                sb.Append(miejsce.ToString());
                i++;
                if (i % 5 == 0)
                    sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// Zerezerwowanie wybranego miejsca na podstawie miejsca i rzędu
        /// </summary>
        /// <param name="rzad"></param>
        /// <param name="miejsce"></param>
        public void ZarezerwujMiejsce(int rzad, int miejsce)
        {
            int index = _miejsca.FindIndex(x => x._rzad == rzad & x._miejsce == miejsce);
            _miejsca[index]._wolne = false;
        }

        /// <summary>
        /// Obliczanie liczby wolnch miejsc w sali
        /// </summary>
        /// <returns></returns>
        public int LiczbaWolnychMiejsc()
        {
            return _miejsca.FindAll(x => x._wolne == true).Count();
        }
    }
}
