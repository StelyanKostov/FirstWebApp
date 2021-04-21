using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Services
{
    public interface IRankingServices
    {
        public void AddSmartphoneToRanking(int id, int position);

        public List<ViewModels.SmartphoneViewModel> GetSmartphonesRanking();
    }
}
