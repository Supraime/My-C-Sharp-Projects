// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using MaterialDesignThemes.Wpf;

namespace Medkit.DialogsWindow
{
    /// <summary>
    /// Логика взаимодействия для UserAdd.xaml
    /// </summary>
    public partial class UserAdd : Window
    {
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string UserPassword { get; set; }

        private int status;
        public string currentLogin;
        public UserAdd(int state)
        {
            InitializeComponent();
            LoginUser.Focus();
            status = state;
            if (state == 1)
            {
                TitleDialog.Content = "Редактирование пользователя";
                AcceptButton.Content = "Редактировать";
                HintAssist.SetHint(Password,"Новый пароль");
                HintAssist.SetHelperText(Password, "Оставьте поле пустым, если смена пароля не требуется");
                HintAssist.SetHelperText(RepeatPassword, "Оставьте поле пустым, если смена пароля не требуется");
                Password.ToolTip = "Пароль должен состоять из не менее 8 символов и содержать в себе латинские буквы и цифры\nОставьте поле пустым если смена пароля не требуется";
            }
            
        }

        private readonly int _minpasslenght = 8;
        ConnectionBuild _connector = new ConnectionBuild();
        private MySqlConnection connection;
        private string badsym = "!@#$%^&*()_+-=`~[]{};':,/<>?|\\№";

        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (LoginUser.Text == "" || UsernameBox.Text == "" || StatusBox.SelectedIndex == -1 )
            {
                WarningMsg.Visibility = Visibility.Visible;
                return;
            }
            bool acceptLogin = Regex.IsMatch(LoginUser.Text, @"^[a-zA-Z0-9_]+$");

            if (!acceptLogin || IsDigitsOnly(LoginUser.Text))
            {
                WarningMsg.Content = "Логин не соответствует требованиям";
                WarningMsg.Visibility = Visibility.Visible;
                return;
            }

            bool onlyaz = Regex.IsMatch(Password.Text, @"^[a-zA-Z]+$");
            bool attep = Regex.IsMatch(Password.Text, @"^[a-zA-Z0-9_`~!@#$%^&*()_+=\-|[\]{}:.<>?]+$");

            if ((Password.Text != "" && status == 1) || status == 0)
            {
                if (Password.Text.Length < _minpasslenght)
                {
                    WarningMsg.Content = $"Длина пароля меньше {_minpasslenght} символов";
                    WarningMsg.Visibility = Visibility.Visible;
                    return;
                }
                else if (IsDigitsOnly(Password.Text) || !attep || onlyaz)
                {
                    WarningMsg.Content = "Пароль не соответствует требованиям";
                    WarningMsg.Visibility = Visibility.Visible;
                    return;
                }
                else if (Password.Text != RepeatPassword.Text)
                {
                    WarningMsg.Content = "Пароли не совпадают!";
                    WarningMsg.Visibility = Visibility.Visible;
                    return;
                }
            }

            if (currentLogin != LoginUser.Text && status == 1)
            {
                int unicLogin;
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) FROM users WHERE login='{LoginUser.Text}'", connection); 
                    unicLogin = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                }

                if (unicLogin != 0)
                {
                    WarningMsg.Content = "Данный логин уже занят!";
                    WarningMsg.Visibility = Visibility.Visible;
                    return;
                }
            }

            UserLogin = LoginUser.Text;
            UserName = UsernameBox.Text;
            Status = ((ComboBoxItem) StatusBox.SelectedItem).Tag.ToString();
            UserPassword = Password.Text;

            DialogResult = true;
        }

        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            string str = "qwertyuiopasdfghjklzxcvbnm";
            string UPstr = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string sym = "~!@#$%^&*RTYUIOPASDFGHJ()_+=-|:?";
            int num = 0;
            Random rnd = new Random();
            string genpass = "";
            int leng = rnd.Next(9, 13);
            while (genpass.Length < leng)
            {
                num = rnd.Next(0, str.Length - 1);
                genpass += str[num];
                num = rnd.Next(0, UPstr.Length - 1);
                genpass += UPstr[num];
                num = rnd.Next(0, sym.Length - 1);
                genpass += sym[num];
                num = rnd.Next(0, 250);
                genpass += num;
            }
            Password.Text = genpass;
            RepeatPassword.Text = genpass;
        }

        private void UsernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void UsernameBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text, 0)) e.Handled = true;
            if (badsym.Contains(e.Text)) e.Handled = true;
        }
    }
}
