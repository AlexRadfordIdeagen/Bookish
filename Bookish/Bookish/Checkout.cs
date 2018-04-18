using System;

namespace Bookish
{
    public class Checkout
    {
        public string CheckoutId { get; set; }
        public string UserId { get; set; }
        public string TitleId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
