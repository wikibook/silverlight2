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

namespace Snippet11_3
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

                string[] results1 = isoFile.GetFileNames("*");
                string[] results2 = isoFile.GetFileNames("Directory1/*");
                string[] results3 = isoFile.GetFileNames("textfile*");
                string[] results4 = isoFile.GetFileNames("*.txt");

                HtmlWindow window = HtmlPage.Window;
                window.Alert("Search for \"*\" brought back " + results1.Length + " result(s).");
                window.Alert("Search for \"Directory1\" brought back " + results2.Length + " result(s).");
                window.Alert("Search for \"textfile*\" brought back " + results3.Length + " result(s).");
                window.Alert("Search for \"*.txt\" brought back " + results4.Length + " result(s).");
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
