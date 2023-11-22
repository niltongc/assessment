using System.Net;
using System.Net.Sockets;
using System.Text;
using UDPClient.Handlers;


Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

//Local ip address: 192.168.3
IPAddress broadcast = IPAddress.Parse("192.168.3.255");

string messageToSend;

bool exitRequested = false;

Thread loopThread = new Thread(() =>
{
    while (!exitRequested)
    {
        MessageHandler messageHandler = new MessageHandler();
        messageToSend = $"{messageHandler.AutomaticMessage()}";


        Console.WriteLine(messageToSend);
        byte[] sendbuf = Encoding.ASCII.GetBytes(messageToSend);
        IPEndPoint ep = new IPEndPoint(broadcast, 11000);

        s.SendTo(sendbuf, ep);

        Console.WriteLine("Message sent to the broadcast address");
        Console.WriteLine("");
        Console.WriteLine("Press Enter to Stop");
        Console.WriteLine("");


        Thread.Sleep(5000);

    }
});

loopThread.Start();

Console.WriteLine("Press Enter to Stop");
Console.ReadLine();

exitRequested = true;

// Wait for loop execution
loopThread.Join();















