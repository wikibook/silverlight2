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

using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Browser;

namespace Snippet11_9
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
                if (isoFile.FileExists("file1.txt"))
                    isoFile.DeleteFile("file1.txt");

                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("file1.txt", FileMode.Create, isoFile)) 
                {
                    using (StreamWriter writer = new StreamWriter(stream))               
                    {                                                                    
                        writer.Write("Hello, from the isolated storage area!");             
                    }                    
                }
            }

            HtmlWindow window = HtmlPage.Window;
            window.Alert("File written!");
        }
    }
}
