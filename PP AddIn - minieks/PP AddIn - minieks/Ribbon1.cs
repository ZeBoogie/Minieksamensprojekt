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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Office.Core;
using System.Collections;
using System.Drawing;

namespace PP_AddIn___minieks
{
    public partial class Ribbon1
    {
        HubConnection _connection;
        int mycode;
        bool sessionActive = false;

        private const string uri = "https://localhost:7252/webHub";
        string nonCodeText = "Join the quiz with XXXX\nat Myrequizzen.com";
        string codeText = "error";


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
                codeText = "Join the quiz with " + mycode + "\nat Myrequizzen.com";
                changetext(codeText, nonCodeText);
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


        private void button1_Click_2(object sender, RibbonControlEventArgs e)
        {
            var p = new Process();
            p.StartInfo.FileName = "\"C:\\Program Files\\ACD64FREE\\CHEMSK.EXE\"";
            p.Start();
        }


        public void changetext(string newText, string oldText)
        {
            PowerPoint.Slides s = Globals.ThisAddIn.Application.ActivePresentation.Slides;
            foreach (PowerPoint.Slide slide in s)
            {
                foreach (var item in slide.Shapes)
                {
                    var shape = (PowerPoint.Shape)item;
                    MessageBox.Show(shape.Name);
                    if (shape.HasTextFrame == MsoTriState.msoTrue)
                    {
                        if (shape.TextFrame.HasText == MsoTriState.msoTrue)
                        {
                            
                            var textRange = shape.TextFrame.TextRange;
                            var text = textRange.Text;
                            MessageBox.Show(text);
                            if(text == oldText)
                            {
                                shape.TextFrame.TextRange.Text = newText;
                            }
                        }
                    }
                }
            }
        }

        private void StartStopSession_btn_Click(object sender, RibbonControlEventArgs e)
        {
            if (!sessionActive)
            {
                _connection.InvokeAsync("giveMeCode");
                Trace.WriteLine("hi");
                StartStopSession_btn.Image = Properties.Resources.Stopknap;
                sessionActive = true;

            }
            else
            {
                sessionActive = false;
                StartStopSession_btn.Image = Properties.Resources.Startknap;
                _connection.InvokeAsync("removeCode", mycode);
                changetext(nonCodeText, codeText);
                mycode = 0;
            }
        }


        int textboxwidth = 300;
        int textboxheight = 50;
        private void BRbutton_Click(object sender, RibbonControlEventArgs e)
        {
            Trace.WriteLine("brbutton");
            insertTextBox(1, 1);
        }

        private void insertTextBox(int x, int y)
        {
            PowerPoint.Slides s = Globals.ThisAddIn.Application.ActivePresentation.Slides;
            float height = Globals.ThisAddIn.Application.ActivePresentation.PageSetup.SlideHeight;
            float width = Globals.ThisAddIn.Application.ActivePresentation.PageSetup.SlideWidth;

            foreach (PowerPoint.Slide slide in s)
            {
                PowerPoint.Shape textBox = slide.Shapes.AddTextbox(
                    Office.MsoTextOrientation.msoTextOrientationHorizontal, (width-textboxwidth)*x, (height-textboxheight)*y, textboxwidth, textboxheight);
                textBox.TextFrame.TextRange.InsertAfter(nonCodeText);
                if(x == 1)
                {
                    textBox.TextFrame.TextRange.ParagraphFormat.Alignment = PpParagraphAlignment.ppAlignRight;
                }
            }
        }

        public void insertBigBox()
        {
            PowerPoint.Slide Sld = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
            float height = Globals.ThisAddIn.Application.ActivePresentation.PageSetup.SlideHeight;
            float width = Globals.ThisAddIn.Application.ActivePresentation.PageSetup.SlideWidth;

            PowerPoint.Shape shape = Sld.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, 500, 50);
            shape.Name = "shape1";
            shape.TextFrame.TextRange.InsertAfter("This text was added by using code.");

            shape = Sld.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 0, 100, 500, 50);
            shape.TextFrame.TextRange.InsertAfter("This text was also added by using code.");
            shape.Name = "shape2";

            
            shape = Sld.Shapes.AddShape(MsoAutoShapeType.msoShapeActionButtonCustom, 0, 100, 500, 50);
            shape.TextFrame.TextRange.InsertAfter("This text was also added by using code.");
            shape.Name = "shape3";

            string[] myRangeArray = new string[3];
            myRangeArray[0] = "shape1";
            myRangeArray[1] = "shape2";
            myRangeArray[2] = "shape3";
            Sld.Shapes.Range(myRangeArray).Group();


        }
        private void jdklsaf()
        {

        }
        private void TLbutton_Click(object sender, RibbonControlEventArgs e)
        {
            Trace.WriteLine("brbutton");
            insertTextBox(0, 0);

        }

        private void TRbutton_Click(object sender, RibbonControlEventArgs e)
        {
            Trace.WriteLine("brbutton");
            insertTextBox(1, 0);
            insertBigBox();

        }
        private void BLbutton_Click(object sender, RibbonControlEventArgs e)
        {
            Trace.WriteLine("brbutton");
            insertTextBox(0, 1);

        }
    }
}
