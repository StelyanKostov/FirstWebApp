using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Network
    {

        public Network()
        {
            this.networkdData = new Dictionary<string, string>();
        }
        public Dictionary<string, string> networkdData { get; set; }
    }
}
