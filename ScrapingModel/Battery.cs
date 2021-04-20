using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Battery
    {

        
        public Battery()
        {
            this.Data = new  Dictionary<string, string>();
        }

        public Dictionary<string, string> Data { get; set; }
    }
}
