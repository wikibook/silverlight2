using System;
using System.IO;
using System.Json;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace POX
{
  public partial class Page
  {
    SynchronizationContext uiThread;

    public Page()
    {
      InitializeComponent();
    }

    private void LoadXML(object sender, RoutedEventArgs e)
    {
      uiThread = SynchronizationContext.Current;

      //This is for the XML calls
      string uriPath = "http://ws.geonames.org/neighbourhood?lat={0}&lng={1}&style=ful";

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

      uiThread.Post(UpdateTextXLINQ, responseStream);
    }

    public void UpdateTextXLINQ(object stream)
    {
      XmlReader responseReader = XmlReader.Create((Stream)stream);
      XElement xmlResponse = XElement.Load(responseReader);
      XElement root = xmlResponse.Element("neighbourhood");

      txtResults.Text = root.ToString();
      txCity.Text = (string)root.Element("city");
      txName.Text = (string)root.Element("name");
    }

    public void UpdateTextXmlSerializer(Object stream)
    {
      XmlReader responseReader = XmlReader.Create((Stream)stream);
      responseReader.ReadToFollowing("neighbourhood");
      XmlSerializer serializer = new XmlSerializer(typeof(Neighborhood));
      Neighborhood hood =
        (Neighborhood)serializer.Deserialize(responseReader);

      txCity.Text = hood.city;
      txName.Text = hood.name;
    }

    public void UpdateTextXmlReader(object stream)
    {
      XmlReader responseReader = XmlReader.Create((Stream)stream);
      responseReader.Read();

      responseReader.ReadToFollowing("city");
      string city = responseReader.ReadElementContentAsString();
      responseReader.ReadToFollowing("name");
      string name = responseReader.ReadElementContentAsString();
      responseReader.ReadEndElement();
      responseReader.ReadEndElement();

      txCity.Text = city;
      txName.Text = name;
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
