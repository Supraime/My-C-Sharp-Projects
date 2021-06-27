// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Medkit.DialogsWindow
{
    /// <summary>
    /// Логика взаимодействия для CheckSpec.xaml
    /// </summary>
    public partial class CheckSpec : Window
    {
        ConnectionBuild _connector = new ConnectionBuild();
        private MySqlConnection connection;
        public CheckSpec()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateSpec();
        }

        private void UpdateSpec()
        {
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand("SELECT * FROM special", connection);
                var dataTable = new DataTable();
                mySqlCommand.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                dataAdapter.Fill(dataTable);

                dataTable.Columns[1].ColumnName = "Наименование";
                dataWork.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }
            dataWork.Columns[0].Visibility = Visibility.Hidden;
        }

        private void TalonWord_Click(object sender, RoutedEventArgs e)
        {
            int curId = Convert.ToInt32(((Button)sender).CommandParameter);
            CustomMessageBox msg = new CustomMessageBox(0, "Подтверждение", "Вы точно хотите удалить направление и врачей с этой специальностью?")
            {
                Owner = this
            };

            Shadow.Visibility = Visibility.Visible;
            if(msg.ShowDialog() == true)
            {
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    int[] masI = new int[100];
                    connection.Open();
                    var mySqlCommand = new MySqlCommand($"DELETE FROM special WHERE id={curId}", connection);
                    mySqlCommand.ExecuteNonQuery();
                    mySqlCommand = new MySqlCommand($"SELECT id FROM doctors WHERE spec={curId}", connection);
                    var reader = mySqlCommand.ExecuteReader();
                    int i = 0;
                    while (reader.Read())
                    {
                        masI[i] = Convert.ToInt32(reader[0]);
                        i++;
                    }
                    reader.Close();
                    int j = i;
                    i = 0;
                    while(i <= j)
                    {
                        mySqlCommand = new MySqlCommand("DELETE FROM talons WHERE id_doctor = " + masI[i] + "", connection);
                        mySqlCommand.ExecuteNonQuery();
                        i++;
                    }
                    mySqlCommand = new MySqlCommand($"DELETE FROM doctors WHERE spec={curId}", connection);
                    mySqlCommand.ExecuteNonQuery();
                    //mySqlCommand = new MySqlCommand("DELETE FROM talons WHERE id_doctor = " + curId + "", connection);
                    //mySqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                UpdateSpec();
                SnackInfo.MessageQueue.Enqueue("Специальность успешно удалена", null, null, null, false, true, TimeSpan.FromSeconds(1.5));
            }
            Shadow.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int currentId = Convert.ToInt32(((Button)sender).CommandParameter);
            AddSpecial addSpecial = new AddSpecial(1);
            addSpecial.Owner = this;
            string str;
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"SELECT spec FROM special WHERE id={currentId}", connection);
                str = command.ExecuteScalar().ToString();
                addSpecial.SpecNameBox.Text = str;
                connection.Close();
            }

            Shadow.Visibility = Visibility.Visible;
            if (addSpecial.ShowDialog() == true)
            {
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand($"UPDATE special SET spec='{addSpecial.SpecName}' WHERE id={currentId}", connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                UpdateSpec();
                SnackInfo.MessageQueue.Enqueue($@"Направление '{addSpecial.SpecName}' успешно добавлено!", null, null, null, false, true, TimeSpan.FromSeconds(2));
            }
            Shadow.Visibility = Visibility.Hidden;

        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            AddSpecial addSpecial = new AddSpecial(0);
            addSpecial.Owner = this;
            string id = string.Empty;
            Shadow.Visibility = Visibility.Visible;
            if (addSpecial.ShowDialog() == true)
            {
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("INSERT INTO special (spec) VALUES ('" + addSpecial.SpecName + "')", connection);
                    command.ExecuteNonQuery();
                    command = new MySqlCommand("SELECT id FROM special WHERE spec='" + addSpecial.SpecName + "'", connection);
                    id = command.ExecuteScalar().ToString();
                    connection.Close();
                }
                UpdateSpec();
                SnackInfo.MessageQueue.Enqueue($@"Направление '{addSpecial.SpecName}' успешно добавлено!", null, null, null, false, true, TimeSpan.FromSeconds(2));
            }
            Shadow.Visibility = Visibility.Hidden;
        }
    }
}
