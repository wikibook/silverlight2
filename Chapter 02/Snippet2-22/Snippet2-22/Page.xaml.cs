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

using System.Windows.Browser;

namespace Snippet2_22
{
    [ScriptableType]
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        [ScriptableMember]
        public void ExecuteWebService()
        {
            // Make a call to a web service
        }
    }
}
