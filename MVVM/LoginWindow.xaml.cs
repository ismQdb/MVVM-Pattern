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
using ViewModel;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            LoginWindowViewModel loginWindowViewModel = new LoginWindowViewModel();
            this.DataContext = loginWindowViewModel;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindowViewModel loginWindowViewModel = (LoginWindowViewModel)DataContext;

            if (Model.UserCollection.DoesUserExist(loginWindowViewModel.CurrentlyLogingUser)) {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            } else
             MessageBox.Show("Login failed. Please try again.");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.Show();
        }
    }
}
