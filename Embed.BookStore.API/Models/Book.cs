using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Embed.BookStore.API.Models
{
    public class Book
    {
        public string ISBNCode { get; set; }

        public string bookName { get; set; }

        public string author { get; set; }

        public decimal price { get; set; }

        public int stock { get; set; }
        public Store store { get; set; }
    }
}
