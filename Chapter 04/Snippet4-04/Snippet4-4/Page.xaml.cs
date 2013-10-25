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

namespace Snippet4_4
{
    public partial class Page : UserControl
    {
        private bool isMouseDown = false;
        private Point lastPoint = new Point();
        private Point offset = new Point();

        public Page()
        {
            InitializeComponent();
        }

        public void MyTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)                                               
        {                                                                         
            myTextBlock.CaptureMouse();                                             
            isMouseDown = true;                                                     
                                                                                
            lastPoint = e.GetPosition(null);                                        
            offset.X = lastPoint.X - Convert.ToDouble(myTextBlock.GetValue(Canvas.LeftProperty));
            offset.Y = lastPoint.Y - Convert.ToDouble(myTextBlock.GetValue(Canvas.TopProperty));          
        }                                                                         

        public void MyTextBlock_MouseMove(object sender, MouseEventArgs e)        
        {                                                                         
            if (isMouseDown == true)                                                
            {                                                                       
                lastPoint = e.GetPosition(null);                                      
                myTextBlock.SetValue(Canvas.LeftProperty, (lastPoint.X-offset.X));    
                myTextBlock.SetValue(Canvas.TopProperty, (lastPoint.Y-offset.Y));     
            }                                                                       
        }                                                                         

        public void MyTextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)                                                 
        {                                                                         
            myTextBlock.ReleaseMouseCapture();                                      
            isMouseDown = false;                                                   
        }   
    }
}
