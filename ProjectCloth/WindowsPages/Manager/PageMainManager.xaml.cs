using ProjectCloth.Class;
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

namespace ProjectCloth.WindowsPages.Manager
{
    /// <summary>
    /// Логика взаимодействия для PageMainManager.xaml
    /// </summary>
    public partial class PageMainManager : Page
    {
        public PageMainManager()
        {
            InitializeComponent();
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            WindowsAndFrames.FrmNavPanel.Navigate(new PageOrderManager());
            WindowsAndFrames.BtnBack.Visibility = Visibility.Visible;

        }
    }
}
