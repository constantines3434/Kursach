using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Data;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System.Runtime.CompilerServices;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Math;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Choice.xaml
    /// </summary>
    public partial class Choice_admin : Page
    {
        private string roleUser;
        public Choice_admin(string role)
        {
            InitializeComponent();

            Bindcombo_speciality();
            Bindcombo_kurs();
            Bindcombo_semester();
            Bindcombo_protocols();
            Bindcombo_chairman();
            roleUser = role;
        }

        //связывание таблиц
        /////////////////////////////////////////

        /// <summary>
        /// получение id Председателя
        /// </summary>
        private int GetChairmanId()
        {
            int id =
    (from i in RandomTicketGenerator.GetContext().Chairman_pck.ToList()
     where i.id_chairman_pck == Convert.ToInt32(Chairman.Text)
     select i.id_chairman_pck).First();
            return id;
        }
        /// <summary>
        /// получение id билета
        /// </summary>
        private int GetTicketId()
        {
            int id =
    (int)(from i in RandomTicketGenerator.GetContext().Tickets.ToList()
          where i.id_question == GetQuestId()
          && i.nom_komplect == GetKomplectId()
          && i.id_teacher == GetTeacherId()
          select i.id_ticket).First();
            return id;
        }
        /////////////////////////////////////////
        private string GetSpecialityId()
        {
            return ((Speciality)Spec.SelectedItem).code_speciality;
        }
        /// <summary>
        /// получение id специальности 
        /// </summary>
        private string GetSpecId()
        {
            string id =
    (from i in RandomTicketGenerator.GetContext().Speciality.ToList()
     where i.code_speciality == GetSpecialityId()
     select i.code_speciality).First();
            return id;
        }

        /// <summary>
        /// заполнение ComboBox Специальности
        /// </summary>
        private void Bindcombo_speciality()
        {

            IEnumerable<Speciality> Speciality_list = from i in RandomTicketGenerator.GetContext().Speciality.ToList()
                                                      select i;
            DataContext = Speciality_list;
            Spec.ItemsSource = Speciality_list;
            Spec.SelectedValuePath = "";
            Spec.DisplayMemberPath = "name_of_speciality";
            Spec.SelectedIndex = 0;
        }
        /// <summary>
        /// получение id Курса
        /// </summary>
        private int GetKursId()
        {
            int id =
    (from i in RandomTicketGenerator.GetContext().Kurs.ToList()
     where i.nom_kurs == Convert.ToInt32(Kurs.Text)
     select i.nom_kurs).First();
            return id;
        }
        private void Bindcombo_kurs()
        {
            IEnumerable<Kurs> Kurs_list = from i in RandomTicketGenerator.GetContext().Kurs.ToList()
                                          select i;
            DataContext = Kurs_list;
            Kurs.ItemsSource = Kurs_list;
            Kurs.SelectedValuePath = "";
            Kurs.DisplayMemberPath = "nom_kurs";
            Kurs.SelectedIndex = 0;
        }

        /// <summary>
        /// получение id Семестров
        /// </summary>
        private int GetSemesterId()
        {
            int id =
    (from i in RandomTicketGenerator.GetContext().Semesters.ToList()
     where i.nom_semester == Convert.ToInt32(Semester.Text)
     select i.nom_semester).First();
            return id;
        }

        private DateTime GetSemDate()
        {
            return ((Semesters)Semester.SelectedItem).academic_year.Value;
        }

        private string GetSemYearString()
        {
            return GetSemDate().ToString("yyyy");
        }

        /// <summary>
        /// заполнение ComboBox Специальности
        /// </summary>
        private void Bindcombo_semester()
        {
            IEnumerable<Semesters> Semesters_list = from i in RandomTicketGenerator.GetContext().Semesters.ToList()
                                                    select i;
            DataContext = Semesters_list;
            Semester.ItemsSource = Semesters_list;
            Semester.SelectedValuePath = "";
            Semester.DisplayMemberPath = "nom_semester";
            Semester.SelectedIndex = 0;
        }

        /// <summary>
        /// получение id протокола
        /// </summary>
        private int GetProtocolsId()
        {
            int id =
    (from i in RandomTicketGenerator.GetContext().Protocols.ToList()
     where i.nom_protocol == Convert.ToInt32(Protocol.Text)
     select i.nom_protocol).First();
            return id;
        }
        /// <summary>
        /// заполнение ComboBox Протоколов
        /// </summary>
        private void Bindcombo_protocols()
        {
            IEnumerable<Protocols> Protocols_list = from i in RandomTicketGenerator.GetContext().Protocols.ToList()
                                                    select i;
            DataContext = Protocols_list;
            Protocol.ItemsSource = Protocols_list;
            Protocol.SelectedValuePath = "";
            Protocol.DisplayMemberPath = "nom_protocol";
            Protocol.SelectedIndex = 0;
        }
        private DateTime GetProtDate()
        {
            return ((Protocols)Protocol.SelectedItem).date_protocol.Value;
        }

        private string GetProtDateString()
        {
            return GetProtDate().ToString("dd.MM.yyyy");
        }

        private int GetChairmnaId()
        {
            int id =
   (from i in RandomTicketGenerator.GetContext().Chairman_pck.ToList()
    where i.id_chairman_pck == Convert.ToInt32(Protocol.Text)
    select i.id_chairman_pck).First();
            return id;
        }

        private void Bindcombo_chairman()
        {
            IEnumerable<string> Chairman_list = from i in RandomTicketGenerator.GetContext().Chairman_pck.ToList()
                                                     let fio = i.surname + " " + i.name_[0] + "." + i.patronymic[0] + "."
                                                     select fio;
            Chairman_list.ToList();
            DataContext = Chairman_list;
            Chairman.ItemsSource = Chairman_list;
            Chairman.SelectedValuePath = "";
            Chairman.SelectedIndex = 0;
        }

        /// <summary>
        /// получение id вопроса
        /// </summary>
        private int GetQuestId()
        {
            int id =
    (int)(from i in RandomTicketGenerator.GetContext().Questions.ToList()
          where i.id_discipline == GetDisciplineId()
          select i.id_question).First();
            return id;
        }

        List<Questions> Questions_list { get; set; }
        /// <summary>
        /// Инициализация Вопросов
        /// </summary>
        private void Initialize_questions()
        {
            IEnumerable<Questions> Questions_list = from i in RandomTicketGenerator.GetContext().Questions.ToList()
                                                    where i.id_discipline == GetDisciplineId()
                                                    select i;

            var rng = new Random();
            Questions_list = Questions_list.OrderBy(x => rng.Next()).ToList();
        }

        private string RollQuestions(string type, int id_disc)
        {
            string answer = "";
            foreach (var quest in Questions_list)
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

        /// <summary>
        /// получение id комплекта билетов
        /// </summary>
        private int GetKomplectId()
        {
            int id =
    (int)(from i in RandomTicketGenerator.GetContext().Komplect_tickets.ToList()
          where i.nom_kurs == GetKursId()
           && i.nom_semester == GetSemesterId()
           && i.nom_protocol == GetProtocolsId()
           && i.id_chairman_pck == GetChairmanId()
          select i.nom_komplect).First();
            return id;
        }

        private void But_Click_Form_Ticket(object sender, RoutedEventArgs e)
        {
            if (GetDisipline().ToString() == "")
            {
                MessageBox.Show("Выберите Дисциплину");
            }
            Initialize_questions();

            IEnumerable<Komplect_tickets> Komplect_list = from i in RandomTicketGenerator.GetContext().Komplect_tickets.ToList()
                                                where i.nom_komplect == GetKomplectId()
                                                select i;


            IEnumerable<Tickets> Tickets_list = from i in RandomTicketGenerator.GetContext().Tickets.ToList()
                                                where i.nom_komplect == GetKomplectId()
                                                && i.id_question == GetQuestId()
                                                && i.id_teacher == GetTeacherId()
                                                select i;

          
            string disca_content = Disca.Text;
            var helper = new WordHelper("Ex_Ticket_Prac.docx");
            string count_tickets = count_of_tickets.Text;
            //string teacher_content = Teacher.Text;
            //string Chairman_pck_content = Chairman_pck.Text;
            //string kurs_content = Kurs.Text;
            //string semester_content = Semester.Text;
            string speciality_content = Spec.Text;
            //string protocol_content = Protocol.Text;
            string protocol_date_content = GetProtDateString();
            string sem_year_content = GetSemYearString();
            int nom_ticket = 1;

            int t;
            if (int.TryParse(count_tickets, out t))
            {
                if (t < 1)
                {
                    MessageBox.Show("Число билетов должно быть >= 1");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Неверный формат");
                return;
            }

            for (int i = 0; i < Convert.ToInt32(count_tickets); i++)
            {

                var Items = new Dictionary<string, string>
                {
                    {"<DISC>", disca_content},
                    //{"<PCK>",  Chairman_pck_content},
                    //{"<PREP>", teacher_content},
                    //{"<KURS>", kurs_content},
                    //{"<SEM>", semester_content},
                    {"<SPEC>", speciality_content},
                    //{"<NOMPROT>", protocol_content},
                    {"<DATEPROT>", protocol_date_content},
                    {"<YEARSEM> ", sem_year_content},
                    {"<NOMTICK>", nom_ticket.ToString()},
                    {"<TEO1>", RollQuestions("Теоретический", GetDisipline())},
                    {"<TEO2>", RollQuestions("Теоретический", GetDisipline())},
                    {"<PRAC1>", RollQuestions("Практический", GetDisipline())},

                };

                helper.Process(Items);
                nom_ticket++;
            }
            //MessageBox.Show($"Выбор сделан, Дисциплина: {disca_content},\n" +
            //        $"Количество билетов: {count_tickets},\n" +
            //        //$"Преподаватель {teacher_content},\n" +
            //        $"Председатель цикловой комиссии {Chairman_pck_content} ");
        }
        private void But_Click_Viewing_Table_Data(object sender, RoutedEventArgs e)
        {
            if (roleUser == "Admin")
            {
                NavigationService.Navigate(new ViewingTableData_admin(roleUser));
            }
            else
            {
                MessageBox.Show("Только администратор может редактировать таблицы");
            }
        }
        private void But_Auto(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        /// <summary>
        /// получение id Дисциплины
        /// </summary>
        /// 
        private int GetDisciplineId() //+
        {
            int id =
            (from i in RandomTicketGenerator.GetContext().Disciplines.ToList()
             where i.code_speciality == GetSpecialityId()
             select i.id_discipline).First();
            return id;
        }
        private int GetDisipline()
        {
            return ((Disciplines)Disca.SelectedItem).id_discipline;
        }

        /// <summary>
        /// получение id учителя
        /// </summary>
        private int GetTeacherId()
        {
            int id =
    (from i in RandomTicketGenerator.GetContext().Teacher.ToList()
     where i.id_teacher == Convert.ToInt32(Teacher.Text)
     && i.id_discipline == GetDisciplineId()
     select i.id_teacher).First();
            return id;
        }
        private void But_Confirmation_Click(object sender, RoutedEventArgs e)
        {

            IEnumerable<Disciplines> Disc_list = from i in RandomTicketGenerator.GetContext().Disciplines.ToList()
                                                 where i.code_speciality == GetSpecId()
                                                 && i.id_discipline == GetDisciplineId()
                                                 select i;
            DataContext = Disc_list;
            Disca.ItemsSource = Disc_list;
            Disca.SelectedValuePath = "";
            Disca.DisplayMemberPath = "name_discipline";
            Disca.SelectedIndex = 0;

            IEnumerable<string> FullNameTeach_list = from i in RandomTicketGenerator.GetContext().Teacher.ToList()
                                                     where i.id_discipline == GetDisciplineId()
                                                     let fio = i.surname + " " + i.name_[0] + "." + i.patronymic[0] + "."
                                                     select fio;
            FullNameTeach_list.ToList();
            DataContext = FullNameTeach_list;
            Teacher.ItemsSource = FullNameTeach_list;
            Teacher.SelectedValuePath = "";
            Teacher.SelectedIndex = 0;
        }
    }
}
