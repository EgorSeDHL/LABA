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
using static System.Collections.Specialized.BitVector32;

namespace _5_prac
{
    /// <summary>
    /// Логика взаимодействия для cashier_window.xaml
    /// </summary>
    public partial class cashier_window : Window
    {
        orderrTableAdapter order = new orderrTableAdapter();
        employeeTableAdapter employee = new employeeTableAdapter();
        passangerTableAdapter passanger = new passangerTableAdapter();
        ticketsTableAdapter tickets = new ticketsTableAdapter();
        seatTableAdapter seat = new seatTableAdapter();
        trainTableAdapter train = new trainTableAdapter();
        routeeTableAdapter routee = new routeeTableAdapter();
        public cashier_window()
        {
            InitializeComponent();
            order_grid.ItemsSource = order.GetData();

            seat_grid.ItemsSource = seat.GetData();

            ticket_grid.ItemsSource = tickets.GetData();

            passanger_grid.ItemsSource = passanger.GetData();

            train_id.ItemsSource = train.GetData();
            train_id.DisplayMemberPath = "id";

            passanger_butto.ItemsSource = passanger.GetData();
            passanger_butto.DisplayMemberPath = "Фамилия";
            passanger_butto.SelectedValuePath = "id";

            start_station.ItemsSource = routee.GetData();
            start_station.DisplayMemberPath = "Начальная станция";
            start_station.SelectedValuePath = "id";

            result_box.ItemsSource = order.GetData();
            result_box.DisplayMemberPath = "Итого";
            result_box.SelectedValuePath = "id";

            seat_number.ItemsSource = seat.GetData();
            seat_number.DisplayMemberPath = "Номер места в поезде";
            seat_number.SelectedValuePath = "id";
        }


        private void passanger_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var i = passanger_grid.SelectedItem as DataRowView;
            if (i != null)
            {
                name_box.Text = (i).Row[1].ToString();
                surname_text.Text = (i).Row[2].ToString();
                father_name.Text = (i).Row[3].ToString();
            }
        }

        private void passanger_grid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var i = passanger_grid.SelectedItem as DataRowView;
            if (i != null)
            {
                name_box.Text = (i).Row[1].ToString();
                surname_text.Text = (i).Row[2].ToString();
                father_name.Text = (i).Row[3].ToString();
            }
        }
        private void seat_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var i = seat_grid.SelectedItem as DataRowView;
            if (i != null)
            {
                train_id.Text = (i).Row[1].ToString();
                seat_box.Text = (i).Row[2].ToString();
            }
        }

        private void ticket_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var i = seat_grid.SelectedItem as DataRowView;
            if (i != null)
            {
                seat_box.Text = (i).Row[1].ToString();
            }
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (passanger_grid.SelectedItem as DataRowView).Row[0];
                passanger.UpdateQuery(name_box.Text, surname_text.Text, father_name.Text, (int)id);
                passanger_grid.ItemsSource = passanger.GetData();
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
                object id = (seat_grid.SelectedItem as DataRowView).Row[0];

                int train_ident = Convert.ToInt32((train_id.SelectedItem as DataRowView).Row[0]);
                seat.UpdateQuery(train_ident, Convert.ToInt32(seat_box.Text), (int)id);
                seat_grid.ItemsSource = seat.GetData();
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
                passanger.InsertQuery(name_box.Text, surname_text.Text, father_name.Text);
                passanger_grid.ItemsSource = passanger.GetData();
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
                seat.InsertQuery(Convert.ToInt32(train_id.Text), Convert.ToInt32(seat_box.Text));
                seat_grid.ItemsSource = seat.GetData();

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
                var id = (passanger_grid.SelectedItem as DataRowView).Row[0];
                passanger.DeleteQuery((int)id);
                passanger_grid.ItemsSource = passanger.GetData();

            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка для удаления");
            }
        }
        private void delete_button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = (seat_grid.SelectedItem as DataRowView).Row[0];
                seat.DeleteQuery(Convert.ToInt32(id));
                seat_grid.ItemsSource = seat.GetData();
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка для удаления");
            }
        }

        private void create_button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var b = (passanger_butto.SelectedItem as DataRowView).Row[0];
                var a = Convert.ToInt32((result_box.SelectedItem as DataRowView).Row[0]);
                date_picker.SelectedDate = DateTime.Now;
                order.InsertQuery(Convert.ToDateTime(date_picker.SelectedDate), a, 1, Convert.ToInt32(b));

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
                tickets.InsertQuery(Convert.ToInt32(passanger_butto.SelectedValue), Convert.ToInt32(result_box.SelectedValue), Convert.ToInt32(start_station.SelectedValue), Convert.ToInt32(seat_number.SelectedValue));
                ticket_grid.ItemsSource = tickets.GetData();
            }
            catch (Exception)
            {
                MessageBox.Show("wrong data!");
            }
        }

        private void delete_button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = (order_grid.SelectedItem as DataRowView).Row[0];
                order.DeleteQuery((int)id);
                order_grid.ItemsSource = passanger.GetData();

            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка для удаления");
            }
        }

        private void result_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void delete_button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = (order_grid.SelectedItem as DataRowView).Row[0];
                tickets.DeleteQuery((int)id);
                ticket_grid.ItemsSource = tickets.GetData();

            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка для удаления");
            }
        }
    }
}
