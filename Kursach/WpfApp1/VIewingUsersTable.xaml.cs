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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для VIewingUsersTable.xaml
    /// </summary>
    public partial class VIewingUsersTable : Page
    {
        public VIewingUsersTable()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e) //страница редактирования
        {
            NavigationService.Navigate(new EditingUser((sender as Button).DataContext as Users));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var userForRemoving = DGridUsers.SelectedItems.Cast<Users>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {userForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    RandomTicketGenerator.GetContext().Users.RemoveRange(userForRemoving);
                    RandomTicketGenerator.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridUsers.ItemsSource = RandomTicketGenerator.GetContext().Users.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }
        /// <summary>
        /// показ изменений в таблице
        /// </summary>
        private void ViewingUsers_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                RandomTicketGenerator.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridUsers.ItemsSource = RandomTicketGenerator.GetContext().Users.ToList();
            }
        }

        private void Form_Ticket_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Choice_admin());
        }

    }
}
