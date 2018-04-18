using System;
using System.Collections.Generic;
using System.Linq;
namespace Bookish.Web.Models.HomeViewModels
{
    public class HomeBooksViewModel
    {
        public List<Book> Books { get; set; }
        public bool IsLoggedIn { get; set; }

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public HomeBooksViewModel(List<Book> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Books = items;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static HomeBooksViewModel Create(List<Book> books, int pageIndex, int pageSize)
        {
            var items = books.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new HomeBooksViewModel(items, books.Count, pageIndex, pageSize);
        }
    }
}
