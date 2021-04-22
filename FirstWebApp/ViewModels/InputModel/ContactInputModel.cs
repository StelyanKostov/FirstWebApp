using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.ViewModels.InputModel
{
    public class ContactInputModel
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string text { get; set; }

        [Phone]
        public string phone { get; set; }

        public bool seen { get; set; }
    }
}
