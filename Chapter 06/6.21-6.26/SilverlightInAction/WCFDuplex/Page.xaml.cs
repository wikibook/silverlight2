using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace WCFDuplex
{
    public partial class Page : UserControl
    {
        SynchronizationContext uiThread;

        public Page()
        {
            InitializeComponent();
        }

        private void btnGetScores_Click(object sender, RoutedEventArgs e)
        {
            uiThread = SynchronizationContext.Current;

            PollingDuplexHttpBinding poll = new PollingDuplexHttpBinding();
            poll.InactivityTimeout = TimeSpan.FromMinutes(1);

            IChannelFactory<IDuplexSessionChannel> channelFactory =
              poll.BuildChannelFactory<IDuplexSessionChannel>(new
                BindingParameterCollection());

            IAsyncResult factoryOpenResult =
              channelFactory.BeginOpen(new
                AsyncCallback(OnOpenFactoryComplete), channelFactory);

            if (factoryOpenResult.CompletedSynchronously)
            {
                OpenTheChannel(factoryOpenResult);
            }
        }

        void OpenTheChannel(IAsyncResult result)
        {
            IChannelFactory<IDuplexSessionChannel> channelFactory =
              (IChannelFactory<IDuplexSessionChannel>)result.AsyncState;

            channelFactory.EndOpen(result);

            IDuplexSessionChannel channel = channelFactory.CreateChannel(new EndpointAddress("http://localhost:54391/ScoreService.svc"));

            IAsyncResult channelOpenResult = channel.BeginOpen(new AsyncCallback(OnOpenChannelComplete), channel);

            if (channelOpenResult.CompletedSynchronously)
            {
                StartPolling(channelOpenResult);
            }
        }

        void StartPolling(IAsyncResult result)
        {
            IDuplexSessionChannel channel = (IDuplexSessionChannel)result.AsyncState;

            channel.EndOpen(result);

            Message message = Message.CreateMessage(channel.GetProperty<MessageVersion>(),"Silverlight/IScoreService/Register", "Baseball");

            IAsyncResult resultChannel = channel.BeginSend(message, new AsyncCallback(OnSendComplete), channel);

            if (resultChannel.CompletedSynchronously)
            {
                CompleteOnSend(resultChannel);
            }

            PollingLoop(channel);
        }

        void OnOpenChannelComplete(IAsyncResult result)
        {
            if (result.CompletedSynchronously)
                return;
            else
                StartPolling(result);
        }

        void OnOpenFactoryComplete(IAsyncResult result)
        {
            if (result.CompletedSynchronously)
                return;
            else
                OpenTheChannel(result);
        }

        void OnSendComplete(IAsyncResult result)
        {
            if (result.CompletedSynchronously)
                return;
            else
                CompleteOnSend(result);
        }

        void CompleteOnSend(IAsyncResult result)
        {
            IDuplexSessionChannel channel = (IDuplexSessionChannel)result.AsyncState;

            channel.EndSend(result);
            uiThread.Post(UpdateScore, "Registered!" + Environment.NewLine);
        }

        void UpdateScore(object text)
        {
            txtScores.Text += (string)text;
        }

        void PollingLoop(IDuplexSessionChannel channel)
        {
            IAsyncResult result =
              channel.BeginReceive(new AsyncCallback(OnReceiveComplete),
              channel);
            if (result.CompletedSynchronously)
                CompleteReceive(result);
        }

        void CompleteReceive(IAsyncResult result)
        {
            IDuplexSessionChannel channel =
              (IDuplexSessionChannel)result.AsyncState;

            try
            {
                Message receivedMessage = channel.EndReceive(result);

                if (receivedMessage == null)
                {
                    uiThread.Post(UpdateScore, "Channel Closed");
                }
                else
                {
                    string text = receivedMessage.GetBody<string>();
                    uiThread.Post(UpdateScore, "Score Received: " +
                      text + Environment.NewLine);

                    if (text == "Game Over")
                    {
                        IAsyncResult resultFactory =
                            channel.BeginClose(new AsyncCallback(OnCloseChannelComplete),
                            channel);
                        if (resultFactory.CompletedSynchronously)
                        {
                            CompleteCloseChannel(result);
                        }
                    }
                    else
                    {
                        PollingLoop(channel);
                    }
                }
            }
            catch (CommunicationObjectFaultedException)
            {
                uiThread.Post(UpdateScore, "Channel Timed Out");
            }
        }

        void OnReceiveComplete(IAsyncResult result)
        {
            if (result.CompletedSynchronously)
                return;
            else
                CompleteReceive(result);
        }

        void CompleteCloseChannel(IAsyncResult result)
        {
            IDuplexSessionChannel channel =
              (IDuplexSessionChannel)result.AsyncState;

            channel.EndClose(result);
        }

        void OnCloseChannelComplete(IAsyncResult result)
        {
            if (result.CompletedSynchronously)
                return;
            else
                CompleteCloseChannel(result);
        }
    }
}
