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

namespace Snippet11_8
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication();
            long newQuotaSize = isoFile.Quota * 2;
            bool requestAccepted = isoFile.IncreaseQuotaTo(newQuotaSize);

        }
    }
}
