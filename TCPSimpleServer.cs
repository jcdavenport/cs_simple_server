using System;              // For Console, Int32, ArgumentException, Environment
using System.Net;          // For IPAddress
using System.Net.Sockets;  // For TcpListener, TcpClient
using System.Text;

namespace TCPSimpleServer
{
    class TCPSimpleServer
    {

        private const int BUFSIZE = 500; // Size of receive buffer

        static void Main()
        {
            // Get Port Number of Server
            Int32 servPort = 0;
            Console.Write("\nEnter Port Number for Server To Listen (Example: 41111):");
            servPort = Convert.ToInt32(Console.ReadLine().Trim());

            // Establish the listener for the server

            TcpListener listener = null;

            try
            {
                // Create a TCPListener to accept client connections
                listener = new TcpListener(IPAddress.Any, servPort);
                listener.Start();
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.ErrorCode + ": " + se.Message);
                Environment.Exit(se.ErrorCode);
            }

            byte[] rcvBuffer = new byte[500]; // Receive buffer
            int bytesReceived;        // Received byte count


            //            Int32 servPort =  // assign a port number for application
            //byte[] rcvBuffer = new byte[50000];
            //            TCPListener listener = new TcpListener(IPAddress.Any, servPort);
            //            listener.Start();     // create and start the TCP socket for listener

            for (; ; )  // loop forever listening to any number of client
            {
                TcpClient client = listener.AcceptTcpClient();    // create new client
                NetworkStream netStream = client.GetStream();  // create Stream
                bytesReceived = netStream.Read(rcvBuffer, 0, rcvBuffer.Length);
                string ReceivedString = Encoding.ASCII.GetString(rcvBuffer);
                Console.WriteLine("Received String: " + ReceivedString);
                Console.WriteLine("Received Bytes : {0}", bytesReceived);
                netStream.Write(rcvBuffer, 0, rcvBuffer.Length);
                netStream.Close();
                client.Close();
            }


            // Create loop to Run forever, accepting and servicing connections


            //     // Create TCP Client accepted by the listener
            //    // create teh stream to read inout from client
            //    try           // use try-catch to catch exceptions - uncomment try-catch code
            //    {
            //        read incoming stream by using the netStream read and putting it into the buffer
            //        
            //        //convert buffer to string using ASCII encoding
            //        // print out the string received and the 
            //        // number of bytes received


            //        // Close the stream and socket. We are done with this client!
            //        
            //        

            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //        netStream.Close();
            //    }
            //}

            Console.Write("\nPress the Enter Key to Terminate the Simple Web Server Program \n\n");
            Console.ReadLine();
        }
    }
}
