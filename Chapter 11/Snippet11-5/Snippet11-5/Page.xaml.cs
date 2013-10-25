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

using System.IO.IsolatedStorage;
using System.Windows.Browser;


namespace Snippet11_5
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isoFile.DirectoryExists("Directory1"))
                {                    
                    isoFile.DeleteDirectory("Directory1");
                }

                HtmlWindow window = HtmlPage.Window;
                bool directoryExists = isoFile.DirectoryExists("Directory1");
                window.Alert("Does \"Directory1\" exist in isolated storage? " + directoryExists);

                isoFile.CreateDirectory("Directory1");

                directoryExists = isoFile.DirectoryExists("Directory1");
                window.Alert("Does \"Directory1\" exist in isolated storage? " + directoryExists);
            }
        }
    }
}
