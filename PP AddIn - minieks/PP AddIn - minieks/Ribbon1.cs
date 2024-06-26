﻿using System;
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
using System.Runtime.Remoting;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Microsoft.Data.Sqlite;
using System.Security.Policy;
using System.Globalization;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace PP_AddIn___minieks
{
    public partial class Ribbon1
    {
        static HubConnection _connection;
        int mycode;
        bool sessionActive = false;

        private const string uri = "https://localhost:7252/webHub";
        static string nonCodeText = "Join the quiz with XXXX\nat Myrequizzen.com";
        string codeText = "error";
        DateTime startSession;



        public static string getNonCodeText()
        {
            return nonCodeText;
        }

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

            _connection.On<int[]>("hereAreAnswers", (answers) =>
			{
				System.Diagnostics.Trace.WriteLine($"Powerpoint in Ribbon1.cs has received {string.Join(", ", answers)}");
                ThisAddIn.showResult(answers);
			});


            _connection.On< Dictionary<string, int>> ("displayTheseRankings", (names) =>
            {
                System.Diagnostics.Trace.WriteLine($"Powerpoint in Ribbon1.cs is running displayTheseRankings");
                Globals.ThisAddIn.displayRankings(names);
            });


            _connection.StartAsync();
        }

        public static void invokeConnection(string methodName)
        {
            _connection.InvokeAsync(methodName);
        }

        public static void getRankings()
        {
            Trace.WriteLine("getRAnkings invoke connection");
            List<string> titlesOfQuestions = Globals.ThisAddIn.usedTitles;

            List<List<bool>> correctAnswers = getAllCorrectAnswers(titlesOfQuestions);
            _connection.InvokeAsync("getRankings", correctAnswers);

        }


        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            SetupConnection();
        }

        //Administrer spørgsmål klik
        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            var myForm = new Spoergsmaalsstyring_frm();
            myForm.Show();
        }


        //Nyt spørgsmål klik
        private void button1_Click_1(object sender, RibbonControlEventArgs e)
        {

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
                    if (shape.HasTextFrame == MsoTriState.msoTrue)
                    {
                        if (shape.TextFrame.HasText == MsoTriState.msoTrue)
                        {
                            
                            var textRange = shape.TextFrame.TextRange;
                            var text = textRange.Text;
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
            if (!sessionActive) //when starting session
            {
                _connection.InvokeAsync("giveMeCode");
                StartStopSession_btn.Image = Properties.Resources.Stopknap;
                StartStopSession_btn.Label = "Stop session";
                sessionActive = true;

                startSession = DateTime.Now;
			}
			else //when ending sessions
			{
                sessionActive = false;
                StartStopSession_btn.Image = Properties.Resources.Startknap;
                _connection.InvokeAsync("removeCode", mycode);
				StartStopSession_btn.Label = "Start session";
				changetext(nonCodeText, codeText);


                //---save session to "database"---
				List<string> titlesOfQuestions = new List<string>();
                titlesOfQuestions = Globals.ThisAddIn.usedTitles;

                if (titlesOfQuestions.Count > 0)
                {
                    List<List<string>> answerOptions = new List<List<string>>();
                    answerOptions = getAllAnswerOptions(titlesOfQuestions);

                    List<string> questions = new List<string>();
                    questions = getAllQuestions(titlesOfQuestions);

                    DateTime sessionEnd = DateTime.Now;
                    string result = $"Titles of questions are: {string.Join(", ", titlesOfQuestions)} ---- AnswerOptions are: ";

                    foreach (List<string> titleOfAnswerOption in answerOptions)
                    {

                        result += string.Join(", ", titleOfAnswerOption) + " || next list of answeroptions -> ";
                    }

                    List<List<bool>> correctAnswers = new List<List<bool>>();
                    correctAnswers = getAllCorrectAnswers(titlesOfQuestions);

                    Trace.WriteLine(result);
                    _connection.InvokeAsync("saveDataToDatabase", titlesOfQuestions, questions, answerOptions, startSession, sessionEnd, correctAnswers);
                }
                else
                {
                    MessageBox.Show("There were no encountered titles to save");
                }




                //reset code connected to server
                mycode = 0;

			}
		}
        public static List<List<bool>> getAllCorrectAnswers(List<string> titlesOfQuestions)
        {
            List<List<bool>> allCorrectAnswers = new List<List<bool>>();
            foreach (string title in titlesOfQuestions)
            {
                Spoergsmaalsdata data = new Spoergsmaalsdata();
                string mellemmand = File.ReadAllText("C:\\ProgramData\\PowerPointQuiz\\" + title + ".json");
                data = JsonConvert.DeserializeObject<Spoergsmaalsdata>(mellemmand);
                List<bool> questionAtTitle = data.korrektSvar;
                allCorrectAnswers.Add(questionAtTitle);
            }
            return allCorrectAnswers;
        }
        public List<string> getAllQuestions(List<string> titles)
		{
            //titles also being the names of the files, wherein the questions are.
            //TODO: return all the questions from the titles.
            List<string> allQuestions = new List<string>();
            foreach (string title in titles)
            {
                Spoergsmaalsdata data = new Spoergsmaalsdata();
                string mellemmand = File.ReadAllText("C:\\ProgramData\\PowerPointQuiz\\" + title + ".json");
                data = JsonConvert.DeserializeObject<Spoergsmaalsdata>(mellemmand);
                string questionAtTitle = data.spoergsmaal;
                allQuestions.Add(questionAtTitle);
            }
            return allQuestions;
        }
		public List<List<string>> getAllAnswerOptions(List<string> titles)
        {
            //titles also being the names of the files, wherein the questions are.
            //TODO: return all the answer options.
            List<List<string>> answerOptions = new List<List<string>>();
            foreach(string title in titles)
            {
				Spoergsmaalsdata data = new Spoergsmaalsdata();
				string mellemmand = File.ReadAllText("C:\\ProgramData\\PowerPointQuiz\\" + title + ".json");
				data = JsonConvert.DeserializeObject<Spoergsmaalsdata>(mellemmand);
				List<string> answerOptionsAtTitle = data.svarMuligheder;
                answerOptions.Add(answerOptionsAtTitle);
            }
            return answerOptions;
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



        

        
        
        private void TLbutton_Click(object sender, RibbonControlEventArgs e)
        {
            Trace.WriteLine("brbutton");
            insertTextBox(0, 0);

        }

        private void TRbutton_Click(object sender, RibbonControlEventArgs e)
        {
            Trace.WriteLine("TRbutton");
            insertTextBox(1, 0);
			_connection.InvokeAsync("nextQuestion");
		}
        private void BLbutton_Click(object sender, RibbonControlEventArgs e)
        {
            Trace.WriteLine("BLbutton");
            insertTextBox(0, 1);
        }


        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            var myForm = new Download_frm();
            myForm.Show();
        }
    }
}
