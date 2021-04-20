
namespace FirstWebApp.ViewModels
{
    public class SmartphoneViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Battery battery { get; set; }

        public Body body { get; set; }

        public Connect connect { get; set; }

        public Display display { get; set; }

        public Features features { get; set; }

        public Date date { get; set; }

        public MainCamera mainCamera { get; set; }

        public Memory memory { get; set; }

        public View view { get; set; }

        public Network network { get; set; }

        public Hardware hardware { get; set; }

        public SelfieCamera selfieCamera { get; set; }

        public Sound sound { get; set; }

        public Image image { get; set; }
    }
}
