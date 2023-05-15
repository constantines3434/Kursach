using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Data;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Choice.xaml
    /// </summary>
    public partial class Choice_admin : Page
    {
        public Choice_admin()
        {
            InitializeComponent();

            Bindcombo_disca();
            Bindcombo_teacher();
            Bindcombo_chairman_pck();
            Bindcombo_kurs();
            Bindcombo_semester();
            Bindcombo_speciality();
            Bindcombo_protocols();
            Initialize_questions();

        }

        //ComboBox disca
        public List<Disciplines> Disc_list { get; set; }
        private void Bindcombo_disca()
        {
            var Item = RandomTicketGenerator.GetContext().Disciplines.ToList();
            Disc_list = Item;
            DataContext = Disc_list;
            Disca.ItemsSource = Disc_list;
            Disca.SelectedValuePath = "";
            Disca.DisplayMemberPath = "name_discipline";
            Disca.SelectedIndex = 0;
        }

        private int GetDisipline()
        {
            return ((Disciplines)Disca.SelectedItem).id_discipline;
        }
        //

        //ComboBox Teacher
        public List<Teacher> Teacher_list { get; set; }

        private void Bindcombo_teacher()
        {
            
            var Item = RandomTicketGenerator.GetContext().Teacher.ToList();
            Teacher_list = Item;
            DataContext = Teacher_list;
            Teacher.ItemsSource = Teacher_list;
            Teacher.SelectedValuePath = "";
            Teacher.DisplayMemberPath = "surname";
            Teacher.SelectedIndex = 0;
        }

        //ComboBox Chairman_pck
        public List<Chairman_pck> Chairman_pck_list { get; set; }
        private void Bindcombo_chairman_pck()
        {
            var Item = RandomTicketGenerator.GetContext().Chairman_pck.ToList();
            Chairman_pck_list = Item;
            DataContext = Disc_list;
            Chairman_pck.ItemsSource = Chairman_pck_list;
            Chairman_pck.SelectedValuePath = "";
            Chairman_pck.DisplayMemberPath = "surname";
            Chairman_pck.SelectedIndex = 0;
        }
        //

        //ComboBox Speciality
        public List<Speciality> Speciality_list { get; set; }
        private void Bindcombo_speciality()
        {
            var Item = RandomTicketGenerator.GetContext().Speciality.ToList();
            Speciality_list = Item;
            DataContext = Speciality_list;
            Spec.ItemsSource = Speciality_list;
            Spec.SelectedValuePath = "";
            Spec.DisplayMemberPath = "name_of_speciality";
            Spec.SelectedIndex = 0;
        }
        //

        private int GetTeacherId()
        {
            return ((Teacher)Teacher.SelectedItem).id_teacher;
        }
        private int GetChairmanId()
        {
            return ((Chairman_pck)Chairman_pck.SelectedItem).id_chairman_pck;
        }

        private string GetSpecialytyId()
        {
            return ((Speciality)Spec.SelectedItem).code_speciality;
        }

        public List<Cycle_commissions> Cycle_Commissions_list { get; set; }
        private Cycle_commissions GetCommission()
        {
            return Cycle_Commissions_list.Find(
                (commission) =>
                    commission.id_teacher == GetTeacherId()
                 && commission.id_chairman_pck == GetChairmanId()
                 && commission.code_speciality == GetSpecialytyId()
            );
        }

        public List<Kurs> Kurs_list { get; set; }
        private void Bindcombo_kurs()
        {
            var Item = RandomTicketGenerator.GetContext().Kurs.ToList();
            Kurs_list = Item;
            DataContext = Kurs_list;
            Kurs.ItemsSource = Kurs_list;
            Kurs.SelectedValuePath = "";
            Kurs.DisplayMemberPath = "nom_kurs";
            Kurs.SelectedIndex = 0;
        }

        public List<Semesters> Semesters_list { get; set; }
        private void Bindcombo_semester()
        {
            var Item = RandomTicketGenerator.GetContext().Semesters.ToList();
            Semesters_list = Item;
            DataContext = Semesters_list;
            Semester.ItemsSource = Semesters_list;
            Semester.SelectedValuePath = "";
            Semester.DisplayMemberPath = "nom_semester";
            Semester.SelectedIndex = 0;
        }

        public List<Protocols> Protocols_list { get; set; }

        private void Bindcombo_protocols()
        {

            var Item = RandomTicketGenerator.GetContext().Protocols.ToList();
            Protocols_list = Item;
            DataContext = Protocols_list;
            Protocol.ItemsSource = Protocols_list;
            Protocol.SelectedValuePath = "";
            Protocol.DisplayMemberPath = "nom_protocol";
            Protocol.SelectedIndex = 0;
        }
        private DateTime GetDate()
        {
            return ((Protocols)Protocol.SelectedItem).date_protocol.Value;
        }

        private string GetDateString()
        {
            return GetDate().ToString("dd.MM.yyyy");
        }

        private string GetYearString()
        {
            return GetDate().ToString("yyyy");
        }

        List<Questions> Questions_list { get; set; }
        private void Initialize_questions()
        {
            Questions_list = RandomTicketGenerator.GetContext().Questions.ToList();
            
            var rng = new Random();
            Questions_list = Questions_list.OrderBy(x => rng.Next()).ToList();
        }

        private string RollQuestions(string type, int id_disc)
        {
            string answer = "";
            foreach ( var quest in Questions_list)
            {
                if (quest.type_question == type && quest.id_discipline == id_disc && quest.complexity == complexity_of_question.Text)
                {
                    answer = quest.question;
                    Questions_list.Remove(quest);
                    break;
                }
            }
            return answer;
        }
        
        private void But_Click_Form_Ticket(object sender, RoutedEventArgs e)
        {

            string disca_content = Disca.Text;
            var helper = new WordHelper("Ex_Ticket_Prac.docx");
            string count_tickets = count_of_tickets.Text;
            string teacher_content = Teacher.Text;
            string Chairman_pck_content = Chairman_pck.Text;
            string kurs_content = Kurs.Text;
            string semester_content = Semester.Text;
            string speciality_content = Spec.Text;
            string protocol_content = Protocol.Text;
            var protocol_date_content = GetDateString();
            var protocol_year_content = GetYearString();
            int nom_ticket = 1;
            
            //сделать по 20 вопросов
            for (int i = 0; i < Convert.ToInt32(count_tickets); i++)
            {

                    var Items = new Dictionary<string, string>
                {
                    {"<DISC>", disca_content},
                    {"<PCK>",  Chairman_pck_content},
                    {"<PREP>", teacher_content},
                    {"<KURS>", kurs_content},
                    {"<SEM>", semester_content},
                    {"<SPEC>", speciality_content},
                    {"<NOMPROT>", protocol_content},
                    {"<DATEPROT>", protocol_date_content},
                    {"<YEARPROT> ", protocol_year_content},
                    {"<NOMTICK>", nom_ticket.ToString()},
                    {"<TEO1>", RollQuestions("Теоретический", GetDisipline())},
                    {"<TEO2>", RollQuestions("Теоретический", GetDisipline())},
                    {"<PRAC1>", RollQuestions("Практический", GetDisipline())},

                };
             
                    helper.Process(Items);
                    nom_ticket++;
            }
            MessageBox.Show($"Выбор сделан, Дисциплина: {disca_content},\n" +
                    $"Количество билетов: {count_tickets},\n" +
                    $"Преподаватель {teacher_content},\n" +
                    $"Председатель цикловой комиссии {Chairman_pck_content} ");
        }
        private void But_Click_Viewing_Table_Data(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewingTableData_admin());
        }

        private void But_Auto(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
