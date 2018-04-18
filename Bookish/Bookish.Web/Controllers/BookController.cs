using Microsoft.AspNetCore.Mvc;
using Bookish.Web.Models;
using Bookish.Web.Models.BookViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Bookish.Web.Controllers
{
    [Authorize]
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

            var availableAmount = book.NoOfBooks - dAccessish.GetNumberOfCheckedOut(book.TitleId);

            var dueDate = dAccessish.GetFirstDueDate(book.TitleId);

            var returningUser = dAccessish.GetFirstUserReturningBook(book.TitleId);

            return View(new BookViewModel()
            {
                TitleId = book.TitleId,
                NoOfBooks = book.NoOfBooks,
                Author = book.Author,
                Title = book.Title,
                ISBN = book.ISBN,
                cover = book.cover,
                Available = availableAmount,
                DueDate = dueDate,
                ReturningUser = returningUser
            });
        }
    }
}
