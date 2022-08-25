using Biiblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Input;

namespace ProjektWPF
{


    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<plan_lekcji_bib> plan = new List<plan_lekcji_bib>();
        List<zadania_domowe_bib> zadania = new List<zadania_domowe_bib>();
        List<sprawdziany_bib> sprawdziany = new List<sprawdziany_bib>();
        public MainWindow()
        {
            InitializeComponent();

            LoadPlan();

            LoadZadania();

            LoadSprawdziany();

            InitComboBoxDzien();

            InitComboBoxGodzina();
        }

        private void LoadPlan()
        {
            plan = SQLiteDataAccess.LoadPlan();
            WireUpPlan();
        }

        private void LoadZadania()
        {
            zadania = SQLiteDataAccess.LoadZadania();
            WireUpZadania();
        }

        private void LoadSprawdziany()
        {
            sprawdziany = SQLiteDataAccess.LoadSprawdziany();
            WireUpSprawdziany();
        }

        private void WireUpPlan()
        {
            var labele = plan_grid.Children;

            foreach (var label in labele)
            {
                if (label is Label currentlabel && currentlabel.Name.StartsWith("plan_") && currentlabel.Content != null)
                    currentlabel.Content = "";
            }

            foreach (var label in labele)
            {
                if (label is Label currentlabel && currentlabel.Name.StartsWith("plan_"))
                {
                    var splitname = currentlabel.Name.Split('_');

                    var neededname = plan.FirstOrDefault(zajecie => zajecie.dzien == splitname[1] && zajecie.godzina.ToString() == splitname[2]);

                    if (neededname == null)
                        continue;

                    currentlabel.Content = neededname.nazwa;
                }
            }
        }
        private void WireUpZadania()
        {
            var labele = zadania_grid.Children;

            foreach (var label in labele)
            {
                if (label is Label currentlabel && currentlabel.Name.StartsWith("zadanie_") && currentlabel.Content != null)
                    currentlabel.Content = "";
            }

            foreach (var label in labele)
            {
                if (label is Label currentlabel && currentlabel.Name.StartsWith("zadanie_"))
                {
                    var splitname = currentlabel.Name.Split('_');

                    var neededname = zadania.FirstOrDefault(zajecie => zajecie.dzien == splitname[1] && zajecie.godzina.ToString() == splitname[2]);

                    if (neededname == null)
                        continue;

                    currentlabel.Content = neededname.nazwa;
                }
            }
        }
        private void WireUpSprawdziany()
        {
            var labele = spr_grid.Children;

            foreach (var label in labele)
            {
                if (label is Label currentlabel && currentlabel.Name.StartsWith("spr_") && currentlabel.Content != null)
                    currentlabel.Content = "";
            }

            foreach (var label in labele)
            {
                if (label is Label currentlabel && currentlabel.Name.StartsWith("spr_"))
                {
                    var splitname = currentlabel.Name.Split('_');

                    var neededname = sprawdziany.FirstOrDefault(zajecie => zajecie.dzien == splitname[1] && zajecie.godzina.ToString() == splitname[2]);

                    if (neededname == null)
                        continue;

                    currentlabel.Content = neededname.nazwa;
                }
            }
        }

        private void InitComboBoxDzien()
        {
            InitComboBoxDzienWartosci(dodaj_dzien_przedmiot);
            InitComboBoxDzienWartosci(edytuj_dzien_przedmiot);
            InitComboBoxDzienWartosci(nowa_edytuj_dzien_przedmiot);
            InitComboBoxDzienWartosci(usun_dzien_przedmiot);
            InitComboBoxDzienWartosci(dodaj_dzien_zadanie);
            InitComboBoxDzienWartosci(edytuj_dzien_zadanie);
            InitComboBoxDzienWartosci(nowa_edytuj_dzien_zadanie);
            InitComboBoxDzienWartosci(usun_dzien_zadanie);
            InitComboBoxDzienWartosci(dodaj_dzien_sprawdzian);
            InitComboBoxDzienWartosci(edytuj_dzien_sprawdzian);
            InitComboBoxDzienWartosci(nowa_edytuj_dzien_sprawdzian);
            InitComboBoxDzienWartosci(usun_dzien_sprawdzian);
        }

