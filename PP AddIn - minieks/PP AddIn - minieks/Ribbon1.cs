using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Tools.Ribbon;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;



namespace PP_AddIn___minieks
{
    public partial class Ribbon1
    {
        HubConnection _connection;
        int mycode;
        bool sessionActive = false;

        private const string uri = "https://localhost:7252/webHub";

        void SetupConnection()
        {
            _connection = new HubConnectionBuilder().WithUrl(uri).Build();

            _connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                System.Diagnostics.Trace.WriteLine($"User {user} says {message}");
            });

            _connection.On<int>("useThisCode", (code) =>
            {
                System.Diagnostics.Trace.WriteLine($"Ok, i will use this code {code}");
                mycode = code;
            });


            _connection.StartAsync();
        }

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            SetupConnection();
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            var myForm = new Spoergsmaalsstyring_frm();
            myForm.Show();
        }

        private void button1_Click_1(object sender, RibbonControlEventArgs e)
        {
             var myForm = new Nyt_spaargsmaal_frm();
             myForm.Show();
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
            if(!sessionActive)
            {
                _connection.InvokeAsync("giveMeCode");
                StartStopSession_btn.Image = Properties.Resources.Stopknap;
                sessionActive = true;
            }
            else
            {
                sessionActive = false;
                StartStopSession_btn.Image = Properties.Resources.Startknap;
            }
        }

        private void BRbutton_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Application ppApp = Globals.ThisAddIn.Application;
            PowerPoint.SlideRange ppSR = ppApp.ActiveWindow.Selection.SlideRange
            PowerPoint.Shape ppShap = ppSR.Shapes.AddLabel(Office.MsoTextOrientation
                .msoTextOrientationHorizontal, 0, 0, 200, 25);
            ppShap.TextEffect.Text = "Hello World!";
        }

        private void TLbutton_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void TRbutton_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void BLbutton_Click(object sender, RibbonControlEventArgs e)
        {

        }
    }
}
