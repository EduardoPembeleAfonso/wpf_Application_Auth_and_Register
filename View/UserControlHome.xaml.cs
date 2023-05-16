using Microsoft.EntityFrameworkCore;
using myFirtsAppDesktop.Models;
using myFirtsAppDesktop.Repositories;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace myFirtsAppDesktop.View
{
    /// <summary>
    /// Interação lógica para UserControlHome.xam
    /// </summary>
    public partial class UserControlHome : UserControl
    {
        public List<UserModel> Databaseusers { get; private set; }
        UserDataContext context;
        UserModel NewUser = new UserModel();
        public UserControlHome()
        {
            //this.context = context;
            InitializeComponent();
            GetAllUsers();

            //AddNewUserGrid.DataContext = NewUser;
        }

        // minhas funcoes que sao chamadas pelos metodos
        public void GetAllUsers()
        {
            using (UserDataContext context = new UserDataContext())
            {
                Databaseusers = context.Users.ToList();
                ItemList.ItemsSource = Databaseusers;
            }
        }

        public void CreateUser()
        {

            using (UserDataContext contexts = new UserDataContext())
            {
                int Id = 0;
                Random randNum = new Random();
                for (int i = 0; i < 10; i++)
                    Id = randNum.Next(1, 100);
                var name = NameTextBox.Text;
                //var id = IdTextBox.Text;
                //int Id = int.Parse(id);
                var email = EmailTextBox.Text;
                var username = UsernameTextBox.Text;
                var lastname = LastnameTextBox.Text;
                var password = PasswordTextBox.Text;

                if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(password))
                {
                    ErrorCreateUser.Text = "Por favor preencha todos os campos!";
                    
                } else
                {
                    contexts.Users.Add(new UserModel()
                    {
                        Name = name,
                        Password = password,
                        Email = email,
                        Id = Id,
                        LastName = lastname,
                        Username = username
                    });
                    contexts.SaveChanges();
                }

            }
        }


        public void UpdateUser()
        {


            using (UserDataContext context = new UserDataContext())
            {

                UserModel selectedUser = ItemList.SelectedItem as UserModel;

                var name = NameEditTextBox.Text;
                var email = EmailEditTextBox.Text;
                var username = UsernameEditTextBox.Text;
                var lastname = LastnameEditTextBox.Text;
                var password = PasswordEditTextBox.Text;

                if (email != null && password != null)
                {

                    UserModel user = context.Users.Find(selectedUser.Id);
                    //EditUserGrid.DataContext = user;
                    user.Name = name;
                    user.Password = password;
                    user.Username = username;
                    user.Email = email;
                    //user.Id = id;
                    user.LastName = lastname;

                    context.SaveChanges();
                }

            }



        }

        public void Delete()
        {


            using (UserDataContext context = new UserDataContext())
            {

                UserModel selectedUser = ItemList.SelectedItem as UserModel;

                if (selectedUser != null)
                {
                    UserModel user = context.Users.Single(x => x.Id == selectedUser.Id);

                    context.Remove(user);
                    context.SaveChanges();

                }



            }



        }

        // metodos dos buttons
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            CreateUser();
            GetAllUsers();

        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            GetAllUsers();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateUser();
            GetAllUsers();
        }

        private void DeleteButton_Click(object s, RoutedEventArgs e)
        {
            Delete();
            GetAllUsers();

        }
    }
}
