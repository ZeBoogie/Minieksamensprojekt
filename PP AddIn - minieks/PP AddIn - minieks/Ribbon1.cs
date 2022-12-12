using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Office.Tools.Ribbon;

namespace PP_AddIn___minieks
{
    public partial class Ribbon1
    {
        HubConnection _connection;

        private const string uri = "https://localhost:7252/webHub";

        void SetupConnection()
        {
            _connection = new HubConnectionBuilder().WithUrl(uri).Build();

            _connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                System.Diagnostics.Trace.WriteLine($"User {user} says {message}");
            });

            _connection.On<int>("checkYourCode", (code) =>
            {
                System.Diagnostics.Trace.WriteLine($"this  code is available {code}");
            });

            _connection.On<int>("useThisCode", (code) =>
            {
                System.Diagnostics.Trace.WriteLine($"Ok, i will use this code {code}");
            });


            _connection.StartAsync();
        }

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
                var myForm = new Spoergsmaalsstyring_frm();
                myForm.Show();
        }

        private void button1_Click_1(object sender, RibbonControlEventArgs e)
        {

        }

        private void gallery1_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void button1_Click_2(object sender, RibbonControlEventArgs e)
        {
            var p = new Process();
            p.StartInfo.FileName = "\"C:\\Program Files\\ACD64FREE\\CHEMSK.EXE\"";
            p.Start();
        }

        private void StartStopSession_btn_Click(object sender, RibbonControlEventArgs e)
        {
        }
    }
}
