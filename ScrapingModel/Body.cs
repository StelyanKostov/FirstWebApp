using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Body
    {
        public Body()
        {
            this.bodyData = new Dictionary<string, string>();
        }
        public Dictionary<string, string> bodyData { get; set; }
    }
}
