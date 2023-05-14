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
    /// Логика взаимодействия для EditingQuestion.xaml
    /// </summary>
    public partial class EditingQuestion : Page
    {
        private Questions _selectedQuestion;
        public EditingQuestion(Questions selectedQuest)
        {
            InitializeComponent();
            _selectedQuestion = selectedQuest;

            DataContext = _selectedQuestion;
            Bindcombo_disca();

            InitializeBoxes();
        }

        public List<Disciplines> Disc_list { get; set; }
        /// <summary>
        /// ComboBox Disciplines
        /// </summary>
        private void Bindcombo_disca()
        {
            var Item = RandomTicketGenerator.GetContext().Disciplines.ToList();
            Disc_list = Item;
            DataContext = Disc_list;
            Disca.ItemsSource = Disc_list;
            Disca.SelectedValuePath = "";
            Disca.DisplayMemberPath = "name_discipline";
        }

        private void InitializeBoxes() 
        {
            question_textbox.Text = _selectedQuestion.question;
            Type_question.Text = _selectedQuestion.type_question;

            for (int i = 0; i < Disc_list.Count; i++) //получение по названию дисцы индекса
            {
                if (GetDisciplineId() == _selectedQuestion.id_discipline)
                {
                    return;
                }
            }
        }

        private int GetDisciplineId()
        {
            return ((Disciplines)Disca.SelectedItem).id_discipline;
        }

        private void UpdateQuestions()
        {
            _selectedQuestion.id_discipline = GetDisciplineId();
            _selectedQuestion.question = question_textbox.Text;
            _selectedQuestion.type_question = Type_question.Text;
            _selectedQuestion.complexity = Complexity_question.Text;
        }

        private void But_Click_Save_Question(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedQuestion.question))
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
            NavigationService.Navigate(new ViewingTableData_admin());
        }
    }
}
