using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.BookStore.API.Dtos.Order
{
    public class SetOrderDto
    {
        [Required]
        public string ISBNCode { get; set; }

        [Required]
        public Guid storeId { get; set; }

        [Required]
        public string contactEmail { get; set; }
    }
}
