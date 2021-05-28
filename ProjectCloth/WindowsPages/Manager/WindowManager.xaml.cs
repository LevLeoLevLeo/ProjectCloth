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
using System.Windows.Shapes;

namespace ProjectCloth.WindowsPages.Manager
{
    /// <summary>
    /// Логика взаимодействия для WindowManager.xaml
    /// </summary>
    public partial class WindowManager : Window
    {
        public WindowManager()
        {
            InitializeComponent();
            WindowsAndFrames.FrmNavPanel = FrmWindowManager;
            WindowsAndFrames.FrmNavPanel.Navigate(new PageMainManager());
            WindowsAndFrames.BtnBack = Btn_Back;
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            WindowsAndFrames.FrmNavPanel.GoBack();
            if (!WindowsAndFrames.FrmNavPanel.CanGoBack)

            {

                Btn_Back.Visibility = Visibility.Hidden;

            }

        }
    }
}
