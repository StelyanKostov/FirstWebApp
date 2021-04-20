using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MainCamera
    {
        public MainCamera()
        {
            this.mainCameraData = new Dictionary<string, string>();
        }

        public Dictionary<string, string> mainCameraData { get; set; }
    }
}
