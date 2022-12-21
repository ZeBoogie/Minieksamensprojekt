using Newtonsoft.Json;

namespace WebsiteMiniProjekt2
{
    internal class Svardata
    {
        string Session;
        List<string> Spoergsmaal;
        List<List<string>> Spoergsmaal_;

        public Svardata(string Session)
        {
            this.Session = Session;
        }

        public void samlData(string titel, string korrekt, List<string> bruger, List<int> bud)
        {
            int i = 0;
            foreach (string b in bruger)
            {
                string f = bud[i].ToString() + "||" + b;
                bruger.Add(f);
                i++;
            }
            string s = korrekt + "||" + titel;
            Spoergsmaal.Add(s);
            Spoergsmaal_.Add(bruger);
        }

        private void konverter()
        {
            string titel = DateTime.Now.ToString().Replace(':', '.');
            string fileName = "C:\\ProgramData\\PowerPointQuiz\\Svar" + titel + ".json";
            string jsonString = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
