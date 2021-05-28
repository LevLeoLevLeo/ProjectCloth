using ProjectCloth.Class;
using ProjectCloth.DataBase;
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

namespace ProjectCloth
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassDataBase.DBCloth = new DataBase.ProjectClothEntities();
        }

        private void Chb_ShowPassword_Click(object sender, RoutedEventArgs e)
        {

            if (Chb_ShowPassword.IsChecked == true)

            {

                Txb_ShowPassword.Text = Pssb_Password.Password;
                Pssb_Password.Clear();
                Pssb_Password.Visibility = Visibility.Collapsed;
                Txb_ShowPassword.Visibility = Visibility.Visible;

            }

            else

            {

                Pssb_Password.Password = Txb_ShowPassword.Text;
                Txb_ShowPassword.Clear();
                Txb_ShowPassword.Visibility = Visibility.Collapsed;
                Pssb_Password.Visibility = Visibility.Visible;

            }

        }

        private void Chb_ShowNewPassword_Click(object sender, RoutedEventArgs e)
        {

            if (Chb_ShowNewPassword.IsChecked == true)

            {

                Txb_ShowNewPassword.Text = Pssb_NewPassword.Password;
                Pssb_NewPassword.Clear();
                Pssb_NewPassword.Visibility = Visibility.Collapsed;
                Txb_ShowNewPassword.Visibility = Visibility.Visible;

            }

            else

            {

                Pssb_NewPassword.Password = Txb_ShowNewPassword.Text;
                Txb_ShowNewPassword.Clear();
                Txb_ShowNewPassword.Visibility = Visibility.Collapsed;
                Pssb_NewPassword.Visibility = Visibility.Visible;

            }

        }

        private void Btn_LogIn_Click(object sender, RoutedEventArgs e)
        {

            try

            {
                var DBLogin = ClassDataBase.DBCloth.User.FirstOrDefault
                    (Alien => Alien.Login == Txb_Login.Text && Alien.Password == Pssb_Password.Password || Alien.Login == Txb_Login.Text && Alien.Password == Txb_ShowPassword.Text);

                if (DBLogin == null)

                {
                    Pssb_Password.Clear();
                    Txb_ShowPassword.Clear();
                    MessageBox.Show("Логин или пароль введены неверно, попробуйте еще раз",
                        "Авторизация",
                        MessageBoxButton.OK, MessageBoxImage.Warning);

                }

                else

                {

                    switch (DBLogin.IdRole)

                    {

                        case 1:
                            WindowsPages.Customer.WindowCustomer windowCustomer = new WindowsPages.Customer.WindowCustomer();
                            windowCustomer.Show();
                            this.Close();
                            break;
                        case 2:
                            WindowsPages.Storekeeper.WindowStorekeeper windowStorekeeper = new WindowsPages.Storekeeper.WindowStorekeeper();
                            windowStorekeeper.Show();
                            this.Close();
                            break;
                        case 3:
                            WindowsPages.Manager.WindowManager windowManager = new WindowsPages.Manager.WindowManager();
                            windowManager.Show();
                            this.Close();
                            break;
                        case 4:
                            WindowsPages.Director.WindowDirector windowDirector = new WindowsPages.Director.WindowDirector();
                            windowDirector.Show();
                            this.Close();
                            break;
                        default:
                            MessageBox.Show("Что-то пошло не так, обратитесь к администратору", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;

                    }

                }

            }

            catch (Exception error)

            {

                MessageBox.Show("Произошла ошибка " + error.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void Btn_Registrarion_Click(object sender, RoutedEventArgs e)

        {
            
            if (Chb_ShowNewPassword.IsChecked == true)

            {

                Pssb_NewPassword.Password = Txb_ShowNewPassword.Text;

            }

            User UserReg = new User()
            {

                Login = Txb_NewLogin.Text,
                Password = Pssb_NewPassword.Password,
                IdRole = 1

            };

            ClassDataBase.DBCloth.User.Add(UserReg);
            ClassDataBase.DBCloth.SaveChanges();
            MessageBox.Show("Пользователь создан!");

        }
    }
}
