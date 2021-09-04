using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.BookStore.API.Models
{
    public class Store
    {
        public Guid storeId { get; set; }
        public string storeName { get; set; }
        public virtual List<Book> books { get; set; }
    }
}
