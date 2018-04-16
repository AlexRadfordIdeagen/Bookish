using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookish.Web.Models.HomeViewModels
{
    public class HomeBooksViewModel
    {
        public List<Book> Books { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
