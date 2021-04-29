using FirstWebApp.Services;
using FirstWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers
{
    public class ComparisonController : Controller
    {
        private readonly ISmartphoneServices smartphoneServices;

        public ComparisonController(ISmartphoneServices smartphoneServices)
        {
            this.smartphoneServices = smartphoneServices;
        }
        public IActionResult AddForComparison(int id)
        {
            //Request.Host.Value
            if (this.HttpContext.Session.Get("Card") == null)
            {
                this.HttpContext.Session.SetString("Card", id.ToString());

            }
            else if (this.HttpContext.Session.Get("Card2") == null)
            {
                this.HttpContext.Session.SetString("Card2", id.ToString());

            }
            else if (this.HttpContext.Session.Get("Card3") == null)
            {
                this.HttpContext.Session.SetString("Card3", id.ToString());

            }


            //this.HttpContext.Session.SetString("Card", JsonConvert.SerializeObject(id.ToString()));

            //this.ViewData["Card"] = this.HttpContext.Session.GetString("Card") == null ? null : JsonConvert.DeserializeObject(this.HttpContext.Session.GetString("Card"));


            return this.Redirect("/Smartphone/All");
        }

        public IActionResult Comparison()
        {
            var viewModel = new ViewModels.ComparisonSmartViewModel.ListComparisonSmartphoneViewModel();
            viewModel.comparisonSmartphoneViewModels = new List<SmartphoneViewModel>();
            if (this.HttpContext.Session.Get("Card") != null)
            {

                var comparisonId = int.Parse(this.HttpContext.Session.GetString("Card"));
                viewModel.comparisonSmartphoneViewModels.Add(smartphoneServices.GetSmartphoneById(comparisonId));
            }
            if (this.HttpContext.Session.Get("Card2") != null)
            {

                var comparisonId = int.Parse(this.HttpContext.Session.GetString("Card2"));
                viewModel.comparisonSmartphoneViewModels.Add(smartphoneServices.GetSmartphoneById(comparisonId));
            }
            if (this.HttpContext.Session.Get("Card3") != null)
            {

                var comparisonId = int.Parse(this.HttpContext.Session.GetString("Card3"));
                viewModel.comparisonSmartphoneViewModels.Add(smartphoneServices.GetSmartphoneById(comparisonId));
            }
            return this.View(viewModel);
        }

       public IActionResult RemoveFromComparison(int id)
        {
            if (this.HttpContext.Session.GetString("Card") == id.ToString())
            {
                this.HttpContext.Session.Remove("Card");
            }
            else if (this.HttpContext.Session.GetString("Card2") == id.ToString())
            {
                this.HttpContext.Session.Remove("Card2");

            }
            else if (this.HttpContext.Session.GetString("Card3") == id.ToString())
            {
                this.HttpContext.Session.Remove("Card3");
            }

            return this.Redirect("/Smartphone/All");
        }
    }
}
