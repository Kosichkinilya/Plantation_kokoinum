using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Plantation_kokoinum
{
    public partial class MainWindow : Window
    {
        public MainWindow(int role)
        {
            InitializeComponent();
            this.Height += 15;
            if (role == 1)
            {
                btnAdd.IsEnabled = false;
                btnEdit.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
        }
        Plantation_DBEntities db = Plantation_DBEntities.GetContext();
        Culture_table tb1 = new Culture_table();
        Districts_table tb2 = new Districts_table();
        Productivity_table tb3 = new Productivity_table();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Culture_tables.Load();
            DataGrid1.ItemsSource = db.Culture_tables.Local.ToBindingList();




            // НЕ ОТОБРАЖАЮТСЯ В ПРОЕКТЕ 
            db.Districts_tables.Load();
            DataGrid2.ItemsSource = db.Districts_tables.Local.ToBindingList();

            db.Productivity_tables.Load();
            DataGrid3.ItemsSource = db.Productivity_tables.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add_Culture_Window add = new Add_Culture_Window();
            add.Show();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                Culture_table row = (Culture_table)DataGrid1.Items[indexRow];
                Data.id = row.Код;
                Edit_Culture_Window f = new Edit_Culture_Window();
                f.ShowDialog();
                DataGrid1.Items.Refresh();
                DataGrid1.Focus();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
            MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Culture_table row = (Culture_table)DataGrid1.SelectedItems[0];
                    db.Culture_tables.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
    }
}
