using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Plantation_kokoinum
{
    /// <summary>
    /// Логика взаимодействия для Log_in_window.xaml
    /// </summary>
    public partial class Log_in_window : Window
    {
        public Log_in_window()
        {
            InitializeComponent();
            this.Height += 25;
            this.Width += 25;
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "Гость" && tbPassword.Text == "1234")
            {
                MainWindow main = new MainWindow(1);
                main.Show();
                Close();
            }
            else if (tbLogin.Text == "Админ" && tbPassword.Text == "123")
            {
                MainWindow main = new MainWindow(2);
                main.Show();
                Close();
            }
            else if (tbLogin.Text != "Пользователь" && tbPassword.Text != "123" || tbLogin.Text != "Админ" && tbPassword.Text != "1234")
            {
                MessageBox.Show("Логин или пароль неверен");
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
