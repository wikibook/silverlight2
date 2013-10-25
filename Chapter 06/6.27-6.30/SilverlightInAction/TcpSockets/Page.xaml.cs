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
using System.Net.Sockets;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace TcpSockets
{
    public partial class Page : UserControl
    {
        private bool socketOpen;
        SynchronizationContext uiThread;

        public Page()
        {
            InitializeComponent();
        }

        public void OpenTheSocket()
        {
            DnsEndPoint tcpEndpoint = new DnsEndPoint(Application.Current.Host.Source.DnsSafeHost, 4502);
            Socket tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            SocketAsyncEventArgs socketArgs = new SocketAsyncEventArgs();
            socketArgs.UserToken = tcpSocket;
            socketArgs.RemoteEndPoint = tcpEndpoint;

            socketArgs.Completed += new EventHandler<SocketAsyncEventArgs>(socketArgs_Completed);
            tcpSocket.ConnectAsync(socketArgs);
        }

        public void socketArgs_Completed(object sender, SocketAsyncEventArgs receivedArgs)
        {
            switch (receivedArgs.LastOperation)
            {
                case SocketAsyncOperation.Connect:
                    if (receivedArgs.SocketError == SocketError.Success)
                    {
                        byte[] response = new byte[1024];
                        receivedArgs.SetBuffer(response, 0, response.Length);
                        Socket socket = (Socket)receivedArgs.UserToken;
                        socket.ReceiveAsync(receivedArgs);

                        socketOpen = true;
                    }
                    else
                        throw new SocketException((int)receivedArgs.SocketError);
                    break;
                case SocketAsyncOperation.Receive:
                    ReceiveMessageOverSocket(receivedArgs);
                    break;
            }
        }

        public void ReceiveMessageOverSocket(SocketAsyncEventArgs receivedArgs)
        {
            string message = Encoding.UTF8.GetString(receivedArgs.Buffer, receivedArgs.Offset, receivedArgs.BytesTransferred);

            XmlReader messageReader = XmlReader.Create(message);
            XmlSerializer ser = new XmlSerializer(typeof(SampleData));
            SampleData data = (SampleData)ser.Deserialize(messageReader);

            Socket socket = (Socket)receivedArgs.UserToken;
            socket.ReceiveAsync(receivedArgs);
        }
    }

    public class SampleData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
    }
}
