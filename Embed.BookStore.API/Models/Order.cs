using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.BookStore.API.Models
{
    public class Order
    {
        public string ISBNCode { get; set; }
               
        public Guid storeId { get; set; }

        public string contactEmail { get; set; }
    }
}
