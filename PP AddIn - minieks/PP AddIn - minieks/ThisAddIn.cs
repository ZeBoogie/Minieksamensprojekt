using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using System.Drawing.Text;
using System.Threading;
using System.Reflection;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Security.AccessControl;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using System.Diagnostics;
using System.Globalization;
using System.Timers;
using Microsoft.Office.Interop.Excel;

namespace PP_AddIn___minieks
{
    public partial class ThisAddIn
    {
        public List<string> usedTitles = new List<string>();
        
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            
            Directory.CreateDirectory("C:\\ProgramData\\PowerPointQuiz");
            Directory.CreateDirectory("C:\\ProgramData\\PowerPointQuiz\\Svar");


            this.Application.SlideShowNextSlide += new PowerPoint.EApplication_SlideShowNextSlideEventHandler(shouldChangeSlide);
        }

        public bool isOnQuestionSlide(SlideShowWindow Wn)
        {
            int slideIndex = Wn.View.CurrentShowPosition;
            //TODO: Write code that gets the index of the current slide WHEN PRESENTING
            PowerPoint.Slide Sld = this.Application.ActivePresentation.Slides[slideIndex];
            string[] titles = Spoergsmaalsstyring_frm.loadFiles();
            foreach (PowerPoint.Shape shape in Sld.Shapes)
            {
                for(int i = 0; i < titles.Length; i++)
                {
                    if (shape.TextFrame.TextRange.Text == titles[i])
                    {
                        MessageBox.Show("There is a textbox on this page, that i recognize as i title");
                        return true;
                    }
                }
            }
            //TODO: Write code that checks if we are on curent slide
            return false;
        }
        public int amountOfQuestion()
        {
            //TODO: Write code that returns how many questions there are in the quiz.
            return 5;
        }

        //returns whatever 
        string getQuestionOnSlide(SlideShowWindow Wn)
        {
            int slideIndex = Wn.View.CurrentShowPosition;
            PowerPoint.Slide Sld = this.Application.ActivePresentation.Slides[slideIndex];
            string[] titles = Spoergsmaalsstyring_frm.loadFiles();
            foreach (PowerPoint.Shape shape in Sld.Shapes)
            {
                for (int i = 0; i < titles.Length; i++)
                {
                    if (shape.TextFrame.TextRange.Text == titles[i])
                    {
                        return titles[i];
                    }
                }
            }
            return "Error";
        }


        bool firstTimeLaunched = true;
        int count = 0;
        bool onQuestion = true;
        bool firstTimeSlideChanged = true;
        static bool onResultPage = false;
        static int slideIndex = 0;
        private void shouldChangeSlide(SlideShowWindow Wn)
        {
            //when you "change slide - go to f.eks. resultpage - it does two slide changes, so one must be cancelled.           

            if (isOnQuestionSlide(Wn) || (!(onQuestion || onResultPage)) || onResultPage)
            {

                if(onQuestion) // if just encountered the question slide
                {
                    slideIndex = Wn.View.CurrentShowPosition;
                }
                if(!(onQuestion || onResultPage)) //if on on the way to resultpage
                {
                    onResultPage= true;
                    _timer.Stop();

                    // Makes certain to stay on the same slide.
                    Presentation objPres;
                    SlideShowView objSlideShowView;

                    objPres = Globals.ThisAddIn.Application.ActivePresentation;
                    objPres.SlideShowSettings.ShowPresenterView = MsoTriState.msoFalse;
                    try
                    {
                        objPres.SlideShowSettings.Run();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't go to next question.");
                        return;
                    }
                    objSlideShowView = objPres.SlideShowWindow.View;
                    objSlideShowView.GotoSlide(slideIndex);
                    return;
                }
                string titelOfQuestion = getQuestionOnSlide(Wn);


                //delete everything on current slide (except code), so that the slide is ready to be updated.
                PowerPoint.Slide Sld = this.Application.ActivePresentation.Slides[slideIndex];
                int shapesCount = Sld.Shapes.Count;
                int shapeIndexToDelete = 1;
                for (int i = 0; i < shapesCount; i++)
                {
                    if (!(Sld.Shapes[shapeIndexToDelete].TextFrame.TextRange.Text == Ribbon1.getNonCodeText()))
                    {
                        Sld.Shapes[shapeIndexToDelete].Delete();
                    }
                    else
                    {
                        shapeIndexToDelete += 1;
                    }
                }
                int[] hardCodedAnswers = {2,7,4,3,3};
				//change whatever is on the current slide to question or result, depending on what
				//previous condition was (onQuestion)
				if (onQuestion)
                {
                    usedTitles.Add(titelOfQuestion);
                    onQuestion = false;
                    showQuestionPage(slideIndex, titelOfQuestion);
                }
                else
                {

                    //display resultpage.
                    onQuestion = true;
                    onResultPage = false;

                    //---- WARNING, IF WEBSERVER ISN'T RUNNING, THEN RESULTPAGE WON'T BE SHOWN ---
                    Ribbon1.invokeConnection("timeIsOver");
					//showResult(hardCodedAnswers);
                    count += 1;
                }


                count = 0;
            }
        }
        private static PowerPoint.Shape _timerShape;



