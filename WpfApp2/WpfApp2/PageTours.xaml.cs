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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для PageTours.xaml
    /// </summary>
    public partial class PageTours : Page
    {
    
        public PageTours()
        {
            InitializeComponent();
          
            ToursData.ItemsSource = ToursBaseEntities3.GetContext().Tours.ToList();
        }
        
        private void BtnWatch_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
