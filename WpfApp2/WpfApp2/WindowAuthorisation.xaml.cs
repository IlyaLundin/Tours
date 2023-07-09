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
using System.Windows.Shapes;
using System.Threading;  

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для WindowAuthorisation.xaml
    /// </summary>
    public partial class WindowAuthorisation : Window
    {
        public WindowAuthorisation()
        {
            InitializeComponent();
           
        }
        // Логин и пароль для входа одинаковы: client, manager, admin
         
        private void OpenPassword_Checked(object sender, RoutedEventArgs e)
        {
            TbxPassword.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Hidden;
        }
        private void OpenPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            TbxPassword.Visibility = Visibility.Hidden;
            PasswordBox.Visibility = Visibility.Visible;
        }



      
        int countErrors = 0;
        public static string login;
        public static string role;
        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            var userObj = ToursBaseEntities3.GetContext().USERDATAs.FirstOrDefault(x => x.login == TbxLogin.Text );
            if (userObj==null)
            {
                MessageBox.Show("Такого пользователя нет в системе!", "Ошибка входа в систему", MessageBoxButton.OK, MessageBoxImage.Error);
                countErrors++;
                TbxLogin.Text = "";
                TbxPassword.Text = "";
            }
            else
            {
                if (userObj.password == TbxPassword.Text)
                {
                    MessageBox.Show($"Успешный вход в систему! {TbxLogin.Text}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    login = userObj.FIO;
                    role = userObj.TypeOfUser;
                    MainWindow mW = new MainWindow();
                    mW.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверные пароль!", "Ошибка входа в систему", MessageBoxButton.OK, MessageBoxImage.Error);
                    countErrors++;
                    TbxPassword.Text = "";
                }
            }

            if(countErrors>2)
            {
                MessageBox.Show("Слишком много неверных попыток входа в систему, подождите 5 секунд!", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Stop);
                Thread.Sleep(5000);
                countErrors = 0;
            }
            
        }

        private void TbxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TbxLogin.Text != "")
            {
                TblPassword.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Visible;
            }
            else
            {
                TblPassword.Visibility = Visibility.Hidden;
                PasswordBox.Visibility = Visibility.Hidden;
                PasswordBox.Password = "";
                TbxPassword.Text = "";

            }
        }

        private void TbxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(PasswordBox.Password!= "")
            {
                OpenPassword.Visibility = Visibility.Visible;
                BtnLogIn.Visibility = Visibility.Visible;
                PasswordBox.Password = TbxPassword.Text;
            }
            else
            {
                OpenPassword.Visibility = Visibility.Hidden;
                BtnLogIn.Visibility = Visibility.Hidden;
                PasswordBox.Password = TbxPassword.Text;
                
            }

        }
        private void SetSelection(PasswordBox passwordBox, int start, int length)
        {
            passwordBox.GetType().GetMethod("Select", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(passwordBox, new object[] { start, length });
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TbxPassword.Text = PasswordBox.Password;
            SetSelection(PasswordBox, PasswordBox.Password.Length, 0);
            PasswordBox.Focus();
        }
    }
}
