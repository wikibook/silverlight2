using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WCFDuplex.Web
{
  [ServiceContract(Namespace = "Silverlight",CallbackContract = typeof(IScoreClient))]
  public interface IScoreService
  {
    [OperationContract(IsOneWay = true)]
    void Register(Message receivedMessage);
  }

  [ServiceContract]
  public interface IScoreClient
  {
    [OperationContract(IsOneWay = true)]
    void ScoreUpdate(Message returnMessage);
  }
}

