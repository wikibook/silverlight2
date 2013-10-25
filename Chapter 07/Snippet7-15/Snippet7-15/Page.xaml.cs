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

namespace Snippet7_15
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(Page_KeyDown);
            this.KeyUp += new KeyEventHandler(Page_KeyUp);
            myMultiScaleImage.MouseLeftButtonDown += new 
                MouseButtonEventHandler(myMultiScaleImage_MouseLeftButtonDown);                

        }

        private bool shouldZoom = true;                                           
        void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Shift)                                                 
                shouldZoom = false;
        }

        void Page_KeyUp(object sender, KeyEventArgs e)
        {
              shouldZoom = true;                                                      
        }

        void myMultiScaleImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(myMultiScaleImage);
            point = myMultiScaleImage.ElementToLogicalPoint(point);
            
            if (shouldZoom == true)
                myMultiScaleImage.ZoomAboutLogicalPoint(1.5, point.X, point.Y);       
            else
                myMultiScaleImage.ZoomAboutLogicalPoint(0.5, point.X, point.Y);       
        }
    }
}
