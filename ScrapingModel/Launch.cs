using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Launch
    {
        public Launch()
        {
            this.lanchDate = new Dictionary<string, string>();
        }
        public Dictionary<string, string> lanchDate { get; set; }
    }
}
