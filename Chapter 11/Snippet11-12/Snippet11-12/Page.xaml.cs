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

namespace Snippet11_12
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            string xaml = "<Grid xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Grid.ColumnDefinitions>" +
                "<ColumnDefinition /><ColumnDefinition /></Grid.ColumnDefinitions>" +
                "<Grid.RowDefinitions><RowDefinition /><RowDefinition />" +
                "</Grid.RowDefinitions><TextBlock Text=\"Name: \" />" +
                "<TextBox Width=\"80\" Height=\"20\" Grid.Column=\"1\" />" +
                "<TextBlock Text=\"Email Address: \" Grid.Row=\"1\" />" +
                "<TextBox Grid.Row=\"1\" Grid.Column=\"1\" Width=\"80\" Height=\"20\" />" +
                "</Grid>";

            Grid myGrid = (Grid)XamlReader.Load(xaml);
            myCanvas.Children.Add(myGrid);

        }
    }
}
