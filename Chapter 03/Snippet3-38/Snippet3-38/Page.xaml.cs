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

namespace Snippet3_38
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void MyTextBlock_Click(object sender, MouseButtonEventArgs e)
        {
            double top = Convert.ToDouble(myTextBlock.GetValue(Canvas.TopProperty));           
            double left = Convert.ToDouble(myTextBlock.GetValue(Canvas.LeftProperty));          

            myTextBlock.SetValue(Canvas.TopProperty, (top+5));                      
            myTextBlock.SetValue(Canvas.LeftProperty, (left+5));                    
        }
    }
}
