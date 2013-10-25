using System;
using System.IO;
using System.Json;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Runtime.Serialization.Json;

namespace JSON
{
  public partial class Page : UserControl
  {
    SynchronizationContext uiThread;

    public Page()
    {
      InitializeComponent();
    }

    private void LoadJSON(object sender, RoutedEventArgs e)
    {
        uiThread = SynchronizationContext.Current;

        string uriPath = "http://ws.geonames.org/neighbourhoodJSON?formatted=true&lat={0}&lng={1}&style=full";
        Uri uri = new Uri(string.Format(uriPath, txLat.Text, txLong.Text),
          UriKind.Absolute);

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        request.BeginGetResponse(GetResults, request);
    }

    public void GetResults(IAsyncResult e)
    {
        HttpWebRequest request = (HttpWebRequest)e.AsyncState;
        HttpWebResponse response =
          (HttpWebResponse)request.EndGetResponse(e);
        Stream responseStream = response.GetResponseStream();

        uiThread.Post(UpdateTextJSONObject, responseStream);
    }

    public void UpdateTextJSONObject(Object stream)
    {
        JsonObject hood = (JsonObject)JsonObject.Load((Stream)stream);

        txCity.Text = hood["neighbourhood"]["city"];
        txName.Text = hood["neighbourhood"]["name"];
        txtResults.Text = hood.ToString();
    }

      public void UpdateTextJsonSerializer(object stream)
      {
          DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(MyResults));
          MyResults hood = (MyResults)ser.ReadObject((Stream)stream);

          txCity.Text = hood.neighbourhood.city;
          txName.Text = hood.neighbourhood.name;
      }
  }

  public class MyResults
  {
      public Neighborhood neighbourhood { get; set; }
  }

  public class Neighborhood
  {
      public string adminName2 { get; set; }
      public string adminCode2 { get; set; }
      public string adminCode1 { get; set; }
      public string countryName { get; set; }
      public string name { get; set; }
      public string countryCode { get; set; }
      public string city { get; set; }
      public string adminName1 { get; set; }
  }
}
