using _5_prac.poezdaDataSetTableAdapters;
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

namespace _5_prac
{
    /// <summary>
    /// Логика взаимодействия для role.xaml
    /// </summary>
    public partial class role : Window
    {
            rolesTableAdapter roleSS = new rolesTableAdapter();
        public role()
        {
            InitializeComponent();
            roles_grid.ItemsSource = roleSS.GetData();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            object id = (roles_grid.SelectedItem as DataRowView).Row[0];
            roleSS.UpdateQuery(roles_text.Text, (int)id);
            roles_grid.SelectedItem = roleSS.GetData();
            }
            catch (Exception)
            {

                MessageBox.Show("wrong data!");
            }
        }

        private void roles_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var i = roles_grid.SelectedItem as DataRowView;
            if (i != null)
            {
                roles_text.Text = (i).Row[1].ToString();
                
            }
        }

        private void create_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            roleSS.InsertQuery(roles_text.Text);
            roles_grid.ItemsSource = roleSS.GetData();
            }
            catch (Exception)
            {

                MessageBox.Show("wrong data!");
            }
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            var id = (roles_grid.SelectedItem as DataRowView).Row[0];

            roleSS.DeleteQuery((int)id);
            roles_grid.ItemsSource=roleSS.GetData();
            }
            catch (Exception)
            {

                MessageBox.Show("Не выбрана чтрока для удаления");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            admin_window aw = new admin_window();
            aw.Show();
            this.Close();
        }
    }
}
