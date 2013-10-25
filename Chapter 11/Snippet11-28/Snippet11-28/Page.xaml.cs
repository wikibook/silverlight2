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

namespace Snippet11_28
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }
    }

    public interface IFlyable                                              
    {                                                                      
        void Fly(TextBlock textBlock);                                     
    }                                                                      

    public class Bird : IFlyable                                           
    {
        public void Fly(TextBlock tb)
        { tb.Text = "This bird is flying!"; }
    }

    public class Plane : IFlyable                                         
    {
        public void Fly(TextBlock tb)
        { tb.Text = "This plane is flying!"; }
    }
}
