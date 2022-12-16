using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Diagnostics;
using System.Xml.Linq;

namespace WebsiteMiniProjekt2.Hubs
{
    public class WebHub : Hub
    {
        static List<int> codesInUse = new List<int>();
        static List<string> namesInUse = new List<string>();

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public void removeCode(int code)
        {
            if(codesInUse.Contains(code))
            {
                codesInUse.Remove(code);
            }
        }


        public async Task AttemptedLogin(string code)
        {
            Trace.WriteLine("attempted login method with " + code);
            if(!codesInUse.Contains(42))
            {
                codesInUse.Add(42);
            }
            //return wrong code, if input isn't a number, or of it isn't in our list
            if (!int.TryParse(code, out int codeint) || !codesInUse.Contains(codeint))
            {
                Trace.WriteLine("wrong code");

                await Clients.Caller.SendAsync("wrongStatement", "code");
                return;
            }

            await Clients.Caller.SendAsync("goToPage", "Namepage");

            //Client (webpage), asks if a user has entered a valid code
            //if this is the case, then send back a command to the client
            //telling them to switch side
        }

        public async Task AttamptedUsername(string userName) 
            //this method hasn't been tested
        {
            Trace.WriteLine("attempted chossing following username " + userName);
            //return wrong code, if input isn't a number, or of it isn't in our list
            if (namesInUse.Contains(userName))
            {
                Trace.WriteLine("username is not available");

                await Clients.Caller.SendAsync("wrongStatement", "username");
                return;
            }

            await Clients.Caller.SendAsync("goToPage", "Waitingpage");

            //Client (webpage), asks if a user has entered a valid code
            //if this is the case, then send back a command to the client
            //telling them to switch side
        }
        public async Task nextQuestion()
        {
            await Clients.All.SendAsync("nextQuestion");
            Trace.WriteLine("sending clients to next question");
        }

        public async Task giveMeCode()
        {
            Random rnd = new Random();
            bool foundNewCode = false;
            int code = 0;
            int i = 0;
            while (!foundNewCode)
            {
                i++;
                foundNewCode = true;
                code = rnd.Next(1000, 10000);  // creates a number between 1 and 12
                foreach (int usedCode in codesInUse)
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


        public Task PrintString(string String) //be aware that input from
                                               //html forms, will most likely be a string, you have earlier in your
                                               //life spent more than an hour being confused why there was an
                                               //error on your server, due to this... 13-12-2022
        {
            Trace.WriteLine(String);
            return Task.CompletedTask;
        }

        public Task PrintBool(bool bollean)
        {
            Trace.WriteLine(bollean);
            return Task.CompletedTask;
        }
    }
}
