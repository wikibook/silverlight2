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

namespace Snippet11_23
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
            Uri address = new Uri("http://www.silverlightinaction.com/video2.wmv");

            WebClient webClient = new WebClient();
            webClient.OpenReadCompleted += new 
            OpenReadCompletedEventHandler(webClient_OpenReadCompleted);           
            webClient.OpenReadAsync(address);                                       
        }

        void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)                                           
        {
            myMediaElement.SetSource(e.Result);                                     
        }
    }
}
