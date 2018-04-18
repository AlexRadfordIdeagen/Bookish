using System;
using System.Collections.Generic;

namespace Bookish.Web.Models.HomeViewModels
{
    public class HomeBooksViewModel
    {
        public List<Book> Books { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
