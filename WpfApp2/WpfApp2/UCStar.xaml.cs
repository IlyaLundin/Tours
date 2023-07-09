using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для UCStar.xaml
    /// </summary>
    public partial class UCStar : UserControl
    {
     
        public int StarsCount
        {
            get { return (int)GetValue(StarsCountDep); }
            set 
            {
                SetValue(StarsCountDep, value);            
            }
        }

        public static readonly DependencyProperty StarsCountDep = DependencyProperty.Register("StarsCount", typeof(int), typeof(UCStar), new PropertyMetadata(1));

        public void CountAllStars()
        {
            switch (StarsCount)
            {
                case 1:
                    StarFir.Visibility = Visibility.Visible;
                    break;
                case 2:
                    StarFir.Visibility = Visibility.Visible;
                    StarSec.Visibility = Visibility.Visible;
                    break;
                case 3:
                    StarFir.Visibility = Visibility.Visible;
                    StarSec.Visibility = Visibility.Visible;
                    StarThi.Visibility = Visibility.Visible;
                    break;
                case 4:
                    StarFir.Visibility = Visibility.Visible;
                    StarSec.Visibility = Visibility.Visible;
                    StarThi.Visibility = Visibility.Visible;
                    StarFou.Visibility = Visibility.Visible;
                    break;
                case 5:
                    StarFir.Visibility = Visibility.Visible;
                    StarSec.Visibility = Visibility.Visible;
                    StarThi.Visibility = Visibility.Visible;
                    StarFou.Visibility = Visibility.Visible;
                    StarFiv.Visibility = Visibility.Visible;
                    break;
            }
        }

        public UCStar()
        {
            InitializeComponent();
            CountAllStars();
          
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CountAllStars();
           
        }
    }
}
