using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirtsAppDesktop.ViewModels
{
    public class PdfViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        private Stream docStream;
        public Stream DocumentStream {
            get { return docStream; }
            set { 
                docStream = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DocumentStream"));
                //OnPropertyChanged(new PropertyChangedEventArgs(nameof(DocumentStream)));
            }
        }

        public PdfViewModel()
        {
            docStream = new FileStream(@"..\..\eventos-unilab.pdf", FileMode.OpenOrCreate);
            //docStream = new FileStream(@"..\..\README.pdf", FileMode.OpenOrCreate);
        }
    }
}
