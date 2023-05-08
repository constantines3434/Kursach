﻿using System;
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
    /// Логика взаимодействия для AddEditPAge.xaml
    /// </summary>
    public partial class AddEditPAge : Page
    {
        public AddEditPAge()
        {
            InitializeComponent();
            
            DataContext = GetQuestions();
            Bindcombo_disca();
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
            Disca.SelectedIndex = 0;
        }

        private int GetDisciplineId()
        {
            return ((Disciplines)Disca.SelectedItem).id_discipline;
        }

        private Questions GetQuestions()
        {
            return new Questions
            {
                id_discipline = GetDisciplineId(),
                question = question_textbox.Text,
                type_question = Type_question.Text
            };
        }

        private void But_Click_Save_Question(object sender, RoutedEventArgs e)
        {
            var currentQuest = GetQuestions();

            if (string.IsNullOrWhiteSpace(currentQuest.question))
            {
                MessageBox.Show("Корректно напишите вопрос");
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
