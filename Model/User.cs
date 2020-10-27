using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : INotifyPropertyChanged
    {
        private int id;
        private string userName;
        private string userPass;
        private int isAdmin;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public int Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
            
        }

        public string UserName
        {
            get { return userName; }
            set { 
                userName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserName"));
            }
        }

        public string UserPass
        {
            get { return userPass; }
            set { 
                userPass = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserPassword"));
            }
        }

        public int IsAdmin
        {
            get { return isAdmin; }
            set { 
                isAdmin = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsAdmin"));
            }
        }

        public User(int id, string userName, string userPassword, int isAdmin)
        {
            this.id = id;
            this.userName = userName;
            this.userPass = userPassword;
            this.isAdmin = isAdmin;
        }

        public User() {
            this.UserName = "";
            this.UserPass = "";
        }
    }
}
