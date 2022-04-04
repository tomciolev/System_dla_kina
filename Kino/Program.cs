using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kino
{
    class Program
    {
        static void Main(string[] args)
        {
            //sale
            Sala sala01 = new Sala();
            Sala sala02 = new Sala();
            Sala sala03 = new Sala();
            //filmy
            Film film1= new Film("WSZYSTKIE NASZE STRACHY", "Łukasz Ronduda", Gatunki.Sensacyjny, Typy.Napisy, new TimeSpan(2,12,0), "Polska", "2021", "Daniel (Dawid Ogrodnik) jest artystą, katolikiem i aktywistą", KategorieWiekowe.P15);
            Film film2 = new Film("SING 2", "Garth Jennings", Gatunki.Fantasy, Typy.Dubbing, new TimeSpan(1, 32, 0), "Anglia", "2011", "Miś koala - Buster Moon i gwiazdorska obsada jego teatru pragną wystąpić na olśniewającej, wspaniałej i ekstrawaganckiej scenie", KategorieWiekowe.P0);
            Film film3 = new Film("GIEREK", "Michał Węgrzyn", Gatunki.Komedia, Typy.Dubbing, new TimeSpan(1, 02, 0), "Polska", "2021", "Sekrety i tajemnice domu I sekretarza KC PZPR.", KategorieWiekowe.P18);
            Film film4 = new Film("355", "Simon Kinberg", Gatunki.Romantyczny, Typy.Napisy, new TimeSpan(1, 30, 0), "USA", "2020", "Największe agencje wywiadowcze z różnych stron świata wpadają na trop międzynarodowej organizacji przestępczej", KategorieWiekowe.P18);
            //senase
            Seans seans = new Seans(film1, sala01, DateTime.Now.Date + new TimeSpan(10, 00, 00));
            Seans seans2 = new Seans(film2, sala02, DateTime.Now.Date + new TimeSpan(9, 00, 00));
            Seans seans3 = new Seans(film2, sala02, DateTime.Now.Date.AddDays(1) + new TimeSpan(14, 00, 00));
            Seans seans4 = new Seans(film2, sala02, DateTime.Now.Date + new TimeSpan(13, 00, 00));
            Seans seans5 = new Seans(film3, sala01, DateTime.Now.Date.AddDays(2) + new TimeSpan(18, 00, 00));
            Seans seans6 = new Seans(film3, sala02, DateTime.Now.Date.AddDays(3) + new TimeSpan(18, 00, 00));
            Seans seans7 = new Seans(film3, sala02, DateTime.Now.Date.AddDays(2) + new TimeSpan(22, 00, 00));
            Seans seans8 = new Seans(film1, sala03, DateTime.Now.Date.AddDays(1) + new TimeSpan(18, 00, 00));
            Seans seans9 = new Seans(film4, sala03, DateTime.Now.Date.AddDays(2) + new TimeSpan(15, 00, 00));
            Seans seans10 = new Seans(film4, sala03, DateTime.Now.Date.AddDays(1) + new TimeSpan(10, 00, 00));
            Harmonogram Ogolny = new Harmonogram();
            Ogolny.Dodaj(seans);
            Ogolny.Dodaj(seans2);
            Ogolny.Dodaj(seans3);
            Ogolny.Dodaj(seans4);
            Ogolny.Dodaj(seans5);
            Ogolny.Dodaj(seans6);
            Ogolny.Dodaj(seans7);
            Ogolny.Dodaj(seans8);
            Ogolny.Dodaj(seans9);
            Ogolny.Dodaj(seans10);
            Harmonogram.ZapiszXML(@"C:\Users\tomec\Desktop\Kinopop\GUI_Kino\bin\Debug\harmonogram.xml", Ogolny);
            Klienci klienci = new Klienci();
            Klienci.ZapiszXML(@"C:\Users\tomec\Desktop\Kinopop\GUI_Kino\bin\Debug\klienci.xml", klienci);
            Console.ReadLine();

        }
    }
}
