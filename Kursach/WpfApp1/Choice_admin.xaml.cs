using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для Choice.xaml
    /// </summary>
    public partial class Choice_admin : Page
    {
        public Choice_admin()
        {
            InitializeComponent();
          
            bindcombo_disca();
            bindcombo_teacher();
            bindcombo_chairman_pck();
        }

        //ComboBox disca
        public List<Disciplines> Disc_list { get; set; }
        private void bindcombo_disca()
        {
            //Disca.SelectedIndex = 0;
            var Item = RandomTicketGenerator.GetContext().Disciplines.ToList();
            Disc_list = Item;
            DataContext = Disc_list;
            Disca.ItemsSource= Disc_list;
            Disca.SelectedValuePath = "id_discipline";
            Disca.DisplayMemberPath = "name_discipline";
            Disca.SelectedIndex = 0;
        }
        //

        //ComboBox Teacher
        public List<Teacher> Teacher_list { get; set; }

        private void bindcombo_teacher()
        {
            //Disca.SelectedIndex = 0;
            var Item = RandomTicketGenerator.GetContext().Teacher.ToList();
            Teacher_list = Item;
            DataContext =Teacher_list;
            Teacher.ItemsSource = Teacher_list;
            Teacher.SelectedValuePath = "id_teacher";
            Teacher.DisplayMemberPath = "surname";
            Teacher.SelectedIndex = 0;
        }
        //

        //ComboBox disca
        public List<Chairman_pck> Chairman_pck_list { get; set; }
        private void bindcombo_chairman_pck()
        {
            //Disca.SelectedIndex = 0;
            var Item = RandomTicketGenerator.GetContext().Chairman_pck.ToList();
            Chairman_pck_list = Item;
            DataContext = Disc_list;
            Chairman_pck.ItemsSource = Chairman_pck_list;
            Chairman_pck.SelectedValuePath = "id_chairman_pck";
            Chairman_pck.DisplayMemberPath = "surname";
            Chairman_pck.SelectedIndex = 0;
        }
        //
        private void But_Click_Form_Ticket(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                var disca_content = Disca.Text;
                var teacher_content = Teacher.Text;
                var Chaiman_pck_content = Chairman_pck.Text;
                MessageBox.Show($"Выбор сделан, {disca_content}, {teacher_content}, {Chaiman_pck_content} ");
            }
            if (false)
            {
                MessageBox.Show("Ошибка при формирование билета");
            }
        }
        private void But_Click_Viewing_Table_Data(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewingTableData_admin());
        }
    }
}
