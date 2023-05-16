using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;
using myFirtsAppDesktop.View;
using myFirtsAppDesktop.Repositories;
//AppDomain.CurrentDomain.SetupInformation.PrivateBinPath = "mySubFolderName";

namespace myFirtsAppDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqVk1mQ1BEaV1CX2BZe1l3RWlcdk4BCV5EYF5SRHNeQ11mSH9TdkJlW3g=;Mgo+DSMBPh8sVXJ1S0R+X1pCaV5CQmFJfFBmQGlYf1R1fUU3HVdTRHRcQlhiSH5Wd0RjWXhWcXM=;ORg4AjUWIQA/Gnt2VFhiQlJPcEBDXXxLflF1VWZTfl56cVxWESFaRnZdQV1mSH9Tc0RiWX9WcHZS;MjAwNjMwOUAzMjMxMmUzMjJlMzNWUzlZUVl1T0xkTThIWmdPT1RNZVpLZjg4Ni9hdVVqL1BTZXdaR3hsOEY4PQ==;MjAwNjMxMEAzMjMxMmUzMjJlMzNMMGhuV2kweUxtc2I4YkI5dzBBeVpIUXFhb2tna3hJY2kzYnhqajRXeklzPQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfVldXGNWfFN0RnNcdV9wflBPcC0sT3RfQF5jTH9SdkBiWH9fcHJcTg==;MjAwNjMxMkAzMjMxMmUzMjJlMzNKcHlIQ1czSW5CNUhhYytnUEpXeFFweHRzL01PaHJHSVppNnVXd3I5RUVNPQ==;MjAwNjMxM0AzMjMxMmUzMjJlMzNNMHRlSFdZa0V4Y014bUU3RDh4YUNBZHRYck5EWG5UbFd5MFZ2NXZQMzUwPQ==;Mgo+DSMBMAY9C3t2VFhiQlJPcEBDXXxLflF1VWZTfl56cVxWESFaRnZdQV1mSH9Tc0RiWX5fd3Vd;MjAwNjMxNUAzMjMxMmUzMjJlMzNTaGUyUldJVlp6dnpHaUs4amFhcldjeEZHM2hSSUd4NDlQRWJOenh6RDQ4PQ==;MjAwNjMxNkAzMjMxMmUzMjJlMzNLZVRndWJCdzI3eXpTTGFYRFFTZXBabFppTXdmZitrbWhQdmc5ck9rL1FNPQ==;MjAwNjMxN0AzMjMxMmUzMjJlMzNKcHlIQ1czSW5CNUhhYytnUEpXeFFweHRzL01PaHJHSVppNnVXd3I5RUVNPQ==");
            //AppDomain.CurrentDomain.UnhandledException { get;  };
            //Application.Current.DispatcherUnhandledException;
            //TaskScheduler.UnobservedTaskException;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DatabaseFacade facade = new DatabaseFacade(new UserDataContext());
            facade.EnsureCreated();
        }

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    DatabaseFacade facade = new DatabaseFacade(new UserDataContext());
        //    facade.EnsureCreated();
        //}

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {

            DatabaseFacade facade = new DatabaseFacade(new UserDataContext());
            facade.EnsureCreated();

            var loginView = new Login();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    //var mainView = new MainWindow();
                    //mainView.Show();
                    //loginView.Close();
                }
            };
            //loginView.Show();
        }
    }
}
