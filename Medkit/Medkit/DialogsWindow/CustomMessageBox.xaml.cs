// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Windows;

namespace Medkit
{
    /// <summary>
    /// Логика взаимодействия для CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        int stats;
        string titl;
        string txt;
        public CustomMessageBox(int state, string title, string text)
        {
            InitializeComponent();
            stats = state;
            titl = title;
            txt = text;
        }

        public void MessageBox()
        {

        }

        private void buttonYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            messageLabel.Content = txt;
            titleLabel.Content = titl;
            switch (stats)
            {
                case 0:
                    buttonYes.Visibility = Visibility.Visible;
                    buttonNo.Visibility = Visibility.Visible;
                    break;
                case 1:
                    buttonOk.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
