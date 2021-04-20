using AngleSharp;
using FirstWebApp.Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstWebApp.Services.Scraping
{
    public class ScrapingSmartphoneServices : IScrapingSmartphoneServices
    {
        private readonly ApplicationDbContext db;

        public ScrapingSmartphoneServices(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddToModel(Smarphone smarphone, string categorydata, string typeData, string data)
        {
            if (categorydata == typeof(Model.Battery).Name)
            {


                smarphone.battery.Data.Add(typeData, data);

            }
            else if (categorydata == typeof(Model.Body).Name)
            {
                smarphone.body.bodyData.Add(typeData, data);

            }
            else if (categorydata == typeof(Comms).Name)
            {
                smarphone.commos.Data.Add(typeData, data);

            }
            else if (categorydata == typeof(Model.Display).Name)
            {
                smarphone.display.displayData.Add(typeData, data);

            }
            else if (categorydata == typeof(Model.Features).Name)
            {
                smarphone.features.Data.Add(typeData, data);

            }
            else if (categorydata == typeof(Launch).Name)
            {
                smarphone.Launch.lanchDate.Add(typeData, data);

            }
            else if (categorydata.ToLower() == "main camera")
            {
                smarphone.mainCamera.mainCameraData.Add(typeData, data);

            }
            else if (categorydata == typeof(Model.Memory).Name)
            {
                smarphone.memory.memoryData.Add(typeData, data);

            }
            else if (categorydata == typeof(Misc).Name)
            {
                smarphone.misc.Data.Add(typeData, data);

            }
            else if (categorydata == typeof(Model.Network).Name)
            {
                smarphone.network.networkdData.Add(typeData, data);

            }
            else if (categorydata == typeof(Platform).Name)
            {
                smarphone.platform.Data.Add(typeData, data);

            }
            else if (categorydata.ToLower() == "selfie camera")
            {
                smarphone.selfieCamera.selfieCameraData.Add(typeData, data);

            }
            else if (categorydata == typeof(Model.Sound).Name)
            {
                smarphone.sound.SoundData.Add(typeData, data);

            }
            else if (categorydata == typeof(Tests).Name)
            {
                smarphone.Tests.Data.Add(typeData, data);

            }
        }

        public string DownloadImgFromUrl(string url, string name)
        {
            if (name.Contains("+"))
            {
                name = name.Replace("+", " Plus");

            }
            var pathToImage = $@"C:\Users\kosto\source\repos\FirstWebApp\FirstWebApp\wwwroot\image\{name}.jpg";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(url), pathToImage);
                client.ResponseHeaders.Add("content-type: image/jpeg");

            }

            return pathToImage.Replace(@"C:\Users\kosto\source\repos\FirstWebApp\FirstWebApp\wwwroot", string.Empty);
        }

        public async Task<List<Smarphone>> ScrapingGetData(int start, int end)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            List<Smarphone> sp = new List<Smarphone>();
            for (int cc = start; cc < end; cc++)
            {
                Thread.Sleep(10000);
                var path = $"https://www.gsmarena.com/samsung_galaxy_s21_ultra_5g-{cc}.php";


                var document = await context.OpenAsync(path);

                var count = document.QuerySelectorAll("#specs-list > table").Length;

                var getPathToImg = document.QuerySelector("#body > div > div.review-header > div > div.center-stage.light.nobg.specs-accent > div > a > img");

                string urlToImg;
                try
                {
                    urlToImg = getPathToImg.GetAttribute("src");
                }
                catch (Exception)
                {

                    continue;
                }



                var nameOfSmarphone = document.QuerySelector("#body > div > div.review-header > div > div.article-info-line.page-specs.light.border-bottom > h1").TextContent;

                var pathToImage = DownloadImgFromUrl(urlToImg, nameOfSmarphone);

                Smarphone smarphone = new Smarphone();

                smarphone.image.path = pathToImage;
                smarphone.Name = nameOfSmarphone;


                for (int i = 3; i <= count + 3; i++)
                {

                    var dataCategory = document.QuerySelectorAll($"#specs-list > table:nth-child({i}) > tbody > tr > th");

                    foreach (var item in dataCategory)
                    {

                        var categorydata = item.TextContent;
                        var listTypeData = document.QuerySelectorAll($"#specs-list > table:nth-child({i}) > tbody > tr > td.ttl");

                        int j = 1;
                        var otherCount = 1;
                        foreach (var item1 in listTypeData)
                        {
                            var typeData = item1.TextContent;

                            var dataContext = document.QuerySelectorAll($"#specs-list > table:nth-child({i}) > tbody > tr:nth-child({j}) > td.nfo").FirstOrDefault();

                            var data = dataContext.TextContent;

                            if (string.IsNullOrWhiteSpace(typeData))
                            {
                                typeData = "other" + otherCount;
                                otherCount++;
                            }
                            AddToModel(smarphone, categorydata, typeData, data);


                            j++;
                        }
                        otherCount = 1;
                        j = 1;



                    }

                }
                sp.Add(smarphone);
            };

            return sp;
        }


        public void AddToDb(int start, int end)
        {
            var rezult = new List<Model.Smarphone>();
            try
            {
                rezult = ScrapingGetData(start, end).GetAwaiter().GetResult();
            }
            catch (Exception)
            {


            }
            List<Smartphone> smarphonesList = new List<Smartphone>();
            foreach (var sp in rezult)
            {
                var smartphone = new Data.Smartphone();
                smartphone.Name = sp.Name;
                var battery = new Data.Battery();
                battery.Type = sp.battery.Data.FirstOrDefault(x => x.Key == "Type").Value;
                battery.Charging = sp.battery.Data.FirstOrDefault(x => x.Key == "Charging").Value;
                battery.Other = sp.battery.Data.FirstOrDefault(x => x.Key == "Other").Value;
                smartphone.battery = battery;


                var body = new Data.Body();
                body.Dimensions = sp.body.bodyData.FirstOrDefault(x => x.Key == "Dimensions").Value;
                body.Other = sp.body.bodyData.FirstOrDefault(x => x.Key == "Other").Value;
                body.SIM = sp.body.bodyData.FirstOrDefault(x => x.Key == "SIM").Value;
                body.Weight = sp.body.bodyData.FirstOrDefault(x => x.Key == "Weight").Value;
                smartphone.body = body;


                var connect = new Data.Connect();
                connect.Bluetooth = sp.commos.Data.FirstOrDefault(x => x.Key == "Bluetooth").Value;
                connect.GPS = sp.commos.Data.FirstOrDefault(x => x.Key == "GPS").Value;
                connect.NFC = sp.commos.Data.FirstOrDefault(x => x.Key == "NFC").Value;
                connect.Other = sp.commos.Data.FirstOrDefault(x => x.Key == "Other").Value;
                connect.Radio = sp.commos.Data.FirstOrDefault(x => x.Key == "Radio").Value;
                connect.USB = sp.commos.Data.FirstOrDefault(x => x.Key == "USB").Value;
                connect.WLAN = sp.commos.Data.FirstOrDefault(x => x.Key == "WLAN").Value;
                smartphone.connect = connect;


                var date = new Data.Date();
                date.Announced = sp.Launch.lanchDate.FirstOrDefault(x => x.Key == "Announced").Value;
                date.Other = sp.Launch.lanchDate.FirstOrDefault(x => x.Key == "Other").Value;
                date.Status = sp.Launch.lanchDate.FirstOrDefault(x => x.Key == "Status").Value;
                smartphone.date = date;


                var display = new Data.Display();
                display.Other = sp.display.displayData.FirstOrDefault(x => x.Key == "Other").Value;
                display.Protection = sp.display.displayData.FirstOrDefault(x => x.Key == "Protection").Value;
                display.Resolution = sp.display.displayData.FirstOrDefault(x => x.Key == "Resolution").Value;
                display.Size = sp.display.displayData.FirstOrDefault(x => x.Key == "Size").Value;
                display.Type = sp.display.displayData.FirstOrDefault(x => x.Key == "Type").Value;
                smartphone.display = display;

                var features = new Data.Features();
                features.Other = sp.features.Data.FirstOrDefault(x => x.Key == "Other").Value;
                features.Sensors = sp.features.Data.FirstOrDefault(x => x.Key == "Sensors").Value;
                smartphone.features = features;


                var hardware = new Data.Hardware();
                hardware.Chipset = sp.platform.Data.FirstOrDefault(x => x.Key == "Chipset").Value;
                hardware.CPU = sp.platform.Data.FirstOrDefault(x => x.Key == "CPU").Value;
                hardware.GPU = sp.platform.Data.FirstOrDefault(x => x.Key == "GPU").Value;
                hardware.OS = sp.platform.Data.FirstOrDefault(x => x.Key == "OS").Value;
                hardware.Other = sp.platform.Data.FirstOrDefault(x => x.Key == "Other").Value;
                smartphone.hardware = hardware;

                var image = new Data.Image();
                image.Path = sp.image.path;
                smartphone.image = image;

                var mainCamera = new Data.MainCamera();
                mainCamera.Features = sp.mainCamera.mainCameraData.FirstOrDefault(x => x.Key == "Features").Value;
                mainCamera.Other = sp.mainCamera.mainCameraData.FirstOrDefault(x => x.Key == "Other").Value;
                mainCamera.Quad = sp.mainCamera.mainCameraData.FirstOrDefault(x => x.Key == "Quad").Value;
                mainCamera.Video = sp.mainCamera.mainCameraData.FirstOrDefault(x => x.Key == "Video").Value;
                smartphone.mainCamera = mainCamera;

                var memory = new Data.Memory();
                memory.CardSlot = sp.memory.memoryData.FirstOrDefault(x => x.Key == "CardSlot").Value;
                memory.Internal = sp.memory.memoryData.FirstOrDefault(x => x.Key == "Internal").Value;
                memory.Other = sp.memory.memoryData.FirstOrDefault(x => x.Key == "Other").Value;
                smartphone.memory = memory;

                var network = new Data.Network();
                network.Technology = sp.network.networkdData.FirstOrDefault(x => x.Key == "Technology").Value;
                network.TwoGBands = sp.network.networkdData.FirstOrDefault(x => x.Key == "2G bands").Value;
                network.TreeGBands = sp.network.networkdData.FirstOrDefault(x => x.Key == "3G bands").Value;
                network.FourGBands = sp.network.networkdData.FirstOrDefault(x => x.Key == "4G bands").Value;
                network.FiveGBands = sp.network.networkdData.FirstOrDefault(x => x.Key == "5G bands").Value;
                network.Speed = sp.network.networkdData.FirstOrDefault(x => x.Key == "Speed").Value;
                smartphone.network = network;

                var selfieCamera = new Data.SelfieCamera();
                selfieCamera.Features = sp.selfieCamera.selfieCameraData.FirstOrDefault(x => x.Key == "Features").Value;
                selfieCamera.Other = sp.selfieCamera.selfieCameraData.FirstOrDefault(x => x.Key == "Other").Value;
                selfieCamera.Single = sp.selfieCamera.selfieCameraData.FirstOrDefault(x => x.Key == "Single").Value;
                selfieCamera.Video = sp.selfieCamera.selfieCameraData.FirstOrDefault(x => x.Key == "Video").Value;
                smartphone.selfieCamera = selfieCamera;

                var sound = new Data.Sound();
                sound.Loudspeaker = sp.sound.SoundData.FirstOrDefault(x => x.Key == "Loudspeaker").Value;
                sound.Other = sp.sound.SoundData.FirstOrDefault(x => x.Key == "Other").Value;
                sound.TreeFiveMMJack = sp.sound.SoundData.FirstOrDefault(x => x.Key == "3.5mm jack").Value;
                smartphone.sound = sound;

                var view = new Data.View();
                view.Color = sp.misc.Data.FirstOrDefault(x => x.Key == "Color").Value;
                view.Models = sp.misc.Data.FirstOrDefault(x => x.Key == "Models").Value;
                view.Other = sp.misc.Data.FirstOrDefault(x => x.Key == "Other").Value;
                smartphone.view = view;



                smarphonesList.Add(smartphone);

            }

            db.AddRange(smarphonesList);
            db.SaveChanges();
        }
    }
}
