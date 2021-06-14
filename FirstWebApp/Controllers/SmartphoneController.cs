using AutoMapper;
using FirstWebApp.Services;
using FirstWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers
{

    public class SmartphoneController : Controller
    {
        const int ItemsPerPage = 24;
        private readonly ISmartphoneServices smartphoneServices;


        public SmartphoneController(ISmartphoneServices smartphoneServices)
        {
            this.smartphoneServices = smartphoneServices;

        }

        public IActionResult ById(int id)
        {
            var viewmodel = smartphoneServices.GetSmartphoneById(id);
            return this.View(viewmodel);
        }
        public IActionResult AllDemo(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }
            const int ItemsPerPage = 3;
            var viewModel = new ListSmartphoneViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                listSmartphoneViewModels = smartphoneServices.GetSmartphonesForPages(id, ItemsPerPage),
                CountSmartphones = smartphoneServices.GetCount(),

            };

            return this.View(viewModel);
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }
            
            var viewModel = new ListSmartphoneViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                listSmartphoneViewModels = smartphoneServices.GetSmartphonesForPages(id, ItemsPerPage),
                CountSmartphones = smartphoneServices.GetCount(),
                WitchSearch = false,
                ComparisonSmartphones = new ViewModels.ComparisonSmartViewModel.ListComparisonSmartphoneViewModel()
                {
                    comparisonSmartphoneViewModels = new List<SmartphoneViewModel>()

                }

            };

            if (this.HttpContext.Session.Get("Card") != null)
            {

                var comparisonId = int.Parse(this.HttpContext.Session.GetString("Card"));
                viewModel.ComparisonSmartphones.comparisonSmartphoneViewModels.Add(smartphoneServices.GetSmartphoneById(comparisonId));
            }
            if (this.HttpContext.Session.Get("Card2") != null)
            {

                var comparisonId = int.Parse(this.HttpContext.Session.GetString("Card2"));
                viewModel.ComparisonSmartphones.comparisonSmartphoneViewModels.Add(smartphoneServices.GetSmartphoneById(comparisonId));
            }
            if (this.HttpContext.Session.Get("Card3") != null)
            {

                var comparisonId = int.Parse(this.HttpContext.Session.GetString("Card3"));
                viewModel.ComparisonSmartphones.comparisonSmartphoneViewModels.Add(smartphoneServices.GetSmartphoneById(comparisonId));
            }




            return this.View(viewModel);
        }

        public IActionResult Search(string stringSearch, int id = 1)
        {

            if (id <= 0)
            {
                return this.NotFound();
            }
            var viewModel = new ListSmartphoneViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                listSmartphoneViewModels = smartphoneServices.SearchByString(id, stringSearch, ItemsPerPage),
                CountSmartphones = smartphoneServices.GetCount(),
                WitchSearch = true,
                StringSearch = stringSearch,

            };

            viewModel.CountSmartphones = viewModel.listSmartphoneViewModels.Count();

            return this.View(viewModel);
        }
        
    }
}
