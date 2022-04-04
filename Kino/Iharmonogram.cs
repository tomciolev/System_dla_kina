using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    interface IHarmonogram
    {
        void Wyczysc();
        int PodajIlosc();
        void Usun(Seans seans);
        void Dodaj(Seans seans);

    }
}
