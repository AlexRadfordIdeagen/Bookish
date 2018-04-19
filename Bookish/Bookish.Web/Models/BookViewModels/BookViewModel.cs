using System.ComponentModel.DataAnnotations;

namespace Bookish.Web.Models.BookViewModels
{
    public class BookViewModel
    {
        public string TitleId { get; set; }
        public int NoOfBooks { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string cover { get; set; }
        public string DueDate { get; set; }
        public string ReturningUser { get; set; }
        public int Available { get; set; }
    }
}
