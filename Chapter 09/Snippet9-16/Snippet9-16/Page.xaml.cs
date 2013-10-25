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

namespace Snippet9_16
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myStoryboard1_Completed(object sender, EventArgs e)
        {
            myStoryboard2.Begin();            
        }

        private void myMediaElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            myStoryboard1.Begin();            
        }
    }
}
