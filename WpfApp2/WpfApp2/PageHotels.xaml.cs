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
using System.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для PageHotels.xaml
    /// </summary>
    public partial class PageHotels : Page
    {
        public Tour NeedTour;
        public List<TourAndHotel>  NeedHotel;
            
        public PageHotels()
            {
            InitializeComponent();
            if (WindowAuthorisation.role == "Client" || WindowAuthorisation.role == "Manager")
            {
                BtnAdd.Visibility = Visibility.Hidden;
                BtnDelete.Visibility = Visibility.Hidden;
            }
            DGridHotels.ItemsSource = ToursBaseEntities3.GetContext().TourAndHotels.ToList();
            ToursData.ItemsSource = ToursBaseEntities3.GetContext().Tours.ToList();
            }


        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (WindowAuthorisation.role == "Client" || WindowAuthorisation.role == "Manager")
            {
                MessageBox.Show("Недостаточно прав для операции!", "Ошибка");

            }
            else
            {
                if (DGridHotels.Visibility == Visibility.Visible)
                {
                    MessageBox.Show("Изменение доступно только при нажатии кнопки Посмотреть отели");
                }
                else
                {


                    ManagerPages.MainFrame.Navigate(new PageAddEdit((sender as Button).DataContext as Hotel));
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DGridHotels.Visibility == Visibility.Visible)
            {
                MessageBox.Show("Изменение доступно только при нажатии кнопки Посмотреть отели");
            }
            else
            {
                ManagerPages.MainFrame.Navigate(new PageAddEdit(null));

            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = AllHotels.SelectedItems.Cast<Hotel>().ToList();

            if (DGridHotels.Visibility == Visibility.Visible)
            {
                MessageBox.Show("Изменение доступно только при нажатии кнопки Посмотреть отели");
            }
            else
            {


                if (hotelsForRemoving.Count() == 0)
                {
                    MessageBox.Show("Данные для удаления не выбраны!");
                }
                else
                {


                    if (MessageBox.Show($"Вы уверены, что хотите удалить следующие {hotelsForRemoving.Count()} элементов?", "Внимание",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            ToursBaseEntities3.GetContext().Hotels.RemoveRange(hotelsForRemoving);
                            ToursBaseEntities3.GetContext().SaveChanges();
                            MessageBox.Show("Данные удалены!");
                            DGridHotels.ItemsSource = ToursBaseEntities3.GetContext().TourAndHotels.ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ToursBaseEntities3.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHotels.ItemsSource = ToursBaseEntities3.GetContext().TourAndHotels.ToList();
                AllHotels.ItemsSource = ToursBaseEntities3.GetContext().Hotels.ToList();
            }
        }
      

      
        private void BtnWatch_Click(object sender, RoutedEventArgs e)
        {

            var currentHotel = ToursBaseEntities3.GetContext().TourAndHotels;

            NeedTour = (Tour)ToursData.SelectedItem;
            if (NeedTour == null)
            {
                MessageBox.Show("Тур не выбран!");
            }
            else
            {

            
            NeedHotel = currentHotel.Where(p => p.TourName == NeedTour.Name).ToList();
            NeedHotel = NeedHotel.OrderByDescending(p => p.CountOfStars).ToList();
            DGridHotels.ItemsSource = NeedHotel;
                if (DGridHotels.Items.Count == 0)
                {
                    MessageBox.Show("Для данного тура нет отелей!", "Ошибка");
                }
                else
                {
                    PanelHotel.Visibility = Visibility.Hidden;
                    PanelTour.Visibility = Visibility.Hidden;
                    PanelAllHotel.Visibility = Visibility.Hidden;
                    Search.Visibility = Visibility.Hidden;
                    BtnFind.Visibility = Visibility.Hidden;
                    Hotels.Visibility = Visibility.Visible;
                    Tour.Visibility = Visibility.Hidden;
                    DGridHotels.Visibility = Visibility.Visible;
                    AllHotels.Visibility = Visibility.Hidden;
                    BtnTours.Visibility = Visibility.Hidden;
                    BtnHotels.Visibility = Visibility.Visible;
                    BtnWatch.Visibility = Visibility.Hidden;
                    checkAccurate.IsChecked = false;
                    checkAccurateSec.IsChecked = false;
                    checkActive.IsChecked = false;
                    rbSUp.IsChecked = false;
                    rbSDown.IsChecked = false;
                    checkExpensive.IsChecked = false;
                    checkPrice.IsChecked = false;
                    checkTickets.IsChecked = false;


                }
            }
        }

        private void BtnTours_Click(object sender, RoutedEventArgs e)
        {
            AllHotels.Visibility = Visibility.Visible;
            AllHotels.ItemsSource = ToursBaseEntities3.GetContext().Hotels.ToList();
            DGridHotels.Visibility = Visibility.Hidden;
            PanelHotel.Visibility = Visibility.Visible;
            Hotels.Visibility = Visibility.Visible;
            Tour.Visibility = Visibility.Hidden;
            PanelTour.Visibility = Visibility.Hidden;
            BtnTours.Visibility = Visibility.Collapsed;
            BtnHotels.Visibility = Visibility.Visible;
            BtnWatch.Visibility = Visibility.Hidden;

            Search.Visibility = Visibility.Visible;
            BtnFind.Visibility = Visibility.Visible;

            checkAccurate.IsChecked = false;
            checkAccurateSec.IsChecked = false;
            checkActive.IsChecked = false;
            rbSDown.IsChecked = false;
            rbSUp.IsChecked = false;
            checkExpensive.IsChecked = false;
            checkPrice.IsChecked = false;
            checkTickets.IsChecked = false;
        }

        private void BtnHotels_Click(object sender, RoutedEventArgs e)
        {
            ToursData.ItemsSource = ToursBaseEntities3.GetContext().Tours.ToList();
            PanelHotel.Visibility = Visibility.Hidden;
            PanelTour.Visibility = Visibility.Visible;
            Hotels.Visibility = Visibility.Hidden;
            Tour.Visibility = Visibility.Visible;
            ToursData.Visibility = Visibility.Visible;
            BtnTours.Visibility = Visibility.Visible;
            BtnWatch.Visibility = Visibility.Visible;
            BtnHotels.Visibility = Visibility.Collapsed;

            Search.Visibility = Visibility.Visible;
            BtnFind.Visibility = Visibility.Visible;

            checkAccurate.IsChecked = false;
            checkAccurateSec.IsChecked = false;
            checkActive.IsChecked = false;
            rbSDown.IsChecked = false;
            rbSUp.IsChecked = false;
            checkExpensive.IsChecked = false;
            checkPrice.IsChecked = false;
            checkTickets.IsChecked = false;
        }

        private void ToursData_MouseUp(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void checkExpensive_Checked(object sender, RoutedEventArgs e)
        {
            tblExpensive.Visibility = Visibility.Visible;
            tblExpensiveLess.Visibility = Visibility.Visible;
            tbxExpensive.Visibility = Visibility.Visible;
            tbxExpensiveLess.Visibility = Visibility.Visible;
        }

        private void checkExpensive_Unchecked(object sender, RoutedEventArgs e)
        {
            tblExpensive.Visibility = Visibility.Hidden;
            tblExpensiveLess.Visibility = Visibility.Hidden;
            tbxExpensive.Visibility = Visibility.Hidden;
            tbxExpensiveLess.Visibility = Visibility.Hidden;
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {

            //Блок для отелей в турах
            if (Hotels.Visibility == Visibility.Visible)
            {


                if (DGridHotels.Visibility == Visibility.Visible)
                {
                    

                    if (NeedHotel == null || NeedTour == null)
                    {
                        DGridHotels.Visibility = Visibility.Hidden;
                        AllHotels.Visibility = Visibility.Visible;
                        var currentHotel = ToursBaseEntities3.GetContext().Hotels.ToList();
                        currentHotel = currentHotel.Where(p => p.Name.ToLower()
                                                                  .Contains(Search.Text.ToLower()))
                                                                  .ToList();

                        if (rbSDown.IsChecked.Value)
                            currentHotel = currentHotel.OrderByDescending(p => p.CountOfStars).ToList();

                        if (rbSUp.IsChecked.Value)
                            currentHotel = currentHotel.OrderBy(p => p.CountOfStars).ToList();


                        if (checkAccurateSec.IsChecked.Value)
                        {
                            currentHotel = currentHotel.Where(p => p.Name.ToLower() == Search.Text.ToLower())
                                                                                                   .ToList();
                        }
                        else
                        {
                            currentHotel = currentHotel.Where(p => p.Name.ToLower()
                                                                   .Contains(Search.Text.ToLower()))
                                                                   .ToList();
                        }

                        AllHotels.ItemsSource = currentHotel;
                        if (AllHotels.Items.Count == 0)
                        {
                            AllHotels.Visibility = Visibility.Hidden;
                            BtnHotels.Visibility = Visibility.Hidden;
                            BtnTours.Visibility = Visibility.Visible;
                            PanelHotel.Visibility = Visibility.Hidden;
                            PanelTour.Visibility = Visibility.Hidden;
                            Search.Text = "";
                            rbSDown.IsChecked = false;
                            rbSUp.IsChecked = false;
                        }
                    }
                    else
                    {
                        AllHotels.Visibility = Visibility.Hidden;
                        DGridHotels.Visibility = Visibility.Visible;
                        var currentHotel = NeedHotel;
                        currentHotel = currentHotel.Where(p => p.Name.ToLower()
                                                                  .Contains(Search.Text.ToLower()))
                                                                  .ToList();
                        if (rbSDown.IsChecked.Value)
                            currentHotel = currentHotel.OrderByDescending(p => p.CountOfStars).ToList();

                        if (rbSUp.IsChecked.Value)
                            currentHotel = currentHotel.OrderBy(p => p.CountOfStars).ToList();




                        /* Search.Visibility = Visibility.Visible;
                         BtnFind.Visibility = Visibility.Visible;
                         BtnTours.Visibility = Visibility.Visible;
                         PanelHotel.Visibility = Visibility.Visible; */

                        DGridHotels.ItemsSource = currentHotel;
                        if (DGridHotels.Items.Count == 0)
                        {
                            DGridHotels.Visibility = Visibility.Hidden;
                            BtnHotels.Visibility = Visibility.Hidden;
                            BtnTours.Visibility = Visibility.Visible;
                            PanelHotel.Visibility = Visibility.Hidden;
                            PanelTour.Visibility = Visibility.Hidden;
                            Search.Text = "";
                            rbSDown.IsChecked = false;
                            rbSUp.IsChecked = false;
                            Search.Visibility = Visibility.Visible;
                            BtnFind.Visibility = Visibility.Visible;


                        }
                    }
                }

                if (AllHotels.Visibility == Visibility.Visible)  //Блок всех отелей
                {
                    DGridHotels.Visibility = Visibility.Hidden;
                    ToursData.Visibility = Visibility.Hidden;
                    if (checkAccurate.IsChecked.Value)
                    {
                        var currentHotel = ToursBaseEntities3.GetContext().Hotels.ToList();
                        currentHotel = currentHotel.Where(p => p.Name.ToLower() == Search.Text.ToLower())
                                                                                               .ToList();
                    }
                    else
                    {
                        var currentHotel = ToursBaseEntities3.GetContext().Hotels.ToList();

                        if (rbSDown.IsChecked.Value)
                            currentHotel = currentHotel.OrderByDescending(p => p.CountOfStars).ToList();

                        if (rbSUp.IsChecked.Value)
                            currentHotel = currentHotel.OrderBy(p => p.CountOfStars).ToList();

                        if (checkAccurateSec.IsChecked.Value)
                        {
                            currentHotel = currentHotel.Where(p => p.Name.ToLower() == Search.Text.ToLower())
                                                                                                   .ToList();
                        }
                        else
                        {
                            currentHotel = currentHotel.Where(p => p.Name.ToLower()
                                                                   .Contains(Search.Text.ToLower()))
                                                                   .ToList();
                        }

                        AllHotels.ItemsSource = currentHotel;
                    }
                    if (AllHotels.Items.Count == 0)
                    {
                        AllHotels.Visibility = Visibility.Hidden;
                        BtnHotels.Visibility = Visibility.Hidden;
                        BtnTours.Visibility = Visibility.Visible;
                        PanelHotel.Visibility = Visibility.Hidden;
                        PanelTour.Visibility = Visibility.Hidden;
                        Search.Text = "";
                        rbSDown.IsChecked = false;
                        rbSUp.IsChecked = false;
                    }
                }
            } 


                if (ToursData.Visibility == Visibility.Visible)  //Блок всех туров
                {
                 Hotels.Visibility = Visibility.Hidden;
                    AllHotels.Visibility = Visibility.Hidden;
                 DGridHotels.Visibility = Visibility.Hidden;
                 var currentTour = ToursBaseEntities3.GetContext().Tours.ToList();

                    if (checkAccurate.IsChecked.Value)
                    {
                        currentTour = currentTour.Where(p => p.Name.ToLower() == Search.Text.ToLower())
                                                                                               .ToList();
                    }
                    else
                    {
                        currentTour = currentTour.Where(p => p.Name.ToLower()
                                                                  .Contains(Search.Text.ToLower()))
                                                                  .ToList();
                    }


                    if (checkActive.IsChecked.Value)
                        currentTour = currentTour.Where(p => p.IsActual == true).ToList();

                    if (checkPrice.IsChecked.Value)
                    {
                       if (rbPDown.IsChecked.Value)
                       {
                        currentTour = currentTour.OrderByDescending(p => p.Price).ToList();
                       }

                       if (rbPUp.IsChecked.Value)
                       {
                        currentTour = currentTour.OrderBy(p => p.Price).ToList();
                       }
                    }
                        

                    if (checkTickets.IsChecked.Value)
                    {
                      if (rbTDown.IsChecked.Value)
                      {
                        currentTour = currentTour.OrderByDescending(p => p.TicketCount).ToList();                  
                      }

                    if (rbTUp.IsChecked.Value)
                    {
                        currentTour = currentTour.OrderBy(p => p.TicketCount).ToList();
                    }                   
                }

                    int valueExpensive;
                    int valueExpensiveLess;
                    bool result;
                    bool resultSec;
                    if (checkExpensive.IsChecked.Value)
                    {
                      tblExpensive.Visibility = Visibility.Visible;
                     tblExpensiveLess.Visibility = Visibility.Visible;
                      result = int.TryParse(tbxExpensive.Text, out valueExpensive);
                        resultSec = int.TryParse(tbxExpensiveLess.Text, out valueExpensiveLess);
                        if (result == true && resultSec == true)
                        {
                            if (valueExpensive == valueExpensiveLess)
                            {
                                MessageBox.Show("Введенные числа не могут быть одинаковыми!");
                                tbxExpensive.Text = "100000";
                                tbxExpensiveLess.Text = "0";
                            }
                            else if (valueExpensive < 0 || valueExpensiveLess < 0)
                            {
                                MessageBox.Show("Введенные значения должны быть целым положительным числом!", "Ошибка");
                                tbxExpensive.Text = "100000";
                                tbxExpensiveLess.Text = "0";
                            }
                            else if (valueExpensive < valueExpensiveLess)
                            {
                                MessageBox.Show("Число в верхнем поле должно быть больше числа в нижнем");
                                tbxExpensive.Text = "100000";
                                tbxExpensiveLess.Text = "0";
                            }
                            else
                                currentTour = currentTour.Where(p => p.Price < valueExpensive && p.Price > valueExpensiveLess).ToList();
                        }
                        else
                        {
                            MessageBox.Show("Введенные значения должны быть целым положительным числом!", "Ошибка");
                            tbxExpensive.Text = "100000";
                            tbxExpensiveLess.Text = "0";
                        }
                    }

                    ToursData.ItemsSource = currentTour;
                    if (ToursData.Items.Count == 0)
                    {
                        ToursData.Visibility = Visibility.Hidden;
                        BtnHotels.Visibility = Visibility.Visible;
                        BtnTours.Visibility = Visibility.Hidden;
                        BtnWatch.Visibility = Visibility.Hidden;
                        PanelHotel.Visibility = Visibility.Hidden;
                        PanelTour.Visibility = Visibility.Hidden;
                        Search.Text = "";
                        checkAccurate.IsChecked = false;
                        checkActive.IsChecked = false;
                        checkExpensive.IsChecked = false;
                        checkPrice.IsChecked = false;
                        checkTickets.IsChecked = false;
                    }
                }
                
                if (DGridHotels.Visibility == Visibility.Hidden && AllHotels.Visibility == Visibility.Hidden && ToursData.Visibility == Visibility.Hidden)
            {
                ToursData.Visibility = Visibility.Hidden;
                BtnHotels.Visibility = Visibility.Visible;
                BtnTours.Visibility = Visibility.Hidden;
                BtnWatch.Visibility = Visibility.Hidden;
                PanelHotel.Visibility = Visibility.Hidden;
                PanelTour.Visibility = Visibility.Hidden;
                Search.Text = "";
                checkAccurate.IsChecked = false;
                checkAccurateSec.IsChecked = false;
                checkActive.IsChecked = false;
                rbSDown.IsChecked = false;
                rbSUp.IsChecked = false;
                checkExpensive.IsChecked = false;
                checkPrice.IsChecked = false;
                checkTickets.IsChecked = false;
                Search.Visibility = Visibility.Hidden;
                BtnFind.Visibility = Visibility.Hidden;
            }
        }

        private void UCEraser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search.Text = "";
        }

        private void checkTickets_Checked(object sender, RoutedEventArgs e)
        {
            Tickets.Visibility = Visibility.Visible;
        }

        private void checkTickets_Unchecked(object sender, RoutedEventArgs e)
        {
            Tickets.Visibility = Visibility.Hidden;
        }

        private void checkPrice_Checked(object sender, RoutedEventArgs e)
        {
            Price.Visibility = Visibility.Visible;
        }

        private void checkPrice_Unchecked(object sender, RoutedEventArgs e)
        {
            Price.Visibility = Visibility.Hidden;
        }
    }
  
}




    