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

namespace Snippet2_16
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            HtmlWindow window = HtmlPage.Window;
            HtmlDocument document = HtmlPage.Document;

            if (document.QueryString.Keys.Count == 0)
                window.Alert("Please add some query string parameters.");

            foreach (string key in document.QueryString.Keys)
            {
                window.Alert("Key: " + key + "; Value: " + document.QueryString[key]);
            }
        }
    }
}
