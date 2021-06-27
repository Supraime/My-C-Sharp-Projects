// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace Medkit.DialogsWindow
{
    /// <summary>
    /// Логика взаимодействия для AddDoctorDialog.xaml
    /// </summary>
    public partial class AddDoctorDialog : Window
    {
        ConnectionBuild _connector = new ConnectionBuild();
        private MySqlConnection connection;
        ObservableCollection<SpecialSource> specialSources = new ObservableCollection<SpecialSource>();
        public string FamilyDoctor { get; set; }
        public string NamDoctor { get; set; }
        public string SnamDoctor { get; set; }
        public int SpecDoctor { get; set; }
        public int StartTimePriem { get; set; }
        public int EndTimePriem { get; set; }
        public int CabDoctor { get; set; }
        public int PriceDoctor { get; set; }
        private string badsym = "!@#$%^&*()_+-=`~[]{};':,./<>?|\\№";

        public AddDoctorDialog(int state)
        {
            InitializeComponent();
            if (state == 1)
            {
                TitleDialog.Content = "Редактирование врача";
                AcceptButton.Content = "Редактировать";
            }
            FamDoctor.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FamDoctor.Text == "" || NameDoctor.Text == "" || SenDoctor.Text == "" || SpecDoctorBox.SelectedIndex == -1 || StartTime.Text == "" || EndTime.Text == "" || CabFas.Text == "" ||  Price.Text == "")
            {
                WarningMsg.Content = "Заполните все поля!";
                WarningMsg.Visibility = Visibility.Visible;
                return;
            }

            int startTime = Convert.ToInt32(StartTime.Text);
            int endTime = Convert.ToInt32(EndTime.Text);
            if (startTime < 8 || startTime > 16 || endTime < 9 || endTime > 18 || endTime < startTime)
            {
                WarningMsg.Content = "Некорректное время приема";
                WarningMsg.Visibility = Visibility.Visible;
                return;
            }

            FamilyDoctor = FamDoctor.Text;
            NamDoctor = NameDoctor.Text;
            SnamDoctor = SenDoctor.Text;
            SpecDoctor = Convert.ToInt32(SpecDoctorBox.SelectedValue);
            StartTimePriem = startTime;
            EndTimePriem = endTime;
            CabDoctor = Convert.ToInt32(CabFas.Text);
            PriceDoctor = Convert.ToInt32(Price.Text);

            DialogResult = true;
        }

        private void AddDoctorDialog_OnLoaded(object sender, RoutedEventArgs e)
        {
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM special", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    specialSources.Add(new SpecialSource() { Num = reader[0].ToString(), Spl = reader[1].ToString() });
                }
                SpecDoctorBox.ItemsSource = specialSources;
                reader.Close();
                connection.Close();
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            AddSpecial addSpecial = new AddSpecial(0);
            addSpecial.Owner = this;
            string id = string.Empty;
            ShadowEff.Visibility = Visibility.Visible;
            if (addSpecial.ShowDialog() == true)
            {
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("INSERT INTO special (spec) VALUES ('"+addSpecial.SpecName+"')", connection);
                    command.ExecuteNonQuery();
                    command = new MySqlCommand("SELECT id FROM special WHERE spec='"+addSpecial.SpecName+"'", connection);
                    id = command.ExecuteScalar().ToString();
                    connection.Close();
                }
                specialSources.Add(new SpecialSource() { Num = id, Spl = addSpecial.SpecName});
                SnackInfo.MessageQueue.Enqueue($@"Направление '{addSpecial.SpecName}' успешно добавлено!", null, null, null, false, true, TimeSpan.FromSeconds(3));
            }
            ShadowEff.Visibility = Visibility.Hidden;
        }

        private void StartTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0)) e.Handled = true;
            if (badsym.Contains(e.Text)) e.Handled = true;
        }

        private void FamDoctor_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text, 0)) e.Handled = true;
            if (badsym.Contains(e.Text)) e.Handled = true;
        }

        private void SpaceTriger_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }

        private void FamDoctor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }
    }
}
