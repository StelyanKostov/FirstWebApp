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

        public RankingServices(ApplicationDbContext db)
        {
            this.db = db;
            
        }
        public void AddSmartphoneToRanking(int id, int position)
        {
            var sp = db.RankingPremiumSmartphones.Where(x => x.Position == position).FirstOrDefault();
            sp.SmartphoneId = id;
          
            db.SaveChanges();
        }
    }
}
