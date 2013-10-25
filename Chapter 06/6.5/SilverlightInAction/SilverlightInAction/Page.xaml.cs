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

    private void btnString_Click(object sender, RoutedEventArgs e)
    {
      Binding myBinding = new BasicHttpBinding();
      //The port number & path needs updated for your application
      EndpointAddress myEndpoint = new EndpointAddress("http://localhost:53015/SampleAsmx.asmx");

      SampleAsmxSoapClient proxy = new SampleAsmxSoapClient(myBinding, myEndpoint);

      proxy.GetCoolTextCompleted += proxy_GetCoolTextCompleted;
      proxy.GetCoolTextAsync(1);
    }

    void proxy_GetCoolTextCompleted(object sender, GetCoolTextCompletedEventArgs e)
    {
      txResults.Text = e.Result;
      ((SampleAsmxSoapClient)sender).CloseAsync();
    }


    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
      UploadUser();
    }

    private void UploadUser()
    {
      Binding myBinding = new BasicHttpBinding();
      EndpointAddress myEndpoint = new EndpointAddress("http://localhost:53015/SampleAsmx.asmx");
      SampleAsmxSoapClient proxy = new SampleAsmxSoapClient(myBinding, myEndpoint);

      WsUser myData = new WsUser { Id = 3, Name = "John", IsValid = true };

      proxy.SetSomethingCompleted += proxy_SetSomethingCompleted;
      proxy.SetSomethingAsync(1, myData);

    }

    void proxy_SetSomethingCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
      ((SampleAsmxSoapClient)sender).CloseAsync();
      txResults.Text = "Done";
    }

  }
}
