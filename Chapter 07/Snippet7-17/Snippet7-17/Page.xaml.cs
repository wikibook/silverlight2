﻿using System;
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

namespace Snippet7_17
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            myMultiScaleImage.MouseLeftButtonUp += new MouseButtonEventHandler(myMultiScaleImage_MouseLeftButtonUp);
        }

        void myMultiScaleImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point newOrigin = e.GetPosition(myMultiScaleImage);
            myMultiScaleImage.ViewportOrigin =
              myMultiScaleImage.ElementToLogicalPoint(newOrigin);
        }
    }
}
