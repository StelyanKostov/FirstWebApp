using FirstWebApp.Services;
using FirstWebApp.Services.Scraping;
using FirstWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly UserManager<IdentityUser> userManger;
        private readonly SignInManager<IdentityUser> sigInManager;
        private readonly RoleManager<IdentityRole> roleManger;
        private readonly IScrapingSmartphoneServices scrapingSmartphoneServices;
        private readonly ISmartphoneServices smartphoneServices;

        public AdminController(
            UserManager<IdentityUser> userManger,
            SignInManager<IdentityUser> sigInManager
            , RoleManager<IdentityRole> roleManger,
            IScrapingSmartphoneServices scrapingSmartphoneServices,
            ISmartphoneServices smartphoneServices
            )
        {
            this.userManger = userManger;
            this.sigInManager = sigInManager;
            this.roleManger = roleManger;
            this.scrapingSmartphoneServices = scrapingSmartphoneServices;
            this.smartphoneServices = smartphoneServices;
        }


        //[Authorize]       
        public async Task<ActionResult> Test()
        {
            //sigInManager.IsSignedIn(User)
            var user = await this.userManger.GetUserAsync(this.User);


            //if (!await this.roleManger.RoleExistsAsync("Admin"))
            //{
            //    await this.roleManger.CreateAsync(new IdentityRole
            //    {
            //       Name = "Admin",
            //    });

            //}

            //var rezult = await this.userManger.AddToRoleAsync(user, "admin");

            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userId = userManger.GetUserAsync(this.User).Id;

            this.User.IsInRole("Admin");


            return this.View();
        }
        public IActionResult Index()
        {

            return this.View();
        }

        public IActionResult AddSmartphone()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult AddSmartphone(SmartphoneViewModel viewmodel)
        {
            if (viewmodel.Name != null)
            {
                smartphoneServices.AddSmartphone(viewmodel);

            }
            return this.Redirect("/Smartphone/All");
        }

        public IActionResult AddScraping()
        {


            return this.View();
        }
        [HttpPost]
        public IActionResult AddScraping(int start, int end)
        {
            //10000
            //10400
            
            scrapingSmartphoneServices.AddToDb(start, end);

            //scrapingSmartphoneServices.JustAdd();

            return Redirect("/");
        }

        public IActionResult Edit(int id)
        {
            Console.WriteLine();
            return this.View(smartphoneServices.GetSmartphoneById(id));
        }
        [HttpPost]
        public IActionResult Edit(SmartphoneViewModel sp)
        {

            smartphoneServices.Edit(sp);
            return this.Redirect("/Smartphone/All");
        }

        public IActionResult Delete(int id)
        {
            this.smartphoneServices.Delete(id);


            return this.Redirect("/Smartphone/All");
        }

    }
}
