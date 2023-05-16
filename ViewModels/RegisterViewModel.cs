using myFirtsAppDesktop.Models;
using myFirtsAppDesktop.Repositories;
using myFirtsAppDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace myFirtsAppDesktop.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {

        public List<UserModel> Databaseusers { get; private set; }

        // fields
        private string _name;
        private string _lastname;
        private string _email;
        private string _password;
        private string _username;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public event PropertyChangedEventHandler PropertyChanged;

        private IUserRepository userRepository;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }


        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(_isViewVisible));
            }
        }


        // -> All Commands
        private ICommand _RegisterCommand;

        public ICommand RegisterCommand
        {
            get
            {
                if (_RegisterCommand == null)
                {
                    _RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
                }
                return _RegisterCommand;
            }
        }


        public RegisterViewModel()
        {
            userRepository = new UserRepository();
        }

        private bool CanExecuteRegisterCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Email) || Email.Length < 3 || Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }

            return validData;
        }


        private void ExecuteRegisterCommand(object obj)
        {
            using (UserDataContext context = new UserDataContext())
            {
                bool userFound = context.Users.Any(user => user.Email == Email);

                if (userFound)
                {
                    Databaseusers = context.Users.ToList();
                    var Id = Databaseusers.Count();
                    //int Id = 0;
                    int IdInitial = Id + 1;
                    if (Email != null && Password != null && Name != null) {
                        context.Users.Add(new UserModel() {
                            Name = Name, LastName = Lastname,
                            Email = Email, Password = Password,
                            Username = Username, Id = IdInitial
                        });

                        context.SaveChanges();
                    }

                } else
                {
                    ErrorMessage = "Esse email ja existe!";
                }
            } 
        }


    }
}
