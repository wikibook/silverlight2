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

namespace Snippet7_3
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myMediaElement_DownloadProgressChanged(object sender, RoutedEventArgs e)
        {
            double percentage = myMediaElement.DownloadProgress * 100;          
            string text = String.Format("{0:f}", percentage) + "%";             
            myTextBlock.Text = text;                                            
        }
    }
}
