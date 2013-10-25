using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;

namespace WCFDuplex.Web
{
  public class ScoreDuplexServiceHost : ServiceHostFactoryBase
  {
    public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
    {
      return new ScoreSimplexServiceHost(baseAddresses);
    }
  }

  class ScoreSimplexServiceHost : ServiceHost
  {
    public ScoreSimplexServiceHost(params System.Uri[] addresses)
    {
      base.InitializeDescription(typeof(ScoreService),new UriSchemeKeyedCollection(addresses));
    }

    protected override void InitializeRuntime()
    {
      PollingDuplexBindingElement poll = new PollingDuplexBindingElement();
      poll.ServerPollTimeout = TimeSpan.FromSeconds(2);
      poll.InactivityTimeout = TimeSpan.FromMinutes(2);

      TextMessageEncodingBindingElement textBinding = new TextMessageEncodingBindingElement();
      textBinding.MessageVersion = MessageVersion.Soap11;
      textBinding.WriteEncoding = System.Text.Encoding.UTF8;

      CustomBinding duplexBinding = new CustomBinding(poll, textBinding, new HttpTransportBindingElement());

      this.AddServiceEndpoint(typeof(IScoreService), duplexBinding, "");

      base.InitializeRuntime();
    }
  }

}
