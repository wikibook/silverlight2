using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Snippet7_5
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Your video is ");
            sb.Append(myMediaElement.NaturalDuration.TimeSpan.Minutes);
            sb.Append(" minutes, ");
            sb.Append(myMediaElement.NaturalDuration.TimeSpan.Seconds);
            sb.Append(" seconds, and ");
            sb.Append(myMediaElement.NaturalDuration.TimeSpan.Milliseconds);
            sb.Append("milliseconds.");

            myTextBlock.Text = sb.ToString();
        }
    }
}
