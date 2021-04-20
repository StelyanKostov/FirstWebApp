using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstWebApp.ViewModels
{
    public class Sound
    {
        public string Loudspeaker { get; set; }

        [Display(Name = "3.5Mm Jack")]
        public string TreeFiveMMJack { get; set; }

        public string Other { get; set; }
    }
}
