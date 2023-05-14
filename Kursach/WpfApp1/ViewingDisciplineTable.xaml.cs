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
    /// Логика взаимодействия для ViewingDisciplineTable.xaml
    /// </summary>
    public partial class ViewingDisciplineTable : Page
    {
        public ViewingDisciplineTable()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e) //страница редактирования
        {
            NavigationService.Navigate(new EditingDiscipline((sender as Button).DataContext as Disciplines));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) //страница добавления
        {
            NavigationService.Navigate(new AddDiscipline());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var disciplineForRemoving = DGridDiscipline.SelectedItems.Cast<Disciplines>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {disciplineForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    RandomTicketGenerator.GetContext().Disciplines.RemoveRange(disciplineForRemoving);
                    RandomTicketGenerator.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridDiscipline.ItemsSource = RandomTicketGenerator.GetContext().Disciplines.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void ViewingDisciplineTable_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                RandomTicketGenerator.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridDiscipline.ItemsSource = RandomTicketGenerator.GetContext().Disciplines.ToList();
            }
        }

        private void Form_Ticket_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Choice_admin());
        }

        private void Next_Table(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VIewingUsersTable());
        }
    }
}
