﻿using Microsoft.AspNetCore.SignalR;
using System.Collections;
using System.Diagnostics;
using System.Xml.Linq;

namespace WebsiteMiniProjekt2.Hubs
{
    public class WebHub : Hub
    {
        static List<int> codesInUse = new List<int>(); //hub class is transcient, so
        // this is deleted each time you send a message
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

        public async Task giveMeCode()
        {
            Random rnd = new Random();
            bool foundNewCode = false;
            int code = 0;
            int i = 0;
            while(!foundNewCode)
            {
                i++;
                foundNewCode = true;
                code = rnd.Next(1000, 10000);  // creates a number between 1 and 12
                foreach(int usedCode in codesInUse)
                {
                    Trace.WriteLine($"comparing usedcode {usedCode} and {code}");

                    if (usedCode == code)
                    {
                        foundNewCode = false;
                    }
                }
                Trace.WriteLine($"foundnewCode is {foundNewCode}, this time is {i}");

            }
            Trace.WriteLine($"current chosen code is {code}");
            Trace.WriteLine($"codesinuse bfore are{string.Join(",", codesInUse)}");

            codesInUse.Add(code);
            Trace.WriteLine($"codesinuse after are{string.Join(",", codesInUse)}");


            await Clients.Caller.SendAsync("useThisCode", code);
        }
        public Task PrintString(int String)
        {
            Trace.WriteLine(String);
            return Task.CompletedTask;
        }
    }
}
