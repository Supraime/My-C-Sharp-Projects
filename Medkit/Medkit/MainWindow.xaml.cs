// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;
using Window = System.Windows.Window;
using System.Globalization;
using Form = System.Windows.Forms;

namespace Medkit
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ConnectionBuild _connector = new ConnectionBuild();

        List<PersonSource> perList = new List<PersonSource>();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            erroBox.Visibility = Visibility.Visible;
            var msg = new CustomMessageBox(0, "Подтверждение", "Вы точно хотите выйти из программы?");
            msg.Owner = this;
            if (msg.ShowDialog() == true)
            {
                Close();
            }
            erroBox.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Form.InputLanguage.CurrentInputLanguage = Form.InputLanguage.FromCulture(new CultureInfo("ru-RU"));

            Thread th = new Thread(CheckBackUp);
            th.Start();

            try
            {
                using (var connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.OpenAsync();
                    var command = new MySqlCommand("SELECT login, username FROM users", connection);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        perList.Add(new PersonSource() { Login = reader[0].ToString(), Username = reader[1].ToString() });
                    }
                    LoginBox.ItemsSource = perList;
                    reader.Close();
                    connection.Close();
                }
            }
            catch (InvalidOperationException)
            {
                erroBox.Visibility = Visibility.Visible;
                var msg = new CustomMessageBox(1, "Ошибка соединения", "Соединение с базой данных не установлено!");
                msg.Owner = this;
                msg.ShowDialog();
                erroBox.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                erroBox.Visibility = Visibility.Visible;
                var msg = new CustomMessageBox(1, "Подтверждение", "Ошибка! " + ex);
                msg.Owner = this;
                msg.ShowDialog();
                erroBox.Visibility = Visibility.Hidden;
            }
            GC.Collect();
        }

        private void CheckBackUp()
        {
            try
            {
                DateTime lastback = DateTime.Parse(ConfigurationManager.AppSettings["currentdate"]);
                double count = (DateTime.Today - lastback).TotalDays;

                string currentPath = Directory.GetCurrentDirectory();
                if (!Directory.Exists(Path.Combine(currentPath, "BackupBase")))
                    Directory.CreateDirectory(Path.Combine(currentPath, "BackupBase"));


                if (count >= 7)
                {
                    if (!Directory.Exists(Path.Combine(currentPath, $@"BackupBase\{DateTime.Today.ToShortDateString()}")))
                        Directory.CreateDirectory(Path.Combine(currentPath, $@"BackupBase\{DateTime.Today.ToShortDateString()}"));

                    string backupstring = Directory.GetCurrentDirectory() + $@"\BackupBase\{DateTime.Today.ToShortDateString()}\backupdata_AutoSave_{DateTime.Now.Hour}_{DateTime.Now.Minute}.sql";
                    using (var connection = new MySqlConnection(_connector.builder.ConnectionString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = connection;
                                connection.Open();
                                mb.ExportToFile(backupstring);
                                connection.Close();
                            }
                        }
                    }

                    Save("currentdate", DateTime.Now.ToShortDateString());
                }
            }
            catch 
            {
            }
        }

        private static void Save(string configKey, string value)
        {
            if (ConfigurationManager.AppSettings[configKey] != value)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection asSection = config.AppSettings;
                asSection.Settings.Remove(configKey);
                asSection.Settings.Add(configKey, value);
                config.Save();
                ConfigurationManager.RefreshSection(asSection.SectionInformation.Name);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if(LoginBox.SelectedIndex == -1)
                {
                    errorMsg.Visibility = Visibility.Visible;
                    return;
                }
                if(pass.Password == "")
                {
                    errorPass.Visibility = Visibility.Visible;
                    return;
                }
                string login = LoginBox.SelectedValue.ToString();
                string username = LoginBox.Text;
                string password = Helper.GeneratedHashString(pass.Password);
                string status = string.Empty;

                using(var connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.OpenAsync();
                    var command = new MySqlCommand("SELECT password, status FROM users WHERE login = '"+ login +"'", connection);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if(password == reader[0].ToString())
                        {
                            status = reader[1].ToString();
                            UpdateTimeEnter(login);
                            var menuWindow = new MenuWindow(login, status, username);
                            menuWindow.Show();
                            this.Close();
                            break;
                        }
                        else
                        {
                            var doubleAnim = new DoubleAnimation
                            {
                                From = wrongPass.Opacity,
                                To = 100,
                                Duration = TimeSpan.FromSeconds(20)
                            };
                            wrongPass.BeginAnimation(Label.OpacityProperty, doubleAnim);
                            reader.Close();
                            connection.Close();
                            return;
                        }
                    }
                    reader.Close();
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                erroBox.Visibility = Visibility.Visible;
                var msg = new CustomMessageBox(1, "Подтверждение", "Ошибка! " + ex);
                msg.Owner = this;
                msg.ShowDialog();
                erroBox.Visibility = Visibility.Hidden;
            }
        }

        private void UpdateTimeEnter(string login)
        {
            try
            {
                using (var connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.OpenAsync();
                    var command = new MySqlCommand("UPDATE users SET last_enter='"+DateTime.Now+"' WHERE login='"+login+"'", connection);
                    command.ExecuteNonQueryAsync();
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                erroBox.Visibility = Visibility.Visible;
                var msg = new CustomMessageBox(1, "Подтверждение", "Ошибка! " + ex);
                msg.Owner = this;
                msg.ShowDialog();
                erroBox.Visibility = Visibility.Hidden;
            }
        }

        private void pass_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            errorPass.Visibility = Visibility.Hidden;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Button_Click_1(sender, e);
            }
        }
    }

    class PersonSource
    {
        public string Login { get; set; }
        public string Username { get; set; }
    }
}
