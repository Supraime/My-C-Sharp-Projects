// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Medkit.DialogsWindow
{
    /// <summary>
    /// Логика взаимодействия для StatistDialog.xaml
    /// </summary>
    /// 

    public partial class StatistDialog : Window
    {
        int countCreate = 0;
        int countBad = 0;
        int countCancel = 0;
        int sum = 0;
        int sale = 0;
        int Vsumm = 0;
        string pr;
        string find = ".01.";
        bool mon = false;

        private readonly string _fileName = Directory.GetCurrentDirectory() + @"\template\template.xltx";
        ConnectionBuild _connector = new ConnectionBuild();
        private MySqlConnection connection;

        public StatistDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateDay.SelectedDate = DateTime.Today;
            DateDay.DisplayDateEnd = DateTime.Today;
        }

        private void LoadDay(string date)
        {
            countCreate = 0;
            countBad = 0;
            countCancel = 0;
            sum = 0;
            sale = 0;
            Vsumm = 0;
            RegPriem.Content = countCreate + " " + Helper.GetDeclesion(countCreate, "прием", "приема", "приемов");
            BadPriem.Content = countBad + " " + Helper.GetDeclesion(countBad, "прием", "приема", "приемов");
            CancelPriem.Content = countCancel + " " + Helper.GetDeclesion(countCancel, "прием", "приема", "приемов");
            Sum.Content = sum + " " + Helper.GetDeclesion(sum, "рубль", "рубля", "рублей");
            Vsum.Content = Vsumm + " " + Helper.GetDeclesion(sum, "рубль", "рубля", "рублей");
            Sale.Content = sale + " шт.";

            pr = $"{date}";
            StatusBox.Visibility = Visibility.Hidden;
            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) FROM talons WHERE createdate='{date}'", connection);
                countCreate = Convert.ToInt32(command.ExecuteScalar());
                command = new MySqlCommand($"SELECT COUNT(*) FROM talons WHERE date='{date}' AND cancel=2", connection);
                countBad = Convert.ToInt32(command.ExecuteScalar());
                command = new MySqlCommand($"SELECT COUNT(*) FROM talons WHERE date='{date}' AND cancel=1", connection);
                countCancel = Convert.ToInt32(command.ExecuteScalar());
                command = new MySqlCommand($"SELECT COUNT(*) FROM talons WHERE createdate='{date}' AND disc='3%'", connection);
                sale = Convert.ToInt32(command.ExecuteScalar());
                command = new MySqlCommand($"SELECT SUM(price) FROM talons WHERE date='{date}' AND cancel=1", connection);
                if(command.ExecuteScalar().ToString() != "")
                {
                    sum = Convert.ToInt32(command.ExecuteScalar());
                }
                command = new MySqlCommand($"SELECT SUM(price) FROM talons WHERE date='{date}' AND cancel!=1", connection);
                if (command.ExecuteScalar().ToString() != "")
                {
                    Vsumm = Convert.ToInt32(command.ExecuteScalar());
                }
                RegPriem.Content = countCreate + " " + Helper.GetDeclesion(countCreate, "прием", "приема", "приемов");
                BadPriem.Content = countBad + " " + Helper.GetDeclesion(countBad, "прием", "приема", "приемов");
                CancelPriem.Content = countCancel + " " + Helper.GetDeclesion(countCancel, "прием", "приема", "приемов");
                Sum.Content = sum + " " + Helper.GetDeclesion(sum, "рубль", "рубля", "рублей");
                Vsum.Content = Vsumm + " " + Helper.GetDeclesion(sum, "рубль", "рубля", "рублей");
                Sale.Content = sale + " шт.";
                connection.Close();
            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (mon)
            {
                pr = StatusBox.Text;
            }

            // создаем путь к файлу
            object templatePathObj = _fileName;
            object missingObj = System.Reflection.Missing.Value;


            var wordApp = new Excel.Application();
            wordApp.Visible = false;

            try
            {
                var wordDocument = wordApp.Workbooks.Add(templatePathObj);

                //ReplaceWordStub("{period}", numTicket, wordDocument);
                ReplaceExcelStub("{period}", "{Reg}", "{Bad}", "{Cancel}", "{sum}", "{Vsum}", "{sales}", pr, countCreate.ToString(), countBad.ToString(), countCancel.ToString(), sum.ToString(), Vsumm.ToString(), sale.ToString(), wordDocument);

                wordApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка создания билета " + ex);
                wordApp.Quit();
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            }
        }
        private void ReplaceExcelStub(string stubToReplace, string stubToReplace2, string stubToReplace3, string stubToReplace4, string stubToReplace5, string stubToReplace6, string stubToReplace7, string text, string text2, string text3, string text4, string text5, string text6, string text7, Excel.Workbook excelWorkbook)
        {
            Excel.Sheets excelsheets;
            Excel.Worksheet excelworksheet;
            Excel.Range excelcells;

            excelsheets = excelWorkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
            excelcells = excelworksheet.get_Range("A1", "H9");

            excelcells.Replace(stubToReplace, text);
            excelcells.Replace(stubToReplace2, text2);
            excelcells.Replace(stubToReplace3, text3);
            excelcells.Replace(stubToReplace4, text4);
            excelcells.Replace(stubToReplace5, text5);
            excelcells.Replace(stubToReplace6, text6);
            excelcells.Replace(stubToReplace7, text7);
            //Получаем ссылку на лист 1
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mon = false;
            DateDay.Visibility = Visibility.Hidden;
            LoadWeek();
        }

        private void LoadWeek()
        {
            StatusBox.Visibility = Visibility.Hidden;
            DateTime now = DateTime.Now;
            DateTime currentWeekStart = now.Date.AddDays(1 - (int)now.DayOfWeek);
            DateTime nextWeekStart = currentWeekStart.AddDays(7);
            pr = $"{currentWeekStart.ToShortDateString()}-{nextWeekStart.ToShortDateString()}";
            countCreate = 0;
            countBad = 0;
            countCancel = 0;
            sum = 0;
            sale = 0;
            Vsumm = 0;
            RegPriem.Content = countCreate + " " + Helper.GetDeclesion(countCreate, "прием", "приема", "приемов");
            BadPriem.Content = countBad + " " + Helper.GetDeclesion(countBad, "прием", "приема", "приемов");
            CancelPriem.Content = countCancel + " " + Helper.GetDeclesion(countCancel, "прием", "приема", "приемов");
            Sum.Content = sum + " " + Helper.GetDeclesion(sum, "рубль", "рубля", "рублей");
            Vsum.Content = Vsumm + " " + Helper.GetDeclesion(sum, "рубль", "рубля", "рублей");
            Sale.Content = sale + " шт.";

            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"SELECT * FROM talons", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DateTime cur = DateTime.Parse(reader[3].ToString());
                    DateTime createcur = DateTime.Parse(reader[9].ToString());
                    bool dateTimeIsOnCurrentWeek = cur >= currentWeekStart && cur < nextWeekStart;
                    bool dateTimeIsOnCurrentWeek2 = createcur >= currentWeekStart && createcur < nextWeekStart;
                    if (dateTimeIsOnCurrentWeek)
                    {
                        if(reader[8].ToString() == "1")
                        {
                            countCancel++;
                            sum += Convert.ToInt32(reader[7]);
                        }
                        else
                        {
                            Vsumm += Convert.ToInt32(reader[7]);
                        }
                    }
                    if (dateTimeIsOnCurrentWeek2)
                    {
                        countCreate++;
                        if (reader[8].ToString() == "2")
                        {
                            countBad++;
                        }
                        if(reader[5].ToString() == "3%")
                        {
                            sale++;
                        }
                    }
                }

                RegPriem.Content = countCreate + " " + Helper.GetDeclesion(countCreate, "прием", "приема", "приемов");
                BadPriem.Content = countBad + " " + Helper.GetDeclesion(countBad, "прием", "приема", "приемов");
                CancelPriem.Content = countCancel + " " + Helper.GetDeclesion(countCancel, "прием", "приема", "приемов");
                Sum.Content = sum + " " + Helper.GetDeclesion(sum, "рубль", "рубля", "рублей");
                Vsum.Content = Vsumm + " " + Helper.GetDeclesion(sum, "рубль", "рубля", "рублей");
                Sale.Content = sale + " шт.";
                connection.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mon = false;
            DateDay.Visibility = Visibility.Visible;
            LoadDay(DateDay.SelectedDate.ToString().Split(' ')[0]);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StatusBox.SelectedIndex = 0;
            StatusBox.Visibility = Visibility.Visible;
            DateDay.Visibility = Visibility.Hidden;
            mon = true;
            LoadMonth();
        }

        private void LoadMonth()
        {
            countCreate = 0;
            countBad = 0;
            countCancel = 0;
            sum = 0;
            sale = 0;
            Vsumm = 0;
            RegPriem.Content = countCreate + " " + Helper.GetDeclesion(countCreate, "прием", "приема", "приемов");
            BadPriem.Content = countBad + " " + Helper.GetDeclesion(countBad, "прием", "приема", "приемов");
            CancelPriem.Content = countCancel + " " + Helper.GetDeclesion(countCancel, "прием", "приема", "приемов");
            Sum.Content = sum + " " + Helper.GetDeclesion(sum, "рубль", "рубля", "рублей");
            Vsum.Content = Vsumm + " " + Helper.GetDeclesion(sum, "рубль", "рубля", "рублей");
            Sale.Content = sale + " шт.";
            pr = StatusBox.Text;

            using (connection = new MySqlConnection(_connector.builder.ConnectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) FROM talons WHERE createdate LIKE '%{find}%'", connection);
                countCreate = Convert.ToInt32(command.ExecuteScalar());
                command = new MySqlCommand($"SELECT COUNT(*) FROM talons WHERE createdate LIKE '%{find}%' AND cancel=2", connection);
                countBad = Convert.ToInt32(command.ExecuteScalar());
                command = new MySqlCommand($"SELECT COUNT(*) FROM talons WHERE date LIKE '%{find}%' AND cancel=1", connection);
                countCancel = Convert.ToInt32(command.ExecuteScalar());
                command = new MySqlCommand($"SELECT COUNT(*) FROM talons WHERE createdate LIKE '%{find}%' AND disc='3%'", connection);
                sale = Convert.ToInt32(command.ExecuteScalar());
                command = new MySqlCommand($"SELECT SUM(price) FROM talons WHERE date LIKE '%{find}%' AND cancel=1", connection);
                if (command.ExecuteScalar().ToString() != "")
                {
                    sum = Convert.ToInt32(command.ExecuteScalar());
                }
                command = new MySqlCommand($"SELECT SUM(price) FROM talons WHERE date LIKE '%{find}%' AND cancel!=1", connection);
                if (command.ExecuteScalar().ToString() != "")
                {
                    Vsumm = Convert.ToInt32(command.ExecuteScalar());
                }
                RegPriem.Content = countCreate + " " + Helper.GetDeclesion(countCreate, "прием", "приема", "приемов");
                BadPriem.Content = countBad + " " + Helper.GetDeclesion(countBad, "прием", "приема", "приемов");
                CancelPriem.Content = countCancel + " " + Helper.GetDeclesion(countCancel, "прием", "приема", "приемов");
                Sum.Content = sum + " " + Helper.GetDeclesion(sum, "рубль", "рубля", "рублей");
                Vsum.Content = Vsumm + " " + Helper.GetDeclesion(sum, "рубль", "рубля", "рублей");
                Sale.Content = sale + " шт.";
                connection.Close();
            }
        }

        private void StatusBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int st = Convert.ToInt32(((ComboBoxItem)StatusBox.SelectedItem).Tag);
            if (st < 10)
            {
                find = $".0{st}.";
            }
            else
            {
                find = $".{st}.";
            }
            LoadMonth();
        }

        private void DateDay_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDay(DateDay.SelectedDate.ToString().Split(' ')[0]); 
        }
    }
}
