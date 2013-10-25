using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Snippet4_27
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|Xml Files (*.xml)|*.xml";
            bool? fileWasSelected = openFileDialog.ShowDialog();
            if (fileWasSelected == true)
            {
                FileInfo fileInfo = openFileDialog.File;
                StreamReader reader = fileInfo.OpenText();
                myTextBlock.Text = reader.ReadToEnd();             
            }
        }
    }
}
