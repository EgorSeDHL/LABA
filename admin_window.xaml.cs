using System;
using System.Collections.Generic;
using System.Data;
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
using _5_prac.poezdaDataSetTableAdapters;
using MaterialDesignThemes.Wpf;

namespace _5_prac
{
    /// <summary>
    /// Логика взаимодействия для admin_window.xaml
    /// </summary>
    public partial class admin_window : Window
    {
        employeeTableAdapter employee = new employeeTableAdapter();
        rolesTableAdapter role = new rolesTableAdapter();
        public admin_window()
        {
            InitializeComponent();
            combo_box.ItemsSource = role.GetData();
            employee_grid.ItemsSource = employee.GetData();
            combo_box.DisplayMemberPath = "Роль";

        }

        private void create_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(name_box.Text) || String.IsNullOrEmpty(surname_box.Text)||String.IsNullOrEmpty(fathername_box.Text))
                {
                    MessageBox.Show("wrong data");
                }
                else
                {
                var pass = Convert.ToString((employee_grid.SelectedItem as DataRowView).Row[2]);
                object i = (combo_box.SelectedItem as DataRowView).Row[0];
                employee.InsertQuery(login_box.Text, pass, surname_box.Text, fathername_box.Text, combo_box.Text, Convert.ToInt32(i));
                employee_grid.ItemsSource = employee.GetData();
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("wrong data!");
            }
        }
        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var pass = Convert.ToString((employee_grid.SelectedItem as DataRowView).Row[2]);
                var i = (combo_box.SelectedItem as DataRowView).Row[0];
                object id = (employee_grid.SelectedItem as DataRowView).Row[0];
                employee.UpdateQuery(login_box.Text, pass, name_box.Text, surname_box.Text, fathername_box.Text, Convert.ToInt32(i), Convert.ToInt32(id));
                employee_grid.ItemsSource= employee.GetData();
            }
            catch (Exception)
            {

                MessageBox.Show("wrong data!");
            }
        }

        private void employee_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            var i = employee_grid.SelectedItem as DataRowView;
            if (i != null)
            {
                var pass = Convert.ToString((employee_grid.SelectedItem as DataRowView).Row[2]);
                login_box.Text = (i).Row[1].ToString();
                password_box.Text = (i).Row[2].ToString();
                name_box.Text = (i).Row[3].ToString();
                surname_box.Text = (i).Row[4].ToString();
                fathername_box.Text = (i).Row[5].ToString();
                combo_box.Text = (i).Row[6].ToString();

            }

        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var i = (employee_grid.SelectedItem as DataRowView).Row[0];
                employee.DeleteQuery((int)i);
                employee_grid.ItemsSource = employee.GetData();
            }
            catch (Exception)
            {

                MessageBox.Show("Не выбрана строка для удаления");
            }
        }

        private void role_button_Click(object sender, RoutedEventArgs e)
        {
            role role = new role();
            role.Show();
            this.Close();
        }

        private void name_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