        //--------------------- Show Result ----------------------
        public static void showResult(int[] answerthings)
        {
            int index = slideIndex;
            Trace.WriteLine("ShowResult method in thisaddin.cs received following answers: " + string.Join(", ", answerthings));
            //method that changes the current slide to result design.
            PowerPoint.Slide Sld = Globals.ThisAddIn.Application.ActivePresentation.Slides[index];
			float height = Globals.ThisAddIn.Application.ActivePresentation.PageSetup.SlideHeight;
			float width = Globals.ThisAddIn.Application.ActivePresentation.PageSetup.SlideWidth;



			//title
			int widthOfTitle = (int)Math.Round(width * 0.8);
			int heightOfTitle = 100;

			PowerPoint.Shape shape = Sld.Shapes.AddTextbox(
				Office.MsoTextOrientation.msoTextOrientationHorizontal, (width - widthOfTitle) / 2, (int)(0.25 * heightOfTitle), widthOfTitle, heightOfTitle);
			shape.TextFrame.TextRange.InsertAfter("Results");
			shape.TextFrame.TextRange.ParagraphFormat.Alignment = PpParagraphAlignment.ppAlignCenter;
            shape.TextFrame.TextRange.Font.Size = 24;


			//boxes:
			string[] answerOptions = { "Didn't answer", "A", "B", "C", "D" };
			int margin = 60;
			int heightOfButtomText = 50;

			int WidthOfBox = (int)Math.Round((width - (answerOptions.Length+1) * margin) / answerOptions.Length);
            int heightOfBox = (int)Math.Round(height - heightOfTitle - 1.2 * heightOfButtomText);


            int yCoordinat = (int)1.2 * heightOfTitle;
			float answerY = (float)(height - heightOfButtomText * 1.1);
            int[] R = {100, 0, 0, 255, 0 };
			int[] G = {100, 0, 155, 0, 255 };
			int[] B = {100, 255, 0, 0, 255 };

            float totalAnswers = answerthings.Sum();

			for (int i = 0; i < answerOptions.Length; i++)
			{
                float zoom = 0;
                if (answerthings[i] != 0)
                {
					zoom =  (float)answerthings[i] / (float)answerthings.Max();
				}

				float intemediateHeightOfBox = zoom * heightOfBox;
                
				shape = Sld.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, (i+1) * margin + i* WidthOfBox, heightOfBox + yCoordinat-intemediateHeightOfBox, WidthOfBox, intemediateHeightOfBox);
				shape.TextFrame.TextRange.InsertAfter("" + answerthings[i]);
				shape.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb(R[i], G[i], B[i]).ToArgb();
				shape.Line.Visible = MsoTriState.msoFalse;
				shape.TextFrame.TextRange.Font.Color.RGB = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();

				shape = Sld.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, (i + 1) * margin + i * WidthOfBox, answerY, WidthOfBox, heightOfButtomText);
                shape.TextFrame.TextRange.InsertAfter(answerOptions[i]);
			}

            Ribbon1.getRankings(); //method that sends to webhub, to return a dictionary with who placed where.
        }


        // ---- Rankings ----
        public void displayRankings(Dictionary<string, int> names)
        {
            Trace.WriteLine("---displaying rankings from thisaddin---");
            foreach (KeyValuePair<string, int> element in names)
            {
                Trace.WriteLine("added " + element.Value + " to player " + element.Key);
            }
            int y = 20;
            int placement = 1;
            float height = Globals.ThisAddIn.Application.ActivePresentation.PageSetup.SlideHeight;
            float width = Globals.ThisAddIn.Application.ActivePresentation.PageSetup.SlideWidth;

            foreach (KeyValuePair<string, int> element in names)
            {
                PowerPoint.Slide Sld = Globals.ThisAddIn.Application.ActivePresentation.Slides[slideIndex];
                PowerPoint.Shape shape = Sld.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, (int)Math.Round(width * 0.8), y, (int)Math.Round(width * 0.18), 20);
                shape.TextFrame.TextRange.InsertAfter(placement + ": " + element.Key + " : " + element.Value.ToString());
                y += 25;
                placement++;
            }
        }

        static System.Timers.Timer _timer = new System.Timers.Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);

        private static void TimerTick(object _, ElapsedEventArgs __)
        {
            string timeText = _timerShape.TextFrame2.TextRange.Text;
            if (TimeSpan.TryParseExact(timeText, "mm\\:ss",
                CultureInfo.InvariantCulture, out TimeSpan time))
            {
                if (time.TotalSeconds == 0)
                {
                    onResultPage = true;
                    // act like changing slides, to go  to resultpage
                    Presentation objPres;
                    SlideShowView objSlideShowView;

                    objPres = Globals.ThisAddIn.Application.ActivePresentation;
                    objPres.SlideShowSettings.ShowPresenterView = MsoTriState.msoFalse;
                    try
                    {
                        objPres.SlideShowSettings.Run();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't go to next question.");
                        return;
                    }
                    objSlideShowView = objPres.SlideShowWindow.View;
                    objSlideShowView.GotoSlide(slideIndex);
                    _timer.Stop();
                    return;
                }
                time = time - TimeSpan.FromSeconds(1);
                _timerShape.TextFrame.TextRange.Text = time.ToString("mm\\:ss");
            }
        }


        public void showQuestionPage(int index, string titel)
        {

			//Tell webserver to send webpages to multiple choice question
			Ribbon1.invokeConnection("nextQuestion");


			//TODO: tilføj al teksten som det skal være på Question pagen.. Lige nu kan det ses at det bare er en enkelt tekstboks et tilfældigt sted
			//(Det som Cahtrine startede på at designe i powerpoint, nu i kode)

			//Variables with the answer options an the question itself
			List<string> answerOptions = new List<string>();
            string question;

            //method that should be made where the variables are available:
            answerOptions = getAnswerOptions(titel);
            question = getQuestion(titel);


            if (answerOptions.Count != 4)
            {
                MessageBox.Show("error, multiple choice should have 4 question options, only received " + answerOptions.Count);
                return;
            }

            //get slide at index
            PowerPoint.Slide Sld = this.Application.ActivePresentation.Slides[index];
            float height = Globals.ThisAddIn.Application.ActivePresentation.PageSetup.SlideHeight;
            float width = Globals.ThisAddIn.Application.ActivePresentation.PageSetup.SlideWidth;

            

            //insert 4 questions
            PowerPoint.Shape shape = Sld.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, 5, height/3+5, width/2-10, height/3-10);
            shape.TextFrame.TextRange.InsertAfter(answerOptions[0]);
            shape.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb(0, 0, 255).ToArgb();
            shape.Line.Visible = MsoTriState.msoFalse;
            shape.TextFrame.TextRange.Font.Color.RGB = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();
            //shape.TextFrame.TextRange.ParagraphFormat.Alignment = PpParagraphAlignment.ppAlignCenter;

            shape = Sld.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, width /2+5, height/3+5, width/2-10, height/3-10);
            shape.TextFrame.TextRange.InsertAfter(answerOptions[1]);
            shape.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb(0, 155, 0).ToArgb();
            shape.Line.Visible = MsoTriState.msoFalse;
            shape.TextFrame.TextRange.Font.Color.RGB = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();

            shape = Sld.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, 5, (2*height/3)+5, width/2-10, height/3-10);
			shape.TextFrame.TextRange.InsertAfter(answerOptions[2]);
            shape.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb(255, 0, 0).ToArgb();
            shape.Line.Visible = MsoTriState.msoFalse;
            shape.TextFrame.TextRange.Font.Color.RGB = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();

            shape = Sld.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, width / 2+5, (2 * height) / 3 + 5, width / 2 - 10, height / 3 - 10);
			shape.TextFrame.TextRange.InsertAfter(answerOptions[3]);
            shape.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb(0, 255, 255).ToArgb();
            shape.Line.Visible = MsoTriState.msoFalse;
            shape.TextFrame.TextRange.Font.Color.RGB = System.Drawing.Color.FromArgb(0, 0, 0).ToArgb();


            //Insert question 
            shape = Sld.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, width, height/3);
            shape.TextFrame.TextRange.InsertAfter(question);
            shape.TextFrame.TextRange.ParagraphFormat.Alignment = PpParagraphAlignment.ppAlignCenter;
            shape.TextFrame.TextRange.Font.Size = 50;





            //timer
            _timerShape = Sld.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 20, 20, 100, 20);
            _timerShape.TextFrame.TextRange.Text = "00:20";
            _timerShape.TextFrame.TextRange.Font.Size = 20;
            _timer.Elapsed += TimerTick;
            _timer.Start();
        }
        private Spoergsmaalsdata hentSpoergsmaal(string valgtTitel) //returner en klasse med alt data fra
                                                                    //en bestemt fil som er givet som parameter
        {
            Spoergsmaalsdata data = new Spoergsmaalsdata();
            string mellemmand = File.ReadAllText("C:\\ProgramData\\PowerPointQuiz\\" + valgtTitel + ".json");
            data = JsonConvert.DeserializeObject<Spoergsmaalsdata>(mellemmand);
            return data;
        }

        List<string> getAnswerOptions(string valgtTitel)
        {
            Spoergsmaalsdata data = hentSpoergsmaal(valgtTitel);
            List<string> returnstring = new List<string>();
            foreach (string svarMulighed in data.svarMuligheder)
            {
                returnstring.Add(svarMulighed);
            }
            return returnstring;
        }
        string getQuestion(string valgtTitel)//returner et objekt med alt data fra en fil.
        {
            Spoergsmaalsdata data = hentSpoergsmaal(valgtTitel);
            string returnstring = data.spoergsmaal;
            return returnstring;
        }

        void Application_SlideShowNextSlide(SlideShowWindow Wn)
        {
            
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {


        }

    #region VSTO generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
