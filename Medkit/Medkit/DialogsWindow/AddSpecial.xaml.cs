// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Windows;
using System.Windows.Input;

namespace Medkit.DialogsWindow
{
    /// <summary>
    /// Логика взаимодействия для AddSpecial.xaml
    /// </summary>
    public partial class AddSpecial : Window
    {
        private string badsym = "!@#$%^&*()_+-=`~[]{};':,./<>?|\\№";

        public AddSpecial(int state)
        {
            InitializeComponent();
            SpecNameBox.Focus();
            if(state == 1)
            {
                NameBox.Content = "Редактирование специальности";
                AddSpec.Content = "Редактировать";
            }
        }


        public string SpecName { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SpecNameBox.Text == "")
            {
                WarningMsg.Visibility = Visibility.Visible;
                return;
            }
            SpecName = SpecNameBox.Text;
            DialogResult = true;
        }

        private void SpecNameBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (badsym.Contains(e.Text)) e.Handled = true;
            if (char.IsDigit(e.Text, 0)) e.Handled = true;
        }
    }
}
