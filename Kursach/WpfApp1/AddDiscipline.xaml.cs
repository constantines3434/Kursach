using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddDiscipline.xaml
    /// </summary>
    public partial class AddDiscipline : Page
    {
        private string roleUser;
        public AddDiscipline(string roleUser)
        {
            InitializeComponent();
            DataContext = GetDiscipline();
            this.roleUser = roleUser;
        }

        private Disciplines GetDiscipline()
        {
            return new Disciplines
            {
                name_discipline = name_discipline_textbox.Text
            };
        }

        private void But_Click_Save_Discipline(object sender, RoutedEventArgs e)
        {
            var currentDiscipline = GetDiscipline();

            if (string.IsNullOrWhiteSpace(currentDiscipline.name_discipline))
            {
                MessageBox.Show("Корректно напишите название дисциплины");
                return;
            }

            try
            {
                RandomTicketGenerator.GetContext().Disciplines.Add(currentDiscipline);
                RandomTicketGenerator.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void But_Click_Viewing_Table_Data(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewingDisciplineTable(roleUser));
        }
    }
}
