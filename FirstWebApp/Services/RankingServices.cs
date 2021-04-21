using FirstWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Services
{
    public class RankingServices : IRankingServices
    {
        private ApplicationDbContext db;
        private readonly ISmartphoneServices smartphoneServices;

        public RankingServices(ApplicationDbContext db , ISmartphoneServices smartphoneServices)
        {
            this.db = db;
            this.smartphoneServices = smartphoneServices;
        }
        public void AddSmartphoneToRanking(int id, int position)
        {

            var sp = db.Smartphones.Where(x => x.Id == id).FirstOrDefault();
            sp.RankingPositionPremiumSmartphone = position == 0 ? null: position;

            db.SaveChanges();
        }

        public List<ViewModels.SmartphoneViewModel> GetSmartphonesRanking()
        {
          var smartphones =  smartphoneServices.GetAll().Where(x => x.RankingPositionPremiumSmartphone != null).OrderBy(x=> x.RankingPositionPremiumSmartphone).ToList();

            return smartphones;
        }
    }
}
