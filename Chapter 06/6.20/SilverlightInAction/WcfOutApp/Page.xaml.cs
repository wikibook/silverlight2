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

namespace WcfOutApp
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.SomeServiceClient serviceProxy = new WcfOutApp.ServiceReference1.SomeServiceClient();

            serviceProxy.GetSomeDataCompleted += new EventHandler<WcfOutApp.ServiceReference1.GetSomeDataCompletedEventArgs>(serviceProxy_GetSomeDataCompleted);
            serviceProxy.GetSomeDataAsync(1);
        }

        void serviceProxy_GetSomeDataCompleted(object sender, WcfOutApp.ServiceReference1.GetSomeDataCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                tbxMessage.Text = e.Error.Message;                
            }
            else if (e.myError != null)
            {
                tbxMessage.Text = e.myError.Message;
            }
            else
            {
                tbxMessage.Text = e.Result.ToString();
            }
        }
    }
}
