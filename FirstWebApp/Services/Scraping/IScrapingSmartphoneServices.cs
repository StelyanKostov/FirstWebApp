using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Services.Scraping
{
    public interface IScrapingSmartphoneServices
    {
        Task<List<Smarphone>> ScrapingGetData(int start, int end);

        void AddToModel(Smarphone smarphone, string categorydata, string typeData, string data);

        string DownloadImgFromUrl(string url, string name);

        void AddToDb(int start, int end);

        
    }
}
