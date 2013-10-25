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

using System.Windows.Interop;
using System.Windows.Browser;

namespace Snippet2_12
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            Application application = Application.Current;
            SilverlightHost host = application.Host;

            HtmlWindow window = HtmlPage.Window;
            window.Alert(host.IsLoaded.ToString());
        }
    }
}
