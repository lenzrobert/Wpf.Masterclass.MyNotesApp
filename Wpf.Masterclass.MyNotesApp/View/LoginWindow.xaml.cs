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
using Wpf.Masterclass.MyNotesApp.ViewModel;

namespace Wpf.Masterclass.MyNotesApp.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginViewModel vm = new LoginViewModel();
            GridContainer.DataContext = vm;
           
            vm.HasLoggedIn += Vm_HasLoggedIn;
        }

        private void Vm_HasLoggedIn(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNoAccount_Click(object sender, RoutedEventArgs e)
        {
            StackPanelRegister.Visibility = Visibility.Visible;
            StackPanelLogin.Visibility = Visibility.Collapsed;
        }

        private void BtnHasAccount_Click(object sender, RoutedEventArgs e)
        {
            StackPanelRegister.Visibility = Visibility.Collapsed;
            StackPanelLogin.Visibility = Visibility.Visible;
        }
    }
}
