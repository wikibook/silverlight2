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

namespace Snippet11_6
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
                if (isoFile.DirectoryExists("Directory1/SubDirectory1"))
                    isoFile.DeleteDirectory("Directory1/SubDirectory1");
                if (isoFile.DirectoryExists("Directory1/Sub2/Leaf"))
                    isoFile.DeleteDirectory("Directory1/Sub2/Leaf");

                bool sub1Exists = isoFile.DirectoryExists("Directory1/SubDirectory1");
                bool leafExists = isoFile.DirectoryExists("Directory1/Sub2/Leaf");

                HtmlWindow window = HtmlPage.Window;
                window.Alert("Does \"Directory1/SubDirectory1\" exist? " + sub1Exists);
                window.Alert("Does \"Directory1/Sub2/Leaf\" exist? " + leafExists);

                isoFile.CreateDirectory("Directory1/SubDirectory1");
                isoFile.CreateDirectory("Directory1/Sub2/Leaf");

                sub1Exists = isoFile.DirectoryExists("Directory1/SubDirectory1");
                leafExists = isoFile.DirectoryExists("Directory1/Sub2/Leaf");
                
                window.Alert("Does \"Directory1/SubDirectory1\" exist? " + sub1Exists);
                window.Alert("Does \"Directory1/Sub2/Leaf\" exist? " + leafExists);

            }
        }
    }
}
