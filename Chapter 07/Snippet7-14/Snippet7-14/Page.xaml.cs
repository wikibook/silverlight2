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

namespace Snippet7_14
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            myMultiScaleImage.Source = new DeepZoomImageTileSource(new System.Uri("images/dzc_output.xml", UriKind.Relative));
        }
    }
}
