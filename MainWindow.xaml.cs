using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.PdfViewer;
using myFirtsAppDesktop.View;
using myFirtsAppDesktop.Models;
using myFirtsAppDesktop.Repositories;

namespace myFirtsAppDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

        public partial class MainWindow : Window
        {
            public List<UserModel> Databaseusers { get; private set; }

            public MainWindow()
            {
                InitializeComponent();
            }


        public void Read()
        {
            using (UserDataContext context = new UserDataContext())
            {
                //Databaseusers = context.Users.ToList();
                //ItemList.ItemsSource = Databaseusers;
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            throw new NotImplementedException();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e) {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e) {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridContainerItems.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new UserControlHome();
                    GridContainerItems.Children.Add(usc);
                    break;
                case "ItemCreate":
                    //GridMain.Navigate(new Uri("Pages/Home.xaml", UriKind.RelativeOrAbsolute));
                    //PdfViewerControl pdfViewer = new PdfViewerControl();
                    //GridContainerItems.Children.Add(pdfViewer);
                    var ob = new UserControlCreate01();
                    ob.Show();
                    WindowState = WindowState.Minimized;
                    //usc = new UserControlCreate();
                    //GridMain.Children.Add(usc);
                    break;

                case "Logout_Click":
                    //Close();
                    Application.Current.Shutdown();
                    break;
                default:
                    break;
            }
        }


    }

}