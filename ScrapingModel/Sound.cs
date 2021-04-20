using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Sound
    {
        public Sound()
        {
            this.SoundData = new Dictionary<string, string>();
        }

        public Dictionary<string, string> SoundData { get; set; }
    }
}
