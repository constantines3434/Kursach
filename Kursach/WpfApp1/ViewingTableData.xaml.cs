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
    /// Логика взаимодействия для ViewingTableData.xaml
    /// </summary>
    public partial class ViewingTableData : Page
    {
        public ViewingTableData()
        {
            InitializeComponent();
            DFrid.ItemsSource = RandomTicketGenerator.GetContext().Questions.ToList();
        }

        static void BtnEdit_Click   (object sender, RoutedEventArgs e)
        {
             
        }
    }
}
