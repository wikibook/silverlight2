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

namespace Snippet11_10
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
                CreateSnippet10File(isoFile);
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("file1.txt", FileMode.Open, isoFile))   
                {
                    using (StreamReader writer = new StreamReader(stream))                
                    {                                                                     
                        myTextBlock.Text = writer.ReadToEnd();                              
                    }
                }
            }
        }

        private void CreateSnippet10File(IsolatedStorageFile isoFile)
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
    }
}
