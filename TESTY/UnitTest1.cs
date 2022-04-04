using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Kino;
namespace TESTY
{
    [TestClass]
    public class UnitTest1
    { 

        [TestMethod]
        [ExpectedException(typeof(BlednyZapisException))]
        public void TestMethod2()
        {
            Klient klient = new Klient("tomek", "Kowalski", "tomek@gmail.com", "753525298", Osoba.płcie.K);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Seans seans = new Seans(new Film("Sczęki", "Nowak", Gatunki.Sensacyjny, Typy.Napisy, new TimeSpan(2, 12, 0), "Polska", "2011", "Opisfilmu", KategorieWiekowe.P18), new Sala(), new DateTime (2022, 01, 21, 9, 00, 00));
            Assert.AreEqual(seans._dokladnaDataZakonczenia, seans._dokladnaDataRozpoczecia + seans._film._czasTrwania + new TimeSpan(0, 15, 0) + new TimeSpan(0, 30, 0));
        }
        [TestMethod]
        [ExpectedException(typeof(BlednyNumerTelefonuException))]
        public void TestMethod4()
        {
            Klient klient = new Klient("Tomek", "Kowalski", "tomek@gmail.com", "753525a298", Osoba.płcie.K);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Harmonogram harmonogram = new Harmonogram();
            Seans seans = new Seans(new Film("Sczęki", "Nowak", Gatunki.Sensacyjny, Typy.Napisy, new TimeSpan(2, 12, 0), "Polska", "2011", "Opisfilmu", KategorieWiekowe.P18), new Sala(), new DateTime(2022, 01, 21, 9, 00, 00));
            harmonogram.Dodaj(seans);
            Assert.AreEqual(harmonogram._iloscSeansow, 1);
        }

    }
}
