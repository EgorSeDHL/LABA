using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _5_prac.poezdaDataSetTableAdapters;

namespace _5_prac
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        employeeTableAdapter employee = new employeeTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void check_button_Click(object sender, RoutedEventArgs e)
        {
            bool tf = true;
            
            var login = employee.GetData().Rows;
            if (String.IsNullOrWhiteSpace(login_box.Text) || String.IsNullOrWhiteSpace(password_box.Password) ) {
                MessageBox.Show("Пустое поле!");  
            }
            else
            {
                for (int i = 0; i < login.Count; i++)
                {
                    if (Convert.ToString(login[i][1]) == login_box.Text && Convert.ToString(login[i][2]) == password_box.Password)
                    {
                        string role = (string)login[i][6];
                        switch (role)
                        {
                            case "Администратор":
                                admin_window admin = new admin_window();
                                this.Close();
                                admin.Show();
                                tf = false;
                                break;
                            case "Кассир":
                                cashier_window cashier = new cashier_window();
                                this.Close();
                                cashier.Show();
                                tf = false;
                                break;
                            case "Начальник депо":
                                depo_window depo = new depo_window();
                                this.Close();
                                depo.Show();
                                tf = false;
                                break;

                        }
                    }

                }if (tf) 
                 { 
                    MessageBox.Show("Неверный логин или пароль");
                 }
                
            }
        }
    }
}
