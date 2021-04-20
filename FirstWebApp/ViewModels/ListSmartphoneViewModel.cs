using FirstWebApp.ViewModels.ComparisonSmartViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.ViewModels
{
    public class ListSmartphoneViewModel : PagingViewModel 
    {       
        public IEnumerable<SmartphoneViewModel> listSmartphoneViewModels { get; set; }

        public ListComparisonSmartphoneViewModel ComparisonSmartphones { get; set; }

    }
}
