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

using System.ComponentModel;
using System.Threading;
using System.Windows.Browser;

namespace Snippet11_13
{
    public partial class Page : UserControl
    {
        private BackgroundWorker backgroundWorker = null;                         

        public Page()
        {
            InitializeComponent();

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;

            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);            
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HtmlWindow window = HtmlPage.Window;
            window.Alert("Task Completed!");
        }

        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            myProgressBar.Value = e.ProgressPercentage;
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)                                          
            {                                                                       
                backgroundWorker.ReportProgress(i);                                  
                Thread.Sleep(25);                                                     
            }                                                                       
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            backgroundWorker.RunWorkerAsync();                                      
        }
    }
}
