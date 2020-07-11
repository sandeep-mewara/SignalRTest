using Microsoft.AspNet.SignalR.Client;
using System;

namespace SignalRClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://localhost:8080/";

            var connection = new HubConnection(url);
            IHubProxy _hub = connection.CreateHubProxy("TestHub");
            connection.Start().Wait();

            // For server side initiation of messages
            _hub.On("MessageFromServer", x => Console.WriteLine(x));
            _hub.On("ResponseToClientMessage", x => Console.WriteLine(x));

            Console.WriteLine("Type any message - it will be sent as a request to server for a response.");
            string line = null;
            while ((line = Console.ReadLine()) != null)
            {
                _hub.Invoke("ProcessMessageFromClient", line).Wait();
            }

            Console.Read();
        }
    }
}
