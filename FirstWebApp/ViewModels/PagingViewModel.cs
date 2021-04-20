using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.ViewModels
{
    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.CountSmartphones / this.ItemsPerPage);

        public int CountSmartphones { get; set; }

        public int ItemsPerPage { get; set; }

        public bool WitchSearch { get; set; }

        public string StringSearch { get; set; }
    }
}
