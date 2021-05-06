using FirstWebApp.Data;
using FirstWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Services
{
    public interface ISmartphoneServices
    {
        SmartphoneViewModel GetSmartphoneById(int id);

        IEnumerable<SmartphoneViewModel> GetSmartphonesForPages(int page, int itemsPerPage = 12);

        int GetCount();

         Task AddSmartphoneAsync(SmartphoneViewModel viewModel);

        public IEnumerable<SmartphoneViewModel> SearchByString(int page, string stringSearch ,int itemsPerPage = 12);

        public Task DeleteAsync(int id);

        public Task EditAsync(SmartphoneViewModel sp);

        public IEnumerable<SmartphoneViewModel> GetAll();
    }
}
