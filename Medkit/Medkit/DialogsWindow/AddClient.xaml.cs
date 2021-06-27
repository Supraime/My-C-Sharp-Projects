// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace Medkit.DialogsWindow
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public string FamilyClient { get; set; }
        public string NamClient { get; set; }
        public string SerName { get; set; }
        public string Phone { get; set; }
        public string Date { get; set; }
        public int Serial { get; set; }
        public int Num { get; set; }

        ConnectionBuild _connector = new ConnectionBuild();
        private MySqlConnection connection;
        int currentSerial, currentNum, stat;
        private string badsym = "!@#$%^&*()_+-=`~[]{};':,./<>?|\\№";

        public AddClient(int state)
        {
            InitializeComponent();
            stat = state;
            if(state == 1)
            {
                NameDialog.Content = "Редактирование клиента";
                AcceptButton.Content = "Редактировать";
            }
            FamClient.Focus();
        }

        private void AddClient_OnLoaded(object sender, RoutedEventArgs e)
        {
            DateDay.DisplayDateEnd = DateTime.Today;
            if(stat == 1)
            {
                currentSerial = Convert.ToInt32(SerialPass.Text);
                currentNum = Convert.ToInt32(NumPass.Text);
            }
        }

        private void FamClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void FamClient_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text, 0)) e.Handled = true;
            if (badsym.Contains(e.Text)) e.Handled = true;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (FamClient.Text == "" || NameClient.Text == "" || SnameClient.Text == "" || PhoneBox.IsMaskCompleted == false || DateDay.SelectedDate.ToString() == "" || SerialPass.Text == "" || NumPass.Text == "")
            {
                WarningMsg.Content = "Заполните все поля!";
                WarningMsg.Visibility = Visibility.Visible;
                return;
            }
            int unicPass;
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) FROM clients WHERE serial_pass={Convert.ToInt32(SerialPass.Text)} AND num_pass={Convert.ToInt32(NumPass.Text)}", connection);
                unicPass = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
            }
            if (unicPass != 0 && (currentNum != Convert.ToInt32(NumPass.Text) || currentSerial != Convert.ToInt32(SerialPass.Text)))
            {
                WarningMsg.Content = "Клиент с таким паспортом уже существует!";
                WarningMsg.Visibility = Visibility.Visible;
                return;
            }

            FamilyClient = FamClient.Text;
            NamClient = NameClient.Text;
            SerName = SnameClient.Text;
            Phone = PhoneBox.Text;
            Date = DateDay.SelectedDate.ToString().Split(' ')[0];
            Serial = Convert.ToInt32(SerialPass.Text);
            Num = Convert.ToInt32(NumPass.Text);

            DialogResult = true;
        }
    }
}
