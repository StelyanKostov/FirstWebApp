using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Smarphone
    {
        public Smarphone()
        {
            this.battery = new Battery();
            this.body = new Body();
            this.commos = new Comms();
            this.display = new Display();
            this.features = new Features();
            this.Launch = new Launch();
            this.mainCamera = new MainCamera();
            this.memory = new Memory();
            this.misc = new Misc();
            this.network = new Network();
            this.platform = new Platform();
            this.selfieCamera = new SelfieCamera();
            this.sound = new Sound();
            this.Tests = new Tests();
            this.image = new Image();

        }

        public string Name { get; set; }
        public Battery battery { get; set; }

        public Body body { get; set; }

        public Comms commos { get; set; }

        public Display display { get; set; }

        public Features features { get; set; }

        public Launch Launch { get; set; }

        public MainCamera mainCamera { get; set; }

        public Memory memory { get; set; }

        public Misc misc { get; set; }

        public Network network { get; set; }

        public Platform platform { get; set; }

        public SelfieCamera selfieCamera { get; set; }

        public Sound sound { get; set; }

        public Tests Tests { get; set; }
        public Image image { get; set; }


    }
}
