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

namespace Snippet11_19
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            RequestStreamContent();
        }

        public void RequestStreamContent()
        {
            Uri uri = new Uri("http://silverlightinaction.com/video3.wmv");        

            WebClient webClient = new WebClient();                                  
            webClient.OpenReadAsync(uri);                                    
        }
    }
}