        private void InitComboBoxDzienWartosci(ComboBox comboBox)
        {
            comboBox.Items.Add(new ComboBoxItem() { Content = "Poniedziałek", Uid = "0" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "Wtorek", Uid = "1" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "Środa", Uid = "2" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "Czwartek", Uid = "3" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "Piątek", Uid = "4" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "Sobota", Uid = "5" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "Niedziela", Uid = "6" });
        }

        private string MapowanieDzien(string uid)
        {
            if (uid == "0")
                return "pn";
            else if (uid == "1")
                return "wt";
            else if (uid == "2")
                return "sr";
            else if (uid == "3")
                return "cz";
            else if (uid == "4")
                return "pt";
            else if (uid == "5")
                return "sb";
            else if (uid == "6")
                return "nd";

            return "coś jest nie tak";
        }

        private void InitComboBoxGodzina()
        {
            InitComboBoxGodzinaWartosci(dodaj_godzina_przedmiot);
            InitComboBoxGodzinaWartosci(edytuj_godzina_przedmiot);
            InitComboBoxGodzinaWartosci(nowa_edytuj_godzina_przedmiot);
            InitComboBoxGodzinaWartosci(usun_godzina_przedmiot);
            InitComboBoxGodzinaWartosci(dodaj_godzina_zadanie);
            InitComboBoxGodzinaWartosci(edytuj_godzina_zadanie);
            InitComboBoxGodzinaWartosci(nowa_edytuj_godzina_zadanie);
            InitComboBoxGodzinaWartosci(usun_godzina_zadanie);
            InitComboBoxGodzinaWartosci(dodaj_godzina_sprawdzian);
            InitComboBoxGodzinaWartosci(edytuj_godzina_sprawdzian);
            InitComboBoxGodzinaWartosci(nowa_edytuj_godzina_sprawdzian);
            InitComboBoxGodzinaWartosci(usun_godzina_sprawdzian);
        }

        private void InitComboBoxGodzinaWartosci(ComboBox comboBox)
        {
            comboBox.Items.Add(new ComboBoxItem() { Content = "8:00", Uid = "0" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "9:00", Uid = "1" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "10:00", Uid = "2" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "11:00", Uid = "3" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "12:00", Uid = "4" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "13:00", Uid = "5" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "14:00", Uid = "6" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "15:00", Uid = "7" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "16:00", Uid = "8" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "17:00", Uid = "9" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "18:00", Uid = "10" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "19:00", Uid = "11" });
        }

        private string MapowanieGodzina(string uid)
        {
            if (uid == "0")
                return "8";
            else if (uid == "1")
                return "9";
            else if (uid == "2")
                return "10";
            else if (uid == "3")
                return "11";
            else if (uid == "4")
                return "12";
            else if (uid == "5")
                return "13";
            else if (uid == "6")
                return "14";
            else if (uid == "7")
                return "15";
            else if (uid == "8")
                return "16";
            else if (uid == "9")
                return "17";
            else if (uid == "10")
                return "18";
            else if (uid == "11")
                return "19";

            return "coś jest nie tak";
        }

        //Dodawanie, edytowanie i usuwanie z bazy danych

