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

        public RankingSmartphoneController(IRankingServices rankingServices)
        {
            this.rankingServices = rankingServices;
        }
        public IActionResult Index()
        {

            return this.View();
        }
        public IActionResult AddToRankingSmartphone(int id , int position)
        {
            //this.rankingServices.AddSmartphoneToRanking(id, position);
            return this.RedirectToAction("RankingSmartphones");
        }
        public IActionResult RankingSmartphones()
        {
            return this.View();
        }

    }
}
