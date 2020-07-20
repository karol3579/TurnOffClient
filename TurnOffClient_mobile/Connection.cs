using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TurnOffClient_mobile
{
    class Connection
    {
        public Connection(String ip, Int32 port) {
            try
            {
                //create new socket and open data stream
                TcpClient client = new TcpClient(ip, port);
                NetworkStream stream = client.GetStream();

                //byte array to write in message recived from server
                Byte[] data = new Byte[256];
                String responseData = String.Empty;
                //recive data
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                //write out response in console
                Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();
                client.Close();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

        }
        

       
    } 
}