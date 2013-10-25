﻿using System;
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

using System.Text;

namespace Snippet11_21
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        WebClient webClient = new WebClient();

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            RequestStreamContent();
        }

        public void RequestStreamContent()
        {
            Uri uri = new Uri("http://silverlightinaction.com/video3.wmv");        
            
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            webClient.OpenReadAsync(uri);                                    
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(e.BytesReceived + " of ");                                    
            sb.Append(e.TotalBytesToReceive + " bytes received");                   

            myTextBlock.Text = sb.ToString();            
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (webClient.IsBusy)                                                   
            {
                webClient.CancelAsync();                                              
            }
        }
    }
}