        private void dodaj_przedmiot_Click(object sender, RoutedEventArgs e)
        {
            plan_lekcji_bib p = new plan_lekcji_bib();

            p.nazwa = dodaj_nazwa_przedmiot.Text;
            p.dzien = MapowanieDzien((dodaj_dzien_przedmiot.SelectedItem as ComboBoxItem).Uid);
            p.godzina = MapowanieGodzina((dodaj_godzina_przedmiot.SelectedItem as ComboBoxItem).Uid);

            SQLiteDataAccess.SavePlan(p);

            dodaj_nazwa_przedmiot.Text = String.Empty;
            dodaj_dzien_przedmiot.Text = String.Empty;
            dodaj_godzina_przedmiot.Text = String.Empty;

            LoadPlan();

        }
        private void dodaj_zadanie_Click(object sender, RoutedEventArgs e)
        {
            zadania_domowe_bib p = new zadania_domowe_bib();

            p.nazwa = dodaj_nazwa_zadanie.Text;
            p.dzien = MapowanieDzien((dodaj_dzien_zadanie.SelectedItem as ComboBoxItem).Uid);
            p.godzina = MapowanieGodzina((dodaj_godzina_zadanie.SelectedItem as ComboBoxItem).Uid);

            SQLiteDataAccess.SaveZadania(p);

            dodaj_nazwa_zadanie.Text = String.Empty;
            dodaj_dzien_zadanie.Text = String.Empty;
            dodaj_godzina_zadanie.Text = String.Empty;

            LoadZadania();
        }
        private void dodaj_sprawdzian_Click(object sender, RoutedEventArgs e)
        {
            sprawdziany_bib p = new sprawdziany_bib();

            p.nazwa = dodaj_nazwa_sprawdzian.Text;
            p.dzien = MapowanieDzien((dodaj_dzien_sprawdzian.SelectedItem as ComboBoxItem).Uid);
            p.godzina = MapowanieGodzina((dodaj_godzina_sprawdzian.SelectedItem as ComboBoxItem).Uid);

            SQLiteDataAccess.SaveSprawdziany(p);

            dodaj_nazwa_sprawdzian.Text = String.Empty;
            dodaj_dzien_sprawdzian.Text = String.Empty;
            dodaj_godzina_sprawdzian.Text = String.Empty;
            dodaj_godzina_sprawdzian.Text = String.Empty;

            LoadSprawdziany();
        }
        private void edytuj_przedmiot_Click(object sender, RoutedEventArgs e)
        {
            plan_lekcji_bib p = new plan_lekcji_bib();

            p.nazwa = edytuj_nazwa_przedmiot.Text;
            p.dzien = MapowanieDzien((edytuj_dzien_przedmiot.SelectedItem as ComboBoxItem).Uid);
            p.godzina = MapowanieGodzina((edytuj_godzina_przedmiot.SelectedItem as ComboBoxItem).Uid);

            string nowanazwa = nowa_edytuj_nazwa_przedmiot.Text;
            string nowydzien = MapowanieDzien((nowa_edytuj_dzien_przedmiot.SelectedItem as ComboBoxItem).Uid);
            string nowagodzina = MapowanieGodzina((nowa_edytuj_godzina_przedmiot.SelectedItem as ComboBoxItem).Uid);

            SQLiteDataAccess.ModifyPlan(p, nowanazwa, nowydzien, nowagodzina);

            edytuj_nazwa_przedmiot.Text = String.Empty;
            edytuj_dzien_przedmiot.Text = String.Empty;
            edytuj_godzina_przedmiot.Text = String.Empty;
            nowa_edytuj_nazwa_przedmiot.Text = String.Empty;
            nowa_edytuj_dzien_przedmiot.Text = String.Empty;
            nowa_edytuj_godzina_przedmiot.Text = String.Empty;

            LoadPlan();
        }

        private void edytuj_zadanie_Click(object sender, RoutedEventArgs e)
        {
            zadania_domowe_bib p = new zadania_domowe_bib();

            p.nazwa = edytuj_nazwa_zadanie.Text;
            p.dzien = MapowanieDzien((edytuj_dzien_zadanie.SelectedItem as ComboBoxItem).Uid);
            p.godzina = MapowanieGodzina((edytuj_godzina_zadanie.SelectedItem as ComboBoxItem).Uid);

            string nowanazwa = nowa_edytuj_nazwa_zadanie.Text;
            string nowydzien = MapowanieDzien((nowa_edytuj_dzien_zadanie.SelectedItem as ComboBoxItem).Uid);
            string nowagodzina = MapowanieGodzina((nowa_edytuj_godzina_zadanie.SelectedItem as ComboBoxItem).Uid);

            SQLiteDataAccess.ModifyZadania(p, nowanazwa, nowydzien, nowagodzina);

            edytuj_nazwa_zadanie.Text = String.Empty;
            edytuj_dzien_zadanie.Text = String.Empty;
            edytuj_godzina_zadanie.Text = String.Empty;
            nowa_edytuj_nazwa_zadanie.Text = String.Empty;
            nowa_edytuj_dzien_zadanie.Text = String.Empty;
            nowa_edytuj_godzina_zadanie.Text = String.Empty;

            LoadZadania();
        }

