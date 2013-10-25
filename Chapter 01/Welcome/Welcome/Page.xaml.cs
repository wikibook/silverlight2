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

namespace Welcome
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            myMediaElement.MouseLeftButtonUp += new MouseButtonEventHandler(myMediaElement_MouseLeftButtonUp);

        }

        void myMediaElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (myMediaElement.CurrentState == MediaElementState.Playing)
                myMediaElement.Pause();
            else
                myMediaElement.Play();
        }
    }
}
