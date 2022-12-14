﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_AddIn___minieks
{
    internal class Spoergsmaalsdata
    {
        string titel;
        string spoergsmaal;
        List<string> svarMuligheder;
        List<bool> korrektSvar;
        List<string> billeder;
        public Spoergsmaalsdata(string titel, string spoergsmaal, List<string> svarMuligheder, List<bool> korrektSvar, List<string> billeder)
        {
            this.titel = titel;
            this.spoergsmaal = spoergsmaal;
            this.svarMuligheder = svarMuligheder;
            this.korrektSvar = korrektSvar;
            this.billeder = billeder;
        }
    }
}
