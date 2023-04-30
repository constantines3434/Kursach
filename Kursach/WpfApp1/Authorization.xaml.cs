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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        RandomTicketGenerator db;
        public Authorization()
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
            textBox_password.MaxLength= 100;
        }
        /// <summary>
        /// авторизация пользователя
        /// </summary>
        private void But_authorization(object sender, RoutedEventArgs e)
        {
           var loginUser = textBox_login.Text;
           var roleUser = textBox_role.Text;
           var passUser = textBox_password.Password.ToString();


            if ((loginUser != "") && (roleUser != "") && (passUser != ""))
            {
                //сверяем введённые данные и данные в бд
                if (db.Users.Any(o => (o.login_ == loginUser) && (o.password_ == passUser) && (o.role_ == roleUser)))
                {
                    MessageBox.Show("Успешная авторизация");
                    NavigationService.Navigate(new Choice());
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            }
            else MessageBox.Show("Для продолжения заполните все поля");            
        }

        private void But_registration(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Sign_up());
        }
    }
}
