using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        public ICommand loginCommand;

        public ICommand LoginCommand {
            get { return loginCommand; }
            set {
                if (loginCommand == value)
                    return;
                loginCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LoginCommand"));
            }
        }

        public LoginWindowViewModel() {
            LoginCommand = new CommandTemplate(LoginExecute, CanLogin);
            currentlyLogingUser = new User();
        }

        public User currentlyLogingUser;
        public static bool userExists;
       
        public User CurrentlyLogingUser {
            get { return currentlyLogingUser; }
            set {
                if (currentlyLogingUser == value)
                    return;
                currentlyLogingUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentlyLogingUser"));
            }
        }
        
        public bool UserExists {
            get { return userExists; }
            set {
                userExists = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserExists"));
            }
        }

        public bool CanLogin(object parameter) {
            return true;
        }

        public void LoginExecute(object parameter) {
            if (UserCollection.DoesUserExist(CurrentlyLogingUser))
                UserExists = true;
            else
                UserExists = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        
    }
}
