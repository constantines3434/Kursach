using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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