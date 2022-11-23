using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace WebsiteMiniProjekt2.Hubs
{
    public class WebHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task isCodeAvailable(int code)
        {
            await Clients.All.SendAsync("checkYourCode", code);
            //all clients should have a listener for isYourCode, that sends back
            //the code that they use to everyone.

            //since this is the webserver, it can ask everyone to privately send back their code, and then send out a 
            //not used code to the client who asked for the code.
        }

        public Task PrintString(int String)
        {
            Trace.WriteLine(String);
            return Task.CompletedTask;
        }
    }
}
