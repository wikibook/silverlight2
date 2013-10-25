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

using System.ComponentModel;
using System.Threading;

namespace Snippet11_14
{
    public partial class Page : UserControl
    {
        private BackgroundWorker backgroundWorker = null;                         

        public Page()
        {
            InitializeComponent();

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork +=new DoWorkEventHandler(backgroundWorker_DoWork);    
            backgroundWorker.RunWorkerAsync();                                      
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
 	        for (int i = 1; i <= 100; i++)                                          
            {                                                                       
                Thread.Sleep(25);                                                     
            }
        }
    }
}
