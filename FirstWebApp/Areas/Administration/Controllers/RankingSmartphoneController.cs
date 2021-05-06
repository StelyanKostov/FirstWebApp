using FirstWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class RankingSmartphoneController : Controller
    {
        private readonly IRankingServices rankingServices;
        private readonly ISmartphoneServices smartphoneServices;

        public RankingSmartphoneController(IRankingServices rankingServices, ISmartphoneServices smartphoneServices)
        {
            this.rankingServices = rankingServices;
            this.smartphoneServices = smartphoneServices;
        }
        public IActionResult Index()
        {
            return this.View();
        }
        public IActionResult AddToRankingSmartphone(int id)
        {
            var sp = this.smartphoneServices.GetSmartphoneById(id);
            return this.View(sp);
        }
        [HttpPost]
        public async Task<IActionResult> AddToRankingSmartphone(int id, int position)
        {
            await this.rankingServices.AddSmartphoneToRankingAsync(id, position);
            return this.Redirect("/Ranking/RankingSmartphones");
        }


    }
}
