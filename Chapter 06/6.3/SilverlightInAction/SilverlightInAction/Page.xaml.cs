using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows;
using SilverlightInAction.SilverService;

namespace SilverlightInAction
{
  public partial class Page
  {
    public Page()
    {
      InitializeComponent();
    }

    private void btnTime_Click(object sender, RoutedEventArgs e)
    {
      Binding myBinding = new BasicHttpBinding();

      //The port number & path needs updated for your application
      EndpointAddress myEndpoint = new EndpointAddress("http://localhost:53015/SampleAsmx.asmx");

      SampleAsmxSoapClient proxy = new SampleAsmxSoapClient (myBinding, myEndpoint);

      proxy.GetTimeCompleted += proxy_GetTimeCompleted;
      proxy.GetTimeAsync();
    }

    void proxy_GetTimeCompleted(object sender, GetTimeCompletedEventArgs e)
    {
      txResults.Text = e.Result.ToLongTimeString();
      ((SampleAsmxSoapClient)sender).CloseAsync();
    }
  }
}
