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

        public async Task verifyCode(string code)
        {
            await Clients.All.SendAsync("isYourCode", code);
            Trace.WriteLine(code);
            //all clients should have a listener for isYourCode, that sends back
            //the code that they use to everyone.
        }
    }
}
