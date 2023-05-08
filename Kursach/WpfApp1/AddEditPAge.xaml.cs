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
    /// Логика взаимодействия для AddEditPAge.xaml
    /// </summary>
    public partial class AddEditPAge : Page
    {
        public AddEditPAge()
        {
            InitializeComponent();
            Bindcombo_disca();
            //Bindcombo_type_question();
        }
        private void But_Click_Save_Question(object sender, RoutedEventArgs e)
        {

        }

        private void But_Click_Viewing_Table_Data(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewingTableData_admin());
        }

        //ComboBox Protocol
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
        //ComboBox Protocol
        //public List<Questions> Questions_list { get; set; }
        //private void Bindcombo_type_question()
        //{
        //    var Item = RandomTicketGenerator.GetContext().Questions.ToList();
        //    Questions_list = Item;
        //    DataContext = Questions_list;
        //    Type_question.ItemsSource = Questions_list;
        //    Type_question.SelectedValuePath = "";
        //    Type_question.DisplayMemberPath = "type_question";
        //    Type_question.SelectedIndex = 0;
        //}
    }
}
