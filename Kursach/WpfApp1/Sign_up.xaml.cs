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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data;
using System.Data.Entity.Infrastructure;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Sign_up.xaml
    /// </summary>
    public partial class Sign_up : Page
    {
        RandomTicketGenerator db;

        DataBase database = new DataBase();
        public Sign_up()
        {
            InitializeComponent();
            db = new RandomTicketGenerator();
        }

        /// <summary>
        /// сокрытие пароля
        /// </summary>
        private void log_in_load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '•';
            textBox_password.MaxLength = 100;
        }
        /// <summary>
        /// регистрация
        /// </summary>
        private void But_registration(object sender, RoutedEventArgs e)
        {
            var login = textBox_login.Text;
            var role = textBox_role.Text;
            var password = textBox_password.Password.ToString();

            if ((login != "") && (role != "") && (password != ""))
            {
                if ((role == "User") || (role == "Admin"))
                {
                    try
                    {
                        if (db.Users.Any(o => o.login_ == login))
                        {
                            throw new Exception("Логин уже занят");
                        }
                        Users newUser = new Users();
                        newUser.login_ = login;
                        newUser.password_ = password;
                        newUser.role_ = role;

                        db.Users.Add(newUser);
                        db.SaveChanges();
                        MessageBox.Show("Регистрация прошла успешно");
                        NavigationService.Navigate(new Authorization());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Неверно указана роль пользователя");
                }
            }
            else MessageBox.Show("Для продолжения заполните все поля");
        }   

        /// <summary>
        /// проверка на наличие пользователя в бд
        /// </summary>
        private Boolean check_user()
        {
            var login = textBox_login.Text;
            var role = textBox_role.Text;
            var password = textBox_password.Password.ToString();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select nom_user, login_, password_, role_ from Users where login_ = '{login}' and role_ = '{role}'";
            //, password_ = '{passUser}
            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует");
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Переход к авторизации
        /// </summary>
        private void But_authorization(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}

   
