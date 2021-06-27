// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Medkit.DialogsWindow
{
    /// <summary>
    /// Логика взаимодействия для FiltrDialog.xaml
    /// </summary>
    public partial class FiltrDialog : Window
    {
        public bool DayFilt { get; set; }
        public bool MonthFilt { get; set; }
        public bool TimeFilt { get; set; }
        public string CurDate { get; set; }
        public string CurTime { get; set; }
        public FiltrDialog(bool day, bool month, string select, bool tim, string curt)
        {
            InitializeComponent();
            if (day)
            {
                DateCheck.IsChecked = true;
                DateDay.IsEnabled = true;
                DateDay.SelectedDate = DateTime.Parse(select);
            }
            else if (month)
            {
                MonthCheck.IsChecked = true;
                StatusBox.IsEnabled = true;
                switch(select)
                {
                    case ".01.":
                        StatusBox.SelectedIndex = 0;
                        break;
                    case ".02.":
                        StatusBox.SelectedIndex = 1;
                        break;
                    case ".03.":
                        StatusBox.SelectedIndex = 2;
                        break;
                    case ".04.":
                        StatusBox.SelectedIndex = 3;
                        break;
                    case ".05.":
                        StatusBox.SelectedIndex = 4;
                        break;
                    case ".06.":
                        StatusBox.SelectedIndex = 5;
                        break;
                    case ".07.":
                        StatusBox.SelectedIndex = 6;
                        break;
                    case ".08.":
                        StatusBox.SelectedIndex = 7;
                        break;
                    case ".09.":
                        StatusBox.SelectedIndex = 8;
                        break;
                    case ".10.":
                        StatusBox.SelectedIndex = 9;
                        break;
                    case ".11.":
                        StatusBox.SelectedIndex = 10;
                        break;
                    case ".12.":
                        StatusBox.SelectedIndex = 11;
                        break;
                }
            }

            if (tim)
            {
                TimeCheck.IsChecked = true;
                int numString = 0;
                RadioButton radioButton;
                while (numString != 19)
                {
                    radioButton = Panel.Children.OfType<RadioButton>().FirstOrDefault(x => x.Name == "Time" + numString);
                    if (radioButton.Content.ToString() == curt)
                    {
                        radioButton.IsChecked = true;
                        break;
                    }
                    numString++;
                }
            }
        }

        private void DateCheck_Checked(object sender, RoutedEventArgs e)
        {
            MonthCheck.IsChecked = false;
            StatusBox.IsEnabled = false;
            DateDay.IsEnabled = true;
            DayFilt = true;
            MonthFilt = false;
            if(DateDay.SelectedDate == null)
            {
                DateDay.SelectedDate = DateTime.Now;
            }
            CurDate = DateDay.SelectedDate.ToString().Split(' ')[0];
        }

        private void MonthCheck_Checked(object sender, RoutedEventArgs e)
        {
            DateCheck.IsChecked = false;
            StatusBox.IsEnabled = true;
            DateDay.IsEnabled = false;
            DayFilt = false;
            MonthFilt = true;
            StatusBox.SelectedIndex = 0;
            CurDate = GetCurMotnth();
        }

        public string GetCurMotnth()
        {
            string temp = "";
            switch(StatusBox.SelectedIndex)
            {
                case 0:
                    temp = ".01.";
                    break;
                case 1:
                    temp = ".02.";
                    break;
                case 2:
                    temp = ".03.";
                    break;
                case 3:
                    temp = ".04.";
                    break;
                case 4:
                    temp = ".05.";
                    break;
                case 5:
                    temp = ".06.";
                    break;
                case 6:
                    temp = ".07.";
                    break;
                case 7:
                    temp = ".08.";
                    break;
                case 8:
                    temp = ".09.";
                    break;
                case 9:
                    temp = ".10.";
                    break;
                case 10:
                    temp = ".11.";
                    break;
                case 11:
                    temp = ".12.";
                    break;
            }
            return temp;
        }

        private void DateCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            DateDay.IsEnabled = false;
            DayFilt = false;
            DateDay.SelectedDate = null;
        }

        private void MonthCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            StatusBox.IsEnabled = false;
            MonthFilt = false;
            StatusBox.SelectedIndex = -1;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            StatusBox.IsEnabled = false;
            StatusBox.SelectedIndex = -1;
            DateDay.IsEnabled = false;
            DateDay.SelectedDate = null;
            DateCheck.IsChecked = false;
            MonthCheck.IsChecked = false;
            TimeCheck.IsChecked = false;
            MonthFilt = false;
            DayFilt = false;
            TimeFilt = false;
        }

        private void TimeCheck_Checked(object sender, RoutedEventArgs e)
        {
            TimeFilt = true;
            Time0.IsChecked = true;
            CurTime = Time0.Content.ToString();
        }

        private void TimeCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            TimeFilt = false;
            int numString = 0;
            RadioButton radioButton;
            while (numString != 19)
            {
                radioButton = Panel.Children.OfType<RadioButton>().FirstOrDefault(x => x.Name == "Time" + numString);
                if (radioButton.IsChecked == true)
                {
                    radioButton.IsChecked = false;
                    break;
                }
                numString++;
            }
        }

        private void DateDay_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CurDate = DateDay.SelectedDate.ToString().Split(' ')[0];
        }

        private void StatusBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurDate = GetCurMotnth();
        }

        private void Time0_Checked(object sender, RoutedEventArgs e)
        {
            CurTime = ((RadioButton)sender).Content.ToString();
        }
    }
}
