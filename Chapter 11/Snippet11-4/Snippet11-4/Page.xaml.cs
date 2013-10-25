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

namespace Snippet11_4
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

                isoFile.DeleteFile("testfile1.txt");
                isoFile.DeleteFile("Directory1/file1.txt");

                HtmlWindow window = HtmlPage.Window;
                bool testfile1Exists = isoFile.FileExists("testfile1.txt");
                bool file1Exists = isoFile.FileExists("Directory1/file1.txt");
                window.Alert("Does \"testfile1.txt\" exist? " + testfile1Exists);
                window.Alert("Does \"Directory1/file1.txt\" exist? " + file1Exists);
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
