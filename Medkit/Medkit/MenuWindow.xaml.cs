// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Text;
using Medkit.DialogsWindow;
using MessagingToolkit.QRCode.Codec;
using Size = System.Drawing.Size;
using WindowState = System.Windows.WindowState;

namespace Medkit
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : INotifyPropertyChanged
    {

        private readonly string _tmpLogin;
        private readonly string _status;
        private readonly string _tmpUsername;

        private readonly string _fileName = Directory.GetCurrentDirectory() + @"\template\template.dotx";
        private readonly string _contractName = Directory.GetCurrentDirectory() + @"\template\ShortTemplateContract.dotx";


        private int idClient = -1;
        private bool sale = false;
        private int idDoctor = -1;
        private int price;
        private int cabinet;
        private string timeTalon = string.Empty;
        //private bool creator;
        //private bool loader;
        private int _idClientGrid;
        private string _talonGridName;
        public bool createStateWindos = false;
        private bool _maxWindow = false;

        private bool fltDat = false;
        private bool fltMn = false;
        private bool fltTime = false;
        private string _fValue = "";
        private string _fTime = "";

        ConnectionBuild _connector = new ConnectionBuild();
        private MySqlConnection connection;

        List<SpecialSource> specialSources = new List<SpecialSource>();
        ObservableCollection<DoctorSource> doctorSources = new ObservableCollection<DoctorSource>();
        DispatcherTimer timer;

        public event PropertyChangedEventHandler PropertyChanged;
        private string badsym = "!@#$%^&*()_+-=`~[]{};':,./<>?|\\№";

        public MenuWindow(string log, string statu, string usernam)
        {
            InitializeComponent();
            _tmpLogin = log;
            _status = statu;
            _tmpUsername = usernam;
            labelName.Content = usernam;

            if (statu == "Сотрудник")
            {
                labelStatus.Content = "Сотрудник";
            } 
            else
            {
                labelStatus.Content = "Администратор";
                UserPanel.Visibility = Visibility.Hidden;
                AdminPanel.Visibility = Visibility.Visible;
            }
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1.0)
            };
            timer.Start();
            timer.Tick += new EventHandler(delegate (object s, EventArgs a)
            {
                clock.Content = "Время: " + DateTime.Now.Hour + ":"
              + DateTime.Now.Minute;
            });
            GC.Collect();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clearing();
            MainWindow main = new MainWindow();
            main.Show();
            connection = null;
            _connector = null;
            GC.Collect();
            Close();
        }

        private void MainGridLoad()
        {
            string sql;
            if (fltDat || fltMn || fltTime)
            {
                sql = GetSQLFilt();
            }
            else
            {
                sql = "SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                                                   "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                                                   "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                                                   "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                                                   "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                                                   "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                                                   "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer FROM talons WHERE cancel=0";
            }
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand(sql, connection);
                var dataTable = new DataTable();
                mySqlCommand.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                dataAdapter.Fill(dataTable);
                dataTable.Columns[2].ColumnName = "Дата и время";
                dataWork.ItemsSource = dataTable.DefaultView;
                //mySqlCommand = new MySqlCommand("SELECT COUNT(*) FROM talons WHERE date = '" + DateTime.Now.ToShortDateString() + "'", connection);
                //int сount;
                //сount = Convert.ToInt32(mySqlCommand.ExecuteScalar());
                //TimeLabel.Content = $"{сount} {Helper.GetDeclesion(сount, "талон", "талона", "талонов")}";
                connection.Close();
            }

            dataWork.Columns[0].Visibility = Visibility.Hidden;
            dataWork.Columns[4].Visibility = Visibility.Hidden;
            dataWork.Columns[5].Visibility = Visibility.Hidden;
            dataWork.Columns[6].Visibility = Visibility.Hidden;
            dataWork.Columns[7].Visibility = Visibility.Hidden;
            dataWork.Columns[8].Visibility = Visibility.Hidden;
            dataWork.Columns[9].Visibility = Visibility.Hidden;
            dataWork.Columns[10].Visibility = Visibility.Hidden;
        }

        #region Clearing

        private void Clearing()
        {
            connection = null;
            _connector = null;
            specialSources = null;
            doctorSources = null;
            timer.Stop();
        }

        #endregion

        private string GetSQLFilt()
        {
            string temp = "";
            if (fltDat && fltTime)
            {
                temp = "SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                                                    "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                                                    "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                                                    "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                                                    "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                                                    "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                                                    "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer FROM talons WHERE cancel=0 AND date='"+ _fValue +"' AND time='"+_fTime+"'";
            } 
            else if (fltMn && fltTime)
            {
                temp = "SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                                                    "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                                                    "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                                                    "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                                                    "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                                                    "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                                                    "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer FROM talons WHERE cancel=0 AND date LIKE '%"+ _fValue +"%' AND time='"+_fTime+"'";
            } 
            else if (fltDat)
            {
                temp = "SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                                                       "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                                                       "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                                                       "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                                                       "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                                                       "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                                                       "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer FROM talons WHERE cancel=0 AND date='" + _fValue + "'";

            } 
            else if (fltMn)
            {
                temp = "SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                                                    "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                                                    "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                                                    "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                                                    "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                                                    "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                                                    "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer FROM talons WHERE cancel=0 AND date LIKE '%" + _fValue + "%'";
            }
            else
            {
                temp = "SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                                                    "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                                                    "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                                                    "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                                                    "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                                                    "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                                                    "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer FROM talons WHERE cancel=0 AND time ='" + _fTime + "'";
            }
            return temp;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataWork.Height = Window.Height-140;
            ClientDataTalonGrid.Height = Window.Height-140;
            MainGridLoad();

            //rightGrid.Width = Window.Width - 900;
            //rightGrid.Height = Window.Height;
            LeftGrid.Width = Window.Width - 200;
            clock.Content = "Время: "+ DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            dateLabel.Content = "Дата: " + DateTime.Now.ToShortDateString();
            GC.Collect();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                shadow.Visibility = Visibility.Visible;
                int id = Convert.ToInt32(((Button)sender).CommandParameter);
                CustomMessageBox msg = new CustomMessageBox(0, "Подтверждение", "Вы точно хотите отменить запись на прием?");
                msg.Owner = this;
                if (msg.ShowDialog() == true)
                {
                    using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                    {
                        connection.Open();
                        MySqlCommand mySqlCommand = new MySqlCommand("UPDATE talons SET cancel=2 WHERE id=" + id + "", connection);
                        mySqlCommand.ExecuteNonQuery();
                        RePaintTable(0);
                        connection.Close();
                    }
                    snackInfo.MessageQueue.Enqueue("Запись успешно отмененна", null, null, null, false, true, TimeSpan.FromSeconds(2));
                }
                shadow.Visibility = Visibility.Hidden;
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Eer " + ex);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (TalonGrid.Visibility == Visibility.Visible) return;
            if (MainGrid.Visibility == Visibility.Visible)
            {
                MainGrid.Visibility = Visibility.Hidden;
                CreateTalonWindow();
                TalonGrid.Visibility = Visibility.Visible;
            }
            else if (ClientGrid.Visibility == Visibility.Visible)
            {
                ClientGrid.Visibility = Visibility.Hidden;
                CreateTalonWindow();
                TalonGrid.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                string find = findTextBox.Text;
                string sql;
                if (fltDat || fltMn || fltTime)
                {
                    sql = GetFindFilt(find);
                }
                else
                {
                    sql = "SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                        "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                        "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                        "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                        "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                        "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                        "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer " +
                        "FROM talons WHERE cancel=0 AND (concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) LIKE '%" + find + "%' " +
                        "OR concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) LIKE '%" + find + "%')";
                }
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
                    DataTable dataTable = new DataTable();
                    mySqlCommand.ExecuteNonQuery();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(mySqlCommand);
                    dataAdapter.Fill(dataTable);
                    PaintGrid(dataTable, 0);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("eerr" + ex);
            }

        }

        private string GetFindFilt(string fnd)
        {
            string temp = "";
            if (fltDat && fltTime)
            {
                temp = "SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                        "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                        "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                        "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                        "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                        "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                        "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer " +
                        "FROM talons WHERE cancel=0 AND date='"+ _fValue +"' AND time='"+ _fTime +"' AND (concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) LIKE '%" + fnd + "%' " +
                        "OR concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) LIKE '%" + fnd + "%')";
            }
            else if (fltMn && fltTime)
            {
                temp = "SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                        "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                        "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                        "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                        "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                        "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                        "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer " +
                        "FROM talons WHERE cancel=0 AND date LIKE '%" + _fValue + "%' AND time='"+_fTime+"' AND (concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) LIKE '%" + fnd + "%' " +
                        "OR concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) LIKE '%" + fnd + "%')";
            } 
            else if (fltDat)
            {
                temp = "SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                           "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                           "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                           "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                           "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                           "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                           "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer " +
                           "FROM talons WHERE cancel=0 AND date='" + _fValue + "' AND (concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) LIKE '%" + fnd + "%' " +
                           "OR concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) LIKE '%" + fnd + "%')";
            } 
            else if (fltMn)
            {
                temp = "SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                        "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                        "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                        "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                        "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                        "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                        "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer " +
                        "FROM talons WHERE cancel=0 AND date LIKE '%" + _fValue + "%' AND (concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) LIKE '%" + fnd + "%' " +
                        "OR concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) LIKE '%" + fnd + "%')";
            }
            else
            {
                temp = "SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                        "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                        "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                        "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                        "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                        "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                        "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer " +
                        "FROM talons WHERE cancel=0 AND time='" + _fTime + "' AND (concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) LIKE '%" + fnd + "%' " +
                        "OR concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) LIKE '%" + fnd + "%')";
            }
            return temp;
        }

        private void CreateTalonWindow()
        {
            if (!createStateWindos)
            {
                string dateStart = "Jan 1, 1910";
                dateDay.DisplayDateStart = DateTime.Parse(dateStart);
                dateDay.DisplayDateEnd = DateTime.Today;

                dateStart = "Dec 29, " + DateTime.Now.Year;
                datePrim.DisplayDateStart = DateTime.Today;
                datePrim.DisplayDateEnd = DateTime.Parse(dateStart);

                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM special", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        specialSources.Add(new SpecialSource() { Num = reader[0].ToString(), Spl = reader[1].ToString() });
                    }
                    specBox.ItemsSource = specialSources;
                    reader.Close();
                    connection.Close();
                }
                createStateWindos = true;
            }
        }

        private void LoadClientGrid()
        {
            ClientDataTalonGrid.Height = Window.Height - 140;
            ClientDataGrid.Height = Window.Height - 140;
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand("SELECT id, concat_ws(' ', fname, name, sname) AS ФИО, concat_ws('.', day_bd, month_bd, year_bd) AS dt, telephone, serial_pass AS sera, num_pass AS numa FROM clients", connection);
                var dataTable = new DataTable();
                mySqlCommand.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                dataAdapter.Fill(dataTable);
                dataTable.Columns[4].ColumnName = "Серия";
                dataTable.Columns[5].ColumnName = "Номер паспорта";
                ClientDataGrid.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }
            ClientDataGrid.Columns[0].Visibility = Visibility.Hidden;
            ClientDataGrid.Columns[1].Width = 240;
            ClientDataGrid.Columns[4].Width = 80;
            ClientDataGrid.Columns[3].Visibility = Visibility.Hidden;
            ClientDataGrid.Columns[2].Visibility = Visibility.Hidden;
        }

        private void specBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = Convert.ToInt32(specBox.SelectedValue);
            doctorSources.Clear();
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.OpenAsync();
                var command = new MySqlCommand("SELECT id, concat_ws(' ', fname, name, sname) FROM doctors WHERE spec = " + id + "", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    doctorSources.Add(new DoctorSource() { Num = reader[0].ToString(), Fio = reader[1].ToString() });
                }
                doctorBox.ItemsSource = doctorSources;
                OnPropertyChanged("doctorSources");
                InitializeComponent();
                reader.Close();
                connection.Close();
            }
        }

        private void ButtonFind_OnClick(object sender, RoutedEventArgs e)
        {
            if (SerialBox.Text == "" || NumPass.Text == "")
            {
                WrongData.Visibility = Visibility.Visible;
                return;
            }
            string serial = SerialBox.Text;
            string numPas = NumPass.Text;
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.OpenAsync();
                var command = new MySqlCommand("SELECT fname, name, sname, concat_ws('.', day_bd, month_bd, year_bd) AS date, telephone, id FROM clients WHERE serial_pass = " + serial + " AND num_pass = " + numPas + " ", connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows == false)
                {
                    snackInfo.MessageQueue.Enqueue("Данные паспорта отсутствуют в базе данных", null, null, null, false, true, TimeSpan.FromSeconds(3));
                    return;
                }
                while (reader.Read())
                {
                    FamBox.Text = reader[0].ToString();
                    NameBox.Text = reader[1].ToString();
                    OtchBox.Text = reader[2].ToString();
                    dateDay.Text = reader[3].ToString();
                    PhoneBox.Text = reader[4].ToString();
                    idClient = Convert.ToInt32(reader[5]);
                    sale = true;
                    snackInfo.MessageQueue.Enqueue("Клиент найден! Данные успешно вставлены", null, null, null, false, true, TimeSpan.FromSeconds(2.5));
                }
                ActualPrice(price);
                reader.Close();
                connection.Close();
            }
        }

        private void DoctorBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int numString = 0;
            RadioButton radioButton;
            while (numString != 19)
            {
                radioButton = Panel.Children.OfType<RadioButton>().FirstOrDefault(x => x.Name == "Time" + numString);
                radioButton.Visibility = Visibility.Hidden;
                numString++;
            }

            idDoctor = Convert.ToInt32(doctorBox.SelectedValue);

            datePrim.SelectedDate = null;
            //string[] timeStrings = new string[19];
            //numString = 0;
            //using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            //{
            //    connection.OpenAsync();
            //    var command = new MySqlCommand("SELECT time_start, time_end, price, cabinet FROM doctors WHERE id = " + idDoctor + "", connection);
            //    var reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        price = Convert.ToInt32(reader[2]);
            //        cabinet = Convert.ToInt32(reader[3]);
            //        int start = Convert.ToInt32(reader[0]);
            //        int end = Convert.ToInt32(reader[1]);

            //        string min = "00";
            //        while (start != end)
            //        {
            //            //timeStrings[numString] = start + ":" + min; 
            //            radioButton = Panel.Children.OfType<RadioButton>().FirstOrDefault(x => x.Name == "Time" + numString);
            //            radioButton.Visibility = Visibility.Visible;
            //            radioButton.Content = start + ":" + min;

            //            numString++;
            //            if (min == "30")
            //            {
            //                min = "00";
            //                start++;
            //            }
            //            else
            //            {
            //                min = "30";
            //            }
            //        }

            //    }
            //    ActualPrice(price);
            //    reader.Close();
            //    connection.Close();
            //}
        }

        private int ActualPrice(int actualPrice)
        {
            if (sale)
            {
                actualPrice -= (actualPrice / 100 * 3);
                PriceLabel.Content = actualPrice + "руб";
                SaleLabel.Visibility = Visibility.Visible;
            }
            else
            {
                PriceLabel.Content = actualPrice + "руб";
                SaleLabel.Visibility = Visibility.Hidden;
            }

            return actualPrice;
        }

        private void AddTalon_OnClick(object sender, RoutedEventArgs e)
        {
            if (FamBox.Text == "" || NameBox.Text == "" || OtchBox.Text == "" || dateDay.SelectedDate.ToString() == "" || PhoneBox.IsMaskFull == false || SerialBox.Text == "" || NumPass.Text == "" || TypeTalon.SelectedIndex == -1 || specBox.SelectedIndex == -1 || doctorBox.SelectedIndex == -1 || datePrim.SelectedDate.ToString() == "")
            {
                WarningMsg.Visibility = Visibility.Visible;
                return;
            }
            if (timeTalon == string.Empty)
            {
                WarningMsg.Visibility = Visibility.Visible;
                return;
            }
            WarningMsg.Visibility = Visibility.Hidden;

            TalonData talonData = new TalonData
            {
                FamName = FamBox.Text,
                Name = NameBox.Text,
                OtchName = OtchBox.Text,
                DateOfBd = dateDay.SelectedDate.ToString().Split(' ')[0],
                Phone = PhoneBox.Text,
                SerialPass = SerialBox.Text,
                NumPs = NumPass.Text,
                Type = TypeTalon.Text,
                Napr = specBox.Text,
                Doctor = doctorBox.Text,
                DateOfTalon = datePrim.SelectedDate.ToString().Split(' ')[0],
                TimeOfTalon = timeTalon,
                SaleTalon = sale,
                CabinetTalon = cabinet
            };

            if (talonData.SaleTalon == false)
            {
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.OpenAsync();
                    var command = new MySqlCommand("SELECT id FROM clients WHERE serial_pass = " + talonData.SerialPass + " AND num_pass = " + talonData.NumPs + " ", connection);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        sale = true;
                        while (reader.Read())
                        {
                            idClient = Convert.ToInt32(reader[0]);
                        }
                        talonData.SaleTalon = true;
                    }
                    else
                    {
                        talonData.SaleText = "Отсутствует";
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            else
            {
                talonData.SaleText = "3%";
            }

            talonData.PriceTalon = ActualPrice(price);

            AcceptTalon acceptTalon = new AcceptTalon(talonData);
            acceptTalon.Owner = this;
            shadow.Visibility = Visibility.Visible;
            if (acceptTalon.ShowDialog() == true)
            {
                if (idClient == -1)
                {
                    using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                    {
                        connection.OpenAsync();
                        var command = new MySqlCommand("INSERT INTO clients (fname, name, sname, day_bd, month_bd, year_bd, telephone, serial_pass, num_pass) VALUES ('" + talonData.FamName + "','" + talonData.Name + "','" + talonData.OtchName + "'," +
                                                       "'" + talonData.DateOfBd.Split('.')[0] + "', '" + talonData.DateOfBd.Split('.')[1] + "', '" + talonData.DateOfBd.Split('.')[2] + "', '" + talonData.Phone + "', " + talonData.SerialPass + ", " + talonData.NumPs + ")", connection);
                        command.ExecuteNonQuery();
                        command = new MySqlCommand("SELECT id FROM clients WHERE serial_pass = " + talonData.SerialPass + " AND num_pass = " + talonData.NumPs + " ", connection);
                        idClient = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                    }

                }
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.OpenAsync();
                    var command = new MySqlCommand("INSERT INTO talons (id_client, id_doctor, date, time, disc, first_osmt, price, createdate) VALUES (" + idClient + ", " + idDoctor + ", '" + talonData.DateOfTalon + "', '" + talonData.TimeOfTalon + "', '" + talonData.SaleText + "', '" + talonData.Type + "', " + talonData.PriceTalon + ", '" + DateTime.Today.ToShortDateString() + "')", connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    snackInfo.MessageQueue.Enqueue("Талон успешно оформлен!", null, null, null, false, true, TimeSpan.FromSeconds(2.5));
                }

                int numString = 0;
                RadioButton radioButton;
                while (numString != 19)
                {
                    radioButton = Panel.Children.OfType<RadioButton>().FirstOrDefault(x => x.Name == "Time" + numString);
                    radioButton.Visibility = Visibility.Hidden;
                    numString++;
                }

                if (acceptTalon.Talon)
                {
                    DataTable dataTable = new DataTable();
                    using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                    {
                        connection.OpenAsync();
                        var command = new MySqlCommand("SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                                                       "talons.time, talons.date, concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                                                       "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                                                       "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr " +
                                                       "FROM talons WHERE id_client = " + idClient + " AND time = '" + talonData.TimeOfTalon + "' AND date = '" + talonData.DateOfTalon + "' AND id_doctor = " + idDoctor + "", connection);
                        command.ExecuteNonQuery();
                        var adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dataTable);
                        connection.Close();
                    }

                    string numTalon = dataTable.Rows[0].ItemArray.GetValue(0).ToString();
                    string pacientTalon = dataTable.Rows[0].ItemArray.GetValue(1).ToString();
                    string timeOfTalon = dataTable.Rows[0].ItemArray.GetValue(2).ToString();
                    string dateTalon = dataTable.Rows[0].ItemArray.GetValue(3).ToString();
                    string doctorTalon = dataTable.Rows[0].ItemArray.GetValue(4).ToString();
                    string cabinetTalon = dataTable.Rows[0].ItemArray.GetValue(5).ToString();
                    string specTalon = dataTable.Rows[0].ItemArray.GetValue(6).ToString();

                    string qrtext = $"Номер талона:{numTalon};Дата:{dateTalon};Время:{timeOfTalon};Кабинет:{cabinetTalon}"; //считываем текст из TextBox'a
                    QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
                    Bitmap qrcode = encoder.Encode(qrtext, Encoding.UTF8);
                    string dir = Directory.GetCurrentDirectory() + "img.jpg";
                    Bitmap objBitmap = new Bitmap(qrcode, new Size(100, 100));
                    objBitmap.Save(dir, ImageFormat.Jpeg);

                    object templatePathObj = _fileName;
                    object missingObj = Missing.Value;

                    var wordApp = new Word.Application();
                    wordApp.Visible = false;
                    Word.Table wordTable;
                    try
                    {
                        var wordDocument = wordApp.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);

                        ReplaceWordStub("{Num}", numTalon, wordDocument);
                        ReplaceWordStub("{Pacient}", pacientTalon, wordDocument);
                        ReplaceWordStub("{Doctor}", doctorTalon, wordDocument);
                        ReplaceWordStub("{Spec}", specTalon, wordDocument);
                        ReplaceWordStub("{Date}", dateTalon, wordDocument);
                        ReplaceWordStub("{Time}", timeOfTalon, wordDocument);
                        ReplaceWordStub("{Cab}", cabinetTalon, wordDocument);

                        wordTable = wordDocument.Tables[1];
                        Word.Range cellRange = wordTable.Cell(1, 2).Range;
                        cellRange.InlineShapes.AddPicture(dir, Type.Missing, Type.Missing, Type.Missing);

                        wordApp.Visible = true;
                        File.Delete(dir);
                    }
                    catch
                    {
                        System.Windows.MessageBox.Show("Ошибка создания талона");
                        wordApp.Quit(false);
                    }
                    finally
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                    }

                }

                FamBox.Text = "";
                NameBox.Text = "";
                OtchBox.Text = "";
                dateDay.Text = "";
                TypeTalon.SelectedIndex = -1;
                specBox.SelectedIndex = -1;
                doctorBox.SelectedIndex = -1;
                datePrim.Text = "";
                PhoneBox.Text = "";
                SerialBox.Text = "";
                NumPass.Text = "";
            }
            shadow.Visibility = Visibility.Hidden;
        }

        private void DatePrim_OnCalendarOpened(object sender, RoutedEventArgs e)
        {
            var minDate = datePrim.DisplayDateStart ?? DateTime.MinValue;
            var maxDate = datePrim.DisplayDateEnd ?? DateTime.MaxValue;

            for (var d = minDate; d <= maxDate && DateTime.MaxValue > d; d = d.AddDays(1))
            {
                if (d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday)
                {
                    datePrim.BlackoutDates.Add(new CalendarDateRange(d));
                }
            }
        }

        private void SerialBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            WrongData.Visibility = Visibility.Hidden;
            if (!char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void DatePrim_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RadioButton radioButton;
            int numRadio = 0;
            int numString = 0;

            numString = 0;

            if (datePrim.SelectedDate != null)
            {
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.OpenAsync();
                    var command = new MySqlCommand("SELECT time_start, time_end, price, cabinet FROM doctors WHERE id = " + idDoctor + "", connection);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        price = Convert.ToInt32(reader[2]);
                        cabinet = Convert.ToInt32(reader[3]);
                        int start = Convert.ToInt32(reader[0]);
                        int end = Convert.ToInt32(reader[1]);

                        string min = "00";
                        while (start < end)
                        {
                            //timeStrings[numString] = start + ":" + min; 
                            radioButton = Panel.Children.OfType<RadioButton>().FirstOrDefault(x => x.Name == "Time" + numString);
                            radioButton.Visibility = Visibility.Visible;
                            radioButton.Content = start + ":" + min;

                            numString++;
                            if (min == "30")
                            {
                                min = "00";
                                start++;
                            }
                            else
                            {
                                min = "30";
                            }
                        }

                    }
                    ActualPrice(price);
                    reader.Close();
                    connection.Close();
                }
            }





            while (numRadio != 19)
            {
                radioButton = Panel.Children.OfType<RadioButton>().FirstOrDefault(x => x.Name == "Time" + numRadio);
                if (!radioButton.IsEnabled)
                {
                    radioButton.IsEnabled = true;
                }
                numRadio++;
            }
            string[] datt = datePrim.SelectedDate.ToString().Split(' ');
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.OpenAsync();
                var command = new MySqlCommand("SELECT time FROM talons WHERE date = '" + datt[0] + "' AND cancel=0 AND id_doctor = '"+ idDoctor +"'", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    numRadio = 0;
                    while (numRadio != 19)
                    {
                        radioButton = Panel.Children.OfType<RadioButton>().FirstOrDefault(x => x.Name == "Time" + numRadio);
                        if (radioButton.Content.ToString() == reader[0].ToString())
                        {
                            radioButton.IsEnabled = false;
                            radioButton.IsChecked = false;
                        }
                        numRadio++;
                    }

                }
                reader.Close();
                connection.Close();

                if (datePrim.SelectedDate == DateTime.Today)
                {
                    numRadio = 0;
                    while (numRadio != 19)
                    {
                        radioButton = Panel.Children.OfType<RadioButton>()
                            .FirstOrDefault(x => x.Name == "Time" + numRadio);
                        if (Convert.ToInt32(radioButton.Content.ToString().Split(':')[0]) < DateTime.Now.Hour)
                        {
                            radioButton.IsEnabled = false;
                            radioButton.IsChecked = false;
                        }

                        numRadio++;
                    }
                }
            }
        }

        private void Time0_OnChecked(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            timeTalon = radio.Content.ToString();
        }

        private void PhoneBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void PhoneBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }

        private void FamBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text, 0)) e.Handled = true;
            if (badsym.Contains(e.Text)) e.Handled = true;
        }

        private void SerialBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            sale = false;
            ActualPrice(price);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        private void PaintGrid(DataTable dt, int state)
        {
            switch (state)
            {
                case 0:
                    dt.Columns[2].ColumnName = "Дата и время";
                    dataWork.ItemsSource = dt.DefaultView;

                    dataWork.Columns[0].Visibility = Visibility.Hidden;
                    dataWork.Columns[4].Visibility = Visibility.Hidden;
                    dataWork.Columns[5].Visibility = Visibility.Hidden;
                    dataWork.Columns[6].Visibility = Visibility.Hidden;
                    dataWork.Columns[7].Visibility = Visibility.Hidden;
                    dataWork.Columns[8].Visibility = Visibility.Hidden;
                    dataWork.Columns[9].Visibility = Visibility.Hidden;
                    dataWork.Columns[10].Visibility = Visibility.Hidden;
                    break;
                case 1:
                    if (dt.Rows.Count == 0)
                    {
                        dt.Columns[1].ColumnName = "Данный пациент не записан, не на один прием!";
                        dt.Columns.RemoveAt(2);

                        ClientDataTalonGrid.ItemsSource = dt.DefaultView;

                        ClientDataTalonGrid.Columns[0].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[2].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[3].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[4].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[5].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[6].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[7].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[8].Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        dt.Columns[1].ColumnName = "Дата и время";
                        ClientDataTalonGrid.ItemsSource = dt.DefaultView;

                        ClientDataTalonGrid.Columns[0].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[3].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[4].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[5].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[6].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[7].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[8].Visibility = Visibility.Hidden;
                        ClientDataTalonGrid.Columns[9].Visibility = Visibility.Hidden;
                    }
                    break;
            }
        }

        private void RePaintTable(int state)
        {
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                if (state == 0)
                {
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                                                                 "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                                                                 "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                                                                 "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                                                                 "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                                                                 "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                                                                 "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer FROM talons WHERE cancel=0", connection);
                    DataTable dataTable = new DataTable();
                    mySqlCommand.ExecuteNonQuery();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(mySqlCommand);
                    dataAdapter.Fill(dataTable);
                    PaintGrid(dataTable, 0);
                } else if (state == 1)
                {
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT talons.id, " +
                                                                 "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                                                                 "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                                                                 "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                                                                 "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                                                                 "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                                                                 "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer FROM talons WHERE id_client = " + _idClientGrid + " AND cancel=0", connection);
                    DataTable dataTable = new DataTable();
                    mySqlCommand.ExecuteNonQuery();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(mySqlCommand);
                    dataAdapter.Fill(dataTable);
                    PaintGrid(dataTable, 1);
                }
                connection.Close();
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new About();
            aboutWindow.Owner = this;
            shadow.Visibility = Visibility.Visible;
            aboutWindow.ShowDialog();
            shadow.Visibility = Visibility.Hidden;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (MainGrid.Visibility == Visibility.Visible) return;
            if (TalonGrid.Visibility == Visibility.Visible)
            {
                TalonGrid.Visibility = Visibility.Hidden;
                MainGridLoad();
                MainGrid.Visibility = Visibility.Visible;
            }
            else if (ClientGrid.Visibility == Visibility.Visible)
            {
                ClientGrid.Visibility = Visibility.Hidden;
                MainGridLoad();
                MainGrid.Visibility = Visibility.Visible;
            }
            else if (DoctorGrid.Visibility == Visibility.Visible)
            {
                DoctorGrid.Visibility = Visibility.Hidden;
                MainGridLoad();
                MainGrid.Visibility = Visibility.Visible;
            }
            else if (UsersGrid.Visibility == Visibility.Visible)
            {
                UsersGrid.Visibility = Visibility.Hidden;
                MainGridLoad();
                MainGrid.Visibility = Visibility.Visible;
            }
            else if (ClientAdminGrid.Visibility == Visibility.Visible)
            {
                ClientAdminGrid.Visibility = Visibility.Hidden;
                MainGridLoad();
                MainGrid.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (ClientGrid.Visibility == Visibility.Visible) return;
            if (TalonGrid.Visibility == Visibility.Visible)
            {
                TalonGrid.Visibility = Visibility.Hidden;
                LoadClientGrid();
                ClientGrid.Visibility = Visibility.Visible;
            }
            else if (MainGrid.Visibility == Visibility.Visible)
            {
                MainGrid.Visibility = Visibility.Hidden;
                LoadClientGrid();
                ClientGrid.Visibility = Visibility.Visible;
            }
        }

        private void TalonButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            { 
                _idClientGrid = Convert.ToInt32(((Button)sender).CommandParameter);
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT talons.id, " +
                        "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                        "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                        "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                        "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                        "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                        "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer FROM talons WHERE id_client = " + _idClientGrid + "", connection);
                    DataTable dataTable = new DataTable();
                    mySqlCommand.ExecuteNonQuery();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(mySqlCommand);
                    mySqlCommand = new MySqlCommand("SELECT concat_ws(' ', fname, name, sname) FROM clients WHERE id=" + _idClientGrid + "", connection);
                    _talonGridName =  mySqlCommand.ExecuteScalar().ToString();
                    ClientNameLabel.Content = "Пациент - " + _talonGridName;
                    dataAdapter.Fill(dataTable);
                    PaintGrid(dataTable, 1);
                    connection.Close();
                }

                GridTalons.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Eer " + ex);
            }
        }

        private void TalonButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                shadow.Visibility = Visibility.Visible;
                int id = Convert.ToInt32(((Button)sender).CommandParameter);
                CustomMessageBox msg = new CustomMessageBox(0, "Подтверждение", "Вы точно хотите отменить запись на прием?");
                msg.Owner = this;
                if (msg.ShowDialog() == true)
                {
                    using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                    {
                        connection.Open();
                        MySqlCommand mySqlCommand = new MySqlCommand("UPDATE talons SET cancel=2 WHERE id=" + id + "", connection);
                        mySqlCommand.ExecuteNonQuery();
                        RePaintTable(1);
                        connection.Close();
                    }
                    snackInfo.MessageQueue.Enqueue("Запись успешно отмененна", null, null, null, false, true, TimeSpan.FromSeconds(2));
                }
                shadow.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Eer " + ex);
            }
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            dataWork.Height = Window.Height - 140;
            ClientDataTalonGrid.Height = Window.Height - 140;
            ClientDataGrid.Height = Window.Height - 140;
            LeftGrid.Width = Window.Width - 200;
            DoctorDataGrid.Height = Window.Height - 140;
            UserDataGrid.Height = Window.Height - 140;
            ClientAdminDataGrid.Height = Window.Height - 140;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                dataWork.Height = Window.ActualHeight - 140;
                ClientDataTalonGrid.Height = Window.ActualHeight - 140;
                ClientDataGrid.Height = Window.ActualHeight - 140;
                LeftGrid.Width = Window.ActualWidth - 200;
                DoctorDataGrid.Height = Window.Height - 140;
                UserDataGrid.Height = Window.Height - 140;
                ClientAdminDataGrid.Height = Window.Height - 140;
            }
        }

        private void TalonWord_OnClick(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandParameter);
            var dataTable = new DataTable();

            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand("SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                                                             "talons.time, talons.date, concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                                                             "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                                                             "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr " +
                                                             "FROM talons WHERE id = "+id+"", connection);
                mySqlCommand.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                dataAdapter.Fill(dataTable);
                connection.Close();
            }

            string numTalon = dataTable.Rows[0].ItemArray.GetValue(0).ToString();
            string pacientTalon = dataTable.Rows[0].ItemArray.GetValue(1).ToString();
            string timeOfTalon = dataTable.Rows[0].ItemArray.GetValue(2).ToString();
            string dateTalon = dataTable.Rows[0].ItemArray.GetValue(3).ToString();
            string doctorTalon = dataTable.Rows[0].ItemArray.GetValue(4).ToString();
            string cabinetTalon = dataTable.Rows[0].ItemArray.GetValue(5).ToString();
            string specTalon = dataTable.Rows[0].ItemArray.GetValue(6).ToString();

            string qrtext = $"Номер талона:{numTalon};Дата:{dateTalon};Время:{timeOfTalon};Кабинет:{cabinetTalon}"; //считываем текст из TextBox'a
            QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
            Bitmap qrcode = encoder.Encode(qrtext, Encoding.UTF8);
            string dir = Directory.GetCurrentDirectory() + "img.jpg";
            Bitmap objBitmap = new Bitmap(qrcode, new Size(100, 100));
            objBitmap.Save(dir, ImageFormat.Jpeg);

            // создаем путь к файлу
            object templatePathObj = _fileName;
            object missingObj = System.Reflection.Missing.Value;


            var wordApp = new Word.Application();
            wordApp.Visible = false;
            Word.Table wordTable;

            try
            {
                var wordDocument = wordApp.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);

                ReplaceWordStub("{Num}", numTalon, wordDocument);
                ReplaceWordStub("{Pacient}", pacientTalon, wordDocument);
                ReplaceWordStub("{Doctor}", doctorTalon, wordDocument);
                ReplaceWordStub("{Spec}", specTalon, wordDocument);
                ReplaceWordStub("{Date}", dateTalon, wordDocument);
                ReplaceWordStub("{Time}", timeOfTalon, wordDocument);
                ReplaceWordStub("{Cab}", cabinetTalon, wordDocument);
                //ReplaceWordStub("{img}", dir, wordDocument);

                //wordDocument.Paragraphs.Add(Type.Missing);
                wordTable = wordDocument.Tables[1];
                Word.Range cellRange = wordTable.Cell(1, 2).Range;
                cellRange.InlineShapes.AddPicture(dir, Type.Missing, Type.Missing, Type.Missing);

                wordApp.Visible = true;
                File.Delete(dir);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Ошибка создания талона " + ex);
                wordApp.Quit(ref missingObj, ref missingObj, ref missingObj);

            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                //wordApp.Quit(false);
            }
        }
        private void ReplaceWordStub(string stubToReplace, object text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_maxWindow)
            {
                Window.WindowState = WindowState.Normal;
                _maxWindow = false;
            }
            else
            {
                Window.WindowState = WindowState.Maximized;
                _maxWindow = true;
            }
        }

        private void FindClientBut_OnClick(object sender, RoutedEventArgs e)
        {
            string find = ClinentFindTextBox.Text;
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand("SELECT id, concat_ws(' ', fname, name, sname) AS ФИО, concat_ws('.', day_bd, month_bd, year_bd) AS dt, telephone, serial_pass AS sera, num_pass AS numa FROM clients WHERE concat_ws(' ', fname, name, sname) LIKE '%" + find+ "%' OR serial_pass LIKE '%" + find + "%' OR num_pass LIKE '%" + find + "%'", connection);
                var dataTable = new DataTable();
                mySqlCommand.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                dataAdapter.Fill(dataTable);
                dataTable.Columns[4].ColumnName = "Серия паспорта";
                dataTable.Columns[5].ColumnName = "Номер паспорта";
                ClientDataGrid.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }
            ClientDataGrid.Columns[0].Visibility = Visibility.Hidden;
            ClientDataGrid.Columns[3].Visibility = Visibility.Hidden;
            ClientDataGrid.Columns[2].Visibility = Visibility.Hidden;
        }

        private void TalonWordGrid_OnClick(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandParameter);
            var dataTable = new DataTable();

            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand("SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО, " +
                                                             "talons.time, talons.date, concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                                                             "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                                                             "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr " +
                                                             "FROM talons WHERE id = " + id + "", connection);
                mySqlCommand.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                dataAdapter.Fill(dataTable);
                connection.Close();
            }

            string numTalon = dataTable.Rows[0].ItemArray.GetValue(0).ToString();
            string pacientTalon = dataTable.Rows[0].ItemArray.GetValue(1).ToString();
            string timeOfTalon = dataTable.Rows[0].ItemArray.GetValue(2).ToString();
            string dateTalon = dataTable.Rows[0].ItemArray.GetValue(3).ToString();
            string doctorTalon = dataTable.Rows[0].ItemArray.GetValue(4).ToString();
            string cabinetTalon = dataTable.Rows[0].ItemArray.GetValue(5).ToString();
            string specTalon = dataTable.Rows[0].ItemArray.GetValue(6).ToString();

            string qrtext = $"Номер талона:{numTalon};Дата:{dateTalon};Время:{timeOfTalon};Кабинет:{cabinetTalon}"; //считываем текст из TextBox'a
            QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
            Bitmap qrcode = encoder.Encode(qrtext, Encoding.UTF8);
            string dir = Directory.GetCurrentDirectory() + "img.jpg";
            Bitmap objBitmap = new Bitmap(qrcode, new Size(100, 100));
            objBitmap.Save(dir, ImageFormat.Jpeg);

            // создаем путь к файлу
            object templatePathObj = _fileName;
            object missingObj = System.Reflection.Missing.Value;


            var wordApp = new Word.Application();
            wordApp.Visible = false;
            Word.Table wordTable;

            try
            {
                var wordDocument = wordApp.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);

                ReplaceWordStub("{Num}", numTalon, wordDocument);
                ReplaceWordStub("{Pacient}", pacientTalon, wordDocument);
                ReplaceWordStub("{Doctor}", doctorTalon, wordDocument);
                ReplaceWordStub("{Spec}", specTalon, wordDocument);
                ReplaceWordStub("{Date}", dateTalon, wordDocument);
                ReplaceWordStub("{Time}", timeOfTalon, wordDocument);
                ReplaceWordStub("{Cab}", cabinetTalon, wordDocument);
                //ReplaceWordStub("{img}", dir, wordDocument);

                //wordDocument.Paragraphs.Add(Type.Missing);
                wordTable = wordDocument.Tables[1];
                Word.Range cellRange = wordTable.Cell(1, 2).Range;
                cellRange.InlineShapes.AddPicture(dir, Type.Missing, Type.Missing, Type.Missing);

                wordApp.Visible = true;
                File.Delete(dir);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Ошибка создания талона " + ex);
                wordApp.Quit(ref missingObj, ref missingObj, ref missingObj);

            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                //wordApp.Quit(false);
            }
        }

        private void DoctorGrid_OnClick(object sender, RoutedEventArgs e)
        {
            if (DoctorGrid.Visibility == Visibility.Visible) return;
            if (MainGrid.Visibility == Visibility.Visible)
            {
                MainGrid.Visibility = Visibility.Hidden;
                UpdateDoctorGrid();
                DoctorGrid.Visibility = Visibility.Visible;
            } 
            else if (UsersGrid.Visibility == Visibility.Visible)
            {
                UsersGrid.Visibility = Visibility.Hidden;
                UpdateDoctorGrid();
                DoctorGrid.Visibility = Visibility.Visible;
            }
            else if (ClientAdminGrid.Visibility == Visibility.Visible)
            {
                ClientAdminGrid.Visibility = Visibility.Hidden;
                UpdateDoctorGrid();
                DoctorGrid.Visibility = Visibility.Visible;
            }
        }

        public void UpdateDoctorGrid()
        {
            DoctorDataGrid.Height = Window.Height - 140;
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand("SELECT id, concat_ws(' ', fname, name, sname) AS ФИО, (SELECT spec FROM special WHERE doctors.spec = special.id) AS speciality, concat_ws(' ', price, 'руб'), concat_ws(':', time_start, '00') AS timeStart, concat_ws(':', time_end, '00') AS timeEnd, cabinet AS cabin FROM doctors", connection);
                var dataTable = new DataTable();
                mySqlCommand.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                dataAdapter.Fill(dataTable);
                dataTable.Columns[2].ColumnName = "Направление";
                dataTable.Columns[3].ColumnName = "Цена приема";
                DoctorDataGrid.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }
            DoctorDataGrid.Columns[0].Visibility = Visibility.Hidden;
            DoctorDataGrid.Columns[4].Visibility = Visibility.Hidden;
            DoctorDataGrid.Columns[5].Visibility = Visibility.Hidden;
            DoctorDataGrid.Columns[6].Visibility = Visibility.Hidden;
        }

        private void TalonGridTwoFind_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string find = ClinentFindTalonTextBox.Text;
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT talons.id, " +
                                                                 "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                                                                 "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                                                                 "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                                                                 "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                                                                 "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                                                                 "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer FROM talons WHERE id_client = " + _idClientGrid + " " +
                                                                 "AND concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) LIKE '%"+find+"%'", connection);
                    DataTable dataTable = new DataTable();
                    mySqlCommand.ExecuteNonQuery();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(mySqlCommand);
                    dataAdapter.Fill(dataTable);
                    PaintGrid(dataTable, 1);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("eerr" + ex);
            }
        }

        private void AddDoctor_OnClick(object sender, RoutedEventArgs e)
        {
            AddDoctorDialog addDoctorDialog = new AddDoctorDialog(0);
            addDoctorDialog.Owner = this;

            shadow.Visibility = Visibility.Visible;
            if (addDoctorDialog.ShowDialog() == true)
            {
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO doctors (fname, name, sname, spec, price, time_start, time_end, cabinet) VALUES ('"+addDoctorDialog.FamilyDoctor+"', '"+addDoctorDialog.NamDoctor+"', '"+addDoctorDialog.SnamDoctor+"', "+addDoctorDialog.SpecDoctor+", "+addDoctorDialog.PriceDoctor+", "+addDoctorDialog.StartTimePriem+", "+addDoctorDialog.EndTimePriem+", "+addDoctorDialog.CabDoctor+")", connection);
                    mySqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                UpdateDoctorGrid();
                snackInfo.MessageQueue.Enqueue($@"Врач '{addDoctorDialog.FamilyDoctor} {addDoctorDialog.NamDoctor} {addDoctorDialog.SnamDoctor}' успешно добавлен в базу!", null, null, null, false, true, TimeSpan.FromSeconds(5));
            }
            shadow.Visibility = Visibility.Hidden;
        }

        private void DeleteDoctor_OnClick(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(((Button) sender).CommandParameter);

            CustomMessageBox msg = new CustomMessageBox(0, "Подтверждение", "Вы точно хотите удалить врача и связанные с ним записи из базы?");
            msg.Owner = this;

            shadow.Visibility = Visibility.Visible;
            if (msg.ShowDialog() == true)
            {
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM doctors WHERE id = "+id+"", connection);
                    mySqlCommand.ExecuteNonQuery();
                    mySqlCommand = new MySqlCommand("DELETE FROM talons WHERE id_doctor = " + id + "", connection);
                    mySqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                UpdateDoctorGrid();
                snackInfo.MessageQueue.Enqueue("Врач удален из базы!", null, null, null, false, true, TimeSpan.FromSeconds(3.5));
            }
            shadow.Visibility = Visibility.Hidden;
        }

        private void EditDoctor_OnClick(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(((Button) sender).CommandParameter);

            AddDoctorDialog addDoctorDialog = new AddDoctorDialog(1)
            {
                Owner = this
            };

            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM doctors WHERE id="+id+"", connection);
                var reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    addDoctorDialog.FamDoctor.Text = (string)reader[1];
                    addDoctorDialog.NameDoctor.Text = (string)reader[2];
                    addDoctorDialog.SenDoctor.Text = (string)reader[3];
                    addDoctorDialog.SpecDoctorBox.SelectedValue = (int)reader[4];
                    addDoctorDialog.Price.Text = reader[5].ToString();
                    addDoctorDialog.StartTime.Text = reader[6].ToString();
                    addDoctorDialog.EndTime.Text = reader[7].ToString();
                    addDoctorDialog.CabFas.Text = reader[8].ToString();
                }
                connection.Close();
            }

            shadow.Visibility = Visibility.Visible;
            if (addDoctorDialog.ShowDialog() == true)
            {
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand($"UPDATE doctors SET fname='{addDoctorDialog.FamilyDoctor}', name='{addDoctorDialog.NamDoctor}', sname='{addDoctorDialog.SnamDoctor}', spec={addDoctorDialog.SpecDoctor}, price={addDoctorDialog.PriceDoctor}, time_start={addDoctorDialog.StartTimePriem}, time_end={addDoctorDialog.EndTimePriem}, cabinet={addDoctorDialog.CabDoctor} WHERE id={id}",
                        connection);
                    mySqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                UpdateDoctorGrid();
                snackInfo.MessageQueue.Enqueue($"Изменения врача '{addDoctorDialog.FamilyDoctor} {addDoctorDialog.NamDoctor} {addDoctorDialog.SnamDoctor}' успешно примененны!", null, null, null, false, true, TimeSpan.FromSeconds(4));
            }
            shadow.Visibility = Visibility.Hidden;
        }

        private void UserBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.Visibility == Visibility.Visible) return;
            if (MainGrid.Visibility == Visibility.Visible)
            {
                MainGrid.Visibility = Visibility.Hidden;
                UpdateUsersGrid();
                UsersGrid.Visibility = Visibility.Visible;
            }
            else if (DoctorGrid.Visibility == Visibility.Visible)
            {
                DoctorGrid.Visibility = Visibility.Hidden;
                UpdateUsersGrid();
                UsersGrid.Visibility = Visibility.Visible;
            }
            else if (ClientAdminGrid.Visibility == Visibility.Visible)
            {
                ClientAdminGrid.Visibility = Visibility.Hidden;
                UpdateUsersGrid();
                UsersGrid.Visibility = Visibility.Visible;
            }

        }

        private void UpdateUsersGrid()
        {
            UserDataGrid.Height = Window.Height - 140;
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand("SELECT id, username, login, status, last_enter FROM users", connection);
                var dataTable = new DataTable();
                mySqlCommand.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                dataAdapter.Fill(dataTable);
                dataTable.Columns[1].ColumnName = "Имя пользователя";
                dataTable.Columns[2].ColumnName = "Логин";
                dataTable.Columns[3].ColumnName = "Статус";
                dataTable.Columns[4].ColumnName = "Время последнего входа";
                UserDataGrid.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }
            UserDataGrid.Columns[0].Visibility = Visibility.Hidden;
        }


        private void AddUser_OnClick(object sender, RoutedEventArgs e)
        {
            UserAdd userAdd = new UserAdd(0)
            {
                Owner = this
            };

            shadow.Visibility = Visibility.Visible;
            if (userAdd.ShowDialog() == true)
            {
                string hashPass = Helper.GeneratedHashString(userAdd.UserPassword);
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    var mySqlCommand = new MySqlCommand($"INSERT INTO users (login, username, password, status, last_enter) VALUES ('{userAdd.UserLogin}', '{userAdd.UserName}', '{hashPass}', '{userAdd.Status}', '{DateTime.Today}')", connection);
                    mySqlCommand.ExecuteNonQuery();
                    connection.Close();
                }

                UpdateUsersGrid();
                snackInfo.MessageQueue.Enqueue($"Новый пользователь '{userAdd.UserName}' успешно добавлен в базу!", null, null, null, false, true, TimeSpan.FromSeconds(4));
            } 
            shadow.Visibility = Visibility.Hidden;
        }

        private void DeleteUser_OnClick(object sender, RoutedEventArgs e)
        {
            int currentId = Convert.ToInt32(((Button) sender).CommandParameter);
            CustomMessageBox msg = new CustomMessageBox(0, "Подтверждение", "Вы точно хотите удалить пользователя из базы?")
            {
                Owner = this
            };

            shadow.Visibility = Visibility.Visible;
            if (msg.ShowDialog() == true)
            {
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    var mySqlCommand = new MySqlCommand($"DELETE FROM users WHERE id={currentId}", connection);
                    mySqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                UpdateUsersGrid();
                snackInfo.MessageQueue.Enqueue("Пользователь успешно удален из базы!", null, null, null, false, true, TimeSpan.FromSeconds(3));
            }
            shadow.Visibility = Visibility.Hidden;
        }

        private void EditUser_OnClick(object sender, RoutedEventArgs e)
        {
            int currentId = Convert.ToInt32(((Button) sender).CommandParameter);
            UserAdd user = new UserAdd(1)
            {
                Owner = this
            };
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand($"SELECT login, username, status FROM users WHERE id={currentId}", connection);
                var reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    user.currentLogin = (string)reader[0];
                    user.LoginUser.Text = (string) reader[0];
                    user.UsernameBox.Text = (string) reader[1];
                    if (reader[2].ToString() == "Администратор")
                        user.StatusBox.SelectedIndex = 1;
                    else
                        user.StatusBox.SelectedIndex = 0;
                }
                reader.Close();
                connection.Close();
            }

            shadow.Visibility = Visibility.Visible;
            if (user.ShowDialog() == true)
            {
                string sql;
                if (user.UserPassword == "")
                {
                    sql = $"UPDATE users SET login='{user.UserLogin}', username='{user.UserName}', status='{user.Status}' WHERE id={currentId}";
                }
                else
                {
                    string hashPass = Helper.GeneratedHashString(user.UserPassword);
                    sql = $"UPDATE users SET login='{user.UserLogin}', username='{user.UserName}', status='{user.Status}', password='{hashPass}' WHERE id={currentId}";
                }

                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    var mySqlCommand = new MySqlCommand(sql, connection);
                    mySqlCommand.ExecuteNonQuery();
                    connection.Close();
                }

                UpdateUsersGrid();
                snackInfo.MessageQueue.Enqueue($"Данные пользователя '{user.UserName}' успешно обновленны", null, null, null, false, true, TimeSpan.FromSeconds(4));
            }
            shadow.Visibility = Visibility.Hidden;
        }

        public void UpdateAdminClientsGrid()
        {
            ClientAdminDataGrid.Height = Window.Height - 140;
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand("SELECT id, concat_ws(' ', fname, name, sname) AS ФИО, concat_ws('.', day_bd, month_bd, year_bd) AS dt, telephone, serial_pass AS sera, num_pass AS numa FROM clients", connection);
                var dataTable = new DataTable();
                mySqlCommand.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                dataAdapter.Fill(dataTable);
                dataTable.Columns[4].ColumnName = "Серия паспорта";
                dataTable.Columns[5].ColumnName = "Номер паспорта";
                ClientAdminDataGrid.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }
            ClientAdminDataGrid.Columns[0].Visibility = Visibility.Hidden;
            ClientAdminDataGrid.Columns[3].Visibility = Visibility.Hidden;
            ClientAdminDataGrid.Columns[2].Visibility = Visibility.Hidden;
        }

        private void AdminClients_OnClick(object sender, RoutedEventArgs e)
        {
            if (ClientAdminGrid.Visibility == Visibility.Visible) return;
            if (MainGrid.Visibility == Visibility.Visible)
            {
                MainGrid.Visibility = Visibility.Hidden;
                UpdateAdminClientsGrid();
                ClientAdminGrid.Visibility = Visibility.Visible;
            }
            else if (DoctorGrid.Visibility == Visibility.Visible)
            {
                DoctorGrid.Visibility = Visibility.Hidden;
                UpdateAdminClientsGrid();
                ClientAdminGrid.Visibility = Visibility.Visible;
            }
            else if (UsersGrid.Visibility == Visibility.Visible)
            {
                UsersGrid.Visibility = Visibility.Hidden;
                UpdateAdminClientsGrid();
                ClientAdminGrid.Visibility = Visibility.Visible;
            }
        }

        private void DeleteClient_OnClick(object sender, RoutedEventArgs e)
        {
            int selectId = Convert.ToInt32(((Button) sender).CommandParameter);

            CustomMessageBox msg = new CustomMessageBox(0, "Подтверждение", "Вы точно хотите удалить пациента и все его записи из базы?")
            {
                Owner = this
            };

            shadow.Visibility = Visibility.Visible;
            if (msg.ShowDialog() == true)
            {
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    var mySqlCommand = new MySqlCommand($"DELETE FROM clients WHERE id={selectId}", connection);
                    mySqlCommand.ExecuteNonQuery();
                    mySqlCommand = new MySqlCommand($"DELETE FROM talons WHERE id_client={selectId}", connection);
                    mySqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                UpdateAdminClientsGrid();
                snackInfo.MessageQueue.Enqueue("Все данные связанные с клиентом успешно удаленны!", null, null, null, false, true, TimeSpan.FromSeconds(4));
            }
            shadow.Visibility = Visibility.Hidden;
        }

        private void Settings_OnClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow()
            {
                Owner = this
            };

            shadow.Visibility = Visibility.Visible;
            if (settings.ShowDialog() == false)
            {
                GC.Collect();
            }
            shadow.Visibility = Visibility.Hidden;
        }


        private void AddClient_OnClick(object sender, RoutedEventArgs e)
        {
            AddClient client = new AddClient(0)
            {
                Owner = this
            };

            shadow.Visibility = Visibility.Visible;
            if (client.ShowDialog() == true)
            {
                using(connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    var mySqlCommand = new MySqlCommand($"INSERT INTO clients (fname, name, sname, day_bd, month_bd, year_bd, telephone, serial_pass, num_pass) VALUES " +
                        $"('{client.FamilyClient}', '{client.NamClient}', '{client.SerName}', {client.Date.Split('.')[0]}, {client.Date.Split('.')[1]}, {client.Date.Split('.')[2]}, '{client.Phone}', {client.Serial}, {client.Num})", connection);
                    mySqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                UpdateAdminClientsGrid();
                snackInfo.MessageQueue.Enqueue($"Клиент '{client.FamilyClient} {client.NamClient} {client.SerName}' успешно добавлен базу данных", null, null, null, false, true, TimeSpan.FromSeconds(4));
            }
            shadow.Visibility = Visibility.Hidden;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            int currentId = (int)(((Button)sender).CommandParameter);

            AddClient client = new AddClient(1)
            {
                Owner = this
            };

            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand($"SELECT fname, name, sname, concat_ws('.', day_bd, month_bd, year_bd), telephone, serial_pass, num_pass FROM clients WHERE id={currentId}", connection);
                var reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    client.FamClient.Text = (string)reader[0];
                    client.NameClient.Text = (string)reader[1];
                    client.SnameClient.Text = (string)reader[2];
                    client.DateDay.SelectedDate = DateTime.Parse((string)reader[3]);
                    client.PhoneBox.Text = (string)reader[4];
                    client.SerialPass.Text = reader[5].ToString();
                    client.NumPass.Text = reader[6].ToString();
                }
                connection.Close();
            }

            shadow.Visibility = Visibility.Visible;
            if(client.ShowDialog() == true)
            {

                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    var mySqlCommand = new MySqlCommand($"UPDATE clients SET fname='{client.FamilyClient}', name='{client.NamClient}', sname='{client.SerName}', telephone='{client.Phone}', day_bd={client.Date.Split('.')[0]}, month_bd={client.Date.Split('.')[1]}, year_bd={client.Date.Split('.')[2]}, serial_pass={client.Serial}, num_pass={client.Num} WHERE id={currentId}", connection);
                    mySqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                UpdateAdminClientsGrid();
                snackInfo.MessageQueue.Enqueue($"Данные клиента '{client.FamilyClient} {client.NamClient} {client.SerName}' успешно обновлены", null, null, null, false, true, TimeSpan.FromSeconds(4));
            }
            shadow.Visibility = Visibility.Hidden;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            StatistDialog statistDialog = new StatistDialog()
            {
                Owner = this
            };

            shadow.Visibility = Visibility.Visible;
            statistDialog.ShowDialog();
            shadow.Visibility = Visibility.Hidden;

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            int curId = Convert.ToInt32(((Button)sender).CommandParameter);
            CustomMessageBox msg = new CustomMessageBox(0, "Подтверждение", "Вы хотите завершить прием и оформить договор?")
            {
                Owner = this
            };

            shadow.Visibility = Visibility.Visible;
            if(msg.ShowDialog() == true)
            {
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    var mySqlCommand = new MySqlCommand($"UPDATE talons SET cancel=1 WHERE id={curId}", connection);
                    mySqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                MainGridLoad();

                var dataTable = new DataTable();

                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    var mySqlCommand = new MySqlCommand("SELECT talons.id, concat_ws(' ', (SELECT fname FROM clients WHERE talons.id_client = clients.id), (SELECT name FROM clients WHERE talons.id_client = clients.id), (SELECT sname FROM clients WHERE talons.id_client = clients.id)) AS ФИО FROM talons WHERE id = " + curId + "", connection);
                    mySqlCommand.ExecuteNonQuery();
                    var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                    dataAdapter.Fill(dataTable);
                    connection.Close();
                }

                string numTalon = dataTable.Rows[0].ItemArray.GetValue(0).ToString();
                string clientName = dataTable.Rows[0].ItemArray.GetValue(1).ToString();

                //string clientName2 = clientName.Split(' ')[0] + " " + clientName.Split(' ')[1][0] + "." + clientName.Split(' ')[2][0];

                // создаем путь к файлу
                object templatePathObj = _contractName;
                object missingObj = System.Reflection.Missing.Value;


                var wordApp = new Word.Application();
                wordApp.Visible = false;
                //Word.Table wordTable;

                string year = ""+ DateTime.Now.Year.ToString()[2] + DateTime.Now.Year.ToString()[3];

                try
                {
                    var wordDocument = wordApp.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);

                    ReplaceWordStub("{Num}", numTalon, wordDocument);
                    ReplaceWordStub("{ClientName}", clientName, wordDocument);
                    ReplaceWordStub("{Nd}", DateTime.Now.Day, wordDocument);
                    ReplaceWordStub("{NM}", DateTime.Now.Month, wordDocument);
                    ReplaceWordStub("{NY}", year, wordDocument);

                    wordApp.Visible = true;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Ошибка создания талона " + ex);
                    wordApp.Quit(ref missingObj, ref missingObj, ref missingObj);

                }
                finally
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                    //wordApp.Quit(false);
                }


                snackInfo.MessageQueue.Enqueue($"Прием успешно завершен!", null, null, null, false, true, TimeSpan.FromSeconds(2));
            }
            shadow.Visibility = Visibility.Hidden;
        }

        private void FindDoctorBut_Click(object sender, RoutedEventArgs e)
        {
            string find = DocotorFindTextBox.Text;
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand($"SELECT id, concat_ws(' ', fname, name, sname) AS ФИО, (SELECT spec FROM special WHERE doctors.spec = special.id) AS speciality, concat_ws(' ', price, 'руб'), concat_ws(':', time_start, '00') AS timeStart, concat_ws(':', time_end, '00') AS timeEnd, cabinet AS cabin FROM doctors WHERE concat_ws(' ', fname, name, sname) LIKE '%{find}%' OR (SELECT spec FROM special WHERE doctors.spec = special.id) LIKE '%{find}%'", connection);
                var dataTable = new DataTable();
                mySqlCommand.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                dataAdapter.Fill(dataTable);
                dataTable.Columns[2].ColumnName = "Направление";
                dataTable.Columns[3].ColumnName = "Цена приема";
                DoctorDataGrid.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }
            DoctorDataGrid.Columns[0].Visibility = Visibility.Hidden;
            DoctorDataGrid.Columns[4].Visibility = Visibility.Hidden;
            DoctorDataGrid.Columns[5].Visibility = Visibility.Hidden;
            DoctorDataGrid.Columns[6].Visibility = Visibility.Hidden;

        }

        private void FindAdminClientBut_Click(object sender, RoutedEventArgs e)
        {
            string find = ClinentAdminFindTextBox.Text;
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand("SELECT id, concat_ws(' ', fname, name, sname) AS ФИО, concat_ws('.', day_bd, month_bd, year_bd) AS dt, telephone, serial_pass AS sera, num_pass AS numa FROM clients WHERE concat_ws(' ', fname, name, sname) LIKE '%" + find + "%' OR serial_pass LIKE '%" + find + "%' OR num_pass LIKE '%" + find + "%'", connection);
                var dataTable = new DataTable();
                mySqlCommand.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                dataAdapter.Fill(dataTable);
                dataTable.Columns[4].ColumnName = "Серия паспорта";
                dataTable.Columns[5].ColumnName = "Номер паспорта";
                ClientAdminDataGrid.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }
            ClientAdminDataGrid.Columns[0].Visibility = Visibility.Hidden;
            ClientAdminDataGrid.Columns[3].Visibility = Visibility.Hidden;
            ClientAdminDataGrid.Columns[2].Visibility = Visibility.Hidden;
        }

        private void UserFindBut_Click(object sender, RoutedEventArgs e)
        {
            string find = UserFindBox.Text;
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                var mySqlCommand = new MySqlCommand($"SELECT id, username, login, status, last_enter FROM users WHERE username LIKE '%{find}%' OR login LIKE '%{find}%'", connection);
                var dataTable = new DataTable();
                mySqlCommand.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mySqlCommand);
                dataAdapter.Fill(dataTable);
                dataTable.Columns[1].ColumnName = "Имя пользователя";
                dataTable.Columns[2].ColumnName = "Логин";
                dataTable.Columns[3].ColumnName = "Статус";
                dataTable.Columns[4].ColumnName = "Время последнего входа";
                UserDataGrid.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }
            UserDataGrid.Columns[0].Visibility = Visibility.Hidden;
        }

        private void findTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Button_Click_3(sender, e);
        }

        private void ClinentFindTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                FindClientBut_OnClick(sender, e);
        }

        private void DocotorFindTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                FindDoctorBut_Click(sender, e);
        }

        private void UserFindBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                UserFindBut_Click(sender, e);
        }

        private void ClinentAdminFindTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                FindAdminClientBut_Click(sender, e);
        }

        private void FamBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void CheckSpec_Click(object sender, RoutedEventArgs e)
        {
            CheckSpec ser = new CheckSpec()
            {
                Owner = this
            };

            shadow.Visibility = Visibility.Visible;
            ser.ShowDialog();
            UpdateDoctorGrid();
            shadow.Visibility = Visibility.Hidden;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            FiltrDialog filtr = new FiltrDialog(fltDat, fltMn, _fValue, fltTime, _fTime)
            {
                Owner = this
            };

            shadow.Visibility = Visibility.Visible;
            filtr.ShowDialog();
            fltDat = filtr.DayFilt;
            fltMn = filtr.MonthFilt;
            fltTime = filtr.TimeFilt;
            _fValue = filtr.CurDate;
            _fTime = filtr.CurTime;

            shadow.Visibility = Visibility.Hidden;
            if(fltDat || fltMn || fltTime)
            {
                WarFilt.Visibility = Visibility.Visible;
            } 
            else
            {
                WarFilt.Visibility = Visibility.Hidden;
            }

            MainGridLoad();
        }

        private void ClientDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)ClientDataGrid.SelectedItems[0];
                _idClientGrid = Convert.ToInt32(row[0]);
                using (connection = new MySqlConnection(_connector.builder.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT talons.id, " +
                        "concat_ws(' ', talons.time, talons.date), concat_ws(' ', (SELECT fname FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT name FROM doctors WHERE talons.id_doctor = doctors.id), (SELECT sname FROM doctors WHERE talons.id_doctor = doctors.id)) AS Врач, " +
                        "(SELECT telephone FROM clients WHERE talons.id_client = clients.id) AS telephone, " +
                        "(SELECT cabinet FROM doctors WHERE talons.id_doctor = doctors.id) AS cab, " +
                        "(SELECT spec FROM special WHERE special.id = (SELECT spec FROM doctors WHERE talons.id_doctor = doctors.id)) AS napr, " +
                        "concat_ws('.', (SELECT day_bd FROM clients WHERE talons.id_client = clients.id), (SELECT month_bd FROM clients WHERE talons.id_client = clients.id), (SELECT year_bd FROM clients WHERE talons.id_client = clients.id)) AS date, " +
                        "talons.disc AS disc, talons.first_osmt AS osmt, talons.price AS pricer FROM talons WHERE id_client = " + _idClientGrid + " AND cancel = 0", connection);
                    DataTable dataTable = new DataTable();
                    mySqlCommand.ExecuteNonQuery();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(mySqlCommand);
                    mySqlCommand = new MySqlCommand("SELECT concat_ws(' ', fname, name, sname) FROM clients WHERE id=" + _idClientGrid + "", connection);
                    _talonGridName = mySqlCommand.ExecuteScalar().ToString();
                    ClientNameLabel.Content = "Записи на прием пациента - " + _talonGridName;
                    dataAdapter.Fill(dataTable);
                    PaintGrid(dataTable, 1);
                    connection.Close();
                }

                GridTalons.Visibility = Visibility.Visible;
            }
            catch
            {
                //System.Windows.MessageBox.Show("Eer " + ex);
            }
        }
    }

    class SpecialSource
    {
        public string Num { get; set; }
        public string Spl { get; set; }
    }
   
    class DoctorSource
    {
        public string Num { get; set; }
        public string Fio { get; set; }
    }
    public class TalonData
    {
        public string Name { get; set; }
        public string FamName { get; set; }
        public string OtchName { get; set; }
        public string DateOfBd { get; set; }
        public string SerialPass { get; set; }
        public string NumPs { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string Napr { get; set; }
        public string Doctor { get; set; }
        public string DateOfTalon { get; set; }
        public string TimeOfTalon { get; set; }
        public bool SaleTalon { get; set; }
        public int PriceTalon { get; set; }
        public int CabinetTalon { get; set; }
        public string SaleText { get; set; }
    }
}
