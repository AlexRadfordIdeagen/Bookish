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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Bookish.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private BookAccessish dAccessish = new BookAccessish();

        public HomeController(
            SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View(new HomeBooksViewModel()
            {
               Books = dAccessish.GetBooks(),
                IsLoggedIn = _signInManager.IsSignedIn(User)
            });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                ISBN = book.ISBN,
                cover = book.cover
            });
        }
    }
}
