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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kino;

namespace GUI_Kino
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Harmonogram harmonogram;
        List<CheckBox> listChckBox;
        
        /// <summary>
        /// Tworzenie głównego okna aplikacji
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            txtOpisFilmu.Visibility = Visibility.Hidden;
            labelEkran.Visibility = Visibility.Hidden;
            txtSzczegoly.Visibility = Visibility.Hidden;
            labelSzczegoly.Visibility = Visibility.Hidden;
            labelInfo.Visibility = Visibility.Hidden;
            txtOpisFilmu.IsReadOnly = true;
            txtSzczegoly.IsReadOnly = true;
            harmonogram = (Harmonogram)Harmonogram.OdczytajXML("harmonogram.xml");
            if (harmonogram is object)
            {
                lstRepertuar.ItemsSource = new ObservableCollection<Seans>(harmonogram.SeansyWDanymDniu(DateTime.Now));
            }
            
        }
        /// <summary>
        /// Wybieranie daty 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime data = Convert.ToDateTime((sender as DatePicker).SelectedDate);
            lstRepertuar.ItemsSource = new ObservableCollection<Seans>(harmonogram.SeansyWDanymDniu(data));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstRepertuar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstRepertuar.SelectedIndex != -1)
            {
                InitializeSeatsGrid();
                InitializeOpisFilmuTextBox();
            }
        }
        public void InitializeSeatsGrid()
        {
            listChckBox = new List<CheckBox>();
            labelEkran.Visibility = Visibility.Visible;
            Seans seans = harmonogram._seanse.Find(x => x.nrSeansu == (lstRepertuar.SelectedItem as Seans).nrSeansu);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    CheckBox b = new CheckBox();
                    
                    b.Tag = $"{i + 1}{j + 1}";
                    listChckBox.Add(b);
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);
                    grid1.Children.Add(b);
                    if (seans._sala._miejsca.Exists(x => x._rzad == i + 1 & x._miejsce == j + 1 & x._wolne == false))
                        b.IsEnabled = false;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        private void InitializeOpisFilmuTextBox()
        {
            txtOpisFilmu.Visibility = Visibility.Visible;
            labelInfo.Visibility = Visibility.Visible;
            Seans seans = harmonogram._seanse.Find(x => x.nrSeansu == (lstRepertuar.SelectedItem as Seans).nrSeansu);
            txtOpisFilmu.Text = seans._film.ToString();
            txtSzczegoly.Text = string.Empty;       
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        private void Button_ZakupMiejsca(object sender, RoutedEventArgs e)
        {
            SprzedaneBilety sprzedaneBilety;
            sprzedaneBilety = new SprzedaneBilety();
            if (lstRepertuar.SelectedIndex != -1)
            {
                Seans seans = harmonogram._seanse.Find(x => x.nrSeansu == (lstRepertuar.SelectedItem as Seans).nrSeansu);
                foreach (CheckBox checkBox in listChckBox)
                {
                    int rzad = int.Parse((checkBox.Tag.ToString()).Substring(0, 1));
                    int miejsce = int.Parse((checkBox.Tag.ToString()).Substring(1, 1));
                    if (checkBox.IsChecked == true)
                    {
                        int index = seans._sala._miejsca.FindIndex(x => x._rzad == rzad & x._miejsce == miejsce);
                        sprzedaneBilety.DodajBilet(new Bilet(seans, seans._sala._miejsca[index]));
                        seans._sala.ZarezerwujMiejsce(rzad, miejsce);
                    }     
                }
                SprzedaneBilety.ZapiszXML("sprzedane.xml", sprzedaneBilety);
            }
            ZakupBiletuWindow zbWindow = new ZakupBiletuWindow();
            bool? result = zbWindow.ShowDialog();
            if (zbWindow.DialogResult == false)
                InitializeSeatsGrid();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Szczegoly_Click(object sender, RoutedEventArgs e)
        {
            labelSzczegoly.Visibility = Visibility.Visible;
            txtSzczegoly.Visibility = Visibility.Visible;
            if (lstRepertuar.SelectedIndex != -1)
            {
                Seans seans = harmonogram.SeansyWDanymDniu(datePicker.SelectedDate.Value.Date)[lstRepertuar.SelectedIndex];
                txtSzczegoly.Text = seans._film.PodajSzczegoly();
            }
        }
    }
}
