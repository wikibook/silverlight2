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
using System.Threading;
using System.Xml;
using System.ServiceModel.Syndication;
using System.IO;
using System.Text;

namespace SyndicatedFeeds
{
    public partial class Page : UserControl
    {
        SynchronizationContext uiThread;

        public Page()
        {
            InitializeComponent();
        }


        private void btnRSS_Click(object sender, RoutedEventArgs e)
        {
            uiThread = SynchronizationContext.Current;

            Uri uri = new Uri("http://feeds.feedburner.com/ToCodeOrNotToCode");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.BeginGetResponse(ReadRSS, request);
        }

        public void ReadRSS(IAsyncResult e)
        {
            HttpWebRequest request = (HttpWebRequest)e.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(e);
            Stream responseStream = response.GetResponseStream();

            XmlReader reader = XmlReader.Create(responseStream);
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            response.Close();
            uiThread.Post(ShowRSS, feed);
        }

        public void ShowRSS(Object rawFeed)
        {
            FeedList.ItemsSource = ((SyndicationFeed)rawFeed).Items;
        }
    }
}
