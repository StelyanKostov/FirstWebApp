using AutoMapper;
using FirstWebApp.Data;
using FirstWebApp.ViewModels.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Services.ContactServices
{
    public class ContactServices : IContactServices
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper _mapper;

        public ContactServices(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this._mapper = mapper;
        }
        public void AddMassageToDb(ContactInputModel input)
        {
           db.ContactMessages.Add(new ContactMessages()
            {
                name = input.name,
                email = input.email,
                text = input.text,
                phone = input.phone
            });

            db.SaveChanges();
        }

        public List<ContactInputModel> GetMessages()
        {
            var messages = db.ContactMessages.Where(x => x.seen != true).ToList();

            List<ContactInputModel> ms = _mapper.Map<List<ContactInputModel>>(messages);

            return ms;
           
        }

        public void ReadMS(int id)
        {
            var ms = db.ContactMessages.Where(x => x.Id == id).FirstOrDefault();

            ms.seen = true;

            db.SaveChanges();
        }
    }
}
