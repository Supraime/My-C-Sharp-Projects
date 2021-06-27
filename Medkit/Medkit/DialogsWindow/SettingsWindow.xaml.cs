// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Configuration;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using MySql.Data.MySqlClient;

namespace Medkit.DialogsWindow
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private readonly ConnectionBuild _connector = new ConnectionBuild();

        private void SettingsWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            DateTime lastback = DateTime.Parse(ConfigurationManager.AppSettings["currentdate"]);
            double count = (DateTime.Today - lastback).TotalDays;
            if (count == 0)
            {
                TimeLabel.Content = "Сегодня";
            }
            else
            {
                TimeLabel.Content = $"{ConfigurationManager.AppSettings["currentdate"]} ({count} {Helper.GetDeclesion(Convert.ToInt32(count), "день", "дня", "дней")} назад)";
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                CheckFileExists = false,
                CheckPathExists = true,
                Filter = "SQL Files|*.sql",
                InitialDirectory = Directory.GetCurrentDirectory() +$@"\BackupBase",
                Multiselect = false,
                Title = "Выберите файл"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    string filename = dialog.FileName;

                    using (MySqlConnection conn = new MySqlConnection(_connector.builder.ConnectionString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ImportFromFile(filename);
                                conn.Close();
                            }
                        }
                    }
                    SnackInfo.MessageQueue.Enqueue("База данных успешно востановлена", null, null, null, false, true, TimeSpan.FromSeconds(3));
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка " + ex);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string currentPath = Directory.GetCurrentDirectory();
                if (!Directory.Exists(System.IO.Path.Combine(currentPath, "BackupBase")))
                    Directory.CreateDirectory(System.IO.Path.Combine(currentPath, "BackupBase"));
                if (!Directory.Exists(System.IO.Path.Combine(currentPath, $@"BackupBase\{DateTime.Today.ToShortDateString()}")))
                    Directory.CreateDirectory(System.IO.Path.Combine(currentPath, $@"BackupBase\{DateTime.Today.ToShortDateString()}"));

                string backupstring = Directory.GetCurrentDirectory() + $@"\BackupBase\{DateTime.Today.ToShortDateString()}\backupdata_QuickSave_{DateTime.Now.Hour}_{DateTime.Now.Minute}.sql";
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
                SnackInfo.MessageQueue.Enqueue("Ручное копирование базы успешно произведенно", null, null, null, false, true, TimeSpan.FromSeconds(3));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
    }
}
