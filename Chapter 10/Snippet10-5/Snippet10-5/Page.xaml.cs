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

namespace Snippet10_5
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            object resource = myStackPanel.Resources["theSolidColorBrush"];
            if (resource != null)
            {
                SolidColorBrush brush = (SolidColorBrush)(resource);
                brush.Color = Colors.Blue;
            }
        }
    }
}
