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

using System.Windows.Browser;

namespace Snippet3_4
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            HtmlPage.RegisterScriptableObject("bridge", this);
        }

        [ScriptableMember]
        public void MoveText()
        {
            double newLeft = Canvas.GetLeft(tb) + 15;                        
            Canvas.SetLeft(tb, newLeft);                                     

            double newTop = Canvas.GetTop(tb) + 30;                          
            Canvas.SetTop(tb, newTop);                                       
        }
    }
}