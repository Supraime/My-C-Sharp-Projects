// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Windows;

namespace Medkit
{
    /// <summary>
    /// Логика взаимодействия для AcceptTalon.xaml
    /// </summary>
    public partial class AcceptTalon : Window
    {
        //private TalonData dater;
        public AcceptTalon(TalonData data)
        {
            InitializeComponent();
            FioPac.Content = data.FamName + " " + data.Name + " " + data.OtchName;
            Type.Content = data.Type;
            Napr.Content = data.Napr;
            Doctor.Content = data.Doctor;
            Dateofpriem.Content = data.DateOfTalon;
            Timeofpriem.Content = data.TimeOfTalon;
            CabPriem.Content = data.CabinetTalon;
            if (data.SaleTalon == true)
            {
                Sale.Content = "3%";
            }

            Price.Content = data.PriceTalon + " руб";
        }

        private void AcceptTalon_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void PrintTalon_OnClick(object sender, RoutedEventArgs e)
        {
            Talon = true;
            this.DialogResult = true;
        }

        public bool Talon
        {
            get;
            private set;
        }
    }
}
