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
    /// Логика взаимодействия для EditingTicket.xaml
    /// </summary>
    public partial class EditingTicket : Page
    {
        private Tickets _selectedTicket;
        private string roleUser;

        private int GetTicketId()
        {
            return ((Tickets)TicketId.SelectedItem).id_ticket;
        }
        public EditingTicket(Tickets selectedTick, string roleUser)
        {
            InitializeComponent();
            _selectedTicket = selectedTick;
            int IdTick = GetTicketId();
            IdTick = selectedTick.id_ticket;
            DataContext = _selectedTicket;
            this.roleUser = roleUser;
        }

        private void UpdateQuestions()
        {
            _selectedTicket.id_ticket = GetTicketId();
        }

        private void But_Click_Save_Question(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(_selectedTicket.id_ticket))
            //{
            //    MessageBox.Show("Корректно напишите вопрос");
            //    return;
            //}

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
            NavigationService.Navigate(new ViewingDisciplineTable(roleUser));
        }
    }
}
