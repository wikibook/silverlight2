using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;

namespace WCFDuplex.Web
{
  public class ScoreService : IScoreService
  {
    IScoreClient client;
    int responseNumber = 0;

    public void Register(Message receivedMessage)
    {
      client = OperationContext.Current.GetCallbackChannel<IScoreClient>();

      using (Timer timer = new Timer(new TimerCallback(SendScore), receivedMessage.GetBody<string>(), 2000, 2000))
      {
        Thread.Sleep(9000);
      }
    }

    private void SendScore(object game)
    {
      string Score;

      if (responseNumber == 3)
        Score = "Game Over";
      else
        Score = (string)game + " score: 1 - " + responseNumber.ToString();

      responseNumber++;

      Message returnMessage = Message.CreateMessage(MessageVersion.Soap11, "Silverlight/IScoreService/ScoreUpdate",Score);

      client.ScoreUpdate(returnMessage);
    }
  }
}
