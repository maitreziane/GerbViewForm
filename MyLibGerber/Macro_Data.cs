/**
    cette class permet de stoker les paramettres des macros


*/

using System;
using System.Collections.Generic;

namespace MyLibGerber
{



    internal class Macro_Data
    {
        List<string> data;

        public Macro_Data(string current_macro)
        {

            Current_macro = current_macro;
            data = new List<string>();


        }

        public string Current_macro { get; }

        internal void append(string value) {  data.Add(value); }

        public List<string> getData() { return data; }


    }
}