        private void edytuj_sprawdzian_Click(object sender, RoutedEventArgs e)
        {
            sprawdziany_bib p = new sprawdziany_bib();

            p.nazwa = edytuj_nazwa_sprawdzian.Text;
            p.dzien = MapowanieDzien((edytuj_dzien_sprawdzian.SelectedItem as ComboBoxItem).Uid);
            p.godzina = MapowanieGodzina((edytuj_godzina_sprawdzian.SelectedItem as ComboBoxItem).Uid);

            string nowanazwa = nowa_edytuj_nazwa_sprawdzian.Text;
            string nowydzien = MapowanieDzien((nowa_edytuj_dzien_sprawdzian.SelectedItem as ComboBoxItem).Uid);
            string nowagodzina = MapowanieGodzina((nowa_edytuj_godzina_sprawdzian.SelectedItem as ComboBoxItem).Uid);

            SQLiteDataAccess.ModifySprawdziany(p, nowanazwa, nowydzien, nowagodzina);

            edytuj_nazwa_sprawdzian.Text = String.Empty;
            edytuj_dzien_sprawdzian.Text = String.Empty;
            edytuj_godzina_sprawdzian.Text = String.Empty;
            nowa_edytuj_nazwa_sprawdzian.Text = String.Empty;
            nowa_edytuj_dzien_sprawdzian.Text = String.Empty;
            nowa_edytuj_godzina_sprawdzian.Text = String.Empty;

            LoadSprawdziany();
        }

        private void usun_przedmiot_Click(object sender, RoutedEventArgs e)
        {
            plan_lekcji_bib p = new plan_lekcji_bib();

            p.nazwa = usun_nazwa_przedmiot.Text;
            p.dzien = MapowanieDzien((usun_dzien_przedmiot.SelectedItem as ComboBoxItem).Uid);
            p.godzina = MapowanieGodzina((usun_godzina_przedmiot.SelectedItem as ComboBoxItem).Uid);

            SQLiteDataAccess.DeletePlan(p);

            usun_nazwa_przedmiot.Text = String.Empty;
            usun_dzien_przedmiot.Text = String.Empty;
            usun_godzina_przedmiot.Text = String.Empty;

            LoadPlan();
        }

        private void usun_zadanie_Click(object sender, RoutedEventArgs e)
        {
            zadania_domowe_bib p = new zadania_domowe_bib();

            p.nazwa = usun_nazwa_zadanie.Text;
            p.dzien = MapowanieDzien((usun_dzien_zadanie.SelectedItem as ComboBoxItem).Uid);
            p.godzina = MapowanieGodzina((usun_godzina_zadanie.SelectedItem as ComboBoxItem).Uid);

            SQLiteDataAccess.DeleteZadania(p);

            usun_nazwa_zadanie.Text = String.Empty;
            usun_dzien_zadanie.Text = String.Empty;
            usun_godzina_zadanie.Text = String.Empty;

            LoadZadania();
        }

        private void usun_sprawdzian_Click(object sender, RoutedEventArgs e)
        {
            sprawdziany_bib p = new sprawdziany_bib();

            p.nazwa = usun_nazwa_sprawdzian.Text;
            p.dzien = MapowanieDzien((usun_dzien_sprawdzian.SelectedItem as ComboBoxItem).Uid);
            p.godzina = MapowanieGodzina((usun_godzina_sprawdzian.SelectedItem as ComboBoxItem).Uid);

            SQLiteDataAccess.DeleteSprawdziany(p);

            usun_nazwa_sprawdzian.Text = String.Empty;
            usun_dzien_sprawdzian.Text = String.Empty;
            usun_godzina_sprawdzian.Text = String.Empty;

            LoadSprawdziany();
        }

        private void RibbonWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                if (sender is Ribbon ribbon)
                {
                    if (ribbon.SelectedIndex == 0)
                    {
                        plan_grid.Visibility = Visibility.Visible;
                        zadania_grid.Visibility = Visibility.Collapsed;
                        spr_grid.Visibility = Visibility.Collapsed;
                    }
                    if (ribbon.SelectedIndex == 1)
                    {
                        zadania_grid.Visibility = Visibility.Visible;
                        plan_grid.Visibility = Visibility.Collapsed;
                        spr_grid.Visibility = Visibility.Collapsed;
                    }
                    if (ribbon.SelectedIndex == 2)
                    {
                        spr_grid.Visibility = Visibility.Visible;
                        zadania_grid.Visibility = Visibility.Collapsed;
                        plan_grid.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
    }
}
