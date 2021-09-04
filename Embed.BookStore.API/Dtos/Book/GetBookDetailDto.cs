using Embed.BookStore.API.Dtos.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.BookStore.API.Dtos.Book
{
    public class GetBookDetailDto
    {
        public string ISBNCode { get; set; }
        public string bookName { get; set; }
        public string author { get; set; }
        public List<GetBookInStoreDto> bookInStores { get; set; }
    }
    public class GetBookInStoreDto
    {
        public virtual GetStoreInfoDto store { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
    }

    public class GetStoreInfoDto
    {
        public Guid storeId { get; set; }
        public string storeName { get; set; }

    }
}
