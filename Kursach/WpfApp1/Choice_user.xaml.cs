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
    /// Логика взаимодействия для Choice.xaml
    /// </summary>
    public partial class Choice_user : Page
    {
        public Choice_user()
        {
            InitializeComponent();
        }

        private void But_Click_Form_Ticket(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                MessageBox.Show("Билет сформирован");
            }
            if (false)
            {
                MessageBox.Show("Ошибка при формирование билета");
            }
        }

        private void But_Click_Viewing_Table_Data(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewingTableData_user());
        }
    }
}
