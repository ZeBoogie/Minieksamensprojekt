﻿using System;
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

        int getCurrentSlideIndex()
        {
            //TODO: Write code that gets the index of the current slide WHEN PRESENTING
            return 1;
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
            MessageBox.Show("count is " + count);
            if (!firstTimeSlideChanged)
            {
                firstTimeSlideChanged = true;
                return;
            }
            firstTimeSlideChanged = false;


            if (isOnQuestionSlide() && count > 0 && count < amountOfQuestion())
            {
                MessageBox.Show("This is a question Slide");
                int slideIndex = getCurrentSlideIndex();

                //delete everything on current slide, so that the slide is ready to be updated.
                PowerPoint.Slide Sld = this.Application.ActivePresentation.Slides[slideIndex];
                foreach (PowerPoint.Shape shap in Sld.Shapes)
                {
                    shap.Delete();
                }


                //change whatever is on the current slide to question or result, depending on what
                //previous condition was (onQuestion)
                if (onQuestion)
                {
                    onQuestion = false;
                    showQuestion(slideIndex);
                }
                else
                {
                    onQuestion = true;
                    showResult(slideIndex);
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

        private void showResult(int index)
        {
            //TODO: make method that changes the current slide to result design.
            PowerPoint.Slide Sld = this.Application.ActivePresentation.Slides[index];
            PowerPoint.Shape textBox = Sld.Shapes.AddTextbox(
                Office.MsoTextOrientation.msoTextOrientationHorizontal, 0, 200, 500, 50);
            textBox.TextFrame.TextRange.InsertAfter("Congratulations, you are on the result page.");
        }

        private void showQuestion(int index)
        {
            //get first slide, and insert text on it.
            PowerPoint.Slide Sld = this.Application.ActivePresentation.Slides[index];
            PowerPoint.Shape textBox = Sld.Shapes.AddTextbox(
                Office.MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, 500, 50);
            textBox.TextFrame.TextRange.InsertAfter("And this is how the question page looks for now.");

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
