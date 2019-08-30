using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalNetworkHardwareManagement.Core.Socket_Classes
{
    public class AsynchronousClient
    {
        // The port number for the remote device.  
        private const int port = 8081;
        private string _message = String.Empty;
        private string _response = String.Empty;

        private static ManualResetEvent operationDone;

        public AsynchronousClient()
        {
            operationDone =
                new ManualResetEvent(false);
        }

        public string StartClient(string message, string serverAddress)
        {
            return StartClient(message, IPAddress.Parse(serverAddress));
        }
        public string StartClient(string message, IPAddress serverAddress)
        {
            // Connect to a remote device.  
            try
            {
                IPAddress ipAddress = serverAddress;
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                _message = message;

                // Create a TCP/IP socket.  
                Socket client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                operationDone.WaitOne();

                client.Shutdown(SocketShutdown.Both);
                client.Close();

                return _response;

            }
            catch
            {
                return _response;
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                

                Send(client, $"{_message}<EOF>");

            }
            catch
            {
                _response = "Connection Faild";
            }
        }

        private void Receive(Socket client)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch
            {
                _response = "No Message Recieved.";
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                StateObject state = (StateObject) ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        _response = state.sb.ToString();
                        operationDone.Set();
                    }
                }
            }
            catch
            {
                _response = "Receive Faild.";
                operationDone.Set();
            }
        }

        private void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);

                Receive(client);
            }
            catch
            {
                _response = "No Message Sent.";
            }
        }
    }
}
