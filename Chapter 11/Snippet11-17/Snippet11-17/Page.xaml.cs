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

namespace Snippet11_17
{
    public partial class Page : UserControl
    {
        private BackgroundWorker backgroundWorker = null; 

        public Page()
        {
            InitializeComponent();

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true; 
            backgroundWorker.WorkerSupportsCancellation = true;                     

            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged+= new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);

            backgroundWorker.RunWorkerAsync();                                      
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            myProgressBar.Visibility = Visibility.Collapsed;
        }

        void  backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            myProgressBar.Value = e.ProgressPercentage;
        }

        void  backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (backgroundWorker.CancellationPending == true)
                    return;

                backgroundWorker.ReportProgress(i);
                Thread.Sleep(25);
            }                                                                       
        }

        private void LayoutRoot_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Escape) && (backgroundWorker.IsBusy == true))
                backgroundWorker.CancelAsync();
        }
    }
}
