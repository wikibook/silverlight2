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

using System.Windows.Markup;

namespace Snippet11_11
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            string xaml = "<Rectangle xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Height=\"60\" Width=\"20\" Fill=\"Blue\" />";  
            Rectangle rectangle = (Rectangle) XamlReader.Load(xaml); 
            myCanvas.Children.Add(rectangle);     
        }
    }
}
