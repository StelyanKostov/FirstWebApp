using FirstWebApp.Services.ContactServices;
using FirstWebApp.ViewModels.InputModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactServices contactServices;

        public ContactController(IContactServices contactServices)
        {
            this.contactServices = contactServices;
        }
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Index(ContactInputModel input)
        {
            if (!ModelState.IsValid)
            {
                TempData["Success"] = false;

                return this.View();
            }
            
            contactServices.AddMassageToDb(input);
            return this.RedirectToAction("ContactMessageRezult");
        }

        public IActionResult ContactMessageRezult()
        {
           
            return this.View();
        }
    }
}
