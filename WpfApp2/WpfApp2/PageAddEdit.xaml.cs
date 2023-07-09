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
    /// Логика взаимодействия для PageAddEdit.xaml
    /// </summary>
    public partial class PageAddEdit : Page
    {
        internal Hotel _currentHotel = new Hotel();
        public PageAddEdit(Hotel selectedHotel)
        {
            InitializeComponent();
            

                if (selectedHotel != null)
                _currentHotel = selectedHotel;

            DataContext = _currentHotel;
            ComboCountries.ItemsSource = ToursBaseEntities3.GetContext().Countries.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentHotel.Name) || _currentHotel.CountOfStars < 1 || _currentHotel.CountOfStars > 5 || _currentHotel.Country == null)
            {
                MessageBox.Show("Заполнены не все поля или некорректные данные!", "Ошибка");
                return;
            }

            if (_currentHotel.Id == 0)
                ToursBaseEntities3.GetContext().Hotels.Add(_currentHotel);

            try
            {
                ToursBaseEntities3.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
