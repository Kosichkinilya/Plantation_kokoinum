﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Plantation_kokoinum
{
    // класс Data, позволяет отображать данные таблицы бд в TextBox при редактирвоании данных в таблице проекта 
    public static class Data
    {
        public static int id { get; set; }
    }

    public partial class Edit_Culture_Window : Window
    {
        public Edit_Culture_Window()
        {
            InitializeComponent();
            this.Height += 25;
        }
        Plantation_DBEntities db = Plantation_DBEntities.GetContext();
        Culture_table tb1 = new Culture_table();

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (tb_id.Text.Length == 0) errors.AppendLine("Введите код");
            if (tb_Name.Text.Length == 0) errors.AppendLine("Введите название культуры");
            if (tb_Fam.Text.Length == 0) errors.AppendLine("Введите название семейства");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            tb1.Код = Convert.ToInt32(tb_id.Text);
            tb1.Название = Convert.ToString(tb_Name.Text);
            tb1.Семейство = Convert.ToString(tb_Fam.Text);

            try
            {
                db.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tb1 = db.Culture_tables.Find(Data.id);
            tb_id.Text = Convert.ToString(tb1.Код);
            tb_Name.Text = tb1.Название;
            tb_Fam.Text = tb1.Семейство;
        }
    }
}
