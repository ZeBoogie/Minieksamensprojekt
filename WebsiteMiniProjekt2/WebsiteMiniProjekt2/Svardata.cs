using Newtonsoft.Json;

namespace WebsiteMiniProjekt2
{
    internal class Svardata
    {
        public List<string> titlesOfQuestions;
        public List<string> questions;
        public List<List<string>> answerOptions;
        public DateTime sessionStart;
        public DateTime sessionEnd;
        public Dictionary<string, List<string>> playersAndAnswers;
        public Svardata(List<string> titlesOfQuestions, List<string> questions, List<List<string>> answerOptions,
            DateTime sessionStart, DateTime sessionEnd, Dictionary<string, List<string>> playersAndAnswers)
        {
            this.titlesOfQuestions = titlesOfQuestions;
            this.questions = questions;
            this.answerOptions = answerOptions;
            this.sessionStart = sessionStart;
            this.sessionEnd = sessionEnd;
            this.playersAndAnswers = playersAndAnswers;
        }

    }
}
