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

namespace PP_AddIn___minieks
{
    public partial class ThisAddIn
    {

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            
            Directory.CreateDirectory("C:\\ProgramData\\PowerPointQuiz");


            this.Application.SlideShowNextSlide += new PowerPoint.EApplication_SlideShowNextSlideEventHandler(shouldChangeSlide);
        }

        public bool isOnQuestionSlide()
        {
            //TODO: Write code that checks if we are on curent slide
            return true;
        }
        public int amountOfQuestion()
        {
            //TODO: Write code that returns how many questions there are in the quiz.
            return 5;
        }

        string getQuestionOnSlide(SlideShowWindow Wn)
        {
            int i = Wn.View.CurrentShowPosition;
            MessageBox.Show("getClickindex is: " + i);
            //TODO: Write code that gets the index of the current slide WHEN PRESENTING
            return "Hvordan staver man til Jonathan.";
        }


        bool firstTimeLaunched = true;
        int count = 0;
        bool onQuestion = true;
        bool firstTimeSlideChanged = true;
        private void shouldChangeSlide(SlideShowWindow Wn)
        {
            if(firstTimeLaunched)
            {
                count += 1;
                firstTimeLaunched = false;
            }

            //when powerpoint is opened, it counts as a slide change, whic
            if (!firstTimeSlideChanged)
            {
                firstTimeSlideChanged = true;
                return;
            }
            firstTimeSlideChanged = false;


            if (isOnQuestionSlide() && count > 0 && count < amountOfQuestion())
            {
                string titelOfQuestion = getQuestionOnSlide(Wn);
                int slideIndex = Wn.View.CurrentShowPosition;

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
                

                //change whatever is on the current slide to question or result, depending on what
                //previous condition was (onQuestion)
                if (onQuestion)
                {
                    onQuestion = false;

                    showQuestionPage(slideIndex, count);
                }
                else
                {
                    onQuestion = true;
                    showResult(slideIndex, count);
                    count += 1;
                }

                //Makes certain to stay on the same slide.
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
                objSlideShowView = objPres.SlideShowWindow.View;
                objSlideShowView.GotoSlide(1);
            }
        }

        private void showResult(int index, int questionCount)
        {
            //TODO: make method that changes the current slide to result design.
            PowerPoint.Slide Sld = this.Application.ActivePresentation.Slides[index];

            PowerPoint.Shape textBox = Sld.Shapes.AddTextbox(
                Office.MsoTextOrientation.msoTextOrientationHorizontal, 0, 200, 500, 50);
            textBox.TextFrame.TextRange.InsertAfter("Congratulations, you are on the result page.");
            //TODO: tilføj al teksten som det skal være på Result Page. Lige nu kan det ses at det bare er en enkelt tekstboks et tilfældigt sted
            //(Det som Cahtrine startede på at designe i powerpoint, nu i kode)
        }
        public void showQuestionPage(int index, int questionCount)
        {

            //Tell webserver to send webpages to multiple choice question
            Ribbon1.invokeConnection("nextQuestion");


            //TODO: tilføj al teksten som det skal være på Question pagen.. Lige nu kan det ses at det bare er en enkelt tekstboks et tilfældigt sted
            //(Det som Cahtrine startede på at designe i powerpoint, nu i kode)

            //Variables with the answer options an the question itself
            List<string> answerOptions = new List<string>();
            string question;

            //method that should be made where the variables are available:
            string titel = "dobbelt";
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
            // TODO: repeat with different coordinates. also make the design with boxes with colors etc


            //Insert question
            //TODO: figure out coordinates, and possibly size of text as well.
            shape = Sld.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, width, height/3);
            shape.TextFrame.TextRange.InsertAfter(question);
            shape.TextFrame.TextRange.ParagraphFormat.Alignment = PpParagraphAlignment.ppAlignCenter;




            /* Code for grouping, if needed...
            string[] myRangeArray = new string[3];
            myRangeArray[0] = "shape1";
            myRangeArray[1] = "shape2";
            myRangeArray[2] = "shape3";
            Sld.Shapes.Range(myRangeArray).Group();
            */

        }
        private Spoergsmaalsdata hentSpoergsmaal(string valgtTitel)
        {
            Spoergsmaalsdata data = new Spoergsmaalsdata();
            string mellemmand = File.ReadAllText("C:\\ProgramData\\PowerPointQuiz\\" + valgtTitel + ".json");
            data = JsonConvert.DeserializeObject<Spoergsmaalsdata>(mellemmand);
            return data;
        }

        List<string> getAnswerOptions(string valgtTitel)
        {
            List<string> returdnstring = new List<string>();
            returdnstring.Add("Jonatahn");
            returdnstring.Add("Jonathn");
            returdnstring.Add("Jonatn");
            returdnstring.Add("Jonan");
            return returdnstring;

            Spoergsmaalsdata data = hentSpoergsmaal(valgtTitel);
            //TODO: Get the answer options at a specific question
            List<string> returnstring = new List<string>();
            foreach (string svarMulighed in data.svarMuligheder)
            {
                returnstring.Add(svarMulighed);
            }
            return returnstring;
        }
        string getQuestion(string valgtTitel)
        {
           
            return "hvordan staver man Jonathan";
            Spoergsmaalsdata data = hentSpoergsmaal(valgtTitel);
            //TODO: Get the question at a specific question
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
