using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.IO;
using System.Windows.Resources;
using System.Windows.Media.Imaging;

namespace Snippet11_25
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            RequestContent();
        }

        private void RequestContent()
        {
            Uri address = new Uri("http://www.silverlightinaction.com/files.zip");  

            WebClient webClient = new WebClient();
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
            webClient.OpenReadAsync(address, "man.png");                            
        }

        void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            Uri part = new Uri(Convert.ToString(e.UserState), UriKind.Relative);    
            StreamResourceInfo zipStream = new StreamResourceInfo(e.Result as Stream, null);                     
            StreamResourceInfo imageStream = Application.GetResourceStream(zipStream, part);                       

            BitmapImage image = new BitmapImage();                                  
            image.SetSource(imageStream.Stream);                                    
            myImage.Source = image;                                                 
        }
    }
}
