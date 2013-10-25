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
using System.IO;

namespace TimeForARest
{
  public partial class Page : UserControl
  {
    private SynchronizationContext UIThread;

    public Page()
    {
      InitializeComponent();
    }

    private void btnSingleXml_Click(object sender, RoutedEventArgs e)
    {
      UIThread = SynchronizationContext.Current;

      string rawPath = "http://localhost:50145/Authors.svc/SingleXml/{0}";

      Uri path = new Uri(string.Format(rawPath, tbxInput.Text), UriKind.Absolute);
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
      request.BeginGetResponse(SingleXmlCallBack, request);
    }

    private void SingleXmlCallBack(IAsyncResult result)
    {
      HttpWebRequest request = (HttpWebRequest)result.AsyncState;
      HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
      Stream responseStream = response.GetResponseStream();

      UIThread.Post(UpdateUiText, responseStream);
    }

    private void UpdateUiText(object stream)
    {
      if (stream != null)
      {
        StreamReader sr = new StreamReader((Stream)stream);
        tbkRaw.Text = sr.ReadToEnd();
      }
      else
      {
        tbkRaw.Text = "";
      }
    }
  }
}
