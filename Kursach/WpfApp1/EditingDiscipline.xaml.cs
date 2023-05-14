using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для EditingDiscipline
    /// </summary>
    public partial class EditingDiscipline : Page
    {

        private Disciplines _selectedDiscipline;

        public EditingDiscipline(Disciplines selectedDisca)
        {
            InitializeComponent();
            _selectedDiscipline = selectedDisca;
            name_discipline_textbox.Text = selectedDisca.name_discipline;
            DataContext = _selectedDiscipline;
          
        }
        public List<Disciplines> Disc_list { get; set; }


        private void UpdateQuestions()
        {
            _selectedDiscipline.name_discipline = name_discipline_textbox.Text;
        }

        private void But_Click_Save_Question(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedDiscipline.name_discipline))
            {
                MessageBox.Show("Корректно напишите вопрос");
                return;
            }

            UpdateQuestions();

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
    }
}