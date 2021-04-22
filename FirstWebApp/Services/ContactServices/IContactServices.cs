using FirstWebApp.ViewModels.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Services.ContactServices
{
    public interface IContactServices
    {

        public void AddMassageToDb(ContactInputModel input);

        public List<ContactInputModel> GetMessages();

        public void ReadMS(int id);
        


    }
}
