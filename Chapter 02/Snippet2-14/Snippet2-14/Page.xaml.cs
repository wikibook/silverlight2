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

namespace Snippet2_14
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
            HtmlElement myTextField = document.GetElementById("myTextField");

            int value = Convert.ToInt32(myTextField.GetProperty("value"));            
            value = value + 1;
            myTextField.SetProperty("value", Convert.ToString(value));                

        }
    }
}
