using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace SignalRServer
{
    [HubName("TestHub")]
    public class TestHub : Hub
    {
        public void ProcessMessageFromClient(string message)
        {
            Console.WriteLine($"<Client sent:> {message}");

            // Do some processing with the client request and send the response back
            string newMessage = $"<Service sent>: Client message back in upper case: {message.ToUpper()}";
            Clients.All.ResponseToClientMessage(newMessage);
        }
    }
}
