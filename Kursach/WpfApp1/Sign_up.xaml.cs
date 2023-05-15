using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    public partial class Sign_up : Page
    {
        RandomTicketGenerator db;

        DataBase database = new DataBase();
        public Sign_up()
        {
            InitializeComponent();
            bindcombo_Users();
            db = new RandomTicketGenerator();
        }

        //ComboBox kurs
        public List<Users> Users_list { get; set; }
        private void bindcombo_Users()
        {
            Role.Items.Add("Admin");
            Role.Items.Add("User");
            Role.SelectedIndex = 0;
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
        /// проверка на наличие пользователя в бд
        /// </summary>
        private Boolean check_user()
        {
            var login = textBox_login.Text;
            var role = Role.Text;
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
        /// регистрация
        /// </summary>
        private void But_registration(object sender, RoutedEventArgs e)
        {
            var login = textBox_login.Text;

            var role = Role.Text;

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
                        if (!check_user())
                        {
                            return;
                        }
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
        /// Переход к авторизации
        /// </summary>
        private void But_authorization(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}


