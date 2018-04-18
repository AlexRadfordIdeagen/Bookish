using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish
{
    public class DetailedCheckout
    {
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string Title { get; set; }

        public string ReadableDueDate {
            get
            {
                return DueDate.ToShortDateString();
            }
        }
    }
}
