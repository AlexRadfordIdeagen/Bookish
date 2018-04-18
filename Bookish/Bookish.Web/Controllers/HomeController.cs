using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Web.Models;
using Bookish.Web.Models.BookViewModels;
using Bookish.Web.Models.HomeViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Bookish.Web.Models.AccountViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Index(string searchString, int? page, string currentFilter)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var books = dAccessish.GetBooks();
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(    
                    book => {
                        return book.Title.ToLower().Contains(searchString.ToLower())
                        || book.Author.ToLower().Contains(searchString.ToLower());
                    }).ToList();
            }
            books = books.OrderBy(book => book.Title).ToList();
            return View(HomeBooksViewModel.Create(books, page ?? 1, 3));
        }

        public IActionResult YourAccount()
        {
            var checkouts = dAccessish.GetCheckout(
                _signInManager.UserManager.GetUserId(User)
            );

            return View(new YourAccountViewModel()
            {
                Checkouts = checkouts,
            });
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
