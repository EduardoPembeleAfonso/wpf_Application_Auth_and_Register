using myFirtsAppDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Windows.Input;
using myFirtsAppDesktop.Models;
using myFirtsAppDesktop.Repositories;
using System.Threading;
using System.Security.Principal;
using myFirtsAppDesktop.View;
using System.Windows;
using System.ComponentModel;

namespace myFirtsAppDesktop.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // fields
        private string _email;
        private string _password;
        //private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public event PropertyChangedEventHandler PropertyChanged;

        private IUserRepository userRepository;

        public string Email {
            get {
                return _email;
            }
            set {
                _email = value;
                OnPropertyChanged(nameof(Email));
            } 
        }
        //public SecureString Password
        //{
        //    get
        //    {
        //        return _password;
        //    }
        //    set
        //    {
        //        _password = value;
        //        OnPropertyChanged(nameof(Password));
        //    }
        //}

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage {
            get { 
            return _errorMessage;
            }  
            set
            {
                _errorMessage = value;
                //OnPropertyChanged(ErrorMessage);
                OnPropertyChanged(nameof(ErrorMessage));
            } 
        }
        public bool IsViewVisible {
            get {
                return _isViewVisible;
            }  set {
                _isViewVisible = value;
                OnPropertyChanged(nameof(_isViewVisible));
            } 
        }

        // -> Commands
        private ICommand _LoginCommand;
        //public ICommand LoginCommand { get; set; }
        public ICommand RecoverPasswordCommand { get; set; }
        public ICommand ShowPasswordCommand { get; set; }
        public ICommand RememberPasswordCommand { get; set;  }

        public ICommand LoginCommand
        {
            get
            {
                if (_LoginCommand == null)
                {
                    _LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand );
                }
                return _LoginCommand;
            }
        }

        public LoginViewModel()
        {
            userRepository = new UserRepository();
            //LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", "") );
        }

        private bool CanExecuteLoginCommand(object obj)
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


        private void ExecuteLoginCommand(object obj)
        {

            using (UserDataContext context = new UserDataContext())
            {
                bool userFounded = context.Users.Any(user => user.Email == Email && user.Password == Password);

                if (userFounded)
                {
                    //var loginView = new Login();
                    //var mainView = new MainWindow();
                    //mainView.Show();
                    //loginView.Close();
                }
                else
                {
                    ErrorMessage = " Email ou Password invalida!";
                    //MessageBox.Show("Error user not found... ");
                }



            }

            //MessageBox.Show("Hello... " + Email);
            //var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(UserName, Password));
            //var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(Email, Password));
            //if (isValidUser)
            //{
            //    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Email), null);
            //    IsViewVisible = false;
            //}
            //else
            //{
            //    ErrorMessage = " Invalid username or password";
            //}

            //var loginView = new Login();
            //loginView.Show();

            //if (IsViewVisible == true)
            //{
            //var mainView = new MainWindow();
            //mainView.Show();
            //loginView.Close();
            //}

        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }



    }
}
