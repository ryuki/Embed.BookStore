using Embed.BookStore.API.Dtos.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.BookStore.API.Dtos.Book
{
    public class GetBookSummaryDto
    {
        public string ISBNCode { get; set; }
        public string bookName { get; set; }
        public string author { get; set; }
        public decimal priceMin { get; set; }
        public decimal priceMax { get; set; }

        public int totalStock { get; set; }
    }
}
