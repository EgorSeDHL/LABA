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
    /// Логика взаимодействия для depo_window.xaml
    /// </summary>
    public partial class depo_window : Window
    {
        trainTableAdapter train = new trainTableAdapter();
        stationTableAdapter station = new stationTableAdapter();
        routeeTableAdapter routee = new routeeTableAdapter();
        public depo_window()
        {
            InitializeComponent();

            route_grid.ItemsSource = routee.GetData();
            station_grid.ItemsSource = station.GetData();
            depo_grid.ItemsSource = train.GetData();

            route_id.ItemsSource = routee.GetData();
            route_id.DisplayMemberPath = "id";

            start_statinon.ItemsSource = station.GetData();
            start_statinon.DisplayMemberPath = "Название станции";

            end_station.ItemsSource = station.GetData();
            end_station.DisplayMemberPath = "Название станции";
        }




        private void change_button_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                object id = (depo_grid.SelectedItem as DataRowView).Row[0];
                var a = Convert.ToInt32((route_id.SelectedItem as DataRowView).Row[0]);
                train.UpdateQuery(Convert.ToInt32(train_number_box.Text), a, (int)id);
                depo_grid.ItemsSource = train.GetData();

            }
            catch (Exception)
            {
                MessageBox.Show("wrong data!");
            }
        }

        private void change3_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                object id = (station_grid.SelectedItem as DataRowView).Row[0];
                if (id!=null)
                {
                station.UpdateQuery(station_box.Text, city_box.Text, Convert.ToInt32(id));
                station_grid.ItemsSource = station.GetData();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("wrong data!");
            }
        }

        private void update_button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (route_grid.SelectedItem as DataRowView).Row[0];
                var a = Convert.ToInt32((start_statinon.SelectedItem as DataRowView).Row[0]);
                var b = Convert.ToInt32((end_station.SelectedItem as DataRowView).Row[0]);
                routee.UpdateQuery(a,b, (int)id);
                route_grid.ItemsSource = routee.GetData();
            }
            catch (Exception)
            {
                MessageBox.Show("wrong data!");
            }
        }



        private void create_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object i = Convert.ToInt32((route_id.SelectedItem as DataRowView).Row[0]);
                train.InsertQuery(Convert.ToInt32(train_number_box.Text), (int)i);
                depo_grid.ItemsSource = train.GetData();

            }
            catch (Exception)
            {
                MessageBox.Show("wrong data!");
            }
        }

        private void create_button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = (start_statinon.SelectedItem as DataRowView).Row[0];
                var b = (end_station.SelectedItem as DataRowView).Row[0];
                routee.InsertQuery(Convert.ToInt32(a), Convert.ToInt32(b));
                route_grid.ItemsSource = routee.GetData();
            }
            catch (Exception)
            {
                MessageBox.Show("wrong data!");
            }
        }
        private void create_button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                station.InsertQuery(station_box.Text, city_box.Text);
                station_grid.ItemsSource = station.GetData();
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
                var id = (depo_grid.SelectedItem as DataRowView).Row[0];
                train.DeleteQuery((int)id);
                depo_grid.ItemsSource = train.GetData();
            }
            catch (Exception)
            {
                MessageBox.Show("Не выцбрана строка для удаления");
            }
        }


        private void delete_button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (route_grid.SelectedItem as DataRowView != null)
                {
                    var id = (route_grid.SelectedItem as DataRowView).Row[0];
                    routee.DeleteQuery((int)id);
                    route_grid.ItemsSource = routee.GetData();

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Не выцбрана строка для удаления");
            }
        }
        private void delete_button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                station.DeleteQuery(Convert.ToInt32((station_grid.SelectedItem as DataRowView).Row[0]));
                station_grid.ItemsSource = station.GetData();

            }
            catch (Exception)
            {
                MessageBox.Show("Не выцбрана строка для удаления");
            }
        }


        private void train_number_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void route_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var i = route_grid.SelectedItem as DataRowView;
            if (i != null)
            {
                start_statinon.Text = (i).Row[1].ToString();
                end_station.Text = (i).Row[2].ToString();

            }

        }
        private void station_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var i = station_grid.SelectedItem as DataRowView;
            if (i != null)
            {
                station_box.Text = (i).Row[1].ToString();
                city_box.Text = (i).Row[2].ToString();
            }
        }
        private void depo_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var i = depo_grid.SelectedItem as DataRowView;
            if (i != null)
            {

                train_number_box.Text = (i).Row[1].ToString();
                route_id.Text = (i).Row[2].ToString();

            }
        }
    }
}
