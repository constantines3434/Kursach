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
    /// Логика взаимодействия для AddDiscipline.xaml
    /// </summary>
    public partial class AddDiscipline : Page
    {
        public AddDiscipline()
        {
            InitializeComponent();
            DataContext = GetDiscipline();
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

            RandomTicketGenerator.GetContext().Disciplines.Add(currentDiscipline);

            try
            {
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
            NavigationService.Navigate(new ViewingDisciplineTable());
        }

        private void But_Click_Save_Question(object sender, RoutedEventArgs e)
        {
            var currentQuest = GetDiscipline();

            if (string.IsNullOrWhiteSpace(currentQuest.name_discipline))
            {
                MessageBox.Show("Корректно напишите вопрос");
                return;
            }

            RandomTicketGenerator.GetContext().Disciplines.Add(currentQuest);

            try
            {
                RandomTicketGenerator.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
