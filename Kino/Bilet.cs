using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    [Serializable]
    public class Bilet
    {
        public enum Rodzaj { Ulgowy, Normalny, Senior };
        public Seans _seans;
        public Miejsce _miejsce;
        public Bilet() { }
        public Bilet(Seans seans, Miejsce miejsce)
        {
            _seans = seans;
            _miejsce = miejsce;
        }
        public override string ToString()
        {
            return $"Rząd: {_miejsce._rzad} Miejsce: {_miejsce._miejsce}";
        }
    }
}
