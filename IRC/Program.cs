using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
namespace IRC
{
    class Program
    {
        static void Main(string[] args)
        {
            // Establish the remote endpoint for the socket.
            // The name of the 
            // remote device is "host.contoso.com".         
            //(193.219.128.49:6697)6667
            IPHostEntry ipHostInfo = Dns.GetHostEntry("irc.freenode.net");            
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress,6667 );
            string nick = "bot_1232";
            string channel ="##news";

            // Create a TCP/IP socket.
            Socket client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            client.Connect(remoteEP);
            NetworkStream stream;
            StreamReader reader;
            StreamWriter writer;

            stream = new NetworkStream(client);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { NewLine = "\r\n", AutoFlush = true };
            //client.Send(Encoding.UTF8.GetBytes("USER " + nick));
            //client.Send(Encoding.UTF8.GetBytes("NICK " + nick));
            //client.Send(Encoding.UTF8.GetBytes("JOIN " + channel));

            writer.WriteLine("USER " + nick + " 8 * :" + nick);
            writer.Flush();
            writer.WriteLine("NICK " + nick);
            writer.Flush();
            writer.WriteLine("JOIN " + channel);
            writer.Flush();

            while (true)
            {
                writer.WriteLine(Console.ReadLine());
                writer.Flush(); 
            }
            //using (TextWriter txtIRC = File.CreateText("C:\\txtIRC.txt"))
            //{
            //    while (true)
            //    {
            //        string parser;
            //        parser = reader.ReadLine();
            //        txtIRC.WriteLine(parser);

            //        //else
            //        //{
            //        //    writer.WriteLine(Console.ReadLine());
            //        //    writer.Flush(); 

            //        //}

            //    }
            //}
            
            
        }
    }
}
