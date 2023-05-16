using Syncfusion.Windows.PdfViewer;
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
using myFirtsAppDesktop.View;

namespace myFirtsAppDesktop.View
{
    /// <summary>
    /// Lógica interna para UserControlCreate01.xaml
    /// </summary>
    public partial class UserControlCreate01 : Window
    {
        public UserControlCreate01()
        {
            InitializeComponent();
            PdfViewerControl pdfViewer = new PdfViewerControl();
            GridUserCreate.Children.Add(pdfViewer);
        }

        public static implicit operator UserControl(UserControlCreate01 v)
        {
            throw new NotImplementedException();
        }
    }
}
