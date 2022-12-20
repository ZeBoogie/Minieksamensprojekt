﻿namespace WebsiteMiniProjekt2
{
        internal class Spoergsmaalsdata
        {
            public string titel;
            public string type;
            public string spoergsmaal;
            public List<string> svarMuligheder;
            public List<bool> korrektSvar;
            public List<string> billeder;
            public Spoergsmaalsdata(string titel, string spoergsmaal, List<string> svarMuligheder, List<bool> korrektSvar, List<string> billeder, string type)
            {
                this.titel = titel;
                this.spoergsmaal = spoergsmaal;
                this.svarMuligheder = svarMuligheder;
                this.korrektSvar = korrektSvar;
                this.billeder = billeder;
                this.type = type;
            }

            public Spoergsmaalsdata()
            {

            }
        }
    }
