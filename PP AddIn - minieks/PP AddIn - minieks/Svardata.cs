﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PP_AddIn___minieks
{
    internal class Svardata
    {
        string Session;
        List<string> Spoergsmaal;
        List<List<string>> Spoergsmaal_;
        int korrekt;

        public Svardata
            (string Session)
        {
            this.Session = Session;
        }

        public void samlData(string titel, List<string> bruger, List<int> bud)
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

        private void konverter(string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }
        
        
    }
}
