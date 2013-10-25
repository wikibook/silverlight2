using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Snippet5_1
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            DateTime currentTime = DateTime.Now;       

            Binding binding = new Binding("TimeOfDay");                               
            binding.Source = currentTime;                                             
            binding.Mode = BindingMode.OneWay;                                        
            myTextBox.SetBinding(TextBox.TextProperty, binding);                      

        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;       

            Binding binding = new Binding("TimeOfDay");                               
            binding.Source = currentTime;                                             
            binding.Mode = BindingMode.OneWay;                                        
            myTextBox.SetBinding(TextBox.TextProperty, binding);                      
        }
    }
}
