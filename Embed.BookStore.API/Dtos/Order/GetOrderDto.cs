using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.BookStore.API.Dtos.Order
{
    public class GetOrderDto
    {
        public string ISBNCode { get; set; }

        public Guid storeId { get; set; }

        public string contactEmail { get; set; }
    }
}
