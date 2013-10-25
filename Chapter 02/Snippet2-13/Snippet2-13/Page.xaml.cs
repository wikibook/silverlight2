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

namespace Snippet2_13
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            HtmlDocument document = HtmlPage.Document;
            HtmlElement element = document.GetElementById("myDiv");

            HtmlWindow window = HtmlPage.Window;
            if (element == null)
                window.Alert("The element was not found.");
            else
                window.Alert("The element was found.");
        }
    }
}
