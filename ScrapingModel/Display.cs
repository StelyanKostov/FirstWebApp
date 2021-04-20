using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Display
    {
        public Display()
        {
            this.displayData = new Dictionary<string, string>();
        }
        public Dictionary<string, string> displayData { get; set; }
    }
}

