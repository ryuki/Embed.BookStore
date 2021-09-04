using Embed.BookStore.API.Dtos.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.BookStore.API.Dtos.Book
{
    public class GetBookDto
    {
        public string ISBNCode { get; set; }
        public string bookName { get; set; }
        public string author { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public virtual GetStoreDto store { get; set; }
    }
}
