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
using myFirtsAppDesktop.Models;
using myFirtsAppDesktop.Repositories;
using System.Threading;
using System.Security.Principal;
using myFirtsAppDesktop.View;
using System.Security;
using myFirtsAppDesktop.ViewModel;

namespace myFirtsAppDesktop.View
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {


        public Login()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click (object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e) {

            using (UserDataContext context = new UserDataContext())
            {
                var Email = txtUser.Text;
                var Password = textPassword.Password;
                bool userFounded = context.Users.Any(user => user.Email == Email && user.Password == Password);

                if (userFounded)
                {
                    //MainWindow main = new MainWindow();
                    //App.Current.MainWindow = main;
                    //this.Close();
                    //main.Show();

                    //var loginView = new Login();
                    //var mainView = new MainWindow();
                    MainWindow mainView = new MainWindow();
                    mainView.Show();
                    //Application.Current.MainWindow.Show();
                    Close();

                } else
                {
                    ErrorMessage.Text = "Email ou Password invalida";
                }



            }

        }

        private void btnGoRegister_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            //ContainerLoginAndRegister.Children.Clear();
            usc = new RegisterControl();
            ContainerLoginAndRegister.Children.Add(usc);
            //var RegisterView = new Register();
            //RegisterView.Show();
            //var mainView = new MainWindow();
            //mainView.Close();
            //this.Hide();

        }


    }
}
