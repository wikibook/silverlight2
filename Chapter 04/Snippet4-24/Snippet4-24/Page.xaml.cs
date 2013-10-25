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

namespace Snippet4_24
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            myButton.Click += new RoutedEventHandler(myButton_Click);

            myPopup.IsOpen = true;
        }

        void myButton_Click(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = false;
        }
    }
}
