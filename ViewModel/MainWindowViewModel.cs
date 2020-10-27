using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        List<User> users = new List<User>();
        private User userToSave;
        private ICommand saveCommand;

        public User UserToSave {
            get { return userToSave; }
            set {
                if (userToSave == value)
                    return;
                userToSave = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserToSave"));
            }
        }

        public ICommand SaveCommand {
            get { return saveCommand; }
            set {
                if (saveCommand == value) return;
                saveCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SaveCommand"));
            }
        }

        public List<User> Users {
            get { return users; }
            set { users = value; }
        }

        public MainWindowViewModel()
        {
            this.users = UserCollection.GetAllUsers();
            SaveCommand = new CommandTemplate(SaveUser, CanSaveUser);
        }

        public bool CanSaveUser(object parameter) {
            return true;
        }

        public void SaveUser(object parameter) {
            UserCollection.UpdateUser(UserToSave);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
