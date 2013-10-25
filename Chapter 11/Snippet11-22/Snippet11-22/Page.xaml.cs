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

using System.Windows.Browser;

namespace Snippet11_22
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void RequestContent()
        {
            Uri address = new Uri("http://ws.geonames.org/findNearByWeatherJSON?lat=35.82&lng=-84.04");

            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            webClient.DownloadStringAsync(address);                                 
        }

        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)                                     
        {
            HtmlWindow window = HtmlPage.Window;
            window.Alert(e.Result);                                                 
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            RequestContent();
        }
    }
}
