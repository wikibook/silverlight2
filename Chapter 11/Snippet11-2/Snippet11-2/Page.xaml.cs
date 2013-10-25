using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Windows.Browser;

namespace Snippet11_2
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
                // Create the isolated storage directory structure for figure 11.1
                CreateIsoStore(isoFile);
                
                string[] directory1 = isoFile.GetDirectoryNames("Directory1");
                string[] noDirFound = isoFile.GetDirectoryNames("Directory2");

                string[] testfile1 = isoFile.GetFileNames("testfile1.txt");
                string[] noFileFound = isoFile.GetFileNames("testfile2.txt");

                string[] nestedFile = isoFile.GetFileNames("Directory1/file1.txt");

                HtmlWindow window = HtmlPage.Window;
                window.Alert("Search for \"Directory1\" brought back " + directory1.Length + " result(s).");
                window.Alert("Search for \"Directory2\" brought back " + noDirFound.Length + " result(s).");
                window.Alert("Search for \"testfile1.txt\" brought back " + testfile1.Length + " result(s).");
                window.Alert("Search for \"testfile2.txt\" brought back " + noFileFound.Length + " result(s).");
                window.Alert("Search for \"Directory1/file1.txt\" brought back " + nestedFile.Length + " result(s).");
            }
        }

        private void CreateIsoStore(IsolatedStorageFile isoFile)
        {
            isoFile.CreateDirectory("Directory1");

            IsolatedStorageFileStream textfile2 = isoFile.CreateFile("textfile2.xml");
            textfile2.Close();

            IsolatedStorageFileStream textfile1 = isoFile.CreateFile("textfile1.txt");
            textfile1.Close();

            IsolatedStorageFileStream testfile1 = isoFile.CreateFile("testfile1.txt");
            testfile1.Close();

            IsolatedStorageFileStream nestedFile = isoFile.CreateFile("Directory1/file1.txt");
            nestedFile.Close();
        }
    }
}
