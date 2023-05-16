using myFirtsAppDesktop.Models;
using myFirtsAppDesktop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace myFirtsAppDesktop.View
{
    /// <summary>
    /// Interação lógica para RegisterControl.xam
    /// </summary>
    public partial class RegisterControl : UserControl
    {


        public RegisterControl()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            using (UserDataContext context = new UserDataContext())
            {
                bool userFound = context.Users.Any(user => user.Email == txtUserEmail.Text);

                if (!userFound)
                {
                    int Id = 0;
                    Random randNum = new Random();
                    for (int i = 0; i < 10; i++)
                        Id = randNum.Next(1, 100);

                    if (txtUserEmail.Text != null && textPassword.Password != null && txtUserName.Text != null)
                    {
                        context.Users.Add(new UserModel()
                        {
                            Name = txtUserName.Text,
                            LastName = txtUserLastName.Text,
                            Email = txtUserEmail.Text,
                            Password = textPassword.Password,
                            Username = txtUserUserName.Text,
                            Id = Id
                        });

                        context.SaveChanges();
                        var mainView = new MainWindow();
                        mainView.Show();
                        Window.GetWindow(this).Close();
                    }

                }
                else
                {
                    ErrorMessage.Text = "Esse email ja existe!";
                }
            }
        }


        private void btnBackLogin_Click(object sender, RoutedEventArgs e)
        {

            var loginView = new Login();
            loginView.Show();
            Window.GetWindow(this).Close();


            //UserControl usc = null;
            //ContainerLoginAndRegister.Children.Clear()
            //usc = new Login();
            //ContainerLoginAndRegister.Children.Add(usc);
        }

    }
}
