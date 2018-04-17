using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bookish.Web.Models;
using Bookish;
using Bookish.Web.Models.BookViewModels;
using Bookish.Web.Models.HomeViewModels;
using Bookish.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Bookish.Web.Controllers
{

    public class BookController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private BookAccessish dAccessish = new BookAccessish();

        public BookController(
            SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult ISBN(string isbn)
        {
            var book = dAccessish.GetBook(isbn);

            return View(new BookViewModel()
            {
                TitleId = book.TitleId,
                NoOfBooks = book.NoOfBooks,
                Author = book.Author,
                Title = book.Title,
                ISBN =  book.ISBN,
                cover = book.cover

            });
        }

    }
}
