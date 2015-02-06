using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TDService.Code
{
    public class SocketCH
    {
        string serverIP = "172.10.13.1"; //服务器IP

        /// <summary>
        /// 服务器IP
        /// </summary>
        public string ServerIP
        {
            get { return serverIP; }
            set { serverIP = value; }
        }

        int port = 11000; //监听端口

        /// <summary>
        /// 监听端口
        /// </summary>
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        string acceptData; //接受到的数据

        /// <summary>
        /// 接受到的数据
        /// </summary>
        public string AcceptData
        {
            get { return acceptData; }
        }

        public IPAddress Local()
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            return ipHostInfo.AddressList[0];
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data">发送字符串数据</param>
        public string Send(string data)
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            string result = ""; // Server back data

            // Connect to a remote device. 
            try
            {
                // Establish the remote endpoint for the socket.
                IPAddress ipAddress =IPAddress.Parse(serverIP); //Local(); /
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP  socket.
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    client.Connect(remoteEP);

                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.UTF8.GetBytes(data + "<EOF>");

                    // Send the data through the socket.
                    int bytesSent = client.Send(msg);

                    int bytesRec = client.Receive(bytes);

                    result = Encoding.ASCII.GetString(bytes, 0, bytesRec).Replace("<EOF>", "");

                    // Release the socket.
                    client.Shutdown(SocketShutdown.Both);

                    client.Close();

                    return result;

                }
                catch (ArgumentNullException)
                {
                    throw;
                }
                catch (SocketException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
