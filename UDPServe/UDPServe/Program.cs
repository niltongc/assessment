﻿
using System.Net;
using System.Net.Sockets;
using System.Text;
using UDPServe.Handlers;

public class UDPListener
{
    private const int listenPort = 11000;

    private static void StartListener()
    {
        SaveData.CreateDatabaseAndTableIfNotExists();

        UdpClient listener = new UdpClient(listenPort);
        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

        try
        {
            while (true)
            {
                
                Console.WriteLine("Waiting for broadcast");
                Console.WriteLine("");

                byte[] bytes = listener.Receive(ref groupEP);

                Console.WriteLine($"Received broadcast from {groupEP} :");
                Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");

                string message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);


                SaveData.SaveInDatabase(message);
        
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            listener.Close();
        }
    }

    public static void Main()
    {
        StartListener();
    }

 
}
