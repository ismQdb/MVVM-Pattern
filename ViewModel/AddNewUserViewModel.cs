using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class AddNewUserViewModel : INotifyPropertyChanged
    {
        private ICommand addNewUserCommand;

        public ICommand AddNewUserCommand
        {
            get { return addNewUserCommand; }
            set
            {
                if (addNewUserCommand == value) return;
                addNewUserCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AddNewUserCommand"));
            }
        }

        public User currentUser;

        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser == value)
                    return;
                currentUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentUser"));
            }
        }

        public AddNewUserViewModel()
        {
            AddNewUserCommand = new CommandTemplate(AddUserExecute, CanAddUser);
            CurrentUser = new User();
        }

        void AddUserExecute(object obj)
        {
            if (CurrentUser != null)
                UserCollection.AddNewUser(CurrentUser);
        }

        bool CanAddUser(object obj)
        {
            if (CurrentUser != null)
                return true;
            else
                return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
