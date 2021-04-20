using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.ViewModels.ComparisonSmartViewModel
{
    public class ListComparisonSmartphoneViewModel
    {

        public List<SmartphoneViewModel> comparisonSmartphoneViewModels { get; set; }
            

        public int Count => comparisonSmartphoneViewModels.Count();

        public bool Have => Count > 0 ? true : false; 
    }
}
