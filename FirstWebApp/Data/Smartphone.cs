using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Data
{
    public class Smartphone
    {
        public int Id { get; set; }

        [Required]
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
      
        public  RankingPremiumSmartphones rankingPremiumSmartphones { get; set; }


    }
}
