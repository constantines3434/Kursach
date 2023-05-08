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
    /// Логика взаимодействия для ViewingTableData_admin.xaml
    /// </summary>
    public partial class ViewingTableData_admin : Page
    {
        public ViewingTableData_admin()
        {
            InitializeComponent();
            DGridQuestion.ItemsSource = RandomTicketGenerator.GetContext().Questions.ToList();
        }

        static void BtnEdit_Click(object sender, EventArgs e)
        {
        
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPAge());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
