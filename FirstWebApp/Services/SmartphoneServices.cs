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

            var sp = db.Smartphones.Include(x => x.image).Include(x=> x.hardware).ToList();
             //.Include(x => x.battery)
             //.Include(x => x.body)
             //.Include(x => x.connect)
             //.Include(x => x.date)
             //.Include(x => x.display)
             //.Include(x => x.features)
             //.Include(x => x.hardware)
             //.Include(x => x.image)
             //.Include(x => x.mainCamera)
             //.Include(x => x.memory)
             //.Include(x => x.network)
             //.Include(x => x.selfieCamera)
             //.Include(x => x.sound)
             //.Include(x => x.view).ToList();



            List<SmartphoneViewModel> smartphone = _mapper.Map<List<SmartphoneViewModel>>(sp);

            return smartphone;
        }

        public IEnumerable<SmartphoneViewModel> GetSmartphonesForPages(int page, int itemsPerPage)
        {

            var smartphone = this.GetAll();


            return smartphone.OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
        }

        public IEnumerable<SmartphoneViewModel> SearchByString(int page, string stringSearch, int itemsPerPage)
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
