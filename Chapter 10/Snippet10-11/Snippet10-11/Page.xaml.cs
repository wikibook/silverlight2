using System;
using System.Collections.Generic;
using System.Windows.Resources;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Snippet10_11
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            StreamResourceInfo resource = Application.GetResourceStream(new Uri("Snippet10-11;component/embedded.png", UriKind.Relative));
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.SetSource(resource.Stream);
            myImage.Source = bitmapImage;
        }
    }
}