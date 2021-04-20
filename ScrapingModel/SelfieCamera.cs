using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class SelfieCamera
    {
        public SelfieCamera()
        {
            this.selfieCameraData = new Dictionary<string, string>();
        }

        public Dictionary<string, string> selfieCameraData { get; set; }
    }
}
