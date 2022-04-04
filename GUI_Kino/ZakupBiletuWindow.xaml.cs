using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Kino;

namespace GUI_Kino
{
    /// <summary>
    /// Logika interakcji dla klasy ZakupBiletuWindow.xaml
    /// </summary>
    public partial class ZakupBiletuWindow : Window
    {
        SprzedaneBilety sprzedaneBilety;
        Klienci klienci = (Klienci)Klienci.OdczytajXML("klienci.xml");

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public ZakupBiletuWindow()
        {
            InitializeComponent();
            
            sprzedaneBilety = (SprzedaneBilety)SprzedaneBilety.OdczytajXML("sprzedane.xml");
            InitializePodusmowanie();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        private void InitializePodusmowanie()
        {
            Seans seans = sprzedaneBilety.OstatnioDodany();
            //txtInfoSprzed.Text = sprzedaneBilety.WypiszBiletyNaDanySeans(seans);
            txtInfoSprzed.Text = sprzedaneBilety.ToString();
            SprzedaneBilety.ZapiszXML(@"sprzedane.xml", sprzedaneBilety);
            //sprzedaneBilety._sprzedaneBilety.Clear();
            txtFilm.Text = seans._film._tytul;
            txtGodzina.Text = seans._dokladnaDataRozpoczecia.ToString();
            txtSala.Text = seans._sala._idSali;
            txtLiczbaBiletow.Text = sprzedaneBilety._sprzedaneBilety.Count().ToString();
            txtDoZaplaty.Text = (sprzedaneBilety._sprzedaneBilety.Count() * 20).ToString("C2");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(klienci._klienci.Exists(x => x.Nr_tel == txtnrtelefonu.Text))
            {
                Klient klient = klienci._klienci.Find(x => x.Nr_tel == txtnrtelefonu.Text);
                klient._iloscZakupionychBiletow = klient._iloscZakupionychBiletow + int.Parse(txtLiczbaBiletow.Text);
            }
            else
            {
                klienci.Dodaj(new Klient(txtImie.Text, txtNazwisko.Text, txtemail.Text, txtnrtelefonu.Text, (Osoba.płcie)cmbPlec.SelectedIndex));
            }
            Klienci.ZapiszXML("klienci.xml", klienci);
            MessageBox.Show("Pomyślnie zarezerwowano bilety");
            DialogResult = false;
        }
    }
}
