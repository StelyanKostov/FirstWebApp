using FirstWebApp.Services.ContactServices;
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
    public class ContactController : Controller
    {
        private readonly IContactServices contactServices;

        public ContactController(IContactServices contactServices)
        {
            this.contactServices = contactServices;
        }

        public IActionResult Messages()
        {
            var ms = contactServices.GetMessages();
            return this.View(ms);
        }

        public IActionResult ReadMessages(int id)
        {
            contactServices.ReadMS(id);
            return this.RedirectToAction("Messages");
        }
    }
}
