using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer
{
    public class WebServer: IDisposable
    {
        static IPAddress addressForAccessToServer;
        int port;
        TcpListener listener;

        public WebServer(int port = 80)
        {
            this.port = port;
            addressForAccessToServer = IPAddress.Any;
        }

        public void Start()
        {
            try
            {
                listener = new TcpListener(addressForAccessToServer, port);
                listener.Start();
                Console.WriteLine("Server has started at the port {0}", port);

                var listeningTask = Task.Factory.StartNew(() => Listen(listener));

                Console.WriteLine("To stop the server press any key");
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public void Listen(TcpListener listener)
        {
            while (true)
            {
                TcpClient incommingClient = listener.AcceptTcpClient();

                Console.WriteLine("Incomming call from {0} has just been accepted. Processing request...", incommingClient.Client.RemoteEndPoint);

                var task = Task.Factory.StartNew(() => ProcessRequest(incommingClient));
            }
        }

        static void ProcessRequest(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {                
                string messageBody = File.ReadAllText("RestClientPage.html");
                byte[] buffer = Encoding.UTF8.GetBytes(messageBody);
                string statringLine = "HTTP/1.1 200 OK";
                string headers = "Content-Length:" + buffer.Length + Environment.NewLine +
                                                           "Connection: Close" + Environment.NewLine +
                                                           "Content-Type: text/html; charset=UTF-8" + Environment.NewLine +
                                                           "Content-Encoding: UTF-8";

                string httpResponse = statringLine + Environment.NewLine +
                                      headers + Environment.NewLine +
                                      Environment.NewLine +
                                      messageBody;

                buffer = Encoding.UTF8.GetBytes(httpResponse);
                stream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(200);
                stream.Flush();
                stream.Close();
                client.Close();
            }
        }

        public void Dispose()
        {
            if (listener != null)
                listener.Stop();
        }
    }
}
