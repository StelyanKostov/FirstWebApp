using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Memory
    {
        public Memory()
        {
            this.memoryData = new Dictionary<string, string>();
        }

        public Dictionary<string, string> memoryData { get; set; }
    }
}
