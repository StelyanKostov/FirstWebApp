using AutoMapper;
using FirstWebApp.Data;
using FirstWebApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Services
{
    public class SmartphoneServices : ISmartphoneServices
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public SmartphoneServices(ApplicationDbContext db,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            this._mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IEnumerable<SmartphoneViewModel> GetAll()
        {

            var sp = db.Smartphones
             .Include(x => x.battery)
             .Include(x => x.body)
             .Include(x => x.connect)
             .Include(x => x.date)
             .Include(x => x.display)
             .Include(x => x.features)
             .Include(x => x.hardware)
             .Include(x => x.image)
             .Include(x => x.mainCamera)
             .Include(x => x.memory)
             .Include(x => x.network)
             .Include(x => x.selfieCamera)
             .Include(x => x.sound)
             .Include(x => x.view).ToList();



            List<SmartphoneViewModel> smartphone = _mapper.Map<List<SmartphoneViewModel>>(sp);

            return smartphone;
        }

        public IEnumerable<SmartphoneViewModel> GetSmartphonesForPages(int page, int itemsPerPage = 12)
        {

            var smartphone = this.GetAll();

            //var smartphone = db.Smartphones.AsNoTracking().Select(x => new SmartphoneViewModel
            //{
            //    Name = x.Name,
            //    Id = x.Id,
            //    battery = new ViewModels.Battery()
            //    {
            //        Charging = x.battery.Charging,
            //        Type = x.battery.Type,
            //        Other = x.battery.Other
            //    },
            //    body = new ViewModels.Body()
            //    {
            //        Dimensions = x.body.Dimensions,
            //        Other = x.body.Other,
            //        SIM = x.body.SIM,
            //        Weight = x.body.Weight
            //    },
            //    connect = new ViewModels.Connect()
            //    {
            //        GPS = x.connect.GPS,
            //        USB = x.connect.USB,
            //        Bluetooth = x.connect.Bluetooth,
            //        NFC = x.connect.NFC,
            //        Other = x.connect.Other,
            //        Radio = x.connect.Radio,
            //        WLAN = x.connect.WLAN
            //    },
            //    date = new ViewModels.Date()
            //    {
            //        Announced = x.date.Announced,
            //        Other = x.date.Other,
            //        Status = x.date.Status
            //    },
            //    display = new ViewModels.Display()
            //    {
            //        Other = x.display.Other,
            //        Size = x.display.Size,
            //        Protection = x.display.Protection,
            //        Resolution = x.display.Resolution,
            //        Type = x.display.Type
            //    },
            //    features = new ViewModels.Features()
            //    {
            //        Other = x.features.Other,
            //        Sensors = x.features.Sensors
            //    },
            //    hardware = new ViewModels.Hardware()
            //    {
            //        Chipset = x.hardware.Chipset,
            //        OS = x.hardware.OS,
            //        CPU = x.hardware.CPU,
            //        GPU = x.hardware.GPU,
            //        Other = x.hardware.Other
            //    },
            //    image = new ViewModels.Image()
            //    {
            //        Path = x.image.Path
            //    },
            //    mainCamera = new ViewModels.MainCamera()
            //    {
            //        Features = x.mainCamera.Features,
            //        Other = x.mainCamera.Other,
            //        Quad = x.mainCamera.Quad,
            //        Video = x.mainCamera.Video
            //    },
            //    memory = new ViewModels.Memory()
            //    {
            //        CardSlot = x.memory.CardSlot,
            //        Internal = x.memory.Internal,
            //        Other = x.memory.Other

            //    },
            //    network = new ViewModels.Network()
            //    {
            //        FiveGBands = x.network.FiveGBands,
            //        Speed = x.network.Speed,
            //        FourGBands = x.network.FourGBands,
            //        Other = x.network.Other,
            //        Technology = x.network.Technology,
            //        TreeGBands = x.network.TreeGBands,
            //        TwoGBands = x.network.TwoGBands
            //    },
            //    selfieCamera = new ViewModels.SelfieCamera()
            //    {
            //        Single = x.selfieCamera.Single,
            //        Features = x.selfieCamera.Features,
            //        Other = x.selfieCamera.Other,
            //        Video = x.selfieCamera.Video
            //    },
            //    sound = new ViewModels.Sound()
            //    {
            //        Loudspeaker = x.sound.Loudspeaker,
            //        Other = x.sound.Other,
            //        TreeFiveMMJack = x.sound.TreeFiveMMJack

            //    },
            //    view = new ViewModels.View()
            //    {
            //        Color = x.view.Color,
            //        Models = x.view.Models,
            //        Other = x.view.Other
            //    }



            //}).OrderByDescending(x => x.Id).Skip((page -1) * itemsPerPage).Take(itemsPerPage).ToList();

            return smartphone.OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
        }

        public IEnumerable<SmartphoneViewModel> SearchByString(int page, string stringSearch, int itemsPerPage = 12)
        {
            var sp = db.Smartphones
              .Include(x => x.battery)
              .Include(x => x.body)
              .Include(x => x.connect)
              .Include(x => x.date)
              .Include(x => x.display)
              .Include(x => x.features)
              .Include(x => x.hardware)
              .Include(x => x.image)
              .Include(x => x.mainCamera)
              .Include(x => x.memory)
              .Include(x => x.network)
              .Include(x => x.selfieCamera)
              .Include(x => x.sound)
              .Include(x => x.view).Where(x => x.Name.Contains(stringSearch)).ToList();


            List<SmartphoneViewModel> smartphone = _mapper.Map<List<SmartphoneViewModel>>(sp);

            return smartphone.OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
        }

        public int GetCount()
        {
            return this.db.Smartphones.Count();
        }
        public async Task AddSmartphoneAsync(SmartphoneViewModel viewModel)
        {
            Console.WriteLine();
            if (viewModel.image != null)
            {
                var path = $@"{this.webHostEnvironment.WebRootPath}/image/" + viewModel.image.fullInfo.FileName;
                using (Stream fileStream = new FileStream(path, FileMode.Create))
                {
                    viewModel.image.fullInfo.CopyTo(fileStream);
                }
                viewModel.image.Path = @"/image/" + viewModel.image.fullInfo.FileName;
            }


            var smartphone = _mapper.Map<Smartphone>(viewModel);
            await this.db.AddAsync(smartphone);
            await this.db.SaveChangesAsync();
        }

        public Smartphone getSmartphone(int id)
        {
            var sp = db.Smartphones.Where(x => x.Id == id)
               .Include(x => x.battery)
               .Include(x => x.body)
               .Include(x => x.connect)
               .Include(x => x.date)
               .Include(x => x.display)
               .Include(x => x.features)
               .Include(x => x.hardware)
               .Include(x => x.image)
               .Include(x => x.mainCamera)
               .Include(x => x.memory)
               .Include(x => x.network)
               .Include(x => x.selfieCamera)
               .Include(x => x.sound)
               .Include(x => x.view)
               .FirstOrDefault();
            return sp;
        }

        public async Task EditAsync(SmartphoneViewModel sp)
        {
            var smartphone = getSmartphone(sp.Id);


            var path = $@"{this.webHostEnvironment.WebRootPath}/image/" + sp.image.fullInfo.FileName;
            using (Stream fileStream = new FileStream(path, FileMode.Create))
            {
                sp.image.fullInfo.CopyTo(fileStream);
            }
            sp.image.Path = @"/image/" + sp.image.fullInfo.FileName;



            _mapper.Map(sp, smartphone);

           await db.SaveChangesAsync();
        }

        public SmartphoneViewModel GetSmartphoneById(int id)
        {
            var sp = this.getSmartphone(id);
            var smartphone = _mapper.Map<SmartphoneViewModel>(sp);
            return smartphone;
        }

        public async Task DeleteAsync(int id)
        {
            var sp = this.getSmartphone(id);
            db.Remove(sp);
            await db.SaveChangesAsync();
        }
    }
}
