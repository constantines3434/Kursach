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
            DataContext = GetDisciplines();
            Bindcombo_disca();
        }

        

        private int GetDisciplineId()
        {
            //return ((Disciplines)Disca.SelectedItem).id_discipline; ошибка
            return 1;
        }

        private Disciplines GetDisciplines()
        {
            return new Disciplines
            {
                id_discipline = int.Parse(id_discipline_textbox.Text),
                name_discipline = name_discipline_textbox.Text,
            };
        }

        private void But_Click_Save_Question(object sender, RoutedEventArgs e)
        {
            var currentQuest = GetDisciplines();

            if (string.IsNullOrWhiteSpace(currentQuest.name_discipline))
            {
                MessageBox.Show("Корректно напишите название дисциплины");
                return;
            }

         //   if (string.IsNullOrWhiteSpace(currentQuest.id_discipline))
           
            {
                MessageBox.Show("Корректно напишите номер дисциплины");
                return;
            }

            RandomTicketGenerator.GetContext().Questions.Add(currentQuest);

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
            NavigationService.Navigate(new ViewingTableData_admin());
        }
    }
}
