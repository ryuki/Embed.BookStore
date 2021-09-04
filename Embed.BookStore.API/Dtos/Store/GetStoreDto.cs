using Embed.BookStore.API.Dtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.BookStore.API.Dtos.Store
{
    public class GetStoreDto
    {
        public Guid storeId { get; set; }
        public string storeName { get; set; }
        public virtual List<GetBookDto> books { get; set; }

    }
}
