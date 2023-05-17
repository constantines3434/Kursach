﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Data;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System.Runtime.CompilerServices;

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

            Bindcombo_disca();
            Bindcombo_teacher();
            //Bindcombo_chairman_pck();
            Bindcombo_kurs();
            Bindcombo_semester();
            Bindcombo_speciality();
            Bindcombo_protocols();
            Initialize_questions();
            roleUser = role;
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
        static string conString = @"Data Source=WIN-OMJN02Q49QC; Initial Catalog=BookShop; Integrated Security=true;";
        private int GetDisipline()
        {
            return ((Disciplines)Disca.SelectedItem).id_discipline;
        }
        //

        //связывание таблиц
        /////////////////////////////////////////
        /// <summary>
        /// получение id экзаменатора
        /// </summary>
        private int GetExaminersId()
        {
            int id =
    (from i in RandomTicketGenerator.GetContext().Examiners
     where i.id_examiners == Convert.ToInt32(Teacher.Text)
     select i.id_examiners).First();
            return id;
        }

        /// <summary>
        /// получение id специальности 
        /// </summary>
        private string GetSpecialityId()
        {
            string id =
    (from i in RandomTicketGenerator.GetContext().Speciality
     where i.code_speciality == Protocol.Text
     select i.code_speciality).First();
            return id;
        }
        
        /// <summary>
        /// получение id цикловой комиссии
        /// </summary>
        private int GetCycleComissionId()
        {
            int id =
    (from i in RandomTicketGenerator.GetContext().Cycle_commissions
     where i.id_examiners == GetExaminersId() &&
           i.code_speciality == GetSpecialityId()
     select i.id_cycle_commission).First();
            return id;
        }
        //
        /// <summary>
        /// получение id протокола
        /// </summary>
        private int GetProtocolsId()
        {
            int id =
    (from i in RandomTicketGenerator.GetContext().Protocols
     where i.nom_protocol == Convert.ToInt32(Protocol.Text)
     && i.id_cycle_commission == GetCycleComissionId()
     select i.nom_protocol).First();
            return id;
        }
        //
        /// <summary>
        /// получение id Семестров
        /// </summary>
        private int GetSemesterId()
        {
            int id =
    (from i in RandomTicketGenerator.GetContext().Semesters
     where i.nom_semester == Convert.ToInt32(Semester.Text)
     select i.nom_semester).First();
            return id;
        }
        //
        /// <summary>
        /// получение id Курса
        /// </summary>
        private int GetKursId()
        {
            int id =
    (from i in RandomTicketGenerator.GetContext().Kurs
     where i.nom_kurs == Convert.ToInt32(Kurs.Text)
     select i.nom_kurs).First();
            return id;
        }
        //
        private int GetDisciplineId() //+
        {
            int id =
    (from i in RandomTicketGenerator.GetContext().Disciplines
     where i.id_discipline == Convert.ToInt32(Disca.Text)
      && i.id_semester == Convert.ToInt32(Semester.Text)
     select i.id_discipline).First();
            return id;
        }
        //
        /// <summary>
        /// получение id комплекта билетов
        /// </summary>
        private int GetKomplectId()
        {
            int id =
    (int)(from i in RandomTicketGenerator.GetContext().Komplect_tickets
     where i.nom_kurs == GetKursId()
      && i.nom_semester == GetSemesterId()
      && i.nom_protocol == GetProtocolsId()
      && i.id_discipline == GetDisciplineId()
     select i.nom_komplect).First();
            return id;
        }
        //
        /// <summary>
        /// получение id вопроса
        /// </summary>
        private int GetQuestId()
        {
            int id =
    (int)(from i in RandomTicketGenerator.GetContext().Questions
          where i.id_discipline == GetDisciplineId()
          select i.id_question).First();
            return id;
        }
        //
        /// <summary>
        /// получение id билета
        /// </summary>
        private int GetTicketId()
        {
            int id =
    (int)(from i in RandomTicketGenerator.GetContext().Tickets
          where i.id_question == GetQuestId()
          && i.nom_komplect== GetKomplectId()
          select i.id_ticket).First();
            return id;
        }
        /////////////////////////////////////////

        //ComboBox Teacher
        public List<Examiners> Examiners_list { get; set; }

        private void Bindcombo_teacher()
        {
            var Item = RandomTicketGenerator.GetContext().Examiners.ToList();
            Examiners_list = Item;

            if (System.Windows.Controls.ComboBox.NameProperty.Name == "Teacher")
            {

                DataContext = Examiners_list;
                Teacher.ItemsSource = Examiners_list;
                if (GetExaminersRole() == "Преподаватель")
                {
                    Teacher.SelectedValuePath = "";
                    Teacher.DisplayMemberPath = "surname";
                    Teacher.SelectedIndex = 0;
                }

                else
                {
                    DataContext = Examiners_list;
                    Chairman_pck.ItemsSource = Examiners_list;
                    Chairman_pck.SelectedValuePath = "";
                    Chairman_pck.DisplayMemberPath = "surname";
                    Chairman_pck.SelectedIndex = 0;
                }
            }
        }

        public int GetExaminerRole() //доделать
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string cmdString = "GetExaminersRole";
                con.Open();

                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter
                {
                    ParameterName = "@id",
                };
                cmd.Parameters.Add(Param);

                int result = (int)cmd.ExecuteScalar();

                con.Close();

                return result;
            }
        }


        private string GetExaminersRole()
        {
            return ((Examiners)Teacher.SelectedItem).role_;
        }
        //ComboBox Chairman_pck

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

        //private int GetTeacherId()
        //{
        //    return ((Teacher)Teacher.SelectedItem).id_teacher;
        //}
        //private int GetChairmanId()
        //{
        //    return ((Chairman_pck)Chairman_pck.SelectedItem).id_chairman_pck;
        //}

        private string GetSpecialytyId()
        {
            return ((Speciality)Spec.SelectedItem).code_speciality;
        }

        //public List<Cycle_commissions> Cycle_Commissions_list { get; set; }
        //private Cycle_commissions GetCommission()
        //{
        //    return Cycle_Commissions_list.Find(
        //        (commission) =>
        //            commission.id_teacher == GetTeacherId()
        //         && commission.id_chairman_pck == GetChairmanId()
        //         && commission.code_speciality == GetSpecialytyId()
        //    );
        //}

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
            string protocol_date_content = GetDateString();
            string protocol_year_content = GetYearString();
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
    }
}
