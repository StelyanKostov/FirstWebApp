
using FirstWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    public class RankingController : Controller
    {
        private readonly IRankingServices rankingServices;

        public RankingController(IRankingServices rankingServices)
        {
            this.rankingServices = rankingServices;
        }

        public IActionResult RankingSmartphones()
        {
            var smartphones = this.rankingServices.GetSmartphonesRanking();

            return this.View(smartphones);
        }
    }
}
