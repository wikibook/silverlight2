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

namespace Snippet10_2
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Green;

            // This will cause an error because a resource with the same key already exists.
            // This is just to show the syntax. You can remove the resource from XAML and uncomment
            // this line if you would like.
            //myStackPanel.Resources.Add("theSolidColorBrush", brush);
        }
    }
}
